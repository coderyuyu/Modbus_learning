Imports System
Imports System.IO
' source from https://github.com/amgarnier/EasyPID

Public Class MyEasyPID
    Public Property Kp As Double
    Public Property Ki As Double
    Public Property Kd As Double
    Public Property Setpoint As Double
    Public ReadOnly Property OutputSpeed As Long
    Public ReadOnly Property MinOutput As Long
    Public ReadOnly Property MaxOutput As Long
    Private Property _errorResidual As Double = 0
    Private Property _errorValuedT As Double = 0

    Public Property ErrorResidual As Double
        Get
            Return ErrorResidual
        End Get
        Set(ByVal value As Double)
            _errorResidual = value
        End Set
    End Property

    Public Property dT As Double
    Public Property errorPrevious As Double
    Public Property Interval As Long

    Public Sub New(ByVal Optional Kp As Double = 0.0,
                   ByVal Optional Ki As Double = 0.0,
                   ByVal Optional Kd As Double = 0.0,
                   ByVal Optional Setpoint As Double = 0.0,
                   ByVal Optional OutputSpeed As Long = 1000,
                   ByVal Optional MinOutput As Long = -1,
                   ByVal Optional MaxOutput As Long = 1)
        Me.Kp = Kp
        Me.Ki = Ki
        Me.Kd = Kd
        Me.Setpoint = Setpoint
        Me.OutputSpeed = OutputSpeed
        Me.MinOutput = MinOutput
        Me.MaxOutput = MaxOutput
        Me.OutputSpeed = OutputSpeed
        Me.errorPrevious = 0
        Me.ErrorResidual = 0

        If OutputSpeed < 1 Then
            Throw New IOException("Interval is set too low please update to be above 1 ms")
        End If

        If MinOutput > MaxOutput Then
            Throw New IOException("Minimum output must be greater than maximum output")
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ProcessVariable"></param>
    ''' <param name="currentTime">用Now.Ticks</param>
    ''' <returns></returns>
    Public Function GetControlSignal(ByVal ProcessVariable As Double, ByVal currentTime As Long) As Double
        ' Now.Ticks 的單位為一千萬分之一秒
        ' OutputSpeed 為 千分之一秒
        Dim intervalTicks As Long = Me.OutputSpeed * 10000 ' 轉換成 Ticks
        ' -----------------------------
        If DateTime.Now.Ticks > (currentTime + intervalTicks) Then
            ' 如果 OutputSpeed = 1000, 表示間隔為1秒
            Throw New IOException("Interval is set too low please increase to a value that is slower then the output of your signal")
        End If

        Dim [error] = Me.Setpoint - ProcessVariable ' 誤差值
        '誤差（error）和殘差（residual）
        Me.ErrorResidual += ([error] * Me.OutputSpeed / 1000)

        If Me.ErrorResidual > Me.MaxOutput Then
            Me.ErrorResidual = Me.MaxOutput
        End If

        Dim derivative = ([error] - Me.errorPrevious) / Me.OutputSpeed / 1000

        If Double.IsNaN(derivative) Then
            derivative = 0
        End If

        While DateTime.Now.Ticks < (currentTime + intervalTicks)
        End While

        Dim controlVariable = (Me.Kp * [error]) + (Me.Ki * Me.ErrorResidual) + (Kd * derivative)

        If controlVariable <= Me.MinOutput Then
            controlVariable = Me.MinOutput
        End If

        If controlVariable >= Me.MaxOutput Then
            controlVariable = Me.MaxOutput
        End If

        Me.errorPrevious = [error]
        Return controlVariable
    End Function
End Class
