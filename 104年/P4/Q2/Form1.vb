Public Class Form1
    Class node
        Public start, ending As String
        Public cost As Integer
        Public Sub New(a$, b$, c%)
            start = a : ending = b : cost = c
        End Sub
    End Class
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim sc As New List(Of node)
                For Each k In j.Split(" ")
                    sc.Add(New node(k.Split(",")(0), k.Split(",")(1), k.Split(",")(2)))
                    total.Add(kruskal(sc))
                Next
                sc = sc.OrderBy(Function(x) x.cost).ToList
            Next
        Next
    End Sub

    Function kruskal(sc As List(Of node))
        Dim s As New ArrayList, e As New ArrayList, total As New Integer
        s.Add(sc(0).start) : e.Add(sc(0).ending) : total += sc(0).cost
        For Each i In sc.Skip(1)
            If (s.Contains(i.start) Or e.Contains(i.start)) AndAlso (s.Contains(i.ending) Or e.Contains(i.ending)) Then Continue For
            s.Add(i.start) : e.Add(i.ending) : total += i.cost
        Next
        Return total
    End Function
End Class
