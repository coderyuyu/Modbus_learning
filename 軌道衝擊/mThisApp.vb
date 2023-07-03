Module mThisApp
    Public Const CH1 = "COM3" ' channel #1
    Public Const CH2 = "COM4" ' channel #2
    Public SYS As cSYS

    Sub AppInit()
        SYS = New cSYS
        ConsoleLog("program starts")
    End Sub

    Sub ConsoleLog(log As String)
        LOGGER.WriteLog("console", log, True)
    End Sub

    Sub DataLog(log As String)
        LOGGER.WriteLog("data", log, True)
    End Sub
End Module
