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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Layout = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel_Messages = New System.Windows.Forms.Panel()
        Me.Panel_buttons = New System.Windows.Forms.Panel()
        Me.isEMU = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonTest = New System.Windows.Forms.Button()
        Me.ButtonLogs = New System.Windows.Forms.Button()
        Me.ButtonSettings = New System.Windows.Forms.Button()
        Me.Panel_Extras = New System.Windows.Forms.Panel()
        Me.Panel_Main = New System.Windows.Forms.Panel()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonStart2 = New System.Windows.Forms.Button()
        Me.ButtonStartRecord = New System.Windows.Forms.Button()
        Me.Layout.SuspendLayout()
        Me.Panel_buttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Layout
        '
        Me.Layout.ColumnCount = 2
        Me.Layout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Layout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211.0!))
        Me.Layout.Controls.Add(Me.Panel_Messages, 0, 2)
        Me.Layout.Controls.Add(Me.Panel_buttons, 0, 1)
        Me.Layout.Controls.Add(Me.Panel_Extras, 1, 0)
        Me.Layout.Controls.Add(Me.Panel_Main, 0, 0)
        Me.Layout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Layout.Location = New System.Drawing.Point(0, 0)
        Me.Layout.Name = "Layout"
        Me.Layout.RowCount = 3
        Me.Layout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Layout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.Layout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.Layout.Size = New System.Drawing.Size(935, 573)
        Me.Layout.TabIndex = 0
        '
        'Panel_Messages
        '
        Me.Panel_Messages.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Layout.SetColumnSpan(Me.Panel_Messages, 2)
        Me.Panel_Messages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Messages.Location = New System.Drawing.Point(3, 544)
        Me.Panel_Messages.Name = "Panel_Messages"
        Me.Panel_Messages.Size = New System.Drawing.Size(929, 26)
        Me.Panel_Messages.TabIndex = 0
        '
        'Panel_buttons
        '
        Me.Panel_buttons.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Layout.SetColumnSpan(Me.Panel_buttons, 2)
        Me.Panel_buttons.Controls.Add(Me.ButtonStartRecord)
        Me.Panel_buttons.Controls.Add(Me.ButtonStart2)
        Me.Panel_buttons.Controls.Add(Me.ButtonStart)
        Me.Panel_buttons.Controls.Add(Me.isEMU)
        Me.Panel_buttons.Controls.Add(Me.Button1)
        Me.Panel_buttons.Controls.Add(Me.ButtonTest)
        Me.Panel_buttons.Controls.Add(Me.ButtonLogs)
        Me.Panel_buttons.Controls.Add(Me.ButtonSettings)
        Me.Panel_buttons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_buttons.Location = New System.Drawing.Point(3, 479)
        Me.Panel_buttons.Name = "Panel_buttons"
        Me.Panel_buttons.Size = New System.Drawing.Size(929, 59)
        Me.Panel_buttons.TabIndex = 1
        '
        'isEMU
        '
        Me.isEMU.AutoSize = True
        Me.isEMU.Location = New System.Drawing.Point(825, 22)
        Me.isEMU.Name = "isEMU"
        Me.isEMU.Size = New System.Drawing.Size(48, 16)
        Me.isEMU.TabIndex = 4
        Me.isEMU.Text = "模擬"
        Me.isEMU.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(421, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "系統訊息"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonTest
        '
        Me.ButtonTest.Location = New System.Drawing.Point(583, 12)
        Me.ButtonTest.Name = "ButtonTest"
        Me.ButtonTest.Size = New System.Drawing.Size(75, 35)
        Me.ButtonTest.TabIndex = 2
        Me.ButtonTest.Text = "測試"
        Me.ButtonTest.UseVisualStyleBackColor = True
        '
        'ButtonLogs
        '
        Me.ButtonLogs.Location = New System.Drawing.Point(502, 12)
        Me.ButtonLogs.Name = "ButtonLogs"
        Me.ButtonLogs.Size = New System.Drawing.Size(75, 35)
        Me.ButtonLogs.TabIndex = 1
        Me.ButtonLogs.Text = "資料瀏覽"
        Me.ButtonLogs.UseVisualStyleBackColor = True
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Location = New System.Drawing.Point(9, 12)
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(75, 35)
        Me.ButtonSettings.TabIndex = 0
        Me.ButtonSettings.Text = "參數設定"
        Me.ButtonSettings.UseVisualStyleBackColor = True
        '
        'Panel_Extras
        '
        Me.Panel_Extras.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel_Extras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Extras.Location = New System.Drawing.Point(727, 3)
        Me.Panel_Extras.Name = "Panel_Extras"
        Me.Panel_Extras.Size = New System.Drawing.Size(205, 470)
        Me.Panel_Extras.TabIndex = 2
        '
        'Panel_Main
        '
        Me.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Main.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Main.Name = "Panel_Main"
        Me.Panel_Main.Size = New System.Drawing.Size(718, 470)
        Me.Panel_Main.TabIndex = 3
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(90, 12)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 35)
        Me.ButtonStart.TabIndex = 5
        Me.ButtonStart.Text = "啟動油壓"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonStart2
        '
        Me.ButtonStart2.Location = New System.Drawing.Point(171, 12)
        Me.ButtonStart2.Name = "ButtonStart2"
        Me.ButtonStart2.Size = New System.Drawing.Size(75, 35)
        Me.ButtonStart2.TabIndex = 6
        Me.ButtonStart2.Text = "雙點衝擊"
        Me.ButtonStart2.UseVisualStyleBackColor = True
        '
        'ButtonStartRecord
        '
        Me.ButtonStartRecord.Location = New System.Drawing.Point(252, 12)
        Me.ButtonStartRecord.Name = "ButtonStartRecord"
        Me.ButtonStartRecord.Size = New System.Drawing.Size(75, 35)
        Me.ButtonStartRecord.TabIndex = 7
        Me.ButtonStartRecord.Text = "開啟記錄"
        Me.ButtonStartRecord.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 573)
        Me.Controls.Add(Me.Layout)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.Text = "軌道衝擊"
        Me.Layout.ResumeLayout(False)
        Me.Panel_buttons.ResumeLayout(False)
        Me.Panel_buttons.PerformLayout()
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
    Friend WithEvents Button1 As Button
    Friend WithEvents isEMU As CheckBox
    Friend WithEvents ButtonStartRecord As Button
    Friend WithEvents ButtonStart2 As Button
    Friend WithEvents ButtonStart As Button
End Class
