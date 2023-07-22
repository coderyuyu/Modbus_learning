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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PanelParameter = New System.Windows.Forms.Panel()
        Me.isEmulate = New System.Windows.Forms.CheckBox()
        Me.oDec = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.iDec = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.iSetpoint = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Kp = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Ki = New System.Windows.Forms.NumericUpDown()
        Me.oInit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Kd = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.oMax = New System.Windows.Forms.TextBox()
        Me.interval = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.oMin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.inputCom = New System.Windows.Forms.ComboBox()
        Me.outputCom = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.iSlave = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.iAddress = New System.Windows.Forms.TextBox()
        Me.oLength = New System.Windows.Forms.TextBox()
        Me.iLength = New System.Windows.Forms.TextBox()
        Me.oAddress = New System.Windows.Forms.TextBox()
        Me.oSlave = New System.Windows.Forms.TextBox()
        Me.PidOutput = New System.Windows.Forms.TextBox()
        Me.PidError = New System.Windows.Forms.TextBox()
        Me.PidInput = New System.Windows.Forms.TextBox()
        Me.pidSetpoint = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelParameter.SuspendLayout()
        CType(Me.Kp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ki, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Kd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.interval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chart1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1129, 755)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(1123, 499)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.NumericUpDown2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 508)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1123, 244)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PanelParameter)
        Me.Panel2.Controls.Add(Me.PidOutput)
        Me.Panel2.Controls.Add(Me.PidError)
        Me.Panel2.Controls.Add(Me.PidInput)
        Me.Panel2.Controls.Add(Me.pidSetpoint)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1123, 244)
        Me.Panel2.TabIndex = 4
        '
        'PanelParameter
        '
        Me.PanelParameter.Controls.Add(Me.isEmulate)
        Me.PanelParameter.Controls.Add(Me.oDec)
        Me.PanelParameter.Controls.Add(Me.Label22)
        Me.PanelParameter.Controls.Add(Me.iDec)
        Me.PanelParameter.Controls.Add(Me.Label21)
        Me.PanelParameter.Controls.Add(Me.iSetpoint)
        Me.PanelParameter.Controls.Add(Me.Label20)
        Me.PanelParameter.Controls.Add(Me.Label9)
        Me.PanelParameter.Controls.Add(Me.Label16)
        Me.PanelParameter.Controls.Add(Me.Label2)
        Me.PanelParameter.Controls.Add(Me.Label17)
        Me.PanelParameter.Controls.Add(Me.Kp)
        Me.PanelParameter.Controls.Add(Me.Label18)
        Me.PanelParameter.Controls.Add(Me.Label3)
        Me.PanelParameter.Controls.Add(Me.Label19)
        Me.PanelParameter.Controls.Add(Me.Ki)
        Me.PanelParameter.Controls.Add(Me.oInit)
        Me.PanelParameter.Controls.Add(Me.Label4)
        Me.PanelParameter.Controls.Add(Me.Label15)
        Me.PanelParameter.Controls.Add(Me.Kd)
        Me.PanelParameter.Controls.Add(Me.Label5)
        Me.PanelParameter.Controls.Add(Me.ButtonStart)
        Me.PanelParameter.Controls.Add(Me.oMax)
        Me.PanelParameter.Controls.Add(Me.interval)
        Me.PanelParameter.Controls.Add(Me.Label14)
        Me.PanelParameter.Controls.Add(Me.Label6)
        Me.PanelParameter.Controls.Add(Me.oMin)
        Me.PanelParameter.Controls.Add(Me.Label7)
        Me.PanelParameter.Controls.Add(Me.Label13)
        Me.PanelParameter.Controls.Add(Me.Label8)
        Me.PanelParameter.Controls.Add(Me.inputCom)
        Me.PanelParameter.Controls.Add(Me.outputCom)
        Me.PanelParameter.Controls.Add(Me.Label10)
        Me.PanelParameter.Controls.Add(Me.Label11)
        Me.PanelParameter.Controls.Add(Me.Label12)
        Me.PanelParameter.Controls.Add(Me.iSlave)
        Me.PanelParameter.Controls.Add(Me.Button2)
        Me.PanelParameter.Controls.Add(Me.iAddress)
        Me.PanelParameter.Controls.Add(Me.oLength)
        Me.PanelParameter.Controls.Add(Me.iLength)
        Me.PanelParameter.Controls.Add(Me.oAddress)
        Me.PanelParameter.Controls.Add(Me.oSlave)
        Me.PanelParameter.Location = New System.Drawing.Point(9, 16)
        Me.PanelParameter.Name = "PanelParameter"
        Me.PanelParameter.Size = New System.Drawing.Size(734, 217)
        Me.PanelParameter.TabIndex = 51
        '
        'isEmulate
        '
        Me.isEmulate.AutoSize = True
        Me.isEmulate.Checked = True
        Me.isEmulate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.isEmulate.Location = New System.Drawing.Point(654, 88)
        Me.isEmulate.Name = "isEmulate"
        Me.isEmulate.Size = New System.Drawing.Size(62, 16)
        Me.isEmulate.TabIndex = 57
        Me.isEmulate.Text = "Emulate"
        Me.isEmulate.UseVisualStyleBackColor = True
        '
        'oDec
        '
        Me.oDec.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oDec.Location = New System.Drawing.Point(467, 113)
        Me.oDec.Name = "oDec"
        Me.oDec.Size = New System.Drawing.Size(44, 31)
        Me.oDec.TabIndex = 56
        Me.oDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(463, 85)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 23)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "Decimal"
        '
        'iDec
        '
        Me.iDec.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iDec.Location = New System.Drawing.Point(467, 46)
        Me.iDec.Name = "iDec"
        Me.iDec.Size = New System.Drawing.Size(44, 31)
        Me.iDec.TabIndex = 54
        Me.iDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(463, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 23)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Decimal"
        '
        'iSetpoint
        '
        Me.iSetpoint.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iSetpoint.Location = New System.Drawing.Point(390, 46)
        Me.iSetpoint.Name = "iSetpoint"
        Me.iSetpoint.Size = New System.Drawing.Size(60, 31)
        Me.iSetpoint.TabIndex = 52
        Me.iSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(386, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 23)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "Set point"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(66, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 23)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Port"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(70, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 23)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Port"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kp"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(331, 85)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 23)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Length"
        '
        'Kp
        '
        Me.Kp.DecimalPlaces = 1
        Me.Kp.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kp.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Kp.Location = New System.Drawing.Point(72, 165)
        Me.Kp.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Kp.Name = "Kp"
        Me.Kp.Size = New System.Drawing.Size(88, 31)
        Me.Kp.TabIndex = 4
        Me.Kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(241, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 23)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(178, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ki"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(170, 85)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 23)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Slave"
        '
        'Ki
        '
        Me.Ki.DecimalPlaces = 1
        Me.Ki.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ki.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Ki.Location = New System.Drawing.Point(222, 165)
        Me.Ki.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.Ki.Name = "Ki"
        Me.Ki.Size = New System.Drawing.Size(88, 31)
        Me.Ki.TabIndex = 6
        Me.Ki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'oInit
        '
        Me.oInit.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oInit.Location = New System.Drawing.Point(390, 113)
        Me.oInit.Name = "oInit"
        Me.oInit.Size = New System.Drawing.Size(60, 31)
        Me.oInit.TabIndex = 46
        Me.oInit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(326, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 29)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Kd"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(396, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 23)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Initial"
        '
        'Kd
        '
        Me.Kd.DecimalPlaces = 1
        Me.Kd.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kd.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.Kd.Location = New System.Drawing.Point(375, 164)
        Me.Kd.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.Kd.Name = "Kd"
        Me.Kd.Size = New System.Drawing.Size(88, 31)
        Me.Kd.TabIndex = 8
        Me.Kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(566, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 23)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Interval"
        '
        'ButtonStart
        '
        Me.ButtonStart.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStart.Location = New System.Drawing.Point(651, 117)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(80, 88)
        Me.ButtonStart.TabIndex = 9
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'oMax
        '
        Me.oMax.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oMax.Location = New System.Drawing.Point(589, 113)
        Me.oMax.Name = "oMax"
        Me.oMax.Size = New System.Drawing.Size(60, 31)
        Me.oMax.TabIndex = 43
        Me.oMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'interval
        '
        Me.interval.DecimalPlaces = 1
        Me.interval.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.interval.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.interval.Location = New System.Drawing.Point(570, 46)
        Me.interval.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.interval.Name = "interval"
        Me.interval.Size = New System.Drawing.Size(88, 31)
        Me.interval.TabIndex = 10
        Me.interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(589, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 23)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Max"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(664, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "sec"
        '
        'oMin
        '
        Me.oMin.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oMin.Location = New System.Drawing.Point(523, 113)
        Me.oMin.Name = "oMin"
        Me.oMin.Size = New System.Drawing.Size(60, 31)
        Me.oMin.TabIndex = 41
        Me.oMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Input"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(531, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 23)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Min"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Output"
        '
        'inputCom
        '
        Me.inputCom.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputCom.FormattingEnabled = True
        Me.inputCom.Location = New System.Drawing.Point(70, 46)
        Me.inputCom.Name = "inputCom"
        Me.inputCom.Size = New System.Drawing.Size(94, 31)
        Me.inputCom.TabIndex = 15
        '
        'outputCom
        '
        Me.outputCom.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outputCom.FormattingEnabled = True
        Me.outputCom.Location = New System.Drawing.Point(70, 113)
        Me.outputCom.Name = "outputCom"
        Me.outputCom.Size = New System.Drawing.Size(94, 31)
        Me.outputCom.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(166, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 23)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Slave"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(237, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 23)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Address"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(327, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 23)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Length"
        '
        'iSlave
        '
        Me.iSlave.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iSlave.Location = New System.Drawing.Point(170, 46)
        Me.iSlave.Name = "iSlave"
        Me.iSlave.Size = New System.Drawing.Size(60, 31)
        Me.iSlave.TabIndex = 25
        Me.iSlave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(549, 157)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 40)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'iAddress
        '
        Me.iAddress.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iAddress.Location = New System.Drawing.Point(241, 46)
        Me.iAddress.Name = "iAddress"
        Me.iAddress.Size = New System.Drawing.Size(84, 31)
        Me.iAddress.TabIndex = 26
        Me.iAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'oLength
        '
        Me.oLength.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oLength.Location = New System.Drawing.Point(331, 113)
        Me.oLength.Name = "oLength"
        Me.oLength.Size = New System.Drawing.Size(44, 31)
        Me.oLength.TabIndex = 31
        Me.oLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'iLength
        '
        Me.iLength.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.iLength.Location = New System.Drawing.Point(331, 46)
        Me.iLength.Name = "iLength"
        Me.iLength.Size = New System.Drawing.Size(44, 31)
        Me.iLength.TabIndex = 27
        Me.iLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'oAddress
        '
        Me.oAddress.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oAddress.Location = New System.Drawing.Point(241, 113)
        Me.oAddress.Name = "oAddress"
        Me.oAddress.Size = New System.Drawing.Size(84, 31)
        Me.oAddress.TabIndex = 30
        Me.oAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'oSlave
        '
        Me.oSlave.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.oSlave.Location = New System.Drawing.Point(170, 113)
        Me.oSlave.Name = "oSlave"
        Me.oSlave.Size = New System.Drawing.Size(60, 31)
        Me.oSlave.TabIndex = 29
        Me.oSlave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PidOutput
        '
        Me.PidOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PidOutput.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PidOutput.Location = New System.Drawing.Point(1020, 173)
        Me.PidOutput.Name = "PidOutput"
        Me.PidOutput.Size = New System.Drawing.Size(75, 23)
        Me.PidOutput.TabIndex = 39
        Me.PidOutput.Text = "16.7"
        Me.PidOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PidError
        '
        Me.PidError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PidError.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PidError.Location = New System.Drawing.Point(1031, 80)
        Me.PidError.Name = "PidError"
        Me.PidError.Size = New System.Drawing.Size(64, 23)
        Me.PidError.TabIndex = 38
        Me.PidError.Text = "2.2"
        Me.PidError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PidInput
        '
        Me.PidInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PidInput.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PidInput.Location = New System.Drawing.Point(993, 54)
        Me.PidInput.Name = "PidInput"
        Me.PidInput.Size = New System.Drawing.Size(76, 23)
        Me.PidInput.TabIndex = 37
        Me.PidInput.Text = "18"
        Me.PidInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pidSetpoint
        '
        Me.pidSetpoint.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pidSetpoint.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pidSetpoint.Location = New System.Drawing.Point(988, 27)
        Me.pidSetpoint.Name = "pidSetpoint"
        Me.pidSetpoint.Size = New System.Drawing.Size(64, 23)
        Me.pidSetpoint.TabIndex = 36
        Me.pidSetpoint.Text = "20.2"
        Me.pidSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(749, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(359, 220)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 35
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(102, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 59)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Kp"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft JhengHei", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.NumericUpDown2.Location = New System.Drawing.Point(361, 12)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(159, 71)
        Me.NumericUpDown2.TabIndex = 2
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 71)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "設定"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1129, 755)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "PID tuning"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelParameter.ResumeLayout(False)
        Me.PanelParameter.PerformLayout()
        CType(Me.Kp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ki, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Kd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.interval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Kd As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Ki As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Kp As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Button1 As Button
    Friend WithEvents outputCom As ComboBox
    Friend WithEvents inputCom As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents interval As NumericUpDown
    Friend WithEvents ButtonStart As Button
    Friend WithEvents oLength As TextBox
    Friend WithEvents oAddress As TextBox
    Friend WithEvents oSlave As TextBox
    Friend WithEvents iLength As TextBox
    Friend WithEvents iAddress As TextBox
    Friend WithEvents iSlave As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents oInit As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents oMax As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents oMin As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents PidOutput As TextBox
    Friend WithEvents PidError As TextBox
    Friend WithEvents PidInput As TextBox
    Friend WithEvents pidSetpoint As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelParameter As Panel
    Friend WithEvents iSetpoint As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents oDec As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents iDec As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents isEmulate As CheckBox
End Class
