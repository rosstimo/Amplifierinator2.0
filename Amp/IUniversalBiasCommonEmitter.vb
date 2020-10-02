Public Interface IUniversalBiasCommonEmitter
    Inherits ISeriesCoupled
    Property zin As Decimal
    Function FcBypass() As Decimal
    Function FcLow() As Decimal
    Function LowestCBypass() As Double
    Function RthCBypass() As Double
    Function vin() As Decimal
End Interface