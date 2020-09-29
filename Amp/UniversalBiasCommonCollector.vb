'Public Class UniversalBiasCommonCollector
'    'Inherits UniversalBiased
'    Inherits Amplifier

'    'Properties
'    Private _VCC As Integer
'    Public Overrides Property VCC As Integer
'        Get
'            Return _VCC
'        End Get
'        Set(ByVal value As Integer)
'            _VCC = value
'        End Set
'    End Property

'    Private _R1 As Integer
'    Public Overrides Property R1 As Integer
'        Get
'            Return _R1
'        End Get
'        Set(ByVal value As Integer)
'            _R1 = value
'        End Set
'    End Property

'    Private _R2 As Integer
'    Public Overrides Property R2 As Integer
'        Get
'            Return _R2
'        End Get
'        Set(ByVal value As Integer)
'            _R2 = value
'        End Set
'    End Property

'    Private _RC As Integer
'    Public Overrides Property RC As Integer
'        Get
'            Return _RC
'        End Get
'        Set(ByVal value As Integer)
'            _RC = value
'        End Set
'    End Property

'    Private _RE As Integer
'    Public Overrides Property RE As Integer
'        Get
'            Return _RE
'        End Get
'        Set(ByVal value As Integer)
'            _RE = value
'        End Set
'    End Property

'    Private _beta As Integer
'    Public Overrides Property beta As Integer
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
'    Public Overrides Property rLoadAC() As Decimal
'        Get
'            Return rLoadACCC()
'        End Get
'        Set(ByVal value As Decimal)
'            _rLoadAC = value
'        End Set
'    End Property

'    Private _zout As Decimal
'    Public Overrides Property zout() As Decimal
'        Get
'            Return ZoutCC()
'        End Get
'        Set(ByVal value As Decimal)
'            _zout = value
'        End Set
'    End Property

'    Private _zin As Decimal
'    Public Overrides Property zin() As Decimal
'        Get
'            Return Me.ZinCC '_zin
'        End Get
'        Set(ByVal value As Decimal)
'            _zin = value
'        End Set
'    End Property
'    Private _vin As Decimal
'    Public Overrides Property vin() As Decimal
'        Get
'            Return vinCC()
'        End Get
'        Set(ByVal value As Decimal)
'            _vin = value
'        End Set
'    End Property
'    Private _vout As Decimal
'    Public Overrides Property vout() As Decimal
'        Get
'            Return voutCC()
'        End Get
'        Set(ByVal value As Decimal)
'            _vout = value
'        End Set
'    End Property

'    Sub New()

'    End Sub

'    Public Function ZinCC() As Decimal 'CC
'        Return CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.beta + 1) * (Me.rPrimeE + (Me.RE ^ -1 + Me.RL ^ -1) ^ -1) ^ -1)) ^ -1)
'    End Function

'    Public Function ZoutCC() As Decimal 'CC
'        Return (Me.RE ^ -1 + (Me.rPrimeE + (((Me.rgen ^ -1 + R1 ^ -1 + R2 ^ -1) ^ -1) / (Me.beta + 1))) ^ -1) ^ -1
'    End Function

'    Public Function vinCC() As Decimal 'CC
'        Return Me.IE * (Me.rPrimeE + (Me.RE ^ -1 + Me.RL ^ -1) ^ -1)
'    End Function

'    Public Function voutCC() As Decimal 'CC
'        Return CDec(Me.IE * (Me.RE ^ -1 + Me.RL ^ -1) ^ -1)
'    End Function

'    Public Function rLoadACCC() As Decimal 'CC
'        Return CDec((Me.RE ^ -1 + Me.RL ^ -1) ^ -1)
'    End Function



'End Class
