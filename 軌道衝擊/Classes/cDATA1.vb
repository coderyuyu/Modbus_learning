''' <summary>
''' 這個class需要在程式啟動之初實體化 (new)
''' 用於 TASK_PROCESS, 定時由 DATA0 複製過來
''' 依需求設計 events 
''' </summary>
Public Class cDATA1
    Dim var主缸力值
    Dim 容許誤差範圍
    Dim var變頻器頻率
    Public Event 變頻器頻率變更(original As Decimal, ev As Decimal)
    Property 主缸力值
        Set(value)
            If var主缸力值 <> value Then
                var主缸力值 = value
                If Math.Abs(FSET.力值設定 - var主缸力值) < 容許誤差範圍 Then
                    ' do nothing
                Else
                    Dim var變頻器頻率 As Decimal = SYS.變頻器頻率()
                    Dim ev As Decimal
                    If var主缸力值 > FSET.力值設定 Then
                        ev = -var變頻器頻率 * 0.01
                    ElseIf var主缸力值 < FSET.力值設定 Then
                        ev = var變頻器頻率 * 0.01
                    End If
                    'ConsoleLog($"設定變頻器頻率={v + v2}")

                    RaiseEvent 變頻器頻率變更(var變頻器頻率, ev)
                End If

            End If
        End Set
        Get
            Return var主缸力值
        End Get
    End Property

    Sub New()
        容許誤差範圍 = (FSET.力值設定 / 100) * 0.75
    End Sub

    ''' <summary>
    ''' 提供Data log 的header
    ''' </summary>
    ''' <returns></returns>
    Function LogHeaders()
        Return "時間,變頻器頻率,主缸力值"
    End Function

    Function LogString()
        Return {Format(Now, "HH:mm:ss"), var變頻器頻率, var主缸力值}.Aggregate(Function(a, b) $"{a},{b}")
    End Function


End Class
