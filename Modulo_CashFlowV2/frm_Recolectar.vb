Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_Recolectar

    Dim SaldoGeneral As Decimal = 0D
    Dim SaldoManualEfectivo As Decimal = 0D
    Dim Importe_MXN As Integer = 0
    Dim Importe_USD As Integer = 0
    Dim Importe_USDConvert As Decimal = 0D
    Dim SaldoManualDocumento As Decimal = 0D
    Dim Envase As String 'Rd
    Dim Remison As String 'Rd
    Private Function Login_Tv() 'Rd
        varPub.Id_punto = 0
        varPub.RemisionWs = String.Empty
        varPub.Remision_Valida = False
        varPub.Envase_Valido = False

        Dim frm As New frm_AccesoRecoleccion
        frm.ShowDialog()
        Select Case frm.DialogResult
            Case Windows.Forms.DialogResult.Cancel
                varPub.IdPantalla = 33
                varPub.SegundosSesion = 0
                Me.Close()
            Case Windows.Forms.DialogResult.OK
                tbx_Remision.Text = varPub.RemisionWs
                tbx_Remision.Enabled = False
                varPub.Remision_Valida = True
                keysShow(tbx_Envase)
            Case Windows.Forms.DialogResult.No
                keysShow(tbx_Remision)
        End Select

    End Function
    Sub Validar_Envase() 'Rd
        If tbx_Envase.Text.Trim = String.Empty Or tbx_Envase.Text = "0" Then Exit Sub
        If lbl_Envase.Text = "No. Envase" Then
            envase = tbx_Envase.Text.Trim
            lbl_Envase.Text = "Confirmar No. Envase"
            tbx_Envase.Clear()
            tbx_Envase.Focus()
        ElseIf lbl_Envase.Text = "Confirmar No. Envase" Then
            If envase = tbx_Envase.Text Then
                tbx_Envase.Enabled = False
                lbl_Envase.Text = "No. Envase validado"
                varPub.Envase_Valido = True
                tbx_Observaciones.Focus()
            Else
                'Me.Close()
                lbl_Envase.Text = "No. Envase"
                envase = String.Empty
                tbx_Envase.Text = String.Empty
                varPub.Envase_Valido = False
                tbx_Envase.Focus()
            End If
        End If
    End Sub
    Sub Validar_Remision() 'Rd 

        If tbx_Remision.Text.Trim = String.Empty Or tbx_Remision.Text = "0" Then Exit Sub
        If lbl_Remision.Text = "Remisión" Then
            Remison = tbx_Remision.Text.Trim
            lbl_Remision.Text = "Confirmar Remisión"
            tbx_Remision.Clear()
            tbx_Remision.Focus()
        ElseIf lbl_Remision.Text = "Confirmar Remisión" Then
            If Remison = tbx_Remision.Text Then
                tbx_Remision.Enabled = False
                lbl_Remision.Text = "Remisión validada"
                varPub.Remision_Valida = True
                tbx_Observaciones.Focus()
            Else
                'Me.Close()
                lbl_Remision.Text = "Remisión"
                Remison = String.Empty
                tbx_Remision.Text = String.Empty
                varPub.Remision_Valida = False
                tbx_Remision.Focus()
            End If
        End If
    End Sub
    Function keysShow(obj As TextBox) 'Rd
        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = tbx_Observaciones.Location.Y + tbx_Observaciones.Height + 10
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(obj) = True
        obj.Focus()
    End Function

    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub frm_Recolectar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_Recolectar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Variable Publica para mandar Id de la Pantalla
        varPub.IdPantalla = 36


        pnl_General.Enabled = False
        Dim dt_Detalle As DataTable = Nothing

        Call CambiarTamanodelosControles()
        lbl_SaldoGeneral.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 10, FontStyle.Bold)

        If varPub.Cant_Validadores = 1 Then

            With tlp_DatosCaset
                .ColumnCount = 2
                .Controls.Remove(lblCasetActual_2)
                .Controls.Remove(lblCasetnuevo_2)
                .Controls.Remove(lblTotalcaset_2)
                .Controls.Remove(lbl_CasetActualD2)
                .Controls.Remove(cmb_Caset2)
                .Controls.Remove(lbl_Total2)
            End With

            Call fn_Retiros_LlenarCombo(cmb_Caset, varPub.CasetID)
            dt_Detalle = fn_Retiros_LlenarXcaset(varPub.Serie_Caset1)

            ' Calcular Total Importe Casetero 1
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

        Else

            'Calcula saldo a retirar para el caset 1-------
            Call fn_Retiros_LlenarCombo(cmb_Caset, varPub.CasetID, varPub.Caset2ID) 'agregando PArametro KsetID2
            dt_Detalle = fn_Retiros_LlenarXcaset(varPub.Serie_Caset1)
            ' Calcular Total Importe Casetero 1
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
            '******************************************************

            'Calcula saldo a retirar para el caset 2-------
            Call fn_Retiros_LlenarCombo(cmb_Caset2, varPub.CasetID, varPub.Caset2ID) 'agregando PArametro KsetID2
            dt_Detalle = fn_Retiros_LlenarXcaset(varPub.Serie_Caset2)

            ' Calcular Total Importe Casetero 2
            ImporteMXNcaset = 0
            ImporteUSDcaset = 0
            ImporteTotalCaset = 0D
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
            '--------------
        End If

        '******************************************************************
        '29/09/2016 Obtener el Importe Total Depósito Manual
        Dim dt_SaldoValidado As DataTable = fn_ConsultaSaldosValidados(0)
        'Trae Total_MXP y Total_USD (depositados en ambos cartuchos)
        Dim dt_SaldoManual As DataTable = fn_ConsultaSaldosManualEfectivo(0)
        Dim dt_SaldoManualDocumento As DataTable = fn_ConsultaSaldosManualDocumento(0)
        If dt_SaldoManual IsNot Nothing AndAlso dt_SaldoManual.Rows.Count > 0 Then
            If IsDBNull(dt_SaldoManual.Rows(0)("Importe_Total")) = False Then
                SaldoManualEfectivo = dt_SaldoManual.Rows(0)("Importe_Total")
            End If
        End If

        If dt_SaldoValidado IsNot Nothing AndAlso dt_SaldoValidado.Rows.Count > 0 Then
            If IsDBNull(dt_SaldoValidado.Rows(0)("Importe_Total")) = False Then
                SaldoGeneral = dt_SaldoValidado.Rows(0)("Importe_Total")
                Importe_MXN = dt_SaldoValidado.Rows(0)("Total_MXP")
                Importe_USD = dt_SaldoValidado.Rows(0)("Total_USD")
                Importe_USD = dt_SaldoValidado.Rows(0)("TotalUSD_Convert")
            End If
        End If
        '29/09/2016 Obtener el Importe Total Depósito Manual
        If dt_SaldoManualDocumento IsNot Nothing AndAlso dt_SaldoManualDocumento.Rows.Count > 0 Then
            If IsDBNull(dt_SaldoManualDocumento.Rows(0)("Importe_Total")) = False Then
                SaldoManualDocumento = dt_SaldoManualDocumento.Rows(0)("Importe_Total")
            End If
        End If
        tbx_ImporteOtros.Text = FormatCurrency(SaldoManualEfectivo, 2) & "+" & FormatCurrency(SaldoManualDocumento, 2)

        SaldoGeneral += SaldoManualEfectivo
        SaldoGeneral += SaldoManualDocumento

        'btn_Retirar.Enabled = SaldoGeneral > 0
        lbl_SaldoGeneral.Text = "Total: " & FormatCurrency(SaldoGeneral, 2)

        pnl_General.Enabled = True

        '----------------------------------------
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = tbx_Observaciones.Location.Y + tbx_Observaciones.Height + 10
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)
        ''Cargar tipo de recoleccion [Normal,RD]
        varPub.Urd = fn_TipoRecoleccion(1, 0)

        If (varPub.Urd) Then
            Login_Tv()
        End If


    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Retirar_Click(sender As Object, e As EventArgs)
        ctrlTeclado.Hide()

        If SaldoGeneral = 0 Then
            Call fn_MsgBox("Debe haber depósitos para que se pueda hacer un «Retiro».", MessageBoxIcon.Error, True, 2)
            Exit Sub
        End If

        pnl_General.Enabled = False
        pnl_General.Visible = False

        ctrlTeclado.Hide()
        '----------
        varPub.SegundosSesion = 0
        Dim abrirValidar As Boolean = False
        Select Case fn_Recoleccion_Recolectar(SaldoGeneral, Importe_MXN, Importe_USD, Importe_USDConvert, _
                                         tbx_Remision.Text, SaldoManualEfectivo, SaldoManualDocumento, tbx_Envase.Text, cmb_Caset.SelectedValue, cmb_Caset2.SelectedValue, tbx_Observaciones.Text)
            Case 0
                Call fn_MsgBox("El Retiro se realizó correctamente.", MessageBoxIcon.Information)
                abrirValidar = True
                'Me.Close()
            Case 1
                Call fn_MsgBox("Capture y valide la Remisión.", MessageBoxIcon.Exclamation)
                tbx_Remision.Focus()

            Case 2
                cmb_Caset.Focus()

            Case 3
                Call fn_MsgBox("Datos incorrectos, No se pudo realizar el retiro.", MessageBoxIcon.Exclamation)

            Case 4
                Call fn_MsgBox("Ocurrió error al realizar el retiro.", MessageBoxIcon.Exclamation)

            Case 5
                Call fn_MsgBox("Ocurrió error al realizar el retiro, Servicio no disponible(RD).", MessageBoxIcon.Exclamation)

            Case 8, 9
                Call fn_MsgBox("El Retiro se realizó correctamente, Pero no se pudo imprimir el ticket.", MessageBoxIcon.Exclamation)
                abrirValidar = True
                'Me.Close()
            Case 10
                Call fn_MsgBox("Debe colocar el número de envase", MessageBoxIcon.Exclamation)

            Case 11
                Call fn_MsgBox("El usuario no es el mismo al que se firmó.", MessageBoxIcon.Information)

            Case 12
                Call fn_MsgBox("Falta validar envases.", MessageBoxIcon.Exclamation)

        End Select

        If abrirValidar Then
            Dim val1 As New frm_Check_Validadores()
            val1.ShowDialog()
            Me.Close()
        End If


        pnl_General.Visible = True

        pnl_General.Enabled = True
        Me.Close()

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.IdPantalla = 33
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub lbl_SaldoD_Click(sender As Object, e As EventArgs) Handles lbl_SaldoGeneral.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Saldo_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_CiaTV_Click(sender As Object, e As EventArgs) Handles lbl_CiaTV.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_CiaTVD_Click(sender As Object, e As EventArgs) Handles lbl_CiaTVD.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_CasetActual_Click(sender As Object, e As EventArgs) Handles lbl_CasetActual.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_CasetActualD_Click(sender As Object, e As EventArgs) Handles lbl_CasetActualD.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_CasetDisponibles_Click(sender As Object, e As EventArgs) Handles lbl_CasetDisponibles.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub cmb_Caset_Click(sender As Object, e As EventArgs) Handles cmb_Caset.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Caset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Caset.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tlp_DatosCaset_Click(sender As Object, e As EventArgs) Handles tlp_DatosCaset.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_Remision_Click(sender As Object, e As EventArgs) Handles tbx_Remision.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Remision) = True
    End Sub

    Private Sub tbx_Remision_Enter(sender As Object, e As EventArgs) Handles tbx_Remision.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Remision) = True
    End Sub

    Private Sub tbx_Remision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Remision.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Backk
            Case Keys.Enter
                If varPub.Urd Then
                    Validar_Remision()
                Else
                    tbx_ImporteOtros.Focus()
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Remision_Leave(sender As Object, e As EventArgs) Handles tbx_Remision.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Remision_TextChanged(sender As Object, e As EventArgs) Handles tbx_Remision.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ImporteOtros_Click(sender As Object, e As EventArgs) Handles tbx_ImporteOtros.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ImporteOtros_Enter(sender As Object, e As EventArgs) Handles tbx_ImporteOtros.Enter
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ImporteOtros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ImporteOtros.KeyPress
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ImporteOtros_Leave(sender As Object, e As EventArgs) Handles tbx_ImporteOtros.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ImporteOtros_TextChanged(sender As Object, e As EventArgs) Handles tbx_ImporteOtros.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Envase_Click(sender As Object, e As EventArgs) Handles tbx_Envase.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Envase) = True
    End Sub

    Private Sub tbx_Envase_Enter(sender As Object, e As EventArgs) Handles tbx_Envase.Enter
        varPub.SegundosSesion = 0

        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Envase) = True
    End Sub

    Private Sub tbx_Envase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Envase.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then

            If (varPub.Urd) Then
                Validar_Envase()
            Else
                tbx_Observaciones.Focus()
            End If
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Envase_Leave(sender As Object, e As EventArgs) Handles tbx_Envase.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Envase_TextChanged(sender As Object, e As EventArgs) Handles tbx_Envase.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Remision_Click(sender As Object, e As EventArgs) Handles lbl_Remision.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_ImporteOtros_Click(sender As Object, e As EventArgs) Handles lbl_ImporteOtros.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Envase_Click(sender As Object, e As EventArgs) Handles lbl_Envase.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Observaciones_Click(sender As Object, e As EventArgs) Handles lbl_Observaciones.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Subtotal1_Click(sender As Object, e As EventArgs) Handles lbl_Subtotal1.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_Observaciones_Click(sender As Object, e As EventArgs) Handles tbx_Observaciones.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Observaciones) = True
    End Sub

    Private Sub tbx_Observaciones_Enter(sender As Object, e As EventArgs) Handles tbx_Observaciones.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Observaciones) = True
    End Sub

    Private Sub tbx_Observaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Observaciones.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            'btn_Retirar.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Observaciones_Leave(sender As Object, e As EventArgs) Handles tbx_Observaciones.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Observaciones_TextChanged(sender As Object, e As EventArgs) Handles tbx_Observaciones.TextChanged
        varPub.SegundosSesion = 0
    End Sub


End Class