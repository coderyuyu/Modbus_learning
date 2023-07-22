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
        NewOutput = MySettings.oInit
        oFact = 10 ^ MySettings.oDec
        iFact = 10 ^ MySettings.iDec
        Dim com As cCOM
        Dim kp = MySettings.Kp
        Dim ki = MySettings.Ki
        Dim kd = MySettings.Kd

        Dim setpoint = MySettings.iSetpoint
        Dim minoutput = MySettings.oMin
        Dim maxoutput = MySettings.oMax
        Dim interval = MySettings.interval * 1000

        PID = New EasyPID(Kp:=kp / 10, Ki:=ki, Kd:=kd,
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

        WriteInput(0)
    End Sub


    Sub PostCheck()
        For Each com As cCOM In COMS.Values
            com.DisConnect()
        Next
    End Sub

    Sub DoOnce()

        Dim iv As Long
        Dim ov As Decimal

        iv = ReadInput()
        ov = PID.GetControlSignal(iv, DateTime.Now.Ticks)
        NewOutput += ov
        Debug.Print($"set={PID.Setpoint} current={iv} pid={ov} adj={NewOutput}")
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
        'ConsoleLog($"Emu read input {iv}")
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
            'ConsoleLog($"Emu write input {iv}")
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

    Sub doTest()
        Dim rnd As New Random(Now.Second)
        Dim count = 0
        Dim ar(200) As Double
        For i = 0 To 200
            ar(i) = (i + 3) + rnd.NextDouble()
        Next
        Dim PID As EasyPID = New EasyPID(0.009, 0.05, 0.3, 120, 100)
        For i = 0 To 200
            Dim currentTime = Now.Ticks
            Dim pv = ar(i)
            Dim cv = PID.GetControlSignal(pv, currentTime)
            Console.WriteLine($"Process variable is: {pv}, Control Variable is: {cv}")
        Next
    End Sub

    Function GuessKp()
        Dim setpoint = MySettings.iSetpoint

        Dim PID As EasyPID
        Dim kp As Double = 1
        Dim ov As Double
        Do
            PID = New EasyPID(kp, 0, 0, setpoint, 100, -1, 1)
            ov = PID.GetControlSignal(MySettings.oInit, Now.Ticks)
            If ov = 1 Then
                kp = kp / 10
            ElseIf ov = -1 Then
                kp = kp * 10
            Else
                Return kp
                Exit Do
            End If
        Loop
    End Function
End Module
