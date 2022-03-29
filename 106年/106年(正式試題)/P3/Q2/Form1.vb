Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim t = j.Replace(" ", "").Split(",")
                total.Add(get_ans(t))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function get_ans(t As String())
        Dim ar As List(Of String) = t.ToList, arr As New List(Of String)
        Do
            Dim max As String = 0
            For i = 0 To ar.Count - 1
                If Array.IndexOf(arr.ToArray, ar(i)) <> -1 Then
                    Continue For
                Else
                    max = chk(max, ar(i))
                End If
            Next
            arr.Add(max)
        Loop Until arr.Count = ar.Count
        ar.Clear() : arr.Reverse()
        For Each i In t
            ar.Add(Array.IndexOf(arr.ToArray, i) + 1)
        Next
        Return Join(ar.ToArray, ",")
    End Function
    Function chk(a$, b$)
        Select Case a.Count
            Case > b.Count : Return a
            Case < b.Count : Return b
            Case = b.Count
                For i = 1 To a.Count
                    If Mid(a, i, 1) > Mid(b, i, 1) Then Return a
                Next
                Return b
        End Select
        Return 0
    End Function
End Class
