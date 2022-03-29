Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(get_ans(j.Split("/")(0), j.Split("/")(1)))
            Next
            total.Add("")
        Next
        Stop
        Close()
    End Sub
    Function get_ans(t1$, t2$)
        Dim ans As New ArrayList
        Dim a$() = con(t1.Split(".")), b$() = con(t2.Split("."))
        For i = 0 To a.Count - 1
            Dim str As String = ""
            For j = 1 To a(i).Count
                str &= Mid(a(i), j, 1) Or (If(Mid(b(i), j, 1) = 1, 0, 1))
            Next
            ans.Add(Convert.ToInt32(str, 2))
        Next
        Return Join(ans.ToArray, ".")
    End Function
    Function con(s$())
        Dim str As New List(Of String)
        For Each i In s
            str.Add(Convert.ToString(CInt(i), 2).PadLeft(8, "0"))
        Next
        Return str.ToArray
    End Function
End Class
