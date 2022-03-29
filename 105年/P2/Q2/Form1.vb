Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As Integer() = j.Split(",").Select(Function(x) CInt(x)).ToArray
                Dim ans As New List(Of Integer)
                For k = 0 To data.Count - 1
                    For l = k + 1 To data.Count - 1
                        ans.Add(GCD(data(k), data(l)))
                    Next
                Next
                total.Add(ans.Max)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function GCD(a%, b%)
        If a Mod b = 0 Then Return b Else Return GCD(b, a Mod b)
    End Function
End Class
