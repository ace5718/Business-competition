Public Class Form1
    Dim str As String() = {"I", "V", "X", "L", "C", "D", "M"}
    Dim num As Integer() = {1, 5, 10, 50, 100, 500, 1000}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("In" & i & ".txt").Skip(1) '"in" & i & ".txt"
                Dim n As Integer() = get_number(j)
                total.Add(get_ans(n))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function get_number(n As String)
        Dim t As New List(Of Integer)
        For i = 1 To n.Count
            If Mid(n, i, 1) <> 0 Then t.Add(Mid(n, i, 1).PadRight(n.Count - (i - 1), "0"))
        Next
        Return t.Select(Function(x) CInt(x)).ToArray
    End Function

    Function get_ans(n As Integer())
        Dim ans As String = ""
        For Each i As String In n
            Select Case Mid(i, 1, 1)
                Case 9
                    ans &= str(Array.IndexOf(num, CInt("1".PadRight(i.Count, "0"))))
                    ans &= str(Array.IndexOf(num, CInt("1".PadRight(i.Count + 1, "0"))))
                Case 5 To 8
                    Dim s As String = str(Array.IndexOf(num, CInt("1".PadRight(i.Count, "0"))))
                    ans &= str(Array.IndexOf(num, CInt("5".PadRight(i.Count, "0"))))
                    For j = 1 To Val(Mid(i, 1, 1) - 5) : ans &= s : Next
                Case 4
                    ans &= str(Array.IndexOf(num, CInt("1".PadRight(i.Count, "0"))))
                    ans &= str(Array.IndexOf(num, CInt("5".PadRight(i.Count, "0"))))
                Case 1 To 3
                    Dim a As Integer = Val(i) / Val(Mid(i, 1, 1))
                    Dim s As String = str(Array.IndexOf(num, a))
                    For j = 1 To Val(Mid(i, 1, 1)) : ans &= s : Next

            End Select
        Next
        Return ans
    End Function
End Class
