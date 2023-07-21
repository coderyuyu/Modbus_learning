Imports System.Net
Imports Controller.EasyPID
Module mPID
    Dim PID As EasyPID
    Dim COMS As New Dictionary(Of String, cCOM)
    Dim NewOutput As Decimal
    Dim oFact As Decimal
    Dim iFact As Decimal
    Public ChartData As New List(Of Array)
    Sub PreCheck()

        Dim com As cCOM
        Dim kp = MySettings.Kp
        Dim ki = MySettings.Ki
        Dim kd = MySettings.Kd
        Dim setpoint = MySettings.iSetpoint * iFact
        Dim minoutput = MySettings.oMin
        Dim maxoutput = MySettings.oMax
        Dim interval = MySettings.interval * 1000

        PID = New EasyPID(Kp:=kp, Ki:=ki, Kd:=kd,
                          Setpoint:=setpoint, OutputSpeed:=interval,
        MinOutput:=minoutput, MaxOutput:=maxoutput)

        COMS.Clear()
        ChartData.Clear()
        com = New cCOM(MySettings.inputCom)
        COMS.Add("icom", com)
        If MySettings.inputCom <> MySettings.outputCom Then
            com = New cCOM(MySettings.outputCom)

        End If
        COMS.Add("ocom", com)
        NewOutput = MySettings.oInit
        oFact = 10 ^ MySettings.oDec
        iFact = 10 ^ MySettings.iDec
        WriteInput(0)
    End Sub


    Sub PostCheck()
        For Each com As cCOM In COMS.Values
            com.DisConnect()
        Next
    End Sub

    Sub DoOnce()

        Dim iv
        Dim ov

        iv = ReadInput()
        ov = PID.GetControlSignal(iv * iFact, DateTime.Now.Ticks)
        NewOutput += ov
        WriteOutput(NewOutput * oFact)
        'Debug.Print($"{MySettings.iSetpoint} {iv / 10 ^ MySettings.iDec} {NewOutput}")
        ChartData.Add({MySettings.iSetpoint, iv, NewOutput})

        UpdateUI(FMAIN.PidInput, iv)
        UpdateUI(FMAIN.PidOutput, NewOutput) ' ov / 10 ^ MySettings.oDec)
        UpdateUI(FMAIN.PidError, MySettings.iSetpoint - iv)
        UpdateUI(FMAIN.pidSetpoint, MySettings.iSetpoint)
        UpdateUI(FMAIN.Chart1, ChartData)
        'WriteOutput(MySettings.oInit * 10 ^ MySettings.oDec)
    End Sub

    Sub DoEmuOnce()

        Dim iv As Decimal

        ' 以寫入的方法模擬 output 
        iv = ReadInput()
        If MySettings.iSetpoint + 0.3 - iv > 0 Then
            iv = iv * 1.03
            If iv = 0 Then iv = 4
        Else
            iv = iv * 0.91
        End If
        WriteInput(iv)


    End Sub

    Function ReadInput()
        Dim slaveid As Integer = MySettings.iSlave
        Dim addressStr As String = MySettings.iAddress
        Dim address As Integer
        Dim datalength As Integer = MySettings.iLength
        Dim iv As Decimal
        Dim ar() As Integer
        ' 以寫入的方法模擬 output 
        ar = COMS("icom").ReadTag(slaveid, address, datalength)
        If datalength = 1 Then
            iv = ar(0)
        ElseIf datalength = 2 Then
            iv = ar(0) * 16 ^ 2 + ar(1)
        Else
            Throw New Exception("input length > 2 not supported")
        End If
        ConsoleLog($"Emu read input {iv}")
        Return iv / iFact
    End Function

    Function WriteInput(iv As Decimal) '  for EMU
        Dim slaveid As Integer = MySettings.iSlave
        Dim addressStr As String = MySettings.iAddress
        Dim address As Integer
        Dim datalength As Integer = MySettings.iLength
        Dim ar() As Integer
        iv = iv * iFact
        If datalength = 1 Then
            ar = {iv}
        ElseIf datalength = 2 Then
            Dim hx As String = CInt(iv).ToString("X4")
            'Debug.Print(hx)


            Dim v1 As Integer
            Dim v2 As Integer
            v1 = Convert.ToInt32(hx.Substring(0, 2), 16)
            v2 = Convert.ToInt32(hx.Substring(2, 2), 16)
            ar = {v1, v2}
            ConsoleLog($"Emu write input {iv}")
            COMS("icom").WriteTag(slaveid, address, ar)
        Else
            Throw New Exception("output length > 2 not supported")
        End If
        Return iv
    End Function

    Function WriteOutput(ov As Decimal)
        Dim slaveid As Integer = MySettings.iSlave
        Dim addressStr As String = MySettings.iAddress
        Dim address As Integer
        Dim datalength As Integer = MySettings.iLength
        Dim ar() As Integer
        slaveid = MySettings.oSlave
        addressStr = MySettings.oAddress
        datalength = MySettings.oLength
        ov = ov * oFact

        If datalength = 1 Then
            ar = {ov}
        ElseIf datalength = 2 Then
            Dim hx As String = CInt(ov).ToString("X4")
            'Debug.Print(hx)


            Dim v1 As Integer
            Dim v2 As Integer
            v1 = Convert.ToInt32(hx.Substring(0, 2), 16)
            v2 = Convert.ToInt32(hx.Substring(2, 2), 16)
            ar = {v1, v2}
            COMS("ocom").WriteTag(slaveid, address, ar)
        Else
            Throw New Exception("output length > 2 not supported")
        End If
        Return ov
    End Function
End Module
