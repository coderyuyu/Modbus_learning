' 參考:
' https://social.msdn.microsoft.com/Forums/vstudio/en-US/a3b81414-b541-4afb-83ee-655a98377629/line-chart-in-visual-basic?forum=vbgeneral
' https://dotblogs.com.tw/RhinoGoat/2018/04/14/200347
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FormChart
    Dim timer As New Timer
    Dim Y As Dictionary(Of String, List(Of Decimal)) = Nothing
    Dim X As List(Of Integer) = Nothing
    Dim RND As New Random(Now.Millisecond)
    Delegate Sub DrawChart_Invoker(ix As Integer)
    Const VPOINTS As Integer = 50
    Private Sub FormChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'setup the chart
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add("Default")
        With Chart1.ChartAreas("Default")
            .AxisX.Title = "時間"
            .AxisX.Interval = 5
            .AxisX.IsMarginVisible = True
            .AxisX.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.MajorGrid.LineColor = Color.SkyBlue
            .AxisY.Title = "溫度"
            .AxisY.Interval = 10
        End With

        Chart1.Legends.Clear()
        Chart1.Legends.Add("Default")
        Chart1.Legends("Default").Docking = Docking.Top

        Chart1.Series.Clear()
        Chart1.Series.Add("風扇#1")
        Chart1.Series.Add("風扇#2")

        With Chart1.Series(0)
            .BorderWidth = 3
            .Color = Color.Red
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
        End With

        With Chart1.Series(1)
            .BorderWidth = 3
            .Color = Color.Blue
            .ChartType = DataVisualization.Charting.SeriesChartType.Line
        End With

        Y = New Dictionary(Of String, List(Of Decimal))
        X = New List(Of Integer)
        Y.Add("fan1", New List(Of Decimal))
        Y.Add("fan2", New List(Of Decimal))
        For i = 1 To 1000
            X.Add(i)
            Y("fan1").Add(RND.Next(0, 1000) / 10)
            Y("fan2").Add(RND.Next(0, 1000) / 10)
        Next
        HScrollBar1.Minimum = 0
        HScrollBar1.Maximum = X.Count - VPOINTS

        AddHandler HScrollBar1.ValueChanged,
            Sub()
                DrawChart(HScrollBar1.Value)
            End Sub

    End Sub

    'Sub doDrawChart()
    '    Task.Run(Sub()
    '                 For xi = 0 To X.Count Step VPOINTS
    '                     DrawChart(xi)
    '                     Task.Delay(200).Wait()
    '                 Next
    '             End Sub)
    'End Sub

    Sub DrawChart(xi As Integer)
        If Chart1.InvokeRequired Then
            Chart1.Invoke(New DrawChart_Invoker(AddressOf DrawChart), xi)
        Else
            If Y Is Nothing Or Y.Count = 0 Then Exit Sub
            Dim drawTo As Integer
            drawTo = xi + VPOINTS - 1
            If drawTo + 1 > X.Count Then Exit Sub
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()

            'If xi = 0 Then
            ' 初畫


            For i = xi To IIf(X.Count > drawTo, drawTo, X.Count)
                Chart1.Series(0).Points.AddXY(X(i), Y("fan1")(i))
                Chart1.Series(1).Points.AddXY(X(i), Y("fan2")(i))
            Next
            'Else
            '    Chart1.Series(0).Points.RemoveAt(0)
            '    Chart1.Series(1).Points.RemoveAt(0)
            '    Chart1.Series(0).Points.AddXY(X(xi), Y("fan1")(xi))
            '    Chart1.Series(1).Points.AddXY(X(xi), Y("fan2")(xi))
            '    'If Chart1.Series(0).Points.Count = VPOINTS Then
            '    'End If
            '    'If Chart1.Series(1).Points.Count = VPOINTS Then
            '    'End If
            'End If
        End If
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub


End Class