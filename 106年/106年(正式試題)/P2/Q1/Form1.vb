Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                If Regex.IsMatch(j, "[0-9]{16}$") Then
                    If chk(j) Then total.Add("T") Else total.Add("F")
                Else
                    total.Add("F")
                End If
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function chk(s As String)
        Dim total As New Integer
        For i = 0 To s.Count - 1
            If i = 0 Or i Mod 2 = 0 Then
                Dim c = Val(Mid(s, i + 1, 1)) * 2
                total += If(c >= 10, c - 9, c)
            Else
                total += Val(Mid(s, i + 1, 1))
            End If
        Next
        Return If(total Mod 10 = 0, True, False)
    End Function
End Class
