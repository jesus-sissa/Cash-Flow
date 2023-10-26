
Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

''' <summary>
''' Estructura del Recibo de 58mm Windows Normal
''' </summary>
''' <remarks></remarks>
Public Structure stc_58mmWinNormal

#Region "Variables Privadas"

    Private _dr_General As DataRow
    Private _dt_Detalle As DataTable
    Private _dt_Desglose As DataTable
    Private _dt_Desglose2 As DataTable
    Private _dt_DetalleAg As DataTable
    Private _Ventana As Integer
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
            _Ventana = value
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

''' <summary>
''' Generación de la Impresión 58mm (Windows Normal)
''' </summary>
''' <remarks></remarks>
Public Class cls_Ticket58mmWinNormal
#Region "Variables Privadas"

    Private WithEvents _Documento As Printing.PrintDocument
    Private _Recibo As stc_58mmWinNormal
    Private _Margen As Integer = 0
    Private _Fuente As Integer = 9

#End Region

    Public Sub New(ByVal Recibo As stc_58mmWinNormal)
        _Recibo = Recibo
        _Documento = New Printing.PrintDocument
    End Sub

    ''' <summary>
    ''' Función que Manda a Imprimir un Archivo
    ''' </summary>
    ''' <param name="Recibo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Imprimir(ByVal Recibo As stc_58mmWinNormal) As Boolean
        Dim Impr_Doc As cls_Ticket58mmWinNormal = New cls_Ticket58mmWinNormal(Recibo)
        If Not Impr_Doc.ValidarImpresora() Then Return False
        Impr_Doc._Documento.DefaultPageSettings = New Printing.PageSettings With {.Landscape = False}

        Try
            Impr_Doc._Documento.Print()
            Return True
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "", "Error IMPRIMIR: " & ex.Message)
            Call fn_MsgBox(" error al realizar la Impresión del Ticket.", MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Revisar si la Impresora es la Apropiada
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidarImpresora() As Boolean
        Dim ResolucionMax As Integer = (From p As Printing.PrinterResolution In _Documento.PrinterSettings.PrinterResolutions Where p.Y > 0 Order By p.Y Descending Select p.Y).FirstOrDefault
        Return True

        'If ResolucionMax > 200 Then
        '    Select Case MsgBox("La impresora " & _Documento.PrinterSettings.PrinterName & " parece no ser la indicada para la impresión de Tickets. Desea continuar?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Exclamation, "IMPRESORA")
        '        Case MsgBoxResult.Yes
        '            Return True
        '        Case MsgBoxResult.No
        '            Dim print As New PrintDialog With {.Document = _Documento}
        '            If print.ShowDialog = DialogResult.Cancel Then
        '                Return False
        '            Else
        '                Return True
        '            End If
        '        Case MsgBoxResult.Cancel
        '            Return False
        '    End Select
        'Else
        '    Return True
        'End If
    End Function

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles _Documento.PrintPage
        '--------Para hacer el calculo de lo que imprimirá en la 1ra Hoja------
        Dim printFont As Font
        Dim LineasporPagina As Integer = 0
        printFont = New Font("Arial", 8) 'le puse 8 porque esta entre 6,7,8-9
        LineasporPagina = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)
        Dim contadorLineas As Integer = 0
        If LineasporPagina > 60 Then LineasporPagina = 60


        '-------Esta IMpresion es de  58mm (Windows Normal)
        e.HasMorePages = False
        varPub.SegundosSesion = 0
        Dim y As Integer = 6 '10
        Dim x As Integer = varPub.MargenIzq ' 0 para la de 58mm
        Dim ancho As Integer = 48

        Dim alto As Integer = 3 'modificar estos altos ya que la fuente es mas pequeña
        Dim altoDoble As Integer = 6
        Dim TituloTicket As String = ""
        Dim TituloDeposito As String = ""

        If varPub.Nombre_Sucursal.Length > 24 Then
            alto = altoDoble
        Else
            alto = alto
        End If

        If varPub.continuaImprimiendo = False Then

            'pendiente coordenadas y fuentes
            If varPub.Logo_Empresa IsNot Nothing Then
                CrearImagen(e.Graphics, x + 15, y, 20, 20) 'Imprime Logo
                y += 21
            End If

            CrearLinea(e.Graphics, 8, varPub.Nombre_Sucursal, x, y, ancho, alto, StringAlignment.Center, FontStyle.Bold)
            contadorLineas += 1 '--cuenta las lineas
            y += alto

            If varPub.Direccion.Length > 34 Then
                alto = altoDoble '8
            Else
                alto = alto '4
            End If

            CrearLinea(e.Graphics, 6, varPub.Direccion.ToUpper, x, y, ancho, alto, StringAlignment.Center, FontStyle.Bold)
            contadorLineas += 1 '--cuenta las lineas

            y += alto
            CrearLinea(e.Graphics, 6, "Tel: " & varPub.Telefono.ToUpper, x, y, ancho, 4, StringAlignment.Center, FontStyle.Bold)
            contadorLineas += 1 '--cuenta las lineas

        End If ' fin de continuar imprimiendo

        y += 4
        TituloTicket = [Enum].GetName(GetType(stc_58mmWinNormal.Tipos_Impresion), _Recibo.Tipo_Impresion).ToUpper

        Select Case TituloTicket
            Case "CORTE_DIARIO"
                TituloTicket = "CORTE DIARIO"
            Case "DEPOSITO"
                If _Recibo.dr_General("Tipo") = 2 Then
                    TituloTicket = "DEPOSITO MANUAL"
                Else
                    TituloTicket = "DEPOSITO VALIDADO"
                End If
        End Select

        CrearLinea(e.Graphics, 8, TituloTicket, x, y + 1, ancho, 4, StringAlignment.Center, FontStyle.Bold)
        contadorLineas += 1 '--cuenta las lineas

        If TituloTicket = "CORTE_DIARIO" Then
            y += 4
            Dim Subtitulo As String = "[DESDE ULTIMA RECOLECCION]"
            If varPub.Tipo_CorteDiario = 2 Then
                Subtitulo = "[DIA ACTUAL]"
            ElseIf varPub.Tipo_CorteDiario = 3 Then
                Subtitulo = "[DIA ACTUAL COMPLETO]"
            End If
            CrearLinea(e.Graphics, 6, Subtitulo, x, y, ancho, 4, StringAlignment.Center, FontStyle.Bold)
            contadorLineas += 1 '--cuenta las lineas
        End If

        Select Case _Recibo.Tipo_Impresion

            Case stc_58mmWinNormal.Tipos_Impresion.Movimientos
                y += 4 : CrearLinea(e.Graphics, 8, "FECHA INICIO:", x, y, ancho - 26, 6, StringAlignment.Far)
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("FechaInicio"), x + 22, y, ancho, 6, StringAlignment.Near)
                contadorLineas += 1 '--cuenta las lineas
                y += 3 : CrearLinea(e.Graphics, 8, "FECHA FIN:", x, y, ancho - 26, 6, StringAlignment.Far)
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("FechaFin"), x + 22, y, ancho, 6, StringAlignment.Near)
                contadorLineas += 1 '--cuenta las lineas

            Case stc_58mmWinNormal.Tipos_Impresion.Corte_Diario
                y += 4 : CrearLinea(e.Graphics, 8, "FECHA:", x, y, ancho - 34, 6, StringAlignment.Far)
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Fecha") & " - " & _Recibo.dr_General("Hora"), x + 14, y, ancho, 6, StringAlignment.Near)
                contadorLineas += 1 '--cuenta las lineas

            Case stc_58mmWinNormal.Tipos_Impresion.Deposito 'COnsulta Deposito
                y += 4 : CrearLinea(e.Graphics, 8, "FOLIO:", x, y, ancho - 34, 3, StringAlignment.Far)
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Folio"), x + 14, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)

                'Si es tipo=1(validado)
                If _Recibo.dr_General("Tipo") = 1 Then
                    y += 3 : CrearLinea(e.Graphics, 8, "INICIO:", x, y, ancho - 34, 3, StringAlignment.Far)
                    CrearLinea(e.Graphics, 8, _Recibo.dr_General("Fecha_Inicio") & " - " & _Recibo.dr_General("Hora_Inicio"), x + 14, y, ancho, 3, StringAlignment.Near)
                    y += 3 : CrearLinea(e.Graphics, 8, "FIN:", x, y, ancho - 34, 3, StringAlignment.Far)
                    CrearLinea(e.Graphics, 8, _Recibo.dr_General("Fecha_Fin") & " - " & _Recibo.dr_General("Hora_Fin"), x + 14, y, ancho, 3, StringAlignment.Near)
                Else
                    y += 3 : CrearLinea(e.Graphics, 8, "FECHA:", x, y, ancho - 34, 3, StringAlignment.Far)
                    CrearLinea(e.Graphics, 8, _Recibo.dr_General("Fecha_Inicio") & " - " & _Recibo.dr_General("Hora_Inicio"), x + 14, y, ancho, 3, StringAlignment.Near)
                End If
                contadorLineas += 1 '--cuenta las lineas

            Case stc_58mmWinNormal.Tipos_Impresion.Saldo ' COnsulta de Saldos
                y += 6 : CrearLinea(e.Graphics, 8, "FECHA:", x, y, ancho - 34, 3, StringAlignment.Far) '34 -- 14
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Fecha") & " - " & _Recibo.dr_General("Hora"), x + 14, y, ancho, 3, StringAlignment.Near)

            Case stc_58mmWinNormal.Tipos_Impresion.Recoleccion 'COnsulta Retiros

                y += 4 : CrearLinea(e.Graphics, 8, "FOLIO:", x, y, ancho - 28, 3, StringAlignment.Far)
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Folio"), x + 20, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                y += 3 : CrearLinea(e.Graphics, 8, "REMISION:", x, y, ancho - 28, 3, StringAlignment.Far) '-----------
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Remision"), x + 20, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                y += 3 : CrearLinea(e.Graphics, 8, "ENVASE:", x, y, ancho - 28, 6, StringAlignment.Far) '-----------
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Envase"), x + 20, y, ancho, 3, StringAlignment.Near)
                y += 3 : CrearLinea(e.Graphics, 8, "FECHA:", x, y, ancho - 34, 3, StringAlignment.Far)
                CrearLinea(e.Graphics, 8, _Recibo.dr_General("Fecha") & " - " & _Recibo.dr_General("Hora"), x + 14, y, ancho, 3, StringAlignment.Near)

        End Select

        '(Near=cerca(Izquierda), Far = lejos(derecha),  center=centro)

        Select Case _Recibo.Tipo_Impresion
            Case stc_58mmWinNormal.Tipos_Impresion.Deposito, stc_58mmWinNormal.Tipos_Impresion.Saldo, stc_58mmWinNormal.Tipos_Impresion.Recoleccion

                '====== IMPRIME EL NOMBRE DEL CAJERO ============
                If (_Recibo.dr_General("Nombre_Usuario").ToString).Length > 16 Then
                    alto = altoDoble
                Else
                    alto = alto
                End If

                y += 3

                CrearLinea(e.Graphics, 8, "CAJERO: " & _Recibo.dr_General("Nombre_Usuario"), x, y, ancho, alto, StringAlignment.Near)
                If (_Recibo.dr_General("Nombre_Usuario").ToString).Length >= 25 Then y += 4 '------25/03/2013
                contadorLineas += 1 '--cuenta las lineas


                If _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito Then
                    y += 3
                    CrearLinea(e.Graphics, 8, "CAJA: " & _Recibo.dr_General("Clave_Caja"), x, y, ancho, alto, StringAlignment.Near)
                    contadorLineas += 1 '--cuenta las lineas
                End If
                

                '================================================

                '▄▄▄▄▄▄▄▄▄▄▄06/11/2015 solo imprimir esto cuando sea RETIROS▄▄▄▄▄
                If _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Recoleccion Then
                    'Imprimir los datos agrupados de los depositos
                    y += 4
                    CrearLinea(e.Graphics, 6, "DETALLE", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    contadorLineas += 1 '--cuenta las lineas

                    y += 3
                    CrearLinea(e.Graphics, 6, "---------------------------------------------------------------", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                    contadorLineas += 1 '--cuenta las lineas

                    Dim cuentafila As Integer = 0 'Para la paginacion
                    For Each row2 As DataRow In _Recibo.dt_DetalleAgrupado.Rows
                        cuentafila += 1
                        If cuentafila <= varPub.ultFila_DTimpreso Then Continue For

                        y += 3
                        CrearLinea(e.Graphics, 7, row2("Fecha"), x, y, ancho, 3, StringAlignment.Near)
                        CrearLinea(e.Graphics, 7, FormatCurrency(row2("Importe"), 2), x, y, ancho, 3, StringAlignment.Far)
                        contadorLineas += 1 '--cuenta las lineas.

                        If contadorLineas >= LineasporPagina Then '<-----12/02/2015
                            varPub.ultFila_DTimpreso = cuentafila 'Guardamos la ultima fila impresa
                            y += 4 : CrearLinea(e.Graphics, 7, "Pagina " & varPub.Paginacion, x, y, ancho, 4, StringAlignment.Center, FontStyle.Bold)
                            y += 4 : CrearLinea(e.Graphics, 7, "------ ", x, y, ancho, 4, StringAlignment.Center, FontStyle.Regular)
                            varPub.Paginacion += 1
                            varPub.continuaImprimiendo = True
                            GoTo ContinuarPagina
                        End If

                    Next
                    y += 3
                    CrearLinea(e.Graphics, 6, "---------------------------------------------------------------", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                End If
                '▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄

                '══════SI ES DEPOSITO MANUAL(BUZON=2)═══════════════
                If _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito Then
                    If _Recibo.dr_General("Tipo") = 2 Then
                        y += 6
                        CrearLinea(e.Graphics, 7, "TOTAL MXN: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2), x, y, ancho, 4, StringAlignment.Far, FontStyle.Bold)
                        y += 3
                        CrearLinea(e.Graphics, 7, "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2), x, y, ancho, 4, StringAlignment.Far, FontStyle.Bold)
                        y += 3
                        CrearLinea(e.Graphics, 7, "TIPO DE CAMBIO: " & FormatCurrency(_Recibo.dr_General("TipoCambio_USD"), 2), x, y, ancho, 4, StringAlignment.Far, FontStyle.Bold)
                        y += 3
                        CrearLinea(e.Graphics, 7, "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_Convert"), 2), x, y, ancho, 4, StringAlignment.Far, FontStyle.Bold)
                        Exit Select
                    End If

                End If
                '════════════════════════════════════════════════════


                '▀▀▀▀▀▀▀▀▀▀▀▀▀▀DESGLOSE (DEPOSITOS / RETIROS / SALDO)▀▀▀▀▀▀▀▀▀▀▀
                '<-----Hacer Subconsulta por  moneda (Peso[MXP/MXN] Y Dolar[USD])----->
                Dim piezasPeso As Integer = 0
                Dim piezasDolar As Integer = 0
                Dim ImportePesos As Decimal = 0D
                Dim ImporteDolar As Decimal = 0D
                Dim dr_Pesos() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'MXP' Or Moneda = 'MXN'")
                Dim dr_Dolares() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'USD'")

                '<----Validar Registros para imprimir Encabezados ---->
                If dr_Pesos.Count > 0 OrElse dr_Dolares.Count > 0 Then
                    y += 4
                    CrearLinea(e.Graphics, 8, "DESGLOSE VALIDADO", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)

                    y += 3
                    CrearLinea(e.Graphics, 8, "DENOM", x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "CANT", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "IMPORTE", x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                End If

                '--->Imprimiendo los pesos<-------
                If dr_Pesos.Count > 0 Then
                    For i As Integer = 0 To dr_Pesos.Count - 1
                        y += 3
                        CrearLinea(e.Graphics, 7, dr_Pesos(i)("Clave"), x, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, dr_Pesos(i)("Cantidad"), x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, FormatCurrency(dr_Pesos(i)("Importe"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Regular)
                        piezasPeso += CInt(dr_Pesos(i)("Cantidad")) ' va contando los pesos
                        ImportePesos += CInt(dr_Pesos(i)("Importe"))
                    Next

                    y += 3 : CrearLinea(e.Graphics, 7, "PIEZAS MXN: " & piezasPeso, x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    ' la siguiente cantidad sera calculado OK 27/096/2016
                    CrearLinea(e.Graphics, 7, "TOTAL MXN: " & FormatCurrency(ImportePesos, 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                End If

                '--->imprimiendo los dolares<-------
                If dr_Dolares.Count > 0 Then
                    y += 5
                    CrearLinea(e.Graphics, 8, "DENOM", x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "CANT", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "IMPORTE", x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    For i As Integer = 0 To dr_Dolares.Count - 1
                        y += 3
                        CrearLinea(e.Graphics, 7, dr_Dolares(i)("Clave"), x, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, dr_Dolares(i)("Cantidad"), x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, FormatCurrency(dr_Dolares(i)("Importe"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Regular)
                        piezasDolar += CInt(dr_Dolares(i)("Cantidad")) 'Va contando los Dólares
                        ImporteDolar += CInt(dr_Dolares(i)("Importe"))
                    Next
                    y += 3 : CrearLinea(e.Graphics, 7, "PIEZAS USD: " & piezasDolar, x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    ' la siguiente cantidad sera calculado OK 27/096/2016
                    CrearLinea(e.Graphics, 7, "TOTAL USD: " & FormatCurrency(ImporteDolar, 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_Convert"), 2), x, y, ancho, 6, StringAlignment.Far, FontStyle.Bold)

                End If
                '▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀

                If _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Saldo Then
                    '-----------27/09/2016 ESTE IF PARA CONSULTA DE SALDO
                    y += 4
                    CrearLinea(e.Graphics, 8, "DESGLOSE MANUAL", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "TOTAL MXN: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_ConvertManual"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                End If


            Case stc_58mmWinNormal.Tipos_Impresion.Corte_Diario
                '---------------CORTE DIARIO--DESGLOSE DEPOSITOS X USUARIO

                If varPub.Imprimir_DetalleCD Then
                    y += 4
                    CrearLinea(e.Graphics, 8, "DETALLE", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "@ = Deposito Manual", x, y, ancho, 5, StringAlignment.Near, FontStyle.Bold)
                    contadorLineas += 2 '--cuenta las lineas

                    y += 3 'nuevo
                    CrearLinea(e.Graphics, 6, "---------------------------------------------------------------", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                    contadorLineas += 1 '--cuenta las lineas

                    Dim cuentafila As Integer = 0 'Para la paginacion
                    Dim arroba As String = "@ "
                    For Each row As DataRow In _Recibo.dt_Detalle.Rows
                        cuentafila += 1
                        If cuentafila <= varPub.ultFila_DTimpreso Then Continue For

                        y += 2
                        If row("Tipo") = 2 Then arroba = "@ - " Else arroba = ""

                        CrearLinea(e.Graphics, 7, arroba & row("Fecha_Inicio") & " " & row("Hora_Inicio"), x, y, ancho, 3, StringAlignment.Near)
                        CrearLinea(e.Graphics, 7, FormatCurrency(row("Importe"), 2), x, y, ancho, 3, StringAlignment.Far)
                        contadorLineas += 1 '--cuenta las lineas
                        y += 3
                        CrearLinea(e.Graphics, 7, row("Nombre"), x, y, ancho, 3, StringAlignment.Near)
                        contadorLineas += 1 '--cuenta las lineas

                        If contadorLineas >= LineasporPagina Then '<-----12/02/2015
                            varPub.ultFila_DTimpreso = cuentafila 'Guardamos la ultima fila impresa
                            y += 4 : CrearLinea(e.Graphics, 6, "Pagina " & varPub.Paginacion, x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                            y += 4 : CrearLinea(e.Graphics, 6, "------ ", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                            varPub.Paginacion += 1
                            varPub.continuaImprimiendo = True
                            GoTo ContinuarPagina
                        End If

                        y += 3
                    Next
                    CrearLinea(e.Graphics, 6, "---------------------------------------------------------------", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                    y += 3
                    CrearLinea(e.Graphics, 8, "TOTAL: " & FormatCurrency(_Recibo.dr_General("Importe_Total"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    '*********************************
                End If

                '*******CORTE DIARIO -- DEPOSITOS [AGRUPADOS] X USUARIO<-----------
                y += 4
                CrearLinea(e.Graphics, 8, "RESUMEN", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                y += 4
                CrearLinea(e.Graphics, 7, "NOMBRE", x, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                CrearLinea(e.Graphics, 7, "IMPORTE", x, y, ancho, 3, StringAlignment.Far, FontStyle.Regular)

                Dim CadenaLengh As String = ""
                For Each row2 As DataRow In _Recibo.dt_DetalleAgrupado.Rows
                    y += 4
                    CadenaLengh = row2("Nombre").ToString
                    If CadenaLengh.Length > 18 Then CadenaLengh = CadenaLengh.Substring(0, 18)
                    CrearLinea(e.Graphics, 7, CadenaLengh, x, y, ancho, 3, StringAlignment.Near)
                    CrearLinea(e.Graphics, 7, FormatCurrency(row2("Importe"), 2), x, y, ancho, 3, StringAlignment.Far)
                Next
                y += 2
                '********************************

                'Hacer Subconsulta por  moneda (Peso[MXP] Y Dolar[USD])----->
                Dim piezasPeso As Integer = 0
                Dim piezasDolar As Integer = 0
                Dim dr_Pesos() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'MXP' Or Moneda = 'MXN'")
                Dim dr_Dolares() As DataRow = _Recibo.dt_Desglose.Select("Moneda = 'USD'")

                '<----Validar Registros para imprimir Encabezados ---->
                If dr_Pesos.Count > 0 OrElse dr_Dolares.Count > 0 Then
                    y += 4
                    CrearLinea(e.Graphics, 8, "DESGLOSE TOTAL", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    y += 4
                    CrearLinea(e.Graphics, 8, "DENOM", x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "CANT", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "IMPORTE", x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)

                End If

                '--->Imprimiendo los pesos<-------
                If dr_Pesos.Count > 0 Then
                    For i As Integer = 0 To dr_Pesos.Count - 1
                        y += 4
                        CrearLinea(e.Graphics, 7, dr_Pesos(i)("Clave"), x, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, dr_Pesos(i)("Cantidad"), x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, FormatCurrency(dr_Pesos(i)("Importe"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Regular)
                        piezasPeso += CInt(dr_Pesos(i)("Cantidad")) ' va contando los pesos
                    Next

                    y += 4 : CrearLinea(e.Graphics, 7, "PIEZAS MXN: " & piezasPeso, x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 4 : CrearLinea(e.Graphics, 7, "TOTAL MXN: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                End If

                '--->imprimiendo los dolares<-------
                If dr_Dolares.Count > 0 Then
                    y += 4
                    CrearLinea(e.Graphics, 8, "DENOM", x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "CANT", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                    CrearLinea(e.Graphics, 8, "IMPORTE", x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    For i As Integer = 0 To dr_Dolares.Count - 1
                        y += 4
                        CrearLinea(e.Graphics, 7, dr_Dolares(i)("Clave"), x, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, dr_Dolares(i)("Cantidad"), x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                        CrearLinea(e.Graphics, 7, FormatCurrency(dr_Dolares(i)("Importe"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Regular)
                        piezasDolar += CInt(dr_Dolares(i)("Cantidad")) 'Va contando los Dólares
                    Next
                    y += 4
                    CrearLinea(e.Graphics, 7, "PIEZAS USD: " & piezasDolar, x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                    y += 3
                    CrearLinea(e.Graphics, 7, "USD CONVERTIDO: " & FormatCurrency(_Recibo.dr_General("TotalUSD_Convert"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                End If

            Case stc_58mmWinNormal.Tipos_Impresion.Movimientos
                '---------------MOVIMIENTOS---------
                y += 4
                CrearLinea(e.Graphics, 8, "DETALLE", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                contadorLineas += 1 '--cuenta las lineas
                y += 4 'nuevo

                CrearLinea(e.Graphics, 7, "FECHA", x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                contadorLineas += 1 '--cuenta las lineas

                y += 3
                CrearLinea(e.Graphics, 7, "HORA", x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                CrearLinea(e.Graphics, 7, "DEPOSITO", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                CrearLinea(e.Graphics, 7, "RETIRO", x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                contadorLineas += 1 '--cuenta las lineas
                y += 3

                CrearLinea(e.Graphics, 6, "---------------------------------------------------------------", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)
                contadorLineas += 1 '--cuenta las lineas

                Dim FechaAnterior As Date = Nothing
                y += 3

                Dim cuentafila As Integer = 0 'Para la paginacion
                For Each fila As DataRow In _Recibo.dt_Detalle.Rows

                    cuentafila += 1
                    If cuentafila <= varPub.ultFila_DTimpreso Then Continue For

                    If FechaAnterior <> CDate(fila("Fecha").ToString) Then
                        CrearLinea(e.Graphics, 7, fila("Fecha"), x, y, ancho, 3, StringAlignment.Near, FontStyle.Bold)
                        y += 3
                    End If
                    contadorLineas += 1 '--cuenta las lineas
                    CrearLinea(e.Graphics, 7, fila("Hora"), x, y, ancho, 3, StringAlignment.Near)
                    CrearLinea(e.Graphics, 7, FormatCurrency(fila("Deposito"), 2), 22, y, 15, 3, StringAlignment.Far)
                    CrearLinea(e.Graphics, 7, FormatCurrency(fila("Retiro"), 2), x, y, ancho, 3, StringAlignment.Far)
                    FechaAnterior = CDate(fila("Fecha").ToString)

                    If contadorLineas >= LineasporPagina Then
                        varPub.ultFila_DTimpreso = cuentafila 'Guardamos la ultima fila impresa
                        y += 4 : CrearLinea(e.Graphics, 6, "Pagina " & varPub.Paginacion, x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
                        y += 4 : CrearLinea(e.Graphics, 6, "------ ", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)

                        varPub.Paginacion += 1
                        varPub.continuaImprimiendo = True
                        GoTo ContinuarPagina
                    End If
                    y += 3
                Next
                contadorLineas += 1 '--cuenta las lineas
                CrearLinea(e.Graphics, 6, "---------------------------------------------------------------", x, y, ancho, 3, StringAlignment.Center, FontStyle.Regular)

                '---------------->
                contadorLineas += 1 '--cuenta las lineas
                y += 4 : CrearLinea(e.Graphics, 7, "TOTAL DEPOSITOS: " & FormatCurrency(_Recibo.dr_General("ImporteDepositos"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
                contadorLineas += 1 '--cuenta las lineas
                y += 4 : CrearLinea(e.Graphics, 7, "TOTAL RETIROS: " & FormatCurrency(_Recibo.dr_General("ImporteRetiros"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)

        End Select

        '----Imprime total General de la Operación
        If Not _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Movimientos Then
            If _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Recoleccion Then
                y += 3 : CrearLinea(e.Graphics, 8, "IMPORTE MANUAL: " & FormatCurrency(_Recibo.dr_General("Importe_Otros"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
            End If
            y += 4 : CrearLinea(e.Graphics, 8, "IMPORTE TOTAL: " & FormatCurrency(_Recibo.dr_General("Importe_Total"), 2), x, y, ancho, 3, StringAlignment.Far, FontStyle.Bold)
            y += 4 : CrearLinea(e.Graphics, 6, _Recibo.dr_General("ImporteTotal_Letras"), x, y, ancho, 8, StringAlignment.Near, FontStyle.Bold)
        End If

        '---------------Apartado de Firma
        If _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Deposito OrElse _
        _Recibo.Tipo_Impresion = stc_58mmWinNormal.Tipos_Impresion.Recoleccion Then
            y += 10 : CrearLinea(e.Graphics, 6, "______________________________________", x, y, ancho, 4, StringAlignment.Center)
            y += 3 : CrearLinea(e.Graphics, 6, "FIRMA", x, y, ancho, 3, StringAlignment.Center)
            y += 4
        Else
            If TituloTicket = "SALDO" OrElse TituloTicket = "CORTE DIARIO" Then y += 4
            y += 6
        End If

        '-----Imprime Fecha de Impresion y fin ticket
        CrearLinea(e.Graphics, 6, "FECHA IMPRESION: " & Format(Now, "dd/MM/yyyy") & " - " & Hora, x, y, ancho + 4, 3, StringAlignment.Near)

        If varPub.Reimpresion Then
            y += 3 : CrearLinea(e.Graphics, 5, "* ESTA ES UNA REIMPRESION DEL TICKET ORIGINAL", x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
            ' y += 4
        End If
        y += 3 : CrearLinea(e.Graphics, 6, "-------------FIN TICKET-------------", x, y, ancho, 3, StringAlignment.Center)

        If varPub.Paginacion > 1 Then
            y += 4 : CrearLinea(e.Graphics, 6, "Pagina " & varPub.Paginacion, x, y, ancho, 3, StringAlignment.Center, FontStyle.Bold)
        End If

        y += 4 : CrearLinea(e.Graphics, 6, "------", x, y, ancho, 3, StringAlignment.Center)
        For i As Byte = 1 To varPub.Num_LineasBlanco
            y += 4 : CrearLinea(e.Graphics, 6, "     ", x, y, ancho, 6, StringAlignment.Center)
        Next
        y += 2 : CrearLinea(e.Graphics, 6, "--", x, y, ancho, 3, StringAlignment.Center)

        '-----Si llega hasta aqui.. Entonces ya terminó de imprimir 
        varPub.continuaImprimiendo = False
        varPub.ultFila_DTimpreso = 0
        varPub.Paginacion = 1

ContinuarPagina:
    End Sub


    Private Sub CrearLinea(ByRef G As System.Drawing.Graphics, ByVal FontSize As Integer, ByVal Texto As String, _
                        ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer, _
                        Optional ByVal Alineacion As Drawing.StringAlignment = StringAlignment.Near, _
                        Optional ByVal Estilo As System.Drawing.FontStyle = FontStyle.Regular)
        Dim Font As New Font("Arial", FontSize, Estilo)
        Dim Sf As New Drawing.StringFormat
        Dim R As New Rectangle(X, Y + _Margen, W, H)
        Sf.Alignment = Alineacion

        G.PageUnit = GraphicsUnit.Millimeter
        G.DrawString(Texto, Font, Brushes.Black, R, Sf)
    End Sub

    Private Sub CrearImagen(ByRef G As System.Drawing.Graphics, ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, _
                       ByVal H As Integer)
        'Dim newImage As Image = Image.FromFile("LogoSISSA.jpg")
        Dim newImage As Image = fn_ByteArrayToImage(varPub.Logo_Empresa)
        Dim srcRect As New Rectangle(X, Y, W, H)

        G.PageUnit = GraphicsUnit.Millimeter
        G.DrawImage(newImage, srcRect)
    End Sub

End Class
