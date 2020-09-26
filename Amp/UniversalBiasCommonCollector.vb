Public Class UniversalBiasCommonCollector
    'Inherits UniversalBiased
    Inherits Amplifier

    'Properties
    Sub New()

    End Sub


    Public Overloads Function Zout() As Decimal 'CC
        Return CDec(((Me.RE - Me.rSwamp) ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.rgen ^ -1 + R1 ^ -1 + R2 ^ -1) ^ -1) / (Me.beta + 1))) ^ -1)
    End Function

    Public Shadows Function Zin() As Decimal 'CC
        Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp + ((Me.RE - Me.rSwamp) ^ -1 + Me.RL ^ -1) ^ -1) ^ -1)) ^ -1)
    End Function

    Public Overloads Function vin() As Decimal 'CC
        Return CDec(Me.IE * (Me.rPrimeE + Me.rSwamp + ((Me.RE - Me.rSwamp) ^ -1 + Me.RL ^ -1) ^ -1))
    End Function

    Public Overloads Function vout() As Decimal 'CC
        Return CDec(Me.IE * ((Me.RE - Me.rSwamp) ^ -1 + Me.RL ^ -1) ^ -1)
    End Function

    Public Overloads Function rLoadAC() As Decimal 'CC
        Return CDec((Me.RE ^ -1 + Me.RL ^ -1) ^ -1)
    End Function



End Class
