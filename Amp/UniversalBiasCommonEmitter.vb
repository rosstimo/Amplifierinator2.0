Public Class UniversalBiasCommonEmitter
    'Inherits Amplifier
    'Implements ICommonEmitter

    'Private _VCC As Integer
    'Public Property VCC As Integer
    '    Get
    '        Return _VCC
    '    End Get
    '    Set(ByVal value As Integer)
    '        _VCC = value
    '    End Set
    'End Property

    'Private _R1 As Integer
    'Public Property R1 As Integer
    '    Get
    '        Return _R1
    '    End Get
    '    Set(ByVal value As Integer)
    '        _R1 = value
    '    End Set
    'End Property

    'Private _R2 As Integer
    'Public Property R2 As Integer
    '    Get
    '        Return _R2
    '    End Get
    '    Set(ByVal value As Integer)
    '        _R2 = value
    '    End Set
    'End Property

    'Private _RC As Integer
    'Public Property RC As Integer
    '    Get
    '        Return _RC
    '    End Get
    '    Set(ByVal value As Integer)
    '        _RC = value
    '    End Set
    'End Property

    'Private _RE As Integer
    'Public Property RE As Integer
    '    Get
    '        Return _RE
    '    End Get
    '    Set(ByVal value As Integer)
    '        _RE = value
    '    End Set
    'End Property

    'Private _beta As Integer
    'Public Property beta As Integer
    '    Get
    '        Return _beta
    '    End Get
    '    Set(ByVal value As Integer)
    '        _beta = value
    '    End Set
    'End Property


    Private _rLoadAC As Decimal
    Public Property rLoadAC() As Decimal
        Get
            Return rLoadACCE()
        End Get
        Set(ByVal value As Decimal)
            _rLoadAC = value
        End Set
    End Property

    'Private _zout As Decimal
    'Public Property zout() As Decimal
    '    Get
    '        Return ZoutCE()
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _zout = value
    '    End Set
    'End Property
    'Private _zin As Decimal
    'Public Property zin() As Decimal
    '    Get
    '        Return Me.zinCE '_zin
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _zin = value
    '    End Set
    'End Property
    'Private _vin As Decimal
    'Public Property vin() As Decimal
    '    Get
    '        Return vinCE()
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _vin = value
    '    End Set
    'End Property
    'Private _vout As Decimal
    'Public Property vout() As Decimal
    '    Get
    '        Return voutCE()
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _vout = value
    '    End Set
    'End Property

    Public Property RL As Integer

    Public Universalbias As New UniversalBiased
    ' 

    Sub New(Optional ByVal VCC% = 30%,
            Optional ByVal R1% = 120000%,
            Optional ByVal R2% = 18000%,
            Optional ByVal RC% = 3300%,
            Optional ByVal RE% = 830%,
            Optional ByVal beta% = 200%,
            Optional ByVal rSwamp% = 150%,
            Optional ByVal RL% = 3300%,
            Optional ByVal rgen% = 50%,
            Optional ByVal cIn# = 1 * 10 ^ -6,
            Optional ByVal cOut# = 1 * 10 ^ -6,
            Optional ByVal cBypass# = 1 * 10 ^ -6
            )
        Me.Universalbias.VCC = VCC
        Me.Universalbias.R1 = R1
        Me.Universalbias.R2 = R2
        Me.Universalbias.RC = RC
        Me.Universalbias.RE = RE
        Me.Universalbias.beta = beta




        Console.WriteLine("CE")
        'Me.universalbias.beta = 
    End Sub

    Public Function rLoadACCE() As Decimal
        Return CDec((Me.Universalbias.RC ^ -1 + Me.RL ^ -1) ^ -1)
    End Function

    'Private Function zinCE() As Decimal
    '    Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1)
    'End Function

    'Public Function ZoutCE() As Decimal
    '    Return Me.RC
    'End Function

    'Public Function voutCE() As Decimal 'max TODO rename?? deltaIB ??
    '    Return CDec(Me.Universalbias.IC * Me.rLoadAC)
    'End Function

    'Public Function vinCE() As Decimal
    '    Return Me.Universalbias.IE * (Me.rPrimeE + Me.rSwamp)
    'End Function

    'Public Function rthcbypass() As Double
    '    Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    'End Function

    'Public Function fcbypass() As Decimal
    '    Return LibElectronicsMath.CriticalFrequency(Me.rthcbypass, Me.cBypass)
    'End Function

    'Public numberOfCapacitors As Integer = 3I


    'Public Function lowestcbypass() As Double
    '    Return LibElectronicsMath.Capacitance(Me.rthcbypass, Me.fcLowTargetOffset(Me.numberOfCapacitors, Me.fcLowTargetDefault))
    'End Function

    'Public Function fclow() As Decimal
    '    Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.fcbypass ^ 2))
    'End Function

End Class