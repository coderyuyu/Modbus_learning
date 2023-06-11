<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogSettings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.LabelOpenDegree = New System.Windows.Forms.Label()
        Me.LabelCloseDegree = New System.Windows.Forms.Label()
        Me.openDegree = New System.Windows.Forms.MaskedTextBox()
        Me.closeDegree = New System.Windows.Forms.MaskedTextBox()
        Me.Fan1On = New System.Windows.Forms.CheckBox()
        Me.Fan2On = New System.Windows.Forms.CheckBox()
        Me.WarningDegree = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(111, 292)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(176, 41)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(10, 5)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 31)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "設定"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(98, 5)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 31)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "取消"
        '
        'LabelOpenDegree
        '
        Me.LabelOpenDegree.AutoSize = True
        Me.LabelOpenDegree.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelOpenDegree.Location = New System.Drawing.Point(50, 42)
        Me.LabelOpenDegree.Name = "LabelOpenDegree"
        Me.LabelOpenDegree.Size = New System.Drawing.Size(138, 27)
        Me.LabelOpenDegree.TabIndex = 1
        Me.LabelOpenDegree.Text = "風扇開啟溫度"
        '
        'LabelCloseDegree
        '
        Me.LabelCloseDegree.AutoSize = True
        Me.LabelCloseDegree.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelCloseDegree.Location = New System.Drawing.Point(50, 89)
        Me.LabelCloseDegree.Name = "LabelCloseDegree"
        Me.LabelCloseDegree.Size = New System.Drawing.Size(138, 27)
        Me.LabelCloseDegree.TabIndex = 2
        Me.LabelCloseDegree.Text = "風扇關閉溫度"
        '
        'openDegree
        '
        Me.openDegree.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.openDegree.Location = New System.Drawing.Point(194, 41)
        Me.openDegree.Mask = "##"
        Me.openDegree.Name = "openDegree"
        Me.openDegree.Size = New System.Drawing.Size(37, 33)
        Me.openDegree.TabIndex = 3
        Me.openDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'closeDegree
        '
        Me.closeDegree.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.closeDegree.Location = New System.Drawing.Point(194, 83)
        Me.closeDegree.Mask = "##"
        Me.closeDegree.Name = "closeDegree"
        Me.closeDegree.Size = New System.Drawing.Size(37, 33)
        Me.closeDegree.TabIndex = 4
        Me.closeDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fan1On
        '
        Me.Fan1On.AutoSize = True
        Me.Fan1On.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Fan1On.Location = New System.Drawing.Point(91, 180)
        Me.Fan1On.Name = "Fan1On"
        Me.Fan1On.Size = New System.Drawing.Size(140, 31)
        Me.Fan1On.TabIndex = 5
        Me.Fan1On.Text = "啟用風扇#1"
        Me.Fan1On.UseVisualStyleBackColor = True
        '
        'Fan2On
        '
        Me.Fan2On.AutoSize = True
        Me.Fan2On.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Fan2On.Location = New System.Drawing.Point(91, 217)
        Me.Fan2On.Name = "Fan2On"
        Me.Fan2On.Size = New System.Drawing.Size(140, 31)
        Me.Fan2On.TabIndex = 6
        Me.Fan2On.Text = "啟用風扇#2"
        Me.Fan2On.UseVisualStyleBackColor = True
        '
        'WarningDegree
        '
        Me.WarningDegree.Font = New System.Drawing.Font("Microsoft JhengHei", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.WarningDegree.Location = New System.Drawing.Point(194, 131)
        Me.WarningDegree.Mask = "##"
        Me.WarningDegree.Name = "WarningDegree"
        Me.WarningDegree.Size = New System.Drawing.Size(37, 33)
        Me.WarningDegree.TabIndex = 8
        Me.WarningDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(92, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 27)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "警示溫度"
        '
        'DialogSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(299, 344)
        Me.Controls.Add(Me.WarningDegree)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Fan2On)
        Me.Controls.Add(Me.Fan1On)
        Me.Controls.Add(Me.closeDegree)
        Me.Controls.Add(Me.openDegree)
        Me.Controls.Add(Me.LabelCloseDegree)
        Me.Controls.Add(Me.LabelOpenDegree)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DialogSettings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LabelOpenDegree As Label
    Friend WithEvents LabelCloseDegree As Label
    Friend WithEvents openDegree As MaskedTextBox
    Friend WithEvents closeDegree As MaskedTextBox
    Friend WithEvents Fan1On As CheckBox
    Friend WithEvents Fan2On As CheckBox
    Friend WithEvents WarningDegree As MaskedTextBox
    Friend WithEvents Label1 As Label
End Class
