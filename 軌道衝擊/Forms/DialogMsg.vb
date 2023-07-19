Imports System.Windows.Forms

Public Class DialogMsg
    Property timeoutms As Integer = 0
    Property defaultbutton As Integer = 0
    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    Me.Close()
    'End Sub

    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub

    Private Sub DialogMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If timeoutms > 0 AndAlso defaultbutton > 0 And Me.ButtonPannel.Controls.ContainsKey("B" & defaultbutton) Then
            Dim timer As New Timer
            timer.Interval = timeoutms
            timer.Enabled = True
            timer.Start()
            AddHandler timer.Tick, AddressOf AutoClick
        End If
    End Sub

    Private Sub AutoClick(s As Object, e As EventArgs)
        DirectCast(s, Timer).Stop()
        DirectCast(s, Timer).Dispose()
        DirectCast(Me.ButtonPannel.Controls("B" & defaultbutton), Button).PerformClick()
    End Sub

End Class
