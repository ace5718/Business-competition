Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out1.txt", "", False)
        Dim ar As New ArrayList
        Dim c As Object = CreateObject("scriptcontrol")
        c.language = "VBScript"
        For r = 1 To 2
            For Each i In My.Computer.FileSystem.ReadAllText("in" & r & ".txt").Replace(vbCrLf, "#").Split({"#"}, StringSplitOptions.RemoveEmptyEntries).Skip(1)
                Dim t As String() = i.Split("==")
                ar.Add(c.eval(t(0)) = c.eval(t(2)))
            Next
            For Each i In ar
                If i = "True" Then
                    My.Computer.FileSystem.WriteAllText("out1.txt", "T" & vbCrLf, True)
                ElseIf i = "False" Then
                    My.Computer.FileSystem.WriteAllText("out1.txt", "F" & vbCrLf, True)
                End If
            Next
            My.Computer.FileSystem.WriteAllText("out1.txt", vbCrLf, True)
            ar.Clear()
        Next
        Close()
    End Sub
End Class
