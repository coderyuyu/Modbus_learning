Module mThisApp
    Public FMAIN As Form1
    Sub Main()
        FMAIN = New Form1
        Application.Run(FMAIN)
    End Sub
    Function ShowMsgBox(msg As String, Optional buttonTexts As String = "好", Optional timeoutms As Integer = 0, Optional defaultbutton As Integer = 0) As DialogResult
        Dim ar = Split(buttonTexts, ",")
        With DialogMsg
            .timeoutms = timeoutms
            .defaultbutton = defaultbutton
            .msg.Text = msg
            .ButtonPannel.Controls.Clear()
            If ar.Length = 1 Then
                .icon.Image = My.Resources.info
            Else
                .icon.Image = My.Resources.question
            End If
            For i = 1 To ar.Length
                Dim BTN As New Button
                BTN.Text = ar(i - 1) ' vb.net array 預設是 0 base
                BTN.Tag = i
                BTN.Name = "B" & i
                .ButtonPannel.Controls.Add(BTN)
                AddHandler BTN.Click, Sub(sender As Object, args As EventArgs)
                                          DialogMsg.DialogResult = sender.tag
                                          DialogMsg.Close()
                                      End Sub
            Next

            Return DialogMsg.ShowDialog()
        End With
    End Function


    Sub ConsoleLog(logtext)
        Console.WriteLine(logtext)
    End Sub


    Public Class MySettings
        Shared Function oDec()
            Return mSetting.GetParaValue("oDec")
        End Function
        Shared Function iDec()
            Return mSetting.GetParaValue("iDec")
        End Function
        Shared Function iSetpoint()
            Return mSetting.GetParaValue("iSetpoint")
        End Function
        Shared Function Kp()
            Return mSetting.GetParaValue("Kp")
        End Function
        Shared Function Ki()
            Return mSetting.GetParaValue("Ki")
        End Function
        Shared Function oInit()
            Return mSetting.GetParaValue("oInit")
        End Function
        Shared Function Kd()
            Return mSetting.GetParaValue("Kd")
        End Function
        Shared Function oMax()
            Return mSetting.GetParaValue("oMax")
        End Function
        Shared Function interval()
            Return mSetting.GetParaValue("interval")
        End Function
        Shared Function oMin()
            Return mSetting.GetParaValue("oMin")
        End Function
        Shared Function inputCom()
            Return mSetting.GetParaValue("inputCom")
        End Function
        Shared Function outputCom()
            Return mSetting.GetParaValue("outputCom")
        End Function
        Shared Function iSlave()
            Return mSetting.GetParaValue("iSlave")
        End Function
        Shared Function iAddress()
            Return mSetting.GetParaValue("iAddress")
        End Function
        Shared Function oLength()
            Return mSetting.GetParaValue("oLength")
        End Function
        Shared Function iLength()
            Return mSetting.GetParaValue("iLength")
        End Function
        Shared Function oAddress()
            Return mSetting.GetParaValue("oAddress")
        End Function
        Shared Function oSlave()
            Return mSetting.GetParaValue("oSlave")
        End Function
    End Class
End Module
