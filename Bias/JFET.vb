Option Explicit On
Option Strict On
Namespace JFET

    Class SelfBias
        Public RG%, RD%, RS%, VDD%, IDSS@, VGSOff@
        Public IG% = 0
        Public CE As New CommonSource

        '''<summary>
        '''ID = IDSS*(1-(VGS/VGSOff))^2
        '''</summary>
        Function ID() As Decimal
            Dim _ID@, a@, b@, c@
            'a = 500
            'b = -5
            'c =0.008
            a = CDec((Me.IDSS * Me.RS ^ 2) / Me.VGSOff ^ 2)
            b = ((2 * Me.IDSS * Me.RS) / Me.VGSOff) - 1
            c = Me.IDSS

            'quadratic TODO add to math library return tuple or something
            _ID = CDec(-b - Math.Sqrt(b ^ 2 - (4 * a * c))) / (2 * a)


            Return _ID
        End Function

        ''' <summary>
        ''' VRG=IG*RG
        ''' </summary>
        Function VRG() As Decimal
            Return Me.IG * Me.RG
        End Function

        Function VRS() As Decimal
            Return Me.ID * Me.RS
        End Function

        Function VRD() As Decimal
            Return Me.ID * Me.RD
        End Function

        ''' <summary>
        ''' 0=-VRG+VGS+VRS
        ''' VGS=VRG-VRS
        ''' </summary>
        Function VGS() As Decimal
            Return Me.VRG - Me.VRS
        End Function

        Function VDS() As Decimal
            Return Me.VDD - Me.VRD - Me.VRS
        End Function

        Function VG() As Decimal
            Return Me.VRG
        End Function

        Function VD() As Decimal
            Return Me.VDS + Me.VRS
        End Function

        Function VS() As Decimal
            Return Me.VRS
        End Function

        Function IDSat() As Double
            Return Me.VDD / (Me.RD + Me.RS)
        End Function

    End Class

    Class UniversalBias

    End Class

    Class CommonSource




    End Class

    Class CommonDrain

    End Class

    Class CommonGate

    End Class

    'FcL


End Namespace