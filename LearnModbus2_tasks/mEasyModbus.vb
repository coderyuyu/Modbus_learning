Imports EasyModbus
Module mEasyModbus
    Function CreateChannel(com As String, baud As Integer) As ModbusClient
        Dim method As String = $"{System.Reflection.MethodBase.GetCurrentMethod().Name} {com}"
        Try
            Dim mc As New ModbusClient
            With mc
                .Baudrate = baud
                .SerialPort = com
                .Parity = IO.Ports.Parity.None '  2023-6-5
                .StopBits = IO.Ports.StopBits.One '  2023-6-5
                .Connect()
            End With
            Return mc
        Catch ex As Exception
            Throw New Exception($"Error {method} message:{ex.Message}")
        End Try
    End Function
End Module
