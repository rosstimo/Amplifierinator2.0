Public Class CommonEmitter
    Inherits Amplifier

    Public Shadows Property VCC As Integer
    Public Shadows Property R1 As Integer
    Public Shadows Property R2 As Integer
    Public Shadows Property RC As Integer
    Public Shadows Property RE As Integer
    Public Shadows Property beta As Integer


    'Properties

    Private _zin As Decimal
    Public Overrides Property zin() As Decimal
        Get
            Return _zin
        End Get
        Set(ByVal value As Decimal)
            _zin = value
        End Set
    End Property

    'fields

    Sub New()
        Me.zin = Me.setZin()

    End Sub


    Private Function setZin() As Decimal
        Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1)
    End Function

    Public Overloads Function vin() As Decimal
        Return Me.IE * (Me.rPrimeE + Me.rSwamp)
    End Function

    Public Overloads Function RthCBypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    End Function

End Class