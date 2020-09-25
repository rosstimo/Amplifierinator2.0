Public Class CommonEmitter
    Implements ICommonEmitter, IBJTAmplifier, IUviversalBias
    'Inherits Amplifier

    'Properties
    Public Property VCC As Integer 'Implements IBJTAmplifier.VCC
    'Private _zin As Decimal
    'Public Overrides Property zin() As Decimal
    '    Get
    '        Return _zin
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _zin = value
    '    End Set
    'End Property

    'fields

    Sub New()
        'Me.zin = Me.setZin()

    End Sub


    Private Function zin() As Decimal 'Implements IBJTAmplifier.zin
        'Inherits Amplifier
        Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1)
    End Function

    Public Overloads Function vin() As Decimal
        Return Me.IE * (Me.rPrimeE + Me.rSwamp)
    End Function

    Public Overloads Function RthCBypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    End Function

End Class