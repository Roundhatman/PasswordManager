Module Krypton

    Private Symbols As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

    Public Function encryptText9b(ByVal str As String) As String
        On Error Resume Next
        Dim str9 As String = vbNullString

        For Each c As Char In str.ToCharArray
            Dim e As Int16 = 0
            Dim pl As Int16 = 1
            Dim k As Int16 = Asc(c)

            While (k > 0)
                e = e + (k Mod 9) * pl
                k = k \ 9
                pl = pl * 10
            End While
            str9 = str9 & Chr(e)
        Next c

        Return str9

    End Function

    Public Function decryptText9b(str9 As String) As String
        On Error Resume Next
        Dim str As String = vbNullString

        For Each e As Char In str9.ToCharArray
            Dim c As Int32 = 0
            Dim pl As Int32 = 0
            Dim k As Int32 = Asc(e)

            While k > 0
                c = c + (k Mod 10) * Math.Pow(9, pl)
                pl = pl + 1
                k = k \ 10
            End While

            str = str & Chr(c)
        Next e

        Return str
    End Function

    Public Function encryptTextKey(str As String, key As String) As String

        On Error Resume Next
        Dim keyPointer As Byte = 0
        Dim strOutput As String = vbNullString

        For Each symbol As Char In str

            If Not Symbols.IndexOf(symbol) = -1 Then

                Dim x As SByte = Symbols.IndexOf(key(keyPointer))
                Dim y As SByte = Symbols.IndexOf(symbol)
                Dim z As Char = vbNullChar

                If (y + x >= Symbols.Length) Then
                    z = Symbols(y + x - Symbols.Length)
                Else
                    z = Symbols(y + x)
                End If

                keyPointer = keyPointer + 1
                If keyPointer = key.Length Then keyPointer = 0

                strOutput = strOutput & z

            Else
                strOutput = strOutput & symbol
            End If
        Next

        Return strOutput

    End Function

    Public Function decryptTextKey(str As String, key As String) As String

        On Error Resume Next
        Dim keyPointer As Byte = 0
        Dim strOutput As String = vbNullString

        For Each symbol As Char In str

            If Not Symbols.IndexOf(symbol) = -1 Then
                Dim x As SByte = Symbols.IndexOf(key(keyPointer))
                Dim y As SByte = Symbols.IndexOf(symbol)
                Dim z As Char = vbNullChar

                If (y - x < 0) Then
                    z = Symbols(Symbols.Length + y - x)
                Else
                    z = Symbols(y - x)
                End If

                keyPointer = keyPointer + 1
                If keyPointer = key.Length Then keyPointer = 0

                strOutput = strOutput & z

            Else
                strOutput = strOutput & symbol
            End If

        Next

        Return strOutput

    End Function

End Module
