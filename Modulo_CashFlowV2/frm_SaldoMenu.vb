Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_SaldoMenu

    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub frm_CorteDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CambiarTamanodelosControles()

        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 39
    End Sub

    Private Sub gbx_CorteDiario_Click(sender As Object, e As EventArgs) Handles gbx_CorteDiario.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_UltimaRecoleccion_Click(sender As Object, e As EventArgs) Handles btn_UltimaRecoleccion.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        '1= Todos los Depósitos finalizados 'F' desde última Recolección.
        '2= Todos los Depósitos finalizados 'F' solo del dia actual.
        '3= Todos los depositos del dia actual('R' Retirados o 'F' finalizados)
        Call fn_CorteDiario_Imprimir(1) ' enviar parametro
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_DiaActual_Click(sender As Object, e As EventArgs) Handles btn_DiaActual.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_CorteDiario_Imprimir(2)
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_DiaActualCompleto_Click(sender As Object, e As EventArgs) Handles btn_DiaActualCompleto.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_CorteDiario_Imprimir(3)
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        varPub.Tipo_CorteDiario = 0
        Me.Close()
    End Sub
End Class