Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        Dim test As New ArrayList
        Dim t As New List(Of Integer)
        Dim tt As Integer
        For i = 1 To 2
            test.Clear()
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim ans As String
                Dim n As Integer = 1
                t.Clear()
                Do
                    n += 1
                    If f(n) <= j Then t.Add(f(n)) Else Exit Do
                Loop
                tt = j
                ans = ""
                For l = t.Count - 1 To 0 Step -1
                    If t(l) <= tt Then
                        tt -= t(l) : ans &= 1
                    Else
                        ans &= 0
                    End If
                Next
                test.Add(j & "=" & ans)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", Join(test.ToArray, vbCrLf) & vbCrLf, True)
        Next
        Close()
    End Sub
    Function f(n%)
        If n <= 1 Then
            Return n
        Else
            Return f(n - 1) + f(n - 2)
        End If
    End Function
End Class
