Imports System.IO.Ports
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Xml
Imports EasyModbus
Public Class cSystem
    Dim xml As XmlDocument
    Property ComPorts As New Dictionary(Of String, cCOM)
    Property name As String
    Public Event SendMessage(msg As String)

    Sub New(name As String)
        Me.name = name
    End Sub

    Sub New()

    End Sub



    Sub LoadConfig(configXML As XmlDocument)
        Dim com As cCOM
        Dim slave As cSlave
        Dim tag As cTag
        xml = configXML
        Me.name = DirectCast(xml.GetElementsByTagName("system")(0), XmlElement).GetAttribute("name")
        For Each c As XmlElement In xml.GetElementsByTagName("com")
            Dim port = "COM" & c.GetAttribute("port").Trim.ToLower.Replace("com", "")
            Dim baud = c.GetAttribute("baud")
            If baud = "" Then baud = "9600"
            com = New cCOM(port, baud)
            AddCom(com)
            With com

                For Each s As XmlElement In c.GetElementsByTagName("slave")
                    Dim sname = s.GetAttribute("name")
                    Dim sid = s.GetAttribute("id")
                    slave = New cSlave(sid, sname)
                    com.AddSlave(slave)
                    For Each t As XmlElement In s.GetElementsByTagName("tag")
                        Dim tname = t.GetAttribute("name")
                        Dim taddr = t.GetAttribute("address")
                        Dim tlen = t.GetAttribute("length")
                        Dim ttype = t.GetAttribute("type")
                        If tlen = "" Then tlen = "1"
                        tag = New cTag(tname, taddr, ttype, CInt(tlen))
                        slave.AddTag(tag)

                    Next
                Next
            End With
        Next
        RaiseEvent SendMessage("config import successed")
    End Sub

    Sub AddCom(com As cCOM)
        ComPorts.Add(com.port, com)
        RaiseEvent SendMessage(com.port & " added")
    End Sub

    Sub WriteValue(C As cCOM, S As cSlave, T As cTag, value As Integer)
        Dim msgfor As String = $"{System.Reflection.MethodBase.GetCurrentMethod().Name} {C.port}-{S.id}-{T.address}"
        Try
            With C.MBC
                .UnitIdentifier = S.id
                .WriteMultipleRegisters(T.address, {value})
            End With
            RaiseEvent SendMessage($"Write {msgfor} value={value}")
        Catch ex As Exception
            RaiseEvent SendMessage($"Error {msgfor}")
        End Try
    End Sub

    Function ReadValue(C As cCOM, S As cSlave, T As cTag)
        Dim values
        Try
            With C.MBC
                .UnitIdentifier = S.id
                values = .ReadHoldingRegisters(T.address, T.length)
            End With
            Return values
        Catch ex As Exception
            Return {ex.Message}
        End Try
    End Function
    Sub Start()
        For Each com In ComPorts.Values
            Try
                com.Connect()
                RaiseEvent SendMessage(com.port & " connected")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        Next
    End Sub

    Sub [Stop]()
        Try
            For Each com In ComPorts.Values
                com.DisConnect()
                RaiseEvent SendMessage(com.port & " disconnected")
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class



