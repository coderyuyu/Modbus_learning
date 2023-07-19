Module mACImpact
    Async Function doACImpact() As Task

        If DATA0.主缸力值 >= minTons Then
            If isAorC Then
                SYS.A點衝擊()
                UpdateAC("A")
            Else
                SYS.C點衝擊()
                UpdateAC("C")
                count += 1 ' 做完 C 點算一次
            End If

            isAorC = Not isAorC
        End If
        Await Task.Delay(0)
    End Function


End Module
