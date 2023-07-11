Imports MfgControl.AdvancedHMI.Controls

Public Class FormTest
    Private Sub FormTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Me.Feq.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.mTons.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.decpos.KeyPress, AddressOf TextboxKeypressCheck
        AddHandler Me.cbA1.CheckedChanged, AddressOf cbACCheck
        AddHandler Me.cbA2.CheckedChanged, AddressOf cbACCheck
        AddHandler Me.cbC1.CheckedChanged, AddressOf cbACCheck
        AddHandler Me.cbC2.CheckedChanged, AddressOf cbACCheck
        decpos.Text = SYS.讀取小數位
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            TestLog("全關指令")
            TestLog(SYS.全關指令)

        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            TestLog("A點衝擊")
            TestLog(SYS.A點衝擊)

        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            TestLog("C點衝擊")
            TestLog(SYS.C點衝擊)

        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub




    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            TestLog(SYS.主缸力值)
        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


    Sub TestLog(log As String)
        FConsole1.WriteLine(log)
        FConsole1.WriteLine("--------------------------------------")

    End Sub


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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            SYS.開啟變頻器()
            TestLog("開啟變頻器 OK")
        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            SYS.關閉變頻器()
            TestLog("變頻器關 OK")
        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            SYS.設定變頻器頻率(Feq.Text)
            TestLog($"設定變頻器頻率={Feq.Text}")
        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FConsole1.Clear()
    End Sub

    Function ConvertResp(s As String)
        Dim s2 As String = ""
        For i = 1 To s.Length
            s2 &= Hex(Asc(s.Substring(i - 1, 1))).ToString & " "
        Next
        s = s.Replace(vbCr, "Cr").Replace(vbLf, "Lf")
        Return s & " : " & s2
    End Function

    'Private Sub 初始化(sender As Object, e As EventArgs) Handles Button9.Click
    '    Try
    '        SYS.全關指令()
    '        SYS.設定變頻器頻率(0)
    '    Catch ex As Exception
    '        TestLog("初始化" & ex.ToString)
    '    End Try
    'End Sub

    'Private Sub 開啟油壓(sender As Object, e As EventArgs) Handles Button10.Click
    '    Try
    '        SYS.開啟變頻器()
    '        SYS.設定變頻器頻率(FSET.變頻器初始頻率)
    '    Catch ex As Exception
    '        TestLog("開啟油壓" & ex.ToString)
    '    End Try

    'End Sub

    'Private Sub 關閉油壓(sender As Object, e As EventArgs) Handles Button11.Click
    '    Try
    '        SYS.關閉變頻器()
    '        SYS.設定變頻器頻率(0)
    '    Catch ex As Exception
    '        TestLog("關閉油壓" & ex.ToString)
    '    End Try
    'End Sub

    Private Sub cbACCheck()
        lblcmd.Text = SYS.電磁閥測試指令碼(cbA1.Checked, cbA2.Checked, cbC1.Checked, cbC2.Checked)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            SYS.寫入主缸力值(mTons.Text)
            TestLog($"寫入主缸力值 {mTons.Text}")
        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            SYS.設定小數位(decpos.Text)
            TestLog($"設定小數位 {decpos.Text}")
        Catch ex As Exception
            TestLog(ex.ToString)
        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            cbACCheck() ' 重算一次
            Dim DOData As String = "#0F00" & lblcmd.Text
            TestLog("手動電磁閥測試")
            TestLog(SYS.手動電磁閥測試(DOData))

        Catch ex As Exception
            TestLog(ex.ToString)
        End Try

    End Sub
End Class