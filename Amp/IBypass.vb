Public Interface IBypass
    'swamped/bypassed Frequency Response 'ISwamped
    Property rSwamp() As Decimal ' CE, CB, CS, CG
    Property rBypass() As Decimal ' CE, CB, CS, CG
    Property cBypass() As Decimal ' CE, CB, CS, CG?
    Property RthCBypass() As Double 'CE, CB, CS, CG?
    Property FcBypass() As Decimal 'CE, CB, CS, CG?
    Property LowestCBypass() As Double 'CE, CB, CS, CG?
End Interface
