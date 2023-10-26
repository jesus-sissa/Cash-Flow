Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Usuarios
Imports Modulo_CashFlowV2.cls_Correo
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.IO.Ports '(20/12/2018 JAVIER ZAPATA)
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL
Imports System.Deployment.Application
Imports System.Data.SQLite
Imports System.Configuration
'NUEVOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
Public Class frm_Login

#Region "- Variables"

    Private Segundos_UltConexion As Integer = 0
    Private Segundos_ConexionInternet As Integer = 0
    Private HayVariablesPersistentes As Boolean = False
    Private WithEvents DepositoXWS As New cls_DepositoXValidadorWebS
    Private ManejaCnxWebS As New Dictionary(Of String, Integer)
    Private Sesion As Boolean
    Private Cargado As Boolean
    Private Descargando As Boolean
    Public Puerto As New SerialPort '(20/12/2018 JAVIER ZAPATA)'
    Private Conectividad As Boolean
    Private ClickCount As Integer = 0
    Dim myVersion As Version

#End Region

#Region "- Eventos Formulario"

    Private Sub frm_Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Close()
        'Call Ocultar_Taskbar.Show() 'volver a mostrar la barrade tareas al cerrar sistema
    End Sub

    Function Test_Conexion(ByVal Cnx As String) As Boolean
        Try
            Dim connection As SqlConnection = New SqlConnection(Cnx)
            connection.Open()

            If (connection.State And ConnectionState.Open) > 0 Then
                connection.Close()
                Return True
            Else
                Return False
            End If

        Catch
            Return False
        End Try
    End Function
    Public Function Get_Configuracion() As Boolean


        Using conexion As SQLiteConnection = New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
            conexion.Open()
            Dim query As String = "select * from Parametros"
            Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)
            cmd.CommandType = System.Data.CommandType.Text

            Using dr As SQLiteDataReader = cmd.ExecuteReader()

                While dr.Read()
                    Variables._ServerName = dr("ServerName")
                    Variables._Cnx = dr("Cnx")
                End While
            End Using
        End Using
        Return Test_Conexion(Variables._Cnx)
    End Function

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA1
        varPub.IdPantalla = 30


        If (Not Get_Configuracion()) Then
            Dim frmConfigServer As New frm_Config_Server
            frmConfigServer.ShowDialog()
            If Variables._ServerName = "" Then
                Application.Exit()
                Exit Sub
            End If

        End If

        Try
            lblVersion.Text = "VERSION: " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString 'My.Application.Info.Version.ToString
        Catch ex As Exception
            lblVersion.Text = "VERSION: 3.0.0.1"
        End Try


        Call main() '1.- Inicializa valores de variables publicas
        Dim Persistente As New cls_VariablesPersistentes()
        If Not Persistente.Cargar() Then
            HayVariablesPersistentes = False
            Call fn_MsgBox("Ocurrió un error al leer la configuracion de la base de datos.", MessageBoxIcon.Error, True, 3)
            Exit Sub
        End If

        HayVariablesPersistentes = True
        lbl_Clavesucursal.Text = "SUCURSAL: " + varPub.Cve_Sucursal
        Me.Refresh()
        Me.WindowState = FormWindowState.Maximized
        pnl_General.Enabled = False
        varPub.Logo_Empresa = Nothing
        tbx_Clave.Clear()
        tbx_Contrasena.Clear()
        varPub.TipoUser = 0 'siempre 0 ok

        'Dejé afuera esto para que se inicializara siempre  JAVIERZAPATA
        If Persistente.Existe Then
            Persistente.Cargar()
            Dim VersionEnsamblado As String = My.Application.Info.Version.ToString
            'A).- Cargar logoEmpresa si existe
            If varPub.Logo_EmpresaRuta.Trim <> "" Then
                'validar siempre que exista la imagen
                If IO.File.Exists(varPub.Logo_EmpresaRuta) Then
                    varPub.Logo_Empresa = fn_ConvierteArchivoaBytes(varPub.Logo_EmpresaRuta)
                End If
            End If
        End If

        pnl_General.Enabled = True
        forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.NUMEROS
        Call Reestablecer_TecladoLogin()
        tbx_Clave.Select()
        Me.Refresh()
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Call ReiniciarMedidasEscritorio()
        tbx_Clave.Focus()
        Call ProbarPuerto()


    End Sub
    Private Function ConexionActivaCashWeb() As Boolean
        Dim resp = False
        Try
            Using cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
                cnn.Open()
                resp = True

            End Using
        Catch ex As Exception

        End Try
        Return resp
    End Function



    Private Sub MostrarRecibido()
        Dim Cadena As Object = Puerto.ReadExisting()
        Dim SensorEstatus As String = "cerrada"
        Dim Contador As Integer = 0
        Dim SesionSensor As Boolean = False

        For i As Integer = 1 To Cadena.Length
            If Mid(Cadena, i, 1) = "e" Then
                SensorEstatus = "abierta"
                Exit For
            ElseIf Mid(Cadena, i, 1) = "H" Then
                Contador = Contador + 1
            End If
        Next

        For Each Frm As Form In Application.OpenForms
            If Frm.Name = "frm_MenuGeneral" Then
                SesionSensor = True
            End If
        Next

        If SensorEstatus = "abierta" Then
            ctrlTeclado.Hide()
            Call fn_EscribirLog(varPub.UsuarioClave, "MOVIMIENTO EN BOVEDA", "LA BÓVEDA ESTÁ: " & SensorEstatus)
            fn_MsgBox("La Bóveda está " & SensorEstatus & "", MessageBoxIcon.Information, True)

            If Conectividad Then
                If SesionSensor Then
                    MandarCorreo("La bóveda fue  " & SensorEstatus, "Movimiento en bóveda")
                    Exit Sub
                Else
                    MandarCorreo("La bóveda fue " & SensorEstatus, "Movimiento en bóveda")
                    Exit Sub
                End If
            End If

        ElseIf Contador > 0 And SensorEstatus = "cerrada" Then
            ctrlTeclado.Hide()
            Call fn_EscribirLog(varPub.UsuarioClave, "MOVIMIENTO EN BOVEDA", "LA BÓVEDA ESTÁ: " & SensorEstatus)
            fn_MsgBox("La Bóveda está " & SensorEstatus & "", MessageBoxIcon.Information, True)

            If Conectividad Then
                If SesionSensor Then
                    MandarCorreo("La bóveda fue  " & SensorEstatus, "Movimiento en bóveda")
                    Exit Sub
                Else
                    MandarCorreo("La bóveda fue " & SensorEstatus, "Movimiento en bóveda")
                    Exit Sub
                End If
            End If

        End If

    End Sub

    '----Empezamos a validar el puerto de los sensores  -Javier Zapata 20/12/2018------
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub ProbarPuerto()

        If Puerto.IsOpen Then
            Puerto.Close()
        End If

        Try
            Puerto.PortName = varPub.PuertoSensores
            Puerto.Open()
            Puerto.Close()
        Catch ex As Exception
            Puerto.Dispose()
            Exit Sub
        End Try

        Puerto.PortName = varPub.PuertoSensores
        Puerto.BaudRate = 9600
        Puerto.Parity = 1
        Puerto.StopBits = 1
        Puerto.Open()
        AddHandler Puerto.DataReceived, AddressOf MostrarRecibido

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#End Region

