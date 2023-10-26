Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class cls_CashWeb
#Region "Sincronizar Ultima Conexión"

    Private Shared Function GetExternalIp() As String
        Try
            Dim ExternalIP As String
            ExternalIP = (New System.Net.WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIP = (New System.Text.RegularExpressions.Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                     .Matches(ExternalIP)(0).ToString()
            Return ExternalIP
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_Monitoreo_ClaveExiste() As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Monitoreo_ClaveExistente", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)

            Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_Monitoreo_Guardar() As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Monitoreo_Create", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, varPub.Nombre_Corto)
            Ejecutar_NonQuerySQL(cmd)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function fn_Monitoreo_Actualizar() As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)

        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Monitoreo_Update", CommandType.StoredProcedure, cnn)
            'varPub.IP_Publica = GetExternalIp()

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            'Crear_ParametroSQL(cmd, "@IP_Publica", SqlDbType.VarChar, varPub.IP_Publica)

            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shared Sub fn_AfectarMonitoreo()
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)

        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("[CashflowWEB_AfectarMonitoreo]", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@ClaveSucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, varPub.Nombre_Corto)
            Ejecutar_NonQuerySQL(cmd)
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 79, varPub.IdPantalla, "AFECTAR MONITOREO - " + "FIN - OCURRIÓ UN ERROR AL AFECTAR MONITOREO DE CONEXÍÓN: " + ex.ToString() + " RFC: " + varPub.CUNICA)
            Call fn_EscribirLog(varPub.UsuarioClave, "AFECTAR MONITOREO", "FIN - OCURRIÓ UN ERROR AL AFECTAR MONITOREO DE CONEXÍÓN: " + ex.ToString() + " RFC: " + varPub.CUNICA)
        End Try
    End Sub

#End Region



#Region "Actualizar Datos de Sucursal"

    Public Shared Function fn_ActualizaStatus_Actualizar(ByVal Actualizar As String) As Boolean
        Try
            'funcion que cambia de estatus de actualizacion del sistema
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIAR CAMBIO DE ESTATUS DEL CAMPO «Actualizar»  EN LA BDD WEB SUCURSALES CON VALOR: =" & Actualizar)

            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Sucursales_StatusActualizar", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Actualizar", SqlDbType.VarChar, Actualizar)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "SE CAMBIO CORRECTAMENTE EL VALOR DEL CAMPO «Actualizar» EN LA BDD WEB, CON VALOR = " & Actualizar)

            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " ERROR AL CAMBIAR EL VALOR DEL CAMPO «Actualizar» EN LA BDD WEB, CON VALOR = " & Actualizar)
            Return False
        End Try

    End Function

    Public Shared Function fn_ActualizaStatus_Respaldar(ByVal respaldar As String) As Boolean
        Try
            'funcion que cambia de estatus de Respaldar bdd del sistema
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIAR CAMBIO DE ESTATUS DEL CAMPO «Respaldar»  EN LA BDD WEB SUCURSALES CON VALOR: =" & respaldar)

            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Sucursales_StatusRespaldar", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Respaldar", SqlDbType.VarChar, respaldar)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "SE CAMBIO CORRECTAMENTE EL VALOR DEL CAMPO «Respaldar» EN LA BDD WEB, CON VALOR = " & respaldar)

            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " ERROR AL CAMBIAR EL VALOR DEL CAMPO «Respaldar» EN LA BDD WEB, CON VALOR = " & respaldar)
            Return False
        End Try

    End Function

    Public Shared Function fn_Actualizar_PrioridadPrivilegios(ByVal PrioridadPrivilegios As Byte) As Boolean
        Try
            'funcion que cambia de estatus de actualizacion del sistema
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIAR CAMBIO DE PRIORIDAD DE DESCARGA EN LA BDD WEB SUCURSALES CON VALOR: =" & varPub.Prioridad_Priv)

            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Sucursales_UpdatePrioridad", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Prioridad_Priv", SqlDbType.TinyInt, PrioridadPrivilegios)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "SE CAMBIO CORRECTAMENTE EL VALOR DEL CAMPO «Prioridad_Priv» EN LA BDD WEB, CON VALOR = " & varPub.Prioridad_Priv)

            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " ERROR AL CAMBIAR EL VALOR DEL CAMPO «Prioridad_Priv» EN LA BDD WEB, CON VALOR = " & varPub.Prioridad_Priv)
            Return False
        End Try

    End Function

#End Region

#Region "Funciones relacionada con los privilegios"

    Public Shared Function fn_Consulta_PrivilegiosWeb(ByVal ClaveUser As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Read", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUser)

            Return Ejecutar_ConsultaSQL(cmd)

            'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            '    ReDim Arreglo(dt.Rows.Count - 1)
            '    For i As Integer = 0 To dt.Rows.Count - 1
            '        Arreglo(i) = dt.Rows(i)("ClaveO").ToString
            '    Next
            '    Return dt
            'Else
            '    Return Nothing
            'End If

        Catch ex As Exception
            cnn.Dispose()
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_Guarda_PrivilegiosWeb(ByVal ClaveUser As String, ByVal ClaveOpcion As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            'Buscar si Privilegio existe en la web -->
            Dim OpcionExiste As DataTable = fn_BuscaExistencia_PrivilegiosWeb(ClaveUser, ClaveOpcion)

            If OpcionExiste IsNot Nothing AndAlso OpcionExiste.Rows.Count > 0 Then
                Return False
            Else
                Dim cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Create", CommandType.StoredProcedure, cnn)
                Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
                Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUser)
                Crear_ParametroSQL(cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)
                Crear_ParametroSQL(cmd, "@Status2", SqlDbType.VarChar, "A")
                Ejecutar_NonQuerySQL(cmd)

                Return True
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function fn_BuscaExistencia_PrivilegiosWeb(ByVal ClaveUser As String, ByVal ClaveOpcion As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Privilegios_BuscaPrivilegioExiste", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUser)
            Crear_ParametroSQL(cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)

            Return Ejecutar_ConsultaSQL(cmd)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function fn_Elimina1X1_PrivilegiosWeb(ByVal ClaveUser As String, ByVal ClaveOpcion As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Privilegios_DeleteOpcion", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUser)
            Crear_ParametroSQL(cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)

            Ejecutar_NonQuerySQL(cmd)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function fn_EliminarTodos_PrivilegiosWeb(ByVal ClaveUser As String, ByVal ClaveOpcion As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Privilegios_DeleteAllOpciones", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUser)
            Crear_ParametroSQL(cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)

            Ejecutar_NonQuerySQL(cmd)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Funciones de Eliminar contenido de tablas en la web"

    Public Shared Function fn_TablasBorrar_BDDWeb() As Boolean
        'limpiar base de datos depositosD Y depositos
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)

        Try

            '-*----Seccion de Depositos
            Dim cmd As SqlCommand = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "DepositosD_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)


            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Depositos_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            '-*----Seccion de Retiros
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "RetirosD_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)


            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Retiros_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            '----Seccion casets
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Casets_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            '---Seccion usuarios
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Usuarios_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            '---Seccion Privilegios de Usuarios 17/01/2014 -3:50pm
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Privilegios_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            '---pendiente ver si se elimian Monedas,denominaciones, sucursales, Opciones(son fijas) 
            'que correposnde el cajero 17/10/2015

            Tr.Commit()
            Return True

        Catch ex As Exception
            Tr.Rollback()
            Return False
        End Try
    End Function

    Public Shared Function fn_DepositosRetirosBorrar_BDDWeb() As Boolean
        'lipiar base de datos depositosD Y depositos
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)


        Try

            '-*----Seccion de Depositos
            Dim cmd As SqlCommand = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "DepositosD_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)


            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Depositos_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            '-*----Seccion de Retiros
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "RetirosD_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)


            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Retiros_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)


            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Cajas_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)


            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Corte_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            Tr.Commit()
            Return True

        Catch ex As Exception
            Tr.Rollback()
            Return False
        End Try
    End Function

