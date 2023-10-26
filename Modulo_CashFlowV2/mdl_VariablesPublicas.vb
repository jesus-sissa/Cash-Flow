
Module mdl_VariablesPublicas

    Structure VariablesPublicas

        Dim Imprimir_DetalleCD As Integer
        Dim Logo_Empresa As Byte()
        Dim Logo_EmpresaRuta As String

        Dim hostNameOrAddress As String
        Dim Version_CashFlow As String
        Dim Inicio_Operaciones As Date
        Dim Mail_Sucursal As String

        Dim ultFila_DTimpreso As Integer
        Dim continuaImprimiendo As Integer
        Dim Paginacion As Integer
        Dim ultBilleteDepositado As String
        Dim Tipo_CorteDiario As Integer

        Dim ConexionwebAdmin As Integer
        Dim Conectividad As Integer
        Dim Conectado As Integer
        Dim Prioridad_Priv As Integer
        Dim Num_CopiasImprimir As Integer
        Dim Num_LineasBlanco As Integer

        Dim Ubicacion_ftp As String
        Dim Usuario_ftp As String
        Dim Password_ftp As String
        Dim VerificaUpdate As String

        Dim TipoCambio As Integer
        Dim Reimpresion As Integer

        Dim cnx_Local As String
        Dim cnx_SucursalWeb As String
        Dim CUNICA As String
        Dim TamañoFuente_Mensajes As Integer
        Dim TamañoFuente_Etiqueta As Integer
        Dim TamañoFuente_Botones As Integer

        Dim Tamaño_Papel As Integer
        Dim Tipo_Windows As Integer

        Dim MargenIzq As Integer
        Dim NombreUser As String

        Dim Cant_Validadores As Integer
        Dim Serie_Val1 As String
        Dim Serie_Val2 As String

        Dim Serie_Caset1 As String
        Dim Serie_Caset2 As String

        Dim Puerto_Val1 As String
        Dim Puerto_Val2 As String

        Dim Activar_Val1 As Integer
        Dim Activar_Val2 As Integer

        Dim S_dtb As String
        Dim B_dtb As String
        Dim U_dtb As String
        Dim P_dtb As String
        Dim Cve_Sucursal As String
        Dim Nombre_Sucursal As String
        Dim Id_Cajero As String         '08/08/2020
        Dim Nombre_Corto As String
        Dim Cve_Cliente As String
        Dim IP_Publica As String
        Dim IdPantalla As Integer

        Dim Nombre_Archivo As String
        Dim TimeOut_Receptor As Integer
        Dim TimeOut_Sesion As Integer
        Dim Ult_Archivo As String
        Dim Ruta_Log As String
        Dim Dias_Expira As Integer

        Dim CiaTV As String

        Dim ID_DepositoP As Integer
        Dim ID_UltimoRetiro As Integer

        Dim LimiteCapacidad_Kct As Integer
        Dim LimiteCapacidad_Kct2 As Integer

        Dim Caset2ID As Integer
        Dim Capacidad_Caset2 As Integer
        Dim Porcentaje_Alerta2 As Integer
        Dim Capacidad_Actual2 As Integer

        Dim CasetID As Integer
        Dim Capacidad_Caset As Integer
        Dim Porcentaje_Alerta As Integer
        Dim Capacidad_Actual As Integer

        Dim Cliente As String
        Dim Direccion As String
        Dim Telefono As String
        Dim Detalle_Anterior As String

        Dim MinutosUltimaConexion As Integer
        Dim SegundosSesion As Integer
        Dim SegundosReceptor As Integer

        Dim UsuarioClave As Integer
        Dim Intentos_Log As Integer

        Dim TipoUser As Integer
        Dim Hora_Inicio As String
        Dim Hora_Fin As String

        Dim Resp As Boolean
        Dim TextoCopiado As String
        Dim NombreImpresora As String
        Dim Modo_Impresion As Integer

        Dim Comprobacion As String
        Dim VersionNvo As Integer
        Dim VersionAnt As Integer
        Dim ManejaCorte As Integer
        Dim CorteActual As Integer

        Dim TipoMonedaV1 As String ' 1=peso 2=Dolar 3=ambos
        Dim TipoMonedaV2 As String ' 1=peso 2=Dolar 3=ambos

        Dim Cantidad_Cajas As Integer
        Dim Id_Transaccion As Integer ' Se usará para guardar la transaccion actual y insertarlo en la tabla depositos
        Dim FolioDeposito As String ' Se usara para guardar el Folio actual del deposito para insertar en la transaccion
        Dim Folio As String ' Se usará para guardar el folio de la transaccion
        Dim DepositoFinalizado As Boolean ' Se usurá para validar si el depósito ya fue finalizado para eliminar la Clave "K_IN" del Objeto Statuscajero
        ' de tipo Dictionary que se encuentre en la clase cls_DepositosXValidadorWebS para que si otro punto de venta inicie una peticion el cajero pueda escucharlo
        Dim CajeroStatus As String
        Dim ManejaConexionWebService As Integer
        Dim EsDepositoNormal As Boolean
        Dim PorcentajeBateriaBaja As Integer
        Dim PorcentajeBateriaCritica As Integer
        Dim BateriaBaja As Integer
        Dim BateriaCritica As Integer
        Dim PuertoSensores As String
        Dim ManejaDepositoManual As Integer '05/02/2018 JAVIER ZAPATA (sin depositos manuales)
        Dim ManejaFolioManual As Integer
        Dim ValidarFolio As Integer
        Dim Conexion As Integer
        Dim Id_caja As String
        Dim FolioManual As String ' Para almacenar el folio introducido por el usuario
        Dim Dt_Cajascnx As DataTable
        'variables de cadena de conexion externa
        Dim CajasCnx As String

        Dim D_On As Boolean
        Dim state As Boolean
        'conectividad 
        Dim Trabajar_sin As Integer
        Dim Id_Caje As String
        Dim Plaza As String
        Dim FlagImprimirTicket As Integer
        'Variables utilizadas para gestionar la recoleccion por web service 09/06/21 #0001
        Dim Id_punto As Integer
        Dim RemisionWs As String
        Dim Envase_Valido As Boolean
        Dim Remision_Valida As Boolean
        Dim Urd As Boolean
        'Fin #0001

    End Structure

    Structure VariablesTeclado
        Dim DesktopSize As Size
        Dim AnchoPantalla As Integer
        Dim AltoPantalla As Integer

        Dim ubicaX_Teclado As Integer
        Dim ubicaY_Teclado As Integer
        Dim PuntoNew_Teclado As Point
    End Structure

    Public varPub As VariablesPublicas
    Public varTecl As VariablesTeclado

    ''' <summary>
    ''' Fechapersonalizda con _ para nombre de archivo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CustomFecha() As String
        Get
            Return Format(Now, "_dd-MM-yyyy")
        End Get
    End Property

    ''' <summary>
    ''' Hora Personalizada con _ para nombre de archivo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CustomHora() As String
        Get
            Return Format(Now, "_HH-mm-ss")
        End Get
    End Property

    ''' <summary>
    ''' Regresa la Fecha Actual en formato yyyy-MM-dd
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public ReadOnly Property Fecha() As String
        Get
            Return Format(Now, "yyyy-MM-dd")
        End Get
    End Property

    ''' <summary>
    ''' Regresa la Hora Actual en formato HH:mm:ss (24 hrs.)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public ReadOnly Property Hora() As String
        Get
            Return Format(Now, "HH:mm:ss")
        End Get
    End Property

    Sub main()
        'inicializamos las variables con valores por defecto, 
        'llamar este main en load del primer formulario
        varPub.Logo_EmpresaRuta = ""
        varPub.hostNameOrAddress = "www.google.com.mx"
        varPub.Version_CashFlow = ""
        varPub.Inicio_Operaciones = Now.Date
        varPub.Mail_Sucursal = ""

        varPub.ultFila_DTimpreso = 0 'ultima fila de la tabla impresa 11/02/2014
        varPub.continuaImprimiendo = False ' continau rimprimiendo Hojas 11/02/2014
        varPub.Paginacion = 1 ' Numero de paginas
        varPub.ultBilleteDepositado = "01/01/1900 00:00:00"

        varPub.Tipo_CorteDiario = 0
        '1= Todos los Depositos 'F' desde ultimo Retiro
        '2= Todos los depositos del dia actual
        varPub.ConexionwebAdmin = 2 '1=conectado, 2 = desconectado
        varPub.Conectividad = False
        varPub.Prioridad_Priv = 1 ' 1=local, 2= web
        varPub.Num_CopiasImprimir = 1 ' Numero de copias de impresion (depositos/Recolección)
        varPub.Num_LineasBlanco = 1

        varPub.Ubicacion_ftp = ""
        varPub.Usuario_ftp = ""
        varPub.Password_ftp = ""
        varPub.VerificaUpdate = ""

        varPub.TipoCambio = 1.0 'Tipo de cambio
        varPub.Reimpresion = False
        '-------var cnx bdd --
        'varPub.cnx_Local = System.Configuration.ConfigurationManager.ConnectionStrings("ConexionLocal").ConnectionString
        varPub.CUNICA = ""

        '----------------------
        varPub.TamañoFuente_Mensajes = 14
        varPub.TamañoFuente_Etiqueta = 16
        varPub.TamañoFuente_Botones = 16

        varPub.Tamaño_Papel = 1  ' 1=80 mm' , 2='56 mm'
        varPub.Tipo_Windows = 1 ' 1=Normal, 2= embebido

        varPub.MargenIzq = 0
        varPub.NombreUser = ""
        varPub.Cant_Validadores = 1
        varPub.Serie_Val1 = ""
        varPub.Serie_Val2 = ""

        varPub.Serie_Caset1 = ""
        varPub.Serie_Caset2 = ""

        varPub.Puerto_Val1 = ""
        varPub.Puerto_Val2 = ""

        varPub.Activar_Val1 = True
        varPub.Activar_Val2 = True
        varPub.Cve_Sucursal = ""
        varPub.Nombre_Sucursal = ""
        varPub.Nombre_Corto = ""
        varPub.Cve_Cliente = ""
        varPub.MinutosUltimaConexion = 3
        varPub.TimeOut_Receptor = 60
        varPub.TimeOut_Sesion = 80
        varPub.Ult_Archivo = "" '
        varPub.Dias_Expira = 30 'default
        varPub.LimiteCapacidad_Kct = 600  'new 20/11/2014
        varPub.LimiteCapacidad_Kct2 = 600  'new 25/11/2014
        varPub.Detalle_Anterior = ""

        ' -------- --------
        varPub.SegundosSesion = 0
        varPub.SegundosReceptor = 0
        varPub.Intentos_Log = 0
        varPub.TipoUser = 9 'debe ser <> 0
        varPub.Resp = False
        varPub.TextoCopiado = ""
        varPub.NombreImpresora = ""
        varPub.Modo_Impresion = 0 ' 1=windows 2= nippon, 3=Zebra
        varPub.Comprobacion = ""
        'Valores para el Teclado
        varTecl.AnchoPantalla = 800 ' 800 ' valores defaul del Monitor de 7"
        varTecl.AltoPantalla = 480 '480

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = 0
        varPub.Cantidad_Cajas = 0
        varPub.PorcentajeBateriaBaja = 50
        varPub.PorcentajeBateriaCritica = 29
        varPub.BateriaBaja = False 'valor que nos indica si la batería se considera baja
        varPub.BateriaCritica = False 'valor que nos indica si la batería se considera crítica
        varPub.PuertoSensores = "COM18" 'puerto de los sensores
        varPub.ManejaDepositoManual = True  'depositos manuales no habrá en Litte Caesar´s 
        varPub.ManejaFolioManual = False
        varPub.Trabajar_sin = False
        varPub.FlagImprimirTicket = 1
    End Sub

End Module
