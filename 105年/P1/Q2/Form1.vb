Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim str As String = ""
                For Each k In j.Split(" ")
                    str &= chk(k)
                Next
                total.Add(str)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function chk(s As String)
        If s.IndexOf(".") = -1 Then
            Return 0
        ElseIf s.IndexOf("-") = -1 Then
            Return 5
        ElseIf Mid(s, 1, 1) = "." Then
            Dim count As New Integer
            For Each i In s
                If i = "." Then count += 1 Else Return count
            Next
        ElseIf Mid(s, s.Count, 1) = "." Then
            Dim count As Integer = 10
            For Each i In StrReverse(s)
                If i = "." Then count -= 1 Else Return count
            Next
        End If
    End Function
End Class
