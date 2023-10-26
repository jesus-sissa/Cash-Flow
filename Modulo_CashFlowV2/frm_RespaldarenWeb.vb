Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports System.Net

Public Class frm_RespaldarenWeb

    Dim RutabddLocal As String = ""
    Dim DestinoFtp As String = ""
    Dim DireccionFtp As String = ""
    Dim RutaAplicacion As String = ""
    Public IniciarUp As Boolean = False

#Region " SUBIR ARCHIVO A FTP"

    Private Sub Iniciar_CargaArchivo()
        ' Verificar Respaldo en segundo plano( U otro hilo)
        If varPub.Conectividad = False Then
            Me.Close()
            Exit Sub
        End If

        If fn_VerificaConexionInternet() = False Then
            fn_MsgBox("No existe conexión a internet, la trasferencia de Archivo se canceló.", MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        If fn_Obtieneparametros_ftp() = "ERROR" Then
            fn_MsgBox("Ocurrió un error al descargar parámetros de conexión ftp.", MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        btn_SubirArchivo.Enabled = False
        pnl_General.Enabled = False

        Dim RutaTemp_sdf As String = RutaAplicacion & "\RutaTemp_sdf"
        Dim Archivo_sdf As String = RutaAplicacion & "\CashFlow.sdf"
        Dim ArchivoRespaldoTemp As String = RutaTemp_sdf & "\CashFlow.sdf"
        Try
            If System.IO.Directory.Exists(RutaTemp_sdf) Then
                If System.IO.File.Exists(ArchivoRespaldoTemp) Then
                    My.Computer.FileSystem.DeleteFile(ArchivoRespaldoTemp)
                End If
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "COPIAR LA BDD LOCAL A CARPETA TEMPORAL.")
                System.IO.File.Copy(Archivo_sdf, ArchivoRespaldoTemp)
            Else
                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "CREANDO EL DIRECTORIO TEMPORAL PARA ALMACENAR EL ARCHIVO DE BDD .SDF")
                System.IO.Directory.CreateDirectory(RutaTemp_sdf)

                fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "COPIAR LA BDD LOCAL A CARPETA TEMPORAL.")
                System.IO.File.Copy(Archivo_sdf, ArchivoRespaldoTemp)
            End If

            Call subirFichero(RutabddLocal, DestinoFtp, DireccionFtp)

            '4.-si todo fue correcto/ eliminar archivo temporal
            My.Computer.FileSystem.DeleteFile(ArchivoRespaldoTemp)

            '5.- cambiar la bandera  Respaldar='N'
            Call cls_CashWeb.fn_ActualizaStatus_Respaldar("N")

            fn_MsgBox("La trasferencia de archivo de base de datos al FTP fue satisfactoria.", MessageBoxIcon.Information, True, 2)

        Catch ex As Exception
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "ERROR AL SUBIR ARCHIVO DE BDD AL FTP. " & ex.Message.ToUpper)
            fn_MsgBox("Ocurrió un error al subir el archivo de base de datos al servidor ftp.", MessageBoxIcon.Error, True, 3)
        End Try

        Me.Close() ' si todo fue correcto cerrar pantalla

    End Sub

    Private Function EliminarArchivo_ftp(ByVal Archivo As String) As String
        Dim peticionFTP As FtpWebRequest

        ' Creamos una petición FTP con la dirección del Archivo a eliminar
        peticionFTP = CType(WebRequest.Create(New Uri(Archivo)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(varPub.Usuario_ftp, varPub.Password_ftp)

        ' Seleccionamos el comando que vamos a utilizar: Eliminar un Archivo
        peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
        peticionFTP.UsePassive = False

        Try
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuestaFTP.Close()
            ' Si todo ha ido bien, devolvemos String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function

    Private Function existeObjeto(ByVal dir As String) As Boolean
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(varPub.Usuario_ftp, varPub.Password_ftp)

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function

    Private Function creaDirectorio(ByVal dir As String, ByRef msgError As String) As Boolean
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(varPub.Usuario_ftp, varPub.Password_ftp)

        ' Seleccionamos el comando que vamos a utilizar. Crear un Directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            msgError = String.Empty
            Return True
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            msgError = ex.Message
            Return False
        End Try
    End Function

    Private Function subirFichero(ByVal ArchivoLocal As String, ByVal destinoFTP As String, _
                                 ByVal dirFTP As String) As String
        Dim infoFichero As New IO.FileInfo(ArchivoLocal)
        Dim tamañoArchivoUp As Integer = infoFichero.Length
        Dim msgError As String = ""
        Dim uri As String
        uri = destinoFTP
        varPub.SegundosSesion = 0

        ' ---CREA DIRECTORIO SINO EXISTE---
        '(esto falla porque no tiene acceso ftp desde vb.net
        'If Not existeObjeto(dirFTP) Then
        '    If creaDirectorio(dirFTP, msgError) = False Then
        '        cn_CashFlow.fn_MsgBox(msgError, MessageBoxIcon.Error)
        '        Return msgError
        '    End If
        'End If

        Dim peticionFTP As FtpWebRequest
        pgr_Subiendo.Value = 0
        lbl_porcientoUp.Text = "0%"
        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destinoFTP)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(varPub.Usuario_ftp, varPub.Password_ftp)

        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False

        varPub.SegundosSesion = 0
        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile

        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True

        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = tamañoArchivoUp

        varPub.SegundosSesion = 0
        ' Fijamos un buffer de 2KB
        Dim longitudBuffer As Integer
        longitudBuffer = 2048
        Dim lector As Byte() = New Byte(2048) {}

        Dim num As Integer

        ' Abrimos el fichero para subirlo
        Dim fs As IO.FileStream
        fs = infoFichero.OpenRead()

        Dim totalBytesUp As Integer = 0

        Try
            'Iniciar carga de archivo( colocar progresabar)
            Dim escritor As IO.Stream
            escritor = peticionFTP.GetRequestStream()

            varPub.SegundosSesion = 0
            ' Leemos 2 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)

            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el 
                ' flujo de escritura del comando FTP
                totalBytesUp += num 'le va pasando la cantidad cargada ---> en base a 2048kb

                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)

                pgr_Subiendo.Value = CLng((totalBytesUp * 100) / tamañoArchivoUp)
                lbl_porcientoUp.Text = pgr_Subiendo.Value.ToString & " %"
                Application.DoEvents()
                varPub.SegundosSesion = 0
            End While
            escritor.Close()
            fs.Close()

            varPub.SegundosSesion = 0
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try

    End Function

