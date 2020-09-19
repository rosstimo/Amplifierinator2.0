Public Interface IBJTAmplifier

    'Components
    Property VCC As Integer
    Property R1 As Integer
    Property R2 As Integer
    Property RC As Integer
    Property RE As Integer
    Property beta As Integer
    Property isNPN As Boolean

    'DC Stuff
    Function IB() As Decimal
    Function IR1(Optional value@ = 0D) As Decimal
    Function SolveSimultaneousEquation(ByVal a1@, ByVal b1@, ByVal k1@, ByVal a2@, ByVal b2@, ByVal k2@) As (aTermResult@, bTermResult@)
    Function VBE() As Decimal
    Function IC() As Decimal
    Function IE() As Decimal
    Function IR2() As Decimal
    Function VR1() As Decimal
    Function VR2() As Decimal
    Function VRC() As Decimal
    Function VRE() As Decimal
    Function VCE() As Decimal
    Function IcSat() As Decimal
    Function VCECutOff() As Decimal

    'AC Stuff
    Property rgen() As Decimal
    Property RL() As Decimal
    Property rSwamp() As Decimal

    Property cIn() As Decimal
    Property cOut() As Decimal
    Property cBypass() As Decimal
    Property FcLowTarget As Decimal

    Function rPrimeE() As Decimal 'CE, CB, CC
    Function rEBypass() As Decimal 'CE, CB
    Function rLoadAC() As Decimal 'CE, CB
    Function zin() As Decimal
    Function Zout() As Decimal
    Function vout() As Decimal
    Function vin() As Decimal 'CE, CB
    Function vceCutOffAC() As Decimal 'CE, CB, CC
    Function icSatAC() As Decimal 'CE, CB

    Function Av() As Decimal
    Function Ai() As Decimal 'CE, CB, CC
    Function Ap() As Decimal 'CE, CB, CC
    Function AvdB() As Decimal 'CE, CB, CC
    Function AidB() As Decimal 'CE, CB, CC
    Function ApdB() As Decimal 'CE, CB, CC

    'Frequency Response
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
