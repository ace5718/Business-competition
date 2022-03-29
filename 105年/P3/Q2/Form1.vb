Public Class Form1
    Class node
        Public lt, rt As node, num As Integer, cheek As Boolean
        Public Sub New(a As Integer)
            num = a
        End Sub
    End Class
    Dim sc As New List(Of node), a As List(Of String)
    Dim P_oder As New List(Of String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As String() = IO.File.ReadAllLines("in" & i & ".txt")
            For j = 1 To data.Count - 1 Step 2
                sc.Clear() : P_oder.Clear()
                a = data(j).Split(",").ToList
                Dim b As String() = data(j + 1).Split(",")
                sc.Add(New node(b(0)))
                tree(b, sc(0), 0, 1, b(1))
                Postorder(sc(0))
                total.Add(Join(P_oder.ToArray, ","))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Sub Postorder(t As node)
s:
        If P_oder.Count = a.Count Then Exit Sub
        If chk_post(t) Or (IsNothing(t.lt) And IsNothing(t.rt)) Then
            P_oder.Add(t.num) : t.cheek = True
        Else
            Postorder(If(Not IsNothing(t.lt) AndAlso t.lt.cheek = False, t.lt, t.rt))
            If chk_post(t) = False Then
                GoTo s
            Else
                P_oder.Add(t.num) : t.cheek = True
            End If
        End If
    End Sub
    Function chk_post(t As node)
        If Not IsNothing(t.lt) AndAlso t.lt.cheek <> True Then Return False
        If Not IsNothing(t.rt) AndAlso t.rt.cheek <> True Then Return False
        Return True
    End Function


    Sub tree(b As String(), t As node, n As Integer, bn As Integer, bs As String)
        If chk_tree(t.num, bs) Then
            If IsNothing(t.lt) Then
                t.lt = New node(bs)
                If bn + 1 >= b.Count Then Exit Sub Else tree(b, sc(0), 0, bn + 1, b(bn + 1))
            Else
                tree(b, t.lt, n + 1, bn, bs)
            End If
        Else
            If IsNothing(t.rt) Then
                t.rt = New node(bs)
                If bn + 1 >= b.Count Then Exit Sub Else tree(b, sc(0), 0, bn + 1, b(bn + 1))
            Else
                tree(b, t.rt, n + 1, bn, bs)
            End If
        End If
    End Sub
    Function chk_tree(t As String, tt As String)
        Return Array.IndexOf(a.ToArray, t) > Array.IndexOf(a.ToArray, tt)
    End Function
End Class
