Public Class Form1
    Dim str As String() = {"I", "V", "X", "L", "C", "D", "M"}
    Dim num As String() = {1, 5, 10, 50, 100, 500, 1000}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(get_ans(j))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function get_ans(s As String)
        Dim chk As Integer = Integer.MaxValue, total As New Integer
        For Each i As String In s
            Dim t = num(Array.IndexOf(str, i))
            If chk < t Then
                total -= chk
                total += (t - chk)
            Else
                total += t
            End If
            chk = t
        Next
        Return total
    End Function
End Class
