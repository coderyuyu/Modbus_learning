Public Class FormConsole

    Sub WriteLog(log As String, Optional color As Color = Nothing)
        If color = Nothing Then
            color = ContrastColor(FConsole1.BackColor)
        End If
        FConsole1.WriteLine(log, color)
    End Sub

    Private Sub FConsole1_TextChanged(sender As Object, e As EventArgs) Handles FConsole1.TextChanged

    End Sub

    ''' <summary>
    ''' https://stackoverflow.com/questions/1855884/determine-font-color-based-on-background-color
    ''' </summary>
    ''' <param name="color"></param>
    ''' <returns></returns>
    Function ContrastColor(color As Color) As Color

        Dim d As Integer
        ' Counting the perceptive luminance - human eye favors green color...      
        Dim luminance As Double = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255

        If (luminance > 0.5) Then
            d = 0 'bright colors - black font
        Else
            d = 255 ' dark colors - white font
        End If
        Return Color.FromArgb(d, d, d)
    End Function
End Class