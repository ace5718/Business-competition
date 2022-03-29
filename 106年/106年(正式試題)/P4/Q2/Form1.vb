Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                total.Add(conv(j))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Function conv(str As String) As String
        Dim num$ = "", s As New Stack
        For Each i In str
            Select Case i
                Case "+", "-", "*", "/", "^"
                    Dim a$ = s.Pop, b$ = s.Pop
                    Dim co As Object = CreateObject("scriptcontrol")
                    co.language = "vbscript"
                    s.Push(co.eval(b & i & a))
                Case " "
                    If num <> "" Then s.Push(num) : num = ""
                Case Else
                    num &= i
            End Select
        Next
        Return s(0)
    End Function
End Class
