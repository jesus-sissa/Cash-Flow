Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL

Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Correo

Imports Modulo_CashFlowV2.cls_Usuarios
Imports System.IO
Imports NMPOST

Public Class frm_DepositoXvalidadorNew

#Region "-Variables"

    Public Id_CajaLocal As Integer = 0
    Public Clave_CajaLocal As String = ""

    Public Id_Caja As Integer = 0     'Esta variable se usurá para guardar el Id_Caja Local y Id_Caja por Web Service
    Public Clave_Caja As String = ""  'Esta variable se usurá para guardar el Clave_Caja Local y Clave_Caja por Web Service

    Private Event DepositoFinalizar_PorWebS(CierreDeposito As CierreDeposito)

    Public TotalDepositado As Integer 'variable,  que gurda el total de ingreso del deposito actual, la cual se va a comparar con el monto enviado por ws
    Private StatusCajeroDic As New Dictionary(Of String, String)
    Private MontoDepositadoV1 As Integer = 0
    Private MontoDepositadoV2 As Integer = 0

    Dim Contador As Integer = 0, Contador2 As Integer = 0
    Dim ContadorDolar As Integer = 0, ContadorDolar2 As Integer = 0
    Dim DepositoDesconexion As Boolean = False

    Dim PesoDolar1() As Integer = {0, 0} 'PESO , DOLAR
    Dim PesoDolar2() As Integer = {0, 0} 'PESO , DOLAR

    Dim EstadoMEI_V1 As String = "Iniciando"
    Dim EstadoMEI_V2 As String = "Iniciando"
    Dim Alerta() As String = {"", ""}
    '
    'Dim Estado As String = ""
    ' Dim Activo As Boolean = False
    ''
    Dim SerieVal1Obtenido As String = ""
    Dim SerieVal2Obtenido As String = ""
    Dim DenominacionV1 As String = "0"
    Dim DenominacionV2 As String = "0"
    Dim Removido As Boolean = False
    Dim timer_ok As Boolean = False
    Public Folio_Registrar As String
    Public Importe_Registrar As Decimal
    Dim sDescripcion As String = ""



