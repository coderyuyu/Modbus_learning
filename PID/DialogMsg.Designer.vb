<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogMsg
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
        Me.ButtonPannel = New System.Windows.Forms.FlowLayoutPanel()
        Me.icon = New System.Windows.Forms.PictureBox()
        Me.msg = New System.Windows.Forms.Label()
        CType(Me.icon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonPannel
        '
        Me.ButtonPannel.Font = New System.Drawing.Font("Microsoft JhengHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonPannel.Location = New System.Drawing.Point(188, 141)
        Me.ButtonPannel.Name = "ButtonPannel"
        Me.ButtonPannel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonPannel.Size = New System.Drawing.Size(239, 36)
        Me.ButtonPannel.TabIndex = 6
        '
        'icon
        '
        Me.icon.Image = Global.PID.My.Resources.Resources.info
        Me.icon.Location = New System.Drawing.Point(214, 12)
        Me.icon.Name = "icon"
        Me.icon.Size = New System.Drawing.Size(47, 42)
        Me.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.icon.TabIndex = 5
        Me.icon.TabStop = False
        '
        'msg
        '
        Me.msg.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.msg.Location = New System.Drawing.Point(11, 57)
        Me.msg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(458, 81)
        Me.msg.TabIndex = 4
        Me.msg.Text = "Label1"
        Me.msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DialogMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 197)
        Me.Controls.Add(Me.ButtonPannel)
        Me.Controls.Add(Me.icon)
        Me.Controls.Add(Me.msg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogMsg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DialogMsg"
        CType(Me.icon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonPannel As FlowLayoutPanel
    Friend WithEvents icon As PictureBox
    Friend WithEvents msg As Label
End Class
