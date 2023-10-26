Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports System.Diagnostics
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL
Imports System.Data.SqlServerCe
Imports System.Threading
Imports System.IO.Ports '26/12/2018 Javier zapata
Imports System.Deployment.Application

Public Class frm_Parametros
    Dim Ruta_Default As String
    Dim segundosImprime As Integer = 0
    Dim Conex As String = ""
    Dim thread As Thread
    Dim Filtro As String = "Archivos Ejecutables(*.exe)|*.exe"
    Dim Dialogo As New OpenFileDialog
    Dim PathFile_Actualiza As String = ""
    Dim logoRuta As String = ""
    Dim RutaFiledescargado As String = ""
    Dim PathDescargado As String = ""
    Dim NombreExeDescargado As String = ""
    Dim DepositoManual As Integer
    Dim FolioManual As Integer
    Dim validarFolio As Integer
    Dim Trabajar_sin As Integer
    Private miTimer As New System.Windows.Forms.Timer
    Private Plaza As String 'JROO


#Region "Funciones Privadas"

    Private Sub CambiaestatusActualizar(ByVal SiUpdate As String)
        cls_CashWeb.fn_ActualizaStatus_Actualizar(SiUpdate)
    End Sub

    Private Sub Guardar()
        btn_Guardar.Enabled = False
        'Validar que los Datos sean correctos


        If tbx_SucursalNombre.Text.Trim = "" Then
            Call fn_MsgBox("Especifique el nombre de la Sucursal.", MessageBoxIcon.Error)
            tbx_SucursalNombre.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_Cliente.Text.Trim = "" Then
            Call fn_MsgBox("Especifique el nombre del Cliente.", MessageBoxIcon.Error)
            tbx_Cliente.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_NombreCorto.Text.Trim = "" Then
            Call fn_MsgBox("Especifique el nombre corto para la Sucursal.", MessageBoxIcon.Error)
            tbx_NombreCorto.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_Direccion.Text.Trim = "" Then
            Call fn_MsgBox("Especifique la dirección del Cliente.", MessageBoxIcon.Error)
            tbx_Direccion.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_ClaveSucursal.Text.Trim = "" Then
            Call fn_MsgBox("Especifique la Clave de la Sucursal.", MessageBoxIcon.Error)
            tbx_ClaveSucursal.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If cmb_ClaveSucursal.Visible Then
            If cmb_ClaveSucursal.SelectedValue = "0" Then
                Call fn_MsgBox("Seleccione la clave de la Sucursal", MessageBoxIcon.Error)
                cmb_ClaveSucursal.Focus()
                btn_Guardar.Enabled = True
                Exit Sub
            End If
        End If

        If tbx_CiaTV.Text.Trim = "" Then
            Call fn_MsgBox("Capture una Compañía de Traslado.", MessageBoxIcon.Error)
            tbx_CiaTV.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_ClaveCliente.Text.Trim = "" Then
            Call fn_MsgBox("Capture una la Clave del cliente.", MessageBoxIcon.Error)
            tbx_ClaveCliente.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_Mail.Text.Trim = "" Then
            Call fn_MsgBox("Capture el correo de la sucursal.", MessageBoxIcon.Error)
            tbx_Mail.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_Mail.Text.Trim <> "" Then
            If fn_ValidarMail(tbx_Mail.Text) = False Then
                Call fn_MsgBox("El correo capturado no es válido.", MessageBoxIcon.Error)
                tbx_Mail.Focus()
                btn_Guardar.Enabled = True
                Exit Sub
            End If
        End If

        If tbx_Tel.Text.Trim = "" Then
            Call fn_MsgBox("Especifique el telefono del Cliente.", MessageBoxIcon.Error)
            tbx_Tel.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_Validador1.Text.Trim = "" Then
            Call fn_MsgBox("Capture el Numero de serie del Validador 1", MessageBoxIcon.Error)
            tbx_Validador1.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If tbx_PuertoVal1.Text.Trim = "" Then
            Call fn_MsgBox("Capture el Numero de Puerto de Conexion del Validador 1", MessageBoxIcon.Error)
            tbx_PuertoVal1.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If cmb_Caset.SelectedValue = 0 Then
            Call fn_MsgBox("Seleccione un Caset.", MessageBoxIcon.Error)
            cmb_Caset.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If
        'If Cmb_PesoDolarV1.SelectedValue = 0 Then
        '    Call fn_MsgBox("Seleccione un Caset.", MessageBoxIcon.Error)
        '    Cmb_PesoDolarV1.Focus()
        '    btn_Guardar.Enabled = True
        '    Exit Sub
        'End If
        'If Cmb_PesoDolarV2.SelectedValue = 0 Then
        '    Call fn_MsgBox("Seleccione un Caset.", MessageBoxIcon.Error)
        '    Cmb_PesoDolarV2.Focus()
        '    btn_Guardar.Enabled = True
        '    Exit Sub
        'End If

        ' If cmb_Caset.Enabled Then
        Dim dt_Valorescaset As DataTable = fn_CasetsValores(cmb_Caset.SelectedValue)
        If dt_Valorescaset IsNot Nothing AndAlso dt_Valorescaset.Rows.Count > 0 Then
            varPub.Capacidad_Caset = dt_Valorescaset(0)("Capacidad")
            varPub.Porcentaje_Alerta = dt_Valorescaset(0)("Porcentaje_Alerta")
            varPub.Serie_Caset1 = dt_Valorescaset(0)("Serie_Caset")
            '  varPub.Capacidad_Actual = 0
            dt_Valorescaset.Dispose()
            If cmb_Caset.Enabled Then varPub.Capacidad_Actual = 0 '04/03/2017
        End If
        ' End If

        If rdb_2val.Checked Then 'Si esta activado rdb 2 validadores

            If tbx_Validador2.Text.Trim = "" Then
                Call fn_MsgBox("Capture el Número de serie del Validador 2", MessageBoxIcon.Error)
                tbx_Validador2.Focus()
                btn_Guardar.Enabled = True
                Exit Sub
            End If

            If tbx_PuertoVal2.Text.Trim = "" Then
                Call fn_MsgBox("Capture el Número de Puerto de Conexion del Validador 2", MessageBoxIcon.Error)
                tbx_PuertoVal2.Focus()
                btn_Guardar.Enabled = True
                Exit Sub
            End If

            If cmb_Caset2.SelectedValue = 0 Then
                Call fn_MsgBox("Seleccione el Caset Número 2.", MessageBoxIcon.Error)
                cmb_Caset2.Focus()
                btn_Guardar.Enabled = True
                Exit Sub
            End If

            If cmb_Caset.SelectedValue = cmb_Caset2.SelectedValue Then
                Call fn_MsgBox("Seleccione un caset Diferente.", MessageBoxIcon.Error)
                cmb_Caset2.Focus()
                btn_Guardar.Enabled = True
                Exit Sub
            End If

            ' If cmb_Caset2.Enabled Then
            Dim dt_Valorescaset2 As DataTable = fn_CasetsValores(cmb_Caset2.SelectedValue)
            If dt_Valorescaset2 IsNot Nothing AndAlso dt_Valorescaset2.Rows.Count > 0 Then
                varPub.Capacidad_Caset2 = dt_Valorescaset2(0)("Capacidad")
                varPub.Porcentaje_Alerta2 = dt_Valorescaset2(0)("Porcentaje_Alerta")
                varPub.Serie_Caset2 = dt_Valorescaset2(0)("Serie_Caset")
                'varPub.Capacidad_Actual2 = 0
                dt_Valorescaset2.Dispose()
                If cmb_Caset2.Enabled Then varPub.Capacidad_Actual2 = 0 '04/03/2017
            End If
            'End If

        Else
            cmb_Caset2.SelectedValue = 0
            tbx_Validador2.Text = ""
            tbx_PuertoVal2.Text = ""
            varPub.Serie_Caset2 = ""
            cmb_LimiteCapacidadKct2.Text = 0

            varPub.Capacidad_Caset2 = 0
            varPub.Porcentaje_Alerta2 = 0
            varPub.Capacidad_Actual2 = 0
        End If

        '- 13enero 2014
        If tbx_DiasExpira.Text.Trim = "" Then
            Call fn_MsgBox("Capture un número entero, la cantidad de días para que expire la Contraseña", MessageBoxIcon.Error)
            tbx_DiasExpira.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If
        If CInt(tbx_DiasExpira.Text) < 30 OrElse CInt(tbx_DiasExpira.Text) > 180 Then
            Call fn_MsgBox("El Rango válido de días debe estar entre 30 y 180", MessageBoxIcon.Error)
            tbx_DiasExpira.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        'verifica que se haya creado el tipo de cambio la 1ra Vez
        If tbx_AnteriorTC.Text = "0.0" Then
            fn_MsgBox("Capture una cantidad númerica de forma correcta diferente a 0 en Tipo de Cambio", MessageBoxIcon.Error, True, 2)
            Tab_Parametros.SelectTab(tbp_TipoCambio)
            tbx_NuevoTC.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        If cmb_MododeImprimir.SelectedValue = 0 Then
            fn_MsgBox("Seleccione el modo de impresión de los Tickets.", MessageBoxIcon.Error, True, 2)
            Tab_Parametros.SelectTab(tbp_Impresora)
            cmb_MododeImprimir.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        End If

        'Conectividad con central
        If rdb_SiConectaSA.Checked AndAlso
            tbx_Servidor.Text.Trim = "" AndAlso varPub.Conectividad = False Then
            Tab_Parametros.SelectTab(tbp_ConexionCentral)
            Call fn_MsgBox("Capture los datos de conexión web.", MessageBoxIcon.Error)
            btn_Guardar.Enabled = True
            Exit Sub
        End If
        If rdb_SiConectaSA.Checked Then
            varPub.Conectividad = 1
        Else
            varPub.Conectividad = 0
        End If

        'Permitir Sincronizacion
        Dim Conectado As Byte = 2 ' desconectado
        If rdb_SIconectaAdmin.Checked Then
            Conectado = 1 ' conectado
        End If

        '---prioridad privilegios y ftp, user, password
        Dim prioriPriv As Byte = 1 '1=local, 2=web
        If rdb_web.Checked Then
            prioriPriv = 2
        End If

        '------------Destino del Log
        If lbl_RutaLog.Text = "" Then
            Tab_Parametros.SelectTab(tbp_SizeFuente)
            btn_DestinoLog.Focus()
            btn_Guardar.Enabled = True
            Exit Sub
        Else
            If Not System.IO.Directory.Exists(varPub.Ruta_Log) Then
                System.IO.Directory.CreateDirectory(varPub.Ruta_Log)
                'copiar de "C:\SIac\Loggos aRuta destino
                My.Computer.FileSystem.CopyFile(Ruta_Default & "\" & varPub.Nombre_Archivo & ".txt", varPub.Ruta_Log & "\" & varPub.Nombre_Archivo & ".txt")
            End If
        End If

        '---------------------------------
        If varPub.Ult_Archivo = "" Then
            varPub.Ult_Archivo = varPub.Nombre_Archivo '1marzo por ejemplo y hoy es 5 de marzo(nos conectamos)=
        End If

        varPub.Cant_Validadores = 1

        If rdb_2val.Checked Then varPub.Cant_Validadores = 2

        If logoRuta.Trim <> "" Then

            If IO.File.Exists(logoRuta) Then
                varPub.Logo_Empresa = fn_ConvierteArchivoaBytes(logoRuta)
                varPub.Logo_EmpresaRuta = logoRuta
            Else
                varPub.Logo_Empresa = Nothing
                varPub.Logo_EmpresaRuta = ""
            End If
        Else
            varPub.Logo_Empresa = Nothing
            varPub.Logo_EmpresaRuta = ""
        End If

        If rdb_ManejaDepositoManualSi.Checked Then
            DepositoManual = 1
        ElseIf rdb_ManejaDepositoManualNo.Checked Then
            DepositoManual = 0
        End If

        If rdb_ManejaFolioManualSi.Checked Then
            FolioManual = 1
        ElseIf rdb_ManejaDepositoManualNo.Checked Then
            FolioManual = 0
        End If
        ''Agregado 09/09/2019 nuevo
        If rdb_validarfsi.Checked Then
            validarFolio = 1
        ElseIf rdb_validarfn.Checked Then
            validarFolio = 0
        End If

        Dim SizePapel As Byte = 1
        If rdb_58mm.Checked Then SizePapel = 2
        ''Sincronizar en el login
        If Rdb_sin_s.Checked Then
            Trabajar_sin = 1
        ElseIf Rdb_sin_n.Checked = True Then
            Trabajar_sin = 0
        End If
        'JROO

        If Cmb_Plaza.SelectedIndex = 0 Or Cmb_Plaza.Text = "" Then
            Plaza = 1
        ElseIf Cmb_Plaza.SelectedIndex = 1 Then
            Plaza = 2
        ElseIf Cmb_Plaza.SelectedIndex = 2 Then
            Plaza = 3
        End If


        'verificar que la clave de la sucursal seleccionada no este en USO
        '*************encripta la cadena
        If fn_Parametros_Crear(cmb_MsgFuente.Text, cmb_lblFuente.Text, cmb_cmdFuente.Text,
                                SizePapel, tbx_CiaTV.Text, cmb_Caset.SelectedValue, tbx_Cliente.Text,
                                tbx_Direccion.Text, tbx_Tel.Text, tbx_Servidor.Text, tbx_BDD.Text, tbx_Usuario.Text,
                                tbx_Password.Text, tbx_ClaveSucursal.Text, varPub.Conectividad, tbx_SucursalNombre.Text,
                                tbx_ClaveCliente.Text, varPub.Ruta_Log, cmb_TiempoReceptor.Text, cmb_TiempoSesion.Text,
                                tbx_DiasExpira.Text, varPub.cnx_SucursalWeb, tbx_ClaveUnica.Text, cmb_MargenIzq.Text,
                                varPub.Cant_Validadores, tbx_Validador1.Text, tbx_Validador2.Text,
                                cmb_Caset2.SelectedValue, tbx_PuertoVal1.Text, tbx_PuertoVal2.Text,
                                tbx_NombreCorto.Text, cmb_TipoWindows.SelectedValue, IIf(rdb_SiVal1.Checked, 1, 0),
                                IIf(rdb_SiVal2.Checked, 1, 0), prioriPriv, CInt(cmb_LimiteCapacidadKct.Text),
                                CInt(cmb_LimiteCapacidadKct2.Text), Conectado, CByte(cmb_NoCopias.Text),
                                CByte(cmb_LineasBlanco.Text), tbx_Mail.Text, CDate(btn_FechaInicioOperaciones.Text),
                                tbx_HostIP.Text, IIf(rdb_SIdetalle.Checked, 1, 0), cmb_MododeImprimir.SelectedValue,
                                cmb_PorcBateriaBaja.Text, cmb_PorcBateriaCritica.Text, cmb_puertoSensor.Text,
                                DepositoManual, FolioManual, validarFolio, Trabajar_sin, tbx_IdCajero.Text, Plaza) Then

            '----Revisar la Conectividad y hacer ping hacia internet
            If varPub.Conectividad Then
                If fn_VerificaConexionInternet() Then
                    If ConexionActivaCashWeb() Then
                        Dim dt_sucursal As DataTable = cls_CashWeb.fn_ClaveSucursalExistente(tbx_ClaveSucursal.Text.Trim)
                        If dt_sucursal Is Nothing Then GoTo Continuar

                        If dt_sucursal.Rows.Count > 0 Then
                            If Not cls_CashWeb.fn_ActualizaSucursal(varPub.Cve_Sucursal) Then
                                Call fn_MsgBox("Error al Actualizar datos de la sucursal", MessageBoxIcon.Error)
                                GoTo Continuar
                            End If
                        Else
                            If Not cls_CashWeb.fn_GuardaSucursal() Then
                                Call fn_MsgBox("Error al guardar datos de la sucursal", MessageBoxIcon.Error)
                                GoTo Continuar
                            End If
                        End If
                        '14/10/2016
                        cls_CashWeb.fn_Actualizar_PrioridadPrivilegios(prioriPriv)
                    End If
                End If
            End If
            varPub.TipoMonedaV1 = Cmb_PesoDolarV1.SelectedItem
            varPub.TipoMonedaV2 = Cmb_PesoDolarV2.SelectedItem

            Dim Persistente As New cls_VariablesPersistentes()
            Persistente.Persistir()
            Persistente.Cargar()

            Call fn_MsgBox("Datos Guardados correctamente.", MessageBoxIcon.Information)
            '---------------------------------
        End If
        If Rdb_CorteSi.Checked Then
            Dim Persistente As New cls_VariablesPersistentes()
            ' varPub.CorteActual = 0
            varPub.ManejaCorte = 1
            Persistente.Persistir()
            Persistente.Cargar()
        ElseIf Rdb_CorteNo.Checked Then
            Dim Persistente As New cls_VariablesPersistentes()
            varPub.CorteActual = 0
            varPub.ManejaCorte = 0
            Persistente.Persistir()
            Persistente.Cargar()
            Call Fn_CerrarCorte()
        End If

        If rdb_WebServiceSi.Checked Then
            Dim Persistente As New cls_VariablesPersistentes()
            varPub.ManejaConexionWebService = 1
            Persistente.Persistir()
            Persistente.Cargar()
            If varPub.CajeroStatus = "D" Or varPub.CajeroStatus = "CN" Then varPub.CajeroStatus = "D" ' sino es = Disponible significa que el cajero tenga los caseteros llenos o problemas de conexion con validador
        ElseIf rdb_WebServiceNo.Checked Then                            ' por lo tanto, no se actualizara el status hasta que se resuelva el tipo de problema
            Dim Persistente As New cls_VariablesPersistentes()
            varPub.ManejaConexionWebService = 0
            Persistente.Persistir()
            Persistente.Cargar()
            If varPub.CajeroStatus = "D" Then varPub.CajeroStatus = "CN" ' se actualizará el cajero únicamente cuando tenga el satus disponible o cuando no esta confiurado la conexion (CN)
        End If

        '-----------------
Continuar:

        If (varPub.ConexionwebAdmin = 1) Then
            If frm_Login.tmr_SesionGeneral.Enabled = False Then frm_Login.tmr_SesionGeneral.Enabled = True
            btn_Sincronizar.Enabled = True
        Else
            btn_Sincronizar.Enabled = False
        End If
        ' ----------------------
        btn_Guardar.Enabled = True
        Me.Close()

        '------Javier Zapata 28/12/2018-----------
        If varPub.PuertoSensores <> "Ninguno" Then

            frm_Login.ProbarPuerto()     ' Cargar puerto cambiado
        Else
            If frm_Login.Puerto.IsOpen Then   ' Si se quitó el puerto cerrar el abierto (si es que lo está)
                frm_Login.Puerto.Close()
            End If
        End If
        'Tipo Recoleecion 30/08/2021 
        varPub.Urd = fn_TipoRecoleccion(2, IIf(Rdb_rds.Checked = True, 1, 0))
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
    Private Sub ValidaConexion()
        varPub.Conectividad = False
        varPub.ConexionwebAdmin = 2
        If tbx_ClaveUnica.Text.Trim = "" Then
            Call fn_MsgBox("Debe escribir el nombre de la Clave Unica de la Sucursal.", MessageBoxIcon.Error)
            tbx_ClaveUnica.Focus()
            Exit Sub
        End If

        If tbx_Servidor.Text.Trim = "" Then
            Call fn_MsgBox("Debe Escribir el nombre del Servidor a conectarse.", MessageBoxIcon.Error)
            tbx_Servidor.Focus()
            Exit Sub
        End If
        If tbx_BDD.Text.Trim = "" Then
            Call fn_MsgBox("Debe Escribir la Base de Datos a conectarse.", MessageBoxIcon.Error)
            tbx_BDD.Focus()
            Exit Sub
        End If

        If tbx_Usuario.Text.Trim = "" Then
            Call fn_MsgBox("Debe Escribir el nombre de Usuario de la Base de Datos.", MessageBoxIcon.Error)
            tbx_Usuario.Focus()
            Exit Sub
        End If
        If tbx_Password.Text.Trim = "" Then
            Call fn_MsgBox("Debe Escribir la contraseña de Usuario de la Base de Datos.", MessageBoxIcon.Error)
            tbx_Password.Focus()
            Exit Sub
        End If
        If tbx_HostIP.Text.Trim = "" Then
            Call fn_MsgBox("Debe Escribir algún nombre de host, dirección IP ó URL para poder hacer ping.", MessageBoxIcon.Error)
            tbx_HostIP.Focus()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Tab_Parametros.Enabled = False

        'en este se conecta al server web de sistemas a la bdd [SBDSIS]
        'Para obtener user,pass,server,y bdd a conectarse con ese cliente en particular
        Conex = fn_ConectaServidorWeb(tbx_Servidor.Text, tbx_BDD.Text, tbx_Usuario.Text, tbx_Password.Text, tbx_ClaveUnica.Text.Trim)

        Cursor = Cursors.Default
        Tab_Parametros.Enabled = True

        Dim arr_ConexCorp() As String 'Almacena la cadena de conexion para las SUcursales y nonbre del Corporativo
        If Conex = "" Then
            Call fn_MsgBox("No se encontró ningún Corporativo con los datos especificados.", MessageBoxIcon.Error)
            tbx_Servidor.Focus()
            varPub.cnx_SucursalWeb = "" 'Limpiar Var si no hay conexion
            Exit Sub
        End If

        If Conex = "ERROR" Then
            Call fn_MsgBox("Error al intentar conectarse a la Base de Datos central del Web ..", MessageBoxIcon.Error)
            tbx_Servidor.Focus()
            varPub.cnx_SucursalWeb = "" 'Limpiar Var si no hay conexion
            Exit Sub
        End If

        arr_ConexCorp = Split(Conex, "/")
        Call fn_MsgBox("Se encontró el corporativo " & arr_ConexCorp(1), MessageBoxIcon.Information)

        'Almacena la cn_conexion para sicronizar con las sucursale
        varPub.cnx_SucursalWeb = arr_ConexCorp(0)
        Call fn_Parametros_LlenarComboSucursales(cmb_ClaveSucursal)

        If cmb_ClaveSucursal.Items.Count > 1 Then
            tbx_ClaveSucursal.Visible = False
            cmb_ClaveSucursal.Location = tbx_ClaveSucursal.Location
            cmb_ClaveSucursal.Visible = True
            cmb_ClaveSucursal.SelectedIndex = 1
            tbx_Cliente.Text = arr_ConexCorp(1) '19/10/2015
            If varPub.Cve_Sucursal <> "" Then cmb_ClaveSucursal.Text = varPub.Cve_Sucursal
        End If

        '-----------------------------------------------
        varPub.S_dtb = tbx_Servidor.Text
        varPub.B_dtb = tbx_BDD.Text
        varPub.U_dtb = tbx_Usuario.Text
        varPub.P_dtb = tbx_Password.Text
        If tbx_HostIP.Text.Trim = "" Then
            varPub.hostNameOrAddress = "WWW.GOOGLE.COM"
        Else
            varPub.hostNameOrAddress = tbx_HostIP.Text
        End If

        varPub.ConexionwebAdmin = 1
        varPub.Conectividad = True
        btn_Sincronizar.Enabled = True
        Dim Persistente As New cls_VariablesPersistentes()
        Persistente.Persistir()
        Persistente.Cargar()



    End Sub

    Private Sub HabilitaTexTbox()
        tbx_Servidor.Enabled = True
        tbx_BDD.Enabled = True
        tbx_Usuario.Enabled = True
        tbx_Password.Enabled = True
        tbx_ClaveUnica.Enabled = True
        btn_ConectarBDD.Enabled = True
        tbx_HostIP.Enabled = True
    End Sub

    Private Sub LimpiaTexTbox()
        tbx_Servidor.Clear()
        tbx_BDD.Clear()
        varPub.cnx_SucursalWeb = String.Empty
        tbx_Usuario.Clear()
        tbx_Password.Clear()
        tbx_ClaveUnica.Clear()
        tbx_HostIP.Clear()
    End Sub

    Private Sub DeshabilitaTexTbox()
        tbx_Servidor.Enabled = False
        tbx_BDD.Enabled = False
        tbx_Usuario.Enabled = False
        tbx_Password.Enabled = False
        tbx_ClaveUnica.Enabled = False
        tbx_HostIP.Enabled = False
    End Sub

    Sub HabilitaBotones()
        btn_Guardar.Enabled = True
        btn_Cerrar.Enabled = True
        Tab_Parametros.Enabled = True
        'pgr_Descargando.Value = 0
        'lbl_porcientoDown.Text = "0%"
    End Sub

#End Region

    Private Sub frm_Parametros_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_Parametros_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_Parametros_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub

    Private Sub frm_Parametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 34
        Try
            lbl_Version.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString 'My.Application.Info.Version.ToString
        Catch ex As Exception
            lbl_Version.Text = "3.0.0.1"
            'lblVersion.Text = "TEST"
        End Try
        '4.6.2.5" version de ensamblado es lo que se valida
        ' 3.9.7.1 Version de Archivo(es lo que aparce en detalle del .exe)
        'lbl_Version.Text = "Versión " & My.Application.Info.Version.Major '4
        'lbl_Version.Text = "Versión " & My.Application.Info.Version.MajorRevision '0
        'lbl_Version.Text = "Versión " & My.Application.Info.Version.Minor '6
        'lbl_Version.Text = "Versión " & My.Application.Info.Version.MinorRevision '5
        'lbl_Version.Text = "Versión " & My.Application.Info.Version.Revision '5


        'Agrega valores al combo para la fuente

        For i As Byte = 8 To 18 Step 2
            cmb_lblFuente.Items.Add(i)
            cmb_cmdFuente.Items.Add(i)
        Next

        For i As Byte = 1 To 10
            cmb_LineasBlanco.Items.Add(i)
        Next

        For i As Byte = 10 To 120 Step 10
            cmb_TiempoReceptor.Items.Add(i)
            cmb_TiempoSesion.Items.Add(i)
        Next


        Call fn_Parametros_LlenarCombo(cmb_Caset)
        cmb_Caset.SelectedValue = varPub.CasetID 'selecciona el caset_1

        'Deshabilitar ComboCaset si se esta usando
        If varPub.Capacidad_Actual > 0 Then cmb_Caset.Enabled = False

        '--Marcar el Numero de validadores
        If varPub.Cant_Validadores = 1 Then
            spc_Validadores.Panel2Collapsed = True
            rdb_1val.Checked = True
            rdb_2val.Checked = False

            gbx_StatusVal2.Visible = False
            rdb_1val.Image = My.Resources.RadioButton_Checked_24x24
            rdb_2val.Image = My.Resources.RadioButton_UnChecked_24x24

        Else '2 validares
            spc_Validadores.Panel2Collapsed = False
            rdb_1val.Checked = False
            rdb_2val.Checked = True

            Call fn_Parametros_LlenarCombo(cmb_Caset2)
            cmb_Caset2.SelectedValue = varPub.Caset2ID 'selecciona el caset_2
            If varPub.Capacidad_Actual2 > 0 Then cmb_Caset2.Enabled = False 'deshabilita

            gbx_StatusVal2.Visible = True
            rdb_SiVal2.Image = My.Resources.RadioButton_Checked_24x24
            rdb_SiVal2.Checked = True
            rdb_NoVal2.Image = My.Resources.RadioButton_UnChecked_24x24

            rdb_1val.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_2val.Image = My.Resources.RadioButton_Checked_24x24
        End If


        '--Mostar el Puerto y Serie de los validadores
        tbx_Validador1.Text = varPub.Serie_Val1
        tbx_Validador2.Text = varPub.Serie_Val2

        tbx_PuertoVal1.Text = varPub.Puerto_Val1
        tbx_PuertoVal2.Text = varPub.Puerto_Val2

        '--llena Combo_PesoDolarV1
        Cmb_PesoDolarV1.Items.Add("MXP")
        Cmb_PesoDolarV1.Items.Add("USD")
        Cmb_PesoDolarV1.Items.Add("MXP,USD")

        '--llena Combo_PesoDolarV1
        Cmb_PesoDolarV2.Items.Add("MXP")
        Cmb_PesoDolarV2.Items.Add("USD")
        Cmb_PesoDolarV2.Items.Add("MXP,USD")

        If varPub.TipoMonedaV1 > "" Then
            Cmb_PesoDolarV1.SelectedItem = varPub.TipoMonedaV1

        End If
        If varPub.TipoMonedaV2 > "" Then

            Cmb_PesoDolarV2.SelectedItem = varPub.TipoMonedaV2
        End If


        '--llena Combo_LimiteCapacidad de Caseteros 1 y 2
        cmb_LimiteCapacidadKct.Items.Add("600")
        cmb_LimiteCapacidadKct.Items.Add("800")
        cmb_LimiteCapacidadKct.Items.Add("1200")
        cmb_LimiteCapacidadKct.Items.Add("2200")
        cmb_LimiteCapacidadKct.Text = varPub.LimiteCapacidad_Kct

        cmb_LimiteCapacidadKct2.Items.Add("600")
        cmb_LimiteCapacidadKct2.Items.Add("800")
        cmb_LimiteCapacidadKct2.Items.Add("1200")
        cmb_LimiteCapacidadKct2.Items.Add("2200")
        cmb_LimiteCapacidadKct2.Text = varPub.LimiteCapacidad_Kct2

        rdb_SiConectaSA.Checked = varPub.Conectividad
        rdb_NoconectaSA.Checked = (varPub.Conectividad = False)

        rdb_SiVal1.Checked = varPub.Activar_Val1
        rdb_NoVal1.Checked = (varPub.Activar_Val1 = False)

        rdb_SiVal2.Checked = varPub.Activar_Val2
        rdb_NoVal2.Checked = (varPub.Activar_Val2 = False)

        '1=Conectado :     '2=Desconectado
        rdb_SIconectaAdmin.Checked = (varPub.ConexionwebAdmin = 1)
        rdb_NOconectaAdmin.Checked = (varPub.ConexionwebAdmin = 2)

        '1=Local  :        '2=Web
        rdb_local.Checked = (varPub.Prioridad_Priv = 1)
        rdb_web.Checked = (varPub.Prioridad_Priv = 2)

        btn_Sincronizar.Enabled = (varPub.ConexionwebAdmin = 1)
        tbx_ClaveSucursal.Enabled = (varPub.Conectividad = False) AndAlso (varPub.ConexionwebAdmin = 2 Or varPub.ConexionwebAdmin = 0)
        btn_ActualizaWeb.Enabled = varPub.ConexionwebAdmin = 1

        'Nota:Si no hay Varibles_Persistentes--> Tomar ValoresDefault
        cmb_TiempoReceptor.Text = varPub.TimeOut_Receptor
        cmb_TiempoSesion.Text = varPub.TimeOut_Sesion
        cmb_lblFuente.Text = varPub.TamañoFuente_Etiqueta
        cmb_cmdFuente.Text = varPub.TamañoFuente_Botones
        cmb_MsgFuente.Text = varPub.TamañoFuente_Mensajes

        cmb_NoCopias.Text = varPub.Num_CopiasImprimir
        cmb_MargenIzq.Text = varPub.MargenIzq
        cmb_LineasBlanco.Text = varPub.Num_LineasBlanco

        tbx_Mail.Text = varPub.Mail_Sucursal
        btn_FechaInicioOperaciones.Text = varPub.Inicio_Operaciones
        tbx_HostIP.Text = varPub.hostNameOrAddress

        tbx_SucursalNombre.Text = varPub.Nombre_Sucursal
        tbx_NombreCorto.Text = varPub.Nombre_Corto '-

        tbx_ClaveCliente.Text = varPub.Cve_Cliente
        tbx_ClaveSucursal.Text = varPub.Cve_Sucursal
        tbx_IdCajero.Text = varPub.Id_Cajero '08/08/2020
        lbl_RutaLog.Text = varPub.Ruta_Log '---
        tbx_DiasExpira.Text = varPub.Dias_Expira
        cmb_PorcBateriaBaja.Text = varPub.PorcentajeBateriaBaja
        cmb_PorcBateriaCritica.Text = varPub.PorcentajeBateriaCritica

        Call BuscarPuertos()

        cmb_puertoSensor.Text = varPub.PuertoSensores

        '-----tamaño de papel a usar  ' 1=80 mm' , 2='56 mm'
        rdb_80mm.Checked = (varPub.Tamaño_Papel = 1)
        rdb_58mm.Checked = (varPub.Tamaño_Papel = 2)

        If rdb_80mm.Checked Then
            rdb_80mm.Image = My.Resources.RadioButton_Checked_24x24
            rdb_58mm.Image = My.Resources.RadioButton_UnChecked_24x24
        Else
            rdb_80mm.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_58mm.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '-------------si imprimi desglose
        rdb_SIdetalle.Checked = varPub.Imprimir_DetalleCD
        rdb_NOdetalle.Checked = (varPub.Imprimir_DetalleCD = False)

        If varPub.Imprimir_DetalleCD Then
            rdb_SIdetalle.Image = My.Resources.RadioButton_Checked_24x24
            rdb_NOdetalle.Image = My.Resources.RadioButton_UnChecked_24x24
        Else
            rdb_SIdetalle.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_NOdetalle.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '---------color radiobutonConexionSA
        If rdb_SiConectaSA.Checked Then
            Call HabilitaTexTbox()
            rdb_SiConectaSA.Image = My.Resources.RadioButton_Checked_24x24
            rdb_NoconectaSA.Image = My.Resources.RadioButton_UnChecked_24x24
            gbx_Conectado.Enabled = True
        Else
            gbx_Conectado.Enabled = False
            'Call DeshabilitaTexTbox()
            Call HabilitaTexTbox()
            rdb_SiConectaSA.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_NoconectaSA.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '---------color radiobutonVal1 Activado 
        If rdb_SiVal1.Checked Then
            rdb_SiVal1.Image = My.Resources.RadioButton_Checked_24x24
            rdb_NoVal1.Image = My.Resources.RadioButton_UnChecked_24x24
        Else
            rdb_SiVal1.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_NoVal1.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '---------color radiobutonVal1 Activado 
        If rdb_SiVal2.Checked Then
            rdb_SiVal2.Image = My.Resources.RadioButton_Checked_24x24
            rdb_NoVal2.Image = My.Resources.RadioButton_UnChecked_24x24
        Else
            rdb_SiVal2.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_NoVal2.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '------Conectado (conexion web)
        If rdb_SIconectaAdmin.Checked Then
            rdb_SIconectaAdmin.Image = My.Resources.RadioButton_Checked_24x24
            rdb_NOconectaAdmin.Image = My.Resources.RadioButton_UnChecked_24x24
            gbx_Prioridad.Enabled = True
        Else
            rdb_SIconectaAdmin.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_NOconectaAdmin.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '-------Prioridad de privilegios
        If rdb_local.Checked Then
            rdb_local.Image = My.Resources.RadioButton_Checked_24x24
            rdb_web.Image = My.Resources.RadioButton_UnChecked_24x24
        Else
            rdb_local.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_web.Image = My.Resources.RadioButton_Checked_24x24
        End If

        '--Cargar Logo empresa y mostrar en Picturebox
        varPub.Logo_Empresa = Nothing
        If varPub.Logo_EmpresaRuta.Trim <> "" Then
            logoRuta = varPub.Logo_EmpresaRuta

            If IO.File.Exists(varPub.Logo_EmpresaRuta) Then
                varPub.Logo_Empresa = fn_ConvierteArchivoaBytes(varPub.Logo_EmpresaRuta)
                pct_ImgEmpresa.Image = Image.FromFile(logoRuta)
            Else
                pct_ImgEmpresa.Image = Nothing
            End If
        End If

        '------Datos para el Teclado--------------
        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = Tab_Parametros.Location.Y + Tab_Parametros.ItemSize.Height
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + btn_ConectarBDD.Location.Y)
        tbx_SucursalNombre.Focus()
        '----------------------------------------

        '-------------quitar pestaña conexion, si noEs de sistemas sisssa
        If varPub.TipoUser <> 0 Then
            Tab_Parametros.TabPages.Remove(tbp_ConexionCentral)
            gbx_NumValidadores.Enabled = False
            tbx_Validador1.Enabled = False
            tbx_PuertoVal1.Enabled = False
            tbx_Validador2.Enabled = False
            tbx_PuertoVal2.Enabled = False
            cmb_LimiteCapacidadKct.Enabled = False
            cmb_LimiteCapacidadKct2.Enabled = False
            cmb_TipoWindows.Enabled = False
            'btn_PegarSerieVal1.Visible = False
            'btn_PegarSerieVal2.Visible = False
            btn_ActualizarLocal.Visible = False
            cmb_PorcBateriaBaja.Enabled = False
            cmb_PorcBateriaCritica.Enabled = False
            cmb_puertoSensor.Enabled = False
            pic_BuscarPuertos.Enabled = False

        End If

        '---Llenar el ComboConexion
        Dim dt_ModoImpresion As New DataTable()
        Dim dr_ModoImpresion As DataRow

        dt_ModoImpresion.Columns.Add("Valor", GetType(System.Byte))
        dt_ModoImpresion.Columns.Add("Descripcion", GetType(System.String))

        dr_ModoImpresion = dt_ModoImpresion.NewRow()
        dr_ModoImpresion("Valor") = 0
        dr_ModoImpresion("Descripcion") = "Seleccione..."
        dt_ModoImpresion.Rows.Add(dr_ModoImpresion)

        dr_ModoImpresion = dt_ModoImpresion.NewRow()
        dr_ModoImpresion("Valor") = 1
        dr_ModoImpresion("Descripcion") = "Windows"
        dt_ModoImpresion.Rows.Add(dr_ModoImpresion)

        dr_ModoImpresion = dt_ModoImpresion.NewRow()
        dr_ModoImpresion("Valor") = 2
        dr_ModoImpresion("Descripcion") = "Nippon"
        dt_ModoImpresion.Rows.Add(dr_ModoImpresion)

        'dr_ModoImpresion = dt_ModoImpresion.NewRow()
        'dr_ModoImpresion("Valor") = 3
        'dr_ModoImpresion("Descripcion") = "Zebra"
        'dt_ModoImpresion.Rows.Add(dr_ModoImpresion)

        cmb_MododeImprimir.ValueMember = "Valor"
        cmb_MododeImprimir.DisplayMember = "Descripcion"
        cmb_MododeImprimir.DataSource = dt_ModoImpresion
        cmb_MododeImprimir.SelectedIndex = varPub.Modo_Impresion


        '---------Selecciona el tipo de windows -----
        Dim dt_TipoWindows As New DataTable()
        Dim dr_TipoWindows As DataRow

        dt_TipoWindows.Columns.Add("Valor", GetType(System.Byte))
        dt_TipoWindows.Columns.Add("Descripcion", GetType(System.String))

        dr_TipoWindows = dt_TipoWindows.NewRow()
        dr_TipoWindows("Valor") = 1
        dr_TipoWindows("Descripcion") = "Normal"
        dt_TipoWindows.Rows.Add(dr_TipoWindows)

        dr_TipoWindows = dt_TipoWindows.NewRow()
        dr_TipoWindows("Valor") = 2
        dr_TipoWindows("Descripcion") = "Embebido"
        dt_TipoWindows.Rows.Add(dr_TipoWindows)

        cmb_TipoWindows.ValueMember = "Valor"
        cmb_TipoWindows.DisplayMember = "Descripcion"
        cmb_TipoWindows.DataSource = dt_TipoWindows
        cmb_TipoWindows.Text = varPub.Tipo_Windows
        '----------Maneja Corte Diario
        If varPub.ManejaCorte = 0 Then
            Rdb_CorteSi.Checked = False
            Rdb_CorteNo.Checked = True
            Rdb_CorteSi.Image = My.Resources.RadioButton_UnChecked_24x24
            Rdb_CorteNo.Image = My.Resources.RadioButton_Checked_24x24
        End If

        If varPub.ManejaCorte = 1 Then
            Rdb_CorteSi.Checked = True
            Rdb_CorteNo.Checked = False
            Rdb_CorteSi.Image = My.Resources.RadioButton_Checked_24x24
            Rdb_CorteNo.Image = My.Resources.RadioButton_UnChecked_24x24
        End If

        '----Maneja Conexión con Web Service


        If varPub.ManejaConexionWebService = 1 Then
            rdb_WebServiceNo.Enabled = True
            rdb_WebServiceSi.Checked = True
            rdb_WebServiceSi.Image = My.Resources.RadioButton_Checked_24x24
            rdb_WebServiceNo.Checked = False
            rdb_WebServiceNo.Image = My.Resources.RadioButton_UnChecked_24x24

            If varPub.CajeroStatus = "ND" Or varPub.CajeroStatus = "F" Or varPub.CajeroStatus = "CL" Then
                rdb_WebServiceNo.Enabled = False
            End If

        End If

        If varPub.ManejaConexionWebService = 0 Then

            rdb_WebServiceSi.Checked = False
            rdb_WebServiceSi.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_WebServiceNo.Checked = True
            rdb_WebServiceNo.Image = My.Resources.RadioButton_Checked_24x24

        End If

        If varPub.ManejaDepositoManual Then
            rdb_ManejaDepositoManualNo.Checked = False
            rdb_ManejaDepositoManualSi.Checked = True
            rdb_ManejaDepositoManualNo.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_ManejaDepositoManualSi.Image = My.Resources.RadioButton_Checked_24x24
        Else
            rdb_ManejaDepositoManualNo.Checked = True
            rdb_ManejaDepositoManualSi.Checked = False
            rdb_ManejaDepositoManualNo.Image = My.Resources.RadioButton_Checked_24x24
            rdb_ManejaDepositoManualSi.Image = My.Resources.RadioButton_UnChecked_24x24
        End If




        If varPub.ManejaFolioManual Then
            rdb_ManejaFolioManualSi.Checked = True
            rdb_ManejaFolioManualNo.Checked = False
            rdb_ManejaFolioManualSi.Image = My.Resources.RadioButton_Checked_24x24
            rdb_ManejaFolioManualNo.Image = My.Resources.RadioButton_UnChecked_24x24
        Else
            rdb_ManejaFolioManualSi.Checked = False
            rdb_ManejaFolioManualNo.Checked = True
            gbx_verificarfolio.Enabled = False
            rdb_ManejaFolioManualSi.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_ManejaFolioManualNo.Image = My.Resources.RadioButton_Checked_24x24
        End If


        If varPub.ManejaFolioManual And varPub.ValidarFolio Then
            rdb_validarfsi.Checked = True
            rdb_validarfn.Checked = False
            'txt_conec.Text = varPub.Conexion
            rdb_validarfsi.Image = My.Resources.RadioButton_Checked_24x24
            rdb_validarfn.Image = My.Resources.RadioButton_UnChecked_24x24
        End If
        If varPub.ManejaFolioManual And varPub.ValidarFolio = False Then
            rdb_validarfsi.Checked = False
            rdb_validarfn.Checked = True
            'gbx_verificarfolio.Enabled = False
            'txt_conec.Text = varPub.Conexion
            rdb_validarfsi.Image = My.Resources.RadioButton_UnChecked_24x24
            rdb_validarfn.Image = My.Resources.RadioButton_Checked_24x24
        End If
        If varPub.Trabajar_sin Then
            Rdb_sin_s.Checked = True
            Rdb_sin_n.Checked = False
            Rdb_sin_s.Image = My.Resources.RadioButton_Checked_24x24
            Rdb_sin_n.Image = My.Resources.RadioButton_UnChecked_24x24
        End If
        tbx_IdCajero.Text = varPub.Id_Caje
        ''Cargar tipo de recoleccion [Normal,RD]
        varPub.Urd = fn_TipoRecoleccion(1, 0)
        If (varPub.Urd) Then
            Rdb_rds.Checked = True
            Rdb_rdn.Checked = False
            Rdb_rds.Image = My.Resources.RadioButton_Checked_24x24
            Rdb_rdn.Image = My.Resources.RadioButton_UnChecked_24x24
        End If
        If varPub.Plaza = 1 Then
            Cmb_Plaza.SelectedIndex = 0
        ElseIf varPub.Plaza = 2 Then
            Cmb_Plaza.SelectedIndex = 1
        ElseIf varPub.Plaza = 3 Then
            Cmb_Plaza.SelectedIndex = 2
        ElseIf varPub.Plaza = "" Then
            Cmb_Plaza.SelectedIndex = 0
        End If


        'Evento indica Conexión Fallida
        'AddHandler btn_Guardar.Click, AddressOf btn_Guardar_Click
        'AddHandler btn_Cerrar.Click, AddressOf btn_Cerrar_Click
        'If Not rdb_SiVal1.Checked Then

        '    btn_Guardar.PerformClick()
        '    Dim frm As New frm_DepositoXvalidador
        '    frm.btn_Iniciar.PerformClick()

        'End If
        'btn_Cerrar.PerformClick()

    End Sub

    Private Sub Tab_Parametros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab_Parametros.SelectedIndexChanged
        varPub.SegundosSesion = 0
        btn_Guardar.Visible = True
        btn_Cerrar.Visible = True
        ctrlTeclado.Hide()
        Select Case Tab_Parametros.SelectedTab.Name
            Case tbp_ConexionCentral.Name '0,550
                varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + btn_ConectarBDD.Location.Y)
                ctrlTeclado.Hide()
                tbx_Servidor.Focus()
            Case tbp_datos.Name '0,507
                varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, (varTecl.ubicaY_Teclado + btn_FechaInicioOperaciones.Location.Y + 5))
                ctrlTeclado.Hide()

            Case tbp_Cajero.Name '0,541
                varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + gbx_NumValidadores.Height + cmb_Caset.Location.Y + 10)
                ctrlTeclado.Hide()
                tbx_Validador1.Focus()

            Case tbp_TipoCambio.Name, tbp_ConexionAdmin.Name
                btn_Guardar.Visible = False
                btn_Cerrar.Visible = False
            Case Else
                ctrlTeclado.Hide()
                cmb_lblFuente.Focus()
        End Select
    End Sub

    Private Sub tbp_ConexionCentral_Click(sender As Object, e As EventArgs) Handles tbp_ConexionCentral.Click
        varPub.SegundosSesion = 0
        tbp_ConexionCentral.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbp_datos_Click(sender As Object, e As EventArgs) Handles tbp_datos.Click
        varPub.SegundosSesion = 0
        tbp_datos.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbp_SizeFuente_Click(sender As Object, e As EventArgs) Handles tbp_SizeFuente.Click
        varPub.SegundosSesion = 0
        tbp_SizeFuente.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbp_Cajero_Click(sender As Object, e As EventArgs) Handles tbp_Cajero.Click
        varPub.SegundosSesion = 0
        tbp_Cajero.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbp_TipoCambio_Click(sender As Object, e As EventArgs) Handles tbp_TipoCambio.Click
        varPub.SegundosSesion = 0
        tbp_TipoCambio.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbp_ConexionAdmin_Click(sender As Object, e As EventArgs) Handles tbp_ConexionAdmin.Click
        varPub.SegundosSesion = 0
        tbp_ConexionAdmin.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbp_Impresora_Click(sender As Object, e As EventArgs) Handles tbp_Impresora.Click
        varPub.SegundosSesion = 0
        tbp_Impresora.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Call Guardar()

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Me.Close()

    End Sub

