Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_CashFlow
Public Class frm_CatalogoCorreos

Private Sub frm_CatalogoCorreos_Click(sender As Object, e As EventArgs) Handles Me.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub

Private Sub frm_CatalogoCorreos_Load(sender As Object, e As EventArgs) Handles Me.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 8

        pnl_General.Enabled = False
        Cursor = Cursors.WaitCursor
     varPub.SegundosSesion = 0
     Call CambiarTamanodelosControles()

     varTecl.ubicaY_Teclado = tab_Correos.Location.Y + tab_Correos.ItemSize.Height

    lsv_Correos.Columns.Add("id_Correo", 0)
    lsv_Correos.Columns.Add("Correo", 450)
    lsv_Correos.Columns.Add("Descripcion", 270)
    lsv_Correos.Columns.Add("Etatus", 120)

   LlenarLista()
   Cursor = Cursors.Default
   pnl_General.Enabled = True

   '---------------------------Cambiar tamaño de teclado
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If
            varTecl.ubicaX_Teclado = 0
            varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + CInt(tbx_Descripcion.Location.Y) + CInt(tbx_Descripcion.Height) + 5)

End Sub

Private Sub btn_Editar_Click(sender As Object, e As EventArgs) Handles btn_Editar.Click
   varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
      tab_Correos.SelectedTab = tbp_Nuevo
      tbp_Nuevo.Text = "Editar"

      tbx_Correo.Text = lsv_Correos.SelectedItems(0).SubItems(1).Text
      tbx_Descripcion.Text = lsv_Correos.SelectedItems(0).SubItems(2).Text

End Sub

Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
   varPub.SegundosSesion = 0
   ctrlTeclado.Hide()
  Select Case fn_ValidarCorreoNuevo(tbx_Correo.Text, tbx_Descripcion.Text)
         Case 1
                Call fn_MsgBox("Debe de colocar un correo.", MessageBoxIcon.Information)
         Case 2
                Call fn_MsgBox("Debe colocar una descripción.", MessageBoxIcon.Information)
         Case 3
                Call fn_MsgBox("El correo no es válido.", MessageBoxIcon.Information)
         Case 4
                Call fn_MsgBox("El correo ya existe, favor de colocar otro.", MessageBoxIcon.Information)
         Case 5
'---------------------------------------------------------------------------------
          If tbp_Nuevo.Text = "Nuevo" Then

               If fn_Agregar_Correos(tbx_Correo.Text, tbx_Descripcion.Text) Then
                  Call fn_MsgBox("Correo guardado correctamente.", MessageBoxIcon.Information)
                  tab_Correos.SelectedTab = tbp_ListadoUser
                  Call LlenarLista()
                   Deseleccionar_Controles()
               Else
                   Call fn_MsgBox("Ocurrió un error al agregar el correo.", MessageBoxIcon.Error)
                     Deseleccionar_Controles()
             End If

          ElseIf tbp_Nuevo.Text = "Editar" Then

               If tbx_Correo.Text = lsv_Correos.SelectedItems(0).SubItems(1).Text And tbx_Descripcion.Text = lsv_Correos.SelectedItems(0).SubItems(2).Text Then
                   Call fn_MsgBox("Correo editado correctamente.", MessageBoxIcon.Information) 'si no se cambió nada de información no consultar a la base de datos
                    Deseleccionar_Controles()
                   tab_Correos.SelectedTab = tbp_ListadoUser
                  Call LlenarLista()
               Else
                    If fn_CorreoEditar(tbx_Correo.Text, tbx_Descripcion.Text, CInt(lsv_Correos.SelectedItems(0).Text)) Then
                      Call fn_MsgBox("Correo editado correctamente.", MessageBoxIcon.Information)
                      tab_Correos.SelectedTab = tbp_ListadoUser
                  Call LlenarLista()
                    Deseleccionar_Controles()
                   Else
                     Call fn_MsgBox("Ocurrió un error al editar.", MessageBoxIcon.Error) '
                      Deseleccionar_Controles()
                    End If
              End If

          End If
  End Select

End Sub


Private Sub tab_Correos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_Correos.SelectedIndexChanged
  varPub.SegundosSesion = 0
   ctrlTeclado.Hide()
If tab_Correos.SelectedIndex = 0 Then
       tbx_Correo.Text = String.Empty
       tbx_Descripcion.Text = String.Empty
       tbp_Nuevo.Text = "Nuevo"
        Deseleccionar_Controles()
Else
tbx_Correo.Focus()
End If

End Sub

Private Sub btn_CerrarNewuser_Click(sender As Object, e As EventArgs) Handles btn_CerrarNewuser.Click
      varPub.SegundosSesion = 0
       tbx_Correo.Text = String.Empty
       tbx_Descripcion.Text = String.Empty
       tbp_Nuevo.Text = "Nuevo"
       tab_Correos.SelectedTab = tbp_ListadoUser
        ctrlTeclado.Hide()
