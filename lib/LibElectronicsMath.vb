Public Class LibElectronicsMath

    Public Shared Function CriticalFrequency(ByRef R As Double, ByRef C As Double) As Decimal
        Return CDec((2 * Math.PI * R * C) ^ -1)
    End Function

    Public Shared Function Capacitance(ByRef Xc As Double, ByRef f As Double) As Double
        Return (2 * Math.PI * Xc * f) ^ -1
    End Function

    Public Function Xc(ByRef f As Double, ByRef C As Double) As Decimal
        Return CDec((2 * Math.PI * C * f) ^ -1)
    End Function

    Private Function CEngNotation(doubleValue As Double) As String
        'found this code at: http://mibifici.blogspot.com/2012/02/engineering-notation-in-vbavb6.html
        Dim x As Double    ' --- Original Double (Floating-point)
        Dim y As Double    ' --- Mantissa
        Dim n As Long      ' --- Exponent
        Dim str As String
        Dim sign As String
        On Error GoTo error_hander   ' --- uncomment for debug; disable when bug-free!
        x = doubleValue
        If x <> 0 Then
            If x < 0 Then
                ' --- x *must* be positive for log function to work
                x = x * -1
                sign = "-"    ' --- we need to preserve the sign for output string
            End If
            n = 3 * CLng((Math.Log10(x) / Math.Log10(1000)))   ' --- calculate Exponent...
            '     (Converts: log-base-e to log-base-10)
            y = x / (10 ^ n)                     ' --- calculate Mantissa.
            If y < 1 Then                        ' --- if Mantissa <1 then...
                n = n - 3                        ' --- ...adjust Exponent and...
                y = x / (10 ^ n)                 ' --- ...recalculate Mantissa.
            End If
            ' --- Create output string (special treatment when Exponent of zero; don't append "e")
            str = sign & y & CStr(If(n <> 0, "e" & CStr(If(n > 0, "+", "")) & n, ""))
        Else
            ' --- if the value is zero, well, return zero...
            str = "0"
        End If
        CEngNotation = str
        Exit Function
error_hander:
        ' --- this is really just for debugging suspected problems
        Resume Next
    End Function

    Private Function metricUnit(num As String) As String()
        'for some reason this can't be called with option explicit on
        Dim can() As String
        'Dim x
        On Error GoTo broke
        If InStr(num, "e") > 0 Then
            can = Split(num, "e")
            Select Case can(1)
                Case "+9"
                    can(1) = "G"
                'can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
                Case "+6"
                    can(1) = "M"
                'can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
                Case "+3"
                    can(1) = "k"
                'can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
                Case "-3"
                    can(1) = "m"
                'can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
                Case "-6"
                    can(1) = ChrW(&HB5)
                'can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
                Case "-9"
                    can(1) = "n"
                'can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
                Case "-12"
                    can(1) = "p"
                    ' can(0) = str(Round(CDbl(can(0)), 3)) 'Left(can(0), 5)
            End Select
        Else
            ReDim can(1)
            can(1) = ""
            can(0) = num
        End If
        can(0) = Trim(Str((CDbl(can(0)), 3)))
        metricUnit = can

        Exit Function
broke:
        'x = MsgBox(num, vbOKOnly Err.Description,,,)
        Resume Next
    End Function

    Public Function engFormat(num As Double) As String() 'returns number in engineering format
        engFormat = metricUnit(CEngNotation(num))
    End Function

    Public Function engFormatUnit(num As Double, baseUnit As String) As String 'returns number in engineering format with base unit
        engFormatUnit = metricUnit(CEngNotation(num))(0) & metricUnit(CEngNotation(num))(1) & baseUnit
    End Function

    Public Shared Function SolveSimultaneousEquation(ByVal a1@, ByVal b1@, ByVal k1@, ByVal a2@, ByVal b2@, ByVal k2@) As (aTermResult@, bTermResult@)
        Dim aTermResult@, bTermResult@, numerator@, denominator@
        Dim result = (aTermResult, bTermResult)
        denominator = (a1 * b2) - (b1 * a2)
        numerator = (k1 * b2) - (b1 * k2)
        result.aTermResult = (numerator / denominator)
        numerator = (a1 * k2) - (k1 * a2)
        result.bTermResult = (numerator / denominator)
        Return result
    End Function

End Class