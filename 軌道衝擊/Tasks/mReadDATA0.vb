Module mReadDATA0
    Async Function ReadDATA0() As Task
        SyncLock DATA0
            With DATA0
                .主缸力值 = SYS.主缸力值
            End With
        End SyncLock
        Await Task.Delay(0)
    End Function
End Module