#End Region

#Region "Funciones de Depositos"

    Public Shared Function fn_GuardaDepositosWeb(ByVal Fecha_Deposito As Date, ByVal Id_Deposito As Integer, ByVal ImporteTotal As Decimal,
                                                 ByVal TotalMXP As Decimal, ByVal TotalUSD As Decimal, ByVal TotalUSDConvert As Decimal, ByVal TipoCambioUSD As Decimal,
                                                 ByVal HoraInicio As String, ByVal HoraFin As String, ByVal dt_DepositosD As DataTable,
                                                 ByVal status As Char, ByVal Folio As String, ByVal TipoDeposito As Byte, ByVal UsuarioRegistro As Int32, ByVal Id_Corte As Integer, ByVal Es_Efectivo As Char, Id_Caja As Integer, Clave_Caja As String) As Boolean





        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Try
            'Nota:26/03/2013 Agregue update De status en Retiros donde Status='A' y clave_Sucu=clavesuc
            'Nota 20/08/2020 Se agrega "Id_Cajero" como parametro en el procedimiento.
            Dim cmd As SqlCommand = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Depositos_Create")
            Crear_ParametroSQL(cmd, "@Id_Cajero", SqlDbType.VarChar, varPub.Id_Caje)      '08/08/2020
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Id_Deposito", SqlDbType.Int, Id_Deposito)
            Crear_ParametroSQL(cmd, "@Fecha_Deposito", SqlDbType.Date, Fecha_Deposito) '16/07/2013
            Crear_ParametroSQL(cmd, "@Hora_Inicio", SqlDbType.Time, HoraInicio)
            Crear_ParametroSQL(cmd, "@Hora_Fin", SqlDbType.Time, HoraFin)
            Crear_ParametroSQL(cmd, "@Usuario_Registro", SqlDbType.VarChar, UsuarioRegistro)
            Crear_ParametroSQL(cmd, "@Importe_Total", SqlDbType.Money, ImporteTotal) '19/12/2013
            Crear_ParametroSQL(cmd, "@Total_MXP", SqlDbType.Money, TotalMXP) ''
            Crear_ParametroSQL(cmd, "@Total_USD", SqlDbType.Money, TotalUSD) ''
            Crear_ParametroSQL(cmd, "@TotalUSD_Convert", SqlDbType.Money, TotalUSDConvert) ''
            Crear_ParametroSQL(cmd, "@TipoCambio_USD", SqlDbType.Money, TipoCambioUSD)
            Crear_ParametroSQL(cmd, "@Folio", SqlDbType.VarChar, Folio)
            Crear_ParametroSQL(cmd, "@Tipo", SqlDbType.TinyInt, TipoDeposito)
            Crear_ParametroSQL(cmd, "@Id_Corte", SqlDbType.Int, Id_Corte)
            Crear_ParametroSQL(cmd, "@Es_Efectivo", SqlDbType.Char, Es_Efectivo)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, status)
            Crear_ParametroSQL(cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            Crear_ParametroSQL(cmd, "@Clave_Caja", SqlDbType.VarChar, Clave_Caja)
            Ejecutar_NonQueryTSQL(cmd)

            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "DepositosD_Create")
            For Each elemento As DataRow In dt_DepositosD.Rows
                cmd.Parameters.Clear()

                Crear_ParametroSQL(cmd, "@Id_Deposito", SqlDbType.Int, Id_Deposito)
                Crear_ParametroSQL(cmd, "@Serie_Caset", SqlDbType.VarChar, elemento("SerieCaset")) 'nuevo
                Crear_ParametroSQL(cmd, "@Serie_Validador", SqlDbType.VarChar, elemento("SerieVal")) 'nuevo
                Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
                Crear_ParametroSQL(cmd, "@Clave_Denominacion", SqlDbType.VarChar, elemento("Clave"))
                Crear_ParametroSQL(cmd, "@Denominacion", SqlDbType.Int, elemento("Denominacion"))
                Crear_ParametroSQL(cmd, "@Cantidad_Piezas", SqlDbType.Int, elemento("Cantidad"))
                Crear_ParametroSQL(cmd, "@Importe", SqlDbType.Money, elemento("Importe"))
                Crear_ParametroSQL(cmd, "@Clave_Moneda", SqlDbType.VarChar, elemento("Moneda"))
                Crear_ParametroSQL(cmd, "@Numero_Validador", SqlDbType.Int, elemento("Numero_Validador"))
                Ejecutar_NonQueryTSQL(cmd)
            Next
            'Tr.Commit()
            Return True
        Catch ex As Exception

            'Tr.Rollback()
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
    'Este es el que sincroniza depositos-actualmente
    Public Shared Sub fn_GuardarDepositosWebService(ByVal dtDepositos As DataTable, ByVal dtDepositosDet As DataTable)

        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

        Dim xDocument As XDocument = <?xml version="1.0" encoding="UTF-8" standalone="yes"?><Depositos></Depositos>
        Dim IdDeposito As Integer
        Dim Folio As String
        Dim FechaInicio As Date
        Dim HoraInicio As String
        Dim HoraFinal As String

        Dim errorMessage As String
        Dim _service As SissaCashflowService.CashflowServiceClient
        Dim _Deposito As SissaCashflowService.TransaccionEntityObject
        Dim _DepositoDetalle As SissaCashflowService.TransaccionDetailEntityObject
        Dim _transactionResponse As SissaCashflowService.TransaccionResponse
        Dim RowId As String
        Dim blResult As Boolean = False


        Try

            'Se crean los objetos de enlace al WS Cashflow
            _service = New SissaCashflowService.CashflowServiceClient()

            For Each row As DataRow In dtDepositos.Rows
                IdDeposito = row("Id_Deposito")
                FechaInicio = CDate(Format(row("Fecha_Inicio"), "yyyy-MM-dd"))
                HoraInicio = Format(row("Fecha_Inicio"), "HH:mm:ss")
                HoraFinal = Format(row("Fecha_Fin"), "HH:mm:ss")
                Folio = row("Folio")

                'Se crea el objeto tipo Deposito de WS
                _Deposito = New SissaCashflowService.TransaccionEntityObject() With {
                    .ClaveCajero = varPub.Id_Caje,
                    .ClaveSucursal = varPub.Cve_Sucursal,
                    .IdTransaccion = IdDeposito,
                    .Fecha = FechaInicio,
                    .HoraInicio = TimeSpan.Parse(HoraInicio),
                    .HoraFin = TimeSpan.Parse(HoraFinal),
                    .UsuarioRegistro = row("Usuario_Registro").ToString(),
                    .ImporteTotal = Convert.ToDecimal(row("Importe_Total")),
                    .TotalMXN = Convert.ToDecimal(row("Total_MXP")),
                    .TotalUSD = Convert.ToDecimal(row("Total_USD")),
                    .TotalUSDConvert = Convert.ToDecimal(row("TotalUSD_Convert")),
                    .TipoCambio = Convert.ToDecimal(row("TipoCambio_USD")),
                    .Folio = Folio,
                    .Tipo = Convert.ToInt32(row("Tipo")),
                    .IdCorte = Convert.ToInt32(row("Id_Corte")),
                    .EsEfectivo = IIf(row("Es_Efectivo") = "S", True, False),
                    .Status = Convert.ToChar(row("Status")),
                    .IdCaja = Convert.ToInt32(row("Id_Caja")),
                    .ClaveCaja = row("Clave_Caja").ToString(),
                    .NumeroCuenta = "",
                    .Referencia = "",
                    .Divisa = "MXN",
                    .Acreditado = False
                }

                _Deposito.Movimientos = New List(Of SissaCashflowService.TransaccionDetailEntityObject)()
                If _Deposito.TotalMXN = 0.00 Or _Deposito.ImporteTotal = 0.00 Then
                    Continue For
                End If
                Dim dr() As DataRow = dtDepositosDet.Select("Id_Deposito=" & IdDeposito)

                If dr IsNot Nothing AndAlso dr.Length > 0 Then

                    For Each iR As DataRow In dr
                        _DepositoDetalle = New SissaCashflowService.TransaccionDetailEntityObject() With {
                           .IdTransaccion = IdDeposito,
                           .SerieCasete = iR("SerieCaset").ToString(),
                           .SerieValidador = iR("SerieVal").ToString(),
                           .ClaveSucursal = varPub.Cve_Sucursal,
                           .Denominacion = iR("Denominacion"),
                           .ClaveDenominacion = iR("Clave").ToString(),
                           .CantidadPiezas = Convert.ToInt32(iR("Cantidad")),
                           .Importe = Convert.ToDecimal(iR("Importe")),
                           .ClaveMoneda = iR("Moneda").ToString(),
                           .NumeroValidador = iR("Numero_Validador")
                            }
                        _Deposito.Movimientos.Add(_DepositoDetalle)
                    Next
                End If

                'Se realiza la llamada al metodo WS para envio de Deposito
                _transactionResponse = _service.InsertTransaccionDeposito(varPub.CUNICA, _Deposito)

                If _transactionResponse IsNot Nothing AndAlso _transactionResponse.HasError Then
                    errorMessage = _transactionResponse.ResultMessage
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 73, varPub.IdPantalla, "SINCRONIZAR DEPOSITOS - " + " Id Deposito: " + IdDeposito.ToString() + " Error en proceso de insertado Deposito a Web Service. " + "RFC: " + varPub.CUNICA + " - " + errorMessage)
                    If blResult = True Then cls_CashFlow.fn_UpdateSincronizaDepositos(xDocument.ToString())
                    Exit Sub
                Else
                    Dim xElement As XElement = New XElement("Encabezado")
                    RowId = _transactionResponse.RowID
                    xElement.SetAttributeValue("IdDeposito", IdDeposito)
                    xElement.SetAttributeValue("Folio", Folio)
                    xElement.SetAttributeValue("RowId", RowId)
                    xDocument.Element("Depositos").Add(xElement)
                    blResult = True
                End If
            Next
            cls_CashFlow.fn_UpdateSincronizaDepositos(xDocument.ToString())
        Catch ex As Exception
            If blResult = True Then cls_CashFlow.fn_UpdateSincronizaDepositos(xDocument.ToString())
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 68, varPub.IdPantalla, "SINCRONIZAR DEPÓSITOS - " + " Id Deposito: " + IdDeposito.ToString() + " FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB." + " " + ex.ToString() + "RFC: " + varPub.CUNICA)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.")
            fn_MsgBox("OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.", MessageBoxIcon.Error)
        End Try
    End Sub


    Public Shared Function fn_DepositosExiste(ByVal Id_deposito As Integer) As DataTable
        Try
            'se  utiliza para cancelacion de retiro

            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Depositos_BuscaIdDeposito", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Id_Deposito", SqlDbType.Int, Id_deposito)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Dim dt_Deposito As DataTable = Ejecutar_ConsultaSQL(cmd)

            Return Ejecutar_ConsultaSQL(cmd)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function fn_DepositosActualizaStatus(ByVal Id_deposito As Integer) As Boolean
        Try
            'se utiliza esto se utiliza para cancelacion de retiro
            '11/11/2015 ya no se usa , porque no hay cancelacion de retiro
            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Depositos_Status", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Id_Deposito", SqlDbType.Int, Id_deposito)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            'se supone que estaba en status='R' y pasa a 'F'
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, "F")

            Ejecutar_NonQuerySQL(cmd)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Funciones de Retiro"

    Public Shared Function fn_RetirosExiste(ByVal Id_Retiro As Integer) As DataTable
        Try
            'se  utiliza para cancelacion de retiro
            'corregido 07/11/2015 mandaba id_deposito (busca si el retiro ya existe)

            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Retiros_BuscaIdRetiro", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Return Ejecutar_ConsultaSQL(cmd)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function



    Public Shared Function fn_GuardarRetirosWeb(ByVal dt_IdDepositos As DataTable,
                                                ByVal Id_Retiro As Integer,
                                                ByVal ImporteTotal As Decimal,
                                                ByVal TotalMXP As Integer,
                                                ByVal TotalUSD As Integer,
                                                ByVal TotalUSDConvert As Decimal,
                                                ByVal HoraInicio As String,
                                                ByVal HoraFin As String,
                                                ByVal Observaciones As String,
                                                ByVal Status As Char,
                                                ByVal Dt_RetirosD As DataTable,
                                                ByVal NumeroRemision As Long,
                                                ByVal NumeroEnvase As String,
                                                ByVal Encontro As Boolean,
                                                ByVal Fecha_Retiro As Date,
                                                ByVal ImporteOtros As Decimal,
                                                ByVal ImporteOtrosd As Decimal,
                                                ByVal UsuarioRegistro As Int32
                                                ) As Boolean


        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Dim cmd As SqlCommand
        Try
            If Encontro Then
                ''si encontro solo actualiza
                cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Retiros_Status")
                Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
                Crear_ParametroSQL(cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
                Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Else
                cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Retiros_Create")

                Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
                Crear_ParametroSQL(cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
                Crear_ParametroSQL(cmd, "@Hora_Inicio", SqlDbType.Time, HoraInicio)
                Crear_ParametroSQL(cmd, "@Hora_Fin", SqlDbType.Time, HoraFin)
                Crear_ParametroSQL(cmd, "@Usuario_Registro", SqlDbType.VarChar, UsuarioRegistro)
                Crear_ParametroSQL(cmd, "@Importe_Total", SqlDbType.Money, ImporteTotal)
                Crear_ParametroSQL(cmd, "@Total_MXP", SqlDbType.Money, TotalMXP) ''
                Crear_ParametroSQL(cmd, "@Total_USD", SqlDbType.Money, TotalUSD) ''
                Crear_ParametroSQL(cmd, "@TotalUSD_Convert", SqlDbType.Money, TotalUSDConvert) ''
                Crear_ParametroSQL(cmd, "@Observaciones", SqlDbType.VarChar, Observaciones)
                Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
                Crear_ParametroSQL(cmd, "@Numero_Remision", SqlDbType.Decimal, NumeroRemision)
                Crear_ParametroSQL(cmd, "@Numero_Envase", SqlDbType.VarChar, NumeroEnvase)
                Crear_ParametroSQL(cmd, "@Fecha_Retiro", SqlDbType.Date, Fecha_Retiro) '-->
                Crear_ParametroSQL(cmd, "@Importe_Otros", SqlDbType.Money, ImporteOtros)
                Crear_ParametroSQL(cmd, "@Importe_OtrosD", SqlDbType.Money, ImporteOtrosd)
            End If

            Ejecutar_NonQueryTSQL(cmd)

            '------------------------------------------------------
            If Encontro = False Then
                cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "RetirosD_Create")
                For Each elemento As DataRow In Dt_RetirosD.Rows
                    cmd.Parameters.Clear()
                    Crear_ParametroSQL(cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
                    Crear_ParametroSQL(cmd, "@Clave_Denominacion", SqlDbType.VarChar, elemento("Clave"))
                    Crear_ParametroSQL(cmd, "@Cantidad_Piezas", SqlDbType.Int, elemento("Cantidad"))
                    Crear_ParametroSQL(cmd, "@Importe", SqlDbType.Money, elemento("Importe"))
                    Crear_ParametroSQL(cmd, "@Denominacion", SqlDbType.Int, elemento("Denominacion"))
                    Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
                    Ejecutar_NonQueryTSQL(cmd)
                Next
            End If

            '-----------------------------------------------------
            'Aqui actualiza Satus a "R" Retirado en <Depositos>
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Depositos_Status")
            For Each elemento As DataRow In dt_IdDepositos.Rows
                cmd.Parameters.Clear()
                If Status = "A" Or Status = "V" Then
                    Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, "R")
                    Crear_ParametroSQL(cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
                    'donde hay f y soncronizado=n ( ponemos idretiro,status= S)
                ElseIf Status = "C" Then
                    'de otra forma si status= "C" mandas F a DEpositos
                    Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, "F")
                End If
                Crear_ParametroSQL(cmd, "@Id_Deposito", SqlDbType.Int, elemento("Id_Deposito"))
                Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)

                Ejecutar_NonQueryTSQL(cmd)
            Next

            Tr.Commit()
            Return True

        Catch ex As Exception
            Tr.Rollback()
            Return False
        End Try
    End Function
    Public Shared Sub fn_GuardarRetirowsWs(ByVal dtRetiros As DataTable, ByVal dtRetirosDet As DataTable)


        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

        Dim xDocument As XDocument = <?xml version="1.0" encoding="UTF-8" standalone="yes"?><Retiros></Retiros>
        Dim _service As SissaCashflowService.CashflowServiceClient
        Dim _retiro As SissaCashflowService.TransaccionEntityObject
        Dim _retiroD As SissaCashflowService.TransaccionDetailEntityObject
        Dim _transactionResponse As SissaCashflowService.TransaccionResponse
        Dim errorMessage As String
        Dim IdRetiro As Integer
        Dim FechaRetiro As Date
        Dim HoraInicial As String
        Dim HoraFinal As String
        Dim RowId As String
        Dim Status As String
        Dim dtDepositos As DataTable
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim blResul As Boolean = False


        Try
            'Se crean los objetos de enlace al WS Cashflow
            _service = New SissaCashflowService.CashflowServiceClient()


            For Each row As DataRow In dtRetiros.Rows

                IdRetiro = row("Id_Retiro")
                FechaRetiro = CDate(Format(row("Fecha_Registro"), "yyyy-MM-dd"))
                HoraInicial = Format(row("Fecha_Registro"), "HH:mm:ss")
                HoraFinal = Format(row("Fecha_Registro"), "HH:mm:ss")

                'MANDANDO DATOS DEL WEB SERVICE DETALLE DE DEPOSITO
                _retiro = New SissaCashflowService.TransaccionEntityObject() With {
                    .IdTransaccion = IdRetiro,
                    .ClaveSucursal = varPub.Cve_Sucursal,
                    .Fecha = FechaRetiro,
                    .HoraInicio = TimeSpan.Parse(HoraInicial),
                    .HoraFin = TimeSpan.Parse(HoraFinal),
                    .ImporteTotal = Convert.ToDecimal(row("Importe_Total")),
                    .Status = Convert.ToChar(row("status")),
                    .UsuarioRegistro = row("Usuario_Registro").ToString(),
                    .Observaciones = row("Observaciones").ToString(),
                    .NumeroRemision = Convert.ToDouble(row("Numero_Remision")),
                    .NumeroEnvase = row("Numero_Envase").ToString(),
                    .TotalMXN = Convert.ToDecimal(row("Total_MXP")),
                    .TotalUSD = Convert.ToDecimal(row("Total_USD")),
                    .TotalUSDConvert = Convert.ToDecimal(row("TotalUSD_Convert")),
                    .ImporteOtros = Convert.ToDecimal(row("Importe_Otros")),
                    .ImporteOtrosD = Convert.ToDecimal(row("Importe_Otrosd"))
                }
                _retiro.Movimientos = New List(Of SissaCashflowService.TransaccionDetailEntityObject)()

                Dim dr() As DataRow = dtRetirosDet.Select("Id_Retiro=" & IdRetiro)

                For Each iR As DataRow In dr

                    _retiroD = New SissaCashflowService.TransaccionDetailEntityObject() With {
                        .IdTransaccion = IdRetiro,
                        .ClaveDenominacion = iR("Clave").ToString(),
                        .ClaveSucursal = varPub.Cve_Sucursal,
                        .CantidadPiezas = Integer.Parse(iR("Cantidad")),
                        .Importe = Decimal.Parse(iR("Importe")),
                        .Denominacion = Integer.Parse(iR("Denominacion"))
                        }
                    _retiro.Movimientos.Add(_retiroD)
                Next

                _transactionResponse = _service.InsertTransaccionRetiro(varPub.CUNICA, _retiro)
                If _transactionResponse IsNot Nothing AndAlso _transactionResponse.HasError Then
                    errorMessage = _transactionResponse.ResultMessage
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 71, varPub.IdPantalla, "SINCRONIZAR RECOLECCIÓN - " + "Id Retiro: " + IdRetiro.ToString() + " FIN - OCURRIÓ UN ERROR AL SINCRONIZAR RECOLECCIÓN EN LA BDD WEB. " + "RFC: " + varPub.CUNICA + " - " + errorMessage)
                    Exit Sub
                Else
                    Dim xElement As XElement = New XElement("Encabezado")
                    RowId = _transactionResponse.RowID
                    xElement.SetAttributeValue("IdRetiro", IdRetiro)
                    xElement.SetAttributeValue("RowId", RowId)
                    xDocument.Element("Retiros").Add(xElement)
                    blResul = True
                End If


                'Se genera la lista con a reacion de Depositos asociados al Retiro
                Dim _DepositoInfo As SissaCashflowService.TransaccionEntityObject
                Dim _ListDepositos As List(Of SissaCashflowService.TransaccionEntityObject)

                'Se Obtienen los registros de depositos asociados al Retiro
                cnn = Crear_ConexionSQL(_Cnx)
                cmd = Crear_ComandoSQL("[Depositos].[GetDepositosConRetiro]", CommandType.StoredProcedure, cnn)
                cmd.Parameters.Clear()
                Crear_ParametroSQL(cmd, "@IdRetiro", SqlDbType.Int, IdRetiro)
                dtDepositos = Ejecutar_ConsultaSQL(cmd)
                cnn.Dispose()
                cmd.Dispose()

                'Validamos que exitan registros de deposito correspondientes al Retiro
                If dtDepositos IsNot Nothing AndAlso dtDepositos.Rows.Count > 0 Then

                    _ListDepositos = New List(Of SissaCashflowService.TransaccionEntityObject)

                    For Each iR As DataRow In dtDepositos.Rows
                        Status = iR("Status").ToString()

                        If Status = "A" Or Status = "V" Then
                            Status = "R"
                        ElseIf Status = "C" Then
                            Status = "F"
                        End If

                        'Se crea el objeto tipo Deposito
                        _DepositoInfo = New SissaCashflowService.TransaccionEntityObject() With {
                                .IdTransaccion = iR("Id_Deposito"),
                                .ClaveSucursal = varPub.Cve_Sucursal,
                                .Status = Status,
                                .IdRetiro = IdRetiro
                            }

                        'Se agrega el deposito a la lista de Depositos
                        _ListDepositos.Add(_DepositoInfo)
                    Next
                End If

                'Se envia la lista de Depositos para actualizacion de referencia con Retiro
                _transactionResponse = _service.UpdateDepositoReferenciaStatus(varPub.CUNICA, _ListDepositos)

                If _transactionResponse IsNot Nothing AndAlso _transactionResponse.HasError Then
                    errorMessage = _transactionResponse.ResultMessage
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 72, varPub.IdPantalla, "SINCRONIZAR RECOLECCIÓN - " + "Id Retiro: " + IdRetiro.ToString() + " Error al realizar proceso de actualizacion a depositos, asignando retiros. " + "RFC: " + varPub.CUNICA + " - " + errorMessage)
                    Exit Sub
                End If
            Next
            cls_CashFlow.fn_UpdateSincronizaRetiros(xDocument.ToString())
        Catch ex As Exception
            If blResul = True Then cls_CashFlow.fn_UpdateSincronizaRetiros(xDocument.ToString())
            fn_MsgBox("Error al realizar la sincronizacion de retiros.", MessageBoxIcon.Error)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 69, varPub.IdPantalla, "SINCRONIZAR RECOLECCIÓN - " + "Id Retiro: " + IdRetiro.ToString() + " Error al realizar la sincronizacion de retiros. " + "RFC: " + varPub.CUNICA + " - " + ex.ToString())
        End Try
    End Sub

    Public Shared Function fn_CancelarRetirosWeb(ByVal Id_Retiro As Integer, ByVal UsuarioCancela As String, _
                                                ByVal ObservacionesCancela As String) As Boolean
        ' este ya no se va usar porque ya no se cancelan retiros
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Try
            'Actualiza status en Retiros a "C" Y Depositos Status a "F"
            'Esta Funcion se usa solo cuando  SE CANCELA NORMAL con sincronizacionn
            Dim cmd As SqlCommand = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "RetirosDepositos_Update")
            Crear_ParametroSQL(cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
            Crear_ParametroSQL(cmd, "@Usuario_Cancela", SqlDbType.VarChar, UsuarioCancela)
            Crear_ParametroSQL(cmd, "@Observaciones_Cancela", SqlDbType.VarChar, ObservacionesCancela)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal) 'new parameter
            Crear_ParametroSQL(cmd, "@StatusR", SqlDbType.VarChar, "C")
            Crear_ParametroSQL(cmd, "@StatusD", SqlDbType.VarChar, "F")
            Ejecutar_NonQueryTSQL(cmd)

            Tr.Commit()
            Return True

        Catch ex As Exception
            Tr.Rollback()
            Return False
        End Try
    End Function

