Public Class Form1
    Dim a(4, 13) As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As String() = j.Split("-")
                total.Add(get_ans(data))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function get_ans1(a As List(Of Point))
        Dim ca As New List(Of Point)
        For Each i In a
            ca.Add(i)
        Next
        Dim cost As New Integer
        Dim tf As Boolean = False
        Do
            If cost > 21 Then Exit Do
            For Each j In ca
                If j.Y <> 1 Then
                    cost += If(j.Y > 10, 10, j.Y)
                    ca.Remove(j) : Continue Do
                End If
                If tf = True Then
                    If cost + 11 > 21 Then
                        cost += 1
                    Else
                        cost += 11
                    End If
                    ca.Remove(j) : Continue Do
                End If
            Next
            tf = True
        Loop Until ca.Count = 0
        Return If(cost > 21, "F", cost)
    End Function

    Function point(a As List(Of Point), b As List(Of Point))
        For Each j In b
            a.Add(j)
        Next
        Return chk_7(a)
    End Function
    Function chk_7(c As List(Of Point))
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
        Return "同花順"
    End Function
    Function chk_6(c As List(Of Point))
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 4 Or a(1).Value <> 1 Then Return chk_5(c) Else Return "四條"
    End Function
    Function chk_5(c As List(Of Point))
        Dim h As New Dictionary(Of Integer, Integer)
        For Each i In c
            If h.ContainsKey(i.Y) Then
                h.Item(i.Y) += 1
            Else
                h.Add(i.Y, 1)
            End If
        Next
        Dim a = h.OrderByDescending(Function(x) x.Value)
        If a(0).Value <> 3 Or a(1).Value <> 2 Then Return chk_4(c) Else Return "葫蘆"
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
        Return "順子"
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
        If a(0).Value <> 3 Then Return chk_2(c) Else Return "三條"
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
        If a(0).Value <> 2 Or a(1).Value <> 2 Then Return chk_1(c) Else Return "兩對"
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
        If a(0).Value <> 2 Then Return "雜牌" Else Return "一對"
    End Function

    Function get_ans(data As String())
        Dim a, b As New List(Of Point)
        For i = 1 To 2
            For Each j In data(i - 1).Split(" ")
                If j <> "" Then
                    For k = 1 To 4
                        For l = 1 To 13
                            j = Val(j) - 1
                            If j = 0 Then
                                If i = 1 Then
                                    a.Add(New Point(k, l))
                                Else
                                    b.Add(New Point(k, l))
                                End If
                            End If
                        Next
                    Next
                End If
            Next
        Next


        Return get_ans1(a) & "," & point(a, b)
    End Function
End Class
