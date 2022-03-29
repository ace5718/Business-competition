Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt").ToArray
            For j = 1 To data.Count - 1 Step 2
                total.Add(LCS((From x In data(j) Select CStr(x)).ToArray, (From x In data(j + 1) Select CStr(x)).ToArray))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function LCS(x As Array, y As Array)
        Dim c(x.Length, y.Length) As Integer
        For i = 1 To x.Length
            For j = 1 To y.Length
                If x(i - 1) = y(j - 1) Then
                    c(i, j) = c(i - 1, j - 1) + 1
                Else
                    c(i, j) = Math.Max(c(i, j - 1), c(i - 1, j))
                End If
            Next
        Next
        Return c(x.Length, y.Length)
    End Function
End Class