#Region "Pestaña Conexión Central."

    Private Sub gbx_ConexionSA_Click(sender As Object, e As EventArgs) Handles gbx_ConexionSA.Click
        varPub.SegundosSesion = 0
        gbx_ConexionSA.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub rdb_SiConectaSA_Click(sender As Object, e As EventArgs) Handles rdb_SiConectaSA.Click
        'Antes que nada se debe verificar si hay red disponible
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Call HabilitaTexTbox()

        'Cargar info en textbox si existe.
        tbx_Servidor.Text = varPub.S_dtb
        tbx_BDD.Text = varPub.B_dtb
        tbx_Usuario.Text = varPub.U_dtb
        tbx_Password.Text = varPub.P_dtb
        tbx_ClaveUnica.Text = varPub.CUNICA
        tbx_HostIP.Text = varPub.hostNameOrAddress
        tbx_ClaveUnica.Focus()

        rdb_SiConectaSA.Image = My.Resources.RadioButton_Checked_24x24
        rdb_NoconectaSA.Image = My.Resources.RadioButton_UnChecked_24x24

        '--Conectado
        gbx_Conectado.Enabled = True
        rdb_SIconectaAdmin.Image = My.Resources.RadioButton_Checked_24x24
        rdb_SIconectaAdmin.Checked = True

        rdb_NOconectaAdmin.Image = My.Resources.RadioButton_UnChecked_24x24

        '--Prioridad
        gbx_Prioridad.Enabled = True
        rdb_local.Image = My.Resources.RadioButton_Checked_24x24
        rdb_local.Checked = True

        rdb_web.Image = My.Resources.RadioButton_UnChecked_24x24

    End Sub

    Private Sub rdb_NoconectaSA_Click(sender As Object, e As EventArgs) Handles rdb_NoconectaSA.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        'Call DeshabilitaTexTbox()
        ' Call LimpiaTexTbox()

        rdb_NoconectaSA.Image = My.Resources.RadioButton_Checked_24x24
        rdb_SiConectaSA.Image = My.Resources.RadioButton_UnChecked_24x24

        '--------Conectado
        gbx_Conectado.Enabled = False
        rdb_SIconectaAdmin.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_SIconectaAdmin.Checked = False

        rdb_NOconectaAdmin.Image = My.Resources.RadioButton_Checked_24x24
        rdb_NOconectaAdmin.Checked = True

        '--------Prioridad
        gbx_Prioridad.Enabled = False
        rdb_local.Image = My.Resources.RadioButton_Checked_24x24
        rdb_local.Checked = True

        rdb_web.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_web.Checked = False
        tbx_ClaveUnica.Focus()
    End Sub

    Private Sub btn_ConectarBDD_Click(sender As Object, e As EventArgs) Handles btn_ConectarBDD.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        Call ValidaConexion()


    End Sub

    Private Sub btn_DesktopSize_Click(sender As Object, ByVal e As EventArgs) Handles btn_DesktopSize.Click
        'Al dar click Obtenems el tamaño del monitor Principal 'Alto y Ancho

        varTecl.DesktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        tbx_Width.Text = varTecl.DesktopSize.Width
        tbx_Height.Text = varTecl.DesktopSize.Height

        varTecl.AnchoPantalla = varTecl.DesktopSize.Width '1280
        varTecl.AltoPantalla = varTecl.DesktopSize.Height '1024

        Dim Persistente As New cls_VariablesPersistentes()

        'creamos el xml con los valoress incluidas del Ancho y alto
        Persistente.Persistir()

        'cargamos los valores que se crearon
        Persistente.Cargar()
    End Sub

    Private Sub chk_Taskbar_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Taskbar.CheckedChanged
        'esto es para ocultar y desocultar la barra de tareas.-
        If chk_Taskbar.Checked Then
            Try
                ' Ocultar_Taskbar.Hide()
            Catch ex As Exception

            End Try
            chk_Taskbar.Image = My.Resources.CheckBox_Checked_24x24
        Else
            Try
                ' Ocultar_Taskbar.Show()
            Catch ex As Exception

            End Try

            chk_Taskbar.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub tbx_ClaveUnica_Click(sender As Object, e As EventArgs) Handles tbx_ClaveUnica.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveUnica) = True
    End Sub

    Private Sub tbx_ClaveUnica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ClaveUnica.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Servidor.Focus()
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub tbx_ClaveUnica_Leave(sender As Object, e As EventArgs) Handles tbx_ClaveUnica.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveUnica_TextChanged(sender As Object, e As EventArgs) Handles tbx_ClaveUnica.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveUnica_Enter(sender As Object, e As EventArgs) Handles tbx_ClaveUnica.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveUnica) = True
    End Sub

    Private Sub chk_ClaveUnica_CheckedChanged(sender As Object, e As EventArgs) Handles chk_ClaveUnica.CheckedChanged
        If chk_ClaveUnica.Checked Then
            tbx_ClaveUnica.PasswordChar = ""
            chk_ClaveUnica.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_ClaveUnica.Image = My.Resources.CheckBox_Unchecked_24x24
            tbx_ClaveUnica.PasswordChar = "*"
        End If
    End Sub

    Private Sub tbx_Servidor_Click(sender As Object, e As EventArgs) Handles tbx_Servidor.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Servidor) = True
    End Sub

    Private Sub tbx_Servidor_Enter(sender As Object, e As EventArgs) Handles tbx_Servidor.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Servidor) = True
    End Sub

    Private Sub tbx_Servidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Servidor.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_BDD.Focus()
        End If
    End Sub

    Private Sub tbx_Servidor_Leave(sender As Object, e As EventArgs) Handles tbx_Servidor.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Servidor_TextChanged(sender As Object, e As EventArgs) Handles tbx_Servidor.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub chk_Servidor_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Servidor.CheckedChanged
        If chk_Servidor.Checked Then
            chk_Servidor.Image = My.Resources.CheckBox_Checked_24x24
            tbx_Servidor.PasswordChar = ""
        Else
            chk_Servidor.Image = My.Resources.CheckBox_Unchecked_24x24
            tbx_Servidor.PasswordChar = "*"
        End If
    End Sub

    Private Sub tbx_BDD_Click(sender As Object, e As EventArgs) Handles tbx_BDD.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_BDD) = True
    End Sub

    Private Sub tbx_BDD_Enter(sender As Object, e As EventArgs) Handles tbx_BDD.Enter
        tbx_BDD.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_BDD) = True
    End Sub

    Private Sub tbx_BDD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_BDD.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Usuario.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_BDD_Leave(sender As Object, e As EventArgs) Handles tbx_BDD.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_BDD_TextChanged(sender As Object, e As EventArgs) Handles tbx_BDD.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub chk_BD_CheckedChanged(sender As Object, e As EventArgs) Handles chk_BD.CheckedChanged
        If chk_BD.Checked Then
            chk_BD.Image = My.Resources.CheckBox_Checked_24x24
            tbx_BDD.PasswordChar = ""
        Else
            chk_BD.Image = My.Resources.CheckBox_Unchecked_24x24
            tbx_BDD.PasswordChar = "*"
        End If
    End Sub

    Private Sub tbx_Password_Click(sender As Object, e As EventArgs) Handles tbx_Password.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Password) = True
    End Sub

    Private Sub tbx_Password_Enter(sender As Object, e As EventArgs) Handles tbx_Password.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Password) = True
    End Sub

    Private Sub tbx_Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Password.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            btn_ConectarBDD.Focus()
        End If
    End Sub

    Private Sub tbx_Password_Leave(sender As Object, e As EventArgs) Handles tbx_Password.Leave
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_Password_TextChanged(sender As Object, e As EventArgs) Handles tbx_Password.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub chk_Password_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Password.CheckedChanged
        If chk_Password.Checked Then
            chk_Password.Image = My.Resources.CheckBox_Checked_24x24
            tbx_Password.PasswordChar = ""
        Else
            chk_Password.Image = My.Resources.CheckBox_Unchecked_24x24
            tbx_Password.PasswordChar = "*"
        End If
    End Sub

    Private Sub tbx_Usuario_Click(sender As Object, e As EventArgs) Handles tbx_Usuario.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Usuario) = True

    End Sub

    Private Sub tbx_Usuario_Enter(sender As Object, e As EventArgs) Handles tbx_Usuario.Enter
        tbx_Usuario.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Usuario) = True
    End Sub

    Private Sub tbx_Usuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Usuario.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Password.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Usuario_Leave(sender As Object, e As EventArgs) Handles tbx_Usuario.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Usuario_TextChanged(sender As Object, e As EventArgs) Handles tbx_Usuario.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub chk_User_CheckedChanged(sender As Object, e As EventArgs) Handles chk_User.CheckedChanged
        If chk_User.Checked Then
            chk_User.Image = My.Resources.CheckBox_Checked_24x24
            tbx_Usuario.PasswordChar = ""
        Else
            chk_User.Image = My.Resources.CheckBox_Unchecked_24x24
            tbx_Usuario.PasswordChar = "*"
        End If
    End Sub

    Private Sub tbx_HostIP_Click(sender As Object, e As EventArgs) Handles tbx_HostIP.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_HostIP) = True
    End Sub

    Private Sub tbx_Width_KeyPress(sender As Object, ByVal e As KeyPressEventArgs) Handles tbx_Width.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                tbx_Height.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Height_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Height.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                btn_DesktopSize.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

