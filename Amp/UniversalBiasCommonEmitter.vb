Public Class UniversalBiasCommonEmitter


    'Private _beta As Integer
    'Public Property beta As Integer
    '    Get
    '        Return _beta
    '    End Get
    '    Set(ByVal value As Integer)
    '        _beta = value
    '    End Set
    'End Property


    'Private _rLoadAC As Decimal
    'Public Property rLoadAC() As Decimal
    '    Get
    '        Return _rLoadAC
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _rLoadAC = value
    '    End Set
    'End Property

    'Private _rPrimeE As Decimal
    'Public Property rPrimeE() As Decimal
    '    Get
    '        Return _rPrimeE
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _rPrimeE = value
    '    End Set
    'End Property

    Private _rSwamp As Decimal
    Public Property rSwamp() As Decimal
        Get
            Return _rSwamp
        End Get
        Set(ByVal value As Decimal)
            _rSwamp = value
        End Set
    End Property

    Private _RL As Decimal
    Public Property RL() As Decimal
        Get
            Return _RL
        End Get
        Set(ByVal value As Decimal)
            _RL = value
        End Set
    End Property

    Private _rgen As Decimal
    Public Property rgen() As Decimal
        Get
            Return _rgen
        End Get
        Set(ByVal value As Decimal)
            _rgen = value
        End Set
    End Property

    Private _cIn As Decimal
    Public Property cIn() As Decimal
        Get
            Return _cIn
        End Get
        Set(ByVal value As Decimal)
            _cIn = value
        End Set
    End Property

    Private _cOut As Decimal
    Public Property cOut() As Decimal
        Get
            Return _cOut
        End Get
        Set(ByVal value As Decimal)
            _cOut = value
        End Set
    End Property

    Private _cBypass As Decimal
    Public Property cBypass() As Decimal
        Get
            Return _cBypass
        End Get
        Set(ByVal value As Decimal)
            _cBypass = value
        End Set
    End Property

    Public Universalbias As New UniversalBiased
    'Public Selfbias As New SelfBiased

    Sub New(Optional ByVal VCC% = 30%,
            Optional ByVal R1% = 120000%,
            Optional ByVal R2% = 18000%,
            Optional ByVal RB% = 0%,
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

        'Me.Universalbias.VCC = VCC
        'Me.Universalbias.R1 = R1
        'Me.Universalbias.R2 = R2
        'Me.Universalbias.RB = RB
        'Me.Universalbias.RC = RC
        'Me.Universalbias.RE = RE
        'Me.Universalbias.beta = beta


        Me.rSwamp = rSwamp
        Me.RL = RL
        Me.rgen = rgen
        Me.cIn = cIn
        Me.cOut = cOut
        Me.cBypass = cBypass



        Console.WriteLine("CE")
        'Me.universalbias.beta = 
    End Sub

    Public Function rLoadAC() As Decimal
        Return CDec((Me.Universalbias.RC ^ -1 + Me.RL ^ -1) ^ -1)
    End Function

    Public Function zin() As Decimal
        Return CDec((Me.Universalbias.R1 ^ -1 + Me.Universalbias.R2 ^ -1 + ((Me.Universalbias.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1)
    End Function

    Public Function Zout() As Decimal
        Return Me.Universalbias.RC
    End Function

    Public Function rPrimeE() As Decimal
        Return 0.026D / Me.Universalbias.IE
    End Function

    Public Function vin() As Decimal
        Return Me.Universalbias.IE * (Me.rPrimeE + Me.rSwamp)
    End Function

    Public Function vout() As Decimal
        Return CDec(Me.Universalbias.IC * Me.rLoadAC)
    End Function

    Public Function vceCutOffAC() As Decimal
        Return Me.vout + Me.Universalbias.VCE
    End Function

    Public Function Av() As Decimal
        Return Me.vout / Me.vin 'CE, CB, CC
    End Function
    Public Function Ai() As Decimal 'CE, CB, CC
        Return Me.Av * (Me.zin() / Me.RL)
    End Function
    Public Function Ap() As Decimal 'CE, CB, CC
        Return Me.Av * Me.Ai
    End Function
    Public Function AvdB() As Decimal 'CE, CB, CC
        Return CDec(20 * Math.Log10(Me.Av))
    End Function
    Public Function AidB() As Decimal 'CE, CB, CC
        Return CDec(20 * Math.Log10(Me.Ai))
    End Function
    Public Function ApdB() As Decimal 'CE, CB, CC
        Return CDec(10 * Math.Log10(Me.Ap))
    End Function

    'Any Bias
    'CE, CB Only
    Public Function rEBypass() As Decimal 'CE, CB
        Return CDec(Me.Universalbias.RE - Me.rSwamp)
    End Function

    Public Function icSatAC() As Decimal 'CE, CB
        Return Me.Universalbias.IC + (Me.Universalbias.VCE / Me.rLoadAC)
    End Function

    'Frequency Response
    Public Function RthCIn() As Double 'CE, CB, CC
        Return (Me.rgen ^ -1 + Me.zin ^ -1) ^ -1
    End Function

    Public Function RthCOut() As Double 'CE, CB, CC
        Return Me.Zout + Me.RL
    End Function

    Public Function Fcin() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.RthCIn, Me.cIn)
    End Function

    Public Function FcOut() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.RthCOut, Me.cOut)
    End Function

    Public fcLowTargetDefault As Decimal = 100D


    Public Function fcLowTargetOffset(ByVal numberOfCapacitors As Integer, ByVal fcLowTarget As Decimal) As Double
        Return (fcLowTarget / numberOfCapacitors) * Math.Sqrt(numberOfCapacitors)
    End Function

    Public Function LowestCIn() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCIn, fcLowTargetOffset(numberOfCapacitors, fcLowTargetDefault))
    End Function

    Public Function LowestCOut() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCOut, fcLowTargetOffset(numberOfCapacitors, fcLowTargetDefault))
    End Function

    Public Function rthcbypass() As Double
        Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.Universalbias.R1 ^ -1 + Me.Universalbias.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.Universalbias.beta + 1))) ^ -1) ^ -1
    End Function

    Public Function fcbypass() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.rthcbypass, Me.cBypass)
    End Function

    Public numberOfCapacitors As Integer = 3I

    Public Function lowestcbypass() As Double
        Return LibElectronicsMath.Capacitance(Me.rthcbypass, Me.fcLowTargetOffset(Me.numberOfCapacitors, Me.fcLowTargetDefault))
    End Function

    Public Function fclow() As Decimal
        Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.fcbypass ^ 2))
    End Function

End Class