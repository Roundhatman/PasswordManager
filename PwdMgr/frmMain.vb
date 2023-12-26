Public Class frmMain

    Private fileName As String = Application.StartupPath & "\data.bin"
    Private encryptedFile As String = vbNullString
    Private decryptedFile As String = vbNullString

    Private Sub firstBoot()

        Dim key As String = InputBox("Key")
        decryptedFile = "lakmilaswarnajith@gmail.com" & vbTab & "!AlphaOnetoGM"
        encryptedFile = encryptText9b(encryptTextKey(decryptedFile, key))
        Using writer As New IO.StreamWriter(fileName)
            writer.Write(encryptedFile)
        End Using
        End

    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'firstBoot()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Using writer As New IO.StreamWriter(fileName)
            writer.Write(encryptText9b(encryptTextKey(txtBody.Text, txtKey.Text)))
        End Using

    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click

        Using reader As New IO.StreamReader(fileName)
            encryptedFile = reader.ReadToEnd
        End Using

        txtBody.Text = decryptTextKey(decryptText9b(encryptedFile), txtKey.Text)
    End Sub
End Class
