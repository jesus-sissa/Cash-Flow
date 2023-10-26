Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_Oledb
Public Class frm_AgregarImporte
    Public Resultado, id_caja As Integer
    Public validarF As Boolean = False
    Public DataSource, InitialCatalog, User, Pass As String
    Private Sub frm_AgregarImporte_Click(sender As Object, e As EventArgs) Handles Me.Click
ctrlTeclado.Hide()
End Sub


    Private Sub frm_AgregarImporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 2

        'Me.StartPosition = FormStartPosition.CenterScreen
        Dim Posicion As Integer = varTecl.AnchoPantalla - 624
        Me.Location = New Point(Posicion / 2, 230)
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = 380 + btn_Aceptar.Height + 8
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Folio) = True

    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        If varPub.ManejaFolioManual Then

            If tbx_Folio.Text.Length <> 13 Or tbx_Importe.Text.Trim() = "" Or tbx_Importe.Text = "0" Then
                ctrlTeclado.Hide()
                fn_MsgBox("El folio o importe es incorrecto.", MessageBoxIcon.Information, True)
                Exit Sub
            End If

            If varPub.ValidarFolio Then

                ctrlTeclado.Hide()

                ' Dim dt_Folio As DataTable = fn_ValidarFolio(tbx_Folio.Text)
                Dim dt_Folio As DataTable = fn_ValidarFolio_Oledb(tbx_Folio.Text) 'OLEDB

                If dt_Folio Is Nothing Then
                    ctrlTeclado.Hide()
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 65, varPub.IdPantalla, "DEPOSITOS - " + ":ERROR AL CONSULTAR FOLIO  ")
                    fn_MsgBox("Ocurrió un error al intentar validar el Folio.", MessageBoxIcon.Information, True)
                    Exit Sub
                End If

                If dt_Folio.Rows.Count = 0 Then
                    ctrlTeclado.Hide()
                    fn_MsgBox("El Folio " & tbx_Folio.Text & " no existe en el punto de venta.", MessageBoxIcon.Information, True)
                    Exit Sub
                End If

            End If

            If fn_Depositos_ConsultaFolio(tbx_Folio.Text) Then
                ctrlTeclado.Hide()
                fn_MsgBox("El folio" & tbx_Folio.Text & " ya existe en la base de datos, intente con otro.", MessageBoxIcon.Information, True)
                Exit Sub
            End If

            varPub.FolioManual = tbx_Folio.Text
            Resultado = True
            ctrlTeclado.Hide()
            Me.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Resultado = False
        ctrlTeclado.Hide()
    End Sub

Private Sub tbx_Importe_Click(sender As Object, e As EventArgs) Handles tbx_Importe.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Importe) = True
End Sub

Private Sub tbx_Folio_Click(sender As Object, e As EventArgs) Handles tbx_Folio.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Folio) = True
End Sub

    Private Sub tbx_Folio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Folio.KeyPress
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                e.Handled = False
            Case Keys.Enter
                If tbx_Folio.Text.Trim <> "" And tbx_Importe.Text = "" Then
                    tbx_Importe.Focus()
                    Teclado_RecibirControl(tbx_Importe) = True
                Else

                End If
            Case Else
                e.Handled = True
        End Select
    End Sub
    Private Sub tbx_Importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Importe.KeyPress
        fn_SoloNumeros(e)
    End Sub
End Class