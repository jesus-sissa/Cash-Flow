Imports System.Web.Script.Serialization

Public Class frm_Tickets
    Dim _service As New WsRemision.WsCashFlowSoapClient
    Public _ticketInt As Integer = 0
    Private Sub frm_Tickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        varPub.SegundosSesion = 0
        'recibo ñps tickets y agregar al listview , habilitar checkbox
        lv_tickets.Columns.Add("Ticket", 100, HorizontalAlignment.Left)
        lv_tickets.Columns.Add("Estatus", 0, HorizontalAlignment.Left)
        lv_tickets.Columns.Add("Estatus", 100, HorizontalAlignment.Left)
        lv_tickets.Columns.Add("Descripcion", 500, HorizontalAlignment.Left)
        lv_tickets.Columns.Add("Tecnico", 300, HorizontalAlignment.Left)
        lv_tickets.View = View.Details
        'lv_tickets.CheckBoxes = True

        Get_Ticket_Sucursal()
        'si el ticket seleccionado su estatus es A habilitar boton de recibir y deshabilitar boton de Terminar
        'si el ticket seleccionado su estatus es AC habilidar el boton de Terminar y deshabilitar el boton de recibir 

    End Sub
    Private Sub btn_Recibir_Click(sender As Object, e As EventArgs) Handles btn_Recibir.Click
        ''cambiar a estatus AC al ticket seleccionado
        If _service.Recibir_Ticket_Tecnico(varPub.Plaza, _ticketInt) Then
            'agregar comentario de recibido
            If _service.Agregar_ComentarioTicket_Tenico(varPub.Plaza, _ticketInt, "[ACTUANDO] El ticket ha sido recibido correctamente") Then
                fn_MsgBox("Ticket:" + _ticketInt.ToString() + ", recibido correctamente", MessageBoxIcon.Information)
            End If
        Else
            fn_MsgBox("No se puedo recibir el Ticket:" + _ticketInt.ToString(), MessageBoxIcon.Error)
        End If
        'una vez cambiado al estatus AC actualizar listview y desabilitar el boton recibir
        Get_Ticket_Sucursal()
        btn_Recibir.Enabled = False
    End Sub

    Private Sub btn_Terminar_Click(sender As Object, e As EventArgs) Handles btn_Terminar.Click
        'abrir ventana de cierre
        Dim detalle As New frm_Tickets_Detalle
        detalle._ticket = _ticketInt
        detalle.ShowDialog()
        If detalle.DialogResult = DialogResult.OK Then
            Get_Ticket_Sucursal()
        End If
        btn_Terminar.Enabled = False
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Get_Ticket_Sucursal()

        lv_tickets.Items.Clear()
        Dim tickets = _service.Consultar_Tickets_Sucursal(varPub.Plaza, varPub.Cve_Cliente)
        Dim jss As New JavaScriptSerializer()
        Dim dict = jss.Deserialize(Of List(Of Tickets))(tickets)

        For i As Integer = 0 To dict.Count - 1 Step 1
            Dim item As New ListViewItem(dict(i).Ticket.ToString()) 'Cargando etiquetas a los checkboxs'
            item.SubItems.Add(dict(i).Status.ToString())
            item.SubItems.Add(Get_Status(dict(i).Status.ToString()))
            item.SubItems.Add(dict(i).Descripcion.ToString())
            item.SubItems.Add(dict(i).Tecnico.ToString())
            lv_tickets.Items.Add(item)
            lv_tickets.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            lv_tickets.Columns(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            lv_tickets.Columns(3).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            lv_tickets.Columns(4).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        Next

    End Sub

    Private Function Get_Status(status As String) As String

        If status = "A" Then
            Return "NUEVO"
        End If
        If status = "AS" Then
            Return "ASIGNADO"
        End If
        If status = "AC" Then
            Return "ACTUANDO"
        End If

    End Function
    Private Sub lv_tickets_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lv_tickets.ItemCheck
        Dim index = e.Index
        Dim status = lv_tickets.Items(index).SubItems(1).Text.ToString()
        _ticketInt = CInt(lv_tickets.Items(index).SubItems(0).Text.ToString())

        If status = "A" Then
            btn_Recibir.Enabled = True
        ElseIf status = "AS" Then
            btn_Recibir.Enabled = True
        ElseIf status = "AC" Then
            btn_Terminar.Enabled = True
        End If

    End Sub

    Private Sub lv_tickets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv_tickets.SelectedIndexChanged
        varPub.SegundosSesion = 0

        If lv_tickets.SelectedItems.Count > 0 Then

            Dim status = lv_tickets.Items(0).SubItems(1).Text.ToString()
            _ticketInt = CInt(lv_tickets.Items(0).SubItems(0).Text.ToString())
            If status = "A" Then
                btn_Recibir.Enabled = True
            ElseIf status = "AS" Then
                btn_Recibir.Enabled = True
            ElseIf status = "AC" Then
                btn_Terminar.Enabled = True
            End If

        End If

    End Sub
End Class

Class Tickets
    Private _ticket As String
    Private _status As String
    Private _descripcion As String
    Private _tecnico As String

    Public Property Ticket As String
        Get
            Return _ticket
        End Get
        Set(value As String)
            If value.Contains(".") Then
                Dim result(1) As String
                result = value.Split(".")
                _ticket = result(0)
            Else
                _ticket = value
            End If

        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Tecnico As String
        Get
            Return _tecnico
        End Get
        Set(value As String)
            _tecnico = value
        End Set
    End Property
End Class