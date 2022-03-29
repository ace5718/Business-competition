Public Class Form1
    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 1 To data.Count - 1 Step 2
                Dim a As String() = data(j).Split(" "), b As String() = data(j + 1).Split(" ")
                total.Add((From x In b Where Array.IndexOf(a, x) <> -1).ToHashSet.Count)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
