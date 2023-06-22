Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
'Imports ClassModbus
'Imports Opc.Hda
Imports EasyModbus
Imports LearnModbus2_tasks.FormChart
Imports OfficeOpenXml.Drawing

Public Class FormMain
    Dim configXML As XmlDocument
    Dim xmlPath As String
    'Dim SYS As cSystem
    Delegate Sub ConsoleLog_Invoker(msg As String, color As Color)
    Dim console As WindowsForms.Console.FConsole = FormConsole.FConsole1
    Dim TASK_READ As Task
    Dim TASK_PROCESS As Task
    Dim TASK_SIMULATE As Task
    Dim TASK_LOG As Task

    Dim cs As CancellationTokenSource
    Dim cancel_token As CancellationToken
    Delegate Sub UpdateRegs_Invoker(slave1 As Array)
    Delegate Sub UpdateStatus_Invoker(text As String, which As String)
    Delegate Sub DrawChart_Invoker()
    Delegate Sub UpdateFan_Invoker(f12 As Integer, onoff As Boolean)
    '    Dim channels As New Dictionary(Of String, ModbusClient)
    Dim SYS As New cSYS
    Dim DATA0 As New cDATA0
    Dim DATA1 As cDATA1
    Dim LOGQ As New Dictionary(Of String, Queue(Of String))
    Dim logTypes As Array = {"data", "system", "debug"}
    Dim chartData As New Dictionary(Of String, List(Of Decimal))
    ''' <summary>
    ''' 程式啟動時一定會被執行的Form1_Load事件, 所有初始設定可在此執行
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LOGGER.AddLogHeader("data", "DateTime,Fan1Degree,fan1OnOff,Fan2Degree,fan2OnOff")
        LOGGER.WriteLog("system", "Program start", True)
        For Each item In logTypes
            LOGQ.Add(item, New Queue(Of String))
        Next
        SETTINGS.LoadSettingsFromFile()
        cs = New CancellationTokenSource
        cancel_token = cs.Token
        AddHandler fanSwitch1.ValueChanged, Sub()
                                                UpdateUI(fanSwitch1.Value, "fanSwitch1")
                                                'Fan1.Value = fanSwitch1.Value
                                                'SETTINGS.Fan1On = fanSwitch1.Value
                                                'SYS.COMS(CHANNEL1).WriteTag("f1onoff", {IIf(SETTINGS.Fan1On, 1, 0)})
                                            End Sub
        AddHandler fanSwitch2.ValueChanged, Sub()
                                                UpdateUI(fanSwitch2.Value, "fanSwitch2")
                                                'Fan2.Value = fanSwitch2.Value
                                                'SETTINGS.Fan2On = fanSwitch2.Value
                                                'SYS.COMS(CHANNEL2).WriteTag("f2onoff", {IIf(SETTINGS.Fan2On, 1, 0)})
                                            End Sub

#If DEBUG Then
        ' 開發環境, 先寫入一組預設值到, 只有 DEBUG 時才會執行
        ' 
        t1.Value = 21.3
        t2.Value = 11.9
        SYS.COMS(CHANNEL1).WriteTag("f1temp", {t1.Value * 10})
        SYS.COMS(CHANNEL1).WriteTag("f1onoff", {IIf(SETTINGS.Fan1On, 1, 0)})
        SYS.COMS(CHANNEL2).WriteTag("f2temp", {t2.Value * 10})
        SYS.COMS(CHANNEL2).WriteTag("f2onoff", {IIf(SETTINGS.Fan2On, 1, 0)})
        fanSwitch1.Value = SETTINGS.Fan1On
        fanSwitch2.Value = SETTINGS.Fan2On


        'Fan1.Value = SETTINGS.Fan1On
        'Fan2.Value = SETTINGS.Fan2On
        With t1
            .Band1Color = Color.Green
            .Band2Color = Color.Red
            .Minimum = 5
            .Maximum = 40
            .Band1StartValue = SETTINGS.FanCloseDegree
            .Band1EndValue = SETTINGS.FanOpenDegree
            .Band2StartValue = SETTINGS.FanOpenDegree
            .Band2EndValue = .Maximum
        End With
        With t2
            .Band1Color = Color.Green
            .Band2Color = Color.Red
            .Minimum = 5
            .Maximum = 40
            .Band1StartValue = SETTINGS.FanCloseDegree
            .Band1EndValue = SETTINGS.FanOpenDegree
            .Band2StartValue = SETTINGS.FanOpenDegree
            .Band2EndValue = .Maximum
        End With
