Imports nonskinupgrade.Repository
Imports nonskinupgrade.RunningProcess
Imports System.Linq

Public Class NewOrder

    Dim repo As New Repository

    Private Sub NewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Control.CheckForIllegalCrossThreadCalls = False
        bgwNewOrder.WorkerSupportsCancellation = True

        checkStatus()

    End Sub

    Private Sub checkStatus()
        If randomUploadStatus = False Then
            btnStop.Enabled = False
            btnRun.Enabled = True
            txtfname.Enabled = True
            txtlname.Enabled = True
            btnReset.Enabled = True
            btnUpload.Enabled = True
            lblStatus.Text = "# this allows program to random upload new orders"
        Else
            btnStop.Enabled = True
            btnRun.Enabled = False
            txtfname.Enabled = False
            txtlname.Enabled = False
            btnReset.Enabled = False
            btnUpload.Enabled = False
            lblStatus.Text = "Random upload is running in process...."
        End If
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        randomUploadStatus = False
        checkStatus()
        bgwNewOrder.CancelAsync()
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        randomUploadStatus = True
        checkStatus()
        bgwNewOrder.RunWorkerAsync()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtfname.Clear()
        txtlname.Clear()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim fname As String
        Dim lname As String
        Dim id As Integer
        If String.IsNullOrEmpty(txtfname.Text) Or String.IsNullOrEmpty(txtlname.Text) Then
            MsgBox("Please fill in the blanks before uploading.")
        Else
            fname = txtfname.Text
            lname = txtlname.Text
            id = repo.getId() + 1
            repo.uploadOrder(id, fname, lname)
            MessageBox.Show("New actor with ID of " & id & " is added!")
        End If
    End Sub

    Private Sub bgwNewOrder_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwNewOrder.DoWork
        Do Until randomUploadProcess = 11
            System.Threading.Thread.Sleep(1000)
            randomUploadProcess = randomUploadProcess + 1

            If bgwNewOrder.CancellationPending Or randomUploadProcess = 11 Or connected = False Then
                e.Cancel = True
                Return
            End If
        Loop
    End Sub

    Private Sub bgwNewOrder_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwNewOrder.RunWorkerCompleted
        If randomUploadProcess < 11 And connected = True Then
            MsgBox("Random Upload is stopped.")
            randomUploadProcess = 0
            randomUploadStatus = False
            checkStatus()
        ElseIf randomUploadProcess = 11 Then
            repo.randomUploadOrder()
            randomUploadProcess = 0
            bgwNewOrder.RunWorkerAsync()
        ElseIf randomUploadProcess < 11 And connected = False Then
            randomUploadStatus = False
            randomUploadProcess = 0
            MsgBox("Random Upload is stopped since mysql is disconnected.")
            checkStatus()
        End If
    End Sub
End Class