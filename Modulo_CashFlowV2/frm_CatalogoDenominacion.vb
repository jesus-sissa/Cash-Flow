
Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_CatalogoDenominacion

#Region "Funciones Privadas"
    Private Sub CambiarTamanodelosControles()
        cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub LlenarLista()
        Call fn_Denominaciones_Llenar(lsv_Denominaciones, cmb_Monedas.SelectedValue)
        btn_Eliminar.Enabled = False
    End Sub

    Private Sub AgregarDenominacion()
        pnl_General.Enabled = False

        Select Case fn_Denominaciones_Create(tbx_Denominacion.Text, cmb_Monedas.SelectedValue)

            Case 0
                pnl_General.Enabled = True
                Call LlenarLista() 'volver a cargar lista
            Case 1, -1
                pnl_General.Enabled = True
                cmb_Monedas.Focus()

            Case 2, 3
                pnl_General.Enabled = True
                tbx_Denominacion.Focus()
        End Select

    End Sub

#End Region

    Private Sub frm_CatalogoDenominacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' frm.DesactivarMAYUSCULAS() 'esto es para desactivar Block Mayus
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_CatalogoDenominacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 9

        pnl_General.Enabled = False
        Call CambiarTamanodelosControles()

        Dim w As Integer = (lsv_Denominaciones.Width / 3)
        lsv_Denominaciones.Columns.Add("Clave", w, HorizontalAlignment.Left)
        lsv_Denominaciones.Columns.Add("Denominacion", w, HorizontalAlignment.Right)
        lsv_Denominaciones.Columns.Add("Moneda", w, HorizontalAlignment.Left)

        Call fn_Denominaciones_LlenarCombo(cmb_Monedas)

        Cursor = Cursors.WaitCursor

        If (varPub.ConexionwebAdmin = 1) Then
            If fn_VerificaConexionInternet() Then Call fn_SincronizarDenominaciones_aLOCAL()
        End If

        Cursor = Cursors.Default
        Call LlenarLista()

        pnl_General.Enabled = True
        varPub.SegundosSesion = 0

        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.miniNUMEROS Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.miniNUMEROS
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = lsv_Denominaciones.Width - ctrlTeclado.Width
        varTecl.ubicaY_Teclado = (lsv_Denominaciones.Location.Y + 35)
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        pnl_General.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub cmb_Monedas_Click(sender As Object, e As EventArgs) Handles cmb_Monedas.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub cmb_Monedas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_Monedas.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then tbx_Denominacion.Focus()
    End Sub

    Private Sub cmb_Monedas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Monedas.SelectedIndexChanged
        varPub.SegundosSesion = 0
        lsv_Denominaciones.Items.Clear()

        Call LlenarLista()
    End Sub

    Private Sub tbx_Denominacion_Click(sender As Object, e As EventArgs) Handles tbx_Denominacion.Click
        varPub.SegundosSesion = 0
        'lsv_Denominaciones.SelectedItems.Clear()
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Denominacion) = True
    End Sub

    Private Sub tbx_Denominacion_Enter(sender As Object, e As EventArgs) Handles tbx_Denominacion.Enter
        varPub.SegundosSesion = 0
        'lsv_Denominaciones.SelectedItems.Clear()
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Denominacion) = True
    End Sub

    Private Sub tbx_Denominacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Denominacion.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                ctrlTeclado.Hide()
                Call AgregarDenominacion()

            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Denominacion_Leave(sender As Object, e As EventArgs) Handles tbx_Denominacion.Leave
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_Denominacion_TextChanged(sender As Object, e As EventArgs) Handles tbx_Denominacion.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lsv_Denominaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Denominaciones.SelectedIndexChanged
        varPub.SegundosSesion = 0
        btn_Eliminar.Enabled = lsv_Denominaciones.SelectedItems.Count > 0
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        varPub.SegundosSesion = 0
        lsv_Denominaciones.SelectedItems.Clear()
        ctrlTeclado.Hide()
        Call AgregarDenominacion()
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()

        Dim DenomCant As Integer = fn_Denominaciones_Delete(lsv_Denominaciones.SelectedItems(0).Text)

        Select Case DenomCant
            Case -1
                Call fn_MsgBox("Ocurrió un Error al eliminar la Denominación.", MessageBoxIcon.Error, True, 2)

            Case 0
                fn_MsgBox("No se puede eliminar la denominación, porque existen depósitos.", MessageBoxIcon.Exclamation, True, 2)

            Case 1
                fn_MsgBox("Denominación eliminada correctamente. ", MessageBoxIcon.Information, True, 2)
                Call LlenarLista()

        End Select
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

End Class