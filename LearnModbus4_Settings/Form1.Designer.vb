<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Emailer1 = New MfgControl.AdvancedHMI.Controls.Emailer()
        Me.EmailerEx1 = New MfgControl.AdvancedHMI.Controls.EmailerEx()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Emailer1
        '
        Me.Emailer1.MessageBody = ""
        Me.Emailer1.MessageFrom = ""
        Me.Emailer1.MessageSubject = "Email from AdvancedHMI Emailer"
        Me.Emailer1.MessageTo = ""
        Me.Emailer1.SmtpLoginPassword = Nothing
        Me.Emailer1.SmtpLoginUserName = ""
        Me.Emailer1.SmtpPort = 25
        Me.Emailer1.SmtpServer = Nothing
        Me.Emailer1.UseSsl = False
        '
        'EmailerEx1
        '
        Me.EmailerEx1.MessageBody = ""
        Me.EmailerEx1.MessageFrom = ""
        Me.EmailerEx1.MessageSubject = "Email from AdvancedHMI Emailer"
        Me.EmailerEx1.MessageTo = ""
        Me.EmailerEx1.ServerPresets = MfgControl.AdvancedHMI.Controls.EmailerEx.ServerPresetsEnum.SelectOne
        Me.EmailerEx1.SmtpLoginPassword = Nothing
        Me.EmailerEx1.SmtpLoginUserName = ""
        Me.EmailerEx1.SmtpPort = 25
        Me.EmailerEx1.SmtpServer = Nothing
        Me.EmailerEx1.TargetValue = Nothing
        Me.EmailerEx1.TriggerType = MfgControl.AdvancedHMI.Controls.EmailerEx.TriggerTypeEnum.ValueChange
        Me.EmailerEx1.UseSsl = False
        Me.EmailerEx1.Value = Nothing
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 46)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Setting"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(291, 101)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Emailer1 As MfgControl.AdvancedHMI.Controls.Emailer
    Friend WithEvents EmailerEx1 As MfgControl.AdvancedHMI.Controls.EmailerEx
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Button1 As Button
End Class
