Imports Modulo_CashFlowV2.cls_Cajascxn
Public Class Frm_CajasCxn
    Public id_caja, Status As String
    Dim ban As Integer = 0
    Private Sub Btn_CerrarCaja_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        varPub.SegundosSesion = 0
        If fn_validar() Then
            ctrlTeclado.Hide()
            If fn_CajasProbarCnxOledb(Tbx_servidor.Text, Tbx_bd.Text, Tbx_usuario.Text, Tbx_contra.Text) Then
                If fn_CajasGuardarCnx(Tbx_servidor.Text, Tbx_bd.Text, Tbx_usuario.Text, Tbx_contra.Text, Convert.ToInt32(id_caja)) Then
                    ctrlTeclado.Hide()
                    Call fn_MsgBox("Se guardo la conexión exitosamente.", MessageBoxIcon.Information, True)
                    Btn_Guardar.Enabled = False
                    Btn_Actualizar.Enabled = True
                    Tbx_servidor.Enabled = False
                    Tbx_bd.Enabled = False
                    Tbx_usuario.Enabled = False
                    Tbx_contra.Enabled = False
                    fn_conexioncajavalores()
                End If
            End If
        Else
            ctrlTeclado.Hide()
            Call fn_MsgBox("Capture los datos correctamente..", MessageBoxIcon.Information, True)
        End If
    End Sub
    Private Sub Btn_cerrar_Click(sender As Object, e As EventArgs) Handles Btn_Cerrar.Click
        ctrlTeclado.Hide()
        Me.Close()
    End Sub

    Private Sub Frm_CajasCxn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 4

        Tbx_servidor.Focus()

        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        fn_conexioncajavalores()
    End Sub
    Function fn_conexioncajavalores()
        Dim dt As New DataTable
        dt = fn_CajasConsultarCnx(id_caja)

        If fn_CajasConsultarCnx(id_caja) IsNot Nothing Then
            If (dt.Rows.Count > 0) Then
                Tbx_servidor.Text = dt.Rows(0)(0).ToString()
                Tbx_bd.Text = dt.Rows(0)(1).ToString()
                Tbx_usuario.Text = dt.Rows(0)(2).ToString()
                Tbx_contra.Text = dt.Rows(0)(3).ToString()
                If (dt.Rows(0)(4).ToString() = "A") Then
                    Lbl_Status.Text = "ACTIVO"
                Else
                    Lbl_Status.Text = "BAJA"
                End If
                Btn_Guardar.Enabled = False
                Btn_Status.Enabled = True
                Tbx_servidor.Enabled = False
                Tbx_bd.Enabled = False
                Tbx_usuario.Enabled = False
                Tbx_contra.Enabled = False
                Lbl_Status.Visible = True
                Lbl_Statuss.Visible = True
            Else
                Btn_Actualizar.Enabled = False
                Btn_Status.Enabled = False
            End If
            Return False
        End If
        Return False
    End Function

    Private Sub Btn_actualizar_Click(sender As Object, e As EventArgs) Handles Btn_Actualizar.Click
        If ban = 0 Then
            varPub.SegundosSesion = 0
            Tbx_servidor.Enabled = True
            Tbx_bd.Enabled = True
            Tbx_usuario.Enabled = True
            Tbx_contra.Enabled = True
            Tbx_servidor.Focus()
            ban = 1
        Else
            If fn_validar() Then
                ctrlTeclado.Hide()
                If fn_CajasProbarCnxOledb(Tbx_servidor.Text, Tbx_bd.Text, Tbx_usuario.Text, Tbx_contra.Text) Then
                    If fn_CajasActualizarCnx(Tbx_servidor.Text, Tbx_bd.Text, Tbx_usuario.Text, Tbx_contra.Text, Convert.ToInt32(id_caja)) Then
                        fn_conexioncajavalores()
                        ctrlTeclado.Hide()
                        Call fn_MsgBox("Se guardo la conexión exitosamente.", MessageBoxIcon.Information, True)
                        ban = 0
                    End If
                End If
            Else
                ctrlTeclado.Hide()
                Call fn_MsgBox("Capture los datos correctamente..", MessageBoxIcon.Information, True)
            End If

        End If
    End Sub
    Private Sub Btn_status_Click(sender As Object, e As EventArgs) Handles Btn_Status.Click
        varPub.SegundosSesion = 0
        If Lbl_Status.Text = "ACTIVO" Then
            fn_CajasStatus(id_caja, "B")
            fn_conexioncajavalores()
        Else
            fn_CajasStatus(id_caja, "A")
            fn_conexioncajavalores()
        End If

    End Sub

    Private Sub Txt_servidor_Click(sender As Object, e As EventArgs) Handles Tbx_servidor.Click
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(Tbx_servidor) = True
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Frm_CajasCxn_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        ctrlTeclado.Hide()
    End Sub

    Private Sub Txt_bd_Click(sender As Object, e As EventArgs) Handles Tbx_bd.Click
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(Tbx_bd) = True
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Txt_usuario_Click(sender As Object, e As EventArgs) Handles Tbx_usuario.Click
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(Tbx_usuario) = True
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Txt_contra_Click(sender As Object, e As EventArgs) Handles Tbx_contra.Click
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(Tbx_contra) = True
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Txt_servidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tbx_servidor.KeyPress
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Txt_bd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tbx_bd.KeyPress
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Txt_usuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tbx_usuario.KeyPress
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Txt_contra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tbx_contra.KeyPress
        varPub.SegundosSesion = 0
    End Sub

    Function fn_validar() As Boolean
        If (Tbx_servidor.Text.Trim() <> Nothing And Tbx_bd.Text.Trim() <> Nothing And Tbx_usuario.Text.Trim() <> Nothing And Tbx_contra.Text.Trim() <> Nothing) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class