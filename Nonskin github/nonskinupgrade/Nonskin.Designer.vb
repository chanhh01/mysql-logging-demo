<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nonskin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nonskin))
        Me.panel_TestConnection = New System.Windows.Forms.Panel()
        Me.panel_Top = New System.Windows.Forms.Panel()
        Me.btnMin = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.picImgShutDown = New System.Windows.Forms.PictureBox()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.btnOrderHistory = New System.Windows.Forms.Button()
        Me.btnNewOrder = New System.Windows.Forms.Button()
        Me.panel_form = New System.Windows.Forms.Panel()
        Me.nonskinNotify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.panel_TestConnection.SuspendLayout()
        Me.panel_Top.SuspendLayout()
        CType(Me.picImgShutDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_TestConnection
        '
        Me.panel_TestConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_TestConnection.Controls.Add(Me.panel_Top)
        Me.panel_TestConnection.Controls.Add(Me.btnTestConnection)
        Me.panel_TestConnection.Controls.Add(Me.btnLog)
        Me.panel_TestConnection.Controls.Add(Me.btnOrderHistory)
        Me.panel_TestConnection.Controls.Add(Me.btnNewOrder)
        Me.panel_TestConnection.Controls.Add(Me.panel_form)
        Me.panel_TestConnection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_TestConnection.Location = New System.Drawing.Point(0, 0)
        Me.panel_TestConnection.Name = "panel_TestConnection"
        Me.panel_TestConnection.Size = New System.Drawing.Size(639, 470)
        Me.panel_TestConnection.TabIndex = 23
        '
        'panel_Top
        '
        Me.panel_Top.BackColor = System.Drawing.Color.Teal
        Me.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_Top.Controls.Add(Me.btnMin)
        Me.panel_Top.Controls.Add(Me.btnExit)
        Me.panel_Top.Controls.Add(Me.picImgShutDown)
        Me.panel_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel_Top.Location = New System.Drawing.Point(0, 0)
        Me.panel_Top.Name = "panel_Top"
        Me.panel_Top.Size = New System.Drawing.Size(637, 28)
        Me.panel_Top.TabIndex = 19
        '
        'btnMin
        '
        Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin.ForeColor = System.Drawing.Color.Transparent
        Me.btnMin.Location = New System.Drawing.Point(572, 2)
        Me.btnMin.Name = "btnMin"
        Me.btnMin.Size = New System.Drawing.Size(26, 22)
        Me.btnMin.TabIndex = 12
        Me.btnMin.Text = "一"
        Me.btnMin.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnMin.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.ForeColor = System.Drawing.Color.Transparent
        Me.btnExit.Location = New System.Drawing.Point(605, 2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(26, 22)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "X"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'picImgShutDown
        '
        Me.picImgShutDown.Image = CType(resources.GetObject("picImgShutDown.Image"), System.Drawing.Image)
        Me.picImgShutDown.Location = New System.Drawing.Point(5, 2)
        Me.picImgShutDown.Name = "picImgShutDown"
        Me.picImgShutDown.Size = New System.Drawing.Size(23, 21)
        Me.picImgShutDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picImgShutDown.TabIndex = 11
        Me.picImgShutDown.TabStop = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(0, 28)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(160, 47)
        Me.btnTestConnection.TabIndex = 25
        Me.btnTestConnection.Text = "Test Connection"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'btnLog
        '
        Me.btnLog.Location = New System.Drawing.Point(159, 28)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(160, 47)
        Me.btnLog.TabIndex = 23
        Me.btnLog.Text = "Log"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'btnOrderHistory
        '
        Me.btnOrderHistory.Location = New System.Drawing.Point(477, 28)
        Me.btnOrderHistory.Name = "btnOrderHistory"
        Me.btnOrderHistory.Size = New System.Drawing.Size(160, 47)
        Me.btnOrderHistory.TabIndex = 26
        Me.btnOrderHistory.Text = "Check History"
        Me.btnOrderHistory.UseVisualStyleBackColor = True
        '
        'btnNewOrder
        '
        Me.btnNewOrder.Location = New System.Drawing.Point(318, 28)
        Me.btnNewOrder.Name = "btnNewOrder"
        Me.btnNewOrder.Size = New System.Drawing.Size(160, 47)
        Me.btnNewOrder.TabIndex = 24
        Me.btnNewOrder.Text = "Upload New Order"
        Me.btnNewOrder.UseVisualStyleBackColor = True
        '
        'panel_form
        '
        Me.panel_form.Location = New System.Drawing.Point(-1, 73)
        Me.panel_form.Name = "panel_form"
        Me.panel_form.Size = New System.Drawing.Size(639, 395)
        Me.panel_form.TabIndex = 0
        '
        'nonskinNotify
        '
        Me.nonskinNotify.Icon = CType(resources.GetObject("nonskinNotify.Icon"), System.Drawing.Icon)
        Me.nonskinNotify.Text = "Nonskin"
        Me.nonskinNotify.Visible = True
        '
        'Nonskin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 470)
        Me.Controls.Add(Me.panel_TestConnection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Nonskin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nonskin DEMO"
        Me.panel_TestConnection.ResumeLayout(False)
        Me.panel_Top.ResumeLayout(False)
        CType(Me.picImgShutDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panel_TestConnection As System.Windows.Forms.Panel
    Friend WithEvents panel_Top As System.Windows.Forms.Panel
    Friend WithEvents btnMin As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents picImgShutDown As System.Windows.Forms.PictureBox
    Friend WithEvents nonskinNotify As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents btnLog As System.Windows.Forms.Button
    Friend WithEvents btnOrderHistory As System.Windows.Forms.Button
    Friend WithEvents btnNewOrder As System.Windows.Forms.Button
    Friend WithEvents panel_form As System.Windows.Forms.Panel

End Class
