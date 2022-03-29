Module Module1


    Sub Main()
        Console.Write("輸入字串：")
        Dim str As String = Console.ReadLine
        Console.WriteLine()
        Dim ans As String
        Dim a As New List(Of Integer)
        For Each i In str
            If IsNumeric(i) Then
                ans &= i
            Else
                Try
                    a.Add(ans)
                    ans = ""
                Catch ex As Exception
                End Try
            End If
        Next
        For i = 1 To a.Count - 1
            If i = a.Count - 1 Then
                ans &= a(i) & "=" & a.Sum
            Else
                ans &= a(i) & "+"
            End If
        Next
        Console.Write(ans)
        Console.Read()
    End Sub

End Module
