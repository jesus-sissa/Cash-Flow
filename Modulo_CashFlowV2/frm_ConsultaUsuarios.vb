Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_Usuarios
Imports Modulo_CashFlowV2.cls_FuncionesPublicas


Public Class frm_ConsultaUsuarios

    Public Acc As Acciones = Acciones.X
    Public CambioPsw As Boolean = False

#Region "Funciones Privadas"

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones) 'MODIFICADO
    End Sub

    Private Sub LlenarLista()
        Call fn_Usuarios_Llenar(lsv_Usuarios)
        btn_Editar.Enabled = False
        btn_CambiarStatus.Enabled = False
        btn_Eliminar.Enabled = False
        btn_ReiniciarPassword.Enabled = False

        lsv_Usuarios.SmallImageList = iml_Sincronia

        If lsv_Usuarios.Items.Count = 0 Then Exit Sub ' si no hay elemento en la lista entonces finalizar la ejecución.
        For Each lvi As ListViewItem In lsv_Usuarios.Items
            If lvi.SubItems(6).Text = "S" Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If
        Next

        lsv_Usuarios.Columns(6).Width = 0
        lsv_Usuarios.Columns(0).Width = 100
        lsv_Usuarios.Columns(0).Width = 110

    End Sub

    Private Sub LimpiaTexbox()
        gbx_Tipo.Enabled = True
        tbx_Clave.Text = String.Empty
        tbx_NombreCompleto.Text = String.Empty
        tbx_ContrasenaActual.Text = String.Empty
        tbx_ContrasenaNueva.Text = String.Empty
        tbx_Confirmar.Text = String.Empty
        tbx_NombreCorto.Text = String.Empty
        rdb_Local.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_Local.Checked = False
        rdb_Local.ForeColor = Color.Black

        rdb_Admin.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_Admin.Checked = False
        rdb_Admin.ForeColor = Color.Black

        tbx_Clave.Enabled = True
        tbx_NombreCompleto.Enabled = True
        tbx_Confirmar.Enabled = False
        tbx_ContrasenaNueva.Enabled = False

    End Sub

    Private Sub Validar()

        pClave = tbx_Clave.Text
        pNombre = tbx_NombreCompleto.Text
        pNombreCortoUser = tbx_NombreCorto.Text
        pContrasenaActual = tbx_ContrasenaActual.Text
        pContrasenaNueva = tbx_ContrasenaNueva.Text
        pConfirmar = tbx_Confirmar.Text
        Dim Tipo_Usuario As Byte = 1 'Local
        If rdb_Admin.Checked Then Tipo_Usuario = 2 'Admin

        pTipo_Usuario = Tipo_Usuario
        pAccion = Acc

        Select Case fn_Usuario_Validar()
            Case -1
                Call fn_MsgBox("Ocurrió un error al editar/crear el usuario.", MessageBoxIcon.Error)
                tbx_Clave.Focus()
            Case 0
                'If Not tbx_Clave.Enabled Then Me.Close()
                Call LimpiaTexbox()
                CambioPsw = True

                If Acc = Acciones.CambiarContrasena Then
                    Call fn_MsgBox("Se cambio la contraseña correctamente.", MessageBoxIcon.Information)
                    Me.Close()
                Else
                    Call fn_MsgBox("Datos guardados correctamente.", MessageBoxIcon.Information)
                    rdb_Local.Checked = True
                    rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
                    Tab_Usuarios.SelectedIndex = 0
                End If

            Case 1
                tbx_Clave.Focus()
                tbx_Clave.SelectAll()

            Case 2
                tbx_ContrasenaActual.Focus()
                tbx_ContrasenaActual.SelectAll()

            Case 3
                tbx_ContrasenaNueva.Focus()
                tbx_ContrasenaNueva.SelectAll()

            Case 4
                tbx_Confirmar.Focus()
                tbx_Confirmar.SelectAll()

            Case 5
                gbx_Tipo.Focus()

            Case 6
                tbx_NombreCompleto.Focus()
                tbx_NombreCompleto.SelectAll()
            Case 7
                tbx_NombreCorto.Focus()
                tbx_NombreCorto.SelectAll()
            Case -9
                fn_MsgBox("Error de conexión de red, no se puede comprobar en la base de datos central.", MessageBoxIcon.Error)
                Me.Close()
        End Select
    End Sub

