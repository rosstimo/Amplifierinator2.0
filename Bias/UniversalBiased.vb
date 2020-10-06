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

    'Private _IsNPN As Boolean
    'Public Property isNPN As Boolean
    '    Get
    '        Return _IsNPN
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _IsNPN = value
    '    End Set
    'End Property

    'fields

    Public Sub New(Optional ByVal VCC% = 24%, Optional ByVal optimal As Boolean = False, Optional ByVal bootstrap As Boolean = False)
        'Optional ByVal R1% = 120000%,
        'Optional ByVal R2% = 18000%,
        'Optional ByVal RB% = 0%,'bootstrap
        'Optional ByVal RC% = 3300%,
        'Optional ByVal RE% = 830%,
        'Optional ByVal beta% = 200%,
        'Optional ByVal rSwamp% = 150%)

        'If Me.VCC = 0 Then
        '    Me.VCC = 24
        'End If
        'If Me.VR1 = 0 Then
        '    Me.VCC = 24
        'End If
        'Me.R1 = R1
        'Me.R2 = R2
        'Me.RB = RB
        'Me.RC = RC
        'Me.RE = RE
        'Me.beta = beta


    End Sub

    'Public Function IB() As Decimal
    '    Static a@, b@
    '    Dim results = (a, b)
    '    Static notSet As Boolean = True
    '    '   | aTerm      | bTerm          | kTerm
    '    '--------------------------------------------
    '    '1  |IR1(R1+R2)  | - IB(R2) =     | VCC
    '    '2  |IR1(R1)     | + IB(beta+1)(RE) = | VCC - VBE
    '    If notSet Then
    '        results = SolveSimultaneousEquation(Me.R1 + Me.R2, Me.R2 * -1, Me.VCC, Me.R1, (Me.beta + 1) * Me.RE, Me.VCC - Me.VBE())
    '    End If
    '    Me.IR1(results.a)
    '    Return results.b

    'End Function

    Public Function IB() As Decimal
        Static a@, b@
        Dim results = (a, b)
        Static notSet As Boolean = True
        '   | aTerm      | bTerm          | kTerm
        '--------------------------------------------
        '1  |IR2(R1+R2)  | + IB(R2) =     | VCC
        '2  |IR2(R1)     | + IB(R1+RB+RE(beta+1)) = | VCC - VBE


        If notSet Then
            results = SolveSimultaneousEquation(Me.R1 + Me.R2, Me.R2, Me.VCC, Me.R1, Me.R1 + Me.RB + (Me.RE * (Me.beta + 1)), Me.VCC - Me.VBE())
        End If
        'Me.IR2(results.a)
        Return results.b

    End Function


    'Public Function IR1(Optional value@ = 0D) As Decimal
    '    Static storedValue@
    '    Static notSet As Boolean = True
    '    If notSet And value <> 0 Then
    '        storedValue = value
    '        notSet = False
    '    End If
    '    Return storedValue
    'End Function

    'TODO This could be part of a electronics math class library
    Private Function SolveSimultaneousEquation(ByVal a1@, ByVal b1@, ByVal k1@, ByVal a2@, ByVal b2@, ByVal k2@) As (aTermResult@, bTermResult@)
        Dim aTermResult@, bTermResult@, numerator@, denominator@
        Dim result = (aTermResult, bTermResult)
        denominator = (a1 * b2) - (b1 * a2)
        numerator = (k1 * b2) - (b1 * k2)
        result.aTermResult = (numerator / denominator)
        numerator = (a1 * k2) - (k1 * a2)
        result.bTermResult = (numerator / denominator)
        Return result
    End Function




    Public Function VBE() As Decimal
        Return 0.7@
    End Function
    Public Function IC() As Decimal
        Return Me.IB * Me.beta
    End Function
    Public Function IE() As Decimal
        Return Me.IB * (Me.beta + 1)
    End Function
    Public Function VRC(optomize As Boolean) As Decimal
        Return Me.VCC * 0.45
    End Function
    Public Function VRC() As Decimal
        Return Me.IC * Me.RC
    End Function
    Public Function VRB() As Decimal
        Return Me.RB * Me.IB
    End Function
    Public Function VRE(optomize As Boolean) As Decimal
        Return Me.VCC * 0.1
    End Function
    Public Function VRE() As Decimal
        Return Me.IE * Me.RE
    End Function
    Public Function VCE() As Decimal
        Return Me.VCC - Me.VRC - Me.VRE
    End Function
    Public Function VR2() As Decimal
        Return Me.VRE + Me.VBE + Me.VRB
    End Function
    Public Function VR1() As Decimal
        Return Me.VCC - Me.VR2
    End Function
    Public Function IR2(optomize As Boolean) As Decimal
        'TODO round down to common value then recalculate IR2
        Return Me.IB * 10
    End Function
    Public Function IR2() As Decimal
        Return Me.VR2 / Me.R2
    End Function
    Public Function IR1(optomize As Boolean) As Decimal
        'TODO round down to common value then recalculate IR1
        Return Me.IB + Me.IR2
    End Function
    Public Function IR1() As Decimal
        Return Me.VR1 / Me.R1
    End Function
    Public Shadows Function IcSat() As Decimal
        Return CDec(Me.VCC / (Me.RC + Me.RE))
    End Function
    Public Function VCECutOff() As Decimal
        Return Me.VCC
    End Function

End Class