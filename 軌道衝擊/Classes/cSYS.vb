Public Class cSYS
    Property COMS As Dictionary(Of String, cCOM)
    Property TAGS As Dictionary(Of String, Array)
    Sub New()
        loadConfig()
    End Sub

    Sub ConnectAll()
        Dim com As cCOM
        For Each k In COMS.Keys
            com = COMS(k)
            com.Connect()
        Next
    End Sub

    Sub DisConnectAll()
        Dim com As cCOM
        For Each k In COMS.Keys
            com = COMS(k)
            com.DisConnect()
        Next
    End Sub
    ''' <summary>
    ''' 客戶監控組態 com ports 及 tags
    ''' 注意tagname不要重覆
    ''' </summary>



    Private Sub loadConfig()
        COMS = New Dictionary(Of String, cCOM)
        Dim com As cCOM
        com = New cCOM(CH1, Name:="COM3")
        With com
            .AddDIO(New cDIO(DioName:="DO", slaveid:=&HF00, dataLength:=1))
            ' 在 cCOM 用 WriteString("#0F00" & "00" & Chr$(13)) '全關指令(DO)
            ' 在 cCOM 用 WriteString("#0F00" & "02" & Chr$(13)) 'A點衝擊(DO)
            ' 在 cCOM 用 WriteString("#0F00" & "04" & Chr$(13)) 'C點衝擊(DO)
        End With
        COMS.Add(com.SerialPort, com)

        com = New cCOM(CH2, Name:="COM4")
        With com
            .AddTAG(New cTAG(tagName:="InverterOnOff", slaveid:=4, registerAddress:=&H2000, dataLength:=2))
            .AddTAG(New cTAG(tagName:="Frequency", slaveid:=4, registerAddress:=&H2001, dataLength:=2))
            .AddTAG(New cTAG(tagName:="Pressure", slaveid:=1, registerAddress:=&H26, dataLength:=2))
            .AddDIO(New cDIO(DioName:="DI", slaveid:=&HF06, dataLength:=2))
            ' 在 cCOM 用 WriteString("$0F6" & Chr$(13))
        End With
        COMS.Add(com.SerialPort, com)
    End Sub
End Class
