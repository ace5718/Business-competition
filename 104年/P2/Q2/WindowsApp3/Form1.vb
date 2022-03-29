Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim num As New List(Of Integer)
        Dim v As String = ""
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim test As New Integer
                Dim ans As New List(Of Integer)
                num = j.Split(",").Select(Function(x) CInt(x)).ToList
                For k = 0 To num.Count - 1
                    Dim t = GCD(num(k), num(If(k + 1 >= num.Count, k + 1 - num.Count, k + 1)))
                    If cheek(t, num) Then ans.Add(t)
                Next
                v &= ans.OrderBy(Function(x) x).ToList(0) & vbCrLf
            Next
            v &= vbCrLf
        Next
        My.Computer.FileSystem.WriteAllText("out.txt", v, False)
        Close()
    End Sub
    Function GCD(a%, b%)
        If a Mod b = 0 Then Return b Else Return GCD(b, a Mod b)
    End Function
    Function cheek(a%, b As List(Of Integer)) As Boolean
        For Each i In b
            If i Mod a <> 0 Then Return False
        Next
        Return True
    End Function
End Class
