Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Sub initChart()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("Default")
        With Chart1.ChartAreas("Default")
            .AxisX.Title = "t"
            .AxisX.Interval = 5
            .AxisX.IsMarginVisible = True
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Title = "PID"
            .AxisY.Interval = 10
        End With

        Chart1.Legends.Clear()
        Chart1.Legends.Add("Default")
        Chart1.Legends("Default").Docking = Docking.Top

        Chart1.Series.Clear()
        Chart1.Series.Add("Set point")
        Chart1.Series.Add("Input")
        Chart1.Series.Add("Output")

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

        With Chart1.Series(2)
            .BorderWidth = 1
            .Color = Color.Green
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
        End With
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mSetting.SaveSettings()
        'mSetting.LoadSettings()
    End Sub

    Private Sub PanelParameter_Paint(sender As Object, e As PaintEventArgs) Handles PanelParameter.Paint

    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Select Case ButtonStart.Text
            Case "Start"
                mSetting.SaveSettings()
                PreCheck()
                WriteInput(0)
                Try
                    StartTasks()
                    ButtonStart.Text = "Stop"
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Stop"
                ButtonStart.Text = "Stopping"
                ButtonStart.Enabled = False
                StopTasks() ' Stop by "關閉油壓"
                ButtonStart.Text = "Start"
                ButtonStart.Enabled = True
        End Select

    End Sub

    Sub UpdateChart(data As List(Of Array))

        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        For i = 1 To data.Count
            Chart1.Series(0).Points.AddXY(i, data(i - 1)(0))
            Chart1.Series(1).Points.AddXY(i, data(i - 1)(1))
            Chart1.Series(2).Points.AddXY(i, data(i - 1)(2))
        Next
    End Sub

    Sub TextboxKeypressCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            ElseIf e.KeyChar = "&" Or e.KeyChar = "H" Or e.KeyChar = "h" Then
                If textbox.Text.StartsWith("-") Then
                    Beep()
                ElseIf Not textbox.Text.StartsWith("&H") Then
                    textbox.Text = "&H" & textbox.Text
                ElseIf textbox.Text.StartsWith("&H") Then
                    textbox.Text = textbox.Text.Substring(2)
                Else
                    Beep()
                End If
                'e.Handled = True
            ElseIf e.KeyChar = "-" Then
                If textbox.Text.StartsWith("-") Then
                    textbox.Text = textbox.Text.Substring(1, textbox.TextLength - 1)
                Else
                    textbox.Text = "-" & textbox.Text
                End If
                'e.Handled = True
            ElseIf e.KeyChar = "." Then
                If DirectCast(sender, TextBox).Text.Contains(".") Then
                    Beep()
                    e.Handled = True

                End If
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initChart()
        inputCom.Items.Clear()
        outputCom.Items.Clear()

        For i = 1 To 9
            inputCom.Items.Add("COM" & i)
            outputCom.Items.Add("COM" & i)
        Next
        mSetting.SetParameterPanel(Me.PanelParameter)
        mSetting.LoadSettings()
        For Each ctrl As Control In PanelParameter.Controls
            Select Case TypeName(ctrl)
                Case "TextBox"
                    AddHandler ctrl.KeyPress, AddressOf TextboxKeypressCheck
            End Select
        Next
    End Sub
End Class
