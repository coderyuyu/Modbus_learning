Module mUpdateUI

    Sub StartUpdateUI(interval As Integer)
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
        Dim newTons As Decimal
        Dim newFeq As Decimal
        SyncLock DATA0
            With DATA2
                .主缸力值 = DATA0.主缸力值
            End With
        End SyncLock
        newTons = DATA2.主缸力值
        newFeq = SYS.最後更新變頻器頻率
        UpdateUI(FMAIN.CylinderTons, newTons)
        UpdateUI(FMAIN.feq, newFeq)
        If ChartData.Count > 300 Then
            ChartData.RemoveAt(0)
        End If
        ChartData.Add({newFeq, newTons})
        UpdateUI(FMAIN.Chart1, ChartData)
        If SYS.開始記錄 Then
            If count Mod 100 Then
                FSET.更新累計次數(count) ' 每100次存檔
            End If
            UpdateUI(FMAIN.counter, count)
        End If
    End Sub


    Private Sub PreProcess()

    End Sub


    Private Sub PostProcess()

    End Sub


End Module
