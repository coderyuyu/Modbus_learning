﻿Imports System.IO.Ports
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
            comport.Dispose()
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

        SyncLock comport
            returnStr = doWriteString(cmd, timeoutms)
        End SyncLock

        Return returnStr
    End Function


    Private Function doWriteString(cmd As String, timeoutms As Integer) As String

        Dim receivedData As String = ""
        If Not cmd.EndsWith(vbCr) Then
            cmd &= vbCr
        End If

        With comport
            .WriteTimeout = timeoutms
            .ReadTimeout = timeoutms
            Try
                .Write(cmd) ' 因為 AA 有 vbCr, 覺得用Write即可, 不用WriteLine
                receivedData = .ReadExisting
            Catch ex As Exception
                Debug.Print(ex.ToString)

            End Try
        End With

        Return receivedData
    End Function


End Class
