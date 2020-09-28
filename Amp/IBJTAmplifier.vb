Public Interface IBJTAmplifier

    'Components
    Property rgen() As Decimal
    Property RL() As Decimal

    'AC Stuff
    Property rSwamp() As Decimal ' CE, CB
    Function rEBypass() As Decimal ' CE, CB

    Function rLoadAC() As Decimal
    Function rPrimeE() As Decimal

    Function zin() As Decimal
    Function Zout() As Decimal

    Function vout() As Decimal
    Function vin() As Decimal
    Function vceCutOffAC() As Decimal
    Function icSatAC() As Decimal

    Function Av() As Decimal
    Function Ai() As Decimal 'CE, CB, CC
    Function Ap() As Decimal 'CE, CB, CC
    Function AvdB() As Decimal 'CE, CB, CC
    Function AidB() As Decimal 'CE, CB, CC
    Function ApdB() As Decimal 'CE, CB, CC

    'Frequency Response

    Property cIn() As Decimal
    Property cOut() As Decimal
    Property cBypass() As Decimal
    Property FcLowTarget As Decimal

    Function RthCIn() As Double 'CE, CB, CC
    Function RthCOut() As Double 'CE, CB, CC
    Function RthCBypass() As Double ' CE Only

    Function Fcin() As Decimal
    Function FcOut() As Decimal
    Function FcBypass() As Decimal

    Function FcLow() As Decimal 'CE, CB, CC

    Function LowestCIn() As Double
    Function LowestCOut() As Double
    Function LowestCBypass() As Double

End Interface
