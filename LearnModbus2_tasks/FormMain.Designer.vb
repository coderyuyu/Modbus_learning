<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
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
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.t2 = New AdvancedHMIControls.GaugeCompact()
        Me.EthernetIPforCLXCom1 = New AdvancedHMIDrivers.EthernetIPforCLXCom(Me.components)
        Me.t1 = New AdvancedHMIControls.GaugeCompact()
        Me.Fan2 = New MfgControl.AdvancedHMI.Controls.Fan()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fanSwitch2 = New AdvancedHMIControls.SelectorSwitch()
        Me.fanSwitch1 = New AdvancedHMIControls.SelectorSwitch()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.isEmulate = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.Fan1.Font = New System.Drawing.Font("Microsoft JhengHei", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Fan1.ForeColor = System.Drawing.Color.White
        Me.Fan1.Location = New System.Drawing.Point(213, 91)
        Me.Fan1.Name = "Fan1"
        Me.Fan1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.Fan1.Size = New System.Drawing.Size(148, 148)
        Me.Fan1.TabIndex = 48
        Me.Fan1.Text = "#1"
        Me.Fan1.TextPosition = System.Drawing.StringAlignment.Center
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
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.85943!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.14058!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1005, 626)
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 535)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(999, 67)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Chart2)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Controls.Add(Me.t2)
        Me.Panel1.Controls.Add(Me.t1)
        Me.Panel1.Controls.Add(Me.Fan2)
        Me.Panel1.Controls.Add(Me.Fan1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 526)
        Me.Panel1.TabIndex = 1
        '
        'Chart2
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend1)
        Me.Chart2.Location = New System.Drawing.Point(419, 263)
        Me.Chart2.Name = "Chart2"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(302, 228)
        Me.Chart2.TabIndex = 54
        Me.Chart2.Text = "Chart2"
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(59, 263)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(302, 228)
        Me.Chart1.TabIndex = 53
        Me.Chart1.Text = "Chart1"
        '
        't2
        '
        Me.t2.BackColor = System.Drawing.Color.Transparent
        Me.t2.Band1Color = System.Drawing.Color.Red
        Me.t2.Band1EndValue = 100.0R
        Me.t2.Band1StartValue = 61.0R
        Me.t2.Band2Color = System.Drawing.Color.Yellow
        Me.t2.Band2EndValue = 60.0R
        Me.t2.Band2StartValue = 50.0R
        Me.t2.BorderColor = System.Drawing.Color.DimGray
        Me.t2.BorderWidth = 0
        Me.t2.ComComponent = Me.EthernetIPforCLXCom1
        Me.t2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.t2.ForeColor = System.Drawing.Color.LightGray
        Me.t2.HighlightColor = System.Drawing.Color.Red
        Me.t2.Location = New System.Drawing.Point(419, 91)
        Me.t2.MajorTickColor = System.Drawing.Color.DimGray
        Me.t2.MajorTickDivisions = 10
        Me.t2.MajorTickLength = 15
        Me.t2.Maximum = 100.0R
        Me.t2.Minimum = 0R
        Me.t2.MinorTickColor = System.Drawing.Color.DimGray
        Me.t2.MinorTickDivisions = 5
        Me.t2.Name = "t2"
        Me.t2.NeedleColor = System.Drawing.Color.Maroon
        Me.t2.NumericFormat = Nothing
        Me.t2.PLCAddressText = ""
        Me.t2.PLCAddressValue = Nothing
        Me.t2.PLCAddressVisible = ""
        Me.t2.ShowLabels = True
        Me.t2.Size = New System.Drawing.Size(148, 148)
        Me.t2.TabIndex = 52
        Me.t2.TickMarkInset = 0
        Me.t2.Value = 28.0R
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
        't1
        '
        Me.t1.BackColor = System.Drawing.Color.Transparent
        Me.t1.Band1Color = System.Drawing.Color.Red
        Me.t1.Band1EndValue = 100.0R
        Me.t1.Band1StartValue = 61.0R
        Me.t1.Band2Color = System.Drawing.Color.Yellow
        Me.t1.Band2EndValue = 60.0R
        Me.t1.Band2StartValue = 50.0R
        Me.t1.BorderColor = System.Drawing.Color.DimGray
        Me.t1.BorderWidth = 0
        Me.t1.ComComponent = Me.EthernetIPforCLXCom1
        Me.t1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.t1.ForeColor = System.Drawing.Color.LightGray
        Me.t1.HighlightColor = System.Drawing.Color.Red
        Me.t1.Location = New System.Drawing.Point(59, 91)
        Me.t1.MajorTickColor = System.Drawing.Color.DimGray
        Me.t1.MajorTickDivisions = 10
        Me.t1.MajorTickLength = 15
        Me.t1.Maximum = 100.0R
        Me.t1.Minimum = 0R
        Me.t1.MinorTickColor = System.Drawing.Color.DimGray
        Me.t1.MinorTickDivisions = 5
        Me.t1.Name = "t1"
        Me.t1.NeedleColor = System.Drawing.Color.Maroon
        Me.t1.NumericFormat = Nothing
        Me.t1.PLCAddressText = ""
        Me.t1.PLCAddressValue = Nothing
        Me.t1.PLCAddressVisible = ""
        Me.t1.ShowLabels = True
        Me.t1.Size = New System.Drawing.Size(148, 148)
        Me.t1.TabIndex = 51
        Me.t1.TickMarkInset = 0
        Me.t1.Value = 25.0R
        '
        'Fan2
        '
        Me.Fan2.Direction = False
        Me.Fan2.Font = New System.Drawing.Font("Microsoft JhengHei", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Fan2.ForeColor = System.Drawing.Color.White
        Me.Fan2.Location = New System.Drawing.Point(573, 91)
        Me.Fan2.Name = "Fan2"
        Me.Fan2.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.Fan2.Size = New System.Drawing.Size(148, 148)
        Me.Fan2.TabIndex = 49
        Me.Fan2.Text = "#2"
        Me.Fan2.TextPosition = System.Drawing.StringAlignment.Center
        Me.Fan2.Value = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.fanSwitch2)
        Me.Panel2.Controls.Add(Me.fanSwitch1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(795, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(207, 526)
        Me.Panel2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(114, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "OFF      ON"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "OFF      ON"
        '
        'fanSwitch2
        '
        Me.fanSwitch2.BackColor = System.Drawing.Color.Transparent
        Me.fanSwitch2.BackgroundImage = CType(resources.GetObject("fanSwitch2.BackgroundImage"), System.Drawing.Image)
        Me.fanSwitch2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.fanSwitch2.ComComponent = Me.EthernetIPforCLXCom1
        Me.fanSwitch2.LegendPlate = MfgControl.AdvancedHMI.Controls.SelectorSwitch.LegendPlates.Large
        Me.fanSwitch2.Location = New System.Drawing.Point(112, 69)
        Me.fanSwitch2.Name = "fanSwitch2"
        Me.fanSwitch2.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.fanSwitch2.PLCAddressClick = ""
        Me.fanSwitch2.PLCAddressText = ""
        Me.fanSwitch2.PLCAddressValue = ""
        Me.fanSwitch2.PLCAddressVisible = ""
        Me.fanSwitch2.Size = New System.Drawing.Size(62, 91)
        Me.fanSwitch2.TabIndex = 3
        Me.fanSwitch2.Text = "風扇#2"
        Me.fanSwitch2.Value = False
        '
        'fanSwitch1
        '
        Me.fanSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.fanSwitch1.BackgroundImage = CType(resources.GetObject("fanSwitch1.BackgroundImage"), System.Drawing.Image)
        Me.fanSwitch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.fanSwitch1.ComComponent = Me.EthernetIPforCLXCom1
        Me.fanSwitch1.LegendPlate = MfgControl.AdvancedHMI.Controls.SelectorSwitch.LegendPlates.Large
        Me.fanSwitch1.Location = New System.Drawing.Point(23, 69)
        Me.fanSwitch1.Name = "fanSwitch1"
        Me.fanSwitch1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet
        Me.fanSwitch1.PLCAddressClick = ""
        Me.fanSwitch1.PLCAddressText = ""
        Me.fanSwitch1.PLCAddressValue = ""
        Me.fanSwitch1.PLCAddressVisible = ""
        Me.fanSwitch1.Size = New System.Drawing.Size(62, 91)
        Me.fanSwitch1.TabIndex = 1
        Me.fanSwitch1.Text = "風扇#1"
        Me.fanSwitch1.Value = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.isEmulate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 377)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 136)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "僅開發環境模擬用"
        '
        'isEmulate
        '
        Me.isEmulate.AutoSize = True
        Me.isEmulate.Checked = True
        Me.isEmulate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.isEmulate.Location = New System.Drawing.Point(10, 106)
        Me.isEmulate.Name = "isEmulate"
        Me.isEmulate.Size = New System.Drawing.Size(92, 24)
        Me.isEmulate.TabIndex = 1
        Me.isEmulate.Text = "啟用模擬"
        Me.isEmulate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 60)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "風扇" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "啟動時每秒降溫0.2度" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "未啟動時每秒升溫0.1度"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1005, 22)
        Me.StatusStrip1.TabIndex = 55
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(10, 17)
        Me.status.Text = "."
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1005, 626)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormMain"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents status As ToolStripStatusLabel
    Friend WithEvents t2 As AdvancedHMIControls.GaugeCompact
    Friend WithEvents EthernetIPforCLXCom1 As AdvancedHMIDrivers.EthernetIPforCLXCom
    Friend WithEvents t1 As AdvancedHMIControls.GaugeCompact
    Friend WithEvents Fan2 As MfgControl.AdvancedHMI.Controls.Fan
    Friend WithEvents fanSwitch2 As AdvancedHMIControls.SelectorSwitch
    Friend WithEvents fanSwitch1 As AdvancedHMIControls.SelectorSwitch
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents isEmulate As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class
