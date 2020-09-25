Public Interface IBJTBias
    'DC Stuff
    'BJT Pin Currents
    Property beta As Integer
    Function IB() As Decimal
    Function IC() As Decimal
    Function IE() As Decimal
    'BJT Pin Voltages
    Function VB() As Decimal
    Function VC() As Decimal
    Function VE() As Decimal
    Function VCE() As Decimal
    Function VBE() As Decimal
    Function VBC() As Decimal
    'Load Line Limits
    Function IcSat() As Decimal
    Function VCECutOff() As Decimal
End Interface
