Imports System.Windows.Forms.DataVisualization.Charting
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
        With FFBROWSER
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Me.Left + 10, Me.Top + 10)
            .ShowDialog()
        End With
    End Sub



    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isEMU.Checked = SYS.isEmulate
        SetButtons(buttonState.初值化)
        UpdateCounter(FSET.累計次數)
        InitChart()
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



                    SYS.開啟變頻器()
                    SYS.設定變頻器頻率(FSET.變頻器初始頻率)
                    ConsoleLog($"設定變頻器頻率={FSET.變頻器初始頻率}")
                    If SYS.isEmulate Then
                        ConsoleLog($"模擬初始缸值={FSET.力值設定 - 5}")
                        SYS.寫入主缸力值(FSET.力值設定 - 5) '若模擬
                        SYS.ev = 1 ' 升壓

                    End If

                    ButtonStart.Text = "關閉油壓"
                    StartTasks()
                    SetButtons(buttonState.啟動油壓)
                Catch ex As Exception
                    ConsoleLog(ex.ToString)
                End Try
            Case "關閉油壓"
                ButtonStart.Text = "關閉中..."
                ButtonStart.Enabled = False
                StopTasks() ' Stop by "關閉油壓"
                ButtonStart.Text = "啟動油壓"
                SetButtons(buttonState.初值化)
        End Select

    End Sub



    Private Sub ButtonStartRecord_Click(sender As Object, e As EventArgs) Handles ButtonStartRecord.Click
        SYS.設定變頻器頻率(FSET.開始紀錄前重置頻率)
        SYS.開始記錄 = True
        SYS.開始記錄時間 = Now
        SetButtons(buttonState.開始記錄)
    End Sub

    Private Sub ButtonStart2_Click(sender As Object, e As EventArgs) Handles ButtonStart2.Click

        If SYS.主缸力值 < FSET.容許最低承載力值 Then
            ShowMsgBox($"力值未達 {FSET.容許最低承載力值}", "好", 2000, 1)
        Else

            Try
                count = FSET.累計次數
                minTons = FSET.容許最低承載力值
                StartACImpact2(1000 / FSET.測試點應變頻率)

                'RunBgTask(1000 / FSET.測試點應變頻率, AddressOf doACImpact, NameOf(doACImpact))
                'SYS.開始衝擊 = False
                'StartACTask(1000 / FSET.測試點應變頻率)
                SetButtons(buttonState.雙點衝擊)
            Catch ex As Exception

            End Try
        End If

    End Sub



    Sub SetButtons(status As Integer)
        Select Case status
            Case buttonState.初值化
                ButtonSettings.Enabled = True '參數設定
                ButtonStart.Enabled = True ' 油壓啟動/關閉
                'ButtonStart.Text = "油壓啟動"
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

            If ShowMsgBox("結束系統?", "是,否") = 1 Then
                StopTasks() ' Stop by 結束系統
                FSET.更新累計次數(counter.Text)
                SYS.停機()
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            ConsoleLog(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonEnd_Click(sender As Object, e As EventArgs) Handles ButtonEnd.Click
        Me.Close()
    End Sub




    Private Sub Panel_Main_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Main.Paint

    End Sub

    Private Sub stopButton_Click(sender As Object, e As EventArgs) Handles stopButton.Click
        Try
            StopTasks()
            SYS.停機()
            ButtonStart.Text = "啟動油壓"
            SetButtons(buttonState.初值化) 'stopButton_Click
        Catch ex As Exception
            ShowMsgBox("停機失敗", "好")
        End Try
    End Sub

    Private Sub Panel_Messages_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Messages.Paint

    End Sub

    Private Sub Panel_buttons_Paint(sender As Object, e As PaintEventArgs) Handles Panel_buttons.Paint

    End Sub

    Private Sub InitChart()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("Default")
        With Chart1.ChartAreas("Default")
            .AxisX.Title = "時間"
            .AxisX.Interval = 5
            .AxisX.IsMarginVisible = True
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Title = "頻率/力值"
            .AxisY.Interval = 10
        End With

        Chart1.Legends.Clear()
        Chart1.Legends.Add("Default")
        Chart1.Legends("Default").Docking = Docking.Top

        Chart1.Series.Clear()
        Chart1.Series.Add("頻率")
        Chart1.Series.Add("力值")

        With Chart1.Series(0)
            .BorderWidth = 1
            .Color = Color.Red
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
        End With

        With Chart1.Series(1)
            .BorderWidth = 1
            .Color = Color.Blue
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
        End With


    End Sub


    Sub UpdateChart(data As List(Of Array))
        Try


            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()

            For i = 1 To data.Count
                Chart1.Series(0).Points.AddXY(i, data(i - 1)(0))
                Chart1.Series(1).Points.AddXY(i, data(i - 1)(1))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        FormPID.Show()
    End Sub
End Class
