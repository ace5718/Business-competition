Public Class Form1
    Dim ar As New List(Of Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                ar.Clear() : ab("", j.Replace(",", ""))
                ar = ar.OrderByDescending(Function(x) x).ToList
                My.Computer.FileSystem.WriteAllText("out.txt", ar(1) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Sub ab(a$, b$)
        If b = "" Then
            ar.Add(a)
        Else
            For i = 1 To b.Count
                ab(a & Mid(b, i, 1), b.Substring(0, i - 1) + b.Substring(i))
            Next
        End If
    End Sub
End Class
