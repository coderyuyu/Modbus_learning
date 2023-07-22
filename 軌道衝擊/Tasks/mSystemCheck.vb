Module mSystemCheck

    Sub StartSystemCheck(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name
        Dim loopWait As Integer
        Dim exitMsg As String = ""
        Dim T = Task.Run(Async Function()
                             Dim stw As New Stopwatch
                             AddTaskCount(methodName) 'StartSystemCheck
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
                                                        SubstractTaskCount(methodName)
                                                        PostProcess()
                                                        If exitMsg <> "" Then
                                                            StopTasks(exitMsg)
                                                        End If
                                                    End Sub)

    End Sub

    Private Sub DoWorker()
        If SYS.緊急按鈕狀態 Then
            '
            Throw New Exception("StopTasks:緊急按鈕已按下")
        ElseIf SYS.主缸力值 > FSET.容許最高承載力值 Then
            Throw New Exception("StopTasks:主缸力值 > 容許最高承載力值")
        ElseIf SYS.開始衝擊 AndAlso SYS.主缸力值 < FSET.容許最低承載力值 Then
            Throw New Exception("StopTasks:開始衝擊 但 > 主缸力值 < 容許最低承載力值")
        End If
    End Sub


    Private Sub PreProcess()

    End Sub


    Private Sub PostProcess()

    End Sub


End Module
