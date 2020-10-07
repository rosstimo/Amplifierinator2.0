Public Class UniversalBiased
    'Inherits Amplifier
    'Implements IBJTBias

    'Properties
    Private _VCC As Integer
    Public Overridable Property VCC As Integer
        Get
            Return _VCC
        End Get
        Set(ByVal value As Integer)
            _VCC = value
        End Set
    End Property

    Private _R1 As Integer
    Public Overridable Property R1 As Integer
        Get
            Return _R1
        End Get
        Set(ByVal value As Integer)
            _R1 = value
        End Set
    End Property
    Private _R2 As Integer
    Public Overridable Property R2 As Integer
        Get
            Return _R2
        End Get
        Set(ByVal value As Integer)
            _R2 = value
        End Set
    End Property
    Private _RB As Integer
    Public Overridable Property RB As Integer
        Get
            Return _RB
        End Get
        Set(ByVal value As Integer)
            _RB = value
        End Set
    End Property
    Private _RC As Integer
    Public Overridable Property RC As Integer
        Get
            Return _RC
        End Get
        Set(ByVal value As Integer)
            _RC = value
        End Set
    End Property
    Private _RE As Integer
    Public Overridable Property RE As Integer
        Get
            Return _RE
        End Get
        Set(ByVal value As Integer)
            _RE = value
        End Set
    End Property

    Private _beta As Integer
    Public Overridable Property beta As Integer
        Get
            Return _beta
        End Get
        Set(ByVal value As Integer)
            _beta = value
        End Set
    End Property

    Private _IB As Double
    Public Property IB As Double
        Get
            Return _IB
        End Get
        Set(ByVal value As Double)

            _IB = value
        End Set
    End Property
    Private _IC As Double
    Public Property IC As Double
        Get
            Return _IC
        End Get
        Set(ByVal value As Double)

            _IC = value
        End Set
    End Property
    Private _IE As Double
    Public Property IE As Double
        Get
            Return _IE
        End Get
        Set(ByVal value As Double)

            _IE = value
        End Set
    End Property
    Private _IR1 As Double
    Public Property IR1 As Double
        Get
            Return _IR1
        End Get
        Set(ByVal value As Double)
            _IR1 = value
        End Set
    End Property
    Private _IR2 As Double
    Public Property IR2 As Double
        Get
            Return _IR2
        End Get
        Set(ByVal value As Double)

            _IR2 = value
        End Set
    End Property

    Private _VRC As Double
    Public Property VRC As Double
        Get
            Return _VRC
        End Get
        Set(ByVal value As Double)

            _VRC = value
        End Set
    End Property
    Private _VRE As Double
    Public Property VRE As Double
        Get
            Return _VRE
        End Get
        Set(ByVal value As Double)

            _VRE = value
        End Set
    End Property
    Private _VRB As Double
    Public Property VRB As Double
        Get
            Return _VRB
        End Get
        Set(ByVal value As Double)

            _VRB = value
        End Set
    End Property
    Private _VCE As Double
    Public Property VCE As Double
        Get
            Return _VCE
        End Get
        Set(ByVal value As Double)

            _VCE = value
        End Set
    End Property
    Private _VR1 As Double
    Public Property VR1 As Double
        Get
            Return _VR1
        End Get
        Set(ByVal value As Double)
            _VR1 = value
        End Set
    End Property
    Private _VR2 As Double
    Public Property VR2 As Double
        Get
            Return _VR2
        End Get
        Set(ByVal value As Double)
            _VR2 = value
        End Set
    End Property


    'fields
    Private optomize As Boolean
    Private bootstrap As Boolean

    Public Sub New(Optional ByVal optimize As Boolean = False, Optional ByVal bootstrap As Boolean = False)
        Me.optomize = optimize
        Me.bootstrap = bootstrap
        If Me.VCC = 0 Then
            Me.VCC = 30
        End If
        If Me.RC = 0 Then
            Me.RC = 3300
        End If
        If Me.beta = 0 Then
            Me.beta = 200
        End If
        'Me.RC = ElectronicComponentsLib.Resistor.getCommonResistor(128345)
        If optomize Then
            solveVRC()
            solveVCE()
            solveVRE()
            solveIC()
            solveIB()
            solveIE()
            SolveRC()
            SolveRE()
            SolveRB()
            solveIR2()
            solveVR2()
            solveR2()
            SolveIR1()
            solveVR1()
            solveR1()
        End If
    End Sub


    Private Sub solveRB()
        Me.RB = ElectronicComponentsLib.Resistor.getCommonResistor(Me.VRB / Me.IB)
    End Sub
    Private Sub solveRC()
        Me.RC = ElectronicComponentsLib.Resistor.getCommonResistor(Me.VRC / Me.IC)
    End Sub
    Private Sub solveRE()
        Me.RE = ElectronicComponentsLib.Resistor.getCommonResistor(Me.VRE / Me.IE)
    End Sub
    Private Sub solveR1()
        Me.R1 = ElectronicComponentsLib.Resistor.getCommonResistor(Me.VR1 / Me.IR1)
    End Sub
    Private Sub solveR2()
        Me.R2 = ElectronicComponentsLib.Resistor.getCommonResistor(Me.VR2 / Me.IR2)
    End Sub

    Private Sub solveIB()
        If Me.optomize Then
            Me.IB = Me.IC / Me.beta
        Else
            '   | a Term     | b Term                   | k Term
            '------------------------------------------------------
            '1  |IR2(R1+R2)  | + IB(R2) =               | VCC
            '2  |IR2(R1)     | + IB(R1+RB+RE(beta+1)) = | VCC - VBE
            Dim a@, b@
            Dim results = (a, b)
            results = LibElectronicsMath.SolveSimultaneousEquation(Me.R1 + Me.R2, Me.R2, Me.VCC, Me.R1, Me.R1 + Me.RB + (Me.RE * (Me.beta + 1)), Me.VCC - Me.VBE())
            Me.IB = results.b
        End If
    End Sub
    Private Sub solveIC()
        If Me.optomize Then
            Me.IC = Me.VRC / Me.RC  'Assume Impedance match RC to C.E. RL
        Else
            Me.IC = Me.IB * Me.beta
        End If
    End Sub
    Private Sub solveIE()
        Me.IE = Me.IB * (Me.beta + 1)
    End Sub
    Private Sub solveIR1()
        'TODO round down to common value then recalculate IR1
        If optomize Then
            Me.IR1 = Me.IB + Me.IR2
        Else
            Me.IR1 = Me.VR1 / Me.R1
        End If
    End Sub
    Private Sub solveIR2()
        'TODO round down to common value then recalculate IR2
        If optomize Then
            Me.IR2 = Me.IB * 10
        Else
            Me.IR2 = Me.VR2 / Me.R2
        End If
    End Sub

    Private Sub solveVRB()
        Me.VRB = Me.RB * Me.IB
    End Sub
    Private Sub solveVRC()
        If Me.optomize Then
            Me.VRC = Me.VCC * 0.45
        Else
            Me.VRC = Me.IC * Me.RC
        End If
    End Sub
    Private Sub solveVRE()
        If Me.optomize Then
            Me.VRE = Me.VCC * 0.1
        Else
            Me.VRE = Me.IE * Me.RE
        End If
    End Sub
    Private Sub solveVR1()
        Me.VR1 = Me.VCC - Me.VR2
    End Sub
    Private Sub solveVR2()
        Me.VR2 = Me.VRE + Me.VBE + Me.VRB
    End Sub
    Private Sub solveVCE()
        If Me.optomize Then
            Me.VCE = Me.VCC * 0.45
        Else
            Me.VCE = Me.VCC - Me.VRC - Me.VRE
        End If
    End Sub
    Public Function VBE() As Decimal
        Return 0.7@
    End Function

    Public Function IcSat() As Decimal
        Return CDec(Me.VCC / (Me.RC + Me.RE))
    End Function
    Public Function VCECutOff() As Decimal
        Return Me.VCC
    End Function

End Class