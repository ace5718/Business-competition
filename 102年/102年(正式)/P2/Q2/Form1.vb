Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim ans As New List(Of Integer)
                sb("", j.Replace(" ", "").Split(",")(0), ans)
                ans = ans.OrderBy(Function(x) x).ToList
                total.Add(GCD(ans(j.Replace(" ", "").Split(",")(1) - 1), ans(j.Replace(" ", "").Split(",")(2) - 1)))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Sub sb(a$, b$, ans As List(Of Integer))
        If b = "" Then
            ans.Add(CInt(a))
        Else
            For i = 1 To b.Count
                sb(a & Mid(b, i, 1), b.Substring(0, i - 1) + b.Substring(i), ans)
            Next
        End If
    End Sub

    Function GCD(a%, b%)
        If a Mod b = 0 Then
            Return b
        Else
            Return GCD(b, a Mod b)
        End If
    End Function
End Class
