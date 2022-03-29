Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(get_ans(j.Replace(" ", "").Replace("{", "").Replace("}", "").Split(",")))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function get_ans(data As String())
        Return "{" & Join(data.ToHashSet.ToArray, ",") & "}" & "," & b(data) & "," & c(data) & "," & d(data)
    End Function

    Function b(data As String())
        Dim dic As New Dictionary(Of String, Integer)
        Dim ans As New List(Of String)
        For Each i In data
            If dic.ContainsKey(i) Then dic.Item(i) += 1 Else dic.Add(i, 1)
        Next
        For Each i In dic.OrderByDescending(Function(x) x.Value)
            If i.Value > 1 Then ans.Add(i.Key)
        Next
        Return If(ans.Count = 0, "N", "{" & Join(ans.OrderBy(Function(x) CInt(x)).ToArray, ",") & "}")
    End Function
    Function c(data As String())
        Dim a As New List(Of String)
        For i = 0 To data.Count / 2 - 1 : a.Add(data(i)) : Next
        For i = data.Count / 2 To data.Count - 1 : a.Remove(data(i)) : Next
        Return If(a.Count = 0, "N", "{" & Join(a.OrderBy(Function(x) CInt(x)).ToArray, ",") & "}")
    End Function

    Function d(data As String())
        Dim ans As New List(Of String)
        For Each i In data
            If ans.Contains(i) Then
                ans.Remove(i)
            Else
                ans.Add(i)
            End If
        Next
        Return If(ans.Count = 0, "N", "{" & Join(ans.OrderBy(Function(x) CInt(x)).ToArray, ",") & "}")
    End Function
End Class
