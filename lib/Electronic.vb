'Imports System.Runtime.CompilerServices
Namespace Electronic

    Namespace Component
        Public Class Resistor
            'First two digits of a "standard" resistor list


            Public P As Decimal
            Public R As Decimal
            Public I As Decimal
            Public V As Decimal

            Sub New()

            End Sub

            'returns an array with "resisterCount number of random resistors.
            '    Function resistor(resistorCount As Integer) As Double()
            '        Dim commonResistors(23) As Double
            '        Dim multiplier As Double
            '        Dim e As Integer 'multiplier exponent
            '        Dim i As Integer 'common value index
            '        Dim Value As Double
            '        Dim currentResistor As Integer
            '        Dim resistorArray() As Double
            '        ReDim resistorArray(resistorCount - 1) As Double

            ''load common resistor values
            'commonResistors(0) = 1
            '        commonResistors(1) = 1.1
            '        commonResistors(2) = 1.2
            '        commonResistors(3) = 1.3
            '        commonResistors(4) = 1.5
            '        commonResistors(5) = 1.6
            '        commonResistors(6) = 1.8
            '        commonResistors(7) = 2
            '        commonResistors(8) = 2.2
            '        commonResistors(9) = 2.4
            '        commonResistors(10) = 2.7
            '        commonResistors(11) = 3
            '        commonResistors(12) = 3.3
            '        commonResistors(13) = 3.6
            '        commonResistors(14) = 3.9
            '        commonResistors(15) = 4.3
            '        commonResistors(16) = 4.7
            '        commonResistors(17) = 5.1
            '        commonResistors(18) = 5.6
            '        commonResistors(19) = 6.2
            '        commonResistors(20) = 6.8
            '        commonResistors(21) = 7.5
            '        commonResistors(22) = 8.2
            '        commonResistors(23) = 9.1

            '        Randomize(seedRnd) 'call Randomize function with timer as seed
            '        e = (5 * Rnd())  'random multiplier exponant between 0 and 5. doing this outside the loop makes it so all resistors will have the same multiplier.
            '        For currentResistor = 0 To resistorCount - 1
            '            Randomize(seedRnd) 'call Randomize function with timer as seed
            '            i = (23 * Rnd()) 'random common resistor index between 0 and 23
            '            resistorArray(currentResistor) = commonResistors(i) * 10 ^ e
            '        Next currentResistor

            '        resistor = resistorArray

            '    End Function

            Public Shared Function getCommonResistor(ByRef calculatedResistance As Double) As Integer
                Dim commonValue As Integer
                Dim digits As Double
                Dim firstTwoDigits As Integer
                Dim multiplier As Integer
                Dim standardValues = New Integer(23) {10, 11, 12, 13, 15, 16, 18, 20, 22, 24, 27, 30, 33, 36, 39, 43, 47, 51, 56, 62, 68, 75, 82, 91}

                If IsNumeric(calculatedResistance) Then
                    calculatedResistance = CInt(calculatedResistance)
                    firstTwoDigits = Left(CStr(calculatedResistance), 2)
                    'Console.WriteLine($"{calculatedResistance} splits to: {firstTwoDigits} | {Mid(calculatedResistance, 3)} so {firstTwoDigits}E{Len(Mid(calculatedResistance, 3))}")
                    For digits = UBound(standardValues) To 0 Step -1
                        If standardValues(digits) <= firstTwoDigits Then
                            firstTwoDigits = standardValues(digits)
                            Exit For
                        End If
                    Next
                    multiplier = Len(Mid(calculatedResistance, 3))
                    'Console.WriteLine($"{calculatedResistance} splits to: {firstTwoDigits} | {Mid(calculatedResistance, 3)} so {firstTwoDigits}E{Len(Mid(calculatedResistance, 3))}")
                    commonValue = CInt(firstTwoDigits & StrDup(multiplier, "0"))
                    'Console.WriteLine(commonValue)
                End If
                'Try
                '    For multiplier = 9 To 0 Step -1
                '        If 10 ^ multiplier <= calculatedResistance Then
                '            multiplier -= 1
                '            Exit For
                '        End If
                '    Next
                '    For digits = UBound(standardValues) To 0 Step -1
                '        If standardValues(digits) * 10 ^ multiplier <= calculatedResistance Then
                '            commonValue = standardValues(digits) * 10 ^ multiplier
                '            Exit For
                '        End If
                '    Next
                'Catch e As Exception
                '    Console.WriteLine(e.Message & vbNewLine & $"Calculated: {calculatedResistance}, Common Value: {commonValue}")
                'End Try
                Return commonValue
            End Function

        End Class

        Class Capacitor

        End Class

        Class Inductor

        End Class

        Class BJT

        End Class

    End Namespace

    Namespace Math

    End Namespace


End Namespace