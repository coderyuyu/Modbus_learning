Module mProcessDATA1
    Async Function ProcessDATA1() As Task
        SyncLock DATA1
            SyncLock DATA0
                DATA1.主缸力值 = DATA0.主缸力值
            End SyncLock
        End SyncLock
        DataLog(DATA1.LogString)
        Await Task.Delay(0)
    End Function
End Module
