Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                If (Prime(j.Split(",")(0)) And Prime(j.Split(",")(1))) AndAlso Math.Abs(CInt(j.Split(",")(0)) - CInt(j.Split(",")(1))) = 2 Then
                    total.Add("Y")
                Else
                    total.Add("N")
                End If
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub

    Function Prime(num As Integer)
        For i = 2 To (num / 2)
            If num Mod i = 0 Then Return False
        Next
        Return True
    End Function
End Class
