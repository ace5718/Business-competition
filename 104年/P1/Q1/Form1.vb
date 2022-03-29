Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim inp As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 2 To inp.Count - 1 Step 2
                Dim cost As New Integer
                Dim data As Integer() = inp(j).Split(",").Select(Function(x) CInt(x.ToString)).ToArray
                For k = 0 To data.Count - 2
                    cost += If(data(k) > data(k + 1), (data(k) - data(k + 1)) * 10, (data(k + 1) - data(k)) * 20)
                Next
                total.Add(cost)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class