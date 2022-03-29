Public Class Form1
    Class node
        Public lt, rt As node
        Public num As Integer
        Public Sub New(a As Integer)
            num = a
        End Sub
    End Class
    Dim sc As New List(Of node), pos As New ArrayList
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim inp As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 2 To inp.Count - 1 Step 2
                Dim data As List(Of Integer) = inp(j).Split(",").Select(Function(x) CInt(x)).ToList
                sc.Clear() : pos.Clear()
                sc.Add(New node(data(0))) : data.RemoveAt(0)
                Btree(sc(0), data) : Postfix(sc(0))
                total.Add(Join(pos.ToArray, ","))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Sub Btree(t As node, data As List(Of Integer))
        If data.Count = 0 Then Exit Sub
        If data.Count > 0 AndAlso data(0) < t.num Then
            If IsNothing(t.lt) Then
                t.lt = New node(data(0)) : data.RemoveAt(0)
            Else
                Btree(t.lt, data)
            End If
        ElseIf data.Count > 0 AndAlso data(0) > t.num Then
            If IsNothing(t.rt) Then
                t.rt = New node(data(0)) : data.RemoveAt(0)
            Else
                Btree(t.rt, data)
            End If
        End If
        Btree(sc(0), data)
    End Sub

    Sub Postfix(t As node)
        If Not IsNothing(t.lt) Then Postfix(t.lt)
        If Not IsNothing(t.rt) Then Postfix(t.rt)
        pos.Add(t.num)
    End Sub
End Class
