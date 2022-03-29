Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data = (From x In j.Split(",") Select Regex.Replace(x, "\D", ""))
                total.Add(U(data.ToArray) & "," & Inter(data.ToArray) & "," & S(data.ToList))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function U(data As String())
        Return "{" & Join(data.OrderBy(Function(x) Val(x.ToString)).ToHashSet.ToArray, ",") & "}"
    End Function

    Function Inter(data As String())
        Dim dic As New Dictionary(Of String, Integer)
        For Each I In data
            If dic.ContainsKey(I) Then dic.Item(I) += 1 Else dic.Add(I, 1)
        Next
        Dim t = Join((From x In dic Where x.Value > 1).Select(Function(x) x.Key).ToArray, ",")
        Return If(t = "", "N", "{" & t & "}")
    End Function

    Function S(data As List(Of String))
        Dim a, b As New List(Of String)
        For i = 0 To data.Count - 1
            If i < data.Count / 2 Then a.Add(data(i)) Else b.Add(data(i))
        Next
        For Each i In b
            If Array.IndexOf(a.ToArray, i) <> -1 Then a.Remove(i)
        Next
        Return If(a.Count = 0, "N", "{" & Join(a.ToArray, ",") & "}")
    End Function
End Class

