Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_DepositoManual

#Region "-Variables"

    Dim Id_Caja As Integer = 0
    Dim Clave_caja As String = ""
    Dim Descripcion As String = ""

#End Region







#Region "-Procedimientos o Funciones"

    Private Sub Finalizar_Deposito(Optional Id_Caja As Integer = 0, Optional Clave_Caja As String = "")
        varPub.SegundosSesion = 0
        Dim Importe_Total As Decimal = 0D
        Dim Importe_USDConvertido As Decimal = 0D
        Dim EsEfectivo As Char = "S"
        'validar que almenso algun valor sea mayor a 0.00


        If rdb_SiEsEfectivo.Checked = True And rdb_NoEsEfectivo.Checked = False Then
            EsEfectivo = "S"
        ElseIf rdb_NoEsEfectivo.Checked = True And rdb_SiEsEfectivo.Checked = False Then
            EsEfectivo = "N"
        End If

        '-Abre un Nuevo Deposito del tipo 2
        If fn_Depositos_Open(2, EsEfectivo, Id_Caja, Clave_Caja) = False Then Exit Sub

        'Hacer el tipo de cambio de dolar a peso 
        Importe_USDConvertido = CDec(tbx_USD.Text) * varPub.TipoCambio

        'Sumar Importes
        Importe_Total = CDec(tbx_MXP.Text) + Importe_USDConvertido

        '--« Segundo cierra el deposito de los validadores »--
        If fn_Depositos_Close(Importe_Total, CDec(tbx_MXP.Text), CDec(tbx_USD.Text), 2, 23) Then
            Call fn_MsgBox("El Depósito se ha guardado correctamente.", MessageBoxIcon.Information, True, 2)
            tbx_MXP.Clear()
            tbx_USD.Clear()
            tbx_MXP.Focus()
            tbx_USDConvertido.Clear()
            varPub.SegundosReceptor = 0
        End If

    End Sub

    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub
    Public Sub GuadarDepositoManual()
        ctrlTeclado.Hide()
        If Validaciones() Then
            If varPub.Cantidad_Cajas = 1 Then
                Finalizar_Deposito(Id_Caja, Clave_caja)

            Else
                Finalizar_Deposito(Id_Caja, Clave_caja)
            End If
            Me.Close()
        End If
    End Sub

    Public Function Validaciones() As Boolean
        Dim blResult As Boolean = True
        Dim ContarPunto As Integer = 0

        If varPub.ManejaCorte = 1 And varPub.CorteActual = 0 Then
            Call fn_MsgBox("Imposible realizar depósitos ya que no hay Corte abierto .", MessageBoxIcon.Information)
            blResult = False

        ElseIf tbx_MXP.Text.Trim = "" AndAlso tbx_USD.Text.Trim = "" Then
            Call fn_MsgBox("Capture algún Importe peso ó dolar.", MessageBoxIcon.Error, True, 2)
            tbx_MXP.Focus()
            blResult = False
        Else
            For i As Long = 0 To tbx_MXP.Text.Length - 1
                If tbx_MXP.Text.Chars(i) = "." Then
                    ContarPunto += 1
                End If
            Next
            If ContarPunto >= 2 Then
                fn_MsgBox("Dato no válido.", MessageBoxIcon.Error, True, 3)
                tbx_MXP.Focus()
                ContarPunto = 0
                blResult = False

                If tbx_MXP.Text = "" Then tbx_MXP.Text = 0
                If tbx_USD.Text = "" Then tbx_USD.Text = 0

            ElseIf CDec(tbx_MXP.Text) = 0 And CDec(tbx_USD.Text) = 0 Then
                Call fn_MsgBox("El Importe debe ser mayor que Cero.", MessageBoxIcon.Error, True, 2)
                tbx_MXP.Focus()
                blResult = False
            End If
        End If
        Return blResult
    End Function

#End Region

