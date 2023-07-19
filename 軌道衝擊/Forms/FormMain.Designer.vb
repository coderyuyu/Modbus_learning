<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Layout = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel_Messages = New System.Windows.Forms.Panel()
        Me.Panel_buttons = New System.Windows.Forms.Panel()
        Me.ButtonEnd = New System.Windows.Forms.Button()
        Me.ButtonStartRecord = New System.Windows.Forms.Button()
        Me.ButtonStart2 = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.isEMU = New System.Windows.Forms.CheckBox()
        Me.ButtonConsole = New System.Windows.Forms.Button()
        Me.ButtonTest = New System.Windows.Forms.Button()
        Me.ButtonLogs = New System.Windows.Forms.Button()
        Me.ButtonSettings = New System.Windows.Forms.Button()
        Me.Panel_Extras = New System.Windows.Forms.Panel()
        Me.Panel_Main = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.counter = New System.Windows.Forms.TextBox()
        Me.mainLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C = New MfgControl.AdvancedHMI.Controls.GraphicIndicator()
        Me.CylinderTons = New System.Windows.Forms.TextBox()
        Me.A = New MfgControl.AdvancedHMI.Controls.GraphicIndicator()
        Me.EthernetIPforCLXCom1 = New AdvancedHMIDrivers.EthernetIPforCLXCom(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.feq = New System.Windows.Forms.TextBox()
        Me.stopButton = New AdvancedHMIControls.MushroomButton()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Layout.SuspendLayout()
        Me.Panel_buttons.SuspendLayout()
        Me.Panel_Main.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Layout
        '
        Me.Layout.ColumnCount = 2
        Me.Layout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Layout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281.0!))
        Me.Layout.Controls.Add(Me.Panel_Messages, 0, 2)
        Me.Layout.Controls.Add(Me.Panel_buttons, 0, 1)
        Me.Layout.Controls.Add(Me.Panel_Extras, 1, 0)
        Me.Layout.Controls.Add(Me.Panel_Main, 0, 0)
        Me.Layout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Layout.Location = New System.Drawing.Point(0, 0)
        Me.Layout.Margin = New System.Windows.Forms.Padding(4)
        Me.Layout.Name = "Layout"
        Me.Layout.RowCount = 3
        Me.Layout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Layout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.Layout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.Layout.Size = New System.Drawing.Size(1247, 812)
        Me.Layout.TabIndex = 0
        '
        'Panel_Messages
        '
        Me.Panel_Messages.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Layout.SetColumnSpan(Me.Panel_Messages, 2)
        Me.Panel_Messages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Messages.Location = New System.Drawing.Point(4, 771)
        Me.Panel_Messages.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_Messages.Name = "Panel_Messages"
        Me.Panel_Messages.Size = New System.Drawing.Size(1239, 37)
        Me.Panel_Messages.TabIndex = 0
        '
        'Panel_buttons
        '
        Me.Panel_buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Layout.SetColumnSpan(Me.Panel_buttons, 2)
        Me.Panel_buttons.Controls.Add(Me.ButtonEnd)
        Me.Panel_buttons.Controls.Add(Me.ButtonStartRecord)
        Me.Panel_buttons.Controls.Add(Me.ButtonStart2)
        Me.Panel_buttons.Controls.Add(Me.ButtonStart)
        Me.Panel_buttons.Controls.Add(Me.isEMU)
        Me.Panel_buttons.Controls.Add(Me.ButtonConsole)
        Me.Panel_buttons.Controls.Add(Me.ButtonTest)
        Me.Panel_buttons.Controls.Add(Me.ButtonLogs)
        Me.Panel_buttons.Controls.Add(Me.ButtonSettings)
        Me.Panel_buttons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_buttons.Location = New System.Drawing.Point(4, 679)
        Me.Panel_buttons.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_buttons.Name = "Panel_buttons"
        Me.Panel_buttons.Size = New System.Drawing.Size(1239, 84)
        Me.Panel_buttons.TabIndex = 1
        '
        'ButtonEnd
        '
        Me.ButtonEnd.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonEnd.Location = New System.Drawing.Point(885, 17)
        Me.ButtonEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEnd.Name = "ButtonEnd"
        Me.ButtonEnd.Size = New System.Drawing.Size(100, 50)
        Me.ButtonEnd.TabIndex = 8
        Me.ButtonEnd.Text = "結束"
        Me.ButtonEnd.UseVisualStyleBackColor = True
        '
        'ButtonStartRecord
        '
        Me.ButtonStartRecord.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonStartRecord.Location = New System.Drawing.Point(336, 17)
        Me.ButtonStartRecord.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonStartRecord.Name = "ButtonStartRecord"
        Me.ButtonStartRecord.Size = New System.Drawing.Size(100, 50)
        Me.ButtonStartRecord.TabIndex = 7
        Me.ButtonStartRecord.Text = "開始記錄"
        Me.ButtonStartRecord.UseVisualStyleBackColor = True
        '
        'ButtonStart2
        '
        Me.ButtonStart2.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonStart2.Location = New System.Drawing.Point(228, 17)
        Me.ButtonStart2.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonStart2.Name = "ButtonStart2"
        Me.ButtonStart2.Size = New System.Drawing.Size(100, 50)
        Me.ButtonStart2.TabIndex = 6
        Me.ButtonStart2.Text = "雙點衝擊"
        Me.ButtonStart2.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonStart.Location = New System.Drawing.Point(120, 17)
        Me.ButtonStart.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(100, 50)
        Me.ButtonStart.TabIndex = 5
        Me.ButtonStart.Text = "啟動油壓"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'isEMU
        '
        Me.isEMU.AutoSize = True
        Me.isEMU.Enabled = False
        Me.isEMU.Font = New System.Drawing.Font("Microsoft JhengHei", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.isEMU.Location = New System.Drawing.Point(1051, 24)
        Me.isEMU.Margin = New System.Windows.Forms.Padding(4)
        Me.isEMU.Name = "isEMU"
        Me.isEMU.Size = New System.Drawing.Size(80, 34)
        Me.isEMU.TabIndex = 4
        Me.isEMU.Text = "模擬"
        Me.isEMU.UseVisualStyleBackColor = True
        '
        'ButtonConsole
        '
        Me.ButtonConsole.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonConsole.Location = New System.Drawing.Point(561, 17)
        Me.ButtonConsole.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonConsole.Name = "ButtonConsole"
        Me.ButtonConsole.Size = New System.Drawing.Size(100, 50)
        Me.ButtonConsole.TabIndex = 3
        Me.ButtonConsole.Text = "系統訊息"
        Me.ButtonConsole.UseVisualStyleBackColor = True
        '
        'ButtonTest
        '
        Me.ButtonTest.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonTest.Location = New System.Drawing.Point(777, 17)
        Me.ButtonTest.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonTest.Name = "ButtonTest"
        Me.ButtonTest.Size = New System.Drawing.Size(100, 50)
        Me.ButtonTest.TabIndex = 2
        Me.ButtonTest.Text = "測試"
        Me.ButtonTest.UseVisualStyleBackColor = True
        '
        'ButtonLogs
        '
        Me.ButtonLogs.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonLogs.Location = New System.Drawing.Point(669, 17)
        Me.ButtonLogs.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonLogs.Name = "ButtonLogs"
        Me.ButtonLogs.Size = New System.Drawing.Size(100, 50)
        Me.ButtonLogs.TabIndex = 1
        Me.ButtonLogs.Text = "記錄瀏覽"
        Me.ButtonLogs.UseVisualStyleBackColor = True
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonSettings.Location = New System.Drawing.Point(12, 17)
        Me.ButtonSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(100, 50)
        Me.ButtonSettings.TabIndex = 0
        Me.ButtonSettings.Text = "參數設定"
        Me.ButtonSettings.UseVisualStyleBackColor = True
        '
        'Panel_Extras
        '
        Me.Panel_Extras.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel_Extras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Extras.Location = New System.Drawing.Point(970, 4)
        Me.Panel_Extras.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_Extras.Name = "Panel_Extras"
        Me.Panel_Extras.Size = New System.Drawing.Size(273, 667)
        Me.Panel_Extras.TabIndex = 2
        '
        'Panel_Main
        '
        Me.Panel_Main.Controls.Add(Me.Chart1)
        Me.Panel_Main.Controls.Add(Me.stopButton)
        Me.Panel_Main.Controls.Add(Me.Panel1)
        Me.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Main.Location = New System.Drawing.Point(4, 4)
        Me.Panel_Main.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_Main.Name = "Panel_Main"
        Me.Panel_Main.Size = New System.Drawing.Size(958, 667)
        Me.Panel_Main.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.CylinderTons)
        Me.Panel1.Controls.Add(Me.feq)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.counter)
        Me.Panel1.Controls.Add(Me.mainLabel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.C)
        Me.Panel1.Controls.Add(Me.A)
        Me.Panel1.Location = New System.Drawing.Point(298, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 405)
        Me.Panel1.TabIndex = 0
        '
        'counter
        '
        Me.counter.Font = New System.Drawing.Font("Microsoft JhengHei", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.counter.Location = New System.Drawing.Point(77, 333)
        Me.counter.Margin = New System.Windows.Forms.Padding(4)
        Me.counter.Name = "counter"
        Me.counter.Size = New System.Drawing.Size(235, 46)
        Me.counter.TabIndex = 7
        Me.counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mainLabel
        '
        Me.mainLabel.AutoSize = True
        Me.mainLabel.Font = New System.Drawing.Font("Microsoft JhengHei", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.mainLabel.Location = New System.Drawing.Point(225, 14)
        Me.mainLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.mainLabel.Name = "mainLabel"
        Me.mainLabel.Size = New System.Drawing.Size(123, 61)
        Me.mainLabel.TabIndex = 0
        Me.mainLabel.Text = "力值"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft JhengHei", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(93, 266)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 61)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "累計次數"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'C
        '
        Me.C.Flash1 = False
        Me.C.Font2 = New System.Drawing.Font("Arial", 10.0!)
        Me.C.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.C.GraphicAllOff = Global.軌道衝擊.My.Resources.Resources.C0
        Me.C.GraphicSelect1 = Global.軌道衝擊.My.Resources.Resources.C1
        Me.C.GraphicSelect2 = Global.軌道衝擊.My.Resources.Resources.C2
        Me.C.Location = New System.Drawing.Point(206, 164)
        Me.C.Margin = New System.Windows.Forms.Padding(0)
        Me.C.Name = "C"
        Me.C.NumericFormat = Nothing
        Me.C.OutputType = MfgControl.AdvancedHMI.Controls.GraphicIndicator.OutputTypes.MomentarySet
        Me.C.RotationAngle = MfgControl.AdvancedHMI.Controls.GraphicIndicator.RotationAngleEnum.NoRotation
        Me.C.Size = New System.Drawing.Size(87, 89)
        Me.C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.C.TabIndex = 5
        Me.C.Text2 = ""
        Me.C.ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        Me.C.ValueSelect1 = False
        Me.C.ValueSelect2 = False
        '
        'CylinderTons
        '
        Me.CylinderTons.Enabled = False
        Me.CylinderTons.Font = New System.Drawing.Font("Microsoft JhengHei", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CylinderTons.Location = New System.Drawing.Point(206, 79)
        Me.CylinderTons.Margin = New System.Windows.Forms.Padding(4)
        Me.CylinderTons.Name = "CylinderTons"
        Me.CylinderTons.Size = New System.Drawing.Size(169, 71)
        Me.CylinderTons.TabIndex = 1
        Me.CylinderTons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'A
        '
        Me.A.Flash1 = False
        Me.A.Font2 = New System.Drawing.Font("Arial", 10.0!)
        Me.A.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.A.GraphicAllOff = Global.軌道衝擊.My.Resources.Resources.A0
        Me.A.GraphicSelect1 = Global.軌道衝擊.My.Resources.Resources.A1
        Me.A.GraphicSelect2 = Global.軌道衝擊.My.Resources.Resources.A2
        Me.A.Location = New System.Drawing.Point(104, 164)
        Me.A.Margin = New System.Windows.Forms.Padding(0)
        Me.A.Name = "A"
        Me.A.NumericFormat = Nothing
        Me.A.OutputType = MfgControl.AdvancedHMI.Controls.GraphicIndicator.OutputTypes.MomentarySet
        Me.A.RotationAngle = MfgControl.AdvancedHMI.Controls.GraphicIndicator.RotationAngleEnum.NoRotation
        Me.A.Size = New System.Drawing.Size(87, 89)
        Me.A.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.A.TabIndex = 4
        Me.A.Text2 = ""
        Me.A.ValueScaleFactor = New Decimal(New Integer() {1, 0, 0, 0})
        Me.A.ValueSelect1 = False
        Me.A.ValueSelect2 = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft JhengHei", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 61)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "頻率"
        '
        'feq
        '
        Me.feq.Enabled = False
        Me.feq.Font = New System.Drawing.Font("Microsoft JhengHei", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.feq.Location = New System.Drawing.Point(22, 79)
        Me.feq.Margin = New System.Windows.Forms.Padding(4)
        Me.feq.Name = "feq"
        Me.feq.Size = New System.Drawing.Size(169, 71)
        Me.feq.TabIndex = 9
        Me.feq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'stopButton
        '
        Me.stopButton.ComComponent = Me.EthernetIPforCLXCom1
        Me.stopButton.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.stopButton.LegendPlate = MfgControl.AdvancedHMI.Controls.MushroomButton.LegendPlates.Large
        Me.stopButton.Location = New System.Drawing.Point(692, 334)
        Me.stopButton.MaximumHoldTime = 3000
        Me.stopButton.MinimumHoldTime = 500
        Me.stopButton.Name = "stopButton"
        Me.stopButton.OutputType = MfgControl.AdvancedHMI.Controls.MushroomButton.OutputTypes.MomentarySet
        Me.stopButton.PLCAddressClick = ""
        Me.stopButton.PLCAddressVisible = ""
        Me.stopButton.Size = New System.Drawing.Size(77, 113)
        Me.stopButton.TabIndex = 1
        Me.stopButton.Text = "緊急關機"
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(37, 453)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(892, 190)
        Me.Chart1.TabIndex = 2
        Me.Chart1.Text = "Chart1"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1247, 812)
        Me.Controls.Add(Me.Layout)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMain"
        Me.Text = "軌道衝擊"
        Me.Layout.ResumeLayout(False)
        Me.Panel_buttons.ResumeLayout(False)
        Me.Panel_buttons.PerformLayout()
        Me.Panel_Main.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.EthernetIPforCLXCom1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Layout As TableLayoutPanel
    Friend WithEvents Panel_Messages As Panel
    Friend WithEvents Panel_buttons As Panel
    Friend WithEvents Panel_Extras As Panel
    Friend WithEvents Panel_Main As Panel
    Friend WithEvents ButtonSettings As Button
    Friend WithEvents ButtonLogs As Button
    Friend WithEvents ButtonTest As Button
    Friend WithEvents ButtonConsole As Button
    Friend WithEvents isEMU As CheckBox
    Friend WithEvents ButtonStartRecord As Button
    Friend WithEvents ButtonStart2 As Button
    Friend WithEvents ButtonStart As Button
    Friend WithEvents EthernetIPforCLXCom1 As AdvancedHMIDrivers.EthernetIPforCLXCom
    Friend WithEvents CylinderTons As TextBox
    Friend WithEvents mainLabel As Label
    Friend WithEvents A As MfgControl.AdvancedHMI.Controls.GraphicIndicator
    Friend WithEvents C As MfgControl.AdvancedHMI.Controls.GraphicIndicator
    Friend WithEvents ButtonEnd As Button
    Friend WithEvents counter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents feq As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents stopButton As AdvancedHMIControls.MushroomButton
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class
