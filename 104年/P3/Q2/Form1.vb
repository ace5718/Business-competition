Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim data As List(Of String) = IO.File.ReadAllLines("in" & i & ".txt").ToList : data.RemoveAt(0)
            Do Until data.Count = 0
                Dim m, r, n As Integer
                m = data(0).Split(",")(0)
                r = data(0).Split(",")(1)
                n = data(0).Split(",")(3)
                data.RemoveAt(0)
                total.Add(sort(data, m - 1, n - 1, r - 1))
            Loop
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function sort(data As List(Of String), m%, n%, r%)
        Dim A(,) As Integer = get_A(m, r, data)
        Dim B(,) As Integer = get_B(n, r, data)
        Dim AB(,) As Integer = get_AB(m, n, data)

        For i = 0 To m
            For j = 0 To n
                Dim an, bn As New List(Of Integer) : get_an_bn(A, B, i, r, j, an, bn)
                Dim x As New Integer, c%
                If Array.IndexOf(an.ToArray, 9999) <> -1 Or Array.IndexOf(bn.ToArray, 9999) <> -1 Then
                    For k = 0 To an.Count - 1
                        If an(k) = 9999 Or bn(k) = 9999 Then
                            c = If(an(k) = 9999, bn(k), an(k))
                        Else
                            x += an(k) * bn(k)
                        End If
                    Next
                    If c <> 0 Then Return (AB(i, j) - x) / c
                End If
            Next
        Next
        Return 0
    End Function


    Sub get_an_bn(a As Integer(,), b As Integer(,), m%, r%, n%, an As List(Of Integer), bn As List(Of Integer))
        For i = 0 To r : an.Add(a(m, i)) : bn.Add(b(i, n)) : Next
    End Sub

    Function get_A(m%, r%, data As List(Of String))
        Dim a(m, r) As Integer
        For i = 0 To m
            Dim t As List(Of Integer) = Regex.Replace(data(0), "\s+", ",").Split(",").Select(Function(x) CInt(x)).ToList : data.RemoveAt(0)
            For j = 0 To r : a(i, j) = t(0) : t.RemoveAt(0) : Next
        Next
        Return a
    End Function
    Function get_B(n%, r%, data As List(Of String))
        Dim b(r, n) As Integer
        For i = 0 To r
            Dim t As List(Of Integer) = Regex.Replace(data(0), "\s+", ",").Split(",").Select(Function(x) CInt(x)).ToList : data.RemoveAt(0)
            For j = 0 To n : b(i, j) = t(0) : t.RemoveAt(0) : Next
        Next
        Return b
    End Function
    Function get_AB(m%, n%, data As List(Of String))
        Dim ab(m, n) As Integer
        For i = 0 To m
            Dim t As List(Of Integer) = Regex.Replace(data(0), "\s+", ",").Split(",").Select(Function(x) CInt(x)).ToList : data.RemoveAt(0)
            For j = 0 To n : ab(i, j) = t(0) : t.RemoveAt(0) : Next
        Next
        Return ab
    End Function
End Class
