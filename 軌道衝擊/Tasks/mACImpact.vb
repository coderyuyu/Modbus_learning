Module mACImpact

    Sub StartACImpact(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name
        Dim loopWait As Integer
        Dim exitMsg As String = ""
        Dim T = Task.Run(Async Function()
                             Dim stw As New Stopwatch
                             AddTaskCount()
                             PreProcess()
                             Do
                                 Try
                                     stw.Restart()
                                     DoWorker()
                                     stw.Stop()
                                     loopWait = interval - stw.Elapsed.Milliseconds
                                     If loopWait > 0 Then
                                         'Task.Delay(loopWait).Wait()
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
                                                        PostProcess()
                                                        ConsoleLog($"{methodName} end")
                                                        If exitMsg <> "" Then
                                                            StopTasks(exitMsg)
                                                        End If
                                                    End Sub)

    End Sub

    Private Sub DoWorker()
        Static isAorC As Boolean = False
        If DATA0.主缸力值 >= minTons Then
            If isAorC Then
                SYS.A點衝擊()
                UpdateAC("A")
            Else
                SYS.C點衝擊()
                UpdateAC("C")
                count += 1 ' 做完 C 點算一次
            End If

            isAorC = Not isAorC
        End If
    End Sub


    Private Sub PreProcess()
        SYS.開始衝擊 = True
    End Sub


    Private Sub PostProcess()
        SYS.開始衝擊 = False
    End Sub





End Module