#Region "- Funciones Privadas"

    Private Sub Validar()


        If Not HayVariablesPersistentes Then
            Call fn_MsgBox("Ocurrió un error al leer la configuracion de la base de datos.", MessageBoxIcon.Error, True, 3)
            Exit Sub
        End If

        pnl_General.Enabled = False
        varPub.TipoUser = 0
        '--------------------
        Dim Persistente As New cls_VariablesPersistentes()
        tmr_SesionGeneral.Enabled = Persistente.Existe


        ' ------------------------
        pClave = tbx_Clave.Text
        pContrasenaActual = tbx_Contrasena.Text
        pAccion = Acciones.Login

        varPub.SegundosSesion = 0
        Select Case fn_Usuario_Validar()
            Case 11
                Call fn_MsgBox("Capture una clave de usuario.", MessageBoxIcon.Exclamation)
                varPub.SegundosSesion = 0
                tmr_SesionGeneral.Enabled = False
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Clave.Focus()

            Case 12
                Call fn_MsgBox("Clave De Usuario o Contraseña Incorrecta.", MessageBoxIcon.Error)
                varPub.SegundosSesion = 0
                tmr_SesionGeneral.Enabled = False
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Clave.Focus()
                tbx_Clave.Text = ""
                tbx_Contrasena.Text = ""
            Case 21
                fn_MsgBox("Capture una Contraseña.", MessageBoxIcon.Exclamation)
                varPub.SegundosSesion = 0
                tmr_SesionGeneral.Enabled = False
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Contrasena.Focus()
            Case 22
                fn_MsgBox("Clave De Usuario o Contraseña Incorrecta.", MessageBoxIcon.Error)
                varPub.SegundosSesion = 0
                tmr_SesionGeneral.Enabled = False
                pnl_General.Enabled = True
                ctrlTeclado.Show()
                tbx_Contrasena.Text = ""
                tbx_Clave.Text = ""
                tbx_Clave.Focus()
            Case Else
                Call Reestablecer_TecladoLogin()
                tmr_SesionGeneral.Enabled = False
                pnl_General.Enabled = True
                tbx_Clave.Focus()
                tbx_Clave.Clear()
                tbx_Contrasena.Clear()
                Me.Focus()
                'Sincronizar()

        End Select
    End Sub

    Private Sub ReiniciarMedidasEscritorio()
        Me.Refresh()
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        '-------------------

        varTecl.DesktopSize = SystemInformation.PrimaryMonitorSize
        varTecl.AnchoPantalla = varTecl.DesktopSize.Width '1280
        varTecl.AltoPantalla = varTecl.DesktopSize.Height '1024

        Dim Persistente As New cls_VariablesPersistentes()
        If Persistente.Existe Then
            'creamos el xml con los valores incluidas del Ancho y alto
            Persistente.Persistir()
            'cargamos los valores que creamos
            Persistente.Cargar()
        End If

        ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
        ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)

        varTecl.ubicaX_Teclado = varTecl.AnchoPantalla - ctrlTeclado.Width
        varTecl.ubicaX_Teclado = varTecl.ubicaX_Teclado / 2
        varTecl.ubicaY_Teclado = tbx_Contrasena.Location.Y + tbx_Contrasena.Height + 10
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        Me.Refresh()
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ctrlTeclado.Hide()
        ctrlTeclado.Show()
        tbx_Clave.Focus()
    End Sub

    Private Sub Reestablecer_TecladoLogin()
        '1.- Siempre hay que mandar la forma del teclado si es la 1ra Vez.
        '2.- Si se cambia la forma de teclado entoces se debe Redimensionar.
        '3.- Enviar ancho y alto de nuevo monitor si se redimensiono.
        '4.- SI el Teclado es el mismo solo Reubicar Posicion.
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.NUMEROS Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.NUMEROS
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        ctrlTeclado.formaTeclado = forma_teclado
        varTecl.ubicaX_Teclado = varTecl.AnchoPantalla - ctrlTeclado.Width 'Las 2 lineas son para centrarlos
        varTecl.ubicaX_Teclado = varTecl.ubicaX_Teclado / 2

        varTecl.ubicaY_Teclado = tbx_Contrasena.Location.Y + tbx_Contrasena.Height + 10
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)
        ctrlTeclado.Show()
        '-------------------
    End Sub

