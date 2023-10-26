Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Usuarios

Public Class frm_BuscarActualizar
    Dim Ruta_Default As String
    Dim segundosImprime As Integer = 0
    Dim Conex As String = ""
    Dim Filtro As String = "Archivos Ejecutables(*.exe)|*.exe"
    Dim Dialogo As New OpenFileDialog
    Dim PathFile_Actualiza As String = ""
    Dim logoRuta As String = ""
    Dim RutaFiledescargado As String = ""
    Dim PathDescargado As String = ""
    Dim NombreExeDescargado As String = ""
    Public Sub Actualizar()
        'Aquí vamos hacer la actualizacion desde web(Verificar archivo exista, estar logueado y conexion a internet)
        varPub.SegundosSesion = 0
        If varPub.ConexionwebAdmin = 2 Then Exit Sub

        If fn_VerificaConexionInternet() = False Then
            Call fn_MsgBox("De momento no hay conexion a internet..", MessageBoxIcon.Error)
            Me.Close()

            Exit Sub
        End If

        fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO PROCESO DE ACTUALIZACION WEB.")

        Try

            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO PROCESO DE DESCARGA DE ARCHIVO.")
            
            Call fn_Obtieneparametros_ftp()
            'nombre de nuestro exe a buscar en el ftp
            Dim nombreEXE As String = Application.ProductName
            Dim ftpDescarga As String = varPub.Ubicacion_ftp & "/UpdateCashFlow/" & nombreEXE & ".exe"
            Dim rutaApp As String = Application.StartupPath
            RutaFiledescargado = rutaApp & "\DescargasCashFlow" 'es un acarpeta fija adonde se descarga elnuevo exe

            Dim buffer(1023) As Byte 'bloques de descarga de 1KB o sea 1024bytes 
            Dim bytesIn As Integer
            Dim output As IO.Stream = Nothing

            pgr_Descargando.Value = 0 'o Cualquier otro metodo a visualizar que exista

            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "REALIZANDO PETICIÓN PARA OBTENER EL TAMAÑO DEL ARCHIVO A DESCARGAR.")
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
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "VERIFICANDO QUE EL DIRECTORIO DE DESCARGAS EXISTA.")
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

                        pgr_Descargando.Value = CLng((totalBytesIn * 100) / sizeFile)
                        lbl_porcientoDown.Text = pgr_Descargando.Value.ToString & " %"
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
                 
                End If

            End If

        Catch ex As Net.WebException

            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ERROR DE ENLACE FTP. " & ex.Message.ToUpper)
            fn_MsgBox(ex.Message.ToString, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Function SistemaCashFlow_Actualizar(ByVal TipoActualizacion As String) As Boolean
        varPub.SegundosSesion = 0

        If fn_VerificaConexionInternet() = False Then
            Call fn_MsgBox("De momento no hay conexion a internet..", MessageBoxIcon.Error)
            Me.Close()


        End If
        Try

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
            If varPub.VersionAnt >= varPub.VersionNvo Then
                Call fn_Obtieneparametros_ftp()

                fn_MsgBox("No hay actualizaciones Nuevas", MessageBoxIcon.Exclamation, True, 2)
                'Dim Persistente As New cls_VariablesPersistentes()
                Persistente.Persistir()
                Persistente.Cargar()
                Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
                Dim Query As String = "Update actualizaciones" & _
                                      " Set Fecha_Comprobacion = '" & Format(Now.Date, "MM/dd/yyyy") & "'" & _
                                      " where Clave_Sucursal = '" & varPub.Cve_Sucursal & "'"
                Dim cmd As SqlCommand = Crear_ComandoSQL(Query, CommandType.Text, cnn)
                Dim dts As DataTable = Ejecutar_ConsultaSQL(cmd)
                cnn.Dispose()
                cmd.Dispose()

                varPub.Comprobacion = Format(Now.Date, "yyyy/MM")
                'creamos el xml con los valoress incluidas del Ancho y alto
                Persistente.Persistir()

                'cargamos los valores que se crearon carga
                Persistente.Cargar()
                Me.Close()
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
            Me.Close()
            Return True 'Si todo es correcto
        Catch ex As Exception
            Call fn_MsgBox("Error al intentar actualizar el sistema ..", MessageBoxIcon.Error, True, 2)
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ERROR AL ACTUALIZAR O RESTAURAR, " & ex.Message.ToUpper)
            Me.Close()
            Return False
        End Try
    End Function

    Sub ActualizarInformacion()
        If fn_VerificaConexionInternet() = False Then
            Call fn_MsgBox("De momento no hay conexion a internet..", MessageBoxIcon.Error)
            Me.Close()

            Exit Sub
        End If
        Dim myFileNVOVersion As FileVersionInfo = FileVersionInfo.GetVersionInfo(PathDescargado)
        Dim Persistente As New cls_VariablesPersistentes()
        Dim cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
        Dim Query As String = "Update actualizaciones " & _
                              "Set Version_Actual = '" & varPub.VersionNvo & "'," & _
                              "Fecha_Actualizacion = '" & Format(Now.Date, "MM/dd/yyyy") & "'," & _
                              "Fecha_Comprobacion = '" & Format(Now.Date, "MM/dd/yyyy") & "'" & _
                              "where Clave_Sucursal = '" & varPub.Cve_Sucursal & "'"

        Dim cmd As SqlCommand = Crear_ComandoSQL(Query, CommandType.Text, cnn)
        Dim dt_DepositosId As DataTable = Ejecutar_ConsultaSQL(cmd)



        Query = "Insert Into actualizacionesD  (Clave_Sucursal , Version_Actual ,Fecha_Actualizacion) " & _
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
    Private Sub frm_BuscarActualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 3
        If fn_VerificaConexionInternet() = False Then
            Call fn_MsgBox("De momento no hay conexion a internet..", MessageBoxIcon.Error)
            Me.Close()

            Exit Sub
        End If
        Call Actualizar()

    End Sub

End Class