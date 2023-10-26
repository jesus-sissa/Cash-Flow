Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_Usuarios
Public Class frm_FirmaElectronica

    Public panelBotones As Boolean = False
    Public Apaga_Reinicia As Byte = 0

    Private Sub frm_FirmaElectronica_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        varPub.SegundosSesion = 0
        ' frm.DesactivarMAYUSCULAS() 'esto es para desactivar Block Mayus
        ctrlTeclado.Hide()

    End Sub

    Private Sub frm_FirmaElectronica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 28
        varPub.SegundosSesion = 0
        pnl_Botones.Visible = panelBotones

        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.NUMEROS Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.NUMEROS
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = varTecl.AnchoPantalla - ctrlTeclado.Width
        varTecl.ubicaX_Teclado = varTecl.ubicaX_Teclado / 2
        varTecl.ubicaY_Teclado = pnl_Firma.Location.Y + pnl_Firma.Height + 5
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        If panelBotones = False Then
            pnl_Firma.Visible = True
            tbx_Clave.Select()
        End If

    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub pnl_Botones_Click(sender As Object, e As EventArgs) Handles pnl_Botones.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub pnl_Firma_Click(sender As Object, e As EventArgs) Handles pnl_Firma.Click
        pnl_General.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_Clave_Click(sender As Object, e As EventArgs) Handles tbx_Clave.Click
        tbx_Clave.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Clave) = True
        tbx_Clave.Focus()
    End Sub

    Private Sub tbx_Clave_Enter(sender As Object, e As EventArgs) Handles tbx_Clave.Enter
        tbx_Clave.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Clave) = True
    End Sub

    Private Sub tbx_Clave_GotFocus(sender As Object, e As EventArgs) Handles tbx_Clave.GotFocus
        tbx_Clave.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
    End Sub

    Private Sub tbx_Clave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Clave.KeyPress
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                If tbx_Clave.Text.Trim <> "" AndAlso tbx_Contrasena.Text.Trim = "" Then
                    tbx_Contrasena.Focus()
                Else
                    ctrlTeclado.Hide()
                    Call Validar()
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Clave_Leave(sender As Object, e As EventArgs) Handles tbx_Clave.Leave
        ctrlTeclado.Hide()
        tbx_Clave.BackColor = Color.White
    End Sub

    Private Sub tbx_Contrasena_Click(sender As Object, e As EventArgs) Handles tbx_Contrasena.Click
        tbx_Contrasena.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Contrasena) = True
        tbx_Contrasena.Focus()
    End Sub

    Private Sub tbx_Contrasena_Enter(sender As Object, e As EventArgs) Handles tbx_Contrasena.Enter
        tbx_Contrasena.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Contrasena) = True
        tbx_Contrasena.Focus()
    End Sub

    Private Sub tbx_Contrasena_GotFocus(sender As Object, e As EventArgs) Handles tbx_Contrasena.GotFocus
        tbx_Contrasena.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
    End Sub

    Private Sub tbx_Contrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Contrasena.KeyPress
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                ctrlTeclado.Hide()
                Call Validar()

            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Contrasena_Leave(sender As Object, e As EventArgs) Handles tbx_Contrasena.Leave
        ctrlTeclado.Hide()
        tbx_Contrasena.BackColor = Color.White
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        varPub.SegundosSesion = 0
        DialogResult = Windows.Forms.DialogResult.Cancel
        ctrlTeclado.Hide()
        Me.Close()
    End Sub

    Private Sub btn_Apagar_Click(sender As Object, e As EventArgs) Handles btn_Apagar.Click
        varPub.SegundosSesion = 0
        Apaga_Reinicia = 1
        pnl_Botones.Visible = False
        lbl_AlertaApagar.Visible = True
        pnl_Firma.Visible = True
        tbx_Clave.Focus()
    End Sub

    Private Sub btn_Reiniciar_Click(sender As Object, e As EventArgs) Handles btn_Reiniciar.Click
        varPub.SegundosSesion = 0
        Apaga_Reinicia = 2
        pnl_Botones.Visible = False
        lbl_AlertaApagar.Visible = True
        lbl_AlertaApagar.Text = "Firma para Reiniciar el cajero"
        pnl_Firma.Visible = True
        tbx_Clave.Focus()
    End Sub

    Private Sub lbl_Clave_Click(sender As Object, e As EventArgs) Handles lbl_Clave.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Contrasena_Click(sender As Object, e As EventArgs) Handles lbl_Contrasena.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

#Region "Funciones Privadas"

    Private Sub Validar()

        pClave = tbx_Clave.Text
        pContrasenaActual = tbx_Contrasena.Text
        pAccion = Acciones.Validar
        varPub.SegundosSesion = 0

        Select Case fn_Usuario_Validar()
            Case -1
                DialogResult = Windows.Forms.DialogResult.Abort
                Me.Close()
            Case 0
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Case 11
                fn_MsgBox("Capture una clave de usuario.", MessageBoxIcon.Exclamation)
                varPub.SegundosSesion = 0
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Clave.Focus()
            Case 21
                fn_MsgBox("Capture una Contaseña.", MessageBoxIcon.Exclamation)
                varPub.SegundosSesion = 0
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Contrasena.Focus()
                '---
            Case 12
                fn_MsgBox("Clave de Usuario Incorrecta, por favor verifique.", MessageBoxIcon.Error)
                varPub.SegundosSesion = 0
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Clave.Focus()
                tbx_Clave.SelectAll()
            Case 22
                fn_MsgBox("Contraseña Incorrecta, por favor verifique.", MessageBoxIcon.Error)
                varPub.SegundosSesion = 0
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Contrasena.Focus()
                tbx_Contrasena.SelectAll()
        End Select
    End Sub

#End Region
End Class