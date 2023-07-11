Module mThisApp
    Public Const CH1 = "COM3" ' channel #1
    Public Const CH2 = "COM4" ' channel #2
    Public SYS As cSYS

    Public FCONSOLE As FormConsole
    Public FMAIN As FormMain
    Public FSET As FormSettings
    Public FFBROWSER As FormFileBrowser
    Delegate Sub ConsoleLog_Invoker(log As String)


    Public Enum SystemStatus
        初值化
        啟動油壓
        雙點衝擊
        A點衝擊
        C點衝擊
    End Enum


    ''' <summary>
    ''' 參考 https://docs.devexpress.com/WindowsForms/119891/build-an-application/how-to-perform-actions-on-application-startup
    ''' 讓 Winform application 從 Sub Main() 啟動
    ''' </summary>
    Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        FMAIN = New FormMain ' 主廠窗
        FCONSOLE = New FormConsole ' 訊息視窗
        FSET = New FormSettings ' 參數設定視窗
        FFBROWSER = New FormFileBrowser ' 記錄瀏覽器
        SYS = New cSYS
        SYS.SetEmulate(True) ' 初始設為模擬
        UpdateAC(SystemStatus.初值化)
        Application.Run(FMAIN)  'Specify the startup form
    End Sub

    Sub AppInit()

    End Sub

    Sub ConsoleLog(log As String)
        LOGGER.WriteLog("console", log, True)
        ConsoleLog2(log)
        Debug.Print(log)
    End Sub

    Sub ConsoleLog2(log As String)
        If FCONSOLE.FConsole1.InvokeRequired Then
            FCONSOLE.FConsole1.Invoke(New ConsoleLog_Invoker(AddressOf ConsoleLog2), log)
        Else
            FCONSOLE.WriteLog($"{Format(Now, "HH:mm:ss")} {log}")
        End If
    End Sub



    Sub DataLog(log As String)
        LOGGER.WriteLog("data", log, True)
    End Sub
End Module
