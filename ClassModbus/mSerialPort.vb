Imports System.IO
Imports System.IO.Ports
Imports ClassModbus
Public Module mSerialPort
    'Dim serialPort As New System.IO.
    Dim waitresponse As Boolean
    WithEvents serialPort As SerialPort
    Function WriteString2(C As cCOM, msg As String)
        Dim dataBits As Integer = 8 ' 資料位元
        Dim parity As Parity = Parity.None ' 奇偶校驗位
        Dim stopBits As StopBits = StopBits.One ' 停止位元
        serialPort = New SerialPort(C.port, C.baudrate, parity, dataBits, stopBits)
        AddHandler serialPort.DataReceived, AddressOf DataReceivedHandler
        serialPort.Open()
        serialPort.WriteLine(msg)
        Return True
    End Function

    Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Debug.Print(e.ToString)
    End Sub

End Module