#End Region

#Region "- Eventos de Timers"
    Private Sub tmr_SesionGeneral_Tick(sender As Object, e As EventArgs) Handles tmr_SesionGeneral.Tick
        varPub.SegundosSesion += 1
        If varPub.SegundosSesion >= (varPub.TimeOut_Sesion) Then
            tmr_SesionGeneral.Enabled = False
            Dim TotalModal As Integer = Application.OpenForms.Count - 1 '-1 porque es de 0 a N

            For contador As Integer = 2 To TotalModal '0 Login ,1 es Teclado por eso empieza en 2
                If Application.OpenForms(TotalModal).Modal OrElse Not (Application.OpenForms(TotalModal).Modal) Then
                    Dim NombreForm As String = Application.OpenForms(TotalModal).Name
                    Application.OpenForms(TotalModal).Close()
                    Application.OpenForms(TotalModal).Dispose()

                    'Call cls_FuncionesPublicas.fn_EscribirLog(varPub.UsuarioClave, "----", "CERRANDO PANTALLA: " & NombreForm & " POR INACTIVIDAD")
                    TotalModal -= 1
                End If
            Next

            If varPub.Conectividad Then

                Segundos_UltConexion = (varPub.MinutosUltimaConexion * 60)
            End If

            varPub.SegundosSesion = 0

            Me.Show()
            If varPub.Conectividad = False Then
                Sincronizar()
            End If
        End If

    End Sub
    Public Sub Sincronizar()
        If cls_CashFlow.fn_VerificaConexionInternet Then
            'comentarizado JMCB
            Call cls_CashFlow.fn_Menus_Open(15) 'DEscargas usuarios-Privilegios,casetes y variable[S o N]de UpdateCashflow
            Call cls_CashFlow.fn_Menus_Open(14)   '4.- Verificar Respaldo bdd ->web/Ult_conexion (nuevo 07/11/2016)
            'Para que no muestre la opcion de conexion cuando se alcanza 10 clic sobre el logo
            ClickCount = 0
            '
            Call cls_CashFlow.fn_Verifica_Folios()

        End If
    End Sub



