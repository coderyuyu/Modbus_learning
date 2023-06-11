Imports System.Windows.Forms
Imports System.Xml
Public Class DialogSettings
    Dim xml As XmlDocument

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' 存檔
        SaveSetting()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        ' 放棄不存
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadSetting()
        Catch ex As Exception
            MsgBox(MSG.LOAD_SETTING_FAIL)
        End Try
    End Sub


    Sub SaveSetting()
        SETTINGS.FanOpenDegree = openDegree.Text
        SETTINGS.FanCloseDegree = closeDegree.Text
        SETTINGS.WarningDegree = WarningDegree.Text
        SETTINGS.Fan1On = Fan1On.Checked
        SETTINGS.Fan2On = Fan2On.Checked
        SETTINGS.SaveSettingsToFile()
    End Sub

    Sub LoadSetting()
        SETTINGS.LoadSettingsFromFile()
        openDegree.Text = SETTINGS.FanOpenDegree
        closeDegree.Text = SETTINGS.FanCloseDegree
        WarningDegree.Text = SETTINGS.WarningDegree
        Fan1On.Checked = SETTINGS.Fan1On
        Fan2On.Checked = SETTINGS.Fan2On
    End Sub

End Class
