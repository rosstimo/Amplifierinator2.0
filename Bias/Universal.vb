Option Explicit On
Option Strict On

'Namespace BJT 'TODO
Class Universal
    Public VCC%, R1%, R2%, RC%, RE%, Beta%
    Public RE1%, RE2%
    Public RB% 'Bootstrap resister
    Const VBE = 0.7@
    Public CommonEmitter As New CommonEmitTer
    Public CommonCollector As New CommonCollector
    Public CommonBase As New CommonBase

    Sub Analize()
        GetCommonEmmiter()
    End Sub
    ''' <summary>
    '''    | a Term     | b Term                | k Term
    '''----------------------------------------------------
    ''' 1  |IR1(R1+R2)  | - IB(R2) =            | VCC
    ''' 2  |IR1(R1)     | + IB(RB+RE(beta+1)) = | VCC - VBE
    ''' </summary>
    Function IB() As Decimal

        Dim a1@, b1@, k1@, a2@, b2@, k2@
        Dim a@, b@
        Dim results = (a, b)
        a1 = Me.R1 + Me.R2
        b1 = Me.R2 * -1
        k1 = Me.VCC
        a2 = Me.R1
        b2 = Me.RB + (Me.RE * Me.Beta + 1)
        k2 = Me.VCC - Me.VBE

        results = Electronic.Math.SolveSimultaneousEquation(a1@, b1@, k1@, a2@, b2@, k2@)

        Return results.b
    End Function

    Function IC() As Decimal
        Return Me.IB * Me.Beta
    End Function

    Function IE() As Decimal
        Return Me.IB * (Me.Beta + 1)
    End Function

    Function VRC() As Decimal
        Return Me.IC * Me.RC
    End Function

    Function VRE() As Decimal
        Return Me.IE * Me.RE
    End Function

    Function VR2() As Decimal
        Return Me.VBE + Me.VRE
    End Function

    Function VR1() As Decimal
        Return Me.VCC - Me.VR2
    End Function

    Function VCE() As Decimal
        Return Me.VCC - Me.VRC - Me.VRE
    End Function

    Function VCECutOff() As Decimal
        Return Me.VCC
    End Function

    Function ICSaturation() As Decimal
        Return CDec(Me.VCC / (Me.RC + Me.RE))
    End Function

    Private Sub GetCommonEmmiter()
        'Me.CommonEmitter.RL = Me.RC
        'Me.CommonEmitter.rgen = 50
        ' Me.CommonEmitter.rSwamp = Me.RE1
        With Me.CommonEmitter
            .rPrimeE = CDec(0.026 / Me.IE)
            .zin = CDec((Me.R1 ^ -1 + Me.R2 ^ -1 + ((Me.Beta + 1) * (.rPrimeE + .rSwamp)) ^ -1) ^ -1)
            .zout = Me.RC
            .rLAC = CDec((.zout ^ -1 + .RL ^ -1) ^ -1)
            .voutMax = Me.IC * (.rLAC)
            .vinMax = Me.IE * (.rPrimeE + .rSwamp)
            .Av = .voutMax / .vinMax
            .Ai = .Av * (.zin / .RL)
            .Ap = .Av * .Ai
            .icSatAC = (Me.VCE / .rLAC) + Me.IC
            .vceCutAC = Me.VCE + .voutMax
        End With
    End Sub

    Private Sub GetCommonCollector()

    End Sub

    Private Sub GetCommonBase()

    End Sub

End Class

Class CommonEmitter
    Public RL%, rgen%, rSwamp%, zin@, zout@, rLAC@, Av@, Ai@, Ap@, rPrimeE@, voutMax@, vinMax@, icSatAC@, vceCutAC@
End Class

Class CommonCollector
    Public RL%, rgen%, rSwamp%, zin@, zout@, rLAC@, Av@, Ai@, Ap@, rPrimeE@, voutMax@, vinMax@, icSatAC@, vceCutAC@
End Class

Class CommonBase
    Public RL%, rgen%, rSwamp%, zin@, zout@, rLAC@, Av@, Ai@, Ap@, rPrimeE@, voutMax@, vinMax@, icSatAC@, vceCutAC@
End Class