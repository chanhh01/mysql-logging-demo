Imports nonskinupgrade.Repository
Imports System.IO.File
Imports System.IO
Imports System.Windows.Documents
Imports nonskinupgrade.RunningProcess
Imports nonskinupgrade.DataTables

Public Class Log

    Dim repo As New Repository
    Dim prev_insert_date As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
    Dim prev_update_date As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

    Private Sub Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Control.CheckForIllegalCrossThreadCalls = False
        bgwLog.WorkerSupportsCancellation = True

        ' determine the image of picturebox that can be interacted to turn live monitor on or off
        checkImage()
        
        repo.createUpdateTrigger()

        If repo.isExistUpdateLogTable() = False Then
            repo.createUpdateLogTable()
        End If

        Dim orderlogname As String = ""
        Dim ranklogname As String = ""

        Dim log As Object = repo.displayLog(orderlogname, ranklogname)
        Dim orderlogsplit() As String
        Dim ranklogsplit() As String

        lblOrderLog.Text = orderlogname
        lblRankingLog.Text = ranklogname

        orderlogsplit = log(0).ToString.Split(New String() {" >>", vbCrLf}, StringSplitOptions.None)
        ranklogsplit = log(1).ToString.Split(New String() {" >>", vbCrLf}, StringSplitOptions.None)

        For i As Integer = 0 To orderlogsplit.Length - 1 Step 1
            If i Mod 2 = 0 Then
                rtxtLogOrder.SelectionColor = Color.Black
                If Not String.IsNullOrEmpty(orderlogsplit(i)) Then
                    rtxtLogOrder.SelectedText = orderlogsplit(i) & " >>"
                    prev_insert_date = orderlogsplit(i)
                End If
            Else
                If orderlogsplit(i).StartsWith(" Error:", StringComparison.OrdinalIgnoreCase) Then
                    rtxtLogOrder.SelectionColor = Color.Red
                    rtxtLogOrder.SelectedText = orderlogsplit(i) & vbCrLf
                Else
                    rtxtLogOrder.SelectionColor = Color.Green
                    rtxtLogOrder.SelectedText = orderlogsplit(i) & vbCrLf
                End If
            End If
        Next

        For j As Integer = 0 To ranklogsplit.Length - 1 Step 1
            If j Mod 2 = 0 Then
                rtxtLogRanking.SelectionColor = Color.Black
                If Not String.IsNullOrEmpty(ranklogsplit(j)) Then
                    rtxtLogRanking.SelectedText = ranklogsplit(j) & " >>"
                    prev_update_date = ranklogsplit(j)
                End If
            Else
                If ranklogsplit(j).StartsWith(" Error:", StringComparison.OrdinalIgnoreCase) Then
                    rtxtLogRanking.SelectionColor = Color.Red
                    rtxtLogRanking.SelectedText = ranklogsplit(j) & vbCrLf
                Else
                    rtxtLogRanking.SelectionColor = Color.Green
                    rtxtLogRanking.SelectedText = ranklogsplit(j) & vbCrLf
                End If
            End If
        Next
    End Sub

    Private Sub checkImage()
        If monitorChangeStatus = True Then
            pbMonitor.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Image\updated.png")
            pbMonitor.ImageLocation = My.Application.Info.DirectoryPath & "\Image\updated.png"
        Else
            pbMonitor.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Image\refresh.png")
            pbMonitor.ImageLocation = My.Application.Info.DirectoryPath & "\Image\refresh.png"
        End If
    End Sub

    Private Sub pbMonitor_Click(sender As Object, e As EventArgs) Handles pbMonitor.Click
        If Path.GetFileName(pbMonitor.ImageLocation) = "updated.png" Then
            pbMonitor.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Image\refresh.png")
            pbMonitor.ImageLocation = My.Application.Info.DirectoryPath & "\Image\refresh.png"
            'here stops monitoring
            bgwLog.CancelAsync()

        ElseIf Path.GetFileName(pbMonitor.ImageLocation) = "refresh.png" Then
            pbMonitor.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\Image\updated.png")
            pbMonitor.ImageLocation = My.Application.Info.DirectoryPath & "\Image\updated.png"
            'here starts monitoring
            MsgBox("Log live update started.")
            monitorChangeStatus = True
            If IsNothing(dataTable_prevUpdate) Then
                dataTable_prevUpdate = repo.populateDataTable_prev(prev_update_date, 1)
            End If
            If IsNothing(dataTable_prevInsert) Then
                dataTable_prevInsert = repo.populateDataTable_prev(prev_insert_date, 0)
            End If
            If Not IsNothing(dataTable_prevInsert) And Not IsNothing(dataTable_prevUpdate) Then
                bgwLog.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bgwLog_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwLog.DoWork
        ' after some amount of time, allow the program to compare two data table, if got difference then update the table
        ' and also extract the new rows to be logged into richtextbox as well as the txt file
        Do Until monitorChangeProcess = 6
            System.Threading.Thread.Sleep(1000)
            monitorChangeProcess = monitorChangeProcess + 1

            If bgwLog.CancellationPending Or monitorChangeProcess = 6 Or connected = False Then
                e.Cancel = True
                Return
            End If
        Loop
    End Sub

    Private Sub bgwLog_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwLog.RunWorkerCompleted
        If monitorChangeProcess < 6 And connected = True Then
            MsgBox("Log live update stopped.")
            monitorChangeStatus = False
            monitorChangeProcess = 0
        ElseIf monitorChangeProcess = 6 Then
            monitorChangeProcess = 0
            dataTable_afterInsert = repo.populateDataTable_after(0)
            dataTable_afterUpdate = repo.populateDataTable_after(1)
            'compare data tables
            updateNewLog()
            bgwLog.RunWorkerAsync()
        ElseIf monitorChangeProcess < 6 And connected = False Then
            monitorChangeStatus = False
            monitorChangeProcess = 0
            checkImage()
            MsgBox("Log live update stopped since mysql is disconnected.")
        End If
    End Sub

    Private Sub updateNewLog()
        Dim updateLog() As String = New String() {}
        updateLog = repo.monitorUpdate(dataTable_prevUpdate, dataTable_afterUpdate)
        Dim insertLog() As String = New String() {}
        insertLog = repo.monitorInsert(dataTable_prevInsert, dataTable_afterInsert)

        Dim updateLogSplit() As String = New String() {}
        Dim insertLogSplit() As String = New String() {}

        If updateLog IsNot Nothing Then
            For i As Integer = 0 To updateLog.Length - 1
                updateLogSplit = updateLog(i).Split(New String() {" >>", vbCrLf}, StringSplitOptions.None)
                repo.appendFile(Nothing, updateLog(i), 1)
                rtxtLogRanking.SelectionColor = Color.Black
                rtxtLogRanking.SelectedText = updateLogSplit(0) & " >>"
                If updateLogSplit(1).StartsWith(" Error:", StringComparison.OrdinalIgnoreCase) Then
                    rtxtLogRanking.SelectionColor = Color.Red
                    rtxtLogRanking.SelectedText = updateLogSplit(1) & vbCrLf
                Else
                    rtxtLogRanking.SelectionColor = Color.Green
                    rtxtLogRanking.SelectedText = updateLogSplit(1) & vbCrLf
                End If
            Next
            dataTable_prevUpdate = dataTable_afterUpdate.Copy()
        End If

        If insertLog IsNot Nothing Then
            For j As Integer = 0 To insertLog.Length - 1
                insertLogSplit = insertLog(j).Split(New String() {" >>", vbCrLf}, StringSplitOptions.None)
                repo.appendFile(insertLog(j), Nothing, 0)
                rtxtLogOrder.SelectionColor = Color.Black
                rtxtLogOrder.SelectedText = insertLogSplit(0) & " >>"
                If insertLogSplit(1).StartsWith(" Error:", StringComparison.OrdinalIgnoreCase) Then
                    rtxtLogOrder.SelectionColor = Color.Red
                    rtxtLogOrder.SelectedText = insertLogSplit(1) & vbCrLf
                Else
                    rtxtLogOrder.SelectionColor = Color.Green
                    rtxtLogOrder.SelectedText = insertLogSplit(1) & vbCrLf
                End If
            Next
            dataTable_prevInsert = dataTable_afterInsert.Copy()
        End If
    End Sub
End Class