Public Class FormView
    Dim isPlaying As Boolean = False
    Dim count As Long = 0

    Private Sub picStart_MouseLeave(sender As Object, e As EventArgs) Handles picStart.MouseLeave
        isPlaying = True
        TmrClock.Enabled = True
        count = 0
    End Sub

    Private Sub MazeWall_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter, Label2.MouseEnter, Label3.MouseEnter, Label9.MouseEnter, Label8.MouseEnter, Label7.MouseEnter, Label6.MouseEnter, Label5.MouseEnter, Label46.MouseEnter, Label45.MouseEnter, Label44.MouseEnter, Label43.MouseEnter, Label42.MouseEnter, Label41.MouseEnter, Label40.MouseEnter, Label4.MouseEnter, Label39.MouseEnter, Label38.MouseEnter, Label37.MouseEnter, Label36.MouseEnter, Label35.MouseEnter, Label34.MouseEnter, Label33.MouseEnter, Label32.MouseEnter, Label31.MouseEnter, Label30.MouseEnter, Label29.MouseEnter, Label28.MouseEnter, Label27.MouseEnter, Label26.MouseEnter, Label25.MouseEnter, Label24.MouseEnter, Label23.MouseEnter, Label22.MouseEnter, Label21.MouseEnter, Label20.MouseEnter, Label19.MouseEnter, Label18.MouseEnter, Label17.MouseEnter, Label16.MouseEnter, Label15.MouseEnter, Label14.MouseEnter, Label13.MouseEnter, Label12.MouseEnter, Label11.MouseEnter, Label10.MouseEnter
        SetGameState("You lose!!!:(")
    End Sub

    Private Sub picEnd_MouseEnter(sender As Object, e As EventArgs) Handles picEnd.MouseEnter
        SetGameState(String.Format("You win :) Your time: {0}", New DateTime(count * 10000000).ToString("HH:mm:ss")))
    End Sub

    Private Sub TmrClock_Tick(sender As Object, e As EventArgs) Handles TmrClock.Tick
        count += 1
        Label4.Text = New DateTime(count * 10000000).ToString("HH:mm:ss")
    End Sub

    Private Sub SetGameState(msg As String)
        If isPlaying Then
            isPlaying = False
            TmrClock.Enabled = False
            MessageBox.Show(msg)
        End If
    End Sub

End Class
