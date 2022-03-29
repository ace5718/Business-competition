Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 2 To data.Count - 1
                Dim win As String() = data(1).Split(",")
                total.Add(ans(win, data(j).Split(",")))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function ans(win As String(), num As String())
        Dim ar() As Integer = {0, 0, 0, 0}
        For i = 0 To num.Count - 1
            Dim cost As New Integer
            For j = 0 To num.Count - 1
                If i <> j AndAlso Array.IndexOf(win, num(j)) <> -1 Then cost += 1
            Next
            If cost >= 2 Then ar(cost - 2) += 1
        Next
        Return Join(ar.Select(Function(x) CStr(x)).ToArray, ",")
    End Function
End Class
