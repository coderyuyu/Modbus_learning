Public Class cDIO
    Property DioName As String
    Property slaveid As Integer
    Property dataLength As Integer
    Public Sub New(DioName As String, slaveid As Integer, dataLength As Integer)
        Me.DioName = DioName
        Me.slaveid = slaveid
        Me.dataLength = dataLength
    End Sub

    Sub test()
        Dim abc As Integer = &HF012
    End Sub
End Class
