Imports System.IO.Ports

Module mTest
    Function WriteStringXXX(msg As String, isWaitResponse As Boolean, Optional ReadTimeoutMs As Integer = 100, Optional WriteTimeoutMs As Integer = 100)
        Dim AA As String
        Dim timeoutMsec As Integer = 1000
        Dim receivedData As String = ""
        AA = "#0F0000" & vbCr
        'SerialPort1.WriteLine(AA)
        ' 建立 SerialPort 物件
        Using serialPort = New SerialPort("COM3", 9600, Parity.None, 8, 1)
            With serialPort
                .Handshake = Handshake.None ' 不使用握手
                .RtsEnable = True ' 啟用 RTS 控制
                .ReadTimeout = timeoutMsec ' 設定 timeout 時間
                .WriteTimeout = timeoutMsec
                .Open()
                Try
                    .Write(msg) ' 因為 AA 有 vbCr, 覺得用Write即可, 不用WriteLine
                    receivedData = .ReadExisting
                Catch ex As Exception
                    Debug.Print(ex.ToString)
                End Try
            End With
        End Using
        Debug.Print(receivedData)
        Return receivedData
    End Function
End Module
