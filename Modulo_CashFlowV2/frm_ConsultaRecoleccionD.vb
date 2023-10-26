Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_ConsultaRecoleccionD

    Private Sub CambiarTamanodelosControles()
        cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub frm_ConsultaRecoleccionD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 17

        varPub.SegundosSesion = 0
        Dim AnchoColumna As Integer = (lsv_RecoleccionD.Width / 6)
        Call CambiarTamanodelosControles()

        lsv_RecoleccionD.Columns(0).Width = AnchoColumna
        lsv_RecoleccionD.Columns(1).Width = AnchoColumna
        lsv_RecoleccionD.Columns(2).Width = AnchoColumna
        lsv_RecoleccionD.Columns(3).Width = AnchoColumna

    End Sub

    Private Sub lbl_SubTotalValidado_Click(sender As Object, e As EventArgs) Handles lbl_SubTotalValidado.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub pnl_RecoleccionD_Paint(sender As Object, e As PaintEventArgs) Handles pnl_RecoleccionD.Paint
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Total_Click(sender As Object, e As EventArgs) Handles lbl_Total.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_SubtotalManual_Click(sender As Object, e As EventArgs) Handles lbl_SubtotalManual.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_ImporteManual_Click(sender As Object, e As EventArgs) Handles lbl_ImporteManual.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_ImporteTotal_Click(sender As Object, e As EventArgs) Handles lbl_ImporteTotal.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub
End Class