Imports dataconection.cls_DatosSQLCE
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_CashFlow
Imports dataconection.cls_DatosSQL
Imports System.Data.SqlClient

Public Class cls_Usuarios

#Region "Variables Públicas"

    Public Enum Tipos_Usuarios As Byte
        SuperAdmin = 0
        Local = 1
        Administrador = 2
        Supervisor = 3
    End Enum

    Public Enum Acciones As Byte
        X = 0
        Login = 1
        Nuevo = 2
        Editar = 3
        Validar = 4
        CambiarContrasena = 5
    End Enum

#End Region

#Region "Variables Privadas"

    Private Const _Secuencia As String = "012345678909876543210"
    Private Shared _Accion As Acciones
    Private Shared _Clave As String
    Private Shared _Nombre As String
    Private Shared _NombreCortoUser As String
    Private Shared _ContrasenaActual As String
    Private Shared _ContrasenaNueva As String
    Private Shared _Confirmar As String
    Private Shared _Tipo_Usuario As Tipos_Usuarios

#End Region

#Region "Propiedades Públicas"

    Public Shared WriteOnly Property pAccion() As Acciones
        Set(ByVal value As Acciones)
            _Accion = value
        End Set
    End Property

    Public Shared WriteOnly Property pClave() As String
        Set(ByVal value As String)
            _Clave = value
        End Set
    End Property

    Public Shared WriteOnly Property pNombre() As String
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Shared WriteOnly Property pNombreCortoUser() As String
        Set(ByVal value As String)
            _NombreCortoUser = value
        End Set
    End Property

    Public Shared WriteOnly Property pContrasenaActual() As String
        Set(ByVal value As String)
            _ContrasenaActual = value
        End Set
    End Property

    Public Shared WriteOnly Property pContrasenaNueva() As String
        Set(ByVal value As String)
            _ContrasenaNueva = value
        End Set
    End Property

    Public Shared WriteOnly Property pConfirmar() As String
        Set(ByVal value As String)
            _Confirmar = value
        End Set
    End Property

    Public Shared WriteOnly Property pTipo_Usuario() As Tipos_Usuarios
        Set(ByVal value As Tipos_Usuarios)
            _Tipo_Usuario = value
        End Set
    End Property

#End Region

    Private Cajero_Status As String