#End Region

#Region "- Eventos Controles"

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        pnl_General.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub lbl_Clave_Click(sender As Object, e As EventArgs) Handles lbl_Clave.Click
        lbl_Clave.Focus()
        ctrlTeclado.Hide()
        Call ReiniciarMedidasEscritorio()
        tbx_Clave.Focus()
    End Sub

    Private Sub lbl_Contrasena_Click(sender As Object, e As EventArgs) Handles lbl_Contrasena.Click
        lbl_Clave.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_Clave_Click(sender As Object, e As EventArgs) Handles tbx_Clave.Click
        tbx_Clave.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Clave) = True
        tbx_Clave.Focus()
    End Sub

    Private Sub tbx_Clave_Enter(sender As Object, e As EventArgs) Handles tbx_Clave.Enter
        tbx_Clave.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Clave) = True
    End Sub

    Private Sub tbx_Clave_GotFocus(sender As Object, e As EventArgs) Handles tbx_Clave.GotFocus
        tbx_Clave.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
    End Sub

    Private Sub tbx_Clave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Clave.KeyPress
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

            Case Keys.Enter
                If tbx_Clave.Text.Trim <> "" AndAlso tbx_Contrasena.Text.Trim = "" Then
                    tbx_Contrasena.Focus()
                Else
                    ctrlTeclado.Hide()

                    Call Validar()

                End If
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub tbx_Clave_Leave(sender As Object, e As EventArgs) Handles tbx_Clave.Leave
        ctrlTeclado.Hide()
        tbx_Clave.BackColor = Color.White
    End Sub

    Private Sub tbx_Contrasena_Click(sender As Object, e As EventArgs) Handles tbx_Contrasena.Click
        tbx_Contrasena.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Contrasena) = True
        tbx_Contrasena.Focus()
    End Sub

    Private Sub tbx_Contrasena_Enter(sender As Object, e As EventArgs) Handles tbx_Contrasena.Enter
        tbx_Contrasena.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Contrasena) = True
        tbx_Contrasena.Focus()
    End Sub

    Private Sub tbx_Contrasena_GotFocus(sender As Object, e As EventArgs) Handles tbx_Contrasena.GotFocus
        tbx_Contrasena.BackColor = Color.LightGoldenrodYellow
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
    End Sub

    Private Sub tbx_Contrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Contrasena.KeyPress

        Try

            Select Case Asc(e.KeyChar)
                Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back

                Case Keys.Enter
                    ctrlTeclado.Hide()
                    Call Validar()
                Case Else
                    e.Handled = True
            End Select
        Catch ex As Exception
            Call fn_EscribirLog("0", "LOGIN", ex.StackTrace.ToString())
        End Try


    End Sub

    Private Sub tbx_Contrasena_Leave(sender As Object, e As EventArgs) Handles tbx_Contrasena.Leave
        ctrlTeclado.Hide()
        tbx_Contrasena.BackColor = Color.White
    End Sub

    Private Sub btn_Apagar_Click(sender As Object, e As EventArgs)


    End Sub

