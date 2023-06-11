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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBaudrate = New System.Windows.Forms.TextBox()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Reg1_1 = New System.Windows.Forms.Label()
        Me.Reg1_2 = New System.Windows.Forms.Label()
        Me.Reg1_3 = New System.Windows.Forms.Label()
        Me.Reg2_3 = New System.Windows.Forms.Label()
        Me.Reg2_2 = New System.Windows.Forms.Label()
        Me.Reg2_1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.EthernetIPforCLXCom1 = New AdvancedHMIDrivers.EthernetIPforCLXCom(Me.components)
        Me.Emailer1 = New MfgControl.AdvancedHMI.Controls.Emailer()
        Me.Fan1 = New MfgControl.AdvancedHMI.Controls.Fan()
        Me.Meter1 = New MfgControl.AdvancedHMI.Controls.Meter()
        Me.SelectorSwitch1 = New MfgControl.AdvancedHMI.Controls.SelectorSwitch()
        Me.Tank1 = New MfgControl.AdvancedHMI.Controls.Tank()
        Me.Thermometer21 = New MfgControl.AdvancedHMI.Controls.Thermometer2()
        Me.Motor1 = New MfgControl.AdvancedHMI.Controls.Motor()
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(84, 25)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 22)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "COM2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Baudrate"
        '
        'txtBaudrate
        '
        Me.txtBaudrate.Location = New System.Drawing.Point(84, 53)
        Me.txtBaudrate.Name = "txtBaudrate"
        Me.txtBaudrate.Size = New System.Drawing.Size(100, 22)
        Me.txtBaudrate.TabIndex = 3
        Me.txtBaudrate.Text = "9600"
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(33, 81)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(151, 31)
        Me.ButtonConnect.TabIndex = 4
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Slave1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(238, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Reg1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(284, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Reg2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(330, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Reg3"
        '
        'Reg1_1
        '
        Me.Reg1_1.AutoSize = True
        Me.Reg1_1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg1_1.Location = New System.Drawing.Point(237, 63)
        Me.Reg1_1.Name = "Reg1_1"
        Me.Reg1_1.Size = New System.Drawing.Size(21, 19)
        Me.Reg1_1.TabIndex = 9
        Me.Reg1_1.Text = "..."
        '
        'Reg1_2
        '
        Me.Reg1_2.AutoSize = True
        Me.Reg1_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg1_2.Location = New System.Drawing.Point(282, 63)
        Me.Reg1_2.Name = "Reg1_2"
        Me.Reg1_2.Size = New System.Drawing.Size(21, 19)
        Me.Reg1_2.TabIndex = 10
        Me.Reg1_2.Text = "..."
        '
        'Reg1_3
        '
        Me.Reg1_3.AutoSize = True
        Me.Reg1_3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg1_3.Location = New System.Drawing.Point(328, 63)
        Me.Reg1_3.Name = "Reg1_3"
        Me.Reg1_3.Size = New System.Drawing.Size(21, 19)
        Me.Reg1_3.TabIndex = 11
        Me.Reg1_3.Text = "..."
        '
        'Reg2_3
        '
        Me.Reg2_3.AutoSize = True
        Me.Reg2_3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg2_3.Location = New System.Drawing.Point(474, 63)
        Me.Reg2_3.Name = "Reg2_3"
        Me.Reg2_3.Size = New System.Drawing.Size(21, 19)
        Me.Reg2_3.TabIndex = 18
        Me.Reg2_3.Text = "..."
        '
        'Reg2_2
        '
        Me.Reg2_2.AutoSize = True
        Me.Reg2_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg2_2.Location = New System.Drawing.Point(428, 63)
        Me.Reg2_2.Name = "Reg2_2"
        Me.Reg2_2.Size = New System.Drawing.Size(21, 19)
        Me.Reg2_2.TabIndex = 17
        Me.Reg2_2.Text = "..."
        '
        'Reg2_1
        '
        Me.Reg2_1.AutoSize = True
        Me.Reg2_1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg2_1.Location = New System.Drawing.Point(383, 63)
        Me.Reg2_1.Name = "Reg2_1"
        Me.Reg2_1.Size = New System.Drawing.Size(21, 19)
        Me.Reg2_1.TabIndex = 16
        Me.Reg2_1.Text = "..."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(476, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Reg3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(430, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Reg2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(384, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 12)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Reg1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(384, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 12)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Slave2"
        '
        'EthernetIPforCLXCom1
        '
        Me.EthernetIPforCLXCom1.CIPConnectionSize = 508
        Me.EthernetIPforCLXCom1.DisableMultiServiceRequest = False
        Me.EthernetIPforCLXCom1.DisableSubscriptions = False
        Me.EthernetIPforCLXCom1.IniFileName = ""
        Me.EthernetIPforCLXCom1.IniFileSection = Nothing
        Me.EthernetIPforCLXCom1.IPAddress = "192.168.0.10"
        Me.EthernetIPforCLXCom1.PollRateOverride = 500
        Me.EthernetIPforCLXCom1.Port = 44818
        Me.EthernetIPforCLXCom1.ProcessorSlot = 0
        Me.EthernetIPforCLXCom1.RoutePath = Nothing
        Me.EthernetIPforCLXCom1.Timeout = 4000
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
        'Fan1
        '
        Me.Fan1.Direction = False
        Me.Fan1.Location = New System.Drawing.Point(315, 145)
        Me.Fan1.Name = "Fan1"
        Me.Fan1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.Fan1.Size = New System.Drawing.Size(105, 105)
        Me.Fan1.TabIndex = 19
        Me.Fan1.Text = "Fan1"
        Me.Fan1.TextPosition = System.Drawing.StringAlignment.Near
        Me.Fan1.Value = True
        '
        'Meter1
        '
        Me.Meter1.Location = New System.Drawing.Point(125, 145)
        Me.Meter1.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.Meter1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.Meter1.Name = "Meter1"
        Me.Meter1.Size = New System.Drawing.Size(133, 114)
        Me.Meter1.TabIndex = 20
        Me.Meter1.Text = "Meter1"
        Me.Meter1.Value = 0R
        Me.Meter1.ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SelectorSwitch1
        '
        Me.SelectorSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.SelectorSwitch1.BackgroundImage = CType(resources.GetObject("SelectorSwitch1.BackgroundImage"), System.Drawing.Image)
        Me.SelectorSwitch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.SelectorSwitch1.LegendPlate = MfgControl.AdvancedHMI.Controls.SelectorSwitch.LegendPlates.Large
        Me.SelectorSwitch1.Location = New System.Drawing.Point(328, 276)
        Me.SelectorSwitch1.Name = "SelectorSwitch1"
        Me.SelectorSwitch1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.SelectorSwitch1.Size = New System.Drawing.Size(32, 47)
        Me.SelectorSwitch1.TabIndex = 21
        Me.SelectorSwitch1.Text = "SelectorSwitch1"
        Me.SelectorSwitch1.Value = False
        '
        'Tank1
        '
        Me.Tank1.Location = New System.Drawing.Point(460, 173)
        Me.Tank1.MaxValue = 100
        Me.Tank1.MinValue = 0
        Me.Tank1.Name = "Tank1"
        Me.Tank1.Size = New System.Drawing.Size(77, 103)
        Me.Tank1.TabIndex = 22
        Me.Tank1.TankContentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Tank1.Text = "Tank1"
        Me.Tank1.Value = 0!
        Me.Tank1.ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Thermometer21
        '
        Me.Thermometer21.ColumnColor = MfgControl.AdvancedHMI.Controls.Thermometer2.ColumnColors.Red
        Me.Thermometer21.FillColor = System.Drawing.Color.Red
        Me.Thermometer21.ForeColor = System.Drawing.Color.Black
        Me.Thermometer21.Location = New System.Drawing.Point(24, 145)
        Me.Thermometer21.Minimum = -40.0R
        Me.Thermometer21.Name = "Thermometer21"
        Me.Thermometer21.Size = New System.Drawing.Size(54, 214)
        Me.Thermometer21.TabIndex = 23
        Me.Thermometer21.Text = "Thermometer21"
        Me.Thermometer21.Value = 0R
        Me.Thermometer21.ValueUnits = MfgControl.AdvancedHMI.Controls.Thermometer2.UnitsSelect.F
        '
        'Motor1
        '
        Me.Motor1.LightColor = MfgControl.AdvancedHMI.Controls.Motor.LightColors.Green
        Me.Motor1.Location = New System.Drawing.Point(165, 277)
        Me.Motor1.Name = "Motor1"
        Me.Motor1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.Motor1.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone
        Me.Motor1.Size = New System.Drawing.Size(121, 82)
        Me.Motor1.TabIndex = 24
        Me.Motor1.Text = "Motor1"
        Me.Motor1.Value = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 403)
        Me.Controls.Add(Me.Motor1)
        Me.Controls.Add(Me.Thermometer21)
        Me.Controls.Add(Me.Tank1)
        Me.Controls.Add(Me.SelectorSwitch1)
        Me.Controls.Add(Me.Meter1)
        Me.Controls.Add(Me.Fan1)
        Me.Controls.Add(Me.Reg2_3)
        Me.Controls.Add(Me.Reg2_2)
        Me.Controls.Add(Me.Reg2_1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Reg1_3)
        Me.Controls.Add(Me.Reg1_2)
        Me.Controls.Add(Me.Reg1_1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.txtBaudrate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Modbus sample1"
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBaudrate As TextBox
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Reg1_1 As Label
    Friend WithEvents Reg1_2 As Label
    Friend WithEvents Reg1_3 As Label
    Friend WithEvents Reg2_3 As Label
    Friend WithEvents Reg2_2 As Label
    Friend WithEvents Reg2_1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents EthernetIPforCLXCom1 As AdvancedHMIDrivers.EthernetIPforCLXCom
    Friend WithEvents Emailer1 As MfgControl.AdvancedHMI.Controls.Emailer
    Friend WithEvents Fan1 As MfgControl.AdvancedHMI.Controls.Fan
    Friend WithEvents Meter1 As MfgControl.AdvancedHMI.Controls.Meter
    Friend WithEvents SelectorSwitch1 As MfgControl.AdvancedHMI.Controls.SelectorSwitch
    Friend WithEvents Tank1 As MfgControl.AdvancedHMI.Controls.Tank
    Friend WithEvents Thermometer21 As MfgControl.AdvancedHMI.Controls.Thermometer2
    Friend WithEvents Motor1 As MfgControl.AdvancedHMI.Controls.Motor
End Class