#End Region

#Region "-Funciones de Log Monitoreo"

    Public Shared Sub fn_GuardarLogErroresWebService(ByVal dtLog As DataTable)
        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 26/05/2021

        Dim xDocument As XDocument = <?xml version="1.0" encoding="UTF-8" standalone="yes"?><Monitoreo></Monitoreo>
        Dim IdLog As Integer
        Dim Hora As String

        Dim errorMessage As String
        Dim _service As SissaCashflowService.CashflowServiceClient
        Dim _Log As SissaCashflowService.TransaccionLogEntity
        Dim _transactionResponse As SissaCashflowService.TransaccionResponse
        Dim RowId As String
        Dim blResult As Boolean = False

        Try

            'Se crean los objetos de enlace al WS Cashflow
            _service = New SissaCashflowService.CashflowServiceClient()

            For Each row As DataRow In dtLog.Rows
                IdLog = Convert.ToInt32(row("IdLog"))
                Hora = row("Hora").ToString()

                ''Se crea el objeto tipo Deposito de WS
                _Log = New SissaCashflowService.TransaccionLogEntity With {
                    .ClaveSucursal = varPub.Cve_Sucursal,
                    .IdCajero = varPub.Id_Caje,
                    .IdUsuario = Convert.ToInt32(row("IdUsuario")),
                    .Descripcion = row("DescripcionLog").ToString(),
                    .IdLogDescripcion = Convert.ToInt32(row("IdLogDescripcion")),
                    .IdPantalla = Convert.ToInt32(row("IdPantalla")),
                    .Fecha = CDate(Format(row("Fecha"), "yyyy-MM-dd")),
                    .Hora = Hora
                }

                ''Se realiza la llamada al metodo WS para envio de Deposito
                _transactionResponse = _service.AddTransactionLog(varPub.CUNICA, _Log)

                If _transactionResponse IsNot Nothing AndAlso _transactionResponse.HasError Then
                    errorMessage = _transactionResponse.ResultMessage
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 79, varPub.IdPantalla, "SINCRONIZAR MONITOREO - " + " Error en proceso de insertado Log a Web Service, En IdLog: " + IdLog.ToString() + " y RFC: " + varPub.CUNICA + " - " + errorMessage)
                    If blResult = True Then cls_CashFlow.fn_UpdateSincronizaLogMonitoreo(xDocument.ToString())
                    Exit Sub
                Else
                    Dim xElement As XElement = New XElement("Log")
                    RowId = _transactionResponse.RowID
                    xElement.SetAttributeValue("IdLog", IdLog)
                    xElement.SetAttributeValue("RowId", RowId)
                    xDocument.Element("Monitoreo").Add(xElement)
                    blResult = True
                End If
            Next
            cls_CashFlow.fn_UpdateSincronizaLogMonitoreo(xDocument.ToString())
        Catch ex As Exception
            If blResult = True Then cls_CashFlow.fn_UpdateSincronizaLogMonitoreo(xDocument.ToString())
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 79, varPub.IdPantalla, "SINCRONIZAR MONITOREO - " + "FIN - OCURRIÓ UN ERROR AL GUARDAR LOGS DE MONITOREO EN LA BDD WEB, EN IDLOG: ." + IdLog.ToString() + " " + ex.ToString() + " RFC: " + varPub.CUNICA)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL GUARDAR LOGS MONITOREO EN LA BDD WEB.")
            fn_MsgBox("OCURRIÓ UN ERROR AL GUARDAR LOGS MONITOREO EN LA BDD WEB.", MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Funciones de Corte"

    Public Shared Function fn_GuardarCorteWeb(ByVal Id_Corte As Integer, ByVal UsuarioRegistro As Integer, ByVal Fecha_Retiro As Date, ByVal Usuario_Cierre As Integer, ByVal Fecha_Cierre As Date, ByVal Status As String) As Boolean

        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Dim cmd As SqlCommand
        Try
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Corte_Create")

            Crear_ParametroSQL(cmd, "@Usuario_Registro", SqlDbType.Int, UsuarioRegistro)
            Crear_ParametroSQL(cmd, "@Id_Corte", SqlDbType.Int, Id_Corte)
            Crear_ParametroSQL(cmd, "@Fecha_Registro", SqlDbType.DateTime, Fecha_Retiro) '-->
            Crear_ParametroSQL(cmd, "@Usuario_Cierre", SqlDbType.Int, Usuario_Cierre)
            Crear_ParametroSQL(cmd, "@Fecha_Cierre", SqlDbType.DateTime, Fecha_Cierre) '-->
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Crear_ParametroSQL(cmd, "@Sincronizado", SqlDbType.VarChar, "S")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)

            Ejecutar_NonQueryTSQL(cmd)


            Tr.Commit()
            Return True

        Catch ex As Exception
            Tr.Rollback()
            Return False
        End Try
    End Function

