Imports System.IO
Imports System.Runtime
Imports System.Xml

Module mSetting
    Public settings As XmlDocument
    Dim parms As New Dictionary(Of String, String)
    Dim PanelParameter As Panel
    Sub SetParameterPanel(p As Panel)
        PanelParameter = p
    End Sub


    Sub SaveSettings()
        LoadSettingsXML()
        For Each ctrl As Control In PanelParameter.Controls
            SaveControls(ctrl)
            'If ctrl.Name.StartsWith("para") Then
            'Debug.Print($"{ctrl.Name} { ctrl.Text}")
            'Select Case TypeName(ctrl)
            '    Case "TextBox"
            '        'Debug.Print(ctrl.Name)
            '        SetParaValue(ctrl.Name, ctrl.Text)
            '        parms(ctrl.Name) = ctrl.Text
            '    Case "CheckBox"
            '            ' TODO:
            '    Case "RadioBox"
            '            ' TODO:
            '    Case "ComboBox"
            '        SetParaValue(ctrl.Name, ctrl.Text)
            '        parms(ctrl.Name) = ctrl.Text
            '    Case "NumericUpDown"
            '        SetParaValue(ctrl.Name, ctrl.Text)
            '        parms(ctrl.Name) = ctrl.Text
            '    Case Else
            'End Select

            'End If
        Next
        settings.Save(SettingsPath)
    End Sub

    Sub SaveControls(ctrl As Control)
        If ctrl.Controls.Count = 0 Then
            'Debug.Print($"{ctrl.Name} { ctrl.Text}")
            Select Case TypeName(ctrl)
                Case "TextBox"
                    'Debug.Print(ctrl.Name)
                    SetParaValue(ctrl.Name, ctrl.Text)
                    parms(ctrl.Name) = ctrl.Text
                Case "CheckBox"
                        ' TODO:
                Case "RadioBox"
                        ' TODO:
                Case "ComboBox"
                    SetParaValue(ctrl.Name, ctrl.Text)
                    parms(ctrl.Name) = ctrl.Text
                Case "NumericUpDown"
                    SetParaValue(ctrl.Name, ctrl.Text)
                    parms(ctrl.Name) = ctrl.Text
                Case Else
            End Select
        Else
            For Each childctrl In ctrl.Controls
                SaveControls(childctrl)
            Next
        End If
    End Sub


    Private Sub LoadSettingsXML()
        Dim root As XmlElement

        Try
            settings = New XmlDocument
            settings.Load(SettingsPath)
            If settings.GetElementsByTagName("root").Count = 0 Then
                root = settings.CreateElement("root")
                settings.AppendChild(root)
            End If
        Catch ex As Exception
            ' 如果有錯, 則建立新的xml
            settings = New XmlDocument
            root = settings.CreateElement("root")
            settings.AppendChild(root)
        End Try

    End Sub
    Sub LoadSettings()

        LoadSettingsXML()

        For Each ctrl As Control In PanelParameter.Controls
            'If ctrl.Name.StartsWith("para") Then
            'Debug.Print(ctrl.Name)
            LoadControls(ctrl)

        Next

        settings.Save(SettingsPath)
    End Sub

    Sub LoadControls(ctrl As Control)
        If ctrl.Controls.Count = 0 Then
            Select Case TypeName(ctrl)
                Case "TextBox"
                    ctrl.Text = GetParaValue(ctrl.Name)
                    parms(ctrl.Name) = ctrl.Text
                Case "CheckBox"
                            ' TODO:
                Case "RadioBox"
                            ' TODO:
                Case "ComboBox"
                    DirectCast(ctrl, ComboBox).Text = GetParaValue(ctrl.Name)
                    parms(ctrl.Name) = ctrl.Text
                Case "NumericUpDown"
                    DirectCast(ctrl, NumericUpDown).Text = GetParaValue(ctrl.Name)
                    parms(ctrl.Name) = ctrl.Text
                Case Else
            End Select
        Else
            For Each childctrl In ctrl.Controls
                LoadControls(childctrl)
            Next
        End If
    End Sub

    ''' <summary>
    ''' 取得xml element值
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Function GetParaValue(name As String)
        Dim e As XmlElement
        If settings Is Nothing Then
            LoadSettings()
        End If
        If settings.GetElementsByTagName(name).Count <> 0 Then
            e = settings.GetElementsByTagName(name)(0)
            Return e.InnerText
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' 寫 config xml 值
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="value"></param>
    Private Sub SetParaValue(name As String, value As String)
        Dim e As XmlElement
        Dim root As XmlElement
        root = settings.GetElementsByTagName("root")(0)
        If settings.GetElementsByTagName(name).Count <> 0 Then
            e = settings.GetElementsByTagName(name)(0)
            e.InnerText = value
        Else
            e = settings.CreateElement(name)
            e.InnerText = value
            root.AppendChild(e)
        End If

    End Sub
    ''' <summary>
    ''' 過澽 textbox 輸入只能是數字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub TextboxKeypressCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            ElseIf e.KeyChar = "&" Or e.KeyChar = "H" Or e.KeyChar = "h" Then
                If textbox.Text.StartsWith("-") Then
                    Beep()
                ElseIf Not textbox.Text.StartsWith("&H") Then
                    textbox.Text = "&H" & textbox.Text
                ElseIf textbox.Text.StartsWith("&H") Then
                    textbox.Text = textbox.Text.Substring(2)
                Else
                    Beep()
                End If
                'e.Handled = True
            ElseIf e.KeyChar = "-" Then
                If textbox.Text.StartsWith("-") Then
                    textbox.Text = textbox.Text.Substring(1, textbox.TextLength - 1)
                Else
                    textbox.Text = "-" & textbox.Text
                End If
                'e.Handled = True
            ElseIf e.KeyChar = "." Then
                If DirectCast(sender, TextBox).Text.Contains(".") Then
                    Beep()
                    e.Handled = True

                End If
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Function SettingsPath()
        DumpSetting()
        Return Path.Combine(Application.StartupPath, "settings.xml")
    End Function

    Sub DumpSetting()
        ConsoleLog("Public Class MySettings")
        '       Shared Function oDec()
        '    Return mSetting.GetParaValue(oDec)
        'End Function
        For Each key In parms.Keys
            ConsoleLog($"shared function {key}()")
            ConsoleLog($"Return mSetting.GetParaValue(""{key}"")")
            ConsoleLog($"end function")
        Next
        ConsoleLog("End Class")
    End Sub
End Module
