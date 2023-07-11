<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTest
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FConsole1 = New WindowsForms.Console.FConsole()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.lblcmd = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbC2 = New System.Windows.Forms.CheckBox()
        Me.cbC1 = New System.Windows.Forms.CheckBox()
        Me.cbA2 = New System.Windows.Forms.CheckBox()
        Me.cbA1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.decpos = New System.Windows.Forms.TextBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.mTons = New System.Windows.Forms.TextBox()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Feq = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FConsole1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(957, 568)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FConsole1
        '
        Me.FConsole1.Arguments = New String(-1) {}
        Me.FConsole1.AutoScrollToEndLine = True
        Me.FConsole1.BackColor = System.Drawing.Color.Black
        Me.FConsole1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FConsole1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FConsole1.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.FConsole1.ForeColor = System.Drawing.Color.White
        Me.FConsole1.HyperlinkColor = System.Drawing.Color.Empty
        Me.FConsole1.Location = New System.Drawing.Point(203, 3)
        Me.FConsole1.MaxLength = 32767
        Me.FConsole1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.FConsole1.Name = "FConsole1"
        Me.FConsole1.ReadOnly = True
        Me.FConsole1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.FConsole1.SecureReadLine = True
        Me.FConsole1.Size = New System.Drawing.Size(751, 562)
        Me.FConsole1.State = WindowsForms.Console.Enums.ConsoleState.Writing
        Me.FConsole1.TabIndex = 0
        Me.FConsole1.Text = ""
        Me.FConsole1.Title = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 562)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button14)
        Me.GroupBox3.Controls.Add(Me.lblcmd)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbC2)
        Me.GroupBox3.Controls.Add(Me.cbC1)
        Me.GroupBox3.Controls.Add(Me.cbA2)
        Me.GroupBox3.Controls.Add(Me.cbA1)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 227)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 100)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "手動電磁閥開關"
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(111, 67)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(58, 25)
        Me.Button14.TabIndex = 6
        Me.Button14.Text = "執行"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'lblcmd
        '
        Me.lblcmd.AutoSize = True
        Me.lblcmd.Location = New System.Drawing.Point(53, 73)
        Me.lblcmd.Name = "lblcmd"
        Me.lblcmd.Size = New System.Drawing.Size(8, 12)
        Me.lblcmd.TabIndex = 5
        Me.lblcmd.Text = "."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "指令碼"
        '
        'cbC2
        '
        Me.cbC2.AutoSize = True
        Me.cbC2.Location = New System.Drawing.Point(57, 43)
        Me.cbC2.Name = "cbC2"
        Me.cbC2.Size = New System.Drawing.Size(44, 16)
        Me.cbC2.TabIndex = 3
        Me.cbC2.Text = "C動"
        Me.cbC2.UseVisualStyleBackColor = True
        '
        'cbC1
        '
        Me.cbC1.AutoSize = True
        Me.cbC1.Location = New System.Drawing.Point(57, 21)
        Me.cbC1.Name = "cbC1"
        Me.cbC1.Size = New System.Drawing.Size(44, 16)
        Me.cbC1.TabIndex = 2
        Me.cbC1.Text = "C點"
        Me.cbC1.UseVisualStyleBackColor = True
        '
        'cbA2
        '
        Me.cbA2.AutoSize = True
        Me.cbA2.Location = New System.Drawing.Point(7, 43)
        Me.cbA2.Name = "cbA2"
        Me.cbA2.Size = New System.Drawing.Size(44, 16)
        Me.cbA2.TabIndex = 1
        Me.cbA2.Text = "A動"
        Me.cbA2.UseVisualStyleBackColor = True
        '
        'cbA1
        '
        Me.cbA1.AutoSize = True
        Me.cbA1.Location = New System.Drawing.Point(7, 21)
        Me.cbA1.Name = "cbA1"
        Me.cbA1.Size = New System.Drawing.Size(44, 16)
        Me.cbA1.TabIndex = 0
        Me.cbA1.Text = "A點"
        Me.cbA1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.decpos)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Controls.Add(Me.mTons)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Feq)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 212)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "單元測試"
        '
        'decpos
        '
        Me.decpos.Location = New System.Drawing.Point(112, 178)
        Me.decpos.Name = "decpos"
        Me.decpos.Size = New System.Drawing.Size(56, 22)
        Me.decpos.TabIndex = 11
        Me.decpos.Text = "10"
        Me.decpos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(6, 175)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(103, 25)
        Me.Button13.TabIndex = 10
        Me.Button13.Text = "設定小數位"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'mTons
        '
        Me.mTons.Location = New System.Drawing.Point(112, 148)
        Me.mTons.Name = "mTons"
        Me.mTons.Size = New System.Drawing.Size(56, 22)
        Me.mTons.TabIndex = 9
        Me.mTons.Text = "10"
        Me.mTons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(6, 145)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(103, 25)
        Me.Button12.TabIndex = 8
        Me.Button12.Text = "寫入主缸力值"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 25)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "全關指令"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 52)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 25)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "A點衝擊"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Feq
        '
        Me.Feq.Location = New System.Drawing.Point(112, 117)
        Me.Feq.Name = "Feq"
        Me.Feq.Size = New System.Drawing.Size(56, 22)
        Me.Feq.TabIndex = 7
        Me.Feq.Text = "10"
        Me.Feq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 25)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "C點衝擊"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(6, 114)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(103, 25)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "設定變頻器頻率"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(92, 21)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(76, 25)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "主缸力值"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(92, 83)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(76, 25)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "變頻器關"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(92, 52)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 25)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "變頻器開"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(108, 530)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "清除"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'FormTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 568)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormTest"
        Me.Text = "測試"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FConsole1 As WindowsForms.Console.FConsole
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Feq As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents mTons As TextBox
    Friend WithEvents Button12 As Button
    Friend WithEvents decpos As TextBox
    Friend WithEvents Button13 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbC2 As CheckBox
    Friend WithEvents cbC1 As CheckBox
    Friend WithEvents cbA2 As CheckBox
    Friend WithEvents cbA1 As CheckBox
    Friend WithEvents Button14 As Button
    Friend WithEvents lblcmd As Label
    Friend WithEvents Label1 As Label
End Class
