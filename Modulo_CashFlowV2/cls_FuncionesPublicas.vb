Imports System.Text
Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQLCE
Imports System.Data.SqlClient
Imports dataconection.cls_DatosSQL
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports Modulo_CashFlowV2.cls_Usuarios
Imports System.Data.SQLite
Imports System.Configuration

Public Class cls_FuncionesPublicas

#Region "-Variables"
    Dim Cmd As SqlCommand

    Public Enum strPosicion As Byte
        Izquierda = 0
        Derecha = 1
        Izq_Der = 2
    End Enum

#End Region

#Region " Funcion de Log"

    Public Shared Sub fn_EscribirLog(ByVal Usuario As String, ByVal Pantalla As String, ByVal Accion As String)
        Dim query As String

        Try
            Using conexion As SQLiteConnection = New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
                conexion.Open()
                '""
                query = "Insert Into Tbl_Log (Usuario,Pantalla,Accion,Fecha,Hora) Values(@Usurio,@Pantalla,@Accion,@Fecha,@Hora)"
                Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)
                cmd.Parameters.Add(New SQLiteParameter("@Usurio", Usuario))
                cmd.Parameters.Add(New SQLiteParameter("@Pantalla", Pantalla))
                cmd.Parameters.Add(New SQLiteParameter("@Accion", Accion))
                cmd.Parameters.Add(New SQLiteParameter("@Fecha", String.Format("{0:yyyy'-'MM'-'dd}", DateTime.Now)))
                cmd.Parameters.Add(New SQLiteParameter("@Hora", DateTime.Now.ToShortTimeString))
                cmd.CommandType = System.Data.CommandType.Text

                If cmd.ExecuteNonQuery() < 1 Then


                End If


            End Using
        Catch ex As Exception
            'MsgBox("Mamo :(")
        End Try

    End Sub
    Public Shared Sub fn_AddLog(ByRef idCajeroReceptor As String, ByRef IdUsuario As Integer, ByRef sSucursal As String, ByRef IdLogDescripcion As Integer, ByRef IdPantalla As Integer, ByRef sDescripcion As String)
        Try
            'Dim Cnn As SqlConnection = Crear_ConexionSQL(_Cnx)
            'Dim Cmd As SqlCommand = Crear_ComandoSQL("CE_AddLOG", CommandType.StoredProcedure, Cnn)
            'Crear_ParametroSQL(Cmd, "@id_CajeroReceptor", SqlDbType.VarChar, idCajeroReceptor)
            'Crear_ParametroSQL(Cmd, "@iIdUsuario", SqlDbType.VarChar, IdUsuario)
            'Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, sSucursal)
            'Crear_ParametroSQL(Cmd, "@Fecha", SqlDbType.Date, Fecha)
            'Crear_ParametroSQL(Cmd, "@Hora", SqlDbType.Time, Hora)
            'Crear_ParametroSQL(Cmd, "@iIdLog_Descripcion", SqlDbType.Int, IdLogDescripcion)
            'Crear_ParametroSQL(Cmd, "@iIdPantalla", SqlDbType.Int, IdPantalla)
            'Crear_ParametroSQL(Cmd, "@sDescripcion", SqlDbType.VarChar, sDescripcion)
            'Ejecutar_NonQuerySQL(Cmd)
            'fn_AddTicket(idCajeroReceptor, IdUsuario, sSucursal, IdLogDescripcion, IdPantalla, sDescripcion)
        Catch ex As Exception
            'fn_AddLog(idCajeroReceptor, IdUsuario, sSucursal, IdLogDescripcion, IdPantalla, ex.ToString())
            'fn_MsgBox("Ocurrio error al insertar la incidencia al log.", MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub fn_AddTicket(ByRef idCajeroReceptor As String, ByRef IdUsuario As Integer, ByRef sSucursal As String, ByRef iIdLogDescripcion As Integer, ByRef IdPantalla As Integer, ByRef sDescripcion As String)
        Try
            Dim Cnn As SqlConnection = Crear_ConexionSQL(varPub.cnx_SucursalWeb)
            Dim Cmd As SqlCommand = Crear_ComandoSQL("[CashflowWEB_AddTicket]", CommandType.StoredProcedure, Cnn)
            Crear_ParametroSQL(Cmd, "@IdLogDescripcion", SqlDbType.Int, iIdLogDescripcion)
            Crear_ParametroSQL(Cmd, "@Clave_Sucursal", SqlDbType.VarChar, sSucursal)
            Crear_ParametroSQL(Cmd, "@UsuarioOrigen", SqlDbType.Int, IdUsuario)
            Crear_ParametroSQL(Cmd, "@UsuarioDestino", SqlDbType.Int, 20)
            Crear_ParametroSQL(Cmd, "@Comentario", SqlDbType.VarChar, sDescripcion)
            Ejecutar_NonQuerySQL(Cmd)
        Catch ex As Exception
            fn_AddLog(idCajeroReceptor, IdUsuario, sSucursal, iIdLogDescripcion, IdPantalla, ex.ToString())
        End Try
    End Sub

