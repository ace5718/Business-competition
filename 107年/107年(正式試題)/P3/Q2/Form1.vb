Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim data() As String = j.Split(" ")
                My.Computer.FileSystem.WriteAllText("out.txt", cheek(data) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Function cheek(data As String())
        Dim count As New Integer
        For i = Val(data(0)) To Val(data(1))
            For j = Val(data(2)) To Val(data(3))
                For k = Val(data(4)) To Val(data(5))
                    If modulo((i + j), k) = modulo((i - j), k) Then count += 1
                Next
            Next
        Next
        Return count
    End Function
    Function modulo(a As Integer, b As Integer)
        If a = 0 Then Return 0
        If a >= b Then Return a Mod b
        Dim s As Integer = 1
        Do Until b * s <= a
            s -= 1
        Loop
        Return -(b * s - a)
    End Function
End Class
