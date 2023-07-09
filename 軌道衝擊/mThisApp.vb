Module mThisApp
    Public Const CH1 = "COM3" ' channel #1
    Public Const CH2 = "COM4" ' channel #2
    Public SYS As cSYS

    Sub AppInit()
        SYS = New cSYS
        SYS.SetEmulate(True) ' 初始設為模擬
        ConsoleLog("program starts")
    End Sub

    Sub ConsoleLog(log As String)
        LOGGER.WriteLog("console", log, True)
        FormConsole.WriteLog($"{Format(Now, "HH:mm:ss")} {log}")
    End Sub

    Sub DataLog(log As String)
        LOGGER.WriteLog("data", log, True)
    End Sub
End Module
