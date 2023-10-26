Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_ConsultaDepositosD

#Region "Funciones Privadas"
    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub
#End Region

    Private Sub frm_ConsultaDepositosD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 13

        varPub.SegundosSesion = 0

        Dim AnchoColumna As Integer = (lsv_DepositosD.Width / 6)
        Call CambiarTamanodelosControles()

        lbl_TotalD.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 10, FontStyle.Bold)

        lsv_DepositosD.Columns(0).Width = AnchoColumna
        lsv_DepositosD.Columns(1).Width = AnchoColumna * 2
        lsv_DepositosD.Columns(2).Width = AnchoColumna
        lsv_DepositosD.Columns(3).Width = AnchoColumna

        Dim CuentaPeso As Integer = 0
        Dim CuentaDolar As Integer = 0

        For J As Byte = 0 To lsv_DepositosD.Items.Count - 1
            If lsv_DepositosD.Items(J).SubItems(4).Text = "MXP" _
            OrElse lsv_DepositosD.Items(J).SubItems(4).Text = "MXN" Then
                CuentaPeso += CInt(lsv_DepositosD.Items(J).SubItems(3).Text)
            ElseIf lsv_DepositosD.Items(J).SubItems(4).Text = "USD" Then
                CuentaDolar += CInt(lsv_DepositosD.Items(J).SubItems(3).Text)
            End If
        Next

        If CuentaPeso > 0 Then
            lsv_DepositosD.Items.Add("").SubItems.Add("")
            lsv_DepositosD.Items(lsv_DepositosD.Items.Count - 1).SubItems.Add("TOTAL MXP")
            lsv_DepositosD.Items(lsv_DepositosD.Items.Count - 1).SubItems.Add(FormatCurrency(CuentaPeso, 2))
        End If
        If CuentaDolar > 0 Then
            lsv_DepositosD.Items.Add("").SubItems.Add("")
            lsv_DepositosD.Items(lsv_DepositosD.Items.Count - 1).SubItems.Add("TOTAL USD")
            lsv_DepositosD.Items(lsv_DepositosD.Items.Count - 1).SubItems.Add(FormatCurrency(CuentaDolar, ))
        End If
    End Sub

    Private Sub pnl_DepositosD_Click(sender As Object, e As EventArgs) Handles pnl_DepositosD.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_TotalD_Click(sender As Object, e As EventArgs) Handles lbl_TotalD.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

End Class