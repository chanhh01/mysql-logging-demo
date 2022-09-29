Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports nonskinupgrade.Connection
Imports nonskinupgrade.RunningProcess
Imports nonskinupgrade.DataTables
Imports nonskinupgrade.Model
Imports System.Linq

Public Class Repository

    Dim MySqlConn As New MySqlConnection
    Dim sqlstr As String = ""
    Dim dttable As DataTable = Nothing
    Dim out As String = ""

    Public Function testConnection() As Boolean
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = conn
        Try
            MySqlConn.Open()
            MsgBox("The connection is successful!")
            Return True
            MySqlConn.Dispose()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    'This one displays the log by reading the log txt file
    Public Function displayLog(ByRef orderlogname As String, ByRef ranklogname As String) As Object
        Dim orderlog As String = ""
        Dim rankinglog As String = ""
        Dim currentMonth As String = DateTime.Now.ToString("yyyy-MM")
        Dim dateSplit() As String = New String() {}
        Dim orderlogpath As String = ""
        Dim rankinglogpath As String = ""

        Dim orderdi As New DirectoryInfo(My.Application.Info.DirectoryPath & "\OrderLogs")
        Dim rankingdi As New DirectoryInfo(My.Application.Info.DirectoryPath & "\RankingLogs")
        Dim orderfiArr As FileInfo() = orderdi.GetFiles()
        Dim rankingfiArr As FileInfo() = rankingdi.GetFiles()
        Dim orderfri As FileInfo
        Dim rankingfri As FileInfo

        For Each orderfri In orderfiArr
            dateSplit = orderfri.Name.Split("_")
            If orderfri IsNot orderfiArr.Last Then
                If currentMonth = dateSplit(0) Then
                    orderlogpath = My.Application.Info.DirectoryPath & "\OrderLogs\" & orderfri.Name
                    orderlogname = orderfri.Name
                    GoTo Rank_Log
                End If
            Else
                If currentMonth = dateSplit(0) Then
                    orderlogpath = My.Application.Info.DirectoryPath & "\OrderLogs\" & orderfri.Name
                    orderlogname = orderfri.Name
                    GoTo Rank_Log
                Else
                    orderlogname = currentMonth & "_Order Process Log.txt"
                    orderlogpath = orderdi.Name & "\" & orderlogname
                    Dim fs As FileStream = File.Create(orderlogpath)
                    fs.Close()
                    GoTo Rank_Log
                End If
            End If
        Next orderfri

Rank_Log:
        For Each rankingfri In rankingfiArr
            dateSplit = rankingfri.Name.Split("_")
            If rankingfri IsNot rankingfiArr.Last Then
                If currentMonth = dateSplit(0) Then
                    rankinglogpath = My.Application.Info.DirectoryPath & "\RankingLogs\" & rankingfri.Name
                    ranklogname = rankingfri.Name
                    GoTo Read_Log
                End If
            Else
                If currentMonth = dateSplit(0) Then
                    rankinglogpath = My.Application.Info.DirectoryPath & "\RankingLogs\" & rankingfri.Name
                    ranklogname = rankingfri.Name
                    GoTo Read_Log
                Else
                    ranklogname = currentMonth & "_Rank Change Log.txt"
                    rankinglogpath = rankingdi.ToString & "\" & ranklogname
                    Dim fs As FileStream = File.Create(rankinglogpath)
                    fs.Close()
                    GoTo Read_Log
                End If
            End If
        Next rankingfri

