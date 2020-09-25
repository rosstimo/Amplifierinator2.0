Public Class CommonBase
    'Inherits UniversalBiased
    Inherits Amplifier

    'Properties


    Public Shadows Function Zin() As Decimal 'CB
        Return CDec(((Me.RE - Me.rSwamp) ^ -1 + (Me.rPrimeE + Me.rSwamp) ^ -1) ^ -1)
    End Function

    Public Overloads Function RthCBypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rgen ^ -1)) ^ -1 + (Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1
    End Function



End Class