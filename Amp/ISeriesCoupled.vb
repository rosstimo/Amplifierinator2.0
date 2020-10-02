Public Interface ISeriesCoupled

    'Series Coupling Frequency Response 'ISeriesCoupled
    Property cIn() As Decimal
    Property cOut() As Decimal
    Property RthCIn() As Double
    Property RthCOut() As Double
    Property Fcin() As Decimal
    Property FcOut() As Decimal
    Property LowestCIn() As Double
    Property LowestCOut() As Double

End Interface
