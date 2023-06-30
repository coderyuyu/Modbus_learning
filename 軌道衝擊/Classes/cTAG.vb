Public Class cTAG
    Property tagName As String
    Property slaveid As Integer
    Property registerAddress As Integer
    Property dataLength As Integer
    Public Sub New(tagName As String, slaveid As Integer, registerAddress As Integer, dataLength As Integer)
        Me.tagName = tagName
        Me.slaveid = slaveid
        Me.registerAddress = registerAddress
        Me.dataLength = dataLength
    End Sub
End Class
