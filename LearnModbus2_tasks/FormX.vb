Imports System.Threading
Imports EasyModbus
Public Class FormX
    ' 宣告程式會用到的變數
    Dim modClient As New ModbusClient  ' 宣告一個 modbus client 物件
    Dim TASK_READ As Task
    Dim cs As CancellationTokenSource
    Dim cancel_token As CancellationToken
    Delegate Sub UpdateRegs_Invoker(slave1 As Array)
    Delegate Sub UpdateStatus_Invoker(text As String)

    ''' <summary>
    ''' 程式啟動時一定會被執行的Form1_Load事件, 所有初始設定可在此執行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cs = New CancellationTokenSource
        cancel_token = cs.Token



        'ButtonConnect.PerformClick()
    End Sub

    ''' <summary>
    ''' 更新讀取資料到畫面
    ''' </summary>
    ''' <param name="slave1"></param>
    Sub UpdateRegs(slave1 As Array)
        If Reg1_1.InvokeRequired Then
            Reg1_1.Invoke(New UpdateRegs_Invoker(AddressOf UpdateRegs), slave1)
        Else
            Me.Reg1_1.Text = slave1(0)
            'Me.Reg1_2.Text = slave1(1)
            ' Me.Reg1_3.Text = slave1(2)
            'Me.Reg2_1.Text = slave2(0)
            'Me.Reg2_2.Text = slave2(1)
            'Me.Reg2_3.Text = slave2(2)
        End If
    End Sub
    ''' <summary>
    ''' 更新button及狀態文字
    ''' 透過delegate的慣用寫法如下, 常用.
    ''' </summary>
    ''' <param name="text"></param>
    Sub UpdateStatus(text As String)
        If ButtonConnect.InvokeRequired Then ' 這行是用來判斷是否由背景執行緒呼叫, 通常選一個UI control代表
            ' 若是, 則透過 delegate 執行
            ButtonConnect.Invoke(New UpdateStatus_Invoker(AddressOf UpdateStatus), text)
        Else
            ' 進到這裡, 可以安全更新UI
            With ButtonConnect
                .Text = text
                Select Case text
                    Case "Connect"
                        .Enabled = True
                    Case "Disconnect"
                        .Enabled = True
                    Case "Disconnecting" ' 中斷可能需要一段時間, 其間button disable掉
                        .Enabled = False
                End Select
                status.Text = $"Button text chaged to {text} at {Now}"
            End With
        End If
    End Sub


    ''' <summary>
    ''' 按下 Connect 按鈕時要執行的工作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click

        With ButtonConnect
            Select Case .Text
                Case "Connect" ' 如果 Button上文字是 Connect
                    With modClient ' 這個物件在程式開始時 Dim modClient As New ModbusClient 宣告的
                        .Baudrate = txtBaudrate.Text ' 設定 Baudrate
                        .SerialPort = txtPort.Text ' 設定 COM port
                        .Parity = IO.Ports.Parity.None '  2023-6-5
                        .StopBits = IO.Ports.StopBits.One '  2023-6-5
                        .Connect() ' 執行 Connect 方法(method)
                    End With
                    UpdateStatus("Disconnect") ' 保持良好習慣, 用delegate更新UI
                    TASK_READ = Task.Run(Sub()
                                             DoReadProcess()
                                         End Sub).ContinueWith(Sub() ' 當 DeReadProcess結束後, 會執行 ContinueWith
                                                                   modClient.Disconnect()
                                                                   UpdateStatus("Connect") ' 此時 TASK_READ正式結束, 更新button
                                                               End Sub)
                Case "Disconnect"
                    UpdateStatus("Disconnecting") ' 多一個 Disconnecting 的狀態, 以確保不會在讀取loop中間com被disconnect掉
                    cs.Cancel()
            End Select

        End With

    End Sub

    ''' <summary>
    ''' 讀取資料的LOOP 
    ''' </summary>
    Sub DoReadProcess()
        Dim slave1
        Dim st As New Stopwatch
        Static count As Long = 0
        'Dim slave2 As Integer()

        Do
            Try
                st.Restart()
                count += 1
                modClient.UnitIdentifier = 1 ' Slave 1
                'modClient.WriteSingleRegister(3, 0)
                'modClient.WriteMultipleRegisters()
                'modClient.WriteMultipleCoils()
                'modClient.WriteSingleCoil()
                'modClient.WriteSingleRegister(&H3A, 3001)
                'modClient.WriteSingleRegister(27, 3)
                'modClient.WriteSingleRegister(28, 4)
                'modClient.WriteSingleRegister(29, 5)
                'modClient.WriteSingleRegister(30, 6)

                For i = 0 To &H3C
                    slave1 = modClient.ReadHoldingRegisters(i, 1) ' 從第0個開始, 取3個數值, vb 的 array 預設是 base 0, 0 為第1個
                    Debug.Print($"{i} ### {slave1(0)} ")
                Next
                'UpdateRegs(slave1) ' 透過 delegate 才可更新UI
                'modClient.UnitIdentifier = 2  ' Slave 2
                'slave2 = modClient.ReadHoldingRegisters(0, 3)
            Catch ex As Exception
                Debug.Print($"{count} ### {ex.Message} ")
                Task.Delay(1000).Wait()
                Try
                    modClient.Connect()
                    Debug.Print("retry connect successed")
                Catch ex2 As Exception
                    Debug.Print("retry connect failed")
                End Try

            End Try


            ' 如果加上運算後處理時間過長, 則這裡會先放入Queue由另一個執行緒處理運算及更新UI
            'Task.Delay(10).Wait() ' 延遲 10 ms
        Loop While Not cancel_token.IsCancellationRequested ' 一直loop到 CancellationTokenSource 被 cancel

    End Sub



End Class