#End Region

#Region "Funciones de Sucursales"

    Public Shared Function fn_GuardaSucursal() As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Sucursales_Create", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Nombre_Sucursal", SqlDbType.VarChar, varPub.Nombre_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Cliente", SqlDbType.VarChar, varPub.Cve_Cliente)
            Crear_ParametroSQL(cmd, "@Domicilio", SqlDbType.VarChar, varPub.Direccion)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, varPub.Nombre_Corto) '--
            Crear_ParametroSQL(cmd, "@Num_Validadores", SqlDbType.TinyInt, varPub.Cant_Validadores) '--
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, "A")
            Ejecutar_NonQuerySQL(cmd)

            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR ULTIMA CONEXION", " ERROR AL SINCRONIZAR CONEXION(GUARDAR). " & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_ActualizaSucursal(ByVal ClaveSucursal As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Sucursales_Update", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)
            Crear_ParametroSQL(cmd, "@Nombre_Sucursal", SqlDbType.VarChar, varPub.Nombre_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Cliente", SqlDbType.VarChar, varPub.Cve_Cliente)
            Crear_ParametroSQL(cmd, "@Domicilio", SqlDbType.VarChar, varPub.Direccion)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, varPub.Nombre_Corto) '--
            Crear_ParametroSQL(cmd, "@Num_Validadores", SqlDbType.TinyInt, varPub.Cant_Validadores) '--

            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR ULTIMA CONEXION", " ERROR AL SINCRONIZAR CONEXION(ACTUALIZAR). " & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_ClaveSucursalExistente(ByVal ClaveSucursal As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Sucursales_ClaveExistente", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)

            Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)
            Return dt
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR ULTIMA CONEXION", " ERROR AL SINCRONIZAR CONEXION(VERIFICAR CLAVE EXISTE). " & ex.Message.ToUpper)

            Return Nothing
        End Try

    End Function

