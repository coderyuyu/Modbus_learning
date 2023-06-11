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
        Me.AnalogDial1 = New MfgControl.AdvancedHMI.Controls.AnalogDial()
        Me.Emailer1 = New MfgControl.AdvancedHMI.Controls.Emailer()
        Me.EmailerEx1 = New MfgControl.AdvancedHMI.Controls.EmailerEx()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ButtonSetting = New System.Windows.Forms.Button()
        Me.Fan1 = New MfgControl.AdvancedHMI.Controls.Fan()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonQuit = New System.Windows.Forms.Button()
        Me.ButtonLog = New System.Windows.Forms.Button()
        Me.ButtonTest = New System.Windows.Forms.Button()
        Me.ButtonConsole = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AnalogDial1
        '
        Me.AnalogDial1.Location = New System.Drawing.Point(24, 38)
        Me.AnalogDial1.Maximum = 100.0R
        Me.AnalogDial1.Minimum = 0R
        Me.AnalogDial1.Name = "AnalogDial1"
        Me.AnalogDial1.RedColorBandStartValue = 75.0R
        Me.AnalogDial1.Resolution = 0.1R
        Me.AnalogDial1.ShowColorBand = True
        Me.AnalogDial1.Size = New System.Drawing.Size(89, 86)
        Me.AnalogDial1.TabIndex = 0
        Me.AnalogDial1.Text = "AnalogDial1"
        Me.AnalogDial1.Value = 0R
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
        'ButtonSetting
        '
        Me.ButtonSetting.Location = New System.Drawing.Point(3, 3)
        Me.ButtonSetting.Name = "ButtonSetting"
        Me.ButtonSetting.Size = New System.Drawing.Size(110, 39)
        Me.ButtonSetting.TabIndex = 47
        Me.ButtonSetting.Text = "Settings"
        Me.ButtonSetting.UseVisualStyleBackColor = True
        '
        'Fan1
        '
        Me.Fan1.Direction = False
        Me.Fan1.Location = New System.Drawing.Point(140, 38)
        Me.Fan1.Name = "Fan1"
        Me.Fan1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.Fan1.Size = New System.Drawing.Size(75, 75)
        Me.Fan1.TabIndex = 48
        Me.Fan1.Text = "Fan1"
        Me.Fan1.TextPosition = System.Drawing.StringAlignment.Near
        Me.Fan1.Value = False
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(119, 3)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(110, 39)
        Me.ButtonStart.TabIndex = 49
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonQuit
        '
        Me.ButtonQuit.Location = New System.Drawing.Point(351, 3)
        Me.ButtonQuit.Name = "ButtonQuit"
        Me.ButtonQuit.Size = New System.Drawing.Size(110, 39)
        Me.ButtonQuit.TabIndex = 50
        Me.ButtonQuit.Text = "Quit"
        Me.ButtonQuit.UseVisualStyleBackColor = True
        '
        'ButtonLog
        '
        Me.ButtonLog.Location = New System.Drawing.Point(235, 3)
        Me.ButtonLog.Name = "ButtonLog"
        Me.ButtonLog.Size = New System.Drawing.Size(110, 39)
        Me.ButtonLog.TabIndex = 51
        Me.ButtonLog.Text = "Log"
        Me.ButtonLog.UseVisualStyleBackColor = True
        '
        'ButtonTest
        '
        Me.ButtonTest.Location = New System.Drawing.Point(467, 3)
        Me.ButtonTest.Name = "ButtonTest"
        Me.ButtonTest.Size = New System.Drawing.Size(110, 39)
        Me.ButtonTest.TabIndex = 52
        Me.ButtonTest.Text = "Test"
        Me.ButtonTest.UseVisualStyleBackColor = True
        '
        'ButtonConsole
        '
        Me.ButtonConsole.Location = New System.Drawing.Point(583, 3)
        Me.ButtonConsole.Name = "ButtonConsole"
        Me.ButtonConsole.Size = New System.Drawing.Size(110, 39)
        Me.ButtonConsole.TabIndex = 54
        Me.ButtonConsole.Text = "Console"
        Me.ButtonConsole.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.89546!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.10454!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.85943!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.14058!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1014, 626)
        Me.TableLayoutPanel1.TabIndex = 55
        '
        'FlowLayoutPanel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel1, 2)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonSetting)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonStart)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonLog)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonQuit)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonTest)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonConsole)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 553)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1008, 70)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.AnalogDial1)
        Me.Panel1.Controls.Add(Me.Fan1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 544)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(803, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 100)
        Me.Panel2.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1014, 626)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AnalogDial1 As MfgControl.AdvancedHMI.Controls.AnalogDial
    Friend WithEvents Emailer1 As MfgControl.AdvancedHMI.Controls.Emailer
    Friend WithEvents EmailerEx1 As MfgControl.AdvancedHMI.Controls.EmailerEx
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ButtonSetting As Button
    Friend WithEvents Fan1 As MfgControl.AdvancedHMI.Controls.Fan
    Friend WithEvents ButtonStart As Button
    Friend WithEvents ButtonQuit As Button
    Friend WithEvents ButtonLog As Button
    Friend WithEvents ButtonTest As Button
    Friend WithEvents ButtonConsole As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
