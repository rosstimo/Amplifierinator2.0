Public Interface IAmplifier

    'All Amplifiers
    Property rgen() As Decimal
    Property RLoad() As Decimal
    Property rLoadAC() As Decimal
    Property rPrime() As Decimal 'dynamic resistance r'e or r's
    Property zin() As Decimal
    Property zout() As Decimal
    Property vout() As Decimal
    Property vin() As Decimal
    Property vCutOffAC() As Decimal
    Property iSatAC() As Decimal
    Property Av() As Decimal
    Property Ai() As Decimal
    Property Ap() As Decimal
    Property AvdB() As Decimal
    Property AidB() As Decimal
    Property ApdB() As Decimal
    Property fcLowTarget As Decimal
    Property fcLow() As Decimal


    'transistor specific
    'Property rPrimeE() As Decimal 'BJT Only
    'Property rPrimeS() As Decimal 'FET Only

End Interface
