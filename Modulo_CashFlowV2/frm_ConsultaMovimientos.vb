Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_ConsultaMovimientos

#Region "Procedimientos Privados"

    Private Sub Calcular_TotalDepositos()
        lbl_TotalDepositos.Text = "$ 0.00"
        Dim Total As Decimal = 0
        For Each Item As ListViewItem In lsv_Balance.Items
            Total += CDec(Item.SubItems(3).Text)
        Next
        lbl_TotalDepositos.Text = "Total Depositos " & FormatCurrency(Total)

    End Sub

    Private Sub Calcular_TotalRetiros()
        lbl_TotalRetiros.Text = "$ 0.00"
        Dim Total As Decimal = 0
        For Each Item As ListViewItem In lsv_Balance.Items
            Total += CDec(Item.SubItems(4).Text)
        Next
        lbl_TotalRetiros.Text = "Total Retiros " & FormatCurrency(Total)
    End Sub

    Private Sub CambiarTamanodelosControles()
        cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

#End Region

    Private Sub frm_ConsultaMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 15

        pnl_General.Enabled = False

        btn_FechaDesde.Text = DateTime.Now.Date
        btn_FechaHasta.Text = DateTime.Now.Date

        ' PENDIENTE ESPECIFICAR SI SON 2 CASETS ,,, AGREGAR
        Call CambiarTamanodelosControles()
        '--------------------------------------------------------
        Dim AnchoColumna As Integer = 0

        AnchoColumna = (lsv_Balance.Width / 5)

        With lsv_Balance
            .Columns.Add("Fecha")
            .Columns.Add("Hora")
            .Columns.Add("Usuario")
            .Columns.Add("ImporteDeposito")
            .Columns.Add("ImporteRetiro")
            .Columns(0).Width = AnchoColumna * 0.7
            .Columns(1).Width = AnchoColumna * 0.5
            .Columns(2).Width = AnchoColumna * 2
            .Columns(3).Width = AnchoColumna * 0.9
            .Columns(4).Width = AnchoColumna * 0.8
        End With

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

    Private Sub btn_Mostrar_Click(sender As Object, e As EventArgs) Handles btn_Mostrar.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        lbl_TotalDepositos.Text = "Total Depositos $ 0.00"
        lbl_TotalRetiros.Text = "Total Retiros $ 0.00"

        If CDate(btn_FechaDesde.Text) > CDate(btn_FechaHasta.Text) Then
            Call fn_MsgBox("La Fecha Inicial no debe ser Mayor que la Fecha Final.", MessageBoxIcon.Error)
            pnl_General.Enabled = True
            btn_FechaDesde.Focus()
            Exit Sub
        End If

        lsv_Balance.Items.Clear()
        Call fn_ConsultaMovimientos_Llenar(CDate(btn_FechaDesde.Text), CDate(btn_FechaHasta.Text), lsv_Balance)

        If lsv_Balance.Items.Count > 0 Then
            Call Calcular_TotalDepositos()
            Call Calcular_TotalRetiros()
        End If
        btn_Imprimir.Enabled = lsv_Balance.Items.Count > 0

        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Imprimir_Click(sender As Object, e As EventArgs) Handles btn_Imprimir.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_ConsultaMovimientos_Imprimir(CDate(btn_FechaDesde.Text), CDate(btn_FechaHasta.Text))

        pnl_General.Enabled = True
    End Sub

    Private Sub lbl_TotalDepositos_Click(sender As Object, e As EventArgs) Handles lbl_TotalDepositos.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_TotalRetiros_Click(sender As Object, e As EventArgs) Handles lbl_TotalRetiros.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub
End Class