#End Region

    Private Sub frm_ConsultaUsuarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_ConsultaUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        varPub.IdPantalla = 19
        pnl_General.Enabled = False
        Call CambiarTamanodelosControles()
        varTecl.ubicaY_Teclado = tab_Usuarios.Location.Y + tab_Usuarios.ItemSize.Height

        'verificar si biene a cambiar paword o nuevo
        If Acc = Acciones.CambiarContrasena Then

            If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.miniNUMEROS Then
                forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.miniNUMEROS
                ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
                ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
            End If
            varTecl.ubicaX_Teclado = varTecl.AnchoPantalla - ctrlTeclado.Width 'las 2 lineas son para centrarlos

            lbl_ContrasenaActual.Visible = True
            lbl_ContrasenaNueva.Visible = True
            lbl_Confirmar.Visible = True
            tbx_ContrasenaActual.Visible = True
            tbx_ContrasenaNueva.Visible = True
            tbx_Confirmar.Visible = True
            varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + CInt(tbx_NombreCorto.Location.Y) + CInt(tbx_NombreCorto.Height) + 5)
        Else
            lsv_Usuarios.Columns.Add("Clave", 150)
            lsv_Usuarios.Columns.Add("Nombre", 150)
            lsv_Usuarios.Columns.Add("NombreCorto", 160)
            lsv_Usuarios.Columns.Add("Tipo", 80)
            lsv_Usuarios.Columns.Add("FechaRegistro", 140)
            lsv_Usuarios.Columns.Add("Estatus", 90)
            lsv_Usuarios.Columns.Add("Sincronizado", 0)

            Cursor = Cursors.WaitCursor
            '------------verifica conectividad haciendo ping a google
            If (varPub.ConexionwebAdmin = 1) Then
                If fn_VerificaConexionInternet() Then fn_SincronizarUsuarios_aLOCAL(varPub.Cve_Sucursal) ' descarga usuarios agregados
            End If
            Cursor = Cursors.Default

            Call LlenarLista() 'llena lista con usuarios
            lsv_Usuarios.Columns(6).Width = 0

            If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
                forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
                ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
                ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
            End If
            varTecl.ubicaX_Teclado = 0
            varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + CInt(tbx_NombreCorto.Location.Y) + CInt(tbx_NombreCorto.Height) + 5)

        End If
        pnl_General.Enabled = True

    End Sub

    Private Sub tab_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_Usuarios.SelectedIndexChanged
        varpub.SegundosSesion = 0

        If tab_Usuarios.SelectedIndex = 1 Then
            If tbp_Nuevo.Text = "Modificar" Then
                Acc = Acciones.Editar
                  ctrlTeclado.Hide()
            Else
                tbx_ContrasenaActual.Enabled = False
                tbx_ContrasenaNueva.Enabled = False
                tbx_Confirmar.Enabled = False
                rdb_Local.Checked = True
                rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
                Acc = Acciones.Nuevo
                lsv_Usuarios.SelectedItems.Clear()
                  If varPub.Cve_Sucursal <> "" Then
'----------------------------------------------------------------------------------
                     For i As Integer = 1 To varPub.Cve_Sucursal.Length

                        If Not (Mid(varPub.Cve_Sucursal, i, 1) Like "[0-9]") Then 'si hay letras no puede generar clave
                           GoTo Continuar
                        End If
                            If Mid(varPub.Cve_Sucursal, 1, 1) Like "0" Then 'si el primer número es 0 no puede generar la clave
                              GoTo Continuar
                           End If
                     Next

                    tbx_Clave.Text = fn_GenerarClaves() 'Genera la nueva clave consecutiva 
                    tbx_Clave.Enabled = False
                    tbx_NombreCompleto.Focus()
'----------------------------------------------------------------------------------
                  Else
