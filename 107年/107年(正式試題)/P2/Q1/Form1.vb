Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim num As Integer = j, tf As Boolean, cheek As New ArrayList
                Do
                    Dim a As New Integer
                    For Each k In num.ToString
                        a += Val(k) ^ 2
                    Next
                    If Array.IndexOf(cheek.ToArray, a) <> -1 Then Exit Do
                    If a = 1 Then tf = True : Exit Do Else cheek.Add(a) : num = a : tf = False
                Loop Until num = j
                My.Computer.FileSystem.WriteAllText("out.txt", If(tf = True, "T", "F") & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
End Class
