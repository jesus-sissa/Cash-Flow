Imports System.Xml.Serialization
Imports System.IO
Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.Reflection

Public Class Cls_Propiedades
#Region "Propiedades Públicas"
    Public Property pModo_Impresion() As Integer
        Get
            Return varPub.Modo_Impresion
        End Get
        Set(ByVal value As Integer)
            varPub.Modo_Impresion = value
        End Set
    End Property

    Public Property pLogo_EmpresaRuta() As String
        Get
            Return varPub.Logo_EmpresaRuta
        End Get
        Set(ByVal value As String)
            varPub.Logo_EmpresaRuta = value
        End Set
    End Property

    Public Property pImprimir_DetalleCD() As Integer
        Get
            Return varPub.Imprimir_DetalleCD
        End Get
        Set(ByVal value As Integer)
            varPub.Imprimir_DetalleCD = value
        End Set
    End Property

    Public Property phostNameOrAddress() As String
        Get
            Return varPub.hostNameOrAddress
        End Get
        Set(ByVal value As String)
            varPub.hostNameOrAddress = value
        End Set
    End Property

    Public Property pVersionCashFlow() As String
        Get
            Return varPub.Version_CashFlow
        End Get
        Set(ByVal value As String)
            varPub.Version_CashFlow = value
        End Set
    End Property

    Public Property pInicioOperaciones() As Date
        Get
            Return varPub.Inicio_Operaciones
        End Get
        Set(ByVal value As Date)
            varPub.Inicio_Operaciones = value
        End Set
    End Property

    Public Property pMailSucursal() As String
        Get
            Return varPub.Mail_Sucursal
        End Get
        Set(ByVal value As String)
            varPub.Mail_Sucursal = value
        End Set
    End Property

    Public Property pLimiteCapacidadKct2() As Integer
        Get
            Return varPub.LimiteCapacidad_Kct2
        End Get
        Set(ByVal value As Integer)

            varPub.LimiteCapacidad_Kct2 = value
        End Set
    End Property

    Public Property pLimiteCapacidadKct() As Integer
        Get
            Return varPub.LimiteCapacidad_Kct
        End Get
        Set(ByVal value As Integer)
            varPub.LimiteCapacidad_Kct = value
        End Set
    End Property

    Public Property pAncho_Pantalla() As Integer
        Get
            Return varTecl.AnchoPantalla
        End Get
        Set(ByVal value As Integer)
            varTecl.AnchoPantalla = value
        End Set
    End Property

    Public Property pAlto_Pantalla() As Integer
        Get
            Return varTecl.AltoPantalla
        End Get
        Set(ByVal value As Integer)
            varTecl.AltoPantalla = value
        End Set
    End Property

    Public Property pTipoWindows() As Integer
        Get
            Return varPub.Tipo_Windows
        End Get
        Set(ByVal value As Integer)
            varPub.Tipo_Windows = value
        End Set
    End Property

    Public Property pNumValidadores() As Integer
        Get
            Return varPub.Cant_Validadores
        End Get
        Set(ByVal value As Integer)
            varPub.Cant_Validadores = value
        End Set
    End Property

    Public Property pActivarVal1() As Integer
        Get
            Return varPub.Activar_Val1
        End Get
        Set(ByVal value As Integer)
            varPub.Activar_Val1 = value
        End Set
    End Property

    Public Property pSerieCaset1() As String
        Get
            Return varPub.Serie_Caset1
        End Get
        Set(ByVal value As String)
            varPub.Serie_Caset1 = value
        End Set
    End Property

    Public Property pSerieVal1() As String
        Get
            Return varPub.Serie_Val1
        End Get
        Set(ByVal value As String)
            varPub.Serie_Val1 = value
        End Set
    End Property

    Public Property pPuerto_Val1() As String
        Get
            Return varPub.Puerto_Val1
        End Get
        Set(ByVal value As String)
            varPub.Puerto_Val1 = value
        End Set
    End Property

    Public Property pCapacidad_Caset() As Integer
        Get
            Return varPub.Capacidad_Caset
        End Get
        Set(ByVal value As Integer)
            varPub.Capacidad_Caset = value
        End Set
    End Property

    Public Property pCapacidad_Actual() As Integer
        Get
            Return varPub.Capacidad_Actual
        End Get
        Set(ByVal value As Integer)
            varPub.Capacidad_Actual = value
        End Set
    End Property

    Public Property pCasetID() As Integer
        Get
            Return varPub.CasetID
        End Get
        Set(ByVal value As Integer)
            varPub.CasetID = value
        End Set
    End Property

    Public Property pPorcentaje_Alerta() As Integer
        Get
            Return varPub.Porcentaje_Alerta
        End Get
        Set(ByVal value As Integer)
            varPub.Porcentaje_Alerta = value
        End Set
    End Property

    Public Property pActivarVal2() As Integer
        Get
            Return varPub.Activar_Val2
        End Get
        Set(ByVal value As Integer)
            varPub.Activar_Val2 = value
        End Set
    End Property

    Public Property pSerieCaset2() As String
        Get
            Return varPub.Serie_Caset2
        End Get
        Set(ByVal value As String)
            varPub.Serie_Caset2 = value
        End Set
    End Property

    Public Property pSerieVal2() As String
        Get
            Return varPub.Serie_Val2
        End Get
        Set(ByVal value As String)
            varPub.Serie_Val2 = value
        End Set
    End Property

    Public Property pPuerto_Val2() As String
        Get
            Return varPub.Puerto_Val2
        End Get
        Set(ByVal value As String)
            varPub.Puerto_Val2 = value
        End Set
    End Property

    Public Property pCapacidad_Caset2() As Integer
        Get
            Return varPub.Capacidad_Caset2
        End Get
        Set(ByVal value As Integer)
            varPub.Capacidad_Caset2 = value
        End Set
    End Property

    Public Property pCapacidad_Actual2() As Integer
        Get
            Return varPub.Capacidad_Actual2
        End Get
        Set(ByVal value As Integer)
            varPub.Capacidad_Actual2 = value
        End Set
    End Property

    Public Property pCaset2ID() As Integer
        Get
            Return varPub.Caset2ID
        End Get
        Set(ByVal value As Integer)
            varPub.Caset2ID = value
        End Set
    End Property

    Public Property pPorcentaje_Alerta2() As Integer
        Get
            Return varPub.Porcentaje_Alerta2
        End Get
        Set(ByVal value As Integer)
            varPub.Porcentaje_Alerta2 = value
        End Set
    End Property

    Public Property pMargenIZq() As Integer
        Get
            Return varPub.MargenIzq
        End Get
        Set(ByVal value As Integer)
            varPub.MargenIzq = value
        End Set
    End Property

    Public Property pDias_Expira() As Integer
        Get
            Return varPub.Dias_Expira
        End Get
        Set(ByVal value As Integer)
            varPub.Dias_Expira = value
        End Set
    End Property

    Public Property pTimeOut_Receptor() As Integer
        Get
            Return varPub.TimeOut_Receptor
        End Get
        Set(ByVal value As Integer)
            varPub.TimeOut_Receptor = value
        End Set
    End Property

    Public Property pTimeOut_Sesion() As Integer
        Get
            Return varPub.TimeOut_Sesion
        End Get
        Set(ByVal value As Integer)
            varPub.TimeOut_Sesion = value
        End Set
    End Property

    Public Property pUlt_Archivo() As String
        Get
            Return varPub.Ult_Archivo
        End Get
        Set(ByVal value As String)
            varPub.Ult_Archivo = value
        End Set
    End Property

    Public Property pU_dtb() As String
        Get
            Return varPub.U_dtb
        End Get
        Set(ByVal value As String)
            varPub.U_dtb = value
        End Set
    End Property

    Public Property pP_dtb() As String
        Get
            Return varPub.P_dtb
        End Get
        Set(ByVal value As String)
            varPub.P_dtb = value
        End Set
    End Property

    Public Property pB_dtb() As String
        Get
            Return varPub.B_dtb
        End Get
        Set(ByVal value As String)
            varPub.B_dtb = value
        End Set
    End Property

    Public Property pS_dtb() As String
        Get
            Return varPub.S_dtb
        End Get
        Set(ByVal value As String)
            varPub.S_dtb = value
        End Set
    End Property

    Public Property pRuta_Log() As String
        Get
            Return varPub.Ruta_Log
        End Get
        Set(ByVal value As String)
            varPub.Ruta_Log = value
        End Set
    End Property

    Public Property pMsg_Fuente() As Integer
        Get
            Return varPub.TamañoFuente_Mensajes
        End Get
        Set(ByVal value As Integer)
            varPub.TamañoFuente_Mensajes = value
        End Set
    End Property

    Public Property pLbl_Fuente() As Integer
        Get
            Return varPub.TamañoFuente_Etiqueta
        End Get
        Set(ByVal value As Integer)
            varPub.TamañoFuente_Etiqueta = value
        End Set
    End Property

    Public Property pCmd_Fuente() As Integer
        Get
            Return varPub.TamañoFuente_Botones
        End Get
        Set(ByVal value As Integer)
            varPub.TamañoFuente_Botones = value
        End Set
    End Property

    Public Property pTipo_papel() As Integer
        Get
            Return varPub.Tamaño_Papel
        End Get
        Set(ByVal value As Integer)
            varPub.Tamaño_Papel = value
        End Set
    End Property

    Public Property pCve_Sucursal() As String
        Get
            Return varPub.Cve_Sucursal
        End Get
        Set(ByVal value As String)
            varPub.Cve_Sucursal = value
        End Set
    End Property

    'Private Property pId_Cajero As String   '08/08/2020
    'Public Property NewProperty() As String
    '    Get
    '        Return varPub.Id_Cajero
    '    End Get
    '    Set(ByVal value As String)
    '        varPub.Id_Cajero = value
    '    End Set
    'End Property

    Public Property pCve_Cliente() As String
        Get
            Return varPub.Cve_Cliente
        End Get
        Set(ByVal value As String)
            varPub.Cve_Cliente = value
        End Set
    End Property

    Public Property pNombre_Sucursal() As String
        Get
            Return varPub.Nombre_Sucursal
        End Get
        Set(ByVal value As String)
            varPub.Nombre_Sucursal = value
        End Set
    End Property

    Public Property pConectividad() As Integer
        Get
            Return varPub.Conectividad
        End Get
        Set(ByVal value As Integer)
            varPub.Conectividad = value
        End Set
    End Property

    Public Property pConexionwebAdmin() As Integer
        Get
            Return varPub.ConexionwebAdmin
        End Get
        Set(ByVal value As Integer)
            varPub.ConexionwebAdmin = value
        End Set
    End Property

    Public Property pNumLineasEnBlanco() As Integer
        Get
            Return varPub.Num_LineasBlanco
        End Get
        Set(ByVal value As Integer)
            varPub.Num_LineasBlanco = value
        End Set
    End Property

    Public Property pNumCopiasImprimir() As Integer
        Get
            Return varPub.Num_CopiasImprimir
        End Get
        Set(ByVal value As Integer)
            varPub.Num_CopiasImprimir = value
        End Set
    End Property

    Public Property pPrioridadPriv() As Integer
        Get
            Return varPub.Prioridad_Priv
        End Get
        Set(ByVal value As Integer)
            varPub.Prioridad_Priv = value
        End Set
    End Property

    Public Property pCliente() As String
        Get
            Return varPub.Cliente
        End Get
        Set(ByVal value As String)
            varPub.Cliente = value
        End Set
    End Property

    Public Property pDireccion() As String
        Get
            Return varPub.Direccion
        End Get
        Set(ByVal value As String)
            varPub.Direccion = value
        End Set
    End Property

    Public Property pNombreCorto() As String
        Get
            Return varPub.Nombre_Corto
        End Get
        Set(ByVal value As String)
            varPub.Nombre_Corto = value
        End Set
    End Property

    Public Property pTelefono() As String
        Get
            Return varPub.Telefono
        End Get
        Set(ByVal value As String)
            varPub.Telefono = value
        End Set
    End Property

    Public Property pCiaTV() As String
        Get
            Return varPub.CiaTV
        End Get
        Set(ByVal value As String)
            varPub.CiaTV = value
        End Set
    End Property

    Public Property pDepositoP() As Integer
        Get
            Return varPub.ID_DepositoP
        End Get
        Set(ByVal value As Integer)
            varPub.ID_DepositoP = value
        End Set
    End Property

    Public Property pUlt_Retiro() As Integer
        Get
            Return varPub.ID_UltimoRetiro
        End Get
        Set(ByVal value As Integer)
            varPub.ID_UltimoRetiro = value
        End Set
    End Property

    Public Property pconexweb() As String
        Get
            Return varPub.cnx_SucursalWeb
        End Get
        Set(ByVal value As String)
            varPub.cnx_SucursalWeb = value
        End Set
    End Property

    Public Property pCUNICA() As String
        Get
            Return varPub.CUNICA
        End Get
        Set(ByVal value As String)
            varPub.CUNICA = value
        End Set
    End Property
    Public Property pComprobacion() As String
        Get
            Return varPub.Comprobacion
        End Get
        Set(ByVal value As String)
            varPub.Comprobacion = value
        End Set
    End Property
    Public Property pVersionNvo() As String
        Get
            Return varPub.VersionNvo
        End Get
        Set(ByVal value As String)
            varPub.VersionNvo = value
        End Set
    End Property
    Public Property pVersionAnt() As String
        Get
            Return varPub.VersionAnt
        End Get
        Set(ByVal value As String)
            varPub.VersionAnt = value
        End Set
    End Property

    Public Property pManejaCorte() As Integer
        Get
            Return varPub.ManejaCorte
        End Get
        Set(ByVal value As Integer)
            varPub.ManejaCorte = value
        End Set
    End Property

    Public Property pCorteActual() As String
        Get
            Return varPub.CorteActual
        End Get
        Set(ByVal value As String)
            varPub.CorteActual = value
        End Set
    End Property

    Public Property pTipoMonedaV1() As String
        Get
            Return varPub.TipoMonedaV1
        End Get
        Set(ByVal value As String)
            varPub.TipoMonedaV1 = value
        End Set
    End Property
    Public Property pTipoMonedaV2() As String
        Get
            Return varPub.TipoMonedaV2
        End Get
        Set(ByVal value As String)
            varPub.TipoMonedaV2 = value
        End Set
    End Property

    Public Property pCantidadCajas() As Integer
        Get
            Return varPub.Cantidad_Cajas
        End Get
        Set(ByVal value As Integer)
            varPub.Cantidad_Cajas = value
        End Set
    End Property

    Public Property pManejaConexionWebService As Integer
        Get
            Return varPub.ManejaConexionWebService
        End Get
        Set(value As Integer)
            varPub.ManejaConexionWebService = value
        End Set
    End Property

    Public Property pPorcentajeBateriaBaja As Integer
        Get
            Return varPub.PorcentajeBateriaBaja
        End Get
        Set(value As Integer)
            varPub.PorcentajeBateriaBaja = value
        End Set
    End Property

    Public Property pPorcentajeBateriaCritica As Integer
        Get
            Return varPub.PorcentajeBateriaCritica
        End Get
        Set(value As Integer)
            varPub.PorcentajeBateriaCritica = value
        End Set
    End Property


    Public Property pBateriaBaja As Integer
        Get
            Return varPub.BateriaBaja
        End Get
        Set(value As Integer)
            varPub.BateriaBaja = value
        End Set
    End Property


    Public Property pBateriaCritica As Integer
        Get
            Return varPub.BateriaCritica
        End Get
        Set(value As Integer)
            varPub.BateriaCritica = value
        End Set
    End Property


    Public Property pPuertoSensores As String
        Get
            Return varPub.PuertoSensores
        End Get
        Set(value As String)
            varPub.PuertoSensores = value
        End Set
    End Property

    Public Property pManejaDepositoManual As Integer
        Get
            Return varPub.ManejaDepositoManual
        End Get
        Set(value As Integer)
            varPub.ManejaDepositoManual = value
        End Set
    End Property

    Public Property pManejaFolioManual As Integer
        Get
            Return varPub.ManejaFolioManual
        End Get
        Set(value As Integer)
            varPub.ManejaFolioManual = value
        End Set
    End Property
    Public Property pvalidarFolio As Integer
        Get
            Return varPub.ValidarFolio
        End Get
        Set(value As Integer)
            varPub.ValidarFolio = value
        End Set
    End Property
    Public Property pconexion As Integer
        Get
            Return varPub.Conexion
        End Get
        Set(value As Integer)
            varPub.Conexion = value
        End Set
    End Property
    Public Property pTrabajar_sin As Integer
        Get
            Return varPub.Trabajar_sin
        End Get
        Set(value As Integer)
            varPub.Trabajar_sin = value
        End Set
    End Property
    Public Property Id_caj As String
        Get
            Return varPub.Id_Caje
        End Get
        Set(value As String)
            varPub.Id_Caje = value
        End Set
    End Property
    Public Property Plaza As String
        Get
            Return varPub.Plaza
        End Get
        Set(value As String)
            varPub.Plaza = value
        End Set
    End Property
#End Region
End Class
Public Class cls_VariablesPersistentes

#Region "Variables Privadas"
    Dim Persistente As New Cls_Propiedades()

#End Region


#Region "Metodos Públicos"

    Public Function Existe() As Boolean
        Return True
    End Function

    Public Function Cargar() As Boolean

        Dim Response As DataTable = fn_ParametrosGet()
        'Dim Persistente As New cls_VariablesPersistentes()
        Dim GetTypeC As Type = Persistente.GetType()
        Dim GetProperties As PropertyInfo() = GetTypeC.GetProperties()
        For Each row As DataColumn In Response.Columns
            For Each oProperty As PropertyInfo In GetProperties
                If row.ColumnName = oProperty.Name Then
                    oProperty.SetValue(Persistente, Response.Rows(0)(row.ColumnName))
                End If
            Next
        Next
        Return True
    End Function
    Public Sub Persistir()
        fn_configuracion()
    End Sub

#End Region

End Class
