Public Interface IBJTBias
    'DC Stuff
    'BJT Pin Currents
    Property beta As Integer
    Property IB() As Decimal
    Property IC() As Decimal
    Property IE() As Decimal
    'BJT Pin Voltages
    Property VB() As Decimal
    Property VC() As Decimal
    Property VE() As Decimal
    Property VCE() As Decimal
    Property VBE() As Decimal
    Property VBC() As Decimal
    'Load Line Limits
    Property IcSat() As Decimal
    Property VCECutOff() As Decimal
End Interface
