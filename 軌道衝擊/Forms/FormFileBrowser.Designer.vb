<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFileBrowser
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFileBrowser))
        Me.file_tree_view = New System.Windows.Forms.TreeView()
        Me.TLP = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.top_path = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.file_list = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.FConsole1 = New WindowsForms.Console.FConsole()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TLP.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'file_tree_view
        '
        Me.file_tree_view.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.file_tree_view.Dock = System.Windows.Forms.DockStyle.Fill
        Me.file_tree_view.Location = New System.Drawing.Point(4, 71)
        Me.file_tree_view.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.file_tree_view.Name = "file_tree_view"
        Me.file_tree_view.Size = New System.Drawing.Size(157, 674)
        Me.file_tree_view.TabIndex = 0
        '
        'TLP
        '
        Me.TLP.ColumnCount = 3
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TLP.Controls.Add(Me.file_tree_view, 0, 1)
        Me.TLP.Controls.Add(Me.Panel1, 0, 0)
        Me.TLP.Controls.Add(Me.Panel2, 1, 1)
        Me.TLP.Controls.Add(Me.StatusStrip1, 0, 2)
        Me.TLP.Controls.Add(Me.TableLayoutPanel1, 2, 1)
        Me.TLP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TLP.Location = New System.Drawing.Point(0, 0)
        Me.TLP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TLP.Name = "TLP"
        Me.TLP.RowCount = 3
        Me.TLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.TLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TLP.Size = New System.Drawing.Size(1103, 775)
        Me.TLP.TabIndex = 2
        '
        'Panel1
        '
        Me.TLP.SetColumnSpan(Me.Panel1, 3)
        Me.Panel1.Controls.Add(Me.top_path)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1039, 58)
        Me.Panel1.TabIndex = 2
        '
        'top_path
        '
        Me.top_path.AutoSize = True
        Me.top_path.Location = New System.Drawing.Point(10, 22)
        Me.top_path.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.top_path.Name = "top_path"
        Me.top_path.Size = New System.Drawing.Size(45, 16)
        Me.top_path.TabIndex = 0
        Me.top_path.Text = "Label1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(165, 67)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(275, 682)
        Me.Panel2.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.file_list)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(275, 682)
        Me.Panel4.TabIndex = 1
        '
        'file_list
        '
        Me.file_list.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.file_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.file_list.FormattingEnabled = True
        Me.file_list.ItemHeight = 16
        Me.file_list.Location = New System.Drawing.Point(0, 0)
        Me.file_list.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.file_list.Name = "file_list"
        Me.file_list.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.file_list.Size = New System.Drawing.Size(275, 682)
        Me.file_list.Sorted = True
        Me.file_list.TabIndex = 5
        '
        'StatusStrip1
        '
        Me.TLP.SetColumnSpan(Me.StatusStrip1, 3)
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 749)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 17, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(202, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FConsole1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(444, 71)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.89401!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.10599!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(655, 674)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(4, 4)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(647, 456)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'FConsole1
        '
        Me.FConsole1.Arguments = New String(-1) {}
        Me.FConsole1.AutoScrollToEndLine = True
        Me.FConsole1.BackColor = System.Drawing.Color.Black
        Me.FConsole1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FConsole1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FConsole1.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.FConsole1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.FConsole1.HyperlinkColor = System.Drawing.Color.Empty
        Me.FConsole1.Location = New System.Drawing.Point(4, 468)
        Me.FConsole1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FConsole1.MaxLength = 32767
        Me.FConsole1.MinimumSize = New System.Drawing.Size(11, 13)
        Me.FConsole1.Name = "FConsole1"
        Me.FConsole1.ReadOnly = True
        Me.FConsole1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.FConsole1.SecureReadLine = True
        Me.FConsole1.Size = New System.Drawing.Size(647, 202)
        Me.FConsole1.State = WindowsForms.Console.Enums.ConsoleState.Writing
        Me.FConsole1.TabIndex = 3
        Me.FConsole1.Text = ""
        Me.FConsole1.Title = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(61, 4)
        '
        'FormFileBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 775)
        Me.Controls.Add(Me.TLP)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormFileBrowser"
        Me.Text = "記錄瀏覽"
        Me.TLP.ResumeLayout(False)
        Me.TLP.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents file_tree_view As TreeView
    Friend WithEvents TLP As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents top_path As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents file_list As ListBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents FConsole1 As WindowsForms.Console.FConsole
End Class
