Imports nonskinupgrade.Repository
Imports nonskinupgrade.Connection
Imports System.Linq

Public Class Nonskin

    Dim repo As New Repository
    Dim mouse_move As System.Drawing.Point

    Private Sub Nonskin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        btnTestConnection.Enabled = False
        switchPanel(TestConnection)
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        If connected = False Then
            MessageBox.Show("You are not connected to MySQL yet!")
        Else
            btnTestConnection.Enabled = True
            btnLog.Enabled = False
            btnNewOrder.Enabled = True
            btnOrderHistory.Enabled = True
            switchPanel(Log)
        End If

    End Sub


    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        If connected = False Then
            MessageBox.Show("You are not connected to MySQL yet!")
        Else
            btnTestConnection.Enabled = True
            btnLog.Enabled = True
            btnNewOrder.Enabled = False
            btnOrderHistory.Enabled = True
            switchPanel(NewOrder)
        End If
    End Sub


    Private Sub btnOrderHistory_Click(sender As Object, e As EventArgs) Handles btnOrderHistory.Click
        If connected = False Then
            MessageBox.Show("You are not connected to MySQL yet!")
        Else
            btnTestConnection.Enabled = True
            btnLog.Enabled = True
            btnNewOrder.Enabled = True
            btnOrderHistory.Enabled = False
            switchPanel(OrderHistory)
        End If
    End Sub

    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        btnTestConnection.Enabled = False
        btnLog.Enabled = True
        btnNewOrder.Enabled = True
        btnOrderHistory.Enabled = True
        switchPanel(TestConnection)
    End Sub

    Sub switchPanel(ByVal panel As Form)
        panel_form.Controls.Clear()
        panel.TopLevel = False
        panel_form.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub picImgShutDown_Click(sender As Object, e As EventArgs) Handles picImgShutDown.Click
        Dim shut As DialogResult = MessageBox.Show("Terminate application?", "Wait!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If shut = DialogResult.Yes Then
            connected = False
            monitorChangeStatus = False
            randomUploadStatus = False
            Me.nonskinNotify.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Visible = False
        nonskinNotify.ShowBalloonTip(200, "Nonskin", "Application running in tooltip tray.", ToolTipIcon.Info)
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub panel_Top_MouseDown(sender As Object, e As MouseEventArgs) Handles panel_Top.MouseDown
        mouse_move = New Point(-e.X, -e.Y)
    End Sub

    Private Sub panel_Top_MouseMove(sender As Object, e As MouseEventArgs) Handles panel_Top.MouseMove
        If (e.Button = Windows.Forms.MouseButtons.Left) Then
            Dim mposition As Point
            mposition = Control.MousePosition
            mposition.Offset(mouse_move.X, mouse_move.Y)
            Me.Location = mposition
        End If
    End Sub

    Private Sub nonskinNotify_MouseClick(sender As Object, e As MouseEventArgs) Handles nonskinNotify.MouseClick
        Me.Visible = True
    End Sub
End Class
