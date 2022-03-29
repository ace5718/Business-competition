Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim data As String() = j.Split("/")
                total.Add(get_ans(data))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function get_ans(data())
        Dim str As New List(Of String)
        Dim ans As String = ""
        Dim s As New List(Of String)
        For Each i In data : str.Add(conv(i)) : Next
        For i = 1 To str(0).Count
            If Mid(str(0), i, 1) <> "." Then
                ans &= Mid(str(0), i, 1) And Mid(str(1), i, 1)
            Else
                s.Add(Convert.ToInt16(ans, 2))
                ans = ""
            End If
        Next
        s.Add(Convert.ToInt16(ans, 2))
        Return Join(s.ToArray, ".")
    End Function
    Function conv(s As String)
        Dim str As New List(Of String)
        For Each i In s.Split(".") : str.Add(Convert.ToString(CInt(i), 2).PadLeft(8, "0")) : Next
        Return Join(str.ToArray, ".")
    End Function
End Class
