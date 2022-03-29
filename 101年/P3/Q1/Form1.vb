Imports System.Text.RegularExpressions
Public Class Form1
    Dim num As Integer() = {10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33}
    Dim n As Integer() = {1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            Dim temp As Integer() = {0, 0, 0}
            Dim dic As New Dictionary(Of String, Integer)
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                If Regex.IsMatch(j, "^\p{Lu}[1-2]{1}\d{8}$") Then
                    Dim str = (From x In j Select If(IsNumeric(x), x, (From y In num(Asc(x) - 65).ToString Select y).Select(Function(z) CInt(z.ToString)).ToArray)).ToArray
                    If ans(str) Then
                        If dic.ContainsKey(j) Then
                            temp(1) += 1
                        Else
                            dic.Add(j, 1) : temp(0) += 1
                        End If
                    Else
                        temp(2) += 1
                    End If
                Else
                    temp(2) += 1
                End If
            Next
            total.Add(Join(temp.Select(Function(x) CStr(x)).ToArray, ","))
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function ans(str As Array)
        Dim c As New Integer, cost As New Integer
        For Each i In str
            Try
                For Each j In i
                    cost += j * n(c) : c += 1
                Next
            Catch ex As Exception
                cost += Val(i) * n(c) : c += 1
            End Try
        Next
        Return cost Mod 10 = 0
    End Function
End Class

