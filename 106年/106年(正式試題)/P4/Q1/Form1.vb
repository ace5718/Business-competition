Public Class Form1
    Dim ans As String = Nothing
    Dim chk As New HashSet(Of String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As New List(Of String)
        For i = 1 To 2
            For Each j In IO.File.ReadAllLines("in" & i & ".txt").Skip(1)
                Dim t = (From x In j.Split() From y In x.Split(",") Group x.Split(",")(If(y = x.Split(",")(0), 1, 0)) By p = y Into Group).ToArray
                ans = Nothing : chk.Clear()
                dfs(t, t(0).p, "")
                If IsNothing(ans) Then
                    total.Add(If(chk.Count = t.Count, "T", "F"))
                Else
                    total.Add(Join((From x In ans Order By Val(x) Select CStr(x)).ToArray, ","))
                End If
            Next
            total.Add("")
        Next
        IO.File.WriteAllLines("out.txt", total.ToArray)
        Close()
    End Sub
    Sub dfs(ar As Array, f As String, str As String)
        chk.Add(f)
        For Each i In ar
            If i.p = f Then
                For Each j In i.group
                    If str.Count = 0 Then GoTo 1
                    If Mid(str, str.Count, 1) <> j Then
1:
                        If str.Contains(j) Then
                            ans = Mid(str, str.IndexOf(j) + 1) & f
                        Else
                            dfs(ar, j, str & f)
                        End If
                    End If
                Next
            End If
        Next
    End Sub
End Class
