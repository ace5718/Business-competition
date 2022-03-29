Public Class Form1
    Class node
        Public lt, rt As node
        Public num As Integer, chk As Boolean
        Public Sub New(a As Integer)
            num = a
        End Sub
    End Class
    Dim sc As New List(Of node)
    Dim bc As Boolean = True, hc As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                sc.Clear() : bc = True : hc = True
                Dim data As List(Of String) = j.Split(",").ToList
                sc.Add(New node(data(0))) : data.RemoveAt(0)
                get_tree(data, sc(0))
                total.Add(chk())
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Sub get_tree(data As List(Of String), t As node)
        If data.Count = 0 Then Exit Sub
        If t.chk = False Then
            t.lt = New node(data(0))
            data.RemoveAt(0)
            If data.Count > 0 Then
                t.rt = New node(data(0))
                data.RemoveAt(0)
            End If
            t.chk = True
            get_tree(data, sc(0))
        Else
            If t.lt.chk And t.rt.chk Then
                get_tree(data, t.lt)
            Else
                get_tree(data, If(t.lt.chk = False, t.lt, t.rt))
            End If
        End If
    End Sub

    Function chk()
        If chk_Btree() Then Return "B"
        If chk_Htree() Then Return "H"
        Return "F"
    End Function

    Function chk_Htree()
        Min_Htree(sc(0))
        If hc Then Return True Else hc = True
        Max_Htree(sc(0))
        Return If(hc, True, False)
    End Function
    Sub Min_Htree(t As node)
        If Not IsNothing(t.lt) AndAlso (t.lt.num < t.num) Then hc = False : Exit Sub
        If Not IsNothing(t.rt) AndAlso (t.rt.num < t.num) Then hc = False : Exit Sub
        If hc = True Then
            If Not IsNothing(t.lt) Then Min_Htree(t.lt)
            If Not IsNothing(t.rt) Then Min_Htree(t.rt)
        End If
    End Sub
    Sub Max_Htree(t As node)
        If Not IsNothing(t.lt) AndAlso (t.lt.num > t.num) Then hc = False : Exit Sub
        If Not IsNothing(t.rt) AndAlso (t.rt.num > t.num) Then hc = False : Exit Sub
        If hc = True Then
            If Not IsNothing(t.lt) Then Max_Htree(t.lt)
            If Not IsNothing(t.rt) Then Max_Htree(t.rt)
        End If
    End Sub

    Function chk_Btree()
        If sc(0).num > sc(0).lt.num Then Btree_lt(sc(0).lt, sc(0).num) Else Return False
        If sc(0).num < sc(0).rt.num Then Btree_rt(sc(0).rt, sc(0).num) Else Return False
        If bc = False Then Return False
        Return True
    End Function
    Sub Btree_lt(t As node, sc1 As Integer)
        If Not IsNothing(t.lt) AndAlso (t.lt.num > t.num Or t.lt.num > sc1) Then bc = False : Exit Sub
        If Not IsNothing(t.rt) AndAlso (t.rt.num < t.num Or t.rt.num > sc1) Then bc = False : Exit Sub
        If bc = True Then
            If Not IsNothing(t.lt) Then Btree_lt(t.lt, sc(0).num)
            If Not IsNothing(t.rt) Then Btree_lt(t.rt, sc(0).num)
        End If
    End Sub
    Sub Btree_rt(t As node, sc1 As Integer)
        If Not IsNothing(t.lt) AndAlso (t.lt.num > t.num Or t.lt.num < sc1) Then bc = False : Exit Sub
        If Not IsNothing(t.rt) AndAlso (t.rt.num < t.num Or t.rt.num < sc1) Then bc = False : Exit Sub
        If bc = True Then
            If Not IsNothing(t.lt) Then Btree_rt(t.lt, sc(0).num)
            If Not IsNothing(t.rt) Then Btree_rt(t.rt, sc(0).num)
        End If
    End Sub


End Class
