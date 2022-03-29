Public Class Form1
    Dim ans As New List(Of Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                ans.Clear() : sb("", j.Split(",")(0))
                ans = ans.OrderBy(Function(x) x).ToList
                My.Computer.FileSystem.WriteAllText("out.txt", ans(j.Split(",")(1) - 1) + ans(j.Split(",")(2) - 1) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Sub sb(a$, b$)
        If b = "" Then
            ans.Add(a)
        Else
            For i = 1 To b.Count
                sb(a & Mid(b, i, 1), b.Substring(0, i - 1) + b.Substring(i))
            Next
        End If
    End Sub
End Class
