Imports EasyModbus
Public Class Form1
    ' 宣告程式會用到的變數
    Dim modClient As New ModbusClient  ' 宣告一個 modbus client 物件
    Dim timer As New Timer ' 宣告一個timer
    Dim count As Long = 0 ' 測試用計數器
    Dim st As New Stopwatch ' 測試用碼表
    ''' <summary>
    ''' 程式啟動時一定會被執行的Form1_Load事件, 所有初始設定可在此執行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer.Interval = 10 ' 每10ms 就執行一次 timer tick
        AddHandler timer.Tick, AddressOf TimerTick ' 宣告 timer.Tick 的執行程式碼位置
    End Sub

    ''' <summary>
    ''' 按下 Connect 按鈕時要執行的工作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        With ButtonConnect
            If .Text = "Connect" Then ' 如果 Button上文字是 Connect
                With modClient ' 這個物件在程式開始時 Dim modClient As New ModbusClient 宣告的
                    .Baudrate = 9600 '  txtBaudrate.Text ' 設定 Baudrate
                    .SerialPort = "COM3" ' txtPort.Text ' 設定 COM port
                    .Parity = IO.Ports.Parity.None
                    .StopBits = IO.Ports.StopBits.One

                    .Connect() ' 執行 Connect 方法(method)
                End With
                .Text = "Disconnect" ' 把按鈕文字改成 Disconnect
                timer.Start() ' 啟動 timer, 依  timer.Interval = 10 的設定, 毎10ms就會執行一次
            Else ' 如果不是, 代表正在執行
                modClient.Disconnect() ' 斷線
                .Text = "Connect" ' 把按鈕文字恢復成 Connect
                timer.Stop() ' 停止 timer
            End If
        End With

    End Sub
    ''' <summary>
    ''' 這是 timer 定期執行的程式 
    ''' </summary>
    Sub TimerTick()
        'Static isBusy As Boolean
        ' 這段程式用來實驗 TimerTick 如果沒有執行完成是否會一直被觸發
        count += 1 ' 每進來一次, count就會+1並印到 console
        Debug.Print(count)
        st.Restart() ' 開始計時
        'Task.Delay(1000).Wait() ' 這裡故意延遲1秒再執行, 這個會造成UI嚴重卡頓
        'If isBusy Then Exit Sub
        'isBusy = True

        ' 這段程式呼叫 ReadHoldingRegisters 讀取資料, 有2個slave
        Dim vals
        modClient.UnitIdentifier = 1 ' Slave 1

        Try
            vals = modClient.ReadHoldingRegisters(26, 30)
        Catch ex As Exception

        End Try

        ' 從第0個開始, 取3個數值, vb 的 array 預設是 base 0, 0 為第1個
        Me.Reg1_1.Text = vals(0) ' 更新UI, timer 可用, 多工時需改用其他方法, 否則會當掉
        'Me.Reg1_2.Text = vals(1)
        'Me.Reg1_3.Text = vals(2)
        ' modClient.UnitIdentifier = 2  ' Slave 2
        'vals = modClient.ReadHoldingRegisters(0, 3)
        'Me.Reg2_1.Text = vals(0)
        'Me.Reg2_2.Text = vals(1)
        'Me.Reg2_3.Text = vals(2)
        'isBusy = False
        Debug.Print($"Elasped ms={st.Elapsed.TotalMilliseconds}") ' 印出總共執行多少時間
        Application.DoEvents()
    End Sub


End Class
