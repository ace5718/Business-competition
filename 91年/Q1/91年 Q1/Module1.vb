Module Module1

    Sub Main()
        Console.Write("input")
        Dim t As Single = Console.ReadLine
        Select Case t
            Case < 50
                t = t * 1.5 + 20
            Case 50 To 100
                t = t * 2 + 20
            Case < 100
                t = t * 3 + 20
        End Select
        Console.Write(CSng(Format(t, "000.0")))
        Console.Read()
    End Sub

End Module