End Sub

Private Sub lsv_Correos_Click(sender As Object, e As EventArgs) Handles lsv_Correos.Click
  varPub.SegundosSesion = 0

  If lsv_Correos.SelectedItems.Count > 0 Then
        btn_Editar.Enabled = False
        btn_CambiarStatus.Enabled = True
   If lsv_Correos.SelectedItems(0).SubItems(3).Text = "Activo" Then
      btn_Editar.Enabled = True
   End If
  Else
  Deseleccionar_Controles()
  End If
End Sub

Private Sub btn_CambiarStatus_Click(sender As Object, e As EventArgs) Handles btn_CambiarStatus.Click
   varPub.SegundosSesion = 0
   ctrlTeclado.Hide()
    If lsv_Correos.SelectedItems.Count > 0 Then
       If fn_CorreoEstatus(lsv_Correos.SelectedItems(0).Text) Then
          Call fn_MsgBox("Estatus cambiado correctamente.", MessageBoxIcon.Information)
          Call LlenarLista()
          Deseleccionar_Controles()
         Else
          Call fn_MsgBox("Ocurrió un error al cambiar el estatus.", MessageBoxIcon.Error)
    End If

    End If
End Sub

#Region "FUCIONES PRIVADAS"
Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones) 'MODIFICADO
    End Sub


 Sub LlenarLista()

Call fn_Llenar_Correos(lsv_Correos)
 End Sub

Private Function fn_ValidarCorreoNuevo(ByVal Correo As String, ByVal Descripcion As String) As Integer

     If Correo = "" Then
        Return 1   'Sin correo
     ElseIf Descripcion = "" Then
        Return 2   'Sin descipción
     ElseIf fn_ValidarMail(Correo) = False Then
        Return 3    'correo no valido
     ElseIf fn_BuscarCorreoExistente() = True Then
            If tbp_Nuevo.Text = "Editar" Then 'al editar se puede quedar el mismo correo
               Return 5 'validación correcta
            Else
               Return 4  'correo ya existente
            End If
     Else
        Return 5 'validación correcta
     End If

End Function

Private Function fn_BuscarCorreoExistente() As Boolean

For Each LsvItem As ListViewItem In lsv_Correos.Items
  For SubItemsCorreo As Integer = 1 To 1
     If LsvItem.SubItems(1).Text = tbx_Correo.Text Then
       Return True
     End If
  Next
Next
Return False
End Function

Private Sub Deseleccionar_Controles()
btn_CambiarStatus.Enabled = False
btn_Editar.Enabled = False
tbx_Correo.Text = String.Empty
tbx_Descripcion.Text = String.Empty
End Sub


#End Region

#Region "EVENTOS FORMULARIO"
Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
       varPub.SegundosSesion = 0
       ctrlTeclado.Hide()
        Me.Close()
End Sub

Private Sub tbx_Correo_Click(sender As Object, e As EventArgs) Handles tbx_Correo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Correo) = True

End Sub

Private Sub tbx_Descripcion_Click(sender As Object, e As EventArgs) Handles tbx_Descripcion.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Descripcion) = True
End Sub

Private Sub tbp_ListadoUser_Click(sender As Object, e As EventArgs) Handles tbp_ListadoUser.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Deseleccionar_Controles()
End Sub

Private Sub lsv_Correos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Correos.SelectedIndexChanged
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Deseleccionar_Controles()
End Sub

Private Sub lbl_Recomendacion2_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub



Private Sub lbl_Recomendacion_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub

Private Sub lbl_Advertencia_Click(sender As Object, e As EventArgs) Handles lbl_Advertencia.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub

Private Sub lbl_Descripcion_Click(sender As Object, e As EventArgs) Handles lbl_Descripcion.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub

Private Sub lbl_CorreoDestinatario_Click(sender As Object, e As EventArgs) Handles lbl_CorreoDestinatario.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub

Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
         varPub.SegundosSesion = 0
         ctrlTeclado.Hide()
         Deseleccionar_Controles()
End Sub

Private Sub tbp_Nuevo_Click(sender As Object, e As EventArgs) Handles tbp_Nuevo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
End Sub

Private Sub tbx_Correo_Enter(sender As Object, e As EventArgs) Handles tbx_Correo.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Correo) = True
End Sub

Private Sub tbx_NombreCompleto_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Descripcion) = True
End Sub
#End Region

Private Sub tbx_Correo_TextChanged(sender As Object, e As EventArgs) Handles tbx_Correo.TextChanged
  varPub.SegundosSesion = 0
End Sub

Private Sub tbx_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles tbx_Descripcion.TextChanged
     varPub.SegundosSesion = 0
End Sub
End Class