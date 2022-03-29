Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            Dim str() As String = My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!")
            For j = 1 To str.Count - 1 Step 2
                Dim a As String = str(j), b As New Integer
                For Each k In str(j + 1)
                    If Array.IndexOf(a.ToArray, k) <> -1 Then b += 1
                Next
                My.Computer.FileSystem.WriteAllText("out.txt", b & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
End Class
