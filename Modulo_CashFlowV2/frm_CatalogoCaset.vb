Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class frm_CatalogoCaset

#Region "Funciones Privadas"

    Private Sub CambiarTamanodelosControles()
        fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub LlenarLista()
        Call fn_Casets_Llenar(lsv_Casets)
        btn_CambiarStatus.Enabled = False
        btn_Eliminar.Enabled = False
        '
        lsv_Casets.SmallImageList = iml_Sincronia
        For Each lvi As ListViewItem In lsv_Casets.Items
            If lvi.SubItems(5).Text = "S" Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If
        Next
        lsv_Casets.Columns(5).Width = 0

    End Sub

    Private Sub AgregarCaset()

        pnl_General.Enabled = False

        ''SINCRONIZAR CASET SI HAY de Web a Local
        'fn_SincronizarCasets(Cve_Sucursal)

        Select Case fn_Casets_Create(tbx_ClaveCaset.Text, tbx_Serie.Text, tbx_Capacidad.Text, tbx_Porcentaje.Text)
            Case 1
                Call fn_MsgBox("Caset Guardado Correctamente.", MessageBoxIcon.Information)
                pnl_General.Enabled = True
                Call LlenarLista()
                tbx_ClaveCaset.Text = String.Empty
                tbx_Serie.Text = String.Empty
                tbx_Capacidad.Text = String.Empty
                tbx_Porcentaje.Text = "90"
                tbx_ClaveCaset.Focus()

            Case 2
                pnl_General.Enabled = True
                Call fn_MsgBox("Capture la clave del Caset mayor de 3 Letras.", MessageBoxIcon.Exclamation)
                tbx_ClaveCaset.Focus()

            Case 3
                pnl_General.Enabled = True
                Call fn_MsgBox("La Clave ya existe en la base de datos, capture otra.", MessageBoxIcon.Exclamation)
                tbx_ClaveCaset.Focus()
            Case 4
                pnl_General.Enabled = True
                Call fn_MsgBox("Capture el Número de Serie del caset. con todos sus dígitos", MessageBoxIcon.Exclamation)
                tbx_Serie.Focus()
            Case 5
                pnl_General.Enabled = True
                Call fn_MsgBox("El número de serie ya existe, capture otro número de serie.", MessageBoxIcon.Exclamation)
                tbx_Serie.Focus()
            Case 6
                pnl_General.Enabled = True 'pendiente validar capacidad kct2,
                Call fn_MsgBox("Capture la Capacidad del Caset, la capacidad no puede rebasar: " & varPub.LimiteCapacidad_Kct & " piezas.", MessageBoxIcon.Exclamation)
                tbx_Capacidad.Focus()
            Case 7
                pnl_General.Enabled = True
                Call fn_MsgBox("Capture el Porcentaje del caset, debe estar en el rango entre 40% y 95%", MessageBoxIcon.Error)
                tbx_Porcentaje.Focus()
        End Select
        pnl_General.Enabled = True
    End Sub

