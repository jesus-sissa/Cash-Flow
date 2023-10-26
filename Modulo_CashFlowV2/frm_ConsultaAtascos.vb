Public Class frm_ConsultaAtascos

#Region "-Eventos"
    Private Sub btn_Mostrar_Click(sender As Object, e As EventArgs) Handles btn_Mostrar.Click
        varPub.IdPantalla = 12
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call Limpiar()


        If CDate(btn_FechaDesde.Text) > CDate(btn_FechaHasta.Text) Then
            Call fn_MsgBox("La Fecha Inicial no debe ser Mayor que la Fecha Final.", MessageBoxIcon.Error)
            btn_FechaDesde.Text = DateTime.Now.Date
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

        cls_CashFlow.fn_GetAtascos(cmb_Usuarios.SelectedValue, CDate(btn_FechaDesde.Text), CDate(btn_FechaHasta.Text), lsv_Atascos)
        Calcular()
        lsv_Atascos.SmallImageList = iml_Sincronia
        For Each lvi As ListViewItem In lsv_Atascos.Items
            If lvi.SubItems(6).Text = "S" Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If
        Next
        pnl_General.Enabled = True
        lsv_Atascos.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub
    Private Sub Calcular()
        Dim Total As Decimal = 0
        For Each Item As ListViewItem In lsv_Atascos.Items
            Total += CDec(Item.SubItems(6).Text)
            Item.SubItems("Folio").Text = Item.SubItems("Folio").Text & "*"
        Next
        lbl_TotalD.Text = "Total: " & FormatCurrency(Total, 2)
    End Sub

    Private Sub cmb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_ConsultaAtascos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 42
        varPub.SegundosSesion = 0
        pnl_General.Enabled = False

        btn_FechaDesde.Text = DateTime.Now.Date
        btn_FechaHasta.Text = DateTime.Now.Date

        cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
        lbl_TotalD.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 4)
        CrearColumnas()
        Call cls_CashFlow.fn_ConsultaDepositos_LlenarCombo(cmb_Usuarios)
        cmb_Usuarios.SelectedValue = varPub.UsuarioClave
        cmb_Usuarios.Enabled = (varPub.TipoUser <> 1)
        chk_Todos.Enabled = (varPub.TipoUser <> 1)
        pnl_General.Enabled = True

    End Sub
    Private Sub CrearColumnas()
        lsv_Atascos.Columns.Add("Folio", 200)
        lsv_Atascos.Columns.Add("Clave", 100)
        lsv_Atascos.Columns.Add("Usuario", 250)
        lsv_Atascos.Columns.Add("Fecha", 150)
        lsv_Atascos.Columns.Add("Hora", 150)
        lsv_Atascos.Columns.Add("Totales Antes", 150)
        lsv_Atascos.Columns.Add("Importe Descontado", 220)
        lsv_Atascos.Columns.Add("Total Nuevo", 150)
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
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

#End Region

#Region "-Metodos o Funciones"
    Private Sub Limpiar()
        lbl_TotalD.Text = "Total: $0.00"
        lsv_Atascos.Items.Clear()
        btn_Reimprimir.Enabled = False
    End Sub

    Private Sub btn_FechaDesde_Click(sender As Object, e As EventArgs) Handles btn_FechaDesde.Click
        varPub.SegundosSesion = 0
        pnl_General.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaDesde.Text)
        frm_Fecha.Location = New Point(btn_FechaDesde.Location.X, (btn_FechaDesde.Location.Y + btn_FechaDesde.Height + 5))
        frm_Fecha.ShowDialog()
        btn_FechaDesde.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_FechaHasta_Click(sender As Object, e As EventArgs) Handles btn_FechaHasta.Click
        varPub.SegundosSesion = 0
        pnl_General.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaHasta.Text)
        frm_Fecha.Location = New Point(btn_FechaHasta.Location.X, (btn_FechaHasta.Location.Y + btn_FechaHasta.Height + 5))
        frm_Fecha.ShowDialog()
        btn_FechaHasta.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        pnl_General.Enabled = True
    End Sub

    Private Sub lsv_Atascos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Atascos.SelectedIndexChanged
        varPub.SegundosSesion = 0
        If lsv_Atascos.SelectedItems.Count > 0 Then
            btn_Reimprimir.Enabled = CDec(lsv_Atascos.SelectedItems(0).SubItems(6).Text) > 0
        Else
            btn_Reimprimir.Enabled = False
        End If
    End Sub

    Private Sub btn_Reimprimir_Click(sender As Object, e As EventArgs) Handles btn_Reimprimir.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        varPub.Reimpresion = True
        cls_CashFlow.fn_ImprimirAtascos(lsv_Atascos.SelectedItems(0).Tag.ToString())
        varPub.Reimpresion = False
        pnl_General.Enabled = True
    End Sub

    Private Sub lbl_Desde_Click(sender As Object, e As EventArgs) Handles lbl_Desde.Click

    End Sub
#End Region
End Class