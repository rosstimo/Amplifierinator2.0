Public Class Amplifier
    'Inherits UniversalBiased
    'Implements IBJTAmplifier
    'Components
    'Public Overrides Property R1 As Integer

    'Private _rgen As Decimal
    'Public Property rgen() As Decimal
    '    Get
    '        Return _rgen
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _rgen = value
    '    End Set
    'End Property
    'Private _RL As Decimal
    'Public Property RL() As Decimal
    '    Get
    '        Return _RL
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _RL = value
    '    End Set
    'End Property
    'Private _rSwamp As Decimal
    'Public Property rSwamp() As Decimal
    '    Get
    '        Return _rSwamp
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _rSwamp = value
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
    'Private _zin As Decimal
    'Public Property zin() As Decimal
    '    Get
    '        Return _zin
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _zin = value
    '    End Set
    'End Property
    'Private _zout As Decimal
    'Public Property zout() As Decimal
    '    Get
    '        Return _zout
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _zout = value
    '    End Set
    'End Property
    'Private _vin As Decimal
    'Public Property vin() As Decimal
    '    Get
    '        Return _vin
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _vin = value
    '    End Set
    'End Property
    ''Private _vout As Decimal
    ''Public Property vout() As Decimal
    ''    Get
    ''        Return _vout
    ''    End Get
    ''    Set(ByVal value As Decimal)
    ''        _vout = value
    ''    End Set
    ''End Property
    'Private _cIn As Decimal
    'Public Property cIn() As Decimal
    '    Get
    '        Return _cIn
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _cIn = value
    '    End Set
    'End Property
    'Private _cOut As Decimal
    'Public Property cOut() As Decimal
    '    Get
    '        Return _cOut
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _cOut = value
    '    End Set
    'End Property
    'Private _cBypass As Decimal
    'Public Property cBypass() As Decimal
    '    Get
    '        Return _cBypass
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _cBypass = value
    '    End Set
    'End Property

    'Private _FcLowTarget As Decimal

    ' Public UniversalBias = New UniversalBiased With {.R1 = Me.R1, .R2 = Me.R2, .RC = Me.RC, .RE = Me.RE, .beta = Me.beta, .VCC = Me.VCC}

    'Public Universalbias As New UniversalBiased
    Public CommonEmitter As New UniversalBiasCommonEmitter

    Sub New(Optional ByVal VCC% = 24%,
            Optional ByVal R1% = 120000%,
            Optional ByVal R2% = 22000%,
            Optional ByVal RB% = 3300%,
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
        'Me.CommonEmitter.Universalbias.VCC = VCC
        'Me.CommonEmitter.Universalbias.R1 = R1
        'Me.CommonEmitter.Universalbias.R2 = R2
        'Me.CommonEmitter.Universalbias.RB = RB
        'Me.CommonEmitter.Universalbias.RC = RC
        'Me.CommonEmitter.Universalbias.RE = RE
        'Me.CommonEmitter.Universalbias.beta = beta


        'Me.CommonEmitter.rSwamp = rSwamp
        'Me.CommonEmitter.RL = RL
        'Me.CommonEmitter.rgen = rgen
        'Me.CommonEmitter.cIn = cIn
        'Me.CommonEmitter.cOut = cOut
        'Me.CommonEmitter.cBypass = cBypass

        Console.WriteLine("Amp")

    End Sub

    'All BJT amplifier
    'Public Function rPrimeE() As Decimal 'CE, CB, CC
    '    Return 0.026D / Me.Universalbias.IE
    'End Function
    'Public Function vceCutOffAC() As Decimal 'CE, CB, CC
    '    Return Me.CommonEmitter.vout + Me.Universalbias.VCE
    'End Function
    'Public Function Av() As Decimal
    '    Return Me.CommonEmitter.vout / Me.vin 'CE, CB, CC
    'End Function
    'Public Function Ai() As Decimal 'CE, CB, CC
    '    Return Me.Av * (Me.zin() / Me.RL)
    'End Function
    'Public Function Ap() As Decimal 'CE, CB, CC
    '    Return Me.Av * Me.Ai
    'End Function
    'Public Function AvdB() As Decimal 'CE, CB, CC
    '    Return CDec(20 * Math.Log10(Me.Av))
    'End Function
    'Public Function AidB() As Decimal 'CE, CB, CC
    '    Return CDec(20 * Math.Log10(Me.Ai))
    'End Function
    'Public Function ApdB() As Decimal 'CE, CB, CC
    '    Return CDec(10 * Math.Log10(Me.Ap))
    'End Function

    ''Any Bias
    ''CE, CB Only
    'Public Function rEBypass() As Decimal 'CE, CB
    '    Return CDec(Me.Universalbias.RE - Me.rSwamp)
    'End Function

    ''CE , CB Override by CC
    ''Public  Function Zout() As Decimal
    ''    Return Me.RC
    ''End Function

    'Public Function icSatAC() As Decimal 'CE, CB
    '    Return Me.Universalbias.IC + (Me.Universalbias.VCE / Me.rLoadAC)
    'End Function




    ''Frequency Response
    'Public Function RthCIn() As Double 'CE, CB, CC
    '    Return (Me.rgen ^ -1 + Me.zin ^ -1) ^ -1
    'End Function
    'Public Function RthCOut() As Double 'CE, CB, CC
    '    Return Me.zout + Me.RL
    'End Function

    'Public Function Fcin() As Decimal
    '    Return LibElectronicsMath.CriticalFrequency(Me.RthCIn, Me.cIn)
    'End Function
    'Public Function FcOut() As Decimal
    '    Return LibElectronicsMath.CriticalFrequency(Me.RthCOut, Me.cOut)
    'End Function

    'Public fcLowTargetDefault As Decimal = 100D
    'Public numberOfCapacitors As Integer = 2I

    'Public Function fcLowTargetOffset(ByVal numberOfCapacitors As Integer, ByVal fcLowTarget As Decimal) As Double
    '    Return (fcLowTarget / numberOfCapacitors) * Math.Sqrt(numberOfCapacitors)
    'End Function

    'Public Function LowestCIn() As Double
    '    Return LibElectronicsMath.Capacitance(Me.RthCIn, fcLowTargetOffset(numberOfCapacitors, fcLowTargetDefault))
    'End Function
    'Public Function LowestCOut() As Double
    '    Return LibElectronicsMath.Capacitance(Me.RthCOut, fcLowTargetOffset(numberOfCapacitors, fcLowTargetDefault))
    'End Function

    'Public Function FcLow() As Decimal 'CE, CB, CC
    '    Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2))
    'End Function

    'Public Function RthCBypass() As Double 'Universal CE Only
    '    Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    'End Function

    'Public Function FcBypass() As Decimal
    '    Return LibElectronicsMath.CriticalFrequency(Me.RthCBypass, Me.cBypass)
    'End Function

    'Public Function LowestCBypass() As Double
    '    Return LibElectronicsMath.Capacitance(Me.RthCBypass, 57.0#)
    'End Function



End Class