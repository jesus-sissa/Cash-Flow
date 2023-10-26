Imports System.Data.SqlClient

Public Class frm_ImprimirAtasco
#Region "-Eventos"
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        cls_CashFlow.fn_ImprimirAtascos(varPub.ID_DepositoP)
        Me.Close()
    End Sub

    Private Sub Btn_Cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
        Dim frm As New frm_DepositoXvalidador()
        frm.Close()
    End Sub
#End Region

End Class