Public Class cCOM
    Property port As String
    Property baudrate As Integer
    Property slaves As New Dictionary(Of Integer, cSlave)
    Property MBC As New ModbusClient
    Property lastExceptionMessage As String
    Dim WithEvents serialPort As SerialPort
    Dim stw As New Stopwatch
    Sub New(port As String, Optional baudrate As Integer = 9600)
        Me.port = port
        Me.baudrate = baudrate
    End Sub

    Sub Connect()
        Try
            With MBC
                .SerialPort = Me.port
                .Baudrate = Me.baudrate
                .Parity = IO.Ports.Parity.None
                .StopBits = IO.Ports.StopBits.One
                .Connect()
            End With
        Catch ex As Exception
            Throw New Exception($"Error: Connect {Me.port} {ex.Message}")
        End Try
    End Sub

    Function DisConnect()
        Try
            With MBC
                .Disconnect()
            End With
            Return True
        Catch ex As Exception
            Throw New Exception($"Error: DisConnect {Me.port} {ex.Message}")
        End Try
    End Function


    Sub AddSlave(slave As cSlave)
        slaves.Add(slave.id, slave)
    End Sub

    Function ReadHoldingRegisters(slaveid As Integer, address As Integer, length As Integer)
        Dim msgfor As String = $"{System.Reflection.MethodBase.GetCurrentMethod().Name} {Me.port}-{slaveid}-{address}"

        Try
            MBC.UnitIdentifier = slaveid
            Dim values = MBC.ReadHoldingRegisters(address, length)
            Return values
        Catch ex As Exception
            Throw New Exception($"Error {msgfor} {ex.Message}")
        End Try
    End Function

    Sub WriteHoldingRegisters(slaveid As Integer, address As Integer, values As Integer())
        Dim msgfor As String = $"{System.Reflection.MethodBase.GetCurrentMethod()} {Me.port}-{slaveid}-{address}"
        Try
            MBC.WriteMultipleRegisters(address, values)
        Catch ex As Exception
            Throw New Exception($"Error {msgfor} {ex.Message}")
        End Try
    End Sub



    Function WriteString(msg As String, isWaitResponse As Boolean, Optional ReadTimeoutMs As Integer = 100, Optional WriteTimeoutMs As Integer = 100)
        Dim portName As String = Me.port ' 串列埠名稱
        Dim baudRate As Integer = Me.baudrate ' 波特率
        Dim dataBits As Integer = 8 ' 資料位元
        Dim parity As Parity = Parity.None ' 奇偶校驗位
        Dim stopBits As StopBits = StopBits.One ' 停止位元
        Dim receivedData As String = ""
        Dim isReconnectNeeded As Boolean = False
        Dim st As New Stopwatch
        If MBC.Connected Then
            MBC.Disconnect()
            isReconnectNeeded = True
        End If
        WriteString2(Me, msg)
        ' 建立 SerialPort 物件
        Using serialPort = New SerialPort(portName, baudRate, parity, dataBits, stopBits)
            With serialPort
                .Handshake = Handshake.None ' 不使用握手
                .RtsEnable = True ' 啟用 RTS 控制
                .ReadTimeout = ReadTimeoutMs
                .WriteTimeout = WriteTimeoutMs
                .Open()
                Try
                    .Write(msg)
                    If isWaitResponse Then
                        st.Restart()
                        Do
                            Try
                                receivedData &= .ReadExisting
                            Catch ex2 As Exception
                                Throw New Exception($"Error: Wait response {portName} {ex2.Message}")
                            End Try
                        Loop While st.Elapsed.TotalMilliseconds < ReadTimeoutMs
                    End If
                Catch ex As Exception
                    Throw New Exception($"Error: Write {portName} {ex.Message}")
                End Try
            End With
        End Using
        If isReconnectNeeded Then
            Me.Connect()
        End If
        Return receivedData
    End Function
    'Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
    '    Debug.Print(e.ToString)
    'End Sub

End Class



Public Class cSlave
    Property id As String
    Property name As String
    Property readTags As New Dictionary(Of Integer, cTag)
    Property writableTags As New Dictionary(Of Integer, cTag)

    Sub New(id As String, name As String)
        Me.name = name
        Me.id = id
    End Sub

    Sub AddTag(tag As cTag)
        Select Case tag.tagtype.ToLower
            Case "r"
                readTags.Add(tag.address, tag)
            Case "w"
                writableTags.Add(tag.address, tag)
            Case "rw", "wr"
                readTags.Add(tag.address, tag)
                writableTags.Add(tag.address, tag)
        End Select
    End Sub
End Class




Public Class cTag
    ReadOnly Property name As String
    ReadOnly Property address As Integer
    ReadOnly Property length As Integer
    ReadOnly Property tagtype As String
    Sub New(name As String, address As Integer, tagtype As String, readLength As Integer)
        Me.name = name
        Me.address = address
        Me.length = readLength
        Me.tagtype = tagtype
    End Sub



End Class


'Public Class cTagR
'    Inherits cTag
'    ReadOnly Property values
'        Get
'            Return _values
'        End Get
'    End Property
'    Dim _values(0)
'    Sub New(name As String, address As Integer, Optional readLength As Integer = 1)
'        Me.name = name
'        Me.address = address
'        ReDim _values(readLength - 1)
'    End Sub

'    Function GetValues()
'        Dim id As Integer

'    End Function
'End Class

'Public Class cTagW
'    ReadOnly Property name As String
'    ReadOnly Property address As Integer
'    ReadOnly Property values
'        Get
'            Return _values
'        End Get
'    End Property

'    Dim _values(0)
'    Sub New(name As String, address As Integer, Optional readLength As Integer = 1)
'        Me.name = name
'        Me.address = address
'        ReDim _values(readLength - 1)
'    End Sub


'End Class