Read_Log:
        Using orderlogReader As New StreamReader(orderlogpath), rankinglogReader As New StreamReader(rankinglogpath)
            orderlog = orderlogReader.ReadToEnd
            rankinglog = rankinglogReader.ReadToEnd
        End Using

        Return {orderlog, rankinglog}
    End Function

    Public Sub appendFile(ByVal orderlogcontent As String, ByVal ranklogcontent As String, ByVal choice As Integer)
        Dim orderlog As String = ""
        Dim ranklog As String = ""
        Dim currentMonth As String = DateTime.Now.ToString("yyyy-MM")
        Dim dateSplit() As String = New String() {}
        Dim orderlogpath As String = ""
        Dim rankinglogpath As String = ""

        Dim orderdi As New DirectoryInfo(My.Application.Info.DirectoryPath & "\OrderLogs")
        Dim rankingdi As New DirectoryInfo(My.Application.Info.DirectoryPath & "\RankingLogs")
        Dim orderfiArr As FileInfo() = orderdi.GetFiles()
        Dim rankingfiArr As FileInfo() = rankingdi.GetFiles()
        Dim orderfri As FileInfo
        Dim rankingfri As FileInfo

        'choice = 0 then append into order log file (insert), if = 1 then append into rank log file (update)
        If choice = 0 Then
            For Each orderfri In orderfiArr
                dateSplit = orderfri.Name.Split("_")
                If orderfri IsNot orderfiArr.Last Then
                    If currentMonth = dateSplit(0) Then
                        orderlogpath = My.Application.Info.DirectoryPath & "\OrderLogs\" & orderfri.Name
                        orderlog = orderfri.Name
                        GoTo Write_OrderFile
                    End If
                Else
                    If currentMonth = dateSplit(0) Then
                        orderlogpath = My.Application.Info.DirectoryPath & "\OrderLogs\" & orderfri.Name
                        orderlog = orderfri.Name
                        GoTo Write_OrderFile
                    Else
                        orderlog = currentMonth & "_Order Process Log.txt"
                        orderlogpath = orderdi.Name & "\" & orderlog
                        Dim fs As FileStream = File.Create(orderlogpath)
                        fs.Close()
                        GoTo Write_OrderFile
                    End If
                End If
            Next orderfri

Write_OrderFile:
            File.AppendAllText(orderlogpath, orderlogcontent)

        ElseIf choice = 1 Then
            For Each rankingfri In rankingfiArr
                dateSplit = rankingfri.Name.Split("_")
                If rankingfri IsNot rankingfiArr.Last Then
                    If currentMonth = dateSplit(0) Then
                        rankinglogpath = My.Application.Info.DirectoryPath & "\RankingLogs\" & rankingfri.Name
                        ranklog = rankingfri.Name
                        GoTo Write_RankFile
                    End If
                Else
                    If currentMonth = dateSplit(0) Then
                        rankinglogpath = My.Application.Info.DirectoryPath & "\RankingLogs\" & rankingfri.Name
                        ranklog = rankingfri.Name
                        GoTo Write_RankFile
                    Else
                        ranklog = currentMonth & "_Rank Change Log.txt"
                        rankinglogpath = rankingdi.ToString & "\" & ranklog
                        Dim fs As FileStream = File.Create(rankinglogpath)
                        fs.Close()
                        GoTo Write_RankFile
                    End If
                End If
            Next rankingfri