#End Region

    Private Sub frm_CatalogoCaset_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        varPub.SegundosSesion = 0

        Dim NumCasets As Integer = fn_Casets_Count()

        Select Case NumCasets
            Case 0, 1
                Call fn_MsgBox("Debe de haber mínimo 2 Casets activos.", MessageBoxIcon.Error)
            Case Else
                If varPub.Cant_Validadores = 2 And NumCasets < 4 Then
                    Call fn_MsgBox("Debe de haber mínimo 4 casets activos ya que se tienen 2 validadores,", MessageBoxIcon.Error)
                End If

        End Select
        'frm.DesactivarMAYUSCULAS() 'esto es para desactivar Block Mayus '
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_CatalogoCaset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 7

        pnl_General.Enabled = False
        varPub.SegundosSesion = 0

        Call CambiarTamanodelosControles()
        Dim w As Integer = (lsv_Casets.Width / 5)
        lsv_Casets.Columns.Add("Clave", w)
        lsv_Casets.Columns.Add("Serie", w)
        lsv_Casets.Columns.Add("Capacidad", w)
        lsv_Casets.Columns.Add("Porcentaje", w)
        lsv_Casets.Columns.Add("Estatus", w)
        lsv_Casets.Columns.Add("Sincronizado", 0)

        'sincronizar caset si existen(de Web a Local)
        Cursor = Cursors.WaitCursor

        If (varPub.ConexionwebAdmin = 1) Then
            If fn_VerificaConexionInternet() Then fn_SincronizarCasets_aLOCAL(varPub.Cve_Sucursal)
        End If

        Cursor = Cursors.Default
        Call LlenarLista()

        pnl_General.Enabled = True
        btn_Agregar.Select()
        '----------------------------------------
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = lsv_Casets.Location.Y + 65
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        pnl_General.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_ClaveCaset_Click(sender As Object, e As EventArgs) Handles tbx_ClaveCaset.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveCaset) = True

    End Sub

    Private Sub tbx_ClaveCaset_Enter(sender As Object, e As EventArgs) Handles tbx_ClaveCaset.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveCaset) = True
    End Sub

    Private Sub tbx_ClaveCaset_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ClaveCaset.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Serie.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_ClaveCaset_Leave(sender As Object, e As EventArgs) Handles tbx_ClaveCaset.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveCaset_TextChanged(sender As Object, e As EventArgs) Handles tbx_ClaveCaset.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Serie_Click(sender As Object, e As EventArgs) Handles tbx_Serie.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Serie) = True
    End Sub

    Private Sub tbx_Serie_Enter(sender As Object, e As EventArgs) Handles tbx_Serie.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Serie) = True
    End Sub

    Private Sub tbx_Serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Serie.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Capacidad.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Serie_Leave(sender As Object, e As EventArgs) Handles tbx_Serie.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Serie_TextChanged(sender As Object, e As EventArgs) Handles tbx_Serie.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Capacidad_Click(sender As Object, e As EventArgs) Handles tbx_Capacidad.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Capacidad) = True
    End Sub

    Private Sub tbx_Capacidad_Enter(sender As Object, e As EventArgs) Handles tbx_Capacidad.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Capacidad) = True
    End Sub

    Private Sub tbx_Capacidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Capacidad.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                tbx_Porcentaje.Focus()

            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Capacidad_Leave(sender As Object, e As EventArgs) Handles tbx_Capacidad.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Capacidad_TextChanged(sender As Object, e As EventArgs) Handles tbx_Capacidad.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Porcentaje_Click(sender As Object, e As EventArgs) Handles tbx_Porcentaje.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Porcentaje) = True
    End Sub

    Private Sub tbx_Porcentaje_Enter(sender As Object, e As EventArgs) Handles tbx_Porcentaje.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Porcentaje) = True
    End Sub

    Private Sub tbx_Porcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Porcentaje.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                Call AgregarCaset()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Porcentaje_Leave(sender As Object, e As EventArgs) Handles tbx_Porcentaje.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Porcentaje_TextChanged(sender As Object, e As EventArgs) Handles tbx_Porcentaje.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lsv_Casets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Casets.SelectedIndexChanged
        varPub.SegundosSesion = 0
        btn_CambiarStatus.Enabled = lsv_Casets.SelectedItems.Count > 0
        btn_Eliminar.Enabled = lsv_Casets.SelectedItems.Count > 0
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        varPub.SegundosSesion = 0
        lsv_Casets.SelectedItems.Clear()
        ctrlTeclado.Hide()
        Call AgregarCaset()
    End Sub

    Private Sub btn_CambiarStatus_Click(sender As Object, e As EventArgs) Handles btn_CambiarStatus.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        'Al dar de Baja caset {verficar que no este en uso, ni que tengan depositos}
        If lsv_Casets.SelectedItems(0).SubItems(1).Text = varPub.Serie_Caset1 OrElse _
        lsv_Casets.SelectedItems(0).SubItems(1).Text = varPub.Serie_Caset2 Then
            fn_MsgBox("El caset está siendo usando no se puede dar de baja", MessageBoxIcon.Exclamation)
            pnl_General.Enabled = True
            Exit Sub
        Else
            If fn_Casets_Status(lsv_Casets.SelectedItems(0).SubItems(1).Text, lsv_Casets.SelectedItems(0).SubItems(4).Text) Then
                Call LlenarLista()
            End If
        End If
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        '--------------
        'Accion Pendiente 25/Junio/2013
        'al Eliminar KCT {verifica que no esten en uso, ni Que tengan depositos}
        If lsv_Casets.SelectedItems(0).SubItems(1).Text = varPub.Serie_Caset1 OrElse _
        lsv_Casets.SelectedItems(0).SubItems(1).Text = varPub.Serie_Caset2 Then

            fn_MsgBox("El caset está siendo usando no se puede eliminar", MessageBoxIcon.Exclamation)
            pnl_General.Enabled = True
            Exit Sub
        End If


        Dim CasetCant As Integer = fn_Casets_Eliminar(lsv_Casets.SelectedItems(0).SubItems(1).Text, lsv_Casets.SelectedItems(0).SubItems(5).Text)

        Select Case CasetCant
            Case -1
                fn_MsgBox("Ocurrió un error al eliminar el Caset. ", MessageBoxIcon.Error, True, 2)
            Case 0
                fn_MsgBox("No se puede eliminar Caset, tiene depósitos realizados.", MessageBoxIcon.Error, True, 2)
            Case 1
                fn_MsgBox("Caset eliminado correctamente. ", MessageBoxIcon.Information, True, 2)
                Call LlenarLista()
        End Select

        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Me.Close()
    End Sub
End Class