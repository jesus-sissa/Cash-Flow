Public Class frm_Mensaje

    Private Sub frm_Mensaje_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_Mensaje_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_Mensaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        varPub.SegundosSesion = 0
        varPub.Resp = True
        Me.Close()
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub lbl_Mensaje_Click(sender As Object, e As EventArgs) Handles lbl_Mensaje.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub frm_Mensaje_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub pct_Icono_Click(sender As Object, e As EventArgs) Handles pct_Icono.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub tmr_Mensaje_Tick(sender As Object, e As EventArgs) Handles tmr_Mensaje.Tick
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        Me.Close()
    End Sub
End Class