Imports System
'Imports R = Amplifierinator.ElectronicComponentsLib.Resistor
'Imports C = Amplifierinator.ElectronicComponentsLib.Capacitor
'Imports Q = Amplifierinator.ElectronicComponentsLib.BJT

Module Amplifierinator

    Sub Main(args As String())
        'Dim testCEAmp = New UniversalBiased() With {.VCC = 24, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(22 * 10 ^ 3), .RC = 3300, .RE = 830, .beta = 200, .isNPN = True}
        'Dim testCBAmp = New CommonBase() With {.VCC = 24, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(22 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rGen = 50, .RL = 3300, .rSwamp = 0, .C1 = 100 * 10 ^ -6, .C2 = 10 * 10 ^ -6, .C3 = 10 * 10 ^ -6}
        'Dim testCEAmp = New CommonBase() With {.VCC = 24, .R1 = CInt(360 * 10 ^ 3), .R2 = CInt(56 * 10 ^ 3), .RC = 10000, .RE = 2200, .beta = 200, .isNPN = True, .rGen = 50, .RL = 10500, .rSwamp = 470, .C1 = 68 * 10 ^ -6, .C2 = 0.22 * 10 ^ -6, .C3 = 0.47 * 10 ^ -6}
        'Dim testCEAmp = New CommonCollector() With {.VCC = 9, .R1 = CInt(68000), .R2 = CInt(120000), .RC = 0, .RE = 32, .beta = 200 * 200, .isNPN = True, .rGen = 50, .RL = 8, .rSwamp = 16, .C1 = 68 * 10 ^ -6, .C2 = 0.22 * 10 ^ -6, .C3 = 0.47 * 10 ^ -6}
        'Dim testCEAmp = New CommonCollector() With {.VCC = 24, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(22 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rGen = 50, .RL = 8, .rSwamp = 0, .C1 = 100 * 10 ^ -6, .C2 = 10 * 10 ^ -6, .C3 = 10 * 10 ^ -6}
        'Dim testCEAmp = New CommonCollector() With {.VCC = 9, .R1 = CInt(3300), .R2 = CInt(4700), .RC = 0, .RE = 660, .beta = 200, .isNPN = True, .rGen = 50, .RL = 330, .rSwamp = 330, .C1 = 68 * 10 ^ -6, .C2 = 0.22 * 10 ^ -6, .C3 = 0.47 * 10 ^ -6}


        'Dim testCEAmp = New TestClass() With {.VCC = 30, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(18 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .rgen = 10000, .RL = 3300, .rSwamp = 150, .cIn = 0.22 * 10 ^ -6, .cOut = 0.47 * 10 ^ -6, .cBypass = 22 * 10 ^ -6}
        'Dim testCEAmp = New UniversalBiasCommonEmitter() With {.VCC = 30, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(18 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200}

        'Dim CEAmp = New UniversalBiasCommonEmitter() With {.VCC = 30, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(18 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .rgen = 10000, .RL = 3300, .rSwamp = 150, .cIn = 0.22 * 10 ^ -6, .cOut = 0.47 * 10 ^ -6, .cBypass = 22 * 10 ^ -6}
        'Dim CEAmp = New UniversalBiasCommonEmitter
        'Dim CEAmp = New Amplifier(30, 75000, 91000, 2200, 5100, 200, 10, 100)
        'Dim CEAmp = New Amplifier(30, 16000, 3300, 2200, 110, 200, 0, 2200, 50)
        'test(CEAmp)

        'Dim CBAmp = New UniversalBiasCommonBase() With {.VCC = 30, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(18 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rgen = 10000, .RL = 3300, .rSwamp = 150, .cIn = 0.22 * 10 ^ -6, .cOut = 0.47 * 10 ^ -6, .cBypass = 22 * 10 ^ -6}
        'test(CBAmp)
        'Dim CCAmp = New UniversalBiasCommonCollector() With {.VCC = 30, .R1 = CInt(120 * 10 ^ 3), .R2 = CInt(18 * 10 ^ 3), .RC = 3300, .RE = 820, .beta = 200, .isNPN = True, .rgen = 10000, .RL = 3300, .rSwamp = 150, .cIn = 0.22 * 10 ^ -6, .cOut = 0.47 * 10 ^ -6, .cBypass = 22 * 10 ^ -6}
        'test(CCAmp)
        Dim CEAmp = New Amplifier
        Console.WriteLine("Given:")
        Console.WriteLine($"VCC = {CEAmp.CommonEmitter.Universalbias.VCC}")
        Console.WriteLine($"Beta = {CEAmp.CommonEmitter.Universalbias.beta}")
        Console.WriteLine($"R1 = {CEAmp.CommonEmitter.Universalbias.R1}")
        Console.WriteLine($"R2 = {CEAmp.CommonEmitter.Universalbias.R2}")
        Console.WriteLine($"RC = {CEAmp.CommonEmitter.Universalbias.RC}")
        Console.WriteLine($"RE = {CEAmp.CommonEmitter.Universalbias.RE}")
        Console.WriteLine()
        Console.WriteLine("DC Summery:")
        'Console.WriteLine($"IB = {testCEAmp.UniversalBias.IB}")
        Console.WriteLine($"IB = {CEAmp.CommonEmitter.Universalbias.IB}")
        Console.WriteLine($"IC = {CEAmp.CommonEmitter.Universalbias.IC}")
        Console.WriteLine($"IE = {CEAmp.CommonEmitter.Universalbias.IE}")
        Console.WriteLine($"VRC = {CEAmp.CommonEmitter.Universalbias.VRC}")
        Console.WriteLine($"VCE = {CEAmp.CommonEmitter.Universalbias.VCE}")
        Console.WriteLine($"VRE = {CEAmp.CommonEmitter.Universalbias.VRE}")
        Console.WriteLine($"VR1 = {CEAmp.CommonEmitter.Universalbias.VR1}")
        Console.WriteLine($"VR2 = {CEAmp.CommonEmitter.Universalbias.VR2}")

        Console.WriteLine()

        Console.WriteLine("AC Summery:")
        Console.WriteLine($"RL = {CEAmp.CommonEmitter.RL}")
        Console.WriteLine($"Rswamp = {CEAmp.CommonEmitter.rSwamp}")
        Console.WriteLine($"Zin = {CEAmp.CommonEmitter.zin}")
        Console.WriteLine($"Zout = {CEAmp.CommonEmitter.Zout}")
        Console.WriteLine($"vout max = {CEAmp.CommonEmitter.vout}")
        Console.WriteLine($"Av = {CEAmp.CommonEmitter.Av}")
        Console.WriteLine($"AvdB = {CEAmp.CommonEmitter.AvdB}")
        Console.WriteLine($"Ai = {CEAmp.CommonEmitter.Ai}")
        Console.WriteLine($"AidB = {CEAmp.CommonEmitter.AidB}")
        Console.WriteLine($"Ap = {CEAmp.CommonEmitter.Ap}")
        Console.WriteLine($"ApdB = {CEAmp.CommonEmitter.ApdB}")
        Console.WriteLine()
        Console.WriteLine("Frequency Response Summery:")
        Console.WriteLine($"FcLow = {CEAmp.CommonEmitter.FcLow}")
        Console.WriteLine($"C1 = {CEAmp.CommonEmitter.cIn}")
        Console.WriteLine($"RthC1 = {CEAmp.CommonEmitter.RthCIn}")
        Console.WriteLine($"Fc1 = {CEAmp.CommonEmitter.Fcin}")
        Console.WriteLine($"Lowest C1 = {CEAmp.CommonEmitter.LowestCIn}")
        Console.WriteLine($"C2 = {CEAmp.CommonEmitter.cOut}")
        Console.WriteLine($"RthC2 = {CEAmp.CommonEmitter.RthCOut}")
        Console.WriteLine($"Fc2 = {CEAmp.CommonEmitter.FcOut}")
        Console.WriteLine($"Lowest C2 = {CEAmp.CommonEmitter.LowestCOut}")
        Console.WriteLine($"C3 = {CEAmp.CommonEmitter.cBypass}")
        Console.WriteLine($"RthC3 = {CEAmp.CommonEmitter.rthcbypass}")
        Console.WriteLine($"Fc3 = {CEAmp.CommonEmitter.fcbypass}")
        Console.WriteLine($"Lowest C3 = {CEAmp.CommonEmitter.lowestcbypass}")

        Console.Read()
    End Sub

    Sub test(ByRef Amp As Object)
        Console.WriteLine(StrDup(80, "-"))
        Console.WriteLine("Given:")
        Console.WriteLine($"VCC = {Amp.VCC}")
        Console.WriteLine($"Beta = {Amp.beta}")
        Console.WriteLine($"R1 = {Amp.R1}")
        Console.WriteLine($"R2 = {Amp.R2}")
        Console.WriteLine($"RC = {Amp.RC}")
        Console.WriteLine($"RE = {Amp.RE}")
        Console.WriteLine()
        Console.WriteLine("DC Summery:")
        'Console.WriteLine($"IB = {Amp.UniversalBias.IB}")
        Console.WriteLine($"IB = {Amp.IB}")
        Console.WriteLine($"IC = {Amp.IC}")
        Console.WriteLine($"IE = {Amp.IE}")
        Console.WriteLine($"VRC = {Amp.VRC}")
        Console.WriteLine($"VCE = {Amp.VCE}")
        Console.WriteLine($"VRE = {Amp.VRE}")
        Console.WriteLine($"VR1 = {Amp.VR1}")
        Console.WriteLine($"VR2 = {Amp.VR2}")

        Console.WriteLine()

        Console.WriteLine("AC Summery:")
        Console.WriteLine($"RL = {Amp.RL}")
        Console.WriteLine($"Rswamp = {Amp.rSwamp}")
        Console.WriteLine($"Zin = {Amp.zin}")
        Console.WriteLine($"Zout = {Amp.Zout}")
        Console.WriteLine($"vout max = {Amp.vout}")
        Console.WriteLine($"Av = {Amp.Av}")
        Console.WriteLine($"AvdB = {Amp.AvdB}")
        Console.WriteLine($"Ai = {Amp.Ai}")
        Console.WriteLine($"AidB = {Amp.AidB}")
        Console.WriteLine($"Ap = {Amp.Ap}")
        Console.WriteLine($"ApdB = {Amp.ApdB}")
        Console.WriteLine()
        Console.WriteLine("Frequency Response Summery:")
        Console.WriteLine($"FcLow = {Amp.fclow}")
        Console.WriteLine($"C1 = {Amp.cIn}")
        Console.WriteLine($"RthC1 = {Amp.RthCIn}")
        Console.WriteLine($"Fc1 = {Amp.Fcin}")
        Console.WriteLine($"Lowest C1 = {Amp.LowestCIn}")
        Console.WriteLine($"C2 = {Amp.cOut}")
        Console.WriteLine($"RthC2 = {Amp.RthCOut}")
        Console.WriteLine($"Fc2 = {Amp.FcOut}")
        Console.WriteLine($"Lowest C2 = {Amp.LowestCOut}")
        Try
            Console.WriteLine($"C3 = {Amp.cBypass}")
            Console.WriteLine($"RthC3 = {Amp.rthcbypass}")
            Console.WriteLine($"Fc3 = {Amp.fcbypass}")
            Console.WriteLine($"Lowest C3 = {Amp.lowestcbypass}")
        Catch
        End Try
    End Sub

End Module
