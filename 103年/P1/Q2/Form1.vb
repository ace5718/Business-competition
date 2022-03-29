Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As Integer() = j.Split(",").Select(Function(k) CInt(k)).ToArray
                Dim x, y As New Integer
                x = data(0) / 2 : y = data(0) - x
                Dim cost As New Integer
                Do
                    cost = data(1) * x + data(2) * y
                    If cost <> data(3) Then
                        Select Case cost
                            Case > data(3)
                                x = If(data(1) > data(3), x - 1, x + 1)
                                y = If(data(3) > data(1), y - 1, y + 1)
                            Case < data(3)
                                x = If(data(1) > data(3), x + 1, x - 1)
                                y = If(data(3) > data(1), y + 1, y - 1)
                        End Select
                    End If
                Loop Until cost = data(3)
                total.Add(x & "," & y)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