Continuar:
                    tbx_Clave.Focus()
                  End If
           End If
        Else
            ctrlTeclado.Hide()
            Call LlenarLista() 'Refresca la lista
            Call LimpiaTexbox()
            tbp_Nuevo.Text = "Nuevo"
            Acc = 0
        End If
    End Sub

    Private Sub lsv_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Usuarios.SelectedIndexChanged
        varPub.SegundosSesion = 0
        btn_Editar.Enabled = False
        btn_Eliminar.Enabled = False
        btn_ReiniciarPassword.Enabled = False
        btn_CambiarStatus.Enabled = False

        If lsv_Usuarios.SelectedItems.Count = 0 Then Exit Sub
        btn_Editar.Enabled = lsv_Usuarios.SelectedItems(0).SubItems(5).Text = "ACTIVO"

        btn_CambiarStatus.Enabled = lsv_Usuarios.SelectedItems.Count > 0 AndAlso lsv_Usuarios.SelectedItems(0).Text <> varPub.UsuarioClave
        btn_Eliminar.Enabled = lsv_Usuarios.SelectedItems.Count > 0 AndAlso lsv_Usuarios.SelectedItems(0).Text <> varPub.UsuarioClave
        btn_ReiniciarPassword.Enabled = lsv_Usuarios.SelectedItems.Count > 0

    End Sub

    Private Sub btn_Editar_Click(sender As Object, e As EventArgs) Handles btn_Editar.Click
        pnl_General.Enabled = False
        varpub.SegundosSesion = 0
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "EDITAR USUARIO")
        Dim dt_Datos As DataTable = fn_Usuarios_Read(lsv_Usuarios.SelectedItems(0).Text)
        If dt_Datos Is Nothing OrElse dt_Datos.Rows.Count = 0 Then
            Exit Sub
        End If

        Acc = Acciones.Editar
        tbx_Clave.Enabled = False
        tbx_ContrasenaActual.Enabled = False
        tbx_ContrasenaNueva.Enabled = False
        tbx_Confirmar.Enabled = False

        tbx_Clave.Text = dt_Datos.Rows(0)("Clave_Usuario")
        tbx_NombreCompleto.Text = dt_Datos.Rows(0)("Nombre_Usuario")
        tbx_NombreCorto.Text = dt_Datos.Rows(0)("Nombre_Corto")

        Select Case dt_Datos.Rows(0)("Tipo_Usuario")
            Case 1
                rdb_Local.Checked = True
                rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
            Case 2
                rdb_Admin.Checked = True
                rdb_Admin.Image = My.Resources.RadioButton_Checked_24x24
        End Select
        tbp_Nuevo.Text = "Modificar"
        tab_Usuarios.SelectedTab = tbp_Nuevo
        lsv_Usuarios.SelectedItems.Clear() 'Deseleccionar

        'si es usuario 2 y es modificar, no debe modificar su tipo usuario
        If varPub.TipoUser = 2 And CInt(tbx_Clave.Text) = varPub.UsuarioClave Then
            gbx_Tipo.Enabled = False
        Else
            gbx_Tipo.Enabled = True
        End If
        pnl_General.Enabled = True

    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        'eliminar usuario  .<> de logueado y que no tenga depositos
        '--eliminar aki y en web
        varPub.SegundosSesion = 0

        If lsv_Usuarios.SelectedItems(0).Text = varPub.UsuarioClave Then
            fn_MsgBox("No se puede eliminar Usuario Administrador. ", MessageBoxIcon.Error, True, 2)
            Exit Sub
        End If

        pnl_General.Enabled = False
        '--------------
        Dim UsuarioCant As Integer = fn_Usuarios_Eliminar(lsv_Usuarios.SelectedItems(0).Text)

        Select Case UsuarioCant
            Case -1
                fn_MsgBox("Ocurrió un error al eliminar el Usuario seleccionado. ", MessageBoxIcon.Error, True, 2)
            Case 0
                fn_MsgBox("No se puede eliminar Usuario, porque ha realizado depósitos.", MessageBoxIcon.Exclamation, True, 2)
            Case 1
                fn_MsgBox("Usuario eliminado correctamente. ", MessageBoxIcon.Information, True, 2)
                Call LlenarLista()
        End Select
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_ReiniciarPassword_Click(sender As Object, e As EventArgs) Handles btn_ReiniciarPassword.Click
        varPub.SegundosSesion = 0

        If lsv_Usuarios.SelectedItems.Count = 0 Then Exit Sub
        pnl_General.Enabled = False
        '--------------
        If fn_Usuarios_ReiniciarPassword(lsv_Usuarios.SelectedItems(0).Text) Then
            fn_MsgBox("La contraseña se reinició correctamente", MessageBoxIcon.Information, True, 2)
            Call LlenarLista()
        End If
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_CambiarStatus_Click(sender As Object, e As EventArgs) Handles btn_CambiarStatus.Click
        pnl_General.Enabled = False
        varpub.SegundosSesion = 0
        If fn_Usuarios_Status(lsv_Usuarios.SelectedItems(0).Text, lsv_Usuarios.SelectedItems(0).SubItems(5).Text) Then
            Call LlenarLista()
        End If
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

