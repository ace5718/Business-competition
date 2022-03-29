Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            Dim str() As String = My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!")
            For j = 1 To str.Count - 1 Step 3
                My.Computer.FileSystem.WriteAllText("out.txt", cheek(str(j) & str(j + 1) & str(j + 2)) & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Function cheek(str$)
        Dim map(2, 2) As Integer
        Dim x, y As New Integer
        For Each i In str
            map(y, x) = Val(i)
            If x = 2 Then x = 0 : y += 1 Else x += 1
        Next
        For i = 0 To 2
            If map(i, 0) = map(i, 1) AndAlso map(i, 1) = map(i, 2) AndAlso map(i, 0) <> 0 Then Return map(i, 0)
            If map(0, i) = map(1, i) AndAlso map(1, i) = map(2, i) AndAlso map(0, i) <> 0 Then Return map(0, i)
        Next
        If map(0, 0) = map(1, 1) AndAlso map(1, 1) = map(2, 2) AndAlso map(0, 0) <> 0 Then Return map(0, 0)
        If map(2, 0) = map(1, 1) AndAlso map(1, 1) = map(0, 2) AndAlso map(2, 0) <> 0 Then Return map(3, 0)
        Return 3
    End Function
End Class
