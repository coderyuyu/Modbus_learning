Imports OpenQA.Selenium

Public Class FormTester
    Public jobd As Queryable
    Public driver As IWebDriver

    Private Sub FormTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.sso.Items.Clear()

        Dim menu = driver.FindElement(By.Id("mbmcpebul_table"))
        If menu IsNot Nothing Then
            Dim ul = menu.FindElements(By.TagName("ul"))
            If ul IsNot Nothing Then
                Dim list = (From a In ul(1).FindElements(By.TagName("a"))
                            Where a.GetAttribute("onclick").Contains("全方位電傳")
                            Select getTextBetween(a.GetAttribute("onclick"), ",'", "'")).ToArray
                sso.Items.AddRange(list)
            End If
        End If

        'Dim li = (From a In driver.FindElements(By.TagName("a"))
        '          Where a.Text.EndsWith("全方位電傳")
        '          Select $"{a.Text}({a.GetAttribute("onclick")})").ToArray

        'Dim aa = driver.FindElements(By.TagName("li")).Where(Function(x) x.Text.Contains("全方位")).ToArray
        'Me.sso.Items.AddRange(li)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(GetCurrentCityId(driver))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ChangeCityByCityId(driver, sso.Text)
    End Sub
End Class