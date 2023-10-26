Imports Modulo_CashFlowV2.cls_Actualizacion

Public Class frm_Actualizar

    Private Sub LlenarLista()
        Call fn_Actualizacion_Llenar(lsv_Actualizar)
    End Sub

    Private Sub frm_Actualizar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 1

        pnl_Actualizacion.Enabled = False

        lsv_Actualizar.Columns.Add("Descripcion", 250)
        lsv_Actualizar.Columns.Add("FechaRegistro", 150)

        Cursor = Cursors.WaitCursor
        Call LlenarLista() 'llena lista con usuarioss
        Cursor = Cursors.Default


        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = (rtb_Observaciones.Location.Y - ctrlTeclado.Height)
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        pnl_Actualizacion.Enabled = True
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        fn_Actualizacion_Insertar(rtb_Observaciones.Text)
        Call LlenarLista()
        rtb_Observaciones.Clear()
        rtb_Observaciones.Focus()
    End Sub

    Private Sub btn_Mostrar_Click(sender As Object, e As EventArgs) Handles btn_Mostrar.Click
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Me.Close()
    End Sub

    Private Sub rtb_Observaciones_Click(sender As Object, e As EventArgs) Handles rtb_Observaciones.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(rtb_Observaciones) = True

    End Sub

    Private Sub pnl_Actualizacion_Click(sender As Object, e As EventArgs) Handles pnl_Actualizacion.Click
        pnl_Actualizacion.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub
End Class