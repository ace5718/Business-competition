Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim inp As String() = IO.File.ReadAllLines("in" & i & ".txt")
            Dim a, b As New Integer
            For j = 1 To inp.Count - 2
                If inp(j) <> "" Then
                    For Each k In inp(j).Split(" ")
                        If Regex.Replace(k, "\W", "").ToLower = inp(0).ToLower Then a += 1
                        b += 1
                    Next
                End If
            Next
            total.Add(a & "," & b)
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