#Region "Métodos Privados"

    ''' <summary>
    ''' Validación de Usuario
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function fn_Usuario_Validar() As Integer
        Dim Validacion As Int16

        Select Case _Accion
            Case Acciones.Login

                Dim dt_StatusCajero = fn_Cajero_ConsultaStatus() 'obtiene el status del cajero


                If dt_StatusCajero.Rows.Count > 0 Then
                   varPub.CajeroStatus = dt_StatusCajero.Rows(0).Item("Status")

                    Else
                     If fn_Cajero_Insertar() Then
                      dt_StatusCajero = fn_Cajero_ConsultaStatus()
                      varPub.CajeroStatus = dt_StatusCajero.Rows(0).Item("Status")
                      Else
                          fn_MsgBox("Ocurrió un error al consultar status del Cajero.", MessageBoxIcon.Error, True, 3)
                     End If
                End If

                If varPub.CajeroStatus = "D" Then ' Si cajero tiene el status D se actualiza a ND. Esta condición no se va a cumplir cuando falle ambos validadores porque el cajero toma el status 'CF'
                    If Not fn_Cajero_ActualizaStatus("ND") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                        Call fn_MsgBox("Ocurrió un error al actualizar  Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda iniciar depósitos mientras el cajero este en uso.
                        Return -1
                    End If

                End If


                '1.- Validar datos de usuario...
                Validacion = fn_Datos_Validar()
                If Validacion <> 0 Then ' 0 = Correcto

                    Call fn_Propiedades_Limpiar()

                    If varPub.CajeroStatus = "D" Then

                        If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se termina de hacer la  acción se actualiza el status del cajero a DISPONIBLE
                            Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta  pueda ininiaciar depósitos
                            Return -1
                        End If

                    End If
                    Return Validacion
                End If

                '*****************************
                If varPub.TipoUser <> 0 Then
                    '2.- Revisar si ya hay Parametros(XML Persistents)
                    If Not fn_Parametros_Validar() Then
                        Call fn_MsgBox("Parámetros Iniciales no Cargados.", MessageBoxIcon.Error)
                        Return -1
                    End If

                    '3.- Validar monedas y denominaciones capturadas
                    If Not fn_Monedas_VerificarExistencia() Then
                        Call fn_MsgBox("Información de Monedas no cargadas, Consulte al Administrador", MessageBoxIcon.Error)
                        Return -1
                    End If

                    If Not fn_Denominaciones_VerificarExistencia() Then
                        Call fn_MsgBox("Información de Denominaciones no cargados, Consulte al Administrador", MessageBoxIcon.Error)
                        Return -1
                    End If

                    '4.- Verificar los casets que haya (2casets por validador)
                    Dim NumCasets As Integer = fn_Casets_Count()

                    If NumCasets = -1 Then
                        Call fn_MsgBox("Información de Casets no cargados, Consulte al Administrador", MessageBoxIcon.Error)
                        Return -1
                    End If

                    If varPub.Cant_Validadores = 2 And NumCasets < 4 Then
                        Call fn_MsgBox("Debe  haber mínimo 4 casets activos ya que se tienen 2 validadores.", MessageBoxIcon.Error)
                    End If

                    If varPub.Cant_Validadores = 1 And NumCasets < 2 Then
                        Call fn_MsgBox("Debe  haber mínimo 2 casets activos ya que se tienen 2 validadores.", MessageBoxIcon.Error)
                    End If

                    If NumCasets = 0 Or NumCasets = 1 Then
                        'If varPub.TipoUser = 2 Then fn_Menus_Open(11) Else fn_MsgBox("Sin Privilegios para agregar Caset.", MessageBoxIcon.Error)
                    ElseIf varPub.Cant_Validadores = 2 And NumCasets < 4 Then
                        'If varPub.TipoUser = 2 Then fn_Menus_Open(11) Else fn_MsgBox("Sin Privilegios para agregar Caset.", MessageBoxIcon.Error)
                    End If



                End If
                '*****************

                frm_Login.FormBorderStyle = FormBorderStyle.None
                'Validación de la ventana Login para apertura de Menús
                frm_Login.tbx_Clave.Text = String.Empty
                frm_Login.tbx_Contrasena.Text = String.Empty
                'Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "VERSION " & My.Application.Info.Version.ToString)
                Select Case _Tipo_Usuario
                    ' usuarioclave: Es el que esta logueado en el Sistema CashFlow
                    Case Tipos_Usuarios.Local
                        '1.-Verifica si hay nueva Actualizacion
                        'Call fn_ActualizacionCashFlow_Buscar()

                        '2.-Verifica si hay que subir archivo Log.txt
                        'Call fn_VerificarEnvio_ArchivoLog() "Comentado 11/01/2018 por crecimiento de Bd"

                        '3.- Respaldar Bdd en la web
                        Call fn_Menus_Open(24)

                        'Call fn_EscribirLog(UsuarioClave, "LOGIN", "FIN VALIDACIÓN USUARIO LOGIN, USUARIO LOCAL CORRECTO")
                        ''<<<<verificar la fecha expira de la contraseña>>>>>>>>
                        Dim dt_Datos As DataTable = fn_Usuarios_Read(varPub.UsuarioClave)

                       If dt_Datos(0)("Clave_Usuario") <> 5959 Then

                        If dt_Datos.Rows(0)("Usuario_Registro") > 0 AndAlso dt_Datos.Rows(0)("Fecha_Expira") < Date.Now Then

                            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA USUARIOS", "ABRIR VENTANA - CAMBIAR CONTRASEÑA")

                            Dim frm2 As New frm_ConsultaUsuarios

                            'Remueve pestaña cuando es cambio de contraseña
                            frm2.tab_Usuarios.TabPages.Remove(frm2.tbp_ListadoUser)
                            frm2.tbp_Nuevo.Text = "Cambiar Contraseña"

                            'Call fn_Usuarios_Clases(frm2.cmb_Tipo)
                            pAccion = Acciones.CambiarContrasena
                            frm2.Acc = Acciones.CambiarContrasena
                            frm2.tbx_Clave.Enabled = False
                            frm2.tbx_NombreCompleto.Enabled = False
                            frm2.tbx_NombreCorto.Enabled = False
                            frm2.gbx_Tipo.Enabled = False

                            frm2.tbx_Clave.Text = dt_Datos.Rows(0)("Clave_Usuario")
                            frm2.tbx_NombreCompleto.Text = dt_Datos.Rows(0)("Nombre_Usuario")
                            frm2.tbx_NombreCorto.Text = dt_Datos.Rows(0)("Nombre_Corto")
                            'frm2.cmb_Tipo.SelectedValue = dt_Datos.Rows(0)("Tipo_Usuario")

                            Select Case dt_Datos.Rows(0)("Tipo_Usuario")
                                Case 1
                                    frm2.rdb_Local.Checked = True
                                    frm2.rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
                                Case 2
                                    frm2.rdb_Admin.Checked = True
                                    frm2.rdb_Admin.Image = My.Resources.RadioButton_UnChecked_24x24
                            End Select

                            frm2.ShowDialog()
                            If frm2.CambioPsw = False Then
                                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "CERRAR VENTANA - NO CAMBIO CONTRASEÑA")
                                Return -1
                            End If
                            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "CERRAR VENTANA - CAMBIO DE CONTRASEÑA CORRECTA")
                            '..........................................................
                        End If
                       End If

                        Call fn_Propiedades_Limpiar()

                        'Cargar aquí el menu general con sus Privilegios
                        Dim dt_Privilegios As DataTable = fn_ConsultaPrivilegios_LlenatDT(varPub.UsuarioClave, dt_Datos.Rows(0)("Tipo_Usuario"))

                        Dim frm As New frm_MenuGeneral
                        frm.TablapUser = dt_Privilegios
                        'Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "ABRIR VENTANA")

                        frm.ShowDialog()
                        '-----------------------------
                        Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "CERRAR VENTANA")
                        varPub.UsuarioClave = 0



                        'If varPub.CajeroStatus = "D" Then

                        '    If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                        '        Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                        '        Return -1
                        '    End I

                        If varPub.ManejaConexionWebService = 1 Then
                            If varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If

                        If varPub.ManejaConexionWebService = 0 Then
                            If varPub.CajeroStatus = "CN" Then
                                If Not fn_Cajero_ActualizaStatus("CN") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            ElseIf varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If

                    Case Tipos_Usuarios.Administrador

                        '1.-Verifica si hay nueva Actualizacion
                       ' Call fn_ActualizacionCashFlow_Buscar()

                        '2.-Verifica si hay que subir archivo Log.txt
                        'Call fn_VerificarEnvio_ArchivoLog() "Comentado 11/01/2018 por crecimiento de Bd"

                        '3.- Respaldar Bdd en la web
                        Call fn_Menus_Open(24)

                        'Call fn_EscribirLog(UsuarioClave, "LOGIN", "FIN VALIDACIÓN USUARIO LOGIN, USUARIO ADMINISTRADOR CORRECTO")
                        '--«---verificar la fecha expira de la contraseña--»

                        Dim dt_Datos As DataTable = fn_Usuarios_Read(varPub.UsuarioClave)
                      If dt_Datos(0)("Clave_Usuario") <> 5959 Then


                        If dt_Datos.Rows(0)("Usuario_Registro") > 0 AndAlso dt_Datos.Rows(0)("Fecha_Expira") < Date.Now Then
                            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "ABRIR VENTANA - CAMBIAR CONTRASEÑA")
                            Dim frm2 As New frm_ConsultaUsuarios

                            'remover pestaña de listado de usuario
                            frm2.tab_Usuarios.TabPages.Remove(frm2.tbp_ListadoUser)
                            frm2.tbp_Nuevo.Text = "Cambiar Contraseña"

                            pAccion = Acciones.CambiarContrasena
                            frm2.Acc = Acciones.CambiarContrasena
                            frm2.tbx_Clave.Enabled = False
                            frm2.tbx_NombreCompleto.Enabled = False
                            frm2.gbx_Tipo.Enabled = False
                            frm2.tbx_NombreCorto.Enabled = False

                            frm2.tbx_Clave.Text = dt_Datos.Rows(0)("Clave_Usuario")
                            frm2.tbx_NombreCompleto.Text = dt_Datos.Rows(0)("Nombre_Usuario")
                            frm2.tbx_NombreCorto.Text = dt_Datos.Rows(0)("Nombre_Corto")
                            Select Case dt_Datos.Rows(0)("Tipo_Usuario")
                                Case 1
                                    frm2.rdb_Local.Checked = True
                                    frm2.rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
                                Case 2
                                    frm2.rdb_Admin.Checked = True
                                    frm2.rdb_Admin.Image = My.Resources.RadioButton_Checked_24x24
                            End Select

                            frm2.ShowDialog()
                            If frm2.CambioPsw = False Then
                                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "CERRAR VENTANA - NO CAMBIO CONTRASEÑA")
                                Return -1
                            End If
                            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "CERRAR VENTANA - CAMBIO DE CONTRASEÑA CORRECTA")
                            '..........................................................
                        End If
                       End If

                        'Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "ABRIR VENTANA")
                        Call fn_Propiedades_Limpiar()

                        '--------validar que tipo de usuario es 1Local(operativo), 2 Administartivo
                        ' Cargar el menú General con sus Privilegios
                        Dim dt_Privilegios As DataTable = fn_ConsultaPrivilegios_LlenatDT(varPub.UsuarioClave, dt_Datos.Rows(0)("Tipo_Usuario"))

                        Dim frm As New frm_MenuGeneral
                        frm.TablapUser = dt_Privilegios
                        frm.ShowDialog()
                        '-----------------------------
                        Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "CERRAR VENTANA")
                        varPub.UsuarioClave = 0


                        If varPub.ManejaConexionWebService = 1 Then
                            If varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If

                        If varPub.ManejaConexionWebService = 0 Then
                            If varPub.CajeroStatus = "CN" Then
                                If Not fn_Cajero_ActualizaStatus("CN") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            ElseIf varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If


                        'If varPub.CajeroStatus = "D" Then

                        '    If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                        '        Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                        '        Return -1
                        '    End If
                        'End If
                    Case Tipos_Usuarios.Supervisor

                        '1.-Verifica si hay nueva Actualizacion
                        Call fn_ActualizacionCashFlow_Buscar()

                        '2.-Verifica si hay que subir archivo Log.txt
                        ' Call fn_VerificarEnvio_ArchivoLog() "Comentado 11/01/2017 por crecimiento de BD"

                        '3.- Respaldar Bdd en la web
                        Call fn_Menus_Open(24)

                        ' 04/06/2014 en esta parte no entra, pero se deja activo para futuras consultas
                        If varPub.ID_DepositoP > 0 Then
                            Call fn_EscribirLog(varPub.UsuarioClave, "MENSAJE", "PENDIENTE DEPÓSITO POR DESCONEXIÓN")
                            Call fn_MsgBox("Quedo pendiente un Depósito, Iniciar Sesión como Usuario Local o Administrador para Finalizar el Depósito.", MessageBoxIcon.Exclamation)
                        End If

                        Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN VALIDACIÓN USUARIO LOGIN, USUARIO SUPERVISOR CORRECTO")
                        Call fn_EscribirLog(varPub.UsuarioClave, "MENU AUDITORIA", "ABRIR VENTANA")
                        Call fn_Propiedades_Limpiar()
                        Dim frm As New frm_MenuAuditoria

                        frm.ShowDialog()
                        Call fn_EscribirLog(varPub.UsuarioClave, "MENU AUDITORIA", "CERRAR VENTANA")
                        varPub.UsuarioClave = 0

                        'If varPub.CajeroStatus = "D" Then
                        '    If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                        '        Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                        '        Return -1
                        '    End If
                        'End If

                        If varPub.ManejaConexionWebService = 1 Then
                            If varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If

                        If varPub.ManejaConexionWebService = 0 Then
                            If varPub.CajeroStatus = "CN" Then
                                If Not fn_Cajero_ActualizaStatus("CN") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            ElseIf varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If



                    Case Tipos_Usuarios.SuperAdmin

                        '1.-Verifica si hay nueva Actualizacion
                        'Call fn_ActualizacionCashFlow_Buscar()

                        '2.-Verifica si hay que subir archivo Log.txt
                        'Call fn_VerificarEnvio_ArchivoLog()  "Comentado 11/01/2017 por crecimiento de BD"

                        '3.- Respaldar Bdd en la web
                        Call fn_Menus_Open(24)

                        If varPub.ID_DepositoP > 0 Then
                            Call fn_EscribirLog(varPub.UsuarioClave, "MENSAJE", "PENDIENTE DEPÓSITO POR DESCONEXIÓN")
                            Call fn_MsgBox("Quedo pendiente un Depósito, Iniciar Sesión como Usuario Local o Administrador para Finalizar el Depósito.", MessageBoxIcon.Exclamation)
                        End If

                        'Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN VALIDACIÓN USUARIO LOGIN, USUARIO SISTEMAS SISSA CORRECTO")
                        Call fn_EscribirLog(varPub.UsuarioClave, "MENU AUDITORIA", "ABRIR VENTANA")
                        Call fn_Propiedades_Limpiar()
                        Dim frm As New frm_MenuAuditoria

                        frm.ShowDialog()
                        Call fn_EscribirLog(varPub.UsuarioClave, "MENU AUDITORIA", "CERRAR VENTANA")
                        varPub.UsuarioClave = 0

                        'If varPub.CajeroStatus = "D" Then
                        '    If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                        '        Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                        '        Return -1
                        '    End If
                        'End If
                        If varPub.ManejaConexionWebService = 1 Then
                            If varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If

                        If varPub.ManejaConexionWebService = 0 Then
                            If varPub.CajeroStatus = "CN" Then
                                If Not fn_Cajero_ActualizaStatus("CN") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            ElseIf varPub.CajeroStatus = "D" Then
                                If Not fn_Cajero_ActualizaStatus("D") Then  ' Cuando se hace cualquier acción que no sea por web service se actualiza el status del cajero a NODISPONIBLE
                                    Call fn_MsgBox("Ocurrió un error al actualizar el Status del Cajero.", MessageBoxIcon.Error) ' Para que la caja punto de venta no pueda ininiaciar depósitos mientras el cajero este uso.
                                    Return -1
                                End If
                            End If
                        End If

                End Select
                Return 0

            Case Acciones.Nuevo, Acciones.Editar
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "INICIO - EDITAR Y/O CREAR USUARIOS.")

                Validacion = fn_Datos_Validar() 'Verificar para que valida aqui?
                Dim Query As String = ""

                If Validacion <> 0 Then
                    Call fn_Propiedades_Limpiar()
                    Return Validacion
                End If

                Dim Cnn As SqlConnection = Nothing
                Dim Cmd As SqlCommand = Nothing
                If _Accion = Acciones.Nuevo Then ' si es un usuario nuevo
                    Dim ContraCod As String = fn_Encode(_Clave) 'modif 15/10/2015

                    Try
                        Cnn = Crear_ConexionSQL(_Cnx)
                        If _Clave <> "5959" Then ' Si es clave Admin no se consultara la clave
                            If varPub.ConexionwebAdmin = 1 Then
                                If fn_VerificaConexionInternet() Then
                                    Dim UsuarioExisteWeb As DataTable = cls_CashWeb.fn_ConsultaUsuariosExistente(_Clave)
                                    If UsuarioExisteWeb IsNot Nothing AndAlso UsuarioExisteWeb.Rows.Count > 0 Then
                                        Return -1 ' ya existe usuario en la bd web
                                    End If
                                End If
                            End If
                        End If

                        'Cmd = Crear_ComandoSQL("Usuarios_Insert", CommandType.StoredProcedure, Cnn)
                        Cmd = Crear_ComandoSQL("[Usuarios].[AddUsuario]", CommandType.StoredProcedure, Cnn)
                        'Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, _Clave)
                        Crear_ParametroSQL(Cmd, "@Nombre_Usuario", SqlDbType.VarChar, _Nombre)
                        Crear_ParametroSQL(Cmd, "@Nombre_Corto", SqlDbType.VarChar, _NombreCortoUser)
                        Crear_ParametroSQL(Cmd, "@Tipo_Usuario ", SqlDbType.TinyInt, _Tipo_Usuario)
                        Crear_ParametroSQL(Cmd, "@Contra_Cod  ", SqlDbType.VarChar, ContraCod)
                        Crear_ParametroSQL(Cmd, "@Usuario_Registro ", SqlDbType.VarChar, varPub.UsuarioClave)
                        Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "A")
                        Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "N")
                        Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, "1900-01-01")



                        If _Clave = "5959" Then ' Si  es clave AdministradorSissa se guarda sin afectar el Status2 Para que quede nulo y cuando se carge la lista de empleados no se muestre dicha clave

                            Crear_ParametroSQL(Cmd, "@Status2 ", SqlDbType.VarChar, Nothing)
                        Else
                            Crear_ParametroSQL(Cmd, "@Status2 ", SqlDbType.VarChar, "A")

                        End If

                        Ejecutar_NonQuerySQL(Cmd)

                        ''''''Guarda Usuario en la Web'''''

                        If (varPub.ConexionwebAdmin = 1) Then
                            If fn_VerificaConexionInternet() Then 'verifica si hay conexión
                                If cls_CashWeb.fn_GuardaUsuarios(_Clave, _Nombre, ContraCod, _Tipo_Usuario, "A", _NombreCortoUser, Fecha & " " & Hora, System.DateTime.Now) Then
                                    Cnn = Crear_ConexionSQL(_Cnx)

                                    Cmd = Crear_ComandoSQL("Usuarios_Update4", CommandType.StoredProcedure, Cnn)
                                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, _Clave)
                                    Ejecutar_NonQuerySQL(Cmd)

                                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "EL USUARIO CON CLAVE: " & _Clave & " SE SINCRONIZÓ CORRECTAMENTE.")
                                End If
                                Call fn_SincronizaUltimaConexion()
                            End If
                        End If
                        Return 0
                    Catch ex As Exception
                        Cnn.Dispose()
                        Cmd.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - ERROR AL GUARDAR USUARIO NUEVO CON CLAVE: " & _Clave)
                        fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 68, varPub.IdPantalla, "ERROR AL EDITAR/INSERTAR USUARIO - " + ex.ToString())
                        Return -1
                    End Try


                ElseIf _Accion = Acciones.Editar Then

                    Dim Cnn1 As SqlConnection = Nothing
                    Dim Cmd1 As SqlCommand = Nothing
                    Dim Tr As SqlTransaction = Nothing

                    Try
                        Cnn1 = Crear_ConexionSQL(_Cnx)
                        Tr = Crear_TransSQL(Cnn1)

                        'A).-Revisa si era Usario tipo 2(administrador)


                        Cmd1 = Crear_ComandoTSQL(Cnn1, Tr, CommandType.StoredProcedure, "Usuarios_Read5")
                        Crear_ParametroSQL(Cmd1, "@Clave_Usuario", SqlDbType.Int, _Clave)
                        Dim dt_TipoUsuarios As DataTable = Ejecutar_ConsultaTSQL(Cmd1)
                        Dim TipoAnt As Integer = CInt(dt_TipoUsuarios.Rows(0)("Tipo_Usuario"))

                        If TipoAnt = 2 AndAlso (_Tipo_Usuario = Tipos_Usuarios.Local) Then ' valida si era usuario admin
                            'Obtener privilegios del usuario anterior

                            Cmd1 = Crear_ComandoTSQL(Cnn1, Tr, CommandType.StoredProcedure, "Opciones_Read2")
                            Crear_ParametroSQL(Cmd1, "@Clave_Usuario", SqlDbType.Int, _Clave)
                            Dim dt_Privilegios As DataTable = Ejecutar_ConsultaTSQL(Cmd1)

                            'Si Era admin(2) y cambia a local(1), Eliminar privilegios tipo 2

                            For Each Elementos As DataRow In dt_Privilegios.Rows
                                Cmd1 = Crear_ComandoTSQL(Cnn1, Tr, CommandType.StoredProcedure, "Privilegios_Delete2")
                                Crear_ParametroSQL(Cmd1, "@Clave_Usuario", SqlDbType.Int, _Clave)
                                Crear_ParametroSQL(Cmd1, "@Clave_Opcion", SqlDbType.Int, Elementos("Clave_Opcion"))
                                Ejecutar_NonQueryTSQL(Cmd1)
                            Next

                        End If

                        Cmd1 = Crear_ComandoTSQL(Cnn1, Tr, CommandType.StoredProcedure, "Usuarios_Update5")
                        Crear_ParametroSQL(Cmd1, "@Clave_Usuario", SqlDbType.Int, _Clave)
                        Crear_ParametroSQL(Cmd1, "@Nombre_Usuario", SqlDbType.VarChar, _Nombre)
                        Crear_ParametroSQL(Cmd1, "@Nombre_Corto", SqlDbType.VarChar, _NombreCortoUser)
                        Crear_ParametroSQL(Cmd1, "@Tipo_Usuario ", SqlDbType.TinyInt, _Tipo_Usuario)

                        Ejecutar_NonQueryTSQL(Cmd1)

                        Tr.Commit()
                        Tr.Dispose()
                        Cmd1.Dispose()
                        Cnn1.Dispose()

                        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - USUARIO: " & _Clave & " -" & _Nombre & " EDITADO CORRECTAMENTE EN BDD LOCAL.")

                        If (varPub.ConexionwebAdmin = 1) Then
                            If fn_VerificaConexionInternet() Then
                                Call fn_SincronizaUltimaConexion()
                                If cls_CashWeb.fn_Modificar_Usuarios(_Clave, _Tipo_Usuario, _Nombre, _NombreCortoUser, Fecha & " " & Hora) Then ' Si sicronizó usuario al momento de actualizar entonce cambiar el valor de status 2 de 'U' a 'A'

                                    Cnn1 = Crear_ConexionSQL(_Cnx)
                                    Cmd1 = Crear_ComandoSQL("Usuarios_Update6", CommandType.StoredProcedure, Cnn1)
                                    Crear_ParametroSQL(Cmd1, "@Clave_Usuario", SqlDbType.Int, _Clave)
                                    If Ejecutar_NonQuerySQL(Cmd1) <= 0 Then
                                        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN -OCURRIÓ UN ERROR AL EDITAR USUARIO STATUS2: " & _Clave & " EN BDD LOCAL.")
                                    End If
                                End If
                            End If
                        End If
                        Return 0
                    Catch ex As Exception

                        Tr.Rollback()
                        Tr.Dispose()
                        Cmd1.Dispose()
                        Cnn1.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN -  ERROR AL GUARDAR USUARIO: " & _Clave & " ." & ex.Message.ToUpper)
                        Return -1
                    End Try
                End If

            Case Acciones.CambiarContrasena
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "INICIO - VALIDACIÓN DE CAMBIO DE CONTRASEÑA")

                'Se le asigna este valor porque es el mismo usuario firmado que se cambiará su contraseña
                pClave = varPub.UsuarioClave

                Validacion = fn_Datos_Validar()
                If Validacion <> 0 Then
                    Call fn_Propiedades_Limpiar()
                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - NO SE CAMBIO LA CONTRASEÑA, DATOS NO VALIDOS.")
                    Return Validacion
                End If

                Dim Cmd As SqlCommand = Nothing
                Dim Cnn As SqlConnection = Nothing

                Try
                    Cnn = Crear_ConexionSQL(_Cnx)
                    Dim ContraCod As String = fn_Encode(_ContrasenaNueva)

                    Cmd = Crear_ComandoSQL("Usuarios_Update7", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@Contrasena_Usuario", SqlDbType.VarChar, ContraCod)
                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, _Clave)
                    Crear_ParametroSQL(Cmd, "@Dias_Expira", SqlDbType.Int, varPub.Dias_Expira)

                    If Ejecutar_NonQuerySQL(Cmd) <= 0 Then
                        Cmd.Dispose()
                        Cnn.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - ERROR  AL CAMBIAR LA CONTRASEÑA DEL USUARIO: " & _Clave)
                        Call fn_MsgBox(" Error al Editar el Usuario.", MessageBoxIcon.Error)
                        Return -1
                    End If

                    If (varPub.ConexionwebAdmin = 1) Then
                        If fn_VerificaConexionInternet() Then
                            Dim FechaEx As Date = DateAdd(DateInterval.Day, varPub.Dias_Expira, Date.Today)
                            cls_CashWeb.fn_CambiarPassword_Usuarios(_Clave, ContraCod, FechaEx)
                        End If
                    End If

                    Cmd.Dispose()
                    Cnn.Dispose()
                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - SE CAMBIO LA CONTRASEÑA CORRECTAMENTE AL USUARIO: " & _Clave)
                    Return 0

                Catch ex As Exception
                    Cmd.Dispose()
                    Cnn.Dispose()
                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "ERROR AL CAMBIAR CONTRASEÑA DE USUARIO: " & _Clave & "." & ex.Message.ToUpper)
                    Call fn_MsgBox("OCURRIÓ UN ERROR AL CAMBIAR LA CONTRASEÑA DEL USUARIO: " & _Clave & ".", MessageBoxIcon.Error)
                    Return -1
                End Try

            Case Acciones.Validar
                Call fn_EscribirLog(varPub.UsuarioClave, "USUARIOS", "INICIO - VALIDACIÓN USUARIO VALIDAR")
                Validacion = fn_Datos_Validar()
                Call fn_Propiedades_Limpiar()
                Call fn_EscribirLog(varPub.UsuarioClave, "USUARIOS", "FIN - VALIDACIÓN USUARIO VALIDAR")
                Return Validacion
        End Select
        Return -1
    End Function

#End Region



#Region "Funciones Privadas"

    ''' <summary>
    ''' Limpiar valores de las Propiedades
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub fn_Propiedades_Limpiar()
        pAccion = Acciones.X
        pClave = String.Empty
        pNombre = String.Empty
        pContrasenaActual = String.Empty
        pContrasenaNueva = String.Empty
        pConfirmar = String.Empty
        pTipo_Usuario = Tipos_Usuarios.SuperAdmin 'X
    End Sub

    ''' <summary>
    ''' Revisar Existencia de la Clave de Usuario
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Clave_Existe() As Boolean

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        'editado 12marzo 10:12 add status
        Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read12", CommandType.StoredProcedure, Cnn)
        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(_Clave))

        Dim dt_Usuario As DataTable = Ejecutar_ConsultaSQL(Cmd)

        Cmd.Dispose()
        Cnn.Dispose()

        If dt_Usuario.Rows.Count > 0 Then
            Select Case _Accion
                Case Acciones.Login
                    'Sólo el Login se debe de asignarle el Tipo Usuario

                    If dt_Usuario IsNot Nothing AndAlso dt_Usuario.Rows.Count > 0 Then

                        If dt_Usuario.Rows(0)("Status") = "A" Then
                            pTipo_Usuario = dt_Usuario.Rows(0)("Tipo_Usuario")
                            varPub.TipoUser = dt_Usuario.Rows(0)("Tipo_Usuario") '23febr

                        End If
                    End If
                    Return True
                Case Else
                    Return dt_Usuario IsNot Nothing AndAlso dt_Usuario.Rows.Count > 0
            End Select
        End If

        Return False

    End Function

    ''' <summary>
    ''' Validación de la estructura de la Clave
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Clave_Validar() As Boolean
        If _Secuencia.Contains(_Clave) Then Return False
        Return ValidarRepeticion(_Clave)
    End Function

    ''' <summary>
    ''' Revisar Existencia de la Contrasena de Usuario
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Contrasena_Existe(ByVal Contrasena_Existe As String, ByVal ClaveUsuario As String) As Boolean

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

        Dim ContraCod As String = fn_Encode(Contrasena_Existe)


        Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read6", CommandType.StoredProcedure, Cnn)
        Crear_ParametroSQL(Cmd, "@Contra_Cod ", SqlDbType.VarChar, ContraCod)
        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(ClaveUsuario))
        Dim dt_user As DataTable = Ejecutar_ConsultaSQL(cmd)
        cmd.Dispose()
        cnn.Dispose()
        If dt_user IsNot Nothing AndAlso dt_user.Rows.Count > 0 Then
            varPub.NombreUser = dt_user.Rows(0)("Nombre_Usuario")
            Return True
        End If
        Return False

    End Function

    ''' <summary>
    ''' Validación de la estructura de la Contraseña
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Contrasena_Validar() As Boolean
        If _Secuencia.Contains(_ContrasenaNueva) Then Return False
        Return ValidarRepeticion(_ContrasenaNueva)
    End Function

    ''' <summary>
    ''' Validar la Repetición de los Dígitos Capturados
    ''' </summary>
    ''' <param name="Valor">El Datos que se Validará en Repetición de su contenido</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ValidarRepeticion(ByVal Valor As String) As Boolean
        Dim Ultima As Char = Nothing
        Dim Penultima As Char = Nothing

        For Each Letra As Char In Valor
            If Ultima = Nothing Then
                Ultima = Letra
            Else
                If Letra <> Ultima Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Validaciones Sencillas de los Datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Datos_Validar() As Integer
        '-1 -> Error

        'Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "INICIO - VALIDAR DATOS USUARIO")
        Dim rClave As Integer

        Select Case _Accion
            Case Acciones.Login
                'Validar Clave
                If _Clave.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO CAPTURADA")
                    Return 11
                End If

                'Validar Contraseña Actual
                If _ContrasenaActual.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA ACTUAL NO CAPTURADA")
                    varPub.UsuarioClave = 0
                    Return 21
                End If

                If Not Integer.TryParse(_Clave, rClave) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO ES UN ENTERO: " & _Clave)
                    Return 12
                End If

                ' If varPub.ModoCnn = 0 Then varPub.ModoCnn = 3 'para que entrea buscar usuario

                If Not fn_Clave_Existe() Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - LA CLAVE NO EXISTE: " & _Clave)
                    Return 12
                End If

                varPub.UsuarioClave = CInt(_Clave)
                If Not fn_Contrasena_Existe(_ContrasenaActual, varPub.UsuarioClave) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA ACTUAL NO EXISTE: " & _ContrasenaActual)
                    varPub.UsuarioClave = 0
                    Return 22
                End If

            Case Acciones.Nuevo

                If _Clave.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO CAPTURADA")
                    Call fn_MsgBox("Capture una Clave de usuario.", MessageBoxIcon.Exclamation)
                    Return 1
                End If

                'If _Clave.Length < 4 OrElse _Clave.Length > 4 Then
                '    Call fn_EscribirLog(UsuarioClave, "LOGIN", "FIN - CLAVE NO CUMPLE CON LA LONGIRUD: " & _Clave)
                '    Call fn_MsgBox("Clave de Usuario Incorrecta, por favor verifique.", MessageBoxIcon.Error)
                '    Return 1 ' 31/10/2016
                'End If

                If Not Integer.TryParse(_Clave, rClave) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO ES UN ENTERO: " & _Clave)
                    Call fn_MsgBox("Clave de Usuario Incorrecta, por favor verifique.", MessageBoxIcon.Error)
                    Return 1
                End If

                If fn_Clave_Existe() Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE YA EXISTE: " & _Clave)
                    Call fn_MsgBox("Clave ya Existente, por favor ingrese otra.", MessageBoxIcon.Error)
                    Return 1
                End If

                'If CInt(_Clave) < 1000 Then
                '    Call fn_EscribirLog(UsuarioClave, "LOGIN", "FIN- VALIDAR DATOS USUARIO, CLAVE NO CUMPLE CON LAS ESPECIFICACIONES: " & _Clave)
                '    Call fn_MsgBox("Clave de Usuario incorrecta el 1er Numero debe ser Mayor que 0, por favor ingrese otra.", MessageBoxIcon.Error)
                '    Return 1 '31/10/2016
                'End If

                'Validar Nombre
                If _Nombre.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NOMBRE NO CAPTURADO")
                    Call fn_MsgBox("Capture el Nombre del Usuario.", MessageBoxIcon.Exclamation)
                    Return 6
                End If

                If _NombreCortoUser.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NOMBRE CORTO NO CAPTURADO")
                    Call fn_MsgBox("Capture el Nombre Corto del Usuario.", MessageBoxIcon.Exclamation)
                    Return 7
                End If

                If _Nombre.Length > 50 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NOMBRE SOBREPASA LA LONGITUD: " & _Nombre)
                    Call fn_MsgBox("El Nombre no debe ser mayor a 50 caracteres, por favor verifique.", MessageBoxIcon.Error)
                    Return 6
                End If

                ''Validar Tipo Usuario 22 FEBRERO 2013-.X ={0}
                If _Tipo_Usuario = Tipos_Usuarios.SuperAdmin Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - TIPO USUARIO NO SELECCIONADO")
                    Call fn_MsgBox("Debe Seleecionar el Tipo de Usuario.", MessageBoxIcon.Error)
                    Return 5
                End If

            Case Acciones.Editar
                'Validar Nombre
                If _Nombre.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NOMBRE NO CAPTURADO")
                    Call fn_MsgBox("Capture el Nombre del Usuario.", MessageBoxIcon.Exclamation)
                    Return 6
                End If
                If _Nombre.Length > 50 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NOMBRE SOBREPASA LA LONGITUD: " & _Nombre)
                    Call fn_MsgBox("El Nombre no debe ser mayor a 50 caracteres, por favor verifique.", MessageBoxIcon.Error)
                    Return 6
                End If
                If _NombreCortoUser.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NOMBRE CORTO NO CAPTURADO")
                    Call fn_MsgBox("Capture el Nombre Corto del Usuario.", MessageBoxIcon.Exclamation)
                    Return 7
                End If

                ''Validar Tipo Usuario '22 FEBRERO 2013
                If _Tipo_Usuario = Tipos_Usuarios.SuperAdmin Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - TIPO USUARIO NO SELECCIONADO")
                    Call fn_MsgBox("Debe Selecionar el Tipo de Usuario.", MessageBoxIcon.Error)
                    Return 5
                End If

            Case Acciones.CambiarContrasena
                'Validar Contraseña Actual
                If _ContrasenaActual.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA ACTUAL NO CAPTURADA")
                    Call fn_MsgBox("Capture la Contraseña Actual.", MessageBoxIcon.Exclamation)
                    Return 2
                End If

                '-/*----------nueva validacion valida que sean8 numeros----*\
                If Not fn_Valida_Contra(_ContrasenaNueva) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA NUEVA NO ES CORRECTO: " & _ContrasenaNueva)
                    Call fn_MsgBox("La contraseña debe de ser de 8 digitos.", MessageBoxIcon.Error)
                    Return 2
                End If

                If Not fn_Contrasena_Existe(_ContrasenaActual, varPub.UsuarioClave) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN -CONTRASEÑA ACTUAL NO EXISTE: " & _ContrasenaActual)
                    Call fn_MsgBox("Contraseña Actual Incorrecta, por favor verifique.", MessageBoxIcon.Error)
                    Return 2
                End If

                'Validar Contraseña Nueva
                If _ContrasenaNueva.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA NUEVA NO CAPTURADA")
                    Call fn_MsgBox("Capture una Contraseña Nueva.", MessageBoxIcon.Exclamation)
                    Return 3
                End If

                If _ContrasenaActual = _ContrasenaNueva Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA ACTUAL IGUAL A LA CONTRASEÑA NUEVA")
                    Call fn_MsgBox("La Contraseña Nueva no debe ser Igual a la Contraseña Actual, por favor verifique.", MessageBoxIcon.Error)
                    Return 3
                End If

                'Validar Confirmación de Contraseña
                If _Confirmar.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONFIRMACION DE CONTRASEÑA NO CAPTURADA")
                    Call fn_MsgBox("Capture la Confirmación de la Contraseña.", MessageBoxIcon.Exclamation)
                    Return 4
                End If
                If _Confirmar <> _ContrasenaNueva Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONFIRMACION DE CONTRASEÑA DIFERENTE A LA CONTRASEÑA NUEVA")
                    Call fn_MsgBox("La Confirmación de la Contraseña es distinta a la Contraseña Nueva, por favor verifique.", MessageBoxIcon.Error)
                    Return 4
                End If

            Case Acciones.Validar
                'Validar Clave
                If _Clave.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO CAPTURADA")
                    Return 11
                End If

                'Validar Contraseña Actual
                If _ContrasenaActual.Trim = "" Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN  - CONTRASEÑA ACTUAL NO CAPTURADA")
                    Return 21
                End If

                'If _Clave.Length < 4 OrElse _Clave.Length > 4 Then ' 04/03/2017
                '    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO CUMPLE CON LA LONGITUD: " & _Clave)
                '    Return 12
                'End If

                If Not Integer.TryParse(_Clave, rClave) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO ES UN ENTERO: " & _Clave)
                    Return 12
                End If

                If Not fn_Clave_Existe() Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CLAVE NO EXISTE: " & _Clave)
                    Return 12
                End If

                If Not fn_Contrasena_Existe(_ContrasenaActual, _Clave) Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - CONTRASEÑA ACTUAL NO EXISTE: " & _ContrasenaActual)
                    Return 22
                End If

        End Select

        'Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - DATOS DE USUARIO CORRECTOS")
        Return 0
    End Function

#End Region
    ''''''''''''''''''''

End Class
