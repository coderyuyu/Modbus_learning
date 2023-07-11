Imports System.Xml
Imports System.IO

Public Class FormSettings

    Dim settings As XmlDocument
    ''' <summary>
    ''' 在form上建立的control, 若依下列命名原則, 可自動存成 config.xml
    ''' name 以 para 為命名起始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Me.paraACFQ.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraCycles.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraDis100.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraEn100.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraInitFQ.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraMinTons.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraRecordFQ.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraTargetTons.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.paraAccumulate.KeyPress, AddressOf TextboxKeypressCheck
        LoadSettings()
    End Sub

    ''' <summary>
    ''' 預設 config.xml 位置
    ''' </summary>
    ''' <returns></returns>
    Private Function SettingsPath()
        Return Path.Combine(Application.StartupPath, "settings.xml")
    End Function

    Private Sub LoadSettings()
        LoadSettingsXML()

        For Each ctrl As Control In Me.Controls
            If ctrl.Name.StartsWith("para") Then
                Debug.Print(ctrl.Name)
                If settings.GetElementsByTagName(ctrl.Name).Count <> 0 Then

                    Select Case TypeName(ctrl)
                        Case "TextBox"
                            ctrl.Text = GetParaValue(ctrl.Name)
                            'Case "CheckBox"
                            'Case "RadioBox"
                            'Case "ListBox"
                        Case Else
                    End Select
                End If
            End If
        Next
        settings.Save(SettingsPath)
    End Sub

    Private Sub SaveConfig()
        LoadSettingsXML()
        For Each ctrl As Control In Me.Controls
            If ctrl.Name.StartsWith("para") Then
                SetParaValue(ctrl.Name, ctrl.Text)
            End If
        Next
        settings.Save(SettingsPath)
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

    ''' <summary>
    ''' 取得xml element值
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Private Function GetParaValue(name As String)
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
    Private Sub TextboxKeypressCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then

            ElseIf e.KeyChar = "-" Then
                If textbox.Text.StartsWith("-") Then
                    textbox.Text = textbox.Text.Substring(1, textbox.TextLength - 1)
                Else
                    textbox.Text = "-" & textbox.Text
                End If
                e.Handled = True
            ElseIf e.KeyChar = "." Then
                If DirectCast(sender, TextBox).Text.Contains(".") Then
                    e.Handled = True
                    Beep()
                End If
            Else
                Beep()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.SaveConfig()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    '=======================================
    '以下function方使程式取得系統參數
    '使用方法 FSET.參數名稱
    Function 預定循環次數() '預定循環次數
        Return GetParaValue("paraCycles")
    End Function
    Function 電磁閥不送電時間分配() '
        Return GetParaValue("paraDis100")
    End Function
    Function 電磁閥送電時間分配() '
        Return GetParaValue("paraEn100")
    End Function
    Function 測試點應變頻率() '
        Return GetParaValue("paraACFQ")
    End Function
    Function 容許最低承載力值() '
        Return GetParaValue("paraMinTons")
    End Function
    Function 開始紀錄前重置頻率() '
        Return GetParaValue("paraRecordFQ")
    End Function
    Function 變頻器初始頻率() '
        Return GetParaValue("paraInitFQ")
    End Function
    Function 力值設定() '
        Return GetParaValue("paraTargetTons")
    End Function
    Function 累計次數() '
        Return GetParaValue("paraAccumulate")
    End Function

    Sub 更新累計次數(value)
        paraAccumulate.Text = value
        Me.SaveConfig()
    End Sub

    Private Function GetParaValue(name)
        LoadSettingsXML()
        Return GetParaValue(name)
        'System.Reflection.MethodInfo.GetCurrentMethod().Name
    End Function



End Class