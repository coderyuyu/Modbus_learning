Imports System.Reflection
Imports System.Threading

Public Module mACImpact2
    Sub StartACImpact2(interval As Integer)
        Dim methodName As String = System.Reflection.MethodInfo.GetCurrentMethod().Name
        Dim th As Thread =
            New Thread(Sub()
                           DoWork(methodName, interval)
                       End Sub)
        th.IsBackground = True
        th.Start()
        ConsoleLog($"{methodName} thread start {th.IsThreadPoolThread}")

    End Sub




    Private Sub PreProcess()
        SYS.開始衝擊 = True
    End Sub


    Private Sub PostProcess()
        SYS.開始衝擊 = False
    End Sub
    Sub DoWork(methodName As String, interval As Integer)
        Dim doOne As Integer = interval / 2
        Debug.Print($"{methodName} async Thread id {Thread.CurrentThread.ManagedThreadId}")
        Dim stw As New Stopwatch
        Dim loopWait As Integer = 0
        Dim exitMsg As String = ""
        Dim startDo As Date = Now
        AddTaskCount(methodName) 'StartACImpact
        PreProcess()
        Dim err As Decimal
        Dim averr As Decimal = 0
        Dim isA As Boolean = True
        Do
            Try
                err = Now.Subtract(startDo).TotalMilliseconds - doOne
                If Math.Abs(err) < 5 Then
                    averr = (averr + err) / 2
                Else
                    Debug.Print("control " & err)
                End If
                startDo = Now
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
                'Debug.Print(averr)
                loopWait = doOne - Now.Subtract(startDo).TotalMilliseconds - averr
                If loopWait > 0 Then
                    stw.Restart()
                    Do While stw.Elapsed.Milliseconds <= loopWait
                        Application.DoEvents()
                    Loop
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
        SubstractTaskCount(methodName)
        PostProcess()

        If exitMsg <> "" Then
            StopTasks(exitMsg)
        End If
    End Sub

End Module