#End Region

#Region "Pestaña Datos Sucursal."

    Private Sub gbx_Sucursal_Click(sender As Object, e As EventArgs) Handles gbx_Sucursal.Click
        varPub.SegundosSesion = 0
        gbx_Sucursal.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_SucursalNombre_Click(sender As Object, e As EventArgs) Handles tbx_SucursalNombre.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_SucursalNombre) = True
    End Sub

    Private Sub tbx_SucursalN_Enter(sender As Object, e As EventArgs) Handles tbx_SucursalNombre.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_SucursalNombre) = True
    End Sub

    Private Sub tbx_SucursalN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_SucursalNombre.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Cliente.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_SucursalN_Leave(sender As Object, e As EventArgs) Handles tbx_SucursalNombre.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_SucursalN_TextChanged(sender As Object, e As EventArgs) Handles tbx_SucursalNombre.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Cliente_Click(sender As Object, e As EventArgs) Handles tbx_Cliente.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Cliente) = True
    End Sub

    Private Sub tbx_Cliente_TextChanged(sender As Object, e As EventArgs) Handles tbx_Cliente.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Cliente_Leave(sender As Object, e As EventArgs) Handles tbx_Cliente.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Cliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Cliente.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_NombreCorto.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Cliente_Enter(sender As Object, e As EventArgs) Handles tbx_Cliente.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Cliente) = True
    End Sub

    Private Sub tbx_NombreCorto_TextChanged(sender As Object, e As EventArgs) Handles tbx_NombreCorto.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NombreCorto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_NombreCorto.KeyPress
        varPub.SegundosSesion = 0

        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Direccion.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_NombreCorto_Enter(sender As Object, e As EventArgs) Handles tbx_NombreCorto.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreCorto) = True
    End Sub

    Private Sub tbx_NombreCorto_Leave(sender As Object, e As EventArgs) Handles tbx_NombreCorto.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NombreCorto_Click(sender As Object, e As EventArgs) Handles tbx_NombreCorto.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NombreCorto) = True
    End Sub

    Private Sub tbx_Direccion_Click(sender As Object, e As EventArgs) Handles tbx_Direccion.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Direccion) = True
    End Sub

    Private Sub tbx_Direccion_KeyPress(sender As Object, ByVal e As KeyPressEventArgs) Handles tbx_Direccion.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_ClaveSucursal.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Direccion_Leave(sender As Object, e As EventArgs) Handles tbx_Direccion.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Direccion_Enter(sender As Object, e As EventArgs) Handles tbx_Direccion.Enter
        tbx_Direccion.Focus()
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Direccion) = True
    End Sub

    Private Sub tbx_Direccion_TextChanged(sender As Object, e As EventArgs) Handles tbx_Direccion.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveSucursal_Click(sender As Object, e As EventArgs) Handles tbx_ClaveSucursal.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveSucursal) = True
    End Sub

    Private Sub tbx_ClaveSucursal_Enter(sender As Object, e As EventArgs) Handles tbx_ClaveSucursal.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveSucursal) = True
    End Sub

    Private Sub tbx_ClaveSucursal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ClaveSucursal.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_CiaTV.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_ClaveSucursal_Leave(sender As Object, e As EventArgs) Handles tbx_ClaveSucursal.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveSucursal_TextChanged(sender As Object, e As EventArgs) Handles tbx_ClaveSucursal.TextChanged
        varPub.SegundosSesion = 0
        If varPub.ConexionwebAdmin = 1 Then btn_Sincronizar.Enabled = True
    End Sub

    Private Sub tbx_CiaTV_Enter(sender As Object, e As EventArgs) Handles tbx_CiaTV.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_CiaTV) = True
    End Sub

    Private Sub tbx_CiaTV_Click(sender As Object, e As EventArgs) Handles tbx_CiaTV.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_CiaTV) = True
    End Sub

    Private Sub tbx_CiaTV_TextChanged(sender As Object, e As EventArgs) Handles tbx_CiaTV.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_CiaTV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_CiaTV.KeyPress
        varPub.SegundosSesion = 0

        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_ClaveCliente.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_CiaTV_Leave(sender As Object, e As EventArgs) Handles tbx_CiaTV.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveCliente_Click(sender As Object, e As EventArgs) Handles tbx_ClaveCliente.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveCliente) = True
    End Sub

    Private Sub tbx_ClaveCliente_Enter(sender As Object, e As EventArgs) Handles tbx_ClaveCliente.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_ClaveCliente) = True
    End Sub

    Private Sub tbx_ClaveCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_ClaveCliente.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Mail.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_ClaveCliente_Leave(sender As Object, e As EventArgs) Handles tbx_ClaveCliente.Leave
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_ClaveCliente_TextChanged(sender As Object, e As EventArgs) Handles tbx_ClaveCliente.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Mail_Click(sender As Object, e As EventArgs) Handles tbx_Mail.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Mail) = True
    End Sub

    Private Sub tbx_Mail_Enter(sender As Object, e As EventArgs) Handles tbx_Mail.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Mail) = True
    End Sub

    Private Sub tbx_Mail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Mail.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then
            tbx_Tel.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Mail_Leave(sender As Object, e As EventArgs) Handles tbx_Mail.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Mail_TextChanged(sender As Object, e As EventArgs) Handles tbx_Mail.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Tel_Enter(sender As Object, e As EventArgs) Handles tbx_Tel.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Tel) = True
    End Sub

    Private Sub tbx_Tel_Click(sender As Object, e As EventArgs) Handles tbx_Tel.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Tel) = True
    End Sub

    Private Sub tbx_Tel_TextChanged(sender As Object, e As EventArgs) Handles tbx_Tel.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Tel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Tel.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                btn_FechaInicioOperaciones.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_Tel_Leave(sender As Object, e As EventArgs) Handles tbx_Tel.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_ClaveSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ClaveSucursal.SelectedIndexChanged
        varPub.SegundosSesion = 0

        If Tab_Parametros.SelectedIndex = 0 Then Exit Sub

        If cmb_ClaveSucursal.Text = "Nuevo" Then
            'cuando se el agrega nuevo sucursal a la central
            tbx_ClaveSucursal.Visible = True
            tbx_ClaveSucursal.Location = cmb_ClaveSucursal.Location
            cmb_ClaveSucursal.Visible = False
            tbx_ClaveSucursal.Enabled = True

            tbx_SucursalNombre.Text = varPub.Nombre_Sucursal
            tbx_ClaveSucursal.Text = varPub.Cve_Sucursal
            tbx_IdCajero.Text = varPub.Id_Cajero
            tbx_NombreCorto.Text = varPub.Nombre_Corto
            tbx_ClaveSucursal.Focus()
        Else
            'al seleccionar una sucursal descargada
            tbx_ClaveSucursal.Visible = False
            cmb_ClaveSucursal.Visible = True
            cmb_ClaveSucursal.Location = tbx_ClaveSucursal.Location

            tbx_SucursalNombre.Text = (cmb_ClaveSucursal.SelectedValue).ToString.Split("/")(0)
            tbx_ClaveSucursal.Text = cmb_ClaveSucursal.Text
            tbx_ClaveCliente.Text = (cmb_ClaveSucursal.SelectedValue).ToString.Split("/")(1)
            tbx_Direccion.Text = (cmb_ClaveSucursal.SelectedValue).ToString.Split("/")(2)
            tbx_NombreCorto.Text = (cmb_ClaveSucursal.SelectedValue).ToString.Split("/")(3)

        End If

    End Sub

    Private Sub btn_FechaInicioOperaciones_Click(sender As Object, e As EventArgs) Handles btn_FechaInicioOperaciones.Click
        varPub.SegundosSesion = 0
        Tab_Parametros.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaInicioOperaciones.Text)
        frm_Fecha.Location = New Point(btn_FechaInicioOperaciones.Location.X + 13, (btn_FechaInicioOperaciones.Location.Y - frm_Fecha.Height + varTecl.ubicaY_Teclado + 5))
        frm_Fecha.ShowDialog()
        btn_FechaInicioOperaciones.Text = frm_Fecha.Fecha
        frm_Fecha.Dispose()
        Tab_Parametros.Enabled = True
    End Sub

    Private Sub btn_Sincronizar_Click(sender As Object, e As EventArgs) Handles btn_Sincronizar.Click
        varPub.SegundosSesion = 0

        If cmb_ClaveSucursal.SelectedValue = "Nuevo" OrElse tbx_ClaveSucursal.Text.Trim = "" Then
            fn_MsgBox("Seleccione o capture alguna clave de Sucursal", MessageBoxIcon.Error)
            Exit Sub
        End If

        ctrlTeclado.Hide()

        If varPub.Conectividad Then
            Tab_Parametros.Enabled = False
            Cursor = Cursors.WaitCursor
            If varPub.Cve_Sucursal = "" Then varPub.Cve_Sucursal = tbx_ClaveSucursal.Text.Trim

            If fn_VerificaConexionInternet() Then


                thread = New Thread(New ThreadStart(AddressOf Sincronizar))
                thread.Start()

            Else
                fn_MsgBox("No hay conexión a Internet", MessageBoxIcon.Error)
            End If

            Call fn_Parametros_LlenarCombo(cmb_Caset)
            cmb_Caset.SelectedValue = varPub.CasetID 'es el caset que se esta usando actualmente(falta el caset2)
            Tab_Parametros.Enabled = True
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub Sincronizar()
        Call fn_Menus_Open(14) 'DEscargas
        Call fn_Menus_Open(15) 'Subidas
    End Sub


    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        Dim frm As New frm_Actualizar
        frm.ShowDialog()
    End Sub

    Private Sub btn_AgregaCaset_Click(sender As Object, e As EventArgs) Handles btn_AgregaCaset.Click
        varPub.SegundosSesion = 0

        'descargar caset si los hay
        If varPub.ConexionwebAdmin = 1 Then
            If tbx_ClaveSucursal.Visible = False Then tbx_ClaveSucursal.Text = cmb_ClaveSucursal.Text
            If fn_VerificaConexionInternet() Then fn_SincronizarCasets_aLOCAL(tbx_ClaveSucursal.Text)
        End If

        Dim frm As New frm_CatalogoCaset
        frm.ShowDialog()
        Call fn_Parametros_LlenarCombo(cmb_Caset)
        If varPub.Cant_Validadores = 2 Then
            fn_Parametros_LlenarCombo(cmb_Caset2)
            cmb_Caset2.SelectedValue = varPub.Caset2ID
        End If

        cmb_Caset.SelectedValue = varPub.CasetID
        ' restaurar valores de posicion del teclado 15/02/2017  y el teclado ya no se valida
        ' porque viene de COMPLETO.

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = Tab_Parametros.Location.Y + Tab_Parametros.ItemSize.Height
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, (varTecl.ubicaY_Teclado + btn_ConectarBDD.Location.Y))

    End Sub

