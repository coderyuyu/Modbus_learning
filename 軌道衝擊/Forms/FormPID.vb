Imports System.Windows.Forms.DataVisualization.Charting

Public Class FormPID
    Private Sub FormPID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initChart()
    End Sub

    Sub initChart()
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

End Class