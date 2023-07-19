Module mSystemCheck
    Async Function doSystemCheck() As Task


        If SYS.緊急按鈕狀態 Then
            '
            Throw New Exception("StopTasks:緊急按鈕已按下")
        ElseIf SYS.主缸力值 > FSET.容許最高承載力值 Then
            Throw New Exception("StopTasks:主缸力值 > 容許最高承載力值")
        ElseIf SYS.開始衝擊 AndAlso SYS.主缸力值 < FSET.容許最低承載力值 Then
            Throw New Exception("StopTasks:開始衝擊 但 > 主缸力值 < 容許最低承載力值")
        End If
        Await Task.Delay(0)
    End Function
End Module
