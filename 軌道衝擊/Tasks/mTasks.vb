Imports System.Threading
Module mTasks
    Dim cs As CancellationTokenSource
    Dim ctoken As CancellationToken
    Const INTERVAL As Integer = 1000
    Dim taskCount As Integer = 0
    Dim DATA0 As cDATA0
    Dim DATA1 As cDATA1
    Delegate Sub UpdateUI_Invoker(ctrl As Control, value As Object)
    Delegate Sub UpdateAC_Invoker(status As Integer)



    Sub StartTasks()
        ConsoleLog("Tasks start")
        DATA0 = New cDATA0
        DATA1 = New cDATA1
        LOGGER.AddLogHeader("data", DATA1.LogHeaders)
        AddHandler DATA1.變頻器頻率變更, Sub(original As Decimal, ev As Decimal)
                                      SYS.ev = ev ' StartEmuTask 需要用到
                                      SYS.設定變頻器頻率(original + ev)
                                      'UpdateUI(FMAIN.vfd, original + ev)
                                  End Sub
        cs = New CancellationTokenSource
        ctoken = cs.Token
        taskCount = 0
        StartReadTask(1000)
        StartProcessTask(3000)

        If SYS.isEmulate Then
            StartEmuTask(1000)
        End If
    End Sub

    Sub StopTasks()
        cs.Cancel()
        ConsoleLog("Tasks end")
    End Sub

    Function RunningTasksCount()
        Return taskCount
    End Function
    ''' <summary>
    ''' 定期讀取系統各項數據的task
    ''' 資料集中存在DATA0中
    ''' 只讀取, 不處理, 必要時更新畫面
    ''' </summary>
    ''' <param name="interval"></param>
    Sub StartReadTask(interval As Integer)
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     taskCount += 1
                     Do
                         Try
                             stw.Restart()
                             SyncLock DATA0
                                 With DATA0
                                     .主缸力值 = SYS.主缸力值
                                 End With
                             End SyncLock
                             UpdateUI(FMAIN.CylinderTons, DATA0.主缸力值)
                             stw.Stop()
                             If interval > stw.Elapsed.Milliseconds Then Task.Delay(interval - stw.Elapsed.Milliseconds).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(Sub()
                                           taskCount -= 1
                                       End Sub)
    End Sub
    ''' <summary>
    ''' 定期檢查系統各項數據, 計算, 決策, 更新畫面, 記錄等
    ''' 數據不直接由系統讀取, 而由 DATA0 搬過來給 DATA1
    ''' 在DATA1 這個物件中, 需設計必要的計算/決策 及 event 來進行系統的控制動作
    ''' </summary>
    ''' <param name="interval"></param>
    Sub StartProcessTask(interval As Integer)
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     taskCount += 1
                     Do
                         Try
                             stw.Restart()
                             SyncLock DATA1
                                 SyncLock DATA0
                                     DATA1.主缸力值 = DATA0.主缸力值
                                 End SyncLock
                             End SyncLock
                             DataLog(DATA1.LogString)
                             stw.Stop()
                             If interval > stw.Elapsed.Milliseconds Then Task.Delay(interval - stw.Elapsed.Milliseconds).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(Sub()
                                           taskCount -= 1
                                       End Sub)
    End Sub
    ''' <summary>
    ''' AC 雙點衝擊
    ''' </summary>
    ''' <param name="interval"></param>
    Sub StartACTask(interval As Integer)
        Dim isCheckEmergent As Boolean = True ' true=do check  false=do AC 
        Dim isAorC As Boolean = True ' true=A false=C
        Dim count As Integer = FSET.累計次數
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     taskCount += 1
                     Do
                         Try
                             stw.Restart()
                             If isCheckEmergent Then
                                 If SYS.緊急按鈕() = True Then
                                     StopTasks()
                                 End If
                             Else
                                 If isAorC Then
                                     SYS.A點衝擊()
                                     UpdateAC(SystemStatus.A點衝擊)
                                 Else
                                     SYS.C點衝擊()
                                     UpdateAC(SystemStatus.C點衝擊)
                                     If FMAIN.isRecord Then
                                         count += 1
                                         If count Mod 100 Then
                                             FSET.更新累計次數(count) ' 每100次存檔
                                         End If
                                         UpdateUI(FMAIN.counter, count)
                                     End If
                                 End If
                                     isAorC = Not isAorC
                             End If
                             isCheckEmergent = Not isCheckEmergent
                             stw.Stop()
                             If interval > stw.Elapsed.Milliseconds Then Task.Delay(interval - stw.Elapsed.Milliseconds).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(
                 Sub()
                     taskCount -= 1
                 End Sub)
    End Sub



    ''' <summary>
    ''' 這是模擬用的程式, 適合系統離線時開發用
    ''' </summary>
    ''' <param name="interval"></param>
    Sub StartEmuTask(interval As Integer)
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     taskCount += 1
                     Do
                         Try
                             stw.Restart()
                             Dim v As Decimal
                             SyncLock DATA0
                                 v = DATA0.主缸力值
                             End SyncLock
                             ' 因為離線, 主缸力值不會有變化
                             ' 因此在此依 sys.ev 調整主缸力值, 寫出主缸力值
                             Select Case SYS.ev
                                 Case > 0
                                     SYS.寫入主缸力值(v + 0.2)
                                 Case < 0
                                     SYS.寫入主缸力值(v - 0.2)
                                 Case Else

                             End Select
                             stw.Stop()
                             If interval > stw.Elapsed.Milliseconds Then Task.Delay(interval - stw.Elapsed.Milliseconds).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(Sub()
                                           taskCount -= 1
                                       End Sub)
    End Sub

    ''' <summary>
    ''' 這是通用的畫面更新程序
    ''' 適合不同執行緒更新畫面
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <param name="value"></param>
    Sub UpdateUI(ctrl As Control, value As Object)
        If ctrl.InvokeRequired Then
            ctrl.Invoke(New UpdateUI_Invoker(AddressOf UpdateUI), ctrl, value)
        Else
            Select Case TypeName(ctrl)
                Case "TextBox"
                    ctrl.Text = value
            End Select
        End If
    End Sub


    Sub UpdateAC(state As Integer)
        If FMAIN.A.InvokeRequired Then
            FMAIN.A.Invoke(New UpdateAC_Invoker(AddressOf UpdateAC), state)
        Else
            Select Case state
                Case SystemStatus.A點衝擊
                    FMAIN.A.ValueSelect2 = True
                    FMAIN.A.ValueSelect1 = False

                    FMAIN.C.ValueSelect1 = True
                    FMAIN.C.ValueSelect2 = False

                Case SystemStatus.C點衝擊
                    FMAIN.C.ValueSelect2 = True
                    FMAIN.C.ValueSelect1 = False

                    FMAIN.A.ValueSelect1 = True
                    FMAIN.A.ValueSelect2 = False
                Case Else
                    FMAIN.A.ValueSelect1 = False
                    FMAIN.C.ValueSelect1 = False
                    FMAIN.A.ValueSelect2 = False
                    FMAIN.C.ValueSelect2 = False
            End Select
        End If
    End Sub
End Module
