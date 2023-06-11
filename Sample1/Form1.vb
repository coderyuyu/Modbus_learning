Imports EasyModbus
Public Class Form1
    Dim modClient As New ModbusClient
    Dim timer As New Timer
    Dim count As Long = 0
    Dim st As New Stopwatch
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer.Interval = 1
        AddHandler timer.Tick, AddressOf TimerTick
    End Sub

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        With ButtonConnect
            If .Text = "Connect" Then
                With modClient
                    .Baudrate = txtBaudrate.Text
                    .SerialPort = txtPort.Text
                    .Connect()
                End With
                .Text = "Disconnect"
                timer.Start()
            Else
                modClient.Disconnect()
                .Text = "Connect"
                timer.Stop()
            End If
        End With

    End Sub

    Sub TimerTick()
        Static isBusy As Boolean
        count += 1
        Debug.Print(count)
        If isBusy Then Exit Sub
        isBusy = True
        st.Restart()
        Dim vals As Integer()
        modClient.UnitIdentifier = 1
            vals = modClient.ReadHoldingRegisters(0, 3)
            Me.Reg1_1.Text = vals(0)
            Me.Reg1_2.Text = vals(1)
            Me.Reg1_3.Text = vals(2)
            modClient.UnitIdentifier = 2
            vals = modClient.ReadHoldingRegisters(0, 3)
            Me.Reg2_1.Text = vals(0)
            Me.Reg2_2.Text = vals(1)
            Me.Reg2_3.Text = vals(2)

        isBusy = False
        Debug.Print(st.Elapsed.TotalMilliseconds)
    End Sub

    Private Sub BasicButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