#End Region

#Region "Pestaña Tiempo-Fuente."

    Private Sub gbx_Tiempo_Click(sender As Object, e As EventArgs) Handles gbx_Tiempo.Click
        varPub.SegundosSesion = 0
        gbx_Tiempo.Focus()
        ctrlTeclado.Hide()


    End Sub

    Private Sub tbx_DiasExpira_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_DiasExpira.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                cmb_TiempoReceptor.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_DiasExpira_Leave(sender As Object, e As EventArgs) Handles tbx_DiasExpira.Leave
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_DiasExpira_TextChanged(sender As Object, e As EventArgs) Handles tbx_DiasExpira.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DiasExpira_Enter(sender As Object, e As EventArgs) Handles tbx_DiasExpira.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + cmb_TiempoSesion.Location.Y)
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DiasExpira) = True
    End Sub

    Private Sub tbx_DiasExpira_Click(sender As Object, e As EventArgs) Handles tbx_DiasExpira.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + cmb_TiempoSesion.Location.Y)
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DiasExpira) = True
    End Sub

    Private Sub cmb_lblFuente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_lblFuente.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_lblFuente_Click(sender As Object, e As EventArgs) Handles cmb_lblFuente.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_cmdFuente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_cmdFuente.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_cmdFuente_Click(sender As Object, e As EventArgs) Handles cmb_cmdFuente.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_MsgFuente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MsgFuente.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_MsgFuente_Click(sender As Object, e As EventArgs) Handles cmb_MsgFuente.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_TiempoReceptor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TiempoReceptor.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_TiempoReceptor_Click(sender As Object, e As EventArgs) Handles cmb_TiempoReceptor.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_TiempoSesion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TiempoSesion.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_TiempoSesion_Click(sender As Object, e As EventArgs) Handles cmb_TiempoSesion.Click
        varPub.SegundosSesion = 0
    End Sub

