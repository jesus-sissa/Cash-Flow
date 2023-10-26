Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

''' <summary>
''' Estructura del Recibo de 80mm Impresora Nippon
''' </summary>
''' <remarks></remarks>
Public Structure stc_NPI80mmWinNormal

#Region "Variables Privadas"

    Private _dr_General As DataRow
    Private _dt_Detalle As DataTable
    Private _dt_Desglose As DataTable
    Private _dt_Desglose2 As DataTable
    Private _ventana As Integer
    Private _dt_DetalleAg As DataTable

    Private _CasetAnt As String

    Private _Tipo_Impresion As Tipos_Impresion

#End Region

#Region "Variables Públicas"

    Public Enum Tipos_Impresion As Byte
        Deposito = 0
        Saldo = 1
        Recoleccion = 2
        Corte_Diario = 3
        Movimientos = 4
        Atascos = 5
    End Enum

#End Region

#Region "Propiedades Públicas"

    Public Property dr_General() As DataRow
        Get
            Return _dr_General
        End Get
        Set(ByVal value As DataRow)
            _dr_General = value
        End Set
    End Property

    Public Property dt_Detalle() As DataTable
        Get
            Return _dt_Detalle
        End Get
        Set(ByVal value As DataTable)
            _dt_Detalle = value
        End Set
    End Property

    Public Property dt_Desglose() As DataTable
        Get
            Return _dt_Desglose
        End Get
        Set(ByVal value As DataTable)
            _dt_Desglose = value
        End Set
    End Property

    Public Property dt_Desglose2() As DataTable
        Get
            Return _dt_Desglose2
        End Get
        Set(ByVal value As DataTable)
            _dt_Desglose2 = value
        End Set
    End Property

    Public Property Ventana() As Integer
        Get
            Return _Ventana
        End Get
        Set(ByVal value As Integer)
            _ventana = value
        End Set
    End Property

    Public Property dt_DetalleAgrupado() As DataTable
        Get
            Return _dt_DetalleAg
        End Get
        Set(ByVal value As DataTable)
            _dt_DetalleAg = value
        End Set
    End Property

    Public Property CasetAnt() As String
        Get
            Return _CasetAnt
        End Get
        Set(ByVal value As String)
            _CasetAnt = value
        End Set
    End Property

    Public Property Tipo_Impresion() As Tipos_Impresion
        Get
            Return _Tipo_Impresion
        End Get
        Set(ByVal value As Tipos_Impresion)
            _Tipo_Impresion = value
        End Set
    End Property

#End Region
End Structure

