Module mEmu
    Async Function DoEmu() As Task
        Dim v As Decimal
        SyncLock DATA0
            v = DATA0.主缸力值
        End SyncLock
        ' 因為離線, 主缸力值不會有變化
        ' 因此在此依 sys.ev 調整主缸力值, 寫出主缸力值
        Select Case SYS.ev
            Case > 0
                SYS.寫入主缸力值(v + 0.2)
            Case < 0
                SYS.寫入主缸力值(v - 0.2)
            Case Else

        End Select
        Await Task.Delay(0)
    End Function
End Module
