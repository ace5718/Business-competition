Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim inp As String() = IO.File.ReadAllLines("in" & i & ".txt")
            Dim dic As New Dictionary(Of String, Integer)
            For j = 0 To inp.Count - 2
                If inp(j) <> "" Then
                    For Each k In inp(j).Split(" ")
                        If dic.ContainsKey(k.ToLower) Then
                            dic.Item(k.ToLower) += 1
                        Else
                            dic.Add(k.ToLower, 1)
                        End If
                    Next
                End If
            Next
            Dim a = dic.OrderByDescending(Function(x) x.Value).ToArray
            total.Add(a(0).Value & "," & a(1).Value & "," & a(2).Value)
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
