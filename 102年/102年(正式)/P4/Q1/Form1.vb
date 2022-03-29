Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As String = j.Replace("-", "")
                total.Add(If(data.Count = 10, If(ISBN10(data), "T", "F"), If(ISBN13(data), "T", "F")))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function ISBN10(str As String)
        Dim total As New Integer
        For i = 1 To 9
            total += Mid(str, i, 1) * (10 - (i - 1))
        Next
        total = 11 - (total Mod 11)
        If total = 10 Then
            Return Mid(str, str.Count, 1) = "X"
        ElseIf total = 11 Then
            Return Mid(str, str.Count, 1) = 0
        Else
            Return Mid(str, str.Count, 1) = total
        End If
    End Function

    Function ISBN13(str As String)
        Dim total As New Integer
        For i = 1 To 12
            If i Mod 2 = 0 Then total += Mid(str, i, 1) * 3 Else total += Mid(str, i, 1)
        Next
        total = If(10 - (total Mod 10) = 10, 0, 10 - (total Mod 10))
        Return Mid(str, str.Count, 1) = total
    End Function
End Class