#End If
        ' Chart 初始設定
        For Each chart In {Chart1, Chart2}
            With chart
                .ChartAreas.Clear()
                .ChartAreas.Add("Default")
                With chart.ChartAreas("Default")
                    .AxisX.Title = "時間"
                    .AxisX.Interval = 2
                    .AxisX.IsMarginVisible = True
                    .AxisX.MajorGrid.LineColor = Color.SkyBlue
                    .AxisY.MajorGrid.LineColor = Color.SkyBlue
                    .AxisY.Title = "溫度"
                    .AxisY.Interval = 5
                    .AxisY.Maximum = 30
                    .AxisY.Minimum = 10

                End With

                .Legends.Clear()
                .Legends.Add("Default")
                .Legends("Default").Docking = Docking.Top

                .Series.Clear()
                .Series.Add("溫度")

                With .Series(0)
                    .BorderWidth = 2
                    .Color = Color.Red
                    .ChartType = DataVisualization.Charting.SeriesChartType.Line
                End With
            End With
        Next
        chartData.Add("fan1", New List(Of Decimal))
        chartData.Add("fan2", New List(Of Decimal))
        ' 實例化 DATA1
        ' 宣告各個 event 要執行的項目
        DATA1 = New cDATA1()
        With DATA1
            AddHandler .Fan1DegreeChange,
                Sub(updateTime As Date, newValue As Decimal)
                    t1.Value = newValue
                End Sub
            AddHandler .Fan2DegreeChange,
            Sub(updateTime As Date, newValue As Decimal)
                t2.Value = newValue
            End Sub
            AddHandler .Fan1OnOff,
            Sub(updateTime As Date, newValue As Boolean)
                fanSwitch1.Value = newValue
                'Fan1.Value = newValue
                'SETTINGS.Fan1On = newValue
            End Sub
            AddHandler .Fan2OnOff,
            Sub(updateTime As Date, newValue As Boolean)
                fanSwitch2.Value = newValue
                'Fan2.Value = newValue
                'SETTINGS.Fan2On = newValue
            End Sub
        End With
    End Sub

    Private Sub ButtonSetting_Click(sender As Object, e As EventArgs) Handles ButtonSetting.Click
        DialogSettings.ShowDialog()
        SETTINGS.LoadSettingsFromFile()
        fanSwitch1.Value = SETTINGS.Fan1On
        fanSwitch2.Value = SETTINGS.Fan2On
    End Sub

    Private Function GetSettingValue(id As String)
        Dim list As XmlNodeList = configXML.GetElementsByTagName("parameter")
        Dim e = (From ele In list Where ele.GetAttribute("id") = id Select ele)
        If e.Count = 0 Then
            Return "N/A"
        Else
            Return DirectCast(e(0), XmlElement).GetAttribute("value")
        End If
    End Function




    Private Sub ButtonConsole_Click(sender As Object, e As EventArgs) Handles ButtonConsole.Click
        If FormConsole.Visible Then
            FormConsole.Visible = False
        Else
            FormConsole.Visible = True
        End If
    End Sub



    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click


        Dim isError As Boolean = False
        With ButtonStart

            Select Case .Text
                Case RS.UI.BUTTON_START_TEXT ' 如果 Button上文字是 Connect
                    'Dim coms = SYS.TAGS.Select(Function(t) New With {.com = t.com, .baud = t.baud}).Distinct.ToArray
                    For Each kv In SYS.COMS
                        Try
                            SYS.ConnectAll()
                        Catch ex As Exception
                            ConsoleLog(ex.Message)
                            isError = True
                        End Try
                    Next
                    If isError Then
                        UpdateUI(RS.MSG.START_NG, RS.UI.STATUS_LABEL) ' 下方訊息列
                        Exit Sub
                    Else
                        UpdateUI(RS.UI.BUTTON_STOP_TEXT, RS.UI.START_BUTTON) ' start button
                        UpdateUI(RS.MSG.START_OK, RS.UI.STATUS_LABEL) ' 下方訊息列 保持良好習慣, 用delegate更新UI
                    End If
                    ' 至此 com port 都開了
                    ' modClient 物件存在 channels dictionary 中
                    'chartData("fan1").Clear()
                    'chartData("fan2").Clear()
                    chartData("fan1").Add(t1.Value)
                    chartData("fan2").Add(t2.Value)


                    UpdateUI(text:=RS.UI.BUTTON_STOP_TEXT, which:=RS.UI.START_BUTTON) ' 保持良好習慣, 用delegate更新UI
                    TASK_SIMULATE = Task.Run(Sub()
                                                 DoWriteSimulate()
                                             End Sub)

                    TASK_READ = Task.Run(Sub()
                                             DoReadProcess()
                                             Task.Delay(3000).Wait()
                                         End Sub).ContinueWith(Sub() ' 當 DeReadProcess結束後, 會執行 ContinueWith
                                                                   SYS.DisConnectAll()
                                                                   UpdateUI(RS.UI.BUTTON_START_TEXT, RS.UI.START_BUTTON) ' 此時 TASK_READ正式結束, 更新button
                                                                   UpdateUI("", RS.UI.STATUS_LABEL)
                                                               End Sub)

                    TASK_PROCESS = Task.Run(Sub()
                                                DoActionProcess()
                                                Task.Delay(3000).Wait()
                                            End Sub)
                    TASK_LOG = Task.Run(Sub()
                                            doWriteLogProcess()
                                            Task.Delay(3000).Wait()
                                        End Sub)

                Case RS.UI.BUTTON_STOP_TEXT
                    UpdateUI(RS.UI.BUTTON_STOPPING_TEXT, RS.UI.START_BUTTON) ' 多一個 Disconnecting 的狀態, 以確保不會在讀取loop中間com被disconnect掉
                    cs.Cancel()
            End Select
        End With
    End Sub

    Sub UpdateUI(text As String, which As String)
        If ButtonStart.InvokeRequired Then ' 這行是用來判斷是否由背景執行緒呼叫, 通常選一個UI control代表
            ' 若是, 則透過 delegate 執行
            ButtonStart.Invoke(New UpdateStatus_Invoker(AddressOf UpdateUI), text, which)
        Else
            ' 進到這裡, 可以安全更新UI
            Select Case which
                Case "ButtonStart"
                    With ButtonStart
                        .Text = text
                        Select Case text
                            Case RS.UI.BUTTON_START_TEXT
                                .Enabled = True
                            Case RS.UI.BUTTON_STOP_TEXT
                                .Enabled = True
                            Case RS.UI.BUTTON_STOPPING_TEXT ' 中斷可能需要一段時間, 其間button disable掉
                                .Enabled = False
                        End Select
                    End With
                Case "status"
                    With status
                        .Text = text
                    End With
                Case "t1"
                    t1.Value = text
                Case "t2"
                    t2.Value = text
                Case "fanSwitch1"
                    ' fanSwitch1.Value = CBool(text)
                    Fan1.Value = fanSwitch1.Value
                    SETTINGS.Fan1On = fanSwitch1.Value
                    SYS.COMS(CHANNEL1).WriteTag("f1onoff", {IIf(SETTINGS.Fan1On, 1, 0)})
                Case "fanSwitch2"
                    Fan2.Value = fanSwitch2.Value
                    SETTINGS.Fan2On = fanSwitch2.Value
                    SYS.COMS(CHANNEL1).WriteTag("f1onoff", {IIf(SETTINGS.Fan2On, 1, 0)})
                    ' fanSwitch2.Value = CBool(text)
                    'Fan2.Value = fanSwitch2.Value
            End Select

        End If
    End Sub

    Sub ConsoleLog(msg As String, Optional color As Color = Nothing)
        If color = Nothing Then
            color = console.BackColor
            color = Color.FromArgb(255 - color.R,
                                  255 - color.G,
                                  255 - color.B)

        End If
        If console.InvokeRequired Then
            console.Invoke(New ConsoleLog_Invoker(AddressOf ConsoleLog), msg, color)
            LOGGER.WriteLog("console", msg, True)
        Else
            With console
                .WriteLine(msg, color)
            End With
        End If
    End Sub

    ''' <summary>
    ''' 這個程序不斷地讀取資料, 不做任何處理
    ''' </summary>
    Sub DoReadProcess()
        Do
            Try
                Dim T1 = Task.Run(Sub()
                                      Dim values, values2
                                      Try
                                          values = SYS.COMS(CHANNEL1).ReadTag("f1temp")
                                          values2 = SYS.COMS(CHANNEL1).ReadTag("f1onoff")
                                          SyncLock DATA0
                                              DATA0.Fan1Degree = values(0)
                                              DATA0.Fan1On = IIf(values2(0) = 1, True, False)
                                              DATA0.Fan1DegreeTime = Now
                                              DATA0.Fan1OnTime = Now
                                          End SyncLock
                                      Catch ex As Exception
                                          ConsoleLog(ex.ToString)
                                      End Try
                                  End Sub)
                Dim T2 = Task.Run(Sub()
                                      Dim values, values2
                                      Try
                                          values = SYS.COMS(CHANNEL2).ReadTag("f2temp")
                                          values2 = SYS.COMS(CHANNEL2).ReadTag("f2onoff")
                                          SyncLock DATA0
                                              DATA0.Fan2Degree = values(0)
                                              DATA0.Fan2On = IIf(values2(0) = 1, True, False)
                                              DATA0.Fan2DegreeTime = Now
                                              DATA0.Fan2OnTime = Now
                                          End SyncLock
                                      Catch ex As Exception
                                          ConsoleLog(ex.ToString)
                                      End Try
                                  End Sub)
                Task.WaitAll(T1, T2)
                Task.Delay(1000).Wait()
            Catch ex As Exception
                ConsoleLog(ex.ToString)
            End Try


            ' 如果加上運算後處理時間過長, 則這裡會先放入Queue由另一個執行緒處理運算及更新UI
            'Task.Delay(10).Wait() ' 延遲 10 ms
        Loop While Not cancel_token.IsCancellationRequested ' 一直loop到 CancellationTokenSource 被 cancel

    End Sub

    ''' <summary>
    ''' 用 最新的 DATA0 更新 DATA1, 產出相應的 event
    ''' </summary>
    Sub DoActionProcess()

        'Dim st As New Stopwatch
        'Static count As Long = 0
        'Dim slave2 As Integer()
        Do
            Try
                If DATA0.Fan1Degree <> 0 Then
                    SyncLock DATA0
                        DATA1.Update(DATA0)
                    End SyncLock
                    SyncLock LOGQ("data")
                        LOGQ("data").Enqueue(DATA1.LogString())
                    End SyncLock
                    chartData("fan1").Add(DATA1.Fan1Degree)
                    chartData("fan2").Add(DATA1.Fan2Degree)
                    If chartData("fan1").Count > 50 Then chartData("fan1").RemoveAt(0)
                    If chartData("fan2").Count > 50 Then chartData("fan2").RemoveAt(0)
                    DrawChart()
                End If
                Task.Delay(1000).Wait()
            Catch ex As Exception
                ConsoleLog(ex.ToString)
            End Try


            Task.Delay(500).Wait() ' 延遲 500 ms
        Loop While Not cancel_token.IsCancellationRequested ' 一直loop到 CancellationTokenSource 被 cancel

    End Sub

    Sub doWriteLogProcess()
        Do
            Parallel.ForEach(LOGQ.Keys,
                Sub(logtype)
                    Dim list As New List(Of String)
                    Dim Q As Queue(Of String) = LOGQ(logtype)
                    SyncLock Q
                        Do While Q.Count <> 0
                            Dim text As String = Q.Dequeue
                            list.Add(text)
                        Loop
                    End SyncLock
                    LOGGER.WriteLog(logtype, list, True)
                End Sub
                )
        Loop While Not cancel_token.IsCancellationRequested OrElse Not isAllLogQEmpty()
    End Sub

    Function isAllLogQEmpty() As Boolean
        Dim isAllEmpty As Boolean = True
        For Each logtype In logTypes
            If LOGQ(logtype).Count <> 0 Then
                isAllEmpty = False
                Exit For
            End If
        Next
        Return isAllEmpty
    End Function

    Sub DrawChart()
        If Chart1.InvokeRequired Then
            Chart1.Invoke(New DrawChart_Invoker(AddressOf DrawChart))
        Else
            Chart1.Series(0).Points.Clear()
            Chart2.Series(0).Points.Clear()
            For Each i In chartData("fan1")
                Chart1.Series(0).Points.AddXY("", i)
            Next
            For Each i In chartData("fan2")
                Chart2.Series(0).Points.AddXY("", i)
            Next
        End If

    End Sub

    ''' <summary>
    ''' 用於開發時沒有實體的模擬測試
    ''' </summary>
    Sub DoWriteSimulate()
        Static f1temp = t1.Value
        Static f2temp = t2.Value
        Dim st As New Stopwatch
        Dim RND As New Random(Now.Millisecond)
        Static count As Long = 0

        Do
            Try


                If Me.fanSwitch1.Value Then
                    f1temp -= 0.3
                Else
                    f1temp += 0.4
                End If
                If Me.fanSwitch2.Value Then
                    f2temp -= 0.3
                Else
                    f2temp += 0.3
                End If
                If f1temp > 0 And f1temp < 100 Then
                    SYS.COMS(CHANNEL1).WriteTag("f1temp", {f1temp * 10})
                End If
                If f2temp > 0 And f2temp < 100 Then
                    SYS.COMS(CHANNEL2).WriteTag("f2temp", {f2temp * 10})
                End If
            Catch ex As Exception
                Debug.Print(ex.ToString)
            End Try
            Task.Delay(1000).Wait() ' 延遲 1000 ms
        Loop While Not cancel_token.IsCancellationRequested ' 
    End Sub

    Private Sub doFanSwitch1(sender As Object, e As EventArgs) Handles fanSwitch1.Click
        fanSwitch1.Value = Not fanSwitch1.Value
    End Sub
    Private Sub doFanSwitch2(sender As Object, e As EventArgs) Handles fanSwitch2.Click
        fanSwitch2.Value = Not fanSwitch2.Value
    End Sub

    Private Sub WriteOneSimulateData(MBC As ModbusClient,
                                     tempture As Decimal, fanOnOff As Boolean)

    End Sub


    Private Sub WriteOneSimulateData(tempture1, fan1OnOff, tempture2, fan2OnOff)
        Dim MBC As New ModbusClient
        With SYS.COMS(CHANNEL1)
            MBC.SerialPort = .SerialPort
            MBC.Baudrate = .Baudrate
            MBC.Parity = .Parity
            MBC.StopBits = .StopBits
            MBC.Connect()
        End With
        'WriteOneSimulateData(MBC, tempture1, fan1OnOff, tempture2, fan2OnOff)
        MBC.Disconnect()
    End Sub



    Private Sub ButtonLog_Click(sender As Object, e As EventArgs) Handles ButtonLog.Click
        FormFileBrowser.Show()
    End Sub

    Private Sub ButtonTest_Click(sender As Object, e As EventArgs) Handles ButtonTest.Click
        FormChart.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
