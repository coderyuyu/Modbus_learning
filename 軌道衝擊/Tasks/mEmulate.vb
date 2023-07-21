Imports OfficeOpenXml.FormulaParsing.LexicalAnalysis

Module mEmulate
    ''' <summary>
    ''' 理想是這段程式可以照抄, 只需修改 DoWork, PreProcess, PostProcess
    ''' </summary>
    ''' <param name="interval">The interval.</param>
    Sub StartEmulate(interval As Integer)
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
        Dim v As Decimal
        SyncLock DATA0
            v = DATA0.主缸力值
        End SyncLock
        ' 因為離線, 主缸力值不會有變化
        ' 因此在此依 sys.ev 調整主缸力值, 寫出主缸力值
        If v = 0 Then Exit Sub ' 多工, 有時候 DATA0 會晚到
        Select Case SYS.ev
            Case > 0
                SYS.寫入主缸力值(v + 0.2)
            Case < 0
                SYS.寫入主缸力值(v - 0.2)
            Case Else

        End Select

    End Sub


    Private Sub PreProcess()

    End Sub

    Private Sub PostProcess()

    End Sub
End Module