#End Region

#Region "Pestaña Datos del Cajero."

    Private Sub gbx_StatusVal1_Click(sender As Object, e As EventArgs) Handles gbx_StatusVal1.Click
        varPub.SegundosSesion = 0
        gbx_StatusVal1.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub gbx_StatusVal2_Click(sender As Object, e As EventArgs) Handles gbx_StatusVal2.Click
        varPub.SegundosSesion = 0
        gbx_StatusVal2.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub rdb_1val_Click(sender As Object, e As EventArgs) Handles rdb_1val.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        spc_Validadores.Panel2Collapsed = True
        rdb_NoVal2.Checked = True

        rdb_1val.Image = My.Resources.RadioButton_Checked_24x24
        rdb_2val.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_2val_Click(sender As Object, e As EventArgs) Handles rdb_2val.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Call fn_Parametros_LlenarCombo(cmb_Caset2)
        cmb_Caset2.SelectedValue = varPub.Caset2ID

        spc_Validadores.Panel2Collapsed = False

        gbx_StatusVal2.Visible = True
        rdb_SiVal2.Image = My.Resources.RadioButton_Checked_24x24
        rdb_SiVal2.Checked = True

        rdb_NoVal2.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_2val.Image = My.Resources.RadioButton_Checked_24x24
        rdb_1val.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_SiVal1_Click(sender As Object, e As EventArgs) Handles rdb_SiVal1.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_NoVal1.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_SiVal1.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    Private Sub rdb_NoVal1_Click(sender As Object, e As EventArgs) Handles rdb_NoVal1.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_NoVal1.Image = My.Resources.RadioButton_Checked_24x24
        rdb_SiVal1.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub tbx_Validador1_Click(sender As Object, e As EventArgs) Handles tbx_Validador1.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Validador1) = True
    End Sub

    Private Sub tbx_Validador1_Enter(sender As Object, e As EventArgs) Handles tbx_Validador1.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Validador1) = True
    End Sub

    Private Sub tbx_Validador1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Validador1.KeyPress
        varPub.SegundosSesion = 0

        If Asc(e.KeyChar) = Keys.Enter Then
            cmb_Caset.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If

    End Sub

    Private Sub tbx_Validador1_Leave(sender As Object, e As EventArgs) Handles tbx_Validador1.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Validador1_TextChanged(sender As Object, e As EventArgs) Handles tbx_Validador1.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_PuertoVal1_Click(sender As Object, e As EventArgs) Handles tbx_PuertoVal1.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_PuertoVal1) = True
    End Sub

    Private Sub tbx_PuertoVal1_Enter(sender As Object, e As EventArgs) Handles tbx_PuertoVal1.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_PuertoVal1) = True
    End Sub

    Private Sub tbx_PuertoVal1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_PuertoVal1.KeyPress
        varPub.SegundosSesion = 0
        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                cmb_Caset.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_PuertoVal1_Leave(sender As Object, e As EventArgs) Handles tbx_PuertoVal1.Leave
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_PuertoVal1_TextChanged(sender As Object, e As EventArgs) Handles tbx_PuertoVal1.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Caset_Click(sender As Object, e As EventArgs) Handles cmb_Caset.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_Caset_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmb_Caset.KeyPress
        varPub.SegundosSesion = 0
        If Asc(e.KeyChar) = Keys.Enter Then Call Guardar()
    End Sub

    Private Sub rdb_SiVal2_Click(sender As Object, e As EventArgs) Handles rdb_SiVal2.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_SiVal2.Image = My.Resources.RadioButton_Checked_24x24
        rdb_NoVal2.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_NoVal2_Click(sender As Object, e As EventArgs) Handles rdb_NoVal2.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_SiVal2.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_NoVal2.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    Private Sub tbx_Validador2_Click(sender As Object, e As EventArgs) Handles tbx_Validador2.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Validador2) = True
    End Sub

    Private Sub tbx_Validador2_Enter(sender As Object, e As EventArgs) Handles tbx_Validador2.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_Validador2) = True
    End Sub

    Private Sub tbx_Validador2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_Validador2.KeyPress
        varPub.SegundosSesion = 0

        If Asc(e.KeyChar) = Keys.Enter Then
            cmb_Caset2.Focus()
        Else
            e.KeyChar = UCase(e.KeyChar)
        End If
    End Sub

    Private Sub tbx_Validador2_Leave(sender As Object, e As EventArgs) Handles tbx_Validador2.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_Validador2_TextChanged(sender As Object, e As EventArgs) Handles tbx_Validador2.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_PuertoVal2_Click(sender As Object, e As EventArgs) Handles tbx_PuertoVal2.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_PuertoVal2) = True
    End Sub

    Private Sub tbx_PuertoVal2_Enter(sender As Object, e As EventArgs) Handles tbx_PuertoVal2.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_PuertoVal2) = True
    End Sub

    Private Sub tbx_PuertoVal2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_PuertoVal2.KeyPress
        varPub.SegundosSesion = 0

        Select Case Asc(e.KeyChar)
            Case Asc(0) To Asc(9), 8
                'Valores correctos Numéricos y Back
            Case Keys.Enter
                cmb_Caset2.Focus()
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub tbx_PuertoVal2_Leave(sender As Object, e As EventArgs) Handles tbx_PuertoVal2.Leave
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_PuertoVal2_TextChanged(sender As Object, e As EventArgs) Handles tbx_PuertoVal2.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_PegarSerieVal1_Click(sender As Object, e As EventArgs)
        tbx_Validador1.Text = varPub.TextoCopiado  'My.Computer.Clipboard.GetText()
    End Sub

    Private Sub btn_PegarSerieVal2_Click(sender As Object, e As EventArgs)
        tbx_Validador2.Text = varPub.TextoCopiado ' My.Computer.Clipboard.GetText()
    End Sub

