Public Class Form1
    Dim ans As New List(Of String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                ans.Clear()
                Dim str() As String = j.Split(","), t As String = ""
                For k = 1 To str.Count - 2
                    t &= str(k)
                Next
                Sort("", t)
                ans = ans.OrderBy(Function(n) n).ToList
                My.Computer.FileSystem.WriteAllText("out.txt", ans(str(str.Count - 1) - 1) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Sub Sort(a$, b$)
        If b = "" Then
            ans.Add(a)
        Else
            For i = 1 To b.Count
                Sort(a & Mid(b, i, 1), b.Substring(0, i - 1) & b.Substring(i))
            Next
        End If
    End Sub
End Class
