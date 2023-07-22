Module mLog
    Sub StartLog(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name
        Dim loopWait As Integer
        Dim exitMsg As String = ""
        Dim T = Task.Run(Async Function()
                             Dim stw As New Stopwatch
                             AddTaskCount(methodName) 'StartLog
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
        Dim logobj As cLogObject
        Dim logdic As New Dictionary(Of String, List(Of String))
        SyncLock LogQ
            Do While LogQ.Count <> 0
                logobj = LogQ.Dequeue
                With logobj
                    If Not logdic.ContainsKey(.logtype) Then
                        logdic.Add(.logtype, New List(Of String))
                    End If
                    logdic(.logtype).Add(.ToStringWithShortTime())
                End With
            Loop
        End SyncLock
        For Each logtype In logdic.Keys
            LOGGER.WriteLog(logtype, logdic(logtype))
        Next
    End Sub


    Private Sub PreProcess()

    End Sub

    Private Sub PostProcess()

    End Sub
End Module