#End Region


    Private Sub pbx_Bateria_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frm_Login_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub



    Private Sub pnl_General_Paint(sender As Object, e As PaintEventArgs) Handles pnl_General.Paint

    End Sub

    Private Sub pic_reinicio_Click(sender As Object, e As EventArgs)

    End Sub
    Sub Apagar_CI()
        Dim frm As New frm_FirmaElectronica
        frm.panelBotones = True
        frm.ShowDialog()

        Select Case frm.DialogResult
            Case Windows.Forms.DialogResult.Cancel
                Call fn_EscribirLog(varPub.UsuarioClave, "APAGAR CAJERO", "Fin APAGAR CAJERO Cancelar Acción")

            Case Windows.Forms.DialogResult.Abort
                Call fn_EscribirLog(varPub.UsuarioClave, "APAGAR CAJERO", "Fin APAGAR CAJERO Usuario no Válido")
                fn_MsgBox("Usuario no Válido.", MessageBoxIcon.Information)

            Case Windows.Forms.DialogResult.OK
                If frm.Apaga_Reinicia = 1 Then
                    'Apagar
                    fn_MsgBox("Apagando el equipo.", MessageBoxIcon.Information, True, 2)

                    Call fn_EscribirLog(varPub.UsuarioClave, "APAGAR CAJERO", "EL Cajero ha sido apagado por: " & varPub.UsuarioClave & ": " & varPub.NombreUser)
                    Dim TotalModal As Integer = Application.OpenForms.Count - 1  '-1 porque Empieza en 0 a N
                    For contador As Byte = 0 To TotalModal '
                        If Application.OpenForms(TotalModal).Modal OrElse Not (Application.OpenForms(TotalModal).Modal) Then
                            Application.OpenForms(TotalModal).Close()
                            TotalModal -= 1
                        End If
                    Next
                    System.Diagnostics.Process.Start("shutdown.exe", " -s -t 0 -f")
                    Exit Sub
                ElseIf frm.Apaga_Reinicia = 2 Then
                    'Reiniciar
                    fn_MsgBox("Reiniciando el equipo.", MessageBoxIcon.Information, True, 2)

                    Call fn_EscribirLog(varPub.UsuarioClave, "REINICIAR CAJERO", "EL Cajero ha sido reiniciado por: " & varPub.UsuarioClave & ": " & varPub.NombreUser)
                    Dim TotalModal As Integer = Application.OpenForms.Count - 1  '-1 porque Empieza en 0 a N
                    For contador As Byte = 0 To TotalModal '
                        If Application.OpenForms(TotalModal).Modal OrElse Not (Application.OpenForms(TotalModal).Modal) Then
                            Application.OpenForms(TotalModal).Close()
                            TotalModal -= 1
                        End If
                    Next
                    System.Diagnostics.Process.Start("shutdown.exe", " -r -t 0 -f")
                    Exit Sub
                End If

        End Select
        Call Reestablecer_TecladoLogin()

        If tbx_Clave.Text.Trim <> "" AndAlso tbx_Clave.Text.Length = 4 Then
            tbx_Contrasena.Focus()
        Else
            tbx_Clave.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ClickCount += 1
        If ClickCount = 10 Then
            'lblVersion.Text = 1
            Dim frmConfigServer As New frm_Config_Server
            frmConfigServer.ShowDialog()
            If Variables._ServerName = "" Then
                Me.Close()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click
        ClickCount += 1
        If ClickCount = 5 Then
            Me.Close()
        End If
    End Sub
End Class