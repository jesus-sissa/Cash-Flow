
Imports MPOST

Public Class frm_Rest_Validador
    Private BillAcceptor As MPOST.Acceptor = New MPOST.Acceptor()
    Private meicontrol As New Ccash.MeiDevice
    Private ConnectedDelegate As New ConnectedEventHandler(AddressOf HandleConnectedEvent)

    Public puerto As String = ""

    Dim cantPuertosDisponibles() As String ' = {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10"}
    'End Function



    Private Sub frm_Config_Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        varPub.SegundosSesion = 0

        cantPuertosDisponibles = System.IO.Ports.SerialPort.GetPortNames
        Array.Sort(cantPuertosDisponibles)


        For i As Integer = 0 To cantPuertosDisponibles.Length - 1

            cmb_Puertos.Items.Add(cantPuertosDisponibles(i))
            'ComboBox1.Items.Add(cantPuertosDisponibles(i))
        Next
        BillAcceptor.Close()

    End Sub


    Private Sub btn_Resetear_Click(sender As Object, e As EventArgs) Handles btn_Resetear.Click
        varPub.SegundosSesion = 0
        Try

            If cmb_Puertos.Text = "" Then
                MessageBox.Show("Seleccione un puerto")
                Exit Sub
            End If

            If BillAcceptor.Connected = True Then
                BillAcceptor.Close()
            End If

            Iniciar(cmb_Puertos.Text)
            Threading.Thread.Sleep(2900)
            Timer1.Enabled = True
            btn_Resetear.Enabled = False

            'BillAcceptor.EscrowReturn()
            BillAcceptor.SoftReset()


            BillAcceptor.Close()

        Catch ex As Exception
            BillAcceptor.Close()
            MessageBox.Show($"Ocurrio un error..{ex.Message}")
        End Try



    End Sub

    Sub Iniciar(ByVal validador As String)

        InicializarControl()
        Conectar1(validador)
    End Sub
    Public Sub InicializarControl()
        Me.Controls.Remove(Me.meicontrol)

        'Crear el control
        Me.meicontrol = New Ccash.MeiDevice


        AddHandler BillAcceptor.OnConnected, ConnectedDelegate
    End Sub
    Private Sub Conectar1(ByVal PuertoAceptador As String)
        Try

            BillAcceptor.Open(PuertoAceptador, 0)
        Catch err As Exception
            MessageBox.Show("Error al conectar")
        End Try
    End Sub
    Private Sub HandleConnectedEvent(ByVal sender As Object, ByVal e As EventArgs)
        Try

            If InvokeRequired Then
                BeginInvoke(ConnectedDelegate, New Object() {sender, e})
            Else
                BillAcceptor.EnableAcceptance = True
                BillAcceptor.AutoStack = True
                ' ListBox1.Items.Add("Conectado...............")
                'ListBox1.Items.Add(BillAcceptor.DisconnectTimeout.ToString())
                BillAcceptor.DisconnectTimeout = 6000
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click

        'Variables._ServerName = ""
        If BillAcceptor.Connected = True Then
            BillAcceptor.Close()
        End If
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.btn_Resetear.Enabled = True

        Timer1.Enabled = False
    End Sub

    Private Sub cmb_Puertos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmb_Puertos.SelectedValueChanged

    End Sub

    Private Sub cmb_Puertos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Puertos.SelectedIndexChanged

    End Sub
End Class