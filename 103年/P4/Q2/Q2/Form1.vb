Public Class Form1
    Dim ar As New ArrayList
    Dim ans As New ArrayList
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            Dim test As New ArrayList
            test.Add(My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").ToList)
            For j = 1 To Val(test(0)(0))
                ans.Clear()
                ar.Clear()

                For k = 2 To Val(test(0)(1)) + 1
                    Dim t As String = test(0)(2).Replace("   ", " ")
                    ar.Add(t.Replace("  ", " ").Split(" "))
                    test(0).RemoveAt(2)
                Next
                get_ans(test(0)(1).ToString.Split(",")(2), test(0)(1).ToString.Split(",")(2), 0, 1, test(0)(1).ToString.Split(",")(1))
                My.Computer.FileSystem.WriteAllText("out.txt", Join(ans.ToArray, ","), True)
                My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
                test(0).RemoveAt(1)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub
    Function get_ans(start%, move%, str%, tree%, max%)
        If move = 999 Then
            ans.Add(str - 1)
            Return get_ans(start, start, 0, tree + 1, max)
        ElseIf ans.Count < max And move <> 999 Then
            Return get_ans(start, ar(move)(tree), str + 1, tree, max)
        End If
    End Function
End Class
