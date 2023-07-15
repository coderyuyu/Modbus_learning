<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsole
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConsole))
        Me.FConsole1 = New WindowsForms.Console.FConsole()
        Me.SuspendLayout()
        '
        'FConsole1
        '
        Me.FConsole1.Arguments = New String(-1) {}
        Me.FConsole1.AutoScrollToEndLine = True
        Me.FConsole1.BackColor = System.Drawing.Color.White
        Me.FConsole1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FConsole1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FConsole1.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.FConsole1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.FConsole1.HyperlinkColor = System.Drawing.Color.Empty
        Me.FConsole1.Location = New System.Drawing.Point(0, 0)
        Me.FConsole1.MaxLength = 32767
        Me.FConsole1.MinimumSize = New System.Drawing.Size(470, 200)
        Me.FConsole1.Name = "FConsole1"
        Me.FConsole1.ReadOnly = True
        Me.FConsole1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.FConsole1.SecureReadLine = True
        Me.FConsole1.Size = New System.Drawing.Size(520, 665)
        Me.FConsole1.State = WindowsForms.Console.Enums.ConsoleState.Writing
        Me.FConsole1.TabIndex = 0
        Me.FConsole1.Text = ""
        Me.FConsole1.Title = "Console"
        '
        'FormConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 665)
        Me.Controls.Add(Me.FConsole1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormConsole"
        Me.Text = "Console"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FConsole1 As WindowsForms.Console.FConsole
End Class
