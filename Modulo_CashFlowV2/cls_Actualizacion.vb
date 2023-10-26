
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class cls_Actualizacion

#Region "Modificando Estructura de las tablas de SQLCE en caso de Update al CashFlow"




    ''' <summary>
    ''' Consulta que nos trae todas las columnas de la Tabla indicada
    ''' </summary>
    ''' <param name="NombreTabla"> Nombre de la Tabla del cual obtendremos sus columnas</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Columnas_Consultar(ByVal NombreTabla As String) As DataTable
        'Try
        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim cmd As SqlCeCommand = Nothing

        '    'TRAER TODAS LAS COLUMNAS DE LA TABLA
        '    Dim Query As String = "SELECT COLUMN_NAME " & _
        '                          "FROM INFORMATION_SCHEMA.COLUMNS " & _
        '                          "WHERE TABLE_NAME= '" & NombreTabla & "'"
        '    cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Dim ColumnaBuscar As DataTable = Ejecutar_ConsultaSQLCE(cmd)

        '    Return ColumnaBuscar

        'Catch ex As Exception
        '    Return Nothing
        'End Try
    Return Nothing
    End Function

    ''' <summary>
    ''' Funcion que busca si la tabla que deseamos crear existe en la BDD
    ''' </summary>
    ''' <param name="NombreTabla"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function fn_Buscar_TablaenBDD(ByVal NombreTabla As String) As DataTable
        'Try
        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim cmd As SqlCeCommand = Nothing

        '    '{BUSCANDO SI TABLA A CREAR EXISTE EN LA BASE DE DATOS'
        '    Dim Query As String = "SELECT TABLE_NAME AS NOMBRETABLA " & _
        '                          "FROM INFORMATION_SCHEMA.TABLES " & _
        '                          "WHERE TABLE_TYPE='TABLE' AND TABLE_NAME= '" & NombreTabla & "'"
        '    cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Dim TablaBuscar As DataTable = Ejecutar_ConsultaSQLCE(cmd)

        '    Return TablaBuscar

        'Catch ex As Exception
        '    Return Nothing
        'End Try
      Return Nothing
    End Function

    ''' <summary>
    ''' Funcion para crear y/o modificar campos, crear Tablas nuevas
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public Shared Function fn_AlterarEsctructura_SQLCE() As Boolean
        Return True
    End Function

    Public Shared Function fn_AlterarEsctructura_SQLCE_version1cash() As Boolean
        ' esta funcion era para la version 1, por lo tanto los cambios que hay en el codigo
        ' ya no aplica ya que en la V2 ya viene todo corregido.
        ' si llegara haber mas cambios posteriores solo hay que hacer 
        'algo similar al codigo de aqui y ponerlo en la funcion  --> fn_AlterarEsctructura_SQLCE

        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIO - ALTERANDO LA ESTRUCTURA DE LA BDD SQL CE")
        'Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        'Dim tr As SqlCeTransaction = Crear_TransSQLCE(cnn)
        'Dim cmd As SqlCeCommand = Nothing
        'Dim Query As String = ""

        'Try

        '    '---->>>>Consulta que trae todas las tablas de la BDD<<<<<<<-----
        '    'Query = "Select Table_Name " & _
        '    '        "From Information_Schema.Tables " & _
        '    '        "Where Table_Type='Table' "
        '    'cmd = Crea_Comando(Query, CommandType.Text, cnn)
        '    'EjecutarNonQuery(cmd)


        '    Dim dt_BuscaCampoenTabla As DataTable = Nothing
        '    Dim dt_BuscarTabla As DataTable = Nothing
        '    Dim dt_TraerColumnas As DataTable = Nothing

        '    'Buscarmos si la tabla existe en la BBD
        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "BUSCA SI EXISTE LA TABLA «Opciones» EN LA BDD")
        '    dt_BuscarTabla = fn_Buscar_TablaenBDD("Opciones") 'Actualizacion

        '    If dt_BuscarTabla IsNot Nothing Then
        '        ''significa que No hubo error

        '        'Proceso de insercion de Registros y Update en la tabla Opciones 26/10/2015
        '        If dt_BuscarTabla.Rows.Count = 1 Then
        '            'La tabla si Existe

        '            Dim cuentaCol As Byte = 0
        '            Dim cont As Byte = 0
        '            Dim Columnas() As String = {"Orden_Opcion", "Clave_Opcion", "Descripcion", "Nombre_Boton", "Tipo", "Status"}

        '            'Buscar en Tabla "Opciones" 6 Columnas
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " VERIFICAR QUE TENGA LAS 6 COLUMNAS EN LA TABLA «Opciones» ")
        '            dt_TraerColumnas = fn_Columnas_Consultar("Opciones")

        '            If dt_TraerColumnas IsNot Nothing Then
        '                'sino hubo error
        '                For Each fila As DataRow In dt_TraerColumnas.Rows
        '                    If fila("COLUMN_NAME") = Columnas(cont) Then
        '                        cuentaCol += 1
        '                    End If
        '                    cont += 1
        '                Next

        '            End If

        '            Dim colDescripcion() As String = {"Depositar", "Recolectar", "Diario", "Validar", "Depositos", "Recolecciones", "Saldo", "Movimientos", "Cartuchos", "Usuarios", "Cambiar"}
        '            Dim colClaveOpcion() As String = {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "13"}

        '            If cuentaCol = 6 Then
        '                'Si existen las 6 columnas, Iniciar proceso de Update 
        '                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " ACTUALIZAR EL CAMPO <Descripcion> EN LA TABLA «Opciones» ")

        '                For fila As Integer = 0 To colDescripcion.Length - 1
        '                    Try
        '                        Query = "Update Opciones " & _
        '                                " Set Descripcion = '" & colDescripcion(fila) & "' " & _
        '                                " Where Clave_Opcion = '" & colClaveOpcion(fila) & "' "
        '                        cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '                        Ejecutar_NonQueryTSQLCE(cmd)
        '                    Catch ex As Exception
        '                        'Deshacer cambios en transaccion y/o no copiar .exe
        '                        ' Return False
        '                    End Try
        '                Next

        '                'Continuar con Proceso de Insercion de Registros

        '                Try
        '                    ' buscar si las claves a insertar existen
        '                    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI LA CLAVE 15 YA EXISTE, ANTES DE INSERTAR EN TABLA «Opciones» ")
        '                    Dim dt_claveExiste As DataTable = Nothing

        '                    Query = "Select Clave_Opcion " & _
        '                            "From Opciones " & _
        '                            "Where Clave_Opcion = '15' "
        '                    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '                    dt_claveExiste = Ejecutar_ConsultaTSQLCE(cmd)


        '                    If dt_claveExiste IsNot Nothing Then
        '                        If dt_claveExiste.Rows.Count = 0 Then
        '                            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " INSERTANDO LA CLAVE 15 EN TABLA «Opciones» ")
        '                            Query = "Insert Into Opciones(Orden_Opcion, Clave_Opcion, Descripcion, Nombre_Boton, Tipo, Status) " & _
        '                                     "Values(15,'15','Reiniciar','btn_ReiniciarImpresora',1,'A')"
        '                            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '                            Ejecutar_NonQueryTSQLCE(cmd)
        '                        End If
        '                    End If

        '                    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI LA CLAVE 16 YA EXISTR, ANTES DE INSERTAR EN TABLA «Opciones» ")
        '                    Query = "Select Clave_Opcion " & _
        '                           "From Opciones " & _
        '                           "Where Clave_Opcion = '16' "

        '                    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '                    dt_claveExiste = Ejecutar_ConsultaTSQLCE(cmd)

        '                    If dt_claveExiste IsNot Nothing Then
        '                        If dt_claveExiste.Rows.Count = 0 Then
        '                            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " INSERTANDO LA CLAVE 16 EN TABLA «Opciones» ")
        '                            Query = "Insert Into Opciones(Orden_Opcion, Clave_Opcion, Descripcion, Nombre_Boton, Tipo, Status) " & _
        '                                    "Values(16,'16','Auditoria','btn_Auditoria',2,'A')"
        '                            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '                            Ejecutar_NonQueryTSQLCE(cmd)
        '                        End If
        '                    End If


        '                Catch ex As Exception
        '                    'Deshacer cambios en transaccion y/o no copiar .exe
        '                    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "OCURRIÓ UN ERROR EN EL PROCESO DE INSERTAR REGISTROS: " & ex.Message.ToUpper)
        '                    ' Return False
        '                End Try
        '            Else
        '                ' Return False
        '            End If ' fin cuenta=6

        '        End If
        '    End If


        '    'Por cada campo nuevo a Insertar, se debe verificar si
        '    'ya existe en la tabla 04/11/2015

        '    'Agregar nuevo campo(Importe_Otros) a la tabla RETIROS
        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR  SI LA COLUMNA <Importe_Otros> YA EXISTE EN LA TABLA «Retiros» ")
        '    dt_BuscaCampoenTabla = fn_Buscar_ColumnaenTabla(cnn, tr, "Retiros", "Importe_Otros")

        '    If dt_BuscaCampoenTabla Is Nothing Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " OCURRIÓ UN ERROR AL INSERTAR LA COLUMNA <Importe_Otros> EN LA TABLA «Retiros» ")
        '    Else
        '        If dt_BuscaCampoenTabla.Rows.Count = 0 Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INSERTAR LA COLUMNA <Importe_Otros> EN LA TABLA «Retiros» ")

        '            'si no existe Campo, insertaR
        '            '---->>>>insertando Campo nuevo en la Tabla especificada 
        '            Query = "Alter Table Retiros " & _
        '                    "Add Importe_Otros Money"
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '            ' Si el campo se inserto, entonces se debe hacer alter a la tabla
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ACTUALIZANDO EN CAMPO <Importe_Otros> CON EL VALOR DE 0.0 «Retiros» ")
        '            Query = "Update Retiros " & _
        '                    " Set Importe_Otros = 0.0 "
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)
        '        End If


        '    End If

        '    '------------15/Agosto 2016----------------
        '    'agregar nuevo campo(Nombre_Corto) a la tabla USUARIOS

        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI LA COLUMNA <Nombre_Corto> YA EXISTE EN LA TABLA «Usuarios» ")
        '    dt_BuscaCampoenTabla = fn_Buscar_ColumnaenTabla(cnn, tr, "Usuarios", "Nombre_Corto")
        '    If dt_BuscaCampoenTabla Is Nothing Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " OCURRIÓ UN ERROR AL INSERTAR LA COLUMNA <Nombre_Corto> EN LA TABLA «Usuarios» ")
        '    Else
        '        If dt_BuscaCampoenTabla.Rows.Count = 0 Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INSERTAR LA COLUMNA <Nombre_Corto> EN LA TABLA «Usuarios» ")

        '            'si no existe Campo, insertaR
        '            '---->>>>insertando Campo nuevo en la Tabla especificada 
        '            Query = "Alter Table Usuarios " & _
        '                    "Add Nombre_Corto nvarchar(20)"
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '            ' Si el campo se inserto, entonces se debe hacer alter a la tabla
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ACTUALIZANDO EN CAMPO <Nombre_Corto> CON EL VALOR DE "" «Usuarios» ")
        '            Query = "Update Usuarios " & _
        '                    " Set Nombre_Corto = '' "
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '        End If
        '    End If


        '    '-----ver 2-------26 de Septiembre 2016----------------
        '    'agregar nuevo campo(Tipo) a la tabla DEPOSITOS
        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI LA COLUMNA <Tipo> YA EXISTE EN LA TABLA «Depositos» ")
        '    dt_BuscaCampoenTabla = fn_Buscar_ColumnaenTabla(cnn, tr, "Depositos", "Tipo")
        '    If dt_BuscaCampoenTabla Is Nothing Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " OCURRIÓ UN ERROR AL INSERTAR LA COLUMNA <Tipo> EN LA TABLA «Depositos» ")
        '    Else
        '        If dt_BuscaCampoenTabla.Rows.Count = 0 Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INSERTAR LA COLUMNA <Tipo> EN LA TABLA «Depositos» ")

        '            'si no existe Campo, insertaR
        '            '---->>>>insertando Campo nuevo en la Tabla especificada 
        '            Query = "Alter Table Depositos " & _
        '                    "Add Tipo Tinyint"
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '            ' Si el campo se inserto, entonces se debe hacer alter a la tabla
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ACTUALIZANDO EN CAMPO <Tipo> CON EL VALOR DE 1 «Depositos» ")
        '            Query = "Update Depositos " & _
        '                    " Set Tipo = 1 "
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '        End If
        '    End If
        '    '------------------------------------

        '    '------ver. 3------13 Octubre 2016----------------
        '    'agregar nuevo campo(Fecha_Modifica) a la tabla USUARIOS

        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI LA COLUMNA <FechaModifica> YA EXISTE EN LA TABLA «Usuarios» ")
        '    dt_BuscaCampoenTabla = fn_Buscar_ColumnaenTabla(cnn, tr, "Usuarios", "FechaModifica")
        '    If dt_BuscaCampoenTabla Is Nothing Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " OCURRIÓ UN ERROR AL INSERTAR LA COLUMNA <FechaModifica> EN LA TABLA «Usuarios» ")
        '    Else
        '        If dt_BuscaCampoenTabla.Rows.Count = 0 Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INSERTAR LA COLUMNA <FechaModifica> EN LA TABLA «Usuarios» ")

        '            'si no existe Campo, insertaR
        '            '---->>>>insertando Campo nuevo en la Tabla especificada 
        '            Query = "Alter Table Usuarios " & _
        '                    "Add Fecha_Modifica datetime"
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '            '' Si el campo se inserto, entonces se debe hacer alter a la tabla
        '            'Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "ACTUALIZANDO EN CAMPO <FechaModifica> CON EL VALOR DE GetDate() «Usuarios» ")
        '            'Query = "Update Usuarios " & _
        '            '        " Set FechaModifica = GetDate() "
        '            'cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            'Ejecutar_NonQueryTSQLCE(cmd)

        '        End If
        '    End If
        '    '---------------------------------

        '    '----ver 3 --------13 Octubre 2016----------------
        '    'agregar nuevo campo(Fecha_Modifica) a la tabla CASETS

        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICAR SI LA COLUMNA <FechaModifica> YA EXISTE EN LA TABLA «Casets» ")
        '    dt_BuscaCampoenTabla = fn_Buscar_ColumnaenTabla(cnn, tr, "Casets", "FechaModifica")
        '    If dt_BuscaCampoenTabla Is Nothing Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " OCURRIÓ UN ERROR AL INSERTAR LA COLUMNA <FechaModifica> EN LA TABLA «Casets» ")
        '    Else
        '        If dt_BuscaCampoenTabla.Rows.Count = 0 Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INSERTAR LA COLUMNA <FechaModifica> EN LA TABLA «Casets» ")

        '            'si no existe Campo, insertaR
        '            '---->>>>insertando Campo nuevo en la Tabla especificada 
        '            Query = "Alter Table Casets " & _
        '                    "Add Fecha_Modifica datetime"
        '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            Ejecutar_NonQueryTSQLCE(cmd)

        '            '' Si el campo se inserto, entonces se debe hacer alter a la tabla
        '            'Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "ACTUALIZANDO EN CAMPO <FechaModifica> CON EL VALOR DE GetDate() «Casets» ")
        '            'Query = "Update Casets " & _
        '            '        " Set FechaModifica = GetDate() "
        '            'cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '            'Ejecutar_NonQueryTSQLCE(cmd)

        '        End If
        '    End If

        '    '-----------------------------------------
        '    'Query = "Alter Table nombre_tabla " & _
        '    '        "Drop column nombre_ColumnaElimina "
        '    'cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    'Ejecutar_NonQueryTSQLCE(cmd)


        '    '09/11/2015 Cambiar Tipo de dato de algun <<Campo>> en las tablas
        '    'Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "Cambiando el tipo de dato de Id_Deposito(Int) por BigInt")

        '    'Query = "Alter Table Depositos  " & _
        '    '    " Alter Column Folio numeric(18,0) "
        '    'cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    'Ejecutar_NonQueryTSQLCE(cmd)

        '    'Query = "Alter Table DepositosD  " & _
        '    '        " Alter Column Serie_Validador nvarchar(20) "
        '    'cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    'Ejecutar_NonQueryTSQLCE(cmd)


        '    'Query = "Alter Table Retiros  " & _
        '    '        " Alter Column Numero_Remision numeric(18,0) "
        '    'cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    'Ejecutar_NonQueryTSQLCE(cmd)

        '    '*********************************

        '    'Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "Error al cambiar tipo de dato de Id_Deposito(Int) por BigInt")


        '    'ejemplo: Busca si la tabla a crear ya existe
        '    ' Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "Busca si existe la tabla «Actualizacion» en la BDD")
        '    ' dt_BuscarTabla = fn_Buscar_TablaenBDD("Actualizacion") 'Actualizacion

        '    'If dt_BuscarTabla IsNot Nothing Then
        '    ''significa que No hubo error

        '    'If dt_BuscarTabla.rows.Count = 0 Then
        '    ' Significa que no existe la tabla, Se debe crear
        '    '    '--->>>>creando Nueva tabla e insertando 3 campos nuevos
        '    '    '(1,1) =(incremento en 1, y valor incial 1)
        '    '    Query = "Create Table Actualizacion " & _
        '    '            "(Id_Actualizacion int Identity(1,1), " & _
        '    '            "Descripcion nvarchar(200)," & _
        '    '            "Fecha_Registro datetime) "
        '    '    cmd = Crea_Comando(Query, CommandType.Text, cnn)
        '    '    EjecutarNonQuery(cmd)
        '    'End If

        '    'Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "Fin de actualizar campos de la bdd SQL CE")
        '    '--Insertar detalle de la actualizacion mejoras-cambios etc

        '    '{
        '    'Query = "Insert Into Actualizacion(Descripcion,Fecha_Registro) " & _
        '    '       "Values('Se agregaron 2 nuevos campos en la tabla',getdate())"
        '    'cmd = Crea_Comando(Query, CommandType.Text, cnn)
        '    'EjecutarNonQuery(cmd)
        '    '}

        '    tr.Commit()
        '    tr.Dispose()
        '    cmd.Dispose()
        '    cnn.Dispose()
        '    Return True 'Si todo es correcto

        'Catch ex As Exception
        '    tr.Rollback() 'Rehacer transaccion
        '    cmd.Dispose()
        '    cnn.Dispose()
        '    Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - OCURRIÓ UN ERROR AL REALIZAR LA ACTUALIZACIÓN DE CAMPOS Y/O TABLAS.")
        '    Return False
        'End Try
  Return True
    End Function

    Public Shared Sub fn_Actualizacion_Llenar(ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA USUARIOS", "INICIO USUARIOS LLENAR LISTA")
        'Try

        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim Query As String = "Select Actualizacion, " & _
        '                          "CONVERT(nvarchar(10),Fecha_Registro,103) As FechaRegistro " & _
        '                          "From Usuarios "

        '    Dim cmd As SqlCeCommand = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Dim dt_Update As DataTable = Ejecutar_ConsultaSQLCE(cmd)

        '    'aqui no llevo nada en tag
        '    Call fn_LlenarListView(dt_Update, lsv, "", "")

        'Catch ex As Exception
        '    'Call fn_EscribirLog(UsuarioClave, "CONSULTA USUARIOS", "Error USUARIOS LLENAR LISTA: " & ex.Message)
        '    'Call fn_MsgBox(" Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        'End Try
    End Sub

    Public Shared Function fn_Actualizacion_Insertar(ByVal Descripcion As String) As Boolean
        ' Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "Inicio Insertar tipo de cambio del dia-" & TC_Nuevo)
        'Dim cmd As SqlCeCommand
        ''prueba de actualizacion de tabla nueva creada 
        ''e insertando un nuevo registro 22/10/2015

        'Try
        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)

        '    Dim Query As String = "Insert into Actualizacion(Descripcion,Fecha_Registro) " & _
        '          "Values('" & Descripcion & "',Getdate())"
        '    cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Ejecutar_NonQuerySQLCE(cmd)
        '    Return True

        'Catch ex As Exception
        '    'call(fn_EscribirLog(UsuarioClave, "PARAMETROS", "Error al Insertar tipo de cambio del dia: " & ex.Message))
        '    Return False
        'End Try
       Return True
    End Function

#End Region

End Class
