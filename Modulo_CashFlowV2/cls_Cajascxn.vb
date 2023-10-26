Imports System.Data.SqlClient
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Usuarios
Imports Modulo_CashFlowV2.cls_Oledb
Imports dataconection.cls_DatosSQL
Imports System.Configuration
Public Class cls_Cajascxn
    'Esto es un cambio con GIT
    Public Shared Function fn_CajasConsultarCnx() As DataTable
        Dim dt As DataTable
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajascnx_Read", CommandType.StoredProcedure, Cnn)
            'Crear_ParametroSQL(Cmd, "@Id_caja", SqlDbType.Int, id_caja)
            dt = Ejecutar_ConsultaSQL(Cmd)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Shared Function fn_CajasConsultarCnx(Id_Caja As String) As DataTable
        Dim dt As DataTable
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajascnx_Get", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_caja", SqlDbType.Int, Id_Caja)
            dt = Ejecutar_ConsultaSQL(Cmd)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Shared Function fn_CajasGuardarCnx(ByVal Datasource As String, ByVal Initialcatalog As String, ByVal user As String, ByVal pass As String, ByVal id_caja As Integer) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Cajascnx_create", CommandType.StoredProcedure, cnn)
        Try
            Crear_ParametroSQL(cmd, "@Datasource", SqlDbType.VarChar, Datasource, False)
            Crear_ParametroSQL(cmd, "@Initialcatalog", SqlDbType.VarChar, Initialcatalog)
            Crear_ParametroSQL(cmd, "@User", SqlDbType.VarChar, user, False)
            Crear_ParametroSQL(cmd, "@Pass", SqlDbType.VarChar, pass, False)
            Crear_ParametroSQL(cmd, "@Id_caja", SqlDbType.Int, id_caja, False)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, "A",)
            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 64, varPub.IdPantalla, "DEPOSITOS - " + ": Error AL GUARDAR LA CONEXION DE LA CAJA  ")
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ": Error AL GUARDAR LA CONEXION DE LA CAJA  ")
            Call fn_MsgBox("Error al guardar la cadena de conexion de la caja.", MessageBoxIcon.Error)
            Return False
        End Try
        Return Nothing
    End Function

    Public Shared Function fn_CajasActualizarCnx(ByVal Datasource As String, ByVal Initialcatalog As String, ByVal user As String, ByVal pass As String, ByVal id_caja As Integer) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Cajascnx_update", CommandType.StoredProcedure, cnn)
        Try
            Crear_ParametroSQL(cmd, "@Datasource", SqlDbType.VarChar, Datasource, False)
            Crear_ParametroSQL(cmd, "@Initialcatalog", SqlDbType.VarChar, Initialcatalog, False)
            Crear_ParametroSQL(cmd, "@User", SqlDbType.VarChar, user, False)
            Crear_ParametroSQL(cmd, "@Pass", SqlDbType.VarChar, pass, False)
            Crear_ParametroSQL(cmd, "@Id_caja", SqlDbType.Int, id_caja, False)
            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 63, varPub.IdPantalla, "DEPOSITOS - " + ": Error AL ACTUALIZAR LA CONEXION DE LA CAJA  ")
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ": Error AL ACTUALIZAR LA CONEXION DE LA CAJA  ")
            Call fn_MsgBox("Error al actualizar la cadena de conexion de la caja.", MessageBoxIcon.Error)
            Return False
        End Try
        Return Nothing
    End Function
    Public Shared Function fn_CajasStatus(ByVal id_caja As Integer, ByVal status As String) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim cmd As SqlCommand = Crear_ComandoSQL("Cajascnx_staus_Update", CommandType.StoredProcedure, cnn)
        Try
            Crear_ParametroSQL(cmd, "@Id_caja", SqlDbType.VarChar, id_caja)
            Crear_ParametroSQL(cmd, "@Status", SqlDbType.VarChar, status)
            Ejecutar_NonQuerySQL(cmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return Nothing
    End Function

    Public Shared Function fn_CajasProbarCnx(ByVal DataSource As String, ByVal InitialCatalog As String, ByVal User As String, ByVal Pass As String) As Boolean
        Dim Con As SqlConnection = Crear_ConexionSQL("Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + "; User id=" + User + "; pwd=" + Pass + " ;")
        Try
            Con.Open()
            Con.Close()
            Return True
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 14, varPub.IdPantalla, "CAJAS - " + ": Error AL CONSULTAR LA CONEXION DE LA CAJA  ")
            Call fn_EscribirLog(varPub.UsuarioClave, "CAJAS", ": Error AL CONSULTAR LA CONEXION DE LA CAJA  ")
            Call fn_MsgBox("Error cadena de conexion no valida.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''SQLOLEDB
    Public Shared Function fn_CajasProbarCnxOledb(ByVal DataSource As String, ByVal InitialCatalog As String, ByVal User As String, ByVal Pass As String) As Boolean
        Try
            Return Crear_CnxOledb("Provider=SQLOLEDB; Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + "; User id=" + User + "; password=" + Pass + " ;")
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 14, varPub.IdPantalla, "CAJAS - " + ": Error AL CONSULTAR LA CONEXION DE LA CAJA  ")
            Call fn_EscribirLog(varPub.UsuarioClave, "CAJAS", ": Error AL CONSULTAR LA CONEXION DE LA CAJA  ")
            Call fn_MsgBox("Error cadena de conexion no valida.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
