Imports System.Text.RegularExpressions
Public Class Form1
    Dim str As Integer() = {10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33}
    Dim num As Integer() = {1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                If Regex.IsMatch(j, "^\p{Lu}[1|2]{1}\d{8}$") Then
                    Dim t As String() = j.Select(Function(x) x.ToString).ToArray : t(0) = str(Asc(t(0)) - 65)
                    Dim s As New Integer
                    Dim ss As String = Join(t.ToArray, "")
                    For k = 0 To ss.Count - 1
                        s += CInt(Mid(ss, k + 1, 1)) * num(k)
                    Next
                    total.Add(If(s Mod 10 = 0, "T", "F"))
                End If
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
