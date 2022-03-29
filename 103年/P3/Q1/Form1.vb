Imports System.Text.RegularExpressions
Public Class Form1
    Dim total_cards(3, 12) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As Integer() = Regex.Replace(j, "\s+", ",").Split(",").Select(Function(x) CInt(x)).ToArray
                Dim ans As New List(Of Integer)
                For k = 0 To data.Count - 1
                    Dim cards As New List(Of Point)
                    Dim t As New List(Of Integer)
                    For l = 0 To data.Count - 1
                        If k <> l Then t.Add(data(l))
                    Next
                    get_cards(cards, t.ToArray)
                    ans.Add(point(cards))
                Next
                total.Add(ans.OrderByDescending(Function(x) x).ToArray(0))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function point(c As List(Of Point))
        Return chk_7(c)
    End Function

    Function chk_7(c As List(Of Point)) As Integer
        c = c.OrderBy(Function(x) x.X).ToList
        If c(0).X <> c(c.Count - 1).X Then Return chk_6(c)
        c = c.OrderBy(Function(x) x.Y).ToList
        For i = 0 To c.Count - 2
            If c(i).Y <> 12 Then
                If c(i + 1).Y - c(i).Y <> 1 Then Return chk_6(c)
            Else
                If c(i + 1).Y <> 0 Then Return chk_6(c)
            End If
        Next
        Return 7
    End Function

    Function chk_6(c As List(Of Point)) As Integer
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 4 Or a(1).Value <> 1 Then Return chk_5(c) Else Return 6
    End Function

    Function chk_5(c As List(Of Point)) As Integer
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 3 Or a(1).Value <> 2 Then Return chk_4(c) Else Return 5
    End Function

    Function chk_4(c As List(Of Point))
        c = c.OrderBy(Function(x) x.Y).ToList
        For i = 0 To c.Count - 2
            If c(i).Y <> 12 Then
                If c(i + 1).Y - c(i).Y <> 1 Then Return chk_3(c)
            Else
                If c(i + 1).Y <> 0 Then Return chk_3(c)
            End If
        Next
        Return 4
    End Function

    Function chk_3(c As List(Of Point))
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 3 Then Return chk_2(c) Else Return 3
    End Function

    Function chk_2(c As List(Of Point))
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 2 Or a(1).Value <> 2 Then Return chk_1(c) Else Return 2
    End Function

    Function chk_1(c As List(Of Point))
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 2 Then Return 0 Else Return 1
    End Function

    Sub get_cards(cards As List(Of Point), data As Integer())
        For Each i As Integer In data
            For j = 0 To 3
                For k = 0 To 12
                    i -= 1
                    If i = 0 Then cards.Add(New Point(j, k))
                Next
            Next
        Next
    End Sub
End Class
