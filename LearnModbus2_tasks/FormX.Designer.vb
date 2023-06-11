<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormX
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
        Me.Reg2_3 = New System.Windows.Forms.Label()
        Me.Reg2_2 = New System.Windows.Forms.Label()
        Me.Reg2_1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Reg1_3 = New System.Windows.Forms.Label()
        Me.Reg1_2 = New System.Windows.Forms.Label()
        Me.Reg1_1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.txtBaudrate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.status = New System.Windows.Forms.Label()
        Me.AnalogValueDisplay1 = New AdvancedHMIControls.AnalogValueDisplay()
        Me.EthernetIPforCLXCom1 = New AdvancedHMIDrivers.EthernetIPforCLXCom(Me.components)
        Me.AnalogVisibilityController1 = New AdvancedHMIControls.AnalogVisibilityController()
        Me.BarLevel1 = New AdvancedHMIControls.BarLevel()
        Me.CircularProgressBar1 = New AdvancedHMIControls.CircularProgressBar()
        Me.ComBridge1 = New AdvancedHMIControls.ComBridge()
        Me.Gauge1 = New AdvancedHMIControls.Gauge()
        Me.MessageDisplayByBit1 = New AdvancedHMIControls.MessageDisplayByBit()
        Me.Meter21 = New AdvancedHMIControls.Meter2()
        Me.Motor1 = New AdvancedHMIControls.Motor()
        Me.TempController1 = New AdvancedHMIControls.TempController()
        Me.ThreeButtons1 = New AdvancedHMIControls.ThreeButtons()
        Me.Tank1 = New AdvancedHMIControls.Tank()
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnalogVisibilityController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CircularProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComBridge1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Reg2_3
        '
        Me.Reg2_3.AutoSize = True
        Me.Reg2_3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg2_3.Location = New System.Drawing.Point(474, 65)
        Me.Reg2_3.Name = "Reg2_3"
        Me.Reg2_3.Size = New System.Drawing.Size(21, 19)
        Me.Reg2_3.TabIndex = 56
        Me.Reg2_3.Text = "..."
        '
        'Reg2_2
        '
        Me.Reg2_2.AutoSize = True
        Me.Reg2_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg2_2.Location = New System.Drawing.Point(428, 65)
        Me.Reg2_2.Name = "Reg2_2"
        Me.Reg2_2.Size = New System.Drawing.Size(21, 19)
        Me.Reg2_2.TabIndex = 55
        Me.Reg2_2.Text = "..."
        '
        'Reg2_1
        '
        Me.Reg2_1.AutoSize = True
        Me.Reg2_1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg2_1.Location = New System.Drawing.Point(383, 65)
        Me.Reg2_1.Name = "Reg2_1"
        Me.Reg2_1.Size = New System.Drawing.Size(21, 19)
        Me.Reg2_1.TabIndex = 54
        Me.Reg2_1.Text = "..."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(476, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Reg3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(430, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Reg2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(384, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 12)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Reg1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(384, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 12)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Slave2"
        '
        'Reg1_3
        '
        Me.Reg1_3.AutoSize = True
        Me.Reg1_3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg1_3.Location = New System.Drawing.Point(328, 65)
        Me.Reg1_3.Name = "Reg1_3"
        Me.Reg1_3.Size = New System.Drawing.Size(21, 19)
        Me.Reg1_3.TabIndex = 49
        Me.Reg1_3.Text = "..."
        '
        'Reg1_2
        '
        Me.Reg1_2.AutoSize = True
        Me.Reg1_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg1_2.Location = New System.Drawing.Point(282, 65)
        Me.Reg1_2.Name = "Reg1_2"
        Me.Reg1_2.Size = New System.Drawing.Size(21, 19)
        Me.Reg1_2.TabIndex = 48
        Me.Reg1_2.Text = "..."
        '
        'Reg1_1
        '
        Me.Reg1_1.AutoSize = True
        Me.Reg1_1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reg1_1.Location = New System.Drawing.Point(237, 65)
        Me.Reg1_1.Name = "Reg1_1"
        Me.Reg1_1.Size = New System.Drawing.Size(21, 19)
        Me.Reg1_1.TabIndex = 47
        Me.Reg1_1.Text = "..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(330, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 12)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Reg3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(284, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 12)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Reg2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(238, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Reg1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 12)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Slave1"
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(33, 83)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(151, 31)
        Me.ButtonConnect.TabIndex = 42
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'txtBaudrate
        '
        Me.txtBaudrate.Location = New System.Drawing.Point(84, 55)
        Me.txtBaudrate.Name = "txtBaudrate"
        Me.txtBaudrate.Size = New System.Drawing.Size(100, 22)
        Me.txtBaudrate.TabIndex = 41
        Me.txtBaudrate.Text = "9600"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Baudrate"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(84, 27)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 22)
        Me.txtPort.TabIndex = 39
        Me.txtPort.Text = "COM1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 12)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Port"
        '
        'status
        '
        Me.status.AutoSize = True
        Me.status.Location = New System.Drawing.Point(31, 137)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(30, 12)
        Me.status.TabIndex = 57
        Me.status.Text = "status"
        '
        'AnalogValueDisplay1
        '
        Me.AnalogValueDisplay1.AutoSize = True
        Me.AnalogValueDisplay1.ComComponent = Me.EthernetIPforCLXCom1
        Me.AnalogValueDisplay1.ForeColor = System.Drawing.Color.White
        Me.AnalogValueDisplay1.ForeColorInLimits = System.Drawing.Color.White
        Me.AnalogValueDisplay1.ForeColorOverLimit = System.Drawing.Color.Red
        Me.AnalogValueDisplay1.ForeColorUnderLimit = System.Drawing.Color.Yellow
        Me.AnalogValueDisplay1.KeypadFontColor = System.Drawing.Color.WhiteSmoke
        Me.AnalogValueDisplay1.KeypadMaxValue = 0R
        Me.AnalogValueDisplay1.KeypadMinValue = 0R
        Me.AnalogValueDisplay1.KeypadPasscode = Nothing
        Me.AnalogValueDisplay1.KeypadScaleFactor = 1.0R
        Me.AnalogValueDisplay1.KeypadText = Nothing
        Me.AnalogValueDisplay1.KeypadWidth = 300
        Me.AnalogValueDisplay1.Location = New System.Drawing.Point(125, 229)
        Me.AnalogValueDisplay1.Name = "AnalogValueDisplay1"
        Me.AnalogValueDisplay1.NumericFormat = Nothing
        Me.AnalogValueDisplay1.PLCAddressKeypad = ""
        Me.AnalogValueDisplay1.PLCAddressValue = Nothing
        Me.AnalogValueDisplay1.PLCAddressValueLimitLower = Nothing
        Me.AnalogValueDisplay1.PLCAddressValueLimitUpper = Nothing
        Me.AnalogValueDisplay1.PLCAddressVisible = Nothing
        Me.AnalogValueDisplay1.ShowValue = True
        Me.AnalogValueDisplay1.Size = New System.Drawing.Size(29, 12)
        Me.AnalogValueDisplay1.TabIndex = 58
        Me.AnalogValueDisplay1.Text = "0000"
        Me.AnalogValueDisplay1.Value = "0000"
        Me.AnalogValueDisplay1.ValueLimitLower = -999999.0R
        Me.AnalogValueDisplay1.ValueLimitUpper = 999999.0R
        Me.AnalogValueDisplay1.ValuePrefix = Nothing
        Me.AnalogValueDisplay1.ValueSuffix = Nothing
        Me.AnalogValueDisplay1.VisibleControl = AdvancedHMIControls.AnalogValueDisplay.VisibleControlEnum.Always
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
        'AnalogVisibilityController1
        '
        Me.AnalogVisibilityController1.ComComponent = Me.EthernetIPforCLXCom1
        Me.AnalogVisibilityController1.PLCAddressValue = Nothing
        Me.AnalogVisibilityController1.TargetObject = Nothing
        Me.AnalogVisibilityController1.Value = Nothing
        Me.AnalogVisibilityController1.ValueCompareType = AdvancedHMIControls.AnalogVisibilityController.CompareTypeEnum.AboveTarget
        Me.AnalogVisibilityController1.ValueTarget = 1000.0R
        '
        'BarLevel1
        '
        Me.BarLevel1.BarContentColor = System.Drawing.Color.Red
        Me.BarLevel1.BorderColor = System.Drawing.Color.Wheat
        Me.BarLevel1.ComComponent = Me.EthernetIPforCLXCom1
        Me.BarLevel1.FillDirection = MfgControl.AdvancedHMI.Controls.BarLevel.FillDirectionEnum.Up
        Me.BarLevel1.FillStyle = MfgControl.AdvancedHMI.Controls.BarLevel.BarStyle.Hatch
        Me.BarLevel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BarLevel1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BarLevel1.HighlightColor = System.Drawing.Color.Red
        Me.BarLevel1.Location = New System.Drawing.Point(316, 326)
        Me.BarLevel1.Maximum = 100.0R
        Me.BarLevel1.Minimum = 0R
        Me.BarLevel1.Name = "BarLevel1"
        Me.BarLevel1.NumericFormat = Nothing
        Me.BarLevel1.ShowValue = True
        Me.BarLevel1.Size = New System.Drawing.Size(75, 23)
        Me.BarLevel1.TabIndex = 59
        Me.BarLevel1.Text = "BarLevel1"
        Me.BarLevel1.TextSuffix = Nothing
        Me.BarLevel1.Value = 0R
        Me.BarLevel1.ValueScaleFactor = 1.0R
        '
        'CircularProgressBar1
        '
        Me.CircularProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.CircularProgressBar1.ComComponent = Me.EthernetIPforCLXCom1
        Me.CircularProgressBar1.HighlightColor = System.Drawing.Color.Red
        Me.CircularProgressBar1.IniFileName = ""
        Me.CircularProgressBar1.IniFileSection = Nothing
        Me.CircularProgressBar1.Location = New System.Drawing.Point(151, 370)
        Me.CircularProgressBar1.Maximum = 100
        Me.CircularProgressBar1.Minimum = 0
        Me.CircularProgressBar1.Name = "CircularProgressBar1"
        Me.CircularProgressBar1.NumericFormat = Nothing
        Me.CircularProgressBar1.PenBackColor = System.Drawing.Color.White
        Me.CircularProgressBar1.PenForeColor = System.Drawing.Color.Lime
        Me.CircularProgressBar1.PenSize = 4
        Me.CircularProgressBar1.PLCAddressText = ""
        Me.CircularProgressBar1.PLCAddressValue = Nothing
        Me.CircularProgressBar1.PLCAddressVisible = ""
        Me.CircularProgressBar1.ShowValue = True
        Me.CircularProgressBar1.Size = New System.Drawing.Size(75, 23)
        Me.CircularProgressBar1.TabIndex = 60
        Me.CircularProgressBar1.Text = "CircularProgressBar1"
        Me.CircularProgressBar1.Value = 0R
        Me.CircularProgressBar1.ValueSuffix = "%"
        '
        'ComBridge1
        '
        Me.ComBridge1.ComComponent = Me.EthernetIPforCLXCom1
        Me.ComBridge1.ComComponentTarget = Nothing
        Me.ComBridge1.PLCAddressValue = Nothing
        Me.ComBridge1.PLCAddressValueTarget = Nothing
        Me.ComBridge1.Value = Nothing
        '
        'Gauge1
        '
        Me.Gauge1.AllowDragging = False
        Me.Gauge1.BackColor = System.Drawing.Color.Transparent
        Me.Gauge1.ComComponent = Me.EthernetIPforCLXCom1
        Me.Gauge1.HighlightColor = System.Drawing.Color.Red
        Me.Gauge1.Location = New System.Drawing.Point(316, 248)
        Me.Gauge1.Maximum = 100
        Me.Gauge1.Minimum = 0
        Me.Gauge1.Name = "Gauge1"
        Me.Gauge1.NumericFormat = Nothing
        Me.Gauge1.PLCAddressText = ""
        Me.Gauge1.PLCAddressValue = ""
        Me.Gauge1.PLCAddressVisible = ""
        Me.Gauge1.Size = New System.Drawing.Size(75, 75)
        Me.Gauge1.TabIndex = 61
        Me.Gauge1.Text = "Gauge1"
        Me.Gauge1.Value = 55.0R
        Me.Gauge1.ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'MessageDisplayByBit1
        '
        Me.MessageDisplayByBit1.AutoSize = True
        Me.MessageDisplayByBit1.ComComponent = Me.EthernetIPforCLXCom1
        Me.MessageDisplayByBit1.DefaultMessage = "No Messages"
        Me.MessageDisplayByBit1.DisplayTime = 3000
        Me.MessageDisplayByBit1.ForeColor = System.Drawing.Color.Transparent
        Me.MessageDisplayByBit1.HighlightColor = System.Drawing.Color.Red
        Me.MessageDisplayByBit1.HighlightKeyCharacter = "!"
        Me.MessageDisplayByBit1.IniFileName = Nothing
        Me.MessageDisplayByBit1.Location = New System.Drawing.Point(112, 370)
        Me.MessageDisplayByBit1.LogFile = Nothing
        Me.MessageDisplayByBit1.Name = "MessageDisplayByBit1"
        Me.MessageDisplayByBit1.PLCAddressValues = ""
        Me.MessageDisplayByBit1.PLCAddressVisible = ""
        Me.MessageDisplayByBit1.PLCElementBitWidth = 32
        Me.MessageDisplayByBit1.PLCNumberOfElements = 1
        Me.MessageDisplayByBit1.ShowMessageNumber = False
        Me.MessageDisplayByBit1.ShowUndefinedMessages = True
        Me.MessageDisplayByBit1.Size = New System.Drawing.Size(113, 12)
        Me.MessageDisplayByBit1.TabIndex = 62
        Me.MessageDisplayByBit1.Text = "MessageDisplayByBit1"
        Me.MessageDisplayByBit1.Value = CType(0, Long)
        Me.MessageDisplayByBit1.ValueBitMask = CType(0, Long)
        '
        'Meter21
        '
        Me.Meter21.ComComponent = Me.EthernetIPforCLXCom1
        Me.Meter21.ForeColor = System.Drawing.Color.LightGray
        Me.Meter21.HighlightColor = System.Drawing.Color.Red
        Me.Meter21.Location = New System.Drawing.Point(338, 408)
        Me.Meter21.Maximum = 100.0R
        Me.Meter21.Minimum = 0R
        Me.Meter21.Name = "Meter21"
        Me.Meter21.NumericFormat = Nothing
        Me.Meter21.PLCAddressText = ""
        Me.Meter21.PLCAddressValue = ""
        Me.Meter21.PLCAddressVisible = ""
        Me.Meter21.Size = New System.Drawing.Size(75, 50)
        Me.Meter21.TabIndex = 63
        Me.Meter21.Text = "Meter21"
        Me.Meter21.Value = 0R
        Me.Meter21.ValueScaleFactor = 1.0R
        '
        'Motor1
        '
        Me.Motor1.ComComponent = Me.EthernetIPforCLXCom1
        Me.Motor1.LightColor = MfgControl.AdvancedHMI.Controls.Motor.LightColors.Green
        Me.Motor1.Location = New System.Drawing.Point(229, 192)
        Me.Motor1.Name = "Motor1"
        Me.Motor1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.Motor1.PLCAddressClick = ""
        Me.Motor1.PLCAddressText = ""
        Me.Motor1.PLCAddressValue = ""
        Me.Motor1.PLCAddressVisible = ""
        Me.Motor1.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone
        Me.Motor1.Size = New System.Drawing.Size(93, 63)
        Me.Motor1.TabIndex = 64
        Me.Motor1.Text = "Motor1"
        Me.Motor1.Value = True
        '
        'TempController1
        '
        Me.TempController1.Button1Text = Nothing
        Me.TempController1.Button2Text = Nothing
        Me.TempController1.ComComponent = Me.EthernetIPforCLXCom1
        Me.TempController1.DecimalPosition = 0
        Me.TempController1.ForeColor = System.Drawing.Color.LightGray
        Me.TempController1.Location = New System.Drawing.Point(12, 326)
        Me.TempController1.Name = "TempController1"
        Me.TempController1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.TempController1.PLCAddressClick1 = ""
        Me.TempController1.PLCAddressClick2 = ""
        Me.TempController1.PLCAddressClick3 = ""
        Me.TempController1.PLCAddressClick4 = ""
        Me.TempController1.PLCAddressText = ""
        Me.TempController1.PLCAddressValuePV = ""
        Me.TempController1.PLCAddressValueSP = ""
        Me.TempController1.PLCAddressVisible = ""
        Me.TempController1.ScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TempController1.Size = New System.Drawing.Size(182, 183)
        Me.TempController1.TabIndex = 65
        Me.TempController1.Text = "TempController1"
        Me.TempController1.Value_ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TempController1.Value_ValueScaleFactorSP = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TempController1.Value2Text = "SP"
        Me.TempController1.ValuePV = 0!
        Me.TempController1.ValueSP = 0!
        '
        'ThreeButtons1
        '
        Me.ThreeButtons1.Button1Text = "Hand"
        Me.ThreeButtons1.Button2Text = "Auto"
        Me.ThreeButtons1.Button3Text = "Off"
        Me.ThreeButtons1.Location = New System.Drawing.Point(383, 178)
        Me.ThreeButtons1.Name = "ThreeButtons1"
        Me.ThreeButtons1.Size = New System.Drawing.Size(77, 39)
        Me.ThreeButtons1.TabIndex = 66
        '
        'Tank1
        '
        Me.Tank1.ComComponent = Me.EthernetIPforCLXCom1
        Me.Tank1.HighlightColor = System.Drawing.Color.Red
        Me.Tank1.HighlightKeyCharacter = "!"
        Me.Tank1.KeypadText = Nothing
        Me.Tank1.Location = New System.Drawing.Point(79, 178)
        Me.Tank1.MaxValue = 100
        Me.Tank1.MinValue = 0
        Me.Tank1.Name = "Tank1"
        Me.Tank1.NumericFormat = Nothing
        Me.Tank1.PLCAddressKeypad = ""
        Me.Tank1.PLCAddressText = ""
        Me.Tank1.PLCAddressValue = ""
        Me.Tank1.PLCAddressVisible = ""
        Me.Tank1.ScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Tank1.Size = New System.Drawing.Size(75, 98)
        Me.Tank1.TabIndex = 67
        Me.Tank1.TankContentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Tank1.Text = "Tank1"
        Me.Tank1.TextPrefix = Nothing
        Me.Tank1.TextSuffix = Nothing
        Me.Tank1.Value = 22.0!
        Me.Tank1.ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 514)
        Me.Controls.Add(Me.Tank1)
        Me.Controls.Add(Me.ThreeButtons1)
        Me.Controls.Add(Me.TempController1)
        Me.Controls.Add(Me.Motor1)
        Me.Controls.Add(Me.Meter21)
        Me.Controls.Add(Me.MessageDisplayByBit1)
        Me.Controls.Add(Me.Gauge1)
        Me.Controls.Add(Me.CircularProgressBar1)
        Me.Controls.Add(Me.BarLevel1)
        Me.Controls.Add(Me.AnalogValueDisplay1)
        Me.Controls.Add(Me.status)
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
        Me.Text = "22222"
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnalogVisibilityController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CircularProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComBridge1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Reg2_3 As Label
    Friend WithEvents Reg2_2 As Label
    Friend WithEvents Reg2_1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Reg1_3 As Label
    Friend WithEvents Reg1_2 As Label
    Friend WithEvents Reg1_1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents txtBaudrate As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents status As Label
    Friend WithEvents AnalogValueDisplay1 As AdvancedHMIControls.AnalogValueDisplay
    Friend WithEvents EthernetIPforCLXCom1 As AdvancedHMIDrivers.EthernetIPforCLXCom
    Friend WithEvents AnalogVisibilityController1 As AdvancedHMIControls.AnalogVisibilityController
    Friend WithEvents BarLevel1 As AdvancedHMIControls.BarLevel
    Friend WithEvents CircularProgressBar1 As AdvancedHMIControls.CircularProgressBar
    Friend WithEvents ComBridge1 As AdvancedHMIControls.ComBridge
    Friend WithEvents Gauge1 As AdvancedHMIControls.Gauge
    Friend WithEvents MessageDisplayByBit1 As AdvancedHMIControls.MessageDisplayByBit
    Friend WithEvents Meter21 As AdvancedHMIControls.Meter2
    Friend WithEvents Motor1 As AdvancedHMIControls.Motor
    Friend WithEvents TempController1 As AdvancedHMIControls.TempController
    Friend WithEvents ThreeButtons1 As AdvancedHMIControls.ThreeButtons
    Friend WithEvents Tank1 As AdvancedHMIControls.Tank
End Class
