Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim a As String = j.Split(",")(0)
                For k = 2 To Val(j.Split(",")(1))
                    a = s(a, j.Split(",")(0))
                Next
                My.Computer.FileSystem.WriteAllText("out.txt", a.Count & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Function s(a As String, b As String)
        Dim t() As Integer = a.PadLeft(b.Count, "0").Reverse.Select(Function(x) CInt(x.ToString)).ToArray
        Dim tt() As Integer = b.PadLeft(a.Count, "0").Reverse.Select(Function(x) CInt(x.ToString)).ToArray
        Dim ans(t.Count + tt.Count) As Integer
        For i = 0 To t.Count - 1
            For j = 0 To tt.Count - 1
                ans(i + j) += t(i) * tt(j)
                If ans(i + j) > 9 Then
                    ans(i + j + 1) += ans(i + j) \ 10
                    ans(i + j) = ans(i + j) Mod 10
                End If
            Next
        Next
        Dim str As String = ""
        For i = ans.Count - 1 To 0 Step -1
            If ans(i) <> 0 Then
                For j = i To 0 Step -1
                    str &= ans(j)
                Next
                Exit For
            End If
        Next
        Return str
    End Function
End Class
