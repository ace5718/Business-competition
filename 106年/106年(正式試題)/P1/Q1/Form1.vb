Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(get_ans(j))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function get_ans(str As String)
        Dim total As New Integer
        For Each i In str.Replace(",", " ").Split(" ")
            For Each j In i
                If j = "s" Or j = "S" Then
                    total += 1 : Exit For
                End If
            Next
        Next
        Return total
    End Function
End Class
