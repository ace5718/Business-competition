Public Class Form1
    Dim num As String() = {"00", "01", "100", "101", "1100", "1101", "11100", "11101", "111100", "111101"}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim str As String = ""
                Dim snum As String = ""
                For Each k In j
                    str &= k
                    Dim ind As Integer = Array.IndexOf(num, str)
                    If ind <> -1 Then snum &= ind : str = ""
                Next
                total.Add(Chr(If((65 + CInt(snum) + 2) > 90, (65 + CInt(snum) + 2) - 26, (65 + CInt(snum) + 2))))
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
End Class
