Public Class UniversalBiasCommonEmitter
    Inherits Amplifier
    'Implements ICommonEmitter

    Private _VCC As Integer
    Public Shadows Property VCC As Integer
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


    Private _rLoadAC As Decimal
    Public Shadows Property rLoadAC() As Decimal
        Get
            Return rLoadACCE()
        End Get
        Set(ByVal value As Decimal)
            _rLoadAC = value
        End Set
    End Property

    Private _zout As Decimal
    Public Overrides Property zout() As Decimal
        Get
            Return ZoutCE()
        End Get
        Set(ByVal value As Decimal)
            _zout = value
        End Set
    End Property
    Private _zin As Decimal
    Public Overrides Property zin() As Decimal
        Get
            Return Me.zinCE '_zin
        End Get
        Set(ByVal value As Decimal)
            _zin = value
        End Set
    End Property
    Private _vin As Decimal
    Public Overrides Property vin() As Decimal
        Get
            Return vinCE()
        End Get
        Set(ByVal value As Decimal)
            _vin = value
        End Set
    End Property
    Private _vout As Decimal
    Public Overrides Property vout() As Decimal
        Get
            Return voutCE()
        End Get
        Set(ByVal value As Decimal)
            _vout = value
        End Set
    End Property

    Sub New()
        Console.WriteLine("CE")
    End Sub

    Public Shadows Function rLoadACCE() As Decimal
        Return CDec((Me.RC ^ -1 + Me.RL ^ -1) ^ -1)
    End Function

    Private Function zinCE() As Decimal
        Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1)
    End Function

    Public Function ZoutCE() As Decimal
        Return Me.RC
    End Function

    Public Function voutCE() As Decimal 'max TODO rename?? deltaIB ??
        Return CDec(Me.IC * Me.rLoadAC)
    End Function

    Public Function vinCE() As Decimal
        Return Me.IE * (Me.rPrimeE + Me.rSwamp)
    End Function

    Public Function rthcbypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    End Function

    Public Function fcbypass() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.rthcbypass, Me.cBypass)
    End Function

    Public Shadows numberOfCapacitors As Integer = 3I
    Public Function lowestcbypass() As Double
        Return LibElectronicsMath.Capacitance(Me.rthcbypass, Me.fcLowTargetOffset(Me.numberOfCapacitors, Me.fcLowTargetDefault))
    End Function

    Public Overrides Function fclow() As Decimal
        Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.fcbypass ^ 2))
    End Function

End Class