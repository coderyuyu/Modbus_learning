Imports OfficeOpenXml.ExcelErrorValue

Public Class FormMain
    Public Enum buttonState
        初值化
        啟動油壓
        雙點衝擊
        開始記錄
    End Enum

    Private Sub ButtonSettings_Click(sender As Object, e As EventArgs) Handles ButtonSettings.Click
        With FSET
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Me.Left + 10, Me.Top + 10)
            .ShowDialog()
        End With
    End Sub


    Private Sub ButtonLogs_Click(sender As Object, e As EventArgs) Handles ButtonLogs.Click
        With FormFileBrowser
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Me.Left + 10, Me.Top + 10)
            .ShowDialog()
        End With
    End Sub



    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isEMU.Checked = SYS.isEmulate
        SetButtons(buttonState.初值化)
        UpdateCounter(FSET.累計次數)

    End Sub

    Private Sub ButtonTest_Click(sender As Object, e As EventArgs) Handles ButtonTest.Click
        With FormTest
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Me.Left + 10, Me.Top + 10)
            .ShowDialog()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonConsole.Click
        If FCONSOLE.Visible Then
            FCONSOLE.Hide()
        Else
            With FCONSOLE
                .StartPosition = FormStartPosition.Manual
                .Location = New Point(Me.Left + 10, Me.Top + 10)
                .Show()
            End With
            'FCONSOLE.Show()
        End If



    End Sub

    Private Sub isEMU_CheckedChanged(sender As Object, e As EventArgs) Handles isEMU.CheckedChanged
        SYS.SetEmulate(isEMU.Checked)
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Select Case ButtonStart.Text
            Case "啟動油壓"
                Try
                    ConsoleLog("全關指令")
                    SYS.全關指令()
                    ConsoleLog("設定變頻器頻率=0")
                    SYS.設定變頻器頻率(0)
                    ConsoleLog("開啟變頻器")
                    SYS.開啟變頻器()
                    SYS.設定變頻器頻率(FSET.變頻器初始頻率)
                    ConsoleLog($"設定變頻器頻率={FSET.變頻器初始頻率}")
                    If SYS.isEmulate Then
                        SYS.寫入主缸力值(15) '若模擬, 則主缸力值預設為15
                    End If
                    ButtonStart.Text = "關閉油壓"
                    StartTasks()
                    SetButtons(buttonState.啟動油壓)
                Catch ex As Exception

                End Try
            Case "關閉油壓"
                ButtonStart.Text = "啟動油壓"
                StopTasks() ' Stop by "關閉油壓"
                SetButtons(buttonState.初值化)
        End Select

    End Sub



    Private Sub ButtonStartRecord_Click(sender As Object, e As EventArgs) Handles ButtonStartRecord.Click
        SYS.設定變頻器頻率(FSET.開始紀錄前重置頻率)
        SYS.開始記錄 = True
        SetButtons(buttonState.開始記錄)
    End Sub

    Private Sub ButtonStart2_Click(sender As Object, e As EventArgs) Handles ButtonStart2.Click
        Try
            StartACTask(1000 / FSET.測試點應變頻率 / 2)
            SetButtons(buttonState.雙點衝擊)
        Catch ex As Exception

        End Try

    End Sub



    Private Sub SetButtons(status As Integer)
        Select Case status
            Case buttonState.初值化
                ButtonSettings.Enabled = True '參數設定
                ButtonStart.Enabled = True ' 油壓啟動/關閉
                ButtonStart2.Enabled = False ' 雙點衝擊
                ButtonStartRecord.Enabled = False ' 開始記錄
                ButtonConsole.Enabled = True ' 系統訊息
                ButtonLogs.Enabled = True ' 記錄瀏覽
                ButtonTest.Enabled = True ' 測試
                ButtonEnd.Enabled = True ' 結束
                counter.BackColor = Color.LightGray
            Case buttonState.啟動油壓
                ButtonSettings.Enabled = False '參數設定
                ButtonStart.Enabled = True ' 油壓啟動/關閉
                ButtonStart2.Enabled = True ' 雙點衝擊
                ButtonStartRecord.Enabled = False ' 開始記錄
                ButtonConsole.Enabled = True ' 系統訊息
                ButtonLogs.Enabled = True ' 記錄瀏覽
                ButtonTest.Enabled = False ' 測試
                ButtonEnd.Enabled = True ' 結束
                counter.BackColor = Color.LightGray
            Case buttonState.雙點衝擊
                ButtonSettings.Enabled = False '參數設定
                ButtonStart.Enabled = True ' 油壓啟動/關閉
                ButtonStart2.Enabled = False ' 雙點衝擊
                ButtonStartRecord.Enabled = True ' 開始記錄
                ButtonConsole.Enabled = True ' 系統訊息
                ButtonLogs.Enabled = True ' 記錄瀏覽
                ButtonTest.Enabled = False ' 測試
                ButtonEnd.Enabled = True ' 結束
                counter.BackColor = Color.LightGray
            Case buttonState.開始記錄
                ButtonSettings.Enabled = False '參數設定
                ButtonStart.Enabled = True ' 油壓啟動/關閉
                ButtonStart2.Enabled = False ' 雙點衝擊
                ButtonStartRecord.Enabled = False ' 開始記錄
                ButtonConsole.Enabled = True ' 系統訊息
                ButtonLogs.Enabled = True ' 記錄瀏覽
                ButtonTest.Enabled = False ' 測試
                ButtonEnd.Enabled = True ' 結束
                counter.BackColor = Color.LightGreen
        End Select
        UpdateButtonColor()
    End Sub

    Sub UpdateButtonColor()
        For Each ctrl As Control In Me.Panel_buttons.Controls
            If ctrl.Name.StartsWith("Button") Then
                If ctrl.Enabled Then
                    ctrl.BackColor = Color.LightPink
                Else
                    ctrl.BackColor = Color.LightGray
                End If
            End If
        Next
    End Sub



    Sub UpdateCounter(value)
        counter.Text = value
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If RunningTasksCount() <> 0 Then
                ShowMsgBox("系統運作中, 請先關閉油壓", "好")
                e.Cancel = True
            Else
                If ShowMsgBox("結束系統?", "是,否") = 1 Then
                    StopTasks() ' Stop by 結束系統
                    FSET.更新累計次數(counter.Text)
                    SYS.停機()
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ConsoleLog(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonEnd_Click(sender As Object, e As EventArgs) Handles ButtonEnd.Click
        If RunningTasksCount() <> 0 Then
            ShowMsgBox("系統運作中, 請先關閉油壓", "好")
        Else
            Me.Close()
        End If
    End Sub




    Private Sub Panel_Main_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Main.Paint

    End Sub
End Class
