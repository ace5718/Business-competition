Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "%").Split("%").Skip(1)
                Dim total, total2 As New Integer
                For Each k In Regex.Replace(j, "\W", " ").Split(" ")
                    If k.IndexOf("s") <> -1 Or k.IndexOf("S") <> -1 Then total += 1
                    If k <> "" Then total2 += 1
                Next
                My.Computer.FileSystem.WriteAllText("out.txt", total2 & "," & total & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
End Class
