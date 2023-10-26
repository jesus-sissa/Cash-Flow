Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_Correo
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Public Class frm_Cerradura

Private Sub frm_Cerradura_Load(sender As Object, e As EventArgs) Handles Me.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 11

        Llenar_Controles()

    End Sub

#Region "FUNCIONES PRIVADAS"

Private Sub Llenar_Controles()

    Dim Dt_Cerradura = fn_Cerradura_Consultar()
   If Dt_Cerradura.Rows.Count > 0 Then
      Lbl_NumBateria2.Text = Dt_Cerradura.Rows(0).Item(0).ToString
     lbl_Clave2.Text = Dt_Cerradura.Rows(0).Item(4).ToString
     Lbl_Nombre2.Text = Dt_Cerradura.Rows(0).Item(5).ToString
     btn_FechaPuesta.Text = Dt_Cerradura.Rows(0).Item(1).ToString
     Lbl_FechaEx2.Text = Format(Dt_Cerradura.Rows(0).Item(2), "dd/MM/yyyy")
     Lbl_Estat2.Text = Dt_Cerradura.Rows(0).Item(7).ToString
     cmb_Meses.Text = Dt_Cerradura.Rows(0).Item(6).ToString

     Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "CONTROLES CARGADOS CORRECTAMENTE")
   ElseIf Dt_Cerradura.Rows.Count = 0 Then
         cmb_Meses.Text = "3"
     btn_FechaPuesta.Text = Format(System.DateTime.Now, "dd/MM/yyyy")
     Else
     fn_MsgBox("Ocurrió un error al consultar datos de cerradura.", MessageBoxIcon.Error, False)
   End If
End Sub
#End Region



Private Sub btn_FechaPuesta_Click(sender As Object, e As EventArgs) Handles btn_FechaPuesta.Click
        varPub.SegundosSesion = 0
        pnl_Cerradura.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaPuesta.Text)
        frm_Fecha.Location = New Point(btn_FechaPuesta.Location.X, (btn_FechaPuesta.Location.Y + btn_FechaPuesta.Height + 5))
        frm_Fecha.ShowDialog()
        btn_FechaPuesta.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_Cerradura.Enabled = True
End Sub

Private Sub btn_Cerradura_Click(sender As Object, e As EventArgs) Handles btn_Cerradura.Click

    Select Case fn_MsgBox("¿Desea cambiar la batería de la cerradura?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Tiempo_Timer:=20, btnAceptarVisible:=True, btnCancelarVisible:=True)
            Case MsgBoxResult.Yes
            Case False
                Exit Sub
        End Select

   If fn_Cerradura_Cambiar(btn_FechaPuesta.Text, cmb_Meses.Text, Lbl_NumBateria2.Text) Then
        If varPub.Conectividad Then
           If cls_CashFlow.fn_VerificaConexionInternet Then
              MandarCorreo("La bateria de la cerradura fue cambiada", "Cerradura", varPub.UsuarioClave, varPub.NombreUser)
              Llenar_Controles()
           End If
        End If
  End If

End Sub

#Region "EVENTOS FORMULARIO"
Private Sub pnl_Cerradura_Click(sender As Object, e As EventArgs) Handles pnl_Cerradura.Click
varPub.SegundosSesion = 0
End Sub


Private Sub Lbl_NumBateria_Click(sender As Object, e As EventArgs) Handles Lbl_NumBateria.Click
varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Clave_Click(sender As Object, e As EventArgs) Handles Lbl_Clave.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Nombre_Click(sender As Object, e As EventArgs) Handles Lbl_Nombre.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Fecha_Click(sender As Object, e As EventArgs) Handles Lbl_Fecha.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_FechaEx_Click(sender As Object, e As EventArgs) Handles Lbl_FechaEx.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Estat_Click(sender As Object, e As EventArgs) Handles Lbl_Estat.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Meses_Click(sender As Object, e As EventArgs) Handles Lbl_Meses.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_NumBateria2_Click(sender As Object, e As EventArgs) Handles Lbl_NumBateria2.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub lbl_Clave2_Click(sender As Object, e As EventArgs) Handles lbl_Clave2.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Nombre2_Click(sender As Object, e As EventArgs) Handles Lbl_Nombre2.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_FechaEx2_Click(sender As Object, e As EventArgs) Handles Lbl_FechaEx2.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub Lbl_Estat2_Click(sender As Object, e As EventArgs) Handles Lbl_Estat2.Click
  varPub.SegundosSesion = 0
End Sub

Private Sub cmb_Meses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Meses.SelectedIndexChanged
  varPub.SegundosSesion = 0
End Sub

Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
  varPub.SegundosSesion = 0
  Me.Close()
End Sub

    Private Sub pnl_Cerradura_Paint(sender As Object, e As PaintEventArgs) Handles pnl_Cerradura.Paint

    End Sub
#End Region

End Class