#End Region

#Region "Pestaña Tipo de cambio."

    Private Sub gbx_TipoCambio_Click(sender As Object, e As EventArgs) Handles gbx_TipoCambio.Click
        varPub.SegundosSesion = 0
        gbx_TipoCambio.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_NuevoTC_Click(sender As Object, e As EventArgs) Handles tbx_NuevoTC.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + btn_GuardarTC.Location.Y + 10)
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NuevoTC) = True
    End Sub

    Private Sub tbx_NuevoTC_TextChanged(sender As Object, e As EventArgs) Handles tbx_NuevoTC.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_NuevoTC_Enter(sender As Object, e As EventArgs) Handles tbx_NuevoTC.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado + btn_GuardarTC.Location.Y + 10)
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_NuevoTC) = True
    End Sub

    Private Sub tbx_NuevoTC_Leave(sender As Object, e As EventArgs) Handles tbx_NuevoTC.Leave
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_NuevoTC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_NuevoTC.KeyPress
        varPub.SegundosSesion = 0

        If e.KeyChar = "." AndAlso tbx_NuevoTC.Text.Contains(".") Then
            e.Handled = True
        ElseIf Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            btn_GuardarTC.Focus()
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub btn_GuardarTC_Click(sender As Object, e As EventArgs) Handles btn_GuardarTC.Click
        varPub.SegundosSesion = 0

        If tbx_NuevoTC.Text = "" OrElse CDec(tbx_NuevoTC.Text) = 0 Then
            Call fn_MsgBox("Capture una cantidad numerica de forma correcta diferente a 0", MessageBoxIcon.Error, True, 2)
            tbx_NuevoTC.Focus()
            Exit Sub
        End If

        '---cuando es nuevo entra aqui----
        If tbx_AnteriorTC.Text = "0.0" Then
            If fn_TipoCambio_Insertar(tbx_NuevoTC.Text) Then
                Call fn_MsgBox("Se ha creado el tipo de cambio correctamente..", MessageBoxIcon.Information, True, 1)
                tbx_AnteriorTC.Text = tbx_NuevoTC.Text
                varPub.TipoCambio = tbx_NuevoTC.Text 'asigna tipo de cambio nuevo
                tbx_NuevoTC.Text = String.Empty
                tbx_NuevoTC.Focus()
                Exit Sub
            Else
                Call fn_MsgBox("Error al insertar el Tipo de cambio diferente ", MessageBoxIcon.Error, True, 2)
                tbx_NuevoTC.Focus()
                Exit Sub
            End If

        End If

        '---cuando se va a modificar el tipo de cambio
        If fn_TipoCambio_Modificar(tbx_NuevoTC.Text, tbx_MonedaTC.Tag) Then
            Call fn_MsgBox("Se ha cambiado el Tipo de cambio correctamente.", MessageBoxIcon.Information, True, 1)
            tbx_AnteriorTC.Text = tbx_NuevoTC.Text
            varPub.TipoCambio = tbx_NuevoTC.Text 'asigna tipo de cambio nuevo
            tbx_NuevoTC.Text = String.Empty
            tbx_NuevoTC.Focus()
        Else
            Call fn_MsgBox("Error al cambiar el Tipo de cambio.", MessageBoxIcon.Error, True, 1)
            tbx_NuevoTC.Focus()
        End If

    End Sub

#End Region

#Region "Pestaña Actualizar."

    Private Sub rdb_SIconectaAdmin_Click(sender As Object, e As EventArgs) Handles rdb_SIconectaAdmin.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        gbx_Prioridad.Enabled = True
        rdb_SIconectaAdmin.Image = My.Resources.RadioButton_Checked_24x24
        rdb_SIconectaAdmin.Checked = True
        rdb_NOconectaAdmin.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_NOconectaAdmin_Click(sender As Object, e As EventArgs) Handles rdb_NOconectaAdmin.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        gbx_Prioridad.Enabled = False
        rdb_NOconectaAdmin.Image = My.Resources.RadioButton_Checked_24x24
        rdb_NOconectaAdmin.Checked = True
        rdb_SIconectaAdmin.Image = My.Resources.RadioButton_UnChecked_24x24

    End Sub

    Private Sub rdb_local_Click(sender As Object, e As EventArgs) Handles rdb_local.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_local.Image = My.Resources.RadioButton_Checked_24x24
        rdb_web.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_web_Click(sender As Object, e As EventArgs) Handles rdb_web.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_web.Image = My.Resources.RadioButton_Checked_24x24
        rdb_local.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

