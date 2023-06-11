Imports System.Xml
Imports ClassModbus
Imports Opc.Hda

Public Class Form1
    Dim configXML As XmlDocument
    Dim xmlPath As String
    Dim SYS As cSystem
    Delegate Sub ConsoleLog_Invoker(msg As String, color As Color)
    Dim console As WindowsForms.Console.FConsole = FormConsole.FConsole1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xmlPath = Application.StartupPath & "\Config.xml"
        configXML = New XmlDocument
        configXML.Load(xmlPath)
        SYS = New cSystem()
        AddHandler SYS.SendMessage, AddressOf ConsoleLog
        SYS.LoadConfig(configXML)
        Me.Text = SYS.name
        'Dim kk As String = "abc"
        'Dim Result = System.Text.Encoding.ASCII.GetBytes(kk.ToCharArray())

    End Sub

    Private Sub ButtonSetting_Click(sender As Object, e As EventArgs) Handles ButtonSetting.Click
        Dim x As Integer = 20
        Dim y As Integer = 40
        Dim st As XmlElement = configXML.GetElementsByTagName("settings")(0)
        Dim widths = Split(st.GetAttribute("widths"), ",")
        Dim fsize = st.GetAttribute("font-size")
        Dim DGR As DialogResult
        Dim Plist As New Dictionary(Of String, XmlElement)
        Dim DG As New DialogSettings
        With DG.Controls
            For Each p As XmlElement In configXML.GetElementsByTagName("parameter")
                Dim labeldesc As New Label
                Dim labelunit As New Label
                Dim txb As New MaskedTextBox
                With labeldesc
                    .Text = p.GetAttribute("name")
                    .Top = y
                    .Left = x
                    .Width = widths(0)
                    .Font = New Font(.Font.Name, fsize, .Font.Style, .Font.Unit)
                End With
                With txb
                    .Name = p.GetAttribute("name")
                    .Top = y
                    .Left = labeldesc.Left + labeldesc.Width
                    .Text = p.GetAttribute("value")
                    .Width = widths(1)
                    .Font = New Font(.Font.Name, fsize, .Font.Style, .Font.Unit)
                    .Name = p.GetAttribute("id")
                    If p.GetAttribute("mask") <> "" Then
                        .Mask = p.GetAttribute("mask")
                    End If
                End With
                With labelunit
                    .Text = p.GetAttribute("unit")
                    .Top = y
                    .Left = txb.Left + txb.Width
                    .Width = widths(2)
                    .Font = New Font(.Font.Name, fsize, .Font.Style, .Font.Unit)
                End With
                .Add(labeldesc)
                .Add(txb)
                .Add(labelunit)
                Plist.Add(p.GetAttribute("id"), p)
                y += 40
            Next
        End With
        With DG
            .Text = "參數設定"
            .Size = New Size(DialogSettings.Width, y + 100)
            DGR = .ShowDialog()
        End With
        If DGR = DialogResult.OK Then
            For Each ctrl In DG.Controls
                If Plist.ContainsKey(ctrl.name) Then
                    Plist(ctrl.name).SetAttribute("value", ctrl.text)
                End If
            Next
        End If
        configXML.Save(xmlPath)
        'MsgBox(GetSettingValue("p03"))
        'MsgBox(GetSettingValue("p33"))
    End Sub

    Private Function GetSettingValue(id As String)
        Dim list As XmlNodeList = configXML.GetElementsByTagName("parameter")
        Dim e = (From ele In list Where ele.GetAttribute("id") = id Select ele)
        If e.Count = 0 Then
            Return "N/A"
        Else
            Return DirectCast(e(0), XmlElement).GetAttribute("value")
        End If
    End Function

    Private Sub ButtonTest_Click(sender As Object, e As EventArgs) Handles ButtonTest.Click
        'Dim FrmTest As New FormTester
        FormTester.Tag = configXML
        FormTester.SetSystemObject(SYS)
        FormTester.Show()
    End Sub

    Sub ConsoleLog(msg As String, Optional color As Color = Nothing)
        If color = Nothing Then
            color = console.BackColor
            color = Color.FromArgb(255 - color.R,
                                  255 - color.G,
                                  255 - color.B)

        End If
        If console.InvokeRequired Then
            console.Invoke(New ConsoleLog_Invoker(AddressOf ConsoleLog), msg, color)
        Else
            With console
                .WriteLine(msg, color)
                '.AppendText(msg & vbCrLf)
            End With
        End If
    End Sub

    Private Sub ButtonConsole_Click(sender As Object, e As EventArgs) Handles ButtonConsole.Click
        If FormConsole.Visible Then
            FormConsole.Visible = False
        Else
            FormConsole.Visible = True
        End If
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