#End Region



    ''
    Private Sub HandleConnectedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(ConnectedDelegate, New Object() {sender, e})
        Else
            'BillAcceptor.EnableAcceptance = True
            'BillAcceptor.AutoStack = False
            'Call Alregresar()
            'pct_cargando.Visible = False
            'Btn_Salir.Enabled = True
            'btn_Validador1.Image = My.Resources.btn_Pausa
            'Val1_Conectado = True
            'btn_Validador1.Text = "Pausar"
        End If
    End Sub
    Private Sub HandleDisconnectedEvent(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        If InvokeRequired Then
            BeginInvoke(DisconnectedDelegate, New Object() {sender, e})
        End If
    End Sub
    ''
    Enum CierreDeposito
        CERRADO_POR_USUARIO = 0
        CERRADO_POR_TIMEOUT = 1
        CERRADO_POR_CONEXION_FALLIDA = 2
        CERRADO_POR_CASETERO_LLENO = 3
        CERRADO_POR_CAJERO = 4
        CERRADO_POR_VALIDADOR_REMOVIDO = 5
    End Enum

#Region "Variables Privadas"

    Private meicontrol1 As New NCcash.NewMeiDevice
    Private meicontrol2 As New NCcash.NewMeiDevice

    Private BillAcceptor2 As New NMPOST.Acceptor

    Private ConnectedDelegate As New ConnectedEventHandler(AddressOf HandleConnectedEvent)
    Private DisconnectedDelegate As New DisconnectedEventHandler(AddressOf HandleDisconnectedEvent)
    Private conectarbill As New ConnectedEventHandler(AddressOf HandleConnectedEvent)

#End Region

#Region "Eventos Privados de la 1ra Instancia del Validador"

    ''' <summary>
    ''' Iniciar el equipo CashFlow
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub InicializarControl()
        varPub.SegundosReceptor = 0
        'Quitar el control a la forma, no es visible
        Me.Controls.Remove(Me.meicontrol1)

        'Crear el control
        Me.meicontrol1 = New NCcash.NewMeiDevice

        '***Definición de Eventos

        'Evento para Recepción de Billetes
        AddHandler meicontrol1.OnBilleteAceptado, AddressOf meicontrol_OnBilleteAceptado
        'Evento indica Conexión Correcta
        AddHandler meicontrol1.OnConexionCompletada, AddressOf meicontrol_OnConexionCompletada
        'Evento indica Conexión Fallida
        AddHandler meicontrol1.OnConexionFallida, AddressOf meicontrol_OnConexionFallida
        'Evento indica los Diferentes Estados del Validador
        AddHandler meicontrol1.OnEstadosAceptador, AddressOf meicontrol_OnEstadosAceptador
        'Evento que se lanza en caso de que ocurra algun error de caracter general
        AddHandler meicontrol1.OnError, AddressOf meicontrol_OnError
        'Evento que indica cuando un billete es retirado de la boca del validador
        AddHandler meicontrol1.OnBilleteRetirado, AddressOf meicontrol_OnBilleteRetirado


        'Agregar el control a la forma, no es visible
        Me.Controls.Add(Me.meicontrol1)
        ''
        'AddHandler BillAcceptor.OnConnected, ConnectedDelegate
        'AddHandler BillAcceptor.OnDisconnected, DisconnectedDelegate
        ''
        'AddHandler BillAcceptor.OnCashBoxRemoved, remov
        varPub.SegundosReceptor = 0
    End Sub




    ''' <summary>
    ''' Evento que muestra los diferentes estados del validador
    ''' </summary>
    ''' <param name="estadoMei"></param>
    ''' <remarks></remarks>

    Private Sub meicontrol_OnEstadosAceptador(ByVal estadoMei As String)
        'fn_Log_Depositos("estados aceptador v1")
        'fn_Log_Depositos("estado_mei_val1:" + estadoMei)

        'Call fn_EscribirLog("----------------------------------------------------------------------------------------------------------------------", estadoMei, "  ")
        'Dim x As Integer = Ccash.e_TipoEventoMei.Almacenado
        ' Activo = BillAcceptor.BNFStatus
        '        Call fn_EscribirLog("--------------------", "--------------------------------------------", " 0000000000000000000000000000000000000000000000000000xxxxxxxxxxxxxxxx " & BillAcceptor.BNFStatus.ToString)
        'If Activo AndAlso BillAcceptor.BNFStatus.ToString() = "Unknown" Then
        '    MessageBox.Show("Ya valio")
        'End If
        'Call fn_EscribirLog("--------------------", "--------------------------------------------", " ---------------------------------------------xxxxxxxxxxxxxxxx " & estadoMei)
        'If estadoMei.ToUpper = "FALLA" Then
        '    Call fn_MsgBox(" ya detecto" & varPub.Serie_Val1, MessageBoxIcon.Exclamation, True, 3) 
        'End If
        'If estadoMei.ToUpper = "ATASCADO" Then
        '    btn_Finalizar.Enabled = True
        'End If
        EstadoMEI_V1 = estadoMei

        If estadoMei.ToUpper = "DESCONECTADO" AndAlso varPub.D_On = True AndAlso Not timer_ok Then
            'If estadoMei.ToUpper = "DESCONECTADO" Or estadoMei.ToUpper = "ATASCADO" Then
            'fn_Log_Depositos("estado_mei_val1:" + estadoMei)
            varPub.FlagImprimirTicket = 2

            'COMENTARIZADO POR BJSE 07/06/2021, CREACION DE TRIGGER PARA ENVIAR CORREO DIRECTAMENTE DESDE SQL
            'EnviarCorreo("DEPOSITOS, ATASCO DETECTADO VALIDADOR No. 1. </br>ULTIMA DENOMINACION ACEPTADA: <strong>$" & DenominacionV1 & ".00</strong>", "ATASCO - " + varPub.Nombre_Sucursal)
            'sDescripcion = "DEPOSITOS, ATASCO DETECTADO VALIDADOR No. 1. </br>ULTIMA DENOMINACION ACEPTADA: <strong>$" & DenominacionV1 & ".00</strong>" + " ATASCO"

            finalizar_deposito(CierreDeposito.CERRADO_POR_VALIDADOR_REMOVIDO)
            Dim Persistente As New cls_VariablesPersistentes()

            'If estadoMei.ToUpper = "DESCONECTADO" Then
            varPub.Activar_Val1 = 0
            'End If

            Persistente.Persistir()
            Persistente.Cargar()

            If DenominacionV1 > 0 Then
                AnularDenominacion(varPub.ID_DepositoP, DenominacionV1, 1, varPub.Serie_Val1, varPub.Serie_Caset1)
                cls_CashFlow.fn_Depositos_imprimir(1, varPub.ID_DepositoP, 24)
                'Call fn_EscribirLog(varPub.UsuarioClave, "IMPRIMIR ATASCO:", DenominacionV1)
                Dim frm As New frm_ImprimirAtasco()
                frm.ShowDialog()
            End If

            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 16, 24, "DEPOSITOS, ID DEPOSITO: " & varPub.ID_DepositoP.ToString() & " POSIBLE ATASCO DETECTADO V1." & " ULTIMA DENOMINACION ACEPTADA:  " & DenominacionV1)
            varPub.FlagImprimirTicket = 1
            varPub.ID_DepositoP = 0
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS, POSIBLE ATASCO DETECTADO V1.", " ULTIMA DENOMINACION ACEPTADA: " & DenominacionV1)
            varPub.D_On = False
            varPub.state = False
            Removido = True


        End If
        If estadoMei.ToUpper = "ACEPTANDO" Or estadoMei.ToUpper = "INGRESANDO" Then 'New
            'para que este reinicando el contador
            varPub.SegundosReceptor = 0
        End If

        If estadoMei.ToUpper = "ATASCADO" Then
            lsv_Datos.BackColor = Color.FromArgb(255, 153, 51)
        End If

        'If varPub.Activar_Val2 AndAlso (varPub.Cant_Validadores = 2 And EstadoMEI_V2 <> "Fallo_Conexion") Then
        '    If (EstadoMEI_V1 <> "Listo" OrElse EstadoMEI_V2 <> "Listo") And EstadoMEI_V2 <> "Iniciando" Then
        '        btn_Finalizar.Enabled = False
        '    Else
        '        btn_Finalizar.Enabled = True
        '    End If
        'Else
        '    Select Case estadoMei.ToUpper
        '        Case "ACEPTANDO", "INGRESANDO", "ALMACENANDO", "RECHAZANDO"
        '            btn_Finalizar.Enabled = False
        '        Case "LISTO"
        '            btn_Finalizar.Enabled = True

        '    End Select
        '    '--->
        '    If prg_Caset1.Value = prg_Caset1.Maximum AndAlso estadoMei.ToUpper = "DESCONECTADO" Then
        '        btn_Finalizar.Enabled = True
        '    End If

        'End If

        If estadoMei.ToUpper = "DESCONECTADO" Then
            EstadoMEI_V1 = "DESCONECTADO"
            meicontrol1.DetenerAceptacion()
            lsv_Datos.BackColor = Color.IndianRed
            varPub.SegundosReceptor = 0
            varPub.SegundosSesion = 0
            btn_Iniciar.Text = "Cajas"
            btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
            btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
            btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
            btn_Finalizar.Enabled = False
            btn_Cerrar.Enabled = True
            pnl_General.Enabled = True
            pct_cargando.Visible = False
            tmr_depositos.Enabled = False
        End If

        If EstadoMEI_V1 = "Listo" Or EstadoMEI_V2 = "Listo" Then
            'tmr_depositos.Enabled = True
        End If

        If SerieVal1Obtenido.Trim <> "" AndAlso (SerieVal1Obtenido <> varPub.Serie_Val1) Then
            EstadoMEI_V1 = "Fallo_Conexion"
        End If



    End Sub

    Private Sub finalizar_deposito(tipo As CierreDeposito)
        varPub.D_On = False
        If varPub.ManejaConexionWebService = 0 Then
            Call FinalizarDeposito(tipo)
            btn_Iniciar.Text = "Cajas"
            btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
            btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
            btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
        ElseIf varPub.ManejaConexionWebService = 1 Then
            RaiseEvent DepositoFinalizar_PorWebS(tipo)
        End If
    End Sub

    ''' <summary>
    ''' Evento que indica que no se efectuó la conexión
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnConexionFallida(ByVal mensajeError As String)
        fn_Log_Depositos("Conexionfallida_mei_val1:" + mensajeError)
        Dim Persistente As New cls_VariablesPersistentes()
        '----- IF POR SI SON 2 VALIDADORES ------
        If varPub.Cant_Validadores = 2 AndAlso varPub.Activar_Val2 Then

            tmr_depositos.Enabled = False '-27/06/2013
            Me.meicontrol1.DetenerAceptacion()
            'MessageBox.Show(varPub.SegundosReceptor + " " + EstadoMEI_V1.ToString())
            Call fn_Depositos_Detalle(mensajeError & " CON NUMERO DE SERIE: " & varPub.Serie_Val1)
            Call fn_MsgBox(mensajeError & " (Val: 1), Con Número de serie: " & varPub.Serie_Val1, MessageBoxIcon.Exclamation, True, 3)
            lsv_Datos.BackColor = Color.IndianRed
            EstadoMEI_V1 = "Fallo_Conexion"
            varPub.SegundosSesion = 0
            btn_Cerrar.Enabled = True
            'si las 2 variables son vacias , tonces ninguna se conecto
            If EstadoMEI_V1 = "Fallo_Conexion" AndAlso EstadoMEI_V2 = "Fallo_Conexion" Then
                btn_Iniciar.Enabled = False
                btn_Finalizar.Enabled = False
                btn_Cerrar.Enabled = True
                pnl_General.Enabled = True
                pct_cargando.Visible = False
                btn_Iniciar.Focus()
                If varPub.ID_DepositoP > 0 Then
                    If varPub.ManejaConexionWebService = 0 Then
                        Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
                    End If

                    If varPub.ManejaConexionWebService = 1 Then
                        RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)

                    End If
                End If
                varPub.SegundosSesion = 0
                varPub.SegundosReceptor = 0
                lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

                btn_Iniciar.Text = "Cajas"
                btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
                btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
                btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
            End If
            If EstadoMEI_V2 <> "Fallo_Conexion" Then
                tmr_depositos.Enabled = True
            End If
            'Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)

            'finalizar_deposito(CierreDeposito.CERRADO_POR_USUARIO)
            ' finalizar_deposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)

            varPub.Activar_Val1 = 0
            Persistente.Persistir()
            Persistente.Cargar()

            'Call fn_Menus_Open(31, 0)
            'btn_Iniciar.PerformClick()

            Exit Sub 'salir despues de validar....
        End If

        '----- ESTE IF SOLO CUANDO ES  1 VALIDADOR --------
        tmr_depositos.Enabled = False

        Me.meicontrol1.DetenerAceptacion()
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        Call fn_MsgBox(mensajeError & " (Val: 1), Con Número de serie: " & varPub.Serie_Val1, MessageBoxIcon.Exclamation, True, 2)

        btn_Iniciar.Enabled = False
        btn_Finalizar.Enabled = False
        btn_Cerrar.Enabled = True
        pnl_General.Enabled = True
        pct_cargando.Visible = False
        btn_Iniciar.Focus()
        lsv_Datos.BackColor = Color.IndianRed
        lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

        Call fn_Depositos_Detalle(mensajeError & " CON NUMERO DE SERIE: " & varPub.Serie_Val1)

        If varPub.ID_DepositoP > 0 Then
            If varPub.ManejaConexionWebService = 0 Then
                Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
            End If

            If varPub.ManejaConexionWebService = 1 Then
                RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
            End If
        End If

        btn_Iniciar.Text = "Cajas"
        btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
        btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
        btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
        varPub.Activar_Val1 = 0
        Persistente.Persistir()
        Persistente.Cargar()

    End Sub

    Public Function meicontrol_OnConexionFallidaPruebas() As Boolean
        '----- IF POR SI SON 2 VALIDADORES ------
        If varPub.Cant_Validadores = 2 AndAlso varPub.Activar_Val2 Then

            tmr_depositos.Enabled = False '-27/06/2013
            Me.meicontrol1.DetenerAceptacion()
            ' MessageBox.Show(varPub.SegundosReceptor + " " + EstadoMEI_V1.ToString())
            'Call fn_Depositos_Detalle(mensajeError & " CON NUMERO DE SERIE: " & varPub.Serie_Val1)
            'Call fn_MsgBox(mensajeError & " (Val: 1), Con Número de serie: " & varPub.Serie_Val1, MessageBoxIcon.Exclamation, True, 3)
            lsv_Datos.BackColor = Color.IndianRed
            EstadoMEI_V1 = "Fallo_Conexion"
            varPub.SegundosSesion = 0
            btn_Cerrar.Enabled = True
            'si las 2 variables son vacias , tonces ninguna se conecto
            If EstadoMEI_V1 = "Fallo_Conexion" AndAlso EstadoMEI_V2 = "Fallo_Conexion" Then
                btn_Iniciar.Enabled = False
                btn_Finalizar.Enabled = False
                btn_Cerrar.Enabled = True
                pnl_General.Enabled = True
                pct_cargando.Visible = False
                btn_Iniciar.Focus()
                If varPub.ID_DepositoP > 0 Then
                    If varPub.ManejaConexionWebService = 0 Then
                        Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
                    End If

                    If varPub.ManejaConexionWebService = 1 Then
                        RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
                    End If
                End If
                varPub.SegundosSesion = 0
                varPub.SegundosReceptor = 0
                lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

                btn_Iniciar.Text = "Cajas"
                btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
                btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
                btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
            End If
            If EstadoMEI_V2 <> "Fallo_Conexion" Then
                tmr_depositos.Enabled = True
            End If
            'Exit Sub 'salir despues de validar....
        End If

        '----- ESTE IF SOLO CUANDO ES  1 VALIDADOR --------
        tmr_depositos.Enabled = False

        Me.meicontrol1.DetenerAceptacion()
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        'Call fn_MsgBox(mensajeError & " (Val: 1), Con Número de serie: " & varPub.Serie_Val1, MessageBoxIcon.Exclamation, True, 3)

        btn_Iniciar.Enabled = False
        btn_Finalizar.Enabled = False
        btn_Cerrar.Enabled = True
        pnl_General.Enabled = True
        pct_cargando.Visible = False
        btn_Iniciar.Focus()
        lsv_Datos.BackColor = Color.IndianRed
        lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

        'Call fn_Depositos_Detalle(mensajeError & " CON NUMERO DE SERIE: " & varPub.Serie_Val1)

        If varPub.ID_DepositoP > 0 Then
            If varPub.ManejaConexionWebService = 0 Then
                Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
            End If

            If varPub.ManejaConexionWebService = 1 Then
                RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
            End If
        End If

        btn_Iniciar.Text = "Cajas"
        btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
        btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
        btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)

        Return EstadoMEI_V1
    End Function
    ''' <summary>
    ''' Evento que indica que la conexión fue correcta
    ''' </summary>
    ''' <param name="numeroSerie">Numero de serie del validador</param>
    ''' <param name="PuertoRegresado"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnConexionCompletada(ByVal numeroSerie As String, ByVal PuertoRegresado As String)
        fn_Log_Depositos("ConexionCompletada_mei_val1")
        varPub.SegundosReceptor = 0

        'Activo = True
        SerieVal1Obtenido = numeroSerie
        Removido = False
        If numeroSerie <> varPub.Serie_Val1 Then
            Me.meicontrol1.DetenerAceptacion()
            Call fn_MsgBox("El número de serie del validador1 no coincide con el que se tiene registrado, consulte al Administrador.", MessageBoxIcon.Error)
            Exit Sub

        End If
        'Me.lsv_Datos.Items.Add(numeroSerie)
        ' metodo que inicia la aceptacion de billetes en forma manual. es necesario haber realizado primero la conexion con el validador
        ' en caso de error se lanza el evento OnError 
        ' se debe usar una vez que se ha lanzado el evento de conexion completa
        ' para usarlo pon el false el parametro 4 del metodo IniciarConexion y descomenta esta linea
        'Me.meicontrol.IniciarAceptacion()
        If (varPub.ID_DepositoP > 0) Then
            lsv_Datos.BackColor = Color.FromArgb(53, 170, 71) 'pone lsv1 en verde porke esta conectado.
            EstadoMEI_V1 = "Listo"
        End If
        If varPub.Activar_Val2 AndAlso (varPub.Cant_Validadores = 2 AndAlso EstadoMEI_V2 = "Iniciando") Then
            Exit Sub
        Else
            'EnviarCorreo("DEPOSITOS, POSIBLE ATASCO DETECTADO V1.", "ATASCO")

            If varPub.Cant_Validadores = 1 Then EstadoMEI_V2 = "Fallo_Conexion"
            If (varPub.ID_DepositoP > 0) Then
                btn_Iniciar.Enabled = False
                btn_Finalizar.Enabled = True
                btn_Cerrar.Enabled = False
                pnl_General.Enabled = True
                pct_cargando.Visible = False
                ''''
                varPub.state = True
                btn_Finalizar.Focus()
            Else
                varPub.state = True
                meicontrol1.DetenerAceptacion()
            End If
        End If
        If varPub.ManejaConexionWebService = 1 Then
            If varPub.CajeroStatus = "CF" Then varPub.CajeroStatus = "D"
        End If
        'Me.meicontrol1.DetenerAceptacion()
        'BillAcceptor.Open(PuertoRegresado, PowerUp.A)
        'Timer1.Enabled = True
        'Activo = True
    End Sub
    Public Function meicontrol_OnConexionCompletadaPrueba(ByVal numeroSerie As String, ByVal PuertoRegresado As String) As String
        varPub.SegundosReceptor = 0

        'Activo = True
        SerieVal1Obtenido = numeroSerie
        Removido = False
        If numeroSerie <> varPub.Serie_Val1 Then
            Me.meicontrol1.DetenerAceptacion()
            Call fn_MsgBox("El número de serie del validador1 no coincide con el que se tiene registrado, consulte al Administrador.", MessageBoxIcon.Error)
            'Exit Sub

        End If
        'Me.lsv_Datos.Items.Add(numeroSerie)
        ' metodo que inicia la aceptacion de billetes en forma manual. es necesario haber realizado primero la conexion con el validador
        ' en caso de error se lanza el evento OnError 
        ' se debe usar una vez que se ha lanzado el evento de conexion completa
        ' para usarlo pon el false el parametro 4 del metodo IniciarConexion y descomenta esta linea
        'Me.meicontrol.IniciarAceptacion()
        If (varPub.ID_DepositoP > 0) Then
            lsv_Datos.BackColor = Color.FromArgb(53, 170, 71) 'pone lsv1 en verde porke esta conectado.
            EstadoMEI_V1 = "Listo"
        End If
        If varPub.Activar_Val2 AndAlso (varPub.Cant_Validadores = 2 AndAlso EstadoMEI_V2 = "Iniciando") Then
            'Exit Sub
        Else
            'EnviarCorreo("DEPOSITOS, POSIBLE ATASCO DETECTADO V1.", "ATASCO")

            If varPub.Cant_Validadores = 1 Then EstadoMEI_V2 = "Fallo_Conexion"
            If (varPub.ID_DepositoP > 0) Then
                btn_Iniciar.Enabled = False
                btn_Finalizar.Enabled = True
                btn_Cerrar.Enabled = False
                pnl_General.Enabled = True
                pct_cargando.Visible = False
                ''''
                varPub.state = True
                btn_Finalizar.Focus()
            Else
                varPub.state = True
                meicontrol1.DetenerAceptacion()
            End If
        End If
        If varPub.ManejaConexionWebService = 1 Then
            If varPub.CajeroStatus = "CF" Then varPub.CajeroStatus = "D"
        End If
        'Me.meicontrol1.DetenerAceptacion()
        'BillAcceptor.Open(PuertoRegresado, PowerUp.A)
        'Timer1.Enabled = True
        'Activo = True
        Return EstadoMEI_V1
    End Function

    ''' <summary>
    ''' Evento que se lanza al guardar un billete en el cassete
    ''' </summary>
    ''' <param name="billeteAceptado"></param>
    ''' <remarks></remarks>
    Private Sub meicontrol_OnBilleteAceptado(ByVal billeteAceptado As NCcash.NewMeiDevice.DatosBilleteAceptado)
        varPub.SegundosReceptor = 0

        fn_Log_Depositos("BilleteAceptado_mei_val1:" + billeteAceptado.ToString())

        If billeteAceptado.Moneda.Trim = "MXN" Then
            billeteAceptado.Moneda = "MXP"
        Else
            billeteAceptado.Moneda = "MXP"
        End If


        If fn_Depositos_GuardarBillete(billeteAceptado.Moneda.Trim, CInt(billeteAceptado.Denominacion), varPub.Serie_Val1, varPub.Serie_Caset1, "CasetID", "1") Then
            varPub.D_On = True
            DenominacionV1 = billeteAceptado.Denominacion.ToString()
            Dim item As ListViewItem
            item = New ListViewItem(billeteAceptado.Moneda.Trim) 'MXP, MXN
            item.SubItems.Add(billeteAceptado.Denominacion.Trim)
            item.SubItems.Add(varPub.Serie_Val1)
            lsv_Datos.Items.Add(item)

            Call Calcular_Total()
            Call Porcentaje_Avance()
            If lsv_Datos.Items.Count > 0 Then
                lsv_Datos.Items.Item(lsv_Datos.Items.Count - 1).EnsureVisible()
            End If
        End If
    End Sub

    Private Sub Calcular_Total()
        lbl_Total1.Text = "TotalV1 $ 0.00 MXN"
        Dim ImportePesos As Integer = 0
        Dim ImporteDolar As Integer = 0
        Contador = 0
        ContadorDolar = 0

        For Each Item As ListViewItem In lsv_Datos.Items

            If Item.Text.Trim = "MXP" OrElse Item.Text.Trim = "MXN" Then
                ImportePesos += CInt(Item.SubItems(1).Text)
                MontoDepositadoV1 = ImportePesos
                Contador += 1
            ElseIf Item.Text.Trim = "USD" Then
                ImporteDolar += CInt(Item.SubItems(1).Text)
                ContadorDolar += 1
            End If
        Next

        lsv_Datos.Columns(1).TextAlign = HorizontalAlignment.Right
        lbl_Total1.Text = ImportePesos & "/" & ImporteDolar

        PesoDolar1(0) = ImportePesos
        PesoDolar1(1) = ImporteDolar

        If CInt(PesoDolar1(1)) > 0 Then
            lbl_Total1.Text = "TotalV1: " & PesoDolar1(0) & "MXP" & "(" & Contador & "Pza)" & " / " & PesoDolar1(1) & "USD" & "(" & ContadorDolar & "Pza)"
        Else
            lbl_Total1.Text = "TotalV1: " & PesoDolar1(0) & "MXP" & " (" & Contador & " Piezas)"
            If lbl_Total1.Text = "0/0" Then lbl_Total1.Text = "TotalV1: 0 MXN, 0 USD"
        End If

    End Sub

    Private Function Porcentaje_Avance() As Boolean

        prg_Caset1.Value = varPub.Capacidad_Actual '< 800

        If prg_Caset1.Value < prg_Caset1.Maximum Then

            Dim Calculo_Llenado As Integer = CInt((varPub.Capacidad_Actual / varPub.Capacidad_Caset) * 100)
            If Calculo_Llenado >= varPub.Porcentaje_Alerta Then
                lbl_Alerta.Visible = True
                Alerta(0) = "    Caset1 Llenandose - "
                lbl_Alerta.Text = Alerta(0) & Alerta(1)
            End If
            Return False '-->> llenandose
        Else
            Me.meicontrol1.DetenerAceptacion() '-->Pendiente
            EstadoMEI_V1 = "Fallo_Conexion" '--> 29enero2014 para sincronizar timer receptor

            Alerta(0) = "    Caset1 Lleno - "
            lbl_Alerta.Text = Alerta(0) & Alerta(1)
            Call fn_Depositos_Detalle("CASETERO 1 ESTA LLENO.")
            lbl_Alerta.Visible = True

            Call fn_MsgBox("El caset se ha llenado, Favor de comunicarse con la empresa de traslado de valores", MessageBoxIcon.Exclamation, True, 2)
            If varPub.Cant_Validadores = 1 Then

                If varPub.ManejaConexionWebService = 0 Then
                    Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If


                If varPub.ManejaConexionWebService = 1 Then
                    RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If

            ElseIf varPub.Cant_Validadores = 2 AndAlso prg_Caset2.Value = prg_Caset2.Maximum Then

                If varPub.ManejaConexionWebService = 0 Then
                    Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If

                If varPub.ManejaConexionWebService = 1 Then
                    RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If
            End If

            Return True '<<--lleno
        End If

    End Function


    ''' <summary>
    ''' Evento que indica el error que ha sucedido
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnError(ByVal mensajeError As String)
        fn_Log_Depositos("OnError_mei_val1:" + mensajeError.ToString())
        Call fn_Depositos_Detalle(mensajeError.ToUpper)
        Call fn_MsgBox(mensajeError, MessageBoxIcon.Error, True, 1)
    End Sub

    ''' <summary>
    ''' Evento que indica cuando un billete fue retirado de la boca del validador
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub meicontrol_OnBilleteRetirado()
        'fn_Log_Depositos("OnBilleteRetirado_mei_val1")
        varPub.SegundosReceptor = 0
        'cls_CashFlow.GetAnulacionDenominacion(varPub.ID_DepositoP, 1, DenominacionV1)
        Call fn_Depositos_Detalle("BILLETE RETIRADO DEL VALIDADOR 1, SERIE VALIDADOR: " & varPub.Serie_Val1)
    End Sub

    ''' <summary>
    ''' Permite conocer la informacion de una operacion trunca por falla eléctrica.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Verificar()
        varPub.SegundosReceptor = 0 ' 16/mayo/2013

        ' Si no hay dep_pendiente salir
        If varPub.ID_DepositoP <= 0 Then Exit Sub

        'Este procedimiento se debe de realizar antes de iniciar la comunicacion con el validador
        'indica que usuario lo estaba realizando, la denominación y la moneda
        btn_Iniciar.Enabled = False
        btn_Cerrar.Enabled = False

        Dim billete As NCcash.NewMeiDevice.DatosBilleteEscorw = meicontrol1.BuscarBillete()
        If billete.Moneda Is Nothing Then
            btn_Iniciar.Enabled = True
            btn_Cerrar.Enabled = True
        Else
            If fn_Depositos_GuardarBilleteDesconexion(billete.Moneda.Trim, billete.Denominacion.Trim, lsv_Datos, varPub.Serie_Caset1, "CasetID") Then
                lbl_DepositoP.Visible = True

                If varPub.Activar_Val1 AndAlso varPub.Capacidad_Actual < varPub.Capacidad_Caset Then
                    Call Me.InicializarControl()
                    Me.meicontrol1.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val1, False, True)
                End If

                DepositoDesconexion = True
                Call Calcular_Total()
                Call Porcentaje_Avance()
            Else
                btn_Iniciar.Enabled = True
                btn_Cerrar.Enabled = True
            End If
        End If
    End Sub
#End Region
#Region "Eventos Privados de la segunda instancia del Validador"
    ''' <summary>
    ''' Iniciar el equipo CashFlow
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub InicializarControl2()
        'varpub.SegundosReceptor = 0'---

        'Quitar el contro a la forma, no es visible

        Me.Controls.Remove(Me.meicontrol2)

        'Crear el control
        Me.meicontrol2 = New NCcash.NewMeiDevice

        '***Definición de Eventos

        'Evento para Recepción de Billetes
        AddHandler meicontrol2.OnBilleteAceptado, AddressOf meicontrol_OnBilleteAceptado2
        'Evento indica Conexión Correcta
        AddHandler meicontrol2.OnConexionCompletada, AddressOf meicontrol_OnConexionCompletada2
        'Evento indica Conexión Fallida
        AddHandler meicontrol2.OnConexionFallida, AddressOf meicontrol_OnConexionFallida2
        'Evento indica los Diferentes Estados del Validador
        AddHandler meicontrol2.OnEstadosAceptador, AddressOf meicontrol_OnEstadosAceptador2
        'Evento que se lanza en caso de que ocurra algun error de caracter general
        AddHandler meicontrol2.OnError, AddressOf meicontrol_OnError2
        'Evento que indica cuando un billete es retirado de la boca del validador
        AddHandler meicontrol2.OnBilleteRetirado, AddressOf meicontrol_OnBilleteRetirado2




        'Agregar el control a la forma, no es visible
        Me.Controls.Add(Me.meicontrol2)

        varPub.SegundosReceptor = 0
    End Sub
    Private Sub AnularDenominacion(ByVal IdDeposito As Integer, ByVal Denominacion As String, ByVal NumVal As Integer, ByVal SerieVal As String, ByVal SerieCaset As String)

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing

        Try
            Cmd = Crear_ComandoSQL("[Depositos].[AnularDenominacion]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@IdDeposito", SqlDbType.Int, IdDeposito)
            Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Char, Denominacion)
            Crear_ParametroSQL(Cmd, "@UsuarioId", SqlDbType.Int, varPub.UsuarioClave)
            Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.Int, varPub.Cve_Sucursal)
            Crear_ParametroSQL(Cmd, "@Numero_Validador", SqlDbType.Int, NumVal)
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, SerieVal)
            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
            Ejecutar_NonQuerySQL(Cmd)

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 77, varPub.IdPantalla, ex.ToString())
        End Try
    End Sub

    ''' <summary>
    ''' Evento que muestra los diferentes estados del validador
    ''' </summary>
    ''' <param name="estadoMei"></param>
    ''' <remarks></remarks>

    Private Sub meicontrol_OnEstadosAceptador2(ByVal estadoMei As String)
        'fn_Log_Depositos("EstadoAceptador_mei_val2:" + estadoMei.ToString())
        EstadoMEI_V2 = estadoMei

        ''
        If estadoMei.ToUpper = "DESCONECTADO" AndAlso varPub.D_On = True AndAlso Not timer_ok Then
            'If estadoMei.ToUpper = "DESCONECTADO" Or estadoMei.ToUpper = "ATASCADO" Then
            'fn_Log_Depositos("Desconectado_mei_val2:" + estadoMei.ToString())
            'Call fn_EscribirLog(estadoMei, "YA ENTRE", Date.Now.ToLongTimeString())
            'JMCB 2020-07-20
            varPub.FlagImprimirTicket = 2

            'COMENTARIZADO POR BJSE 07/06/2021 CREACION DE TRIGGER PARA ENVIAR CORREO DIRECTAMENTE DESDE SQL.
            'EnviarCorreo("DEPOSITOS, ATASCO DETECTADO VALIDADOR No. 2.  ULTIMA DENOMINACION ACEPTADA: <strong>$" & DenominacionV2 & ".00</strong>", "ATASCO - " + varPub.Nombre_Sucursal)
            'sDescripcion = "DEPOSITOS, ATASCO DETECTADO VALIDADOR No. 2.  ULTIMA DENOMINACION ACEPTADA: <strong>$" & DenominacionV2 & ".00</strong>" + " ATASCO"

            finalizar_deposito(CierreDeposito.CERRADO_POR_VALIDADOR_REMOVIDO)

            Dim Persistente As New cls_VariablesPersistentes()

            'If estadoMei.ToUpper = "DESCONECTADO" Then
            varPub.Activar_Val2 = 0
            'End If

            Persistente.Persistir()
            Persistente.Cargar()
            If DenominacionV2 > 0 Then
                AnularDenominacion(varPub.ID_DepositoP, DenominacionV2, 2, varPub.Serie_Val2, varPub.Serie_Caset2)
                cls_CashFlow.fn_Depositos_imprimir(1, varPub.ID_DepositoP, 24)
                Dim frm As New frm_ImprimirAtasco()
                frm.ShowDialog()
            End If
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 16, 24, "DEPOSITOS, ID DEPOSITO: " & varPub.ID_DepositoP.ToString() & " POSIBLE ATASCO DETECTADO V2." & " ULTIMA DENOMINACION ACEPTADA: " & DenominacionV2)
            varPub.FlagImprimirTicket = 1
            varPub.ID_DepositoP = 0
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS, POSIBLE ATASCO DETECTADO V2.", " ULTIMA DENOMINACION ACEPTADA: " & DenominacionV2)
            varPub.D_On = False
            varPub.state = False
            Removido = True
            ''Call fn_EscribirLog(estadoMei, "YA SALI", Date.Now.ToLongTimeString())
            ' Me.Close()
        End If

        If estadoMei.ToUpper = "ATASCADO" Then
            lsv_Datos2.BackColor = Color.FromArgb(255, 153, 51)
        End If

        ''
        If estadoMei.ToUpper = "ACEPTANDO" Or estadoMei.ToUpper = "INGRESANDO" Then 'New
            varPub.SegundosReceptor = 0 '---

        End If

        'If varPub.Activar_Val1 AndAlso ((varPub.Cant_Validadores = 2 And EstadoMEI_V1 <> "Fallo_Conexion") And EstadoMEI_V1 <> "Iniciando") Then
        '    If EstadoMEI_V1 <> "Listo" OrElse EstadoMEI_V2 <> "Listo" Then
        '        btn_Finalizar.Enabled = False
        '    Else
        '        btn_Finalizar.Enabled = True
        '    End If
        'Else

        '    Select Case estadoMei.ToUpper
        '        Case "ACEPTANDO", "INGRESANDO", "ALMACENANDO", "RECHAZANDO"
        '            btn_Finalizar.Enabled = False
        '        Case "LISTO"
        '            'btn_Finalizar.Enabled = True
        '    End Select

        '    If prg_Caset2.Value = prg_Caset2.Maximum AndAlso estadoMei.ToUpper = "DESCONECTADO" Then
        '        btn_Finalizar.Enabled = True
        '    End If
        'End If


        If estadoMei.ToUpper = "DESCONECTADO" Then
            EstadoMEI_V2 = "DESCONECTADO"
            meicontrol2.DetenerAceptacion()
            lsv_Datos2.BackColor = Color.IndianRed
            varPub.SegundosReceptor = 0
            varPub.SegundosSesion = 0
            btn_Iniciar.Text = "Cajas"
            btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
            btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
            btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
            btn_Finalizar.Enabled = False
            btn_Cerrar.Enabled = True
            pnl_General.Enabled = True
            pct_cargando.Visible = False
            tmr_depositos.Enabled = False

        End If

        If SerieVal2Obtenido.Trim <> "" AndAlso (SerieVal2Obtenido <> varPub.Serie_Val2) Then
            EstadoMEI_V2 = "Fallo_Conexion"
        End If

        'If EstadoMEI_V1 = "Listo" Or EstadoMEI_V2 = "Listo" Then
        '    tmr_depositos.Enabled = True
        'End If
        'If estadoMei.ToUpper = "ATASCADO" Then
        '    btn_Finalizar.Enabled = True
        'End If

    End Sub

    ''' <summary>
    ''' Evento que indica que no se efectuó la conexión
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    Private Sub meicontrol_OnConexionFallida2(ByVal mensajeError As String)
        'fn_Log_Depositos("ConexionFallida_mei_val2:" + mensajeError.ToString())
        Dim Persistente As New cls_VariablesPersistentes()
        '----- IF POR SI SON 2 VALIDADORES ------
        If varPub.Cant_Validadores = 2 And varPub.Activar_Val1 Then

            tmr_depositos.Enabled = False
            Me.meicontrol2.DetenerAceptacion()
            lsv_Datos2.BackColor = Color.IndianRed
            EstadoMEI_V2 = "Fallo_Conexion"
            Call fn_Depositos_Detalle(mensajeError & " CON NUMERO DE SERIE: " & varPub.Serie_Val2)
            Call fn_MsgBox(mensajeError & " (Val: 2), Con Número de serie: " & varPub.Serie_Val2, MessageBoxIcon.Exclamation, True, 2)

            varPub.SegundosSesion = 0
            'si las 2 variables son vacias , entonces ninguna se conecto
            If EstadoMEI_V1 = "Fallo_Conexion" AndAlso EstadoMEI_V2 = "Fallo_Conexion" Then
                ' jmcb
                'EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")

                btn_Iniciar.Enabled = True
                btn_Finalizar.Enabled = False

                btn_Cerrar.Enabled = True
                pnl_General.Enabled = True
                pct_cargando.Visible = False
                btn_Iniciar.Focus()
                '----------------------
                If varPub.ID_DepositoP > 0 Then

                    If varPub.ManejaConexionWebService = 0 Then
                        Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
                    End If

                    If varPub.ManejaConexionWebService = 1 Then
                        RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
                    End If

                End If
                varPub.SegundosSesion = 0
                varPub.SegundosReceptor = 0
                lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

                btn_Iniciar.Text = "Cajas"
                btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
                btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
                btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
            End If

            If EstadoMEI_V1 <> "Fallo_Conexion" Then
                tmr_depositos.Enabled = True
            End If
            'Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)

            varPub.Activar_Val2 = 0
            Persistente.Persistir()
            Persistente.Cargar()

            Exit Sub 'se sale despues de validar..
        End If

        '----- ESTE IF SOLO CUANDO ES  1 VALIDADOR --------
        tmr_depositos.Enabled = False
        Me.meicontrol2.DetenerAceptacion()
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        Call fn_MsgBox(mensajeError & " (Val: 2), Con Número de serie: " & varPub.Serie_Val2, MessageBoxIcon.Exclamation, True, 2)

        lsv_Datos2.BackColor = Color.IndianRed
        btn_Iniciar.Enabled = True
        btn_Finalizar.Enabled = False
        btn_Cerrar.Enabled = True
        pnl_General.Enabled = True
        pct_cargando.Visible = False
        btn_Iniciar.Focus()
        lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

        Call fn_Depositos_Detalle(mensajeError & " CON NUMERO DE SERIE: " & varPub.Serie_Val2)
        If varPub.ID_DepositoP > 0 Then
            If varPub.ManejaConexionWebService = 0 Then
                'JMCB
                'EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")
                Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
                varPub.Activar_Val2 = 0
                Persistente.Persistir()
                Persistente.Cargar()
            End If

            If varPub.ManejaConexionWebService = 1 Then
                'JMCB
                EnviarCorreo("CERRADO_POR_CONEXION_FALLIDA", "CONEXION FALLIDA")
                RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CONEXION_FALLIDA)
            End If
        End If
        btn_Iniciar.Text = "Cajas"
        btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
        btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
        btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
        'btn_Iniciar.PerformClick()
        ''

    End Sub

    ''' <summary>
    ''' Evento que indica que la conexión fue correcta
    ''' </summary>
    ''' <param name="numeroSerie"></param>
    ''' <remarks></remarks>
    Private Sub meicontrol_OnConexionCompletada2(ByVal numeroSerie As String, ByVal PuertoRegresado As String)
        'fn_Log_Depositos("ConexionCompleta_mei_val2:")
        varPub.SegundosReceptor = 0 '17/12/2013
        SerieVal2Obtenido = numeroSerie
        Removido = False
        If numeroSerie <> varPub.Serie_Val2 Then
            Me.meicontrol2.DetenerAceptacion()
            Call fn_MsgBox("El número de serie del validador2 no coincide con el que se tiene registrado, consulte al Administrador.", MessageBoxIcon.Error)
            Exit Sub
        End If
        If (varPub.ID_DepositoP > 0) Then
            lsv_Datos2.BackColor = Color.FromArgb(53, 170, 71) 'pone lsv2 en verde porke esta conectado.
            EstadoMEI_V2 = "Listo"
        End If

        'If varPub.Activar_Val1 AndAlso (varPub.Cant_Validadores = 2 AndAlso EstadoMEI_V1 = "Iniciando") Then
        '    Exit Sub
        'Else
        If (varPub.ID_DepositoP > 0) Then
            pnl_General.Enabled = True
            btn_Iniciar.Enabled = False
            btn_Finalizar.Enabled = True
            btn_Cerrar.Enabled = False

            pct_cargando.Visible = False
            btn_Finalizar.Focus()

            varPub.state = True
        Else
            varPub.state = True
            meicontrol2.DetenerAceptacion()
        End If

        ' End If
        If varPub.ManejaConexionWebService = 1 Then
            If varPub.CajeroStatus = "CF" Then varPub.CajeroStatus = "D"
        End If
    End Sub

    ''' <summary>
    ''' Evento que se lanza al guardar un billete en el cassete
    ''' </summary>
    ''' <param name="billeteAceptado"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnBilleteAceptado2(ByVal billeteAceptado As NCcash.NewMeiDevice.DatosBilleteAceptado)
        'fn_Log_Depositos("BilleteAceptado_mei_val2:" + billeteAceptado.Denominacion.ToString)
        varPub.SegundosReceptor = 0 '-----

        If billeteAceptado.Moneda.Trim = "MXN" Then
            billeteAceptado.Moneda = "MXP"
        Else
            billeteAceptado.Moneda = "MXP"
        End If


        If fn_Depositos_GuardarBillete(billeteAceptado.Moneda.Trim, CInt(billeteAceptado.Denominacion), varPub.Serie_Val2, varPub.Serie_Caset2, "Caset2ID", "2") Then
            varPub.D_On = True
            DenominacionV2 = billeteAceptado.Denominacion.ToString()
            Dim item As ListViewItem
            item = New ListViewItem(billeteAceptado.Moneda.Trim)

            item.SubItems.Add(billeteAceptado.Denominacion.Trim)
            item.SubItems.Add(varPub.Serie_Val2)
            lsv_Datos2.Items.Add(item)

            Call Calcular_Total2()
            Call Porcentaje_Avance2()
            'lsv_Datos2.Items.Item(lsv_Datos2.Items.Count - 1).EnsureVisible()
        End If
    End Sub

    Private Sub Calcular_Total2()
        lbl_Total2.Text = "TotalV2 $ 0.00 MXN"
        Dim ImportePesos As Integer = 0
        Dim ImporteDolar As Integer = 0
        Contador2 = 0
        ContadorDolar2 = 0 '23/12/2013

        For Each Item As ListViewItem In lsv_Datos2.Items
            If Item.Text.Trim = "MXP" OrElse Item.Text.Trim = "MXN" Then
                ImportePesos += CInt(Item.SubItems(1).Text)
                MontoDepositadoV2 = ImportePesos
                Contador2 += 1
            ElseIf Item.Text.Trim = "USD" Then
                ImporteDolar += CInt(Item.SubItems(1).Text)
                ContadorDolar2 += 1
            End If
        Next
        lsv_Datos2.Columns(1).TextAlign = HorizontalAlignment.Right
        lbl_Total2.Text = ImportePesos & "/" & ImporteDolar

        PesoDolar2(0) = ImportePesos
        PesoDolar2(1) = ImporteDolar

        If CInt(PesoDolar2(1)) > 0 Then
            lbl_Total2.Text = "TotalV2: " & PesoDolar2(0) & "MXN" & "(" & Contador2 & "Pza)" & " / " & PesoDolar2(1) & "USD" & "(" & ContadorDolar2 & "Pza)"
        Else
            lbl_Total2.Text = "TotalV2: " & PesoDolar2(0) & "MXN" & " (" & Contador2 & " Piezas)"
            If lbl_Total2.Text = "0/0" Then lbl_Total2.Text = "TotalV2: 0 MXN, 0 USD"
        End If
    End Sub

    Private Function Porcentaje_Avance2() As Boolean
        prg_Caset2.Value = varPub.Capacidad_Actual2

        If prg_Caset2.Value < prg_Caset2.Maximum Then
            Dim Calculo_Llenado As Integer = CInt((varPub.Capacidad_Actual2 / varPub.Capacidad_Caset2) * 100)
            If Calculo_Llenado >= varPub.Porcentaje_Alerta2 Then
                lbl_Alerta.Visible = True
                Alerta(1) = "    Caset2 Llenandose"
                lbl_Alerta.Text = Alerta(0) & Alerta(1)
            End If

            Return False '-->>
        Else
            Me.meicontrol2.DetenerAceptacion() '-->

            Alerta(1) = "    Caset2 Lleno"
            lbl_Alerta.Text = Alerta(0) & Alerta(1)

            Call fn_Depositos_Detalle("CASETERO 2 LLENO.")
            lbl_Alerta.Visible = True

            Call fn_MsgBox("El caset2 se ha llenado, Favor de comunicarse con la empresa de traslado de valores", MessageBoxIcon.Exclamation, True, 2)
            EstadoMEI_V2 = "Fallo_Conexion" '--> 29enero2014

            If varPub.Cant_Validadores = 1 Then
                If varPub.ManejaConexionWebService = 0 Then
                    Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If

                If varPub.ManejaConexionWebService = 1 Then ' Se cumplirá cuando se hace depositos por web service
                    RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If

            ElseIf varPub.Cant_Validadores = 2 AndAlso prg_Caset1.Value = prg_Caset1.Maximum Then
                If varPub.ManejaConexionWebService = 0 Then
                    Call FinalizarDeposito(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If

                If varPub.ManejaConexionWebService = 1 Then ' Se cumplirá cuando se hace depositos por web service
                    RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_CASETERO_LLENO)
                End If
            End If
            Return True '-->>
        End If
    End Function

    ''' <summary>
    ''' Evento que indica el error que ha sucedido
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnError2(ByVal mensajeError As String)
        'fn_Log_Depositos("onError_mei_val2:" + mensajeError.ToString())
        Call fn_Depositos_Detalle(mensajeError.ToUpper)
    End Sub

    ''' <summary>
    ''' Evento que indica cuando un billete fue retirado de la boca del validador
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnBilleteRetirado2()
        'fn_Log_Depositos("BilleteRetirado_mei_val2:")
        varPub.SegundosReceptor = 0
        Call fn_Depositos_Detalle("BILLETE RETIRADO DEL VALIDADOR 2, SERIE VALIDADOR: " & varPub.Serie_Val2)
    End Sub

    ''' <summary>
    ''' Permite conocer la informacion de una operacion trunca por falla eléctrica.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Verificar2()
        varPub.SegundosReceptor = 0

        If varPub.ID_DepositoP <= 0 Then Exit Sub

        btn_Iniciar.Enabled = False
        btn_Cerrar.Enabled = False

        Dim billete As NCcash.NewMeiDevice.DatosBilleteEscorw = meicontrol2.BuscarBillete()

        If fn_Depositos_GuardarBilleteDesconexion(billete.Moneda.Trim, billete.Denominacion.Trim, lsv_Datos2, varPub.Serie_Caset2, "Caset2ID") Then
            lbl_DepositoP.Visible = True

            'si esta activo val2 y no esta lleno Entonces Inciar Control del Validador
            If varPub.Activar_Val2 AndAlso varPub.Capacidad_Actual2 < varPub.Capacidad_Caset2 Then
                Call Me.InicializarControl2()
                Me.meicontrol2.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val2, False, True)
            End If
            DepositoDesconexion = True '23/12/2013
            Call Calcular_Total2()
            Call Porcentaje_Avance2()
        Else
            btn_Iniciar.Enabled = True
            btn_Cerrar.Enabled = True
        End If
    End Sub

#End Region

#Region "Procedimientos Privados"
    Private Sub Iniciar(Id_caja As Integer, Clave_Caja As String)
        'Método que inicia la conexión con el validador
        'param 1 idusuario. Es usado para respaldo en caso de operaciones truncas debido 
        'a fallas de corriente 
        'param 2 puerto. Si ya se conoce el puerto por el cual esta conecatdo el validador
        ' se asigna en este parametro.
        'param 3 buscarpuertos: realiza una busqueda del validador en los puertos disponibles 
        'en caso de que no se conozca el puerto o en caso de que el puerto especificado ya no este disponible
        'param 4 iniciar al conectar, inicia la aceptacion de billetes de manera automatica al conectarse 
        'correctamente. si no se desea iniciar automaticamente, se debe usar el metodo IniciarAceptacion()


        '------------BORARRA TEMPORALES QUE PUEDEN ESTAR DAÑADOS Y PRODUZCA ERROR AL DEPOSITAR 29/05/2019-----------

        If My.Computer.FileSystem.FileExists("C:\Users\pc\AppData\Local\Modulo_CashFlowV2") Then

            Dim miFolder = New DirectoryInfo("C:\Users\pc\AppData\Local\Modulo_CashFlowV2")
            Dim misTemporales() = miFolder.GetDirectories

            For i = 0 To misTemporales.Length - 1
                My.Computer.FileSystem.DeleteDirectory("C:\Users\pc\AppData\Local\Modulo_CashFlowV2\" & misTemporales(i).ToString, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Next
        End If

        pnl_General.Enabled = False
        pct_cargando.Visible = True
        tmr_depositos.Enabled = True '-27/06 Despues de validar llenado kst

        'Verifik si esta lleno caset tonces no hace nada, se sale
        Dim Caset1LLeno As Boolean = Porcentaje_Avance()
        Dim Caset2LLeno As Boolean
        If varPub.Cant_Validadores = 2 Then Caset2LLeno = Porcentaje_Avance2()

        '---------17-dic-2013-----------
        Dim IMPORTETOTAL_VAL1 As Decimal = 0D
        Dim IMPORTETOTAL_VAL2 As Decimal = 0D
        IMPORTETOTAL_VAL1 = (PesoDolar1(1) * varPub.TipoCambio) + PesoDolar1(0)
        IMPORTETOTAL_VAL2 = (PesoDolar2(1) * varPub.TipoCambio) + PesoDolar2(0)
        '------------------------------

        Select Case varPub.Cant_Validadores
            Case 1
                If Caset1LLeno OrElse varPub.Activar_Val1 = False Then
                    pnl_General.Enabled = True
                    pct_cargando.Visible = False
                    tmr_depositos.Enabled = False

                    If varPub.Activar_Val1 = False Then
                        Call fn_MsgBox("El Administrador del sistema ha desactivado el Validador1", MessageBoxIcon.Exclamation, True, 1)
                    End If
                    Exit Sub
                End If

                '1.-Inicializa el validadora
                Call Me.InicializarControl()

                ' BillAcceptor.Close()


                varPub.SegundosReceptor = 0
                '
                '2.-Abre un Nuevo Deposito
                Call fn_Depositos_Open(1, "S", Id_caja, Clave_Caja)

                If varPub.ID_DepositoP > 0 Then
                    ' BillAcceptor.BNFStatus("COM" & varPub.Puerto_Val1, PowerUp.A)
                    'MessageBox.Show(BillAcceptor.BNFStatus.ToString)
                    Me.meicontrol1.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val1, False, True)
                    'BillAcceptor.Open("COM" & varPub.Puerto_Val1, PowerUp.A)
                    lsv_Datos.Items.Clear()
                Else
                    'en caso de que hubiera un deposito pendiente cerrarlo
                    Call fn_Depositos_Close((IMPORTETOTAL_VAL1 + IMPORTETOTAL_VAL2), PesoDolar1(0) + PesoDolar2(0), PesoDolar1(1) + PesoDolar2(1), 24)

                    ' btn_Iniciar.Enabled = True
                    btn_Finalizar.Enabled = False
                    btn_Cerrar.Enabled = True
                    pnl_General.Enabled = True
                    pct_cargando.Visible = False
                    btn_Iniciar.Focus()
                End If

                varPub.SegundosReceptor = 0
                Call Calcular_Total()
                    '--------------------

            Case 2
                If (Caset1LLeno OrElse varPub.Activar_Val1 = False) AndAlso (Caset2LLeno OrElse varPub.Activar_Val2 = False) Then
                    pnl_General.Enabled = True
                    pct_cargando.Visible = False
                    tmr_depositos.Enabled = False

                    If varPub.Activar_Val1 = False And varPub.Activar_Val2 = False Then
                        Call fn_MsgBox("El Administrador del sistema ha desactivado el Validador1 y Validador2", MessageBoxIcon.Exclamation, True, 2)
                    End If
                    Exit Sub
                End If

                '1.- Iniciar Control 1 o 2 o Ambas.
                If Caset1LLeno = False AndAlso varPub.Activar_Val1 Then
                    Call Me.InicializarControl()
                End If
                If Caset2LLeno = False AndAlso varPub.Activar_Val2 Then
                    Call Me.InicializarControl2()

                End If

                '2.- Abrir Nuevo Deposito

                Call fn_Depositos_Open(1, "S", Id_caja, Clave_Caja) 'Se abre 1Deposito para los 2 vAlidadores
                If varPub.ID_DepositoP > 0 Then
                    If Caset1LLeno = False AndAlso varPub.Activar_Val1 Then
                        Me.meicontrol1.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val1, False, True)
                        lsv_Datos.Items.Clear()
                    End If

                    If Caset2LLeno = False AndAlso varPub.Activar_Val2 Then
                        Me.meicontrol2.IniciarConexion(varPub.UsuarioClave, "COM" & varPub.Puerto_Val2, False, True)

                        lsv_Datos2.Items.Clear()
                    End If
                Else
                    Call fn_Depositos_Close((IMPORTETOTAL_VAL1 + IMPORTETOTAL_VAL2), PesoDolar1(0) + PesoDolar2(0), PesoDolar1(1) + PesoDolar2(1), 24)

                    btn_Iniciar.Enabled = True
                    btn_Finalizar.Enabled = False
                    btn_Cerrar.Enabled = True
                    pnl_General.Enabled = True
                    pct_cargando.Visible = False
                    tmr_depositos.Enabled = False
                    lbl_tmrCerrar.Text = varPub.TimeOut_Receptor
                    btn_Iniciar.Focus()
                End If

                varPub.SegundosReceptor = 0
                Call Calcular_Total()
                Call Calcular_Total2()




        End Select

    End Sub

    Private Sub CambiarTamanodelosControles()
        Call cls_FuncionesPublicas.fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub FinalizarDeposito(ByVal tipoCierre As CierreDeposito)

        Dim IMPORTETOTAL_VAL1 As Decimal = 0D
        Dim IMPORTETOTAL_VAL2 As Decimal = 0D
        Dim DesactivadoVal1 As Boolean = False
        Dim DesactivadoVal2 As Boolean = False

        tmr_depositos.Enabled = False
        pnl_General.Enabled = False

        varPub.SegundosReceptor = 0
        varPub.SegundosSesion = 0
        Contador = 0
        Contador2 = 0
        ContadorDolar = 0
        ContadorDolar2 = 0
        DepositoDesconexion = False
        pct_cargando.Visible = False
        lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor

        'Hacer el tipo de cambio de dolar a peso + totalImportePesos 
        IMPORTETOTAL_VAL1 = (PesoDolar1(1) * varPub.TipoCambio) + PesoDolar1(0)
        IMPORTETOTAL_VAL2 = (PesoDolar2(1) * varPub.TipoCambio) + PesoDolar2(0)

        '---« Resetea controles »--31/05/2014-----
        EstadoMEI_V2 = "Desconectado" 'Para que BotonFinalizar se deshabilite
        EstadoMEI_V1 = "Desconectado"
        Call fn_Depositos_Detalle("PROCESANDO DEPOSITO A FINALIZAR, " & tipoCierre.ToString)

        Try
            'si esta Activo Val1 lo detiene
            If varPub.Activar_Val1 Then
                Me.meicontrol1.DetenerAceptacion() '---------{13enero2014}>
                'DesactivadoVal1 = True

                Call fn_Depositos_Detalle("DESACTIVANDO VALIDADOR 1.")
                lsv_Datos.BackColor = Color.IndianRed
                lsv_Datos.Items.Clear()
                lbl_Total1.Text = " Total $ 0.00"
            Else
                lsv_Datos.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
            End If

            '---por si son 2 validaores activos Detiene el segundo----
            If varPub.Cant_Validadores = 2 AndAlso varPub.Activar_Val2 Then
                Me.meicontrol2.DetenerAceptacion()
                'DesactivadoVal2 = True
                Call fn_Depositos_Detalle("DESACTIVANDO VALIDADOR 2.")
                lsv_Datos2.Items.Clear()
                lsv_Datos2.BackColor = Color.IndianRed
                lbl_Total2.Text = " Total $ 0.00"
            Else
                lsv_Datos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
            End If

            btn_Iniciar.Enabled = True
            btn_Finalizar.Enabled = False
            btn_Cerrar.Enabled = True
            lbl_DepositoP.Visible = False

            '--« Segundo cierra el deposito de los validadores »---- 
            If fn_Depositos_Close((IMPORTETOTAL_VAL1 + IMPORTETOTAL_VAL2), PesoDolar1(0) + PesoDolar2(0), PesoDolar1(1) + PesoDolar2(1), 24) Then

                Call fn_MsgBox("El Depósito se ha cerrado correctamente.", MessageBoxIcon.Information, True, 3)

            Else
                Me.Close() 'cerrar para que busque depositos pendientes
            End If

        Catch ex As Exception
            Call fn_Depositos_Detalle("ERROR AL CERRAR DEPOSITO, ID: " & varPub.ID_DepositoP & ", " & ex.Message.ToUpper)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 15, varPub.IdPantalla, "ERROR AL CERRAR DEPOSITO, ID: " & varPub.ID_DepositoP & ", " & ex.Message.ToUpper)
            Call fn_MsgBox("Ocurrió el siguiente error " & ex.Message, MessageBoxIcon.Error, True, 3)
            Me.Close()
        End Try

        varPub.Detalle_Anterior = ""
        pnl_General.Enabled = True
        btn_Cerrar.Focus()
    End Sub
#End Region

#Region "Manejadores de Eventos"

    Private Sub frm_DepositoXvalidador_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        tmr_depositos.Enabled = False
        Dim Persistente As New cls_VariablesPersistentes
        Persistente.Persistir()
        Persistente.Cargar()

        If varPub.Activar_Val1 Then
            Me.meicontrol1.DetenerAceptacion()
            Me.meicontrol1.Dispose()
        End If

        If varPub.Cant_Validadores = 2 AndAlso varPub.Activar_Val2 Then
            Me.meicontrol2.DetenerAceptacion()
            Me.meicontrol2.Dispose()
        End If
    End Sub

    Private Sub frm_DepositoXvalidador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '----validar si quedaron depositos en 'A' y ponerlos en F    
        pnl_General.Enabled = False
        Dim AnchoColumna As Integer = 0
        varPub.IdPantalla = 24

        If varPub.ManejaConexionWebService = 1 Then
            If varPub.EsDepositoNormal Then
                fn_MsgBox("Imposible realizar depósitos ya que el Cajero está configurado con depósitos automáticos, para continuar por favor configuralo con depósitos normales.", MessageBoxIcon.Information, True, 5)
                Me.Close()
                Exit Sub
            End If
        End If

        If varPub.Cant_Validadores = 1 Then
            tlp_Lista.ColumnCount = 1
            tlp_Lista.Controls.Remove(lsv_Datos2)
            tlp_Lista.Controls.Remove(prg_Caset2)
            tlp_Lista.Controls.Remove(lbl_Total2)

            AnchoColumna = (lsv_Datos.Width / 4)
            lsv_Datos.Columns.Add("Moneda", AnchoColumna)
            lsv_Datos.Columns.Add("Denominacion", AnchoColumna + 10)
            lsv_Datos.Columns.Add("Serie", 0)
        Else
            tlp_Lista.ColumnCount = 2
            AnchoColumna = (lsv_Datos.Width / 4)
            lsv_Datos.Columns.Add("Moneda", AnchoColumna)
            lsv_Datos.Columns.Add("Denominacion", AnchoColumna + 10)
            lsv_Datos.Columns.Add("Serie", 0)

            lsv_Datos2.Columns.Add("Moneda", AnchoColumna)
            lsv_Datos2.Columns.Add("Denominacion", AnchoColumna * 2)
            lsv_Datos2.Columns.Add("Serie", 0)

            tlp_Lista.Controls.Add(lsv_Datos2, 1, 0)
            tlp_Lista.Controls.Add(prg_Caset2, 1, 1)
            tlp_Lista.Controls.Add(lbl_Total2, 1, 2)
        End If

        prg_Caset1.Maximum = varPub.Capacidad_Caset '<-Carga Maximum alProgresbarr

        If varPub.Activar_Val1 Then

            Call Verificar()
            Call fn_DepositosPendientes_Close()

            Porcentaje_Avance()
        End If

        'Try

        '*****Verifica Validador 2
        If varPub.Cant_Validadores = 2 Then
            prg_Caset2.Maximum = varPub.Capacidad_Caset2 '>--<

            If varPub.Activar_Val2 Then Call Verificar2()
            If Porcentaje_Avance2() Then Exit Sub
        End If

        '**********************
        'Catch ex As Exception
        '    fn_MsgBox("Desactivar Validador 2 para continuar", MessageBoxIcon.Information, True, 5)
        'End Try
        '*******Verificar Validador 1
        pnl_General.Enabled = True
        pct_cargando.Visible = False

        btn_Finalizar.Enabled = DepositoDesconexion '--nuevo
        tmr_depositos.Enabled = DepositoDesconexion

        lbl_tmrCerrar.Text = "TE " & varPub.TimeOut_Receptor
        varPub.SegundosReceptor = 0

        If varPub.ManejaConexionWebService = 0 Then

            If varPub.Cantidad_Cajas = 1 Then
                btn_Iniciar.Enabled = False
                btn_Iniciar.Text = "Iniciar"
                btn_Iniciar.Font = New Font("Arial", 12, FontStyle.Bold)

                Dim dt_Cajas As DataTable = fn_CajasLocal_Consulta2()

                If dt_Cajas Is Nothing Then
                    fn_MsgBox("Ocurrió un error al consultar Cajas.", MessageBoxIcon.Error, True, 2)
                End If

                Id_CajaLocal = dt_Cajas.Rows(0)("Id_Caja")
                Clave_CajaLocal = dt_Cajas.Rows(0)("Clave_Caja")

                Call IniciarValidador(Id_CajaLocal, Clave_CajaLocal)
            End If

            If varPub.Cantidad_Cajas = 0 Then
                btn_Iniciar.Enabled = False
                fn_MsgBox("Para depositar debe  haber por lo menos una Caja.", MessageBoxIcon.Information, True, 3)
                Exit Sub
            End If

            If varPub.Cantidad_Cajas > 1 Then
                btn_Iniciar.Enabled = True
                btn_Iniciar.Text = "Cajas"
            End If
        End If
        'JESUS ORTEGA
        '24-02-2023
        'YA NO SE MANEJAN DEPOSITOS POR WEB SERVICE

        'If varPub.ManejaConexionWebService = 1 Then
        '    If varPub.ManejaCorte = 1 Then

        '        If varPub.CorteActual = 0 Then
        '            TotalDepositado = 0
        '            fn_TransaccionActualiza_TotalDepositado(varPub.Id_Transaccion, TotalDepositado, CierreDeposito.CERRADO_POR_CAJERO.ToString)
        '            varPub.DepositoFinalizado = True '  Finaliza la transaccion actual
        '            cls_CashFlow.fn_LogTransaccion_Guardar("FIN DEPOSITO- " & CierreDeposito.CERRADO_POR_CAJERO.ToString & " TOTAL DEPOSITO " & TotalDepositado & " El CORTE NO ESTA ABIERTO", varPub.UsuarioClave, Id_Caja, varPub.Folio)
        '            Me.Close()
        '            Exit Sub
        '        End If
        '    End If

        '    'Dim dt_Corte As DataTable = fn_VerificaCorte()

        '    'If dt_Corte Is Nothing Then
        '    '    fn_MsgBox("Ocurrió un error al verificar el corte actual.", MessageBoxIcon.Error, True, 2)
        '    'End If

        '    'If dt_Corte.Rows.Count > 0 Then
        '    '    varPub.CorteActual = CInt(dt_Corte.Rows(0).Item("Corte"))
        '    '    Persistente.Persistir()
        '    '    Persistente.Cargar()
        '    'ElseIf dt_Corte.Rows.Count = 0 Then

        '    '    Me.Close()
        '    '    Exit Sub
        '    'End If

        '    Call IniciarValidador(Id_Caja, Clave_Caja)
        'End If

    End Sub

    Public Sub IniciarValidador(Id_Cajas As Integer, Clave_Caja As String)
        varPub.SegundosSesion = 0
        'sub iniciar inicia los 2 instancias si son 2VAL
        If varPub.ManejaCorte = 1 And varPub.CorteActual = 0 Then
            Call fn_MsgBox("Imposible realizar depósitos ya que no hay Corte abierto .", MessageBoxIcon.Information)
            Exit Sub

        End If

        Call Iniciar(Id_Cajas, Clave_Caja)

        varPub.SegundosReceptor = 0
    End Sub

    'click en la caja
    Private Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        varPub.SegundosSesion = 0

        'MessageBox.Show(EstadoMEI_V1.ToUpper)
        'If Not varPub.state And Removido Then
        '    Call fn_MsgBox("Imposible realizar depósitos ya que no hay validador colocado.", MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        If varPub.ManejaCorte = 1 And varPub.CorteActual = 0 Then
            Call fn_MsgBox("Imposible realizar depósitos ya que no hay Corte abierto .", MessageBoxIcon.Information)
            Exit Sub
        End If
        timer_ok = False
        If varPub.Cantidad_Cajas = 1 Then
            If varPub.ValidarFolio Then

                If Not CajaCadena(varPub.Id_caja) Then
                    Call fn_MsgBox("La Caja no tiene una Cadena de Conexión configurada .", MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If
            Call Iniciar(Id_CajaLocal, Clave_CajaLocal)

        Else
            Dim frm As New frm_Lista_Cajas
            frm.Location = New Point(btn_Iniciar.Location.X, btn_Iniciar.Location.Y + btn_Iniciar.Height + 10)
            frm.ShowDialog()
            varPub.SegundosReceptor = 0

            If frm.Cerrar Then Exit Sub

            If varPub.ValidarFolio Then
                If Not CajaCadena(varPub.Id_caja) Then
                    Call fn_MsgBox("La Caja no tiene una Cadena de Conexión configurada .", MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If

            btn_Iniciar.TextImageRelation = TextImageRelation.ImageAboveText
            btn_Iniciar.TextAlign = ContentAlignment.BottomCenter
            btn_Iniciar.Font = New Font("Arial", 9, FontStyle.Bold)
            btn_Iniciar.Text = "Cajas [" & frm.Clave_Caja & "]"


            If varPub.ManejaFolioManual Then
                Dim frm_Importe As New frm_AgregarImporte
                frm_Importe.ShowDialog()

                If frm_Importe.Resultado = False Then
                    frm_Importe.Dispose()
                    Exit Sub
                End If

                Folio_Registrar = CDec(frm_Importe.tbx_Folio.Text)
                Importe_Registrar = frm_Importe.tbx_Importe.Text
                frm_Importe.Dispose()

            End If
            Call Iniciar(frm.Id_Caja, frm.Clave_Caja)
            frm.Dispose()
            varPub.SegundosReceptor = 0
        End If
    End Sub
    Public Function CajaCadena(Id_caja As String) As Boolean
        Try
            For Each dr As DataRow In varPub.Dt_Cajascnx.Rows
                If (dr("Id_Caja") = Id_caja) Then
                    varPub.CajasCnx = "Data Source = " & dr("DataSource").ToString() & ";" & "Initial Catalog = " & dr("InitialCatalog").ToString() & ";" & "User Id = " & dr("Userr").ToString() & ";" & "Password = " & dr("Password").ToString()
                    Return True
                End If
            Next
        Catch ex As Exception
            fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 14, 24, "Error al consultar la conexión de la caja.")
            fn_MsgBox("Error al consultar la conexión de la caja.", MessageBoxIcon.Information, True)
            Return False
        End Try

        Return False
    End Function

    Private Sub btn_Finalizar_Click(sender As Object, e As EventArgs) Handles btn_Finalizar.Click
        finalizar_deposito(CierreDeposito.CERRADO_POR_USUARIO)
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        'If Removido Then Exit Sub
        varPub.SegundosReceptor = 0
        varPub.SegundosSesion = 0
        tmr_depositos.Enabled = False
        Me.Close()
        lsv_Datos.Columns.Clear()
        lsv_Datos2.Columns.Clear()
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        pnl_General.Focus()
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub pnl_General_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_General.MouseDown
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub lbl_DepositoP_Click(sender As Object, e As EventArgs) Handles lbl_DepositoP.Click
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub lbl_tmrCerrar_Click(sender As Object, e As EventArgs) Handles lbl_tmrCerrar.Click
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub lsv_Datos_Click(sender As Object, e As EventArgs) Handles lsv_Datos.Click, lsv_Datos2.Click
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub lsv_Datos_MouseClick(sender As Object, e As MouseEventArgs) Handles lsv_Datos2.MouseClick
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub lsv_Datos_KeyDown(sender As Object, e As KeyEventArgs) Handles lsv_Datos2.KeyDown
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub lsv_Datos_KeyUp(sender As Object, e As KeyEventArgs) Handles lsv_Datos2.KeyUp
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub prg_Caset1_Click(sender As Object, e As EventArgs) Handles prg_Caset1.Click
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
    End Sub

    Private Sub prg_Caset2_Click(sender As Object, e As EventArgs) Handles prg_Caset2.Click
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
    End Sub
#End Region

#Region "Eventos que gestionan Finalizar y Cancelar depósitos por WebService"
    Private Sub DepositoXWebS_DepositoFinalizar(tipoCierre As CierreDeposito) Handles Me.DepositoFinalizar_PorWebS

        Call FinalizarDeposito(tipoCierre)
        btn_Iniciar.Text = "Cajas"
        btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
        btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
        btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)

        TotalDepositado = MontoDepositadoV1 + MontoDepositadoV2

        If TotalDepositado = Nothing Then TotalDepositado = 0

        Dim filasAfectadas As Integer = fn_TransaccionActualiza_TotalDepositado(varPub.Id_Transaccion, TotalDepositado, tipoCierre.ToString)

        cls_CashFlow.fn_LogTransaccion_Guardar("FIN DEPOSITO- " & tipoCierre.ToString & " TOTAL DEPOSITO " & TotalDepositado & "", varPub.UsuarioClave, Id_Caja, varPub.Folio)

        If filasAfectadas = Nothing Then
            'Ocurrió un error al actualizar la tabla transaccion Montodepositado
        End If
        If filasAfectadas > 0 Then
            'Montodepositado actualizado correctamente de la tabla Transaccion
            varPub.DepositoFinalizado = True
        End If

        TotalDepositado = 0
        MontoDepositadoV1 = 0
        MontoDepositadoV2 = 0

        If StatusCajeroDic.ContainsKey("K_DF") Then
            StatusCajeroDic.Clear()
        End If


        Me.Close()
    End Sub

    Private Sub tmr_depositos_Tick(sender As Object, e As EventArgs) Handles tmr_depositos.Tick
        'comprueba si se atasco billete en validador 1
        'DeviceJammed True -No hay billete atascado
        'DeviceJammed False -billete atascado
        If meicontrol1.BillAcceptor.DeviceJammed Then
            lsv_Datos.BackColor = Color.Green
        Else
            lsv_Datos.BackColor = Color.Orange
        End If
        'comprueba el cartucho del validador 1  
        'CashBoxAttached True -No hay cartucho atascado
        'CashBoxAttached False -cartucho atascado
        If meicontrol1.BillAcceptor.CashBoxAttached Then
            lsv_Datos.BackColor = Color.Green
        Else
            lsv_Datos.BackColor = Color.Yellow
        End If

        ''comprueba si se atasco billete en validador 2
        ''DeviceJammed True -No hay billete atascado
        ''DeviceJammed False -billete atascado
        'If meicontrol2.BillAcceptor.DeviceJammed Then
        '    lsv_Datos.BackColor = Color.Green
        'Else
        '    lsv_Datos.BackColor = Color.Orange
        'End If
        ''comprueba el cartucho del validador 2
        ''CashBoxAttached True -No hay cartucho atascado
        ''CashBoxAttached False -cartucho atascado
        'If meicontrol1.BillAcceptor.CashBoxAttached Then
        '    lsv_Datos.BackColor = Color.Green
        'Else
        '    lsv_Datos.BackColor = Color.Yellow
        'End If

        varPub.SegundosSesion = 0

        If varPub.Activar_Val1 Then
            If (EstadoMEI_V1 = "Aceptando" OrElse EstadoMEI_V1 = "Iniciando") And EstadoMEI_V1 <> "Fallo_Conexion" Then
                varPub.SegundosReceptor = 0
            End If
        End If

        If varPub.Activar_Val2 Then
            If (EstadoMEI_V2 = "Aceptando" OrElse EstadoMEI_V2 = "Iniciando") And EstadoMEI_V2 <> "Fallo_Conexion" Then
                varPub.SegundosReceptor = 0
            End If
        End If

        varPub.SegundosReceptor += 1 '-->
        lbl_tmrCerrar.Text = "TE  " & varPub.TimeOut_Receptor - varPub.SegundosReceptor
        If (EstadoMEI_V1 = "Fallo_Conexion") OrElse EstadoMEI_V2 = "Fallo_Conexion" Then
            pnl_General.Enabled = True
            pct_cargando.Visible = False
            btn_Iniciar.Enabled = False
            btn_Finalizar.Enabled = True
            btn_Cerrar.Enabled = False
            btn_Finalizar.Focus()
        End If

        If varPub.SegundosReceptor >= (varPub.TimeOut_Receptor) Then
            'varPub.D_On = True
            If btn_Finalizar.Enabled = False AndAlso btn_Iniciar.Enabled = False Then
                varPub.SegundosReceptor = 0
            End If
            varPub.SegundosSesion = 0
            varPub.SegundosReceptor = 0

            If btn_Finalizar.Enabled = True Then
                tmr_depositos.Enabled = False
                If varPub.Activar_Val1 Then
                    timer_ok = True
                    Me.meicontrol1.DetenerAceptacion() 'desactiva Val_1

                End If

                If varPub.Cant_Validadores = 2 AndAlso varPub.Activar_Val2 Then
                    Me.meicontrol2.DetenerAceptacion() 'desactiva Val_2
                End If

                If varPub.ManejaConexionWebService = 0 Then
                    Call FinalizarDeposito(CierreDeposito.CERRADO_POR_TIMEOUT)
                End If


            ElseIf btn_Iniciar.Enabled Then
                tmr_depositos.Enabled = False
            End If

            Me.meicontrol1.Dispose()

            If varPub.Cant_Validadores = 2 AndAlso varPub.Activar_Val2 Then
                meicontrol2.Dispose()
            End If

            If varPub.ManejaConexionWebService = 1 Then
                RaiseEvent DepositoFinalizar_PorWebS(CierreDeposito.CERRADO_POR_TIMEOUT)
            End If

            Me.Close()
        End If
    End Sub

    Private Sub frm_DepositoXvalidador_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub

    'Public Sub DepositosXWebS_DepositoCancelar() Handles Me.DepositoCancelar_PorWebS
    '    Call FinalizarDeposito(CierreDeposito.CERRADO_POR_USUARIO)
    '    btn_Iniciar.Text = "Cajas"
    '    btn_Iniciar.TextImageRelation = TextImageRelation.ImageBeforeText
    '    btn_Iniciar.TextAlign = ContentAlignment.MiddleLeft
    '    btn_Iniciar.Font = New Font("Arial", 14.25, FontStyle.Bold)
    '    'Crera funcion que valide Fin Cancela deposito-Deposito cancelado con exito

    '    TotalDepositado = MontoDepositadoV1 + MontoDepositadoV2
    '    If TotalDepositado = Nothing Then TotalDepositado = 0

    '    Dim filasAfectadas As Integer = fn_TransaccionActualiza_TotalDepositado(CInt(dt_MontoEnviado.Rows(0).Item("Id")), TotalDepositado)

    '    If filasAfectadas = Nothing Then
    '        'Ocurrió un error al actualizar la tabla transaccion Montodepositado
    '    End If
    '    If filasAfectadas > 0 Then
    '        'Montodepositado actualizado correctamente de la tabla Transaccion
    '        varPub.DepositoFinalizado = True
    '    End If
    '    TotalDepositado = 0
    '    MontoDepositadoV1 = 0
    '    MontoDepositadoV2 = 0

    '    If StatusCajeroDic.ContainsKey("K_CA") Then
    '        StatusCajeroDic.Clear()
    '    End If

    '    Me.Close()
    'End Sub
#End Region

    Private Sub fn_Log_Depositos(errorDeposito As String)
        ' add_log_depositos
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("add_log_depositos", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@error", SqlDbType.VarChar, errorDeposito)
            Ejecutar_NonQuerySQL(Cmd)
        Catch ex As Exception

        End Try
    End Sub

End Class