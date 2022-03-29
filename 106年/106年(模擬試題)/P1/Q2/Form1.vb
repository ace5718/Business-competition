Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 1 To data.Count - 1 Step 2
                str.Add(get_ans(data(j), data(j + 1)))
            Next
            str.Add("")
        Next
        IO.File.WriteAllLines("out.txt", str.ToArray)
        Close()
    End Sub
    Function get_ans(p$, q$)
        Dim count As New List(Of Integer), s As Integer
        If p.Count > q.Count Then
            p = Mid(p, 1, Len(q))
        Else
            q = StrReverse(Mid(StrReverse(q), 1, Len(p)))
        End If
        Do
S:
            For i = 1 To q.Count
                If Mid(p, 1, i) = Mid(q, 1, i) Then
                    s += 1
                Else
                    count.Add(s)
                    q = StrReverse(Mid(StrReverse(q), 1, q.Count - 1))
                    GoTo S
                End If
            Next
            Return s
        Loop Until p.Count = 0
        Return count.Max
    End Function
End Class
