Public Class BJT
    Implements IBJTBias
    Public CommonEmitter As New UniversalBiasCommonEmitter

    Sub New(Optional ByVal VCC% = 30%,
            Optional ByVal R1% = 120000%,
            Optional ByVal R2% = 18000%,
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
        Me.CommonEmitter.Universalbias.VCC = VCC
        Me.CommonEmitter.Universalbias.R1 = R1
        Me.CommonEmitter.Universalbias.R2 = R2
        Me.CommonEmitter.Universalbias.RC = RC
        Me.CommonEmitter.Universalbias.RE = RE
        Me.CommonEmitter.Universalbias.beta = beta


        Me.CommonEmitter.rSwamp = rSwamp
        Me.CommonEmitter.RL = RL
        Me.CommonEmitter.rgen = rgen
        Me.CommonEmitter.cIn = cIn
        Me.CommonEmitter.cOut = cOut
        Me.CommonEmitter.cBypass = cBypass

        Console.WriteLine("Amp")

    End Sub

    Public Property beta As Integer Implements IBJTBias.beta
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property IB As Decimal Implements IBJTBias.IB
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property IC As Decimal Implements IBJTBias.IC
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property IE As Decimal Implements IBJTBias.IE
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VB As Decimal Implements IBJTBias.VB
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VC As Decimal Implements IBJTBias.VC
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VE As Decimal Implements IBJTBias.VE
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VCE As Decimal Implements IBJTBias.VCE
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VBE As Decimal Implements IBJTBias.VBE
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VBC As Decimal Implements IBJTBias.VBC
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property IcSat As Decimal Implements IBJTBias.IcSat
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property VCECutOff As Decimal Implements IBJTBias.VCECutOff
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Decimal)
            Throw New NotImplementedException()
        End Set
    End Property
End Class