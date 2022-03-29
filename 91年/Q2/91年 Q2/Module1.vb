Module Module1

    Sub Main()
        Dim m As Single
        Console.WriteLine("1 表示日間，2 表示夜間 ")
        Console.WriteLine()
        Console.Write("時間：")
        Dim t As Integer = Console.ReadLine
        Console.WriteLine()
        Console.Write("里程：")
        Dim s As Single = Console.ReadLine
        Select Case t
            Case 1
                If s > 1 Then
                    For i = 1.5 To s Step 0.5
                        m += 5
                    Next
                    m += 70
                Else
                    m = 0
                End If
            Case 2
                If s > 1 Then
                    For i = 1.5 To s Step 0.5
                        m += 8
                    Next
                    m += 85
                End If
        End Select
        Console.WriteLine()
        Console.Write(m)
        Console.Read()
    End Sub

End Module