#Region " Eventos de la pestaña <<Nuevo>> en Tab Usuarios"

    Private Sub tbx_Clave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbx_Clave.Click

        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Clave) = True
    End Sub

     Private Sub tbx_NombreCompleto_Click(sender As Object, e As EventArgs) Handles tbx_NombreCompleto.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreCompleto) = True
    End Sub

    Private Sub tbx_ContrasenaActual_Click(sender As Object, e As EventArgs) Handles tbx_ContrasenaActual.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ContrasenaActual) = True
    End Sub

    Private Sub tbx_ContrasenaNueva_Click(sender As Object, e As EventArgs) Handles tbx_ContrasenaNueva.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ContrasenaNueva) = True
    End Sub

    Private Sub tbx_Confirmar_Click(sender As Object, e As EventArgs) Handles tbx_Confirmar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Confirmar) = True
    End Sub

    Private Sub tbx_Clave_Enter(sender As Object, e As EventArgs) Handles tbx_Clave.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Clave) = True
    End Sub

    Private Sub tbx_NombreCompleto_Enter(sender As Object, e As EventArgs) Handles tbx_NombreCompleto.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreCompleto) = True
    End Sub

    Private Sub tbx_ContrasenaActual_Enter(sender As Object, e As EventArgs) Handles tbx_ContrasenaActual.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ContrasenaActual) = True
    End Sub

    Private Sub tbx_ContrasenaNueva_Enter(sender As Object, e As EventArgs) Handles tbx_ContrasenaNueva.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ContrasenaNueva) = True
    End Sub

    Private Sub tbx_Confirmar_Enter(sender As Object, e As EventArgs) Handles tbx_Confirmar.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Confirmar) = True
    End Sub

    Private Sub tbx_Clave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Clave.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                If tbx_NombreCompleto.Enabled Then
                    tbx_NombreCompleto.Focus()
                ElseIf gbx_Tipo.Enabled Then
                    gbx_Tipo.Focus()
                ElseIf tbx_NombreCorto.Enabled Then
                    tbx_NombreCorto.Focus()
                Else
                    ctrlTeclado.Hide()
                    Call Validar()
                End If

            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_NombreCompleto.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then

            If tbx_NombreCorto.Enabled Then
                tbx_NombreCorto.Focus()
            Else
                ctrlTeclado.Hide()
                Call Validar()
            End If
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_ContrasenaActual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ContrasenaActual.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                ' Valores correctos Numéricos y Back

            Case Keys.Enter
                If tbx_ContrasenaNueva.Enabled Then
                    tbx_ContrasenaNueva.Focus()
                    tbx_ContrasenaNueva.SelectAll()
                ElseIf tbx_Confirmar.Enabled Then
                    tbx_Confirmar.Focus()
                    tbx_Confirmar.SelectAll()
                ElseIf gbx_Tipo.Enabled Then
                    gbx_Tipo.Focus()
                Else
                    ctrlTeclado.Hide()
                    Call Validar()
                End If

            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub tbx_ContrasenaNueva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ContrasenaNueva.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                If tbx_Confirmar.Enabled Then
                    tbx_Confirmar.Focus()
                    tbx_Confirmar.SelectAll()
                ElseIf gbx_Tipo.Enabled Then
                    gbx_Tipo.Focus()
                Else
                    ctrlTeclado.Hide()
                    Call Validar()
                End If

            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Confirmar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Confirmar.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                If gbx_Tipo.Enabled Then
                    ctrlTeclado.Hide()
                    gbx_Tipo.Focus()
                Else
                    ctrlTeclado.Hide()
                    Call Validar()
                End If

            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Clave_Leave(sender As Object, e As EventArgs) Handles tbx_Clave.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Nombre_Leave(sender As Object, e As EventArgs) Handles tbx_NombreCompleto.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ContrasenaActual_Leave(sender As Object, e As EventArgs) Handles tbx_ContrasenaActual.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ContrasenaNueva_Leave(sender As Object, e As EventArgs) Handles tbx_ContrasenaNueva.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Confirmar_Leave(sender As Object, e As EventArgs) Handles tbx_Confirmar.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Call Validar()
    End Sub

    Private Sub lbl_Advertencia_Click(sender As Object, e As EventArgs) Handles lbl_Advertencia.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Clave_Click(sender As Object, e As EventArgs) Handles lbl_Clave.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Nombre_Click(sender As Object, e As EventArgs) Handles lbl_NombreCompleto.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_ContrasenaActual_Click(sender As Object, e As EventArgs) Handles lbl_ContrasenaActual.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_ContrasenaNueva_Click(sender As Object, e As EventArgs) Handles lbl_ContrasenaNueva.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Confirmar_Click(sender As Object, e As EventArgs) Handles lbl_Confirmar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Tipo_Click(sender As Object, e As EventArgs) Handles lbl_Tipo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub txt_Clave_TextChanged(sender As Object, e As EventArgs) Handles tbx_Clave.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub txt_Nombre_TextChanged(sender As Object, e As EventArgs) Handles tbx_NombreCompleto.TextChanged
        varPub.SegundosSesion = 0
        Call Sugerencia()
    End Sub

    Private Sub Sugerencia()
        varPub.SegundosSesion = 0
        Dim Nombres As String() = Split(tbx_NombreCompleto.Text.Trim, " ")
        Dim NumArreglo As Integer = Nombres.Length
        Dim Sugerencia As String = ""
        Select Case NumArreglo
            Case 2
                Sugerencia = fn_Left(tbx_NombreCompleto.Text, 2) & Nombres(1)
                If Sugerencia.Length > 10 Then
                    Sugerencia = fn_Mid(Sugerencia, 1, 10)
                End If
                tbx_NombreCorto.Text = Replace(Sugerencia, "Ñ", "N")
            Case 3
                Sugerencia = fn_Left(tbx_NombreCompleto.Text, 2) & fn_Left(Nombres(1), 3) & Nombres(2)
                If Sugerencia.Length > 10 Then
                    Sugerencia = fn_Mid(Sugerencia, 1, 10)
                End If
                tbx_NombreCorto.Text = Replace(Sugerencia, "Ñ", "N")
            Case Else
                If tbx_NombreCompleto.Text.Trim = "" Then tbx_NombreCorto.Clear()
        End Select
    End Sub

    Private Sub txt_ContrasenaActual_TextChanged(sender As Object, e As EventArgs) Handles tbx_ContrasenaActual.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub txt_ContrasenaNueva_TextChanged(sender As Object, e As EventArgs) Handles tbx_ContrasenaNueva.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub txt_Confirmar_TextChanged(sender As Object, e As EventArgs) Handles tbx_Confirmar.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbp_Nuevo_Click(sender As Object, e As EventArgs) Handles tbp_Nuevo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub btn_CerrarNewuser_Click(sender As Object, e As EventArgs) Handles btn_CerrarNewuser.Click
        varPub.SegundosSesion = 0
        If tbp_Nuevo.Text = "Cambiar Contraseña" And CambioPsw = True Then
            varPub.UsuarioClave = 0 ' para que vuelva a loguearse
            ctrlTeclado.Hide()
            Me.Close()
            ' Exit Sub
        ElseIf tbp_Nuevo.Text = "Modificar" OrElse tbp_Nuevo.Text = "Nuevo" Then
            tbp_Nuevo.Text = "Nuevo" 'al seleccionar el tab, en automatico llama lo ue tiene ahy dentro
            Call LlenarLista()
            tab_Usuarios.SelectedTab = tbp_ListadoUser
            ctrlTeclado.Hide()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub rdb_Local_Click(sender As Object, e As EventArgs) Handles rdb_Local.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
        rdb_Admin.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_Admin_Click(sender As Object, e As EventArgs) Handles rdb_Admin.Click
        varPub.SegundosSesion = 0
        rdb_Admin.Image = My.Resources.RadioButton_Checked_24x24
        rdb_Local.Image = My.Resources.RadioButton_UnChecked_24x24

    End Sub

    Private Sub tbx_NombreCorto_Click(sender As Object, e As EventArgs) Handles tbx_NombreCorto.Click
        tbx_NombreCorto.SelectAll()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreCorto) = True
    End Sub

    Private Sub tbx_NombreCorto_Enter(sender As Object, e As EventArgs) Handles tbx_NombreCorto.Enter
        tbx_NombreCorto.SelectAll()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreCorto) = True
    End Sub

    Private Sub tbx_NombreCorto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_NombreCorto.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            ctrlTeclado.Hide()
            Call Validar()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_NombreCorto_Leave(sender As Object, e As EventArgs) Handles tbx_NombreCorto.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NombreCorto_TextChanged(sender As Object, e As EventArgs) Handles tbx_NombreCorto.TextChanged
        varPub.SegundosSesion = 0
    End Sub

#End Region

End Class