Write_RankFile:
            File.AppendAllText(rankinglogpath, ranklogcontent)
        End If
    End Sub

    'testing purpose by adding actor thus get id is needed
    Public Function getId() As Integer
        Dim id As Integer = 0
        sqlstr = "SELECT MAX(actor_id) FROM actor;"
        id = MysqlClient.DataHandler.GetData(sqlstr, "MAX(actor_id)", conn, True)
        Return id
    End Function

    'This one monitors changes and update the log in real time by comparing data table
    Public Function monitorUpdate(ByVal prev_dttable As DataTable, ByVal after_dttable As DataTable) As String()
        If prev_dttable.Rows.Count < after_dttable.Rows.Count Then
            Dim logcount As Integer = after_dttable.Rows.Count - prev_dttable.Rows.Count - 1
            Dim UpdateLog(logcount) As String
            Dim columnCount As Integer = getColumnCount("updateLog")
            Dim updatelogindex As Integer = 0
            Dim str As String = ""
            Dim columnNames(columnCount - 1) As String
            columnNames = populateColumn("updateLog")


            For i As Integer = prev_dttable.Rows.Count To after_dttable.Rows.Count - 1
                Dim dateUpdate As DateTime = after_dttable.Rows.Item(i).Item(columnNames(5))
                Dim dateUpdateString As String = dateUpdate.ToString("yyyy-MM-dd HH:mm:ss")
                str = dateUpdateString & " >> Actor with ID of " _
                    & after_dttable.Rows.Item(i).Item(columnNames(1)) & " changed " _
                    & after_dttable.Rows.Item(i).Item(columnNames(2)) & " from " _
                    & after_dttable.Rows.Item(i).Item(columnNames(3)) & " to " _
                    & after_dttable.Rows.Item(i).Item(columnNames(4)) & " " & vbCrLf
                UpdateLog(updatelogindex) = str
                updatelogindex = updatelogindex + 1
            Next

            Return UpdateLog
        End If
        Return Nothing
    End Function

    Public Function monitorInsert(ByVal prev_dttable As DataTable, ByVal after_dttable As DataTable) As String()
        If prev_dttable.Rows.Count < after_dttable.Rows.Count Then
            Dim logcount As Integer = after_dttable.Rows.Count - prev_dttable.Rows.Count - 1
            Dim insertLog(logcount) As String
            Dim columnCount As Integer = getColumnCount("actor")
            Dim insertlogindex As Integer = 0
            Dim columnNames(columnCount - 1) As String
            Dim str As String = ""
            columnNames = populateColumn("actor")

            For i As Integer = prev_dttable.Rows.Count To after_dttable.Rows.Count - 1
                Dim dateInsert As DateTime = after_dttable.Rows.Item(i).Item(columnNames(3))
                Dim dateInsertString As String = dateInsert.ToString("yyyy-MM-dd HH:mm:ss")
                str = dateInsertString & " >> Actor with ID of " _
                    & after_dttable.Rows.Item(i).Item(columnNames(0)) & " with name of " _
                    & after_dttable.Rows.Item(i).Item(columnNames(1)) & " " _
                    & after_dttable.Rows.Item(i).Item(columnNames(2)) & " has been added" & vbCrLf
                insertLog(insertlogindex) = str
                insertlogindex = insertlogindex + 1
            Next
            Return insertLog
        End If
        Return Nothing
    End Function

    Public Function isExistUpdateLogTable() As Boolean
        sqlstr = "SELECT * FROM updateLog;"
        dttable = MysqlClient.DataHandler.GetDataTable(sqlstr, conn, True)
        If Not IsNothing(dttable) Then
            If dttable.Rows.Count > 0 Then
                Return True
            End If
        Else
            Return False
        End If
        Return False
    End Function

    Public Sub createUpdateLogTable()
        sqlstr = "CREATE TABLE updateLog(" & vbCrLf _
                    & "id INT AUTO_INCREMENT PRIMARY KEY," & vbCrLf _
                    & "updatedField VARCHAR(50) NOT NULL," & vbCrLf _
                    & "prevValue varchar(50) NOT NULL," & vbCrLf _
                    & "afterValue varchar(50) NOT NULL," & vbCrLf _
                    & "last_updated timestamp NOT NULL);"
        Call MysqlClient.DataHandler.ExecuteSQL(sqlstr, conn, True)
    End Sub

    Public Sub createUpdateTrigger()
        sqlstr = "DROP TRIGGER IF EXISTS update_trigger;" & vbCrLf _
                & "CREATE TRIGGER update_trigger" & vbCrLf _
                    & "AFTER UPDATE " & vbCrLf _
                    & "ON sakila.actor" & vbCrLf _
                & "FOR EACH ROW" & vbCrLf _
                & "BEGIN" & vbCrLf _
                    & "IF OLD.first_name <> NEW.first_name then" & vbCrLf _
                        & "INSERT INTO updateLog(actorID, updatedField, prevValue, afterValue, last_updated)" & vbCrLf _
                        & "VALUES (NEW.actor_id, 'first_name', OLD.first_name, NEW.first_name, now());" & vbCrLf _
                    & "ELSEIF OLD.last_name <> NEW.last_name then" & vbCrLf _
                        & "INSERT INTO updateLog(actorID, updatedField, prevValue, afterValue, last_updated)" & vbCrLf _
                        & "VALUES (NEW.actor_id, 'last_name', OLD.last_name, NEW.last_name, now());" & vbCrLf _
                    & "END IF;" & vbCrLf _
                & "END"
        Call MysqlClient.DataHandler.ExecuteSQL(sqlstr, conn, True)
    End Sub

    'monitor table that is created and inserted using trigger or comparing table
    'alternative way to monitor update changes
    Public Function populateDataTable_after(ByVal choice As Integer) As DataTable
        If choice = 0 Then
            sqlstr = "SELECT * FROM actor;"
        ElseIf choice = 1 Then
            sqlstr = "SELECT * FROM updateLog;"
        End If
        dttable = MysqlClient.DataHandler.GetDataTable(sqlstr, conn, True)
        If Not IsNothing(dttable) Then
            If dttable.Rows.Count > 0 Then
                Return dttable
            End If
        End If
        Return Nothing
    End Function

    Public Function populateDataTable_prev(ByVal date_prev As String, ByVal choice As Integer) As DataTable
        'if choice = 0 then WHERE created on, if = 1 then WHERE last_updated
        If choice = 0 Then
            sqlstr = "SELECT * FROM actor WHERE created_on <= '" & date_prev & "';"
        ElseIf choice = 1 Then
            sqlstr = "SELECT * FROM updateLog WHERE last_updated <= '" & date_prev & "';"
        End If
        dttable = MysqlClient.DataHandler.GetDataTable(sqlstr, conn, True)
        If Not IsNothing(dttable) Then
            Return dttable
        End If
        Return Nothing
    End Function

    'This one allows the user to upload a new order 
    'Test using actor first
    Public Sub uploadOrder(ByVal id As Integer, ByVal fname As String, ByVal lname As String)
        sqlstr = " INSERT INTO actor (actor_id, first_name, last_name, last_update) " _
                      & " VALUES ('" & id & "', '" & fname & "', '" & lname & "', NOW());"
        Call MysqlClient.DataHandler.ExecuteSQL(sqlstr, conn, True)
    End Sub

    'This one allows the program to randomly upload a new order automatically 
    Public Sub randomUploadOrder()
        Dim listnames As New List(Of Model)
        listnames.Add(New Model("John1", "Doe1"))
        listnames.Add(New Model("John2", "Doe2"))
        listnames.Add(New Model("John3", "Doe3"))
        listnames.Add(New Model("John4", "Doe4"))
        listnames.Add(New Model("John5", "Doe5"))
        listnames.Add(New Model("John6", "Doe6"))
        listnames.Add(New Model("John7", "Doe7"))
        listnames.Add(New Model("John8", "Doe8"))
        listnames.Add(New Model("John9", "Doe9"))
        listnames.Add(New Model("John10", "Doe10"))

        Dim rnd As New Random(Now.Millisecond)
        Dim index As Integer = rnd.Next(0, 10)
        Dim curr As Model = listnames(index)
        Dim aid As Integer = getId() + 1
        uploadOrder(aid, curr.firstName, curr.lastName)
    End Sub

    'This display the order history in the order history tab
    Public Function displayData(ByVal tbname As String) As DataTable
        Dim columnNames(getColumnCount(tbname) - 1) As String
        columnNames = populateColumn(tbname)
        If IsNothing(tableName) Then
            MessageBox.Show("Please enter a table name.")
            Return Nothing
        Else
            sqlstr = "SELECT * FROM " & tbname & ";"
            dttable = MysqlClient.DataHandler.GetDataTable(sqlstr, conn, True)
            If Not IsNothing(dttable) Then
                Return dttable
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Function getColumnCount(ByVal tbname As String) As Integer
        If IsNothing(tbname) Then
            MessageBox.Show("Please enter a table name.")
            Return Nothing
        Else
            sqlstr = "SELECT COUNT(*) as column_count FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & tbname & "';"
            out = MysqlClient.DataHandler.GetData(sqlstr, "column_count", conn, True)
            If Not String.IsNullOrEmpty(out) Then
                Return out
            End If
        End If
        Return Nothing
    End Function

    'this populates the table column with selected database
    Public Function populateColumn(ByVal tbname As String) As String()
        If IsNothing(tbname) Then
            MessageBox.Show("Please enter a table name.")
            Return Nothing
        Else
            sqlstr = "SELECT * FROM " & tbname & ";"
            Dim reader As MySqlDataReader
            reader = MysqlClient.DataHandler.GetDataReader(sqlstr, conn, True)
            Dim columnNames(getColumnCount(tbname) - 1) As String
            For i As Integer = 0 To reader.FieldCount - 1
                columnNames(i) = reader.GetName(i)
            Next
            Return columnNames
        End If
    End Function
End Class
