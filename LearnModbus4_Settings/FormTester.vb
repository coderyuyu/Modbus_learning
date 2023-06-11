Imports System.IO
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports ClassModbus

Public Class FormTester
    Dim SYS As cSystem
    Dim RND As New Random(Second(Now))
    Delegate Sub ConsoleLog_Invoker(msg As String, color As Color)
    Dim stw As New Stopwatch


    Private Sub FormTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadXML()
        AddHandler TV.NodeMouseClick, AddressOf TVNode_Click
        AddHandler SYS.SendMessage, AddressOf ConsoleLog
    End Sub
    'Reg1_1.Invoke(New UpdateRegs_Invoker(AddressOf UpdateRegs), slave1)
    Sub ConsoleLog(msg As String, Optional color As Color = Nothing)
        If color = Nothing Then
            color = FConsole1.BackColor
            color = Color.FromArgb(255 - color.R,
                                  255 - color.G,
                                  255 - color.B)

        End If
        If FConsole1.InvokeRequired Then
            FConsole1.Invoke(New ConsoleLog_Invoker(AddressOf ConsoleLog), msg, color)
        Else
            With FConsole1
                .WriteLine(msg)
                '.AppendText(msg & vbCrLf)
            End With
        End If
    End Sub

    Private Sub TVNode_Click(sender As Object, args As TreeNodeMouseClickEventArgs)
        Dim n As XmlNode = args.Node.Tag
        ConsoleLog(args.Node.Name & "--------------------------------")
        For Each attr As XmlAttribute In n.Attributes
            ConsoleLog($"{attr.Name}=""{attr.InnerText}""")
        Next
    End Sub


    Sub SetSystemObject(sys As cSystem)
        Me.SYS = sys
    End Sub
    Sub LoadXML()
        Dim xmldoc = Me.Tag
        Dim xRoot As XmlNode
        Dim tvNode As TreeNode
        xRoot = xmldoc.ChildNodes(1)
        TV.Nodes.Clear()
        tvNode = GetTreeNodeFromXnode(xRoot)
        TV.Nodes.Add(tvNode)
        AddNode(xRoot, tvNode)
    End Sub


    Private Sub AddNode(ByVal inXmlNode As XmlNode, ByVal inTreeNode As TreeNode)
        Dim xNode As XmlNode
        Dim tvNode As TreeNode
        Dim nodeList As XmlNodeList
        Dim i As Integer
        If inXmlNode.HasChildNodes Then
            nodeList = inXmlNode.ChildNodes
            For i = 0 To nodeList.Count - 1
                xNode = inXmlNode.ChildNodes(i)
                tvNode = GetTreeNodeFromXnode(xNode)
                inTreeNode.Nodes.Add(tvNode)
                AddNode(xNode, tvNode)
            Next
        Else
            tvNode = GetTreeNodeFromXnode(inXmlNode)
            'inTreeNode.Text = inXmlNode.Name & GetAttributes(inXmlNode)
            inTreeNode = tvNode
        End If
    End Sub

    Private Function GetTreeNodeFromXnode(xNode As XmlNode)
        Dim tvNode As New TreeNode
        With tvNode
            .Name = xNode.Name
            .Text = xNode.Name & GetAttributes(xNode)
            .Tag = xNode
        End With
        Return tvNode
    End Function

    Private Function GetAttributes(node As XmlNode)
        Dim txt As String = "("
        For Each att As XmlAttribute In node.Attributes
            txt = txt & $"{att.Name}={att.Value} "
        Next
        txt = txt.Trim() & ")"
        Return txt
    End Function

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        Try
            Select Case ButtonConnect.Text
                Case "Connect"
                    SYS.Start()
                    ButtonConnect.Text = "Disconnect"
                Case "Disconnect"
                    SYS.Stop()
                    ButtonConnect.Text = "Connect"
            End Select
        Catch ex As Exception
            ConsoleLog(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles ButtonWrite.Click
        Dim msg As String
        Dim v
        For Each c In SYS.ComPorts.Values
            For Each s In c.slaves.Values
                For Each t In s.readTags.Values
                    Try
                        stw.Restart()
                        v = RND.Next(0, 100)
                        SYS.WriteValue(c, s, t, RND.Next(0, 100))
                        msg = $"{c.port} Slave:{s.id} Addr:{t.address} values: {v} elsaped: {stw.Elapsed.TotalMilliseconds} ms"
                        FConsole1.WriteLine(msg)
                    Catch ex As Exception
                        msg = $"{c.port} Slave:{s.id} Addr:{t.address} error: {ex.Message}"
                        FConsole1.WriteLine(msg)
                    End Try
                Next
            Next
        Next
    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        Dim values As System.Int32()
        Dim msg As String
        'readvalues.Items.Clear()

        For Each c In SYS.ComPorts.Values
            For Each s In c.slaves.Values
                For Each t In s.readTags.Values
                    Try
                        values = SYS.ReadValue(c, s, t)
                        stw.Restart()
                        Dim v = values.Aggregate(Function(a, b) $"{a} {b}")
                        msg = $"{c.port} Slave:{s.id} Addr:{t.address} values: {v} elsaped: {stw.Elapsed.TotalMilliseconds} ms"
                        FConsole1.WriteLine(msg)
                    Catch ex As Exception
                        msg = $"{c.port} Slave:{s.id} Addr:{t.address} error: {ex.Message}"
                        FConsole1.WriteLine(msg)
                    End Try

                Next
            Next
        Next
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    For Each c In SYS.ComPorts
    '        c.WriteString("write " & RND.Next(0, 1000))
    '    Next
    'End Sub
End Class