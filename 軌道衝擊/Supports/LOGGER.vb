Imports System.IO

Public Class LOGGER
    Shared locker As New Object
    Shared logHeader As New Dictionary(Of String, String)
    Public Shared UseDateSubFolder As Boolean = False
    Shared Sub AddLogHeader(logtype As String, header As String)
        logtype = logtype.ToLower
        If Not logHeader.ContainsKey(logtype) Then
            logHeader.Add(logtype, header)
        Else
            logHeader(logtype) = header
        End If
    End Sub

    Shared Sub WriteLog(logtype As String, text As String, Optional isAddDateTime As Boolean = False)
        Dim logs As New List(Of String)
        logs.Add(text)
        WriteLog(logtype.ToLower, logs, isAddDateTime)
    End Sub

    Shared Sub WriteLog(logtype As String, logs As List(Of String), Optional isAddDateTime As Boolean = False)
        Dim logFileName As String = PrepareLogFile(logtype.ToLower)
        SyncLock locker
            DoWriteLog(logs, logFileName, isAddDateTime)
        End SyncLock
    End Sub

    Private Shared Function PrepareLogFile(logtype As String) As String
        'Dim logPath As String = Path.Combine(Application.StartupPath, "logs") ' LOG預設存檔位置在程式下logs子目錄
        Dim logFileName As String = Path.Combine(LogPath, $"{logtype}_{Format(Now, "yyyy-MM-dd")}.log")
        If Not Directory.Exists(LogPath) Then
            Directory.CreateDirectory(LogPath)
        End If
        If Not File.Exists(logFileName) Then
            Using sw = File.CreateText(logFileName)
                If logHeader.ContainsKey(logtype) Then
                    sw.WriteLine(logHeader(logtype))
                End If
            End Using
        End If
        Return logFileName
    End Function
    Shared Function LogRoot() As String
        Return Path.Combine(Application.StartupPath, "logs")
    End Function
    Shared Function LogPath() As String
        If UseDateSubFolder Then
            Return Path.Combine(LogRoot(), Format(Now, "yyyyMMdd"))
        Else
            Return LogRoot()
        End If
    End Function
    Private Shared Sub DoWriteLog(list As List(Of String), logfileName As String, isAddDateTime As Boolean)
        Using sw As New StreamWriter(File.Open(logfileName, FileMode.Append))
            For Each line In list
                If isAddDateTime Then
                    sw.WriteLine($"{Format(Now, "yyyy-MM-dd HH:mm:ss")},{line}")
                Else
                    sw.WriteLine($"{line}")
                End If
            Next
        End Using
    End Sub
End Class

