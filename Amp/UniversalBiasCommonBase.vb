Public Class UniversalBiasCommonBase
    'Inherits UniversalBiased
    Inherits Amplifier

    'Properties


    Public Shadows Function Zin() As Decimal
        Return CDec(((Me.RE - Me.rSwamp) ^ -1 + (Me.rPrimeE + Me.rSwamp) ^ -1) ^ -1)
    End Function

    Public Overloads Function RthCBypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rgen ^ -1)) ^ -1 + (Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1
    End Function

    Public Function FcBypass() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.RthCBypass, Me.cBypass)
    End Function

    Public Function LowestCBypass() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCBypass, 57.0#)
    End Function

    Public Overloads Function FcLow() As Decimal
        Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.FcBypass ^ 2))
    End Function

End Class