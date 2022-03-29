Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim coust As String = j
                Do
                    Dim s As New Integer
                    For Each k In coust
                        s += Val(k)
                    Next
                    coust = s
                Loop Until coust.ToString.Count = 1
                total.Add(coust)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
