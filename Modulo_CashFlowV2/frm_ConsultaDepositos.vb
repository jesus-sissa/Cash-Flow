Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_ConsultaDepositos

#Region "Funciones Privadas"

    Private Sub Limpiar()
        lsv_SumaDepositos.Items.Clear()
        lbl_TotalDeposito.Text = "Total: $0.00"
        lbl_TotalD.Text = "Total: $0.00"
        lsv_Depositos.Items.Clear()
        btn_Detalle.Enabled = False
        btn_Reimprimir.Enabled = False
    End Sub

    Private Sub Calcular()
        Dim Total As Decimal = 0
        For Each Item As ListViewItem In lsv_Depositos.Items
            Total += CDec(Item.SubItems(3).Text)

            If Item.SubItems("Tipo").Text = "2" Then
                Item.SubItems("Folio").Text = Item.SubItems("Folio").Text & "*"
            End If
        Next
        lbl_TotalD.Text = "Total: " & FormatCurrency(Total, 2)
    End Sub


    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub


    Private Function CalcularSumaDepositosTotales() As Integer
        Dim TotalDeposito As Integer = 0

        For Each lsv_Elementos As ListViewItem In lsv_SumaDepositos.Items
            TotalDeposito += CInt(lsv_Elementos.SubItems("ImporteTotal").Text)
        Next
        Return TotalDeposito
    End Function

