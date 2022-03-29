Public Class Form1
    Dim str As String() = {"A", "B", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Dim num As String() = {"00", "01", "100", "101", "1100", "1101", "11100", "11101", "111100", "111101", "111110", "111111"}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim ans As New List(Of String)
                Dim s As String = ""
                Dim temp As New ArrayList
                For Each k In j
                    s &= k
                    If Array.IndexOf(num, s) <> -1 Then
                        ans.Add(str(Array.IndexOf(num, s)))
                        If ans.Count = 4 Then temp.Add(Join(ans.ToArray, "")) : ans.Clear()
                        s = ""
                    End If
                Next
                If ans.Count <> 0 Then temp.Add(Join(ans.ToArray, ""))
                total.Add(Join(temp.ToArray, ","))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
