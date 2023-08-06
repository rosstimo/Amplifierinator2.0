'Public Class UniversalBiasCommonBase
'    'Inherits UniversalBiased
'    Inherits Amplifier
'    'Implements IBJTAmplifier
'    'Properties

'    Private _VCC As Integer
'    Public Property VCC As Integer
'        Get
'            Return _VCC
'        End Get
'        Set(ByVal value As Integer)
'            _VCC = value
'        End Set
'    End Property

'    Private _R1 As Integer
'    Public Property R1 As Integer
'        Get
'            Return _R1
'        End Get
'        Set(ByVal value As Integer)
'            _R1 = value
'        End Set
'    End Property

'    Private _R2 As Integer
'    Public Property R2 As Integer
'        Get
'            Return _R2
'        End Get
'        Set(ByVal value As Integer)
'            _R2 = value
'        End Set
'    End Property

'    Private _RC As Integer
'    Public Property RC As Integer
'        Get
'            Return _RC
'        End Get
'        Set(ByVal value As Integer)
'            _RC = value
'        End Set
'    End Property

'    Private _RE As Integer
'    Public Property RE As Integer
'        Get
'            Return _RE
'        End Get
'        Set(ByVal value As Integer)
'            _RE = value
'        End Set
'    End Property

'    Private _beta As Integer
'    Public Property beta As Integer
'        Get
'            Return _beta
'        End Get
'        Set(ByVal value As Integer)
'            _beta = value
'        End Set
'    End Property

'    Private _IsNPN As Boolean
'    Public Property isNPN As Boolean
'        Get
'            Return _IsNPN
'        End Get
'        Set(ByVal value As Boolean)
'            _IsNPN = value
'        End Set
'    End Property

'    Private _rLoadAC As Decimal
'    Public Property rLoadAC() As Decimal
'        Get
'            Return rLoadACCB()
'        End Get
'        Set(ByVal value As Decimal)
'            _rLoadAC = value
'        End Set
'    End Property

'    Private _zin As Decimal
'    Public Property zin() As Decimal
'        Get
'            Return Me.ZinCB '_zin
'        End Get
'        Set(ByVal value As Decimal)
'            _zin = value
'        End Set
'    End Property

'    Private _zout As Decimal
'    Public Property zout() As Decimal
'        Get
'            Return ZoutCB()
'        End Get
'        Set(ByVal value As Decimal)
'            _zout = value
'        End Set
'    End Property

'    Private _vin As Decimal
'    Public Property vin() As Decimal
'        Get
'            Return vinCB()
'        End Get
'        Set(ByVal value As Decimal)
'            _vin = value
'        End Set
'    End Property

'    Private _vout As Decimal
'    Public Property vout() As Decimal
'        Get
'            Return voutCB()
'        End Get
'        Set(ByVal value As Decimal)
'            _vout = value
'        End Set
'    End Property


'    Public Function rLoadACCB() As Decimal 'CE, CB
'        Return CDec((Me.RC ^ -1 + Me.RL ^ -1) ^ -1)
'    End Function

'    Public Function ZinCB() As Decimal
'        Return CDec(((Me.RE - Me.rSwamp) ^ -1 + (Me.rPrimeE + Me.rSwamp) ^ -1) ^ -1)
'    End Function

'    Public Function ZoutCB() As Decimal
'        Return Me.RC
'    End Function

'    Public Function voutCB() As Decimal 'max TODO rename?? deltaIB ??
'        Return CDec(Me.IC * Me.rLoadAC)
'    End Function

'    Public Function vinCB() As Decimal 'CE, CB
'        Return Me.IE * (Me.rPrimeE + Me.rSwamp)
'    End Function

'    Public Function RthCBypass() As Double
'        Return (Me.rEBypass ^ -1 + (Me.rgen ^ -1)) ^ -1 + (Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + Me.rSwamp)) ^ -1) ^ -1
'    End Function

'    Public Function FcBypass() As Decimal
'        Return LibElectronicsMath.CriticalFrequency(Me.RthCBypass, Me.cBypass)
'    End Function

'    Public numberOfCapacitors As Integer = 3I
'    Public Function lowestcbypass() As Double
'        Return LibElectronicsMath.Capacitance(Me.RthCBypass, Me.fcLowTargetOffset(Me.numberOfCapacitors, Me.fcLowTargetDefault))
'    End Function

'    Public Function FcLow() As Decimal
'        Return CDec(Math.Sqrt(Me.Fcin ^ 2 + Me.FcOut ^ 2 + Me.FcBypass ^ 2))
'    End Function

'End Class