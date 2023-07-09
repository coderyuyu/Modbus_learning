Imports OfficeOpenXml.ExcelErrorValue

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



    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppInit()
        isEMU.Checked = SYS.isEmulate


    End Sub

    Private Sub ButtonTest_Click(sender As Object, e As EventArgs) Handles ButtonTest.Click
        FormTest.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormConsole.Show()
    End Sub

    Private Sub isEMU_CheckedChanged(sender As Object, e As EventArgs) Handles isEMU.CheckedChanged
        SYS.SetEmulate(isEMU.Checked)
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Try
            ConsoleLog("全關指令")
            SYS.全關指令()
            ConsoleLog("設定變頻器頻率=0")
            SYS.設定變頻器頻率(0)
            ConsoleLog("開啟變頻器")
            SYS.開啟變頻器()
            ConsoleLog($"設定變頻器頻率={FormSettings.變頻器初始頻率}")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel_buttons_Paint(sender As Object, e As PaintEventArgs) Handles Panel_buttons.Paint

    End Sub
End Class
