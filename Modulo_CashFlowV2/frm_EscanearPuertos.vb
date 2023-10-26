
Public Class frm_EscanearPuertos
    Dim EstadoBusqueda As Byte = 0 '0=Buscando; 1=Error; 2=Conectado
    Dim cantPuertosDisponibles() As String ' = {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10"}
    Dim tbxControl As Control

#Region "Variables Privadas"
    Private meicontrol As New Ccash.MeiDevice

    'segunda instancia para validador2 27julio
    Private meicontrol2 As Ccash.MeiDevice

#End Region

#Region "Eventos Privados de la 1ra Instancia del Validador"

    ''' <summary>
    ''' Iniciar el equipo CashFlow
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Private Sub InicializarControl()
        Try
            'Quitar el contro a la forma, no es visible
            Me.Controls.Remove(Me.meicontrol)

            'Crear el control
            Me.meicontrol = New Ccash.MeiDevice

            '***Definición de Eventos

            'Evento indica Conexión Correcta
            AddHandler meicontrol.OnConexionCompletada, AddressOf meicontrol_OnConexionCompletada
            'Evento indica Conexión Fallida
            AddHandler meicontrol.OnConexionFallida, AddressOf meicontrol_OnConexionFallida
            'Evento indica los Diferentes Estados del Validador
            AddHandler meicontrol.OnEstadosAceptador, AddressOf meicontrol_OnEstadosAceptador
            'Evento que se lanza en caso de que ocurra algun error de caracter general
            AddHandler meicontrol.OnError, AddressOf meicontrol_OnError
            'Agregar el control a la forma, no es visible
            Me.Controls.Add(Me.meicontrol)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que muestra los diferentes estados del validador
    ''' </summary>
    ''' <param name="estadoMei"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnEstadosAceptador(ByVal estadoMei As String)
        '-------
        Me.lbl_ValorStatus.Text = estadoMei
        Select Case estadoMei.ToUpper
            Case "ACEPTANDO", "INGRESANDO", "ALMACENANDO", "RECHAZANDO"
                btn_Detener.Enabled = False 'NEW 22 / JUNIO /2013
            Case "LISTO"
                lbl_ValorStatus.ForeColor = Color.Green
                btn_Detener.Enabled = True 'NEW 22 / JUNIO /2013
            Case "DESCONECTADO"
                lbl_ValorStatus.ForeColor = Color.Orange
        End Select

    End Sub

    ''' <summary>
    ''' Evento que indica que no se efectuó la conexión
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnConexionFallida(ByVal mensajeError As String)
        Try

            Me.meicontrol.DetenerAceptacion()
            lbl_ValorStatus.Text = "Fallo Conexion"
            lbl_ValorStatus.ForeColor = Color.Red
            gbx_StatusVal1.Enabled = True
            gbx_NumValidadores.Enabled = True
            btn_Detener.Enabled = False
            btn_Escanear.Enabled = True
            btn_cerrar.Enabled = True

            EstadoBusqueda = 1

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Evento que indica que la conexión fue correcta
    ''' </summary>
    ''' <param name="numeroSerie"></param>
    ''' <param name="PuertoRegresado"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnConexionCompletada(ByVal numeroSerie As String, ByVal PuertoRegresado As String)

        'Me.lsv_Datos.Items.Add(numeroSerie)
        ' metodo que inicia la aceptacion de billetes en forma manual. es necesario haber realizado primero la conexion con el validador
        ' en caso de error se lanza el evento OnError 
        ' se debe usar una vez que se ha lanzado el evento de conexion completa
        ' para usarlo pon el false el parametro 4 del metodo IniciarConexion y descomenta esta linea
        'Me.meicontrol.IniciarAceptacion()

        tbx_Validador1.Text = numeroSerie
        tbx_PuertoVal1.Text = PuertoRegresado
        btn_Escanear.Enabled = False
        btn_Detener.Enabled = True
        btn_cerrar.Enabled = False
        gbx_StatusVal1.Enabled = True

        'cmb_NoValidadores.Enabled = True
    End Sub

    ''' <summary>
    ''' Evento que indica el error que ha sucedido
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnError(ByVal mensajeError As String)
        MsgBox(mensajeError, MessageBoxIcon.Error, 1)
    End Sub

    Private Sub Iniciar(ByVal strPuerto As String)
        Try
            btn_Escanear.Enabled = False
            Call Me.InicializarControl()

            Me.meicontrol.IniciarConexion(2342, strPuerto, False, False)

            'Método que inicia la conexión con el validador
            'param 1 idusuario. Es usado para respaldo en caso de operaciones truncas debido 
            'a fallas de corriente 
            'param 2 puerto. Si ya se conoce el puerto por el cual esta conecatdo el validador
            ' se asigna en este parametro.
            'param 3 buscarpuertos: realiza una busqueda del validador en los puertos disponibles 
            'en caso de que no se conozca el puerto o en caso de que el puerto especificado ya no este disponible
            'param 4 iniciar al conectar, inicia la aceptacion de billetes de manera automatica al conectarse 
            'correctamente. si no se desea iniciar automaticamente, se debe usar el metodo IniciarAceptacion()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "Eventos Privados de la 2da Instancia del Validador"

    ''' <summary>
    ''' Iniciar el equipo CashFlow
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub InicializarControl2()
        Try

            'Quitar el contro a la forma, no es visible
            Me.Controls.Remove(Me.meicontrol2)

            'Crear el control
            Me.meicontrol2 = New Ccash.MeiDevice

            '***Definición de Eventos

            'Evento indica Conexión Correcta
            AddHandler meicontrol2.OnConexionCompletada, AddressOf meicontrol_OnConexionCompletada2
            'Evento indica Conexión Fallida
            AddHandler meicontrol2.OnConexionFallida, AddressOf meicontrol_OnConexionFallida2
            'Evento indica los Diferentes Estados del Validador
            AddHandler meicontrol2.OnEstadosAceptador, AddressOf meicontrol_OnEstadosAceptador2
            'Evento que se lanza en caso de que ocurra algun error de caracter general
            AddHandler meicontrol2.OnError, AddressOf meicontrol_OnError2

            'Agregar el control a la forma, no es visible
            Me.Controls.Add(Me.meicontrol2)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que muestra los diferentes estados del validador
    ''' </summary>
    ''' <param name="estadoMei"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnEstadosAceptador2(ByVal estadoMei As String)
        '-------
        lbl_ValorStatus2.Text = estadoMei

        Select Case estadoMei.ToUpper
            Case "ACEPTANDO", "INGRESANDO", "ALMACENANDO", "RECHAZANDO"
                btn_Detener2.Enabled = False 'NEW 22 / JUNIO /2013
            Case "LISTO"
                lbl_ValorStatus2.ForeColor = Color.Green
                btn_Detener2.Enabled = True 'NEW 22 / JUNIO /2013
            Case "DESCONECTADO"
                lbl_ValorStatus2.ForeColor = Color.Red
        End Select

    End Sub

    ''' <summary>
    ''' Evento que indica que no se efectuó la conexión
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnConexionFallida2(ByVal mensajeError As String)
        Try
            Me.meicontrol2.DetenerAceptacion()

            lbl_ValorStatus2.Text = "Fallo Conexion"
            lbl_ValorStatus2.ForeColor = Color.Red
            gbx_StatusVal2.Enabled = True
            btn_Detener2.Enabled = False
            btn_Escanear2.Enabled = True
            btn_cerrar.Enabled = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Evento que indica que la conexión fue correcta
    ''' </summary>
    ''' <param name="numeroSerie"></param>
    ''' <param name="PuertoRegresado"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnConexionCompletada2(ByVal numeroSerie As String, ByVal PuertoRegresado As String)

        'Me.lsv_Datos.Items.Add(numeroSerie)
        ' metodo que inicia la aceptacion de billetes en forma manual. es necesario haber realizado primero la conexion con el validador
        ' en caso de error se lanza el evento OnError 
        ' se debe usar una vez que se ha lanzado el evento de conexion completa
        ' para usarlo pon el false el parametro 4 del metodo IniciarConexion y descomenta esta linea
        'Me.meicontrol.IniciarAceptacion()

        tbx_Validador2.Text = numeroSerie
        tbx_PuertoVal2.Text = PuertoRegresado

        btn_Escanear2.Enabled = False
        btn_Detener2.Enabled = True
        btn_cerrar.Enabled = False
        gbx_StatusVal2.Enabled = True
        gbx_NumValidadores.Enabled = True
    End Sub

    ''' <summary>
    ''' Evento que indica el error que ha sucedido
    ''' </summary>
    ''' <param name="mensajeError"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub meicontrol_OnError2(ByVal mensajeError As String)
        MsgBox(mensajeError, MessageBoxIcon.Error, 1)
    End Sub

    Private Sub Iniciar2(ByVal strPuerto As String)
        Try
            Call Me.InicializarControl2()
            btn_Detener2.Enabled = False

            Me.meicontrol2.IniciarConexion(4348, strPuerto, False, False)

            'Método que inicia la conexión con el validador
            'param 1 idusuario. Es usado para respaldo en caso de operaciones truncas debido 
            'a fallas de corriente 
            'param 2 puerto. Si ya se conoce el puerto por el cual esta conecatdo el validador
            ' se asigna en este parametro.
            'param 3 buscarpuertos: realiza una busqueda del validador en los puertos disponibles 
            'en caso de que no se conozca el puerto o en caso de que el puerto especificado ya no este disponible
            'param 4 iniciar al conectar, inicia la aceptacion de billetes de manera automatica al conectarse 
            'correctamente. si no se desea iniciar automaticamente, se debe usar el metodo IniciarAceptacion()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

    Private Sub frm_EscanearPuertos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.meicontrol IsNot Nothing Then Me.meicontrol.Dispose()
        If rdb_2val.Checked = True Then
            If Me.meicontrol2 IsNot Nothing Then Me.meicontrol2.Dispose()
        End If
    End Sub

    Private Sub frm_EscanearPuertos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 26
        cantPuertosDisponibles = System.IO.Ports.SerialPort.GetPortNames
        Array.Sort(cantPuertosDisponibles)


        lbl_NumPuertos.Text = "Puertos Disponibles: " & cantPuertosDisponibles.Length

        For i As Integer = 0 To cantPuertosDisponibles.Length - 1
            cmb_Puertos.Items.Add(cantPuertosDisponibles(i))
            'Variables.Puertos(i) = cantPuertosDisponibles(i)
        Next

        spc_Validadores.Panel2Collapsed = True

        btn_Escanear.Enabled = cmb_Puertos.Items.Count > 0
        btn_Escanear2.Enabled = cmb_Puertos.Items.Count > 0

    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub rdb_1val_Click(sender As Object, e As EventArgs) Handles rdb_1val.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        spc_Validadores.Panel2Collapsed = True

        rdb_1val.Image = My.Resources.RadioButton_Checked_24x24
        rdb_2val.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_2val_Click(sender As Object, e As EventArgs) Handles rdb_2val.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        spc_Validadores.Panel2Collapsed = False

        gbx_StatusVal2.Visible = True
        rdb_2val.Image = My.Resources.RadioButton_Checked_24x24
        rdb_1val.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub btn_Escanear_Click(sender As Object, e As EventArgs) Handles btn_Escanear.Click
        btn_Cerrar.Enabled = False
        btn_Escanear.Enabled = False
        Call Iniciar(cmb_Puertos.Text)

    End Sub

    Private Sub btn_Detener_Click(sender As Object, e As EventArgs) Handles btn_Detener.Click
        Me.meicontrol.DetenerAceptacion()

        btn_Escanear.Enabled = True
        btn_Detener.Enabled = False
        btn_Cerrar.Enabled = True

        tbx_Validador1.Text = ""
        tbx_PuertoVal1.Text = ""
        lbl_ValorStatus.Text = "Desconectado"
    End Sub

    Private Sub btn_Escanear2_Click(sender As Object, e As EventArgs) Handles btn_Escanear2.Click
        btn_Cerrar.Enabled = False
        btn_Escanear2.Enabled = False

        Call Iniciar2(cmb_Puertos.Text)
    End Sub

    Private Sub btn_Detener2_Click(sender As Object, e As EventArgs) Handles btn_Detener2.Click
        Me.meicontrol2.DetenerAceptacion()

        btn_Escanear2.Enabled = True
        btn_Detener2.Enabled = False
        btn_Cerrar.Enabled = True

        tbx_Validador2.Text = ""
        tbx_PuertoVal2.Text = ""
        lbl_ValorStatus2.Text = "Desconectado"
    End Sub

    Private Sub CopiarTexto()
        varPub.TextoCopiado = String.Empty

        If tbxControl Is Nothing Then Exit Sub
        Dim _tbxNuevo As New TextBox

        If TypeOf tbxControl Is TextBox Then
            _tbxNuevo = tbxControl
            varPub.TextoCopiado = _tbxNuevo.Text
        End If
    End Sub

    Private Sub btn_CopiarTexto_Click(sender As Object, e As EventArgs) Handles btn_CopiarTexto.Click
        varPub.SegundosSesion = 0
        Call CopiarTexto()
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub tbx_Validador1_Click(sender As Object, e As EventArgs) Handles tbx_Validador1.Click
        tbxControl = tbx_Validador1
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Validador1_Enter(sender As Object, e As EventArgs) Handles tbx_Validador1.Enter
        tbxControl = tbx_Validador1
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Validador2_Click(sender As Object, e As EventArgs) Handles tbx_Validador2.Click
        tbxControl = tbx_Validador2
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Validador2_Enter(sender As Object, e As EventArgs) Handles tbx_Validador2.Enter
        tbxControl = tbx_Validador2
        varPub.SegundosSesion = 0
    End Sub
End Class