Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_CatalogoMonedas

#Region "Funciones Privadas"
    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub LlenarLista()
        Call fn_Monedas_Llenar(lsv_Monedas)
        btn_Eliminar.Enabled = False
    End Sub

    Private Sub AgregarMonedas()
        pnl_General.Enabled = False
        Select Case fn_Monedas_Create(tbx_ClaveMoneda.Text, tbx_NombreMoneda.Text)
            '0 correcto
            Case 0
                tbx_ClaveMoneda.Text = ""
                tbx_NombreMoneda.Text = ""
                Call LlenarLista() 'volver a cargar lista

            Case 1, -1
                tbx_ClaveMoneda.Focus()
            Case 2
                tbx_NombreMoneda.Focus()
        End Select
        pnl_General.Enabled = True

    End Sub

#End Region

    Private Sub frm_CatalogoMonedas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_CatalogoMonedas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 10

        pnl_General.Enabled = False
        Call CambiarTamanodelosControles()

        Dim w As Integer = (lsv_Monedas.Width / 4)
        lsv_Monedas.Columns.Add("Clave", w, HorizontalAlignment.Left)
        lsv_Monedas.Columns.Add("Nombre", w, HorizontalAlignment.Left)

        'Revisa las monedas en la web  e inserta en local si hay nuevoss
        Cursor = Cursors.WaitCursor

        If (varPub.ConexionwebAdmin = 1) Then
            If fn_VerificaConexionInternet() Then Call fn_SincronizarMonedas_aLOCAL()
        End If

        Cursor = Cursors.Default
        Call LlenarLista()

        pnl_General.Enabled = True

        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = (lsv_Monedas.Location.Y + 65)
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        pnl_General.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_ClaveMoneda_Click(sender As Object, e As EventArgs) Handles tbx_ClaveMoneda.Click
        tbx_ClaveMoneda.SelectAll()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveMoneda) = True

    End Sub

    Private Sub tbx_ClaveMoneda_Enter(sender As Object, e As EventArgs) Handles tbx_ClaveMoneda.Enter
        tbx_ClaveMoneda.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveMoneda) = True
    End Sub

    Private Sub tbx_ClaveMoneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ClaveMoneda.KeyPress
        varPub.SegundosSesion = 0
        e.KeyChar = UCase(e.KeyChar)

        Select Case Asc(e.KeyChar)
            Case Asc("A") To Asc("Z"), 8
                'Letras mayus y Back
            Case Keys.Enter
                tbx_NombreMoneda.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_ClaveMoneda_Leave(sender As Object, e As EventArgs) Handles tbx_ClaveMoneda.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveMoneda_TextChanged(sender As Object, e As EventArgs) Handles tbx_ClaveMoneda.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NombreMoneda_Click(sender As Object, e As EventArgs) Handles tbx_NombreMoneda.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreMoneda) = True
    End Sub

    Private Sub tbx_NombreMoneda_Enter(sender As Object, e As EventArgs) Handles tbx_NombreMoneda.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreMoneda) = True
    End Sub

    Private Sub tbx_NombreMoneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_NombreMoneda.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            btn_Agregar.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_NombreMoneda_Leave(sender As Object, e As EventArgs) Handles tbx_NombreMoneda.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NombreMoneda_TextChanged(sender As Object, e As EventArgs) Handles tbx_NombreMoneda.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lsv_Monedas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Monedas.SelectedIndexChanged
        varPub.SegundosSesion = 0
        btn_Eliminar.Enabled = lsv_Monedas.SelectedItems.Count > 0
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        lsv_Monedas.SelectedItems.Clear()

        Call AgregarMonedas()
        tbx_ClaveMoneda.Focus()
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0

        Dim MonedaCant As Integer = fn_Monedas_Delete(lsv_Monedas.SelectedItems(0).Text)

        Select Case MonedaCant
            Case -1
                Call fn_MsgBox("Ocurrió un Error al eliminar la Moneda.", MessageBoxIcon.Error, True, 2)

            Case 0
                fn_MsgBox("No se puede eliminar la Moneda, porque existen denominaciones ligadas.", MessageBoxIcon.Exclamation, True, 2)

            Case 1
                fn_MsgBox("Moneda eliminada correctamente. ", MessageBoxIcon.Information, True, 2)
                Call LlenarLista()
                tbx_ClaveMoneda.Focus()

        End Select
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub
End Class