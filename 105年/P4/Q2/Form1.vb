Public Class Form1
    Class node
        Public lt, rt As node
        Public num As Integer
        Public Sub New(a As Integer)
            num = a
        End Sub
    End Class
    Dim sc As List(Of node)
    Dim cost As New List(Of Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim sel As String() = j.Split(",")
                sc = j.Split(",").Select(Function(x) New node(x)).ToList : cost.Clear()
                Do
                    sc = sc.OrderBy(Function(x) x.num).ToList
                    Dim t As node = New node(sc(0).num + sc(1).num)
                    t.lt = sc(1) : t.rt = sc(0)
                    sc.RemoveAt(1) : sc.RemoveAt(0)
                    sc.Add(t)
                Loop Until sc.Count = 1
                Huffman(sc(0), 0, sel.ToList)
                total.Add(Join(cost.Select(Function(x) CStr(x)).ToArray, ","))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Sub Huffman(t As node, c As Integer, s As List(Of String))
        If s.Count = 0 Then Exit Sub
        If s.Count > 0 AndAlso Not IsNothing(t.lt) Then Huffman(t.lt, c + 1, s)
        If s.Count > 0 AndAlso Not IsNothing(t.rt) Then Huffman(t.rt, c + 1, s)
        If s.Count > 0 AndAlso t.num = CInt(s(0)) Then
            cost.Add(c) : s.RemoveAt(0)
            Huffman(sc(0), 0, s)
        End If
    End Sub
End Class
