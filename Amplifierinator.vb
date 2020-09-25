Imports System
Imports R = Amplifierinator.ElectronicComponentsLib.Resistor
Imports C = Amplifierinator.ElectronicComponentsLib.Capacitor
Imports Q = Amplifierinator.ElectronicComponentsLib.BJT

Module Amplifierinator

    Sub Main(args As String())
        'Dim testCEAmp = New UniversalBiased() With {.VCC = 24, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(22 * 10 ^ 3), .RC = 3300, .RE = 830, .beta = 200, .isNPN = True}
        'Dim testCBAmp = New CommonBase() With {.VCC = 24, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(22 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rGen = 50, .RL = 3300, .rSwamp = 0, .C1 = 100 * 10 ^ -6, .C2 = 10 * 10 ^ -6, .C3 = 10 * 10 ^ -6}
        Dim testCEAmp = New CommonEmitter() With {.VCC = 30, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(18 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rgen = 10000, .RL = 3300, .rSwamp = 150, .cIn = 0.22 * 10 ^ -6, .cOut = 0.47 * 10 ^ -6, .cBypass = 22 * 10 ^ -6}
        'Dim testCEAmp = New CommonBase() With {.VCC = 24, .R1 = CInt(360 * 10 ^ 3), .R2 = CInt(56 * 10 ^ 3), .RC = 10000, .RE = 2200, .beta = 200, .isNPN = True, .rGen = 50, .RL = 10500, .rSwamp = 470, .C1 = 68 * 10 ^ -6, .C2 = 0.22 * 10 ^ -6, .C3 = 0.47 * 10 ^ -6}
        'Dim testCEAmp = New CommonCollector() With {.VCC = 9, .R1 = CInt(68000), .R2 = CInt(120000), .RC = 0, .RE = 32, .beta = 200 * 200, .isNPN = True, .rGen = 50, .RL = 8, .rSwamp = 16, .C1 = 68 * 10 ^ -6, .C2 = 0.22 * 10 ^ -6, .C3 = 0.47 * 10 ^ -6}
        'Dim testCEAmp = New CommonCollector() With {.VCC = 24, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(22 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rGen = 50, .RL = 8, .rSwamp = 0, .C1 = 100 * 10 ^ -6, .C2 = 10 * 10 ^ -6, .C3 = 10 * 10 ^ -6}
        'Dim testCEAmp = New CommonCollector() With {.VCC = 9, .R1 = CInt(3300), .R2 = CInt(4700), .RC = 0, .RE = 660, .beta = 200, .isNPN = True, .rGen = 50, .RL = 330, .rSwamp = 330, .C1 = 68 * 10 ^ -6, .C2 = 0.22 * 10 ^ -6, .C3 = 0.47 * 10 ^ -6}

        Console.WriteLine("Given:")
        Console.WriteLine($"VCC = {testCEAmp.VCC}")
        Console.WriteLine($"Beta = {testCEAmp.beta}")
        Console.WriteLine($"R1 = {testCEAmp.R1}")
        Console.WriteLine($"R2 = {testCEAmp.R2}")
        Console.WriteLine($"RC = {testCEAmp.RC}")
        Console.WriteLine($"RE = {testCEAmp.RE}")
        Console.WriteLine()
        Console.WriteLine("DC Summery:")
        Console.WriteLine($"IB = {testCEAmp.IB}")
        Console.WriteLine($"IC = {testCEAmp.IC}")
        Console.WriteLine($"IE = {testCEAmp.IE}")
        Console.WriteLine($"VRC = {testCEAmp.VRC}")
        Console.WriteLine($"VCE = {testCEAmp.VCE}")
        Console.WriteLine($"VRE = {testCEAmp.VRE}")
        Console.WriteLine($"VR1 = {testCEAmp.VR1}")
        Console.WriteLine($"VR2 = {testCEAmp.VR2}")
        Console.WriteLine()
        'Console.WriteLine("AC Summery:")
        'Console.WriteLine($"RL = {testCEAmp.RL}")
        'Console.WriteLine($"Rswamp = {testCEAmp.rSwamp}")
        'Console.WriteLine($"Zin = {testCEAmp.Zin}")
        'Console.WriteLine($"Zout = {testCEAmp.Zout}")
        'Console.WriteLine($"vout max = {testCEAmp.vout}")
        'Console.WriteLine($"Av = {testCEAmp.Av}")
        'Console.WriteLine($"AvdB = {testCEAmp.AvdB}")
        'Console.WriteLine($"Ai = {testCEAmp.Ai}")
        'Console.WriteLine($"AidB = {testCEAmp.AidB}")
        'Console.WriteLine($"Ap = {testCEAmp.Ap}")
        'Console.WriteLine($"ApdB = {testCEAmp.ApdB}")
        'Console.WriteLine()
        'Console.WriteLine("Frequency Response Summery:")
        'Console.WriteLine($"FcLow = {testCEAmp.FcLow}")
        'Console.WriteLine($"C1 = {testCEAmp.cIn}")
        'Console.WriteLine($"RthC1 = {testCEAmp.RthCIn}")
        'Console.WriteLine($"Fc1 = {testCEAmp.Fcin}")
        'Console.WriteLine($"Lowest C1 = {testCEAmp.LowestCIn}")
        'Console.WriteLine($"C2 = {testCEAmp.cOut}")
        'Console.WriteLine($"RthC2 = {testCEAmp.RthCOut}")
        'Console.WriteLine($"Fc2 = {testCEAmp.FcOut}")
        'Console.WriteLine($"Lowest C2 = {testCEAmp.LowestCOut}")
        'Console.WriteLine($"C3 = {testCEAmp.cBypass}")
        'Console.WriteLine($"RthC3 = {testCEAmp.RthCBypass}")
        'Console.WriteLine($"Fc3 = {testCEAmp.FcBypass}")
        'Console.WriteLine($"Lowest C3 = {testCEAmp.LowestCBypass}")

        Console.Read()
    End Sub


End Module
