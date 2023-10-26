Imports MPOST
Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Correo

Public Class frm_ValidarBillete

    Private BillAcceptor As MPOST.Acceptor = New MPOST.Acceptor()
    Private meicontrol As New Ccash.MeiDevice

    Private BillAcceptor2 As MPOST.Acceptor = New MPOST.Acceptor()
    Private meicontrol2 As New Ccash.MeiDevice

    Private Val1_Conectado As Boolean = False
    Private Val2_Conectado As Boolean = False

#Region "Event Delegate Definitions 2 instances"

    Private ConnectedDelegate As New ConnectedEventHandler(AddressOf HandleConnectedEvent)
    Private EscrowedDelegate As New EscrowEventHandler(AddressOf HandleEscrowedEvent)
    Private ReturnedDelegate As New ReturnedEventHandler(AddressOf HandleReturnedEvent)
    Private NoteRetrievedDelegate As New NoteRetrievedEventHandler(AddressOf HandleNoteRetrievedEvent)
    Private RejectedDelegate As New RejectedEventHandler(AddressOf HandleRejectedEvent)
    Private DisconnectedDelegate As New DisconnectedEventHandler(AddressOf HandleDisconnectedEvent)
    Private Atasco As New JamDetectedEventHandler(AddressOf HandleAtasco)
    Private removido As New CashBoxRemovedEventHandler(AddressOf HandleRemovido)
    Private fallo As New FailureDetectedEventHandler(AddressOf HandleFallo)

    Private ConnectedDelegate2 As New ConnectedEventHandler(AddressOf HandleConnectedEvent2)
    Private EscrowedDelegate2 As New EscrowEventHandler(AddressOf HandleEscrowedEvent2)
    Private ReturnedDelegate2 As New ReturnedEventHandler(AddressOf HandleReturnedEvent2)
    Private NoteRetrievedDelegate2 As New NoteRetrievedEventHandler(AddressOf HandleNoteRetrievedEvent2)
    Private RejectedDelegate2 As New RejectedEventHandler(AddressOf HandleRejectedEvent2)
    Private DisconnectedDelegate2 As New DisconnectedEventHandler(AddressOf HandleDisconnectedEvent2)

#End Region

#Region "Constructor de las 2 instancias."

    Public Sub New()
        InitializeComponent()

        '===de aqui pa abajo le pertenece a MEICONTROL=====
        'Quitar el contro a la forma, no es visible
        Me.Controls.Remove(Me.meicontrol)

        'Crear el control
        Me.meicontrol = New Ccash.MeiDevice

        'Evento indica Conexión Correcta
        AddHandler meicontrol.OnConexionCompletada, AddressOf meicontrol_OnConexionCompletada
        'Evento indica Conexión Fallida
        AddHandler meicontrol.OnConexionFallida, AddressOf meicontrol_OnConexionFallida
        'Evento que se lanza en caso de que ocurra algun error de caracter general

        'Agregar el Control
        Me.Controls.Add(Me.meicontrol)

        '===DE AQUI PARA ARRIBA LE PERTENECE A MEICONTROL

        '****** de aqui pa abajo le pertenece a MPOST *********
        AddHandler BillAcceptor.OnConnected, ConnectedDelegate
        AddHandler BillAcceptor.OnEscrow, EscrowedDelegate
        AddHandler BillAcceptor.OnReturned, ReturnedDelegate
        AddHandler BillAcceptor.OnNoteRetrieved, NoteRetrievedDelegate
        AddHandler BillAcceptor.OnRejected, RejectedDelegate
        AddHandler BillAcceptor.OnDisconnected, DisconnectedDelegate
        AddHandler BillAcceptor.OnJamDetected, Atasco
        AddHandler BillAcceptor.OnFailureDetected, fallo
        AddHandler BillAcceptor.OnCashBoxRemoved, removido
      
        '******* DE AQUI PARA ARRIBA LE PERTENECE A MPOST ******

        '====================================================================
        'Segunda inicializacion de Instancia.
        Me.Controls.Remove(Me.meicontrol2)

        'Crear el control
        Me.meicontrol2 = New Ccash.MeiDevice

        'Evento indica Conexión Correcta
        AddHandler meicontrol2.OnConexionCompletada, AddressOf meicontrol_OnConexionCompletada2
        'Evento indica Conexión Fallida
        AddHandler meicontrol2.OnConexionFallida, AddressOf meicontrol_OnConexionFallida2
        'Evento que se lanza en caso de que ocurra algun error de caracter general

        'Agregar el Control2
        Me.Controls.Add(Me.meicontrol2)
        'DE AQUI PARA ARRIBA LE PERTENECE A MEICONTROL

        '******** De aqui pa abajo le pertenece a MPOST ************
        AddHandler BillAcceptor2.OnConnected, ConnectedDelegate2
        AddHandler BillAcceptor2.OnEscrow, EscrowedDelegate2
        AddHandler BillAcceptor2.OnReturned, ReturnedDelegate2
        AddHandler BillAcceptor2.OnNoteRetrieved, NoteRetrievedDelegate2
        AddHandler BillAcceptor2.OnRejected, RejectedDelegate2
        AddHandler BillAcceptor2.OnDisconnected, DisconnectedDelegate2
        '******* DE AQUI PARA ARRIBA LE PERTENECE A MPOST ******
    End Sub

