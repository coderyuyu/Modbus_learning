Imports System.IO
Imports System.Text
Imports System.Xml
Imports OfficeOpenXml
'Imports XLS = Microsoft.Office.Interop.Excel
'Imports Newtonsoft.Json
'Imports Newtonsoft.Json.Linq
'''' <summary>
''' 通用的log檔案瀏覽器

Public Class FormFileBrowser
    Private Enum ItemType
        Drive
        Folder
        File
        Root
    End Enum

    'Private With Events mi As MenuItem() = New MenuItem() {New MenuItem("全選清單"), New MenuItem("全選謄本")}
    Private cmenu As ContextMenu

    Private Sub frmFileBrowser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim init_Path = Path.Combine(Application.StartupPath, "logs") ', ROOTPATH, APPPATH)
        Me.top_path.Text = init_Path
        'Path.GetDirectoryName(init_Path)
        Dim node As TreeNode = file_tree_view.Nodes.Add(Mid(init_Path, InStrRev(init_Path, "\") + 1))
        node.Tag = ItemType.Root
        'If Directory.GetDirectories(init_Path, "*", SearchOption.TopDirectoryOnly).Length > 0 Then
        node.Nodes.Add("FILLER")
        cmenu = New ContextMenu
        With cmenu
            Dim item As MenuItem
            'For Each m In {"全選清單", "全選謄本", "謄本檢索補登", "匯出Excel檔"}
            For Each m In {"匯出Excel檔", "重新解析"}
                item = New MenuItem
                item.Text = m
                .MenuItems.Add(m, AddressOf cmenu_item_click)
            Next
        End With
        file_list.ContextMenu = cmenu
    End Sub

    Private Sub list_files(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles file_tree_view.NodeMouseClick
        'Dim fi As FileInfo
        Dim currentNode As TreeNode = e.Node
        Dim fullPathString As String
        If currentNode.Tag = ItemType.Root Then
            fullPathString = Path.Combine(logRootPath)
        Else
            fullPathString = Path.Combine(System.IO.Directory.GetParent(logRootPath).ToString, currentNode.FullPath)
        End If

        do_list_files(fullPathString)
    End Sub

    Sub do_list_files(path As String)
        Dim fi As FileInfo
        file_list.Items.Clear()
        For Each fileString As String In Directory.GetFiles(path)
            fi = New FileInfo(fileString)
            If fi.Extension.ToLower = ".log" Then
                file_list.Items.Add(fi.Name)
            End If

        Next
    End Sub

    'Sub radio_click() Handles rbAll.Click, rbList.Click, rbTranscript.Click
    '    Dim currentNode As TreeNode
    '    currentNode = file_tree_view.SelectedNode
    '    Dim fullPathString As String = Path.GetTempPath & currentNode.FullPath
    '    do_list_files(fullPathString)
    'End Sub
    Private Sub file_view_tree_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles file_tree_view.BeforeExpand
        Dim currentNode As TreeNode = e.Node
        currentNode.Nodes.Clear()
        Try
            'Now go get all the files and folders
            Dim fullPathString As String
            If currentNode.Tag = ItemType.Root Then
                fullPathString = logRootPath
            Else
                fullPathString = Path.Combine(System.IO.Directory.GetParent(logRootPath).ToString, currentNode.FullPath)
            End If

            'Dim fi As FileInfo
            'Handle each folder
            For Each folderString As String In Directory.GetDirectories(fullPathString)
                'Dim list = GetFileList("*.pdf", fullPathString)
                'If list.Count > 0 Then
                Dim newNode As TreeNode = currentNode.Nodes.Add(Path.GetFileName(folderString))
                Dim x As String = Path.GetFileName("")
                newNode.Tag = ItemType.Folder
                If Directory.GetDirectories(folderString).Length > 0 Then
                    newNode.Nodes.Add("FILLER")
                End If
                'End If
            Next

        Catch ex As Exception

        End Try
    End Sub



    'Sub file_list_keydown(o As SendKeys, e As KeyEventArgs) 'Handles file_list.KeyDown
    '    Try
    '        If e.KeyCode = (Keys.A And e.Control) Then
    '            For Each item In file_list.Items
    '                item.selected = True
    '            Next
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub


    Private Sub file_list_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles file_list.MouseDown
        Dim match As Boolean = False

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            file_list.ContextMenu.Show(file_list, New Point(e.X, e.Y))
            'For Each item In file_list.ContextMenu.MenuItems
            '    If item.checked Then
            '        Debug.Print(TypeName(item))
            '    End If
            'Next
            'MsgBox(file_list.ContextMenu.ToString)
        End If

    End Sub

    Sub cmenu_item_click(sender As Object, e As EventArgs)
        'MsgBox(e.ToString)
        Dim file_selected As String
        Dim idx As Integer = file_list.SelectedIndex
        Dim todolist As New List(Of String)
        'Dim xapp = find_excel_app(iscreate:=True)
        'If xapp Is Nothing Then Exit Sub
        'Dim wb As XLS.Workbook = FindOpenedWorkBook(xapp, "土地標示部,建物標示部", isCreate:=True)
        Select Case sender.text
            Case "線圖"

            Case "匯出Excel檔"

                Dim files As New List(Of FileInfo)
                Dim fi As FileInfo
                Dim exportFilename As String
                For Each item In file_list.SelectedItems
                    'file_selected = Path.Combine(Me.top_path.Text, file_tree_view.SelectedNode.Text, item)
                    file_selected = Path.Combine(Me.top_path.Text, item)
                    fi = New FileInfo(file_selected)
                    files.Add(fi)
                Next
                ExcelPackage.LicenseContext = LicenseContext.Commercial
                Using EXP As New ExcelPackage
                    For Each fi In files
                        consoleLog("匯出 " & fi.Name)
                        With EXP
                            Dim ws As ExcelWorksheet = .Workbook.Worksheets.Add(fi.Name)
                            Dim lines = File.ReadAllLines(fi.FullName)
                            ' 參考 https://gist.github.com/MikeHook/1132183
                            Dim sheetdata As New List(Of Object())
                            For Each line In lines
                                Dim ar
                                If fi.Name.ToLower.Contains("data") Then
                                    ar = Split(line, ",")
                                Else
                                    ar = {line}
                                End If
                                sheetdata.Add(ar)
                            Next
                            ws.Cells(1, 1).LoadFromArrays(sheetdata)
                        End With
                    Next
                    exportFilename = Path.Combine(Path.GetTempPath, "export_" & Format(Now, "yyyyMMdd_hhmmss") & ".xlsx")
                    consoleLog("匯出至 " & exportFilename)
                End Using


        End Select

    End Sub


    Private Sub file_list_SelectedIndexChanged(sender As ListBox, e As EventArgs) Handles file_list.SelectedIndexChanged
        Dim item As String
        Dim filename As String
        Dim fi As FileInfo
        item = sender.Items(sender.SelectedIndex)
        If file_tree_view.SelectedNode.Tag = ItemType.Root Then
            filename = Path.Combine(Me.top_path.Text, item)
        Else
            filename = Path.Combine(Me.top_path.Text, file_tree_view.SelectedNode.Text, item)
        End If
        fi = New FileInfo(filename)
        If LCase(fi.Extension).Contains(".log") Then
            'RichTextBox1.LoadFile(filename)
            RichTextBox1.Text = File.ReadAllText(filename)
            ' .Navigate(Me.top_path.Text & "\" & file_tree_view.SelectedNode.Text & "\" & item)
        ElseIf LCase(fi.Extension).Contains(".json") Or LCase(fi.Extension).Contains(".err") Then


        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Function logRootPath()
        Return LOGGER.LogPath
    End Function

    Sub consoleLog(msg As String)
        FConsole1.WriteLine(msg)
    End Sub

    Private Sub TLP_Paint(sender As Object, e As PaintEventArgs) Handles TLP.Paint

    End Sub
End Class