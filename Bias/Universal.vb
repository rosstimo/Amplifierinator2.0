Option Explicit On
Option Strict On


Class Universal
    Public VCC%, R1%, R2%, RC%, RE%, Beta%
    Public RB% 'Bootstrap resister
    Const VBE = 0.7@

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

End Class
