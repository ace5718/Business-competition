﻿Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(j.Split(" ").Count)
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
