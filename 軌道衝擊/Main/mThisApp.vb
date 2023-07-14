Module mThisApp
    Public Const CH1 = "COM3" ' channel #1
    Public Const CH2 = "COM4" ' channel #2
    Public SYS As cSYS

    Public FCONSOLE As FormConsole
    Public FMAIN As FormMain
    Public FSET As FormSettings
    Public FFBROWSER As FormFileBrowser
    Delegate Sub ConsoleLog_Invoker(log As String)





    ''' <summary>
    ''' 參考 https://docs.devexpress.com/WindowsForms/119891/build-an-application/how-to-perform-actions-on-application-startup
    ''' 讓 Winform application 從 Sub Main() 啟動
    ''' </summary>
    Sub Main()
        Try
            'Application.SetCompatibleTextRenderingDefault(False)
            'Application.EnableVisualStyles()
            FMAIN = New FormMain ' 主廠窗
            FCONSOLE = New FormConsole ' 訊息視窗
            FSET = New FormSettings ' 參數設定視窗
            FFBROWSER = New FormFileBrowser ' 記錄瀏覽器
            SYS = New cSYS
            SYS.連線檢查() ' 啟動前設備檢查
            SYS.設定小數位(2) ' 啟動前必要的基礎設定
            If ShowMsgBox("是否啟用模擬?", "是,否") = 1 Then
                SYS.SetEmulate(True) ' 初始設為模擬
                FMAIN.isEMU.Visible = True
            Else
                SYS.SetEmulate(False)
                FMAIN.isEMU.Visible = False
            End If
            ' 如果是全螢幕, 視窗最大化, 則加下兩行
            'FMAIN.FormBorderStyle = FormBorderStyle.None
            'FMAIN.WindowState = FormWindowState.Maximized
            Application.Run(FMAIN)  'Specify the startup form
        Catch ex As Exception
            ShowMsgBox("程式啟始發生錯誤, 程式將結束" & vbCrLf & ex.Message, "好")
        End Try
    End Sub


    Sub ConsoleLog(log As String)
        LOGGER.WriteLog("console", log, True) ' 寫到磁碟機
        ConsoleLog2(log) ' 寫到 formConsole 
    End Sub

    Private Sub ConsoleLog2(log As String)
        If FCONSOLE.FConsole1.InvokeRequired Then
            FCONSOLE.FConsole1.Invoke(New ConsoleLog_Invoker(AddressOf ConsoleLog2), log)
        Else
            FCONSOLE.WriteLog($"{Format(Now, "HH:mm:ss")} {log}")
        End If
    End Sub

    Sub DataLog(log As String)
        LOGGER.WriteLog("data", log, True)
    End Sub



    Function ShowMsgBox(msg As String, Optional buttonTexts As String = "好") As DialogResult
        Dim ar = Split(buttonTexts, ",")
        With DialogMsg
            .msg.Text = msg
            .ButtonPannel.Controls.Clear()
            If ar.Length = 1 Then
                .icon.Image = My.Resources.info
            Else
                .icon.Image = My.Resources.question
            End If
            For i = 1 To ar.Length
                Dim BTN As New Button
                BTN.Text = ar(i - 1) ' vb.net array 預設是 0 base
                BTN.Tag = i
                .ButtonPannel.Controls.Add(BTN)
                AddHandler BTN.Click, Sub(sender As Object, args As EventArgs)
                                          DialogMsg.DialogResult = sender.tag
                                          DialogMsg.Close()
                                      End Sub
            Next

            Return DialogMsg.ShowDialog()
        End With
    End Function

End Module
