Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 1 To data.Count - 1
                Dim t As Integer = (From x In data(j).Replace(" ", "").Split(",") Where Array.IndexOf((data(0).Replace(" ", "$").Replace(",", "").Split("$")).ToArray, CStr(x)) <> -1).Count
                total.Add(If(t <= 1, "N", t))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
