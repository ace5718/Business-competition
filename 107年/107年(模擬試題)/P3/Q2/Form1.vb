Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim a As Integer = j.Split(",")(0), b As Integer = j.Split(",")(1)
                Dim c = a - If(a > 0, (b * CInt(a \ b)), (b * Math.Floor(a / b)))
                My.Computer.FileSystem.WriteAllText("out.txt", c & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
End Class
