Imports nonskinupgrade.Repository
Imports System.Data.Common.DbException
Imports System.Data.Common
Imports System.Linq

Public Class OrderHistory

    Dim repo As New Repository
    Dim table As New DataTable
    Dim dv As New DataView


    Private Sub OrderHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        txtFilter.Enabled = False
        txtTableName.Text = tableName
        Try
            If Not String.IsNullOrEmpty(tableName) Then
                table = repo.displayData(tableName)
                dgvOrderHistory.DataSource = table

                Dim columnNames(repo.getColumnCount(tableName) - 1) As String
                columnNames = repo.populateColumn(tableName)
                For i As Integer = 0 To repo.getColumnCount(tableName) - 1
                    cmbFilter.Items.Add(columnNames(i))
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmbFilter_DropDownClosed(sender As Object, e As EventArgs) Handles cmbFilter.DropDownClosed
        If String.IsNullOrEmpty(cmbFilter.Text) = False Then
            txtFilter.Enabled = True
        End If
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        dv.Table = table
        Try
            If IsNumeric(txtFilter.Text) Or ContainsSpecialChars(txtFilter.Text) Then
                dv.RowFilter = String.Format("CONVERT({0}, System.String) like '%{1}%'", cmbFilter.Text, txtFilter.Text)
                dgvOrderHistory.DataSource = Nothing
                dgvOrderHistory.DataSource = dv.ToTable
            ElseIf String.IsNullOrEmpty(txtFilter.Text) Then
                dv.Table = table
                dgvOrderHistory.DataSource = Nothing
                dgvOrderHistory.DataSource = table
            Else
                dv.RowFilter = String.Format(cmbFilter.Text & " Like '%{0}%'", txtFilter.Text)
                dgvOrderHistory.DataSource = Nothing
                dgvOrderHistory.DataSource = dv.ToTable
            End If
        Catch ex As EvaluateException
        End Try
    End Sub

    Private Function ContainsSpecialChars(s As String) As Boolean
        Return s.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray) <> -1
    End Function

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        tableName = txtTableName.Text
        Me.Controls.Clear()
        InitializeComponent()
        OrderHistory_Load(e, e)
    End Sub
End Class