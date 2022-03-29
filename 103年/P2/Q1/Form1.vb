Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 1 To data.Count - 1 Step 2
                Dim a$ = data(j), b$ = data(j + 1)
                Dim ans = Join((From x In b Select If(a.IndexOf(x) <> -1, Asc(x), Nothing)).ToHashSet.OrderBy(Function(x) Chr(x)).Select(Function(x) If(x <> 0, Chr(x).ToString, "")).ToArray, "")
                total.Add(If(ans = "", "N", ans))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
