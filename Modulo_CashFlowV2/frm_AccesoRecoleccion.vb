Public Class frm_AccesoRecoleccion
    Private Sub frm_AccesoRecoleccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        varPub.SegundosSesion = 0
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If
        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = Me.Location.Y + Me.Height - 30
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)
        keysShow(tbx_Clave)
    End Sub
    Function keysShow(obj As TextBox)
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(obj) = True
        obj.Focus()
    End Function
    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        varPub.SegundosSesion = 0
        validar_Credeciales()
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        varPub.SegundosSesion = 0
        DialogResult = Windows.Forms.DialogResult.Cancel
        ctrlTeclado.Hide()
        Me.Close()
    End Sub
    Private Function validar_Credeciales()
        Dim clave As String = "Sissa" & DateTime.Now.Hour & DateTime.Now.Minute
        If clave = tbx_Clave.Text Then
            If buscar_Punto() AndAlso generar_Remision() Then
                DialogResult = Windows.Forms.DialogResult.OK
                ctrlTeclado.Hide()
                Me.Close()
            Else
                DialogResult = Windows.Forms.DialogResult.No
                ctrlTeclado.Hide()
                Me.Close()
            End If
        Else
            ctrlTeclado.Hide()
            Call fn_MsgBox("La contraseña proporcionada es incorrecta.", MessageBoxIcon.Error, True, 2)
            keysShow(tbx_Clave)
        End If
    End Function
    Private Function buscar_Punto() As Boolean
        Dim WsRemision As New WsRemision.WsCashFlowSoapClient
        Try
            varPub.Id_punto = WsRemision.Obtener_punto(varPub.Cve_Cliente + "%" + varPub.Plaza)
            ' varPub.Id_punto = 0
        Catch ex As Exception
            Return False
        End Try
        If varPub.Id_punto <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function generar_Remision() As Boolean
        Try
            Dim WsRemision As New WsRemision.WsCashFlowSoapClient
            varPub.RemisionWs = WsRemision.Obtener_Remision(varPub.Cve_Cliente + "%" + varPub.Plaza)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbl_fecha.Text = DateTime.Now.Year.ToString + "/" + DateTime.Now.Month.ToString + "/" + DateTime.Now.Day.ToString + "[" + DateTime.Now.Hour.ToString + ":" + DateTime.Now.Minute.ToString + ":" + DateTime.Now.Second.ToString + "]"
    End Sub
    Private Sub tbx_Clave_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles tbx_Clave.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Keys.Enter
                validar_Credeciales()
            Case Else
                e.KeyChar = e.KeyChar
        End Select
    End Sub

    Private Sub tbx_Clave_Click(sender As Object, e As EventArgs) Handles tbx_Clave.Click
        varPub.SegundosSesion = 0
        keysShow(tbx_Clave)
    End Sub
End Class