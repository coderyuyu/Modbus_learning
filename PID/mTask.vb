Imports System.Net
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting

Module mTask
    Delegate Sub UpdateUI_Invoker(ctrl As Control, value As Object)
    Dim cs As CancellationTokenSource
    Dim ctoken As CancellationToken
    Dim taskCount As Integer = 0
    Dim CrossTaskLocker As New Object
    Sub StartTasks()
        cs = New CancellationTokenSource
        ctoken = cs.Token
        taskCount = 0
        TaskPIDTuning(0)
        If FMAIN.isEmulate.Checked Then
            TaskEmu(500)
        End If
    End Sub

    Sub StopTasks(Optional message As String = "")
        If cs IsNot Nothing Then
            cs.Cancel()


        End If
        Do While taskCount <> 0
            ShowMsgBox("Stopping..." & taskCount, "", 100, 1)
            Task.Delay(100).Wait()
        Loop
        PostCheck()

        If message <> "" Then
            ShowMsgBox(message, "Ok")
        End If
    End Sub
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

    Sub TaskPIDTuning(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
        Dim loopWait As Integer
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     AddTaskCount()
                     ConsoleLog($"{methodName} start")
                     Do
                         Try
                             stw.Restart()
                             ' work here
                             SyncLock CrossTaskLocker
                                 DoOnce()
                             End SyncLock

                             stw.Stop()
                             loopWait = interval - stw.Elapsed.Milliseconds
                             If loopWait > 0 Then Task.Delay(loopWait).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(Sub()
                                           SubstractTaskCount()
                                           ConsoleLog($"{methodName} end")
                                       End Sub)
    End Sub
    Sub TaskEmu(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
        Dim loopWait As Integer
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     AddTaskCount()
                     ConsoleLog($"{methodName} start")
                     Do
                         Try
                             stw.Restart()
                             ' work here
                             SyncLock CrossTaskLocker
                                 DoEmuOnce()
                             End SyncLock

                             stw.Stop()
                             loopWait = interval - stw.Elapsed.Milliseconds
                             If loopWait > 0 Then Task.Delay(loopWait).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(Sub()
                                           SubstractTaskCount()
                                           ConsoleLog($"{methodName} end")
                                       End Sub)
    End Sub

    Sub TaskSample(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name ' 取得這個 sub 或 function name
        Dim loopWait As Integer
        Task.Run(Sub()
                     Dim stw As New Stopwatch
                     AddTaskCount()
                     ConsoleLog($"{methodName} start")
                     Do
                         Try
                             stw.Restart()
                             ' work here
                             stw.Stop()
                             loopWait = interval - stw.Elapsed.Milliseconds
                             If loopWait > 0 Then Task.Delay(loopWait).Wait()
                         Catch ex As Exception
                             ConsoleLog(System.Reflection.MethodInfo.GetCurrentMethod().Name & ex.Message)
                             ConsoleLog(ex.ToString)
                         End Try
                     Loop While Not ctoken.IsCancellationRequested
                 End Sub).ContinueWith(Sub()
                                           SubstractTaskCount()
                                           ConsoleLog($"{methodName} end")
                                       End Sub)
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
