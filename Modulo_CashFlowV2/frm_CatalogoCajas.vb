Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Public Class frm_CatalogoCajas
    Private Actualizar As Boolean
    Private IdCaja As Integer
    Private IpCajaAnterior As String
    Private Descripcion As String

    Private Sub CambiarTamanodelosControles()
        fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub


    Private Sub LlenarLista()
        Call fn_Cajas_Llenar(lsv_Cajas)
        btn_CambiarStatusCaja.Enabled = False
        btn_EliminarCaja.Enabled = False

        lsv_Cajas.SmallImageList = iml_Sincronia
        For Each lvi As ListViewItem In lsv_Cajas.Items
            If lvi.SubItems(4).Text = "S" Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If
        Next
        lsv_Cajas.Columns(4).Width = 0
        lsv_Cajas.Columns(2).Width = 0

    End Sub


    Private Sub AgregarCajas()

        pnl_Cajas.Enabled = False

        ''SINCRONIZAR CAJA SI HAY de Web a Local
        'fn_SincronizarCasets(Cve_Sucursal)

        If Actualizar Then
            If IpCajaAnterior = tbx_IpCaja.Text And Descripcion = tbx_DescripcionCaja.Text Then
                Call fn_MsgBox("Caja actualizada correctamente.", MessageBoxIcon.Information)
                pnl_Cajas.Enabled = True
                tbx_NumeroCaja.Text = String.Empty
                tbx_DescripcionCaja.Text = String.Empty
                tbx_IpCaja.Text = String.Empty
                tbx_NumeroCaja.Enabled = True
                Actualizar = False
                btn_EliminarCaja.Enabled = True
                Exit Sub
            End If
        End If


        Select Case fn_Cajas_Create(tbx_NumeroCaja.Text.ToUpper, tbx_DescripcionCaja.Text.ToUpper, tbx_IpCaja.Text, Actualizar, IdCaja)
            Case 1

                If Actualizar Then
                    Call fn_MsgBox("Caja actualizada correctamente.", MessageBoxIcon.Information)
                    Call ActualizarListaCajas()
                    tbx_NumeroCaja.Enabled = True
                    Actualizar = False
                    btn_EliminarCaja.Enabled = True
                Else
                    Call fn_MsgBox("Caja guardada correctamente.", MessageBoxIcon.Information)
                    Call ActualizarListaCajas()
                    Dim Persistente As New cls_VariablesPersistentes()
                    Persistente.Persistir()
                    Persistente.Cargar()
                End If

            Case 2
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("Capture el número de Caja.", MessageBoxIcon.Exclamation)
                tbx_NumeroCaja.Focus()

            Case 3
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("El número de Caja ya existe en la base de datos, capture Otra.", MessageBoxIcon.Exclamation)
                tbx_NumeroCaja.Focus()
            Case 4
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("Capture una Descripción.", MessageBoxIcon.Exclamation)
                tbx_DescripcionCaja.Focus()

            Case 5
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("Imposible agregar la Caja porque ha superado la cantidad máxima.", MessageBoxIcon.Information)
            Case 6
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("Capture la Ip de Caja.", MessageBoxIcon.Exclamation)
            Case 7
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("El número de Ip ya existe en la base de datos, capture otra.", MessageBoxIcon.Exclamation)
            Case 8
                pnl_Cajas.Enabled = True
                Call fn_MsgBox("Ip Caja dato no válido.", MessageBoxIcon.Exclamation)
        End Select
        pnl_Cajas.Enabled = True
    End Sub

    Public Sub ActualizarListaCajas()
        pnl_Cajas.Enabled = True
        Call LlenarLista()
        tbx_NumeroCaja.Text = String.Empty
        tbx_DescripcionCaja.Text = String.Empty
        tbx_IpCaja.Text = String.Empty
    End Sub


    Private Sub frm_CatalogoCajas_Load(sender As Object, e As EventArgs) Handles Me.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 6

        pnl_Cajas.Enabled = False
        varPub.SegundosSesion = 0
        Call CambiarTamanodelosControles()

        Dim WidthCajas As Integer = (lsv_Cajas.Width / 5)

        lsv_Cajas.Columns.Add("Numero Caja", WidthCajas)
        lsv_Cajas.Columns.Add("Descripcion", WidthCajas)

        Cursor = Cursors.WaitCursor


        'sincronizar cajas si existen(de Web a Local)
        If (varPub.ConexionwebAdmin = 1) Then
            If fn_VerificaConexionInternet() Then
                If Not fn_SincronizarCajas_aLOCAL(varPub.Cve_Sucursal) Then
                    fn_MsgBox("Ocurrió un error al Descagar las Cajas", MessageBoxIcon.Error, True, 3)
                End If
            End If

        End If



        Cursor = Cursors.Default
        Call LlenarLista()


        pnl_Cajas.Enabled = True
        btn_AgregarCaja.Select()

        If varPub.ManejaConexionWebService = 0 Then tbx_IpCaja.Enabled = False


        '----------------------------------------
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = lsv_Cajas.Location.Y + 65
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)
    End Sub

    Private Sub btn_AgregarCaja_Click(sender As Object, e As EventArgs) Handles btn_AgregarCaja.Click
        varPub.SegundosSesion = 0
        lsv_Cajas.SelectedItems.Clear()
        ctrlTeclado.Hide()
        Call AgregarCajas()
    End Sub

    Private Sub btn_CambiarStatusCaja_Click(sender As Object, e As EventArgs) Handles btn_CambiarStatusCaja.Click
        pnl_Cajas.Enabled = False
        varPub.SegundosSesion = 0
        'Al dar de Baja caset {verficar que no este en uso, ni que tengan depositos}

        If lsv_Cajas.SelectedItems(0).SubItems(3).Text = "BAJA" Then

            If fn_Caja_Maxima() Then
                Call fn_MsgBox("Imposible activar la Caja porque  la cantidad limite a mostrar Son 18, para poder hacerlo se debe primero dar de baja Una y Activar la Deseada", MessageBoxIcon.Information, True, 3)
                pnl_Cajas.Enabled = True
                Exit Sub
            End If


        End If
     
        fn_Caja_Status(lsv_Cajas.SelectedItems(0).Tag, lsv_Cajas.SelectedItems(0).SubItems(0).Text, lsv_Cajas.SelectedItems(0).SubItems(3).Text)

        Call LlenarLista()

        pnl_Cajas.Enabled = True
    End Sub

    Private Sub btn_EliminarCaja_Click(sender As Object, e As EventArgs) Handles btn_EliminarCaja.Click
        pnl_Cajas.Enabled = False
        varPub.SegundosSesion = 0
        Dim CajaExiste As Integer = 0

        CajaExiste = fn_VerificarCajaExiste_EnDepositos(lsv_Cajas.SelectedItems(0).Tag)

        If CajaExiste = -1 Then
            fn_MsgBox("Ocurrió un error al válidar Caja existe en Depósitos.", MessageBoxIcon.Error, True, 3)
            pnl_Cajas.Enabled = True
            Exit Sub
        End If

        If CajaExiste > 0 Then
            fn_MsgBox("No  se puede eliminar la Caja porque cuenta con Depósitos.", MessageBoxIcon.Information, True, 3)
            pnl_Cajas.Enabled = True
            Exit Sub
        End If



        Dim CajaCant As Integer = fn_Cajas_Eliminar(lsv_Cajas.SelectedItems(0).Tag, lsv_Cajas.SelectedItems(0).Text)
        Select Case CajaCant
            Case -1
                fn_MsgBox("Ocurrió un error al eliminar la Caja. ", MessageBoxIcon.Error, True, 2)
            Case 1
                Call LlenarLista()
                fn_MsgBox("Caja eliminada correctamente. ", MessageBoxIcon.Information, True, 2)
                Dim Persistente As New cls_VariablesPersistentes()
                Persistente.Persistir()
                Persistente.Cargar()
        End Select

        pnl_Cajas.Enabled = True

    End Sub

    Private Sub btn_CerrarCaja_Click(sender As Object, e As EventArgs) Handles btn_CerrarCaja.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Me.Close()
    End Sub

    Private Sub pnl_Cajas_Click(sender As Object, e As EventArgs) Handles pnl_Cajas.Click
        pnl_Cajas.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_NumeroCaja_Click(sender As Object, e As EventArgs) Handles tbx_NumeroCaja.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NumeroCaja) = True
    End Sub

    Private Sub tbx_NumeroCaja_Enter(sender As Object, e As EventArgs) Handles tbx_NumeroCaja.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NumeroCaja) = True
    End Sub

    Private Sub tbx_NumeroCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_NumeroCaja.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_DescripcionCaja.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_NumeroCaja_Leave(sender As Object, e As EventArgs) Handles tbx_NumeroCaja.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NumeroCaja_TextChanged(sender As Object, e As EventArgs) Handles tbx_NumeroCaja.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DescripcionCaja_Click(sender As Object, e As EventArgs) Handles tbx_DescripcionCaja.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DescripcionCaja) = True
    End Sub

    Private Sub tbx_DescripcionCaja_Enter(sender As Object, e As EventArgs) Handles tbx_DescripcionCaja.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DescripcionCaja) = True
    End Sub

    Private Sub tbx_DescripcionCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_DescripcionCaja.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_IpCaja.Focus()
            If varPub.ManejaConexionWebService = 0 Then
                lsv_Cajas.SelectedItems.Clear()
                ctrlTeclado.Hide()
                Call AgregarCajas()
            End If
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_DescripcionCaja_Leave(sender As Object, e As EventArgs) Handles tbx_DescripcionCaja.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DescripcionCaja_TextChanged(sender As Object, e As EventArgs) Handles tbx_DescripcionCaja.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lsv_Cajas_SelectedIndexChanged(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        btn_CambiarStatusCaja.Enabled = lsv_Cajas.SelectedItems.Count > 0
        btn_EliminarCaja.Enabled = lsv_Cajas.SelectedItems.Count > 0
    End Sub

    Private Sub lsv_Cajas_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles lsv_Cajas.SelectedIndexChanged
        varPub.SegundosSesion = 0
        btn_Editar.Enabled = False
        btn_CambiarStatusCaja.Enabled = False
        btn_EliminarCaja.Enabled = False
        btn_Editar.Enabled = False

        If lsv_Cajas.SelectedItems.Count > 0 Then
            btn_CambiarStatusCaja.Enabled = lsv_Cajas.SelectedItems.Count > 0
            btn_EliminarCaja.Enabled = lsv_Cajas.SelectedItems.Count > 0
            btn_Editar.Enabled = lsv_Cajas.SelectedItems.Count > 0
            If lsv_Cajas.SelectedItems(0).SubItems(3).Text = "BAJA" Then btn_Editar.Enabled = False
            IdCaja = lsv_Cajas.SelectedItems(0).Tag
        End If
    End Sub

  
    Private Sub btn_Editar_Click(sender As Object, e As EventArgs) Handles btn_Editar.Click
        If lsv_Cajas.Items.Count > 0 Then
            tbx_NumeroCaja.Text = lsv_Cajas.SelectedItems(0).Text
            tbx_DescripcionCaja.Text = lsv_Cajas.SelectedItems(0).SubItems(1).Text
            Descripcion = lsv_Cajas.SelectedItems(0).SubItems(1).Text
            tbx_IpCaja.Text = lsv_Cajas.SelectedItems(0).SubItems(5).Text
            tbx_NumeroCaja.Enabled = False
            Actualizar = True
            IpCajaAnterior = lsv_Cajas.SelectedItems(0).SubItems(5).Text
            btn_EliminarCaja.Enabled = False
        End If
    End Sub

    Private Sub tbx_IpCaja_Click(sender As Object, e As EventArgs) Handles tbx_IpCaja.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_IpCaja) = True
    End Sub

    Private Sub tbx_IpCaja_Enter(sender As Object, e As EventArgs) Handles tbx_IpCaja.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_IpCaja) = True
    End Sub

    Private Sub tbx_IpCaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_IpCaja.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            varPub.SegundosSesion = 0
            lsv_Cajas.SelectedItems.Clear()
            ctrlTeclado.Hide()
            Call AgregarCajas()
        End If
    End Sub

    Private Sub Lsv_Cajas_DoubleClick(sender As Object, e As EventArgs) Handles lsv_Cajas.DoubleClick
        If lsv_Cajas.Items.Count > 0 Then
            'MsgBox(lsv_Cajas.SelectedItems(0).SubItems(3).Text)
            If lsv_Cajas.SelectedItems(0).SubItems(3).Text <> "BAJA" Then
                Dim frm As New Frm_CajasCxn
                frm.id_caja = lsv_Cajas.SelectedItems(0).Tag.ToString()
                frm.ShowDialog()
            End If
        End If
    End Sub
End Class