#End Region

#Region "Funciones de Monedas"

    Public Shared Function fn_ConsultaMonedas() As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, cnn)
            Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_GuardaMonedas(ByVal ClaveMoneda As String, ByVal NombreMoneda As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Monedas_Create", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Moneda", SqlDbType.VarChar, ClaveMoneda)
            Crear_ParametroSQL(cmd, "@Nombre_Moneda", SqlDbType.VarChar, NombreMoneda)
            Ejecutar_NonQuerySQL(cmd)
            Call fn_EscribirLog(varPub.UsuarioClave, "Sincronizacion", "insertando moneda: " & ClaveMoneda & " en Web")

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Funciones de Casets"

    Public Shared Function fn_ConsultaCasets(ByVal ClaveSucursal As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Casets_Read", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)
            Dim dt_Casets As DataTable = Ejecutar_ConsultaSQL(cmd)

            Return dt_Casets
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_GuardaCasets(ByVal ClaveCaset As String, ByVal SerieCaset As String, ByVal Capacidad As Integer, ByVal Porcentaje As Integer, ByVal Status As Char, ByVal fechaSync As DateTime) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Casets_Create", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Caset", SqlDbType.VarChar, ClaveCaset)
            Crear_ParametroSQL(cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
            Crear_ParametroSQL(cmd, "@Capacidad", SqlDbType.Int, Capacidad)
            Crear_ParametroSQL(cmd, "@Porcentaje_Alerta", SqlDbType.Int, Porcentaje)
            Crear_ParametroSQL(cmd, "@FechaSync", SqlDbType.DateTime, fechaSync)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Crear_ParametroSQL(cmd, "@Status2", SqlDbType.VarChar, "A")
            Ejecutar_NonQuerySQL(cmd)

            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASET", "CASET GUARDADO EN LA BDD WEB N° SERIE: " & SerieCaset)

            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASET", " ERROR AL GUARDAR CASET EN LA BDD WEB N° SERIE: " & SerieCaset)
            Return False
        End Try

    End Function

    Public Shared Function fn_CambiarStatus_Casets(ByVal Status As Char, ByVal SerieCaset As String, ByVal fechaModif As DateTime) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Casets_Status", CommandType.StoredProcedure, cnn)

        Try
            ' se cambio clave_caset X @Serie_Caset 5nov
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Crear_ParametroSQL(cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@FechaModifica", SqlDbType.DateTime, fechaModif)
            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASET", "OCURRIÓ UN ERROR AL CAMBIAR STATUS CASET, N° SERIE: " & SerieCaset)

            Return False
        End Try
    End Function

    '25 /junio/2013 pendiente -6nov2013 ok
    Public Shared Function fn_Elimina_Casets(ByVal serieCaset As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Casets_Eliminar", CommandType.StoredProcedure, cnn)

        Try
            Crear_ParametroSQL(cmd, "@Serie_Caset", SqlDbType.VarChar, serieCaset)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Funciones de Usuarios"

    Public Shared Function fn_ConsultaUsuarios(ByVal ClaveSucursal As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(cmd)
            Return dt_Usuarios

        Catch ex As Exception
            cnn.Dispose()

            Return Nothing
        End Try
    End Function

    Public Shared Function fn_ConsultaUsuariosExistente(ByVal ClaveUsuario As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_ClaveExistente", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)

            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(cmd)
            Return dt_Usuarios
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 68, varPub.IdPantalla, " sp: Usuarios_ClaveExistente - ERROR AL EDITAR/INSERTAR USUARIO - " + ex.ToString())
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_GuardaUsuarios(ByVal CveUsuarioNew As Int32, ByVal NombreUser As String, ByVal Contra As String, ByVal TipoUser As Byte, ByVal Status As Char, ByVal NombreCortoUser As String, ByVal fechaSync As DateTime, ByVal Fecha_Registro As DateTime) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Create", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, CveUsuarioNew) '-----
            Crear_ParametroSQL(cmd, "@Nombre", SqlDbType.VarChar, NombreUser)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, NombreCortoUser)
            Crear_ParametroSQL(cmd, "@Password", SqlDbType.VarChar, Contra, False) 'no convertir a mayus0.
            Crear_ParametroSQL(cmd, "@Tipo_Usuario", SqlDbType.TinyInt, TipoUser)
            Crear_ParametroSQL(cmd, "@Usuario_Registro", SqlDbType.VarChar, varPub.UsuarioClave)
            Crear_ParametroSQL(cmd, "@FechaSync", SqlDbType.DateTime, fechaSync)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Crear_ParametroSQL(cmd, "@Fecha_Registro", SqlDbType.DateTime, Fecha_Registro)
            Ejecutar_NonQuerySQL(cmd)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "USUARIO GUARDADO CORRECTAMENTE EN BDD CENTRAL CON CLAVE: " & CveUsuarioNew)
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIO", "ERROR AL GUARDAR USUARIO EN BDD WEB CON CLAVE: " & CveUsuarioNew)

            Return False
        End Try

    End Function

    Public Shared Function fn_Modificar_Usuarios(ByVal ClaveUsuario As String, ByVal TipoUsuario As Byte, ByVal NombreUsuario As String, ByVal NombreCorto As String, ByVal fechaModif As DateTime) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Modificar", CommandType.StoredProcedure, cnn)

        Try
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Nombre", SqlDbType.VarChar, NombreUsuario)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, NombreCorto)
            Crear_ParametroSQL(cmd, "@Tipo_Usuario", SqlDbType.TinyInt, TipoUsuario)
            Crear_ParametroSQL(cmd, "@FechaModifica", SqlDbType.DateTime, fechaModif)

            Ejecutar_NonQuerySQL(cmd)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "USUARIO MODIFICADO CORRECTAMENTE EN BDD CENTRAL.")
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "ERROR AL MODIFICAR USUARIO EN BDD WEB CON CLAVE: " & ClaveUsuario)

            Return False
        End Try
    End Function

    Public Shared Function fn_CambiarPassword_Usuarios(ByVal ClaveUsuario As String, ByVal Contrasena As String, ByVal fechaex As Date) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_CambiaContrasena", CommandType.StoredProcedure, cnn)

        Try
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Password", SqlDbType.VarChar, Contrasena, False)
            Crear_ParametroSQL(cmd, "@Fecha_Expira", SqlDbType.Date, fechaex)
            Ejecutar_NonQuerySQL(cmd)
            Return True

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "ERROR AL CAMBIAR CONTRASEÑA DE USUARIO CON CLAVE: " & ClaveUsuario)

            Return False
        End Try
    End Function

    Public Shared Function fn_Elimina_Usuarios(ByVal claveUser As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Dim cmd As SqlCommand

        Try
            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Privilegios_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, claveUser) '16/12/2015 faltaba
            Ejecutar_NonQueryTSQL(cmd)

            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Usuarios_Eliminar")
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, claveUser)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            Tr.Commit()
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIO", "ERROR AL ELIMIAR EL USUARIO EN BDD WEB CON CLAVE: " & claveUser)

            Tr.Rollback()
            Return False
        End Try

    End Function

    Public Shared Function fn_CambiarStatus_Usuarios(ByVal Status As Char, ByVal ClaveUsuario As String, ByVal UsuarioBaja As String, ByVal FechaBaja As DateTime) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Status", CommandType.StoredProcedure, cnn)

        Try
            If Status = "B" Then
                Crear_ParametroSQL(cmd, "@Usuario_Baja", SqlDbType.VarChar, UsuarioBaja)
                Crear_ParametroSQL(cmd, "@Fecha_Baja", SqlDbType.DateTime, FechaBaja)
            End If
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@FechaModifica", SqlDbType.DateTime, FechaBaja)

            Ejecutar_NonQuerySQL(cmd)
            Return True

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIO", "ERROR AL CAMBIAR DE STATUS AL USUARIO EN BDD WEB CON CLAVE: " & ClaveUsuario)
            Return False
        End Try
    End Function

    Public Shared Function fn_Usuarios_ModificarStatus2(Clave_Sucursal As String, Clave_Usuario As String) As Integer
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim FilasAfectada As Integer = 0
        Try
            cnn = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            cmd = Crear_ComandoSQL("Usuarios_Update2", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, Clave_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, Clave_Usuario)
            FilasAfectada = Ejecutar_NonQuerySQL(cmd)
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIO", "ERROR AL CAMBIAR DE STATUS2 AL USUARIO EN BDD WEB CON CLAVE: " & Clave_Usuario)
            FilasAfectada = 0
            cnn.Dispose()
            cmd.Dispose()
        End Try
        Return FilasAfectada
    End Function

    Public Shared Function fn_Usuarios_Eliminar(Clave_Sucursal As String, Clave_Usuario As String) As Integer
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim FilasAfectadas As Integer = 0
        Try
            cnn = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            cmd = Crear_ComandoSQL("Usuarios_Eliminar", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, Clave_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, Clave_Usuario)
            FilasAfectadas = Ejecutar_NonQuerySQL(cmd)
        Catch ex As Exception
            FilasAfectadas = 0
            cnn.Dispose()
            cmd.Dispose()
        End Try
        Return FilasAfectadas
    End Function

    Public Shared Function fn_Usuarios_ModificarLocalAWeb(Clave_Sucursal As String, Clave_Usuario As String, Nombre As String, Nombre_Corto As String, Tipo_Usuario As String) As Integer
        Dim cnn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim FilasAfectadas As Integer = 0
        Try
            cnn = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            cmd = Crear_ComandoSQL("Usuarios_Update", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, Clave_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, Clave_Usuario)
            Crear_ParametroSQL(cmd, "@Nombre", SqlDbType.VarChar, Nombre)
            Crear_ParametroSQL(cmd, "@Nombre_Corto", SqlDbType.VarChar, Nombre_Corto)
            Crear_ParametroSQL(cmd, "@Tipo_Usuario", SqlDbType.TinyInt, Tipo_Usuario)
            Crear_ParametroSQL(cmd, "@Status2", SqlDbType.VarChar, "A")
            FilasAfectadas = Ejecutar_NonQuerySQL(cmd)
        Catch ex As Exception
            FilasAfectadas = 0
            cnn.Dispose()
            cmd.Dispose()
        End Try
        Return FilasAfectadas
    End Function


