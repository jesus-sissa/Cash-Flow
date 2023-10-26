Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class Frm_CortePorDia
    Public saldo As Integer
    Private Sub Frm_CortePorDia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 21
        If varPub.ManejaCorte = 0 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "SALDO", "ABRIR VENTANA")
            Dim frm As New frm_ConsultaSaldos
            frm.Ventana = 0
            frm.ShowDialog()
        End If

    End Sub

    Private Sub btn_DiaActual_Click(sender As Object, e As EventArgs) Handles btn_CortePorDia.Click

        Call fn_EscribirLog(varPub.UsuarioClave, "SALDO", "ABRIR VENTANA")
        Dim frm As New frm_ConsultaSaldos
        frm.Ventana = 1
        frm.ShowDialog()

    End Sub

    Private Sub btn_DiaActualCompleto_Click(sender As Object, e As EventArgs) Handles btn_Saldo.Click

        Call fn_EscribirLog(varPub.UsuarioClave, "SALDO", "ABRIR VENTANA")
        Dim frm As New frm_ConsultaSaldos

        frm.Ventana = 0
        frm.ShowDialog()
    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub
End Class