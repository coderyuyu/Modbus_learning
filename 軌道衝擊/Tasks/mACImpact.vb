Imports System.Threading

Module mACImpact

    Sub StartACImpact(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name
        Dim loopWait As Integer = 0
        Dim exitMsg As String = ""
        Dim doOne As Integer = interval / 2
        Dim stt As New Stopwatch

        Debug.Print($"{methodName} Thread id {Thread.CurrentThread.ManagedThreadId}")
        Dim T = Task.Run(Async Function()
                             Debug.Print($"{methodName} async Thread id {Thread.CurrentThread.ManagedThreadId}")
                             Dim stw As New Stopwatch
                             Dim ms As Integer = 0
                             Dim startDo As Date = Now
                             AddTaskCount(methodName) 'StartACImpact
                             PreProcess()
                             Dim err As Decimal
                             Dim averr As Decimal = 0
                             Dim isA As Boolean = True

                             'timer = New System.Threading.Timer(
                             'Sub()
                             '    Debug.Print("control " & Now.Subtract(st).TotalMilliseconds)
                             '    'If SYS.開始記錄 Then
                             '    '    If isA Then
                             '    '        DataLog(DATA1.LogString(count + 1, DATA1.主缸力值, 0))
                             '    '    Else
                             '    '        DataLog(DATA1.LogString(count + 1, 0, DATA1.主缸力值))
                             '    '    End If
                             '    'End If
                             '    'If isA Then
                             '    '    UpdateAC("C")
                             '    '    SYS.A點衝擊()
                             '    'Else
                             '    '    UpdateAC("A")
                             '    '    SYS.C點衝擊()
                             '    '    count += 1
                             '    'End If

                             '    isA = Not isA
                             '    st = Now
                             'End Sub, Nothing, 0, doOne)
                             'stw.Start()

                             Do

                                 Try

                                     err = Now.Subtract(startDo).TotalMilliseconds - doOne
                                     startDo = Now
                                     If Math.Abs(err) < 5 Then
                                         averr = (averr + err) / 2
                                     Else
                                         Debug.Print("control " & err)
                                     End If

                                     If SYS.開始記錄 Then
                                         If isA Then
                                             DataLog(DATA1.LogString(count + 1, DATA1.主缸力值, 0))
                                         Else
                                             DataLog(DATA1.LogString(count + 1, 0, DATA1.主缸力值))
                                         End If
                                     End If

                                     'tw.Restart()
                                     If isA Then
                                         UpdateAC("A")
                                         SYS.A點衝擊()
                                     Else
                                         UpdateAC("C")
                                         SYS.C點衝擊()
                                         count += 1
                                     End If

                                     isA = Not isA
                                     'stw.Stop()
                                     Debug.Print(averr)
                                     loopWait = doOne - Now.Subtract(startDo).TotalMilliseconds - averr
                                     If loopWait > 0 Then
                                         stw.Restart()
                                         'Task.Delay(loopWait).Wait()
                                         'Task.Delay(loopWait)
                                         Do While stw.Elapsed.Milliseconds <= loopWait
                                             Application.DoEvents()
                                         Loop
                                         'For i = 1 To loopWait Step 5
                                         '    Task.Delay(5).Wait()
                                         'Next
                                         'Task.Delay(loopWait Mod 5).Wait()
                                         stw.Stop()
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
                             'timer.Dispose()
                             Await Task.Delay(0)
                         End Function).ContinueWith(Sub()

                                                        SubstractTaskCount(methodName)
                                                        PostProcess()

                                                        If exitMsg <> "" Then
                                                            StopTasks(exitMsg)
                                                        End If
                                                    End Sub)


    End Sub

    Private Sub DoWorker()
        Static isAorC As Boolean = False
        'Static stw As New Stopwatch
        'Dim wts As Integer
        If DATA0.主缸力值 >= minTons Then
            If isAorC Then
                If SYS.開始記錄 Then
                    DataLog(DATA1.LogString(count + 1, DATA1.主缸力值, 0))
                End If
                SYS.A點衝擊()
                UpdateAC("A")
            Else
                If SYS.開始記錄 Then
                    DataLog(DATA1.LogString(count + 1, 0, DATA1.主缸力值))
                End If
                SYS.C點衝擊()
                UpdateAC("C")
                count += 1 ' 做完 C 點算一次
            End If
            isAorC = Not isAorC
            'stw.Restart()
            'If SYS.開始記錄 Then
            '    DataLog(DATA1.LogString(count + 1, DATA1.主缸力值, 0))
            'End If
            'SYS.A點衝擊()
            'UpdateAC("A")
            'wts = interval - stw.Elapsed.Milliseconds
            'If wts > 0 Then
            '    Task.Delay(wts).Wait()
            'End If
            '    If SYS.開始記錄 Then
            '        DataLog(DATA1.LogString(count + 1, 0, DATA1.主缸力值))
            '    End If
            'SYS.C點衝擊()
            'UpdateAC("C")
            'stw.Stop()
        End If
    End Sub


    Private Sub PreProcess()
        SYS.開始衝擊 = True
    End Sub


    Private Sub PostProcess()
        SYS.開始衝擊 = False
    End Sub





End Module