#End Region

#Region "Funciones de Denominaciones"

    Public Shared Function fn_ConsultaDenominaciones() As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Read", CommandType.StoredProcedure, cnn)
            Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_GuardaDenominaciones(ByVal ClaveDenom As String, ByVal Denominacion As Integer, ByVal ClaveMoneda As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Create", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Moneda", SqlDbType.VarChar, ClaveMoneda)
            Crear_ParametroSQL(cmd, "@Clave_Denominacion", SqlDbType.VarChar, ClaveDenom)
            Crear_ParametroSQL(cmd, "@Denominacion", SqlDbType.Money, Denominacion)
            Ejecutar_NonQuerySQL(cmd)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Funciones de Logs"

    Public Shared Function fn_BuscasiExiste_Log_enWeb(ByVal FechaArchivo As DateTime, ByVal NombreArchivo As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Logs_VerificarExiste", CommandType.StoredProcedure, cnn)

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Fecha_Archivo", SqlDbType.DateTime, FechaArchivo)
            Crear_ParametroSQL(cmd, "@Nombre_Archivo", SqlDbType.VarChar, NombreArchivo, False)

            Return Ejecutar_ConsultaSQL(cmd)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Shared Function fn_GuardaArchivo_Log(ByVal FechaArchivo As DateTime, ByVal ArchivoLog As Byte(), ByVal NombreArchivo As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            'buscar si el archivo log ya existe en la bdd web
            Dim dt_ArchivoLogExiste As DataTable = fn_BuscasiExiste_Log_enWeb(FechaArchivo, NombreArchivo)

            If dt_ArchivoLogExiste.Rows.Count = 0 Then
                Dim cmd As SqlCommand = Crear_ComandoSQL("Logs_Create", CommandType.StoredProcedure, cnn)
                Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
                Crear_ParametroSQL(cmd, "@Fecha_Archivo", SqlDbType.DateTime, FechaArchivo)
                Crear_ParametroSQL(cmd, "@Nombre_Archivo", SqlDbType.VarChar, NombreArchivo, False) 'el actual usado
                Crear_ParametroSQL(cmd, "@Archivo_Log", SqlDbType.VarBinary, ArchivoLog)
                Ejecutar_NonQuerySQL(cmd)
                Call fn_EscribirLog(varPub.UsuarioClave, "Sincronizacion ", "Enviando archivo de log a la BDD web")
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Funciones Cajas"

    'JAVIER ZAPATA 15/05/2019
    Public Shared Function fn_EditarCajas(ByVal Id_Caja As Integer, ByVal Descripcion As String) As Boolean
        Dim Cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
          Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_Update", CommandType.StoredProcedure, Cnn)
          Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
          Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, Descripcion)
          If Ejecutar_NonQuerySQL(Cmd) > 0 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CAJAS", "CAJA EDITADA CORRECTAMENTE EN LA WEB")
            Return True
          End If
          Return False
        Catch ex As Exception
          Call fn_EscribirLog(varPub.UsuarioClave, "CAJAS", " ERROR AL EDITAR LA CAJA EN LA WEB")
          Return False
        End Try
    End Function

    Public Shared Function fn_ConsultaCajas(ByVal ClaveSucursal As String) As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Cajas_Read", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)
            Dim dt_Cajas As DataTable = Ejecutar_ConsultaSQL(cmd)
            Return dt_Cajas
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Shared Function fn_GuardaCajas(ByVal Numero_Caja As String, ByVal Descripcion As String, ByVal Status As Char, Fecha_Registro As DateTime, ByVal fechaSync As DateTime, Optional ByVal Id_Caja As Integer = 0) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Try
            Dim cmd As SqlCommand = Crear_ComandoSQL("Cajas_Create", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Caja", SqlDbType.VarChar, Numero_Caja)
            Crear_ParametroSQL(cmd, "@Descripcion", SqlDbType.VarChar, Descripcion)
            Crear_ParametroSQL(cmd, "@Fecha_Registro", SqlDbType.DateTime, Fecha_Registro)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Crear_ParametroSQL(cmd, "@Sincronizado", SqlDbType.VarChar, "S")
            Crear_ParametroSQL(cmd, "@Fecha_Sincronizado", SqlDbType.DateTime, fechaSync)
            Ejecutar_NonQuerySQL(cmd)

            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJA", "CAJA GUARDADO EN LA BDD WEB N° CAJA: " & Numero_Caja)

            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJA", " ERROR AL GUARDAR CAJA EN LA BDD WEB N° CAJA: " & Numero_Caja)
            Return False
        End Try

    End Function

    Public Shared Function fn_CambiarStatus_Caja(ByVal Status As Char, ByVal Id_Caja As String, Clave_Caja As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Cajas_Status", CommandType.StoredProcedure, cnn)

        Try
            ' se cambio clave_caset X @Serie_Caset 5nov

            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, Status)
            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJA", "OCURRIÓ UN ERROR AL CAMBIAR STATUS CAJA, N° CAJA: " & Clave_Caja)

            Return False
        End Try
    End Function

    Public Shared Function fn_Elimina_Caja(ByVal NumeroCaja As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Cajas_Eliminar", CommandType.StoredProcedure, cnn)
        Try
            Crear_ParametroSQL(cmd, "@Id_Caja", SqlDbType.Int, NumeroCaja)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Borrar Tablas en la Web"
    Public Shared Function fn_Cajas_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing

        Try
            cmd = Crear_ComandoSQL("Cajas_Delete", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)

        Catch ex As Exception
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CAJAS EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE lA TABLA CAJAS EN LA WEB.")
        Return True
    End Function

    Public Shared Function fn_Casets_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing

        Try

            cmd = Crear_ComandoSQL("Casets_Delete", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)

        Catch ex As Exception
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CASETS EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA CASETS EN LA WEB.")
        Return True
    End Function

    Public Shared Function fn_Corte_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing

        Try

            cmd = Crear_ComandoSQL("Corte_Delete", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)

        Catch ex As Exception
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CORTE EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLAS CORTE EN LA WEB.")
        Return True
    End Function

    Public Shared Function fn_DepositosD_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Dim cmd As SqlCommand = Nothing

        Try

            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "DepositosD_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Depositos_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            Tr.Commit()
        Catch ex As Exception
            Tr.Rollback()
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA DEPOSITOSD EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA DEPOSITOSD EN LA WEB.")
        Return True
    End Function

    'Public Shared Function fn_Depositos_BorrarWeb(ByRef Descripcion) As Boolean
    '    Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
    '    Dim cmd As SqlCommand = Nothing

    '    Try

    '        cmd = Crear_ComandoSQL("Depositos_Delete", CommandType.StoredProcedure, cnn)
    '        Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
    '        Ejecutar_NonQuerySQL(cmd)

    '    Catch ex As Exception
    '        cnn.Dispose()
    '        cmd.Dispose()
    '        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA DEPOSITOS EN LA WEB." & ex.Message())
    '        Descripcion = ex.Message() & " En la Web"
    '        Return False
    '    End Try
    '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE lA TABLA DEPOSITOS EN LA WEB.")
    '    Return True
    'End Function

    Public Shared Function fn_Privilegios_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing
        Try

            cmd = Crear_ComandoSQL("Privilegios_Delete", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.VarChar, varPub.UsuarioClave)
            Ejecutar_NonQuerySQL(cmd)

        Catch ex As Exception
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA PRIVILEGIOS EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA PRIVILEGIOS EN LA WEB.")
        Return True
    End Function


    Public Shared Function fn_Retiros_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing

        Try
            cmd = Crear_ComandoSQL("Retiros_Delete", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)

        Catch ex As Exception
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA RETIROS EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA RETIROS EN LA WEB.")
        Return True
    End Function


    Public Shared Function fn_RetirosD_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Dim cmd As SqlCommand = Nothing

        Try

            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "RetirosD_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            cmd = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Retiros_Delete")
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQueryTSQL(cmd)

            Tr.Commit()
        Catch ex As Exception
            Tr.Rollback()
            cnn.Dispose()
            cmd.Dispose()
            Tr.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA RETIROS EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA RETIROS EN LA WEB.")
        Return True
    End Function

    Public Shared Function fn_Usuarios_BorrarWeb(ByRef Descripcion) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing

        Try
            cmd = Crear_ComandoSQL("Usuarios_Delete", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Ejecutar_NonQuerySQL(cmd)

        Catch ex As Exception
            cnn.Dispose()
            cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA USUARIOS EN LA WEB." & ex.Message())
            Descripcion = ex.Message() & " En la Web"
            Return False
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA USUARIOS EN LA WEB.")
        Return True
    End Function

#End Region

#Region "Conexion de Configuracion Morado"

    Public Shared Function fn_Insertar_Parametros_Conexion(ByVal ClaveSucursal As String, ByVal ClaveUsuario As String, ByVal ClaveOpcion As String) As Boolean
        Dim Con As SqlConnection = Crear_ConexionSQL("SQLCompact")
        Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Insert", CommandType.StoredProcedure, Con)
        Try
            Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario)
            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)
            If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
            Return False
        Catch ex As Exception
            Return False
            Call fn_EscribirLog(varPub.UsuarioClave, "INSERTAR PRIVILEGIO", "OCURRIÓ UN ERROR AL INSERTAR PRIVILEGIO EN LA WEB ")
        End Try
    End Function
#End Region

    '--------------------JAVIER ZAPATA---------------------------------------------
    Public Shared Function fn_ObtenerPrivilegiosWeb(ByVal Clave_Sucursal As String) As DataTable
  Dim Con As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
  Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Read2", CommandType.StoredProcedure, Con)
  Try
    Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, Clave_Sucursal)
    Dim Dt_PrivilegiosWeb = Ejecutar_ConsultaSQL(Cmd)
    Return Dt_PrivilegiosWeb
  Catch ex As Exception
    Return Nothing
  End Try
  Call fn_EscribirLog(varPub.UsuarioClave, "OBTENER PRIVILEGIO", "OCURRIÓ UN ERROR AL OBTENER PRIVILEGIOS EN LA WEB ")
