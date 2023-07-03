Imports System.IO.Ports
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
    Property COMS As Dictionary(Of String, cCOM)
    Property TAGS As Dictionary(Of String, Array)
    Property CH1 As cCOM
    Property CH2 As cCOM
    Sub New()
        CH1 = New cCOM("COM3")
        CH2 = New cCOM("COM4")
    End Sub


    Function 全關指令()
        Dim response = CH1.WriteString("#0F0000")
        Return response
    End Function

    Function A點衝擊()
        Dim response = CH1.WriteString("#0F0002")
        Return response
    End Function

    Function C點衝擊()
        Dim response = CH1.WriteString("#0F0004")
        Return response
    End Function

    Function Adam4052_DI()
        Dim response = CH1.WriteString("$0F6")
        Return response
    End Function

    Function 變頻器開()
        Dim values As Integer() = {2}
        Try
            CH2.WriteTag(slaveid:=4, registerAddress:=&H2000, values:=values)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function 變頻器關()
        Dim values As Integer() = {1}
        Try
            CH2.WriteTag(slaveid:=4, registerAddress:=&H2000, values:=values)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function 變頻器頻率(value As Integer)
        Dim values As Integer() = {value * 100}
        Try
            CH2.WriteTag(slaveid:=4, registerAddress:=&H2001, values:=values)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function 主缸力值() As Decimal
        Static values2 As Integer = Nothing
        Dim values = CH2.ReadTag(1, &H26, 2) ' 整數
        If values2 = Nothing Then
            values2 = CH2.ReadTag(1, &H3, 1)(0) ' 小數
        End If
        Dim result As Decimal = CDec((values(0) * 255 + values(1)) / 10 ^ values2)
        Return result
    End Function
    'Function 主缸力值小數點位置()
    '    Dim values = CH2.ReadTag(1, &H3, 1)
    '    Return values
    'End Function


End Class
