Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim t = (From x As String In j Where IsNumeric(x)).ToHashSet
                total.Add(If(t.Count = 0, "N", Join(t.OrderBy(Function(x) CInt(x)).ToArray, "")))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
