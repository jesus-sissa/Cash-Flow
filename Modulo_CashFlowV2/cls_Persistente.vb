Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports Modulo_CashFlowV2.cls_VariablesPersistentes
Imports dataconection.cls_DatosSQL
Imports System.IO
Imports System.Xml.Serialization

Public Class cls_Persistente
#Region "Variables locales"
    Private RutaPersistente As String = Application.StartupPath & "\ArchivoPersistente.xml"
#End Region
#Region "Metodos Publicos"
    ''' <summary>
    ''' La funcion CargaXmlBD buscara el archivo ArchivoPersistente.xml y extraera los datos almacenados 
    ''' ahi y los agregara a la tabla Cajero mediante StoreProcedure Persistente_Create
    ''' </summary>
    ''' <returns></returns>
    'Public Function CargarXmlaBd() As Boolean
    '    Dim Serializador As XmlSerializer = New XmlSerializer(GetType(cls_VariablesPersistentes))
    '    Dim fs As FileStream = File.OpenRead(RutaPersistente)
    '    Dim EntidadDeserializada As cls_VariablesPersistentes
    '    Try
    '        EntidadDeserializada = Serializador.Deserialize(fs)
    '    Catch ex As Exception
    '        fs.Close()
    '        Return False
    '    End Try
    '    fs.Close()
    '    If fs IsNot Nothing Then fs.Dispose()

    '    Dim Resp = False
    '    Try
    '        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
    '        Dim Cmd As SqlCommand = Crear_ComandoSQL("Persistente_Create", CommandType.StoredProcedure, Cnn)
    '        Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, EntidadDeserializada.pCve_Sucursal)
    '        Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, EntidadDeserializada.pNombre_Sucursal)
    '        Crear_ParametroSQL(Cmd, "@Fecha_Registro", SqlDbType.DateTime, Date.Now)
    '        Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "ND")
    '        Crear_ParametroSQL(Cmd, "@UtilizaRemisionDigital", SqlDbType.Bit, True)
    '        Crear_ParametroSQL(Cmd, "@pModo_Impresion", SqlDbType.Int, EntidadDeserializada.pModo_Impresion)
    '        Crear_ParametroSQL(Cmd, "@pImprimir_DetalleCD", SqlDbType.Bit, EntidadDeserializada.pImprimir_DetalleCD)
    '        Crear_ParametroSQL(Cmd, "@phostNameOrAddress", SqlDbType.VarChar, EntidadDeserializada.phostNameOrAddress)
    '        Crear_ParametroSQL(Cmd, "@pVersionCashFlow", SqlDbType.VarChar, EntidadDeserializada.pVersionCashFlow)
    '        Crear_ParametroSQL(Cmd, "@pInicioOperaciones", SqlDbType.DateTime, EntidadDeserializada.pInicioOperaciones)
    '        Crear_ParametroSQL(Cmd, "@pMailSucursal", SqlDbType.VarChar, EntidadDeserializada.pMailSucursal)
    '        Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct2", SqlDbType.Int, EntidadDeserializada.pLimiteCapacidadKct2)
    '        Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct", SqlDbType.Int, EntidadDeserializada.pLimiteCapacidadKct)
    '        Crear_ParametroSQL(Cmd, "@pAncho_Pantalla", SqlDbType.Int, EntidadDeserializada.pAncho_Pantalla)
    '        Crear_ParametroSQL(Cmd, "@pAlto_Pantalla", SqlDbType.Int, EntidadDeserializada.pAlto_Pantalla)
    '        Crear_ParametroSQL(Cmd, "@pTipoWindows", SqlDbType.Int, EntidadDeserializada.pTipoWindows)
    '        Crear_ParametroSQL(Cmd, "@pNumValidadores", SqlDbType.Int, EntidadDeserializada.pNumValidadores)
    '        Crear_ParametroSQL(Cmd, "@pActivarVal1", SqlDbType.Bit, EntidadDeserializada.pActivarVal1)
    '        Crear_ParametroSQL(Cmd, "@pSerieCaset1", SqlDbType.VarChar, EntidadDeserializada.pSerieCaset1)
    '        Crear_ParametroSQL(Cmd, "@pSerieVal1", SqlDbType.VarChar, EntidadDeserializada.pSerieVal1)
    '        Crear_ParametroSQL(Cmd, "@pPuerto_Val1", SqlDbType.Int, EntidadDeserializada.pPuerto_Val1)
    '        Crear_ParametroSQL(Cmd, "@pCapacidad_Caset", SqlDbType.Int, EntidadDeserializada.pCapacidad_Caset)
    '        Crear_ParametroSQL(Cmd, "@pCapacidad_Actual", SqlDbType.Int, EntidadDeserializada.pCapacidad_Actual)
    '        Crear_ParametroSQL(Cmd, "@pCasetID", SqlDbType.Int, EntidadDeserializada.pCasetID)
    '        Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta", SqlDbType.Int, EntidadDeserializada.pPorcentaje_Alerta)
    '        Crear_ParametroSQL(Cmd, "@pActivarVal2", SqlDbType.Bit, EntidadDeserializada.pActivarVal2)
    '        Crear_ParametroSQL(Cmd, "@pSerieCaset2", SqlDbType.VarChar, EntidadDeserializada.pSerieCaset2)
    '        Crear_ParametroSQL(Cmd, "@pSerieVal2", SqlDbType.VarChar, EntidadDeserializada.pSerieVal2)
    '        Crear_ParametroSQL(Cmd, "@pPuerto_Val2", SqlDbType.VarChar, EntidadDeserializada.pPuerto_Val2)
    '        Crear_ParametroSQL(Cmd, "@pCapacidad_Caset2", SqlDbType.Int, EntidadDeserializada.pCapacidad_Caset2)
    '        Crear_ParametroSQL(Cmd, "@pCapacidad_Actual2", SqlDbType.Int, EntidadDeserializada.pCapacidad_Actual2)
    '        Crear_ParametroSQL(Cmd, "@pCaset2ID", SqlDbType.Int, EntidadDeserializada.pCaset2ID)
    '        Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta2", SqlDbType.Int, EntidadDeserializada.pPorcentaje_Alerta2,)
    '        Crear_ParametroSQL(Cmd, "@pMargenIZq", SqlDbType.Int, EntidadDeserializada.pMargenIZq)
    '        Crear_ParametroSQL(Cmd, "@pDias_Expira", SqlDbType.Int, EntidadDeserializada.pDias_Expira)
    '        Crear_ParametroSQL(Cmd, "@pTimeOut_Receptor", SqlDbType.Int, EntidadDeserializada.pTimeOut_Receptor)
    '        Crear_ParametroSQL(Cmd, "@pTimeOut_Sesion", SqlDbType.Int, EntidadDeserializada.pTimeOut_Sesion)
    '        Crear_ParametroSQL(Cmd, "@pUlt_Archivo", SqlDbType.VarChar, EntidadDeserializada.pUlt_Archivo)
    '        Crear_ParametroSQL(Cmd, "@pU_dtb", SqlDbType.VarChar, EntidadDeserializada.pU_dtb)
    '        Crear_ParametroSQL(Cmd, "@pP_dtb", SqlDbType.VarChar, EntidadDeserializada.pP_dtb)
    '        Crear_ParametroSQL(Cmd, "@pB_dtb", SqlDbType.VarChar, EntidadDeserializada.pB_dtb)
    '        Crear_ParametroSQL(Cmd, "@pS_dtb", SqlDbType.VarChar, EntidadDeserializada.pS_dtb)
    '        Crear_ParametroSQL(Cmd, "@pRuta_Log", SqlDbType.VarChar, EntidadDeserializada.pRuta_Log)
    '        Crear_ParametroSQL(Cmd, "@pMsg_Fuente", SqlDbType.Int, EntidadDeserializada.pMsg_Fuente)
    '        Crear_ParametroSQL(Cmd, "@pCmd_Fuente", SqlDbType.Int, EntidadDeserializada.pCmd_Fuente)
    '        Crear_ParametroSQL(Cmd, "@pLbl_Fuente", SqlDbType.Int, EntidadDeserializada.pLbl_Fuente)
    '        Crear_ParametroSQL(Cmd, "@pTipo_papel", SqlDbType.Int, EntidadDeserializada.pTipo_papel)
    '        Crear_ParametroSQL(Cmd, "@pCve_Sucursal", SqlDbType.Int, EntidadDeserializada.pCve_Sucursal)
    '        Crear_ParametroSQL(Cmd, "@pCve_Cliente", SqlDbType.VarChar, EntidadDeserializada.pCve_Cliente)
    '        Crear_ParametroSQL(Cmd, "@pNombre_Sucursal", SqlDbType.VarChar, EntidadDeserializada.pNombre_Sucursal)
    '        Crear_ParametroSQL(Cmd, "@pConectividad", SqlDbType.Bit, EntidadDeserializada.pConectividad)
    '        Crear_ParametroSQL(Cmd, "@pConexionwebAdmin", SqlDbType.Int, EntidadDeserializada.pConexionwebAdmin)
    '        Crear_ParametroSQL(Cmd, "@pNumLineasEnBlanco", SqlDbType.Int, EntidadDeserializada.pNumLineasEnBlanco)
    '        Crear_ParametroSQL(Cmd, "@pNumCopiasImprimir", SqlDbType.Int, EntidadDeserializada.pNumCopiasImprimir)
    '        Crear_ParametroSQL(Cmd, "@pPrioridadPriv", SqlDbType.Int, EntidadDeserializada.pPrioridadPriv)
    '        Crear_ParametroSQL(Cmd, "@pCliente", SqlDbType.VarChar, EntidadDeserializada.pCliente)
    '        Crear_ParametroSQL(Cmd, "@pDireccion", SqlDbType.VarChar, EntidadDeserializada.pDireccion)
    '        Crear_ParametroSQL(Cmd, "@pNombreCorto", SqlDbType.VarChar, EntidadDeserializada.pNombreCorto)
    '        Crear_ParametroSQL(Cmd, "@pTelefono", SqlDbType.VarChar, EntidadDeserializada.pTelefono)
    '        Crear_ParametroSQL(Cmd, "@pCiaTV", SqlDbType.VarChar, EntidadDeserializada.pCiaTV)
    '        Crear_ParametroSQL(Cmd, "@pDepositoP", SqlDbType.Int, EntidadDeserializada.pDepositoP)
    '        Crear_ParametroSQL(Cmd, "@pUlt_Retiro", SqlDbType.Int, EntidadDeserializada.pUlt_Retiro)
    '        Crear_ParametroSQL(Cmd, "@pconexweb", SqlDbType.VarChar, EntidadDeserializada.pconexweb)
    '        Crear_ParametroSQL(Cmd, "@pCUNICA", SqlDbType.VarChar, EntidadDeserializada.pCUNICA)
    '        Crear_ParametroSQL(Cmd, "@pComprobacion", SqlDbType.VarChar, EntidadDeserializada.pComprobacion)
    '        Crear_ParametroSQL(Cmd, "@pVersionNvo", SqlDbType.Int, EntidadDeserializada.pVersionNvo)
    '        Crear_ParametroSQL(Cmd, "@pVersionAnt", SqlDbType.Int, EntidadDeserializada.pVersionAnt)
    '        Crear_ParametroSQL(Cmd, "@pManejaCorte", SqlDbType.Int, EntidadDeserializada.pManejaCorte)
    '        Crear_ParametroSQL(Cmd, "@pCorteActual", SqlDbType.Int, EntidadDeserializada.pCorteActual)
    '        Crear_ParametroSQL(Cmd, "@pTipoMonedaV1", SqlDbType.VarChar, EntidadDeserializada.pTipoMonedaV1)
    '        Crear_ParametroSQL(Cmd, "@pTipoMonedaV2", SqlDbType.VarChar, EntidadDeserializada.pTipoMonedaV2)
    '        Crear_ParametroSQL(Cmd, "@pCantidadCajas", SqlDbType.Int, EntidadDeserializada.pCantidadCajas)
    '        Crear_ParametroSQL(Cmd, "@pManejaConexionWebService", SqlDbType.Int, EntidadDeserializada.pManejaConexionWebService)
    '        Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaBaja", SqlDbType.Int, EntidadDeserializada.pPorcentajeBateriaBaja)
    '        Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaCritica", SqlDbType.Int, EntidadDeserializada.pPorcentajeBateriaCritica)
    '        Crear_ParametroSQL(Cmd, "@pBateriaBaja", SqlDbType.Bit, EntidadDeserializada.pBateriaBaja)
    '        Crear_ParametroSQL(Cmd, "@pBateriaCritica", SqlDbType.Bit, EntidadDeserializada.pBateriaCritica)
    '        Crear_ParametroSQL(Cmd, "@pPuertoSensores", SqlDbType.VarChar, EntidadDeserializada.pPuertoSensores)
    '        Crear_ParametroSQL(Cmd, "@pManejaDepositoManual", SqlDbType.Bit, EntidadDeserializada.pManejaDepositoManual)
    '        Crear_ParametroSQL(Cmd, "@pManejaFolioManual", SqlDbType.Bit, EntidadDeserializada.pManejaFolioManual)
    '        Crear_ParametroSQL(Cmd, "@pvalidarFolio", SqlDbType.Bit, EntidadDeserializada.pvalidarFolio)
    '        Crear_ParametroSQL(Cmd, "@pconexion", SqlDbType.Int, EntidadDeserializada.pconexion)
    '        Crear_ParametroSQL(Cmd, "@pTrabajar_sin", SqlDbType.Bit, EntidadDeserializada.pTrabajar_sin)
    '        Crear_ParametroSQL(Cmd, "@Id_caj", SqlDbType.VarChar, EntidadDeserializada.Id_caj)
    '        Crear_ParametroSQL(Cmd, "@pLogo_EmpresaRuta", SqlDbType.VarChar, EntidadDeserializada.pLogo_EmpresaRuta)
    '        Ejecutar_NonQuerySQL(Cmd)
    '        Resp = True
    '    Catch ex As Exception

    '    End Try

    '    Return Resp
    'End Function

    ''' <summary>
    ''' La funcion ActualizarDatosPersistentes actualizara los BD
    ''' del persistente mediente StoreProcedure Persistente_Update
    ''' Reemplza a la funcion Persistir de la clase cls_VariablesPersistentes
    ''' </summary>
    ''' <returns></returns>

    Public Function ActualizarDatosPersistente() As Boolean
        Dim Resp = False
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Persistente_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, varPub.Nombre_Sucursal)
            ' Crear_ParametroSQL(Cmd, "@Fecha_Registro", SqlDbType.DateTime, Date.Now)
            Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "ND")
            Crear_ParametroSQL(Cmd, "@UtilizaRemisionDigital", SqlDbType.Bit, varPub.Remision_Valida)
            Crear_ParametroSQL(Cmd, "@pModo_Impresion", SqlDbType.Int, varPub.Modo_Impresion)
            Crear_ParametroSQL(Cmd, "@pImprimir_DetalleCD", SqlDbType.Bit, varPub.Imprimir_DetalleCD)
            Crear_ParametroSQL(Cmd, "@phostNameOrAddress", SqlDbType.VarChar, varPub.hostNameOrAddress)
            Crear_ParametroSQL(Cmd, "@pVersionCashFlow", SqlDbType.VarChar, varPub.Version_CashFlow)
            Crear_ParametroSQL(Cmd, "@pInicioOperaciones", SqlDbType.DateTime, varPub.Inicio_Operaciones)
            Crear_ParametroSQL(Cmd, "@pMailSucursal", SqlDbType.VarChar, varPub.Mail_Sucursal)
            Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct2", SqlDbType.Int, varPub.LimiteCapacidad_Kct2)
            Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct", SqlDbType.Int, varPub.LimiteCapacidad_Kct)
            Crear_ParametroSQL(Cmd, "@pAncho_Pantalla", SqlDbType.Int, varTecl.AnchoPantalla)
            Crear_ParametroSQL(Cmd, "@pAlto_Pantalla", SqlDbType.Int, varTecl.AltoPantalla)
            Crear_ParametroSQL(Cmd, "@pTipoWindows", SqlDbType.Int, varPub.Tipo_Windows)
            Crear_ParametroSQL(Cmd, "@pNumValidadores", SqlDbType.Int, varPub.Cant_Validadores)
            Crear_ParametroSQL(Cmd, "@pActivarVal1", SqlDbType.Bit, varPub.Activar_Val1)
            Crear_ParametroSQL(Cmd, "@pSerieCaset1", SqlDbType.VarChar, varPub.Serie_Caset1)
            Crear_ParametroSQL(Cmd, "@pSerieVal1", SqlDbType.VarChar, varPub.Serie_Val1)
            Crear_ParametroSQL(Cmd, "@pPuerto_Val1", SqlDbType.Int, varPub.Puerto_Val1)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Caset", SqlDbType.Int, varPub.Capacidad_Caset)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Actual", SqlDbType.Int, varPub.Capacidad_Actual)
            Crear_ParametroSQL(Cmd, "@pCasetID", SqlDbType.Int, varPub.CasetID)
            Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta", SqlDbType.Int, varPub.Porcentaje_Alerta)
            Crear_ParametroSQL(Cmd, "@pActivarVal2", SqlDbType.Bit, varPub.Activar_Val2)
            Crear_ParametroSQL(Cmd, "@pSerieCaset2", SqlDbType.VarChar, varPub.Serie_Caset2)
            Crear_ParametroSQL(Cmd, "@pSerieVal2", SqlDbType.VarChar, varPub.Serie_Val2)
            Crear_ParametroSQL(Cmd, "@pPuerto_Val2", SqlDbType.VarChar, varPub.Puerto_Val2)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Caset2", SqlDbType.Int, varPub.Capacidad_Caset2)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Actual2", SqlDbType.Int, varPub.Capacidad_Actual2)
            Crear_ParametroSQL(Cmd, "@pCaset2ID", SqlDbType.Int, varPub.Caset2ID)
            Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta2", SqlDbType.Int, varPub.Porcentaje_Alerta2,)
            Crear_ParametroSQL(Cmd, "@pMargenIZq", SqlDbType.Int, varPub.MargenIzq)
            Crear_ParametroSQL(Cmd, "@pDias_Expira", SqlDbType.Int, varPub.Dias_Expira)
            Crear_ParametroSQL(Cmd, "@pTimeOut_Receptor", SqlDbType.Int, varPub.TimeOut_Receptor)
            Crear_ParametroSQL(Cmd, "@pTimeOut_Sesion", SqlDbType.Int, varPub.TimeOut_Sesion)
            Crear_ParametroSQL(Cmd, "@pUlt_Archivo", SqlDbType.VarChar, varPub.Ult_Archivo)
            Crear_ParametroSQL(Cmd, "@pU_dtb", SqlDbType.VarChar, varPub.U_dtb)
            Crear_ParametroSQL(Cmd, "@pP_dtb", SqlDbType.VarChar, varPub.P_dtb)
            Crear_ParametroSQL(Cmd, "@pB_dtb", SqlDbType.VarChar, varPub.B_dtb)
            Crear_ParametroSQL(Cmd, "@pS_dtb", SqlDbType.VarChar, varPub.S_dtb)
            Crear_ParametroSQL(Cmd, "@pRuta_Log", SqlDbType.VarChar, varPub.Ruta_Log)
            Crear_ParametroSQL(Cmd, "@pMsg_Fuente", SqlDbType.Int, varPub.TamañoFuente_Mensajes)
            Crear_ParametroSQL(Cmd, "@pCmd_Fuente", SqlDbType.Int, varPub.TamañoFuente_Botones)
            Crear_ParametroSQL(Cmd, "@pLbl_Fuente", SqlDbType.Int, varPub.TamañoFuente_Etiqueta)
            Crear_ParametroSQL(Cmd, "@pTipo_papel", SqlDbType.Int, varPub.Tamaño_Papel)
            Crear_ParametroSQL(Cmd, "@pCve_Sucursal", SqlDbType.Int, varPub.Cve_Sucursal)
            Crear_ParametroSQL(Cmd, "@pCve_Cliente", SqlDbType.VarChar, varPub.Cve_Cliente)
            Crear_ParametroSQL(Cmd, "@pNombre_Sucursal", SqlDbType.VarChar, varPub.Nombre_Sucursal)
            Crear_ParametroSQL(Cmd, "@pConectividad", SqlDbType.Bit, varPub.Conectividad)
            Crear_ParametroSQL(Cmd, "@pConexionwebAdmin", SqlDbType.Int, varPub.ConexionwebAdmin)
            Crear_ParametroSQL(Cmd, "@pNumLineasEnBlanco", SqlDbType.Int, varPub.Num_LineasBlanco)
            Crear_ParametroSQL(Cmd, "@pNumCopiasImprimir", SqlDbType.Int, varPub.Num_CopiasImprimir)
            Crear_ParametroSQL(Cmd, "@pPrioridadPriv", SqlDbType.Int, varPub.Prioridad_Priv)
            Crear_ParametroSQL(Cmd, "@pCliente", SqlDbType.VarChar, varPub.Cliente)
            Crear_ParametroSQL(Cmd, "@pDireccion", SqlDbType.VarChar, varPub.Direccion)
            Crear_ParametroSQL(Cmd, "@pNombreCorto", SqlDbType.VarChar, varPub.Nombre_Corto)
            Crear_ParametroSQL(Cmd, "@pTelefono", SqlDbType.VarChar, varPub.Telefono)
            Crear_ParametroSQL(Cmd, "@pCiaTV", SqlDbType.VarChar, varPub.CiaTV)
            Crear_ParametroSQL(Cmd, "@pDepositoP", SqlDbType.Bit, varPub.DepositoFinalizado)
            Crear_ParametroSQL(Cmd, "@pUlt_Retiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
            Crear_ParametroSQL(Cmd, "@pconexweb", SqlDbType.VarChar, varPub.cnx_SucursalWeb)
            Crear_ParametroSQL(Cmd, "@pCUNICA", SqlDbType.VarChar, varPub.CUNICA)
            Crear_ParametroSQL(Cmd, "@pComprobacion", SqlDbType.VarChar, varPub.Comprobacion)
            Crear_ParametroSQL(Cmd, "@pVersionNvo", SqlDbType.Int, varPub.VersionNvo)
            Crear_ParametroSQL(Cmd, "@pVersionAnt", SqlDbType.Int, varPub.VersionAnt)
            Crear_ParametroSQL(Cmd, "@pManejaCorte", SqlDbType.Int, varPub.ManejaCorte)
            Crear_ParametroSQL(Cmd, "@pCorteActual", SqlDbType.Int, varPub.CorteActual)
            Crear_ParametroSQL(Cmd, "@pTipoMonedaV1", SqlDbType.VarChar, varPub.TipoMonedaV1)
            Crear_ParametroSQL(Cmd, "@pTipoMonedaV2", SqlDbType.VarChar, varPub.TipoMonedaV2)
            Crear_ParametroSQL(Cmd, "@pCantidadCajas", SqlDbType.Int, varPub.Cantidad_Cajas)
            Crear_ParametroSQL(Cmd, "@pManejaConexionWebService", SqlDbType.Int, varPub.ManejaConexionWebService)
            Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaBaja", SqlDbType.Int, varPub.PorcentajeBateriaBaja)
            Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaCritica", SqlDbType.Int, varPub.PorcentajeBateriaCritica)
            Crear_ParametroSQL(Cmd, "@pBateriaBaja", SqlDbType.Bit, varPub.BateriaBaja)
            Crear_ParametroSQL(Cmd, "@pBateriaCritica", SqlDbType.Bit, varPub.BateriaCritica)
            Crear_ParametroSQL(Cmd, "@pPuertoSensores", SqlDbType.VarChar, varPub.PuertoSensores)
            Crear_ParametroSQL(Cmd, "@pManejaDepositoManual", SqlDbType.Bit, varPub.ManejaDepositoManual)
            Crear_ParametroSQL(Cmd, "@pManejaFolioManual", SqlDbType.Bit, varPub.ManejaFolioManual)
            Crear_ParametroSQL(Cmd, "@pvalidarFolio", SqlDbType.Bit, varPub.ValidarFolio)
            Crear_ParametroSQL(Cmd, "@pconexion", SqlDbType.Int, varPub.Conexion)
            Crear_ParametroSQL(Cmd, "@pTrabajar_sin", SqlDbType.Bit, varPub.Trabajar_sin)
            Crear_ParametroSQL(Cmd, "@Id_caj", SqlDbType.VarChar, varPub.Id_Cajero)
            Crear_ParametroSQL(Cmd, "@pLogo_EmpresaRuta", SqlDbType.VarChar, varPub.Logo_EmpresaRuta)
            Dim r As Integer = Ejecutar_NonQuerySQL(Cmd)
            MessageBox.Show("ActualizadoCorrectamente:" + r.ToString())
            Resp = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Function
    ''' <summary>
    ''' La funcion CargaDatosPersistente extrae los datos del la BD mediente StoreProcedure Persistente_Get 
    ''' y asigna los datos a las variables publicas
    ''' Reemplaza a la funcion Cargar en la clase cls_VariablesPersistentes
    ''' </summary>
    ''' <returns></returns>
    Public Function CargaDatosPersistente() As Boolean
        Dim resp As Boolean = False
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Persistente_Get", CommandType.StoredProcedure, Cnn)
            Cnn.Open()
            Dim Result As SqlDataReader = Cmd.ExecuteReader()
            If Result.HasRows Then

                While (Result.Read())
                    varPub.Modo_Impresion = Result("pModo_Impresion")
                    varPub.CUNICA = Result("pCUNICA")
                    varPub.TamañoFuente_Mensajes = Result("pMsg_Fuente")
                    varPub.TamañoFuente_Etiqueta = Result("pLbl_Fuente")
                    varPub.TamañoFuente_Botones = Result("pCmd_Fuente")
                    varPub.Tamaño_Papel = Result("pTipo_papel")

                    varPub.LimiteCapacidad_Kct = Result("pLimiteCapacidadKct")
                    varPub.LimiteCapacidad_Kct2 = Result("pLimiteCapacidadKct2")

                    varPub.ConexionwebAdmin = Result("pConexionwebAdmin")
                    varPub.Conectividad = Result("pConectividad")
                    varPub.Prioridad_Priv = Result("pPrioridadPriv")
                    varPub.Conexion = 1
                    varPub.Logo_EmpresaRuta = Result("pLogo_EmpresaRuta")
                    varPub.Imprimir_DetalleCD = Result("pImprimir_DetalleCD")
                    varPub.Mail_Sucursal = Result("pMailSucursal")
                    varPub.Inicio_Operaciones = Result("pInicioOperaciones")
                    varPub.Version_CashFlow = Result("pVersionCashFlow")

                    varPub.Num_LineasBlanco = Result("pNumLineasEnBlanco")
                    varPub.Num_CopiasImprimir = Result("pNumCopiasImprimir")

                    varPub.Activar_Val1 = Result("pActivarVal1")
                    varPub.Activar_Val2 = Result("pActivarVal2")

                    varPub.Cant_Validadores = Result("pNumValidadores")
                    varPub.Caset2ID = Result("pCaset2ID")

                    varPub.Serie_Val1 = Result("pSerieVal1")
                    varPub.Serie_Val2 = Result("pSerieVal2")

                    varPub.Puerto_Val1 = Result("pPuerto_Val1")
                    varPub.Puerto_Val2 = Result("pPuerto_Val2")

                    varPub.Serie_Caset1 = Result("pSerieCaset1")
                    varPub.Serie_Caset2 = Result("pSerieCaset2")

                    varPub.Nombre_Corto = Result("pNombreCorto")
                    varPub.Tipo_Windows = Result("pTipoWindows")

                    varPub.hostNameOrAddress = Result("phostNameOrAddress")
                    varPub.MargenIzq = Result("pMargenIZq")

                    varPub.Ruta_Log = Result("pRuta_Log")
                    varPub.Ult_Archivo = Result("pUlt_Archivo")
                    varPub.TimeOut_Receptor = Result("pTimeOut_Receptor")
                    varPub.TimeOut_Sesion = Result("pTimeOut_Sesion")
                    varPub.Dias_Expira = Result("pDias_Expira")

                    varPub.Cve_Sucursal = Result("pCve_Sucursal")
                    varPub.Nombre_Sucursal = Result("pNombre_Sucursal")
                    varPub.Cve_Cliente = Result("pCve_Cliente")

                    varPub.Id_Cajero = Result("Id_caj")
                    varPub.Cliente = Result("pCliente")
                    varPub.Direccion = Result("pDireccion")
                    varPub.Telefono = Result("pTelefono")
                    varPub.CiaTV = Result("pCiaTV")
                    varPub.CasetID = Result("pCasetID")
                    varPub.ID_DepositoP = Result("pDepositoP")

                    varPub.ID_UltimoRetiro = Result("pUlt_Retiro")

                    varPub.Capacidad_Caset = Result("pCapacidad_Caset")
                    varPub.Porcentaje_Alerta = Result("pPorcentaje_Alerta")
                    varPub.Capacidad_Actual = Result("pCapacidad_Actual")
                    varPub.Comprobacion = Result("pComprobacion")
                    varPub.VersionAnt = Result("pVersionAnt")
                    varPub.VersionNvo = Result("pVersionNvo")
                    varPub.ManejaCorte = Result("pManejaCorte")
                    varPub.CorteActual = Result("pCorteActual")

                    varPub.TipoMonedaV1 = Result("pTipoMonedaV1")
                    varPub.TipoMonedaV2 = Result("pTipoMonedaV2")

                    'lo de abajo es para el casetero No. 2
                    varPub.Capacidad_Caset2 = Result("pCapacidad_Caset2")
                    varPub.Porcentaje_Alerta2 = Result("pPorcentaje_Alerta2")
                    varPub.Capacidad_Actual2 = Result("pCapacidad_Actual2")

                    varTecl.AnchoPantalla = Convert.ToInt32(Result("pAncho_Pantalla2"))
                    varTecl.AltoPantalla = Convert.ToInt32(Result("pAlto_Pantalla"))
                    varPub.Cantidad_Cajas = Convert.ToInt32(Result("pCantidadCajas"))

                    If varPub.Conectividad Then
                        varPub.cnx_SucursalWeb = cls_FuncionesPublicas.fn_Decode(Result("pconexweb"))
                        varPub.S_dtb = cls_FuncionesPublicas.fn_Decode(Result("pS_dtb"))
                        varPub.B_dtb = cls_FuncionesPublicas.fn_Decode(Result("pB_dtb"))
                        varPub.U_dtb = cls_FuncionesPublicas.fn_Decode(Result("pU_dtb"))
                        varPub.P_dtb = cls_FuncionesPublicas.fn_Decode(Result("pP_dtb"))

                    Else
                        varPub.cnx_SucursalWeb = Result("pconexweb")
                        varPub.S_dtb = Result("pS_dtb")
                        varPub.B_dtb = Result("pB_dtb")
                        varPub.U_dtb = Result("pU_dtb")
                        varPub.P_dtb = Result("pP_dtb")
                    End If
                    varPub.PorcentajeBateriaBaja = Result("pPorcentajeBateriaBaja")
                    varPub.PorcentajeBateriaCritica = Result("pPorcentajeBateriaCritica")
                    varPub.BateriaBaja = Result("pBateriaBaja")
                    varPub.BateriaCritica = Result("pBateriaCritica")
                    varPub.ManejaDepositoManual = Result("pManejaDepositoManual")
                    varPub.ManejaFolioManual = Result("pManejaFolioManual")
                    varPub.ValidarFolio = Result("pvalidarFolio")
                    varPub.Conexion = Result("pconexion")
                    varPub.Trabajar_sin = Result("pTrabajar_sin")
                End While
                Result.Close()
                Cnn.Close()
                resp = True
            End If
            MessageBox.Show("ExtraccionDeDatosCorrectamente")
            resp = True
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.ToString())
        End Try

        Return resp
    End Function
#End Region
End Class
