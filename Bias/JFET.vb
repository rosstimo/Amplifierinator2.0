Option Explicit On
Option Strict On
Namespace JFET

    Class SelfBias
        Public RG%, RD%, RS%, RS1%, RS2%, VDD%, IDSS@, VGSOff@
        Public IG% = 0
        Public CommonSource As New CommonSource
        Public CommonDrain As New CommonDrain

        Sub Analize()
            getCommonSource()
        End Sub

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

        'Common Source Amplifier
        Private Sub getCommonSource()
            Me.CommonSource.rSwamp = Me.RS1
            Me.CommonSource.zin = Me.RG
            Me.CommonSource.zout = Me.RD
            Me.CommonSource.rPrimeS = CDec(Me.VGSOff / (Me.VGS * Math.Sqrt(Me.IDSS * Me.ID)))
            Me.CommonSource.vinMax = Me.ID * (Me.CommonSource.rPrimeS + Me.CommonSource.rSwamp)
            Me.CommonSource.voutMax = CDec(Me.ID * (Me.RD ^ -1 + Me.CommonSource.RL ^ -1) ^ -1)
            Me.CommonSource.Av = Me.CommonSource.voutMax / Me.CommonSource.vinMax
            Me.CommonSource.Ai = Me.CommonSource.Av * (Me.CommonSource.zin / Me.CommonSource.RL)
            Me.CommonSource.Ap = Me.CommonSource.Av * Me.CommonSource.Ai
            Me.CommonSource.idSatAC = CDec(Me.VDS / (Me.RD ^ -1 + Me.CommonSource.RL ^ -1) ^ -1) + Me.ID
            Me.CommonSource.vdsCutAC = Me.CommonSource.voutMax + Me.VDS
        End Sub

        'Common Drain Amplifier
        Private Sub getCommonDrain()
            Me.CommonDrain.rSwamp = Me.RS1
            Me.CommonDrain.zin = Me.RG 'TODO
            Me.CommonDrain.zout = Me.RD 'TODO
            Me.CommonDrain.rPrimeS = CDec(Me.VGSOff / (Me.VGS * Math.Sqrt(Me.IDSS * Me.ID)))
            Me.CommonDrain.vinMax = Me.ID * (Me.CommonDrain.rPrimeS + Me.CommonDrain.rSwamp) 'TODO
            Me.CommonDrain.voutMax = CDec(Me.ID * (Me.RD ^ -1 + Me.CommonDrain.RL ^ -1) ^ -1) 'TODO
            Me.CommonDrain.Av = Me.CommonDrain.voutMax / Me.CommonDrain.vinMax
            Me.CommonDrain.Ai = Me.CommonDrain.Av * (Me.CommonDrain.zin / Me.CommonDrain.RL)
            Me.CommonDrain.Ap = Me.CommonDrain.Av * Me.CommonDrain.Ai
            Me.CommonDrain.idSatAC = CDec(Me.VDS / (Me.RD ^ -1 + Me.CommonDrain.RL ^ -1) ^ -1) + Me.ID 'TODO
            Me.CommonDrain.vdsCutAC = Me.CommonDrain.voutMax + Me.VDS
        End Sub

    End Class

    Class UniversalBias

    End Class

    Class CommonSource
        Public RL%, rgen%, rSwamp%, zin@, zout@, Av@, Ai@, Ap@, rPrimeS@, voutMax@, vinMax@, idSatAC@, vdsCutAC@
    End Class

    Class CommonDrain
        Public RL%, rgen%, rSwamp%, zin@, zout@, Av@, Ai@, Ap@, rPrimeS@, voutMax@, vinMax@, idSatAC@, vdsCutAC@
    End Class

    Class CommonGate
        Public RL%, rgen%, rSwamp%, zin@, zout@, Av@, Ai@, Ap@, rPrimeS@, voutMax@, vinMax@, idSatAC@, vdsCutAC@
    End Class

    'FcL


End Namespace