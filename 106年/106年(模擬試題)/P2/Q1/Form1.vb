Imports System.Text.RegularExpressions
Public Class Form1
    Dim n As Integer() = {10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33}
    Dim s As Integer() = {1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim result As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                If Regex.IsMatch(j, "^[A-Z][1|2]{1}[0-9]{8}$") Then
                    If chk((n(Asc(Mid(j, 1, 1)) - 65) & Mid(j, 2, j.Count)).Select(Function(x) x.ToString).ToArray) Then
                        result.Add("T")
                    Else
                        result.Add("F")
                    End If
                Else
                    result.Add("F")
                End If
            Next
            result.Add("")
        Next
        IO.File.WriteAllLines("out.txt", result.ToArray)
        Close()
    End Sub
    Function chk(str As String())
        Dim total As New Integer
        For i = 0 To s.Count - 1 : total += s(i) * Val(str(i)) : Next
        Return If(total Mod 10 = 0, True, False)
    End Function
End Class