#End Region

    Private Sub frm_ConsultaDepositos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_ConsultaDepositos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 12


        pnl_General.Enabled = False

        btn_FechaDesde.Text = DateTime.Now.Date
        btn_FechaHasta.Text = DateTime.Now.Date

        btn_FechaDesde2.Text = DateTime.Now.Date
        btn_FechaHasta2.Text = DateTime.Now.Date

        Call CambiarTamanodelosControles()
        lbl_TotalD.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 4)

        lsv_Depositos.Columns.Add("Folio", 200)
        lsv_Depositos.Columns.Add("Fecha", 85)
        lsv_Depositos.Columns.Add("Hora", 70)
        lsv_Depositos.Columns.Add("Importe", 90)
        lsv_Depositos.Columns.Add("Usuario", 120)
        lsv_Depositos.Columns.Add("Estatus", 90)
        lsv_Depositos.Columns.Add("Sincronizado", 0)
        lsv_Depositos.Columns.Add("Tipo", 0)
        Call fn_ConsultaDepositos_LlenarCombo(cmb_Usuarios)

        cmb_Usuarios.SelectedValue = varPub.UsuarioClave
        cmb_Usuarios.Enabled = (varPub.TipoUser <> 1)
        chk_Todos.Enabled = (varPub.TipoUser <> 1)

      
        If varPub.TipoUser <> 2 Then
            tab_Depositos.TabPages.Remove(tab_Depositos.TabPages(1))
        Else
            Call fn_ConsultaDepositos_LlenarCombo(cmb_Usuarios2)
            cmb_Usuarios.SelectedValue = varPub.UsuarioClave
            lsv_SumaDepositos.Columns.Add("Fecha", 200)
            lsv_SumaDepositos.Columns.Add("UsuarioRegistro", 300)
            lsv_SumaDepositos.Columns.Add("ImporteTotal", 200)

        End If
        pnl_General.Enabled = True
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Desde_Click(sender As Object, e As EventArgs) Handles lbl_Desde.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_FechaDesde_Click(sender As Object, e As EventArgs) Handles btn_FechaDesde.Click
        pnl_General.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaDesde.Text)
        frm_Fecha.Location = New Point(btn_FechaDesde.Location.X, (btn_FechaDesde.Location.Y + btn_FechaDesde.Height + 5))
        frm_Fecha.ShowDialog()
        btn_FechaDesde.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_General.Enabled = True
    End Sub

    Private Sub lbl_Hasta_Click(sender As Object, e As EventArgs) Handles lbl_Hasta.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_FechaHasta_Click(sender As Object, e As EventArgs) Handles btn_FechaHasta.Click
        pnl_General.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaHasta.Text)
        frm_Fecha.Location = New Point(btn_FechaHasta.Location.X, (btn_FechaHasta.Location.Y + btn_FechaHasta.Height + 5))

        frm_Fecha.ShowDialog()
        btn_FechaHasta.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_General.Enabled = True
    End Sub

    Private Sub chk_Cancelados_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Cancelados.CheckedChanged
        varPub.SegundosSesion = 0
        Call Limpiar()
        If chk_Cancelados.Checked Then
            chk_Cancelados.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_Cancelados.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_Cancelados_Click(sender As Object, e As EventArgs) Handles chk_Cancelados.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Usuario_Click(sender As Object, e As EventArgs) Handles lbl_Usuario.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Usuarios_Click(sender As Object, e As EventArgs) Handles cmb_Usuarios.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        varPub.SegundosSesion = 0
        Call Limpiar()
    End Sub

    Private Sub chk_Todos_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Todos.CheckedChanged
        varPub.SegundosSesion = 0
        cmb_Usuarios.SelectedValue = 0
        cmb_Usuarios.Enabled = Not chk_Todos.Checked
        Call Limpiar()
        If chk_Todos.Checked Then
            chk_Todos.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_Todos.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_Todos_Click(sender As Object, e As EventArgs) Handles chk_Todos.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Mostrar_Click(sender As Object, e As EventArgs) Handles btn_Mostrar.Click
        varPub.IdPantalla = 12
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call Limpiar()
        Dim dep_cancel As String = "C"
        If chk_Cancelados.Checked Then dep_cancel = "T"

        If CDate(btn_FechaDesde.Text) > CDate(btn_FechaHasta.Text) Then
            Call fn_MsgBox("La Fecha Inicial no debe ser Mayor que la Fecha Final.", MessageBoxIcon.Error)
            pnl_General.Enabled = True
            btn_FechaDesde.Focus()
            Exit Sub
        End If

        If cmb_Usuarios.SelectedValue = 0 AndAlso Not chk_Todos.Checked Then
            Call fn_MsgBox("Seleccione un Usuario o marque la casilla de «Todos»", MessageBoxIcon.Error)
            pnl_General.Enabled = True
            cmb_Usuarios.Focus()
            Exit Sub
        End If

        Call fn_ConsultaDepositos_Llenar(CDate(btn_FechaDesde.Text), CDate(btn_FechaHasta.Text), lsv_Depositos, dep_cancel, cmb_Usuarios.SelectedValue)

        Call Calcular()

        lsv_Depositos.SmallImageList = iml_Sincronia
        For Each lvi As ListViewItem In lsv_Depositos.Items
            If lvi.SubItems(6).Text = "S" Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If
        Next
        pnl_General.Enabled = True
        lsv_Depositos.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub lsv_Depositos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Depositos.SelectedIndexChanged
        varPub.SegundosSesion = 0

        If lsv_Depositos.SelectedItems.Count > 0 Then

            If CDec(lsv_Depositos.SelectedItems(0).SubItems(3).Text) = 0 _
            OrElse CInt(lsv_Depositos.SelectedItems(0).SubItems(7).Text) = 2 Then
                btn_Detalle.Enabled = False
            Else
                btn_Detalle.Enabled = True
            End If
            btn_Reimprimir.Enabled = CDec(lsv_Depositos.SelectedItems(0).SubItems(3).Text) > 0

        Else
            btn_Detalle.Enabled = False
            btn_Reimprimir.Enabled = False
        End If
    End Sub

    Private Sub btn_Detalle_Click(sender As Object, e As EventArgs) Handles btn_Detalle.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(10, lsv_Depositos.SelectedItems(0).Tag, lsv_Depositos.SelectedItems(0).SubItems(3).Text)
        pnl_General.Enabled = True
    End Sub

    Private Sub lbl_TotalD_Click(sender As Object, e As EventArgs) Handles lbl_TotalD.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Reimprimir_Click(sender As Object, e As EventArgs) Handles btn_Reimprimir.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        varPub.Reimpresion = True
        Call fn_ConsultaDepositos_Reimprimir(lsv_Depositos.SelectedItems(0).Tag, lsv_Depositos.SelectedItems(0).SubItems(7).Text)
        varPub.Reimpresion = False
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub


    '----Eventos Suma de depositos por usuario ----
    Private Sub pnl_SumaDepositos_Click(sender As Object, e As EventArgs) Handles pnl_SumaDepositos.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Desde2_Click(sender As Object, e As EventArgs) Handles lbl_Desde2.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_FechaDesde2_Click(sender As Object, e As EventArgs) Handles btn_FechaDesde2.Click
        pnl_SumaDepositos.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaDesde2.Text)
        frm_Fecha.Location = New Point(btn_FechaDesde2.Location.X, (btn_FechaDesde2.Location.Y + btn_FechaDesde2.Height + 5))
        frm_Fecha.ShowDialog()
        btn_FechaDesde2.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_SumaDepositos.Enabled = True
    End Sub

    Private Sub lbl_Hasta2_Click(sender As Object, e As EventArgs) Handles lbl_Hasta2.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Hasta2_Click(sender As Object, e As EventArgs) Handles btn_FechaHasta2.Click
        pnl_SumaDepositos.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaHasta.Text)
        frm_Fecha.Location = New Point(btn_FechaHasta.Location.X, (btn_FechaHasta.Location.Y + btn_FechaHasta.Height + 5))

        frm_Fecha.ShowDialog()
        btn_FechaHasta2.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_SumaDepositos.Enabled = True
    End Sub

    Private Sub lbl_Usuarios2_Click(sender As Object, e As EventArgs) Handles lbl_Usuario2.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Usuarios2_Click(sender As Object, e As EventArgs) Handles cmb_Usuarios2.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Usuarios2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios2.SelectedIndexChanged
        varPub.SegundosSesion = 0
        Call Limpiar()
    End Sub

    Private Sub chk_Todos2_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Todos2.CheckedChanged
        varPub.SegundosSesion = 0
        cmb_Usuarios2.SelectedIndex = 0
        cmb_Usuarios2.Enabled = Not chk_Todos2.Checked
        Call Limpiar()

        If chk_Todos2.Checked Then
            chk_Todos2.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_Todos2.Image = My.Resources.RadioButton_UnChecked_24x24
        End If
    End Sub

    Private Sub chk_Todos2_Click(sender As Object, e As EventArgs) Handles chk_Todos2.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Cerrar2_Click(sender As Object, e As EventArgs) Handles btn_Cerrar2.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub lsv_SumaDepositos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_SumaDepositos.SelectedIndexChanged

    End Sub


    Private Sub btn_Mostrar2_Click(sender As Object, e As EventArgs) Handles btn_Mostrar2.Click
        varPub.SegundosSesion = 0

        Call Limpiar()

        If CDate(btn_FechaDesde2.Text) > CDate(btn_FechaHasta2.Text) Then
            Call fn_MsgBox("La Fecha Inicial no debe ser Mayor que la Fecha Final.", MessageBoxIcon.Error)
            btn_FechaDesde2.Focus()
            Exit Sub
        End If

        If cmb_Usuarios2.SelectedValue = 0 AndAlso Not chk_Todos2.Checked Then
            Call fn_MsgBox("Seleccione un Usuario o marque la casilla de «Todos»", MessageBoxIcon.Error)
            cmb_Usuarios2.Focus()
            Exit Sub
        End If

        Dim dt_SumaDepositos As DataTable = fn_ConsultaDepositos_SumaDepositos(CDate(btn_FechaDesde2.Text), CDate(btn_FechaHasta2.Text), cmb_Usuarios2.SelectedValue)

        If dt_SumaDepositos Is Nothing Then
            Call fn_MsgBox("Ocurrió un errro al consultar Depósitos.", MessageBoxIcon.Error)
            Exit Sub
        End If

        If dt_SumaDepositos.Rows.Count > 0 Then
            Call cls_FuncionesPublicas.fn_LlenarListView(dt_SumaDepositos, lsv_SumaDepositos, "", "", False)
            lbl_TotalDeposito.Text = "Total: " & FormatCurrency(CalcularSumaDepositosTotales(), 2)
        Else
            Call fn_MsgBox(" No hubo registros para este rango de fechas.", MessageBoxIcon.Error)
        End If
    End Sub


End Class