#End Region

#Region "Event Handlers --Validador 1"

    Private Sub HandleConnectedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(ConnectedDelegate, New Object() {sender, e})
        Else

            BillAcceptor.EnableAcceptance = True
            BillAcceptor.AutoStack = False
            Call Alregresar()
            pct_cargando.Visible = False
            Btn_Salir.Enabled = True
            btn_Validador1.Image = My.Resources.btn_Pausa
            Val1_Conectado = True
            btn_Validador1.Text = "Pausar"
        End If
    End Sub

    Private Sub HandleEscrowedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(EscrowedDelegate, New Object() {sender, e})
        Else
            lbl_Status.Text = "BILLETE VALIDADO."
            lbl_Status.ForeColor = Color.Green

            lbl_Denominacion.Text = BillAcceptor.Bill.Country & " " & BillAcceptor.Bill.Value.ToString
            Call DatosBillete()
            BillAcceptor.EscrowReturn()
        End If
    End Sub

    Private Sub HandleReturnedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(ReturnedDelegate, New Object() {sender, e})
        End If
    End Sub

    Private Sub HandleNoteRetrievedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(NoteRetrievedDelegate, New Object() {sender, e})
        Else
            'Call Alregresar()
        End If
    End Sub

    Private Sub HandleRejectedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(RejectedDelegate, New Object() {sender, e})
        Else
            lbl_Status.Text = "BILLETE NO IDENTIFICADO O PRESUNTAMENTE FALSO."
            lbl_Status.ForeColor = Color.Red
            lbl_Denominacion.Text = ""
            Pct_Billetes.Image = My.Resources.NoId
            Call fn_EscribirLog(varPub.UsuarioClave, "Validar Billetes", "Validación de Billetes")
        End If

    End Sub

    Private Sub HandleDisconnectedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(DisconnectedDelegate, New Object() {sender, e})
        End If
    End Sub
    Private Sub HandleAtasco(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Holi")
    End Sub
    Private Sub HandleRemovido(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Holi removido")
    End Sub
    Private Sub HandleFallo(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("fallo")
    End Sub

    Private Sub meicontrol_OnConexionCompletada(ByVal numeroSerie As String, ByVal PuertoRegresado As String)
        varPub.SegundosSesion = 0
        ' Si la conexion es correcta le agregue a la dll en el evento de conexion completada que me
        'arrojara el puerto por el cual se habia conectado, asi que la dll a la que se le est haciend0
        'referencia es la mas actual
        'PuertoBillAceptor = PuertoRegresado
        Me.meicontrol.DetenerAceptacion()

        lbl_Status.Text = "CONEXION COMPLETADA"
        lbl_Status.ForeColor = Color.Orange

        'llamar FUNCION DE CONECTAR.. PARA INICIAR LA VALIDACION DE BILLETES
        Call Conectar1("COM" & varPub.Puerto_Val1)

    End Sub

    Private Sub meicontrol_OnConexionFallida(ByVal mensajeError As String)
        varPub.SegundosSesion = 0

        btn_Validador1.Focus()
        ' JMCB 
        'EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")

        Call fn_MsgBox(" Error al establecer la conexión con el validador.", MessageBoxIcon.Error, True, 2)
        Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ERROR DE CONEXION con el Validador")
        Me.Close()
    End Sub

#End Region

#Region "Event Handlers --Validador 2"

    Private Sub HandleConnectedEvent2(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(ConnectedDelegate2, New Object() {sender, e})
        Else
            BillAcceptor2.EnableAcceptance = True
            BillAcceptor2.AutoStack = False
            Call Alregresar()
            pct_cargando.Visible = False
            Btn_Salir.Enabled = True
            btn_Validador2.Image = My.Resources.btn_Pausa
            Val2_Conectado = True
            btn_Validador2.Text = "Pausar"
        End If
    End Sub

    Private Sub HandleEscrowedEvent2(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(EscrowedDelegate2, New Object() {sender, e})
        Else
            lbl_Status.Text = "BILLETE VALIDADO."
            lbl_Status.ForeColor = Color.Green

            lbl_Denominacion.Text = BillAcceptor2.Bill.Country & " " & BillAcceptor2.Bill.Value.ToString
            Call DatosBillete2()
            BillAcceptor2.EscrowReturn()
        End If
    End Sub

    Private Sub HandleReturnedEvent2(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(ReturnedDelegate2, New Object() {sender, e})
        End If
    End Sub

    Private Sub HandleNoteRetrievedEvent2(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(NoteRetrievedDelegate2, New Object() {sender, e})
        End If
    End Sub

    Private Sub HandleRejectedEvent2(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(RejectedDelegate2, New Object() {sender, e})
        Else
            lbl_Status.Text = "BILLETE NO IDENTIFICADO O PRESUNTAMENTE FALSO."
            lbl_Status.ForeColor = Color.Red
            lbl_Denominacion.Text = ""
            Pct_Billetes.Image = My.Resources.NoId
            Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "BILLETE PRESUNTAMENTE FALSO.")
        End If

    End Sub

    Private Sub HandleDisconnectedEvent2(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(DisconnectedDelegate2, New Object() {sender, e})
        End If
    End Sub

    Private Sub meicontrol_OnConexionCompletada2(ByVal numeroSerie As String, ByVal PuertoRegresado As String)
        varPub.SegundosSesion = 0
        ' Si la conexion es correcta le agregue a la dll en el evento de conexion completada que me
        'arrojara el puerto por el cual se habia conectado, asi que la dll a la que se le est haciend0
        'referencia es la mas actual

        Me.meicontrol2.DetenerAceptacion()
        lbl_Status.Text = "CONEXIÓN COMPLETADA"
        lbl_Status.ForeColor = Color.Orange

        'llamar FUNCION DE CONECTAR.. PARA INICIAR LA VALIDACION DE BILLETES
        Call Conectar2("COM" & varPub.Puerto_Val2)

    End Sub

    Private Sub meicontrol_OnConexionFallida2(ByVal mensajeError As String)
        varPub.SegundosSesion = 0

        btn_Validador2.Focus()
        ' JMCB
        'EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")

        Call fn_MsgBox("Error al establecer la conexión con el validador.", MessageBoxIcon.Error, True, 2)
        Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ERROR DE CONEXIÓN CON EL VALIDADOR.")
        Me.Close()
    End Sub

#End Region

#Region "Procedimientos Privados"

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub Conectar1(ByVal PuertoAceptador As String)
        Try
            Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "INICIANDO PROCESO DE VALIDACIÓN.")
            BillAcceptor.Open(PuertoAceptador, PowerUp.A)
        Catch err As Exception
            ' jmcb
            'EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")

            Call fn_MsgBox("No se logro la conexion con el validador de billetes.", MessageBoxIcon.Error, True, 2)
            Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ERROR DE CONEXIÓN CON EL VALIDADOR.")
            btn_Validador1.Enabled = True
            Btn_Salir.Enabled = True
        End Try
    End Sub

    Private Sub Conectar2(ByVal PuertoAceptador As String)
        Try
            Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "INICIANDO PROCESO DE VALIDACIÓN.")

            BillAcceptor2.Open(PuertoAceptador, PowerUp.A)
        Catch err As Exception
            'jmcb
            'EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")

            Call fn_MsgBox("No se logro la conexion con el validador de billetes.", MessageBoxIcon.Error, True, 2)
            Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ERROR DE CONEXIÓN CON EL VALIDADOR.")
            btn_Validador2.Enabled = True
            Btn_Salir.Enabled = True
        End Try
    End Sub

    Private Sub Alregresar()
        lbl_Status.Text = "INTRODUZCA EL BILLETE"
        lbl_Status.ForeColor = Color.Green
        lbl_Denominacion.Text = ""
        Pct_Billetes.Image = Nothing

        Btn_Salir.Enabled = True
        pnl_General.Enabled = True
    End Sub

    Private Sub DatosBillete()
        varPub.SegundosSesion = 0

        If BillAcceptor.DocType = DocumentType.Bill Then
            If BillAcceptor.Bill Is Nothing Then
                lbl_Status.Text = " ERROR AL VALIDAR EL BILLETE."
                Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ERROR AL VALIDAR BILLETE.")
                Exit Sub
            End If

            Select Case BillAcceptor.Bill.Country.ToString.ToUpper
                Case "MXP", "MXN"
                    Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "BILLETE DE: " & BillAcceptor.Bill.Value.ToString() & " VALIDADO.")
                    Select Case BillAcceptor.Bill.Value.ToString()
                        Case "20"
                            Pct_Billetes.Image = My.Resources.MXP20
                        Case "50"
                            Pct_Billetes.Image = My.Resources.MXP50
                        Case "100"
                            Pct_Billetes.Image = My.Resources.MXP100
                        Case "200"
                            Pct_Billetes.Image = My.Resources.MXP200
                        Case "500"
                            Pct_Billetes.Image = My.Resources.MXP500
                        Case "1000"
                            Pct_Billetes.Image = My.Resources.MXP1000
                    End Select
                Case "USD"
                    Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "BILLETE DE: " & BillAcceptor.Bill.Value.ToString() & " VALIDADO.")
                    Select Case BillAcceptor.Bill.Value.ToString()
                        Case "1"
                            Pct_Billetes.Image = My.Resources.USD1
                        Case "2"
                            Pct_Billetes.Image = My.Resources.USD2
                        Case "5"
                            Pct_Billetes.Image = My.Resources.USD5
                        Case "10"
                            Pct_Billetes.Image = My.Resources.USD10
                        Case "20"
                            Pct_Billetes.Image = My.Resources.USD20
                        Case "50"
                            Pct_Billetes.Image = My.Resources.USD50
                        Case "100"
                            Pct_Billetes.Image = My.Resources.USD100
                    End Select
            End Select
        End If
    End Sub

    Private Sub DatosBillete2()
        varPub.SegundosSesion = 0

        If BillAcceptor2.DocType = DocumentType.Bill Then
            If BillAcceptor2.Bill Is Nothing Then
                lbl_Status.Text = " ERROR AL VALIDAR EL BILLETE."
                Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ERROR AL VALIDAR BILLETE")
                Exit Sub
            End If

            Select Case BillAcceptor2.Bill.Country.ToString.ToUpper
                Case "MXP", "MXN"
                    Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "BILLETE DE: " & BillAcceptor2.Bill.Value.ToString() & " VALIDADO")
                    Select Case BillAcceptor2.Bill.Value.ToString()
                        Case "20"
                            Pct_Billetes.Image = My.Resources.MXP20
                        Case "50"
                            Pct_Billetes.Image = My.Resources.MXP50
                        Case "100"
                            Pct_Billetes.Image = My.Resources.MXP100
                        Case "200"
                            Pct_Billetes.Image = My.Resources.MXP200
                        Case "500"
                            Pct_Billetes.Image = My.Resources.MXP500
                        Case "1000"
                            Pct_Billetes.Image = My.Resources.MXP1000
                    End Select
                Case "USD"
                    Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES.", "BILLETE DE: " & BillAcceptor2.Bill.Value.ToString() & " VALIDADO")
                    Select Case BillAcceptor2.Bill.Value.ToString()
                        Case "1"
                            Pct_Billetes.Image = My.Resources.USD1
                        Case "2"
                            Pct_Billetes.Image = My.Resources.USD2
                        Case "5"
                            Pct_Billetes.Image = My.Resources.USD5
                        Case "10"
                            Pct_Billetes.Image = My.Resources.USD10
                        Case "20"
                            Pct_Billetes.Image = My.Resources.USD20
                        Case "50"
                            Pct_Billetes.Image = My.Resources.USD50
                        Case "100"
                            Pct_Billetes.Image = My.Resources.USD100
                    End Select
            End Select
        End If
    End Sub

#End Region

    Private Sub frm_ValidarBillete_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        BillAcceptor.Close()
        BillAcceptor2.Close() ' pendiente
    End Sub

    Private Sub frm_ValidarBillete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 41

        varPub.SegundosSesion = 0
        Call CambiarTamanodelosControles()

        btn_Validador1.Enabled = varPub.Activar_Val1
        btn_Salir.Enabled = True

        If varPub.Cant_Validadores = 2 Then
            btn_Validador2.Visible = True
            btn_Validador2.Enabled = varPub.Activar_Val2
        End If
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Status_Click(sender As Object, e As EventArgs) Handles lbl_Status.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Denominacion_Click(sender As Object, e As EventArgs) Handles lbl_Denominacion.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Validador1_Click(sender As Object, e As EventArgs) Handles btn_Validador1.Click
        varPub.SegundosSesion = 0
        If varPub.Activar_Val1 = 0 Then
            Call fn_MsgBox("El validador 1 ha sido desactivado por el Administrador.", MessageBoxIcon.Error, True, 2)
            Exit Sub
        End If

        pnl_General.Enabled = False
        If Val1_Conectado = False Then
            btn_Validador2.Enabled = False
            lbl_Status.Text = "INICIANDO CONEXION CON VAL. 1"
            pct_cargando.Visible = True
            'Se inicia la conexion con el meicontrol para poder obtener el puerto 
            Me.meicontrol.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val1, False, False)
            Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "INICIANDO VALIDADOR1")

        Else
            pnl_General.Enabled = True
            If BillAcceptor.EnableAcceptance = True Then
                BillAcceptor.EnableAcceptance = False ' solo suspende
                btn_Validador1.Image = My.Resources.Inicializar
                btn_Validador1.Text = "Iniciar Val.1"
                pct_Billetes.Image = Nothing
                btn_Validador2.Enabled = True
                lbl_Status.Text = "--||--"
                lbl_Denominacion.Text = ""
            Else
                lbl_Status.Text = "INTRODUZCA EL BILLETE"
                btn_Validador1.Image = My.Resources.btn_Pausa
                BillAcceptor.EnableAcceptance = True
                btn_Validador1.Text = "Pausar"
                btn_Validador2.Enabled = False
            End If
        End If
    End Sub

    Private Sub btn_Validador2_Click(sender As Object, e As EventArgs) Handles btn_Validador2.Click
        varPub.SegundosSesion = 0
        If varPub.Activar_Val2 = 0 Then
            Call fn_MsgBox("El validador 2 ha sido desactivado por el Administrador.", MessageBoxIcon.Error, True, 2)
            Exit Sub
        End If

        pnl_General.Enabled = False
        If Val2_Conectado = False Then
            btn_Validador1.Enabled = False
            lbl_Status.Text = "INICIANDO CONEXION CON VAL. 2"
            pct_cargando.Visible = True
            'Se inicia la conexion con el meicontrol para poder obtener el puerto 
            Me.meicontrol2.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val2, False, False)
            Call fn_EscribirLog(varPub.UsuarioClave, "Validar Billetes", "Iniciando Validador2")

        Else
            pnl_General.Enabled = True
            If BillAcceptor2.EnableAcceptance = True Then
                BillAcceptor2.EnableAcceptance = False ' solo suspende
                btn_Validador2.Image = My.Resources.Inicializar
                pct_Billetes.Image = Nothing
                btn_Validador1.Enabled = True
                btn_Validador2.Text = "Iniciar Val.2"
                lbl_Status.Text = "--||--"
                lbl_Denominacion.Text = ""
            Else
                lbl_Status.Text = "INTRODUZCA EL BILLETE"
                BillAcceptor2.EnableAcceptance = True
                btn_Validador2.Image = My.Resources.btn_Pausa
                btn_Validador2.Text = "Pausar"
                btn_Validador1.Enabled = False
            End If
        End If
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        varPub.SegundosSesion = 0
        Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "CERRANDO VENTANA VALIDAR BILLETES.")
        BillAcceptor.Close()
        BillAcceptor2.Close()
        Me.Close()
    End Sub

End Class