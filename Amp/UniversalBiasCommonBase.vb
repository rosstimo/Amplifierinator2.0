Public Class UniversalBiasCommonBase
    'Inherits UniversalBiased
    Inherits Amplifier

    'Properties

    Private _VCC As Integer
    Public Overrides Property VCC As Integer
        Get
            Return _VCC
        End Get
        Set(ByVal value As Integer)
            _VCC = value
        End Set
    End Property

    Private _R1 As Integer
    Public Overrides Property R1 As Integer
        Get
            Return _R1
        End Get
        Set(ByVal value As Integer)
            _R1 = value
        End Set
    End Property

    Private _R2 As Integer
    Public Overrides Property R2 As Integer
        Get
            Return _R2
        End Get
        Set(ByVal value As Integer)
            _R2 = value
        End Set
    End Property

    Private _RC As Integer
    Public Overrides Property RC As Integer
        Get
            Return _RC
        End Get
        Set(ByVal value As Integer)
            _RC = value
        End Set
    End Property

    Private _RE As Integer
    Public Overrides Property RE As Integer
        Get
            Return _RE
        End Get
        Set(ByVal value As Integer)
            _RE = value
        End Set
    End Property

    Private _beta As Integer
    Public Overrides Property beta As Integer
        Get
            Return _beta
        End Get
        Set(ByVal value As Integer)
            _beta = value
        End Set
    End Property

    Private _IsNPN As Boolean
    Public Property isNPN As Boolean
        Get
            Return _IsNPN
        End Get
        Set(ByVal value As Boolean)
            _IsNPN = value
        End Set
    End Property


    'Private _zin As Decimal
    'Public Overrides Property zin() As Decimal
    '    Get
    '        Return Me.zince '_zin
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _zin = value
    '    End Set
    'End Property

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