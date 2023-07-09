Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports EasyModbus

Public Class cCOM
    Property SerialPort As String
    Property Baudrate As Integer
    Property Parity As Parity = IO.Ports.Parity.None
    Property StopBits As StopBits = IO.Ports.StopBits.One
    Property Name As String = ""
    Property mbc As New ModbusClient
    Property comport As New SerialPort
    Sub New(SerialPort As String,
                Optional Baudrate As Integer = 9600,
                Optional Parity As Parity = Parity.None,
                Optional StopBits As StopBits = StopBits.One, Optional Name As String = "")
        With Me
            .SerialPort = SerialPort
            .Baudrate = Baudrate
            .Parity = Parity
            .StopBits = StopBits
            .Name = Name
        End With
    End Sub

    ''' <summary>
    ''' 建立 modbus client 連線
    ''' </summary>
    Sub ConnectBus(Optional isForceReConnect As Boolean = False)
        If Not mbc.Connected Or isForceReConnect Then
            DisConnect() ' 預防 comport 已開
            With mbc
                .SerialPort = Me.SerialPort
                .Baudrate = Me.Baudrate
                .Parity = Me.Parity
                .StopBits = Me.StopBits
                .Connect()
            End With
        Else
            ' mbc 已開
        End If

    End Sub
    ''' <summary>
    ''' 開啟 com port
    ''' </summary>
    Sub ConnectPort(Optional isForceReConnect As Boolean = False)
        If Not comport.IsOpen Or isForceReConnect Then
            DisConnect() ' 預防 modbus 已開
            With comport
                .PortName = Me.SerialPort
                .BaudRate = Me.Baudrate
                .Parity = Me.Parity
                .StopBits = Me.StopBits
                .Open()
            End With
        Else
            ' com port 已開
        End If

    End Sub
    ''' <summary>
    ''' 關掉 bus 及 com port
    ''' </summary>
    Sub DisConnect()
        If mbc.Connected Then
            mbc.Disconnect()
        ElseIf comport.IsOpen Then
            comport.Close()
        End If
    End Sub



    ''' <summary>
    ''' write modbus
    ''' </summary>
    ''' <param name="slaveid"></param>
    ''' <param name="registerAddress"></param>
    ''' <param name="values"></param>
    Sub WriteTag(slaveid As Integer, registerAddress As Integer, values As Integer())
        If Not mbc.Connected Then
            Me.ConnectBus()
        End If
        SyncLock mbc
            mbc.UnitIdentifier = slaveid
            mbc.WriteMultipleRegisters(registerAddress, values)
        End SyncLock
    End Sub
    ''' <summary>
    ''' read modbus
    ''' </summary>
    ''' <param name="slaveid"></param>
    ''' <param name="registerAddress"></param>
    ''' <param name="dataLength"></param>
    ''' <returns></returns>
    Function ReadTag(slaveid As Integer, registerAddress As Integer, dataLength As Integer) As Integer()
        Dim values = Nothing

        If Not mbc.Connected Then
                Me.ConnectBus()
            End If
        SyncLock mbc
            mbc.UnitIdentifier = slaveid
            values = mbc.ReadHoldingRegisters(registerAddress, dataLength)

        End SyncLock
        Return values

    End Function

    ''' <summary>
    ''' 寫 string to com port (di/do)
    ''' </summary>
    ''' <param name="cmd"></param>
    ''' <returns></returns>
    Function WriteString(cmd As String, Optional timeoutms As Integer = 1000) As String

        Dim returnStr As String = ""

        If Not comport.IsOpen Then
            Me.ConnectPort()
        End If
        returnStr = DoWriteString(cmd, timeoutms)
        Return returnStr

    End Function


    Private Function DoWriteString(cmd As String, timeoutms As Integer) As String
        Dim N As Integer = 0
        Dim receivedData As String = ""
        Dim stw As New Stopwatch
        If Not cmd.EndsWith(vbCr) Then
            cmd &= vbCr
        End If
        Task.Delay(100).Wait()
        SyncLock comport ' 防止多工環境下 com port 同時被存取
            With comport

                ClearBuffer() '先清空BUFFER
                stw.Restart()
                .Write(cmd) ' 因為 cmd 有 vbCr, 覺得用Write即可, 不用WriteLine
                Do Until N > 0
                    receivedData &= .ReadExisting
                    N = InStr(receivedData, vbCr)
                    If stw.Elapsed.Milliseconds > timeoutms Then ' 防止一直讀不到或太久
                        Throw New Exception($"{comport.PortName} do write string timeout")
                    End If
                Loop
                stw.Stop()

            End With
        End SyncLock
        Return receivedData
    End Function

    Private Sub ClearBuffer()
        With comport
            '先清空BUFFER
            If .BytesToRead > 0 Then
                Dim buffer(.BytesToRead - 1) As Byte
                .Read(buffer, 0, buffer.Length)
            End If
        End With
    End Sub




End Class
