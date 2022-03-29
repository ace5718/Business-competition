Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                My.Computer.FileSystem.WriteAllText("out.txt", change(Val(j)) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Function change(t As Decimal) As String
        Dim ans As String = ""
        Dim a As Integer = Val(t.ToString.Split(".")(0)), b As Decimal = Val("0." & t.ToString.Split(".")(1))
        Do Until b = 0 Or ans.Count >= 5
            b *= 2
            If b >= 1 Then b -= 1 : ans &= 1 Else ans &= 0
        Loop
        Return Convert.ToString(a, 2) & "." & ans.PadRight(5, "0")
    End Function
End Class
