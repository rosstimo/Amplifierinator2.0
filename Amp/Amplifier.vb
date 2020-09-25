Public Class Amplifier
    'Inherits UniversalBiased
    Implements IBJTAmplifier
    'Components
    Public Property VCC As Integer Implements IBJTAmplifier.VCC
    Public Property R1 As Integer Implements IBJTAmplifier.R1
    Public Property R2 As Integer Implements IBJTAmplifier.R2
    Public Property RC As Integer Implements IBJTAmplifier.RC
    Public Property RE As Integer Implements IBJTAmplifier.RE
    Public Property beta As Integer Implements IBJTAmplifier.beta

    Private _rgen As Decimal
    Public Property rgen() As Decimal Implements IBJTAmplifier.rgen
        Get
            Return _rgen
        End Get
        Set(ByVal value As Decimal)
            _rgen = value
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
    Private _rSwamp As Decimal ' CE, CB
    Public Property rSwamp() As Decimal
        Get
            Return _rSwamp
        End Get
        Set(ByVal value As Decimal)
            _rSwamp = value
        End Set
    End Property
    Private _zin As Decimal
    Public Overridable Property zin() As Decimal
        Get
            Return _zin
        End Get
        Set(ByVal value As Decimal)
            _zin = value
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

    Private _FcLowTarget As Decimal

'All BJT amplifier
    Public Function rPrimeE() As Decimal 'CE, CB, CC
        Return 0.026D / Me.IE
    End Function
    Public Function vceCutOffAC() As Decimal 'CE, CB, CC
        Return Me.vout + Me.VCE
    End Function
    Public Function Av() As Decimal
        Return Me.vout / Me.vin 'CE, CB, CC
    End Function
    Public Function Ai() As Decimal 'CE, CB, CC
        Return Me.Av * (Me.Zin() / Me.RL)
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

    'CE, CB Only
    Public Function rEBypass() As Decimal'CE, CB
        Return CDec(Me.RE - Me.rSwamp)
    End Function

    'CE , CB Override by CC
    Public Function Zout() As Decimal
        Return Me.RC
    End Function
   Public Function icSatAC() As Decimal 'CE, CB
        Return Me.IC + (Me.VCE / Me.rLoadAC)
    End Function
    Public Function rLoadAC() As Decimal'CE, CB
        Return CDec((Me.RC ^ -1 + Me.RL ^ -1) ^ -1)
    End Function
    Public Function vout() As Decimal 'max TODO rename?? deltaIB ??
        Return CDec(Me.IC * Me.rLoadAC)
    End Function
     Public Function vin() As Decimal 'CE, CB
        Return Me.IE * (Me.rPrimeE + Me.rSwamp)
    End Function



    'Frequency Response


    Public Function RthCIn() As Double 'CE, CB, CC
        Return (Me.rGen ^ -1 + Me.Zin ^ -1) ^ -1
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


    Public Function LowestCIn() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCIn, 57.0#)
    End Function
    Public Function LowestCOut() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCOut, 57.0#)
    End Function

    Public Function RthCBypass() As Double ' CE Only
        Return (Me.rEBypass ^ -1 + (Me.rSwamp + Me.rPrimeE + ((Me.R1 ^ -1 + Me.R2 ^ -1 + Me.rgen ^ -1) ^ -1 / (Me.beta + 1))) ^ -1) ^ -1
    End Function

    Public Function FcBypass() As Decimal
        Return LibElectronicsMath.CriticalFrequency(Me.RthCBypass, Me.cBypass)
    End Function

    Public Function LowestCBypass() As Double
        Return LibElectronicsMath.Capacitance(Me.RthCBypass, 57.0#)
    End Function

    Public Function FcLow() As Decimal 'CE, CB, CC
        Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.FcBypass ^ 2))
    End Function


End Class