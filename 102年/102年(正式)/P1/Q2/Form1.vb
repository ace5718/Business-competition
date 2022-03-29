Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim inp As String() = IO.File.ReadAllLines("in" & i & ".txt")
            Dim data As New List(Of String)
            For j = 1 To inp.Count
                If j <= inp.Count - 1 AndAlso inp(j) <> "" Then
                    data.Add(inp(j))
                Else
                    total.Add(get_ans(data.ToArray))
                    data.Clear()
                End If
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function get_ans(data As String())
        Dim dic As New Dictionary(Of String, Integer)
        Dim ans As New List(Of String)
        Dim num As New Integer
        For Each i In data.Skip(1)
            For Each j In i.Replace(" ", "").Split(",")
                If dic.ContainsKey(j) Then dic.Item(j) += 1 Else dic.Add(j, 1)
            Next
        Next
        For Each i In dic.OrderByDescending(Function(x) x.Value)
            If i.Value >= num Then
                ans.Add(i.Key) : num = i.Value
            Else
                Return Join(ans.ToArray, ",")
            End If
        Next
        Return Nothing
    End Function
End Class
