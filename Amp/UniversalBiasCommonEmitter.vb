Public Class UniversalBiasCommonEmitter
    Inherits Amplifier
    'Implements IUviversalBias ' ICommonEmitter, IBJTAmplifier, 

    'Dim UniversalBiased As New UniversalBiased With {.R1 = Me.R1}
    Private _zin As Decimal
    Public Overrides Property zin() As Decimal
        Get
            Return _zin
        End Get
        Set(ByVal value As Decimal)
            _zin = value
        End Set
    End Property

    Sub New()
        Me.zin = zinCE()
        Console.WriteLine("CE")
        Console.WriteLine(Me.R1)
    End Sub

    Private Function zinCE() As Decimal
        Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1)
    End Function

    Public Overloads Function vin() As Decimal
        Return Me.IE * (Me.rPrimeE + Me.rSwamp)
    End Function

    Public Overloads Function RthCBypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    End Function

    Public Function FcBypass() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.RthCBypass, Me.cBypass)
    End Function

    Public Shadows numberOfCapacitors As Integer = 3I
    Public Function LowestCBypass() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCBypass, Me.fcLowTargetOffset(numberOfCapacitors, fcLowTargetDefault))
    End Function

    Public Overloads Function FcLow() As Decimal
        Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.FcBypass ^ 2))
    End Function

End Class