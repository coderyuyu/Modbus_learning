Imports System.IO.Ports
Imports System.Reflection
Imports System.Security.Policy
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting

Module mTasks
    Public cs As CancellationTokenSource
    Public ctoken As CancellationToken
    Dim taskCount As Integer = 0
    Public DATA0 As cDATA0 ' for read
    Public DATA1 As cDATA1 ' for process
    Public DATA2 As cDATA2 ' for display
    Public ChartData As New List(Of Array)
    Public CrossTaskLocker As New Object
    Public count As Integer
    Public minTons As Decimal

    Delegate Sub UpdateUI_Invoker(ctrl As Control, value As Object)
    Delegate Sub UpdateAC_Invoker(AC As String)
    Public Delegate Function TaskRun_Invoker()
    Public Delegate Function RunSub_Invoker()


    Sub RunBgTask(interval As Integer, runner As TaskRun_Invoker, Optional methodName As String = "")
        'Dim methodName As String = NameOf(runner) ' 取得這個 sub 或 function name
        Dim loopWait As Integer
        Dim exitMsg As String = ""
        Task.Run(Async Function()
                     Dim stw As New Stopwatch
                     AddTaskCount()
                     ConsoleLog($"{methodName} start")
                     If methodName = "doACImpact" Then
                         SYS.開始衝擊 = True
                     End If
                     Do
                         Try
                             stw.Restart()
                             If methodName = "doACImpact" Then
                                 runner()
                             Else
                                 Await runner()
                             End If
                             stw.Stop()
                             loopWait = interval - stw.Elapsed.Milliseconds
                             If loopWait > 0 Then
                                 Await Task.Delay(loopWait)
                             Else
                                 ConsoleLog($"{methodName} 執行時間超過 {loopWait} ms, count={count}")
                             End If
                         Catch ex As Exception
                             If ex.Message.ToLower.StartsWith("stoptasks") Then
                                 If ex.Message.Contains(":") Then
                                     exitMsg = ex.Message.Substring(ex.Message.IndexOf(":") + 1)
                                 Else
                                     exitMsg = ""
                                 End If
                                 Exit Do
                             Else
                                 ConsoleLog(methodName & ex.Message)
                                 ConsoleLog(ex.ToString)
                             End If


                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Function).ContinueWith(Sub()
                                                SubstractTaskCount()
                                                If methodName = "doACImpact" Then
                                                    SYS.開始衝擊 = False
                                                End If
                                                ConsoleLog($"{methodName} end")
                                                If exitMsg <> "" Then
                                                    StopTasks(exitMsg)
                                                End If
                                            End Sub)
    End Sub

    Sub StartTasks()
        ConsoleLog("Tasks start")
        DATA0 = New cDATA0
        DATA1 = New cDATA1
        DATA2 = New cDATA2
        AddHandler DATA1.變頻器頻率變更, Sub(original As Decimal, ev As Decimal)
                                      SYS.ev = ev ' StartEmuTask 需要用到
                                      SYS.設定變頻器頻率(original + ev)
                                  End Sub
        cs = New CancellationTokenSource
        ctoken = cs.Token
        taskCount = 0
        StartSystemCheck(1000)
        'RunBgTask(1000, AddressOf doSystemCheck, NameOf(doSystemCheck))
        'StartSystemCheckTask(1000)
        'RunBgTask(500, AddressOf ReadDATA0, NameOf(ReadDATA0))
        StartReadDATA0(500)
        'StartReadTask(500)
        StartProcessDATA1(1000)
        'RunBgTask(1000, AddressOf ProcessDATA1, NameOf(ProcessDATA1))
        'StartProcessTask(10000)
        StartUpdateUI(1000)
        'RunBgTask(1000, AddressOf UpdateUIDATA2, NameOf(UpdateUIDATA2))
        'StartUIUdateTask(1000)
        StartLog(1000)
        If SYS.isEmulate Then
            'StartEmuTask(1000)
            'RunBgTask(1000, AddressOf DoEmu, NameOf(DoEmu))
            StartEmulate(1000)
            'MsgBox("TODO")
        End If
    End Sub

    Sub StopTasks(Optional message As String = "")
        If cs IsNot Nothing Then
            SYS.開始記錄 = False
            cs.Cancel()
            SYS.停機()
            ConsoleLog("Tasks end")
        End If
        Do While taskCount <> 0
            ShowMsgBox("等候系統關閉..." & taskCount, "", 100, 1)
            Task.Delay(100).Wait()
        Loop
        If message <> "" Then
            ShowMsgBox(message, "好")
        End If
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
    'Sub StartReadTask(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Dim excaptionTime As Date = Nothing
    '    Task.Run(Sub()
    '                 Dim stw As New Stopwatch
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 Do
    '                     Try ' 這個 try catch 很重要, 避免在背景執行中當掉
    '                         stw.Restart()
    '                         SyncLock DATA0
    '                             With DATA0
    '                                 .主缸力值 = SYS.主缸力值
    '                             End With
    '                         End SyncLock
    '                         'UpdateUI(FMAIN.CylinderTons, DATA0.主缸力值)
    '                         stw.Stop()
    '                         ' 按照 interval 計算需要延遲的 ms, 需要時利用 task.delay 延遲
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then Task.Delay(loopWait).Wait()
    '                         excaptionTime = Nothing
    '                     Catch ex As Exception
    '                         ' 當掉時的處理
    '                         ConsoleLog(methodName & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                         If excaptionTime = Nothing Then
    '                             excaptionTime = Now
    '                         Else
    '                             ' 這個機制僅放在 ReadTask
    '                             If Now.Subtract(excaptionTime).TotalMilliseconds > SYS.異常持續上限 Then
    '                                 StopTasks() ' Stop by exception timeout, 會執行 cs.cancel, loop 會結束
    '                                 Try
    '                                     SYS.停機()
    '                                 Catch ex2 As Exception
    '                                     ' 防止停機也失敗
    '                                 End Try
    '                             End If
    '                         End If


    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested ' 直到取消
    '             End Sub).ContinueWith(Sub()

    '                                       SubstractTaskCount() ' taskCount 用來記錄有幾個背景task在跑
    '                                       ConsoleLog($"{methodName} end")
    '                                   End Sub)
    'End Sub

    'Sub StartUIUdateTask(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Dim excaptionTime As Date = Nothing
    '    Task.Run(Sub()
    '                 Dim stw As New Stopwatch
    '                 Dim newTons As Decimal
    '                 Dim newFeq As Decimal
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 Do
    '                     Try ' 這個 try catch 很重要, 避免在背景執行中當掉
    '                         stw.Restart()
    '                         SyncLock DATA0
    '                             With DATA2
    '                                 .主缸力值 = DATA0.主缸力值
    '                             End With
    '                         End SyncLock
    '                         newTons = DATA2.主缸力值
    '                         newFeq = SYS.最後更新變頻器頻率
    '                         UpdateUI(FMAIN.CylinderTons, newTons)
    '                         UpdateUI(FMAIN.feq, newFeq)
    '                         If ChartData.Count > 300 Then
    '                             ChartData.RemoveAt(0)
    '                         End If
    '                         ChartData.Add({newFeq, newTons})
    '                         UpdateUI(FMAIN.Chart1, ChartData)
    '                         stw.Stop()
    '                         ' 按照 interval 計算需要延遲的 ms, 需要時利用 task.delay 延遲
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then Task.Delay(loopWait).Wait()
    '                         excaptionTime = Nothing
    '                     Catch ex As Exception
    '                         ' 當掉時的處理
    '                         ConsoleLog(methodName & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested ' 直到取消
    '             End Sub).ContinueWith(Sub()
    '                                       SubstractTaskCount() ' taskCount 用來記錄有幾個背景task在跑
    '                                       ConsoleLog($"{methodName} end")
    '                                   End Sub)
    'End Sub


    ''' <summary>
    ''' 定期檢查系統各項數據, 計算, 決策, 更新畫面, 記錄等
    ''' 數據不直接由系統讀取, 而由 DATA0 搬過來給 DATA1
    ''' 在DATA1 這個物件中, 需設計必要的計算/決策 及 event 來進行系統的控制動作
    ''' </summary>
    ''' <param name="interval"></param>
    'Sub StartProcessTask(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Task.Run(Sub()
    '                 Dim stw As New Stopwatch
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 Do
    '                     Try
    '                         stw.Restart()
    '                         SyncLock DATA1
    '                             SyncLock DATA0
    '                                 DATA1.主缸力值 = DATA0.主缸力值
    '                             End SyncLock
    '                         End SyncLock
    '                         DataLog(DATA1.LogString)
    '                         stw.Stop()
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then
    '                             ' 由於這個task規格說10執行一次, 這個wait loop可能會影響到關機, 故改寫
    '                             Dim loopWaitCheck As Integer = 0
    '                             Do While loopWaitCheck < loopWait And Not ctoken.IsCancellationRequested
    '                                 Dim swait As Integer = loopWait - loopWaitCheck
    '                                 If swait > 1000 Then
    '                                     swait = 1000
    '                                 ElseIf swait > 0 Then
    '                                 Else
    '                                     swait = 0
    '                                 End If
    '                                 Task.Delay(swait).Wait()
    '                                 loopWaitCheck += swait
    '                                 If ctoken.IsCancellationRequested Then Exit Do ' 提早離開
    '                             Loop

    '                         End If
    '                     Catch ex As Exception
    '                         ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested
    '             End Sub).ContinueWith(Sub()
    '                                       SubstractTaskCount()
    '                                       ConsoleLog($"{methodName} end")
    '                                   End Sub)
    'End Sub
    ''' <summary>
    ''' AC 雙點衝擊
    ''' </summary>
    ''' <param name="interval"></param>
    'Sub StartACTask(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Dim isCheckEmergent As Boolean = True ' true=do check  false=do AC 
    '    Dim isAorC As Boolean = True ' true=A false=C
    '    Dim count As Integer = FSET.累計次數
    '    Dim minTons As Decimal = FSET.容許最低承載力值
    '    Task.Run(Sub()
    '                 Dim stw As New Stopwatch
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 SYS.開始衝擊 = True
    '                 Do
    '                     Try
    '                         stw.Restart()
    '                         If isCheckEmergent Then
    '                             Try
    '                                 If SYS.緊急按鈕狀態() = True Then
    '                                     StopTasks() ' Stop by StopTasks
    '                                     SYS.停機()
    '                                 End If
    '                             Catch ex As Exception
    '                                 ConsoleLog(ex.ToString)
    '                             End Try

    '                         Else
    '                             If DATA0.主缸力值 >= minTons Then
    '                                 If isAorC Then
    '                                     SYS.A點衝擊()
    '                                     UpdateAC("A")
    '                                 Else
    '                                     SYS.C點衝擊()
    '                                     UpdateAC("C")
    '                                     If SYS.開始記錄 Then
    '                                         count += 1
    '                                         If count Mod 100 Then
    '                                             FSET.更新累計次數(count) ' 每100次存檔
    '                                         End If
    '                                         UpdateUI(FMAIN.counter, count)
    '                                     End If
    '                                 End If
    '                                 isAorC = Not isAorC
    '                             Else
    '                                 '油壓啟動後，必須大於17才可點 “雙點衝擊” ？
    '                             End If
    '                         End If

    '                         isCheckEmergent = Not isCheckEmergent
    '                         stw.Stop()
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then Task.Delay(loopWait).Wait()
    '                     Catch ex As Exception
    '                         ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested
    '             End Sub).ContinueWith(Sub()
    '                                       SubstractTaskCount()
    '                                       SYS.開始衝擊 = False
    '                                       ConsoleLog($"{methodName} end")
    '                                   End Sub)
    'End Sub



    ''' <summary>
    ''' 這是模擬用的程式, 適合系統離線時開發用
    ''' </summary>
    ''' <param name="interval"></param>
    'Sub StartEmuTask(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Task.Run(Async Function()
    '                 Dim stw As New Stopwatch
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 Do
    '                     Try
    '                         stw.Restart()
    '                         Await DoEmu()
    '                         'Dim v As Decimal
    '                         'SyncLock DATA0
    '                         '    v = DATA0.主缸力值
    '                         'End SyncLock
    '                         '' 因為離線, 主缸力值不會有變化
    '                         '' 因此在此依 sys.ev 調整主缸力值, 寫出主缸力值
    '                         'Select Case SYS.ev
    '                         '    Case > 0
    '                         '        SYS.寫入主缸力值(v + 0.2)
    '                         '    Case < 0
    '                         '        SYS.寫入主缸力值(v - 0.2)
    '                         '    Case Else

    '                         'End Select
    '                         stw.Stop()
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then
    '                             Await Task.Delay(loopWait)
    '                         End If

    '                     Catch ex As Exception
    '                         ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested
    '             End Function).ContinueWith(Sub()
    '                                            SubstractTaskCount()
    '                                            ConsoleLog($"{methodName} end")
    '                                        End Sub)
    'End Sub



    'Sub testAsync(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Dim task As Task = Task.Run(Async Function()
    '                                    Dim stw As New Stopwatch
    '                                    AddTaskCount()
    '                                    ConsoleLog($"{methodName} start")
    '                                    Do
    '                                        Try
    '                                            stw.Restart()
    '                                            ' work here
    '                                            stw.Stop()
    '                                            loopWait = interval - stw.Elapsed.Milliseconds
    '                                            If loopWait > 0 Then
    '                                                Await Task.Delay(loopWait)
    '                                            End If
    '                                        Catch ex As Exception
    '                                            ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
    '                                            ConsoleLog(ex.ToString)
    '                                        End Try
    '                                    Loop While Not ctoken.IsCancellationRequested
    '                                End Function).ContinueWith(Sub()
    '                                                               SubstractTaskCount()
    '                                                               ConsoleLog($"{methodName} end")
    '                                                           End Sub)
    'End Sub


    'Sub StartSystemCheckTask(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Task.Run(Sub()
    '                 Dim stw As New Stopwatch
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 Do
    '                     Try
    '                         stw.Restart()
    '                         If SYS.緊急按鈕狀態 OrElse
    '                             SYS.主缸力值 > FSET.容許最高承載力值 OrElse
    '                             SYS.開始衝擊 AndAlso SYS.主缸力值 < FSET.容許最低承載力值 Then
    '                             '
    '                             SYS.停機()
    '                             cs.Cancel()
    '                         End If

    '                         stw.Stop()
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then Task.Delay(loopWait).Wait()
    '                     Catch ex As Exception
    '                         ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested
    '             End Sub).ContinueWith(Sub()
    '                                       SubstractTaskCount()
    '                                       ConsoleLog($"{methodName} end")
    '                                   End Sub)
    'End Sub

    'Sub TaskSample(interval As Integer)
    '    Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
    '    Dim loopWait As Integer
    '    Task.Run(Sub()
    '                 Dim stw As New Stopwatch
    '                 AddTaskCount()
    '                 ConsoleLog($"{methodName} start")
    '                 Do
    '                     Try
    '                         stw.Restart()
    '                         ' work here
    '                         stw.Stop()
    '                         loopWait = interval - stw.Elapsed.Milliseconds
    '                         If loopWait > 0 Then Task.Delay(loopWait).Wait()
    '                     Catch ex As Exception
    '                         ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
    '                         ConsoleLog(ex.ToString)
    '                     End Try
    '                 Loop While Not ctoken.IsCancellationRequested
    '             End Sub).ContinueWith(Sub()
    '                                       SubstractTaskCount()
    '                                       ConsoleLog($"{methodName} end")
    '                                   End Sub)
    'End Sub

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
                Case "Chart"

                    FMAIN.UpdateChart(value)


            End Select
        End If
    End Sub


    Sub UpdateAC(AC As String)
        'Static lastupdate As Date = Now
        If FMAIN.A.InvokeRequired Then
            FMAIN.A.Invoke(New UpdateAC_Invoker(AddressOf UpdateAC), AC)
        Else
            'Debug.Print(Now.Subtract(lastupdate).TotalMilliseconds)
            'lastupdate = Now
            Select Case AC
                Case "A"
                    FMAIN.A.ValueSelect2 = True
                    FMAIN.A.ValueSelect1 = False

                    FMAIN.C.ValueSelect1 = True
                    FMAIN.C.ValueSelect2 = False

                Case "C"
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

    Sub AddTaskCount()
        SyncLock CrossTaskLocker
            taskCount += 1
        End SyncLock
    End Sub

    Sub SubstractTaskCount()
        SyncLock CrossTaskLocker
            taskCount -= 1
        End SyncLock
    End Sub



End Module
