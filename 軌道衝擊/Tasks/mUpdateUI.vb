Module mUpdateUI
    Async Function UpdateUIDATA2() As Task
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
        Await Task.Delay(0)
    End Function
End Module
