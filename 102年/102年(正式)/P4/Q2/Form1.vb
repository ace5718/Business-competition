Public Class Form1
    Dim h As New Dictionary(Of Integer, Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(get_card(j.Split(" ")))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function get_card(data As String())
        Dim c As New List(Of Point) : h.Clear()
        For Each d In data
            For i = 1 To 4
                For j = 1 To 13
                    d = Val(d) - 1 : If d = 0 Then c.Add(New Point(i, j))
                Next
            Next
        Next
        Return chk_7(c)
    End Function

    Function chk_7(c As List(Of Point))
        Dim chk As List(Of String) = {"1", "10", "11", "12", "13"}.ToList
        c = c.OrderBy(Function(x) x.X).ToList
        For i = 0 To c.Count - 1
            If c(0).X <> c(i).X Then Return chk_6(c) : chk.Remove(c(i).Y)
        Next
        If chk.Count <> 0 Then
            c = c.OrderBy(Function(x) x.Y).ToList
            For i = 0 To c.Count - 2
                If c(i + 1).Y - c(i).Y <> 1 Then Return chk_6(c)
            Next
        End If
        Return "同花順"
    End Function

    Function chk_6(c As List(Of Point))
        For Each i In c
            If h.ContainsKey(i.Y) Then h.Item(i.Y) += 1 Else h.Add(i.Y, 1)
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 4 Or a(1).Value <> 1 Then Return chk_5(c) Else Return "四條"
    End Function

    Function chk_5(c As List(Of Point))
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 3 Or a(1).Value <> 2 Then Return chk_4(c) Else Return "葫蘆"
    End Function

    Function chk_4(c As List(Of Point))
        Dim chk As List(Of String) = {"1", "10", "11", "12", "13"}.ToList
        For Each i In c : chk.Remove(i.Y) : Next
        If chk.Count <> 0 Then
            c = c.OrderBy(Function(x) x.Y).ToList
            For i = 0 To c.Count - 2
                If c(i + 1).Y - c(i).Y <> 1 Then Return chk_3(c)
            Next
        End If
        Return "順子"
    End Function

    Function chk_3(c As List(Of Point))
        If h.OrderByDescending(Function(x) x.Value)(0).Value <> 3 Then Return chk_2(c) Else Return "三條"
    End Function

    Function chk_2(c As List(Of Point))
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 2 Or a(1).Value <> 2 Then Return chk_1(c) Else Return "兩對"
    End Function

    Function chk_1(c As List(Of Point))
        If h.OrderByDescending(Function(x) x.Value)(0).Value <> 2 Then Return "雜牌" Else Return "一對"
    End Function
End Class