#Region "-Eventos"

    Private Sub frm_DepositoManual_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_DepositoManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 23
        Call CambiarTamanodelosControles()
        rdb_SiEsEfectivo.Image = My.Resources.RadioButton_Checked_24x24
        rdb_NoEsEfectivo.Image = My.Resources.RadioButton_UnChecked_24x24

        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.NUMEROS Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.NUMEROS
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = (varTecl.AnchoPantalla - ctrlTeclado.Width) / 2
        varTecl.ubicaY_Teclado = tbx_USD.Location.Y + tbx_USD.Height + 120
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        tbx_TipoCambio.Text = varPub.TipoCambio

        If varPub.Cantidad_Cajas = 0 Then
            fn_MsgBox("Para depositar debe de haber por lo menos una Caja.", MessageBoxIcon.Information, True, 3)
            Exit Sub
        End If

        If varPub.Cantidad_Cajas = 1 Then

            Dim dt_Cajas As DataTable = fn_CajasLocal_Consulta2()

            If dt_Cajas Is Nothing Then
                fn_MsgBox("Ocurrió un error al consultar Cajas.", MessageBoxIcon.Error, True, 2)

                Exit Sub
            End If



            Id_Caja = dt_Cajas.Rows(0)("Id_Caja")
            Clave_caja = dt_Cajas.Rows(0)("Clave_Caja")
            grp_CajasEntradas.Enabled = True
            btn_Guardar.Enabled = True
            btn_Cajas.Text = "Caja"
        ElseIf varPub.Cantidad_Cajas > 1 Then
            btn_Cajas.Text = "Cajas"
            btn_Guardar.Enabled = False
            grp_CajasEntradas.Enabled = False
            btn_Cajas.Enabled = True
            tbx_MXP.Enabled = False
            tbx_USD.Enabled = False
        End If


    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_MXP_Click_1(sender As Object, e As EventArgs) Handles tbx_MXP.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_MXP) = True
    End Sub

    Private Sub tbx_MXP_Enter_1(sender As Object, e As EventArgs) Handles tbx_MXP.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_MXP) = True
    End Sub


    Private Sub tbx_MXP_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles tbx_MXP.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), Asc("."), 8
                ' es decir 48 to 57, 8 es retroceso(borrar)
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                ctrlTeclado.Hide()
                tbx_USD.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub tbx_MXP_Leave(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_USD_Click_1(sender As Object, e As EventArgs) Handles tbx_USD.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_USD) = True
    End Sub

    Private Sub tbx_USD_Enter_1(sender As Object, e As EventArgs) Handles tbx_USD.Enter
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_USD) = True
    End Sub

    Private Sub tbx_USD_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles tbx_USD.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), Asc("."), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                ctrlTeclado.Hide()
                Call GuadarDepositoManual()
            Case Else
                e.Handled = True
        End Select
    End Sub



    Private Sub tbx_USD_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_MXP_TextChanged(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_USD_TextChanged(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        If tbx_USD.Text = "" Then Exit Sub
        tbx_USDConvertido.Text = varPub.TipoCambio * (CInt(tbx_USD.Text))
    End Sub

    Private Sub lbl_MXP_Click(sender As Object, e As EventArgs) Handles lbl_MXP.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_USD_Click(sender As Object, e As EventArgs) Handles lbl_USD.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_TipoCambio_Click(sender As Object, e As EventArgs) Handles lbl_TipoCambio.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_USDConvertido_Click(sender As Object, e As EventArgs) Handles lbl_USDConvertido.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        varPub.SegundosSesion = 0
        Call GuadarDepositoManual()

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub rdb_NoEsDocumento_Click(sender As Object, e As EventArgs) Handles rdb_NoEsEfectivo.Click
        rdb_NoEsEfectivo.Image = My.Resources.RadioButton_Checked_24x24
        rdb_SiEsEfectivo.Image = My.Resources.RadioButton_UnChecked_24x24

    End Sub

    Private Sub rdb_SiEsDocumento_Click(sender As Object, e As EventArgs) Handles rdb_SiEsEfectivo.Click
        'rdb_SiEsEfectivo.Image = My.Resources.RadioButton_Checked_24x24
        'rdb_NoEsEfectivo.Image = My.Resources.RadioButton_UnChecked_24x24

    End Sub


    Private Sub btn_Cajas_Click(sender As Object, e As EventArgs) Handles btn_Cajas.Click
        Dim frm As New frm_Lista_Cajas
        frm.Location = New Point(btn_Cajas.Location.X, btn_Cajas.Location.Y + btn_Cajas.Height + 10)
        frm.ShowDialog()

        If frm.Cerrar Then
            grp_CajasEntradas.Enabled = False
            btn_Guardar.Enabled = False
            btn_Cajas.Text = "Cajas"
            Exit Sub
        End If

        rdb_SiEsEfectivo.Enabled = False
        rdb_NoEsEfectivo.Checked = True
        rdb_NoEsEfectivo.Image = My.Resources.RadioButton_Checked_24x24

        Id_Caja = frm.Id_Caja
        Clave_caja = frm.Clave_Caja
        btn_Cajas.Text = "Cajas [" & frm.Clave_Caja & "]"
        varPub.SegundosReceptor = 0
        grp_CajasEntradas.Enabled = True
        btn_Guardar.Enabled = True
        frm.Dispose()
        tbx_MXP.Enabled = True
        tbx_USD.Enabled = True
        tbx_MXP.Focus()
    End Sub

    Private Sub grp_CajasEntradas_Click(sender As Object, e As EventArgs) Handles grp_CajasEntradas.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub
#End Region

End Class