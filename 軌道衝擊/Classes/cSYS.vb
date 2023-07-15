Imports System.IO.Ports
Imports OfficeOpenXml.ExcelErrorValue
' COM3----------------------------------
'DO指令傳送與接收
'全關指令(DO) ： "#0F00" & "00" & Chr$(13)
'A點衝擊(DO) ： "#0F00" & "02" & Chr$(13)
'C點衝擊(DO) ： "#0F00" & "04" & Chr$(13)
'DO送出後回應， 正常為!(dataOutput) 00(cr) 異常為?0F(cr)
'DO回應：(cr)可判斷資料結束字元，”?”可判斷傳送失敗

' COM4----------------------------------
'變頻器， 主要指令都是寫入
'   位址：4
'   變頻器開關寫入之參數位置高位元&H20、低位元&H00， 寫入值2(ON)、1(OFF)。
'   頻率設定寫入之參數位置高位元&H20、低位元&H01
'   需求頻率乘100換算為長整數， 再轉16位元字串， 再拆高位元與低位元， 或許高位元根本用不著；EasyModbus可能不需這麼麻煩。
'主缸力值表頭一個， 主要指令都是讀取
'   位址：1
'   讀取之參數位置低位元&H26， 連續讀兩個位置， 再換算物理量
'Adam4052  DI指令： "$0F6" & Chr$(13)
'   DI送出後回應， 正常為： !(dataInput) 00(cr) 異常為：? 0F(cr)
'   DI回應：(cr)可判斷資料結束字元，”?”可判斷傳送失敗
'   dataInput為16位元字串資料， 需自行轉換2位元， 藉以判斷每一個DI是0或1。
Public Class cSYS
    Dim emuState As Integer = 1 '1=Normal 2=Emulate

    'Property COMS As Dictionary(Of String, cCOM)
    'Property TAGS As Dictionary(Of String, Array)
    Property CH1 As cCOM
    Property CH2 As cCOM
    Property ev As Decimal ' 變頻器增減值 (模擬用)

    Property 開始記錄 As Boolean = False
    Property 異常持續上限 As Integer = 10 * 1000 ' 10 秒



    'Dim emulateTimer As System.Threading.Timer
    '''
    Sub New()
        CH1 = New cCOM("COM3")
        CH2 = New cCOM("COM4")
    End Sub

    Sub SetEmulate(onoff As Boolean)
        If onoff = True Then
            emuState = 2
        Else
            emuState = 1
        End If
    End Sub

    ''' <summary>
    ''' 連線檢查 
    ''' </summary>
    Sub 連線檢查()
        ' 程式啟動前的檢查, 可以更精細一些
        CH1.ConnectPort()
        CH2.ConnectPort()
        CH1.DisConnect()
        CH2.DisConnect()
    End Sub


    ' 無濇用虛擬com port模擬writestring, 因此模擬時一律回 true


    Function 全關指令(Optional CMD As String = "#0F0000", Optional ByRef responseString As String = Nothing)
        If isEmulate() Then Return True
        responseString = CH1.WriteString(CMD)
        Return responseString.Contains(vbCr)
    End Function

    Function A點衝擊(Optional CMD As String = "#0F0002", Optional ByRef responseString As String = Nothing)
        If isEmulate() Then Return True
        responseString = CH1.WriteString(CMD)
        Return responseString.Contains(vbCr)
    End Function

    Function C點衝擊(Optional CMD As String = "#0F0004", Optional ByRef responseString As String = Nothing)
        If isEmulate() Then Return True
        responseString = CH1.WriteString(CMD)
        Return responseString.Contains(vbCr)
    End Function
    Function 緊急按鈕狀態(Optional CMD As String = "$0F6", Optional ByRef responseString As String = Nothing)
        If isEmulate() Then Return False ' 模擬狀態下一律回 false
        responseString = CH1.WriteString(CMD)
        Dim v As String = ""
        Dim ar() As Char = responseString.ToCharArray()
        Dim result As Boolean
        For Each ch As Char In ar
            If Char.IsDigit(ch) Then
                v &= ch
            End If
        Next
        ' 如果 v <> 0 表示緊急按鈕 按下
        result = Not CInt(v) = 0
        Return result
    End Function

    Sub 開啟變頻器()
        Dim values As Integer() = {2}
        CH2.WriteTag(slaveid:=4, registerAddress:=&H2000, values:=values)
    End Sub

    Sub 關閉變頻器()
        Dim values As Integer() = {1}
        CH2.WriteTag(slaveid:=4, registerAddress:=&H2000, values:=values)
    End Sub

    Function 變頻器狀態()
        Dim v = CH2.ReadTag(slaveid:=4, registerAddress:=&H2000, 1)
        Select Case v(0)
            Case 2
                Return "ON"
            Case 1
                Return "OFF"
            Case Else
                Return "?"
        End Select

    End Function

    Sub 設定變頻器頻率(value As Decimal)
        Dim values As Integer() = {value * 100}
        CH2.WriteTag(slaveid:=4, registerAddress:=&H2001, values:=values)
    End Sub

    Function 變頻器頻率()
        Dim v As Integer = CH2.ReadTag(slaveid:=4, registerAddress:=&H2001, 1)(0)
        Return v / 100

    End Function

    Function 手動電磁閥測試(CMD As String, Optional ByRef responseString As String = Nothing)
        If isEmulate() Then Return True
        responseString = CH2.WriteString(CMD)
        Return responseString.Contains(vbCr)
    End Function

    Function 電磁閥測試指令碼(a1 As Boolean, a2 As Boolean, c1 As Boolean, c2 As Boolean)
        Dim RoBit(7) As Byte
        Dim I As Integer, SSS As String
        Dim OutputVal As Integer
        If a1 Then 'A點
            RoBit(3) = 1
        Else
            RoBit(3) = 0
        End If
        If c1 Then 'C點
            RoBit(4) = 1
        Else
            RoBit(4) = 0
        End If
        If a2 Then 'A動
            RoBit(1) = 1
        Else
            RoBit(1) = 0
        End If
        If c2 Then 'C動
            RoBit(2) = 1
        Else
            RoBit(2) = 0
        End If
        OutputVal = 0
        For I = 0 To 7
            OutputVal += RoBit(I) * 2 ^ I
        Next I
        SSS = Hex(OutputVal)
        If Len(SSS) < 2 Then SSS = "0" & SSS
        Return SSS
    End Function

    Function 主缸力值() As Decimal
        Static values2 As Integer = Nothing
        Dim values = CH2.ReadTag(1, &H26, 2) ' 整數
        If values(0) < 0 Then
            values(0) = 0 - values(0)
        End If
        If values2 = Nothing Then
            values2 = 讀取小數位()
        End If
        Dim value = values(0) * 16 ^ 2 + values(1)
        Dim result As Decimal = CDec(value / 10 ^ values2)
        Return result
    End Function





    'Private Function RelayOutput() As String
    '    Dim I As Integer, SSS As String
    '    Dim OutputVal As Byte
    '    OutputVal = 0
    '    For I = 0 To 7
    '        OutputVal = OutputVal + RoBit(I) * 2 ^ I
    '    Next I
    '    SSS = Hex(OutputVal)
    '    If Len(SSS) < 2 Then SSS = "0" & SSS
    '    RelayOutput = SSS
    'End Function



    ' ex. 20.8
    ' 小數位2位
    ' 
    Sub 寫入主缸力值(value As Decimal) ' 模擬用
        ' 小數位
        Static values2 As Integer = 0
        If values2 = Nothing Then
            values2 = 讀取小數位()
        End If
        value = value * 10 ^ values2
        '=Convert.ToString(254, 16)  
        '轉成 16進位
        Dim hx As String = CInt(value).ToString("X4")
        Debug.Print(hx)


        Dim v1 As Integer
        Dim v2 As Integer
        v1 = Convert.ToInt32(hx.Substring(0, 2), 16)
        v2 = Convert.ToInt32(hx.Substring(2, 2), 16)

        Debug.Print($"write {v1} {v2}")
        CH2.WriteTag(1, &H26, {v1, v2})
        'Dim result As Decimal = CDec((values(0) * 255 + values(1)) / 10 ^ values2)
        '現在使用EasyModbus直接回傳十進位的值。


    End Sub

    ''' <summary>集中停機所需步驟</summary>
    Sub 停機()
        Try
            SYS.設定變頻器頻率(0)
        Catch ex As Exception
            ConsoleLog(ex.ToString)
        End Try
        ' call {讀取 error code,hex,ERR_CODE}
        Try
            SYS.關閉變頻器()
        Catch ex As Exception
            ConsoleLog(ex.ToString)
        End Try
        Try
            SYS.全關指令()
        Catch ex As Exception
            ConsoleLog(ex.ToString)
        End Try
    End Sub

    Sub 設定小數位(d As Integer)
        Dim values = {d} ' 整數
        CH2.WriteTag(1, &H3, values)
    End Sub

    Function 讀取小數位() As Integer
        Return CH2.ReadTag(1, &H3, 1)(0)
    End Function
    Function isEmulate() As Boolean
        Return emuState = 2
    End Function

End Class
