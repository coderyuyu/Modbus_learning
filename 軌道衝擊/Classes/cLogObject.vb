Public Class cLogObject
    ReadOnly Property logtype As String
    ReadOnly Property logtext As String
    ReadOnly Property logtime As DateTime
    Sub New(logtype As String, logtext As String, Optional logtime As DateTime = Nothing)
        Me.logtext = logtext
        Me.logtype = logtype
        If logtime = Nothing Then
            Me.logtime = Now
        Else
            Me.logtime = logtime
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Format(logtime, "yyyy-MM-dd HH:mm:ss")} {logtext}"
    End Function
    Public Function ToStringWithoutTime() As String
        Return $"{logtext}"
    End Function
    Public Function ToStringWithShortTime() As String
        Return $"{Format(logtime, "HH:mm:ss")} {logtext}"
    End Function

End Class
