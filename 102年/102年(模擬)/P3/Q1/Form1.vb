Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As Integer() = j.Split(",").Select(Function(x) CInt(x)).ToArray
                total.Add(get_ans(data(0)) & "," & GCD(data(0), data(1)))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function get_ans(num As Integer)
        Dim dic As New Dictionary(Of Integer, Integer)
        Dim ar As New ArrayList
        Dim n As Integer = 2
        Do
            If num Mod n = 0 Then
                If dic.ContainsKey(n) Then
                    dic.Item(n) += 1
                Else
                    dic.Add(n, 1)
                End If
                num = num / n
            Else
                n += 1
            End If
        Loop Until num = 1

        For Each i In dic
            ar.Add(i.Key & If(i.Value >= 2, "^" & i.Value, ""))
        Next
        Return Join(ar.ToArray, "*")
    End Function

    Function GCD(a As Integer, b As Integer)
        If a Mod b = 0 Then
            Return b
        Else
            Return GCD(b, a Mod b)
        End If
    End Function
End Class

