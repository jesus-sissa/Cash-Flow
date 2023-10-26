Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_ConsultaRecoleccion

#Region "Funciones Privadas"

    Private Sub Limpiar()
        lbl_TotalD.Text = "Total: $0.00"
        lsv_Recoleccion.Items.Clear()
        btn_Detalle.Enabled = False
        btn_Reimprimir.Enabled = False
    End Sub

    Private Sub CalcularRetiros()
        Dim Total As Decimal = 0
        For Each Item As ListViewItem In lsv_Recoleccion.Items
            Total += CDec(Item.SubItems(5).Text) 'Importe
        Next
        lbl_TotalD.Text = "Total: " & FormatCurrency(Total)
    End Sub

    Private Sub CambiarTamanodelosControles()
        cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

#End Region

    Private Sub frm_ConsultaRecoleccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 16

        pnl_General.Enabled = False
        btn_FechaDesde.Text = DateTime.Now.Date
        btn_FechaHasta.Text = DateTime.Now.Date

        Call CambiarTamanodelosControles()
        lbl_TotalD.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 4)

        With lsv_Recoleccion.Columns
            .Add("Folio", 60)
            .Add("Fecha", 80)
            .Add("Hora", 70)
            .Add("Remision", 120)
            .Add("Envase", 91)
            .Add("ImporteT", 100)
            .Add("ImporteM", 0)
            .Add("Usuario", 90)
            .Add("Estatus", 90)
            .Add("Sincronizado", 0)
        End With
 
        Call fn_ConsultaRetiros_LlenarCombo(cmb_Usuarios)

        If varPub.TipoUser = 1 Then
            cmb_Usuarios.SelectedValue = varPub.UsuarioClave
            cmb_Usuarios.Enabled = False
            chk_Todos.Enabled = False
        Else
            cmb_Usuarios.SelectedValue = varPub.UsuarioClave
            cmb_Usuarios.Enabled = True
            chk_Todos.Enabled = True
        End If

        pnl_General.Enabled = True
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
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

    Private Sub btn_Mostrar_Click(sender As Object, e As EventArgs) Handles btn_Mostrar.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call Limpiar()

        If CDate(btn_FechaDesde.Text) > CDate(btn_FechaHasta.Text) Then
            Call fn_MsgBox("La Fecha Inicial no debe ser Mayor que la Fecha Final.", MessageBoxIcon.Error)
            pnl_General.Enabled = True
            btn_FechaDesde.Focus()
            Exit Sub
        End If

        If cmb_Usuarios.SelectedValue = 0 AndAlso Not chk_Todos.Checked Then
            Call fn_MsgBox("Seleccione un Usuario o marque la casilla  «Todos»", MessageBoxIcon.Error)
            pnl_General.Enabled = True
            cmb_Usuarios.Focus()
            Exit Sub
        End If

        Call fn_ConsultaRetiros_Llenar(CDate(btn_FechaDesde.Text), CDate(btn_FechaHasta.Text), cmb_Usuarios.SelectedValue, lsv_Recoleccion)

        lsv_Recoleccion.SmallImageList = iml_Sincronia
        For Each lvi As ListViewItem In lsv_Recoleccion.Items
            If lvi.SubItems(9).Text = "S" Then
                lvi.ImageIndex = 0
            Else
                lvi.ImageIndex = 1
            End If
        Next

        Call CalcularRetiros()
        pnl_General.Enabled = True
    End Sub

    Private Sub lsv_Recoleccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Recoleccion.SelectedIndexChanged
        varPub.SegundosSesion = 0

        If lsv_Recoleccion.SelectedItems.Count > 0 Then
            If CDec(lsv_Recoleccion.SelectedItems(0).SubItems(3).Text) = 0 Then
                btn_Detalle.Enabled = False
                btn_Reimprimir.Enabled = False
                Exit Sub
            End If
            btn_Detalle.Enabled = True
            btn_Reimprimir.Enabled = btn_Detalle.Enabled
        Else
            btn_Detalle.Enabled = False
            btn_Reimprimir.Enabled = False
        End If

    End Sub

    Private Sub btn_Detalle_Click(sender As Object, e As EventArgs) Handles btn_Detalle.Click

        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(17, lsv_Recoleccion.SelectedItems(0).Tag, lsv_Recoleccion.SelectedItems(0).SubItems(5).Text, lsv_Recoleccion.SelectedItems(0).SubItems(6).Text)
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Reimprimir_Click(sender As Object, e As EventArgs) Handles btn_Reimprimir.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0

        If CDec(lsv_Recoleccion.SelectedItems(0).SubItems(3).Text) = 0 Then
        Else
            varPub.Reimpresion = True
            Call fn_ConsultaRetiros_Reimprimir(lsv_Recoleccion.SelectedItems(0).Tag)
            varPub.Reimpresion = False
        End If

        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

End Class