Public Class cls_NPIticket80mmWinNormal
    Private _Recibo As stc_NPI80mmWinNormal

    Public Function Imprimir(ByVal Recibo As stc_NPI80mmWinNormal) As Boolean
        Try
            _Recibo = Recibo
            Call fn_Imprimir()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function Obtener_ImpresoraDefault() As String
        Try
            ' obtiene la impresora predeterminada   
            Dim instacia As New Printing.PrinterSettings
            Dim PrinterDefault As String = instacia.PrinterName

            'Dim pd As New Printing.PrintDocument ' otra forma de obtner impresora default
            'Dim PrinterDefault2 As String = pd.PrinterSettings.PrinterName
            Return PrinterDefault
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Sub fn_ImprimirAtasco(ByVal _Recibo As stc_NPI80mmWinNormal)
        Dim nii As New NiiPrinterCLib.NIIClassLib()

        Dim ret As Integer
        Dim cmd As Integer
        Dim jid As Long
        Dim textoSalida As String = ""
        Dim strAlineacion As String = ""
        Dim ImportePesosV1 As Decimal = 0D
        Dim ImportePesosV2 As Decimal = 0D
        Dim ImporteDolar As Decimal = 0D
        Dim ImporteDolar2 As Decimal = 0D
        ' Dim hdc As IntPtr
        'Dim g As Graphics

        ' se debe obtner la Impresora y guardarla en variable publica desde parametros
        Dim nombrePrinter As String = Obtener_ImpresoraDefault()
        Try

            If nombrePrinter.Trim = String.Empty Then Exit Sub

            '----Esta IMpresion es de  80mm (Windows Normal)
            varPub.SegundosSesion = 0
            Dim ventana As Integer = _Recibo.Ventana
            Dim TituloTicket As String = ""
            Dim Subtitulo As String = ""
            '1.- INICIA EL DOCUMENTO A IMPRIMIR
            ret = nii.NiiStartDoc(nombrePrinter, jid)
            '2.- IMPRIME INICIO DE LA IMPRESION???
            cmd = jid
            textoSalida = "1D""G""11" + cmd.ToString("X2") + "000000"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            textoSalida = "1b""@""0a" 'Resetea valores la @
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            textoSalida = "1b""a""01" ' ALINEADO A centro
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            textoSalida = """" & varPub.Nombre_Sucursal & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & varPub.Direccion & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """Tel: " & varPub.Telefono & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            TituloTicket = "ATASCO"

            textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & TituloTicket & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""@""0a" 'Resetea valores la @
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""00" ' ALINEADO A izquierda
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "Folio:" & _Recibo.dr_General("Folio") & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "FECHA:" & _Recibo.dr_General("Fecha_Inicio") & " - " & _Recibo.dr_General("Hora_Inicio") & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            '====== IMPRIME EL NOMBRE DEL CAJERO ============
            textoSalida = """" & "CAJERO:" & _Recibo.dr_General("Nombre_Usuario") & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            textoSalida = """" & "CAJA:" & _Recibo.dr_General("Clave_Caja") & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""01" ' ALINEADO A CENTRO
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """DESGLOSE ATASCO""0a0a" ' 
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            '<----Validar Registros para imprimir Encabezados ---->

            textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "VALIDADOR " + _Recibo.dr_General("Numero_Validador").ToString() & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""00" ' ALINEADO A izquierda
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
            textoSalida = """" & strAlineacion & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            strAlineacion = Alinea_Cadenas(_Recibo.dr_General("Clave"), _Recibo.dr_General("Cantidad"), FormatCurrency(_Recibo.dr_General("Denominacion"), 2))
            textoSalida = """" & strAlineacion & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""02" ' ALINEADO A DERECHA
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "PIEZAS MXN V" + _Recibo.dr_General("Numero_Validador").ToString() + ":   " & 1 & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "TOTAL MXN V" + _Recibo.dr_General("Numero_Validador").ToString() + ": " & FormatCurrency(_Recibo.dr_General("Denominacion"), 2) & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""01"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """TOTALES""0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "IMPORTE TOTAL ANTES: " & FormatCurrency(_Recibo.dr_General("Totales_Antes"), 2) & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "IMPORTE DESCONTADO: " & FormatCurrency(_Recibo.dr_General("Importe"), 2) & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "" & _Recibo.dr_General("ImporteTotal_Letras").ToString() & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "IMPORTE TOTAL NUEVO: " & FormatCurrency(_Recibo.dr_General("Total_Nuevo"), 2) & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""01" ' ALINEADO A CENTRO
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """____________________________________""0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """FIRMA""0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            '-----Imprime Fecha y Hora de Impresion y Fin de Ticket-------------

            textoSalida = "1b""a""01" ' ALINEADO A centro
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "FECHA IMPRESION: " & Format(Now, "dd/MM/yyyy") & " - " & Hora & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """-------------FIN TICKET-------------""0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            '-----Si llega hasta aqui.. Entonces ya terminó de imprimir 
            varPub.continuaImprimiendo = False
            varPub.ultFila_DTimpreso = 0
            varPub.Paginacion = 1

            'ˆóŽšŒãˆ—
            ' IMPRIME ALGO QUIEN SABE?
            textoSalida = "1B4A781b69"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            ' IMPRIME FINAL DE IMPRESION?
            textoSalida = "1D""G""10"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            ' FINALIZA EL DOCUMENTO
            ret = nii.NiiEndDoc(nombrePrinter)

        Catch ex As Exception
            fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 82, varPub.IdPantalla, "IMPRIMIR TICKET " + " FIN - ERROR AL IMPRIMIR INFORMACIÓN DEL ATASCO. " + ex.ToString())
            Call fn_EscribirLog(varPub.UsuarioClave, "IMPRIMIR", " ERRROR AL IMPRIMIR EL TICKET. " & ex.Message())
        End Try


    End Sub

    Private Sub fn_Imprimir()

        Dim nii As New NiiPrinterCLib.NIIClassLib()


        Dim ret As Integer
        Dim cmd As Integer
        Dim jid As Long
        Dim textoSalida As String = ""
        Dim strAlineacion As String = ""
        Dim ImportePesosV1 As Decimal = 0D
        Dim ImportePesosV2 As Decimal = 0D
        Dim ImporteDolar As Decimal = 0D
        Dim ImporteDolar2 As Decimal = 0D
        ' Dim hdc As IntPtr
        'Dim g As Graphics

        ' se debe obtner la Impresora y guardarla en variable publica desde parametros
        Dim nombrePrinter As String = Obtener_ImpresoraDefault()
        Try
            If nombrePrinter.Trim = String.Empty Then Exit Sub

            '----Esta IMpresion es de  80mm (Windows Normal)
            varPub.SegundosSesion = 0
            Dim ventana As Integer = _Recibo.Ventana
            Dim TituloTicket As String = ""
            Dim Subtitulo As String = ""
            '1.- INICIA EL DOCUMENTO A IMPRIMIR
            ret = nii.NiiStartDoc(nombrePrinter, jid)

            '2.- IMPRIME INICIO DE LA IMPRESION???
            cmd = jid
            textoSalida = "1D""G""11" + cmd.ToString("X2") + "000000"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""@""0a" 'Resetea valores la @
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""01" ' ALINEADO A centro
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            ' If varPub.Logo_Empresa IsNot Nothing Then
            ''ESTA PENDIENTE IMPRIMIR LA IMAGENNNNN
            'Dim newImage As New Bitmap(varPub.Logo_EmpresaRuta)
            'g = Graphics.FromImage(newImage) 'crear un objeto Graphics a partir de un objeto Image

            'g.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height)
            'hdc = g.GetHdc() '

            ''IMPRIME LA IMAGEN DEL PICTUREBOX
            'ret = nii.NiiImagePrint(nombrePrinter, hdc, newImage.Width, newImage.Height, True, Nothing)
            ' End If

            textoSalida = """" & varPub.Nombre_Sucursal & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & varPub.Direccion & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """Tel: " & varPub.Telefono & """0a0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            TituloTicket = [Enum].GetName(GetType(stc_NPI80mmWinNormal.Tipos_Impresion), _Recibo.Tipo_Impresion).ToUpper
            If ventana = 1 Then
                TituloTicket = "CORTE"
                Subtitulo = "[CORTE POR DIA]"
            End If
            Select Case TituloTicket
                Case "CORTE_DIARIO"
                    TituloTicket = "CORTE DIARIO"
                    Subtitulo = "[DESDE ULTIMA RECOLECCION]"
                    If varPub.Tipo_CorteDiario = 2 Then
                        Subtitulo = "[DIA ACTUAL]"
                    ElseIf varPub.Tipo_CorteDiario = 3 Then
                        Subtitulo = "[DIA ACTUAL COMPLETO]"
                    End If
                Case "DEPOSITO"
                    If _Recibo.dr_General("Tipo") = 2 And _Recibo.dr_General("Es_Efectivo") = "S" Then
                        TituloTicket = "DEPOSITO MANUAL (EFE)"

                    ElseIf _Recibo.dr_General("Tipo") = 2 And _Recibo.dr_General("Es_Efectivo") = "N" Then
                        TituloTicket = "DEPOSITO MANUAL (DOC)"
                    Else
                        TituloTicket = "DEPOSITO VALIDADO"
                    End If
                Case "CORTE"
                    TituloTicket = "CORTE"
                    Subtitulo = "[CORTE POR DIA]"
                    If varPub.ManejaCorte = 1 Then
                        Subtitulo = "[DIA ACTUAL]"
                    End If
            End Select

            If ventana = 1 Then
                TituloTicket = "CORTE"
                Subtitulo = "[CORTE POR DIA]"

            End If
            textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & TituloTicket & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            If TituloTicket = "CORTE DIARIO" Then
                textoSalida = """" & Subtitulo & """0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            End If

            textoSalida = "1b""@""0a" 'Resetea valores la @
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = "1b""a""00" ' ALINEADO A izquierda
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            '-----------------------------------------------------------------------------

            Select Case _Recibo.Tipo_Impresion

                Case stc_NPI80mmWinNormal.Tipos_Impresion.Movimientos
                    'revisar alineaciones de estos textos

                    textoSalida = """" & "FECHA INICIO:" & _Recibo.dr_General("FechaInicio") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """" & "FECHA FIN:" & _Recibo.dr_General("FechaFin") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                Case stc_NPI80mmWinNormal.Tipos_Impresion.Corte_Diario

                    textoSalida = """" & "FECHA :" & _Recibo.dr_General("Fecha") & " - " & _Recibo.dr_General("Hora") & """0a0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                Case stc_NPI80mmWinNormal.Tipos_Impresion.Deposito

                    textoSalida = """" & "FOLIO:" & _Recibo.dr_General("Folio") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    'Si es tipo=1(validado)
                    If _Recibo.dr_General("Tipo") = 1 Then

                        textoSalida = """" & "INICIO:" & _Recibo.dr_General("Fecha_Inicio") & " - " & _Recibo.dr_General("Hora_Inicio") & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "FIN:" & _Recibo.dr_General("Fecha_Fin") & " - " & _Recibo.dr_General("Hora_Fin") & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    Else
                        textoSalida = """" & "FECHA:" & _Recibo.dr_General("Fecha_Inicio") & " - " & _Recibo.dr_General("Hora_Inicio") & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    End If

                Case stc_NPI80mmWinNormal.Tipos_Impresion.Saldo

                    textoSalida = """" & "FECHA:" & _Recibo.dr_General("Fecha") & " - " & _Recibo.dr_General("Hora") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                Case stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion
                    textoSalida = """" & "FOLIO:" & _Recibo.dr_General("Folio") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """" & "REMISION:" & _Recibo.dr_General("Remision") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """" & "ENVASE:" & _Recibo.dr_General("Envase") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """" & "FECHA:" & _Recibo.dr_General("Fecha") & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            End Select

            textoSalida = "1b""a""00" ' ALINEADO A izquierda
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            Select Case _Recibo.Tipo_Impresion
                Case stc_NPI80mmWinNormal.Tipos_Impresion.Deposito, stc_NPI80mmWinNormal.Tipos_Impresion.Saldo, stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion

                    If ventana = 0 Then
                        '====== IMPRIME EL NOMBRE DEL CAJERO ============
                        textoSalida = """" & "CAJERO:" & _Recibo.dr_General("Nombre_Usuario") & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Deposito Then
                            textoSalida = """" & "CAJA:" & _Recibo.dr_General("Clave_Caja") & """0a0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        End If
                    ElseIf ventana = 1 Then
                        '====== IMPRIME EL NOMBRE DE QUIEN HIZO CORTE ============
                        textoSalida = """" & "GENERO CORTE:" & _Recibo.dr_General("Nombre_Usuario") & """0a0a"

                    End If

                    '================================================
                    '▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄06/11/2015 solo imprimir esto cuando sea RETIROS▄▄▄▄▄

                    If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion Then

                        textoSalida = "1b""a""01" ' ALINEADO A centro
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """DETALLE""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """------------------------------------------------""0a" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        For Each row2 As DataRow In _Recibo.dt_DetalleAgrupado.Rows
                            strAlineacion = Alinea_Cadenas(row2("Fecha"), FormatCurrency(row2("Importe"), 2))
                            textoSalida = """" & strAlineacion & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        Next

                        textoSalida = "1b""--------------------------------------------------""0a" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    End If
                    '▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄

                    '══════SI ES DEPOSITO MANUAL(BUZON=2)═══════════════
                    If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Deposito Then
                        If _Recibo.dr_General("Tipo") = 2 Then

                            textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            textoSalida = """" & "TOTAL MXN: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2) & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            textoSalida = """" & "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2) & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            textoSalida = """" & "TIPO DE CAMBIO: " & FormatCurrency(_Recibo.dr_General("TipoCambio_USD"), 2) & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            textoSalida = """" & "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_Convert"), 2) & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                            Exit Select

                        End If

                    End If
                    '════════════════════════════════════════════════════
                    '▀▀▀▀▀▀▀▀▀▀▀▀▀▀DESGLOSE (DEPOSITOS / RETIROS / SALDO)▀▀▀▀▀▀▀▀▀▀▀
                    '<-----Hacer Subconsulta por  moneda (Peso[MXP/MXN] Y Dolar[USD])----->
                    Dim piezasPesoV1 As Integer = 0
                    Dim piezasPesoV2 As Integer = 0
                    Dim piezasDolar As Integer = 0
                    Dim piezasDolar2 As Integer = 0
                    Dim dr_Pesos2() As DataRow
                    Dim dr_Dolares2() As DataRow

                    Dim dr_Pesos() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'MXP' Or Moneda = 'MXN'", "Denominacion")
                    Dim dr_Dolares() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'USD'", "Denominacion")

                    dr_Pesos2 = _Recibo.dt_Desglose2.Select("Moneda = 'MXP' Or Moneda = 'MXN'", "Denominacion")
                    dr_Dolares2 = _Recibo.dt_Desglose2.Select("Moneda = 'USD'", "Denominacion")

                    Dim Serie As Integer = 0
                    '<----Validar Registros para imprimir Encabezados ---->
                    If dr_Pesos.Count > 0 OrElse dr_Dolares.Count > 0 Then
                        textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """DESGLOSE VALIDADO""0a0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                    End If

                    '--->Imprimiendo los pesos<-------
                    If dr_Pesos.Count > 0 Or dr_Dolares.Count > 0 Then
                        textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """VALIDADOR 1""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
                        textoSalida = """" & strAlineacion & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""@""" 'Resetea valores la @
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        If dr_Pesos.Count > 0 Then
                            For i As Integer = 0 To dr_Pesos.Count - 1
                                strAlineacion = Alinea_Cadenas(dr_Pesos(i)("Clave"), dr_Pesos(i)("Cantidad"), FormatCurrency(dr_Pesos(i)("Importe"), 2))
                                textoSalida = """" & strAlineacion & """0a"
                                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                                piezasPesoV1 += CInt(dr_Pesos(i)("Cantidad")) ' va contando los pesos
                                ImportePesosV1 += CInt(dr_Pesos(i)("Importe"))
                            Next
                            'strAlineacion = Alinea_Cadenas("TOTAL V1: ", ImportePesosV1, 2)
                        End If
                    End If
                    If dr_Dolares.Count > 0 Then
                        'textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        'strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
                        'textoSalida = """" & strAlineacion & """0a"
                        'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        For i As Integer = 0 To dr_Dolares.Count - 1
                            strAlineacion = Alinea_Cadenas(dr_Dolares(i)("Clave"), dr_Dolares(i)("Cantidad"), FormatCurrency(dr_Dolares(i)("Importe"), 2))
                            textoSalida = """" & strAlineacion & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            piezasDolar += CInt(dr_Dolares(i)("Cantidad")) 'Va contando los Dólares
                            ImporteDolar += CInt(dr_Dolares(i)("Importe"))
                        Next

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS MXN V1: " & piezasPesoV1 & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA.
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS USD V1: " & piezasDolar & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN V1: " & FormatCurrency(ImportePesosV1, 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL USD V1: " & FormatCurrency(ImporteDolar, 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)


                    End If
                    If dr_Dolares.Count = 0 And dr_Pesos.Count > 0 Then

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS MXN V1: " & piezasPesoV1 & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN V1: " & FormatCurrency(ImportePesosV1, 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    End If

                    If dr_Pesos2.Count > 0 Or dr_Dolares2.Count > 0 Then

                        textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """VALIDADOR 2""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
                        textoSalida = """" & strAlineacion & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""@""" 'Resetea valores la @
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        If dr_Pesos2.Count > 0 Then
                            For i As Integer = 0 To dr_Pesos2.Count - 1

                                strAlineacion = Alinea_Cadenas(dr_Pesos2(i)("Clave"), dr_Pesos2(i)("Cantidad"), FormatCurrency(dr_Pesos2(i)("Importe"), 2))
                                textoSalida = """" & strAlineacion & """0a"
                                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                                piezasPesoV2 += CInt(dr_Pesos2(i)("Cantidad")) ' va contando los pesos
                                ImportePesosV2 += CInt(dr_Pesos2(i)("Importe"))

                            Next
                            'strAlineacion = Alinea_Cadenas("TOTAL V2: ", ImportePesosV2, 2)
                        End If

                    End If
                    If dr_Dolares2.Count > 0 Then

                        'textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        'strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
                        'textoSalida = """" & strAlineacion & """0a"
                        'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        For i As Integer = 0 To dr_Dolares2.Count - 1

                            strAlineacion = Alinea_Cadenas(dr_Dolares2(i)("Clave"), dr_Dolares2(i)("Cantidad"), FormatCurrency(dr_Dolares2(i)("Importe"), 2))
                            textoSalida = """" & strAlineacion & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            piezasDolar2 += CInt(dr_Dolares2(i)("Cantidad")) 'Va contando los Dólares
                            ImporteDolar2 += CInt(dr_Dolares2(i)("Importe"))
                        Next
                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS MXN V2: " & piezasPesoV2 & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS USD V2: " & piezasDolar2 & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN V2: " & FormatCurrency(ImportePesosV2, 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL USD V2: " & FormatCurrency(ImporteDolar2, 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    End If

                    If dr_Dolares2.Count = 0 And dr_Pesos2.Count > 0 Then

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS MXN V2: " & piezasPesoV2 & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN V2: " & FormatCurrency(ImportePesosV2, 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    End If

                    'textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                    'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    'textoSalida = """" & "PIEZAS MXN: " & piezasPeso & """0a"
                    'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    'textoSalida = """" & "TOTAL MXN: " & FormatCurrency(ImportePesosV1 + ImportePesosV2, 2) & """0a"
                    'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)



                    '--->imprimiendo los dolares<-------




                    '▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀

                    If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Saldo Then
                        '-----------27/09/2016 ESTE IF PARA CONSULTA DE SALDO
                        textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """DESGLOSE MANUAL EFE""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""@""" 'Resetea valores la @
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_ConvertManual"), 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """DESGLOSE MANUAL DOC""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""@""" 'Resetea valores la @
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN " & FormatCurrency(_Recibo.dr_General("Total_MXPDOC"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USDDOC"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_ConvertManualDOC"), 2) & """0a0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                    End If

                Case stc_NPI80mmWinNormal.Tipos_Impresion.Corte_Diario
                    '*******CORTE DIARIO--DESGLOSE DEPOSITOS X USUARIO<-------

                    If varPub.Imprimir_DetalleCD Then
                        textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """DETALLE""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)


                        textoSalida = "1b""a""00" ' ALINEADO A IZQUIERDA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """ '@ = Deposito Manual' ""0a" ' 
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """------------------------------------------------""0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        Dim arroba As String = "@ "

                        For Each row As DataRow In _Recibo.dt_Detalle.Rows

                            If row("Tipo") = 2 Then arroba = "@ - " Else arroba = ""

                            strAlineacion = Alinea_Cadenas(arroba & row("Fecha_Inicio") & " " & row("Hora_Inicio"), FormatCurrency(row("Importe"), 2))
                            textoSalida = """" & strAlineacion & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                            textoSalida = """" & row("Nombre") & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        Next

                        textoSalida = """------------------------------------------------""0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL : " & FormatCurrency(_Recibo.dr_General("Importe_Total"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        '*********************************
                    End If


                    '*******CORTE DIARIO -- DEPOSITOS [AGRUPADOS] X USUARIO<-----------

                    textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """RESUMEN""0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)


                    textoSalida = "1b""a""00" ' ALINEADO A IZQUIERDA
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    strAlineacion = Alinea_Cadenas("NOMBRE", "IMPORTE")
                    textoSalida = """" & strAlineacion & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    Dim CadenaLengh As String = ""
                    For Each row2 As DataRow In _Recibo.dt_DetalleAgrupado.Rows

                        CadenaLengh = row2("Nombre").ToString
                        If CadenaLengh.Length > 20 Then CadenaLengh = CadenaLengh.Substring(0, 20)

                        strAlineacion = Alinea_Cadenas(CadenaLengh, FormatCurrency(row2("Importe"), 2))
                        textoSalida = """" & strAlineacion & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    Next

                    '********************************

                    'Hacer Subconsulta por  moneda (Peso[MXP] Y Dolar[USD])----->
                    Dim piezasPeso As Integer = 0
                    Dim piezasDolar As Integer = 0
                    Dim dr_Pesos() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'MXP' Or Moneda = 'MXN'", "Denominacion")
                    Dim dr_Dolares() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'USD'", "Denominacion")

                    '<----Validar Registros para imprimir Encabezados ---->
                    If dr_Pesos.Count > 0 OrElse dr_Dolares.Count > 0 Then

                        textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """DESGLOSE TOTAL""0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                    End If


                    '--->Imprimiendo los pesos<-------
                    If dr_Pesos.Count > 0 Then
                        textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
                        textoSalida = """" & strAlineacion & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        For i As Integer = 0 To dr_Pesos.Count - 1
                            strAlineacion = Alinea_Cadenas(dr_Pesos(i)("Clave"), dr_Pesos(i)("Cantidad"), FormatCurrency(dr_Pesos(i)("Importe"), 2))
                            textoSalida = """" & strAlineacion & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                            piezasPeso += CInt(dr_Pesos(i)("Cantidad")) ' va contando los pesos
                        Next


                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS MXN: " & piezasPeso & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL MXN: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                    End If

                    '--->imprimiendo los dolares<-------
                    If dr_Dolares.Count > 0 Then

                        textoSalida = "1b""a""00" ' ALINEADO A izquierda
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        strAlineacion = Alinea_Cadenas("DENOMINACION", "CANTIDAD", "IMPORTE")
                        textoSalida = """" & strAlineacion & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        For i As Integer = 0 To dr_Dolares.Count - 1

                            strAlineacion = Alinea_Cadenas(dr_Dolares(i)("Clave"), dr_Dolares(i)("Cantidad"), FormatCurrency(dr_Dolares(i)("Importe"), 2))
                            textoSalida = """" & strAlineacion & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                            piezasDolar += CInt(dr_Dolares(i)("Cantidad")) 'Va contando los Dólares
                        Next


                        textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "PIEZAS USD: " & piezasDolar & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        textoSalida = """" & "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_Convert"), 2) & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                    End If


                Case stc_NPI80mmWinNormal.Tipos_Impresion.Movimientos
                    '----------MOVIMIENTOS------------
                    '---Imprime encabezado de Detalles
                    textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """DETALLE""0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = "1b""a""00" ' ALINEADO A IZQUIERDA
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """FECHA""0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    strAlineacion = Alinea_Cadenas("HORA", "DEPOSITO", "RETIRO")
                    textoSalida = """" & strAlineacion & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """------------------------------------------------""0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    '------Imprime Detalle de Movimientos-------
                    Dim FechaAnterior As Date = Nothing

                    Dim cuentafila As Integer = 0 'Para la paginacion
                    For Each fila As DataRow In _Recibo.dt_Detalle.Rows

                        cuentafila += 1
                        If cuentafila <= varPub.ultFila_DTimpreso Then Continue For

                        If FechaAnterior <> CDate(fila("Fecha").ToString) Then
                            textoSalida = """" & fila("Fecha") & """0a"
                            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                        End If

                        strAlineacion = Alinea_Cadenas(fila("Hora"), FormatCurrency(fila("Deposito"), 2), FormatCurrency(fila("Retiro"), 2))
                        textoSalida = """" & strAlineacion & """0a"
                        ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                        FechaAnterior = CDate(fila("Fecha").ToString)

                    Next
                    textoSalida = "1b""--------------------------------------------------""0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    '---TOTALES-----
                    textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """" & "TOTAL DEPOSITOS: " & FormatCurrency(_Recibo.dr_General("ImporteDepositos"), 2) & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                    textoSalida = """" & "TOTAL RETIROS: " & FormatCurrency(_Recibo.dr_General("ImporteRetiros"), 2) & """0a0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            End Select

            '----Imprime total General de la Operación------------
            If Not _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Movimientos Then
                'textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                'ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = "1b""!""001C""!""001b""E""01"   'IMPRIME EN NEGRITA
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = """TOTALES""0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = "1b""@""" 'Resetea valores la @
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = "1b""a""02" ' ALINEADO A DERECHA
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion Then
                    textoSalida = """" & "IMP MANUAL EFE: " & FormatCurrency(_Recibo.dr_General("Importe_Otros"), 2) & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                End If

                If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion Then
                    textoSalida = """" & "IMP MANUAL DOC: " & FormatCurrency(_Recibo.dr_General("Importe_Otrosd"), 2) & """0a"
                    ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
                End If


                textoSalida = """" & "TOTAL USD CONVERTIDOS: " & FormatCurrency(_Recibo.dr_General("TotalUSD_Convert"), 2) & """0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = """" & "TOTAL MXN: " & FormatCurrency(ImportePesosV1 + ImportePesosV2, 2) & """0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = """" & "GRAN TOTAL: " & FormatCurrency(_Recibo.dr_General("Importe_Total"), 2) & """0a0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = "1b""a""00" ' ALINEADO A IZQUIERDA
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = """" & _Recibo.dr_General("ImporteTotal_Letras") & """0a0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            End If

            '---------------Apartado de Firma----------------------
            If _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Deposito OrElse
            _Recibo.Tipo_Impresion = stc_NPI80mmWinNormal.Tipos_Impresion.Recoleccion Then

                textoSalida = "1b""a""01" ' ALINEADO A CENTRO
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = """____________________________________""0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

                textoSalida = """FIRMA""0a0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)
            End If

            '-----Imprime Fecha y Hora de Impresion y Fin de Ticket-------------

            textoSalida = "1b""a""01" ' ALINEADO A centro
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            textoSalida = """" & "FECHA IMPRESION: " & Format(Now, "dd/MM/yyyy") & " - " & Hora & """0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            If varPub.Reimpresion Then

                textoSalida = """ *ES UNA REIMPRESION DEL TICKET ORIGINAL ""0a"
                ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            End If

            textoSalida = """-------------FIN TICKET-------------""0a"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)


            '-----Si llega hasta aqui.. Entonces ya terminó de imprimir 
            varPub.continuaImprimiendo = False
            varPub.ultFila_DTimpreso = 0
            varPub.Paginacion = 1

            'ˆóŽšŒãˆ—
            ' IMPRIME ALGO QUIEN SABE?
            textoSalida = "1B4A781b69"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            ' IMPRIME FINAL DE IMPRESION?
            textoSalida = "1D""G""10"
            ret = nii.NiiPrint(nombrePrinter, textoSalida, textoSalida.Length, Nothing)

            ' FINALIZA EL DOCUMENTO
            ret = nii.NiiEndDoc(nombrePrinter)

            If varPub.Logo_Empresa IsNot Nothing Then
                'ƒŠƒ\[ƒXŠJ•ú
                ' LIBERA LA VARIABLE DEL GRAFICO
                'g.ReleaseHdc(hdc)
                'g.Dispose()
            End If
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "IMPRIMIR", " ERRROR AL IMPRIMIR EL TICKET. " & ex.Message())
        End Try

    End Sub

    Private Function Alinea_Cadenas(ByVal strLeft As String, ByVal strCenter As String, ByVal strRight As String) As String
        Dim cadFinal As String = ""
        'calculados sobre 48 caracteres IMPRESORA NIPPON

        If strLeft.Trim <> "" AndAlso strCenter.Trim <> "" AndAlso strRight.Trim <> "" Then
            'Alinea a la Izquierda
            If strLeft.Length < 16 Then strLeft = fn_RellenarCadena(strLeft, 16, " ", strPosicion.Derecha)
            If strLeft.Length > 16 Then strLeft = strLeft.Substring(0, 16)

            'Alinea a la Centro 'era izq_derecha
            If strCenter.Length < 16 Then strCenter = fn_RellenarCadena(strCenter, 16, " ", strPosicion.Izquierda)
            If strCenter.Length > 16 Then strCenter = strCenter.Substring(0, 16)

            'Alinea a la Derecha
            If strRight.Length < 16 Then strRight = fn_RellenarCadena(strRight, 16, " ", strPosicion.Izquierda)
            If strRight.Length > 16 Then strRight = strRight.Substring(0, 16)

            cadFinal = strLeft + strCenter + strRight
        End If
        Return cadFinal

    End Function

    Private Function Alinea_Cadenas(ByVal strLeft As String, ByVal strRight As String) As String
        Dim cadFinal As String = ""
        'calculados sobre 48 caracteres IMPRESORA NIPPON

        If strLeft.Trim <> "" AndAlso strRight.Trim <> "" Then

            'Alinea a la Izquierda
            If strLeft.Length < 24 Then strLeft = fn_RellenarCadena(strLeft, 24, " ", strPosicion.Derecha)
            If strLeft.Length > 24 Then strLeft = strLeft.Substring(0, 24)

            'Alinea a la Derecha
            If strRight.Length < 24 Then strRight = fn_RellenarCadena(strRight, 24, " ", strPosicion.Izquierda)
            If strRight.Length > 24 Then strRight = strRight.Substring(0, 24)

            cadFinal = strLeft + strRight

        End If
        Return cadFinal

    End Function

    Private Function Alinea_Cadenas(ByVal strCenter As String) As String
        Dim cadFinal As String = ""
        'calculados sobre 48 caracteres IMPRESORA NIPPON

        If strCenter.Trim <> "" Then
            'Alinea al centro
            If strCenter.Length < 48 Then strCenter = fn_RellenarCadena(strCenter, 48, " ", strPosicion.Izq_Der)
            If strCenter.Length > 48 Then strCenter = strCenter.Substring(0, 48)
        End If
        Return cadFinal

    End Function

    Private Sub CrearImagen(ByRef G As System.Drawing.Graphics, ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, _
                    ByVal H As Integer)

        Dim newImage As Image = cls_FuncionesPublicas.fn_ByteArrayToImage(varPub.Logo_Empresa)
        Dim srcRect As New Rectangle(X, Y, W, H)
        G = Graphics.FromImage(newImage) 'crear un objeto Graphics a partir de un objeto Image
        G.PageUnit = GraphicsUnit.Millimeter
        G.DrawImage(newImage, srcRect)
    End Sub

End Class