End Function

Public Shared Function fn_InsertarPrivilegios(ByVal ClaveSucursal As String, ByVal ClaveUsuario As String, ByVal ClaveOpcion As String) As Boolean
  Dim Con As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
  Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Insert", CommandType.StoredProcedure, Con)
  Try
   Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, ClaveSucursal)
   Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario)
   Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)
   If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
   Return False
  Catch ex As Exception
   Return False
   Call fn_EscribirLog(varPub.UsuarioClave, "INSERTAR PRIVILEGIO", "OCURRIÓ UN ERROR AL INSERTAR PRIVILEGIO EN LA WEB ")
  End Try
End Function

Public Shared Function fn_EliminarPrivilegios(ByVal ClaveUsuario As String, ByVal ClaveOpcion As String) As Boolean
  Dim Con As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
  Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_DeleteOpcion", CommandType.StoredProcedure, Con)
  Try
   Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
   Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario.Split("/")(0))
   Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, ClaveOpcion)
   If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
   Return False
  Catch ex As Exception
   Return False
  Call fn_EscribirLog(varPub.UsuarioClave, "ELIMINAR PRIVILEGIOS", "OCURRIÓ UN ERROR AL ELIMINAR PRIVILEGIO EN LA WEB ")
  End Try
End Function

Public Shared Function fn_EliminarTodosPrivilegios(ByVal ClaveUsuario As String) As Boolean
    Dim Con As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
    Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Delete", CommandType.StoredProcedure, Con)
    Try
      Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
      Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.VarChar, ClaveUsuario.Split("/")(0))
      If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
      Return False
     Catch ex As Exception
      Return False
     Call fn_EscribirLog(varPub.UsuarioClave, "ELIMINAR PRIVILEGIOS", "OCURRIÓ UN ERROR AL ELIMINAR PRIVILEGIO EN LA WEB ")
     End Try
End Function

Public Shared Function fn_EditarCasetsStatus(ByVal Serie_Caset As String, ByVal Estatus As String, ByVal Fecha_Modifica As DateTime) As Boolean
     Dim Con As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
     Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Update3", CommandType.StoredProcedure, Con)
     Try
       Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
       Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, Serie_Caset)
       Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, Estatus)
       Crear_ParametroSQL(Cmd, "@FechaModifica", SqlDbType.DateTime, Fecha_Modifica)
       If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
       Return False
     Catch ex As Exception
       Return False
     Call fn_EscribirLog(varPub.UsuarioClave, "EDITAR CASETS", "OCURRIÓ UN ERROR AL EDITAR CASETS EN LA WEB ")
     End Try
End Function


End Class
