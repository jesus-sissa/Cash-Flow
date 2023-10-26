
Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

''' <summary>
''' Estructura del Recibo de 58mm Windows Embebido
''' </summary>
''' <remarks></remarks>
Public Structure stc_58mmWinEmbbd

#Region "Variables Privadas"

    Private _dr_General As DataRow
    Private _dt_Detalle As DataTable
    Private _dt_Desglose As DataTable
    Private _dt_Desglose2 As DataTable
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
''' Generación de la Impresión 58mm (Windows Embebido)
''' </summary>
''' <remarks></remarks>
Public Class cls_Ticket58mmWinEmbbd

#Region "Variables Privadas"

    Private WithEvents _Documento As Printing.PrintDocument

    Private _Recibo As stc_58mmWinEmbbd
    Private _Margen As Integer = 0
    Private _Fuente As Integer = 9

#End Region

    Public Sub New(ByVal Recibo As stc_58mmWinEmbbd)
        _Recibo = Recibo
        _Documento = New Printing.PrintDocument
    End Sub

    ''' <summary>
    ''' Función que Manda a Imprimir un Archivo
    ''' </summary>
    ''' <param name="Recibo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Imprimir(ByVal Recibo As stc_58mmWinEmbbd) As Boolean

        Dim Impr_Doc As cls_Ticket58mmWinEmbbd = New cls_Ticket58mmWinEmbbd(Recibo)

        If Not Impr_Doc.ValidarImpresora() Then Return False
        Impr_Doc._Documento.DefaultPageSettings = New Printing.PageSettings With {.Landscape = False}
        Try
            'Dim prtPrev As New PrintPreviewDialog 'estas 3 lineas Imprimen en VistaPrevia
            'prtPrev.Document = yo._Documento
            'prtPrev.ShowDialog()

            Impr_Doc._Documento.Print()
            ' llama(pd_PrintPage)
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

        If ResolucionMax > 200 Then
            Select Case MsgBox("La impresora " & _Documento.PrinterSettings.PrinterName & " parece no ser la indicada para las remisiones. Desea continuar?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Exclamation, "IMPRESORA")
                Case MsgBoxResult.Yes
                    Return True
                Case MsgBoxResult.No
                    Dim print As New PrintDialog With {.Document = _Documento}
                    '
                    If print.ShowDialog = DialogResult.Cancel Then
                        Return False
                    Else
                        Return True
                    End If
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        Else
            Return True
        End If
     Return False
    End Function

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles _Documento.PrintPage
        ' Esta IMpresion es de  58mm (Windows Embebido)
        e.HasMorePages = False

        varPub.SegundosSesion = 0
        Dim y As Integer = 6 '10
        Dim x As Integer = varPub.MargenIzq ' 0 para la de 58mm
        'probado con Impresora de 56mm CUSTOM TG02

        Dim ancho As Integer = 47 '48
        Dim alto As Integer = 4
        Dim altoDoble As Integer = 8

        If varPub.Cliente.Length > 24 Then
            alto = altoDoble
        Else
            alto = alto
        End If

        y += 4

        CrearLinea(e.Graphics, 8, varPub.Nombre_Sucursal, x, y, ancho, alto, StringAlignment.Center, FontStyle.Bold)

        If varPub.Direccion.Length > 24 Then
            alto = altoDoble
        Else
            alto = alto
        End If

        y += alto
        CrearLinea(e.Graphics, 8, varPub.Direccion.ToUpper, x, y, ancho, alto, StringAlignment.Center, FontStyle.Bold)

        y += alto
        CrearLinea(e.Graphics, 8, Ordena_Cadenas("Tel: " & varPub.Telefono.ToUpper, "", ""), x, y, ancho, 4)

        y += 6
        Dim TituloTicket As String = [Enum].GetName(GetType(stc_58mmWinEmbbd.Tipos_Impresion), _Recibo.Tipo_Impresion).ToUpper
        If TituloTicket = "CORTE_DIARIO" Then TituloTicket = "CORTE DIARIO"

        CrearLinea(e.Graphics, 8, Ordena_Cadenas(TituloTicket, "", ""), x, y, ancho, 4)

        Select Case _Recibo.Tipo_Impresion

            Case stc_58mmWinEmbbd.Tipos_Impresion.Movimientos 'CONSULTA MOVIMIENTOS
                y += 6 : CrearLinea(e.Graphics, 8, "FECHA INICIO:" & _Recibo.dr_General("FechaInicio"), x, y, ancho, 4, StringAlignment.Near)
                y += 4 : CrearLinea(e.Graphics, 8, "FECHA FIN:" & _Recibo.dr_General("FechaFin"), x, y, ancho, 4, StringAlignment.Near)

            Case stc_58mmWinEmbbd.Tipos_Impresion.Corte_Diario 'CORTE DIARIO
                y += 6 : CrearLinea(e.Graphics, 8, "FECHA: " & _Recibo.dr_General("Fecha") & "-" & _Recibo.dr_General("Hora").ToString.Substring(0, 5), x, y, ancho, 4, StringAlignment.Near)

            Case stc_58mmWinEmbbd.Tipos_Impresion.Deposito 'CONSULTA DEPOSITOS
                y += 6 : CrearLinea(e.Graphics, 8, "FOLIO: " & _Recibo.dr_General("Folio"), x + 1, y, ancho, 4, StringAlignment.Near)
                y += 4 : CrearLinea(e.Graphics, 8, "INICIO: " & _Recibo.dr_General("Fecha_Inicio") & "-" & _Recibo.dr_General("Hora_Inicio").ToString.Substring(0, 5), x, y, ancho, 4, StringAlignment.Near)
                y += 4 : CrearLinea(e.Graphics, 8, "FIN: " & _Recibo.dr_General("Fecha_Fin") & "-" & _Recibo.dr_General("Hora_Fin").ToString.Substring(0, 5), x, y, ancho, 4, StringAlignment.Near)

            Case stc_58mmWinEmbbd.Tipos_Impresion.Saldo ' CONSULTA SALDO
                y += 6 : CrearLinea(e.Graphics, 8, "FECHA:" & _Recibo.dr_General("Fecha") & "-" & _Recibo.dr_General("Hora").ToString.Substring(0, 5), x, y, ancho, 4, StringAlignment.Near) '34 -- 14

            Case stc_58mmWinEmbbd.Tipos_Impresion.Recoleccion 'COSULTA RETIROS
                y += 6 : CrearLinea(e.Graphics, 8, "FOLIO: " & _Recibo.dr_General("Folio"), x, y, ancho, 4, StringAlignment.Near)
                y += 4 : CrearLinea(e.Graphics, 8, "REMISION: " & _Recibo.dr_General("Remision"), x, y, ancho, 4, StringAlignment.Near) '-----------
                y += 4 : CrearLinea(e.Graphics, 8, "ENVASE: " & _Recibo.dr_General("Envase"), x, y, ancho, 4, StringAlignment.Near) '-----------
                y += 4 : CrearLinea(e.Graphics, 8, "FECHA:" & _Recibo.dr_General("Fecha") & "-" & _Recibo.dr_General("Hora").ToString.Substring(0, 5), x, y, ancho, 4, StringAlignment.Near)

        End Select

        '(Far = lejos near=cerca  center=centro)
        Select Case _Recibo.Tipo_Impresion

            Case stc_58mmWinEmbbd.Tipos_Impresion.Deposito, stc_58mmWinEmbbd.Tipos_Impresion.Saldo, stc_58mmWinEmbbd.Tipos_Impresion.Recoleccion
                '---Imprime Nombre de Cajero---
                Call Acomodar_Linea("CAJERO:" & _Recibo.dr_General("Nombre_Usuario"), e, x, y, ancho)

                '---- DESGLOSE-> RETIROS - DEPOSITOS - SALDO <---------
                y += 2 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("DESGLOSE", "", ""), x, y, ancho, 4)
                y += 6 : CrearLinea(e.Graphics, 8, "DENOM   CANT     IMPORTE", x, y, ancho, 4, StringAlignment.Near)


                '<<<<<hacer subconsulta por  moneda (PEso Y dolar)>>>>><

                Dim dt_Pesos As DataTable = _Recibo.dt_Desglose
                Dim dr_Pesos() As DataRow = dt_Pesos.Select("Moneda = 'MXP'")

                Dim dt_Dolares As DataTable = _Recibo.dt_Desglose
                Dim dr_Dolares() As DataRow = dt_Dolares.Select("Moneda = 'USD'")

                Dim dt_Pesos2 As DataTable = _Recibo.dt_Desglose2
                Dim dr_Pesos2() As DataRow = dt_Pesos2.Select("Moneda = 'MXP'")

                Dim dt_Dolares2 As DataTable = _Recibo.dt_Desglose2
                Dim dr_Dolares2() As DataRow = dt_Dolares2.Select("Moneda = 'USD'")

                'Imprimiendo los pesos
                If dr_Pesos.Count > 0 Then
                    For i As Integer = 0 To dr_Pesos.Count - 1
                        y += 4
                        Dim cadOrdenada As String = ""
                        cadOrdenada = Ordena_Cadenas(dr_Pesos(i)("Clave"), dr_Pesos(i)("Cantidad"), FormatCurrency(dr_Pesos(i)("Importe"), 2))
                        CrearLinea(e.Graphics, 8, cadOrdenada, x, y, ancho, 4, StringAlignment.Near)
                    Next
                    y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", "TOTAL MXP: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2), ""), x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)
                End If

                'Imprimiendo los dolares
                If dr_Dolares.Count > 0 Then
                    y += 6 : CrearLinea(e.Graphics, 8, "DENOM   CANT     IMPORTE", x, y, ancho, 4, StringAlignment.Near, FontStyle.Bold)

                    For i As Integer = 0 To dr_Dolares.Count - 1
                        y += 4
                        Dim cadOrdenada As String = ""
                        cadOrdenada = Ordena_Cadenas(dr_Dolares(i)("Clave"), dr_Dolares(i)("Cantidad"), FormatCurrency(dr_Dolares(i)("Importe"), 2))
                        CrearLinea(e.Graphics, 8, cadOrdenada, x, y, ancho, 4, StringAlignment.Near)
                    Next
                    y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2), ""), x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)

                End If

                If dr_Pesos2.Count > 0 Then
                    For i As Integer = 0 To dr_Pesos2.Count - 1
                        y += 4
                        Dim cadOrdenada As String = ""
                        cadOrdenada = Ordena_Cadenas(dr_Pesos2(i)("Clave"), dr_Pesos2(i)("Cantidad"), FormatCurrency(dr_Pesos2(i)("Importe"), 2))
                        CrearLinea(e.Graphics, 8, cadOrdenada, x, y, ancho, 4, StringAlignment.Near)
                    Next
                    y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", "TOTAL MXP: " & FormatCurrency(_Recibo.dr_General("Total_MXP"), 2), ""), x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)
                End If

                'Imprimiendo los dolares
                If dr_Dolares2.Count > 0 Then
                    y += 6 : CrearLinea(e.Graphics, 8, "DENOM   CANT     IMPORTE", x, y, ancho, 4, StringAlignment.Near, FontStyle.Bold)

                    For i As Integer = 0 To dr_Dolares2.Count - 1
                        y += 4
                        Dim cadOrdenada As String = ""
                        cadOrdenada = Ordena_Cadenas(dr_Dolares2(i)("Clave"), dr_Dolares2(i)("Cantidad"), FormatCurrency(dr_Dolares2(i)("Importe"), 2))
                        CrearLinea(e.Graphics, 8, cadOrdenada, x, y, ancho, 4, StringAlignment.Near)
                    Next
                    y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", "TOTAL USD: " & FormatCurrency(_Recibo.dr_General("Total_USD"), 2), ""), x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)

                End If

                '-------------------------

            Case stc_58mmWinEmbbd.Tipos_Impresion.Corte_Diario
                '---------------CORTE DIARIO--DESGLOSE DEPOSITOS X USUARIO
                y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("DETALLE", "", ""), x, y, ancho, 4)
                y += 4 : CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)

                For Each row As DataRow In _Recibo.dt_Detalle.Rows
                    y += 4 : CrearLinea(e.Graphics, 8, row("Fecha_Inicio") & "-" & row("Hora_Inicio"), x, y, ancho, 4, StringAlignment.Near)
                    y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", FormatCurrency(row("Importe"), 2), ""), x, y, ancho, 4)
                    y += 4 : CrearLinea(e.Graphics, 8, row("Nombre"), x, y, ancho, 4, StringAlignment.Near)
                    y += 4
                Next

                CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 3, StringAlignment.Near, FontStyle.Regular)
                y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", "TOTAL: " & FormatCurrency(_Recibo.dr_General("Importe_Total"), 2), ""), x, y, ancho, 4)

                '-----------------CORTE DIARIO -- DEPOSITOS AGRUPADOS X USUARIO
                y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("RESUMEN", "", ""), x, y, ancho, 4)
                y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("NOMBRE", "IMPORTE", ""), x, y, ancho, 4)

                Dim MideNombre As String = ""
                For Each row2 As DataRow In _Recibo.dt_DetalleAgrupado.Rows
                    y += 4
                    MideNombre = row2("Nombre").ToString
                    If MideNombre.Length > 18 Then MideNombre = MideNombre.Substring(0, 18)

                    CrearLinea(e.Graphics, 8, MideNombre, x, y, ancho, 4, StringAlignment.Near)
                    y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", FormatCurrency(row2("Importe"), 2), ""), x, y, ancho, 4)
                Next
                y += 2

            Case stc_58mmWinEmbbd.Tipos_Impresion.Movimientos
                '---------------MOVIMIENTOS---------
                y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("DETALLE", "", ""), x, y, ancho, 4)
                y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("FECHA", "HORA", ""), x, y, ancho, 4)

                y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("DEPOSITO", "RETIRO", ""), x, y, ancho, 4)
                y += 4 : CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)

                Dim FechaAnterior As Date = Nothing
                y += 4
                For Each fila As DataRow In _Recibo.dt_Detalle.Rows

                    If FechaAnterior <> CDate(fila("Fecha").ToString) Then
                        CrearLinea(e.Graphics, 8, Ordena_Cadenas(fila("Fecha"), fila("Hora"), ""), x, y, ancho, 4)
                        y += 4
                    Else
                        y -= 4
                    End If
                    '--ordenar
                    CrearLinea(e.Graphics, 8, Ordena_Cadenas(FormatCurrency(fila("Deposito"), 2), FormatCurrency(fila("Retiro"), 2), ""), x, y, ancho, 4, StringAlignment.Near)
                    FechaAnterior = CDate(fila("Fecha").ToString)
                    y += 8 '6
                Next
                CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)

                y += 4 : CrearLinea(e.Graphics, 8, "TOTAL DEPOSITOS: ", x, y, ancho, 4, StringAlignment.Near)
                y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", FormatCurrency(_Recibo.dr_General("ImporteDepositos"), 2), ""), x, y, ancho, 4)
                y += 4 : CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)
                y += 4 : CrearLinea(e.Graphics, 8, "TOTAL RETIROS: ", x, y, ancho, 4, StringAlignment.Near)
                y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", FormatCurrency(_Recibo.dr_General("ImporteRetiros"), 2), ""), x, y, ancho, 4)
                y += 4 : CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)

        End Select

        If Not _Recibo.Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Movimientos Then
            y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas(" ", "TOTAL: " & FormatCurrency(_Recibo.dr_General("Importe_Total"), 2), ""), x, y, ancho, 4, StringAlignment.Near, FontStyle.Regular)
            '----------acomodar esta cadena----- ya
            Dim ImporteLetras As String = _Recibo.dr_General("ImporteTotal_Letras")
            Call Acomodar_Linea(ImporteLetras, e, x, y, ancho)
        End If

        '----------------------------------
        If _Recibo.Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Deposito OrElse _
        _Recibo.Tipo_Impresion = stc_58mmWinEmbbd.Tipos_Impresion.Recoleccion Then
            y += 8 : CrearLinea(e.Graphics, 8, "------------------------", x, y, ancho, 4, StringAlignment.Near)
            y += 4 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("FIRMA", "", ""), x, y, ancho, 4)
            y += 5
        Else
            If TituloTicket = "SALDO" Or TituloTicket = "CORTE DIARIO" Then y += 4
            y += 6 '-->
        End If
        '----------------------->

        CrearLinea(e.Graphics, 8, "FECHA IMPRESION: ", x, y, ancho, 4, StringAlignment.Near)
        y += 4 : CrearLinea(e.Graphics, 8, Format(Now, "dd/MM/yyyy") & " - " & Hora, x, y, ancho, 4, StringAlignment.Near)
        If varPub.Reimpresion Then
            y += 4 : CrearLinea(e.Graphics, 6, "*ES UNA REIMPRESION DEL TICKET ORIGINAL", x, y, ancho, 4, StringAlignment.Center, FontStyle.Bold)
        End If
        y += 6 : CrearLinea(e.Graphics, 8, Ordena_Cadenas("---FIN TICKET---", "", ""), x, y, ancho, 4)
        y += 4 : CrearLinea(e.Graphics, 8, "--", x, y, ancho, 3, StringAlignment.Center)
        y += 6 : CrearLinea(e.Graphics, 7, ".", x, y, ancho, 3, StringAlignment.Center)
        y += 6 : CrearLinea(e.Graphics, 7, ".", x, y, ancho, 3, StringAlignment.Center)
        y += 6 : CrearLinea(e.Graphics, 7, ".", x, y, ancho, 3, StringAlignment.Center)
        y += 6 : CrearLinea(e.Graphics, 7, ".", x, y, ancho, 3, StringAlignment.Center)
        y += 6 : CrearLinea(e.Graphics, 7, ".", x, y, ancho, 3, StringAlignment.Center)

    End Sub


    Private Sub Acomodar_Linea(ByVal Cadena1 As String, ByVal e As System.Drawing.Printing.PrintPageEventArgs, _
                              ByVal posX As Integer, ByRef posY As Integer, ByVal AnchoRec As Integer, Optional ByVal Titulo As Boolean = False)
        'acomoda las lineas en 24 columnas x linea
        Dim Cad_Resul As String = ""
        Dim Total_Char As Integer = Cadena1.Length
        Dim Inicio_Cad As Integer = 0

        Do While Total_Char > 24
            Cad_Resul = ""
            Cad_Resul = Cadena1.Substring(Inicio_Cad, 24)
            posY += 4
            CrearLinea(e.Graphics, 8, Cad_Resul.Trim, posX, posY, AnchoRec, 4, StringAlignment.Near)
            Inicio_Cad += 24
            Total_Char -= 24
        Loop
        If Total_Char > 0 Then
            posY += 4
            CrearLinea(e.Graphics, 8, (Cadena1.Substring(Inicio_Cad, Total_Char)).Trim, posX, posY, AnchoRec, 4, StringAlignment.Near)
        End If
        posY += 4 'suma 4
    End Sub

    Private Function Ordena_Cadenas(ByVal cad1 As String, ByVal cad2 As String, ByVal cad3 As String) As String
        Dim cadFinal As String = ""

        If cad1 <> "" AndAlso cad2 <> "" AndAlso cad3 <> "" Then
            '-----alinea Izquierda, Centro, derecha---
            If cad1.Length < 8 Then cad1 = cad1 & "   "
            If cad1.Length > 8 Then cad1 = cad1.Substring(0, 8)

            If cad2.Length < 3 Then cad2 = "  " & cad2
            If cad2.Length > 3 Then cad2 = fn_Right(cad2, 3)

            If cad3.Length < 13 Then cad3 = "        " & cad3
            If cad3.Length > 13 Then cad3 = fn_Right(cad3, 13)
            cadFinal = cad1 + cad2 + cad3

        ElseIf cad1 <> "" AndAlso cad2 <> "" AndAlso cad3 = "" Then

            If cad1 = " " Then 'VERIFICA SI CAD1 TRAE UN ESPACIO BLANCO
                cad2 = "                      " & cad2 '22esp
                If cad2.Length > 24 Then cadFinal = fn_Right(cad2, 24)
            Else
                '-----------aki para alinear Izquierda, Derecha----
                If cad1.Length < 12 Then cad1 = cad1 & "           "
                If cad1.Length > 12 Then cad1 = cad1.Substring(0, 12)

                If cad2.Length < 12 Then cad2 = "           " & cad2
                If cad2.Length > 12 Then cad2 = fn_Right(cad2, 12)
                cadFinal = cad1 + cad2
            End If

        ElseIf cad1 <> "" AndAlso cad2 = "" AndAlso cad3 = "" Then
            '----Alinea centro----------------
            If cad1.Length < 24 Then
                Dim Cont As Integer = 0
                Cont = (24 - cad1.Length) / 2
                cadFinal = cad1.PadLeft(Cont + cad1.Length, " ") 'rellena con Esp en blanco
                cadFinal += cadFinal.Substring(0, Cont)
                If cadFinal.Length > 24 Then cadFinal = cadFinal.Remove(0, 1)
            End If
        End If
        Return cadFinal

    End Function

    Private Sub CrearLinea(ByRef G As System.Drawing.Graphics, ByVal FontSize As Integer, ByVal Texto As String, _
                           ByVal X As Integer, ByVal Y As Integer, ByVal Ancho As Integer, ByVal Alto As Integer, _
                           Optional ByVal Alineacion As Drawing.StringAlignment = StringAlignment.Near, _
                           Optional ByVal Estilo As System.Drawing.FontStyle = FontStyle.Regular)
        Dim Font As New Font("Courier New", FontSize, Estilo)
        Dim Sf As New Drawing.StringFormat
        Dim R As New Rectangle(X, Y + _Margen, Ancho, Alto)
        Sf.Alignment = Alineacion
        G.PageUnit = GraphicsUnit.Millimeter
        G.DrawString(Texto, Font, Brushes.Black, R, Sf)
    End Sub

    Private Sub CrearImagen(ByRef G As System.Drawing.Graphics, ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, _
                        ByVal H As Integer)
        Dim newImage As Image = Image.FromFile("LogoSISSA.jpg")
        Dim srcRect As New Rectangle(X, Y, W, H) ' 0,25,10,10
        G.DrawImage(newImage, srcRect)
    End Sub
End Class
