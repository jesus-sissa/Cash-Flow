Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Usuarios
Imports System.Text.RegularExpressions

Public Class cls_CashFlow
    Shared EliminoCorrectamente As Boolean
    Enum AccionWeb As Byte
        Actualizar = 0
        Respaldar = 1
    End Enum

    Enum TipoWindows As Byte
        Normal = 1
        Embebido = 2
    End Enum

    Enum ModoImpresion As Byte
        Windows = 1
        Nippon = 2
        Zebra = 3
    End Enum

    Enum TamañoPapel As Byte
        _80mm = 1
        _58mm = 2
    End Enum

    'Public Shared Function fn_Monitoreo_ClaveExiste() As DataTable
    '    Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
    '    Try
    '        Dim cmd As SqlCommand = Crear_ComandoSQL("Monitoreo_ClaveExistente", CommandType.StoredProcedure, cnn)
    '        Crear_ParametroSQL(cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)

    '        Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)
    '        Return dt
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try

    'End Function

    'JAVIER ZAPATA 08/01/2019

#Region "Correo"
    Public Shared Function fn_Correos_Consulta() As DataTable

        Try
            fn_EscribirLog(varPub.UsuarioClave, "Correos", "INICIO - SE CONSULTAN CORREOS")

            'Consultamos los correos electrónicos 
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Correos_Read2", CommandType.StoredProcedure, Cnn)
            Dim Dt_Correos As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Cmd.Dispose()
            Cnn.Dispose()
            Return Dt_Correos
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 78, varPub.IdPantalla, "Correos " + " FIN - ERROR AL CONSULTAR LOS CORREOS: " & ex.Message)
            Call fn_EscribirLog(varPub.Cve_Cliente, "Correos", "FIN - ERROR AL CONSULTAR LOS CORREOS: " & ex.Message)
            Return Nothing
        End Try
    End Function
    'JAVIER ZAPATA 09/01/2019
    Public Shared Sub fn_Llenar_Correos(ByVal Lsv As ListView)
        fn_EscribirLog(varPub.UsuarioClave, "Correos", "CONSULTA CORREOS")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Dim Cmd As SqlCommand = Crear_ComandoSQL("Correos_Read", CommandType.StoredProcedure, Cnn)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("[Correos].[GetCorreos]", CommandType.StoredProcedure, Cnn)
            Dim Dt_Correo As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If Dt_Correo.Rows.Count > 0 Then
                Call fn_LlenarListView(Dt_Correo, Lsv, "", "", True)
            Else
                Lsv.Items.Clear() 'limpia la lista cuando no hay datos en el fuente de origen.
            End If
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA CORREOS", "FIN - SE CARGO CORREOS CORRECTAMENTE")
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA CORREOS", "FIN - OCURRIÓ UN ERROR AL LLENAR LISTA" & ex.Message.ToUpper)
            Call fn_MsgBox("ERROR al Llenar lista.", MessageBoxIcon.Error)
        End Try
    End Sub
    'JAVIER ZAPATA 10/01/2019
    Public Shared Function fn_Agregar_Correos(ByVal Correo As String, ByVal Descripcion As String) As Boolean

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Dim Cmd As SqlCommand = Crear_ComandoSQL("Correos_Insert", CommandType.StoredProcedure, Cnn)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("[Correos].[AddCorreo]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Correo", SqlDbType.NVarChar, Correo, False)
            Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.NVarChar, Descripcion, False)
            'Crear_ParametroSQL(Cmd, "@Usuario_Reg", SqlDbType.Int, CInt(varPub.UsuarioClave))
            Crear_ParametroSQL(Cmd, "@IdUsuarioRegistro", SqlDbType.Int, CInt(varPub.UsuarioClave))
            Dim filasAfectadas As Integer = Ejecutar_NonQuerySQL(Cmd)

            If filasAfectadas > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "AGREGAR CORREO", "FIN - CORREO AREGADO CORRECTAMENTE")
                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "AGREGAR CORREO", "FIN - OCURRIÓ UN ERROR AL AGREGAR CORREO" & ex.Message.ToUpper)
        End Try
        Return False
    End Function
    'JAVIER ZAPATA 10/01/2019
    Public Shared Function fn_CorreoEditar(ByVal Correo As String, ByVal Descripcion As String, ByVal id_Correo As Integer) As Boolean
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Correos_Update2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Correo", SqlDbType.NVarChar, Correo, False)
            Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.NVarChar, Descripcion, False)
            Crear_ParametroSQL(Cmd, "@Usuario_Registro", SqlDbType.Int, CInt(varPub.UsuarioClave))
            Crear_ParametroSQL(Cmd, "@Id_Correo", SqlDbType.Int, id_Correo)
            Dim filasAfectadas As Integer = Ejecutar_NonQuerySQL(Cmd)
            If filasAfectadas > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "EDITAR CORREO", "FIN - CORREO EDITADO CORRECTAMENTE")
                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "EDITAR CORREO", "FIN - ERROR AL EDITAR EL CORREO")
        End Try
        Return False
    End Function
    'JAVIER ZAPATA 11/01/2019 POR EL MOMENTO NO SE PERMITEN ELIMINAR LOS CORREOS
    'Public Shared Function fn_CorreoEliminar(ByVal id_Correo As Integer) As Boolean
    '    Try
    '      Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
    '      Dim Query As String = "Delete Correo " & _
    '                              "Where id_Correo= " & id_Correo

    '      Dim cmd As SqlCeCommand = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
    '      Dim filasAfectadas As Integer = Ejecutar_NonQuerySQLCE(cmd)
    '        If filasAfectadas > 0 Then
    '           Call fn_EscribirLog(varPub.UsuarioClave, "Eliminar CORREO", "FIN - CORREO ElIMINADO CORRECTAMENTE")
    '           cnn.Dispose()
    '           cmd.Dispose()
    '           Return True
    '        End If
    '    Catch ex As Exception
    '     Call fn_EscribirLog(varPub.UsuarioClave, "EDITAR CORREO", "FIN - ERROR AL EDITAR EL CORREO")
    '    End Try
    '       Return False
    'End Function

    'JAVIER ZAPATA 11/01/2019 
    Public Shared Function fn_CorreoEstatus(ByVal id_Correo As Integer) As Boolean
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            'Dim Cmd As SqlCommand = Crear_ComandoSQL("Correos_Update", CommandType.StoredProcedure, Cnn)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("[Correos].[UpdateStatus]", CommandType.StoredProcedure, Cnn)
            'Crear_ParametroSQL(Cmd, "ID_Correo", SqlDbType.Int, id_Correo, False)
            Crear_ParametroSQL(Cmd, "@IdCorreo", SqlDbType.Int, id_Correo, False)
            Dim filasAfectadas As Integer = Ejecutar_NonQuerySQL(Cmd)
            If filasAfectadas > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "ESTATUS CORREO", "FIN - ESTATUS CAMBIADO CORRECTAMENTE")
                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "ESTATUS CORREO", "FIN - ERROR AL CAMBIAR ESTATUS DE CORREO")
        End Try
        Return False
    End Function
#End Region

#Region "CERRADURA"
    'JAVIER ZAPATA 14/01/2019 
    Public Shared Function fn_Cerradura_Cambiar(ByVal Fecha_Puesta As DateTime, ByVal Meses As String, Optional ByVal id_Cerradura As Integer = 0) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "CAMBIAR PILA - CAMBIAR PILA DE CERRADURA")
        Dim Cmd As SqlCommand
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Fecha_Expira As DateTime = Fecha_Puesta.AddMonths(Meses)

            Cmd = Crear_ComandoSQL("Cerradura_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@FechaPuesta", SqlDbType.DateTime, Fecha_Puesta)
            Crear_ParametroSQL(Cmd, "@FechaExpira", SqlDbType.DateTime, Fecha_Expira)
            Crear_ParametroSQL(Cmd, "@Clave_UserRegistro", SqlDbType.Int, CInt(varPub.UsuarioClave))
            Crear_ParametroSQL(Cmd, "@Nombre_userRegistro", SqlDbType.NVarChar, varPub.NombreUser)
            Crear_ParametroSQL(Cmd, "@Meses_Expira", SqlDbType.NVarChar, Meses)
            Crear_ParametroSQL(Cmd, "@Id_Cerradura", SqlDbType.Int, id_Cerradura)


            Dim filasAfectadas As Integer = Ejecutar_NonQuerySQL(Cmd)

            If filasAfectadas > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "FIN - SE GUARDO CORRECTAMENTE LA NUEVA BATERIA")
                Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "FIN - SE ACTUALIZO CORRECTAMENTE EL STATUS DE LA BATERIA ANTERIOR A BAJA")
                Cmd.Dispose()
                Cnn.Dispose()
                Return True
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "FIN - ERROR AL GUARDAR NUEVA BATERIA")
        End Try
        Return False
    End Function
    'JAVIER ZAPATA 14/01/2019 
    Public Shared Function fn_Cerradura_Consultar() As DataTable
        Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "CONSULTAR DATOS DE CERRDURA ACTUAL")
        Dim Cmd As SqlCommand
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Cerradura_Read", CommandType.StoredProcedure, Cnn)
            Dim Dt_Cerradura = Ejecutar_ConsultaSQL(Cmd)
            Return Dt_Cerradura
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", " ERROR AL CONSULTAR DATOS DE CERRADURA")
            Return Nothing
        End Try
    End Function
    'JAVIER ZAPATA 15/01/2019 
    Public Shared Function fn_Cerradura_Consultar_Fecha() As Integer
        'Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "CONSULTAR FECHA - PILA DE CERRADURA")
        Dim Cmd As SqlCommand
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Cerradura_Read2", CommandType.StoredProcedure, Cnn)
            Dim Fecha As DateTime = Ejecutar_ScalarSQL(Cmd)

            If Fecha = "12:00:00 AM" Then
                Return 2
            End If

            If System.DateTime.Now > Fecha Then
                Cmd.Dispose()
                Return 1 'Necesita reemplazo

            Else
                Cmd.Dispose()
                Return 2 'Aún le queda carga o el estatus es E (enviado)
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "FIN - ERROR AL CONSULTAR LA FECHA DE BATERIA")
            Return 3 'Ocurrió un error al 
        End Try
    End Function


    'JAVIER ZAPATA 15/01/2019 
    Public Shared Function fn_Cerradura_Estatus_Enviado() As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", "CAMBIAR ESTATUS -ENVIAR")
        Dim Cmd As SqlCommand
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Cerradura_Update2", CommandType.StoredProcedure, Cnn)
            Dim filasAfectadas As Integer = Ejecutar_NonQuerySQL(Cmd)
            If filasAfectadas > 0 Then
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CERRADURA", " ERROR AL CAMBIAR DE ESTATUS")
        End Try
        Return False
    End Function

#End Region

#Region "Tipo de Cambio"

    Public Shared Function fn_TipoCambio_Insertar(ByVal TC_Nuevo As Decimal) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIO - INSERTAR TIPO DE CAMBIO DEL DIA-" & TC_Nuevo)
        Dim Cmd As SqlCommand

        Try
            'aqui insertamos por 1ra vez el tipo de cambio e peso y dolar

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            '-------insertamos el Peso
            Cmd = Crear_ComandoSQL("TipoCambio_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@TC_Nuevo", SqlDbType.Decimal, TC_Nuevo)

            Dim filasAfectadas = Ejecutar_NonQuerySQL(Cmd)
            If filasAfectadas > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - INSERTAR TIPO DE CAMBIO DEL DIA-" & TC_Nuevo)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - ERROR AL INSERTAR TIPO DE CAMBIO DEL DIA: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function fn_TipoCambio_Modificar(ByVal TC_Nuevo As Decimal, ByVal Id_TC As Integer) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIO - MODIFICAR TIPO DE CAMBIO.")

        Try
            'aquí modificamos el tipo de cambio en caso de que asi se desee.
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("TipoCambio_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@TC_Nuevo", SqlDbType.Decimal, TC_Nuevo)
            Crear_ParametroSQL(Cmd, "@Id_TC", SqlDbType.Int, Id_TC)
            Dim filasAfectadas = Ejecutar_NonQuerySQL(Cmd)
            If filasAfectadas > 0 Then
                Return True
                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - SE MODIFICO EL TIPO DE CAMBIO POR: " & TC_Nuevo)
            Else
                Return False
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - ERROR AL MODIFICAR TIPO DE CAMBIO DEL DIA" & ex.Message.ToUpper)
            Return False
        End Try
    End Function

    Public Shared Function fn_TipoCambio_Read(ByVal FechaActual As Date, Optional ByVal MonedaTC As String = "Ninguna") As DataTable
        'Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "INICIO - OBTENER EL TIPO DE CAMBIO DEL DIA.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("TipoCambio_Read", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@MonedaTC", SqlDbType.VarChar, MonedaTC)
            Dim Dt_TipoCambio As DataTable = Ejecutar_ConsultaSQL(Cmd)
            ' Call fn_EscribirLog(UsuarioClave, "PARAMETROS", "FIN - SE OBTUVO EL TIPO DE CAMBIO CORRECTAMENTE.")
            Cmd.Dispose()
            Cnn.Dispose()
            Return Dt_TipoCambio
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 67, varPub.IdPantalla, "PARAMETROS - " + "FIN - ERROR AL OBTENER EL TIPO DE CAMBIO DEL DIA." & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - ERROR AL OBTENER EL TIPO DE CAMBIO DEL DIA." & ex.Message.ToUpper)
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_Verificar_ExisteTipoCambio() As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "INICIO - VERIFICAR SI EXISTE TIPO DE CAMBIO PARA HOY")
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Try

            'verificar que no este vacio la tabla tipoDe cambio

            Cmd = Crear_ComandoSQL("TipoCambio_ReadUltimo", CommandType.StoredProcedure, Cnn)
            Dim Dt_TC_Verifica As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If Dt_TC_Verifica IsNot Nothing And Dt_TC_Verifica.Rows.Count > 0 Then
                If IsDBNull(Dt_TC_Verifica.Rows(0)("FechaTC")) Then
                    'tonces mandar a pantalla nueva
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - NO EXISTE TIPO DE CAMBIO PARA HOY.")
                    Return 0
                End If
            End If
            Dim FechaMax As Date = CDate(Dt_TC_Verifica.Rows(0)("FechaTC").ToString)

            '----Verifica si hay Tipo de cambio para hoy
            Dim DT_TC_Hoy As DataTable = fn_TipoCambio_Read(Now.Date)

            If DT_TC_Hoy IsNot Nothing AndAlso DT_TC_Hoy.Rows.Count > 0 Then
                'Si existe tipo cambio de hoy.. ..no hacer NAda
                Dim DT_TCUSD As DataTable = fn_TipoCambio_Read(Now.Date, "USD")
                Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - SE OBTUVO EL SIGUIENTE TIPO DE CAMBIO PARA HOY: " & DT_TCUSD.Rows(0)("TC"))
                Return 1
            Else

                Cmd = Crear_ComandoSQL("TipoCambio_Read2", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@FechaMax", SqlDbType.Date, FechaMax)
                Dim Dt_TC As DataTable = Ejecutar_ConsultaSQL(Cmd)


                If FechaMax < Now.Date Then
                    ''" & Fecha & " " & Hora & "'
                    For Each tc As DataRow In Dt_TC.Rows

                        Cmd = Crear_ComandoSQL("TipoCambio_Insert2", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@ClaveMoneda", SqlDbType.VarChar, tc("Clave_moneda"), False)
                        Crear_ParametroSQL(Cmd, "@TipoCambio", SqlDbType.Decimal, tc("TipoCambio"), False)
                        Ejecutar_NonQuerySQL(Cmd)
                    Next
                    Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN - COPIAR EL TIPO DE CAMBIO DEL DIA: " & FechaMax)
                    Return 2
                Else
                    Return 1
                End If

            End If
        Catch ex As Exception
            Cmd.Dispose()
            Cnn.Dispose()
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 66, varPub.IdPantalla, "LOGIN - " + "FIN- ERROR AL VERIFICAR TIPO DE CAMBIO" & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN- ERROR AL VERIFICAR TIPO DE CAMBIO" & ex.Message.ToUpper)
            Return -1 ' error
        End Try
    End Function

#End Region

#Region "Menus"

    ''' <summary>
    ''' Función que gestionará la apertura de Menús
    ''' </summary>
    ''' <param name="Op_Menu">Opción del Menú a Abrir</param>
    ''' <remarks> </remarks>
    ''' 
    Public Shared Sub fn_Menus_Open(ByVal Op_Menu As Byte, Optional ByVal Id As Integer = 0, Optional ByVal ImporteTotal_Dep_Ret As Decimal = 0, Optional ByVal ImporteOtros As Decimal = 0)
        Select Case Op_Menu
            Case 1 'Seleccionar el tipo de Deposito
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "ABRIR VENTANA")
                Dim frm As New frm_Depositar
                frm.ShowDialog()
                'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "CERRAR VENTANA")

            Case 2 'Abre pantalla Retiro
                Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS", "ABRIR VENTANA")
                Dim frm As New frm_Recolectar
                frm.lbl_CiaTVD.Text = varPub.CiaTV
                frm.lbl_CasetActualD.Text = fn_Casets_GetClave(varPub.CasetID)
                If varPub.Cant_Validadores = 2 Then frm.lbl_CasetActualD2.Text = fn_Casets_GetClave(varPub.Caset2ID)
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS", "CERRAR VENTANA")

            Case 3 'Consulta Depósitos
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaDepositos
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "CERRAR VENTANA")

            Case 4 'Consulta Saldos
                If varPub.ManejaCorte = 0 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTASALDOS", "ABRIR VENTANA")
                    Dim frm As New frm_ConsultaSaldos
                    frm.ShowDialog()
                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTASALDOS", "CERRAR VENTANA")
                ElseIf varPub.ManejaCorte = 1 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "CORTE POR DIA", "ABRIR VENTANA")
                    Dim frm As New Frm_CortePorDia
                    frm.ShowDialog()
                    Call fn_EscribirLog(varPub.UsuarioClave, "CORTE POR DIA", "CERRAR VENTANA")
                End If

            Case 5 'Abre form Consulta de usuarios
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaUsuarios

                If Id = -1 Then
                    'remover la pestaña listado
                    frm.tab_Usuarios.TabPages.Remove(frm.tbp_ListadoUser)
                    frm.tbp_Nuevo.Text = "Cambiar Contraseña"

                    'Cambio Contraseña
                    Dim dt_Datos As DataTable = fn_Usuarios_Read(varPub.UsuarioClave)
                    If dt_Datos Is Nothing OrElse dt_Datos.Rows.Count = 0 Then
                        frm.Dispose()
                        Exit Sub
                    End If

                    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "CAMBIAR CONTRASEÑA")

                    frm.Acc = Acciones.CambiarContrasena
                    frm.tbx_Clave.Enabled = False
                    frm.tbx_NombreCompleto.Enabled = False
                    frm.tbx_NombreCorto.Enabled = False
                    frm.gbx_Tipo.Enabled = False

                    frm.tbx_Clave.Text = dt_Datos.Rows(0)("Clave_Usuario")
                    frm.tbx_NombreCompleto.Text = dt_Datos.Rows(0)("Nombre_Usuario")
                    frm.tbx_NombreCorto.Text = dt_Datos.Rows(0)("Nombre_Corto")
                    Select Case dt_Datos.Rows(0)("Tipo_Usuario")
                        Case 1
                            frm.rdb_Local.Checked = True
                            frm.rdb_Local.Image = My.Resources.RadioButton_Checked_24x24
                        Case 2
                            frm.rdb_Admin.Checked = True
                            frm.rdb_Admin.Image = My.Resources.RadioButton_Checked_24x24
                    End Select
                Else
                    '---------si es Usuario Nuevo id=0
                    If Id = 0 Then
                        Call fn_EscribirLog(varPub.UsuarioClave, " CONSULTA DE USUARIOS", "CREAR NUEVO USUARIO")
                        frm.Acc = Acciones.Nuevo
                        frm.tbx_ContrasenaActual.Enabled = False
                    End If
                    '--------------------
                End If
                '-----------------
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "CERRAR VENTANA")

            Case 6 'Abre Pantalla Privilegios
                Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ABRIR VENTANA")
                Dim frm As New frm_Privilegios
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "CERRAR VENTANA")

            Case 7 'Abre pantalla de Movimientos
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaMovimientos
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "CERRAR VENTANA")

            Case 8 'Abre Pantalla de Parámetros
                Call fn_EscribirLog(varPub.UsuarioClave, "PARÁMETROS", "ABRIR VENTANA")
                Dim frm As New frm_Parametros

                'Se abre desde el Menú Auditoría
                frm.FormBorderStyle = FormBorderStyle.None

                frm.tbx_ClaveSucursal.Text = varPub.Cve_Sucursal
                frm.tbx_Servidor.Text = varPub.S_dtb
                frm.tbx_BDD.Text = varPub.B_dtb
                frm.tbx_Usuario.Text = varPub.U_dtb
                frm.tbx_Password.Text = varPub.P_dtb
                frm.tbx_ClaveUnica.Text = varPub.CUNICA
                frm.tbx_HostIP.Text = varPub.hostNameOrAddress
                'frm.txt_MaxIntentosLog.Text = varPub.Max_Intentos_Log 'quitar esta variable
                frm.tbx_Cliente.Text = varPub.Cliente
                frm.tbx_Direccion.Text = varPub.Direccion
                frm.tbx_Tel.Text = varPub.Telefono
                frm.tbx_CiaTV.Text = varPub.CiaTV
                frm.tbx_MonedaTC.Text = "DOLAR" 'De momento es Fijo

                'AQUI cargamos los datos del tipo de cambio 
                Dim DT_TipoCambio As DataTable = fn_TipoCambio_Read(Now.Date, "USD")

                If DT_TipoCambio IsNot Nothing AndAlso DT_TipoCambio.Rows.Count > 0 Then
                    If DT_TipoCambio.Rows(0)("Clave_Moneda") = "USD" Then
                        frm.tbx_MonedaTC.Tag = DT_TipoCambio.Rows(0)("Id_TC").ToString
                        frm.tbx_FechaTC.Text = DT_TipoCambio.Rows(0)("FechaTC").ToString
                        frm.tbx_AnteriorTC.Text = DT_TipoCambio.Rows(0)("TC").ToString
                    End If
                Else
                    frm.tbx_FechaTC.Text = Format(Now.Date, "dd/MM/yyyy")
                    frm.tbx_AnteriorTC.Text = "0.0"
                End If





                '----------
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CERRAR VENTANA")

            Case 9 'Consulta Log
                'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA LOG", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaLog
                frm.ShowDialog()
                'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA LOG", "CERRAR VENTANA")

            Case 10 'Consulta Detalle de Depósitos
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DETALLE DE DEPOSITOS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaDepositosD
                frm.lsv_DepositosD.Columns.Add("Clave")
                frm.lsv_DepositosD.Columns.Add("Denominacion")
                frm.lsv_DepositosD.Columns.Add("Cantidad")
                frm.lsv_DepositosD.Columns.Add("Importe")

                frm.lbl_TotalD.Text = "Total: " & FormatCurrency(ImporteTotal_Dep_Ret, 2)
                Call fn_ConsultaDepositosD_Llenar(Id, frm.lsv_DepositosD)

                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DETALLE DE DEPOSITOS", "CERRAR VENTANA")

            Case 11 'Catálogo de Casets
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "ABRIR VENTANA")
                Dim frm As New frm_CatalogoCaset
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "CERRAR VENTANA")

            Case 12 'Catálogo de Denominaciones
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "ABRIR VENTANA")
                Dim frm As New frm_CatalogoDenominacion
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "CERRAR VENTANA")

            Case 13 'Catálogo de Monedas
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "ABRIR VENTANA")
                Dim frm As New frm_CatalogoMonedas
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "CERRAR VENTANA")

            Case 14 'Sincronización Operaciones de WEB a Local (Descargas)
                'Call fn_EscribirLog(varPub.UsuarioClave, "---", "INICIO - SINCRONIZACION DE OPERACION DESCARGAS: USUARIOS,PRIVILEGIOS, CASETS, MONEDAS Y DENOMINACIONES.")

                Call fn_SincronizarUsuarios_aLOCAL(varPub.Cve_Sucursal)
                'Call fn_DescargarSubirPrivilegios()
                Call fn_SincronizarPrivilegios_aLocal()
                Call fn_SincronizarCasets_aLOCAL(varPub.Cve_Sucursal)
                Call fn_SincronizarMonedas_aLOCAL()
                Call fn_SincronizarDenominaciones_aLOCAL()
                Call fn_SincronizaUltimaConexion()
                Call fn_SincronizarCajas_aLOCAL(varPub.Cve_Sucursal)
                'Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - SINCRONIZACION DE OPERACIONES DESCARGAS")

            Case 15 'Sincronización de Operaciones de (Depositos y Retiros en WEB)  de Local a Web

                'Call fn_EscribirLog(varPub.UsuarioClave, "---", "INICIO - SINCRONIZACION DE OPERACION DE CARGA: DEPOSITOS, RETIROS, USUARIOS, PRIVILEGIOS, CASETS, MONEDAS Y DENOMINACIONES.")
                Call fn_DescargarPrivilegiosLocalWeb() '01/04/2019 JAVIER ZAPATA

                'FUNCION ANTERIOR
                'Call fn_SincronizaDepositos_aWEB()

                'FUNCION NUEVA BJSE 2021
                fn_SincronizarDepositosWebServices()

                'FUNCION ANTERIOR
                'Call fn_SincronizaRetiros_aWEB()

                'FUNCION NUEVA BJSE 2021
                fn_SincronizaRetiros_WebWs()

                'FUNCION NUEVA BJSE 2021x
                'fn_SincronizaLogErrores_WebWs()

                Call fn_SincronizaCorte_aWEB()
                Call fn_SincronizarUsuarios_aWEB()
                'Call fn_DescargarSubirPrivilegios()
                Call fn_SincronizarCasets_aWEB()
                Call fn_SincronizarMonedas_aWEB()
                Call fn_SincronizarDenominaciones_aWEB()
                Call fn_SincronizaUltimaConexion()
                Call fn_SincronizarCajas_aWEB()
                'Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - SINCRONIZACION DE OPERACIONES DE CARGA")

            Case 16 'Intentar guardar el Log del dia anterior si hay conectividad
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE  RETIROS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaRecoleccion
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RETIROS", "CERRAR VENTANA")

            Case 17 'Consulta Detalle de Retiros
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DETALLE DE RETIROS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaRecoleccionD
                frm.lsv_RecoleccionD.Columns.Add("Folio")
                frm.lsv_RecoleccionD.Columns.Add("Fecha")
                frm.lsv_RecoleccionD.Columns.Add("Hora")
                frm.lsv_RecoleccionD.Columns.Add("Importe")

                frm.lbl_ImporteTotal.Text = FormatCurrency(ImporteTotal_Dep_Ret, 2)
                Dim ImporteValidado As Decimal = 0
                Call fn_ConsultaRetirosD_Llenar(Id, frm.lsv_RecoleccionD, ImporteValidado)
                frm.lbl_ImporteValidado.Text = FormatCurrency(ImporteValidado, 2)
                frm.lbl_ImporteManual.Text = FormatCurrency(ImporteOtros, 2)
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA  DETALLE DE RETIROS", "CERRAR VENTANA")

            Case 18 'Limpiar Tablas de la Base de Datos SQL Compact
                'Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " INICIO - LIMPIAR CONTENIDO DE LAS TABLAS ")

                If fn_LimpiarTablas_BDDLocal() Then
                    '    Call fn_MsgBox("LAS TABLAS SE BORRARON CORRECTAMENTE", MessageBoxIcon.Information)

                    '    'ELIMINAR DIRECTORIO DE LOGS (ARCHIVO -> TXT)
                    '    ' varPub.Ruta_Log = String.Format(System.Environment.SystemDirectory.Substring(0, 3)) & varPub.Ruta_Log
                    '    If System.IO.Directory.Exists(varPub.Ruta_Log) Then
                    '        My.Computer.FileSystem.DeleteDirectory(varPub.Ruta_Log, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If

                    '    varPub.ID_UltimoRetiro = 0
                    '    varPub.ID_DepositoP = 0
                    '    varPub.Capacidad_Actual = 0
                    '    varPub.CasetID = 0
                    '    varPub.Serie_Caset1 = ""
                    '    varPub.Caset2ID = 0
                    '    varPub.Serie_Caset2 = ""
                    '    varPub.Capacidad_Actual2 = 0

                    '    varPub.Cantidad_Cajas = 0

                    '    Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
                    '    If Persistente.Existe Then
                    '        Persistente.Persistir()
                    '        Persistente.Cargar()
                    '    End If
                    '    'ELIMINAR LOS PARAMETROS(ARCHIVO .XML)-> PENDIENTE
                    '    'Dim rutaXML As String = Application.StartupPath & "\ArchivoPersistente.xml"
                    '    'If (System.IO.File.Exists(rutaXML)) Then
                    '    '    System.IO.File.Delete(rutaXML) ' sino existe crearlo Nuevo
                    '    'End If
                    'Else
                    '    Call fn_MsgBox(" ERROR AL BORRAR LAS TABLAS EN LA BASE DE DATOS", MessageBoxIcon.Error)
                End If

            Case 19 'Imprimir Corte del dia desde Inicio de Operaciones hasta la hora
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "ABRIR VENTANA")
                Dim frm As New frm_SaldoMenu
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "CERRAR VENTANA")

            Case 20 'Limpiar Tablas  de Depositos yRetiros  10/julio/2013
                Call fn_EscribirLog(varPub.UsuarioClave, "TABLAS", "ABRIR VENTANA")
                Dim Tablas As New frm_Tablas
                Tablas.ShowDialog()
                varPub.SegundosSesion = 0
                Call fn_EscribirLog(varPub.UsuarioClave, "TABLAS", "CERRAR VENTANA")
                Tablas.Close()

                'If fn_LimpiarTablas_DepositosRetiros() Then
                '    varPub.ID_UltimoRetiro = 0
                '    varPub.ID_DepositoP = 0
                '    varPub.Capacidad_Actual = 0
                '    varPub.Capacidad_Actual2 = 0
                '    varPub.Cantidad_Cajas = 0

                '    Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
                '    If Persistente.Existe Then
                '        Persistente.Persistir()
                '        Persistente.Cargar()
                '    End If
                '    Call fn_MsgBox("LAS TABLAS SE BORRARON CORRECTAMENTE", MessageBoxIcon.Information)
                'Else
                '    Call fn_MsgBox("OCURRIÓ UN ERROR AL BORRAR LAS TABLAS EN LA BASE DE DATOS", MessageBoxIcon.Error)
                'End If
            Case 21
                Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "ABRIR VENTANA")
                Dim frm As New frm_ValidarBillete
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "VALIDAR BILLETES", "CERRAR VENTANA")

            Case 22 'Sincroniza Usarios - privilegios y Casets de la web a local {solo en login}

                Call fn_EscribirLog(varPub.UsuarioClave, "---", "INICIO - SINCRONIZACION DE DESCARGAS DE USUARIOS-PRIVILEGIOS ,CASETS")

                Call fn_SincronizarUsuarios_aLOCAL(varPub.Cve_Sucursal)
                'Call fn_DescargarSubirPrivilegios()
                Call fn_SincronizarCasets_aLOCAL(varPub.Cve_Sucursal)

                '1.-Verifica si hay nueva Actualizacion
                'Call fn_ActualizacionCashFlow_Buscar()

                '2.-Verifica si hay que subir archivo Log.txt
                'Call fn_VerificarEnvio_ArchivoLog()  "Comentado 11/01/2017 por crecimiento de BD"

                Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN SINCRONIZACION DE DESCARGAS DE USUARIOS, CASETS")
            Case 23
                Call fn_EscribirLog(varPub.UsuarioClave, "CONFIGURAR IP", "ABRIR VENTANA")
                Dim frm As New frm_CambiarIP
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONFIGURAR IP", "CERRAR VENTANA")

            Case 24 ' Verificar respaldo bdd y sincroniza ult_Conexion
                If varPub.Conectividad Then
                    If fn_VerificaConexionInternet() = False Then Exit Sub

                    'Dim Respaldar As String = fn_ActualizarRespaldar_Verificar(AccionWeb.Respaldar) 'si hay respaldo bdd
                    'If Respaldar = "S" Then
                    '    Call fn_EscribirLog(varPub.UsuarioClave, "RESPALDAR BDD LOCAL A WEB", "ABRIR VENTANA")
                    '    Dim frm As New frm_RespaldarenWeb
                    '    frm.IniciarUp = True
                    '    frm.ShowDialog()
                    '    Call fn_EscribirLog(varPub.UsuarioClave, "RESPALDAR BDD LOCAL A WEB", "CERRAR VENTANA")
                    'End If
                    Call fn_SincronizaUltimaConexion()
                End If
            Case 25 ' Abrir ventana corte 
                If varPub.ManejaCorte = 1 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "ABRIR VENTANA CORTE", "ABRIR VENTANA")
                    Dim frm As New frm_Corte
                    frm.ShowDialog()
                ElseIf varPub.ManejaCorte = 0 Then
                    fn_MsgBox("El Sistema no esta configurado para manejar Corte.", MessageBoxIcon.Information, True, 3)
                End If
            Case 26 ' Abrir ventana corte 
                Call fn_EscribirLog(varPub.UsuarioClave, "ABRIR VENTANA CATALOGO CAJAS", "ABRIR VENTANA")
                Dim frm As New frm_CatalogoCajas
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "CERRAR VENTANA")
            Case 27
                Call fn_EscribirLog(varPub.UsuarioClave, "ABRIR VENTANA CATALOGO CORREOS", "ABRIR VENTANA")
                Dim frm As New frm_CatalogoCorreos
                frm.ShowDialog()
                Call fn_EscribirLog(varPub.UsuarioClave, "CERRAR VENTANA CATALOGO CORREOS", "CERRAR VENTANA")
            Case 28
                Call fn_EscribirLog(varPub.UsuarioClave, "ABRIR VENTANA CERRADURA", "ABRIR VENTANA")
                Dim frm As New frm_Cerradura
                frm.ShowDialog()
            Case 29
                Call fn_EscribirLog(varPub.UsuarioClave, "ABRIR VENTANA ATASCOS", "ABRIR VENTANA")
                Dim frm As New frm_ConsultaAtascos
                frm.ShowDialog()
            Case 30
                Call fn_EscribirLog(varPub.UsuarioClave, "ABRIR VENTANA Reportes", "ABRIR VENTANA")
                Dim frm As New frm_Reporte
                frm.ShowDialog()
            Case 31
                Call fn_EscribirLog(varPub.UsuarioClave, "PARÁMETROS", "ABRIR VENTANA, MODIFICAR EN AUTOMATICO")
                Dim frm As New frm_Parametros

                'Se abre desde el Menú Auditoría
                frm.FormBorderStyle = FormBorderStyle.None

                frm.tbx_ClaveSucursal.Text = varPub.Cve_Sucursal
                frm.tbx_Servidor.Text = varPub.S_dtb
                frm.tbx_BDD.Text = varPub.B_dtb
                frm.tbx_Usuario.Text = varPub.U_dtb
                frm.tbx_Password.Text = varPub.P_dtb
                frm.tbx_ClaveUnica.Text = varPub.CUNICA
                frm.tbx_HostIP.Text = varPub.hostNameOrAddress
                'frm.txt_MaxIntentosLog.Text = varPub.Max_Intentos_Log 'quitar esta variable
                frm.tbx_Cliente.Text = varPub.Cliente
                frm.tbx_Direccion.Text = varPub.Direccion
                frm.tbx_Tel.Text = varPub.Telefono
                frm.tbx_CiaTV.Text = varPub.CiaTV
                frm.tbx_MonedaTC.Text = "DOLAR" 'De momento es Fijo

                'AQUI cargamos los datos del tipo de cambio 
                Dim DT_TipoCambio As DataTable = fn_TipoCambio_Read(Now.Date, "USD")

                If DT_TipoCambio IsNot Nothing AndAlso DT_TipoCambio.Rows.Count > 0 Then
                    If DT_TipoCambio.Rows(0)("Clave_Moneda") = "USD" Then
                        frm.tbx_MonedaTC.Tag = DT_TipoCambio.Rows(0)("Id_TC").ToString
                        frm.tbx_FechaTC.Text = DT_TipoCambio.Rows(0)("FechaTC").ToString
                        frm.tbx_AnteriorTC.Text = DT_TipoCambio.Rows(0)("TC").ToString
                    End If
                Else
                    frm.tbx_FechaTC.Text = Format(Now.Date, "dd/MM/yyyy")
                    frm.tbx_AnteriorTC.Text = "0.0"
                End If

                frm.Tab_Parametros.SelectedIndex = 3

                frm.rdb_SiVal1.Checked = False
                frm.rdb_NoVal1.Checked = True

                '----------
                frm.Show()
                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CERRAR VENTANA, MODIFICAR EN AUTOMATICO")
        End Select

    End Sub

    Public Shared Sub fn_ActualizacionCashFlow_Buscar()
        If varPub.Conectividad Then
            If fn_VerificaConexionInternet() Then
                varPub.VerificaUpdate = fn_ActualizarRespaldar_Verificar(AccionWeb.Actualizar) '06/10/2016
            End If
        End If
    End Sub

    Public Shared Sub fn_SincronizaUltimaConexion()
        If varPub.Conectividad Then
            Dim dt_cveExiste As DataTable = cls_CashWeb.fn_Monitoreo_ClaveExiste()
            If dt_cveExiste IsNot Nothing Then
                If dt_cveExiste.Rows.Count > 0 Then
                    cls_CashWeb.fn_Monitoreo_Actualizar()
                Else
                    cls_CashWeb.fn_Monitoreo_Guardar()
                End If
            End If
        End If
    End Sub
    Public Shared Sub fn_GetConexionCashWeb()

        cls_CashWeb.fn_AfectarMonitoreo()

    End Sub



    Public Shared Sub fn_DescargarSubirPrivilegios()
        'If (varPub.ConexionwebAdmin = 1) Then '***
        '    If fn_VerificaConexionInternet() Then
        '        'cargar la Tabla de usuarios 0 es para que traiga Todos los uSuarios
        '        Dim dt_Usuarios As DataTable = fn_Usuarios_Read(0)

        '        For Each ClaveUser As DataRow In dt_Usuarios.Rows

        '            'No insertar si es admin sistemas
        '            If ClaveUser("Clave_Usuario") = 491752 Or ClaveUser("Clave_Usuario") = 925074 Then Continue For

        '            If varPub.Prioridad_Priv = 1 Then
        '                Call fn_SincronizarPrivilegiosLocal_aWEB(ClaveUser("Clave_Usuario"))
        '            Else
        '                Call fn_SincronizarPrivilegiosWeb_aLOCAL(ClaveUser("Clave_Usuario"))
        '            End If

        '        Next
        '    End If
        'End If
    End Sub

    Public Shared Sub fn_VerificaTipode_Cambio()
        '--verificar si existe Tipo de cambio--
        Call fn_Verificar_ExisteTipoCambio()

        '/---->>cargar el tipo de cambio de Hoy<<-----/
        Dim DT_TipoCambio As DataTable = fn_TipoCambio_Read(Now.Date, "USD")
        If DT_TipoCambio IsNot Nothing AndAlso DT_TipoCambio.Rows.Count > 0 Then

            If DT_TipoCambio.Rows(0)("Clave_Moneda") = "USD" Then
                varPub.TipoCambio = CDec(DT_TipoCambio.Rows(0)("TC"))
            End If
        End If
    End Sub


#End Region

#Region "Depósitos"

    'JAVIER ZAPATA 27/03/2019

    Public Shared Function fn_CajasProbarCnx(ByVal DataSource As String, ByVal InitialCatalog As String, ByVal User As String, ByVal Pass As String) As SqlConnection
        Dim Con As SqlConnection = Crear_ConexionSQL("Data Source=" + DataSource + ";Initial Catalog=" + InitialCatalog + "; User id=" + User + "; pwd=" + Pass + " ;")

        Try
            Con.Open()
            Con.Close()
            Return Con
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 14, varPub.IdPantalla, "DEPOSITOS - " + ": Error AL CONSULTAR LA CONEXION DE LA CAJA  ")
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ": Error AL CONSULTAR LA CONEXION DE LA CAJA  ")
            Call fn_MsgBox("Error al consultar la cadena de conexion de la caja.", MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Shared Function fn_ValidarFolio(ByVal folio As String) As DataTable
        Dim Cmd As SqlCommand = Nothing
        Dim cnn As SqlConnection = Nothing
        Try
            cnn = Crear_ConexionSQL(varPub.CajasCnx)
            Cmd = Crear_ComandoSQL("Select Codigo From ViewFoliosSissaNoVerificados Where Codigo = '" & folio & "'", CommandType.Text, cnn)
            'Crear_ParametroSQL(Cmd, "@Codigo", SqlDbType.VarChar, folio)
            Return Ejecutar_ConsultaSQL(Cmd)

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 65, varPub.IdPantalla, "DEPOSITOS - " + ":ERROR AL CONSULTAR FOLIO  ")
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ":ERROR AL CONSULTAR FOLIO  ")
            'Call fn_MsgBox("Error al consultar el folio.", MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_CajaCnx(ByVal IdCaja As String, ByRef dt As DataTable) As Boolean
        Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Try
            Cmd = Crear_ComandoSQL("Cajascnx_Read", CommandType.StoredProcedure, Con)
            Crear_ParametroSQL(Cmd, "@Id_caja", SqlDbType.Int, IdCaja)
            dt = Ejecutar_ConsultaSQL(Cmd)
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ":ERROR AL CONSULTAR La conexion de la caja  ")
            Call fn_MsgBox("Error al consultar la configuración de la caja", MessageBoxIcon.Error)
            Return False
        End Try
    End Function



    Public Shared Function fn_Depositos_ConsultaFolio(ByVal Folio As String) As Boolean
        Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing

        Try
            Cmd = Crear_ComandoSQL("Depositos_ReadFolio", CommandType.StoredProcedure, Con)
            Crear_ParametroSQL(Cmd, "@Folio", SqlDbType.NVarChar, Folio)
            Dim Id As Object = Ejecutar_ScalarSQL(Cmd)
            If Not IsNothing(Id) Then
                ctrlTeclado.Hide()
                Return True
            Else : Return False
            End If
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 65, varPub.IdPantalla, "DEPOSITOS - " + ":ERROR AL CONSULTAR FOLIO  " & Folio)
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ":ERROR AL CONSULTAR FOLIO  " & Folio)
            Call fn_MsgBox("Error al consultar el folio", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Shared Sub fn_Verifica_Folios()
        Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        'Folio As String, Importe As Integer
        Try
            If varPub.ValidarFolio Then

                Cmd = Crear_ComandoSQL("Verificar_Folios", CommandType.StoredProcedure, Con)

                Dim depositos As DataTable = Ejecutar_ConsultaSQL(Cmd)
                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If
                For Each r As DataRow In depositos.Rows
                    Dim status As String = "R"
                    Try
                        Dim concaja As SqlConnection = Crear_ConexionSQL(r("Conexion").ToString())
                        Dim cmdcaja As SqlCommand = Nothing

                        cmdcaja = Crear_ComandoSQL("Sp_ValidarRetirosSISSA", CommandType.StoredProcedure, concaja)
                        Crear_ParametroSQL(cmdcaja, "@Folio", SqlDbType.VarChar, r("Folio").ToString())
                        Crear_ParametroSQL(cmdcaja, "@Importe", SqlDbType.Int, CInt(r("Importe_Total").ToString))
                        status = Ejecutar_ConsultaSQL(cmdcaja).Rows(0)("Status").ToString
                        concaja.Close()
                        cmdcaja.Dispose()
                    Catch ex As Exception
                        fn_EscribirLog(varPub.UsuarioClave, "----", "No se encontro el procedimiento Sp_ValidarRetirosSISSA en el punto de venta ." + ex.Message + ":" + ex.StackTrace.ToString())
                    End Try

                    If status IsNot Nothing Then
                        Try
                            Dim actualizacon As SqlConnection = Crear_ConexionSQL(_Cnx)
                            Dim actualizacmd As SqlCommand = Crear_ComandoSQL("Actualizar_Folio", CommandType.StoredProcedure, Con)
                            Crear_ParametroSQL(actualizacmd, "@Id_Deposito", SqlDbType.Int, CInt(r("Id_Deposito").ToString))
                            Crear_ParametroSQL(actualizacmd, "@Status", SqlDbType.VarChar, status)
                            Ejecutar_NonQuerySQL(actualizacmd)
                            actualizacon.Close()
                            actualizacmd.Dispose()
                        Catch ex As Exception
                            fn_EscribirLog(varPub.UsuarioClave, "----", "Error al actualizar el Folio" + ex.Message + ":" + ex.StackTrace.ToString())
                        End Try
                    End If


                Next
            Else
                ' Call fn_EscribirLog(varPub.UsuarioClave, "----", "NO SE VALIDAN FOLIOS CON PUNTO DE VENTA")
            End If


        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "----", "ERROR" + ex.Message + ":" + ex.StackTrace.ToString())
        End Try
    End Sub

    Public Shared Sub fn_ConsultaDepositos_LlenarCombo(ByRef cmb As ComboBox)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOS", "INICIO - CONSULTA DEPÓSITOS COMBO USUARIOS")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Dim dr As DataRow = dt_Usuarios.NewRow
            dr("Clave_Usuario") = 0
            dr("Nombre_Usuario") = ""
            dr("Nombre_Corto") = "(Usuarios)..."
            dt_Usuarios.Rows.InsertAt(dr, 0)

            cmb.ValueMember = "Clave_Usuario"
            cmb.DisplayMember = "Nombre_Corto"
            cmb.DataSource = dt_Usuarios

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOS", "FIN - CONSULTA DEPÓSITOS COMBO USUARIOS BD_SDF")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 55, varPub.IdPantalla, "CONSULTA DEPOSITOS - " + "FIN - OCURRIÓ UN ERROR AL CONSULTAR USUARIOS: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOS", "FIN - OCURRIÓ UN ERROR AL CONSULTAR USUARIOS: " & ex.Message.ToUpper)
            Call fn_MsgBox("ERROR al Intentar Llenar la Lista Desplegable de Usuarios.", MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' Guardar Detalle del Depósito
    ''' </summary>
    ''' <param name="ClaveMoneda">Tipo de Moneda</param>
    ''' <param name="Denominacion">La Denominación de la Moneda</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Depositos_GuardarBillete(ByVal ClaveMoneda As String, ByVal Denominacion As Integer, ByVal SerieValidador As String, ByVal SerieCaset As String, ByVal NameCaset As String, Numero_Validador As Integer) As Boolean


        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing

        Try
            'Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "DepositosD_Insert")
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "[Depositos].[AddDetalleDeposito]")
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
            Crear_ParametroSQL(Cmd, "@ClaveDenominacion", SqlDbType.VarChar, ClaveMoneda + "" + Denominacion.ToString)
            Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Int, Denominacion)
            Crear_ParametroSQL(Cmd, "@ClaveMoneda", SqlDbType.VarChar, ClaveMoneda)
            Crear_ParametroSQL(Cmd, "@SerieCaset", SqlDbType.VarChar, SerieCaset)
            Crear_ParametroSQL(Cmd, "@Serievalidador", SqlDbType.VarChar, SerieValidador)
            Crear_ParametroSQL(Cmd, "@NumeroValidador", SqlDbType.Int, Numero_Validador)

            If Ejecutar_NonQueryTSQL(Cmd) > 0 Then
                tr.Commit()
                tr.Dispose()
                Cmd.Dispose()
                Cnn.Dispose()                            ' Va guardando cada Billete Introducido en su Respectivo CAset
                If NameCaset = "CasetID" Then varPub.Capacidad_Actual += 1 Else varPub.Capacidad_Actual2 += 1

                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "INSERTANDO BILLETE DE: " & Denominacion & ", SERIE VAL:" & SerieValidador & ", Y SERIE CASET: " & SerieCaset & ", ID_DEPOSITO: " & varPub.ID_DepositoP)
                varPub.ultBilleteDepositado = Fecha & " " & Hora
                Return True
            Else
                Cmd.Dispose()
                Cnn.Dispose()
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 48, varPub.IdPantalla, "DEPOSITOS - " + "ERROR GUARDAR DEPÓSITO: CLAVE DENOMINACIÓN: " & ClaveMoneda & Denominacion & ", DENOMINACIÓN: " & Denominacion & " ,ID_DEPOSITO: " & varPub.ID_DepositoP)
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "ERROR GUARDAR DEPÓSITO: CLAVE DENOMINACIÓN: " & ClaveMoneda & Denominacion & ", DENOMINACIÓN: " & Denominacion & " ,ID_DEPOSITO: " & varPub.ID_DepositoP)
                Call fn_MsgBox("Error al Guardar el Billete", MessageBoxIcon.Error)
                Return False
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 48, varPub.IdPantalla, "DEPOSITOS - " + "ERROR GUARDAR DEPÓSITO: CLAVE DENOMINACIÓN: " & ClaveMoneda & Denominacion & ", DENOMINACIÓN: " & Denominacion & " ,ID_DEPOSITO: " & varPub.ID_DepositoP & " " + ex.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "ERROR GUARDAR DEPÓSITO: CLAVE DENOMINACIÓN: " & ClaveMoneda & Denominacion & ", DENOMINACIÓN: " & Denominacion & " ,ID_DEPOSITO: " & varPub.ID_DepositoP)
            tr.Rollback()
            Cmd.Dispose()
            Cnn.Dispose()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Guardar Detalle de Depósito depués de un error en la Conexión
    ''' </summary>
    ''' <param name="Clave_Denominacion">Tipo de Moneda</param>
    ''' <param name="Denominacion">La Denominación de la Moneda</param>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Function fn_Depositos_GuardarBilleteDesconexion(ByVal Clave_Denominacion As String, ByVal Denominacion As String, ByRef lsv As ListView, ByVal numSeriecaset As String, ByVal NameCaset As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "INICIO - GUARDAR DEPÓSITO DESPUÉS DE DESCONEXIÓN ")

        'Dim cnn As SqlCeConnection = Crea_ConexionSTD()
        'Dim cmd As SqlCeCommand
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing

        Try
            If Not String.IsNullOrEmpty(Clave_Denominacion) AndAlso Not String.IsNullOrEmpty(Denominacion) Then

                'Encaso de que si existan datos, Realizar el depósito
                ' cmd = Crea_Comando(Query, CommandType.Text, cnn)
                'Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "DepositosD_GuardarBilleteDesconectado")
                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "[Depositos].[AddDetalleDeposito]")
                'Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
                'Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, Clave_Denominacion)
                'Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Int, Denominacion)
                Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
                Crear_ParametroSQL(Cmd, "@ClaveDenominacion", SqlDbType.VarChar, Clave_Denominacion + Denominacion)
                Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Int, Denominacion)
                Crear_ParametroSQL(Cmd, "@ClaveMoneda", SqlDbType.VarChar, Clave_Denominacion)
                Crear_ParametroSQL(Cmd, "@SerieCaset", SqlDbType.VarChar, numSeriecaset)
                Crear_ParametroSQL(Cmd, "@Serievalidador", SqlDbType.VarChar, IIf(NameCaset = "Caset2ID", varPub.Serie_Val2, varPub.Serie_Val1))
                Crear_ParametroSQL(Cmd, "@NumeroValidador", SqlDbType.Int, IIf(NameCaset = "Caset2ID", 2, 1))

                If Ejecutar_NonQueryTSQL(Cmd) > 0 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "INSERTANDO BILLETE DE: " & Denominacion)
                Else
                    Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "Error GUARDAR DEPÓSITO DESPUÉS DE DESCONEXIÓN: Clave Denominación " & CStr(Clave_Denominacion) & CStr(Denominacion) & ", Denominación " & CStr(Denominacion))
                    Call fn_MsgBox("ERROR al Guardar la Última Denominación.", MessageBoxIcon.Error)
                    Return False
                End If
            End If

            'Agregar filtro Id_caset donde se introdujo e ir ++ La Capacidad del caset
            'cmd = Crea_Comando(Query, CommandType.Text, cnn)

            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "DepositosD_GuardarBilleteDesconectado2")
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, numSeriecaset)
            Dim dt_Detalle As DataTable = Ejecutar_ConsultaTSQL(Cmd)

            ' Va guardando cada Billete Introducido en su Respectivo CAset
            If NameCaset = "CasetID" Then varPub.Capacidad_Actual += dt_Detalle.Rows.Count Else varPub.Capacidad_Actual2 += dt_Detalle.Rows.Count

            Call fn_LlenarListView(dt_Detalle, lsv, "", "")
            Dim w As Integer = (lsv.Width / 4)
            lsv.Columns(0).Width = w
            lsv.Columns(1).Width = w * 2
            lsv.Columns(1).TextAlign = HorizontalAlignment.Right

            tr.Commit()
            tr.Dispose()
            Cmd.Dispose()
            Cnn.Dispose()
            Return True
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 48, varPub.IdPantalla, "DEPOSITOS - " + "Error GUARDAR DEPÓSITO DESPUÉS DE DESCONEXIÓN: Clave Denominación " & CStr(Clave_Denominacion) & CStr(Denominacion) & ", Denominación " & CStr(Denominacion))
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "Error GUARDAR DEPÓSITO DESPUÉS DE DESCONEXIÓN: Clave Denominación " & CStr(Clave_Denominacion) & CStr(Denominacion) & ", Denominación " & CStr(Denominacion))
            tr.Rollback()
            Cmd.Dispose()
            Cnn.Dispose()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Registro de los Detalles del Depósito
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub fn_Depositos_Detalle(ByVal Detalle As String)
        If Detalle = varPub.Detalle_Anterior Then
            varPub.Detalle_Anterior = Detalle
        Else
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "DETALLE DEPÓSITO: " & Detalle)
            varPub.Detalle_Anterior = Detalle
        End If
    End Sub

    ''' <summary>
    ''' Nuevo Depósito
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Depositos_Open(Optional ByVal TipoDeposito As Byte = 1, Optional ByVal EsEfectivo As Char = "S", Optional Id_Caja As Integer = 0, Optional Clave_Caja As String = "") As Boolean

        Dim NombreDeposito As String = "POR VALIDADOR"
        Dim Folio As String = 0
        varPub.ID_DepositoP = 0

        If TipoDeposito = 2 Then
            NombreDeposito = " MANUAL(POR BUZÓN)"
        End If

        'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "INICIO - NUEVA SESIÓN DEPÓSITO " & NombreDeposito)


        Try
            'Se maneja una Conexión Abierta y las Ejecutar 'T' para obtener el Identity
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadUltimo", CommandType.StoredProcedure, Cnn)
            Dim FolioMax As Object = Ejecutar_ScalarSQL(Cmd)
            If varPub.ManejaFolioManual Then
                Folio = varPub.FolioManual
            Else
                If IsDBNull(FolioMax) Then
                    Folio = 1
                Else
                    Folio = FolioMax + 1

                End If
            End If
            '''''
            If TipoDeposito = 2 Then
                If IsDBNull(FolioMax) Then
                    Folio = 1
                Else
                    Folio = FolioMax + 1
                End If
            End If

            If varPub.Folio = Nothing Then varPub.Folio = ""
            If varPub.CorteActual = 0 Then

                Call fn_MsgBox("No se encontro el Corte.", MessageBoxIcon.Error)
                Return False
            End If

            Cmd = Crear_ComandoSQL("Depositos_Insert2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Cajero", SqlDbType.VarChar, varPub.Id_Caje)            '08/08/2020
            Crear_ParametroSQL(Cmd, "@Folio", SqlDbType.VarChar, Folio)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, TipoDeposito)
            Crear_ParametroSQL(Cmd, "@Usuario_Registro", SqlDbType.Int, varPub.UsuarioClave)
            Crear_ParametroSQL(Cmd, "@Fecha_Inicio", SqlDbType.DateTime, Fecha + " " + Hora)
            Crear_ParametroSQL(Cmd, "@Fecha_Fin", SqlDbType.DateTime, Fecha + " " + Hora)
            Crear_ParametroSQL(Cmd, "@tipoCambio_USD", SqlDbType.Money, varPub.TipoCambio)
            Crear_ParametroSQL(Cmd, "@Id_Corte", SqlDbType.Int, varPub.CorteActual)
            Crear_ParametroSQL(Cmd, "@Es_Efectivo", SqlDbType.VarChar, EsEfectivo)
            Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            Crear_ParametroSQL(Cmd, "@Clave_Caja", SqlDbType.VarChar, Clave_Caja)
            Crear_ParametroSQL(Cmd, "@Id_Transaccion", SqlDbType.Int, varPub.Id_Transaccion)
            Crear_ParametroSQL(Cmd, "@Folio_Transaccion", SqlDbType.VarChar, varPub.Folio)

            varPub.ID_DepositoP = Ejecutar_ScalarSQL(Cmd)  ' Se obtien el id Folio del depósito para guardar en la tabla Transaccion
            varPub.FolioDeposito = Folio

            Cmd.Dispose()
            Cnn.Dispose()

            'obtenemos la hora de inicio del deposito --
            varPub.Hora_Inicio = Hora
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - DEPOSITO ABIERTO CORRECTAMENTE CON FOLIO: " & Folio)

            If varPub.ID_DepositoP > 0 Then
                Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
                Persistente.Persistir()
                Persistente.Cargar()
                Return True
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN- ERROR AL ABRIR NUEVA SESIÓN DEPÓSITO CON FOLIO: " & Folio)
                Call fn_MsgBox("ELSE Error al Iniciar la Conexión.", MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 76, varPub.IdPantalla, "DEPOSITOS- " + "OCURRIÓ ERROR AL ABRIR NUEVA SESIÓN DEPÓSITO CON FOLIO: " + Folio + " " + ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "OCURRIÓ ERROR AL ABRIR NUEVA SESIÓN DEPÓSITO CON FOLIO: " & Folio & ex.Message.ToUpper)
            Call fn_MsgBox("CATCH Error al Iniciar la Conexión.", MessageBoxIcon.Error)

            Return False
        End Try

    End Function

    Public Shared Sub fn_ImprimirAtascos(ByVal IdDeposito As Integer)
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand

        Try
            Cmd = Crear_ComandoSQL("[Depositos].[GetImprimirAtascos]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@IdDeposito", SqlDbType.Int, IdDeposito)
            Dim dt_Atasco As DataTable = Ejecutar_ConsultaSQL(Cmd)
            dt_Atasco = Ejecutar_ConsultaSQL(Cmd)

            Cmd = Crear_ComandoSQL("[Depositos].[GetImprimirAtascos]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@IdDeposito", SqlDbType.Int, 0)
            Dim dt_Atasco2 As DataTable = Ejecutar_ConsultaSQL(Cmd)
            dt_Atasco2 = Ejecutar_ConsultaSQL(Cmd)

            ''------impresion de ticket windows Normal y Embebido
            varPub.SegundosSesion = 0
            For i As Byte = 1 To varPub.Num_CopiasImprimir
                varPub.SegundosSesion = 0

                Select Case varPub.Tipo_Windows
                    Case TipoWindows.Normal
                        '--seleciconar modo impresion
                        Select Case varPub.Modo_Impresion
                            Case ModoImpresion.Nippon

                                Dim ReciboAtasco As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                                With ReciboAtasco
                                    .dr_General = dt_Atasco.Rows(0)
                                    .dt_Desglose = dt_Atasco
                                    .dt_Desglose2 = dt_Atasco2
                                    .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Atascos
                                End With

                                Dim newimp As New cls_NPIticket80mmWinNormal
                                newimp.fn_ImprimirAtasco(ReciboAtasco)

                            Case ModoImpresion.Windows
                                Select Case varPub.Tamaño_Papel
                                    Case TamañoPapel._80mm
                                        Dim ReciboAtasco As stc_80mmWinNormal = New stc_80mmWinNormal
                                        With ReciboAtasco
                                            .dr_General = dt_Atasco.Rows(0)
                                            .dt_Desglose = dt_Atasco
                                            .dt_Desglose2 = dt_Atasco2
                                            .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Atascos
                                        End With
                                        cls_Ticket80mmWinNormal.Imprimir(ReciboAtasco)


                                    Case TamañoPapel._58mm
                                        Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                        With Recibo
                                            .dr_General = dt_Atasco.Rows(0)
                                            .dt_Desglose = dt_Atasco
                                            .dt_Desglose2 = dt_Atasco2
                                            .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito
                                        End With
                                        cls_Ticket58mmWinNormal.Imprimir(Recibo)
                                End Select
                        End Select
                End Select
            Next
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 82, varPub.IdPantalla, "IMPRIMIR TICKET" + " FIN - ERROR AL IMPRIMIR INFORMACIÓN DEL ATASCO. " + ex.ToString())
            Cmd.Dispose()
            Cnn.Dispose()
        End Try
    End Sub
    Public Shared Function fn_Depositos_imprimir(TipoDeposito As Integer, Id_DepositoImprimir As Integer, IdPantalla As Integer)
        Dim Total_Depositos As Integer = 0
        Dim TotalUSDConvert As Decimal = 0D
        Dim ImporteTotalLetras As String = ""
        'Id_DepositoImprimir = varPub.ID_DepositoP
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand

        '« INICIA PROCESO DE IMPRESIÓN DE TICKETS »
        'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "INICIO - IMPRIMIR INFORMACIÓN DEPÓSITO.")

        Cmd = Crear_ComandoSQL("Depositos_Read2", CommandType.StoredProcedure, Cnn)
        Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoImprimir)
        Dim dt_General As DataTable = Ejecutar_ConsultaSQL(Cmd)

        If dt_General Is Nothing Then
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 45, IdPantalla, "DEPOSITOS-" + " FIN - ERROR AL IMPRIMIR INFORMACIÓN DEL DEPOSITO.")
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", " FIN - ERROR AL IMPRIMIR INFORMACIÓN DEL DEPOSITO.")
            Call fn_MsgBox("Error al Imprimir la Información.", MessageBoxIcon.Error)
            Cmd.Dispose()
            Cnn.Dispose()
            Return False
        ElseIf dt_General.Rows.Count = 0 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - NO EXISTE INFORMACIÓN PARA IMPRIMIR.")
            Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
            Cmd.Dispose()
            Cnn.Dispose()
            Return False
        End If

        'Consultar el DESGLOSE del Depósito.
        Dim dt_Desglose As DataTable = Nothing
        Dim dt_Desglose2 As DataTable = Nothing
        If TipoDeposito = 1 Then

            Cmd = Crear_ComandoSQL("Depositos_DesgloseValidador1", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoImprimir)
            dt_Desglose = Ejecutar_ConsultaSQL(Cmd)

            Cmd = Crear_ComandoSQL("Depositos_DesgloseValidador2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoImprimir)
            dt_Desglose2 = Ejecutar_ConsultaSQL(Cmd)

            If dt_Desglose2 Is Nothing And dt_Desglose Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 46, IdPantalla, "DEPOSITOS-" + "FIN - ERROR AL IMPRIMIR DESGLOSE DEL DEPÓSITO.")
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - ERROR AL IMPRIMIR DESGLOSE DEL DEPÓSITO.")
                Call fn_MsgBox("Error al Imprimir la Información.", MessageBoxIcon.Error)
                Return False
            ElseIf dt_Desglose2.Rows.Count = 0 And dt_Desglose.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - NO EXISTE DESGLOSE DEL DEPOSITO PARA IMPRIMIR.")
            End If

        End If

        ' ******se deberia agregar 0 en num_copias a imprimir ******
        ' para que no guarde en memoria cuando se acaba papel.

        '------impresion de ticket windows Normal y Embebido
        varPub.SegundosSesion = 0
        For i As Byte = 1 To varPub.Num_CopiasImprimir
            varPub.SegundosSesion = 0

            Select Case varPub.Tipo_Windows
                Case TipoWindows.Normal
                    '--seleciconar modo impresion
                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon

                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Deposito
                            End With

                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows
                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm
                                    Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo2
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Desglose = dt_Desglose
                                        .dt_Desglose2 = dt_Desglose2
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Deposito
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Desglose = dt_Desglose
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito
                                    End With
                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)
                            End Select
                    End Select

                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Deposito
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Deposito
                            End With
                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select
            End Select
        Next
        'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - EL TICKET SE IMPRIMIO CORRECTAMENTE")
        Return True
    End Function

    Public Shared Function fn_Depositos_Close(ByVal ImporteTotal As Decimal, ByVal TotalMXP As Decimal, ByVal TotalUSD As Decimal, ByVal IdPantalla As Integer, Optional ByVal TipoDeposito As Byte = 1) As Boolean
        Dim NombreDeposito As String = "POR VALIDADOR"
        If TipoDeposito = 2 Then NombreDeposito = " MANUAL(POR BUZÓN)"
        'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "INICIO - CERRAR SESIÓN DEPÓSITO " & NombreDeposito & " CON ID: " & varPub.ID_DepositoP)

        Try
            Dim Total_Depositos As Integer = 0
            Dim TotalUSDConvert As Decimal = 0D
            Dim ImporteTotalLetras As String = ""
            Dim ID_DepositoImprimir As Integer = varPub.ID_DepositoP
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand
            Dim filasAfectadas As Integer = 0

            'Revisar que si existe información en la tabla DepositosD
            'Solo si es del Tipo 1( por Validador)
            If TipoDeposito = 1 Then

                Cmd = Crear_ComandoSQL("Depositos_UpdateCancelar", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
                Crear_ParametroSQL(Cmd, "@TipoDeposito", SqlDbType.Int, TipoDeposito)

                filasAfectadas = Ejecutar_NonQuerySQL(Cmd)
                If filasAfectadas > 0 Then
                    'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - CERRAR SESION DEPÓSITO, SE CANCELO DEPOSITO CON ID: " & varPub.ID_DepositoP & ", POR NO TENER REGISTROS EN LA TABLA «DepositosD»")
                    Cmd.Dispose()
                    Cnn.Dispose()
                    varPub.ID_DepositoP = 0
                    Dim Persistente1 As cls_VariablesPersistentes = New cls_VariablesPersistentes
                    If Persistente1.Existe Then
                        Persistente1.Persistir()
                        Persistente1.Cargar()
                        Return True
                    End If
                End If
            End If


            'En esta parte convertimos los Dolares a Pesos
            TotalUSDConvert = TotalUSD * varPub.TipoCambio
            'Nota: El Importe_Total ya trae el total de pesos + el total de dolares convertidos a pesos
            ImporteTotalLetras = fn_ConvertNumeroALetras(ImporteTotal, "MXP")

            'Si existen datos Actualizar la tabla Depositos y realizar el cierre Normal
            'If filasAfectadas > 0 Then
            If varPub.ID_DepositoP > 0 Then

                Cmd = Crear_ComandoSQL("Depositos_UpdateCierre", CommandType.StoredProcedure, Cnn)
                'Cmd = Crear_ComandoSQL("[Depositos].[UpdateTotalesDeposito]", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_Cajero", SqlDbType.VarChar, varPub.Id_Caje)
                Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
                'Crear_ParametroSQL(Cmd, "@Fecha_Fin", SqlDbType.VarChar, Fecha + " " + Hora)
                Crear_ParametroSQL(Cmd, "@Fecha_Fin", SqlDbType.DateTime, Convert.ToDateTime(Fecha + " " + Hora))
                Crear_ParametroSQL(Cmd, "@Total_MXP", SqlDbType.Money, TotalMXP)
                Crear_ParametroSQL(Cmd, "@Total_USD", SqlDbType.Money, TotalUSD)
                Crear_ParametroSQL(Cmd, "@TotalUSD_Convert", SqlDbType.Money, TotalUSDConvert)
                Crear_ParametroSQL(Cmd, "@Importe_Total", SqlDbType.Money, ImporteTotal)
                Crear_ParametroSQL(Cmd, "@TipoCambio_USD", SqlDbType.Money, varPub.TipoCambio)
                Crear_ParametroSQL(Cmd, "@ImporteTotal_Letras", SqlDbType.VarChar, ImporteTotalLetras)
                Crear_ParametroSQL(Cmd, "@Id_Transaccion", SqlDbType.Int, varPub.Id_Transaccion)

                If Ejecutar_NonQuerySQL(Cmd) <= 0 Then
                    Cmd.Dispose()
                    Cnn.Dispose()
                    Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - ERROR AL FINALIZAR DEPÓSITO")
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 44, 24, "DEPOSITOS-" + "FIN - ERROR AL FINALIZAR DEPÓSITO")
                    Call fn_MsgBox("Error al Finalizar el Depósito.", MessageBoxIcon.Error)
                    Return False
                End If
                'End If

                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - CERRAR SESIÓN DEPÓSITO CON ID: " & varPub.ID_DepositoP)

            Else
                Return False
            End If

            If varPub.ID_UltimoRetiro > 0 Then
                'Actualizar el Status de "A" a "V" en Retiros en caso de Inicio de Nuevo Deposito

                Cmd = Crear_ComandoSQL("Retiros_Update", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_UltimoRetiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
                Ejecutar_NonQuerySQL(Cmd)
                varPub.ID_UltimoRetiro = 0
            End If

            'BJSE 2020
            'linea para que no imprima ticket, cuando haya atasco sin modificaciones a los totales.
            If varPub.FlagImprimirTicket = 1 Then
                Call fn_Depositos_imprimir(TipoDeposito, varPub.ID_DepositoP, 24)
                varPub.ID_DepositoP = 0
            End If

            ''BJSE 2020
            'varPub.ID_DepositoP = 0
            Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
            If Persistente.Existe Then
                Persistente.Persistir()
                Persistente.Cargar()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''-----------------
            '----------W E B------
            '--------- COMENTARIZADO POR BJSE Y JMCB 2021 PARA QUE SOLO SINCRONICE VIA AL TERMINAR TIMER, BOTON SINCRONIZAR Y AL CERRAR SESIÓN.

            'If (varPub.ConexionwebAdmin = 1) Then
            '    If fn_VerificaConexionInternet() Then

            '        'FUNCION NUEVA BJSE 2021
            '        'Call fn_SincronizaDepositos_aWEBWs()

            '        fn_SincronizarDepositosWebServices()

            '        'FUNCION ANTERIOR
            '        'Call fn_SincronizaDepositos_aWEB()

            '        Call fn_SincronizaUltimaConexion()
            '    End If
            '    varPub.SegundosReceptor = 0
            'End If
            '---------------------
            '--------COMENTARIZADO BJSE, JMB 2021
            Return True
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 44, IdPantalla, "FIN - ERROR AL FINALIZAR DEPÓSITO " & NombreDeposito & " CON ID:  " & varPub.ID_DepositoP & " " & ex.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", "FIN - ERROR AL FINALIZAR DEPÓSITO " & NombreDeposito & " CON ID: " & varPub.ID_DepositoP)
            Call fn_MsgBox("Error al Finalizar el Depósito.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Shared Sub fn_DepositosPendientes_Close()
        'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "INICIO - BUSCAR DEPOSITOS PENDIENTE EN STATUS 'A'")
        ''aqui se le agrega el recalculo del detalle 
        'Try
        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim Query As String = ""
        '    Dim cmd As SqlCeCommand

        '    Query = "Select Id_Deposito, " & _
        '            "TipoCambio_USD " & _
        '            "From Depositos " & _
        '            "Where Status = 'A' "
        '    cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Dim Dt_DepositoPendiente As DataTable = Ejecutar_ConsultaSQLCE(cmd)

        '    '1.Si ocurrio error al consultar status='A'
        '    If Dt_DepositoPendiente Is Nothing Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - OCURRIÓ UN ERROR AL CONSULTAR LOS DEPÓSITOS PENDIENTES EN STATUS = 'A'")
        '        Exit Sub
        '    End If

        '    '1.1 Si no hubo Depósitos pedientes no hacer nada
        '    If Dt_DepositoPendiente.Rows.Count = 0 Then
        '        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - NO EXISTEN DEPÓSITOS PENDIENTES EN STATUS = 'A'")
        '        Exit Sub
        '    End If

        '    Query = "Update Depositos " & _
        '            "Set Status = 'F' " & _
        '            "Where Status = 'A' "
        '    cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Ejecutar_NonQuerySQLCE(cmd)
        '    Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - SE FINALIZARON LOS DEPOSITOS PENDIENTES A ESTATUS 'F'")
        'Catch ex As Exception
        '    Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - OCURRIÓ UN ERROR AL FINALIZAR DEPOSITOS.")

        'End Try
        'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "INICIO - BUSCAR DEPOSITOS PENDIENTE EN STATUS A")


        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim FilasAfectadas As Integer = 0
        Dim Encontrado As Boolean = False

        'Sumar de el efectivo de depositosD y agregar a Importe_Total de depositos 27/03/2017
        Try

            If varPub.ID_DepositoP > 0 Then

                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_UpdatePendientes")
                Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, varPub.ID_DepositoP)
                Crear_ParametroSQL(Cmd, "@ImporteTotal", SqlDbType.Money, 0)
                Crear_ParametroSQL(Cmd, "@Total_MXP", SqlDbType.Money, 0)
                Crear_ParametroSQL(Cmd, "@Total_USD", SqlDbType.Money, 0)
                Crear_ParametroSQL(Cmd, "@TotalUSD_Convert", SqlDbType.Money, 0)
                Crear_ParametroSQL(Cmd, "@ImporteTotal_Letras", SqlDbType.VarChar, "")
                FilasAfectadas = Ejecutar_NonQueryTSQL(Cmd)
            End If
            tr.Commit()
            varPub.ID_DepositoP = 0 ' CesarOdz 27/03/2017
            Dim Persistente As New cls_VariablesPersistentes
            Persistente.Persistir()
            Persistente.Cargar()
            If Encontrado Then
                'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - SE ENCONTRO UN DEPOSITO PENDIENTE: " & Id_DepositoAnterior.ToString & " VALOR NUEVO: " & varPub.ID_DepositoP.ToString)
            End If
            'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - SE FINALIZARON LOS DEPOSITOS PENDIENTES A ESTATUS F")
        Catch ex As Exception
            tr.Rollback()
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 44, varPub.IdPantalla, "DEPOSITOS DESCONEXIÓN - " + "FIN - ERROR AL FINALIZAR DEPOSITOS." & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - OCURRIÓ UN ERROR AL FINALIZAR DEPOSITOS." & ex.Message.ToUpper)
        End Try
    End Sub

    ''' <summary>
    ''' Finalizar depósito en Status 'A' que quedo pendiente en caso de haberse cerrado  la pantalla Depósitos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_DepositosPendientes_CloseAnterior() As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "INICIO - BUSCAR DESPOSITOS PENDIENTE")
        ' se dejo de usar el 02/11/2016 ----------
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand
            Dim Id_DepositoIMprimir As Integer = 0
            'Obtener el Id_Deposito de depositos donde Status='A'

            Cmd = Crear_ComandoSQL("Depositos_ConsultarStatus", CommandType.StoredProcedure, Cnn)
            Dim Dt_DepositoPendiente As DataTable = Ejecutar_ConsultaSQL(Cmd)

            '1.Si ocurrio error al consultar status='A'
            If Dt_DepositoPendiente Is Nothing Then
                fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 17, 17, "FIN - ERROR AL CONSULTAR LOS DEPÓSITOS PENDIENTES EN STATUS = 'A'")
                'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - OCURRIÓ UN ERROR AL CONSULTAR LOS DEPÓSITOS PENDIENTES EN STATUS = 'A'")
                Return False
            End If

            '1.1 Si no hubo Depósitos pedientes no hacer nada
            If Dt_DepositoPendiente.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - NO EXISTEN DEPÓSITOS PENDIENTES EN STATUS = 'A'")
                Return False
            End If

            Id_DepositoIMprimir = Dt_DepositoPendiente.Rows(0)("Id_Deposito")

            '2.- Revisar que si existe información en la tabla DepositosD

            Cmd = Crear_ComandoSQL("DepositosD_Cantidad", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoIMprimir)
            Dim Cantidad_Depositos As Integer = Ejecutar_ScalarSQL(Cmd)

            '3.- Verificar Si existen depositos continuar operaciones

            If Cantidad_Depositos = 0 Then
                Return False
            End If

            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "INICIO - CERRAR SESIÓN DE DEPÓSITOS PENDIENTES EN STATUS: 'A'")

            '3.0  Obtener los importes Totales(MXP, USD)en DepositosD
            Cmd = Crear_ComandoSQL("DepositosD_ConsultarImporteTotal", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Dt_DepositoPendiente.Rows(0)("Id_Deposito"))

            Dim dt_ImportesMonedas As DataTable = Ejecutar_ConsultaSQL(Cmd)
            If dt_ImportesMonedas Is Nothing Then
                fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 18, 17, "ERROR al obtener los importes totales en pesos y dolares,del depósito pendiente.")
                'Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "Ocurrió un error al obtener los importes totales en pesos y dolares,del depósito pendiente.")
                Return False
            End If

            '3.1 Obtener los importes Totales por moneda
            Dim TotalMXP As Integer = 0
            Dim TotalUSD As Integer = 0

            For Each fila As DataRow In dt_ImportesMonedas.Rows
                If fila("Moneda") = "MXP" OrElse fila("Moneda") = "MXN" Then
                    TotalMXP += fila("Importe")
                ElseIf fila("Moneda") = "USD" Then
                    TotalUSD += fila("Importe")
                End If
            Next

            'Convertimos los Dolares a Pesos
            Dim TotalUSDConvert As Decimal = TotalUSD * Dt_DepositoPendiente.Rows(0)("TipoCambio_USD")

            'sumar importes en pesos y dolares convertidos a pesos
            Dim ImporteTotal As Decimal = TotalMXP + TotalUSDConvert

            'Convertir el Importe total a Letras
            Dim ImporteTotalLetras As String = fn_ConvertNumeroALetras(ImporteTotal, "MXN")

            'Si existen datos Actualizar la tabla Depositos y realizar el cierre Normal

            Cmd = Crear_ComandoSQL("Depositos_EditarPendientes", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoIMprimir)
            Crear_ParametroSQL(Cmd, "@UltimoBilleteDepos", SqlDbType.VarChar, varPub.ultBilleteDepositado)
            Crear_ParametroSQL(Cmd, "@ImporteTotal", SqlDbType.Money, ImporteTotal)
            Crear_ParametroSQL(Cmd, "@Total_MXP", SqlDbType.Money, TotalMXP)
            Crear_ParametroSQL(Cmd, "@Total_USD", SqlDbType.Money, TotalUSD)
            Crear_ParametroSQL(Cmd, "@TotalUSD_Convert", SqlDbType.Money, TotalUSDConvert)
            Crear_ParametroSQL(Cmd, "@ImporteTotal_Letras", SqlDbType.VarChar, ImporteTotalLetras)

            If Ejecutar_NonQuerySQL(Cmd) <= 0 Then
                Cmd.Dispose()
                Cnn.Dispose()

                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - ERROR AL FINALIZAR DEPÓSITO")
                Call fn_MsgBox("Error al Finalizar el Depósito.", MessageBoxIcon.Error)
                Return False
            End If

            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - CERRAR SESIÓN DEPÓSITO PENDIENTE BD_SDF")

            If varPub.ID_UltimoRetiro > 0 Then
                'Actualizar el Status de "A" a "V" en Retiros en caso de Inicio de Nuevo Deposito
                Cmd = Crear_ComandoSQL("Retiros_Update", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_UltimoRetiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
                Ejecutar_NonQuerySQL(Cmd)

                varPub.ID_UltimoRetiro = 0
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - ACTUALIZANDO RETIRO DE STATUS  'A' --> 'V'")
                Dim Persistentes As cls_VariablesPersistentes = New cls_VariablesPersistentes
                Persistentes.Persistir()
                Persistentes.Cargar()
            End If

            varPub.ID_DepositoP = 0 ' Reinicia el valor del deposito abierto que no habia sino finalizado
            Dim Persistente As New cls_VariablesPersistentes
            Persistente.Persistir()
            Persistente.Cargar()

            '---------IMPRESIÓN DE TICKET--------------
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "INICIO - IMPRIMIR INFORMACIÓN DEPÓSITO PENDIENTE")

            Cmd = Crear_ComandoSQL("Depositos_Read2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoIMprimir)

            Dim dt_General As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_General Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "Error IMPRIMIR INFORMACIÓN DEPOSITO PENDIENTE, dt_General Is Nothing")
                Call fn_MsgBox("Error al Imprimir la Información.", MessageBoxIcon.Error)
                Return False
            ElseIf dt_General.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "Fin IMPRIMIR INFORMACIÓN DEPOSITO PENDIENTE, dt_General.Rows.Count = 0")
                Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
                Return False
            End If

            'Consultar el DESGLOSE del Depósito realizado

            Cmd = Crear_ComandoSQL("DepositosD_ConsultarImporteTotal", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_DepositoIMprimir)
            Dim dt_Desglose As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Desglose Is Nothing Then
                fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 19, varPub.IdPantalla, "DEPOSITOS DESCONEXIÓN - " + "ERROR IMPRIMIR INFORMACIÓN DEPÓSITO PENDIENTE, dt_Detalle Is Nothing")
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "Error IMPRIMIR INFORMACIÓN DEPÓSITO PENDIENTE, dt_Detalle Is Nothing")
                Call fn_MsgBox(" Error al Imprimir la Información.", MessageBoxIcon.Error)
                Return False
            ElseIf dt_Desglose.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "Fin IMPRIMIR INFORMACIÓN DEPÓSITO PENDIENTE, dt_Detalle.Rows.Count = 0")
                Call fn_MsgBox("No encontró Información para Imprimir.", MessageBoxIcon.Error)
                Return False
            End If

            '------impresion de Ticket windows Normal y Embebido
            varPub.SegundosSesion = 0
            For i As Byte = 1 To varPub.Num_CopiasImprimir
                varPub.SegundosSesion = 0
                Select Case varPub.Tipo_Windows
                    Case "Normal"
                        If varPub.Tamaño_Papel = 1 Then
                            Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Deposito
                            End With
                            cls_Ticket80mmWinNormal.Imprimir(Recibo2)
                        Else
                            '---tipo Papel de 58mm
                            Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                            With Recibo
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito
                            End With
                            cls_Ticket58mmWinNormal.Imprimir(Recibo)
                        End If
                    Case "Embebido"
                        If varPub.Tamaño_Papel = 1 Then
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Deposito
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)
                        Else
                            '---tipo Papel de 58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Deposito
                            End With
                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                        End If
                End Select
            Next
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "FIN - IMPRIMIR INFORMACIÓN DEPÓSITO")

            '------W E B --------------
            '------ COMENTARIZADO POR BJSE Y JMCB 2021 PARA QUE SOLO SINCRONICE VIA AL TERMINAR TIMER, BOTON SINCRONIZAR Y AL CERRAR SESIÓN.
            'If (varPub.ConexionwebAdmin = 1) Then
            '    If fn_VerificaConexionInternet() Then

            '        'FUNCION ANTERIOR
            '        'Call fn_SincronizaDepositos_aWEB()

            '        'FUNCION NUEVA DEPOSITOS BJSE 2021
            '        'Call fn_SincronizaDepositos_aWEBWs()

            '        fn_SincronizarDepositosWebServices()

            '    End If
            'End If
            '------ COMENTARIZADO POR BJSE Y JMCB 2021

            Return True

        Catch ex As Exception
            fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 20, varPub.IdPantalla, "DEPOSITOS DESCONEXIÓN - " + "ERROR AL CERRAR SESIÓN DEPÓSITO PENDIENTE: " & ex.Message)
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS DESCONEXIÓN", "Error CERRAR SESIÓN DEPÓSITO PENDIENTE: " & ex.Message)
            Call fn_MsgBox(" error al Finalizar el depósito pendiente.", MessageBoxIcon.Error)
            Return False
        End Try

    End Function

#End Region

#Region "-Consulta Depósitos"
    ''' <summary>
    ''' Llenar la Lista con los Depósitos Realizados
    ''' </summary>
    ''' <param name="Desde">Fecha Inicial</param>
    ''' <param name="Hasta">Fecha Final</param>
    ''' <param name="Usuario_Clave">Clave del Usuario a Consultar</param>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    ''' 
    Public Shared Sub fn_ConsultaDepositos_Llenar(ByVal Desde As Date, ByVal Hasta As Date, ByRef lsv As ListView, ByVal dep_cancel As String, Optional ByVal Usuario_Clave As Integer = 0)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "INICIO - CONSULTA DEPOSITOS")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_Read", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Dep_Cancel", SqlDbType.VarChar, dep_cancel)
            Crear_ParametroSQL(Cmd, "@Desde", SqlDbType.Date, Desde)
            Crear_ParametroSQL(Cmd, "@Hasta", SqlDbType.Date, Hasta)
            Crear_ParametroSQL(Cmd, "@Usuario_Registro", SqlDbType.Int, Usuario_Clave)
            Dim dt_Depositos As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd.Dispose()
            Cnn.Dispose()
            If dt_Depositos.Rows.Count > 0 Then

                Call fn_LlenarListView(dt_Depositos, lsv, "Id_Deposito", "", True)
                lsv.Columns(6).Width = 0 'sincro 'S' O 'N'
                lsv.Columns(7).Width = 0 'columna tipo

                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - CONSULTA DEPOSITOS BD_SDF")
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - CONSULTA DEPOSITOS BD_SDF NO HUBO REGISTROS PARA ESTE RANGO DE FECHA")
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 21, varPub.IdPantalla, "CONSULTA DE DEPOSITOS - " + "FIN - ERROR AL CONSULTAR DEPOSITOS: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - ERROR AL CONSULTAR DEPOSITOS: " & ex.Message.ToUpper)
            Call fn_MsgBox("Ocurrió un error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reimprime el Ticket del deposito seleccionado
    ''' </summary>
    ''' <param name="Id_Deposito"></param>
    ''' <remarks></remarks>

    Public Shared Sub fn_ConsultaDepositos_Reimprimir(ByVal Id_Deposito As Integer, Optional ByVal TipoDeposito As Byte = 1)

        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "INICIO - REIMPRESION DE DEPOSITO")
        Call fn_Depositos_imprimir(TipoDeposito, Id_Deposito, 12)
        'Try

        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim Query As String = "Select d.Importe_Total, " & _
        '                    "d.Total_MXP, " & _
        '                    "d.Total_USD, " & _
        '                    "d.TotalUSD_Convert, " & _
        '                    "d.ImporteTotal_Letras, " & _
        '                    "d.Folio, " & _
        '                    "u.Clave_Usuario, " & _
        '                    "u.Nombre_Usuario, " & _
        '                    "Convert(nvarchar(10),d.Fecha_Inicio,103) As Fecha_Inicio, " & _
        '                    "Convert(nvarchar(10),d.Fecha_Inicio,108) As Hora_Inicio, " & _
        '                    "Convert(nvarchar(10),d.Fecha_Fin,103) As Fecha_Fin, " & _
        '                    "Convert(nvarchar(10),d.Fecha_Fin,108) As Hora_Fin, " & _
        '                    " d.Tipo, " & _
        '                    " d.TipoCambio_USD " & _
        '                    "From Depositos As d " & _
        '                    "Join Usuarios As u On u.Clave_Usuario = d.Usuario_Registro " & _
        '                    "Where d.Id_Deposito = '" & Id_Deposito & "'"
        '    Dim cmd As SqlCeCommand = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Dim dt_General As DataTable = Ejecutar_ConsultaSQLCE(cmd)

        '    Query = "Select Clave_Denominacion As Clave, " & _
        '           "Denominacion, " & _
        '           "Count(Clave_Denominacion) As Cantidad, " & _
        '           "Sum(Denominacion) As Importe, " & _
        '           "Clave_Moneda As Moneda " & _
        '           "From DepositosD " & _
        '           "Where Id_Deposito = " & Id_Deposito & " " & _
        '           "Group By Clave_Denominacion, Denominacion, Clave_Moneda " & _
        '           "Order By Moneda,Denominacion Desc"
        '    cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    Dim dt_Desglose As DataTable = Ejecutar_ConsultaSQLCE(cmd)

        '    cmd.Dispose()
        '    cnn.Dispose()

        '    If dt_Desglose.Rows.Count > 0 OrElse TipoDeposito = 2 Then
        '        '------REimpresion de ticket windows Normal y Embebido
        '        Select Case varPub.Tipo_Windows

        '            Case TipoWindows.Normal

        '                Select Case varPub.Modo_Impresion
        '                    Case ModoImpresion.Nippon
        '                        Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
        '                        With Recibo2
        '                            .dr_General = dt_General.Rows(0)
        '                            .dt_Desglose = dt_Desglose
        '                            .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Deposito
        '                        End With
        '                        Dim newimp As New cls_NPIticket80mmWinNormal
        '                        newimp.Imprimir(Recibo2)

        '                    Case ModoImpresion.Windows
        '                        Select Case varPub.Tamaño_Papel
        '                            Case TamañoPapel._80mm
        '                                Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
        '                                With Recibo2
        '                                    .dr_General = dt_General.Rows(0)
        '                                    .dt_Desglose = dt_Desglose
        '                                    .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Deposito
        '                                End With
        '                                cls_Ticket80mmWinNormal.Imprimir(Recibo2)

        '                            Case TamañoPapel._58mm
        '                                Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
        '                                With Recibo
        '                                    .dr_General = dt_General.Rows(0)
        '                                    .dt_Desglose = dt_Desglose
        '                                    .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito
        '                                End With
        '                                cls_Ticket58mmWinNormal.Imprimir(Recibo)

        '                        End Select

        '                End Select

        '            Case TipoWindows.Embebido

        '                Select Case varPub.Tamaño_Papel
        '                    Case TamañoPapel._80mm
        '                        Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
        '                        With Recibo4
        '                            .dr_General = dt_General.Rows(0)
        '                            .dt_Desglose = dt_Desglose
        '                            .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Deposito
        '                        End With
        '                        cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

        '                    Case TamañoPapel._58mm
        '                        '---tipo Papel de 58mm
        '                        Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
        '                        With Recibo3
        '                            .dr_General = dt_General.Rows(0)
        '                            .dt_Desglose = dt_Desglose
        '                            .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Deposito
        '                        End With
        '                        cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)

        '                End Select
        '        End Select
        '        '--------------------------------------
        '    Else
        '        fn_MsgBox("No hay Registros de este Depósito cancelado", MessageBoxIcon.Error)
        '    End If
        '    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOS", "FIN - REIMPRESIÓN DE DEPÓSITO")

        'Catch ex As Exception
        '    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOS", "FIN - OCURRIÓ UN ERROR AL REIMPRIMIR EL DEPÓSITO " & ex.Message.ToUpper)
        '    Call fn_MsgBox(" Error al Intentar Reimprimir el Depósito Seleccionado.", MessageBoxIcon.Error)
        'End Try
    End Sub

    Public Shared Function fn_ConsultaDepositos_SumaDepositos(ByVal Desde As Date, ByVal Hasta As Date, ByVal Usuario_Clave As Integer) As DataTable
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "INICIO - CONSULTA SUMA DEPOSITOS POR USUARIO")
        Dim dt As DataTable = Nothing
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing

        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Depositos_Suma", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Usuario", SqlDbType.Int, Usuario_Clave)
            Crear_ParametroSQL(Cmd, "@Desde", SqlDbType.Date, Desde)
            Crear_ParametroSQL(Cmd, "@Hasta", SqlDbType.Date, Hasta)
            dt = Ejecutar_ConsultaSQL(Cmd)

            If dt.Rows.Count > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - CONSULTA SUMA DEPOSITOS BD_SDF")
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - CONSULTA SUMA DEPOSITOS BD_SDF NO HUBO REGISTROS PARA ESTE RANGO DE FECHA")
            End If
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 22, varPub.IdPantalla, "CONSULTA DE DEPOSITOS - " + "FIN - ERROR AL CONSULTAR SUMA DEPOSITOS POR USUARIO: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - ERROR AL CONSULTAR SUMA DEPOSITOS POR USUARIO: " & ex.Message.ToUpper)
            Return Nothing
        End Try
        Return dt
    End Function

#End Region

#Region "-Atascos"
    Public Shared Sub fn_GetAtascos(ByVal ClaveUsuario As Integer, ByVal FechaInicio As DateTime, ByVal FechaFinal As DateTime, ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "INICIO - CONSULTA DEPOSITOS")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("[Depositos].[GetAtascos]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@ClaveUsuario", SqlDbType.Int, ClaveUsuario)
            Crear_ParametroSQL(Cmd, "@FechaInicio", SqlDbType.DateTime, FechaInicio)
            Crear_ParametroSQL(Cmd, "@FechaFinal", SqlDbType.DateTime, FechaFinal)
            Dim dt_Depositos As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Cmd.Dispose()
            Cnn.Dispose()
            If dt_Depositos.Rows.Count > 0 Then
                Call fn_LlenarListView(dt_Depositos, lsv, "Id_Deposito", "", True)
                lsv.Columns(0).Text = "Folio"
                lsv.Columns(0).Width = 200
                lsv.Columns(1).Text = "Clave"
                lsv.Columns(1).Width = 100
                lsv.Columns(2).Text = "Usuario"
                lsv.Columns(2).Width = 250
                lsv.Columns(3).Text = "Fecha"
                lsv.Columns(3).Width = 150
                lsv.Columns(4).Text = "Hora"
                lsv.Columns(4).Width = 150
                lsv.Columns(5).Text = "Totales Antes"
                lsv.Columns(5).Width = 150
                lsv.Columns(6).Text = "Importe Descontado"
                lsv.Columns(6).Width = 220
                lsv.Columns(7).Text = "Total Nuevo"
                lsv.Columns(7).Width = 150
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE ATASCOS", "FIN - CONSULTA ATASCOS")
            Else
                lsv.Columns(0).Text = "Folio"
                lsv.Columns(0).Width = 200
                lsv.Columns(1).Text = "Clave"
                lsv.Columns(1).Width = 100
                lsv.Columns(2).Text = "Usuario"
                lsv.Columns(2).Width = 250
                lsv.Columns(3).Text = "Fecha"
                lsv.Columns(3).Width = 150
                lsv.Columns(4).Text = "Hora"
                lsv.Columns(4).Width = 150
                lsv.Columns(5).Text = "Totales Antes"
                lsv.Columns(5).Width = 150
                lsv.Columns(6).Text = "Importe Descontado"
                lsv.Columns(6).Width = 220
                lsv.Columns(7).Text = "Total Nuevo"
                lsv.Columns(7).Width = 150
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - CONSULTA ATASCOS NO HUBO REGISTROS PARA ESTE RANGO DE FECHA")
            End If
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 83, varPub.IdPantalla, "CONSULTA DE DEPOSITOS - " + "FIN - ERROR AL CONSULTAR ATASCOS: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE DEPOSITOS", "FIN - ERROR AL CONSULTAR ATASCOS: " & ex.Message.ToUpper)
            Call fn_MsgBox("Ocurrió un error al buscar registros de atascos.", MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Consulta de Detalle de Depósitos"

    ''' <summary>
    ''' Llenar la Lista con el Detalle de Depósitos Realizados
    ''' </summary>
    ''' <param name="Id_Deposito">Depósito que se Desglozará</param>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaDepositosD_Llenar(ByVal Id_Deposito As Integer, ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOSD", "INICIO - CONSULTA DEPÓSITOS DETALLE")

        Try
            Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("DepositosD_ConsultarImporteTotal", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, Id_Deposito)
            Dim dt_DepositosD As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd.Dispose()
            cnn.Dispose()
            Call fn_LlenarListView(dt_DepositosD, lsv, "", "")
            lsv.Columns(4).Width = 0

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOSD", "FIN - CONSULTA DEPÓSITOS DETALLE")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 23, varPub.IdPantalla, "CONSULTA DETALLE DEPOSITOS" + "FIN - ERROR AL CONSULTAR DEPÓSITOS DETALLE: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DEPOSITOSD", "FIN - ERROR AL CONSULTAR DEPÓSITOS DETALLE: " & ex.Message.ToUpper)
            Call fn_MsgBox(" Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub GetAnulacionDenominacion(ByVal IdDeposito As Integer, ByVal TipoValidador As Integer, ByVal Denominacion As String)
        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 25/02/2021

        Dim Cnn As SqlConnection
        Dim Cmd As SqlCommand
        Dim Resultado As Object

        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("[Depositos].[GetAnulacionDenominacion]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@IdDeposito", SqlDbType.Int, IdDeposito)
            Resultado = Ejecutar_ScalarSQL(Cmd)
            If Convert.ToInt32(Resultado) > 0 Then
                Cmd = Crear_ComandoSQL("[Depositos].[AnularDenominacion]", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@IdDeposito", SqlDbType.Int, IdDeposito)
                Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Char, Denominacion)
                Ejecutar_NonQuerySQL(Cmd)
            End If
        Catch ex As Exception
            If TipoValidador = 1 Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 70, varPub.IdPantalla, "CONSULTA DENOMINACIONES" + "FIN - ERROR AL CONSULTAR DENOMINACIONES DEL DETALLE CON VALIDADOR V1: " & ex.Message.ToUpper)
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DENOMINACIONES", "FIN - ERROR AL CONSULTAR DENOMINACIONES DEL DETALLE CON VALIDADOR V1: " & ex.Message.ToUpper)
                Call fn_MsgBox("ERROR AL CONSULTAR DENOMINACIONES DEL DETALLE", MessageBoxIcon.Error)
            Else
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 70, varPub.IdPantalla, "CONSULTA DENOMINACIONES" + "FIN - ERROR AL CONSULTAR DENOMINACIONES DEL DETALLE CON VALIDADOR V2: " & ex.Message.ToUpper)
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DENOMINACIONES", "FIN - ERROR AL CONSULTAR DENOMINACIONES DEL DETALLE CON VALIDADOR V2: " & ex.Message.ToUpper)
                Call fn_MsgBox("ERROR AL CONSULTAR DENOMINACIONES DEL DETALLE", MessageBoxIcon.Error)
            End If
        End Try
    End Sub

#End Region


#Region "Consulta Saldos"
    Public Shared Function fn_ConsultaSaldosValidados(ventana As Integer) As DataTable

        'Consulta los importes totales de Depositos Validados.
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "INICIO - CONSULTA SALDOS TOTALES")

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadSaldo6", CommandType.StoredProcedure, Cnn)
            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
                Crear_ParametroSQL(Cmd, "@ConCorte", SqlDbType.Int, 0)
            Else
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
                Crear_ParametroSQL(Cmd, "@ConCorte", SqlDbType.Int, 1)
            End If

            Dim dt_Saldos As DataTable = Ejecutar_ConsultaSQL(Cmd)
            'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "FIN - CONSULTA SALDOS BD_SDF")
            Return dt_Saldos

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 24, varPub.IdPantalla, "CONSULTA DE SALDOS -" + "FIN - ERROR AL REALIZAR LA OPERACION: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL REALIZAR LA OPERACION: " & ex.Message.ToUpper)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Llenar la Lista de el Saldo Actual
    ''' </summary>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaSaldos_Llenar(ByRef lsv As ListView, ByVal SerieCaset As String, ByVal ventana As Integer, Numero_Validador As Integer)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "INICIO - CONSULTA SALDOS")
        'kmlk
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadSaldo5", CommandType.StoredProcedure, Cnn)

            If varPub.ManejaCorte = 0 Or ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Numero_validador", SqlDbType.Int, Numero_Validador)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 0)
            Else
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Numero_validador", SqlDbType.Int, Numero_Validador)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 1)
            End If
            Dim dt_Saldos As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Saldos.Rows.Count = 0 Then
                Exit Sub
            End If

            Cmd.Dispose()
            Cnn.Dispose()
            Call fn_LlenarListView(dt_Saldos, lsv, "", "")

            Dim w As Integer = lsv.Width

            If varPub.Cant_Validadores = 2 Then
                lsv.Columns(0).Width = -2
                lsv.Columns(1).Width = -2
                lsv.Columns(2).Width = -2
                lsv.Columns(3).Width = -2
            ElseIf varPub.Cant_Validadores = 1 Then
                With lsv
                    .Columns(0).Width = w * 0.19
                    .Columns(1).Width = w * 0.3
                    .Columns(2).Width = w * 0.19
                    .Columns(3).Width = w * 0.19
                End With
            End If
            lsv.Columns(4).Width = 0

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "FIN - CONSULTA SALDOS CORRECTAMENTE EN BD_SDF")
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 24, varPub.IdPantalla, "CONSULTA SALDOS - " + "FIN -ERROR EN CONSULTA SALDOS: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "FIN -ERROR EN CONSULTA SALDOS: " & ex.Message.ToUpper)
            Call fn_MsgBox(" Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Function fn_ConsultaSaldosManualEfectivo(ventana As Integer) As DataTable
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "INICIO - CONSULTA SALDOS MANUAL")
        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)


            Dim Cmd As SqlCommand
            Dim dt_Saldos As DataTable

            Cmd = Crear_ComandoSQL("Depositos_ReadSaldo", CommandType.StoredProcedure, Cnn)

            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@EsEfectivo", SqlDbType.VarChar, "S")
                Crear_ParametroSQL(Cmd, "@ConCorte", SqlDbType.Int, 0)
            Else
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@EsEfectivo", SqlDbType.VarChar, "S")
                Crear_ParametroSQL(Cmd, "@ConCorte", SqlDbType.Int, 1)
            End If

            dt_Saldos = Ejecutar_ConsultaSQL(Cmd)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA CORTE", "FIN - CONSULTA SALDOS BD_SDF")
            Return dt_Saldos

            Cmd.Dispose()
            Cnn.Dispose()
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 25, varPub.IdPantalla, "CONSULTA SALDOS -" + "FIN - ERROR EN CONSULTA SALDOS MANUAL: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "FIN - ERROR EN CONSULTA SALDOS MANUAL: " & ex.Message.ToUpper)
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_ConsultaSaldosManualDocumento(ventana As Integer) As DataTable
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "INICIO - CONSULTA SALDOS MANUAL")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand
            Dim dt_Saldos As DataTable

            Cmd = Crear_ComandoSQL("Depositos_ReadSaldo", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@EsEfectivo", SqlDbType.VarChar, "N")

            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@ConCorte", SqlDbType.Int, 0)
            Else
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@ConCorte", SqlDbType.Int, 1)
            End If

            dt_Saldos = Ejecutar_ConsultaSQL(Cmd)
            'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "FIN - CONSULTA SALDOS BD_SDF")
            Return dt_Saldos


            Cmd.Dispose()
            Cnn.Dispose()
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 25, varPub.IdPantalla, "CONSULTA SALDOS - " + "FIN - ERROR EN CONSULTA SALDOS MANUAL: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA SALDOS", "FIN - ERROR EN CONSULTA SALDOS MANUAL: " & ex.Message.ToUpper)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Imprimir el Saldo Actual
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaSaldos_Imprimir(ByVal ventana As Integer)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "INICIO - IMPRIMIR INFORMACION SALDOS")
        Try
            Dim Cmd As SqlCommand
            Dim dt_Desglose As DataTable = Nothing
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Consultar el Depósito realizado e Imprimirlo
            'este query es solo para Validador mei
            Cmd = Crear_ComandoSQL("Depositos_ReadSaldo3", CommandType.StoredProcedure, Cnn)

            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val1)
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 0)

            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val1)
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 1)

            End If
            dt_Desglose = Ejecutar_ConsultaSQL(Cmd)


            If dt_Desglose Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 26, varPub.IdPantalla, "CONSULTA DE SALDOS - " + "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim Cnn2 As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Consultar el Depósito realizado e Imprimirlo
            'este query es solo para Validador mei
            ''>>>>--------------------------------------------->>>>---------------------------------------------

            Dim Cmd2 As SqlCommand
            Dim dt_Desglose2 As DataTable

            Cmd2 = Crear_ComandoSQL("Depositos_ReadSaldo3", CommandType.StoredProcedure, Cnn2)
            If ventana = 0 Then
                Crear_ParametroSQL(Cmd2, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val2)
                Crear_ParametroSQL(Cmd2, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd2, "@Con_Corte", SqlDbType.Int, 0)

            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd2, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val2)
                Crear_ParametroSQL(Cmd2, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd2, "@Con_Corte", SqlDbType.Int, 1)

            End If
            dt_Desglose2 = Ejecutar_ConsultaSQL(Cmd2)

            If dt_Desglose2 Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 26, varPub.IdPantalla, "CONSULTA DE SALDOS - " + "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '<<<Obtener Saldo Validado Totales en Peso, Dolar e Importe Total>>>>>>>>---------------------------------------------

            Dim Dt_SaldosValidado As DataTable

            Cmd = Crear_ComandoSQL("Depositos_ReadSaldo2", CommandType.StoredProcedure, Cnn)
            If ventana = 0 Then

                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 0)
            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 1)
            End If

            Dt_SaldosValidado = Ejecutar_ConsultaSQL(Cmd)
            If Dt_SaldosValidado Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 26, varPub.IdPantalla, "CONSULTA DE SALDOS - " + "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '<<<Obtener Saldo Manual Totales en Peso, Dolar e Importe Total en Efectivo>>>>---------------------------------------------
            Dim Dt_SaldosManual As DataTable

            Cmd = Crear_ComandoSQL("Depositos_ReadSaldo2", CommandType.StoredProcedure, Cnn)

            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 0)
            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
                Crear_ParametroSQL(Cmd, "@Con_Corte", SqlDbType.Int, 1)
            End If
            Dt_SaldosManual = Ejecutar_ConsultaSQL(Cmd)

            If Dt_SaldosManual Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 26, varPub.IdPantalla, "CONSULTA DE SALDOS - " + "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If
            '<<<Obtener Saldo Manual Totales en Peso, Dolar e Importe Total en Documentos>>>>---------------------------------------------
            Dim Dt_SaldosManualDoc As DataTable

            Cmd = Crear_ComandoSQL("Depositos_ReadManual", CommandType.StoredProcedure, Cnn)
            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "F")
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Es_Efectivo", SqlDbType.VarChar, "N")
            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "0")
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Es_Efectivo", SqlDbType.VarChar, "N")
            End If
            Dt_SaldosManualDoc = Ejecutar_ConsultaSQL(Cmd)

            If Dt_SaldosManualDoc Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '<<<Obtener Saldo  Totales  >>>>>>>>----------------------------------------------------------
            Dim Dt_SaldosTOTAL As DataTable

            Cmd = Crear_ComandoSQL("Depositos_ReadSaldo4", CommandType.StoredProcedure, Cnn)
            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "F")
                Crear_ParametroSQL(Cmd, "@Id_Corte", SqlDbType.Int, 0)
            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "0")
                Crear_ParametroSQL(Cmd, "@Id_Corte", SqlDbType.Int, varPub.CorteActual)
            End If
            Dt_SaldosTOTAL = Ejecutar_ConsultaSQL(Cmd)

            If Dt_SaldosTOTAL Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If
            'Consultas para la Información General 'Nombre del que esta firmado'>>>>>>>>----------------------------------------------------------
            Dim NombreUsuario As String

            Cmd = Crear_ComandoSQL("Usuarios_Read9", CommandType.StoredProcedure, Cnn)
            If ventana = 0 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
                Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, varPub.UsuarioClave)
            ElseIf ventana = 1 Then
                Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
                Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, varPub.UsuarioClave)
            End If
            NombreUsuario = Ejecutar_ScalarSQL(Cmd)
            Cmd.Dispose()
            Cnn.Dispose()

            '------Armamos el DT_GENERAL
            Dim dt_General As DataTable = New DataTable
            dt_General.Columns.Add("Fecha")
            dt_General.Columns.Add("Hora")
            dt_General.Columns.Add("Nombre_Usuario")
            dt_General.Columns.Add("Importe_Total")
            dt_General.Columns.Add("Total_MXP")
            dt_General.Columns.Add("Total_USD")
            dt_General.Columns.Add("Total_MXPDoc")
            dt_General.Columns.Add("Total_USDDoc")
            dt_General.Columns.Add("TotalUSD_Convert")
            dt_General.Columns.Add("TotalUSD_ConvertManual")
            dt_General.Columns.Add("TotalUSD_ConvertManualDoc")
            dt_General.Columns.Add("ImporteTotal_Letras")

            Dim SaldoV_ImporteTotal As Decimal = 0D
            Dim SaldoV_USD_Convert As Decimal = 0D

            Dim SaldoM_ImporteTotal As Decimal = 0D
            Dim SaldoM_MXP As Decimal = 0
            Dim SaldoM_USD As Decimal = 0
            Dim SaldoM_USDConvert As Decimal = 0D
            Dim SaldoM_ImporteTotalDoc As Decimal = 0D
            Dim SaldoM_MXPDoc As Decimal = 0
            Dim SaldoM_USDDoc As Decimal = 0
            Dim SaldoM_USDConvertDoc As Decimal = 0D


            If Not IsDBNull(Dt_SaldosValidado.Rows(0)("Importe_Total")) Then
                SaldoV_ImporteTotal = Dt_SaldosValidado.Rows(0)("Importe_Total")
                SaldoV_USD_Convert = Dt_SaldosValidado.Rows(0)("TotalUSD_Convert")
            End If
            If Not IsDBNull(Dt_SaldosTOTAL.Rows(0)("Importe_Total")) Then

            End If
            If Not IsDBNull(Dt_SaldosManual.Rows(0)("Importe_Total")) Then
                SaldoM_ImporteTotal = Dt_SaldosManual.Rows(0)("Importe_Total")
                SaldoM_MXP = Dt_SaldosManual.Rows(0)("Total_MXP")
                SaldoM_USD = Dt_SaldosManual.Rows(0)("Total_USD")
                SaldoM_USDConvert = Dt_SaldosManual.Rows(0)("TotalUSD_Convert")
            End If

            If Not IsDBNull(Dt_SaldosManualDoc.Rows(0)("Importe_Total")) Then
                SaldoM_ImporteTotalDoc = Dt_SaldosManualDoc.Rows(0)("Importe_Total")
                SaldoM_MXPDoc = Dt_SaldosManualDoc.Rows(0)("Total_MXP")
                SaldoM_USDDoc = Dt_SaldosManualDoc.Rows(0)("Total_USD")
                SaldoM_USDConvertDoc = Dt_SaldosManualDoc.Rows(0)("TotalUSD_Convert")
            End If

            Dim ImporteTotal As Decimal = SaldoM_ImporteTotal + SaldoV_ImporteTotal + SaldoM_ImporteTotalDoc
            Dim ImporteTotalLetras As String = fn_ConvertNumeroALetras(ImporteTotal.ToString, "MXN")

            'Agregar la información al dt_General 
            dt_General.Rows.Add(Format(Now, "dd/MM/yyyy"), Hora, NombreUsuario, ImporteTotal, SaldoM_MXP, SaldoM_USD, SaldoM_MXPDoc, SaldoM_USDDoc, SaldoV_USD_Convert, SaldoM_USDConvert, SaldoM_USDConvertDoc, ImporteTotalLetras)

            If dt_General Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR INFORMACIÓN SALDOS, dt_General Is Nothing")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_General.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - IMPRIMIR INFORMACION SALDOS, dt_General.Rows.Count = 0")
                Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '------impresion de ticket windows Normal y Embebido
            Select Case varPub.Tipo_Windows
                Case TipoWindows.Normal
                    '--seleciconar modo impresion
                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon

                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Ventana = ventana
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Saldo
                            End With

                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows
                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm
                                    Dim Recibo3 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo3
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Desglose = dt_Desglose
                                        .dt_Desglose2 = dt_Desglose2
                                        .Ventana = ventana
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Saldo
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo3)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Desglose = dt_Desglose
                                        .dt_Desglose2 = dt_Desglose2
                                        .Ventana = ventana
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Saldo
                                    End With
                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)
                            End Select
                    End Select

                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Saldo
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Saldo
                            End With
                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select
            End Select
            '-------------------
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN IMPRIMIR INFORMACIÓN SALDOS BD_SDF")
        Catch ex As Exception
            'fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 26)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "ERROR IMPRIMIR INFORMACIÓN SALDOS: " & ex.Message)
            Call fn_MsgBox("Ocurrió un Error al intentar imprimir el Saldo.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub fn_ConsultaCorte_Imprimir()
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "INICIO - IMPRIMIR INFORMACIÓN SALDOS")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Consultar el Depósito realizado e Imprimirlo
            'este query es solo para Validador mei

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadCorte6", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.Int, varPub.Serie_Val1)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
            Dim dt_Desglose As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Desglose Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox(" Error al Imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim Cnn2 As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Consultar el Depósito realizado e Imprimirlo
            'este query es solo para Validador mei

            Dim Cmd2 As SqlCommand = Crear_ComandoSQL("Depositos_ReadCorte6", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.Int, varPub.Serie_Val2)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
            Dim dt_Desglose2 As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Desglose2 Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR SALDOS.")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '<<<Obtener Saldo Validado Totales en Peso, Dolar e Importe Total>>>>

            Cmd = Crear_ComandoSQL("Saldos_ImprimirValidado", CommandType.StoredProcedure, Cnn)
            Dim Dt_SaldosValidado As DataTable = Ejecutar_ConsultaSQL(Cmd)

            '<<<Obtener Saldo Manual Totales en Peso, Dolar e Importe Total >>>>

            Cmd = Crear_ComandoSQL("Saldos_TotalValidado", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
            Dim Dt_SaldosManual As DataTable = Ejecutar_ConsultaSQL(Cmd)

            '<<<Obtener Saldo  Totales  >>>>

            Cmd = Crear_ComandoSQL("Saldos_TotalValidado", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
            Dim Dt_SaldosTOTAL As DataTable = Ejecutar_ConsultaSQL(Cmd)

            'Consultas para la Información General 'Nombre del que esta firmado'
            Cmd = Crear_ComandoSQL("Cortes_ConsultaUsuario", CommandType.StoredProcedure, Cnn)

            Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, 0)
            Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, varPub.UsuarioClave)
            Dim NombreUsuario As String = Ejecutar_ScalarSQL(Cmd)

            Cmd.Dispose()
            Cnn.Dispose()

            '------Armamos el DT_GENERAL
            Dim dt_General As DataTable = New DataTable
            dt_General.Columns.Add("Fecha")
            dt_General.Columns.Add("Hora")
            dt_General.Columns.Add("Nombre_Usuario")
            dt_General.Columns.Add("Importe_Total")
            dt_General.Columns.Add("Total_MXP")
            dt_General.Columns.Add("Total_USD")
            dt_General.Columns.Add("TotalUSD_Convert")
            dt_General.Columns.Add("TotalUSD_ConvertManual")
            dt_General.Columns.Add("ImporteTotal_Letras")

            Dim SaldoV_ImporteTotal As Decimal = 0D
            Dim SaldoV_USD_Convert As Decimal = 0D

            Dim SaldoM_ImporteTotal As Decimal = 0D
            Dim SaldoM_MXP As Integer = 0
            Dim SaldoM_USD As Integer = 0
            Dim SaldoM_USDConvert As Decimal = 0D


            If Not IsDBNull(Dt_SaldosValidado.Rows(0)("Importe_Total")) Then
                SaldoV_ImporteTotal = Dt_SaldosValidado.Rows(0)("Importe_Total")
                SaldoV_USD_Convert = Dt_SaldosValidado.Rows(0)("TotalUSD_Convert")
            End If
            If Not IsDBNull(Dt_SaldosTOTAL.Rows(0)("Importe_Total")) Then

            End If
            If Not IsDBNull(Dt_SaldosManual.Rows(0)("Importe_Total")) Then
                SaldoM_ImporteTotal = Dt_SaldosManual.Rows(0)("Importe_Total")
                SaldoM_MXP = Dt_SaldosManual.Rows(0)("Total_MXP")
                SaldoM_USD = Dt_SaldosManual.Rows(0)("Total_USD")
                SaldoM_USDConvert = Dt_SaldosManual.Rows(0)("TotalUSD_ConvertManual")
            End If

            Dim ImporteTotal As Decimal = SaldoM_ImporteTotal + SaldoV_ImporteTotal
            Dim ImporteTotalLetras As String = fn_ConvertNumeroALetras(ImporteTotal.ToString, "MXN")

            'Agregar la información al dt_General 
            dt_General.Rows.Add(Format(Now, "dd/MM/yyyy"), Hora, NombreUsuario, ImporteTotal, SaldoM_MXP, SaldoM_USD, SaldoV_USD_Convert, SaldoM_USDConvert, ImporteTotalLetras)

            If dt_General Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - ERROR AL IMPRIMIR INFORMACIÓN DE SALDOS, dt_General Is Nothing")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_General.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN - IMPRIMIR INFORMACIÓN DE SALDOS, dt_General.Rows.Count = 0")
                Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '------impresion de ticket windows Normal y Embebido
            Select Case varPub.Tipo_Windows
                Case TipoWindows.Normal

                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon
                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Saldo
                            End With
                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows
                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm
                                    Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo2
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Desglose = dt_Desglose
                                        .dt_Desglose2 = dt_Desglose2
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Saldo
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Desglose = dt_Desglose
                                        .dt_Desglose2 = dt_Desglose2
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Saldo
                                    End With
                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)
                            End Select
                    End Select

                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Saldo
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Saldo
                            End With
                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select
            End Select
            '-------------------
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "FIN IMPRIMIR INFORMACION SALDOS BD_SDF")


        Catch ex As Exception
            'fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 26)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE SALDOS", "ERROR IMPRIMIR INFORMACIÓN DE SALDOS: " & ex.Message)
            Call fn_MsgBox("Ocurrió un Error al Intentar Imprimir el Saldo.", MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Consulta de Movimientos"
    ''' <summary>
    ''' Llenar la Lista de Movimientos de Acuerdo al filtro establecido
    ''' </summary>
    ''' <param name="Desde">Fecha Inicial</param>
    ''' <param name="Hasta">Fecha Final</param>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaMovimientos_Llenar(ByVal Desde As Date, ByVal Hasta As Date, ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "INICIO CONSULTA MOVIMIENTOS")

        Try
            Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadMovimientos", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(Cmd, "@Desde", SqlDbType.Date, Desde)
            Crear_ParametroSQL(Cmd, "@Hasta", SqlDbType.Date, Hasta)
            Dim dt_Movimientos As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd.Dispose()
            cnn.Dispose()

            Call fn_LlenarListView(dt_Movimientos, lsv, "", "", True)

            For Each elemento As ListViewItem In lsv.Items
                If CDec(elemento.SubItems(4).Text) > 0 Then
                    elemento.BackColor = Color.LightGreen
                End If
            Next

            If dt_Movimientos.Rows.Count = 0 Then
                Call fn_MsgBox("No se encotraron Registros con ese rango de fechas.", MessageBoxIcon.Exclamation)
            End If

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "FIN CONSULTA MOVIMIENTOS BD_SDF")

        Catch ex As Exception
            'fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 27)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "ERROR CONSULTA MOVIMIENTOS: " & ex.Message)
            Call fn_MsgBox("Ocurrió un Error al intentar llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Imprimir los Movimientos de Acuerdo al rango de Fecha que seleccionamos
    ''' <param name="Desde">Fecha Inicial</param>
    ''' <param name="Hasta">Fecha Final</param>
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaMovimientos_Imprimir(ByVal Desde As Date, ByVal Hasta As Date)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "INICIO IMPRIMIR INFORMACION MOVIMIENTOS")
        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadMovimientos2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Desde", SqlDbType.Date, Desde)
            Crear_ParametroSQL(Cmd, "@Hasta", SqlDbType.Date, Hasta)
            Dim dt_Detalle As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Detalle Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "ERROR IMPRIMIR INFORMACION MOVIMIENTOS, dt_Detalle Is Nothing")
                Call fn_MsgBox(" Error al Imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_Detalle.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "FIN IMPRIMIR INFORMACION MOVIMIENTOS, dt_Detalle.Rows.Count = 0")
                Call fn_MsgBox("No encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If
            '---------Llenamos Totales de Cargos y Abonos------------
            'Dim ImporteDep As Integer = 0, ImporteRet As Integer = 0
            'For Each Row As DataRow In dt_Detalle.Rows
            '    ImporteDep += Row("Deposito")
            '    ImporteRet += Row("Retiro")
            'Next
            '------------------

            '-----Los totales deben ser decimales JAVIER ZAPATA 15/03/2019-----------
            Dim ImporteDep As Decimal = dt_Detalle.Compute("SUM(Deposito)", "")
            Dim ImporteRet As Decimal = dt_Detalle.Compute("SUM(Retiro)", "")
            Cmd.Dispose()
            Cnn.Dispose()

            Dim dt_General As DataTable = New DataTable
            dt_General.Columns.Add("FechaInicio")
            dt_General.Columns.Add("FechaFin")
            dt_General.Columns.Add("ImporteDepositos")
            dt_General.Columns.Add("ImporteRetiros")

            'Agregar la información al dt_General 
            dt_General.Rows.Add(Format(Desde, "dd/MM/yyyy"), Format(Hasta, "dd/MM/yyyy"), ImporteDep, ImporteRet)

            If dt_General Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "ERROR IMPRIMIR INFORMACION MOVIMIENTOS, dt_General Is Nothing")
                Call fn_MsgBox(" Error al Imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_General.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "Fin IMPRIMIR INFORMACION MOVIMIENTOS, dt_General.Rows.Count = 0")
                Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '------impresion de ticket windows Normal y Embebido
            Select Case varPub.Tipo_Windows

                Case TipoWindows.Normal

                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon
                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_Detalle = dt_Detalle
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Movimientos
                            End With

                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows
                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm

                                    Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo2
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Detalle = dt_Detalle
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Movimientos
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Detalle = dt_Detalle
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Movimientos
                                    End With
                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)
                            End Select
                    End Select


                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_Detalle = dt_Detalle
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Movimientos
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_Detalle = dt_Detalle
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Movimientos
                            End With
                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select

            End Select
            '--------------------------------------
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "Fin IMPRIMIR INFORMACION MOVIMIENTOS BD_SDF")

        Catch ex As Exception
            'fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 28)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE MOVIMIENTOS", "Error IMPRIMIR INFORMACION MOVIMIENTOS: " & ex.Message)
            Call fn_MsgBox("Error al intentar imprimir los Movimientos.", MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Recolección, Antes era 'Retiros' "

    ''' <summary>
    ''' Llenar la Lista Desplegable de los Casets
    ''' </summary>
    ''' <param name="cmb">Lista Desplegable que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Retiros_LlenarCombo(ByRef cmb As ComboBox, ByVal IdCaset As Integer, Optional ByVal IdCaset_2 As Integer = 0)
        Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "INICIO - LLENAR COMBO CASETS")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read7", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Caset1", SqlDbType.Int, IdCaset)
            Crear_ParametroSQL(Cmd, "@Id_Caset2", SqlDbType.Int, IdCaset_2)


            Dim dt_Casets As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd.Dispose()
            Cnn.Dispose()

            Dim dr As DataRow = dt_Casets.NewRow
            dr("Id_Caset") = 0
            dr("Clave_Caset") = "(Caset)..."
            dt_Casets.Rows.InsertAt(dr, 0)

            cmb.ValueMember = "Id_Caset"
            cmb.DisplayMember = "Clave_Caset"
            cmb.DataSource = dt_Casets

            If cmb.Items.Count > 1 Then
                cmb.SelectedValue = dt_Casets.Rows(1)("Id_Caset")
            End If

            'Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - COMBO CASETS CARGADO CORRECTAMENTE.")
        Catch ex As Exception
            cmb.DataSource = Nothing
            Dim dt As DataTable = New DataTable
            dt.Columns.Add("Id_Caset")
            dt.Columns.Add("Clave_Caset")
            dt.Rows.Add(0, "(Caset Nuevo)...")
            cmb.ValueMember = "Id_Caset"
            cmb.DisplayMember = "Clave_Caset"
            cmb.DataSource = dt

            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 29, varPub.IdPantalla, "RECOLECTAR -" + "FIN - ERROR AL CARGAR COMBO CASETS. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - ERROR AL CARGAR COMBO CASETS. " & ex.Message.ToUpper)
            Call fn_MsgBox("error al Intentar Llenar la Lista Desplegable de Casets.", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Consulta para saber cuanto saldo hay en el caset N (modif 28/10/2015)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function fn_Retiros_LlenarXcaset(ByVal SerieCaset As String) As DataTable
        'Call fn_EscribirLog(varPub.UsuarioClave, "", "Inicio CONSULTA PARA RETIRO")
        Dim dt_Detalle As DataTable = Nothing
        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            ' Esta consulta es por Casetero se cambio a com oestaba antes 29/09/2016

            Dim cmd As SqlCommand = Crear_ComandoSQL("Depositos_SaldoCaset", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
            dt_Detalle = Ejecutar_ConsultaSQL(cmd)

            cmd.Dispose()
            Cnn.Dispose()

            If dt_Detalle Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS", "Error CONSULTA PARA RETIRO: Error en consultar en la BD_TXT")
                'Call fn_MsgBox(" Error al Consultar los Depósitos para Retirar.", MessageBoxIcon.Error)
            End If


            'Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS", "Fin CONSULTA PARA RETIRO BD_SDF")

            Return dt_Detalle
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 30, varPub.IdPantalla, "RETIROS-" + " Error CONSULTA PARA RETIRO: " & ex.Message)
            Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS", "Error CONSULTA PARA RETIRO: " & ex.Message)
            Call fn_MsgBox("Error al Consultar los Depósitos para Retirar.", MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Realizar el Retiro de la Cantidad Mostrada
    ''' </summary>
    ''' <param name="Remision">Número de Remisón utilizado para llevarse el Dinero</param>
    ''' <param name="CasetNuevo">Clave de Caset que reemplazará al Anterior</param>
    ''' <param name="NumeroEnvase">Número de Envase utilizado para llevarse el Dinero</param>
    ''' <param name="Observaciones">Observaciones del Retiro</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Recoleccion_Recolectar(ByVal Importe_Total As Decimal, ByVal Total_MXP As Decimal, ByVal Total_USD As Decimal,
                                             ByVal TotalUSD_Convert As Decimal, ByVal Remision As String, ByVal ImporteManual As Decimal, ByVal ImporteManuald As Decimal, ByVal NumeroEnvase As String,
                                             ByVal CasetNuevo As Integer, ByVal CasetNuevo2 As Integer, ByVal Observaciones As String) As Byte
        Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "INICIO - RECOLECCION")

        If Remision.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - REMISION NO CAPTURADA.")
            Return 1
        End If
        'Se valida la remision solo en RD
        If varPub.Urd AndAlso Not varPub.Remision_Valida Then
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NUMERO DE REMISION NO VALIDADO.")
            Return 1
        End If
        If NumeroEnvase = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NUMERO DE ENVASE NO CAPTURADO.")
            Return 10
        End If
        'Se valida el envase solo en RD
        If varPub.Urd AndAlso Not varPub.Envase_Valido Then
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NUMERO DE ENVASE NO VALIDADO.")
            Return 12
        End If

        Dim rRemision As Double
        If Not Double.TryParse(Remision, rRemision) Then
            'Funcion para MONITOREO DE ERRORES
            'fn_AddLog(varPub.Id_Caje, varPub.Cve_Sucursal, 13)

            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - REMISION INCORRECTA: " & Remision)
            Call fn_MsgBox("Remisión incorrecta, verifique por favor.", MessageBoxIcon.Exclamation)
            Return 1
        End If

        If CasetNuevo = 0 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - CASET 1 NO CAPTURADO.")
            Call fn_MsgBox("Seleccione el Caset Nuevo.", MessageBoxIcon.Exclamation)
            Return 2
        End If

        If varPub.Cant_Validadores = 2 Then
            If CasetNuevo2 = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - CASET 2 NO CAPTURADO.")
                Call fn_MsgBox("Seleccione el Caset Nuevo No. 2.", MessageBoxIcon.Exclamation)
                Return 2
            End If

            If CasetNuevo = CasetNuevo2 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - LOS CASETS SON IGUALES.")
                Call fn_MsgBox("Seleccione un Caset Diferente al otro Caset.", MessageBoxIcon.Exclamation)
                Return 2
            End If
        End If
        'Pide la firma solo si no se trabaja con remision digital
        If varPub.Urd = False Then
            Dim frm As New frm_FirmaElectronica
            frm.lbl_AlertaApagar.Visible = True
            frm.lbl_AlertaApagar.Text = "Firma para Recolección"
            frm.ShowDialog()

            If frm.DialogResult = DialogResult.Cancel Then
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - SE CANCELO LA RECOLECCIÓN.")
                ' Call fn_MsgBox("Se Canceló el proceso de Retiro.", MessageBoxIcon.Information)
                Return 3
            ElseIf frm.DialogResult = DialogResult.Abort Then
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - USUARIO NO VÁLIDO.")
                ' Call fn_MsgBox("Usuario no Válido.", MessageBoxIcon.Information)
                Return 3
            End If

            If frm.tbx_Clave.Text <> varPub.UsuarioClave Then
                Return 11
            End If
        End If
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand
        Dim dt_Desglosee As DataTable
        Dim dt_Desglose As DataTable
        Dim dt_Desglose2 As DataTable
        Try
            'Insertar en Retiros
            varPub.Hora_Inicio = Hora 'hora del retiro(parametro BDD web)

            'Como si hay depositos se prosigue a Insertar en Retiros
            Dim ImporteTotalLetras As String = fn_ConvertNumeroALetras(Importe_Total, "MXN")

            ' en sql compact 4.0 no se debe enviar Null como valor en campos nulos
            'Nota 20/08/2020 Se agrega "Id_Cajero" como parametro en el procedimiento.
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Retiros_Insert")
            Crear_ParametroSQL(Cmd, "@Id_Cajero", SqlDbType.VarChar, varPub.Id_Caje)            '08/08/2020
            Crear_ParametroSQL(Cmd, "@Importe_Total", SqlDbType.Money, Importe_Total)
            Crear_ParametroSQL(Cmd, "@Total_MXP", SqlDbType.Money, Total_MXP)
            Crear_ParametroSQL(Cmd, "@Total_USD", SqlDbType.Money, Total_USD)
            Crear_ParametroSQL(Cmd, "@TotalUSD_Convert", SqlDbType.Money, TotalUSD_Convert)
            Crear_ParametroSQL(Cmd, "@ImporteTotalLetras", SqlDbType.VarChar, ImporteTotalLetras)
            Crear_ParametroSQL(Cmd, "@Remision", SqlDbType.VarChar, Remision)
            Crear_ParametroSQL(Cmd, "@Numero_Envase", SqlDbType.VarChar, NumeroEnvase)
            Crear_ParametroSQL(Cmd, "@Observaciones", SqlDbType.VarChar, Observaciones)
            Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, varPub.UsuarioClave)
            Crear_ParametroSQL(Cmd, "@Importe_Manual", SqlDbType.Money, ImporteManual)
            Crear_ParametroSQL(Cmd, "@Importe_ManualD", SqlDbType.Money, ImporteManuald)


            Dim Id_Retiro As Integer = Ejecutar_ScalarTSQL(Cmd)

            If Id_Retiro = 0 Then
                tr.Rollback()
                Cmd.Dispose()
                Cnn.Dispose()
                'Funcion para MONITOREO DE ERRORES
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 4, varPub.IdPantalla, "RECOLECTAR - " + "FIN - NO SE OBTUVO EL IDENTITY DEL ULTIMO RETIRO.")

                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NO SE OBTUVO EL IDENTITY DEL ULTIMO RETIRO.")
                Call fn_MsgBox("error al intentar realizar el Retiro.", MessageBoxIcon.Error)

                Return 4
            End If

            'Consultar el Detalle que se Retirará y se pasará a RetirosD

            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_ReadDetalle")
            dt_Desglosee = Ejecutar_ConsultaTSQL(Cmd)

            If dt_Desglosee Is Nothing Then
                tr.Rollback()
                Cmd.Dispose()
                Cnn.Dispose()

                'Funcion para MONITOREO DE ERRORES
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 5, varPub.IdPantalla, "RECOLECTAR - " + "FIN - ERROR AL OBTENER EL DESGLOSE A INSERTAR EN DETALLE RETIROS.")

                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - OCURRIÓ UN ERROR AL OBTENER EL DESGLOSE A INSERTAR EN DETALLE RETIROS.")
                Call fn_MsgBox("error al intentar realizar el Retiro.", MessageBoxIcon.Error)
                Return 4
            End If

            'Consultar el Detalle que se Retirará y se pasará a RetirosD}


            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_ReadCorte6")
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val1)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 0)
            dt_Desglose = Ejecutar_ConsultaTSQL(Cmd)

            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_ReadCorte6")
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val2)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 0)
            dt_Desglose2 = Ejecutar_ConsultaTSQL(Cmd)


            'Guardar la Información en RetiroD

            For Each Row As DataRow In dt_Desglosee.Rows

                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "RetirosD_Insert")
                Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
                Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, Row("Clave"))
                Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Int, Row("Denominacion"))
                Crear_ParametroSQL(Cmd, "@Cantidad_ClaveDenom", SqlDbType.VarChar, Row("Cantidad"))
                Crear_ParametroSQL(Cmd, "@Suma_Denominacion", SqlDbType.Int, Row("Importe"))

                If Ejecutar_NonQueryTSQL(Cmd) = 0 Then
                    tr.Rollback()
                    Cmd.Dispose()
                    Cnn.Dispose()

                    'Funcion para MONITOREO DE ERRORES
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 8, varPub.IdPantalla, "RECOLECTAR - " + "FIN - NO SE PUDO INSERTAR EL DETALLE EN RETIROS.")

                    Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NO SE PUDO INSERTAR EL DETALLE EN RETIROS.")
                    Call fn_MsgBox("error al intentar realizar el Retiro.", MessageBoxIcon.Information)
                    Return 4
                End If
            Next

            'ACTUALIZAR DEPOSITOS AGREGANDO EL ID_RETIRO Y CAMBIANDO SU STATUS
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_Update")
            Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)

            If Ejecutar_NonQueryTSQL(Cmd) <= 0 Then
                tr.Rollback() 'Rehacer transaccion
                Cmd.Dispose()
                Cnn.Dispose()

                'Funcion para MONITOREO DE ERRORES
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 6, varPub.IdPantalla, "RECOLECTAR - " + " ERROR AL ACTUALIZAR LA TABLA DEPOSITOS CON EL ID_RETIRO.")

                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", " ERROR AL ACTUALIZAR LA TABLA DEPOSITOS CON EL ID_RETIRO.")
                Call fn_MsgBox("error al intentar realizar el Retiro.", MessageBoxIcon.Error)
                Return 4
            End If

            'Aqui guardamos el Ultimo Retiro
            varPub.ID_UltimoRetiro = Id_Retiro
            'Se guarda en SIAC los datos de la recoleccion [RD]
            If varPub.Urd AndAlso varPub.Id_punto <> 0 Then
                Dim WsCajero As New WsRemision.WsCashFlowSoapClient
                If WsCajero.SetData(varPub.Cve_Cliente.ToString + "  %" + Importe_Total.ToString + "%" + NumeroEnvase.ToString + "%" + varPub.Id_punto.ToString() + "%" + varPub.RemisionWs + "%" + varPub.Plaza) = False Then
                    tr.Rollback()
                    Return 5
                End If
            End If
            tr.Commit()
            tr.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - LA RECOLECCION SE REALIZO CORRECTAMENTE.")

            '------------------------

            If varPub.Capacidad_Actual = varPub.Capacidad_Caset Then ' válida si capasidad caset llego al máximo
                varPub.CajeroStatus = "D"                             ' actualiza la varpub.StatusCajero tras realizar una recolección para que el cajero este listo para nuevos depositos por webservice.  
            End If

            varPub.Capacidad_Actual = 0 ' 27/junio/2013
            varPub.CasetID = CasetNuevo
            If varPub.Cant_Validadores = 2 Then
                If varPub.Capacidad_Actual2 = varPub.Capacidad_Caset2 Then  ' válida si capasidad caset llego al máximo
                    varPub.CajeroStatus = "D"                               ' actualiza la varpub.StatusCajero tras realizar una recolección para que el cajero este listo para nuevos depositos por webservice.  
                End If
                varPub.Capacidad_Actual2 = 0
                varPub.Caset2ID = CasetNuevo2
                Dim dt_Valorescaset2 As DataTable = fn_CasetsValores(varPub.Caset2ID)
                If dt_Valorescaset2 IsNot Nothing AndAlso dt_Valorescaset2.Rows.Count > 0 Then
                    varPub.Capacidad_Caset2 = dt_Valorescaset2.Rows(0)("Capacidad")
                    varPub.Porcentaje_Alerta2 = dt_Valorescaset2.Rows(0)("Porcentaje_Alerta")
                    varPub.Serie_Caset2 = dt_Valorescaset2.Rows(0)("Serie_Caset")
                End If
            End If

            Dim dt_Valorescaset As DataTable = fn_CasetsValores(varPub.CasetID)
            If dt_Valorescaset IsNot Nothing AndAlso dt_Valorescaset.Rows.Count > 0 Then
                varPub.Capacidad_Caset = dt_Valorescaset.Rows(0)("Capacidad")
                varPub.Porcentaje_Alerta = dt_Valorescaset.Rows(0)("Porcentaje_Alerta")
                varPub.Serie_Caset1 = dt_Valorescaset.Rows(0)("Serie_Caset")
            End If

            Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
            If Persistente.Existe Then
                Persistente.Persistir()
                Persistente.Cargar()
            End If

        Catch ex As Exception
            'tr.Rollback()

            'Funcion para MONITOREO DE ERRORES
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 7, varPub.IdPantalla, "RECOLECTAR - " + " FIN - ERROR AL RECOLECTAR." & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", " FIN - ERROR AL RECOLECTAR." & ex.Message.ToUpper)
            Call fn_MsgBox("error al intentar realizar el Retiro.", MessageBoxIcon.Error)
            Return 4
        End Try
        '-----------------------fin try catch con transaccion

        Cnn = Nothing
        Cnn = Crear_ConexionSQL(_Cnx)

        ' **** INICIAR PROCESO DE IMPRESIÓN DE TICKETS ****
        Try
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "INCIO - IMPRIMIR INFORMACIÓN DE RECOLECCIÓN.")
            'Agrupar los importes depositados por Dia 06/11/2015
            'Nota: Se utilizan los importes del deposito, Porque  ya contiene sumados los dlls convertidos a peso

            Cmd = Crear_ComandoSQL("Depositos_ReadRetiro", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@IdUltRetiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
            Dim dt_detalleAgrupado As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_detalleAgrupado Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 9, varPub.IdPantalla, "RECOLECTAR - " + "FIN - ERROR AL AGRUPAR DEPÓSITOS.")
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - ERROR AL AGRUPAR DEPÓSITOS.")
                Return 8
            ElseIf dt_detalleAgrupado.Rows.Count = 0 Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 10, varPub.IdPantalla, "RECOLECTAR - " + "FIN - NO SE ENCONTRO INFORMACION PARA IMPRIMIR.")
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NO SE ENCONTRO INFORMACION PARA IMPRIMIR.")
                Return 8
            End If

            'Consultas para la Información General que se va imprimir

            Cmd = Crear_ComandoSQL("Retiros_Read3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_UltRetiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
            Dim dt_General As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Cmd.Dispose()
            Cnn.Dispose()

            If dt_General Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 11, varPub.IdPantalla, "RECOLECTAR - " + " FIN -  ERROR AL CONSULTAR DATOS GENERALES.")
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", " FIN -  ERROR AL CONSULTAR DATOS GENERALES.")
                Return 9
            ElseIf dt_General.Rows.Count = 0 Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 10, varPub.IdPantalla, "RECOLECTAR - " + "FIN - NO SE ENCONTRO INFORMACION PARA IMPRIMIR.")
                Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - NO SE ENCONTRO INFORMACION PARA IMPRIMIR.")
                Return 9
            End If

            '------Impresion de ticket windows Normal y Embebido
            varPub.SegundosSesion = 0

            For i As Byte = 1 To varPub.Num_CopiasImprimir + 2
                varPub.SegundosSesion = 0

                Select Case varPub.Tipo_Windows
                    Case TipoWindows.Normal

                        Select Case varPub.Modo_Impresion
                            Case ModoImpresion.Nippon
                                Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                                With Recibo2
                                    .dr_General = dt_General.Rows(0)
                                    .dt_DetalleAgrupado = dt_detalleAgrupado
                                    .dt_Desglose = dt_Desglose
                                    .dt_Desglose2 = dt_Desglose2
                                    .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion
                                End With
                                Dim imprNew As New cls_NPIticket80mmWinNormal
                                imprNew.Imprimir(Recibo2)

                            Case ModoImpresion.Windows

                                Select Case varPub.Tamaño_Papel
                                    Case TamañoPapel._80mm
                                        Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                        With Recibo2
                                            .dr_General = dt_General.Rows(0)
                                            .dt_DetalleAgrupado = dt_detalleAgrupado
                                            .dt_Desglose = dt_Desglosee
                                            .dt_Desglose2 = dt_Desglose2
                                            .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Recoleccion
                                        End With
                                        cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                    Case TamañoPapel._58mm
                                        Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                        With Recibo
                                            .dr_General = dt_General.Rows(0)
                                            .dt_DetalleAgrupado = dt_detalleAgrupado
                                            .dt_Desglose = dt_Desglosee
                                            .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Recoleccion
                                        End With
                                        cls_Ticket58mmWinNormal.Imprimir(Recibo)
                                End Select

                        End Select

                    Case TipoWindows.Embebido

                        Select Case varPub.Tamaño_Papel
                            Case TamañoPapel._80mm
                                Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                                With Recibo4
                                    .dr_General = dt_General.Rows(0)
                                    .dt_DetalleAgrupado = dt_detalleAgrupado
                                    .dt_Desglose = dt_Desglosee
                                    .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Recoleccion
                                End With
                                cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                            Case TamañoPapel._58mm
                                Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                                With Recibo3
                                    .dr_General = dt_General.Rows(0)
                                    .dt_DetalleAgrupado = dt_detalleAgrupado
                                    .dt_Desglose = dt_Desglosee
                                    .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Recoleccion
                                End With
                                cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                        End Select
                End Select
            Next
            '--------------------------------------
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", "FIN - LA IMPRESION DE RECOLECCIÓN SE REALIZÓ CORRECTAMENTE.")

            '-----Valida conectiviad y almacena en la BDD web

            '-------------- COMENTARIZADO POR BJSE Y JMCB 2021 PARA QUE SOLO SINCRONICE VIA AL TERMINAR TIMER, BOTON SINCRONIZAR Y AL CERRAR SESIÓN.

            'If (varPub.ConexionwebAdmin = 1) Then
            '    If fn_VerificaConexionInternet() Then

            '        'FUNCION ANTERIOR
            '        'Call fn_SincronizaDepositos_aWEB()

            '        'FUNCION DEPOSITOS NUEVA BJSE 2021
            '        'Call fn_SincronizaDepositos_aWEBWs()

            '        fn_SincronizarDepositosWebServices()

            '        'FUNCION ANTERIOR
            '        'Call fn_SincronizaRetiros_aWEB()

            '        'FUNCION NUEVA RETIROS BJSE 2021
            '        fn_SincronizaRetiros_WebWs()

            '        Call fn_SincronizaCorte_aWEB()
            '        Call fn_SincronizaUltimaConexion()
            '    End If
            'End If
            '----------COMENTARIZADO POR BJSE JMB 2021
            '--------------

            Return 0
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 12, varPub.IdPantalla, "RECOLECTAR - " + " FIN - ERROR AL IMPRIMIR INFORMACIÓN  DE RECOLECCIÓN." & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "RECOLECTAR", " FIN - ERROR AL IMPRIMIR INFORMACIÓN  DE RECOLECCIÓN." & ex.Message.ToUpper)
            Return 9
        End Try

    End Function

#End Region

#Region "Consulta de Retiros"

    ''' <summary>
    ''' Llenar la Lista Desplegable de los Usuarios
    ''' </summary>
    ''' <param name="cmb">Lista Desplegable que se Llenará con la Información</param>
    ''' <remarks></remarks>
    ''' 

    Public Shared Sub fn_ConsultaRetiros_LlenarCombo(ByRef cmb As ComboBox)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCION", "INICIO - CONSULTA RECOLECCION COMBO USUARIOS")

        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(cmd)
            Dim dr As DataRow = dt_Usuarios.NewRow
            dr("Clave_Usuario") = 0
            dr("Nombre_Usuario") = ""
            dr("Nombre_Corto") = "(Usuarios)..."
            dt_Usuarios.Rows.InsertAt(dr, 0)

            cmb.ValueMember = "Clave_Usuario"
            cmb.DisplayMember = "Nombre_Corto"
            cmb.DataSource = dt_Usuarios

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCION", "FIN - RECOLECCION CONSULTA COMBO USUARIOS BD_SDF")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 31, varPub.IdPantalla, "CONSULTA RECOLECCION - " + "FIN - ERROR EN CONSULTA RECOLECCIÓN COMBO USUARIOS: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCION", "FIN - ERROR EN CONSULTA RECOLECCIÓN COMBO USUARIOS: " & ex.Message.ToUpper)
            Call fn_MsgBox("error al intentar llenar la Lista Desplegable de Usuarios.", MessageBoxIcon.Error)
        End Try


    End Sub

    ''' <summary>
    ''' Llenar la Lista con los Retiros Realizados
    ''' </summary>
    ''' <param name="Desde">Fecha Inicial</param>
    ''' <param name="Hasta">Fecha Final</param>
    ''' <param name="Usuario_Clave">Clave del Usuario a Consultar</param>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    ''' 

    Public Shared Sub fn_ConsultaRetiros_Llenar(ByVal Desde As Date, ByVal Hasta As Date, ByVal Usuario_Clave As Integer, ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "INICIO - CONSULTA RECOLECCIÓN.")

        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Retiros_Read2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Desde", SqlDbType.Date, Desde)
            Crear_ParametroSQL(Cmd, "@Hasta", SqlDbType.Date, Hasta)
            Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, Usuario_Clave)

            Dim dt_Retiros As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Cmd.Dispose()
            Cnn.Dispose()
            If dt_Retiros.Rows.Count > 0 Then
                Call fn_LlenarListView(dt_Retiros, lsv, "Id_Retiro", "", True)
                lsv.Columns(6).Width = 0
                lsv.Columns(9).Width = 0
            End If
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN - CONSULTA CORRECTA EN BD_SDF")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 32, varPub.IdPantalla, "CONSULTA DE RECOLECCION - " + "FIN - ERROR AL CONSULTAR RECOLECCION. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN -  ERROR AL CONSULTAR RECOLECCION. " & ex.Message.ToUpper)
            Call fn_MsgBox("error al intentar llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    '''  'Reimprime el ticket de Retiros
    ''' </summary>
    ''' <param name="Id_Retiro"></param>
    ''' <remarks></remarks>
    ''' 
    Public Shared Sub fn_ConsultaRetiros_Reimprimir(ByVal Id_Retiro As Integer)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RETIROS", "INICIO - DE REIMPRESION DE RECOLECCION.")

        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Retiros_Read", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_UltRetiro", SqlDbType.Int, Id_Retiro)
            Dim dt_General As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_General Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 33, varPub.IdPantalla, "CONSULTA DE RECOLECCION - " + "FIN - ERROR AL OBTENER DATOS GENERALES PARA REIMPRESION DE LA RECOLECCION.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN - ERROR AL OBTENER DATOS GENERALES PARA REIMPRESION DE LA RECOLECCION.")
                Exit Sub
            End If
            'cnn = Crear_ConexionSQLCE(varPub.cnx_Local)
            'Query = "Select r.Id_Retiro As Folio, " & _
            '               "r.Importe_Otros, " & _
            '                "r.Numero_Remision As Remision, " & _
            '                "r.Numero_Envase As Envase, " & _
            '                "Convert(nvarchar(10),r.Fecha_Registro,103) As Fecha, " & _
            '                "Convert(nvarchar(10),r.Fecha_Registro,108) As Hora, " & _
            '                "u.Nombre_Usuario " & _
            '                "From Retiros As r " & _
            '               "Join Usuarios As u On u.Clave_Usuario = r.Usuario_Registro " & _
            '                "Where r.Id_Retiro = " & Id_Retiro & ""
            'cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
            'Dim dt_Efectivo As DataTable = Ejecutar_ConsultaSQLCE(cmd)

            'If dt_Efectivo Is Nothing Then
            '    Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCION", "FIN - ERROR AL OBTENER DATOS GENERALES PARA REIMPRESIÓN DE LA RECOLECCIÓN.")
            '    Exit Sub
            'End If


            '----llenar el detalle del Retiro aReimprimir

            Cmd = Crear_ComandoSQL("Depositos_ReadRetiro2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
            Dim dt_Desglosee As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Desglosee Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 58, varPub.IdPantalla, "CONSULTA DE RECOLECCION - " + "FIN - ERROR AL CONSULTAR DESGLOSE.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN - ERROR AL CONSULTAR DESGLOSE.")
                Exit Sub
            End If
            'Consultar el Detalle que se Retirará y se pasará a RetirosD

            Cmd = Crear_ComandoSQL("Depositos_ReadValidador", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val1)
            Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
            Dim dt_Desglose As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd = Crear_ComandoSQL("Depositos_ReadValidador", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Serie_Validador", SqlDbType.VarChar, varPub.Serie_Val2)
            Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, Id_Retiro)
            Dim dt_Desglose2 As DataTable = Ejecutar_ConsultaSQL(Cmd)

            'Nota: Se utilizan los importes del deposito, Porque  ya contiene sumados los dlls convertidos a peso

            Cmd = Crear_ComandoSQL("Depositos_ReadRetiro3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_UltRetiro", SqlDbType.Int, Id_Retiro)
            Dim dt_detalleAgrupado As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_detalleAgrupado Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 59, varPub.IdPantalla, "CONSULTA DE RECOLECCION - " + "FIN - ERROR AL AGRUPAR EL DETALLE PARA LA REIMPRESION DE LA RECOLECCION.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN - ERROR AL AGRUPAR EL DETALLE PARA LA REIMPRESION DE LA RECOLECCION.")
                Exit Sub
            End If

            Cmd.Dispose()
            Cnn.Dispose()

            '------Reimpresion de ticket windows Normal y Embebido
            Select Case varPub.Tipo_Windows

                Case TipoWindows.Normal

                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon
                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_DetalleAgrupado = dt_detalleAgrupado
                                .dt_Desglose = dt_Desglose
                                .dt_Desglose2 = dt_Desglose2
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion
                            End With
                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows

                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm
                                    Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo2
                                        .dr_General = dt_General.Rows(0)
                                        .dt_DetalleAgrupado = dt_detalleAgrupado
                                        .dt_Desglose = dt_Desglose
                                        .dt_Desglose2 = dt_Desglose2
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Recoleccion
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dr_General = dt_General.Rows(0)
                                        .dt_DetalleAgrupado = dt_detalleAgrupado
                                        .dt_Desglose = dt_Desglose
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Recoleccion
                                    End With
                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)

                            End Select
                    End Select

                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_DetalleAgrupado = dt_detalleAgrupado
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Recoleccion
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)
                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_DetalleAgrupado = dt_detalleAgrupado
                                .dt_Desglose = dt_Desglose
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Recoleccion
                            End With
                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select

            End Select
            '--------------------------------------

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN - REIMPRESION REALIZADA CORRECTAMENTE.")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 33, varPub.IdPantalla, "CONSULTA DE RECOLECCION" + "FIN - ERROR EN REIMPRESION DE RECOLECCION. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE RECOLECCION", "FIN - ERROR EN REIMPRESION DE RECOLECCION. " & ex.Message.ToUpper)
            Call fn_MsgBox("Ocurrió un Error al intentar reimprimir el Retiro Seleccionado.", MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Consulta de Detalle de Retiros"

    ''' <summary>
    ''' Llenar la Lista con el Detalle de Retiros Realizados
    ''' </summary>
    ''' <param name="Id_Retiro">Depósito que se Desglozará</param>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaRetirosD_Llenar(ByVal Id_Retiro As Integer, ByRef lsv As ListView, ByRef SubtotalDepositos As Decimal)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCIOND", "INICIO - CONSULTA RECOLECCION DETALLE")
        SubtotalDepositos = 0
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadRetiro4", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_UltRetiro", SqlDbType.Int, Id_Retiro)
            Dim dt_DepositosD As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_DepositosD IsNot Nothing Then
                For Each Fila As DataRow In dt_DepositosD.Rows
                    If Fila("Tipo") = 1 Then
                        SubtotalDepositos += Fila("Importe")
                    End If

                Next
            End If

            Cmd.Dispose()
            Cnn.Dispose()

            Call fn_LlenarListView(dt_DepositosD, lsv, "", "")
            lsv.Columns(4).Width = 0
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RETIROSD", "FIN - CONSULTA RECOLECCIOND REALIZADO CORRECTAMENTE.")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 34, varPub.IdPantalla, "CONSULTA RECOLECCIOND " + "FIN - ERROR CONSULTA RECOLECCION DETALLE. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCIOND", "FIN - ERROR CONSULTA RECOLECCION DETALLE. " & ex.Message.ToUpper)            'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA RECOLECCIOND", "FIN - ERROR CONSULTA RECOLECCION DETALLE. " & ex.Message.ToUpper)
            Call fn_MsgBox("Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Corte Diario"

    Public Shared Sub fn_CortePorDiario_Imprimir(ByVal TipoCorteDiario As Byte)

        Call fn_EscribirLog(varPub.UsuarioClave, "Corte Diario", "INICIO - DE IMPRESION CORTE DIARIO.")
        Dim Id_Corte As Integer = 0
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            '--------Obtener el Detalle

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadCorte", CommandType.Text, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Corte", SqlDbType.Int, Id_Corte)
            Dim dt_Detalle As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Detalle Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 35, varPub.IdPantalla, "CORTE DIARIO - " + "FIN - ERROR AL IMPRIMIR CORTE DIARIO, dt_Detalle Is Nothing")
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - ERROR AL IMPRIMIR CORTE DIARIO, dt_Detalle Is Nothing")
                Call fn_MsgBox("Error al Imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_Detalle.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - NO HAY REGISTROS PARA IMPRIMIR.")
                Call fn_MsgBox("No encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If

            '------impresion de ticket windows Normal y Embebido
            Select Case varPub.Tipo_Windows

                Case TipoWindows.Normal

                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon
                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dt_Detalle = dt_Detalle
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Corte_Diario
                            End With
                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows
                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm
                                    Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo2
                                        .dt_Detalle = dt_Detalle
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Corte_Diario
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dt_Detalle = dt_Detalle
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Corte_Diario
                                    End With

                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)
                            End Select
                    End Select

                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dt_Detalle = dt_Detalle
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Corte_Diario
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dt_Detalle = dt_Detalle
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Corte_Diario
                            End With

                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select

            End Select

            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - IMPRESION CORTE DIARIO")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 35, varPub.IdPantalla, "CORTE DIARIO - " + "FIN - ERROR EN IMPRESIÓN DE CORTE DIARIO. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - ERROR EN IMPRESIÓN DE CORTE DIARIO. " & ex.Message.ToUpper)
            Call fn_MsgBox("Error al Intentar Imprimir Corte Diario.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub fn_CorteDiario_Imprimir(ByVal TipoCorteDiario As Byte)
        Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "INICIO - DE IMPRESION CORTE DIARIO.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            '1= Todos los Depositos 'F' desde ultimo Retiro
            '2= Todos los depositos 'F' del dia actual
            '3= Todos los depositos 'F' ó 'R' del dia actual

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_ReadCorte2", CommandType.StoredProcedure, Cnn)

            'Dim diaActual As String = " CONVERT(nvarchar(10), d.Fecha_Inicio, 102) = '" & Format(Now, "yyyy.MM.dd") & "' "
            varPub.Tipo_CorteDiario = TipoCorteDiario ' para imprimir segun el tipo
            Select Case TipoCorteDiario
                Case 1
                    'diaActual = "d.Status = 'F'"
                    Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "F")
                    Crear_ParametroSQL(Cmd, "@Fecha_Actual", SqlDbType.VarChar, "0")
                Case 2
                    'diaActual = "d.Status = 'F' And " & diaActual
                    Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "F")
                    Crear_ParametroSQL(Cmd, "@Fecha_Actual", SqlDbType.VarChar, CStr(Format(Now, "yyyy.MM.dd")))
                Case 3
                    'diaActual = "(d.Status = 'F' Or d.Status ='R') And " & diaActual
                    Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "R")
                    Crear_ParametroSQL(Cmd, "@Fecha_Actual", SqlDbType.VarChar, CStr(Format(Now, "yyyy.MM.dd")))
            End Select


            Dim dt_Detalle As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Detalle Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 35, varPub.IdPantalla, "CORTE DIARIO - " + "FIN - ERROR AL IMPRIMIR CORTE DIARIO, dt_Detalle Is Nothing")
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - ERROR AL IMPRIMIR CORTE DIARIO, dt_Detalle Is Nothing")
                Call fn_MsgBox("error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_Detalle.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - NO HAY REGISTROS PARA IMPRIMIR.")
                Call fn_MsgBox("No encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If

            Cmd = Crear_ComandoSQL("Depositos_ReadCorte3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Fecha_Actual", SqlDbType.VarChar, CStr(Format(Now, "yyyy.MM.dd")))
            Dim dt_Desglose As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Desglose Is Nothing Then
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 60, varPub.IdPantalla, "CORTE DIARIO - " + "FIN - ERROR AL CONSULTAR DESGLOSE DE CORTE DIARIO.")
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - ERROR AL CONSULTAR DESGLOSE DE CORTE DIARIO.")
                Call fn_MsgBox("error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
                'ElseIf dt_Desglose.Rows.Count = 0 Then
                '    Call fn_EscribirLog(UsuarioClave, "Corte Diario", "Fin IMPRIMIR INFORMACIÓN CORTE DIARIO, dt_Desglose.Rows.Count = 0")
                '    Call fn_MsgBox("No encontró Información para Imprimir.", MessageBoxIcon.Error)
                '    Exit Sub
            End If

            Cmd = Crear_ComandoSQL("Depositos_ReadCorte3", CommandType.Text, Cnn)
            Crear_ParametroSQL(Cmd, "@Fecha_Actual", SqlDbType.VarChar, CStr(Format(Now, "yyyy.MM.dd")))
            Dim dt_DetalleAgrup As DataTable = Ejecutar_ConsultaSQL(Cmd)


            Cmd = Crear_ComandoSQL("Depositos_ReadCorte5", CommandType.StoredProcedure, Cnn)
            Select Case TipoCorteDiario
                Case 1
                    'diaActual = "Status = 'F'"
                    Crear_ParametroSQL(Cmd, "@CorteDiario", SqlDbType.Int, 1)
                    Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
                Case 2
                    'diaActual = "Status = 'F' And " & diaActual
                    Crear_ParametroSQL(Cmd, "@CorteDiario", SqlDbType.Int, 2)
                    Crear_ParametroSQL(Cmd, "@CTipo", SqlDbType.Int, 1)
                Case 3
                    'diaActual = "(Status = 'F' Or Status ='R') And " & diaActual
                    Crear_ParametroSQL(Cmd, "@CorteDiario", SqlDbType.Int, 3)
                    Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 1)
            End Select

            Dim Dt_SaldosValidado As DataTable = Ejecutar_ConsultaSQL(Cmd)


            Cmd = Crear_ComandoSQL("Depositos_ReadCorte5", CommandType.StoredProcedure, Cnn)
            Select Case TipoCorteDiario
                Case 1
                    'diaActual = "Status = 'F'"
                    Crear_ParametroSQL(Cmd, "@CorteDiario", SqlDbType.Int, 1)
                    Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
                Case 2
                    'diaActual = "Status = 'F' And " & diaActual
                    Crear_ParametroSQL(Cmd, "@CorteDiario", SqlDbType.Int, 2)
                    Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
                Case 3
                    'diaActual = "(Status = 'F' Or Status ='R') And " & diaActual
                    Crear_ParametroSQL(Cmd, "@CorteDiario", SqlDbType.Int, 3)
                    Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, 2)
            End Select
            Dim Dt_SaldoManual As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd.Dispose()
            Cnn.Dispose()

            '--------Obtener el Detalle General
            Dim dt_General As DataTable = New DataTable
            dt_General.Columns.Add("Fecha")
            dt_General.Columns.Add("Hora")
            dt_General.Columns.Add("Importe_Total")
            dt_General.Columns.Add("Total_MXP")
            dt_General.Columns.Add("Total_USD")
            dt_General.Columns.Add("TotalUSD_Convert")
            dt_General.Columns.Add("ImporteTotal_Letras")

            Dim SaldoV_ImporteTotal As Decimal = 0D
            Dim SaldoV_MXP As Integer = 0
            Dim SaldoV_USD As Integer = 0
            Dim SaldoV_USDConvert As Decimal = 0D


            Dim SaldoM_ImporteTotal As Decimal = 0D

            If Not IsDBNull(Dt_SaldosValidado.Rows(0)("Importe_Total")) Then
                SaldoV_ImporteTotal = Dt_SaldosValidado.Rows(0)("Importe_Total")
                SaldoV_MXP = Dt_SaldosValidado.Rows(0)("Total_MXP")
                SaldoV_USD = Dt_SaldosValidado.Rows(0)("Total_USD")
                SaldoV_USDConvert = Dt_SaldosValidado.Rows(0)("TotalUSD_Convert")
            End If

            If Not IsDBNull(Dt_SaldoManual.Rows(0)("Importe_Total")) Then
                SaldoM_ImporteTotal = Dt_SaldoManual.Rows(0)("Importe_Total")
            End If

            Dim ImporteTotal As Decimal = SaldoM_ImporteTotal + SaldoV_ImporteTotal

            If ImporteTotal = 0 Then
                Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim ImporteTotalLetras As String = fn_ConvertNumeroALetras(ImporteTotal.ToString, "MXN")

            'Agregar la información al dt_General
            dt_General.Rows.Add(Format(Now, "dd/MM/yyyy"), Hora, ImporteTotal, SaldoV_MXP, SaldoV_USD, SaldoV_USDConvert, ImporteTotalLetras)
            If dt_General Is Nothing Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - IMPRIMIR INFORMACIÓN CORTE DIARIO, dt_General Is Nothing")
                Call fn_MsgBox("Ocurrió un Error al imprimir la Información.", MessageBoxIcon.Error)
                Exit Sub
            ElseIf dt_General.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - IMPRIMIR INFORMACIÓN CORTE DIARIO, dt_General.Rows.Count = 0")
                Call fn_MsgBox("No se encontró Información para Imprimir.", MessageBoxIcon.Error)
                Exit Sub
            End If


            If dt_Detalle.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - IMPRESION CORTE DIARIO NO HUBO REGISTROS QUE IMPRIMIR.")

                Exit Sub
            End If

            '------impresion de ticket windows Normal y Embebido
            Select Case varPub.Tipo_Windows

                Case TipoWindows.Normal

                    Select Case varPub.Modo_Impresion
                        Case ModoImpresion.Nippon
                            Dim Recibo2 As stc_NPI80mmWinNormal = New stc_NPI80mmWinNormal
                            With Recibo2
                                .dr_General = dt_General.Rows(0)
                                .dt_Detalle = dt_Detalle
                                .dt_Desglose = dt_Desglose
                                .dt_DetalleAgrupado = dt_DetalleAgrup
                                .Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Corte_Diario
                            End With
                            Dim newimp As New cls_NPIticket80mmWinNormal
                            newimp.Imprimir(Recibo2)

                        Case ModoImpresion.Windows
                            Select Case varPub.Tamaño_Papel
                                Case TamañoPapel._80mm
                                    Dim Recibo2 As stc_80mmWinNormal = New stc_80mmWinNormal
                                    With Recibo2
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Detalle = dt_Detalle
                                        .dt_Desglose = dt_Desglose
                                        .dt_DetalleAgrupado = dt_DetalleAgrup '----
                                        .Tipo_Impresion = stc_80mmWinNormal.Tipos_Impresion.Corte_Diario
                                    End With
                                    cls_Ticket80mmWinNormal.Imprimir(Recibo2)

                                Case TamañoPapel._58mm
                                    Dim Recibo As stc_58mmWinNormal = New stc_58mmWinNormal
                                    With Recibo
                                        .dr_General = dt_General.Rows(0)
                                        .dt_Detalle = dt_Detalle
                                        .dt_Desglose = dt_Desglose
                                        .dt_DetalleAgrupado = dt_DetalleAgrup '----
                                        .Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Corte_Diario
                                    End With

                                    cls_Ticket58mmWinNormal.Imprimir(Recibo)
                            End Select
                    End Select

                Case TipoWindows.Embebido

                    Select Case varPub.Tamaño_Papel
                        Case TamañoPapel._80mm
                            Dim Recibo4 As stc_80mmWinEmbbd = New stc_80mmWinEmbbd
                            With Recibo4
                                .dr_General = dt_General.Rows(0)
                                .dt_Detalle = dt_Detalle
                                .dt_Desglose = dt_Desglose
                                .dt_DetalleAgrupado = dt_DetalleAgrup '----
                                .Tipo_Impresion = stc_80mmWinEmbbd.Tipos_Impresion.Corte_Diario
                            End With
                            cls_Ticket80mmWinEmbbd.Imprimir(Recibo4)

                        Case TamañoPapel._58mm
                            Dim Recibo3 As stc_58mmWinEmbbd = New stc_58mmWinEmbbd
                            With Recibo3
                                .dr_General = dt_General.Rows(0)
                                .dt_Detalle = dt_Detalle
                                .dt_Desglose = dt_Desglose
                                .dt_DetalleAgrupado = dt_DetalleAgrup '----
                                .Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Corte_Diario
                            End With

                            cls_Ticket58mmWinEmbbd.Imprimir(Recibo3)
                    End Select

            End Select

            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - IMPRESION CORTE DIARIO")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 35, varPub.IdPantalla, "CORTE DIARIO " + "FIN - ERROR EN IMPRESIÓN DE CORTE DIARIO. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE DIARIO", "FIN - ERROR EN IMPRESIÓN DE CORTE DIARIO. " & ex.Message.ToUpper)
            Call fn_MsgBox("error al intentar imprimir Corte Diario.", MessageBoxIcon.Error)
        End Try
    End Sub
    Public Shared Function fn_VerificaCorte() As DataTable
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing
        Try

            'verificar que no este vacia la tabla Corte

            Cmd = Crear_ComandoSQL("Cortes_ReadUltimo", CommandType.StoredProcedure, Cnn)
            dt = Ejecutar_ConsultaSQL(Cmd)

        Catch ex As Exception
            Cmd.Dispose()
            Cnn.Dispose()
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 37, varPub.IdPantalla, "LOGIN - " + "FIN- ERROR AL CONSULTAR CORTE ACTUAL " & ex.Message.ToUpper)
            fn_EscribirLog(varPub.UsuarioClave, "LOGIN", "FIN- ERROR AL CONSULTAR CORTE ACTUAL" & ex.Message.ToUpper)
            Return Nothing
        End Try
        Return dt
    End Function
#End Region

#Region "Cancelar Retiro"

    ''' <summary>
    ''' Llenar la Lista con el Detalle sobre el Último Retiro Realizado
    ''' </summary>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <param name="lbl_Fecha">Se agregará la Fecha en que se realizó el Retiro</param>
    ''' <param name="lbl_Hora">Se agregará la Hora en que se realizó el Retiro</param>
    ''' <param name="lbl_Usuario">Se agregará el Usuario que realizó el Retiro</param>
    ''' <param name="lbl_CiaTV">Se agregará la Compañía se llevó el Retiro</param>
    ''' <param name="lbl_Remision">Se agregará la Remisión con la que se llevó el Retiro</param>
    ''' <param name="lbl_Envase">Se agregará el Envase con el que se llevó el Retiro</param>
    ''' <remarks></remarks>
    ''' 

    Public Shared Sub fn_RetirosCancelar_Llenar(ByRef lsv As ListView, ByRef lbl_Fecha As Label, ByRef lbl_Hora As Label,
                                                ByRef lbl_Usuario As Label, ByRef lbl_CiaTV As Label, ByRef lbl_Remision As Label,
                                                ByRef lbl_Envase As Label)
        Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS CANCELAR", "Inicio CONSULTA ÚLTIMO RETIRO")

        Try
            'Abrir la Conexion
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            'consultar primero si  hay cancelaciones activas
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Retiros_Read4", CommandType.StoredProcedure, Cnn)
            Dim dt_RetirosActivos As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_RetirosActivos.Rows.Count > 0 Then

                'Crear el comando para Insertar datos

                Cmd = Crear_ComandoSQL("RetirosD_ReadUltimo", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Ultimo_Retiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
                Dim dt_UltRetiro As DataTable = Ejecutar_ConsultaSQL(Cmd)

                Call fn_LlenarListView(dt_UltRetiro, lsv, "", "")
                Dim w As Integer = lsv.Width
                lsv.Columns(0).Width = w * 0.23
                lsv.Columns(1).Width = w * 0.27
                lsv.Columns(2).Width = w * 0.23
                lsv.Columns(3).Width = w * 0.23

                dt_UltRetiro = Nothing

                Cmd = Crear_ComandoSQL("RetirosD_ReadUltimo2", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Ultimo_Retiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
                dt_UltRetiro = Ejecutar_ConsultaSQL(Cmd)

                Cmd.Dispose()
                Cnn.Dispose()

                If dt_UltRetiro Is Nothing Then
                    fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 36, varPub.IdPantalla, "RETIROS CANCELAR - " + "Error CONSULTA ÚLTIMO RETIRO: No se obtuvo la Información del Encabezado")
                    Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS CANCELAR", "Error CONSULTA ÚLTIMO RETIRO: No se obtuvo la Información del Encabezado")
                    Call fn_MsgBox("error al realizar la Consulta del Último Retiro.", MessageBoxIcon.Error)
                    Exit Sub
                End If

                lbl_CiaTV.Text = varPub.CiaTV
                If dt_UltRetiro.Rows.Count = 0 Then
                    lbl_Fecha.Text = String.Empty
                    lbl_Hora.Text = String.Empty
                    lbl_Usuario.Text = String.Empty
                    lbl_Remision.Text = String.Empty
                    lbl_Envase.Text = String.Empty
                Else
                    lbl_Fecha.Text = dt_UltRetiro.Rows(0)("Fecha")
                    lbl_Hora.Text = dt_UltRetiro.Rows(0)("Hora")
                    lbl_Usuario.Text = dt_UltRetiro.Rows(0)("Nombre_Usuario")
                    lbl_Remision.Text = dt_UltRetiro.Rows(0)("Numero_Remision")
                    lbl_Envase.Text = dt_UltRetiro.Rows(0)("Numero_Envase")
                End If

                Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS CANCELAR", "Fin CONSULTA ÚLTIMO RETIRO BD_SDF")
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS CANCELAR", "NO HAY RETIROS POR CANCELAR BD_SDF")
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 36, varPub.IdPantalla, "RETIROS CANCELAR - " + "Error CONSULTA ÚLTIMO RETIRO: " & ex.Message)
            Call fn_EscribirLog(varPub.UsuarioClave, "RETIROS CANCELAR", "Error CONSULTA ÚLTIMO RETIRO: " & ex.Message)
            Call fn_MsgBox("error al realizar la Consulta del Último Retiro.", MessageBoxIcon.Error)
        End Try
    End Sub


#End Region

#Region "Privilegios Usuarios -Carga Lista"

    Public Shared Function fn_AgregaPrivilegios(ByVal Cve_Opcion As String, ByVal ClaveUserN As String) As Boolean
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim tr As SqlTransaction = Nothing

        Try

            If Cve_Opcion <> "T" Then
                'Antes de insertar hay que verificar que no tenga status2=D, si es así hay que actualizar 
                If fn_ValidarPrivilegios(ClaveUserN, Cve_Opcion) Then Return True

                'inserta una opcion en Privilegios
                '
                Cmd = Crear_ComandoSQL("Privilegios_Insert", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(ClaveUserN.Split("/")(0)))
                Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_Opcion)
                Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.NVarChar, "N")
                Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "A")



                If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "SE AGREGO EL PRIVILEGIO " & Cve_Opcion & " en la bdd Local" & " al usuario " & ClaveUserN)


                    If (varPub.ConexionwebAdmin = 1) Then
                        If fn_VerificaConexionInternet() Then
                            'se inserta los privilegios en la web
                            If cls_CashWeb.fn_Guarda_PrivilegiosWeb(ClaveUserN.Split("/")(0), Cve_Opcion) Then

                                Cmd = Crear_ComandoSQL("Privilegios_Update2", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                                Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_Opcion)
                                Ejecutar_ConsultaSQL(Cmd)

                                fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "Guardando privilegios de usuario en la bbd web")
                            End If
                        End If
                    End If
                    Return True
                Else
                    fn_AddLog(varPub.Id_Cajero, varPub.UsuarioClave, varPub.Cve_Sucursal, 38, varPub.IdPantalla, "PRIVILEGIOS - " + "ERROR AL AGREGAR EL PRIVILEGIO " & Cve_Opcion & " en la bdd Local")
                    Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL AGREGAR EL PRIVILEGIO " & Cve_Opcion & " en la bdd Local")
                    Cmd.Dispose()
                    Cnn.Dispose()
                    Return False
                End If
            Else
                tr = Crear_TransSQL(Cnn)
                'si es 'T' elimina todos los privilegios y Agrega Todos lOs privilegios

                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Privilegios_Delete")
                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(ClaveUserN.Split("/")(0)))
                Ejecutar_NonQueryTSQL(Cmd)

                'Carga privilegios si es usuario Amdin(2) o Local (1 = operativo)

                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Opciones_Read")
                Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, CInt(ClaveUserN.Split("/")(1)))
                Dim dtPrivilegios As DataTable = Ejecutar_ConsultaTSQL(Cmd)

                For Each elemento As DataRow In dtPrivilegios.Rows

                    Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Privilegios_Insert")
                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(ClaveUserN.Split("/")(0)))
                    Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, elemento("ClaveOpcion"))
                    Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.NVarChar, "N")
                    Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "A")

                    Ejecutar_NonQueryTSQL(Cmd)

                    'Ir insertando en web de nuevo- ------ -- - - -
                    If (varPub.ConexionwebAdmin = 1) Then
                        If fn_VerificaConexionInternet() Then
                            'insertamos en web 18/01/2014
                            If cls_CashWeb.fn_Guarda_PrivilegiosWeb(ClaveUserN.Split("/")(0), elemento("ClaveOpcion")) Then
                                fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "Guardando privilegios de usuario en la bbd web")
                            End If
                            'Si lo encuentra o lo actualiza en la web debe actualizarlo

                            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Privilegios_Update2")
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, elemento("ClaveOpcion"))
                            Ejecutar_NonQueryTSQL(Cmd)

                        End If
                    End If
                    '------------------
                Next
                tr.Commit()
                tr.Dispose()
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "SE AGREGARON TODOS LOS PRIVILEGIOS CORRECTAMENTE")
                Return True
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 38, varPub.IdPantalla, "PRIVILEGIOS - " + "ERROR AL AGREGAR PRIVILEGIOS" & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL AGREGAR PRIVILEGIOS" & ex.Message.ToUpper)

            If Cve_Opcion = "T" Then tr.Rollback() 'Rehacer transaccion
            Cmd.Dispose()
            Cnn.Dispose()
            Return False
        End Try
    End Function

    Public Shared Function fn_BorrarPrivilegios(ByVal Cve_OpcionBorrar As String, ByVal ClaveUserN As String) As Boolean
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Try
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "Inicio BORRAR PRIVILEGIOS")
            If Cve_OpcionBorrar <> "T" Then
                'borrar una opcion en Privilegios

                If varPub.Conectividad Then
                    If fn_VerificaConexionInternet() Then
                        If cls_CashWeb.fn_EliminarPrivilegios(ClaveUserN, Cve_OpcionBorrar) Then

                            Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(ClaveUserN.Split("/")(0)))
                            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)

                            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                                Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "SE BORRO PRIVILEGIO" & Cve_OpcionBorrar)
                                Cmd.Dispose()
                                Cnn.Dispose()
                                Return True
                            Else

                                If fn_ValidarSincronizadoPrivilegios(ClaveUserN, Cve_OpcionBorrar) Then 'SI NO SE PUDO ELIMINAR EN LA WEB
                                    'ACTUALIZA SI ESTA SINCRONIZADO

                                    Cmd = Crear_ComandoSQL("Privilegios_Update", CommandType.StoredProcedure, Cnn)
                                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                                    Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)
                                    Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "D")

                                Else
                                    'ELIMINA SI NO ESTA SINCRONIZADO

                                    Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Cnn)
                                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                                    Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)

                                End If

                                Ejecutar_NonQuerySQL(Cmd)

                            End If
                        End If
                    Else

                        If fn_ValidarSincronizadoPrivilegios(ClaveUserN, Cve_OpcionBorrar) Then 'SI NO HAY INTERNET
                            'ACTUALIZA SI ESTA SINCRONIZADO
                            Cmd = Crear_ComandoSQL("Privilegios_Update", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)
                            Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "D")
                        Else
                            'ELIMINA SI NO ESTA SINCRONIZADO
                            Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)

                        End If

                        Ejecutar_NonQuerySQL(Cmd)

                    End If
                Else

                    If fn_ValidarSincronizadoPrivilegios(ClaveUserN, Cve_OpcionBorrar) Then 'SI NO HAY CONECTIVIDAD
                        'ACTUALIZA SI ESTA SINCRONIZADO

                        Cmd = Crear_ComandoSQL("Privilegios_Update", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                        Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "D")
                    Else
                        'ELIMINA SI NO ESTA SINCRONIZADO

                        Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                        Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Cve_OpcionBorrar)
                    End If

                    Ejecutar_NonQuerySQL(Cmd)

                End If

                '---------------------------------
            Else
                '---------------------------------
                'si es 'T' elimina todos los privilegios
                If varPub.Conectividad Then
                    If fn_VerificaConexionInternet() Then
                        If cls_CashWeb.fn_EliminarTodosPrivilegios(ClaveUserN) Then ' SI HAY CONECTIVIDAD PRIMERO ELIMINA EN LA WEB

                            Cmd = Crear_ComandoSQL("Privilegios_Delete", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                            'DESPUES LOCALMENTE SE ELIMINAR PRIVILEGIOS

                            'si usuario firmado Admin no puede quitarse Opcion(Privilegios) X seguridad
                            Dim OpcionDelete As String = "T"

                            If CInt(ClaveUserN.Split("/")(0)) = varPub.UsuarioClave Then
                                Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN.Split("/")(0))
                                Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, "14")

                                OpcionDelete = "14"
                            End If

                            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                                Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "SE BORRARON TODOS LOS PRIVILEGIOS CORRECTAMENTE")
                                Cmd.Dispose()
                                Cnn.Dispose()
                                Return True
                            Else
                                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 39, varPub.IdPantalla, "PRIVILEGIOS - " + "ERROR AL BORRAR TODOS LOS PRIVILEGIOS")
                                Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL BORRAR TODOS LOS PRIVILEGIOS")

                                Cmd.Dispose()
                                Cnn.Dispose()
                                Return False
                            End If

                        End If
                    Else   'SI NO HAY INTERNET  DEBE CAMBIAR STATUS Y O ELIMINAR PRIVILEGIOS

                        Return True = fn_ConsultarSincronizadoPrivilegiosAll(ClaveUserN) 'SINCRONIZADO ACTUALIZA, NO SINCRONIZADO ELIMINA

                    End If

                Else 'SI NO HAY CONECTIVIDAD DEBE CAMBIAR STATUS Y O ELIMINAR PRIVILEGIOS

                    Return True = fn_ConsultarSincronizadoPrivilegiosAll(ClaveUserN)   'SINCRONIZADO ACTUALIZA, NO SINCRONIZADO ELIMINA

                End If

            End If
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 39, varPub.IdPantalla, "PRIVILEGIOS - " + "ERROR AL BORRAR PRIVILEGIOS" & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL ABORRAR PRIVILEGIOS" & ex.Message.ToUpper)

            Cmd.Dispose()
            Cnn.Dispose()
            Return False
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Llena un DataTable con los privilegios que tiene el Usuario logueado
    ''' serviran para crear los botones al Leer el form.
    ''' </summary>
    ''' <param name="ClaveUserN"> Usuario que se ha logueado en el Sistema</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_ConsultaPrivilegios_LlenatDT(ByVal ClaveUserN As Integer, ByVal tipoUser As Byte) As DataTable
        'Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "INICIO - CONSULTAR PRIVILEGIOS PARA EL USUARIO: " & ClaveUserN)

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim cmd As SqlCommand = Crear_ComandoSQL("PrivilegiosRead", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN)
            Crear_ParametroSQL(cmd, "@Tipo_Usuario ", SqlDbType.Int, tipoUser)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(cmd)

            '----{Se inserta una Fila( boton cerrar sesion) por Default 
            Dim Fila As DataRow = dt_Usuarios.NewRow
            Fila("DescripcionOpc") = "Cerrar"
            Fila("NombreBoton") = "btn_CerrarSesion"
            dt_Usuarios.Rows.InsertAt(Fila, dt_Usuarios.Rows.Count + 1)
            '-----}

            If dt_Usuarios IsNot Nothing AndAlso dt_Usuarios.Rows.Count > 0 Then
                'Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "FIN - PRIVILEGIOS CARGADOS CORRECTAMENTE.")
                Return dt_Usuarios
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "FIN - NO SE ENCONTRARON PRIVILEGIOS PARA EL USUARIO:" & ClaveUserN)
                Return Nothing
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 40, varPub.IdPantalla, "OCURRIÓ UN ERROr AL CARGAR PRIVILEGIOS AL USUARIO: " & ClaveUserN & ". " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "OCURRIÓ UN ERROr AL CARGAR PRIVILEGIOS AL USUARIO: " & ClaveUserN & ". " & ex.Message.ToUpper)
            Call fn_MsgBox(" Error al Intentar Llenar el DataTable.", MessageBoxIcon.Error)

            Return Nothing
        End Try

    End Function

    Public Shared Sub fn_PrivilegiosAsignados_LlenarListaArray(ByRef Arreglo() As String, ByVal ClaveUserN As Integer)

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("PrivilegiosRead2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Usuarios.Rows.Count = 0 Then Exit Sub

            ReDim Arreglo(dt_Usuarios.Rows.Count - 1)

            For i As Integer = 0 To dt_Usuarios.Rows.Count - 1
                Arreglo(i) = dt_Usuarios.Rows(i)("ClaveOpcion").ToString
            Next

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 49, varPub.IdPantalla, "PRIVILEGIOS - " + "ERROR AL LLENAR LISTA DE PRIVILEGIO EN EL ARREGLO: " & ex.Message)
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL LLENAR LISTA DE PRIVILEGIO EN EL ARREGLO: " & ex.Message)
            Call fn_MsgBox("Ocurrió un error al intentar llenar el Arreglo con privilegios asignados.", MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' Llena la lista con los privilegios asignados a un Usuario seleccionado
    ''' </summary>
    ''' <param name="lst"></param>
    ''' <param name="ClaveUserN"></param>
    ''' <remarks></remarks>
    Public Shared Sub fn_PrivilegiosAsignados_LlenarLista(ByRef lst As ListBox, ByVal ClaveUserN As Integer)
        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("PrivilegiosRead2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUserN)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Call fn_LlenarListBox(lst, dt_Usuarios, "ClaveOpcion", "DescripcionOpc", "")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 49, varPub.IdPantalla, "PRIVILEGIOS" + "ERROR PRIVILEGIOS LLENAR LISTA: " & ex.Message)
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERRO PRIVILEGIOS LLENAR LISTA: " & ex.Message)
            Call fn_MsgBox("error al intentar llenar la Lista con privilegios asignados.", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' llena la lista Privilegios si es Admin tiene Todos, sino-> solo tiene Local
    ''' </summary>
    ''' <param name="lst"> lista a llenar con los privilegios que le corresponden</param>
    ''' <param name="UsuarioTipoN">usuario que se ha seleccionado de la lista de Usuarios</param>
    ''' <remarks></remarks>
    ''' 
    Public Shared Sub fn_Privilegios_LlenarLista(ByRef lst As ListBox, ByVal UsuarioTipoN As Byte)
        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Opciones_Read", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, UsuarioTipoN)
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Call fn_LlenarListBox(lst, dt_Usuarios, "ClaveOpcion", "DescripcionOpc", "")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 49, varPub.IdPantalla, "PRIVILEGIOS" + "ERROR PRIVILEGIOS LLENAR LISTA: " & ex.Message)
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "Error PRIVILEGIOS LLENAR LISTA: " & ex.Message)
            Call fn_MsgBox("Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Usuarios"
    ''' <summary>
    ''' Llenar la Lista Desplegable de las Clases de Usuarios (Local y Administrador)
    ''' </summary>
    ''' <param name="cmb">Lista Desplegable que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Usuarios_Clases(ByRef cmb As ComboBox)
        Call fn_EscribirLog(varPub.UsuarioClave, "USUARIOS", "INICIO - USUARIOS CLASES COMBO")
        Try
            Dim dt_ClasesUsr As DataTable = New DataTable
            dt_ClasesUsr.Columns.Add("Id")
            dt_ClasesUsr.Columns.Add("Descripcion")
            dt_ClasesUsr.Rows.Add(0, "Seleccione...")
            dt_ClasesUsr.Rows.Add(1, "LOCAL")
            dt_ClasesUsr.Rows.Add(2, "ADMINISTRADOR")

            cmb.ValueMember = "Id"
            cmb.DisplayMember = "Descripcion"
            cmb.DataSource = dt_ClasesUsr
            Call fn_EscribirLog(varPub.UsuarioClave, "USUARIOS", "FIN - USUARIOS CLASES COMBO")
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 51, varPub.IdPantalla, "USUARIOS - " + "FIN - ERROR AL LLENAR USUARIOS CLASES COMBO: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "USUARIOS", "FIN - ERROR AL LLENAR USUARIOS CLASES COMBO: " & ex.Message.ToUpper)
            Call fn_MsgBox("error al Intentar Llenar la Lista Desplegable de Clases de Usuarios", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Llenar la Lista de los Usuarios existentes (Locales y Administradores)
    ''' </summary>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Usuarios_Llenar(ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA USUARIOS", "INICIO - LLENAR LISTA")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read2", CommandType.StoredProcedure, Cnn)

            If varPub.TipoUser <> Tipos_Usuarios.SuperAdmin Then
                Crear_ParametroSQL(Cmd, "@TipoUsuario", SqlDbType.Int, 2)
            Else
                Crear_ParametroSQL(Cmd, "@TipoUsuario", SqlDbType.Int, 1)
            End If
            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Usuarios.Rows.Count > 0 Then
                Call fn_LlenarListView(dt_Usuarios, lsv, "", "", True)
            Else
                lsv.Items.Clear() 'limpia la lista cuando no hay datos en el fuente de origen,
            End If

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA USUARIOS", "FIN - SE CARGO LISTA CORRECTAMENTE DE BD_SDF")

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 52, varPub.IdPantalla, "CONSULTA USUARIOS - " + "FIN - ERROR AL LLENAR LISTA" & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA USUARIOS", "FIN - ERROR AL LLENAR LISTA" & ex.Message.ToUpper)
            Call fn_MsgBox("Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub
    '-------------------------------JAVIER ZAPATA 11/12/2018------------------------------------------------
    Public Shared Function fn_GenerarClave() As Integer

        Call fn_EscribirLog(varPub.UsuarioClave, "GENERAR CLAVE", "USUARIOS - CREAR USUARIO")
        Try

            Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_ReadUltimo ", CommandType.StoredProcedure, cnn)
            Dim Clave As Object = Ejecutar_ScalarSQL(cmd)
            If IsDBNull(Clave) Then
                Return CInt(varPub.Cve_Sucursal & 1)
            Else
                Clave = CStr(Clave)
            End If

            If Clave > 0 Then
                Clave = CInt(Microsoft.VisualBasic.Right(Clave, Clave.length - varPub.Cve_Sucursal.Length) + 1)
                Return CInt(varPub.Cve_Sucursal & Clave)
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 53, varPub.IdPantalla, "GENERAR CLAVE - " + "FIN -ERROR AL GENERAR LA CLAVE DEL USUARIO: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "GENERAR CLAVE", "FIN - ERROR AL GENERAR LA CLAVE DEL USUARIO: " & ex.Message.ToUpper)
            Call fn_MsgBox("Error al tratar de generar la clave del usuario.", MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    '-------------javuier zapata 16/05/2019----
    Public Shared Function fn_GenerarClaves() As Integer
        Try
            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_ReadClavemax", CommandType.StoredProcedure, Con)
            Dim Dt_Usuarios = Ejecutar_ConsultaSQL(Cmd)
            If Dt_Usuarios.Rows.Count <= 0 Then
                Return CInt(1)
            ElseIf String.IsNullOrEmpty(Dt_Usuarios.Rows(0).Item(0).ToString()) Then
                Return 1
            Else
                Return CInt(Dt_Usuarios.Rows(0).Item(0).ToString()) + 1
            End If
        Catch ex As Exception
            Call fn_MsgBox(" error al intentar generar el usuario.", MessageBoxIcon.Error)
        End Try
        ' For i = 0 To Dt_Usuarios.Rows.Count - 1
        '     Dim BD = Dt_Usuarios.Rows(i).Item(0).ToString
        '     Dim Claves = CInt(varPub.Cve_Sucursal & 1)
        '      If Dt_Usuarios.Rows(i).Item(0).ToString = varPub.Cve_Sucursal & i + 1 Then
        '           Else
        '           Return CInt(varPub.Cve_Sucursal & i + 1)
        '      End If
        ' Next
        'Return CInt(varPub.Cve_Sucursal & Dt_Usuarios.Rows.Count.ToString + 1)
    End Function
    ''' <summary>
    ''' Realizar la Reactivación o Baja de un Usuario
    ''' </summary>
    ''' <param name="Clave_Usuario">Clave del Usuario que se cambiará de Status</param>
    ''' <param name="Status">Status Actual del Usuario</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Usuarios_Status(ByVal Clave_Usuario As Integer, ByVal Status As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "INICIO - USUARIOS CAMBIAR STATUS.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand
            Dim fechaActual As String = Fecha & " " & Hora
            Dim StatusAsignar As String = ""
            Dim StatusLog As String = ""

            If Status = "ACTIVO" Then
                StatusAsignar = "B"
                StatusLog = "DE ACTIVO A BAJA."
            ElseIf Status = "BAJA" Then
                StatusAsignar = "A"
                StatusLog = "DE BAJA A ACTIVO."
            End If

            Cmd = Crear_ComandoSQL("Usuarios_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Status ", SqlDbType.VarChar, StatusAsignar)
            Crear_ParametroSQL(Cmd, "@Usuario_Baja", SqlDbType.Int, varPub.UsuarioClave)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario)
            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                '------------------
                If (varPub.ConexionwebAdmin = 1) Then
                    If fn_VerificaConexionInternet() Then
                        If cls_CashWeb.fn_CambiarStatus_Usuarios(StatusAsignar, Clave_Usuario, varPub.UsuarioClave, fechaActual) Then
                            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - USUARIO DADO DE '" & Status & "' EN BDD CENTRAL.")
                        End If
                    Else
                        Cmd = Crear_ComandoSQL("Usuarios_Update2", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario)
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "U")
                        Ejecutar_ConsultaSQL(Cmd)
                    End If
                Else
                    Cmd = Crear_ComandoSQL("Usuarios_Update2", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario)
                    Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "U")
                    Ejecutar_ConsultaSQL(Cmd)

                End If
                '--------------------
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - SE CAMBIA EL STATUS DE USUARIO" & StatusLog)
                Return True
            Else
                Cmd.Dispose()
                Cnn.Dispose()
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 54, varPub.IdPantalla, "CONSULTA DE USUARIOS - " + "FIN - ERROR AL CAMBIAR EL USUARIO DE STATUS" & StatusLog)
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - ERROR AL CAMBIAR EL USUARIO DE STATUS" & StatusLog)
                Return False
            End If


        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 54, varPub.IdPantalla, "CONSULTA DE USUARIOS - " + "FIN - ERROR AL CAMBIAR STATUS USUARIO." & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - ERROR AL CAMBIAR STATUS USUARIO." & ex.Message.ToUpper)
            Call fn_MsgBox("Error al cambiar el status del Usuario.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Traer todos los datos del Usuario
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Usuarios_Read(ByVal Clave_Usuario As Integer) As DataTable

        'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "INICIO - TRAER DATOS DEL USUARIO: " & Clave_Usuario)
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            '23marzo2013 add Fecha_expira/

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario)
            'Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - TRAER DATOS DEL USUARIO BD_SDF")

            Dim dt As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Return dt

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 55, varPub.IdPantalla, "CONSULTA DE USUARIOS - " + "FIN - ERROR AL CONSULTAR DATOS DE USUARIO: " & Clave_Usuario & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - ERROR AL CONSULTAR DATOS DE USUARIO: " & Clave_Usuario & ex.Message.ToUpper)
            Call fn_MsgBox("Error al traer consulta de Usuarios.", MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Llena la lista con los usuarios del tipo 1=Local(Operativos) y 2 Administrativos
    ''' </summary>
    ''' <param name="lst"> Listbox que llena los usuarios</param>
    ''' <remarks> </remarks>
    Public Shared Sub fn_Usuarios_LlenarLista(ByRef lst As ListBox)
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read4", CommandType.StoredProcedure, Cnn)
            If varPub.TipoUser <> Tipos_Usuarios.SuperAdmin Then
                'Query = Query & " And Usuario_Registro <> 0 "
                Crear_ParametroSQL(cmd, "@Tipo_Usuario", SqlDbType.Int, 2)
            Else
                Crear_ParametroSQL(cmd, "@Tipo_Usuario", SqlDbType.Int, 1)
            End If


            Dim dt_Usuarios As DataTable = Ejecutar_ConsultaSQL(cmd)

            If dt_Usuarios IsNot Nothing AndAlso dt_Usuarios.Rows.Count > 0 Then
                Call fn_LlenarListBox(lst, dt_Usuarios, "ClaveTipo", "Nombre", "")
            End If

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 52, varPub.IdPantalla, "CONSULTA USUARIOS - " + "ERROR AL LLENAR LISTA: " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA USUARIOS", "ERROR AL LLENAR LISTA: " & ex.Message.ToUpper)
            Call fn_MsgBox("Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Function fn_Usuarios_Eliminar(ByVal userClave As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "INICIO - ELIMINAR USUARIO: " & userClave)
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim tr As SqlTransaction = Nothing

        Try


            Cnn = Crear_ConexionSQL(_Cnx)
            tr = Crear_TransSQL(Cnn)
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_ReadUser")
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(userClave))

            If Ejecutar_ScalarTSQL(Cmd) > 0 Then
                tr.Commit()
                Cnn.Dispose()
                Cmd.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - NO SE ELIMINO EL USUARIO PORQUE TIENE DEPOSITOS.")
                Return 0
            End If


            'Eliminar privilegios
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Privilegios_Delete")
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(userClave))

            Ejecutar_NonQueryTSQL(Cmd)

            Dim eliminaWeb As Integer = 0
            If varPub.ConexionwebAdmin = 1 Then
                If fn_VerificaConexionInternet() Then
                    If cls_CashWeb.fn_Elimina_Usuarios(userClave) Then
                        eliminaWeb = 1
                    Else
                        eliminaWeb = 0
                    End If
                Else
                    eliminaWeb = 0
                End If
            End If

            If eliminaWeb >= 1 Then ' si elimino usuario en la web 

                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Usuarios_Delete")
                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(userClave))
                Ejecutar_ScalarTSQL(Cmd)
                tr.Commit()
                Cnn.Dispose()
                Cmd.Dispose()
                tr.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - USUARIO :" & userClave & " ELIMINADO CORRECTAMENTE.")
                Return 1

            ElseIf eliminaWeb = 0 Then ' si el cajero no tiene configuración de conexión o no tiene conectividad con la web o no se eliminó el usuario en en la web

                Cmd.Connection.Close()
                'Verificamos si está sincroniado en caso de que si se actualiza status2 y si no se elimina directamente
                Cmd = Crear_ComandoSQL("Usuarios_Read10", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(userClave))
                Dim Objeto = Ejecutar_ScalarSQL(Cmd)

                If IsNothing(Objeto) Then
                    Return 0
                Else
                    If Objeto.ToString = "N" Then
                        Cmd = Crear_ComandoSQL("Usuarios_Delete", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(userClave))
                        If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                            Cnn.Dispose()
                            Cmd.Dispose()
                            Return 1
                        End If

                    Else
                        Cmd = Crear_ComandoSQL("Usuarios_Update2", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(userClave))
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "D")

                        Ejecutar_ScalarSQL(Cmd)
                        Cnn.Dispose()
                        Cmd.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - USUARIO :" & userClave & " STATUS2 DEL USUARIO ACTUALIZADO CORRECTAMENTE.")
                        Return 1
                    End If
                End If
            End If
            Return 0
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 56, varPub.IdPantalla, "CONSULTA DE USUARIOS - " + "FIN - ERROR AL ELIMINAR USUARIO: " & userClave & " ." & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN - ERROR AL ELIMINAR USUARIO: " & userClave & " ." & ex.Message.ToUpper)
            Return -1
        End Try

    End Function

    Public Shared Function fn_Usuarios_ReiniciarPassword(ByVal ClaveUsuario As Integer) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "INICIO - REINICIAR CONTRASEÑA A: " & ClaveUsuario)

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand

            Dim ContraCod As String = fn_Encode(ClaveUsuario)

            Cmd = Crear_ComandoSQL("Usuarios_Update3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@ContraCod", SqlDbType.VarChar, ContraCod)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, ClaveUsuario)
            Ejecutar_NonQuerySQL(Cmd)

            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN -CONTRASENA REINICIADA CORRECTAMENTE A: " & ClaveUsuario)

            Return True
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 57, varPub.IdPantalla, "CONSULTA DE USUARIOS - " + "FIN -  ERROR AL REINICIAR CONTRASEÑA. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA DE USUARIOS", "FIN -  ERROR AL REINICIAR CONTRASEÑA. " & ex.Message.ToUpper)
            Return False
        End Try
    End Function

#End Region

#Region "Casets"

    ''' <summary>
    ''' Validar la Capacidad que lleva el Caset Actual
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_ValidarCapacidad() As Integer
        If varPub.Capacidad_Actual >= varPub.Capacidad_Caset Then
            'Call fn_MsgBox("El Caset esta lleno, debe de Cambiar de Caset.", MessageBoxIcon.Exclamation)
            Return 100
        Else
            Dim Calculo_Llenado As Integer = CInt((varPub.Capacidad_Actual / varPub.Capacidad_Caset) * 100)
            If Calculo_Llenado >= varPub.Porcentaje_Alerta Then
                'Call fn_MsgBox("El Caset esta al: " & Calculo_Llenado & "% de su capacidad, debe de Cambiar de Caset.", MessageBoxIcon.Information)
            End If
            Return Calculo_Llenado
        End If
    End Function

    ''' <summary>
    ''' Validar la Capacidad que lleva el Caset Actual 2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_ValidarCapacidad_C2() As Integer
        If varPub.Capacidad_Actual2 >= varPub.Capacidad_Caset2 Then
            'Call fn_MsgBox("El Caset esta lleno, debe de Cambiar de Caset.", MessageBoxIcon.Exclamation)
            Return 100
        Else
            Dim Calculo_Llenado As Integer = CInt((varPub.Capacidad_Actual2 / varPub.Capacidad_Caset2) * 100)
            If Calculo_Llenado >= varPub.Porcentaje_Alerta2 Then
                'Call fn_MsgBox("El Caset esta al: " & Calculo_Llenado & "% de su capacidad, debe de Cambiar de Caset.", MessageBoxIcon.Information)
            End If
            Return Calculo_Llenado
        End If
    End Function

    ''' <summary>
    ''' Llenar la Lista de los Casets existentes
    ''' </summary>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Casets_Llenar(ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "INICIO - LLENAR LISTA CASET.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            '5nov quite idcaset

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_Caset As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Call fn_LlenarListView(dt_Caset, lsv, "Id_Caset", "")
            Dim w As Integer = lsv.Width

            lsv.Columns(0).Width = w * 0.18
            lsv.Columns(1).Width = w * 0.33
            lsv.Columns(2).Width = w * 0.16
            lsv.Columns(3).Width = w * 0.16
            lsv.Columns(4).Width = w * 0.14
            lsv.Columns(4).TextAlign = HorizontalAlignment.Center

            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN - LISTA DE CASETS CARGADA CORRECTAMENTE.")
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 52, varPub.IdPantalla, "CATALOGO CASETS - " + "FIN - ERROR AL CARGAR LISTA. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN - ERROR AL CARGAR LISTA. " & ex.Message.ToUpper)
            Call fn_MsgBox("Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generear Nuevo Registro de un Caset
    ''' </summary>
    ''' <param name="Clave_Caset">Clave que se Agregará al Caset</param>
    ''' <param name="Serie_Caset">Número de Serie</param>
    ''' <param name="Capacidad">Capacidad Máxima del Caset</param>
    ''' <param name="PorcentajeAlerta">Porcentaje que se manejará para prevenir al Usuario sobre un Caset casi Lleno</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Casets_Create(ByVal Clave_Caset As String, ByVal Serie_Caset As String, ByVal Capacidad As String, ByVal PorcentajeAlerta As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "INICIO -CREAR NUEVO CASET.")

        'Validaciones
        If Clave_Caset.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CLAVE DE CASET NO CAPTURADA.")
            Return 2
        End If

        If Clave_Caset.Length < 3 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CLAVE CASET NO VÁLIDA.")
            Return 2
        End If

        If fn_Casets_ClaveExiste(Clave_Caset) Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CLAVE CASET YA EXISTE: " & Clave_Caset)
            Return 3
        End If

        If Serie_Caset.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - NÚMERO DE SERIE NO CAPTURADO.")
            Return 4
        End If

        If Serie_Caset.Length < 8 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - NÚMERO DE SERIE INCOMPLETO.")
            Return 4
        End If

        If fn_Casets_NumeroserieExiste(Serie_Caset) Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - NÚMERO DE SERIE YA EXISTE.")
            Return 5
        End If

        If Capacidad.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN- CAPACIDAD NO CAPTURADO.")
            Return 6
        End If

        Dim rCapacidad As Integer
        If Not Integer.TryParse(Capacidad, rCapacidad) Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CAPACIDAD INCORRECTA: " & Capacidad)
            Return 6
        End If

        'If CInt(Capacidad) < 10 Or CInt(Capacidad) > LimiteCapacidad_Kct Then
        '    Call fn_EscribirLog(UsuarioClave, "CATALOGO CASETS", "Fin CASETS CREAR NUEVO, Capacidad incorrecta")
        '    Return 6
        'End If

        If PorcentajeAlerta.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - PORCENTAJE DE ALERTA NO CAPTURADO.")
            Return 7
        End If

        Dim rPorcentajeAlerta As Integer
        If Not Integer.TryParse(PorcentajeAlerta, rPorcentajeAlerta) Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - PORCENTAJE DE ALERTA INCORRECTO: " & PorcentajeAlerta)
            Return 7
        End If

        If CInt(PorcentajeAlerta) < 40 OrElse CInt(PorcentajeAlerta) > 95 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - PORCENTAJE DE ALERTA FUERA DE RANGO: " & PorcentajeAlerta)
            Return 7
        End If

        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim tr As SqlTransaction = Nothing
        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            tr = Crear_TransSQL(Cnn)


            Dim fechaActual As String = Fecha & " " & Hora

            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Casets_Insert")
            'Cmd = Crear_ComandoSQL("Casets_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, Clave_Caset.Trim)
            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, Serie_Caset.Trim)
            Crear_ParametroSQL(Cmd, "@Capacidad", SqlDbType.Int, rCapacidad)
            Crear_ParametroSQL(Cmd, "@Porcentaje_Alerta", SqlDbType.Int, rPorcentajeAlerta)
            Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "A")
            Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "N")
            Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "A")
            Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.VarChar, "1900-01-01")

            'Dim Query As String = "Insert Into Casets " & _
            '      (Clave_Caset,Serie_Caset,Capacidad,Porcentaje_Alerta,Status,Sincronizado,FechaSync,Fecha_Modifica,Status2) " & _
            '      Values ('" & Clave_Caset.Trim & "','" & Serie_Caset.Trim & "','" & rCapacidad & "','" & rPorcentajeAlerta & "','A','N',Null,Null,'A')"


            'Cmd = Crear_ComandoSQL("Casets_Insert", CommandType.StoredProcedure, Cnn)

            '          Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, cveCaset("ClaveC"))
            '          Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, cveCaset("Serie"))
            '          Crear_ParametroSQL(Cmd, "@Capacidad", SqlDbType.Int, cveCaset("Capacidad"))
            '          Crear_ParametroSQL(Cmd, "@Porcentaje_Alerta", SqlDbType.Int, cveCaset("Porcentaje"))
            '          Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, cveCaset("Status"))
            '          Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "S")
            '          Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, Fecha & " " & Hora)
            '          Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "A")

            Dim Identity As Byte = Ejecutar_ScalarTSQL(Cmd)

            If (varPub.ConexionwebAdmin = 1) Then
                If fn_VerificaConexionInternet() Then
                    Call fn_SincronizaUltimaConexion()
                    If cls_CashWeb.fn_GuardaCasets(Clave_Caset.Trim, Serie_Caset.Trim, rCapacidad, rPorcentajeAlerta, "A", fechaActual) Then

                        ' obtiene id caset

                        Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Casets_Update")
                        Crear_ParametroSQL(Cmd, "@Id_Caset", SqlDbType.Int, Identity)

                        Ejecutar_NonQueryTSQL(Cmd)
                        tr.Commit()
                        Cmd.Dispose()
                        Cnn.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CASETS CREAR NUEVO.")
                        Return 1 'correcto
                    End If
                End If
            End If
            tr.Commit()
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CASETS CREAR NUEVO.")
            Return 1 'correcto
        Catch ex As Exception
            tr.Rollback()
            Cmd.Dispose()
            Cnn.Dispose()
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 61, varPub.IdPantalla, "CATALOGO DE CASETS - " + "FIN -ERROR AL CREAR NUEVO CASET. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN -ERROR AL CREAR NUEVO CASET. " & ex.Message.ToUpper)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Realizar la Reactivación o Baja de un Caset
    ''' </summary>
    ''' <param name="SerieCaset">Id del Caset que se cambiará de Status</param>
    ''' <param name="Status">Status Actual del Caset</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    Public Shared Function fn_Casets_Status(ByVal SerieCaset As String, ByVal Status As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "INICIO - CAMBIAR STATUS.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand
            Dim fechaActual As String = Fecha & " " & Hora
            Dim StatusAsignar As String = ""
            Dim StatusLog As String = ""

            If Status = "ACTIVO" Then
                StatusAsignar = "B"
                StatusLog = "DE ACTIVO A BAJA."
            ElseIf Status = "BAJA" Then
                StatusAsignar = "A"
                StatusLog = "DE BAJA  A ACTIVO"
            End If

            Cmd = Crear_ComandoSQL("Casets_Update2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@StatusAsignar", SqlDbType.VarChar, StatusAsignar)
            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then

                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - SE CAMBIO EL STATUS DEL CASET" & StatusLog)
                '------ si Conectividad ----
                If (varPub.ConexionwebAdmin = 1) Then
                    If fn_VerificaConexionInternet() Then
                        Call fn_SincronizaUltimaConexion()
                        cls_CashWeb.fn_CambiarStatus_Casets(StatusAsignar, SerieCaset, fechaActual)
                    Else
                        '---11/06/2019  Debe actualizar el Status2 en caso de no haber red
                        Cmd = Crear_ComandoSQL("Casets_Update3", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@StatusAsignar", SqlDbType.VarChar, "E")
                        Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
                        Ejecutar_ConsultaSQL(Cmd)

                    End If
                Else

                    '---11/06/2019  Debe actualizar el Status2 en caso de no haber red
                    Cmd = Crear_ComandoSQL("Casets_Update3", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@StatusAsignar", SqlDbType.VarChar, "E")
                    Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
                    Ejecutar_ConsultaSQL(Cmd)
                End If
                '-----------*************
                Cmd.Dispose()
                Cnn.Dispose()

                Return True
            Else
                Cmd.Dispose()
                Cnn.Dispose()
                fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 62, varPub.IdPantalla, "CATALOGO DE CASETS - " + "FIN -ERROR AL CAMBIAR STATUS DEL CASET. ")
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - ERROR AL CAMBIAR EL CASET DE STATUS.")
                Return False
            End If
        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 62, varPub.IdPantalla, "CATALOGO DE CASETS - " + "FIN - ERROR AL CAMBIAR STATUS DEL CASET. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - ERROR AL CAMBIAR STATUS DEL CASET. " & ex.Message.ToUpper)
            Call fn_MsgBox("Error al cambiar el Status del Caset.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' 25 junio boton eliminar pendiente y sincronia con web
    Public Shared Function fn_Casets_Eliminar(ByVal SerieCaset As String, Sincronizado As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "INICIO - ELIMINAR CASET CON NUMERO DE SERIE: " & SerieCaset)
        Dim Cmd As SqlCommand = Nothing

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            '----Consulta para ver si tiene Depositos el caset seleccionado
            Cmd = Crear_ComandoSQL("DepositosD_Cantidad2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
            Dim CantKct As Integer = Ejecutar_ScalarSQL(Cmd)

            If CantKct > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - NO SE ELIMINÓ EL CASET PORQUE TIENE DEPÓSITOS")
                Return 0
            End If

            If Sincronizado = "N" Then ' si casets no se ha sincronizado todavía entonces eliminar
                Cmd = Crear_ComandoSQL("Casets_Delete", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
                Ejecutar_NonQuerySQL(Cmd)

                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CASET CON NUMERO DE SERIE: " & SerieCaset & "  ELIMINADO CORRECTAMENTE")
                Return 1
            End If

            'Si esta sincronizado pero no hay conexión entonces actualizar status2 A a D
            If Sincronizado = "S" Then
                If Not fn_VerificaConexionInternet() Then

                    Cmd = Crear_ComandoSQL("Casets_Update3", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@StatusAsignar", SqlDbType.VarChar, "D")
                    Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
                    Ejecutar_NonQuerySQL(Cmd)

                    Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CASET CON NUMERO DE SERIE: " & SerieCaset & "  STATUS2 ACTUALIZADO CORRECTAMENTE")
                    Return 1
                End If
            End If
            ' si hay conexioncon de internet primero se va a eliminar caset en la web y depués en local

            If (varPub.ConexionwebAdmin = 1) Then
                If fn_VerificaConexionInternet() Then
                    Try
                        Call fn_SincronizaUltimaConexion()
                        If cls_CashWeb.fn_Elimina_Casets(SerieCaset) Then

                            Cmd = Crear_ComandoSQL("Casets_Delete", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)

                            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                                Cnn.Dispose()
                                Cmd.Dispose()
                                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CASET CON NUMERO DE SERIE: " & SerieCaset & "  ELIMINADO CORRECTAMENTE")
                                Return 1
                            End If

                        Else
                            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - ERROR AL ELIMINAR CASET '" & SerieCaset & "' EN LA WEB")
                            Return -1
                        End If

                    Catch ex As Exception
                        Cnn.Dispose()
                        Cmd.Dispose()

                        Return -1
                    End Try
                End If
            End If

        Catch ex As Exception

            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - ERROR AL ELIMINAR CASETS. " & ex.Message.ToUpper)
            Return -1
        End Try
        Return -1
    End Function

    ''' <summary>
    ''' Función que devuelve la Clave de un Caset
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Casets_GetClave(ByVal IdCaset As Integer) As String
        'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "INICIO CASET OBTENER CLAVE")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "Id_Caset", SqlDbType.Int, IdCaset)

            Dim Clave_Caset As String = Ejecutar_ScalarSQL(Cmd)

            If Clave_Caset <> "" Then
                'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN CASET OBTENER CLAVE")
                Return Clave_Caset
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "ERROR CASET OBTENER CLAVE, ID NO ENCONTRADO")
                Return ""
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "ERROR CASET OBTENER CLAVE: " & ex.Message)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Función que indica si existe o no una Clave de Caset
    ''' </summary>
    ''' <param name="Clave_Caset">Clave de Caset a Revisar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Casets_ClaveExiste(ByVal Clave_Caset As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "INICIO - BUSCAR CLAVE DE CASET EXISTENTE.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, Clave_Caset)
            Dim tabla As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN - CASET CLAVE EXISTE")
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN - ERROR AL VERIFICAR SI CLAVE CASET YA EXISTE. " & ex.Message.ToUpper)
            Return False
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Saber la Cantidad de Registros de Caset
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Casets_Count() As Integer
        'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "INICIO - CONTAR EL NUMERO DE CASETS DISPONIBLES.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_ReadCantidad", CommandType.StoredProcedure, Cnn)

            Dim CantidadCaset As Integer = Ejecutar_ScalarSQL(Cmd)

            Cnn.Dispose()
            Cmd.Dispose()

            If CantidadCaset > 0 Then
                'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - SE ENCONTRARON: " & CantidadCaset & " DISPONIBLES.")
                Return CantidadCaset
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - NO SE ENCONTRARON CASETS EN EL CATÁLOGO.")
                Return 0
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - ERROR AL CONTABILIZAR LOS CASETS. " & ex.Message.ToUpper)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Cargar en Parámetros la Información del Caset a Utilizar
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Casets_GetParametros() As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIO - OBTENER DATOS DEL CASET ")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read4", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "Id_Caset", SqlDbType.Int, varPub.CasetID)
            Dim dt_Caset As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Caset IsNot Nothing AndAlso dt_Caset.Rows.Count > 0 Then
                varPub.Capacidad_Caset = dt_Caset.Rows(0)("Capacidad")
                varPub.Porcentaje_Alerta = dt_Caset.Rows(0)("Porcentaje_Alerta")

                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - SE OBTUVO CORRECTAMENTE INFORMACIÓN DEL CASET.")

                Dim Persistente As New cls_VariablesPersistentes
                Persistente.Persistir()
                If Persistente.Existe Then
                    Persistente.Cargar()
                    Return True
                Else
                    Call fn_MsgBox(" error al Obtener Crear las Variables Persistentes.", MessageBoxIcon.Error)
                    Return False
                End If
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - NO SE PUDO OBTENER INFORMACIÓN DE CASETS.")
                Return False
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - ERROR AL OBTENER DATOS DEL CASET : " & ex.Message.ToUpper)
            Return False
        End Try
    End Function

    Public Shared Function fn_CasetsValores(ByVal IdCaset As Integer) As DataTable
        Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIO - OBTENER DATOS DE CASETS.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read4", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "Id_Caset", SqlDbType.Int, IdCaset)
            Dim dt_Caset As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - SE ENCONTRARON: " & dt_Caset.Rows.Count & " CASETS DISPONIBLES.")
            Return dt_Caset

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - ERROR AL OBTENER DATOS DEL CASET. " & ex.Message.ToUpper)
            Return Nothing
        End Try
    End Function

    Public Shared Function fn_Casets_NumeroserieExiste(ByVal SerieCaset As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "INICIO - CASET CLAVE EXISTE")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read5", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, SerieCaset)
            Dim tabla As DataTable = Ejecutar_ConsultaSQL(Cmd)


            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Return True
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN - CASET NUMERO SERIE EXISTE")
                Return False
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CASETS", "FIN - ERROR CASET NUMERO SERIE EXISTE: " & ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "Denominaciones"

    ''' <summary>
    ''' Llenar la Lista Desplegable de las Monedas
    ''' </summary>
    ''' <param name="cmb">Lista Desplegable que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Denominaciones_LlenarCombo(ByRef cmb As ComboBox)
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DENOMINACIONES", "INICIO - LLENAR COMBO MONEDAS.")

        Try
            Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, cnn)
            Dim dt_Monedas As DataTable = Ejecutar_ConsultaSQL(cmd)
            Dim dr As DataRow = dt_Monedas.NewRow
            dr("Clave_Moneda") = 0
            dr("Nombre_Moneda") = "(Monedas)..."
            dt_Monedas.Rows.InsertAt(dr, 0)

            cmb.ValueMember = "Clave_Moneda"
            cmb.DisplayMember = "Nombre_Moneda"
            cmb.DataSource = dt_Monedas

            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DENOMINACIONES", "FIN - COMBO CARGADO DE MANERA CORRECTA.")
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DENOMINACIONES", "FIN -ERROR AL CARGAR COMBO MONEDAS: " & ex.Message.ToUpper)
        End Try
    End Sub

    ''' <summary>
    ''' Llenar la Lista de las Denominaciones existentes
    ''' </summary>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <param name="ClaveMoneda"> clave moneda por cual filtrar y regresar la lista</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Denominaciones_Llenar(ByRef lsv As ListView, ByVal ClaveMoneda As String)
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DENOMINACIONES", "INICIO - DENOMINACIONES LLENAR LISTA")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, ClaveMoneda)
            Dim dt_Denominacion As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Call fn_LlenarListView(dt_Denominacion, lsv, "", "")
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DENOMINACIONES", "FIN - DENOMINACIONES LLENAR LISTA")
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DENOMINACIONES", "FIN - ERROR DENOMINACIONES LLENAR LISTA: " & ex.Message.ToUpper)
        End Try
    End Sub
    ''' <summary>
    ''' Generear Nuevo Registro de una Denominación
    ''' </summary>
    ''' <param name="Clave_Moneda">Moneda con la que se Relacionará la Denominación</param>
    ''' <param name="Denominacion">Descripcion de la Denominación</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Shared Function fn_Denominaciones_Create(ByVal Denominacion As String, ByVal Clave_Moneda As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "INICIO - DENOMINACIONES CREAR NUEVO")

        'Validaciones
        If Clave_Moneda = "0" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN DENOMINACIONES CREAR NUEVO, CLAVE MONEDA  NO SELECCIONADA")
            Call fn_MsgBox("Seleccione una Moneda.", MessageBoxIcon.Exclamation)
            Return 1
        End If

        If Denominacion.Trim = "" Or CInt(Denominacion) = 0 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN DENOMINACIONES CREAR NUEVO, DENOMINACION NO CAPTURADA")
            Call fn_MsgBox("Capture una Denominación.", MessageBoxIcon.Exclamation)
            Return 2
        End If

        If fn_Denominacion_ClaveExiste(Clave_Moneda & Denominacion.Trim) Then
            Call fn_MsgBox("La clave Denominación ya existe, Capture Otra", MessageBoxIcon.Exclamation)
            Return 3
        End If

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, Clave_Moneda + Denominacion)
            Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Money, Denominacion)
            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, Clave_Moneda)
            Crear_ParametroSQL(Cmd, "@Status_Sincronizado", SqlDbType.VarChar, "N")
            Crear_ParametroSQL(Cmd, "@Fecha_Sincronizado", SqlDbType.VarChar, Nothing)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                If (varPub.ConexionwebAdmin = 1) Then
                    If fn_VerificaConexionInternet() Then
                        Try
                            If cls_CashWeb.fn_GuardaDenominaciones(Clave_Moneda & Denominacion.Trim, Denominacion, Clave_Moneda) Then

                                Cmd = Crear_ComandoSQL("Denominaciones_Update", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, Clave_Moneda + Denominacion)
                                Ejecutar_NonQuerySQL(Cmd)
                                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", " DENOMINACIONES GUARDADO CORRECTAMENTE EN LA BDD CENTRAL")
                            Else
                                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "ERROR AL GUARDAR DENOMINACIONES EN BDD CENTRAL")
                            End If

                            Cmd.Dispose()
                            Cnn.Dispose()
                        Catch ex As Exception
                            Cmd.Dispose()
                            Cnn.Dispose()
                            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "ERROR AL GUARDAR DENOMINACIONES EN BDD CENTRAL" & ex.Message.ToUpper)
                        End Try
                    End If

                Else
                    Cmd.Dispose()
                    Cnn.Dispose()
                End If
                '------------------------------

                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN DENOMINACIONES CREAR NUEVO")
                Call fn_MsgBox("Denominación Guardado Correctamente.", MessageBoxIcon.Information)
                'Call fn_MsgBox("Caset Guardado Correctamente.", MessageBoxIcon.Information)
                Return 0
            Else
                Cmd.Dispose()
                Cnn.Dispose()

                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "Error DENOMINACIONES CREAR NUEVO")
                Call fn_MsgBox("Ocurrió un Error al Agregar la Nueva Denominación.", MessageBoxIcon.Error)
                Return -1
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "Error DENOMINACIONES CREAR NUEVO: " & ex.Message)
            Call fn_MsgBox("Ocurrió un Error al Agregar la Nueva Denominación.", MessageBoxIcon.Error)
        End Try
        Return -1
    End Function

    ''' <summary>
    ''' Eliminar Denominación
    ''' </summary>
    ''' <param name="Clave_Denominacion">Denominacion que se Eliminará</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Denominaciones_Delete(ByVal Clave_Denominacion As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "INICIO - DENOMINACIONES ELIMINAR")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand

            Cmd = Crear_ComandoSQL("DepositosD_Cantidad3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, Clave_Denominacion)
            Dim CantcveDenom As Integer = Ejecutar_ScalarSQL(Cmd)

            If CantcveDenom > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "NO SE ELIMINO DENOMINACION, EXISTE DEPOSITOS.")
                Return 0
            End If

            '----------de otra forma elimina la Denominacion
            Cmd = Crear_ComandoSQL("Denominaciones_Delete", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, Clave_Denominacion)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN DENOMINACIONES ELIMINAR CORRECTO.")
                Return 1
            Else
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "ERROR DENOMINACIONES ELIMINAR: NO SE ELIMINO NINGUN REGISTRO.")
                Return -1
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "ERROR DENOMINACIONES ELIMINAR: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Shared Function fn_Denominacion_ClaveExiste(ByVal ClaveDenomonacion As String) As Boolean
        Try

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Read", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, ClaveDenomonacion)
            Dim dt As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Para saber si existen Denominaciones capturadas
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Denominaciones_VerificarExistencia() As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "INICIO - VERIFICAR SI HAY DENOMINACIONES CAPTURADAS.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Read2", CommandType.StoredProcedure, Cnn)
            Dim dt_Denominaciones As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cnn.Dispose()
            Cmd.Dispose()

            If dt_Denominaciones Is Nothing OrElse dt_Denominaciones.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN - NO EXISTEN DENOMINACIONES CAPTURADAS")
                Return False
            Else
                'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN - DENOMINACIONES CAPTURADAS EN EL CATALOGO.")
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE DENOMINACIONES", "FIN - OCURRIÓ UN ERROR AL CONSULTAR DENOMINACIONES. " & ex.Message.ToUpper)
            Return False
        End Try
    End Function

#End Region

#Region "Monedas"
    ''' <summary>
    ''' Genera Un nuevo Registro en Catalogo Monedas
    ''' </summary>
    ''' <param name="NombreMoneda"></param>
    ''' <param name="Clave_Moneda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Monedas_Create(ByVal Clave_Moneda As String, ByVal NombreMoneda As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "INICIO - MONEDAS CREAR NUEVO")

        'Validaciones
        If Clave_Moneda.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN MONEDA CREAR NUEVO, CLAVE MONEDA NO CAPTURADA")
            Call fn_MsgBox("Captura la Clave de la Nueva Moneda.", MessageBoxIcon.Exclamation)
            Return 1
        End If

        If fn_Monedas_Existe(Clave_Moneda) Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN MONEDA CREAR NUEVO, CLAVE MONEDA YA EXISTE")
            Call fn_MsgBox("Captura otra Clave porque esa ya existe.", MessageBoxIcon.Exclamation)
            Return 1
        End If

        If NombreMoneda.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN MONEDAS CREAR NUEVO, NOMBRE DE MONEDA NO CAPTURADO")
            Call fn_MsgBox("Capture el Nombre de la Nueva Moneda.", MessageBoxIcon.Exclamation)
            Return 2
        End If

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, Clave_Moneda)
            Crear_ParametroSQL(Cmd, "@Nombre_Moneda", SqlDbType.VarChar, NombreMoneda)
            Crear_ParametroSQL(Cmd, "@Sincroniado", SqlDbType.VarChar, "N")
            Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, "1900-01-01")

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then

                If (varPub.ConexionwebAdmin = 1) Then
                    If fn_VerificaConexionInternet() Then
                        Try
                            If cls_CashWeb.fn_GuardaMonedas(Clave_Moneda, NombreMoneda) Then
                                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "GRABA UN REGISTRO MONEDA EN LA  BDD CENTRAL")

                                Cmd = Crear_ComandoSQL("Monedas_Update", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, Clave_Moneda)
                                Ejecutar_NonQuerySQL(Cmd)
                                Cmd.Dispose()
                                Cnn.Dispose()
                            Else
                                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "ERROR AL INTENTAR GRABAR REGISTROS MONEDAS EN LA  BDD CENTRAL.")
                            End If
                        Catch ex As Exception
                            Cmd.Dispose()
                            Cnn.Dispose()
                            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "ERROR AL INTENTAR GRABAR REGISTROS MONEDAS EN LA  BDD CENTRAL." & ex.Message.ToUpper)
                        End Try
                    End If

                Else
                    Cmd.Dispose()
                    Cnn.Dispose()
                End If

                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN MONEDAS CREAR NUEVO")
                Call fn_MsgBox("Moneda guardada Correctamente.", MessageBoxIcon.Information)
                Return 0
            Else
                Cmd.Dispose()
                Cnn.Dispose()

                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN - MONEDAS CREAR NUEVO")
                Call fn_MsgBox("Ocurrió un Error al agregar la Nueva Moneda.", MessageBoxIcon.Error)
                Return -1
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN - MONEDAS CREAR NUEVO: " & ex.Message.ToUpper)
            Call fn_MsgBox("Ocurrió un Error al agregar la Nueva Moneda.", MessageBoxIcon.Error)
        End Try
        Return -1
    End Function

    ''' <summary>
    ''' Eliminacion de la Moneda
    ''' </summary>
    ''' <param name="Clave_Moneda"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Monedas_Delete(ByVal Clave_Moneda As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "INICIO - MONEDAS ELIMINAR")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_ReadUltimo", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, Clave_Moneda)
            Dim CantMonedas As Integer = Ejecutar_ScalarSQL(Cmd)

            If CantMonedas > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "NO SE PUDO ELIMINAR MONEDA, EXISTEN DENOMINACIONES.")
                Return 0
            End If

            '---Elimina Moneda si hay 0 denomnaciones

            Cmd = Crear_ComandoSQL("Monedas_Delete", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, Clave_Moneda)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN MONEDAS ELIMINAR CORRECTO.")
                Return 1
            Else
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "ERROR MONEDAS ELIMINAR: NO SE ELIMINO NINGUN REGISTRO.")
                Return -1
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE MONEDAS", "FIN - MONEDAS ELIMINAR: " & ex.Message)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Llenar el listview con el Catálogo Monedas
    ''' </summary>
    ''' <param name="lsv"></param>
    ''' <remarks></remarks>

    Public Shared Sub fn_Monedas_Llenar(ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "INICIO -LLENAR LISTA")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_Denominacion As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Call fn_LlenarListView(dt_Denominacion, lsv, "", "")
            Dim w As Integer = (lsv.Width / 4)
            lsv.Columns(0).Width = w
            lsv.Columns(1).Width = w

            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - CONSULTA CORRECTA.")
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - OCURRIÓ UN ERROR AL CARGAR MONEDAS." & ex.Message.ToUpper)
        End Try
    End Sub

    Public Shared Function fn_Monedas_Existe(ByVal ClaveMoneda As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "INICIO - BUSCAR SI EXISTE CLAVE.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, ClaveMoneda)
            Dim dt_Monedas As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If dt_Monedas IsNot Nothing AndAlso dt_Monedas.Rows.Count > 0 Then
                Return True
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - LA MONEDA YA EXISTE.")
            Else
                Return False
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - MONEDA NO ENCONTRADA, PUEDE USARSE.")
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - ERROR AL VERIFICAR SI EXISTE LA MONEDA A AGREGAR" & ex.Message.ToUpper)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Para saber si existen Monedas capturadas
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Monedas_VerificarExistencia() As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "INICIO - VERIFICAR SI EXISTEN MONEDAS CAPTURADAS.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_Monedas As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Cnn.Dispose()
            Cmd.Dispose()

            If dt_Monedas Is Nothing OrElse dt_Monedas.Rows.Count = 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - NO EXISTEN MONEDAS CAPTURADAS.")
                Return False
            Else
                'Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - SI EXISTEN MONEDAS EN EL CATALOGO.")
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO MONEDAS", "FIN - OCURRIÓ UN ERROR AL CONSULTAR MONEDAS. " & ex.Message.ToUpper)
            Return False
        End Try
    End Function

#End Region

#Region "Consulta Log"

    ''' <summary>
    ''' Llenar la Lista de Detalle con todos las Acciones Realizadas
    ''' </summary>
    ''' <param name="lsv">Lista que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_ConsultaDetalle_Llenar(ByVal Nombre_Archivo As String, ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA LOG", "Inicio CONSULTA LOG")
        Try
            Dim Linea As String = ""
            Dim Archivo As IO.StreamReader = Nothing
            Dim Arreglo() As String
            Dim dt_Log As New DataTable
            dt_Log.Columns.Add("Fecha", GetType(System.String))
            dt_Log.Columns.Add("Hora", GetType(System.String))
            dt_Log.Columns.Add("Usuario", GetType(System.String))
            dt_Log.Columns.Add("Ventana", GetType(System.String))
            dt_Log.Columns.Add("Descripción", GetType(System.String))

            Archivo = New IO.StreamReader(varPub.Ruta_Log & "\" & Nombre_Archivo)

            Do
                If Archivo Is Nothing Then Exit Do

                Linea = Archivo.ReadLine()
                If Linea Is Nothing Then Exit Do
                Arreglo = Split(Linea, "%")
                Dim row As DataRow = dt_Log.NewRow()
                row("Fecha") = Arreglo(0)
                row("Hora") = Arreglo(1)
                row("Usuario") = Arreglo(2)
                row("Ventana") = Arreglo(3)
                row("Descripción") = Arreglo(4)
                dt_Log.Rows.Add(row)

            Loop Until Linea Is Nothing
            Archivo.Close()
            Archivo.Dispose()
            Archivo = Nothing

            Call fn_LlenarListView(dt_Log, lsv, "", "")

            ' Archivo.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA LOG", "Fin CONSULTA LOG")
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CONSULTA LOG", "Error CONSULTA LOG: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Parámetros"

    ''' <summary>
    ''' Validación para revisar la existencia del Archivo Persistente
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Shared Function fn_Parametros_Validar() As Boolean
        Dim Persistente As New cls_VariablesPersistentes

        If Not Persistente.Existe Then
            'Se manda Id = 1 debido a que se especifica que se abra cuando no existe el XML
            Call fn_Menus_Open(8, 1)
        Else
            Persistente.Cargar()
        End If
        Return Persistente.Existe
    End Function

    ''' <summary>
    ''' Llenar la Lista Desplegable de los Casets
    ''' </summary>
    ''' <param name="cmb">Lista Desplegable que se Llenará con la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub fn_Parametros_LlenarCombo(ByRef cmb As ComboBox)
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read6", CommandType.StoredProcedure, Cnn)
            Dim dt_Casets As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Cmd.Dispose()
            Cnn.Dispose()

            Dim dr As DataRow = dt_Casets.NewRow
            dr("Id_Caset") = 0
            dr("Clave_Caset") = "(Caset)..."
            dt_Casets.Rows.InsertAt(dr, 0)

            cmb.ValueMember = "Id_Caset"
            cmb.DisplayMember = "Clave_Caset"
            cmb.DataSource = dt_Casets
        Catch ex As Exception
            cmb.DataSource = Nothing
            Dim dt As DataTable = New DataTable
            dt.Columns.Add("Id_Caset")
            dt.Columns.Add("Clave_Caset")
            dt.Rows.Add(0, "(Caset)...")
            cmb.ValueMember = "Id_Caset"
            cmb.DisplayMember = "Clave_Caset"
            cmb.DataSource = dt

            Call fn_MsgBox(" error al Intentar Llenar la Lista Desplegable de Casets.", MessageBoxIcon.Error & ex.Message.ToUpper)
        End Try
    End Sub
    'Public Shared Function fn_configuracion(ByVal p1, ByVal p2, ByVal p3, ByVal p4, ByVal p5, ByVal p6, ByVal p7, ByVal p8, ByVal p9, ByVal p10, ByVal p11, ByVal p12, ByVal p13, ByVal p14, ByVal p15, ByVal p16,
    '                                        ByVal p17, ByVal p18, ByVal p19, ByVal p20, ByVal p21, ByVal p22, ByVal p23, ByVal p24, ByVal p25, ByVal p26, ByVal p27, ByVal p28, ByVal p29, ByVal p30, ByVal p31, ByVal p32,
    '                                        ByVal p33, ByVal p34, ByVal p35, ByVal p36, ByVal p37, ByVal p38, ByVal p39, ByVal p40, ByVal p41, ByVal p42, ByVal p43, ByVal p44, ByVal p45, ByVal p46, ByVal p47, ByVal p48,
    '                                        ByVal p49, ByVal p50, ByVal p51, ByVal p52, ByVal p53, ByVal p54, ByVal p55, ByVal p56, ByVal p57, ByVal p58, ByVal p59, ByVal p60, ByVal p61, ByVal p62, ByVal p63, ByVal p64,
    '                                        ByVal p65, ByVal p66, ByVal p67, ByVal p68, ByVal p69, ByVal p70, ByVal p71, ByVal p72, ByVal p73, ByVal p74, ByVal p75, ByVal p76, ByVal p77, ByVal p78, ByVal p79)
    '    Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
    '    Dim Cmd As SqlCommand = Crear_ComandoSQL("Configuracion_Create", CommandType.StoredProcedure, Cnn)
    '    Crear_ParametroSQL(Cmd, "@Id_configuracion", SqlDbType.Int, p1)
    '    Crear_ParametroSQL(Cmd, "@Modo_Impresion", SqlDbType.Int, p2)
    '    Crear_ParametroSQL(Cmd, "@Logo_EmpresaRuta", SqlDbType.VarChar, p3)
    '    Crear_ParametroSQL(Cmd, "@Imprimir_DetalleCD", SqlDbType.Bit, p4)
    '    Crear_ParametroSQL(Cmd, "@hostNameOrAddress", SqlDbType.VarChar, p5)
    '    Crear_ParametroSQL(Cmd, "@VersionCashFlow", SqlDbType.VarChar, p6)
    '    Crear_ParametroSQL(Cmd, "@InicioOperaciones", SqlDbType.Date, p7)
    '    Crear_ParametroSQL(Cmd, "@Mail_Sucursal", SqlDbType.VarChar, p8)
    '    Crear_ParametroSQL(Cmd, "@LimiteCapacidad_Kct2", SqlDbType.Int, p9)
    '    Crear_ParametroSQL(Cmd, "@LimiteCapacidad_Kct", SqlDbType.Int, p10)
    '    Crear_ParametroSQL(Cmd, "@AnchoPantalla", SqlDbType.Int, p11)
    '    Crear_ParametroSQL(Cmd, "@AltoPantalla", SqlDbType.Int, p12)
    '    Crear_ParametroSQL(Cmd, "@Tipo_Windows", SqlDbType.Int, p13)
    '    Crear_ParametroSQL(Cmd, "@Cant_Validadores", SqlDbType.Int, p14)
    '    Crear_ParametroSQL(Cmd, "@Activar_Val1", SqlDbType.Bit, p15)
    '    Crear_ParametroSQL(Cmd, "@Serie_Caset1", SqlDbType.VarChar, p16)
    '    Crear_ParametroSQL(Cmd, "@Serie_Val1", SqlDbType.VarChar, p17)
    '    Crear_ParametroSQL(Cmd, "@Puerto_Val1", SqlDbType.VarChar, p18)
    '    Crear_ParametroSQL(Cmd, "@Capacidad_Caset", SqlDbType.Int, p19)
    '    Crear_ParametroSQL(Cmd, "@Capacidad_Actual", SqlDbType.Int, p20)
    '    Crear_ParametroSQL(Cmd, "@CasetID", SqlDbType.Int, p21)
    '    Crear_ParametroSQL(Cmd, "@Porcentaje_Alerta", SqlDbType.Int, p22)
    '    Crear_ParametroSQL(Cmd, "@Activar_Val2", SqlDbType.Bit, p23)
    '    Crear_ParametroSQL(Cmd, "@Serie_Caset2", SqlDbType.VarChar, p24)
    '    Crear_ParametroSQL(Cmd, "@Serie_Val2", SqlDbType.VarChar, p25)
    '    Crear_ParametroSQL(Cmd, "@Puerto_Val2", SqlDbType.VarChar, p26)
    '    Crear_ParametroSQL(Cmd, "@Capacidad_Caset2", SqlDbType.Int, p27)
    '    Crear_ParametroSQL(Cmd, "@Capacidad_Actual2", SqlDbType.Int, p28)
    '    Crear_ParametroSQL(Cmd, "@Caset2ID", SqlDbType.Int, p29)
    '    Crear_ParametroSQL(Cmd, "@Porcentaje_Alerta2", SqlDbType.Int, p30)
    '    Crear_ParametroSQL(Cmd, "@MargenIzq", SqlDbType.Int, p31)
    '    Crear_ParametroSQL(Cmd, "@Dias_Expira", SqlDbType.Int, p32)
    '    Crear_ParametroSQL(Cmd, "@TimeOut_Receptor", SqlDbType.VarChar, p33)
    '    Crear_ParametroSQL(Cmd, "@TimeOut_Sesion", SqlDbType.VarChar, p34)
    '    Crear_ParametroSQL(Cmd, "@Ult_Archivo", SqlDbType.VarChar, p35)
    '    Crear_ParametroSQL(Cmd, "@U_dtb", SqlDbType.VarChar, p36)
    '    Crear_ParametroSQL(Cmd, "@P_dtb ", SqlDbType.VarChar, p37)
    '    Crear_ParametroSQL(Cmd, "@B_dtb", SqlDbType.VarChar, p38)
    '    Crear_ParametroSQL(Cmd, "@S_dtb", SqlDbType.VarChar, p39)
    '    Crear_ParametroSQL(Cmd, "@Ruta_Log", SqlDbType.VarChar, p40)
    '    Crear_ParametroSQL(Cmd, "@TamañoFuente_Mensajes", SqlDbType.Int, p41)
    '    Crear_ParametroSQL(Cmd, "@TamañoFuente_Etiqueta", SqlDbType.Int, p42)
    '    Crear_ParametroSQL(Cmd, "@TamañoFuente_Botones", SqlDbType.Int, p43)
    '    Crear_ParametroSQL(Cmd, "@Tamaño_Papel", SqlDbType.Int, p44)
    '    Crear_ParametroSQL(Cmd, "@Cve_Sucursal", SqlDbType.Int, p45)
    '    Crear_ParametroSQL(Cmd, "@Cve_Cliente", SqlDbType.VarChar, p46)
    '    Crear_ParametroSQL(Cmd, "@Nombre_Sucursal", SqlDbType.VarChar, p47)
    '    Crear_ParametroSQL(Cmd, "@Conectividad", SqlDbType.Bit, p48)
    '    Crear_ParametroSQL(Cmd, "@ConexionwebAdmin", SqlDbType.Int, p49)
    '    Crear_ParametroSQL(Cmd, "@Num_LineasBlanco", SqlDbType.Int, p50)
    '    Crear_ParametroSQL(Cmd, "@Num_CopiasImprimir", SqlDbType.Int, p51)
    '    Crear_ParametroSQL(Cmd, "@Prioridad_Priv", SqlDbType.Int, p52)
    '    Crear_ParametroSQL(Cmd, "@Cliente", SqlDbType.VarChar, p53)
    '    Crear_ParametroSQL(Cmd, "@Direccion", SqlDbType.VarChar, p54)
    '    Crear_ParametroSQL(Cmd, "@Nombre_Corto", SqlDbType.VarChar, p55)
    '    Crear_ParametroSQL(Cmd, "@Telefono", SqlDbType.VarChar, p56)
    '    Crear_ParametroSQL(Cmd, "@CiaTV", SqlDbType.VarChar, p57)
    '    Crear_ParametroSQL(Cmd, "@ID_DepositoP", SqlDbType.Int, p58)
    '    Crear_ParametroSQL(Cmd, "@ID_UltimoRetiro", SqlDbType.Int, p59)
    '    Crear_ParametroSQL(Cmd, "@cnx_SucursalWeb", SqlDbType.VarChar, p60)
    '    Crear_ParametroSQL(Cmd, "@CUNICA", SqlDbType.VarChar, p61)
    '    Crear_ParametroSQL(Cmd, "@Comprobacion", SqlDbType.VarChar, p62)
    '    Crear_ParametroSQL(Cmd, "@VersionNvo", SqlDbType.VarChar, p63)
    '    Crear_ParametroSQL(Cmd, "@VersionAnt", SqlDbType.VarChar, p64)
    '    Crear_ParametroSQL(Cmd, "@ManejaCorte", SqlDbType.Int, p65)
    '    Crear_ParametroSQL(Cmd, "@CorteActual", SqlDbType.Int, p66)
    '    Crear_ParametroSQL(Cmd, "@TipoMonedaV1", SqlDbType.VarChar, p67)
    '    Crear_ParametroSQL(Cmd, "@TipoMonedaV2", SqlDbType.VarChar, p68)
    '    Crear_ParametroSQL(Cmd, "@Cantidad_Cajas", SqlDbType.Int, p69)
    '    Crear_ParametroSQL(Cmd, "@ManejaConexionWebService", SqlDbType.Int, p70)
    '    Crear_ParametroSQL(Cmd, "@PorcentajeBateriabaja", SqlDbType.Int, p71)
    '    Crear_ParametroSQL(Cmd, "@PorcentajeBateriaCritica", SqlDbType.Int, p72)
    '    Crear_ParametroSQL(Cmd, "@BateriaBaja", SqlDbType.Bit, p73)
    '    Crear_ParametroSQL(Cmd, "@BateriaCritica", SqlDbType.Bit, p74)
    '    Crear_ParametroSQL(Cmd, "@PuertoSensores", SqlDbType.VarChar, p75)
    '    Crear_ParametroSQL(Cmd, "@ManejaDepositoManual", SqlDbType.Bit, p76)
    '    Crear_ParametroSQL(Cmd, "@ManejaFolioManual", SqlDbType.Bit, p77)
    '    Crear_ParametroSQL(Cmd, "@ValidarFolio", SqlDbType.Bit, p78)
    '    Crear_ParametroSQL(Cmd, "@Conexion", SqlDbType.Int, p79)
    '    Ejecutar_NonQuerySQL(Cmd)
    'End Function
    ''' <summary>
    ''' Crear los Parámetros y Cargar las Variables Globales
    ''' </summary>
    ''' <param name="MsgFuente">Tamaño de la Fuente del Texto en los Menajes</param>
    ''' <param name="LblFuente">Tamaño de la Fuente de las etiquetas</param>
    ''' <param name="CmdFuente">Tamaño de la Fuente de los Botones de Comando</param>
    ''' <param name="SizePapel">Tamaño de papel usado en la Impresora</param>
    ''' <param name="Cia_Tv">Compañía de Traslado que realizará los Retiros</param>
    ''' <param name="Id_Caset">Caset a Utilizar</param>
    ''' <param name="Nombre" > Nombre del Cliente para imprimir en los tickets</param>
    ''' <param name="Ubicacion">Direccion del cliente para imprimir en los tickets</param>
    ''' <param name="Contacto" >Telefono del cliente para imprimir en los tickets</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Shared Function fn_Parametros_Crear(ByVal MsgFuente As Integer, ByVal LblFuente As Integer, ByVal CmdFuente As Integer,
                                               ByVal SizePapel As Byte, ByVal Cia_Tv As String, ByVal Id_Caset As Integer,
                                               ByVal Nombre As String, ByVal Ubicacion As String, ByVal Contacto As String,
                                               ByVal ServDatos As String, ByVal BasedDatos As String, ByVal Userbd As String,
                                               ByVal Contrabd As String, ByVal ClaveSucursal As String, ByVal ConectividadWeb As Integer,
                                               ByVal NombreSucursal As String, ByVal ClaveCliente As String, ByVal RutaLog As String,
                                               ByVal TimeOutReceptor As Integer, ByVal TimeOutSesion As Integer, ByVal diasExpira As Integer,
                                               ByVal cnx_Web As String, ByVal ClaveUnika As String, ByVal MargenI As Integer,
                                               ByVal NumValid As Byte, ByVal serieVal1 As String, ByVal serieVal2 As String,
                                               ByVal Id_Caset2 As Integer, ByVal puertoVal1 As String,
                                               ByVal puertoVal2 As String, ByVal NombreCorto As String, ByVal tipowin As Byte,
                                               ByVal Val1Activado As Integer, ByVal Val2Activado As Integer,
                                               ByVal prioridadpriv As Byte, ByVal limiteCapKct As Integer,
                                               ByVal limiteCapKct2 As Integer, ByVal Conectado As Byte,
                                               ByVal numCopiasImprimir As Byte, ByVal numLineasenBlanco As Byte,
                                               ByVal mailSucursal As String, ByVal FechaInicoOp As Date, ByVal nombrehostIP As String,
                                               ByVal ImprimirDetalleCD As Integer, ByVal ModoImprime As Byte,
                                               ByVal PorcBateriaBaja As Integer, ByVal PorcBateriaCritica As Integer,
                                               ByVal PuertoSensores As String, ByVal ManejaDepositoManual As Integer,
                                               ByVal FolioManual As Integer, ByVal validarfolio As Integer, ByVal Trabajar_sin As Integer, Id_cajero As String,
                                               ByVal Plaza As String) As Boolean
        Try
            'Pasa variables de la funcion a VAriablesGlobales

            varPub.Modo_Impresion = ModoImprime
            varPub.Imprimir_DetalleCD = ImprimirDetalleCD
            varPub.Inicio_Operaciones = FechaInicoOp
            varPub.Mail_Sucursal = mailSucursal
            varPub.hostNameOrAddress = nombrehostIP
            varPub.Num_CopiasImprimir = numCopiasImprimir
            varPub.Num_LineasBlanco = numLineasenBlanco
            varPub.LimiteCapacidad_Kct2 = limiteCapKct2
            varPub.LimiteCapacidad_Kct = limiteCapKct
            varPub.Activar_Val1 = Val1Activado
            varPub.Activar_Val2 = Val2Activado
            varPub.ConexionwebAdmin = Conectado 'para habilitar si habra conexion web por administrador
            varPub.Prioridad_Priv = prioridadpriv
            varPub.Conectividad = ConectividadWeb
            varPub.cnx_SucursalWeb = cnx_Web
            varPub.CUNICA = ClaveUnika
            varPub.MargenIzq = MargenI
            varPub.Cant_Validadores = NumValid
            varPub.Serie_Val1 = serieVal1
            varPub.Serie_Val2 = serieVal2
            varPub.Caset2ID = Id_Caset2
            varPub.Puerto_Val1 = puertoVal1
            varPub.Puerto_Val2 = puertoVal2
            varPub.Nombre_Corto = NombreCorto
            varPub.Tipo_Windows = tipowin
            varPub.TamañoFuente_Mensajes = MsgFuente
            varPub.TamañoFuente_Etiqueta = LblFuente
            varPub.TamañoFuente_Botones = CmdFuente
            varPub.Tamaño_Papel = SizePapel
            varPub.S_dtb = ServDatos
            varPub.B_dtb = BasedDatos
            varPub.U_dtb = Userbd
            varPub.P_dtb = Contrabd
            varPub.Cve_Sucursal = ClaveSucursal
            varPub.Cve_Cliente = ClaveCliente
            varPub.Nombre_Sucursal = NombreSucursal
            varPub.Ruta_Log = RutaLog
            varPub.Ult_Archivo = varPub.Ult_Archivo '-- pendiente
            varPub.TimeOut_Receptor = TimeOutReceptor
            varPub.TimeOut_Sesion = TimeOutSesion
            varPub.Dias_Expira = diasExpira
            varPub.CiaTV = Cia_Tv
            varPub.CasetID = Id_Caset
            varPub.Cliente = Nombre
            varPub.Direccion = Ubicacion
            varPub.Telefono = Contacto
            varPub.PorcentajeBateriaBaja = PorcBateriaBaja
            varPub.PorcentajeBateriaCritica = PorcBateriaCritica
            varPub.PuertoSensores = PuertoSensores
            varPub.ManejaDepositoManual = ManejaDepositoManual
            varPub.ManejaFolioManual = FolioManual
            varPub.ValidarFolio = validarfolio
            varPub.Trabajar_sin = Trabajar_sin
            varPub.Id_Caje = Id_cajero
            varPub.Plaza = Plaza
            'varPub.Conexion = conexion

            '-----por si modifica parametros y hay procesos pendientes
            If varPub.ID_DepositoP <> 0 Then
                'queda igual
            Else
                varPub.ID_DepositoP = 0
            End If

            If varPub.ID_UltimoRetiro <> 0 Then
                'queda igual
            Else
                varPub.ID_UltimoRetiro = 0
            End If
            '--------------
            Dim Persistente As New cls_VariablesPersistentes
            Persistente.Persistir()
            If Persistente.Existe Then
                Persistente.Cargar()
                Return True
            Else
                Call fn_MsgBox("Ocurrió un error al intentar crear las Variables Persistentes.", MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " ERROR AL GUARDAR LOS VALORES ESTABLECIDOS.")
            Call fn_MsgBox("Al Guardar las Variables Persistentes ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

#End Region

#Region "Limpiar Tablas de Base De Datos SQL Server"

    Public Shared Function fn_LimpiarTablas_BDDLocal() As Boolean
        'Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        'Dim tr As SqlCeTransaction = Crear_TransSQLCE(cnn)
        'Dim Query As String = ""
        'Dim cmd As SqlCeCommand = Nothing
        'Try
        '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "INICIO - BORRAR CONTENIDO DE TABLAS BDD")

        '    '--LImpiar arriba en web si hay conectividad y luego  abajo.
        '    If (varPub.Conectividad = True) Then
        '        If fn_VerificaConexionInternet() Then Return False
        '        If cls_CashWeb.fn_TablasBorrar_BDDWeb() = False Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "FIN - NO SE PUDIERON BORRAR TABLAS, NO HUBO CONEXION A INTERNET")
        '            Return False
        '        End If
        '    End If

        '    ' ALTER TABLE [TableName] ALTER COLUMN ID IDENTITY (1,1)”
        '    'DBCC CHECKIDENT (<nombre_tabla>, RESEED,0)

        '    '----Elimina DepositosD {Detalle Depositos}
        '    Query = "Delete DepositosD"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '----Elimina Depositos {Depositos}
        '    Query = "Delete Depositos"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Depositos Alter Column Id_Deposito Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '----Elimina RetirosD {Detalle RetirosD}
        '    Query = "Delete RetirosD"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '----Elimina Retiros {Retiros}
        '    Query = "Delete Retiros"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Retiros Alter Column Id_Retiro Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '////////FALTA SI BORRAMOS EN WEB
        '    '-----Elimina Casets
        '    Query = "Delete Casets"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Casets Alter Column Id_Caset Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    ''-----Elimna Monedas
        '    'Query = "Delete Monedas"
        '    'cmd = Crea_ComandoT(cnn, tr, CommandType.Text, Query)
        '    'EjecutarNonQueryT(cmd)

        '    ''-----Elimina Denominaciones
        '    'Query = "Delete Denominaciones"
        '    'cmd = Crea_ComandoT(cnn, tr, CommandType.Text, Query)
        '    'EjecutarNonQueryT(cmd)

        '    '-----Elimina Usuarios 'el 9250 es fijo ,agregado desde la bdd Local del SQL Compact
        '    Query = "Delete Usuarios " & _
        '            "Where Clave_Usuario <> 925074 " & _
        '            "And Clave_Usuario <>491752"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '-----Elimina Privilegios Local, luego de haber borrado en web 17/01/2014 3:57pm
        '    Query = "Delete Privilegios " & _
        '                " Where Clave_Usuario <> 491752"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '-----Elimina el Tipo de Cambio y reinicia el identity
        '    Query = "Delete TipoCambio "
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table TipoCambio Alter Column Id_TC Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    tr.Commit()
        '    tr.Dispose()
        '    cmd.Dispose()
        '    cnn.Dispose()
        '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "TABLAS BORRADOS CORRECTAMENTE")
        '    Return True
        '    '--------------------
        'Catch ex As Exception
        '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "ERROR AL BORRAR TABLAS DE BDD" & ex.Message.ToUpper)
        '    tr.Rollback() 'Rehacer transaccion
        '    cmd.Dispose()
        '    cnn.Dispose()
        '    Return False
        'End Try
        Return False
    End Function

#End Region

#Region "Borrar contenido de Tablas de Depositos y Retiros"
    Public Shared Function fn_LimpiarTablas_DepositosRetiros() As Boolean
        'Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)

        'Dim tr As SqlCeTransaction = Crear_TransSQLCE(cnn)
        'Dim Query As String = ""
        'Dim cmd As SqlCeCommand = Nothing
        'Try
        '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "INICIO - BORRAR CONTENIDO DE TABLAS DEPOSITOS Y RETIROS")

        '    If varPub.Conectividad = True Then
        '        If fn_VerificaConexionInternet() = False Then Return False
        '        If cls_CashWeb.fn_DepositosRetirosBorrar_BDDWeb() = False Then
        '            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "FIN -  ERROR AL BORRAR TABLAS DEPOSITOS Y RETIROS EN LA BDD WEB.")
        '            Return False
        '        End If
        '    End If

        '    '-----------------
        '    ' ALTER TABLE [TableName] ALTER COLUMN ID IDENTITY (1,1)"
        '    'DBCC CHECKIDENT (<nombre_tabla>, RESEED,0)

        '    '----Elimina DepositosD {Detalle Depositos}
        '    Query = "Delete DepositosD"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '----Elimina Depositos {Depositos}
        '    Query = "Delete Depositos"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Depositos Alter Column Id_Deposito Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '----Elimina RetirosD {Detalle RetirosD}
        '    Query = "Delete RetirosD"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    '----Elimina Retiros {Retiros}
        '    Query = "Delete Retiros"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Retiros Alter Column Id_Retiro Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Delete Cajas"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Cajas Alter Column Id_Caja Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Delete Corte"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    Query = "Alter Table Corte Alter Column Id_Corte Identity (1,1)"
        '    cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
        '    Ejecutar_NonQueryTSQLCE(cmd)

        '    tr.Commit()
        '    tr.Dispose()
        '    cmd.Dispose()
        '    cnn.Dispose()
        '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "FIN - TABLA BORRADAS CORRECTMENTE DEPOSITOS Y RETIROS")

        '    Return True
        '    '--------------------
        'Catch ex As Exception
        '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "FIN - ERROR AL BORRAR TABLAS DEPOSITOS Y RETIROS" & ex.Message.ToUpper)

        '    tr.Rollback() 'Rehacer transaccion
        '    cmd.Dispose()
        '    cnn.Dispose()
        '    Return False
        'End Try
        Return False
    End Function

#End Region


#Region "Sincronizacion Basedatos Web y Local"
    'funcion verifica bandera de ACTuALIZACION 
    ' y bandera de respaldar bdd.
    Public Shared Function fn_ActualizarRespaldar_Verificar(ByVal tipoAccion As AccionWeb) As String
        'jmcb Call fn_EscribirLog(varPub.UsuarioClave, "---", "INICIO - VERIFICAR SI EXISTE ACTUALIZACIÓN O SI SE DEBE RESPALDAR BDD.")

        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim cmd As SqlCommand = Nothing
        Dim Query As String = ""
        Dim Actual_Resp As String = ""
        Try
            Query = "Select Actualizar, Respaldar  " &
                    "From Sucursales " &
                    "Where Clave_Sucursal='" & varPub.Cve_Sucursal & "'"
            cmd = Crear_ComandoSQL(Query, CommandType.Text, cnn)
            Dim dt As DataTable = Ejecutar_ConsultaSQL(cmd)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then


                Select Case tipoAccion
                    Case AccionWeb.Actualizar
                        Actual_Resp = dt.Rows(0)("Actualizar").ToString
                        ' si Actualizar='S' entonces, consultar y decodificar
                        If Actual_Resp = "S" Then Call fn_Obtieneparametros_ftp()
                        'jmcb Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - EXISTE ACTUALIZACIÓN = " & Actual_Resp)

                    Case AccionWeb.Respaldar
                        Actual_Resp = dt.Rows(0)("Respaldar").ToString
                        ' si Respaldar='S' entonces, consultar y decodificar
                        If Actual_Resp = "S" Then Call fn_Obtieneparametros_ftp()
                        Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - SE DEBE RESPALDAR LA BDD = " & Actual_Resp)
                End Select

            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - EL CAMPO ES NULL O VACIO.")
            End If

            Return Actual_Resp
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - ERROR AL VERIFICAR ACTUALIZACIÓN Y/O RESPALDO." & ex.Message.ToUpper)
            Return String.Empty
        End Try

    End Function

    Public Shared Function fn_Obtieneparametros_ftp() As String
        Call fn_EscribirLog(varPub.UsuarioClave, "---", "INICIO - ESTABLECER CONEXION CON EL SERVIDOR CENTRAL Y OBTENER PARAMETROS DE CONEXIÓN FTP.")

        Dim conex As SqlConnection
        Dim Query As String = ""
        Dim Cadena As String = ""
        Dim cmd As SqlCommand
        Try
            '1.-Armar la cadena de conexion a la bdd central web(conexion-->bdd sbdsis)
            Query = "Data Source=" & varPub.S_dtb &
                     ";Initial Catalog=" & varPub.B_dtb &
                     ";User Id=" & varPub.U_dtb &
                     ";Password=" & varPub.P_dtb & ";"
            conex = Crear_ConexionSQL(Query)

            '2.-Probar la Conexion web
            conex.Open()
            conex.Close()

            '3.-Realizar la Consulta y verificar el resultado
            Query = "Select SVR, " &
                    "USR, " &
                    "PWD " &
                    "From CNNCTES " &
                   "Where CUNICA='" & varPub.CUNICA & "' And TIPO_CONEXION=2"

            cmd = Crear_ComandoSQL(Query, CommandType.Text, conex)

            Dim dt_Conex As DataTable = Ejecutar_ConsultaSQL(cmd)

            If dt_Conex IsNot Nothing AndAlso dt_Conex.Rows.Count > 0 Then
                'Si traemos un Registro entonces vamos a Desencriptar los parametros de conexion ftp
                'User,Pass,Servidor y almacenarlas en variables publikas para hacer la conexion

                varPub.Ubicacion_ftp = fn_Decode(dt_Conex.Rows(0)("SVR"))
                varPub.Usuario_ftp = fn_Decode(dt_Conex.Rows(0)("USR"))
                varPub.Password_ftp = fn_Decode(dt_Conex.Rows(0)("PWD"))
                Cadena = varPub.Ubicacion_ftp & "%" & varPub.Usuario_ftp & "%" & varPub.Password_ftp
                Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - SE OBTUVO CORRECTAMENTE LOS PARAMETROS DE CONEXION FTP.")
            End If

            Return Cadena
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "---", "FIN - ERROR AL CONECTARSE CON EL SERVIDOR CENTRAL." & ex.Message.ToUpper)
            Return "ERROR"
        End Try
    End Function

    Public Shared Function fn_ConectaServidorWeb(ByVal NombreServ As String, ByVal BaseDatos As String, ByVal UserBD As String, ByVal ContraBD As String, ByVal ClaveUnica As String) As String
        Call fn_EscribirLog(varPub.UsuarioClave, "---", "INICIO - ESTABLECER CONEXION CON EL SERVIDOR CENTRAL.")

        Dim conex As SqlConnection
        Dim Query As String = ""
        Dim Cadena As String = ""
        Dim cmd As SqlCommand
        Try
            '1.-Armar la cadena de conexion a la bdd central web
            Query = "Data Source=" & NombreServ &
                     " ;Initial Catalog=" & BaseDatos &
                     ";User Id=" & UserBD &
                     ";Password=" & ContraBD & ";"
            conex = Crear_ConexionSQL(Query)

            '2.-Probar la Conexion web
            conex.Open()
            conex.Close()

            '3.-Realizar la Consulta al Server Central.
            Query = "Select NCOMERCIAL, " &
                    "SVR, " &
                    "BD, " &
                    "USR, " &
                    "PWD " &
                    "From CNNCTES " &
                    "Where CUNICA='" & ClaveUnica & "' And TIPO_CONEXION=1"
            cmd = Crear_ComandoSQL(Query, CommandType.Text, conex)
            Dim dt_Conex As DataTable = Ejecutar_ConsultaSQL(cmd)

            If dt_Conex IsNot Nothing AndAlso dt_Conex.Rows.Count > 0 Then
                'Si traemos un Registro entonces vamos a Desencriptar los parametros de conexion
                'User,Bdd,Servidor y Bdd para poder conectarnos
                Cadena = "Data Source=" & fn_Decode(dt_Conex.Rows(0)("SVR")) & ";Initial Catalog=" & fn_Decode(dt_Conex.Rows(0)("BD")) &
                ";User Id=" & fn_Decode(dt_Conex.Rows(0)("USR")) & ";Password=" & fn_Decode(dt_Conex.Rows(0)("PWD")) & ";"
                Cadena = Cadena & "/" & dt_Conex.Rows(0)("NCOMERCIAL")
                Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - LA CONEXIÓN CON EL SERVIDOR CENTRAL SE REALIZÓ CORRECTAMENTE, SE OBTUVO EL CORPORATIVO: " & dt_Conex.Rows(0)("NCOMERCIAL"))
            End If

            Return Cadena
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "FIN - ERROR AL CONECTARSE CON EL SERVIDOR CENTRAL." & ex.Message.ToUpper)
            Return "ERROR"
        End Try
    End Function

    Public Shared Function fn_Actualizar_aWEB() As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "INICIO - SINCRONIZAR DEPOSITOS EN LA BDD WEB.")

        Try
            ' Solo consulta lo que no esta Sincronizado.
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_Read3", CommandType.StoredProcedure, Cnn)
            Dim dt_DepositosId As DataTable = Ejecutar_ConsultaSQL(Cmd)
            'Call fn_EscribirLog(UsuarioClave, "SINCRONIZAR DEPÓSITOS", "Consulta Correcta en BDD Local con exito para Sacar ID_deposito donde Sincronizado='N'")

            For Each row As DataRow In dt_DepositosId.Rows
                If CInt(row("Folio")) = 3849 Then
                    MessageBox.Show(row("Folio"))
                    Dim FechaDeposito1 As Date = CDate(row("Fecha_Inicio"))
                End If
                Dim FechaDeposito As Date = CDate(row("Fecha_Inicio"))

                Dim HoraIni As String = Format(row("Fecha_Inicio"), "HH:mm:ss")
                Dim HoraFin As String = Format(row("Fecha_Fin"), "HH:mm:ss")

                Cmd = Crear_ComandoSQL("DepositosD_Read3", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, row("Id_Deposito"))
                Dim dt_DetallesD As DataTable = Ejecutar_ConsultaSQL(Cmd)

                '--------Ir a la web a ver si ya estaba el Id_Deposito ....en caso de cancelacion de retiros
                Dim dt_DepositosWeb As DataTable = cls_CashWeb.fn_DepositosExiste(row("Id_Deposito"))

                If dt_DepositosWeb IsNot Nothing AndAlso dt_DepositosWeb.Rows.Count > 0 Then
                    'si encontro solo lo acualiza
                    If cls_CashWeb.fn_DepositosActualizaStatus(row("Id_Deposito")) Then

                        Cmd = Crear_ComandoSQL("Depositos_UpdateSincroniza", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Id_Deposito ", SqlDbType.Int, row("Id_Deposito"))
                        Ejecutar_NonQuerySQL(Cmd)
                    Else
                        Cnn.Dispose()
                        Cmd.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL ACTUALIZAR STATUS DE DEPÓSITO EN LA BDD WEB.")
                        Return False
                    End If

                Else

                    'sino no existe el id_deposito...tonces lo inserta ._BDDweb - 'funcion graba datos
                    If cls_CashWeb.fn_GuardaDepositosWeb(FechaDeposito, row("Id_Deposito"), row("Importe_Total"),
                                                             row("Total_MXP"), row("Total_USD"), row("TotalUSD_Convert"), row("TipoCambio_USD"),
                                                             HoraIni, HoraFin, dt_DetallesD, row("Status"), row("Folio"), row("Tipo"), row("Usuario_Registro"), row("id_Corte"), row("Es_Efectivo"), row("Id_Caja"), row("Clave_Caja")) Then
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "GUARDANDO EL DEPOSITO EN LA BDD WEB CON ID: " & row("Id_Deposito"))

                        '-------------si regresa true cambiar a "S" e N depositos de CE---
                        'Update depositos CE
                        Cmd = Crear_ComandoSQL("Depositos_UpdateSincroniza", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Id_Deposito ", SqlDbType.Int, row("Id_Deposito"))
                        Ejecutar_NonQuerySQL(Cmd)

                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "DEPÓSITO LOCAL CON ID: " & row("Id_Deposito") & " SINCRONIZADO CORRECTAMENTE. ")
                    Else
                        Cnn.Dispose()
                        Cmd.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.")
                        Return False
                    End If

                End If
            Next
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - DEPÓSITOS SINCRONIZADOS CORRECTAMENTE.")
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL SINCRONIZAR DEPÓSITOS EN LA BDD WEB." & ex.Message.ToUpper)
            Return False
        End Try
    End Function
    Public Shared Function fn_SincronizarDepositosWebServices() As Boolean
        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 02/03/2021

        fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "INICIO - SINCRONIZAR DEPOSITOS EN LA BDD WEB.")

        Dim dtDepositos As DataTable = New DataTable("TblDepositos")
        Dim dtDepositosDet As DataTable = New DataTable("TblDespitosDet")
        Dim Cnn As SqlConnection
        Dim Cmd As SqlCommand
        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("[Depositos].[GetDepositos]", CommandType.StoredProcedure, Cnn)
            dtDepositos = Ejecutar_ConsultaSQL(Cmd)
            Cmd = Crear_ComandoSQL("[Depositos].[GetDepositosDet]", CommandType.StoredProcedure, Cnn)
            dtDepositosDet = Ejecutar_ConsultaSQL(Cmd)

            If dtDepositos.Rows.Count > 0 And dtDepositosDet.Rows.Count > 0 Then
                cls_CashWeb.fn_GuardarDepositosWebService(dtDepositos, dtDepositosDet)
            Else
                'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "PROCESO- NO SE ENCONTRARON DEPOSITOS PARA SINCRONIZAR.")
            End If
            Cnn.Dispose()
            Cmd.Dispose()
            Return True
        Catch ex As Exception
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, True)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 68, varPub.IdPantalla, "SINCRONIZAR DEPÓSITOS - " + "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB. " + ex.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.")
            Return False
            Cnn.Dispose()
            Cmd.Dispose()
        End Try
    End Function


    'Public Shared Function fn_SincronizaDepositos_aWEBWs() As Boolean

    '    'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

    '    Dim dtDepositos As DataTable = New DataTable("TblDepositos")
    '    Dim dtDepositosDet As DataTable = New DataTable("TblDespitosDet")


    '    Try
    '        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
    '        Dim Cmd As SqlCommand = Crear_ComandoSQL("[Depositos].[GetDepositos]", CommandType.StoredProcedure, Cnn)
    '        dtDepositos = Ejecutar_ConsultaSQL(Cmd)
    '        Cmd = Crear_ComandoSQL("[Depositos].[GetDepositosDet]", CommandType.StoredProcedure, Cnn)
    '        dtDepositosDet = Ejecutar_ConsultaSQL(Cmd)

    '        If dtDepositos.Rows.Count > 0 And dtDepositosDet.Rows.Count > 0 Then
    '            cls_CashWeb.fn_GuardarDepositosWebService(dtDepositos, dtDepositosDet)
    '        Else
    '            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "PROCESO- NO SE ENCONTRARON DEPOSITOS PARA SINCRONIZAR.")
    '        End If
    '        Cnn.Dispose()
    '        Cmd.Dispose()
    '        Return True
    '    Catch ex As Exception
    '        fn_MsgBox(ex.Message(), MessageBoxIcon.Error, False)
    '        fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 68, varPub.IdPantalla, "SINCRONIZAR DEPÓSITOS - " + "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.")
    '        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.")
    '       c
    '        Cmd.Dispose()
    '        Return False
    '    End Try
    'End Function
    Public Shared Function fn_UpdateSincronizaDepositos(ByVal XmlDepositos As String) As Boolean

        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

        Dim Cnn As SqlConnection
        Dim Cmd As SqlCommand
        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("[Depositos].[DepositosUpdateSincXml]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Xml", SqlDbType.Xml, XmlDepositos)
            Ejecutar_NonQuerySQL(Cmd)
            Cnn.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, False)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 75, varPub.IdPantalla, "SINCRONIZAR DEPOSITOS - " + "FIN - ERROR AL REALIZAR UPDATE STATUS A SINCRONIZADO A LOS DEPOSITOS. " + ex.Message.ToUpper + " XML: " + XmlDepositos.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPOSITOS", "FIN - ERROR AL REALIZAR UPDATE STATUS A SINCRONIZADO A LOS DEPOSITOS. " & ex.Message.ToUpper)
            Return False
            Cnn.Dispose()
            Cmd.Dispose()
            Cmd.Dispose()
        End Try
        Return True
    End Function
    Public Shared Function fn_UpdateSincronizaLogMonitoreo(ByVal XmlLog As String) As Boolean

        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

        Dim Cnn As SqlConnection
        Dim Cmd As SqlCommand
        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("[Monitoreo].[LogSincronizacionXml]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Xml", SqlDbType.Xml, XmlLog)
            Ejecutar_NonQuerySQL(Cmd)
            Cnn.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, False)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 80, varPub.IdPantalla, "SINCRONIZAR DEPOSITOS - " + "FIN - ERROR AL REALIZAR UPDATE STATUS A SINCRONIZADO A LOGS DE MONITOREO. " + ex.Message.ToUpper + " XML: " + XmlLog.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR LOGS", "FIN - ERROR AL REALIZAR UPDATE STATUS A SINCRONIZADO A A LOGS DE MONITOREO. " & ex.Message.ToUpper)
            Return False
            Cnn.Dispose()
            Cmd.Dispose()
            Cmd.Dispose()
        End Try
        Return True
    End Function



    Public Shared Function fn_UpdateSincronizaRetiros(ByVal XmlRetiros) As Boolean
        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

        Dim Cnn As SqlConnection
        Dim Cmd As SqlCommand

        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("[Retiros].[RetirosUpdateSincrXml]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Xml", SqlDbType.Xml, XmlRetiros)
            Ejecutar_NonQuerySQL(Cmd)
            Return True
            Cnn.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            Return False
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, False)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 74, varPub.IdPantalla, "SINCRONIZAR RECOLECCIÓN - " + "FIN - ERROR AL REALIZAR UPDATE STATUS DE SINCRONIZADO A LOS RETIROS MEDIANTE XML." & ex.Message.ToUpper + " XML: " + XmlRetiros.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "FIN - ERROR AL REALIZAR UPDATE STATUS DE SINCRONIZADO A LOS RETIROS MEDIANTE XML." & ex.Message.ToUpper)
            Cnn.Dispose()
            Cmd.Dispose()
        End Try
    End Function


    Public Shared Function fn_SincronizaDepositos_aWEB() As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPOSITOS", "INICIO - SINCRONIZAR DEPOSITOS EN LA BDD WEB.")

        Try
            ' Solo consulta lo que no esta Sincronizado.
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Depositos_Read3", CommandType.StoredProcedure, Cnn)
            Dim dt_DepositosId As DataTable = Ejecutar_ConsultaSQL(Cmd)
            'Call fn_EscribirLog(UsuarioClave, "SINCRONIZAR DEPÓSITOS", "Consulta Correcta en BDD Local con exito para Sacar ID_deposito donde Sincronizado='N'")

            For Each row As DataRow In dt_DepositosId.Rows
                Dim pruebaId_Deposito = row("Id_Deposito")
                Dim FechaDeposito As Date = CDate(row("Fecha_Inicio"))

                Dim HoraIni As String = Format(row("Fecha_Inicio"), "HH:mm:ss")
                Dim HoraFin As String = Format(row("Fecha_Fin"), "HH:mm:ss")

                Cmd = Crear_ComandoSQL("DepositosD_Read2", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, pruebaId_Deposito)
                Dim dt_DetallesD As DataTable = Ejecutar_ConsultaSQL(Cmd)

                '--------Ir a la web a ver si ya estaba el Id_Deposito ....en caso de cancelacion de retiros
                'Dim dt_DepositosWeb As DataTable = cls_CashWeb.fn_DepositosExiste(row("Id_Deposito"))
                Dim dt_DepositosWeb As DataTable = cls_CashWeb.fn_DepositosExiste(pruebaId_Deposito)

                If dt_DepositosWeb IsNot Nothing AndAlso dt_DepositosWeb.Rows.Count > 0 Then
                    'si encontro solo lo acualiza
                    If cls_CashWeb.fn_DepositosActualizaStatus(row("Id_Deposito")) Then

                        Cmd = Crear_ComandoSQL("Depositos_UpdateSincroniza", CommandType.StoredProcedure, Cnn)
                        'Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, row("Id_Deposito"))
                        Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, pruebaId_Deposito)
                        Ejecutar_NonQuerySQL(Cmd)
                    Else
                        Cnn.Dispose()
                        Cmd.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPOSITOS", "FIN - OCURRIÓ UN ERROR AL ACTUALIZAR STATUS DE DEPÓSITO EN LA BDD WEB.")
                        Return False
                    End If

                Else

                    If IsDBNull(row("Id_Caja")) Then
                        row("Id_Caja") = 0
                    End If

                    If cls_CashWeb.fn_GuardaDepositosWeb(FechaDeposito, pruebaId_Deposito, row("Importe_Total"),
                                                             row("Total_MXP"), row("Total_USD"), row("TotalUSD_Convert"), row("TipoCambio_USD"),
                                                             HoraIni, HoraFin, dt_DetallesD, row("Status"), row("Folio"), row("Tipo"), row("Usuario_Registro"), row("Id_Corte"), row("Es_Efectivo"), row("Id_Caja"), row("Clave_Caja")) Then
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "GUARDANDO EL DEPOSITO EN LA BDD WEB CON ID: " & row("Id_Deposito"))

                        '-------------si regresa true cambiar a "S" e N depositos de CE---
                        'Update depositos CE
                        Cmd = Crear_ComandoSQL("Depositos_UpdateSincroniza", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Id_Deposito", SqlDbType.Int, row("Id_Deposito"))
                        Ejecutar_NonQuerySQL(Cmd)

                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "DEPÓSITO LOCAL CON ID: " & row("Id_Deposito") & " SINCRONIZADO CORRECTAMENTE. ")
                    Else
                        Cnn.Dispose()
                        Cmd.Dispose()
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPÓSITOS", "FIN - OCURRIÓ UN ERROR AL GUARDAR DEPÓSITOS EN LA BDD WEB.")
                        Return False
                    End If

                End If
            Next
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPOSITOS", "FIN - DEPÓSITOS SINCRONIZADOS CORRECTAMENTE.")
            Return True
        Catch ex As Exception
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, False)
            'fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, , 24, "SINCRONIZAR DEPOSITOS - " + "FIN - OCURRIÓ UN ERROR AL SINCRONIZAR DEPÓSITOS EN LA BDD WEB.- " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DEPOSITOS", "FIN - ERROR AL SINCRONIZAR DEPÓSITOS EN LA BDD WEB." & ex.Message.ToUpper)
            Return False
        End Try
    End Function
    Public Shared Function fn_SincronizaRetiros_WebWs()

        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 09/02/2021

        Dim Cmd As SqlCommand
        Dim dtRetiros As DataTable
        Dim dtRetirosDet As DataTable


        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "INICIO - SINCRONIZAR RECOLECCIÓN EN LA BDD WEB.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Cmd = Crear_ComandoSQL("[Retiros].[GetRetiros]", CommandType.StoredProcedure, Cnn)
            dtRetiros = Ejecutar_ConsultaSQL(Cmd)
            Cmd = Crear_ComandoSQL("[Retiros].[GetRetirosDet]", CommandType.StoredProcedure, Cnn)
            dtRetirosDet = Ejecutar_ConsultaSQL(Cmd)

            If dtRetiros.Rows.Count > 0 And dtRetirosDet.Rows.Count > 0 Then
                cls_CashWeb.fn_GuardarRetirowsWs(dtRetiros, dtRetirosDet)
            Else
                'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "PROCESO- NO SE ENCONTRARON RETIROS PARA SINCRONIZAR.")
            End If
            Cnn.Dispose()
            Cmd.Dispose()
            Return True
        Catch ex As Exception
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, True)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 69, varPub.IdPantalla, "SINCRONIZAR RECOLECCIÓN - " + "FIN - ERROR AL SINCRONIZAR RECOLECCIÓN EN LA BDD WEB. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "FIN - ERROR AL SINCRONIZAR RECOLECCIÓN EN LA BDD WEB" & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizaLogErrores_WebWs()

        'FUNCION NUEVA BRANDON JHAIR SANCHEZ ESTRADA 26/05/2021

        Dim Cmd As SqlCommand
        Dim dtLog As DataTable

        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR LOG MONITOREO", "INICIO - SINCRONIZAR LOG MONITOREO EN LA BDD WEB.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Cmd = Crear_ComandoSQL("[Monitoreo].[GetLogs]", CommandType.StoredProcedure, Cnn)
            dtLog = Ejecutar_ConsultaSQL(Cmd)

            If dtLog.Rows.Count > 0 Then
                cls_CashWeb.fn_GuardarLogErroresWebService(dtLog)
            Else
                Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR LOG MONITOREO", "PROCESO - NO SE ENCONTRARON LOGS PARA SINCRONIZAR.")
            End If
            Cnn.Dispose()
            Cmd.Dispose()
            Return True
        Catch ex As Exception
            fn_MsgBox(ex.Message(), MessageBoxIcon.Error, True)
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 79, varPub.IdPantalla, "SINCRONIZAR LOG MONITOREO - " + "FIN - ERROR AL SINCRONIZAR LOG MONITOREO EN LA BDD WEB. " & ex.Message.ToUpper)
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR LOG MONITOREO", "FIN - ERROR AL SINCRONIZAR LOG MONITOREO EN LA BDD WEB" & ex.Message.ToUpper)
            Return False
        End Try
    End Function



    Public Shared Function fn_SincronizaRetiros_aWEB() As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "INICIO - SINCRONIZAR RECOLECCIÓN EN LA BDD WEB.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Retiros_Read5", CommandType.StoredProcedure, Cnn)
            Dim dt_RetirosId As DataTable = Ejecutar_ConsultaSQL(Cmd)

            For Each row As DataRow In dt_RetirosId.Rows
                ''--------------Obtiene los IDs de los Depositos correspondientes al ID_retiro

                Cmd = Crear_ComandoSQL("Depositos_ReadRetiro5", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, row("Id_Retiro"))
                '----------------
                Dim FechaRetiro As Date = CDate(row("Fecha_Registro"))
                Dim HoraIni As String = Format(row("Fecha_Registro"), "HH:mm:ss")
                Dim HoraFin As String = Format(row("Fecha_Registro"), "HH:mm:ss")
                '-----------------------------------------------------

                Dim Dt_IdsDepositos As DataTable = Ejecutar_ConsultaSQL(Cmd)
                ''------------------Se obtiene el detalle del retiro

                Cmd = Crear_ComandoSQL("RetirosD_Read", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Id_Retiro ", SqlDbType.Int, row("Id_Retiro"))
                Dim dt_DetallesR As DataTable = Ejecutar_ConsultaSQL(Cmd)

                '----------Buscar si existe el Id_Retiro Existente
                Dim dt_RetirosWeb As DataTable = cls_CashWeb.fn_RetirosExiste(row("Id_Retiro"))
                Dim Encontrado As Boolean = False

                If dt_RetirosWeb Is Nothing Then
                    Cnn.Dispose()
                    Cmd.Dispose()
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "FIN - OCURRIÓ UN ERROR AL CONSULTAR RECOLECCIÓN EN LA BDD WEB.")
                    Return False
                End If

                If dt_RetirosWeb.Rows.Count > 0 Then
                    dt_DetallesR = Nothing
                    Encontrado = True
                End If

                '-------hecho la consulta grabarlo en Retiros _BDDweb - 'funcion graba datos
                If cls_CashWeb.fn_GuardarRetirosWeb(Dt_IdsDepositos, row("Id_Retiro"), row("Importe_Total"),
                                                         row("Total_MXP"), row("Total_USD"), row("TotalUSD_Convert"),
                                                        HoraIni, HoraFin, row("Observaciones"), row("Status"),
                                                       dt_DetallesR, row("Numero_Remision"), row("Numero_Envase"), Encontrado, FechaRetiro, row("Importe_Otros"), row("Importe_Otrosd"), row("Usuario_Registro")) Then
                    '-------------si regresa true cambiar a "S" e N depositos de CE---
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "GUARDANDO LA RECOLECCIÓN EN LA BDD WEB CON ID: " & row("Id_Retiro"))

                    'Update Retiros CE

                    Cmd = Crear_ComandoSQL("Retiros_Update2", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@Id_Retiro", SqlDbType.Int, row("Id_Retiro"))
                    Ejecutar_NonQuerySQL(Cmd)
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "RECOLECCIÓN LOCAL CON ID: " & row("Id_Retiro") & " SINCRONIZADO CORRECTAMENTE. ")
                Else
                    Cnn.Dispose()
                    Cmd.Dispose()
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "FIN - OCURRIÓ UN ERROR AL GUARDAR RECOLECCIÓN EN LA BDD WEB.")
                    Return False
                End If

            Next
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "FIN - RECOLECCIONES SINCRONIZADOS CORRECTAMENTE.")
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR RECOLECCIÓN", "FIN - OCURRIÓ UN ERROR AL SINCRONIZAR RECOLECCIÓN EN LA BDD WEB" & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizaCorte_aWEB() As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CORTE", "INICIO - SINCRONIZAR CORTE EN LA BDD WEB.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)


            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cortes_Read2", CommandType.StoredProcedure, Cnn)
            Dim dt_CortesId As DataTable = Ejecutar_ConsultaSQL(Cmd)


            For Each row As DataRow In dt_CortesId.Rows

                '-------hecho la consulta grabarlo en Corte _BDDweb - 'funcion graba datoss
                If cls_CashWeb.fn_GuardarCorteWeb(row("Id_Corte"), row("Usuario_Registro"), row("Fecha_Registro"), row("Usuario_Cierre"), row("Fecha_Cierre"), row("Status")) Then
                    '-------------si regresa true cambiar a "S" e N Corte de CE---
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CORTE", "GUARDANDO LA CORTE EN LA BDD WEB CON ID: " & row("Id_Corte"))

                    'Update Corte CE

                    Cmd = Crear_ComandoSQL("Cortes_update2", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@Id_Corte", SqlDbType.Int, row("Id_Corte"))
                    Ejecutar_NonQuerySQL(Cmd)

                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CORTE", "CORTE LOCAL CON ID: " & row("Id_Corte") & " SINCRONIZADO CORRECTAMENTE. ")
                Else
                    Cnn.Dispose()
                    Cmd.Dispose()
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CORTE", "FIN - OCURRIÓ UN ERROR AL GUARDAR CORTE EN LA BDD WEB.")
                    Return False
                End If

            Next
            Cnn.Dispose()
            Cmd.Dispose()
            'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CORTE", "FIN - CORTE SINCRONIZADOS CORRECTAMENTE.")
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CORTE", "FIN - OCURRIÓ UN ERROR AL SINCRONIZAR CORTE EN LA BDD WEB" & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizarMonedas_aLOCAL() As Boolean
        Try
            'Funcion que trae todas  las monedas en BDD web a local
            'sincroniza de WEb hacia local ... falta de local hacia web
            Dim dt_monedas As DataTable = cls_CashWeb.fn_ConsultaMonedas
            If dt_monedas IsNot Nothing AndAlso dt_monedas.Rows.Count > 0 Then

                Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

                Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, Cnn)
                Dim dt_Moneditas As DataTable = Ejecutar_ConsultaSQL(Cmd)

                Dim Encontro As Boolean = False
                For Each cveMoneda As DataRow In dt_monedas.Rows

                    For Each cveMonedita As DataRow In dt_Moneditas.Rows
                        If cveMoneda("Clave_Moneda") = cveMonedita("Clave_Moneda") Then
                            Encontro = True
                            Exit For
                        End If
                    Next
                    If Not Encontro Then

                        Cmd = Crear_ComandoSQL("Monedas_Insert", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, cveMoneda("Clave_Moneda"))
                        Crear_ParametroSQL(Cmd, "@Nombre_Moneda", SqlDbType.VarChar, cveMoneda("Nombre_Moneda"))
                        Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "S")
                        Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, Fecha & " " & Hora)
                        Ejecutar_NonQuerySQL(Cmd)
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN", "GUARDANDO MONEDA : " & cveMoneda("Clave_Moneda") & " EN BDD LOCAL.")
                    End If
                    Encontro = False
                Next
                Cnn.Dispose()
                Cmd.Dispose()
            End If

            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR MONEDAS", "ERROR AL SINCRONIZAR MONEDAS EN BDD LOCAL." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizarMonedas_aWEB() As Boolean
        Try
            'Funcion sincroniza de local hacia ----> web
            Dim dt_monedas As DataTable = cls_CashWeb.fn_ConsultaMonedas

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Query As String = "Select Clave_Moneda As Clave, Nombre_Moneda As Nombre From Monedas " '& _
            '"Where Sincronizado ='N' " '12 marzo
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_Moneditas As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Dim Encontro As Boolean = False

            If dt_Moneditas IsNot Nothing And dt_Moneditas.Rows.Count > 0 Then '-------

                For Each cveMonedita As DataRow In dt_Moneditas.Rows
                    If dt_monedas Is Nothing Then
                        If cls_CashWeb.fn_GuardaMonedas(cveMonedita("Clave_Moneda"), cveMonedita("Nombre_Moneda")) Then

                            Cmd = Crear_ComandoSQL("Monedas_Update", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, cveMonedita("Clave_Moneda"))
                            Ejecutar_NonQuerySQL(Cmd)
                            ''Call fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza Monedas Sincronizado ='S' en BDD Local")
                        End If
                    Else
                        '-----------
                        For Each cveMoneda As DataRow In dt_monedas.Rows
                            If cveMonedita("Clave_Moneda") = cveMoneda("Clave_Moneda") Then
                                'Si este ya esta en la Web actualiza status de sincronizado en local 
                                Encontro = True
                                Cmd = Crear_ComandoSQL("Monedas_Update", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, cveMonedita("Clave_Moneda"))
                                Ejecutar_NonQuerySQL(Cmd)
                                ''Call fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza Monedas Sincronizado ='S' en bdd local")
                                Exit For
                            End If
                        Next
                        If Not Encontro Then
                            'si no encontró entonces insertamos en web
                            If cls_CashWeb.fn_GuardaMonedas(cveMonedita("Clave_Moneda"), cveMonedita("Nombre_Moneda")) Then
                                Cmd = Crear_ComandoSQL("Monedas_Update", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, cveMonedita("Clave_Moneda"))
                                Ejecutar_NonQuerySQL(Cmd)
                                ''Call fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza Monedas Sincronizado ='S' en bdd local")
                            End If
                        End If
                        '----------------------
                    End If
                Next
                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR MONEDAS", "ERROR AL SINCRONIZAR MONEDAS EN LA WEB." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizarCasets_aLOCAL(ByVal ClaveSucursal As String) As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "INICIO - SINCRONIZAR CASETS DE BDD WEB A LOCAL.")
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Try
            'Funcion que trae todas  los casets si hay de la BDD web a local
            Dim dt_Casets As DataTable = cls_CashWeb.fn_ConsultaCasets(ClaveSucursal)

            If dt_Casets Is Nothing Then
                fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "OCURRIÓ UN ERROR AL DESCARGAR LOS CASETS.")
                Return False
            End If
            If dt_Casets.Rows.Count = 0 Then
                fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "NO EXISTEN CASETS EN LA BDD WEB.")
                Return False
            End If

            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Casets_Read8", CommandType.StoredProcedure, Cnn)
            Dim dt_CasetsLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Dim Encontro As Boolean = False

            For Each cveCaset As DataRow In dt_Casets.Rows 'CASETS WEB
                Encontro = False

                For Each cveCasetLocal As DataRow In dt_CasetsLocal.Rows 'CASETS LOCAL
                    If cveCaset("ClaveC") = cveCasetLocal("Clave") Then
                        If cveCaset("Status2") = "D" Then
                            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "ELIMINANADO CASET EN LA WEB Y LOCAL CON NUMERO DE SERIE '" & cveCaset("serie") & "'.")

                            Cmd = Crear_ComandoSQL("Casets_Delete", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.Int, cveCaset("ClaveC"))
                            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                                If cls_CashWeb.fn_Elimina_Casets(cveCaset("Serie")) Then
                                    fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "CASET ELIMINADO CORRECTAMENTE EN LA WEB Y LOCAL CON NUMERO DE SERIE '" & cveCaset("serie") & "'.")
                                End If
                            End If

                        End If
                        '-----------------------------------------------
                        Encontro = True
                        Exit For
                    End If
                Next

                If Encontro = False Then
                    If cveCaset("Status2") = "D" Then
                        cls_CashWeb.fn_Elimina_Casets(cveCaset("Serie"))
                    ElseIf cveCaset("Status2") = "A" Then
                        Cmd = Crear_ComandoSQL("Casets_Insert", CommandType.StoredProcedure, Cnn)

                        Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, cveCaset("ClaveC"))
                        Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, cveCaset("Serie"))
                        Crear_ParametroSQL(Cmd, "@Capacidad", SqlDbType.Int, cveCaset("Capacidad"))
                        Crear_ParametroSQL(Cmd, "@Porcentaje_Alerta", SqlDbType.Int, cveCaset("Porcentaje"))
                        Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, cveCaset("Status"))
                        Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "S")
                        Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, Fecha & " " & Hora)
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "A")

                        Ejecutar_NonQuerySQL(Cmd)
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS ", "GUARDANDO CASET Nº DE SERIE: " & cveCaset("Serie") & " EN BDD LOCAL")
                    End If
                End If
            Next

            Cnn.Dispose()
            Cmd.Dispose()
            'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "FIN - CASETS SINCRONIZADOS CORRECTAMENTE EN BDD LOCAL.")
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "FIN - OCURRIÓ UN ERROR AL SINCRONIZAR CASETS EN LA BDD LOCAL." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizarCasets_aWEB() As Boolean
        Try
            'Funcion sincroniza de local hacia ----> web
            Dim dt_Casets As DataTable = cls_CashWeb.fn_ConsultaCasets(varPub.Cve_Sucursal)

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Casets_Read9", CommandType.StoredProcedure, Cnn)
            Dim dt_CasetsLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Dim fechaActual As String = ""
            Dim Encontro As Boolean = False

            If dt_CasetsLocal IsNot Nothing AndAlso dt_CasetsLocal.Rows.Count > 0 Then '-------

                For Each cveCasetLocal As DataRow In dt_CasetsLocal.Rows
                    'preguntar si la tabla de arriba web esta vacia--- si si
                    'tonces insertar directo todo

                    '----nuevo 10 maYO 2013
                    Encontro = False
                    If dt_Casets Is Nothing Then
                        fechaActual = Fecha & " " & Hora

                        '{Si el dt esta vacio inserta en web y actualiza Status='S' en Local}
                        If cls_CashWeb.fn_GuardaCasets(cveCasetLocal("Clave"), cveCasetLocal("Serie"), cveCasetLocal("Capacidad"), cveCasetLocal("Porcentaje"), cveCasetLocal("Status"), fechaActual) Then

                            Cmd = Crear_ComandoSQL("Casets_Update4", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, cveCasetLocal("Clave"))
                            Ejecutar_NonQuerySQL(Cmd)

                            ''Call fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza casets cambiando Sincronizado ='S' en bdd local")
                        End If
                    Else
                        ' Si el dt de la Web ya tiene casets -->
                        For Each cveCasetWeb As DataRow In dt_Casets.Rows
                            If cveCasetLocal("Clave") = cveCasetWeb("ClaveC") Then
                                ' Si ya existe en la web, Solo actualiza Status ='S' en Local
                                Encontro = True

                                If cveCasetLocal("Status2") = "D" Then

                                    If cls_CashWeb.fn_Elimina_Casets(cveCasetLocal("Serie")) Then
                                        Dim Hola As String = cveCasetLocal("Serie")

                                        Cmd = Crear_ComandoSQL("Casets_Delete2", CommandType.StoredProcedure, Cnn)
                                        Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, cveCasetLocal("Serie"))

                                        If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                                            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - CASET CON NUMERO DE SERIE: " & cveCasetLocal("Clave") & "  ELIMINADO CORRECTAMENTE EN LA WEB Y LOCAL")
                                        End If

                                    Else
                                        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CASETS", "FIN - ERROR AL ELIMINAR CASET '" & cveCasetLocal("Clave") & "' EN LA WEB")
                                        Return -1
                                    End If
                                    '-----------------------------------------------
                                ElseIf cveCasetLocal("Status2") = "E" Then
                                    'fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CASETS", "EDITANDOCASET EN LA WEB Y LOCAL CON NUMERO DE SERIE '" & cveCasetLocal("serie") & "'.")
                                    If cls_CashWeb.fn_EditarCasetsStatus(cveCasetLocal("Serie"), cveCasetLocal("Status"), cveCasetLocal("Fecha_Modifica")) Then

                                        Cmd = Crear_ComandoSQL("Casets_Update3", CommandType.StoredProcedure, Cnn)
                                        Crear_ParametroSQL(Cmd, "@StatusAsignar", SqlDbType.VarChar, "A")
                                        Crear_ParametroSQL(Cmd, "@Serie_Caset", SqlDbType.VarChar, cveCasetLocal("Serie"))
                                        Ejecutar_NonQuerySQL(Cmd)
                                    End If
                                End If

                                Cmd = Crear_ComandoSQL("Casets_Update4", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, cveCasetLocal("Clave"))
                                Ejecutar_NonQuerySQL(Cmd)

                                '' fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza Casets Sincronizado ='S' en bdd local")
                                Exit For
                            End If
                        Next

                        If Not Encontro Then
                            fechaActual = Fecha & " " & Hora

                            'si no encontró entonces insertamos en web 
                            If cls_CashWeb.fn_GuardaCasets(cveCasetLocal("Clave"), cveCasetLocal("Serie"), cveCasetLocal("Capacidad"), cveCasetLocal("Porcentaje"), cveCasetLocal("Status"), fechaActual) Then
                                Cmd = Crear_ComandoSQL("Casets_Update4", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Caset", SqlDbType.VarChar, cveCasetLocal("Clave"))
                                Ejecutar_NonQuerySQL(Cmd)

                                ''Call fn_EscribirLog(UsuarioClave, "MENU USUARIOS", "Actualiza casets cambiando Sincronizado ='S' en bdd local")
                            End If
                        End If
                        '-*-----------------------
                    End If
                Next

                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            Else
                Return False
            End If '*------------------
        Catch ex As Exception

            Return False
        End Try
    End Function

    ''' <summary>
    ''' Funcion que sincroniza los privilegios de Web--> hacia Local
    ''' se usa esta funcion cuando la Prioridad es Web
    ''' </summary>
    ''' <param name="ClaveUser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_SincronizarPrivilegiosWeb_aLOCAL(ByVal ClaveUser As String) As Boolean

        'Try
        '    Dim OpcionesLocal() As String = {}
        '    Dim OpcionesWeb() As String = {}
        '    Dim Diferencia As Object

        '    Dim dt_PrivilegiosWeb As DataTable = cls_CashWeb.fn_Consulta_PrivilegiosWeb(ClaveUser, OpcionesWeb)
        '    '---------
        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim Query As String = "Select Clave_Usuario As ClaveUser, " & _
        '                          "Clave_Opcion As ClaveOp " & _
        '                          "From Privilegios " & _
        '                          "Where Clave_Usuario= '" & ClaveUser & "' "
        '    Dim cmd As SqlCeCommand = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    'consultamos los privilegios X USuario (local)
        '    Dim dt_PrivilegiosLocal As DataTable = Ejecutar_ConsultaSQLCE(cmd)
        '    '-------------
        '    If dt_PrivilegiosLocal IsNot Nothing AndAlso dt_PrivilegiosLocal.Rows.Count > 0 Then
        '        ReDim OpcionesLocal(dt_PrivilegiosLocal.Rows.Count - 1)

        '        For i As Integer = 0 To dt_PrivilegiosLocal.Rows.Count - 1
        '            OpcionesLocal(i) = dt_PrivilegiosLocal.Rows(i)("ClaveOp").ToString
        '        Next
        '    End If
        '    '----------
        '    If dt_PrivilegiosWeb IsNot Nothing AndAlso dt_PrivilegiosWeb.Rows.Count > 0 Then

        '        Dim Borrar As Boolean = False
        '        If OpcionesWeb.Count < OpcionesLocal.Count Then
        '            Diferencia = OpcionesLocal.Except(OpcionesWeb)
        '            'en web hay -- y local ++ Borrar los que Sobran
        '            Borrar = True
        '        Else
        '            'en web hay ++ y local -- Insertar los que faltan
        '            Diferencia = OpcionesWeb.Except(OpcionesLocal)
        '        End If

        '        For Each OpcionPriv As String In Diferencia
        '            If Borrar Then
        '                Call fn_BorrarPrivilegios(OpcionPriv, ClaveUser)
        '            Else
        '                Call fn_AgregaPrivilegios(OpcionPriv, ClaveUser)
        '            End If
        '        Next

        '        cnn.Dispose()
        '        cmd.Dispose()
        '        Return True

        '    ElseIf dt_PrivilegiosLocal IsNot Nothing AndAlso dt_PrivilegiosLocal.Rows.Count > 0 Then
        '        'si web esta vacio y local tiene tonces subir/enviar los de local e insertar en web
        '        For Each PrivLocal As DataRow In dt_PrivilegiosLocal.Rows
        '            If cls_CashWeb.fn_Guarda_PrivilegiosWeb(PrivLocal("ClaveUser"), PrivLocal("ClaveOp")) Then
        '                Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN", "Guardando privilegios: " & PrivLocal("ClaveOp") & " en la bdd web")
        '            End If
        '        Next
        '        cnn.Dispose()
        '        cmd.Dispose()
        '        Return True
        '    Else
        '        cnn.Dispose()
        '        cmd.Dispose()
        '        Return False
        '    End If '-------------

        'Catch ex As Exception
        '    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN", "ERROR AL SINCRONIZAR PRIVILEGIOS DE WEB HACIA LOCAL. " & ex.Message)
        '    Return False
        'End Try
        Return False
    End Function

    ''' <summary>
    ''' Funcion que sincroniza Privilegios de Usuarios de local-->hacia Web
    ''' se usa esta funcion cuando la Prioridad es Local
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_SincronizarPrivilegiosLocal_aWEB(ByVal ClaveUser As Integer) As Boolean
        'Try
        '    Dim OpcionesLocal() As String = {}
        '    Dim OpcionesWeb() As String = {}
        '    Dim Diferencia As Object

        '    Dim dt_PrivilegiosWeb As DataTable = cls_CashWeb.fn_Consulta_PrivilegiosWeb(ClaveUser, OpcionesWeb)
        '    '--------------
        '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
        '    Dim Query As String = "Select Clave_Usuario As ClaveUser, " & _
        '                          "Clave_Opcion As ClaveOp " & _
        '                          "From Privilegios " & _
        '                          "Where Clave_Usuario= " & ClaveUser & " "
        '    Dim cmd As SqlCeCommand = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
        '    '---consultamos los privilegios X USuario (local)
        '    Dim dt_PrivilegiosLocal As DataTable = Ejecutar_ConsultaSQLCE(cmd)
        '    '------------
        '    If dt_PrivilegiosLocal IsNot Nothing AndAlso dt_PrivilegiosLocal.Rows.Count > 0 Then

        '        'Llenamos la lista de opciones local
        '        ReDim OpcionesLocal(dt_PrivilegiosLocal.Rows.Count - 1)
        '        For i As Integer = 0 To dt_PrivilegiosLocal.Rows.Count - 1
        '            OpcionesLocal(i) = dt_PrivilegiosLocal.Rows(i)("ClaveOp").ToString
        '        Next

        '        Dim Borrar As Boolean = False

        '        If OpcionesLocal.Count < OpcionesWeb.Count Then
        '            Diferencia = OpcionesWeb.Except(OpcionesLocal)
        '            'en local hay -- y web ++ Borrar los que Sobran
        '            Borrar = True
        '        Else
        '            'en local hay ++ y web -- Insertar los que faltan
        '            Diferencia = OpcionesLocal.Except(OpcionesWeb)
        '        End If

        '        For Each OpcionPriv As String In Diferencia
        '            If Borrar Then
        '                If cls_CashWeb.fn_Elimina1X1_PrivilegiosWeb(ClaveUser, OpcionPriv) Then
        '                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN", "Eliminando privilegios de usuarios en la bdd web")
        '                End If
        '            Else
        '                If cls_CashWeb.fn_Guarda_PrivilegiosWeb(ClaveUser, OpcionPriv) Then
        '                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN", "Guardando privilegios de usuarios en la bdd web")
        '                End If
        '            End If
        '        Next

        '        cnn.Dispose()
        '        cmd.Dispose()
        '        Return True

        '    ElseIf dt_PrivilegiosWeb IsNot Nothing AndAlso dt_PrivilegiosWeb.Rows.Count > 0 Then
        '        'si Local esta vacio y web tiene tonces descargar los de web e insertar en local
        '        For Each PrivWeb As DataRow In dt_PrivilegiosWeb.Rows
        '            Call fn_AgregaPrivilegios(PrivWeb("ClaveO"), PrivWeb("ClaveU"))
        '        Next

        '        cnn.Dispose()
        '        cmd.Dispose()
        '        Return True
        '    Else
        '        cnn.Dispose()
        '        cmd.Dispose()
        '        Return False
        '    End If

        'Catch ex As Exception
        '    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN", "ERROR AL SINCRONIZAR PRIVILEGIOS DE LOCAL HACIA LA WEB. " & ex.Message)

        '    Return False
        'End Try
        Return False
    End Function

    Public Shared Function fn_SincronizarUsuarios_aLOCAL(ByVal ClaveSucursal As String) As Boolean

        'SINCRONIZAR USUARIOS DE BDD WEB >---> LOCAL '***

        Dim dt_UsuariosWEB As DataTable = cls_CashWeb.fn_ConsultaUsuarios(ClaveSucursal)
        If dt_UsuariosWEB Is Nothing Then
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "OCURRIÓ UN ERROR AL DESCARGAR LOS USUARIOS.")
            Return False
        End If
        If dt_UsuariosWEB.Rows.Count = 0 Then
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "NO EXISTEN USUARIOS EN LA BDD WEB.")
            Return False
        End If

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read8", CommandType.StoredProcedure, Cnn)
            Dim dt_UsuariosLOCAL As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Dim fechaActual As String = Fecha & " " & Hora
            Dim Encontro As Boolean = False

            '------RECORRER USUARIOS WEB--------
            For Each dr_UserWeb As DataRow In dt_UsuariosWEB.Rows
                Encontro = False

                For Each dr_UserLocal As DataRow In dt_UsuariosLOCAL.Rows

                    If dr_UserWeb("ClaveU") = dr_UserLocal("Clave") Then

                        If dr_UserWeb("Status2") = "U" Then

                            Cmd = Crear_ComandoSQL("Usuarios_Update9", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserWeb("ClaveU")))
                            Crear_ParametroSQL(Cmd, "@Nombre_Usuario", SqlDbType.VarChar, dr_UserWeb("Nombre"))
                            Crear_ParametroSQL(Cmd, "@Nombre_Corto", SqlDbType.VarChar, dr_UserWeb("Nombre_Corto"))
                            Crear_ParametroSQL(Cmd, "@Tipo_Usuario", SqlDbType.TinyInt, dr_UserWeb("Tipo"))
                            Crear_ParametroSQL(Cmd, "@Fecha_Mod", SqlDbType.DateTime, dr_UserWeb("FechaModifica"))

                            Ejecutar_NonQuerySQL(Cmd)

                            'actaliza el status2 a A para que en la proxima actualizacion ya  actualice, hasta que hay una modificación de usuarios en la web
                            cls_CashWeb.fn_Usuarios_ModificarStatus2(dr_UserWeb("ClaveS"), dr_UserWeb("ClaveU"))
                            Encontro = True
                        ElseIf dr_UserWeb("Status2") = "D" Then

                            Cmd = Crear_ComandoSQL("Usuarios_Delete", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserWeb("ClaveU")))
                            Ejecutar_NonQuerySQL(Cmd)

                            cls_CashWeb.fn_Usuarios_Eliminar(dr_UserWeb("ClaveS"), dr_UserWeb("ClaveU"))
                            Encontro = True
                        Else
                            Encontro = True
                            Exit For
                        End If
                    End If
                Next

                If Encontro = False Then

                    If dr_UserWeb("Status2") = "D" Then ' Si se eliminó usuario antes de sincronizarse
                        cls_CashWeb.fn_Usuarios_Eliminar(dr_UserWeb("ClaveS"), dr_UserWeb("ClaveU"))

                    ElseIf dr_UserWeb("Status2") = "U" Then
                        'se se actualizó usuario antes de sincronizarse

                        Cmd = Crear_ComandoSQL("Usuarios_Insert", CommandType.StoredProcedure, Cnn)

                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserWeb("ClaveU")))
                        Crear_ParametroSQL(Cmd, "@Nombre_Usuario", SqlDbType.VarChar, dr_UserWeb("Nombre"))
                        Crear_ParametroSQL(Cmd, "@Nombre_Corto", SqlDbType.VarChar, dr_UserWeb("Nombre_Corto"))
                        Crear_ParametroSQL(Cmd, "@Tipo_Usuario ", SqlDbType.TinyInt, dr_UserWeb("Tipo"))
                        Crear_ParametroSQL(Cmd, "@Contra_Cod", SqlDbType.VarChar, dr_UserWeb("Contra"))
                        Crear_ParametroSQL(Cmd, "@Usuario_Registro", SqlDbType.VarChar, CInt(dr_UserWeb("RegistroU")))
                        Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, dr_UserWeb("Status"))
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "A")
                        Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "S")
                        Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, fechaActual)

                        Ejecutar_NonQuerySQL(Cmd)

                        If Ejecutar_NonQuerySQL(Cmd) > 0 Then cls_CashWeb.fn_Usuarios_ModificarStatus2(dr_UserWeb("ClaveS"), dr_UserWeb("ClaveU"))
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS ", "GUARDANDO USUARIO CON CLAVE: " & dr_UserWeb("ClaveU") & " EN BDD LOCAL")
                    ElseIf dr_UserWeb("Status2") = "A" Then

                        Cmd = Crear_ComandoSQL("Usuarios_Insert", CommandType.StoredProcedure, Cnn)

                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserWeb("ClaveU")))
                        Crear_ParametroSQL(Cmd, "@Nombre_Usuario", SqlDbType.VarChar, dr_UserWeb("Nombre"))
                        Crear_ParametroSQL(Cmd, "@Nombre_Corto", SqlDbType.VarChar, dr_UserWeb("Nombre_Corto"))
                        Crear_ParametroSQL(Cmd, "@Tipo_Usuario ", SqlDbType.TinyInt, dr_UserWeb("Tipo"))
                        Crear_ParametroSQL(Cmd, "@Contra_Cod", SqlDbType.VarChar, dr_UserWeb("Contra"))
                        Crear_ParametroSQL(Cmd, "@Usuario_Registro", SqlDbType.VarChar, CInt(dr_UserWeb("RegistroU")))
                        Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, dr_UserWeb("Status"))
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.VarChar, "A")
                        Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, "S")
                        Crear_ParametroSQL(Cmd, "@Fecha_Sinc", SqlDbType.DateTime, fechaActual)
                        Ejecutar_NonQuerySQL(Cmd)

                        Cmd = Crear_ComandoSQL("Usuarios_Update4", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserWeb("ClaveU")))
                        Ejecutar_NonQuerySQL(Cmd)
                    End If
                    'FALTARIA ENVIAR LA FECHA DE SINCRONIZADO EN LA WEB
                End If
            Next
            '--------------------------
            Cnn.Dispose()
            Cmd.Dispose()
            'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "FIN - USUARIOS SINCRONIZADOS CORRECTAMENTE EN BDD LOCAL.")

            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "FIN - OCURRIÓ ERROR AL SINCRONIZAR USUARIOS DE WEB A LOCAL." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizarUsuarios_aWEB() As Boolean
        'SINCRONIZAR USUARIOS DE BDD LOCAL >----> WEB
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "INICIO - SINCRONIZAR USUARIOS DE LOCAL A BDD WEB.")

        Dim dt_UsuariosWEB As DataTable = cls_CashWeb.fn_ConsultaUsuarios(varPub.Cve_Sucursal)
        If dt_UsuariosWEB Is Nothing Then
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "FIN - OCURRIÓ UN ERROR AL DESCARGAR LOS USUARIOS.")
            Return False
        End If
        Dim Cant_RegistrosWEB As Integer = dt_UsuariosWEB.Rows.Count

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            'Aqui Quitar el <STATUS> de sincronizaR  2abril 2013
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Usuarios_Read7", CommandType.StoredProcedure, Cnn)
            Dim dt_UsuariosLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Dim Encontro As Boolean = False
            Dim fechaActual As String = ""

            If dt_UsuariosLocal.Rows.Count = 0 Then
                fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "FIN - NO EXISTEN USUARIOS EN LA BDD LOCAL.")
                Return False
            End If

            For Each dr_UserLocal As DataRow In dt_UsuariosLocal.Rows
                If IsDBNull(dr_UserLocal("Status2")) Then dr_UserLocal("Status2") = ""
                Encontro = False
                Select Case Cant_RegistrosWEB

                    Case 0
                        fechaActual = Fecha & " " & Hora
                        If cls_CashWeb.fn_GuardaUsuarios(dr_UserLocal("Clave"), dr_UserLocal("Nombre"), dr_UserLocal("Contra"), dr_UserLocal("Tipo"), dr_UserLocal("Status"), dr_UserLocal("NombreCorto"), fechaActual, dr_UserLocal("Fecha_Registro")) Then
                            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS ", "GUARDANDO USUARIO CON CLAVE: " & dr_UserLocal("Clave") & " EN BDD WEB")
                            If Not Usuarios_ActualizarEstadoASincronizado(fechaActual, dr_UserLocal("Clave")) Then
                                Throw New ArgumentException("Exception Occured")
                            End If
                            'Call fn_EscribirLog(UsuarioClave, "Sincronizacion ", "Actualiza Usuarios Sincronizado = 'S' en bdd local e inserta en Web Usuarios")
                        Else
                            Throw New ArgumentException("Exception Occured")
                        End If

                    Case Is > 0 'Si hay mas de 1 registro

                        For Each dr_UserWeb As DataRow In dt_UsuariosWEB.Rows
                            If dr_UserLocal("Clave") = dr_UserWeb("ClaveU") AndAlso dr_UserLocal("Tipo") <> 0 Then
                                'Si este ya esta en la Web actualiza status de sincronizado en local 
                                Encontro = True
                                If dr_UserLocal("Status2") = "U" Then
                                    fechaActual = Fecha & " " & Hora
                                    If cls_CashWeb.fn_Usuarios_ModificarLocalAWeb(varPub.Cve_Sucursal, dr_UserLocal("Clave"), dr_UserLocal("Nombre"), dr_UserLocal("NombreCorto"), dr_UserLocal("Tipo")) Then

                                        If Not Usuarios_ActualizarEstadoASincronizado(fechaActual, dr_UserLocal("Clave")) Then
                                            Throw New ArgumentException("Exception Occured") 'si ocurrió un error al actualizar estado sincronizado lanzar exception
                                        End If

                                        Cmd = Crear_ComandoSQL("Usuarios_Update8", CommandType.StoredProcedure, Cnn)
                                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserLocal("Clave")))

                                        If Ejecutar_NonQuerySQL(Cmd) <= 0 Then Throw New ArgumentException("Exception Occured") ' si no se actualiza status2 lanzar exception

                                    Else
                                        Throw New ArgumentException("Exception Occured") 'si ocurrió un error al sincronizar usuario con el awe lanzar exception
                                    End If
                                ElseIf dr_UserLocal("Status2") = "D" Then

                                    If fn_Usuarios_Eliminar(dr_UserLocal("Clave")) > 0 Then

                                        Cmd = Crear_ComandoSQL("Usuarios_Delete", CommandType.StoredProcedure, Cnn)
                                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserLocal("Clave")))
                                        Ejecutar_NonQuerySQL(Cmd)
                                    Else
                                        Throw New ArgumentException("Exception Occured")
                                    End If
                                End If

                                ''Call fn_EscribirLog(UsuarioClave, "Sincronizacion ", "Sincroniza Usuarios actualizando sincronizado = 'S' en bdd local")
                                Exit For
                            End If
                        Next

                        If Encontro = False Then
                            If dr_UserLocal("Status2") = "D" Then ' si eliminaron usuario antes de sincronizar

                                Cmd = Crear_ComandoSQL("Usuarios_Delete", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserLocal("Clave")))
                                Ejecutar_NonQuerySQL(Cmd)

                            ElseIf dr_UserLocal("Status2") = "U" Then ' si actualizaron usuario antes de sincronizar
                                fechaActual = Fecha & " " & Hora

                                If cls_CashWeb.fn_GuardaUsuarios(dr_UserLocal("Clave"), dr_UserLocal("Nombre"), dr_UserLocal("Contra"), dr_UserLocal("Tipo"), dr_UserLocal("Status"), dr_UserLocal("NombreCorto"), fechaActual, dr_UserLocal("Fecha_Registro")) Then
                                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS ", "GUARDANDO USUARIO CON CLAVE: " & dr_UserLocal("Clave") & " EN BDD WEB")

                                    Cmd = Crear_ComandoSQL("Usuarios_Update4", CommandType.StoredProcedure, Cnn)
                                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserLocal("Clave")))
                                    Ejecutar_NonQuerySQL(Cmd)

                                    Cmd = Crear_ComandoSQL("Usuarios_Update2", CommandType.StoredProcedure, Cnn)
                                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(dr_UserLocal("Clave")))
                                    Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, "A")

                                    Ejecutar_NonQuerySQL(Cmd)

                                End If

                            ElseIf dr_UserLocal("Status2") = "A" Then

                                fechaActual = Fecha & " " & Hora
                                'si no encontró entonces insertamos en web usuariosy Update usuarioslocal
                                If cls_CashWeb.fn_GuardaUsuarios(dr_UserLocal("Clave"), dr_UserLocal("Nombre"), dr_UserLocal("Contra"), dr_UserLocal("Tipo"), dr_UserLocal("Status"), dr_UserLocal("NombreCorto"), fechaActual, dr_UserLocal("Fecha_Registro")) Then
                                    If Not Usuarios_ActualizarEstadoASincronizado(fechaActual, dr_UserLocal("Clave")) Then
                                        Throw New ArgumentException("Exception Occured") 'si ocurrió un error al actualizar estado sincronizado lanzar exception
                                    End If
                                Else
                                    Throw New ArgumentException("Exception Occured") 'si ocurrió un error al sincronizar usuario con el awe lanzar exception
                                End If
                            End If
                        End If
                End Select
            Next
            Cnn.Dispose()
            Cmd.Dispose()
            'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "FIN - USUARIOS SINCRONIZADOS CORRECTAMENTE EN BDD WEB.")
            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR USUARIOS", "FIN - OCURRIÓ UN ERROR AL SINCRONIZAR USUARIOS HACIA LA WEB." & ex.Message.ToUpper)
            Return False
        End Try
    End Function

    Public Shared Function Usuarios_ActualizarEstadoASincronizado(FechaActual As String, Clave_Usuario As String) As Boolean
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Try
            Cnn = Crear_ConexionSQL(_Cnx)

            Cmd = Crear_ComandoSQL("Usuarios_Update4", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(Clave_Usuario))
            Ejecutar_NonQuerySQL(Cmd)
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return False
        End Try
        Return True
    End Function

    Public Shared Function fn_SincronizarDenominaciones_aLOCAL() As Boolean
        Try
            'Funcion que trae todas  las Denominaciones en BDD web a local
            'sincroniza de WEb hacia local ... falta de local hacia web
            Dim dt_Denominaciones As DataTable = cls_CashWeb.fn_ConsultaDenominaciones
            If dt_Denominaciones IsNot Nothing AndAlso dt_Denominaciones.Rows.Count > 0 Then

                Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

                Dim Cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Read2", CommandType.StoredProcedure, Cnn)
                Dim dt_DenomLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)

                Dim Encontro As Boolean = False
                For Each cveDenom As DataRow In dt_Denominaciones.Rows

                    For Each cveDenomLocal As DataRow In dt_DenomLocal.Rows
                        If cveDenom("ClaveD") = cveDenomLocal("Clave_Denominacion") Then
                            Encontro = True
                            Exit For
                        End If
                    Next
                    If Not Encontro Then
                        Cmd = Crear_ComandoSQL("Denominaciones_Insert", CommandType.StoredProcedure, Cnn)
                        Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, cveDenom("ClaveD"))
                        Crear_ParametroSQL(Cmd, "@Denominacion", SqlDbType.Money, cveDenom("Denominacion"))
                        Crear_ParametroSQL(Cmd, "@Clave_Moneda", SqlDbType.VarChar, cveDenom("ClaveM"))
                        Crear_ParametroSQL(Cmd, "@Status_Sincronizado", SqlDbType.VarChar, "S")
                        Crear_ParametroSQL(Cmd, "@Fecha_Sincronizado", SqlDbType.VarChar, Fecha & " " & Hora)

                        Ejecutar_NonQuerySQL(Cmd)
                        Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZACIÓN ", "GUARDANDO DENOMINACIÓN:" & cveDenom("ClaveD"))

                    End If
                    Encontro = False
                Next
                Cnn.Dispose()
                Cmd.Dispose()
            End If

            Return True
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DENOMINACIONES", "ERROR AL SINCRONIZAR DENOMINACIONES EN BDD LOCAL." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizarDenominaciones_aWEB() As Boolean
        Try
            'Funcion sincroniza Denominaciones de local hacia ----> web
            Dim dt_Denominaciones As DataTable = cls_CashWeb.fn_ConsultaDenominaciones

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Denominaciones_Read3", CommandType.StoredProcedure, Cnn)
            Dim dt_DenomLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Dim Encontro As Boolean = False

            If dt_DenomLocal IsNot Nothing AndAlso dt_DenomLocal.Rows.Count > 0 Then '-------

                For Each cveDenomLocal As DataRow In dt_DenomLocal.Rows
                    If dt_Denominaciones Is Nothing Then
                        If cls_CashWeb.fn_GuardaDenominaciones(cveDenomLocal("Clave"), cveDenomLocal("Denominacion"), cveDenomLocal("ClaveM")) Then
                            Cmd = Crear_ComandoSQL("Denominaciones_Update", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, cveDenomLocal("Clave"))
                            Ejecutar_NonQuerySQL(Cmd)
                            ''Call fn_EscribirLog(UsuarioClave, "Sincronizacion ", "Actualiza  denominaciones sincronizado ='S' en bdd local e inserta en Web Denominaciones")
                        End If
                    Else
                        '--------------------
                        For Each cveDenom As DataRow In dt_Denominaciones.Rows
                            If cveDenomLocal("Clave") = cveDenom("ClaveD") Then
                                'Si este ya esta en la Web actualiza status de sincronizado en local 
                                Encontro = True
                                Cmd = Crear_ComandoSQL("Denominaciones_Update", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, cveDenomLocal("Clave"))
                                Ejecutar_NonQuerySQL(Cmd)
                                ''Call fn_EscribirLog(UsuarioClave, "Sincronizacion ", "Actualiza denominaciones sincronizado ='S' en bdd local")
                                Exit For
                            End If
                        Next
                        If Not Encontro Then
                            'si no encontró entonces insertamos en web 
                            If cls_CashWeb.fn_GuardaDenominaciones(cveDenomLocal("Clave"), cveDenomLocal("Denominacion"), cveDenomLocal("ClaveM")) Then
                                Cmd = Crear_ComandoSQL("Denominaciones_Update", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Clave_Denominacion", SqlDbType.VarChar, cveDenomLocal("Clave"))
                                Ejecutar_NonQuerySQL(Cmd)
                                ''Call fn_EscribirLog(UsuarioClave, "Sincronizacion ", "Actualiza  denominaciones sincronizado ='S' en bdd local e inserta en Web Denominaciones")
                            End If
                        End If
                        '-------------
                    End If
                Next
                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            Else
                Return False
            End If '*-----
        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR DENOMINACIONES", " ERROR AL SINCRONIZAR DENOMINACIONES EN LA BDD WEB." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Function fn_SincronizaArchivoLog_aWEB(ByVal pathArchivo As String, ByVal FechaFile As DateTime, ByVal NameFile As String) As Boolean
        Try
            Dim Archivobyte As Byte() = fn_ConvierteArchivoaBytes(pathArchivo)
            If cls_CashWeb.fn_GuardaArchivo_Log(FechaFile, Archivobyte, NameFile) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function fn_SincronizarPrivilegios_aLocal() As Boolean
        Dim Cnn As SqlConnection = Nothing
        Dim dt_Usuarios As DataTable = fn_Usuarios_Read(0)
        Dim Encontro As Boolean = False
        For Each dr_Usuarios As DataRow In dt_Usuarios.Rows

            ' si es clave supe admnin entoces procesar
            If dr_Usuarios("Clave_Usuario") = 925074 Or dr_Usuarios("Clave_Usuario") = 491752 Then Continue For

            'Obtiene privilegios por usuario en la web
            Dim dt_PrivilegiosWeb As DataTable = cls_CashWeb.fn_Consulta_PrivilegiosWeb(dr_Usuarios("Clave_Usuario"))
            'Obtiene privilegios por usuario en la  bd Local
            Dim dt_PrivilegiosLocal As DataTable = PrivilegiosLocal_Read(dr_Usuarios("Clave_Usuario"))


            For Each dr_PrivilegiosWeb As DataRow In dt_PrivilegiosWeb.Rows
                Encontro = False ' resetea la variable
                For Each dr_PrivilegiosLocal As DataRow In dt_PrivilegiosLocal.Rows
                    If dr_PrivilegiosWeb("ClaveO") = dr_PrivilegiosLocal("Clave_Opcion") Then
                        If dr_PrivilegiosWeb("Status2") = "D" Then ' verifica si es privilegio eliminado
                            If PrivilegiosLocal_Delete(dr_PrivilegiosWeb("ClaveU"), dr_PrivilegiosWeb("ClaveO")) Then ' Si elimino correctamente en la local entonces eliminar en la Web
                                cls_CashWeb.fn_Elimina1X1_PrivilegiosWeb(dr_PrivilegiosWeb("ClaveU"), dr_PrivilegiosWeb("ClaveO"))
                            End If
                        End If
                        Encontro = True
                        Exit For ' sale del bucle interno
                    End If
                Next

                If Not Encontro Then
                    Call PrilegiosLocal_Create(dr_PrivilegiosWeb("ClaveU"), dr_PrivilegiosWeb("ClaveO"))
                End If
            Next
        Next
        Return True
    End Function

    Public Shared Function fn_SincronizarPrivilegios_AWeb() As Boolean
        Return False
    End Function


    Private Shared Function PrivilegiosLocal_Read(Clave_Usuario As String) As DataTable
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing

        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Privilegios_Read3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(Clave_Usuario))
            dt = Ejecutar_ConsultaSQL(Cmd)
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return Nothing
        End Try
        Return dt

    End Function

    Private Shared Function PrivilegiosLocal_Delete(Clave_Usuario As String, Clave_Opcion As String) As Boolean
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing

        Try
            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(Clave_Usuario))
            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Clave_Opcion)

            Ejecutar_NonQuerySQL(Cmd)

        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return False
        End Try
        Return True
    End Function

    Private Shared Function PrilegiosLocal_Create(Clave_Usuario As String, Clave_Opcion As String) As Boolean
        Dim Cnn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing
        Try

            Cnn = Crear_ConexionSQL(_Cnx)
            Cmd = Crear_ComandoSQL("Privilegios_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(Clave_Usuario))
            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Clave_Opcion)
            Ejecutar_NonQuerySQL(Cmd)
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return False
        End Try
        Return True
    End Function

#End Region

#Region " LLenar combo sucursales"

    Public Shared Sub fn_Parametros_LlenarComboSucursales(ByRef cmb As ComboBox)
        Try

            Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim Query As String = "Select Nombre_Sucursal + '/'+ " &
                                  "Clave_Cliente + '/' + Domicilio + '/' + " &
                                  "Nombre_Corto As Nombre, " &
                                  "Clave_Sucursal As Clave " &
                                  "From Sucursales " &
                                  "Where Clave_Sucursal <> '0000' "
            Dim cmd As SqlCommand = Crear_ComandoSQL(Query, CommandType.Text, cnn)

            Dim dt_Sucursales As DataTable = Ejecutar_ConsultaSQL(cmd)
            cmd.Dispose()
            cnn.Dispose()

            Dim dr As DataRow = dt_Sucursales.NewRow
            dr("Nombre") = "-*-*-*-"
            dr("Clave") = "Nuevo"
            dt_Sucursales.Rows.InsertAt(dr, 0)

            cmb.ValueMember = "Nombre"
            cmb.DisplayMember = "Clave"
            ' --------------
            Call fn_EscribirLog(varPub.UsuarioClave, "Parametros ", "llenando combo lista sucursales")

            cmb.DataSource = dt_Sucursales

        Catch ex As Exception
            cmb.DataSource = Nothing
            Dim dt As DataTable = New DataTable
            dt.Columns.Add("Nombre")
            dt.Columns.Add("Clave")
            dt.Rows.Add("-*-", "Clave")

            cmb.ValueMember = "Nombre"
            cmb.DisplayMember = "Clave"
            cmb.DataSource = dt
            Call fn_EscribirLog(varPub.UsuarioClave, "Parametros ", "error al llenar lista sucursales")

            Call fn_MsgBox(" error al Intentar Llenar la Lista Desplegable de Sucursales.", MessageBoxIcon.Error & ex.Message.ToUpper)
        End Try
    End Sub
#End Region

#Region "Consulta de Logs para Enviar a BDD Central"
    Public Shared Sub fn_VerificarEnvio_ArchivoLog()
        If varPub.Conectividad Then
            If fn_VerificaConexionInternet() Then
                'Enviar archivo a la bdd central(web)
                Dim FechaAnterior As Date = CDate(fn_Mid(varPub.Ult_Archivo, 5, 10))  '1/03marzo/2013
                Dim Diferencia As Integer
                Dim Fechahoy As Date = Date.Today ' Fecha de hoy actual 5 de marzo
                Diferencia = DateDiff(DateInterval.Day, FechaAnterior, Fechahoy) 'diferencia entre la fech anterior y la actual
                'aqui pueden dar valores de (0,1,2,3,....N)
                If Diferencia > 0 Then
                    Call fn_CargarEnviar_ArchivosLog(FechaAnterior, Fechahoy)
                End If
            End If
        End If
    End Sub

    Public Shared Sub fn_CargarEnviar_ArchivosLog(ByVal Desde As Date, ByVal Hasta As Date)
        Dim Cont As Integer = 0
        Dim Direc As New IO.DirectoryInfo(varPub.Ruta_Log & "\")
        Dim aryFi As IO.FileInfo() = Direc.GetFiles("*.txt")
        'Dim Fichero As IO.FileInfo
        Dim Dife As Integer = DateDiff(DateInterval.Day, Desde, Hasta)
        Dim Fecha_Log As Date
        Dim Encontrado As Boolean

        For ILocal As Integer = 0 To Dife - 1
            Fecha_Log = DateAdd(DateInterval.Day, ILocal, Desde)
            Encontrado = False
            For Each fi In aryFi

                If fi.Name = "Log_" & Format(Fecha_Log, "yyyy-MM-dd") & ".txt" Then
                    If fn_SincronizaArchivoLog_aWEB(Direc.ToString & fi.Name, Fecha_Log, fi.Name) Then
                        Encontrado = True
                    Else
                        Encontrado = False
                        Cont += 1
                        If Cont = 1 Then varPub.Ult_Archivo = fi.Name
                    End If
                Else
                    Continue For
                End If
                If Encontrado = True Then Exit For
            Next
        Next
        '----------revisar si fallo algun archivo en guardar
        If Cont > 0 Then
            varPub.Ult_Archivo = varPub.Ult_Archivo 'guarda el 1° que fallo si hubo varios
        Else
            varPub.Ult_Archivo = varPub.Nombre_Archivo
        End If
        Dim Persistentes As cls_VariablesPersistentes = New cls_VariablesPersistentes
        Persistentes.Persistir()
        Persistentes.Cargar()
        '----------------------------------
    End Sub

#End Region

#Region "Verificar conexion Salida a Internet"
    Public Shared Function GetExternalIp() As String
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

    Public Shared Function fn_VerificaConexionInternetVB() As Boolean

        If My.Computer.Network.IsAvailable() Then
            Try

                If My.Computer.Network.Ping("www.google.mx", 2000) Then
                    'fn_EscribirLog(UsuarioClave, "", "Verificando conexion a internet Realizada con exito")
                    Return True
                Else
                    fn_EscribirLog(varPub.UsuarioClave, "----", "NO HUBO CONEXIÓN A INTERNET.")
                    Return False
                End If

            Catch ex As Net.NetworkInformation.PingException
                fn_EscribirLog(varPub.UsuarioClave, "----", "ERROR AL VERIFICAR CONEXIÓN A INTERNET.")
                Return False
            End Try

        Else
            Return False
        End If
    End Function

    Public Shared Function Fn_ConexionInternet_Cajeros() As Boolean
        '---forma1 -- YA ES .NET Y NO VB6
        Try
            Dim pingreq As New Net.NetworkInformation.Ping
            Dim EstadoIP As Net.NetworkInformation.IPStatus
            Dim TiempoIdaVuelta As Int64 = 0
            'Si es 0 no hay salida a internet, aunque 0 puede ser correcto tambien,
            'Lo mejor es validar el estado de la IP
            'TiempoIdaVuelta = pingreq.Send(hostNameOrAddress, 2000).RoundtripTime

            If varPub.ConexionwebAdmin = 0 Then
                Return False
            Else

                If Not varPub.hostNameOrAddress = "" Then
                    EstadoIP = pingreq.Send(varPub.hostNameOrAddress, 2500).Status

                    Return (EstadoIP = Net.NetworkInformation.IPStatus.Success)
                Else
                    fn_EscribirLog(varPub.UsuarioClave, "----", " NO HAY  CONEXIÓN A INTERNET. ")
                    Return False
                End If
            End If
        Catch ex As Net.NetworkInformation.PingException
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 81, varPub.IdPantalla, "ERROR AL VERIFICAR CONEXIÓN A INTERNET. " & ex.Message.ToUpper)
            fn_EscribirLog(varPub.UsuarioClave, "----", "ERROR AL VERIFICAR CONEXIÓN A INTERNET. " & ex.Message.ToUpper)
            Return False
        End Try

        '---forma2---
        '
        'Dim host As String = "www.google.mx" ' use any other machine name
        'Dim pingreq As Net.NetworkInformation.Ping = New Net.NetworkInformation.Ping()
        'Dim rep As Net.NetworkInformation.PingReply = pingreq.Send(host)
        'Console.WriteLine("Pinging {0} [{1}]", host, rep.Address.ToString())
        'Console.WriteLine("Reply From {0} : time={1} TTL={2}", rep.Address.ToString(), rep.RoundtripTime, rep.Options.Ttl)
    End Function

    Public Shared Function fn_VerificaConexionInternet() As Boolean
        Dim objUrl As New System.Uri("http://www.google.com.mx/")
        ' Setup WebRequest
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            ' Attempt to get response and return True

            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            ' Error, exit and return False
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 81, varPub.IdPantalla, "ERROR AL VERIFICAR CONEXIÓN A INTERNET. " & ex.Message.ToUpper)
            fn_EscribirLog(varPub.UsuarioClave, "----", "ERROR AL VERIFICAR CONEXIÓN A INTERNET. " & ex.Message.ToUpper)
            objWebReq = Nothing
            Return False
        End Try
    End Function





#End Region

#Region "IMPRESION DE PRUEBA AL REINICIAR COLA DE IMPRESION DE IMPRESORA"
    Public Shared Sub fn_ImpresiondePrueba()
        Try
            ' ejemplo simple para imprimir en .NET
            ' Usamos una clase del tipo PrintDocument
            Dim printDoc As New Printing.PrintDocument
            ' asignamos el método de evento para cada página a imprimir
            AddHandler printDoc.PrintPage, AddressOf print_PrintPage
            ' indicamos que queremos imprimir
            printDoc.Print()

        Catch ex As Exception
            fn_MsgBox("Error al imprimir pagina de prueba. " & ex.Message, MessageBoxIcon.Error)
            fn_EscribirLog(varPub.UsuarioClave, "PARÁMETROS", "NO SE PUDO IMPRIMIR PAGINA DE PRUEBA" & ex.Message.ToUpper)
        End Try

    End Sub

    Private Shared Sub print_PrintPage(ByVal sender As Object,
                           ByVal e As Printing.PrintPageEventArgs)
        'codigo de barra C39HrP36DlTt
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim prFont As New Font("Arial", 12, FontStyle.Bold) 'negrita
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics)

        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        Dim Sf As New Drawing.StringFormat
        Sf.Alignment = StringAlignment.Center 'centrado

        Dim Alto As Integer = 8 * 2
        Dim Ancho As Integer = 64

        If varPub.Tamaño_Papel = TamañoPapel._58mm Then
            Alto = 7 * 2
            Ancho = 48
        End If

        Dim X As Integer = 4 + varPub.MargenIzq

        Call fn_EscribirLog(varPub.UsuarioClave, "Parametros", "IMPRIMIENDO HOJA DE PRUEBA")

        Dim R As New Rectangle(X, 10, Ancho, Alto)
        e.Graphics.DrawString("Servicio Integral de Seguridad S.A. de C.V.", prFont, Brushes.Black, R, Sf)

        Dim R1 As New Rectangle(X, 30, Ancho, 8)
        e.Graphics.DrawString("Módulo CashFlow", prFont, Brushes.Black, R1, Sf)

        Dim R2 As New Rectangle(X, 40, Ancho, Alto)
        e.Graphics.DrawString("Fecha: " & Format(Now.Date, "dd/MM/yyyy") & "-" & Hora, prFont, Brushes.Black, R2, Sf)

        '' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

    End Sub

#End Region

#Region "Corte"
    Public Shared Function Fn_CerrarCorte() As Boolean
        Try

            fn_ConsultaSaldos_Imprimir(1)

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            ' en sql compact 4.0 no se debe enviar Null como valor en campos nulos

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cortes_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, varPub.UsuarioClave)
            Crear_ParametroSQL(Cmd, "@Corte_Actual", SqlDbType.Int, varPub.CorteActual)
            Dim dtFolio As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Cmd.Dispose()
            Cnn.Dispose()
            Call fn_SincronizaCorte_aWEB()
            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE", "Corte cerrado correctamente.")
            Return True
        Catch ex As Exception
            Return False
            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE", "error al cerrar Corte" & ex.Message.ToUpper)
        End Try
    End Function

    Public Shared Function Fn_AbrirCorte() As Boolean
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing

        Try


            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Cortes_Insert")
            Crear_ParametroSQL(Cmd, "@Usuario_Clave", SqlDbType.Int, varPub.UsuarioClave)
            Dim IdCorte As Integer = CInt(Ejecutar_ScalarTSQL(Cmd))

            If IdCorte > 0 Then
                varPub.CorteActual = IdCorte
            End If

            tr.Commit()
            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE", "Corte generado correctamente.")
            Return True
        Catch ex As Exception
            tr.Rollback()
            Cmd.Dispose()
            Cnn.Dispose()
            tr.Dispose()
            varPub.CorteActual = 0
            Return False
            Call fn_EscribirLog(varPub.UsuarioClave, "CORTE", "Error al generar Corte." & ex.Message.ToUpper)
        End Try
    End Function
#End Region

#Region "Operacion de Cajas"
    Public Shared Function fn_SincronizarCajas_aLOCAL(ByVal ClaveSucursal As String) As Boolean
        'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJAS", "INICIO - SINCRONIZAR CAJAS DE BDD WEB A LOCAL.")
        Try
            'Funcion que trae todas  los casets si hay de la BDD web a local
            Dim dt_Cajas As DataTable = cls_CashWeb.fn_ConsultaCajas(ClaveSucursal)

            If dt_Cajas Is Nothing Then
                fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJAS", "OCURRIÓ UN ERROR AL DESCARGAR LAS CAJAS.")
                Return False
            End If
            If dt_Cajas.Rows.Count = 0 Then
                fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJAS", "NO EXISTEN CAJAS EN LA BDD WEB.")
                Return True
            End If

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_CajasLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Dim Encontro As Boolean = False

            For Each cveCajas As DataRow In dt_Cajas.Rows
                Encontro = False
                For Each cveCajaLocal As DataRow In dt_CajasLocal.Rows
                    If cveCajas("Clave_Caja") = cveCajaLocal("Caja") Then
                        Encontro = True
                        Exit For
                    End If
                Next

                If Encontro = False Then

                    Cmd = Crear_ComandoSQL("Cajas_Insert", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@Clave_Caja", SqlDbType.VarChar, cveCajas("Clave_caja"))
                    Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, cveCajas("Descripcion"))
                    Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, cveCajas("Status"))
                    Crear_ParametroSQL(Cmd, "@Fecha_Reg", SqlDbType.DateTime, cveCajas("Fecha_Registro"))
                    Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.VarChar, cveCajas("Sincronizado"))


                    Ejecutar_NonQuerySQL(Cmd)
                    Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJAS ", "GUARDANDO CAJA Nº DE : " & cveCajas("Clave_Caja") & " EN BDD LOCAL")
                End If
            Next
            '11/06/2019 DEBE CAMBIAR LA VARIABLE POR ERRORES DE LOGICA AL QUERER DEPOSITAR
            Cmd = Crear_ComandoSQL("Cajas_Read", CommandType.StoredProcedure, Cnn)
            Dim dt_CajasLocalCantidad As DataTable = Ejecutar_ConsultaSQL(Cmd)
            If Not IsNothing(dt_CajasLocalCantidad) Then
                varPub.Cantidad_Cajas = dt_CajasLocalCantidad.Rows.Count
            End If

            Cnn.Dispose()
            Cmd.Dispose()
            'Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJAS", "FIN - CAJAS SINCRONIZADOS CORRECTAMENTE EN BDD LOCAL.")
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "SINCRONIZAR CAJAS", "FIN -  ERROR AL SINCRONIZAR CAJAS EN LA BDD LOCAL." & ex.Message.ToUpper)
            Return False
        End Try

    End Function

    Public Shared Sub fn_Cajas_Llenar(ByRef lsv As ListView)
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO CAJAS", "INICIO - LLENAR LISTA CAJAS.")
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            '5nov quite idcaset


            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_Read2", CommandType.StoredProcedure, Cnn)
            Dim dt_Caja As DataTable = Ejecutar_ConsultaSQL(Cmd)

            Call fn_LlenarListView(dt_Caja, lsv, "Id_Caja", "")
            Dim w As Integer = lsv.Width

            lsv.Columns(0).Width = w * 0.18
            lsv.Columns(1).Width = w * 0.33
            lsv.Columns(2).Width = w * 0.16
            lsv.Columns(3).Width = w * 0.16
            lsv.Columns(4).Width = w * 0.14
            lsv.Columns(4).TextAlign = HorizontalAlignment.Center
            lsv.Columns(5).Width = w * 0.16

            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - LISTA DE CAJAS CARGADAS CORRECTAMENTE.")
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - OCURRIÓ UN ERROR AL CARGAR LISTA. " & ex.Message.ToUpper)
            Call fn_MsgBox(" Error al Intentar Llenar la Lista.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Function fn_Cajas_Create(ByVal Numero_Caja As String, ByVal Descripcion As String, IpCaja As String, ByRef esActualizar As Boolean, IdCaja As Integer) As Integer
        Dim Paquete1 As String = ""
        Dim Paquete2 As String = ""
        Dim Paquete3 As String = ""
        Dim Paquete4 As String = ""
        Dim PuntosPaquetes As Integer

        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "INICIO - CREAR NUEVA CAJA.")

        'Validaciones
        If Numero_Caja.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - NUMERO DE CAJA NO CAPTURADA.")
            Return 2
        End If

        If Numero_Caja.Length > 6 Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - NUMERO CAJA NO VÁLIDA, RANGO PERMITIDO DEL 1 - 6.")
            Return 2
        End If
        If Not esActualizar Then

            If fn_Caja_ClaveExiste(Numero_Caja) Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - CLAVE CAJA YA EXISTE: " & Numero_Caja)
                Return 3
            End If

        End If

        If Descripcion.Trim = "" Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS ", "FIN - DESCRIPCION CAJA NO CAPTURADA.")
            Return 4
        End If

        If (fn_Caja_Maxima()) Then
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - CANTIDAD DE CAJAS 18.")
            Return 5
        End If

        If varPub.ManejaConexionWebService = 1 Then
            If IpCaja.Trim = "" Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - NUMERO IP DE IP NO CAPTURADO.")
                Return 6
            End If
        End If

        If varPub.ManejaConexionWebService = 1 Then ' si maneja conexion con web service 

            If fn_Caja_IPExiste(IpCaja) Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - IP CAJA YA EXISTE: " & IpCaja)
                Return 7
            End If

            For Each i As String In IpCaja
                If i.Trim = "." Then
                    PuntosPaquetes += 1
                End If
            Next

            If PuntosPaquetes < 3 Or PuntosPaquetes > 3 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - IP CAJA DATO NO VALIDO: " & IpCaja)
                PuntosPaquetes = 0
                Return 8
            End If

            PuntosPaquetes = 1

            For i As Integer = 0 To IpCaja.Length - 1
                If IpCaja.Chars(0) = "." Then Exit For

                If PuntosPaquetes = 1 Then
                    If IpCaja.Chars(i) = "." Then
                        PuntosPaquetes = 2
                        Continue For
                    Else
                        Paquete1 = Paquete1 + IpCaja.Chars(i)
                    End If
                End If

                If PuntosPaquetes = 2 Then
                    If IpCaja.Chars(i) = "." Then
                        PuntosPaquetes = 3
                        Continue For
                    Else
                        Paquete2 = Paquete2 + IpCaja.Chars(i)
                    End If

                End If

                If PuntosPaquetes = 3 Then
                    If IpCaja.Chars(i) = "." Then
                        PuntosPaquetes = 4
                        Continue For
                    Else

                        Paquete3 = Paquete3 + IpCaja.Chars(i)
                    End If

                End If

                If PuntosPaquetes = 4 Then
                    Paquete4 = Paquete4 + IpCaja.Chars(i)
                End If
            Next

            If Len(Paquete1) = 0 Or Len(Paquete1) > 3 Then Return 8
            If Len(Paquete2) = 0 Or Len(Paquete2) > 3 Then Return 8
            If Len(Paquete3) = 0 Or Len(Paquete3) > 3 Then Return 8
            If Len(Paquete4) = 0 Or Len(Paquete4) > 3 Then Return 8


            If Paquete1 = "" Then Paquete1 = 1
            If Paquete2 = "" Then Paquete1 = 1
            If Paquete3 = "" Then Paquete1 = 1
            If Paquete4 = "" Then Paquete1 = 1

            If CInt(Paquete1) > 255 Then
                Paquete1 = ""
                Return 8
            End If

            If CInt(Paquete2) > 255 Then
                Paquete1 = ""
                Return 8
            End If
            If CInt(Paquete3) > 255 Then
                Paquete1 = ""
                Return 8
            End If

            If CInt(Paquete4) > 255 Then
                Paquete1 = ""
                Return 8
            End If

            PuntosPaquetes = 0

        End If

        Try
            If esActualizar Then
                Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
                Dim cmd As SqlCommand
                Dim fechaActual As String = Fecha & " " & Hora

                cmd = Crear_ComandoSQL("Cajas_Update", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(cmd, "@Id_Caja", SqlDbType.Int, IdCaja)
                Crear_ParametroSQL(cmd, "@Descripcion", SqlDbType.VarChar, Descripcion)
                Crear_ParametroSQL(cmd, "@Ip_Caja", SqlDbType.VarChar, IpCaja)
                Dim filasAfectadas As Integer = Ejecutar_NonQuerySQL(cmd)
                '--------------------------------------------------------------------------------------
                If Not IsNothing(filasAfectadas) Then
                    If varPub.Conectividad Then
                        If fn_VerificaConexionInternet() Then
                            If cls_CashWeb.fn_EditarCajas(IdCaja, Descripcion) Then
                                Return 1
                            End If
                        End If
                    End If
                End If
                '--------------------------------------------------------------------------------------

                Return 1
            Else

                Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
                Dim Cmd As SqlCommand
                Dim fechaActual As String = Fecha & " " & Hora


                Cmd = Crear_ComandoSQL("Cajas_Insert2", CommandType.StoredProcedure, Cnn)
                Crear_ParametroSQL(Cmd, "@Clave_Caja", SqlDbType.VarChar, Numero_Caja.Trim)
                Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, Descripcion.Trim)
                Crear_ParametroSQL(Cmd, "@Ip_Caja", SqlDbType.VarChar, IpCaja)

                Dim Id_Caja As Integer = Ejecutar_ScalarSQL(Cmd)

                Cmd.Dispose()
                Cnn.Dispose()

                If Id_Caja > 0 Then
                    '---------Si hay Conectividad Hacer
                    If (varPub.ConexionwebAdmin = 1) Then
                        '---
                        If fn_VerificaConexionInternet() Then

                            Call fn_SincronizaUltimaConexion()
                            If cls_CashWeb.fn_GuardaCajas(Numero_Caja, Descripcion, "A", fechaActual, fechaActual, Id_Caja) Then
                                Cnn = Crear_ConexionSQL(_Cnx)

                                Cmd = Crear_ComandoSQL("Cajas_Update2", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
                                Ejecutar_NonQuerySQL(Cmd)
                                Cmd.Dispose()
                                Cnn.Dispose()

                            End If

                        End If

                    End If
                    '-----------------------
                    Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - CAJA CREAR NUEVA.")
                    Cnn = Crear_ConexionSQL(_Cnx)

                    Cmd = Crear_ComandoSQL("Cajas_ReadUltimo", CommandType.StoredProcedure, Cnn)
                    Dim CantidadCajas As Integer = Ejecutar_ScalarSQL(Cmd)
                    varPub.Cantidad_Cajas = CantidadCajas
                    Cmd.Dispose()
                    Cnn.Dispose()
                    Return 1 'correcto
                Else

                    Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - ERROR AL CREAR NUEVA CAJA.")
                    Return -1
                End If
                Cnn = Crear_ConexionSQL(_Cnx)

            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN -ERROR AL CREAR NUEVA CAJA. " & ex.Message.ToUpper)
            Return -1
        End Try
    End Function

    Public Shared Function fn_Caja_ClaveExiste(ByVal Numero_Caja As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "INICIO - BUSCAR NUMERO DE CAJA EXISTENTE.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_Read3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Caja", SqlDbType.VarChar, Numero_Caja)
            Dim tabla As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - LA CLAVE DE CAJA YA EXISTE")
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - ERROR AL VERIFICAR SI NUMERO CAJA YA EXISTE. " & ex.Message.ToUpper)
            Return False
        End Try
        Return False
    End Function

    Public Shared Function fn_Caja_IPExiste(ByVal IpCaja As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "INICIO - BUSCAR NUMERO DE CAJA EXISTENTE.")

        Try
            Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_Read4", CommandType.StoredProcedure, cnn)
            Crear_ParametroSQL(Cmd, "@Ip_Caja", SqlDbType.VarChar, IpCaja)
            Dim tabla As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - LA IP DE CAJA YA EXISTE")
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - ERROR AL VERIFICAR SI NUMERO CAJA YA EXISTE. " & ex.Message.ToUpper)
            Return False
        End Try
        Return False
    End Function

    Public Shared Function fn_Caja_Maxima() As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "INICIO - CONTAR CAJAS ACTIVAS.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_ReadUltimo", CommandType.StoredProcedure, Cnn)
            Dim Cajas As Integer = CInt(Ejecutar_ScalarSQL(Cmd))

            If Cajas >= 18 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - CONTAR CAJAS ACTIVAS(" & Cajas.ToString & ")")
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE  CAJAS", "FIN - ERROR AL VERIFICAR SI NUMERO CAJA YA EXISTE. " & ex.Message.ToUpper)
            Return False
        End Try
        Return False
    End Function

    Public Shared Function fn_Caja_Status(Id_Caja As Integer, ByVal Numero_Caja As String, ByVal Status As String) As Boolean
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "INICIO - CAMBIAR STATUS.")

        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Query As String = ""
            Dim Cmd As SqlCommand
            Dim fechaActual As String = Fecha & " " & Hora
            Dim StatusAsignar As String = ""
            Dim StatusLog As String = ""

            If Status = "ACTIVO" Then
                StatusAsignar = "B"
                StatusLog = "DE ACTIVO A BAJA"
            ElseIf Status = "BAJA" Then
                StatusAsignar = "A"
                StatusLog = "DE BAJA A ACTIVO"
            End If

            Query = "Update Cajas " &
                    "Set Status = '" & StatusAsignar & "'" &
                    "Where Id_Caja = " & Id_Caja

            Cmd = Crear_ComandoSQL("Cajas_Update3", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_caja", SqlDbType.Int, Id_Caja)
            Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, StatusAsignar)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE  CAJAS", "FIN - SE CAMBIO EL STATUS DE CAJA " & StatusLog)

                If (varPub.ConexionwebAdmin = 1) Then
                    If fn_VerificaConexionInternet() Then
                        Call fn_SincronizaUltimaConexion()
                        cls_CashWeb.fn_CambiarStatus_Caja(StatusAsignar, Id_Caja, Numero_Caja)
                    End If
                End If

                Return True
            Else
                Cmd.Dispose()
                Cnn.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - ERROR AL CAMBIAR LA CAJA DE STATUS.")
                Return False
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJA", "FIN - OCURRIÓ ERROR AL CAMBIAR STATUS DE LA CAJA." & ex.Message.ToUpper)
            Call fn_MsgBox("Ocurrió un Error al cambiar el Status de la Caja.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Shared Function fn_Cajas_Eliminar(ByVal Id_Caja As String, NumeroCaja As String) As Integer
        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "INICIO - ELIMINAR CAJA: " & NumeroCaja)
        Try
            '--------------------------------------
            'elimina caset primero en la web luego abajo...OK
            Dim Eliminaweb As Integer = 0

            If (varPub.ConexionwebAdmin = 1) Then
                If fn_VerificaConexionInternet() Then
                    Try
                        Call fn_SincronizaUltimaConexion()
                        If cls_CashWeb.fn_Elimina_Caja(Id_Caja) Then
                            Eliminaweb = 1
                        Else
                            Eliminaweb = -1
                        End If

                    Catch ex As Exception
                        Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO  DE CAJAS", "FIN - NO SE PUDO ELIMINAR CAJA EN LA WEB" & ex.Message.ToUpper)
                        Eliminaweb = -1
                    End Try
                Else
                    Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - NO SE PUDO ELIMINAR CAJA EN LA WEB")
                    Eliminaweb = -1
                End If
            End If
            '---------------------------------
            ' Pase lo pasew en el Web se debe eliminar localmente
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand

            Cmd = Crear_ComandoSQL("Cajas_Delete", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                Cnn.Dispose()
                Cmd.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - CAJA ELIMINADA CORRECTAMENTE: " & NumeroCaja)

                Cnn = Crear_ConexionSQL(_Cnx)

                Cmd = Crear_ComandoSQL("Cajas_ReadCantidad", CommandType.StoredProcedure, Cnn)
                Dim CantidadCajas As Integer = Ejecutar_ScalarSQL(Cmd)
                varPub.Cantidad_Cajas = CantidadCajas
                Cmd.Dispose()
                Cnn.Dispose()
                Return 1
            Else
                Cnn.Dispose()
                Cmd.Dispose()
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - ERROR AL ELIMINAR LA CAJA")
                Return -1
            End If

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "FIN - ERROR AL ELIMINAR LA CAJA. " & ex.Message.ToUpper)
            Return -1
        End Try
    End Function

    Public Shared Function fn_VerificarCajaExiste_EnDepositos(Id_Caja As Integer) As Integer
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim Query As String = Nothing
        Dim Id_CajaResultado As Integer = 0

        Try
            Cmd = Crear_ComandoSQL("Depositos_ReadCaja", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            Id_CajaResultado = CInt(Ejecutar_ScalarSQL(Cmd))
            Cmd.Dispose()
            Cnn.Dispose()

            If Id_CajaResultado > 0 Then
                Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJAS", "LA CAJA NO SE PUEDE ELIMINAR PORQUE ESTA EN USO.")
            End If

        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "CATALOGO DE CAJA", " ERROR AL OBTENER ID_CAJA DE LA TABLA DEPOSITOS. " & ex.Message.ToUpper)
            Return -1
        End Try

        Return Id_CajaResultado

    End Function

    Public Shared Function fn_SincronizarCajas_aWEB() As Boolean
        Try
            'Funcion sincroniza de local hacia ----> web
            Dim dt_Casets As DataTable = cls_CashWeb.fn_ConsultaCajas(varPub.Cve_Sucursal)

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cajas_Read5", CommandType.StoredProcedure, Cnn)
            Dim dt_CajaLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)
            Dim fechaActual As String = ""
            Dim Encontro As Boolean = False

            If dt_CajaLocal IsNot Nothing AndAlso dt_CajaLocal.Rows.Count > 0 Then '-------

                For Each cveCajaLocal As DataRow In dt_CajaLocal.Rows
                    'preguntar si la tabla de arriba web esta vacia--- si si
                    'tonces insertar directo todo

                    '----nuevo 10 maYO 2013
                    Encontro = False
                    If dt_Casets Is Nothing Then
                        fechaActual = Fecha & " " & Hora

                        '{Si el dt esta vacio inserta en web y actualiza Status='S' en Local}
                        If cls_CashWeb.fn_GuardaCajas(cveCajaLocal("Clave_Caja"), cveCajaLocal("Descripcion"), cveCajaLocal("Fecha_Registro"), cveCajaLocal("Status"), fechaActual, cveCajaLocal("Id_Caja")) Then

                            Cmd = Crear_ComandoSQL("Cajas_Update2", CommandType.StoredProcedure, Cnn)
                            Crear_ParametroSQL(Cmd, "@Id_Caja ", SqlDbType.Int, cveCajaLocal("Id_Caja"))
                            Ejecutar_NonQuerySQL(Cmd)

                            ''Call fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza casets cambiando Sincronizado ='S' en bdd local")
                        End If
                    Else
                        ' Si el dt de la Web ya tiene casets -->
                        For Each cveCasetWeb As DataRow In dt_Casets.Rows
                            If cveCajaLocal("Clave_Caja") = cveCasetWeb("Clave_Caja") Then
                                ' Si ya existe en la web, Solo actualiza Status ='S' en Local
                                Encontro = True

                                Cmd = Crear_ComandoSQL("Cajas_Update2", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Id_Caja ", SqlDbType.Int, cveCajaLocal("Id_Caja"))
                                Ejecutar_NonQuerySQL(Cmd)
                                '' fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza Casets Sincronizado ='S' en bdd local")
                                Exit For
                            End If
                        Next

                        If Not Encontro Then
                            fechaActual = Fecha & " " & Hora

                            'si no encontró entonces insertamos en web 

                            If cls_CashWeb.fn_GuardaCajas(cveCajaLocal("Clave_Caja"), cveCajaLocal("Descripcion"), cveCajaLocal("Status"), cveCajaLocal("Fecha_Registro"), fechaActual, cveCajaLocal("Id_Caja")) Then

                                Cmd = Crear_ComandoSQL("Cajas_Update2", CommandType.StoredProcedure, Cnn)
                                Crear_ParametroSQL(Cmd, "@Id_Caja ", SqlDbType.Int, cveCajaLocal("Id_Caja"))
                                Ejecutar_NonQuerySQL(Cmd)

                                ''Call fn_EscribirLog(UsuarioClave, "Sincronización", "Actualiza casets cambiando Sincronizado ='S' en bdd local")
                            End If
                        End If
                        '-*-----------------------
                    End If
                Next

                Cnn.Dispose()
                Cmd.Dispose()
                Return True
            Else
                Return False
            End If '*------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function fn_CajaLocal_Consulta() As DataTable
        Dim dt_Cajas As DataTable = Nothing
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Try

            Cmd = Crear_ComandoSQL("Cajas_Read6", CommandType.StoredProcedure, Cnn)
            dt_Cajas = Ejecutar_ConsultaSQL(Cmd)

        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return Nothing
        End Try
        Return dt_Cajas
    End Function

    Public Shared Function fn_CajasLocal_Consulta2()
        Dim dt_Cajas As DataTable = Nothing
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Try
            Cmd = Crear_ComandoSQL("Cajas_Read7", CommandType.StoredProcedure, Cnn)
            dt_Cajas = Ejecutar_ConsultaSQL(Cmd)
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return Nothing
        End Try
        Return dt_Cajas
    End Function

#End Region

#Region "Borrar Contenido tablas Tablas"
    Public Shared Function fn_EliminarTablas(Tablas As ListView)

        Return True
    End Function
#End Region


#Region "Borrar Tablas"
    Public Shared Function fn_Cajas_Borrar(ByRef Descripcion As String) As Integer
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoInternet As Boolean

        Try
            If varPub.Conectividad Then
                VerificoInternet = fn_VerificaConexionInternet()

                If VerificoInternet Then
                    EliminoCorrectamente = cls_CashWeb.fn_Cajas_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoInternet Or EliminoCorrectamente Then
                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Cajas_DeleteRegistros")
                Ejecutar_NonQueryTSQL(Cmd)
            End If
            tr.Commit()
            EliminoCorrectamente = False
        Catch ex As Exception
            tr.Rollback()
            Cnn.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CAJAS EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA CAJAS EN LA BASE DE DATOS LOCAL. ")
        Return 1
    End Function

    Public Shared Function fn_Corte_Borrar(ByRef Descripcion As String) As Integer

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoInternet As Boolean

        Try
            If varPub.Conectividad Then

                VerificoInternet = fn_VerificaConexionInternet()
                If VerificoInternet Then
                    EliminoCorrectamente = cls_CashWeb.fn_Corte_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoInternet Or EliminoCorrectamente Then
                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.Text, "Cortes_DeleteRegistros")
                Ejecutar_NonQueryTSQL(Cmd)
            End If
            tr.Commit()
            EliminoCorrectamente = False
        Catch ex As Exception
            tr.Rollback()
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CORTE EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA CORTE EN LA BASE DE DATOS LOCAL. ")
        Return 1
    End Function

    Public Shared Function fn_Casets_Borrar(ByRef Descripcion As String) As Integer

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoInternet As Boolean

        Try
            If varPub.Conectividad Then

                VerificoInternet = fn_VerificaConexionInternet()

                If VerificoInternet Then
                    EliminoCorrectamente = cls_CashWeb.fn_Casets_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoInternet Or EliminoCorrectamente Then
                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Casets_DeleteRegistros")
                Ejecutar_NonQueryTSQL(Cmd)
            End If
            tr.Commit()
            EliminoCorrectamente = False
        Catch ex As Exception
            tr.Rollback()
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CASETS  EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA CASETS EN LA BASE DE DATOS LOCAL. ")
        Return 1
    End Function

    Public Shared Function fn_DepositosD_Borrar(ByRef Descripcion As String) As Integer

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoIntenet As Boolean
        Try
            If varPub.Conectividad Then
                VerificoIntenet = fn_VerificaConexionInternet()

                If VerificoIntenet Then

                    EliminoCorrectamente = cls_CashWeb.fn_DepositosD_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoIntenet Or EliminoCorrectamente Then
                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Depositos_DeleteRegistros")
                Ejecutar_NonQueryTSQL(Cmd)
            End If
            tr.Commit()
            EliminoCorrectamente = False
        Catch ex As Exception
            tr.Rollback()
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA DEPOSITOSD EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA DEPOSITOSD EN LA BASE DE DATOS LOCAL. ")
        Return 1
    End Function

    'Public Shared Function fn_Depositos_Borrar(ByRef Descripcion As String) As Integer

    '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
    '    Dim tr As SqlCeTransaction = Crear_TransSQLCE(cnn)
    '    Dim Query As String = ""
    '    Dim cmd As SqlCeCommand = Nothing

    '    Try
    '        If varPub.Conectividad Then
    '            If fn_VerificaConexionInternet() Then

    '                EliminoCorrectamente = cls_CashWeb.fn_Depositos_BorrarWeb(Descripcion)

    '                If Not EliminoCorrectamente Then
    '                    Return -1
    '                End If
    '            End If
    '        End If

    '        If Not varPub.Conectividad Or EliminoCorrectamente Then
    '            Query = "Delete Depositos"
    '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
    '            Ejecutar_NonQueryTSQLCE(cmd)

    '            Query = "Alter Table Depositos Alter Column Id_Deposito Identity (1,1)"
    '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
    '            Ejecutar_NonQueryTSQLCE(cmd)
    '        End If
    '        EliminoCorrectamente = False
    '    Catch ex As Exception
    '        cnn.Dispose()
    '        cmd.Dispose()
    '        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA DEPOSITOS EN LA BASE DE DATOS LOCAL. " & ex.Message())
    '        Descripcion = ex.Message() & " En Local"
    '        Return -2
    '    End Try
    '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA DEPOSITOS EN LA BASE DE DATOS LOCAL. ")
    '    Return 1
    'End Function

    Public Shared Function fn_Privilegios_Borrar(ByRef Descripcion As String) As Integer

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Query As String = ""
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoIntenet As Boolean

        Try
            If varPub.Conectividad Then
                VerificoIntenet = fn_VerificaConexionInternet()
                If VerificoIntenet Then

                    EliminoCorrectamente = cls_CashWeb.fn_Privilegios_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoIntenet Or EliminoCorrectamente Then
                Cmd = Crear_ComandoSQL("Privilegios_DeleteRegistros", CommandType.StoredProcedure, Cnn)
                Ejecutar_NonQuerySQL(Cmd)
            End If
            EliminoCorrectamente = False
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA PRIVILEGIOS EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA PRIVILEGIOS EN LA BASE DE DATOS LOCAL. ")
        Return 1
    End Function

    Public Shared Function fn_Cerradura_Borrar(ByRef Descripcion As String) As Integer
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing

        Try
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Cerradura_DeleteRegistros")
            Ejecutar_NonQueryTSQL(Cmd)
            Cnn.Dispose()
            Cmd.Dispose()
            tr.Dispose()

            Return 1
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CERRADURA EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Cnn.Dispose()
            Cmd.Dispose()
            tr.Dispose()
            Return -2
        End Try
    End Function

    Public Shared Function fn_Correos_Borrar(ByRef Descripcion As String) As Integer
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing
        Try
            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Correos_DeleteRegistros")
            Ejecutar_NonQueryTSQL(Cmd)
            Cnn.Dispose()
            Cmd.Dispose()
            tr.Dispose()
            Return 1
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA CORREOS EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Cnn.Dispose()
            Cmd.Dispose()
            tr.Dispose()
            Return -2
        End Try
    End Function

    Public Shared Function fn_RetirosD_Borrar(ByRef Descripcion As String) As Integer

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim tr As SqlTransaction = Crear_TransSQL(Cnn)
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoIntenet As Boolean

        Try
            If varPub.Conectividad Then
                VerificoIntenet = fn_VerificaConexionInternet()
                If VerificoIntenet Then

                    EliminoCorrectamente = cls_CashWeb.fn_RetirosD_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoIntenet Or EliminoCorrectamente Then
                Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "RetirosD_DeleteRegistros")
                Ejecutar_NonQueryTSQL(Cmd)
            End If

            Cmd = Crear_ComandoTSQL(Cnn, tr, CommandType.StoredProcedure, "Retiros_DeleteRegistros")
            Ejecutar_NonQueryTSQL(Cmd)
            EliminoCorrectamente = False
            tr.Commit()
        Catch ex As Exception
            tr.Rollback()
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA RETIROS EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA RETIROS EN LA BASE DE DATOS LOCAL. ")
        Return 1

    End Function

    'Public Shared Function fn_Retiros_Borrar(ByRef Descripcion As String) As Integer

    '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
    '    Dim tr As SqlCeTransaction = Crear_TransSQLCE(cnn)
    '    Dim Query As String = ""
    '    Dim cmd As SqlCeCommand = Nothing

    '    Try
    '        If varPub.Conectividad Then
    '            If fn_VerificaConexionInternet() Then

    '                EliminoCorrectamente = cls_CashWeb.fn_Retiros_BorrarWeb(Descripcion)

    '                If Not EliminoCorrectamente Then
    '                    Return -1
    '                End If
    '            End If
    '        End If

    '        If Not varPub.Conectividad Or EliminoCorrectamente Then

    '            Query = "Delete Retiros"
    '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
    '            Ejecutar_NonQueryTSQLCE(cmd)

    '            Query = "Alter Table Retiros Alter Column Id_Retiro Identity (1,1)"
    '            cmd = Crear_ComandoTSQLCE(cnn, tr, CommandType.Text, Query)
    '            Ejecutar_NonQueryTSQLCE(cmd)
    '        End If
    '        EliminoCorrectamente = False
    '    Catch ex As Exception
    '        cnn.Dispose()
    '        cmd.Dispose()
    '        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA RETIROS EN LA BASE DE DATOS LOCAL. " & ex.Message())
    '        Descripcion = ex.Message() & " En Local"
    '        Return -2
    '    End Try
    '    Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA RETIROS EN LA BASE DE DATOS LOCAL. ")
    '    Return 1
    'End Function

    Public Shared Function fn_Usuarios_Borrar(ByRef Descripcion As String) As Integer

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim VerificoInternet As Boolean

        Try
            If varPub.Conectividad Then
                VerificoInternet = fn_VerificaConexionInternet()

                If VerificoInternet Then

                    EliminoCorrectamente = cls_CashWeb.fn_Usuarios_BorrarWeb(Descripcion)

                    If Not EliminoCorrectamente Then
                        Return -1
                    End If
                End If
            End If

            If Not VerificoInternet Or EliminoCorrectamente Then

                Cmd = Crear_ComandoSQL("Usuarios_DeleteRegistros", CommandType.StoredProcedure, Cnn)
                Ejecutar_NonQuerySQL(Cmd)
            End If
            EliminoCorrectamente = False
        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", " ERROR AL LIMPIAR LA TABLA USUARIOS EN LA BASE DE DATOS LOCAL. " & ex.Message())
            Descripcion = ex.Message() & " En Local"
            Return -2
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "MENU DE AUDITORIA", "SE LIMPIO CORRECTAMENTE LA TABLA USUARIOS EN LA BASE DE DATOS LOCAL. ")
        Return 1
    End Function

#End Region


#Region "GESTIONAR CAJERO POR WEB SERVICE"

    Public Shared Function fn_Cajero_ConsultaStatus() As DataTable
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing
        Try
            Cmd = Crear_ComandoSQL("Cajero_Read", CommandType.StoredProcedure, Cnn)
            dt = Ejecutar_ConsultaSQL(Cmd)

            If dt.Rows.Count > 0 Then
                If dt(0)("Clave_Sucursal") <> varPub.Cve_Sucursal Then
                    Cmd = Crear_ComandoSQL("Cajero_Update2", CommandType.StoredProcedure, Cnn)
                    Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
                    Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, varPub.Nombre_Sucursal)
                    Ejecutar_ConsultaSQL(Cmd)
                End If
            End If

            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
        Return dt
    End Function

    'Public Shared Function fn_Cajero_ActualizaStatus(Status As String) As Integer
    '    Dim cnn As SqlCeConnection = Crear_ConexionSQLCE(varPub.cnx_Local)
    '    Dim cmd As SqlCeCommand = Nothing
    '    Dim FilasAfectadas As Integer
    '    Dim Query As String = "Update Cajero " & _
    '                        "Set Status = '" & Status & "' " & _
    '                        "Where Id = 1"
    '    Try
    '        cmd = Crear_ComandoSQLCE(Query, CommandType.Text, cnn)
    '        FilasAfectadas = Ejecutar_NonQuerySQLCE(cmd)
    '    Catch ex As Exception
    '        cnn.Close()
    '        cmd.Dispose()
    '        Return Nothing
    '    End Try
    '    Return FilasAfectadas
    'End Function

    Public Shared Function fn_Transaccion_Consulta() As DataTable
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim dt As DataTable = Nothing
        Try
            Cmd = Crear_ComandoSQL("Transaccion_Read", CommandType.StoredProcedure, Cnn)
            dt = Ejecutar_ConsultaSQL(Cmd)

        Catch ex As Exception
            Cnn.Close()
            Cnn.Dispose()
            Cmd.Dispose()
            Return Nothing
        End Try
        Return dt
    End Function



    Public Shared Function fn_TransaccionActualiza_TotalDepositado(Id_Transccion As Integer, MontoDepositado As Integer, TipoCierre As String) As Integer
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        ' Dim Tr As SqlCeTransaction = Crear_TransSQLCE(cnn)
        Dim Cmd As SqlCommand = Nothing
        Dim FilasAfectadas As Integer = -1

        Try
            Cmd = Crear_ComandoSQL("Transaccion_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Monto_Depositado", SqlDbType.Money, MontoDepositado)
            Crear_ParametroSQL(Cmd, "@Folio_Deposito", SqlDbType.Int, varPub.FolioDeposito)
            Crear_ParametroSQL(Cmd, "@Id_Transaccion", SqlDbType.Int, Id_Transccion)
            FilasAfectadas = Ejecutar_NonQuerySQL(Cmd)

            Cmd = Crear_ComandoSQL("Cajeros_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Tipo_Cierre", SqlDbType.VarChar, TipoCierre)
            FilasAfectadas = Ejecutar_NonQuerySQL(Cmd)


        Catch ex As Exception
            Cnn.Close()
            Cnn.Dispose()
            Cmd.Dispose()
            Return Nothing
        End Try
        Return FilasAfectadas
    End Function

    Public Shared Function fn_Cajas_Read(Id_Caja As Integer) As DataTable
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim Dt As DataTable = Nothing
        Try
            Cmd = Crear_ComandoSQL("Cajas_Read8", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.Int, Id_Caja)
            Dt = Ejecutar_ConsultaSQL(Cmd)
        Catch ex As Exception
            Cnn.Close()
            Cnn.Dispose()
            Cmd.Dispose()
            Return Nothing
        End Try
        Return Dt
    End Function

    Public Shared Function fn_Cajero_ActualizaStatus(Status As String) As Boolean
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Dim Dt As DataTable = Nothing

        Try
            Cmd = Crear_ComandoSQL("Cajero_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Status", SqlDbType.VarChar, Status)
            Dt = Ejecutar_ConsultaSQL(Cmd)

        Catch ex As Exception
            Cnn.Close()
            Cnn.Dispose()
            Cmd.Dispose()
            Return False
        End Try
        Return True
    End Function



    Public Shared Function fn_LogTransaccion_Guardar(Descripcion As String, Clave_Usuario As String, Id_Caja As Integer, Folio_Transaccion As String) As Boolean
        Dim FilasAfectadas As Integer = -1
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Nothing
        Try
            Cmd = Crear_ComandoSQL("LogTransaccion_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Descripcion", SqlDbType.VarChar, Descripcion)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.VarChar, Descripcion)
            Crear_ParametroSQL(Cmd, "@Id_Caja", SqlDbType.VarChar, Descripcion)
            Crear_ParametroSQL(Cmd, "@Folio_Transaccion", SqlDbType.VarChar, Descripcion)
            FilasAfectadas = Ejecutar_NonQuerySQL(Cmd)

        Catch ex As Exception
            Cnn.Dispose()
            Cmd.Dispose()
            Return False
        End Try
        Return True
    End Function
#End Region

    Public Shared Function fn_Cajero_Insertar() As Boolean 'JAVIER ZAPATA 27/05/2019
        Try
            Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "INSERTANDO REGISTRO EN CAJERO.")
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Nothing
            Cmd = Crear_ComandoSQL("Cajero_Insert", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(Cmd, "@Nombre_Sucursal", SqlDbType.VarChar, varPub.Nombre_Sucursal)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
            Return False
            Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "INSERTANDO REGISTRO DE CAJERO CORRECTAMENTE.")
        Catch ex As Exception
            Return True
            Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "ERROR REGISTRO DE CAJERO" & ex.Message.ToUpper)
            Return False
        End Try
    End Function
    '--------CONSULTAR MONEDAS PARA VERIFICAR QUE EXISTEN JAVIER ZAPATA 29/05/2019
    Public Shared Function fn_Monedas_Consultar() As Boolean
        Try
            'Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "CONSULTANDO MONEDAS.")

            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Nothing

            Cmd = Crear_ComandoSQL("Monedas_Read", CommandType.StoredProcedure, Cnn)

            Dim Dt As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If Dt.Rows.Count = 0 Then
                Cmd = Crear_ComandoSQL("Monedas_Insert2", CommandType.StoredProcedure, Cnn)
                If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                    Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "MONEDAS INSERTADAS CORRECTAMENTE.")
                    Return True
                End If
                Return True
            End If
        Catch ex As Exception
            Call fn_EscribirLog(0, "CATALOGO DE LOGIN", " ERROR AL CONSULTAR MONEDAS.")
        End Try
        Return False
    End Function

    Public Shared Function fn_Opciones_Consultar() As Boolean
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Nothing
            Cmd = Crear_ComandoSQL("Opciones_Read3", CommandType.StoredProcedure, Cnn)
            Dim Dt As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If Dt.Rows.Count = 0 Then
                Cmd = Crear_ComandoSQL("Opciones_Insert", CommandType.StoredProcedure, Cnn)
                If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                    Return True
                End If
            Else
                Return True
            End If
            Return False
        Catch ex As Exception
            Call fn_EscribirLog(0, "CATALOGO OPCIONES", "OCURRIÓ UN ERROR AL CONSULTAR OPCIONES")
            Return False
        End Try
    End Function

    Public Shared Function fn_Usuarios_Consultar() As Boolean
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Nothing
            Cmd = Crear_ComandoSQL("Usuarios_Read8", CommandType.StoredProcedure, Cnn)
            Dim Dt As DataTable = Ejecutar_ConsultaSQL(Cmd)

            If Dt.Rows.Count = 0 Then
                Cmd = Crear_ComandoSQL("Usuarios_Insert2", CommandType.StoredProcedure, Cnn)
                If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
            Else
                Return True
            End If
            Return False
        Catch ex As Exception
            Call fn_EscribirLog(0, "CATALOGO USUARIOS", "OCURRIÓ UN ERROR AL CONSULTAR USUARIOS")
            Return False
        End Try
    End Function

    Public Shared Function fn_Denominaciones_Consultar() As Boolean
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Nothing
            Cmd = Crear_ComandoSQL("Denominaciones_Read2", CommandType.StoredProcedure, Cnn)
            Dim Dt_Denominaciones = Ejecutar_ConsultaSQL(Cmd)
            If Dt_Denominaciones.Rows.Count = 0 Then
                Cmd = Crear_ComandoSQL("Denominaciones_Insert2", CommandType.StoredProcedure, Cnn)
                If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
            Else
                Return True
            End If
            Return False
        Catch ex As Exception
            Call fn_EscribirLog(0, "CATALOGO DENOMINACIONES", "OCURRIÓ UN ERROR AL CONSULTAR DENOMINACIONES")
            Return False
        End Try
    End Function

    'JAVIER ZAPATILLA
#Region "PRIVILEGIOS"
    Public Shared Function fn_DescargarPrivilegiosLocalWeb() As Boolean
        Dim Encontro As Boolean = True
        Try

            Dim Dt_PrivilegiosWeb = cls_CashWeb.fn_ObtenerPrivilegiosWeb(varPub.Cve_Sucursal)
            If IsNothing(Dt_PrivilegiosWeb) Then Return False
            '-----------------------------------------------------------------------------------------------------------
            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Read4", CommandType.StoredProcedure, Con)
            Dim Dt_PrivilegiosLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)

            '-----------------------------------------------------------------------------------------------------------
            For Each Privilegio_Local As DataRow In Dt_PrivilegiosLocal.Rows
                Encontro = False

                For Each Privilegio_Web As DataRow In Dt_PrivilegiosWeb.Rows

                    If Privilegio_Local("Usuario") = Privilegio_Web("Usuario") And Privilegio_Local("Clave") = Privilegio_Web("Clave") Then
                        Encontro = True


                        If Privilegio_Local("Status2").ToString = "D" Then 'ELIMINAR PRIVILEGIOS NO SINCRONIZADOS

                            If cls_CashWeb.fn_EliminarPrivilegios(Privilegio_Local("Usuario"), Privilegio_Local("Clave")) Then 'SI SE ELIMINO EN LA WEB ELIMINAR LOCALMENTE

                                Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Con)
                                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Privilegio_Local("Usuario"))
                                Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Privilegio_Local("Clave"))
                                Ejecutar_NonQuerySQL(Cmd)

                            End If
                        End If

                    End If

                Next
                If Encontro = False Then 'SI NO HAY PRIVILEGIO EN WEB PERO LOCAL SI, INSERTA EN LA WEB

                    If Privilegio_Local("Status2").ToString = "D" Then

                        Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Con)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Privilegio_Local("Usuario"))
                        Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Privilegio_Local("Clave"))
                        Ejecutar_NonQuerySQL(Cmd)

                    Else
                        If cls_CashWeb.fn_InsertarPrivilegios(varPub.Cve_Sucursal, Privilegio_Local("Usuario"), Privilegio_Local("Clave")) Then

                        Else
                            Return False
                        End If

                    End If

                End If

            Next
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL DESCARGAR PRIVILEGIOS DE LOCAL A WEB" & ex.Message.ToUpper)
            Return False
        End Try
        Return False
    End Function


    Public Shared Function fn_DescargarPrivilegiosWebLocal() As Boolean
        Dim Encontro = False
        Try
            Dim Dt_PrivilegiosWeb = cls_CashWeb.fn_ObtenerPrivilegiosWeb(varPub.Cve_Sucursal)
            If IsNothing(Dt_PrivilegiosWeb) Then Return False

            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Read4", CommandType.StoredProcedure, Con)
            Dim Dt_PrivilegiosLocal As DataTable = Ejecutar_ConsultaSQL(Cmd)


            For Each Privilegio_Web As DataRow In Dt_PrivilegiosWeb.Rows

                Encontro = False
                For Each Privilegio_Local As DataRow In Dt_PrivilegiosLocal.Rows
                    Dim PrivilegioWeb As Object = Privilegio_Web("Usuario")
                    Dim PrivilegioLocal2 As Object = Privilegio_Web("Clave")
                    Dim PrivilegioWeb2 As Object = Privilegio_Local("Clave")
                    Dim PrivilegioLocal As Object = Privilegio_Local("Usuario")


                    If CInt(Privilegio_Web("Usuario")) = Privilegio_Local("Usuario") And Privilegio_Web("Clave") = Privilegio_Local("Clave") Then

                        Encontro = True

                        If Privilegio_Web("Status2").ToString = "D" Then 'ELIMINAR LOCALMENTE SI HAY STATUS D EN LA WEB

                            Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Con)
                            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Privilegio_Web("Usuario"))
                            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Privilegio_Web("Clave"))

                            If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                                cls_CashWeb.fn_EliminarPrivilegios(Privilegio_Web("Usuario"), Privilegio_Web("Clave")) 'Then 'UNA VEZ BORRADO LOCALMENTE HACERLO EN LA WEB
                            End If

                        End If
                    End If

                Next

                If Encontro = False Then

                    If Privilegio_Web("Status2").ToString = "D" Then
                        cls_CashWeb.fn_EliminarPrivilegios(Privilegio_Web("Usuario"), Privilegio_Web("Clave"))

                    Else
                        Cmd = Crear_ComandoSQL("Privilegios_Insert", CommandType.StoredProcedure, Con)
                        Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Privilegio_Web("Usuario"))
                        Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Privilegio_Web("Clave"))
                        Crear_ParametroSQL(Cmd, "@Sincronizado", SqlDbType.NVarChar, "S")
                        Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "A")
                        If Ejecutar_NonQuerySQL(Cmd) > 0 Then
                        Else : Return False
                        End If
                    End If

                End If

            Next

        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL DESCARGAR PRIVILEGIOS DE WE A LOCAL." & ex.Message.ToUpper)
        End Try
        Return False
    End Function


    Public Shared Function fn_ValidarPrivilegios2(ByVal Clave_Usuario As Integer, ByVal Clave_Opcion As String) As Boolean
        Try
            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Read5", CommandType.StoredProcedure, Con)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario)
            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Clave_Opcion)

            If Not IsNothing(Ejecutar_ScalarSQL(Cmd)) Then
                Return True
            End If
        Catch ex As Exception
        End Try
        Return False
    End Function


    Public Shared Function fn_ValidarPrivilegios(ByVal Clave_Usuario As String, ByVal Clave_Opcion As String) As Boolean
        Try

            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Privilegios_Read5", CommandType.StoredProcedure, Con)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario.Split("/")(0))
            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Clave_Opcion)
            If Not IsNothing(Ejecutar_ScalarSQL(Cmd)) Then

                Cmd = Crear_ComandoSQL("Privilegios_Update", CommandType.StoredProcedure, Con)
                Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Clave_Usuario.Split("/")(0))
                Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Clave_Opcion)
                Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "A")
                If Ejecutar_NonQuerySQL(Cmd) Then
                    Return True
                End If
            Else : Return False

            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function


    Public Shared Function fn_ValidarSincronizadoPrivilegios(ByVal Clave_Usuario As String, ByVal Clave_Opcion As String) As Boolean
        Try

            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd = Crear_ComandoSQL("Privilegios_Read6", CommandType.StoredProcedure, Con)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(Clave_Usuario.Split("/")(0)))
            Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Clave_Opcion)
            Dim Sincronizado = Ejecutar_ScalarSQL(Cmd)

            If Not IsNothing(Sincronizado) Then
                Return True = (Sincronizado.ToString = "S")
            Else : Return False
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Shared Function fn_ConsultarSincronizadoPrivilegiosAll(ByVal Clave_Usuario As String) As Boolean
        Try
            Dim Con As SqlConnection = Crear_ConexionSQL(_Cnx)

            Dim Cmd = Crear_ComandoSQL("Privilegios_Read8", CommandType.StoredProcedure, Con)
            Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, CInt(Clave_Usuario.Split("/")(0)))

            Dim Dt_Privilegios = Ejecutar_ConsultaSQL(Cmd)

            For Each Row_Privilegio In Dt_Privilegios.Rows
                Dim Hola As Object = Row_Privilegio("Sincronizado").ToString

                If Row_Privilegio("Sincronizado").ToString = "" Or Row_Privilegio("Sincronizado").ToString = "N" Then

                    'Query = "Delete Privilegios " & _
                    '        "Where Clave_Usuario = " & Row_Privilegio("Clave_Usuario") & " " & _
                    '        "And Clave_Opcion = " & Row_Privilegio("Clave_Opcion")
                    Cmd = Crear_ComandoSQL("Privilegios_Delete2", CommandType.StoredProcedure, Con)
                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Row_Privilegio("Clave_Usuario"))
                    Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Row_Privilegio("Clave_Opcion"))

                ElseIf Row_Privilegio("Sincronizado").ToString = "S" Then

                    Cmd = Crear_ComandoSQL("Privilegios_Update", CommandType.StoredProcedure, Con)
                    Crear_ParametroSQL(Cmd, "@Clave_Usuario", SqlDbType.Int, Row_Privilegio("Clave_Usuario"))
                    Crear_ParametroSQL(Cmd, "@Clave_Opcion", SqlDbType.VarChar, Row_Privilegio("Clave_Opcion"))
                    Crear_ParametroSQL(Cmd, "@Status2", SqlDbType.NVarChar, "D")


                End If
                If Not Ejecutar_NonQuerySQL(Cmd) > 0 Then
                    Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS ELIMINAR TODOS", "NO SE PUDO ELIMINAR O ACTUALIZAR")
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "PRIVILEGIOS", "ERROR AL ELIMINAR TODOS LOS PRIVILEGIOS" & ex.Message.ToUpper)
            Return False
        End Try
    End Function


#End Region

    'DESCARGAR DE INFORMACION PARA BASE DE DATOS NUEVA
    Public Shared Sub fn_Tablas_Descargas()

        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)

        fn_Monedas_Consultar()
        '----CONUSLTAR OPCIONES SI EXISTEN
        fn_Opciones_Consultar()

        '----CONSULTAR USUARIOS SI EXISTEN
        fn_Usuarios_Consultar()

        '----COSNULTAR DENOMINACIONES SI EXISTEN
        fn_Denominaciones_Consultar()
    End Sub

#Region "Update RowID Local"

    Public Shared Function fn_ActualizarRowIDCajero(ByVal RowId As String, ByVal Id_Deposito As Integer) As Boolean

        Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Tr As SqlTransaction = Crear_TransSQL(cnn)
        Try
            Dim cmd As SqlCommand = Crear_ComandoTSQL(cnn, Tr, CommandType.StoredProcedure, "Update_RowID_Local")
            Crear_ParametroSQL(cmd, "@RowID", SqlDbType.VarChar, RowId)
            Crear_ParametroSQL(cmd, "@Id_Deposito", SqlDbType.Int, Id_Deposito)
            Ejecutar_NonQueryTSQL(cmd)
            Tr.Commit()
            'MessageBox.Show(cnn.ConnectionString)
            Return True
        Catch ex As Exception
            'Tr.Rollback()
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
#End Region
    'Obtener tipo de recoleccion [Normal,RD]
    Public Shared Function fn_TipoRecoleccion(Tipo As Integer, Valor As Integer) As Boolean
        Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Crear_ComandoSQL("TipoRecoleccion_Get", CommandType.StoredProcedure, cnn)
        Try
            Crear_ParametroSQL(Cmd, "@Id_cajero", SqlDbType.Int, 1)
            Crear_ParametroSQL(Cmd, "@Tipo", SqlDbType.Int, Tipo)
            Crear_ParametroSQL(Cmd, "@Valor", SqlDbType.Int, Valor)
            Dim tbl As DataTable
            tbl = Ejecutar_ConsultaSQL(Cmd)
            If (tbl.Rows.Count > 0) Then
                Return tbl.Rows(0)("Urd").ToString()
            End If
            Return 0
        Catch ex As Exception
            Return Nothing
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "TIPO RECOLECCION", "OCURRIÓ UN ERROR AL OBTENER EL TIPO DE RECOLECCION ")
    End Function

    Public Shared Function fn_ParametrosGet() As DataTable
        Dim cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Crear_ComandoSQL("Parametros_Get", CommandType.StoredProcedure, cnn)
        Try
            Dim tbl As DataTable
            tbl = Ejecutar_ConsultaSQL(Cmd)
            If (tbl.Rows.Count > 0) Then
                Return tbl
            End If
            Return tbl
        Catch ex As Exception
            Return Nothing
        End Try
        Call fn_EscribirLog(varPub.UsuarioClave, "Parametros", "OCURRIÓ UN ERROR AL OBTENER LOS PARAMETROS DE CONFIGURACION")
    End Function
    Public Shared Function fn_ParametrosUpdate(Parametro As String, Valor As String) As Boolean 'JAVIER ZAPATA 27/05/2019
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Nothing
            Cmd = Crear_ComandoSQL("Parametros_Update", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@Parametro", SqlDbType.VarChar, Parametro)
            Crear_ParametroSQL(Cmd, "@Valor", SqlDbType.VarChar, Valor)

            If Ejecutar_NonQuerySQL(Cmd) > 0 Then Return True
            Return False
            Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "INSERTANDO REGISTRO DE CAJERO CORRECTAMENTE.")
        Catch ex As Exception
            Return True
            Call fn_EscribirLog(0, "CATALOGO DE LOGIN", "ERROR REGISTRO DE CAJERO" & ex.Message.ToUpper)
            Return False
        End Try
    End Function
    Public Shared Function fn_configuracion()
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("ParametrosUpdate", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@pModo_Impresion", SqlDbType.Int, varPub.Modo_Impresion)
            Crear_ParametroSQL(Cmd, "@pLogo_EmpresaRuta", SqlDbType.VarChar, "NA")
            Crear_ParametroSQL(Cmd, "@pImprimir_DetalleCD", SqlDbType.Int, varPub.Imprimir_DetalleCD)
            Crear_ParametroSQL(Cmd, "@phostNameOrAddress", SqlDbType.VarChar, varPub.hostNameOrAddress)
            Crear_ParametroSQL(Cmd, "@pVersionCashFlow", SqlDbType.VarChar, varPub.Version_CashFlow)
            Crear_ParametroSQL(Cmd, "@pInicioOperaciones", SqlDbType.Date, varPub.Inicio_Operaciones)
            Crear_ParametroSQL(Cmd, "@pMailSucursal", SqlDbType.VarChar, varPub.Mail_Sucursal)
            Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct2", SqlDbType.Int, varPub.LimiteCapacidad_Kct2)
            Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct", SqlDbType.Int, varPub.LimiteCapacidad_Kct)
            Crear_ParametroSQL(Cmd, "@pAncho_Pantalla", SqlDbType.Int, varTecl.AnchoPantalla)
            Crear_ParametroSQL(Cmd, "@pAlto_Pantalla", SqlDbType.Int, varTecl.AltoPantalla)
            Crear_ParametroSQL(Cmd, "@pTipoWindows", SqlDbType.Int, varPub.Tipo_Windows)
            Crear_ParametroSQL(Cmd, "@pNumValidadores", SqlDbType.Int, varPub.Cant_Validadores)
            Crear_ParametroSQL(Cmd, "@pActivarVal1", SqlDbType.Int, varPub.Activar_Val1)
            Crear_ParametroSQL(Cmd, "@pSerieCaset1", SqlDbType.VarChar, varPub.Serie_Caset1)
            Crear_ParametroSQL(Cmd, "@pSerieVal1", SqlDbType.VarChar, varPub.Serie_Val1)
            Crear_ParametroSQL(Cmd, "@pPuerto_Val1", SqlDbType.VarChar, varPub.Puerto_Val1)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Caset", SqlDbType.Int, varPub.Capacidad_Caset)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Actual", SqlDbType.Int, varPub.Capacidad_Actual)
            Crear_ParametroSQL(Cmd, "@pCasetID", SqlDbType.Int, varPub.CasetID)
            Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta", SqlDbType.Int, varPub.Porcentaje_Alerta)
            Crear_ParametroSQL(Cmd, "@pActivarVal2", SqlDbType.VarChar, varPub.Activar_Val2)
            Crear_ParametroSQL(Cmd, "@pSerieCaset2", SqlDbType.VarChar, varPub.Serie_Caset2)
            Crear_ParametroSQL(Cmd, "@pSerieVal2", SqlDbType.VarChar, varPub.Serie_Val2)
            Crear_ParametroSQL(Cmd, "@pPuerto_Val2", SqlDbType.VarChar, varPub.Puerto_Val2)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Caset2", SqlDbType.Int, varPub.Capacidad_Caset2)
            Crear_ParametroSQL(Cmd, "@pCapacidad_Actual2", SqlDbType.Int, varPub.Capacidad_Actual2)
            Crear_ParametroSQL(Cmd, "@pCaset2ID", SqlDbType.Int, varPub.Caset2ID)
            Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta2", SqlDbType.Int, varPub.Porcentaje_Alerta2)
            Crear_ParametroSQL(Cmd, "@pMargenIZq", SqlDbType.Int, varPub.MargenIzq)
            Crear_ParametroSQL(Cmd, "@pDias_Expira", SqlDbType.Int, varPub.Dias_Expira)
            Crear_ParametroSQL(Cmd, "@pTimeOut_Receptor", SqlDbType.Int, varPub.TimeOut_Receptor)
            Crear_ParametroSQL(Cmd, "@pTimeOut_Sesion", SqlDbType.Int, varPub.TimeOut_Sesion)
            Crear_ParametroSQL(Cmd, "@pUlt_Archivo", SqlDbType.VarChar, varPub.Ult_Archivo)
            Crear_ParametroSQL(Cmd, "@pU_dtb", SqlDbType.VarChar, varPub.U_dtb, False)
            Crear_ParametroSQL(Cmd, "@pP_dtb", SqlDbType.VarChar, varPub.P_dtb, False)
            Crear_ParametroSQL(Cmd, "@pB_dtb", SqlDbType.VarChar, varPub.B_dtb, False)
            Crear_ParametroSQL(Cmd, "@pS_dtb", SqlDbType.VarChar, varPub.S_dtb, False)
            Crear_ParametroSQL(Cmd, "@pRuta_Log", SqlDbType.VarChar, varPub.Ruta_Log)
            Crear_ParametroSQL(Cmd, "@pMsg_Fuente", SqlDbType.Int, varPub.TamañoFuente_Mensajes)
            Crear_ParametroSQL(Cmd, "@pLbl_Fuente", SqlDbType.Int, varPub.TamañoFuente_Etiqueta)
            Crear_ParametroSQL(Cmd, "@pCmd_Fuente", SqlDbType.Int, varPub.TamañoFuente_Botones)
            Crear_ParametroSQL(Cmd, "@pTipo_papel", SqlDbType.Int, varPub.Tamaño_Papel)
            Crear_ParametroSQL(Cmd, "@pCve_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
            Crear_ParametroSQL(Cmd, "@pCve_Cliente", SqlDbType.VarChar, varPub.Cve_Cliente)
            Crear_ParametroSQL(Cmd, "@pNombre_Sucursal", SqlDbType.VarChar, varPub.Nombre_Sucursal)
            Crear_ParametroSQL(Cmd, "@pConectividad", SqlDbType.Int, varPub.Conectividad)
            Crear_ParametroSQL(Cmd, "@pConexionwebAdmin", SqlDbType.Int, varPub.ConexionwebAdmin)
            Crear_ParametroSQL(Cmd, "@pNumLineasEnBlanco", SqlDbType.Int, varPub.Num_LineasBlanco)
            Crear_ParametroSQL(Cmd, "@pNumCopiasImprimir", SqlDbType.Int, varPub.Num_CopiasImprimir)
            Crear_ParametroSQL(Cmd, "@pPrioridadPriv", SqlDbType.Int, varPub.Prioridad_Priv)
            Crear_ParametroSQL(Cmd, "@pCliente", SqlDbType.VarChar, varPub.Cliente)
            Crear_ParametroSQL(Cmd, "@pDireccion", SqlDbType.VarChar, varPub.Direccion)
            Crear_ParametroSQL(Cmd, "@pNombreCorto", SqlDbType.VarChar, varPub.Nombre_Corto)
            Crear_ParametroSQL(Cmd, "@pTelefono", SqlDbType.VarChar, varPub.Telefono)
            Crear_ParametroSQL(Cmd, "@pCiaTV", SqlDbType.VarChar, varPub.CiaTV)
            Crear_ParametroSQL(Cmd, "@pDepositoP", SqlDbType.Int, varPub.ID_DepositoP)
            Crear_ParametroSQL(Cmd, "@pUlt_Retiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
            Crear_ParametroSQL(Cmd, "@pconexweb", SqlDbType.VarChar, varPub.cnx_SucursalWeb, False)
            Crear_ParametroSQL(Cmd, "@pCUNICA", SqlDbType.VarChar, varPub.CUNICA)
            Crear_ParametroSQL(Cmd, "@pComprobacion", SqlDbType.VarChar, varPub.Comprobacion)
            Crear_ParametroSQL(Cmd, "@pVersionNvo", SqlDbType.VarChar, varPub.VersionNvo)
            Crear_ParametroSQL(Cmd, "@pVersionAnt", SqlDbType.VarChar, varPub.VersionAnt)
            Crear_ParametroSQL(Cmd, "@pManejaCorte", SqlDbType.VarChar, varPub.ManejaCorte)
            Crear_ParametroSQL(Cmd, "@pCorteActual", SqlDbType.VarChar, varPub.CorteActual)
            Crear_ParametroSQL(Cmd, "@pTipoMonedaV1", SqlDbType.VarChar, varPub.TipoMonedaV1)
            Crear_ParametroSQL(Cmd, "@pTipoMonedaV2", SqlDbType.VarChar, varPub.TipoMonedaV2)
            Crear_ParametroSQL(Cmd, "@pCantidadCajas", SqlDbType.VarChar, varPub.Cantidad_Cajas)
            Crear_ParametroSQL(Cmd, "@pManejaConexionWebService", SqlDbType.VarChar, varPub.ManejaConexionWebService)
            Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaBaja", SqlDbType.VarChar, varPub.PorcentajeBateriaBaja)
            Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaCritica", SqlDbType.VarChar, varPub.PorcentajeBateriaCritica)
            Crear_ParametroSQL(Cmd, "@pBateriaBaja", SqlDbType.Int, varPub.BateriaBaja)
            Crear_ParametroSQL(Cmd, "@pBateriaCritica", SqlDbType.Int, varPub.BateriaCritica)
            Crear_ParametroSQL(Cmd, "@pPuertoSensores", SqlDbType.VarChar, varPub.PuertoSensores)
            Crear_ParametroSQL(Cmd, "@pManejaDepositoManual", SqlDbType.Int, varPub.ManejaDepositoManual)
            Crear_ParametroSQL(Cmd, "@pManejaFolioManual", SqlDbType.Int, varPub.ManejaFolioManual)
            Crear_ParametroSQL(Cmd, "@pvalidarFolio", SqlDbType.Int, varPub.ValidarFolio)
            Crear_ParametroSQL(Cmd, "@pconexion", SqlDbType.Int, varPub.Conexion)
            Crear_ParametroSQL(Cmd, "@pTrabajar_sin", SqlDbType.Int, varPub.Trabajar_sin)
            Crear_ParametroSQL(Cmd, "@Id_caj", SqlDbType.VarChar, varPub.Id_Caje)
            Crear_ParametroSQL(Cmd, "@Plaza", SqlDbType.VarChar, IIf(varPub.Plaza Is Nothing, "1", varPub.Plaza))
            Ejecutar_NonQuerySQL(Cmd)
        Catch ex As Exception
            '    MessageBox.Show(ex.Message)
        End Try

    End Function
    Public Shared Function fn_configuracion_SincronizarAWeb()
        'Try
        Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
        Dim Cmd As SqlCommand = Crear_ComandoSQL("ParametrosUpdate", CommandType.StoredProcedure, Cnn)
        Crear_ParametroSQL(Cmd, "@pModo_Impresion", SqlDbType.Int, varPub.Modo_Impresion)
        Crear_ParametroSQL(Cmd, "@pLogo_EmpresaRuta", SqlDbType.VarChar, "NA")
        Crear_ParametroSQL(Cmd, "@pImprimir_DetalleCD", SqlDbType.Int, varPub.Imprimir_DetalleCD)
        Crear_ParametroSQL(Cmd, "@phostNameOrAddress", SqlDbType.VarChar, varPub.hostNameOrAddress)
        Crear_ParametroSQL(Cmd, "@pVersionCashFlow", SqlDbType.VarChar, varPub.Version_CashFlow)
        Crear_ParametroSQL(Cmd, "@pInicioOperaciones", SqlDbType.Date, varPub.Inicio_Operaciones)
        Crear_ParametroSQL(Cmd, "@pMailSucursal", SqlDbType.VarChar, varPub.Mail_Sucursal)
        Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct2", SqlDbType.Int, varPub.LimiteCapacidad_Kct2)
        Crear_ParametroSQL(Cmd, "@pLimiteCapacidadKct", SqlDbType.Int, varPub.LimiteCapacidad_Kct)
        Crear_ParametroSQL(Cmd, "@pAncho_Pantalla", SqlDbType.Int, varTecl.AnchoPantalla)
        Crear_ParametroSQL(Cmd, "@pAlto_Pantalla", SqlDbType.Int, varTecl.AltoPantalla)
        Crear_ParametroSQL(Cmd, "@pTipoWindows", SqlDbType.Int, varPub.Tipo_Windows)
        Crear_ParametroSQL(Cmd, "@pNumValidadores", SqlDbType.Int, varPub.Cant_Validadores)
        Crear_ParametroSQL(Cmd, "@pActivarVal1", SqlDbType.Int, varPub.Activar_Val1)
        Crear_ParametroSQL(Cmd, "@pSerieCaset1", SqlDbType.VarChar, varPub.Serie_Caset1)
        Crear_ParametroSQL(Cmd, "@pSerieVal1", SqlDbType.VarChar, varPub.Serie_Val1)
        Crear_ParametroSQL(Cmd, "@pPuerto_Val1", SqlDbType.VarChar, varPub.Puerto_Val1)
        Crear_ParametroSQL(Cmd, "@pCapacidad_Caset", SqlDbType.Int, varPub.Capacidad_Caset)
        Crear_ParametroSQL(Cmd, "@pCapacidad_Actual", SqlDbType.Int, varPub.Capacidad_Actual)
        Crear_ParametroSQL(Cmd, "@pCasetID", SqlDbType.Int, varPub.CasetID)
        Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta", SqlDbType.Int, varPub.Porcentaje_Alerta)
        Crear_ParametroSQL(Cmd, "@pActivarVal2", SqlDbType.VarChar, varPub.Activar_Val2)
        Crear_ParametroSQL(Cmd, "@pSerieCaset2", SqlDbType.VarChar, varPub.Serie_Caset2)
        Crear_ParametroSQL(Cmd, "@pSerieVal2", SqlDbType.VarChar, varPub.Serie_Val2)
        Crear_ParametroSQL(Cmd, "@pPuerto_Val2", SqlDbType.VarChar, varPub.Puerto_Val2)
        Crear_ParametroSQL(Cmd, "@pCapacidad_Caset2", SqlDbType.Int, varPub.Capacidad_Caset2)
        Crear_ParametroSQL(Cmd, "@pCapacidad_Actual2", SqlDbType.Int, varPub.Capacidad_Actual2)
        Crear_ParametroSQL(Cmd, "@pCaset2ID", SqlDbType.Int, varPub.Caset2ID)
        Crear_ParametroSQL(Cmd, "@pPorcentaje_Alerta2", SqlDbType.Int, varPub.Porcentaje_Alerta2)
        Crear_ParametroSQL(Cmd, "@pMargenIZq", SqlDbType.Int, varPub.MargenIzq)
        Crear_ParametroSQL(Cmd, "@pDias_Expira", SqlDbType.Int, varPub.Dias_Expira)
        Crear_ParametroSQL(Cmd, "@pTimeOut_Receptor", SqlDbType.Int, varPub.TimeOut_Receptor)
        Crear_ParametroSQL(Cmd, "@pTimeOut_Sesion", SqlDbType.Int, varPub.TimeOut_Sesion)
        Crear_ParametroSQL(Cmd, "@pUlt_Archivo", SqlDbType.VarChar, varPub.Ult_Archivo)
        Crear_ParametroSQL(Cmd, "@pU_dtb", SqlDbType.VarChar, varPub.U_dtb, False)
        Crear_ParametroSQL(Cmd, "@pP_dtb", SqlDbType.VarChar, varPub.P_dtb, False)
        Crear_ParametroSQL(Cmd, "@pB_dtb", SqlDbType.VarChar, varPub.B_dtb, False)
        Crear_ParametroSQL(Cmd, "@pS_dtb", SqlDbType.VarChar, varPub.S_dtb, False)
        Crear_ParametroSQL(Cmd, "@pRuta_Log", SqlDbType.VarChar, varPub.Ruta_Log)
        Crear_ParametroSQL(Cmd, "@pMsg_Fuente", SqlDbType.Int, varPub.TamañoFuente_Mensajes)
        Crear_ParametroSQL(Cmd, "@pLbl_Fuente", SqlDbType.Int, varPub.TamañoFuente_Etiqueta)
        Crear_ParametroSQL(Cmd, "@pCmd_Fuente", SqlDbType.Int, varPub.TamañoFuente_Botones)
        Crear_ParametroSQL(Cmd, "@pTipo_papel", SqlDbType.Int, varPub.Tamaño_Papel)
        Crear_ParametroSQL(Cmd, "@pCve_Sucursal", SqlDbType.VarChar, varPub.Cve_Sucursal)
        Crear_ParametroSQL(Cmd, "@pCve_Cliente", SqlDbType.VarChar, varPub.Cve_Cliente)
        Crear_ParametroSQL(Cmd, "@pNombre_Sucursal", SqlDbType.VarChar, varPub.Nombre_Sucursal)
        Crear_ParametroSQL(Cmd, "@pConectividad", SqlDbType.Int, varPub.Conectividad)
        Crear_ParametroSQL(Cmd, "@pConexionwebAdmin", SqlDbType.Int, varPub.ConexionwebAdmin)
        Crear_ParametroSQL(Cmd, "@pNumLineasEnBlanco", SqlDbType.Int, varPub.Num_LineasBlanco)
        Crear_ParametroSQL(Cmd, "@pNumCopiasImprimir", SqlDbType.Int, varPub.Num_CopiasImprimir)
        Crear_ParametroSQL(Cmd, "@pPrioridadPriv", SqlDbType.Int, varPub.Prioridad_Priv)
        Crear_ParametroSQL(Cmd, "@pCliente", SqlDbType.VarChar, varPub.Cliente)
        Crear_ParametroSQL(Cmd, "@pDireccion", SqlDbType.VarChar, varPub.Direccion)
        Crear_ParametroSQL(Cmd, "@pNombreCorto", SqlDbType.VarChar, varPub.Nombre_Corto)
        Crear_ParametroSQL(Cmd, "@pTelefono", SqlDbType.VarChar, varPub.Telefono)
        Crear_ParametroSQL(Cmd, "@pCiaTV", SqlDbType.VarChar, varPub.CiaTV)
        Crear_ParametroSQL(Cmd, "@pDepositoP", SqlDbType.Int, varPub.ID_DepositoP)
        Crear_ParametroSQL(Cmd, "@pUlt_Retiro", SqlDbType.Int, varPub.ID_UltimoRetiro)
        Crear_ParametroSQL(Cmd, "@pconexweb", SqlDbType.VarChar, varPub.cnx_SucursalWeb, False)
        Crear_ParametroSQL(Cmd, "@pCUNICA", SqlDbType.VarChar, varPub.CUNICA)
        Crear_ParametroSQL(Cmd, "@pComprobacion", SqlDbType.VarChar, varPub.Comprobacion)
        Crear_ParametroSQL(Cmd, "@pVersionNvo", SqlDbType.VarChar, varPub.VersionNvo)
        Crear_ParametroSQL(Cmd, "@pVersionAnt", SqlDbType.VarChar, varPub.VersionAnt)
        Crear_ParametroSQL(Cmd, "@pManejaCorte", SqlDbType.VarChar, varPub.ManejaCorte)
        Crear_ParametroSQL(Cmd, "@pCorteActual", SqlDbType.VarChar, varPub.CorteActual)
        Crear_ParametroSQL(Cmd, "@pTipoMonedaV1", SqlDbType.VarChar, varPub.TipoMonedaV1)
        Crear_ParametroSQL(Cmd, "@pTipoMonedaV2", SqlDbType.VarChar, varPub.TipoMonedaV2)
        Crear_ParametroSQL(Cmd, "@pCantidadCajas", SqlDbType.VarChar, varPub.Cantidad_Cajas)
        Crear_ParametroSQL(Cmd, "@pManejaConexionWebService", SqlDbType.VarChar, varPub.ManejaConexionWebService)
        Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaBaja", SqlDbType.VarChar, varPub.PorcentajeBateriaBaja)
        Crear_ParametroSQL(Cmd, "@pPorcentajeBateriaCritica", SqlDbType.VarChar, varPub.PorcentajeBateriaCritica)
        Crear_ParametroSQL(Cmd, "@pBateriaBaja", SqlDbType.Int, varPub.BateriaBaja)
        Crear_ParametroSQL(Cmd, "@pBateriaCritica", SqlDbType.Int, varPub.BateriaCritica)
        Crear_ParametroSQL(Cmd, "@pPuertoSensores", SqlDbType.VarChar, varPub.PuertoSensores)
        Crear_ParametroSQL(Cmd, "@pManejaDepositoManual", SqlDbType.Int, varPub.ManejaDepositoManual)
        Crear_ParametroSQL(Cmd, "@pManejaFolioManual", SqlDbType.Int, varPub.ManejaFolioManual)
        Crear_ParametroSQL(Cmd, "@pvalidarFolio", SqlDbType.Int, varPub.ValidarFolio)
        Crear_ParametroSQL(Cmd, "@pconexion", SqlDbType.Int, varPub.Conexion)
        Crear_ParametroSQL(Cmd, "@pTrabajar_sin", SqlDbType.Int, varPub.Trabajar_sin)
        Crear_ParametroSQL(Cmd, "@Id_caj", SqlDbType.VarChar, varPub.Id_Caje)
        Crear_ParametroSQL(Cmd, "@Plaza", SqlDbType.VarChar, IIf(varPub.Plaza Is Nothing, "1", varPub.Plaza))
        Ejecutar_NonQuerySQL(Cmd)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Function
End Class