#End Region


    Private Sub frm_RespaldarenWeb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'RutabddLocal: Ruta local del Archivo a subir al ftp.
        'DestinoFtp: Dirección FTP del destino del fichero con su extension. Ej: "ftp://direccion_de_ejemplo/directorio/fichero.sdf"
        'DireccionFtp: Dirección FTP del directorio donde se almacenará el fichero. Ej: "ftp://direccion_de_ejemplo/directorio"

        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 37
        If varPub.Conectividad Then
            If fn_VerificaConexionInternet() = True Then
                fn_Obtieneparametros_ftp()
            End If
        End If

        RutaAplicacion = Application.StartupPath
        RutabddLocal = RutaAplicacion & "\CashFlow.sdf"
        lbl_RutaBdd.Text = RutabddLocal

        DireccionFtp = varPub.Ubicacion_ftp & "/RespaldosCashFlow/" & varPub.CUNICA & "/" & varPub.Cve_Sucursal
        DestinoFtp = DireccionFtp & "/CashFlow" & CustomFecha & CustomHora & ".sdf"
        lbl_Destino.Text = DestinoFtp

        If IniciarUp = False Then
            btn_SubirArchivo.Enabled = varPub.Conectividad
        ElseIf IniciarUp = True Then
            Call Iniciar_CargaArchivo()
        End If
    End Sub

    Private Sub btn_SubirArchivo_Click(sender As Object, e As EventArgs) Handles btn_SubirArchivo.Click
        varPub.SegundosSesion = 0
        Call Iniciar_CargaArchivo()
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub
End Class