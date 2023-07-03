Public Class FormMain
    Private Sub ButtonSettings_Click(sender As Object, e As EventArgs) Handles ButtonSettings.Click
        With FormSettings
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Me.Left + 10, Me.Top + 10)
            .ShowDialog()
        End With
    End Sub

    Private Sub Panel_Main_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Main.Paint


    End Sub

    Private Sub ButtonLogs_Click(sender As Object, e As EventArgs) Handles ButtonLogs.Click
        With FormFileBrowser
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Me.Left + 10, Me.Top + 10)
            .ShowDialog()
        End With
    End Sub

    Private Sub Panel_Extras_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Extras.Paint

    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppInit()
    End Sub
End Class
