<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Log
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
        Me.bgwLog = New System.ComponentModel.BackgroundWorker()
        Me.rtxtLogOrder = New System.Windows.Forms.RichTextBox()
        Me.lblOrderLog = New System.Windows.Forms.Label()
        Me.lblRankingLog = New System.Windows.Forms.Label()
        Me.pbMonitor = New System.Windows.Forms.PictureBox()
        Me.rtxtLogRanking = New System.Windows.Forms.RichTextBox()
        CType(Me.pbMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bgwLog
        '
        Me.bgwLog.WorkerReportsProgress = True
        Me.bgwLog.WorkerSupportsCancellation = True
        '
        'rtxtLogOrder
        '
        Me.rtxtLogOrder.Location = New System.Drawing.Point(3, 35)
        Me.rtxtLogOrder.Name = "rtxtLogOrder"
        Me.rtxtLogOrder.ReadOnly = True
        Me.rtxtLogOrder.Size = New System.Drawing.Size(315, 357)
        Me.rtxtLogOrder.TabIndex = 40
        Me.rtxtLogOrder.Text = ""
        '
        'lblOrderLog
        '
        Me.lblOrderLog.AutoSize = True
        Me.lblOrderLog.Location = New System.Drawing.Point(92, 18)
        Me.lblOrderLog.Name = "lblOrderLog"
        Me.lblOrderLog.Size = New System.Drawing.Size(146, 13)
        Me.lblOrderLog.TabIndex = 38
        Me.lblOrderLog.Text = "order process log nameholder"
        '
        'lblRankingLog
        '
        Me.lblRankingLog.AutoSize = True
        Me.lblRankingLog.Location = New System.Drawing.Point(424, 18)
        Me.lblRankingLog.Name = "lblRankingLog"
        Me.lblRankingLog.Size = New System.Drawing.Size(118, 13)
        Me.lblRankingLog.TabIndex = 37
        Me.lblRankingLog.Text = "rank up log nameholder"
        '
        'pbMonitor
        '
        Me.pbMonitor.Location = New System.Drawing.Point(307, 6)
        Me.pbMonitor.Name = "pbMonitor"
        Me.pbMonitor.Size = New System.Drawing.Size(24, 24)
        Me.pbMonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbMonitor.TabIndex = 41
        Me.pbMonitor.TabStop = False
        '
        'rtxtLogRanking
        '
        Me.rtxtLogRanking.Location = New System.Drawing.Point(320, 35)
        Me.rtxtLogRanking.Name = "rtxtLogRanking"
        Me.rtxtLogRanking.ReadOnly = True
        Me.rtxtLogRanking.Size = New System.Drawing.Size(315, 357)
        Me.rtxtLogRanking.TabIndex = 39
        Me.rtxtLogRanking.Text = ""
        '
        'Log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 395)
        Me.Controls.Add(Me.rtxtLogOrder)
        Me.Controls.Add(Me.lblOrderLog)
        Me.Controls.Add(Me.lblRankingLog)
        Me.Controls.Add(Me.pbMonitor)
        Me.Controls.Add(Me.rtxtLogRanking)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Log"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log"
        CType(Me.pbMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bgwLog As System.ComponentModel.BackgroundWorker
    Friend WithEvents rtxtLogOrder As System.Windows.Forms.RichTextBox
    Friend WithEvents lblOrderLog As System.Windows.Forms.Label
    Friend WithEvents lblRankingLog As System.Windows.Forms.Label
    Friend WithEvents pbMonitor As System.Windows.Forms.PictureBox
    Friend WithEvents rtxtLogRanking As System.Windows.Forms.RichTextBox
End Class
