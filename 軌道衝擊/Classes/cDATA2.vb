''' <summary>
''' 這個class需要在程式啟動之初實體化 (new)
''' 用於 TASK_PROCESS, 定時由 DATA0 複製過來
''' 依需求設計 events 
''' </summary>
Public Class cDATA2
    Dim var主缸力值
    Dim var變頻器頻率
    'Public Event 變頻器頻率變更(original As Decimal, ev As Decimal)
    Property 主缸力值
        Set(value)
            If var主缸力值 <> value Then
                var主缸力值 = value
                UpdateUI(FMAIN.CylinderTons, value)
            End If
        End Set
        Get
            Return var主缸力值
        End Get
    End Property

    Sub New()

    End Sub




End Class

