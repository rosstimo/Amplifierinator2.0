Public Interface IUviversalBias
    Inherits IBJTBias

    Property VCC As Integer

    Property RC As Integer
    Property RE As Integer
    Property R1 As Integer
    Property R2 As Integer

    Function VRC() As Decimal
    Function VRE() As Decimal

    Function IR1() As Decimal
    Function VR1() As Decimal
    Function IR2() As Decimal
    Function VR2() As Decimal

End Interface
