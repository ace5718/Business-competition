Public Class Form1
    Class node
        Public leaf_node As New List(Of node)
        Public leaf, root As String
        Public Sub New(a As String, b As String)
            leaf = a : root = b
        End Sub
    End Class
    Dim sc As New List(Of node), temp As New List(Of Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As New List(Of String)
            Dim inp As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 1 To inp.Count
                If j <> inp.Count AndAlso inp(j) <> "" Then
                    data.Add(inp(j))
                Else
                    Dim ans = data(0).Split(",")(1)
                    data.RemoveAt(0)
                    total.Add(get_tree(data, ans))
                    data.Clear() : sc.Clear() : temp.Clear()
                End If
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function get_tree(data As List(Of String), ans As String)
        Dim chk As New ArrayList
        For Each i In data : sc.Add(New node(i.Split(",")(0), i.Split(",")(1))) : Next
        chk.Add((From x In sc Where x.root = 99 Select x.leaf).ToArray(0))

        While sc.Count <> 1
            For Each i In chk
                For Each j In sc
                    If i = j.root Then
                        For Each k In sc
                            If k.leaf = i Then
                                k.leaf_node.Add(j) : chk.Add(j.leaf)
                            Else
                                get_leaf(k.leaf_node, i, j)
                                chk.Add(j.leaf)
                            End If
                        Next
                        sc.Remove(j) : Continue While
                    End If
                Next
                chk.Remove(i) : Exit For
            Next
        End While
        get_ans(0, sc(0), ans - 1)
        Return temp.Sum
    End Function

    Sub get_ans(c As Integer, sc As node, cost As Integer)
        If c = cost Then
            temp.Add(sc.leaf_node.Count)
        Else
            For Each j In sc.leaf_node
                get_ans(c + 1, j, cost)
            Next
        End If
    End Sub


    Sub get_leaf(ln As List(Of node), r As Integer, j As node)
        For Each i In ln
            If i.leaf = r Then i.leaf_node.Add(j)
            If i.leaf_node.Count <> 0 Then get_leaf(i.leaf_node, r, j)
        Next
    End Sub
End Class
