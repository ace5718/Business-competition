Public Class Form1
    Class node
        Public leaf_node As New List(Of node)
        Public root, leaf As Integer
        Public Sub New(a As Integer, b As Integer)
            root = a : leaf = b
        End Sub
    End Class
    Dim sc As New List(Of node)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As New List(Of String)
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                If j <> "" Then
                    data.Add(j)
                Else
                    data.RemoveAt(0)
                    total.Add(tree(data))
                    total.Add("")
                    data.Clear() : sc.Clear()
                End If
            Next
            total.ToArray()
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function tree(data As List(Of String))
        Dim rt As New List(Of Integer)
        For Each i In data : sc.Add(New node(i.Split(",")(1), i.Split(",")(0))) : Next
        rt.Add((From x In sc Where x.root = 99 Select x.leaf).ToArray(0))

        While sc.Count <> 1
            For Each i In rt
                For Each j In sc
                    If i = j.root Then
                        For Each k In sc
                            If k.leaf = i Then
                                k.leaf_node.Add(j) : rt.Add(j.leaf)
                            ElseIf k.leaf_node.Count <> 0 Then
                                get_leaf(k.leaf_node, i, j) : rt.Add(j.leaf)
                            End If
                        Next
                        sc.Remove(j) : Continue While
                    End If
                Next
                rt.Remove(i) : Exit For
            Next
        End While

        Dim ans As New List(Of String)
        Dim temp As New List(Of String)
        search(sc(0), ans, temp, sc(0).leaf)
        Return Join(ans.ToArray, vbCrLf)
    End Function


    Sub search(t As node, ans As List(Of String), temp As List(Of String), st As Integer)
        If t.leaf_node.Count = 0 Then
            If temp.Count = 0 Then
                ans.Add("N")
            Else
                ans.Add(t.leaf & ":{" & Join(temp.ToArray.Reverse().ToArray, ",") & "}")
            End If
        Else
            For Each i In t.leaf_node
                If st <> t.leaf Then temp.Add(t.leaf)
                search(i, ans, temp, st)
                If temp.Count > 0 Then temp.RemoveAt(temp.Count - 1)
            Next
        End If
    End Sub

    Sub get_leaf(ln As List(Of node), r As Integer, j As node)
        For Each i In ln
            If i.leaf = r Then i.leaf_node.Add(j)
            If i.leaf_node.Count <> 0 Then get_leaf(i.leaf_node, r, j)
        Next
    End Sub


    Sub test()
        Dim th As New ArrayList
        For i = 1 To 10
            th.Add(i)
        Next
        System.Threading.Thread.Sleep(1000)
    End Sub
End Class