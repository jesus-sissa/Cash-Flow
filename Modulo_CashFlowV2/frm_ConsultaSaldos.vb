Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL

Public Class frm_ConsultaSaldos
    Dim SaldoGeneral As Decimal = 0
    Dim SaldoManual As Decimal = 0D
    Dim Importe_MXN As Decimal = 0
    Dim Importe_USD As Decimal = 0
    Dim Importe_USDConvert As Decimal = 0D
    Dim SaldoManualDocumentos As Decimal = 0D
    Dim Importe_MXNDocumentos As Decimal = 0
    Dim Importe_USDDocumentos As Decimal = 0
    Dim Importe_USDConvertDocumentos As Decimal = 0D
    Public Ventana As Integer


#Region "Procedimientos Privados"
    Private Sub Calcular_Total()
        Dim Persistente As New cls_VariablesPersistentes()

        Persistente.Persistir()
        Persistente.Cargar()

        Dim ImportePeso As Integer = 0, PiezasPeso As Integer = 0
        Dim ImporteDolar As Integer = 0, PiezasDolar As Integer = 0
        Dim posInserta As Integer = 0

        For J As Integer = 0 To lsv_Saldos1.Items.Count - 1
            If lsv_Saldos1.Items(J).SubItems(4).Text = "MXP" _
            OrElse lsv_Saldos1.Items(J).SubItems(4).Text = "MXN" Then
                ImportePeso += CInt(lsv_Saldos1.Items(J).SubItems(3).Text)
                PiezasPeso += CInt(lsv_Saldos1.Items(J).SubItems(2).Text)
                posInserta += 1 '-------->
            ElseIf lsv_Saldos1.Items(J).SubItems(4).Text = "USD" Then
                ImporteDolar += CInt(lsv_Saldos1.Items(J).SubItems(3).Text)
                PiezasDolar += CInt(lsv_Saldos1.Items(J).SubItems(2).Text)
            End If
        Next

        If ImportePeso > 0 Then
            lsv_Saldos1.Items.Insert(posInserta, "").SubItems.Add("")
            lsv_Saldos1.Items(posInserta).SubItems.Add("TOTAL MXN:")
            lsv_Saldos1.Items(posInserta).SubItems.Add("$ " & ImportePeso)

            lsv_Saldos1.Items.Insert(posInserta + 1, "").SubItems.Add("")
            lsv_Saldos1.Items(posInserta + 1).SubItems.Add("PIEZAS MXN:")
            lsv_Saldos1.Items(posInserta + 1).SubItems.Add(PiezasPeso)
            lsv_Saldos1.Items.Insert(posInserta + 2, "") '--->
        End If

        If ImporteDolar > 0 Then
            lsv_Saldos1.Items.Add("").SubItems.Add("")
            lsv_Saldos1.Items(lsv_Saldos1.Items.Count - 1).SubItems.Add("TOTAL USD:")
            lsv_Saldos1.Items(lsv_Saldos1.Items.Count - 1).SubItems.Add("$ " & ImporteDolar)

            lsv_Saldos1.Items.Add("").SubItems.Add("")
            lsv_Saldos1.Items(lsv_Saldos1.Items.Count - 1).SubItems.Add("PIEZAS USD:")
            lsv_Saldos1.Items(lsv_Saldos1.Items.Count - 1).SubItems.Add(PiezasDolar)
        End If

        For i As Integer = 0 To 3
            lsv_Saldos1.Columns(i).Width = -2
        Next
        lsv_Saldos1.Columns(4).Width = 0

        ' Calcular Total Importe Casetero 1
        Dim dt_Detalle = fn_Retiros_LlenarXcaset(varPub.Serie_Caset1)
        Dim ImporteMXNcaset As Integer = 0
        Dim ImporteUSDcaset As Integer = 0
        Dim ImporteTotalCaset As Decimal = 0D

        If dt_Detalle IsNot Nothing Then
            For Each fila As DataRow In dt_Detalle.Rows
                If fila("Moneda") = "MXP" OrElse fila("Moneda") = "MXN" Then
                    ImporteMXNcaset += fila("Importe")
                ElseIf fila("Moneda") = "USD" Then
                    ImporteUSDcaset += fila("Importe")
                End If
            Next
        End If
        ' El total es aprox, ya que TC varia dia con dia
        ImporteTotalCaset = ImporteMXNcaset + (ImporteUSDcaset * varPub.TipoCambio)
        lbl_Total1.Text = FormatCurrency(ImporteTotalCaset, 2)
    End Sub

    Private Sub Calcular_Total2()

        Dim ImportePeso As Integer = 0, PiezasPeso As Integer = 0
        Dim ImporteDolar As Integer = 0, PiezasDolar As Integer = 0
        Dim posInserta As Integer = 0 '---->

        For J As Integer = 0 To lsv_Saldos2.Items.Count - 1
            If lsv_Saldos2.Items(J).SubItems(4).Text = "MXP" OrElse _
             lsv_Saldos2.Items(J).SubItems(4).Text = "MXN" Then
                ImportePeso += CInt(lsv_Saldos2.Items(J).SubItems(3).Text)
                PiezasPeso += CInt(lsv_Saldos2.Items(J).SubItems(2).Text)
                posInserta += 1 '-------->
            ElseIf lsv_Saldos2.Items(J).SubItems(4).Text = "USD" Then
                ImporteDolar += CInt(lsv_Saldos2.Items(J).SubItems(3).Text)
                PiezasDolar += CInt(lsv_Saldos2.Items(J).SubItems(2).Text)
            End If
        Next

        If ImportePeso > 0 Then

            lsv_Saldos2.Items.Insert(posInserta, "").SubItems.Add("")
            lsv_Saldos2.Items(posInserta).SubItems.Add("TOTAL MXN:")
            lsv_Saldos2.Items(posInserta).SubItems.Add("$ " & ImportePeso)

            lsv_Saldos2.Items.Insert(posInserta + 1, "").SubItems.Add("")
            lsv_Saldos2.Items(posInserta + 1).SubItems.Add("PIEZAS MXN:")
            lsv_Saldos2.Items(posInserta + 1).SubItems.Add(PiezasPeso)
            lsv_Saldos2.Items.Insert(posInserta + 2, "") '--------->
        End If

        If ImporteDolar > 0 Then
            lsv_Saldos2.Items.Add("").SubItems.Add("")
            lsv_Saldos2.Items(lsv_Saldos2.Items.Count - 1).SubItems.Add("TOTAL USD:")
            lsv_Saldos2.Items(lsv_Saldos2.Items.Count - 1).SubItems.Add("$ " & ImporteDolar)

            lsv_Saldos2.Items.Add("").SubItems.Add("")
            lsv_Saldos2.Items(lsv_Saldos2.Items.Count - 1).SubItems.Add("PIEZAS USD:")
            lsv_Saldos2.Items(lsv_Saldos2.Items.Count - 1).SubItems.Add(PiezasDolar)
        End If

        For i As Integer = 0 To 3
            lsv_Saldos2.Columns(i).Width = -2
        Next
        lsv_Saldos2.Columns(4).Width = 0


        ' Calcular Total Importe Casetero 2
        Dim dt_Detalle = fn_Retiros_LlenarXcaset(varPub.Serie_Caset2)
        Dim ImporteMXNcaset As Integer = 0
        Dim ImporteUSDcaset As Integer = 0
        Dim ImporteTotalCaset As Decimal = 0D

        If dt_Detalle IsNot Nothing Then
            For Each fila As DataRow In dt_Detalle.Rows
                If fila("Moneda") = "MXP" OrElse fila("Moneda") = "MXN" Then
                    ImporteMXNcaset += fila("Importe")
                ElseIf fila("Moneda") = "USD" Then
                    ImporteUSDcaset += fila("Importe")
                End If
            Next
        End If

        ' El total es aprox, ya que TC varia dia con dia
        ImporteTotalCaset = ImporteMXNcaset + (ImporteUSDcaset * varPub.TipoCambio)
        lbl_Total2.Text = FormatCurrency(ImporteTotalCaset, 2)

    End Sub

    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub Saldo()
        pnl_General.Enabled = False
        'If Ventana = 1 Then
        '    Btn_Corte.Visible = True
        '    btn_Imprimir.Visible = False
        'End If

        'If Ventana = 0 Then
        '    Btn_Corte.Visible = False
        '    btn_Imprimir.Visible = True

        'End If

        Call CambiarTamanodelosControles()
        lbl_TotalGeneral.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 10, FontStyle.Bold)

        '------------------------------------
        Dim AnchoColumna As Integer = 0

         If varPub.Cant_Validadores = 1 Then
            tlp_Lista.ColumnCount = 1
            tlp_Lista.Controls.Remove(lsv_Saldos2)
            tlp_Lista.Controls.Remove(prg_Caset2)
            tlp_Lista.Controls.Remove(lbl_Total2)
            'tlp_Lista.Controls.RemoveAt(1)

            AnchoColumna = (lsv_Saldos1.Width / 6)
            lsv_Saldos1.Columns.Add("Clave", AnchoColumna)
            lsv_Saldos1.Columns.Add("Denom", AnchoColumna)
            lsv_Saldos1.Columns.Add("Cant", AnchoColumna)
            lsv_Saldos1.Columns.Add("Importe", AnchoColumna)
            lsv_Saldos1.Columns.Add("Monedas", 0)

            'Trae Detalle de Depositos(Cantidades e Importes)
            lsv_Saldos1.Items.Clear()
            Call fn_ConsultaSaldos_Llenar(lsv_Saldos1, varPub.Serie_Caset1, Ventana, 1)

            If lsv_Saldos1.Items.Count > 0 Then
                prg_Caset1.Value = fn_ValidarCapacidad() 'verificar n1 de casets
                Call Calcular_Total()
            End If

        Else
            tlp_Lista.ColumnCount = 2

            AnchoColumna = (lsv_Saldos1.Width / 6)
            lsv_Saldos1.Columns.Add("Clave", AnchoColumna)
            lsv_Saldos1.Columns.Add("Denom", AnchoColumna)
            lsv_Saldos1.Columns.Add("Cant", AnchoColumna)
            lsv_Saldos1.Columns.Add("Importe", AnchoColumna)
            lsv_Saldos1.Columns.Add("Monedas", 0)

            lsv_Saldos2.Columns.Add("Clave", AnchoColumna)
            lsv_Saldos2.Columns.Add("Denom", AnchoColumna)
            lsv_Saldos2.Columns.Add("Cant", AnchoColumna)
            lsv_Saldos2.Columns.Add("Importe", AnchoColumna)
            lsv_Saldos2.Columns.Add("Monedas", 0)

            'Llenar Saldo en la Lista con Casetero 1 y 2

            Call fn_ConsultaSaldos_Llenar(lsv_Saldos1, varPub.Serie_Caset1, Ventana, 1)
            Call fn_ConsultaSaldos_Llenar(lsv_Saldos2, varPub.Serie_Caset2, Ventana, 2)

            prg_Caset1.Value = fn_ValidarCapacidad() 'verificar cap. caset
            Call Calcular_Total()

            Call Calcular_Total2()
            prg_Caset2.Value = fn_ValidarCapacidad_C2()

        End If

        '******************************************************************
        '29/09/2016 se obtiene el IMporte Total de Depositos Validados
        Dim dt_SaldoValidado As DataTable = fn_ConsultaSaldosValidados(Ventana)

        'Traer Total_MXP y Total_USD (depositados en ambos cartuchos)
        Dim dt_SaldoManualEfectivo As DataTable = fn_ConsultaSaldosManualEfectivo(Ventana)
        If dt_SaldoManualEfectivo IsNot Nothing AndAlso dt_SaldoManualEfectivo.Rows.Count > 0 Then
            If IsDBNull(dt_SaldoManualEfectivo.Rows(0)("Importe_Total")) = False Then
                SaldoManual = dt_SaldoManualEfectivo.Rows(0)("Importe_Total")
                Importe_MXN = dt_SaldoManualEfectivo.Rows(0)("Total_MXP")
                Importe_USD = dt_SaldoManualEfectivo.Rows(0)("Total_USD")
                Importe_USDConvert = dt_SaldoManualEfectivo.Rows(0)("TotalUSD_Convert")
            End If
        End If

        Dim dt_SaldoManualDocumentos As DataTable = fn_ConsultaSaldosManualDocumento(Ventana)
        If dt_SaldoManualDocumentos IsNot Nothing AndAlso dt_SaldoManualDocumentos.Rows.Count > 0 Then
            If IsDBNull(dt_SaldoManualDocumentos.Rows(0)("Importe_Total")) = False Then
                SaldoManualDocumentos = dt_SaldoManualDocumentos.Rows(0)("Importe_Total")
                Importe_MXNDocumentos = dt_SaldoManualDocumentos.Rows(0)("Total_MXP")
                Importe_USDDocumentos = dt_SaldoManualDocumentos.Rows(0)("Total_USD")
                Importe_USDConvertDocumentos = dt_SaldoManualDocumentos.Rows(0)("TotalUSD_Convert")
            End If
        End If

        tbx_mxnManual.Text = FormatCurrency(Importe_MXN, 2)
        tbx_usdManual.Text = FormatCurrency(Importe_USD, 2)
        tbx_usdManualConvert.Text = FormatCurrency(Importe_USDConvert, 2)

        Tbx_ImporteDocumentosMXN.Text = FormatCurrency(Importe_MXNDocumentos, 2)
        Tbx_ImporteDocumentosUSD.Text = FormatCurrency(Importe_USDDocumentos, 2)
        Tbx_ImporteDocumentosUsdEnMxp.Text = FormatCurrency(Importe_USDConvertDocumentos, 2)

        tbx_subtotalManual.Text = FormatCurrency(SaldoManual + SaldoManualDocumentos, 2)

        If dt_SaldoValidado IsNot Nothing AndAlso dt_SaldoValidado.Rows.Count > 0 Then
            If IsDBNull(dt_SaldoValidado.Rows(0)("Importe_Total")) = False Then
                SaldoGeneral = dt_SaldoValidado.Rows(0)("Importe_Total")
            End If
        End If
        SaldoGeneral += SaldoManual + SaldoManualDocumentos
        btn_Imprimir.Enabled = SaldoGeneral > 0

        lbl_TotalGeneral.Text = "Total: " & FormatCurrency(SaldoGeneral, 2)
        pnl_General.Enabled = True
    End Sub



#End Region

    Private Sub frm_ConsultaSaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 18
        Call Saldo()

    End Sub

    Private Sub tab_Saldos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_Saldos.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Imprimir_Click(sender As Object, e As EventArgs) Handles btn_Imprimir.Click
        varPub.SegundosSesion = 0
        pnl_General.Enabled = False
        Call fn_ConsultaSaldos_Imprimir(Ventana)
        pnl_General.Enabled = True
    End Sub

    Private Sub lbl_TotalGeneral_Click(sender As Object, e As EventArgs) Handles lbl_TotalGeneral.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub


 


End Class