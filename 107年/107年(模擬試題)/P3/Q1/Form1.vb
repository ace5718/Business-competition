Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                My.Computer.FileSystem.WriteAllText("out.txt", answer(j) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Function answer(j As String)
        Return Union(j) & "," & intersection(j) & "," & Set_difference(j) & "," & Symmetric_difference(j)
    End Function
    Function Union(t As String)
        Dim h As New HashSet(Of String)
        For Each i In Regex.Replace(t, "\D", "")
            h.Add(i)
        Next
        h = h.OrderBy(Function(n) n).ToHashSet
        Return "{" & Join(h.ToArray, ",") & "}"
    End Function
    Function intersection(t As String)
        Dim c As New List(Of String), ar As New List(Of String)
        For Each i In Regex.Replace(t, "\D", "")
            If c.Contains(i) Then ar.Add(Val(i)) Else c.Add(i)
        Next
        ar = ar.OrderBy(Function(x) CInt(x)).ToList
        Return If(ar.Count > 0, "{" & Join(ar.ToArray, ",") & "}", "N")
    End Function
    Function Set_difference(t As String)
        Dim ar As New ArrayList, x As New ArrayList
        For i = 1 To t.Count
            Dim b As New ArrayList
            If Mid(t, i, 1) = "{" Then
                Do
                    If IsNumeric(Mid(t, i, 1)) Then b.Add(Mid(t, i, 1))
                    i += 1
                Loop Until Mid(t, i, 1) = "}"
                ar.Add(b.ToArray)
            End If
        Next
        For Each i As String In ar(0)
            If Array.IndexOf(ar(1), i) = -1 Then x.Add(i)
        Next
        Return If(x.Count > 0, "{" & Join(x.ToArray, ",") & "}", "N")
    End Function
    Function Symmetric_difference(t As String)
        Dim ar As New List(Of String)
        For Each i In Regex.Replace(t, "\D", "")
            If ar.Contains(i) Then ar.Remove(i) Else ar.Add(i)
        Next
        ar = ar.OrderBy(Function(x) x).ToList
        Return If(ar.Count > 0, "{" & Join(ar.ToArray, ",") & "}", "N")
    End Function
End Class
