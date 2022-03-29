Public Class Form1
    Class node
        Public num As String, inp As String
        Public Sub New(a As String, b As String)
            num = a : inp = b
        End Sub
    End Class
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        For i = 1 To 2
            For Each j In My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1)
                Dim str() As String = j.Replace("[", "").Replace("]", "").Split(",")
                My.Computer.FileSystem.WriteAllText("out.txt", "[" & get_ans(str) & "]" & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
        Close()
    End Sub

    Function get_ans(s As String())
        Dim str As New List(Of String), ans As New ArrayList
        Dim sc As New List(Of node)
        For i = 0 To s.Count - 1 : sc.Add(New node(i + 1, s(i))) : Next
        Dim chk As String = sc(0).inp
        str.Add(sc(0).num) : sc.RemoveAt(0)
        Do
            For i = 0 To sc.Count - 1
                If chk = sc(i).num Or chk = Nothing Then
                    str.Add(sc(i).num)
                    chk = sc(i).inp
                    sc.RemoveAt(i)
                    Continue Do
                End If
            Next
            ans.Add("[" & Join(str.ToArray, ",") & "]")
            str.Clear()
            chk = Nothing
        Loop Until sc.Count = 0 And str.Count = 0
        Return Join(ans.ToArray, ",")
    End Function
End Class