#End Region

#Region "Funciones de Encripta"

    Public Shared Function fn_Encode(ByVal data As String) As String
        Try
            Dim encyrpt(0 To data.Length - 1) As Byte
            encyrpt = System.Text.Encoding.UTF8.GetBytes(data)
            Dim encodedata As String = Convert.ToBase64String(encyrpt)
            Return encodedata
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function fn_Decode(ByVal data As String) As String
        Try
            Dim encoder As New UTF8Encoding()
            Dim decode As Decoder = encoder.GetDecoder()
            Dim bytes As Byte() = Convert.FromBase64String(data)
            Dim count As Int32 = decode.GetCharCount(bytes, 0, bytes.Length)
            Dim decodechar(0 To count - 1) As Char
            decode.GetChars(bytes, 0, bytes.Length, decodechar, 0)
            Dim result As New String(decodechar)
            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function fn_EncryptToSHA1(ByVal password As String) As String
        Dim sha As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte
        bytesToHash = System.Text.Encoding.ASCII.GetBytes(password)
        bytesToHash = sha.ComputeHash(bytesToHash)

        Dim encPassword As String = ""

        For Each b As Byte In bytesToHash
            encPassword += b.ToString("X2")
        Next
        Return encPassword

    End Function

#End Region

#Region "Funciones Varios"
    'JAVIER ZAPATA 25/03/2019
    Public Shared Sub fn_SoloNumeros(ByVal e As KeyPressEventArgs)
        If e.KeyChar Like "[0-9]" Then
            e.Handled = False
        ElseIf e.KeyChar Like ChrW(8) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Function fn_ConvierteArchivoaBytes(ByVal strPath As String) As Byte()
        Dim ruta As New IO.FileStream(strPath, IO.FileMode.Open, IO.FileAccess.Read)
        Dim binario(ruta.Length) As Byte
        ruta.Read(binario, 0, ruta.Length) 'Leo el archivo y lo convierto a binario 
        ruta.Close() 'Cierro el FileStream 
        'Binario ahora ya contiene nuestro archivo pero en binario" 
        Return binario
    End Function

    Public Shared Function fn_ImageToByteArray(ByVal imageIn As Drawing.Image) As Byte()
        Dim ms As New IO.MemoryStream()
        imageIn.Save(ms, Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Shared Function fn_ByteArrayToImage(ByVal byteArrayIn As Byte()) As Drawing.Image
        Dim ms As New IO.MemoryStream(byteArrayIn)
        Return Image.FromStream(ms)
    End Function

    Public Shared Function fn_Left(ByVal Cadena As String, ByVal Longitud As Int32) As String
        Dim ExtraeIzquierda As String
        Dim MideCadena As Int32
        MideCadena = Cadena.Length
        If MideCadena = 0 OrElse Longitud <= 0 Then
            ExtraeIzquierda = ""
        ElseIf MideCadena < Longitud Then
            ExtraeIzquierda = Cadena
        Else
            ExtraeIzquierda = Cadena.Substring(0, Longitud)
        End If
        Return ExtraeIzquierda
    End Function

    Public Shared Function fn_Right(ByVal Cadena As String, ByVal Longitud As Int32) As String
        Dim ExtraeDerecha As String
        Dim MideCadena As Int32
        MideCadena = Cadena.Length
        If MideCadena = 0 OrElse Longitud <= 0 Then
            ExtraeDerecha = ""
        ElseIf MideCadena < Longitud Then
            ExtraeDerecha = Cadena
        Else
            ExtraeDerecha = Cadena.Substring(MideCadena - Longitud, Longitud)
        End If
        Return ExtraeDerecha
    End Function

    Public Shared Function fn_Mid(ByVal Cadena As String, IniciarEn As Int32, Optional Longitud As Int32 = -1) As String
        Dim ExtraeMedio As String
        Dim MideCadena As Int32
        MideCadena = Cadena.Length

        If MideCadena = 0 OrElse (MideCadena < IniciarEn) OrElse Longitud = 0 Then
            ExtraeMedio = ""
        ElseIf MideCadena >= IniciarEn AndAlso (Longitud = -1 OrElse Longitud > (MideCadena - IniciarEn)) Then

            ExtraeMedio = Cadena.Substring(IniciarEn - 1)
        Else
            ExtraeMedio = Cadena.Substring(IniciarEn - 1, Longitud)
        End If

        Return ExtraeMedio
    End Function

    Public Shared Function fn_LlenarListBox(ByVal lst As ListBox, ByVal dt_Info As DataTable, ByVal ValueMember As String, ByVal DisplayMember As String, ByRef MensajeError As String) As Boolean
        Try
            lst.ValueMember = ValueMember
            lst.DisplayMember = DisplayMember
            lst.DataSource = dt_Info
            Return True
        Catch ex As Exception
            Err.Clear()
            MensajeError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function fn_LlenarListView(ByVal dt_Info As DataTable, ByRef Lista As ListView, ByVal Campo_Tag As String, ByRef MensajeError As String, Optional IsAutoAjuste As Boolean = False) As Boolean
        Try
            Campo_Tag = Campo_Tag.Trim.ToUpper

            Dim Item As ListViewItem
            Lista.Items.Clear()

            '-----»»»Almacenamos anchos de las columnas definidas por el usuario
            Dim cont As Int16 = 0
            Dim AnchosCol() As Int32
            ReDim AnchosCol(Lista.Columns.Count - 1)
            For i As Int32 = 0 To AnchosCol.Length - 1
                AnchosCol(i) = Lista.Columns(i).Width
            Next
            Dim Ancho As Int32 = 100 'default//

            Lista.Columns.Clear()
            For Each dc_Columna As DataColumn In dt_Info.Columns
                Ancho = 100
                If dc_Columna.ColumnName.Trim.ToUpper <> Campo_Tag Then
                    If cont < AnchosCol.Length Then Ancho = AnchosCol(cont)
                    Lista.Columns.Add(dc_Columna.ColumnName, Ancho)  'agrega columna
                    cont += 1
                End If
            Next
            '«««-------------

            Dim E As Int16 = 0 'columna de listview

            For Each dr_Fila As DataRow In dt_Info.Rows
                Item = Nothing

                For I As Int32 = 0 To dr_Fila.ItemArray.Count - 1
                    Dim col_Importe As Boolean = False 'Formato Moned

                    If Campo_Tag <> "" AndAlso Campo_Tag = dt_Info.Columns(I).ColumnName.ToUpper Then
                        E = 1
                        Continue For   'Avanzar --»
                    End If
                    col_Importe = (dt_Info.Columns(I).ColumnName.ToUpper).Contains("IMPORTE")

                    If Item Is Nothing Then
                        Item = New ListViewItem(dr_Fila(I).ToString) With {.Name = dt_Info.Columns(I).ColumnName.ToUpper}
                        If Campo_Tag <> "" Then Item.Tag = dr_Fila(Campo_Tag).ToString
                        Continue For   'Avanzar --»
                    End If

                    If col_Importe Then
                        Item.SubItems.Add(New ListViewItem.ListViewSubItem With {.Name = dt_Info.Columns(I).ColumnName.ToUpper, .Text = FormatNumber(dr_Fila(I).ToString)})
                    Else
                        Item.SubItems.Add(New ListViewItem.ListViewSubItem With {.Name = dt_Info.Columns(I).ColumnName.ToUpper, .Text = dr_Fila(I).ToString})
                    End If

                    If IsNumeric(dr_Fila(I)) Then
                        If I > 0 Then Lista.Columns(I - E).TextAlign = HorizontalAlignment.Right
                    Else
                        If I > 0 Then Lista.Columns(I - E).TextAlign = HorizontalAlignment.Left
                    End If
                    col_Importe = False
                Next

                E = 0
                Lista.Items.Add(Item)
            Next

            If Lista.Items.Count > 0 AndAlso IsAutoAjuste Then
                Lista.BeginUpdate()
                Call fn_AutoAjustarColumnasLista(Lista, -2)
                Lista.EndUpdate()
            End If
            Return True
        Catch ex As Exception
            Err.Clear()
            MensajeError = ex.Message
            Return False

        End Try

    End Function

    Public Shared Function fn_LlenarListViewSQL(ByVal dt_Info As DataTable, ByRef Lista As ListView, ByRef MensajeError As String, Optional IsAutoAjuste As Boolean = False) As Boolean
        Try
            Dim Item As ListViewItem
            Lista.Items.Clear()

            '-----»»»Almacenamos anchos de las columnas definidas por el usuario
            Dim cont As Int16 = 0
            Dim AnchosCol() As Int32
            ReDim AnchosCol(Lista.Columns.Count - 1)
            For i As Int32 = 0 To AnchosCol.Length - 1
                AnchosCol(i) = Lista.Columns(i).Width
            Next
            Dim Ancho As Int32 = 100 'default//

            Lista.Columns.Clear()
            For Each dc_Columna As DataColumn In dt_Info.Columns
                Ancho = 100
                If cont < AnchosCol.Length Then Ancho = AnchosCol(cont)
                Lista.Columns.Add(dc_Columna.ColumnName, Ancho)  'agrega columna
                cont += 1
            Next
            '«««-------------

            Dim E As Int16 = 0 'columna de listview

            For Each dr_Fila As DataRow In dt_Info.Rows
                Item = Nothing

                For I As Int32 = 0 To dr_Fila.ItemArray.Count - 1

                    If Item Is Nothing Then
                        Item = New ListViewItem(dr_Fila(I).ToString) With {.Name = dt_Info.Columns(I).ColumnName.ToUpper}
                        Continue For   'Avanzar --»
                    End If

                    Dim Valor As String = ""
                    If IsDBNull(dr_Fila(I)) Then
                        Valor = ""
                    Else
                        Valor = dr_Fila(I).ToString()
                    End If
                    Item.SubItems.Add(New ListViewItem.ListViewSubItem With {.Name = dt_Info.Columns(I).ColumnName.ToUpper, .Text = Valor})

                    'If IsNumeric(dr_Fila(I)) Then
                    '    If I > 0 Then Lista.Columns(I - E).TextAlign = HorizontalAlignment.Right
                    'Else
                    '    If I > 0 Then Lista.Columns(I - E).TextAlign = HorizontalAlignment.Left
                    'End If
                Next

                E = 0
                Lista.Items.Add(Item)
            Next

            If Lista.Items.Count > 0 AndAlso IsAutoAjuste Then
                Lista.BeginUpdate()
                Call fn_AutoAjustarColumnasLista(Lista, -2)
                Lista.EndUpdate()
            End If
            Return True
        Catch ex As Exception
            Err.Clear()
            MensajeError = ex.Message
            Return False

        End Try

    End Function

    Public Shared Function fn_AutoAjustarColumnasLista(ByVal lsv As ListView, ByVal ModoAjuste As SByte) As Boolean
        Try
            For Each col As ColumnHeader In lsv.Columns
                If col.Width > 0 Then
                    col.Width = ModoAjuste
                End If
            Next
            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function fn_CargarCombo(ByRef cmb As ComboBox, ByVal dt_Info As DataTable, ByRef MensajeError As String) As Boolean
        Try
            Dim dr_Nuevo As DataRow = dt_Info.NewRow

            dr_Nuevo.Item(cmb.ValueMember) = "0"
            dr_Nuevo.Item(cmb.DisplayMember) = "Seleccione..."

            If dt_Info.Columns(cmb.DisplayMember).MaxLength < 13 Then
                dt_Info.Columns(cmb.DisplayMember).MaxLength = 20
            End If

            For i = 0 To dt_Info.Columns.Count - 1
                dt_Info.Columns(i).AllowDBNull = True
            Next

            dt_Info.Rows.InsertAt(dr_Nuevo, 0)
            cmb.DataSource = dt_Info
            cmb.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Err.Clear()
            MensajeError = ex.Message
            Return False
        End Try

    End Function

    Public Shared Sub fn_CambiaTamanoFuente(ByVal control As Control, ByVal FuenteTLabel As Int32, ByVal FuenteTBoton As Int32)
        'Recorremos con un ciclo for each cada control que hay en la colección Controls
        For Each contHijo As Control In control.Controls

            Select Case True
                Case TypeOf contHijo Is Label, TypeOf contHijo Is TextBox
                    contHijo.Font = New Font(New FontFamily("Arial"), FuenteTLabel)

                Case TypeOf contHijo Is Button
                    If contHijo.Name = "btn_ConsultaRetiros" Then
                        contHijo.Font = New Font(New FontFamily("Arial"), FuenteTBoton - 2)
                    Else
                        contHijo.Font = New Font(New FontFamily("Arial"), FuenteTBoton)
                    End If
                    ' el tag=1 'Para botones que muestran modal Fecha
                    If contHijo.Tag <> 1 Then
                        'color sissa dorado
                        contHijo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Int32), CType(CType(160, Byte), Int32), CType(CType(98, Byte), Int32))
                    End If

                Case TypeOf contHijo Is Panel
                    '223, 207, 176 fuerte
                    contHijo.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Int32), CType(CType(207, Byte), Int32), CType(CType(176, Byte), Int32))

                Case TypeOf contHijo Is ListView, TypeOf contHijo Is ListBox, TypeOf contHijo Is ComboBox
                    '242, 236, 223 claro
                    contHijo.Font = New Font(New FontFamily("Arial"), FuenteTLabel)
                    contHijo.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Int32), CType(CType(236, Byte), Int32), CType(CType(223, Byte), Int32))

            End Select

            'Preguntamos si el control tiene uno o mas controles dentro de l mismo con la propiedad 'HasChildren'
            'Si el control tiene 1 o más controles, entonces llamamos al procedimiento de forma recursiva, para que siga
            'recorriendo los demás controles
            If contHijo.HasChildren Then fn_CambiaTamanoFuente(contHijo, FuenteTLabel, FuenteTBoton)
            'Aqui va la lógica de lo queramos hacer, modificar tamaño de todos los controles
        Next
    End Sub

    Public Shared Function fn_ConvertNumeroALetras(ByVal Numero As String, Optional ByVal Moneda As String = "") As String

        Dim BandBilion As Boolean
        Dim NumeroALetras As String = ""
        Dim b, paso, cifra As Int32
        Dim expresion As String = ""
        Dim entero As String = ""
        Dim deci As String = ""
        Dim flag As String = ""
        Dim valor As String = ""
        Dim gOpcionMil As Boolean = True 'Para usar Miles de Millones y no la palabra Millardos

        flag = "N"

        '** AQUI REVISAMOS SI EL MONTO TIENE PARTE DECIMAL.
        For paso = 1 To Numero.Length 'DETERMINA CUANTOS CARACTERES TIENE LA CADENA
            If fn_Mid(Numero, paso, 1) = "." Or fn_Mid(Numero, paso, 1) = "," Then 'DEPENDIENDO DE LA REGIÓN
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + fn_Mid(Numero, paso, 1) 'EXTAE LA PARTE ENTERA DEL NUMERO
                Else
                    deci = deci + fn_Mid(Numero, paso, 1) 'EXTRAE LA PARTE DECIMAL DEL NUMERO
                End If
            End If
        Next paso

        'DEFINIMOS VALOR EN LAS VARIABLES
        'CIFRA Y VALOR PARA USARLAS COMO
        'BANDERAS CONDICIONALES.

        cifra = entero.Length

        Select Case cifra
            Case Is = 1
                valor = "UNIDAD" 'SIN USAR
            Case Is = 2
                valor = "DECENAS" 'SIN USAR
            Case Is = 3
                valor = "CENTENAS" 'SIN USAR
            Case Is = 4, 5, 6
                valor = "MILES" 'USADO
            Case Is = 7, 8, 9
                valor = "MILION" 'USADO
            Case Is = 10, 11, 12
                valor = "MILIARDOS" 'USADO
            Case Is = 13, 14, 15
                valor = "BILIONES" 'USADO
        End Select

        '*** SI LA CIFRA TIENE VALOR DECIMAL LO ASIGNAMOS AQUI.
        If deci.Length >= 1 Then
            If deci.Length = 1 Then deci = deci & "0"
            deci = deci & "/100"  'ANTES TENIA & "0" "/100."
        Else
            deci = "00/100"
        End If


        flag = "N"
        If Val(Numero) >= -999999999999999.0# And Val(Numero) <= 999999999999999.0# Then  'SI EL NUMERO ESTA DENTRO DE 0 A 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9, 12, 15
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "CIEN "
                                Else
                                    expresion = expresion & "CIENTO "
                                End If
                            Case "2"
                                expresion = expresion & "DOSCIENTOS "
                            Case "3"
                                expresion = expresion & "TRESCIENTOS "
                            Case "4"
                                expresion = expresion & "CUATROCIENTOS "
                            Case "5"
                                expresion = expresion & "QUINIENTOS "
                            Case "6"
                                expresion = expresion & "SEISCIENTOS "
                            Case "7"
                                expresion = expresion & "SETECIENTOS "
                            Case "8"
                                expresion = expresion & "OCHOCIENTOS "
                            Case "9"
                                expresion = expresion & "NOVECIENTOS "

                        End Select

                    Case 2, 5, 8, 11, 14
                        Select Case fn_Mid(entero, b, 1)
                            Case "1"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "DIEZ "
                                End If
                                If fn_Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "ONCE "
                                End If
                                If fn_Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "DOCE "
                                End If
                                If fn_Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "TRECE "
                                End If
                                If fn_Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "CATORCE "
                                End If
                                If fn_Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "QUINCE "
                                End If
                                If fn_Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "DIECI"
                                End If

                            Case "2"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "VEINTE "
                                    flag = "S"
                                Else
                                    expresion = expresion & "VEINTI"
                                    flag = "N"
                                End If

                            Case "3"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "TREINTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "TREINTA Y "
                                    flag = "N"
                                End If

                            Case "4"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "CUARENTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "CUARENTA Y "
                                    flag = "N"
                                End If

                            Case "5"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "CINCUENTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "CINCUENTA Y "
                                    flag = "N"
                                End If

                            Case "6"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "SESENTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "SESENTA Y "
                                    flag = "N"
                                End If

                            Case "7"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "SETENTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "SETENTA Y "
                                    flag = "N"
                                End If

                            Case "8"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "OCHENTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "OCHENTA Y "
                                    flag = "N"
                                End If

                            Case "9"
                                If fn_Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "NOVENTA "
                                    flag = "S"
                                Else
                                    expresion = expresion & "NOVENTA Y "
                                    flag = "N"
                                End If

                            Case "0"
                                'EXPRESION = EXPRESION & ""
                                flag = "N"
                        End Select


                    Case 1, 4, 7, 10, 13
                        Select Case fn_Mid(entero, b, 1)
                            Case "1"

                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "UNO "
                                    Else
                                        expresion = expresion & "UN "
                                    End If
                                End If

                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "DOS "
                                End If

                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "TRES "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "CUATRO "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "CINCO "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "SEIS "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "SIETE "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "OCHO "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "NUEVE "
                                End If
                        End Select
                End Select

                '*************************************************************************

                '********* MILES PARA MILES
                If paso = 4 And valor = "MILES" Then
                    If fn_Mid(entero, 6, 1) <> "0" Or fn_Mid(entero, 5, 1) <> "0" Or fn_Mid(entero, 4, 1) <> "0" Or
                        (fn_Mid(entero, 6, 1) = "0" And fn_Mid(entero, 5, 1) = "0" And fn_Mid(entero, 4, 1) = "0" And
                        Len(entero) <= 6) Then
                        expresion = expresion & "MIL "
                    End If
                End If

                '********** MILES PARA MILLONES
                If paso = 4 And valor = "MILION" Then

                    If cifra = 7 And Val(fn_Mid(entero, 2, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If


                    If cifra = 8 And Val(fn_Mid(entero, 3, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If

                    If cifra = 9 And Val(fn_Mid(entero, 4, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If
                End If


                '********** MILES PARA MILLARDOS
                If paso = 4 And valor = "MILIARDOS" Then

                    If cifra = 10 And Val(fn_Mid(entero, 5, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If


                    If cifra = 11 And Val(fn_Mid(entero, 6, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If

                    If cifra = 12 And Val(fn_Mid(entero, 7, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If
                End If

                '********** MILES PARA BILLONES
                If paso = 4 And valor = "BILIONES" Then

                    If cifra = 13 And Val(fn_Mid(entero, 8, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If

                    If cifra = 14 And Val(fn_Mid(entero, 9, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If

                    If cifra = 15 And Val(fn_Mid(entero, 10, 3)) >= 1 Then
                        expresion = expresion & "MIL "
                    End If
                End If

                '**********"INICIAMOS CONDICIONES PARA USAR PALABRA MILES DE MILLONES"*****************
                Select Case gOpcionMil
                    Case True 'DESEA USAR LA PALABRA MILES DE MILLONES
                        'Z********[SOLO PARA MILLARDOS] CUANDO MILLONES ES IGUAL A CERO
                        If paso = 7 And valor = "MILIARDOS" And cifra = 10 _
                        And Val(fn_Mid(entero, 2, 3)) = 0 Then
                            expresion = expresion & "MILLONES "
                        End If


                        If paso = 7 And valor = "MILIARDOS" And cifra = 11 _
                        And Val(fn_Mid(entero, 3, 3)) = 0 Then
                            expresion = expresion & "MILLONES "
                        End If


                        If paso = 7 And valor = "MILIARDOS" And cifra = 12 _
                        And Val(fn_Mid(entero, 4, 3)) = 0 Then
                            expresion = expresion & "MILLONES "
                        End If
                        'Z*****PONER MILLARDOS DE BILLONES ******
                        If paso = 10 And valor = "BILIONES" And cifra = 13 _
                        And Val(fn_Mid(entero, 2, 3)) > 0 Then
                            expresion = expresion & "MIL "
                            BandBilion = True
                        End If

                        If paso = 10 And valor = "BILIONES" And cifra = 14 _
                        And Val(fn_Mid(entero, 3, 3)) > 0 Then
                            expresion = expresion & "MIL "
                            BandBilion = True
                        End If

                        If paso = 10 And valor = "BILIONES" And cifra = 15 _
                        And Val(fn_Mid(entero, 4, 3)) > 0 Then
                            expresion = expresion & "MIL "
                            BandBilion = True
                        End If

                        'Z******** SOLO PARA BILLONES CUANDO MILLARDOS ES MAS DE CERO
                        If paso = 7 And valor = "BILIONES" And cifra = 13 _
                        And Val(fn_Mid(entero, 5, 3)) = 0 And BandBilion Then
                            expresion = expresion & "MILLONES "
                            BandBilion = False
                        End If

                        If paso = 7 And valor = "BILIONES" And cifra = 14 _
                        And Val(fn_Mid(entero, 6, 3)) = 0 And BandBilion Then
                            expresion = expresion & "MILLONES "
                            BandBilion = False
                        End If

                        If paso = 7 And valor = "BILIONES" And cifra = 15 _
                        And Val(fn_Mid(entero, 7, 3)) = 0 And BandBilion Then
                            expresion = expresion & "MILLONES "
                            BandBilion = False
                        End If

                        'Z********** SOLO PARA MILLARDOS PRONUNCIADOS EN MILES DE MILLONES.
                        If paso = 10 And valor = "MILIARDOS" Then
                            expresion = expresion & "MIL "
                        End If
                        '**********"TERMINAMOS CONDICIONES PARA USAR PALABRA MILES DE MILLONES"**********


                        '**********"INICIAMOS CONDICIONES PARA USAR PALABRA MILLARDO(S)"**********
                    Case Else ' DESEA USAR  LA PALABRA MILLARDOS

                        If paso = 10 And valor = "BILIONES" And cifra = 13 _
                        And Val(fn_Mid(entero, 2, 3)) > 0 Then
                            If Val(fn_Mid(entero, 2, 3)) = 1 Then
                                expresion = expresion & "MILLARDO "
                            Else
                                expresion = expresion & "MILLARDOS "
                            End If
                        End If
                        If paso = 10 And valor = "BILIONES" And cifra = 14 _
                        And Val(fn_Mid(entero, 3, 3)) > 0 Then
                            If Val(fn_Mid(entero, 3, 3)) = 1 Then
                                expresion = expresion & "MILLARDO "
                            Else
                                expresion = expresion & "MILLARDOS "
                            End If
                        End If
                        If paso = 10 And valor = "BILIONES" And cifra = 15 _
                        And Val(fn_Mid(entero, 4, 3)) > 0 Then
                            If Val(fn_Mid(entero, 4, 3)) = 1 Then
                                expresion = expresion & "MILLARDO "
                            Else
                                expresion = expresion & "MILLARDOS "
                            End If
                        End If

                        '********** MILLARDOS

                        If paso = 10 And valor = "MILIARDOS" Then
                            If Len(entero) = 10 And fn_Mid(entero, 1, 1) = "1" Then
                                expresion = expresion & "MILLARDO "
                            Else
                                expresion = expresion & "MILLARDOS "
                            End If
                        End If
                        '**********"TERMINAMOS CONDICIONES PARA USAR PALABRA MILLARDO(S)"**********
                        '**************************************************************************
                End Select

                '*******[SOLO PARA MILLARDOS] CUANDO MILLONES ES MAS DE CERO

                If paso = 7 And valor = "MILIARDOS" And cifra = 10 And
                Val(fn_Mid(entero, 2, 3)) > 0 Then
                    If Val(fn_Mid(entero, 2, 3)) = 1 Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If

                If paso = 7 And valor = "MILIARDOS" And cifra = 11 _
                And Val(fn_Mid(entero, 3, 3)) > 0 Then
                    If Val(fn_Mid(entero, 3, 3)) = 1 Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If

                If paso = 7 And valor = "MILIARDOS" And cifra = 12 _
                And Val(fn_Mid(entero, 4, 3)) > 0 Then
                    If Val(fn_Mid(entero, 4, 3)) = 1 Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If

                '*************************************************
                '******** SOLO BILLONES **************************

                If paso = 7 And valor = "BILIONES" And cifra = 13 _
                And Val(fn_Mid(entero, 5, 3)) > 0 Then
                    If Val(fn_Mid(entero, 5, 3)) = 1 Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If

                If paso = 7 And valor = "BILIONES" And cifra = 14 _
                And Val(fn_Mid(entero, 6, 3)) > 0 Then
                    If Val(fn_Mid(entero, 6, 3)) = 1 Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If

                If paso = 7 And valor = "BILIONES" And cifra = 15 _
                And Val(fn_Mid(entero, 7, 3)) > 0 Then
                    If Val(fn_Mid(entero, 7, 3)) = 1 Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If
                '****************************************************


                '********** SOLO PARA MILLONES
                If paso = 7 And valor = "MILION" Then
                    If Len(entero) = 7 And fn_Mid(entero, 1, 1) = "1" Then
                        expresion = expresion & "MILLÓN "
                    Else
                        expresion = expresion & "MILLONES "
                    End If
                End If

                '******** SOLO PARA BILLONES
                If paso = 13 Then
                    If Len(entero) = 13 And fn_Mid(entero, 1, 1) = "1" Then
                        expresion = expresion & "BILLÓN "
                    Else
                        expresion = expresion & "BILLONES "
                    End If
                End If
            Next paso

            'Agregar Moneda
            If Moneda <> "" Then
                expresion += " " & Moneda & " "
            End If

            '*** EVALUAR QUE ESCRIBIR
            If deci <> "" Then 'SI EL VALOR RESULTANTE ES NEGATIVO CON DECIMAL
                If fn_Mid(entero, 1, 1) = "-" Or fn_Mid(entero, 1, 1) = "(" Then
                    NumeroALetras = "MENOS " & expresion & "CON " & deci 'ANTES & "/100"
                Else
                    NumeroALetras = expresion & "CON " & deci 'ANTES & "/100"
                End If
            Else 'SI EL VALOR RESULTANTE ES NEGATIVO SIN DECIMAL
                If fn_Mid(entero, 1, 1) = "-" Or fn_Mid(entero, 1, 1) = "(" Then
                    NumeroALetras = "MENOS " & expresion
                Else
                    NumeroALetras = expresion 'SI NO TIENE DECIMAL
                End If
            End If

            If Val(Numero) = 0 Then NumeroALetras = "MONTO ES IGUAL A CERO." 'NO DEBERÍA LLEAGR AQUI
        Else 'SI EL NUMERO A CONVERTIR ESTÁ FUERA DEL RANGO SUPERIOR O INFERIOR
            NumeroALetras = "ERROR EN EL DATO INTRODUCIDO"
        End If

        Return NumeroALetras

    End Function

    Public Shared Function fn_Valida_Contra(ByVal cadena As String) As Boolean
        Dim Ii As Int32
        Dim Car As String
        Dim Numeros As String = "0123456789"
        Dim Mayus As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim Minus As String = "abcdefghijklmnopqrstuvwxyz"
        Dim Cant_Numeros As Int32 = 0
        Dim Cant_Mayus As Int32 = 0
        Dim Cant_Minus As Int32 = 0

        fn_Valida_Contra = False
        If cadena.Length < 8 Then
            Exit Function
        End If

        For Ii = 1 To cadena.Length
            Car = fn_Mid(cadena, Ii, 1)

            If Numeros.Contains(Car) Then
                Cant_Numeros = Cant_Numeros + 1
            End If

            If Mayus.Contains(Car) Then
                Cant_Mayus = Cant_Mayus + 1
            End If

            If Minus.Contains(Car) Then
                Cant_Minus = Cant_Minus + 1
            End If

        Next Ii
        'Antes era->cantidad_numeros lo dejamos en 2 ..antes era >3 o sea 4
        'ahora valida que sean 8 numeros
        If Cant_Numeros = 8 Then ' And (Cant_Mayus + Cant_Minus) = 4 Then
            fn_Valida_Contra = True
        Else
            fn_Valida_Contra = False
        End If

    End Function

    Public Shared Function fn_RellenarCadena(ByVal Cadena As String, ByVal LongitudDeseada As Int32, ByVal CaracterRellena As Char, ByVal Posicion As strPosicion) As String
        Dim CadResult As String = Cadena
        ' ACTUALZAR ESTA FUNCION EN LA DLL
        If Cadena.Length >= LongitudDeseada Then
            Return Cadena
        End If

        Select Case Posicion
            Case strPosicion.Izquierda
                For n As Int32 = Cadena.Length To LongitudDeseada - 1
                    CadResult = CaracterRellena & CadResult
                Next n
            Case strPosicion.Derecha
                For n As Int32 = Cadena.Length To LongitudDeseada - 1
                    CadResult = CadResult & CaracterRellena
                Next n
            Case strPosicion.Izq_Der
                Dim hasta As Int16 = (LongitudDeseada - Cadena.Length) / 2

                For n As Int32 = 1 To hasta
                    CadResult = CaracterRellena & CadResult & CaracterRellena
                Next n
                If CadResult.Length > LongitudDeseada Then
                    CadResult = CadResult.Substring(0, LongitudDeseada)
                ElseIf CadResult.Length < LongitudDeseada Then
                    CadResult = CaracterRellena & CadResult
                End If
        End Select

        Return CadResult

    End Function

    Public Shared Function fn_ValidarMail(ByVal sMail As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(sMail, "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
    End Function

#End Region

End Class
