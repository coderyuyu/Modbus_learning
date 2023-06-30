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
        Me.Panel_Extras = New System.Windows.Forms.Panel()
        Me.Panel_Main = New System.Windows.Forms.Panel()
        Me.ButtonSettings = New System.Windows.Forms.Button()
        Me.ButtonLogs = New System.Windows.Forms.Button()
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
        Me.Panel_buttons.Controls.Add(Me.ButtonLogs)
        Me.Panel_buttons.Controls.Add(Me.ButtonSettings)
        Me.Panel_buttons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_buttons.Location = New System.Drawing.Point(3, 479)
        Me.Panel_buttons.Name = "Panel_buttons"
        Me.Panel_buttons.Size = New System.Drawing.Size(929, 59)
        Me.Panel_buttons.TabIndex = 1
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
        'ButtonSettings
        '
        Me.ButtonSettings.Location = New System.Drawing.Point(9, 12)
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(75, 35)
        Me.ButtonSettings.TabIndex = 0
        Me.ButtonSettings.Text = "參數設定"
        Me.ButtonSettings.UseVisualStyleBackColor = True
        '
        'ButtonLogs
        '
        Me.ButtonLogs.Location = New System.Drawing.Point(724, 12)
        Me.ButtonLogs.Name = "ButtonLogs"
        Me.ButtonLogs.Size = New System.Drawing.Size(75, 35)
        Me.ButtonLogs.TabIndex = 1
        Me.ButtonLogs.Text = "資料瀏覽"
        Me.ButtonLogs.UseVisualStyleBackColor = True
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
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Layout As TableLayoutPanel
    Friend WithEvents Panel_Messages As Panel
    Friend WithEvents Panel_buttons As Panel
    Friend WithEvents Panel_Extras As Panel
    Friend WithEvents Panel_Main As Panel
    Friend WithEvents ButtonSettings As Button
    Friend WithEvents ButtonLogs As Button
End Class
