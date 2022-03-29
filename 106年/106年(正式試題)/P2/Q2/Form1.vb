Public Class Form1
    Dim ar As New List(Of Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                ar.Clear() : ab("", j.Split(",")(0))
                ar = ar.OrderBy(Function(x) x).ToList
                total.Add(get_ans(ar(j.Split(",")(1) - 1), ar(j.Split(",")(2) - 1)))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
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
    Function get_ans(t1$, t2$) As String
        Dim a As New Integer, b As New Integer
        For i = 1 To t1.Count
            If Mid(t1, i, 1) = Mid(t2, i, 1) Then
                a += 1
            Else
                If t1.IndexOf(Mid(t2, i, 1)) <> -1 Then b += 1
            End If
        Next
        Return a & "A" & b & "B"
    End Function
End Class
