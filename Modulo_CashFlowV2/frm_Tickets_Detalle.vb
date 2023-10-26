Public Class frm_Tickets_Detalle
    Public _ticket As Integer = 0
    Dim checkBoxRespuestas(15) As String
    Dim respuestas As New List(Of String)
    Dim _service As New WsRemision.WsCashFlowSoapClient
    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub frm_Tickets_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCheckboxes()
    End Sub

    Private Sub FillCheckboxes()
        checkBoxRespuestas(0) = "Reeinstalacion de CashFlow"
        checkBoxRespuestas(1) = "Se reinicio el aplicativo"
        checkBoxRespuestas(2) = "Se llevo acabo el mantenimiento correctamente"
        checkBoxRespuestas(3) = "Se ejecuta sincronizacion correctamente"
        checkBoxRespuestas(4) = "Reinicio de validador"
        checkBoxRespuestas(5) = "Se atendio atasco en validador"
        checkBoxRespuestas(6) = "Se detecto fallo en validador, se realizo cambio de validador"
        checkBoxRespuestas(7) = "Se atendio atasco en apilador"
        checkBoxRespuestas(8) = "Se detecta error en impresora, se realiza cambio de impresora"
        checkBoxRespuestas(9) = "Se detecta error en impresora, se realiza cambio de cartucho de impresion"
        checkBoxRespuestas(10) = "Se realiza cambio de cartucho dañado en sucursal"
        checkBoxRespuestas(11) = "Se detecto bnf dañado, se realizo cambio de bnf"
        checkBoxRespuestas(12) = "Daño en pantalla, se reemplaza la pantalla"
        checkBoxRespuestas(13) = "Configuracion de pantalla"
        checkBoxRespuestas(14) = "Daño en UPS, se reemplaza el UPS"
        checkBoxRespuestas(15) = "Otro"

        lv_respuestas.Columns.Add("Seleciona la opcion mas adecuada para cerrar tu Ticket", 1000, HorizontalAlignment.Left)
        lv_respuestas.View = View.Details
        lv_respuestas.CheckBoxes = True
        For i As Integer = 0 To checkBoxRespuestas.Length - 1 Step 1
            Dim item As New ListViewItem(checkBoxRespuestas(i)) 'Cargando etiquetas a los checkboxs'
            lv_respuestas.Items.Add(item)
            lv_respuestas.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        Next
    End Sub

    Private Sub btn_Detalle_Click(sender As Object, e As EventArgs) Handles btn_Detalle.Click
        ''cambiar a estatus F al ticket seleccionado

        If _service.Finalizar_Ticket_Tecnico(varPub.Plaza, _ticket) Then
            'agregar comentario de cierre
            If _service.Agregar_ComentarioTicket_Tenico(varPub.Plaza, _ticket, getRespuesta()) Then
                fn_MsgBox("Ticket :" + _ticket.ToString + ", Finalizado correctamente", MessageBoxIcon.Information)
                DialogResult = DialogResult.OK
                Me.Close()
            Else
                fn_MsgBox("Ticket :" + _ticket.ToString + ", Finalizado, falta comentario de cierre", MessageBoxIcon.Information)
                DialogResult = DialogResult.OK
            End If
        Else
            fn_MsgBox("Ticket :" + _ticket.ToString + ", No se puedo finalizar", MessageBoxIcon.Information)
        End If


        'una vez cambiado al estatus F+ actualizar listview y desabilitar el boton Terminar
    End Sub

    Private Function getRespuesta() As String
        Dim resp As String = Nothing
        resp += "[RESUELTO]"
        For index = 0 To respuestas.Count - 1 Step 1
            resp += respuestas(index).ToString() + Environment.NewLine
        Next
        Return resp + ", Ticket Resuelto Correctamente."
    End Function

    Private Sub lv_respuestas_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lv_respuestas.ItemCheck
        Dim index = e.Index
        '_ticketInt = CInt(lv_tickets.Items(index).SubItems(0).Text.ToString())

        If lv_respuestas.Items(index).Checked Then
            respuestas.Remove(lv_respuestas.Items(index).SubItems(0).Text.ToString)
        End If


    End Sub

    Private Sub lv_respuestas_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lv_respuestas.ItemChecked
        If e.Item.Checked Then
            respuestas.Add(e.Item.SubItems(0).Text.ToString)
        End If
    End Sub
End Class