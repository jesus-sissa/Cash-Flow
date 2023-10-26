Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Cajascxn

Public Class frm_Depositar

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub


    Private Sub frm_Depositar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 22
        If Not varPub.ManejaDepositoManual Then
            btn_DepositoManual.Enabled = False
        End If
        Call CambiarTamanodelosControles()
    End Sub

    Private Sub gbx_CorteDiario_Click(sender As Object, e As EventArgs) Handles gbx_CorteDiario.Click
        varPub.SegundosSesion = 0
    End Sub


    Private Sub btn_DepositoXvalidador_Click(sender As Object, e As EventArgs) Handles btn_DepositoXvalidador.Click
        'Depositar por Validador
        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITAR POR VALIDADOR", "ABRIR VENTANA")
        'Dim frm As New frm_DepositoXvalidador
        varPub.EsDepositoNormal = True
        If varPub.ValidarFolio Then
            varPub.Dt_Cajascnx = fn_CajasConsultarCnx()
        End If
        Dim frm As New frm_DepositoXvalidador
        frm.ShowDialog()
        varPub.EsDepositoNormal = False
        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITAR POR VALIDADOR", "CERRAR VENTANA")
    End Sub

    Private Sub btn_DepositoManual_Click(sender As Object, e As EventArgs) Handles btn_DepositoManual.Click
        'Depositar Manual(Buzón)
        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITO MANUAL", "ABRIR VENTANA")
        Dim frm As New frm_DepositoManual
        frm.ShowDialog()
        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITO MANUAL", "CERRAR VENTANA")

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.IdPantalla = 33
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub gbx_CorteDiario_Enter(sender As Object, e As EventArgs) Handles gbx_CorteDiario.Enter

    End Sub
End Class