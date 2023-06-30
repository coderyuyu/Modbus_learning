Imports System.IO.Ports
Imports EasyModbus

Public Class cCOM
    Property SerialPort As String
    Property Baudrate As Integer
    Property Parity As Parity = IO.Ports.Parity.None
    Property StopBits As StopBits = IO.Ports.StopBits.One
    Property Name As String = ""
    Property Tags As New Dictionary(Of String, cTAG)
    Property DIOs As New Dictionary(Of String, cDIO)
    Property mbc As New ModbusClient
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
    Sub AddTAG(tag As cTAG)
        If Not Tags.ContainsKey(tag.tagName) Then
            Tags.Add(tag.tagName, tag)
        End If
    End Sub

    Sub AddDIO(DIO As cDIO)
        If Not DIOs.ContainsKey(DIO.DioName) Then
            DIOs.Add(DIO.DioName, DIO)
        End If
    End Sub


    ''' <summary>
    ''' 建立 modbus client 連線
    ''' </summary>
    Sub Connect()
        If Not mbc.Connected Then
            With mbc
                .SerialPort = Me.SerialPort
                .Baudrate = Me.Baudrate
                .Parity = Me.Parity
                .StopBits = Me.StopBits
                .Connect()
            End With
        End If
    End Sub

    Sub DisConnect()
        If mbc.Connected Then
            mbc.Disconnect()
        End If
    End Sub

    Sub WriteTag(tagname As String, values As Integer())
        Dim tag As cTAG
        If Not mbc.Connected Then
            Me.Connect()
        End If
        If Me.Tags.ContainsKey(tagname) Then
            tag = Tags(tagname)
            SyncLock mbc
                With tag
                    mbc.UnitIdentifier = .slaveid
                    mbc.WriteMultipleRegisters(.registerAddress, values)
                End With
            End SyncLock
        End If
    End Sub

    Function ReadTag(tagname) As Integer()
        Dim tag As cTAG
        Dim values = Nothing
        If Not mbc.Connected Then
            Me.Connect()
        End If
        If Me.Tags.ContainsKey(tagname) Then
            SyncLock mbc
                tag = Tags(tagname)
                With tag
                    mbc.UnitIdentifier = .slaveid
                    values = mbc.ReadHoldingRegisters(.registerAddress, tag.dataLength)
                End With
            End SyncLock
        End If
        Return values
    End Function

    Function DI(dioName)
        Dim DIO As cDIO
        Dim returnStr As String = ""
        If Not mbc.Connected Then
            Me.Connect()
        End If
        If Me.DIOs.ContainsKey(dioName) Then
            DIO = DIOs(dioName)
            SyncLock DIOs
                With DIO
                    ' todo: write string 
                End With
            End SyncLock
        End If
        Return returnStr
    End Function

    Function [DO](dioName As String, value As String)
        Dim DIO As cDIO
        Dim returnStr As String = ""
        If Not mbc.Connected Then
            Me.Connect()
        End If
        If Me.DIOs.ContainsKey(dioName) Then
            DIO = DIOs(dioName)
            SyncLock DIOs
                With DIO
                    ' todo: write string 
                End With
            End SyncLock
        End If
        Return returnStr
    End Function

End Class