#Region "DESCARGAR ARCHIVO DE FTP --> CAJERO LOCAL"

    Private Sub btn_ActualizaWeb_Click(sender As Object, e As EventArgs) Handles btn_ActualizaWeb.Click
        If varPub.cnx_SucursalWeb = "" Then
            Call fn_MsgBox("Se requiere conectar con Central, en la pestaña Conexion", MessageBoxIcon.Error)
        Else
            frm_BuscarActualizar.ShowDialog()
        End If


        'Call Actualizar( )
    End Sub

    Sub ActualizarInformacion()
        Dim myFileNVOVersion As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathDescargado)
        Dim Persistente As New cls_VariablesPersistentes()
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Query As String = "Update actualizaciones " &
                              "Set Version_Actual = '" & varPub.VersionNvo & "'," &
                              "Fecha_Actualizacion = '" & Format(Now.Date, "MM/dd/yyyy") & "'," &
                              "Fecha_Comprobacion = '" & Format(Now.Date, "MM/dd/yyyy") & "'" &
                              "where Clave_Sucursal = '" & varPub.Cve_Sucursal & "'"

        Dim cmd As SqlCommand = Crear_ComandoSQL(Query, CommandType.Text, cnn)
        Dim dt_DepositosId As DataTable = Ejecutar_ConsultaSQL(cmd)



        Query = "Insert Into actualizacionesD  (Clave_Sucursal , Version_Actual ,Fecha_Actualizacion) " &
                "Values('" & varPub.Cve_Sucursal & "','" & varPub.VersionNvo & "','" & Format(Now.Date, "MM/dd/yyyy") & "')"

        cmd = Crear_ComandoSQL(Query, CommandType.Text, cnn)
        Dim dt_DetallesD As DataTable = Ejecutar_ConsultaSQL(cmd)

        cnn.Dispose()
        cmd.Dispose()
        varPub.Comprobacion = Format(Now.Date, "yyyy/MM")
        'creamos el xml con los valoress incluidas del Ancho y alto
        Persistente.Persistir()

        'cargamos los valores que se crearon
        Persistente.Cargar()

    End Sub

    Public Sub Actualizar()
        'Aquí vamos hacer la actualizacion desde web(Verificar archivo exista, estar logueado y conexion a internet)
        varPub.SegundosSesion = 0
        If varPub.ConexionwebAdmin = 2 Then Exit Sub

        If fn_VerificaConexionInternet() = False Then
            Call fn_MsgBox("De momento no hay conexion a internet..", MessageBoxIcon.Error)
        End If

        fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO PROCESO DE ACTUALIZACION WEB.")

        Try
            Tab_Parametros.Enabled = False
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO PROCESO DE DESCARGA DE ARCHIVO.")
            btn_ActualizaWeb.Enabled = True
            Tab_Parametros.Enabled = False
            btn_Guardar.Enabled = False
            btn_Cerrar.Enabled = False

            'nombre de nuestro exe a buscar en el ftp
            Dim nombreEXE As String = Application.ProductName
            Dim ftpDescarga As String = varPub.Ubicacion_ftp & "/UpdateCashFlow/" & nombreEXE & ".exe"
            Dim rutaApp As String = Application.StartupPath
            RutaFiledescargado = rutaApp & "\DescargasCashFlow" 'es un acarpeta fija adonde se descarga elnuevo exe

            Dim buffer(1023) As Byte 'bloques de descarga de 1KB o sea 1024bytes 
            Dim bytesIn As Integer
            Dim output As IO.Stream = Nothing

            ' pgr_Descargando.Value = 0 'o Cualquier otro metodo a visualizar que exista

            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "REALIZANDO PETICIÓN PARA OBTENER EL TAMAÑO DEL ARCHIVO A DESCARGAR.")
            '-----------Peticion1 de Traer el tamaño de archivo eb bytes()----------------

            Dim ftpPeticion As System.Net.FtpWebRequest = DirectCast(System.Net.FtpWebRequest.Create(ftpDescarga), System.Net.FtpWebRequest)
            ftpPeticion.Credentials = New System.Net.NetworkCredential(varPub.Usuario_ftp, varPub.Password_ftp)
            ftpPeticion.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
            Dim ftpRespuesta As System.Net.FtpWebResponse = DirectCast(ftpPeticion.GetResponse(), Net.FtpWebResponse)
            Dim sizeFile As Integer = ftpRespuesta.ContentLength 'Obtenemos tamaño de archivo--->

            Dim ftpStream As IO.Stream = ftpRespuesta.GetResponseStream()
            bytesIn = ftpStream.Read(buffer, 0, 1024)
            ftpStream.Close() '------cierra el ftpstream despues de medir el archivo

            '*****------------------------------------------*****

            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "REALIZANDO 2DA PETICIÓN AL WEB PARA INICIAR DESCARGA DE ARCHIVO.")
            '-----Peticion2 de Descarga reinitialise ftp request-----------------

            ftpPeticion = DirectCast(System.Net.FtpWebRequest.Create(ftpDescarga), System.Net.FtpWebRequest)
            ftpPeticion.Credentials = New System.Net.NetworkCredential(varPub.Usuario_ftp, varPub.Password_ftp)
            ftpPeticion.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
            ftpRespuesta = DirectCast(ftpPeticion.GetResponse(), Net.FtpWebResponse)
            ftpStream = ftpRespuesta.GetResponseStream()
            '----------------------------------------------

            '----Verificar que se tenga permiso de Write en C:\, verificar si existe directorio
            'tambien si existe el file descargado, luego renombrarse_

            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICANDI QUE EL DIRECTORIO DE DESCARGAS EXISTA.")
            NombreExeDescargado = nombreEXE & CustomFecha & CustomHora & "NVO.exe"
            PathDescargado = RutaFiledescargado & "\" & NombreExeDescargado
            If System.IO.Directory.Exists(RutaFiledescargado) Then

                ' se crea Nuevo archivo EN EL Path especificado
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CREAR EL ARCHIVO A DESCARGAR.")
                output = System.IO.File.Create(PathDescargado)

            Else
                'SINO EXISTE DIRECTORIO LO CRAMOS  NUEVO
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CREANDO EL DIRECTORIO PARA DESCARGA DE ARCHIVO ACTUALIZADOS.")
                System.IO.Directory.CreateDirectory(RutaFiledescargado)

                'CREAMOS EL ARCHIVO EN EL PATH EL Path especificado
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CREANDO EL ARCHIVO A DESCARGAR.")
                output = System.IO.File.Create(PathDescargado)

            End If

            '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            'Establecer el valor inicial a 1 para entrar en bucle. Salimos del bucle cuando bytesIn es cero
            bytesIn = 1
            Dim totalBytesIn As Integer = 0 ' Total number of bytes received (= filesize)

            Try
                '------------->
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO DESCARGA DE KB DEL ARCHIVO PARA ACTUALIZAR.")
                Do Until bytesIn < 1

                    bytesIn = ftpStream.Read(buffer, 0, 1024)
                    If bytesIn > 0 Then
                        totalBytesIn += bytesIn 'le va pasando la cantidad descargada ---> en base a 1024kb

                        output.Write(buffer, 0, bytesIn) 'va leyendo del bufer y lo va escribiendo a la salida

                        'pgr_Descargando.Value = CLng((totalBytesIn * 100) / sizeFile)
                        'lbl_porcientoDown.Text = pgr_Descargando.Value.ToString & " %"
                        Application.DoEvents()
                    End If
                Loop
                '<------------------

                ftpRespuesta.Close()
                output.Close()  'cierra la salida del archivo
                ftpStream.Close() 'cierra el ftpstream de la segunda peticon

            Catch ex As Exception
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ERROR EN EL PROCESO DE DESCARGA DEL ARCHIVO.")

                Call fn_MsgBox(ex.Message.ToString, MessageBoxIcon.Error)
                Call HabilitaBotones()
                Exit Sub
            End Try
            'En este punto ya se descargo el archivo 

            If sizeFile = totalBytesIn Then
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIAR PROCESO DE REEMPLAZO DE ARCHIVO EJECUTABLES Modulo_CashFlow")

                'Qiere decir que  si se desscargo de forma completa el archivo
                PathFile_Actualiza = RutaFiledescargado & "\" & NombreExeDescargado

                '-------Al llegar aqui hacer de proceso de copiado e iniciar la actualizacion
                'Call btn_UpdateSistem_Click(btn_UpdateSistem, New EventArgs)antes del 26/10/2015

                If SistemaCashFlow_Actualizar("Actu4liz4ci0n_W3b") Then
                    'Cambiar Status='N' en sucursales porque ya se actualizo el sistema
                    '''''''''''''''''''''' Call CambiaestatusActualizar("N") 'pone actualizar='N'

                    'SI TODO ES CORRECTO
                    Call fn_MsgBox("Actualizando sistema ... Reiniciando equipo..", MessageBoxIcon.Information, True, 1)

                    'cerramos el exe viejo y finalizamos
                    ctrlTeclado.Hide()
                    Me.Close()

                    'reiniciando equipo tras actualizar
                    fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "REINICIANDO EQUIPO DESPUES DE UNA ACTUALIZACIÓN O RESTAURACIÓN.")
                    System.Diagnostics.Process.Start("shutdown.exe", " -r -t 0 -f")

                    '---------------------------
                    End 'detiene la ejecucion
                Else
                    'Call fn_MsgBox("Error al intentar actualizar el sistema desde Web..", MessageBoxIcon.Error, True, 2)
                    Tab_Parametros.Enabled = True
                    Call HabilitaBotones()
                End If

            End If
            Tab_Parametros.Enabled = True
        Catch ex As Net.WebException
            Tab_Parametros.Enabled = True
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ERROR DE ENLACE FTP. " & ex.Message.ToUpper)
            fn_MsgBox(ex.Message.ToString, MessageBoxIcon.Error)
            Call HabilitaBotones()
        End Try

    End Sub

    Private Sub btn_ActualizarLocal_Click(sender As Object, e As EventArgs) Handles btn_ActualizarLocal.Click
        If SistemaCashFlow_Actualizar("Actu4liz4ci0n_L0c4l") Then
            Call fn_MsgBox("Actualizando sistema ... Reiniciando equipo..", MessageBoxIcon.Information, True, 1)

            'cerramos el exe viejo y finalizamoOs
            ctrlTeclado.Hide()
            Me.Close()

            'reiniciando equipo tras actualizar
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "REINICIAR EQUIPO DESPUES DE UNA ACTUALIZACIÓN O RESTAURACIÓN.")
            System.Diagnostics.Process.Start("shutdown.exe", " -r -t 0 -f")

            '---------------------------
            End 'detiene la ejecucion
        Else
            ' Call fn_MsgBox("Error al intentar actualizar el sistema desde Local..", MessageBoxIcon.Error, True, 2)
            Tab_Parametros.Enabled = True
            Call HabilitaBotones()
        End If
    End Sub

    Private Function SistemaCashFlow_Actualizar(ByVal TipoActualizacion As String) As Boolean
        varPub.SegundosSesion = 0
        Try
            Tab_Parametros.Enabled = False
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO ACTUALIZACIÓN DE SISTEMA CASHFLOW EN EL CAJERO.")

            '*************INICIO****************************
            Dim PathAplicacion As String = Application.StartupPath
            Dim PathOrigen_ExeActualiza As String = ""

            '1.-Obtiene Nombre del archivo ejecutable .exe que esta en Uso
            Dim NombreFile_Original As String = Application.ProductName

            '2.- Asigna la directorio de ruta de Respaldo
            Dim RutaRespaldo As String = PathAplicacion & "\RespaldosCashFlow"

            If Not (System.IO.Directory.Exists(RutaRespaldo)) Then
                '3.-Si NO existe Directorio crearlo Nuevo
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CREAR DIRECTOPIO NUEVO PARA RESPALDOS.")
                System.IO.Directory.CreateDirectory(RutaRespaldo)

            End If

            '*********SI ES ACTUALIZACION LOCAL HACER*****************
            If TipoActualizacion = "Actu4liz4ci0n_L0c4l" Then
                'Obtener Path del Archivo .exe 24/10/2015

                Dialogo = New OpenFileDialog With {.Title = "Seleccione un Archivo.", .Filter = Filtro, .Multiselect = False}
                If Dialogo.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                    Tab_Parametros.Enabled = True
                    Return False
                End If

                If System.IO.Path.GetFileNameWithoutExtension(Dialogo.FileName) <> NombreFile_Original Then
                    fn_MsgBox("Nombre de Archivo incorrecto.", MessageBoxIcon.Error, True, 2)
                    fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "EL NOMBRE DE ARCHIVO ES INCORRECTO, USTED SELECCIONO: " & Dialogo.FileName)
                    Return False
                End If

                PathFile_Actualiza = Dialogo.FileName

                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "SELECCIONA EL ARCHIVO .exe ACTUAL DESDE LA UBICACIÓN: " & PathFile_Actualiza)
                'VALIDAR QUE EL ARCHIVO EXISTA
                If Not (System.IO.File.Exists(PathFile_Actualiza)) Then
                    fn_MsgBox("No existe archivo para actualizar", MessageBoxIcon.Exclamation, True, 2)
                    Return False
                End If
            End If
            '---------------------------------


            '**** Pendiente ..1ro Se actualiza la BDD, Tablas, columnas, Registros  etc..
            If Not (TipoActualizacion = "R3st4ur4ci0n") Then
                'NO ejecutar cn_ cuando es restauracion

                ''---- si no hay modificacion a BDD, comentar este codigo ----
                'Call cn_Log.fn_EscribirLog(UsuarioClave, "Parametros", "Iniciando proceso de alteración de base de datos sqlCE")
                'If Not cn_Actualizacion.fn_AlterarEsctructura_SQLCE() Then

                '    Call cn_Log.fn_EscribirLog(UsuarioClave, "Parametros", "FIN: Ocurrió un error al modificar la estructura de la base de datos")
                '    Call fn_MsgBox("Ocurrió un error al modificar la estructura de la base de datos.", MessageBoxIcon.Error, True, 3)
                '    Return False
                'End If
                'Call cn_Log.fn_EscribirLog(UsuarioClave, "Parametros", "Fin de proceso de alteración de base de datos sqlce")
                ''---------------
            End If
            '----------------------------------

            '********PROCESO DE COPIADO, REEMPLAZO DE .EXES***************
            'A).-Crear variable para el Nuevo Nombre del .exe original usado.
            'Cesar 21/04/2017
            Dim BuscaArchivoDown As String = NombreFile_Original
            Dim Persistente As New cls_VariablesPersistentes()

            'FileVersionInfo.GetVersionInfo(System.IO.Path.Combine(PathDescargado))
            'Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(NombreExeDescargado)
            Dim myFileNVOVersion As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathDescargado)
            ' Print the file name and version number.
            'MsgBox("File: " + myFileVersionInfo.FileDescription + vbLf + "Version number: " + myFileVersionInfo.FileVersion)
            Dim myFileVersion As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathAplicacion & "\" & BuscaArchivoDown & ".exe")

            varPub.VersionNvo = myFileNVOVersion.FileVersion.Replace(".", "")
            varPub.VersionAnt = myFileVersion.FileVersion.Replace(".", "")
            'creamos el xml con los valoress incluidas del Ancho y alto
            Persistente.Persistir()

            'cargamos los valores que se crearon
            Persistente.Cargar()
            If varPub.VersionAnt <= varPub.VersionNvo Then

                fn_MsgBox("No hay actualizaciones Nuevas", MessageBoxIcon.Exclamation, True, 2)

                Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
                Dim cmd As SqlCommand = Nothing
                Dim Query As String = "Update actualizaciones" &
                                      " Set Fecha_Comprobacion = '" & Format(Now.Date, "MM/dd/yyyy") & "'" &
                                      " where Clave_Sucursal = '" & varPub.Cve_Sucursal & "'"
                cmd = Crear_ComandoSQL(Query, CommandType.Text, cnn)
                Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)
                cnn.Dispose()
                cmd.Dispose()

                varPub.Comprobacion = Format(Now.Date, "yyyy/MM")
                'creamos el xml con los valoress incluidas del Ancho y alto
                Persistente.Persistir()

                'cargamos los valores que se crearon
                Persistente.Cargar()
                Return False

            End If
            BuscaArchivoDown = NombreFile_Original & "_DWN"
            Dim Newname_FileDown As String = ""

            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI YA HABIA UN ARCHIVO DESCARGADO, Y/O REMOVERLO.")

            'B).- Si el Archivo ya existe
            If System.IO.File.Exists(PathAplicacion & "\" & BuscaArchivoDown & ".exe") Then
                'C).-Renombrar el Archivo
                Newname_FileDown = BuscaArchivoDown & CustomFecha & CustomHora & ".exe"
                'D).- Moverlo al Directorio de Ruta respaldo( ya que haveces no se pued eliminar)
                System.IO.File.Move(PathAplicacion & "\" & BuscaArchivoDown & ".exe", RutaRespaldo & "\" & Newname_FileDown)
            End If

            'FileIO.FileSystem.MoveFile("", "")ejemplo

            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "COPIAR EL NUEVO ARCHIVO DESCARGADO O DE DISPOSITIVO: " & PathFile_Actualiza & " HACIA EL PATH: " & PathAplicacion & "\" & NombreFile_Original & "_DWN" & ".exe")
            'E).- Copiar el Archivo Nuevo de usb(pft://,D:\, E:\, F:\, etc) ' al path del exe instalado o sea en C:\
            '     'es decir se copia como «Modulo_CashFlow_DWN.exe»
            System.IO.File.Copy(PathFile_Actualiza, PathAplicacion & "\" & NombreFile_Original & "_DWN" & ".exe")

            'F)._Al nombre Original se le agrega la fecha y hora.
            Dim NewName_Original As String = NombreFile_Original & CustomFecha & CustomHora & ".exe"

            'G).-Renombramos el .exe Original usado a
            'Modulo_CashFlow ---> «Modulo_CashFlow_26-10-2015_15-49-35»
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "RENOMBRAR EL ARCHIVO ORIGINAL QUE ESTA EJECUTANDOSE: " & PathAplicacion & "\" & NombreFile_Original & ".exe ,POR EL SIGUIENTE NOMBRE: " & PathAplicacion & "\" & NewName_Original)
            FileSystem.Rename(PathAplicacion & "\" & NombreFile_Original & ".exe", PathAplicacion & "\" & NewName_Original)

            'H).-Renombramos el copiado(descargado) al Nombre Original
            'es decir se le quita el « _DWN »
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "RENOMBRAR EL ARCHIVO COPIADO: " & PathAplicacion & "\" & NombreFile_Original & "_DWN" & ".exe CON EL NOMBRE ORIGINAL " & PathAplicacion & "\" & NombreFile_Original & ".exe")
            FileSystem.Rename(PathAplicacion & "\" & NombreFile_Original & "_DWN" & ".exe", PathAplicacion & "\" & NombreFile_Original & ".exe")

            'I).- Si el directorio ya se creo o ya existia (Mover el archivo a la Nueva Ruta)
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "MOVER EL .exe ORIGINAL RENOMBRADO CON NOMBRE Y FECHA_HHORA" & PathAplicacion & "\" & NewName_Original & " A LA CARPETA RESPALDOS: " & RutaRespaldo & "\" & NewName_Original)

            System.IO.File.Move(PathAplicacion & "\" & NewName_Original, RutaRespaldo & "\" & NewName_Original)

            Call ActualizarInformacion()

            '================06/10/2016=====
            ' En este recuadro se cre aun respaldo completo
            ' de la bdd, ejecutable y el persistente(.sdf, .exe, .xml)
            Dim RespaldosNuevos As String = PathAplicacion & "\RespaldosCashFlow\Respaldo" & CustomFecha & CustomHora
            Try
                System.IO.Directory.CreateDirectory(RespaldosNuevos)
                System.IO.File.Copy(PathAplicacion & "\" & NombreFile_Original & ".exe", RespaldosNuevos & "\" & NombreFile_Original & ".exe")
                System.IO.File.Copy(PathAplicacion & "\CashFlow.sdf", RespaldosNuevos & "\CashFlow.sdf")
                System.IO.File.Copy(PathAplicacion & "\ArchivoPersistente.xml", RespaldosNuevos & "\ArchivoPersistente.xml")
            Catch ex As Exception

            End Try
            '=============================

            '*****************************************************************

            'Call Ocultar_Taskbar.Hide() 'ocultamos la barra de tareas
            TipoActualizacion = "" 'limpiamos despues de actualizar

            Return True 'Si todo es correcto
        Catch ex As Exception
            Call fn_MsgBox("Error al intentar actualizar el sistema ..", MessageBoxIcon.Error, True, 2)
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ERROR AL ACTUALIZAR O RESTAURAR, " & ex.Message.ToUpper)
            Return False
        End Try
    End Function


#End Region

#End Region

#Region "Pestaña Impresora."

    Private Sub cmb_MododeImprimir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MododeImprimir.SelectedIndexChanged
        varPub.SegundosSesion = 0



        If cmb_MododeImprimir Is Nothing Then Exit Sub
        If cmb_MododeImprimir.SelectedValue = 2 Then
            cmb_LineasBlanco.Enabled = False
            cmb_MargenIzq.Enabled = False
            gbx_Sizepapel.Enabled = False
        Else
            cmb_LineasBlanco.Enabled = True
            cmb_MargenIzq.Enabled = True
            gbx_Sizepapel.Enabled = True
        End If


    End Sub

    Private Sub gbx_Papel_Click(sender As Object, e As EventArgs) Handles gbx_Papel.Click
        varPub.SegundosSesion = 0
        gbx_Papel.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub cmb_TipoWindows_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TipoWindows.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_TipoWindows_Click(sender As Object, e As EventArgs) Handles cmb_TipoWindows.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_MargenIzq_Click(sender As Object, e As EventArgs) Handles cmb_MargenIzq.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub cmb_MargenIzq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MargenIzq.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub rdb_58mm_Click(sender As Object, e As EventArgs) Handles rdb_58mm.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_58mm.Image = My.Resources.RadioButton_Checked_24x24
        rdb_80mm.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_80mm_Click(sender As Object, e As EventArgs) Handles rdb_80mm.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_80mm.Image = My.Resources.RadioButton_Checked_24x24
        rdb_58mm.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub btn_AgregarLogo_Click(sender As Object, e As EventArgs) Handles btn_AgregarLogo.Click
        frm_Login.tmr_SesionGeneral.Enabled = False

        Dialogo = New OpenFileDialog With {.Title = "Buscar Imagen.", .Filter =
                                         "Archivos de Imagenes(*.jpg;*.jpeg;*.bmp;*.png)|*.jpg;*jpeg;*.bmp;*.png", .Multiselect = False}

        If Dialogo.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            frm_Login.tmr_SesionGeneral.Enabled = True
            Exit Sub
        End If

        If Dialogo.FileName <> "" Then
            logoRuta = Dialogo.FileName 'ruta imagen
            pct_ImgEmpresa.Image = Image.FromFile(logoRuta)
        End If

        frm_Login.tmr_SesionGeneral.Enabled = True
    End Sub

    Private Sub btn_EliminaLogo_Click(sender As Object, e As EventArgs) Handles btn_EliminaLogo.Click
        varPub.SegundosSesion = 0
        logoRuta = ""
        pct_ImgEmpresa.Image = Nothing
    End Sub

    Private Sub rdb_SIdetalle_Click(sender As Object, e As EventArgs) Handles rdb_SIdetalle.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_SIdetalle.Image = My.Resources.RadioButton_Checked_24x24
        rdb_NOdetalle.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_NOdetalle_Click(sender As Object, e As EventArgs) Handles rdb_NOdetalle.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
        rdb_SIdetalle.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_NOdetalle.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    Private Sub btn_DestinoLog_Click(sender As Object, e As EventArgs) Handles btn_DestinoLog.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        frm_Login.tmr_SesionGeneral.Enabled = False

        Dim Dialogo As New FolderBrowserDialog With {.Description = "Destino del Archivo.", .ShowNewFolderButton = True}
        If Dialogo.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            frm_Login.tmr_SesionGeneral.Enabled = True
            Exit Sub
        End If

        frm_Login.tmr_SesionGeneral.Enabled = True
        varPub.SegundosSesion = 0
        '-------------------
        Ruta_Default = varPub.Ruta_Log
        varPub.Ruta_Log = Dialogo.SelectedPath

        If varPub.Ruta_Log.Length = 3 Then
            varPub.Ruta_Log = varPub.Ruta_Log & "CashFlowv2Logs"
        Else
            varPub.Ruta_Log = varPub.Ruta_Log & "\CashFlowv2Logs"
        End If
        lbl_RutaLog.Text = varPub.Ruta_Log

    End Sub

#End Region



    Private Sub Rdb_CorteSi_Click(sender As Object, e As EventArgs) Handles Rdb_CorteSi.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Rdb_CorteSi.Checked = True
        Rdb_CorteNo.Checked = False
        Rdb_CorteSi.Image = My.Resources.RadioButton_Checked_24x24
        Rdb_CorteNo.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub Rdb_CorteNo_Click(sender As Object, e As EventArgs) Handles Rdb_CorteNo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Select Case fn_MsgBox("Confirma que desea dejar de manejar Cortes (Se cerrara Corte actual)?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, , Tiempo_Timer:=20, btnAceptarVisible:=True, btnCancelarVisible:=True)
            Case MsgBoxResult.Yes
            Case False
                Exit Sub
        End Select

        Rdb_CorteSi.Checked = False
        Rdb_CorteNo.Checked = True
        Rdb_CorteSi.Image = My.Resources.RadioButton_UnChecked_24x24
        Rdb_CorteNo.Image = My.Resources.RadioButton_Checked_24x24

    End Sub

    Private Sub rdb_ManejaDepositoManualSi_Click(sender As Object, e As EventArgs) Handles rdb_ManejaDepositoManualSi.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        rdb_ManejaDepositoManualSi.Checked = True
        rdb_ManejaDepositoManualNo.Checked = False
        rdb_ManejaDepositoManualNo.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_ManejaDepositoManualSi.Image = My.Resources.RadioButton_Checked_24x24

    End Sub

    Private Sub rdb_ManejaDepositoManualNo_Click(sender As Object, e As EventArgs) Handles rdb_ManejaDepositoManualNo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        rdb_ManejaDepositoManualSi.Checked = False
        rdb_ManejaDepositoManualNo.Checked = True
        rdb_ManejaDepositoManualSi.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_ManejaDepositoManualNo.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    Private Sub rdb_WebServiceSi_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        rdb_WebServiceSi.Checked = True
        rdb_WebServiceNo.Checked = False
        rdb_WebServiceSi.Image = My.Resources.RadioButton_Checked_24x24
        rdb_WebServiceNo.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub rdb_WebServiceNo_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0
        rdb_WebServiceSi.Checked = False
        rdb_WebServiceNo.Checked = True
        rdb_WebServiceSi.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_WebServiceNo.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    Private Sub rdbImporteManualSi_Click(sender As Object, e As EventArgs) Handles rdb_ManejaFolioManualSi.Click
        varPub.SegundosSesion = 0
        rdb_ManejaFolioManualSi.Checked = True
        rdb_ManejaFolioManualNo.Checked = False
        ' gbx_verificarfolio.Enabled = True
        rdb_ManejaFolioManualNo.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_ManejaFolioManualSi.Image = My.Resources.RadioButton_Checked_24x24
        gbx_verificarfolio.Enabled = True
    End Sub

    Private Sub rdbImporteManualNo_Click(sender As Object, e As EventArgs) Handles rdb_ManejaFolioManualNo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        rdb_ManejaFolioManualSi.Checked = False
        rdb_ManejaFolioManualNo.Checked = True
        'gbx_verificarfolio.Enabled = False
        rdb_ManejaFolioManualSi.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_ManejaFolioManualNo.Image = My.Resources.RadioButton_Checked_24x24
        ''09-09-19
        rdb_validarfn.Checked = False
        rdb_validarfsi.Checked = False
        rdb_validarfsi.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_validarfn.Image = My.Resources.RadioButton_UnChecked_24x24
        gbx_verificarfolio.Enabled = False
    End Sub

    '------BUSCAR PUERTOS--JAVIER ZAPATA--28/12/2018-----------------------------------
    Private Sub BuscarPuertos() Handles pic_BuscarPuertos.Click
        Call fn_EscribirLog(varPub.UsuarioClave, "BUSCANDO PUERTOS", "PARAMETROS - PUERTOS COM")
        If cmb_puertoSensor.Items.Count > 0 Then
            cmb_puertoSensor.DataSource = Nothing
        End If

        Dim Dt_Puertos As New DataTable
        Dt_Puertos.Columns.Add("Display")
        cmb_puertoSensor.DisplayMember = "Display"
        Dim Dr As DataRow = Dt_Puertos.NewRow
        Dr("Display") = "Ninguno"
        Dt_Puertos.Rows.Add(Dr)
        For Each Puerto In My.Computer.Ports.SerialPortNames
            Dim DRows As DataRow = Dt_Puertos.NewRow
            DRows("Display") = Puerto.ToString
            Dt_Puertos.Rows.Add(DRows)
        Next
        cmb_puertoSensor.DataSource = Dt_Puertos

        If Dt_Puertos.Rows.Count > 1 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "BUSCANDO PUERTOS", "PUERTOS - SE ENCONTRARON PUERTOS DISPONIBLES")
        Else
            Call fn_EscribirLog(varPub.UsuarioClave, "BUSCANDO PUERTOS", "PUERTOS - NO SE ENCONTRARON PUERTOS DISPONIBLES")
        End If
    End Sub

    Private Sub btn_TeamViewer_Click(sender As Object, e As EventArgs) Handles btn_TeamViewer.Click
        AddHandler miTimer.Tick, AddressOf Visibilizar_Formulario

        Dim Formularios = My.Application.OpenForms.Count - 1

        For i As Byte = 0 To Formularios

            If My.Application.OpenForms(Formularios).Modal OrElse Not My.Application.OpenForms(Formularios).Modal Then
                My.Application.OpenForms(Formularios).Opacity = 0.1
                My.Application.OpenForms(Formularios).Enabled = False
                Formularios -= 1
            End If
        Next

        miTimer.Interval = 10000
        miTimer.Start()
    End Sub

    Private Sub Visibilizar_Formulario()

        Dim Formularios = My.Application.OpenForms.Count - 1

        For i As Byte = 0 To Formularios
            If My.Application.OpenForms(i).Modal OrElse Not My.Application.OpenForms(i).Modal Then
                My.Application.OpenForms(i).Opacity = 1.0
                My.Application.OpenForms(i).Enabled = True
                miTimer.Stop()
            End If

        Next

    End Sub

    Private Sub Rdb_validarfsi_Click(sender As Object, e As EventArgs) Handles rdb_validarfsi.Click
        rdb_validarfsi.Checked = True
        rdb_validarfn.Checked = False
        rdb_validarfn.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_validarfsi.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    Private Sub Rdb_validarfn_Click(sender As Object, e As EventArgs) Handles rdb_validarfn.Click
        rdb_validarfsi.Checked = False
        rdb_validarfn.Checked = True
        rdb_validarfsi.Image = My.Resources.RadioButton_UnChecked_24x24
        rdb_validarfn.Image = My.Resources.RadioButton_Checked_24x24
    End Sub

    'rdb_ManejaFolioManualNo.Image = My.Resources.RadioButton_UnChecked_24x24
    ' rdb_ManejaFolioManualSi.Image = My.Resources.RadioButton_Checked_24x24
    'Private Sub Rdb_vfoliosi_Click(sender As Object, e As EventArgs) Handles rdb_vfoliosi.Click
    '    rdb_vfoliosi.Checked = True
    '    rdb_vfoliono.Checked = False
    'End Sub

    'Private Sub Rdb_vfoliono_Click(sender As Object, e As EventArgs) Handles rdb_vfoliono.Click
    '    rdb_vfoliosi.Checked = False
    '    rdb_vfoliono.Checked = True
    'End Sub

    Private Sub Rdb_sin_s_Click(sender As Object, e As EventArgs) Handles Rdb_sin_s.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Rdb_sin_s.Checked = True
        Rdb_sin_n.Checked = False
        Rdb_sin_s.Image = My.Resources.RadioButton_Checked_24x24
        Rdb_sin_n.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub Rdb_sin_n_Click(sender As Object, e As EventArgs) Handles Rdb_sin_n.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Rdb_sin_n.Checked = True
        Rdb_sin_s.Checked = False
        Rdb_sin_n.Image = My.Resources.RadioButton_Checked_24x24
        Rdb_sin_s.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub Rdb_rds_Click(sender As Object, e As EventArgs) Handles Rdb_rds.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Rdb_rds.Checked = True
        Rdb_rdn.Checked = False
        Rdb_rds.Image = My.Resources.RadioButton_Checked_24x24
        Rdb_rdn.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub

    Private Sub Rdb_rdn_Click(sender As Object, e As EventArgs) Handles Rdb_rdn.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        Rdb_rdn.Checked = True
        Rdb_rds.Checked = False
        Rdb_rdn.Image = My.Resources.RadioButton_Checked_24x24
        Rdb_rds.Image = My.Resources.RadioButton_UnChecked_24x24
    End Sub


End Class
