Imports nonskinupgrade.Repository
Imports nonskinupgrade.Connection

Public Class TestConnection

    Dim repo As New Repository

    Private Sub TestConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPWD.UseSystemPasswordChar = True
        txtServer.Text = server
        txtID.Text = uid
        txtPWD.Text = pwd
        txtDB.Text = db
        txtPort.Text = port
    End Sub

    Private Sub cbShow_CheckedChanged(sender As Object, e As EventArgs) Handles cbShow.CheckedChanged
        If cbShow.Checked = False Then
            txtPWD.UseSystemPasswordChar = True
        Else
            txtPWD.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        server = txtServer.Text
        uid = txtID.Text
        pwd = txtPWD.Text
        db = txtDB.Text
        port = txtPort.Text

        conn = "server=" & server & "; uid=" & uid & "; pwd=" & pwd & "; database=" & db & "; port=" & port
        connected = repo.testConnection()
        tableName = Nothing
    End Sub
End Class