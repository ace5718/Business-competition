Module Module1
    Sub Main()
        Dim ar, arr As New ArrayList
        Dim num As New Integer
        For i = 1 To 2
            ar.Add(My.Computer.FileSystem.ReadAllText("in" & i & ".txt").Replace(vbCrLf, "!").Split("!").Skip(1))
            For Each j In ar(i - 1)
                j.ToString.Split(",")
                My.Computer.FileSystem.WriteAllText("out1.txt", get_ans(j(0).ToString, j(2).ToString), True)
            Next
        Next

        Stop
    End Sub
    Function get_ans(a As String, b As String) As String
        Select Case a
            Case "Y"
                Select Case b
                    Case "Y"
                        Return 0 & vbCrLf
                    Case "O"
                        Return 2 & vbCrLf
                    Case "P"
                        Return 1 & vbCrLf
                End Select
            Case "O"
                Select Case b
                    Case "Y"
                        Return 1 & vbCrLf
                    Case "O"
                        Return 0 & vbCrLf
                    Case "P"
                        Return 2 & vbCrLf
                End Select
            Case "P"
                Select Case b
                    Case "Y"
                        Return 2 & vbCrLf
                    Case "O"
                        Return 1 & vbCrLf
                    Case "P"
                        Return 0 & vbCrLf
                End Select
        End Select


    End Function
End Module
'
