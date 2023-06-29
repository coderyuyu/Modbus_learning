Imports System.Xml
Imports System.IO

Public Class FormSettings

    Dim config As XmlDocument
    ''' <summary>
    ''' 在form上建立的control, 若依下列命名原則, 可自動存成 config.xml
    ''' name 以 para 為命名起始
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler paraTargetTons.KeyPress, AddressOf TextboxKeypressCheck
        LoadConfig()
    End Sub

    ''' <summary>
    ''' 預設 config.xml 位置
    ''' </summary>
    ''' <returns></returns>
    Private Function ConfigPath()
        Return Path.Combine(Application.StartupPath, "Config.XML")
    End Function

    Private Sub LoadConfig()
        LoadConfigXML()

        For Each ctrl As Control In Me.Controls
            If ctrl.Name.StartsWith("para") Then
                Debug.Print(ctrl.Name)
                If config.GetElementsByTagName(ctrl.Name).Count <> 0 Then

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
        config.Save(ConfigPath)
    End Sub

    Private Sub SaveConfig()
        LoadConfigXML()
        For Each ctrl As Control In Me.Controls
            If ctrl.Name.StartsWith("para") Then
                SetParaValue(ctrl.Name, ctrl.Text)
            End If
        Next
        config.Save(ConfigPath)
    End Sub


    Private Sub LoadConfigXML()
        Dim root As XmlElement
        Try
            config = New XmlDocument
            config.Load(ConfigPath)
            If config.GetElementsByTagName("root").Count = 0 Then
                root = config.CreateElement("root")
                config.AppendChild(root)
            End If
        Catch ex As Exception
            ' 如果有錯, 則建立新的xml
            config = New XmlDocument
            root = config.CreateElement("root")
            config.AppendChild(root)
        End Try
    End Sub

    ''' <summary>
    ''' 取得xml element值
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Private Function GetParaValue(name As String)
        Dim e As XmlElement
        If config.GetElementsByTagName(name).Count <> 0 Then
            e = config.GetElementsByTagName(name)(0)
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
        root = config.GetElementsByTagName("root")(0)
        If config.GetElementsByTagName(name).Count <> 0 Then
            e = config.GetElementsByTagName(name)(0)
            e.InnerText = value
        Else
            e = config.CreateElement(name)
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
    '使用方法 formSettings.參數名稱
    Function Cycles()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function Dis100()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function En100()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function ACFQ()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function MaxTons()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function RecordFQ()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function InitFQ()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function
    Function TargetTons()
        Return GetParaValue("para" & System.Reflection.MethodInfo.GetCurrentMethod().Name)
    End Function

    Private Function GetParaValue(name)
        LoadConfigXML()
        Return GetParaValue(name)
    End Function
End Class