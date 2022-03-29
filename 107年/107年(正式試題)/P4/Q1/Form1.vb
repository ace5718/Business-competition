Public Class Form1
    Dim ar As New ArrayList
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ans As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As List(Of String) = j.Replace("[", "").Replace("]", "").Split(",").ToList

                ar.Clear()
                Dim sc As node = get_tree(data)
                Dim total As New List(Of Integer)
                Dim cost As New Integer
                get_long(sc.lt, 1, total)
                If total.Max <> 0 Then cost += total.Max : total.Clear()

                get_long(sc.rt, 1, total)
                If Not IsNothing(total) Then cost += total.Max : total.Clear()

                ans.Add(cost)
            Next
            ans.Add("")
        Next
        IO.File.WriteAllLines("out.txt", ans.ToArray)
        Close()
    End Sub

    Sub get_long(sc As node, cost As Integer, ByRef total As List(Of Integer))
        If Not IsNothing(sc.lt) AndAlso sc.lt.str <> "null" Then get_long(sc.lt, cost + 1, total)

        If Not IsNothing(sc.rt) AndAlso sc.rt.str <> "null" Then get_long(sc.rt, cost + 1, total)

        If ((IsNothing(sc.lt) OrElse sc.lt.str = "null") And (IsNothing(sc.rt) OrElse sc.rt.str = "null")) Then total.Add(If(sc.str <> "null", cost, 0))
    End Sub

    Class node
        Public str As String
        Public lt, rt As node
        Public Sub New(a As String)
            str = a
        End Sub
    End Class


    Function get_tree(data As List(Of String)) As node
        Dim cost As New Integer, num As Integer = 2 ^ cost
        Dim sc As New List(Of node)

        Do Until data.Count = 0
            If sc.Count = num Then
                ar.Add(sc.ToArray.Clone) : sc.Clear()
                cost += 1 : num = 2 ^ cost
            Else
                sc.Add(New node(data(0))) : data.RemoveAt(0)
            End If
        Loop

        If sc.Count <> 0 Then ar.Add(sc.ToArray.Clone)
        For i = ar.Count - 2 To 0 Step -1
            Dim count As New Integer
            For Each j In ar(i)
                If count < ar(i + 1).length Then CType(j, node).lt = ar(i + 1)(count) : count += 1
                If count < ar(i + 1).length Then CType(j, node).rt = ar(i + 1)(count) : count += 1
            Next
        Next
        Return ar(0)(0)
    End Function
End Class
