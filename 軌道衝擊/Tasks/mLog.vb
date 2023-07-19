Module mLog
    Async Function DoLogWriter() As Task
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
        Await Task.Delay(0)
    End Function
End Module
