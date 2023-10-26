Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports System.Threading

Public Class frm_Lista_Cajas
    Dim miBoton As Button
    Dim lbl_Cerrar As Label
    Dim X As Integer = 8
    Dim Y As Integer = 10
    Dim Ancho_btn As Integer = 260
    Dim Alto_btn As Integer = 88
    Dim miTipo As Type
    Dim btnContar As Integer
    Dim segundosImprime As Integer = 0
    Dim btn_Sincronizar As Button
    Dim thread As Thread
    Dim dt_CajasLocales As DataTable = Nothing
    Public Id_Caja As Integer = 0
    Public Clave_Caja As String = ""
    Public Cerrar As Boolean = True
    Dim Alto_Frm As Integer = Me.Height
    Dim Ancho_Frm As Integer = Me.Width
    Dim Ancho_Pantalla As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim Alto_Pantalla As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim Descripcion As String
    Dim ArregloCajas(,)

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub ReinciarImpresora()
        'lohs reinciar impresoras***********************

        varPub.SegundosSesion = 0
        'Process.Start("cmd.exe", "/k @echo Hola mundo. & pause>nul")Ejem.

        'en este Apartado Reinicia la cola de impresion
        'al reinciar mandar a imprimir en automatico una prueba de impresion.....
        Cursor = Cursors.WaitCursor
        Try
            Dim cmdColaImpresion As New Process

            cmdColaImpresion.StartInfo.FileName = "cmd.exe"
            cmdColaImpresion.StartInfo.Arguments = "/k Net Stop Spooler & Net Start Spooler"

            'esto pa ke no muestre la pantalla negra CMD
            cmdColaImpresion.StartInfo.UseShellExecute = False
            cmdColaImpresion.StartInfo.CreateNoWindow = True

            fn_EscribirLog(varPub.UsuarioClave, "Parametros", "Se inicio proceso de reiniciar impresora")
            cmdColaImpresion.Start()
            'esperar 3 segundos y luego Mandar Imprimir Ticket prueba
            tmr_ColaImpresion.Enabled = True

        Catch ex As Exception
            tmr_ColaImpresion.Enabled = False
            fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", " ERRRO AL REININCIAR LA IMPRESORA")

            fn_MsgBox("Ocurrió un error al reiniciar la Impresora. " & ex.Message, MessageBoxIcon.Error, True, 2)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frm_Lista_Cajas_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.Refresh()
    End Sub


    Private Sub frm_Lista_Cajas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 29
        dt_CajasLocales = fn_CajaLocal_Consulta()

        If dt_CajasLocales Is Nothing Then
            fn_MsgBox("Ocurrió un error al consultar las Cajas Locales.", MessageBoxIcon.Error, True, 3)
            Me.Close()
            Exit Sub
        End If

        If dt_CajasLocales.Rows.Count > 0 Then

            'Calcular cuantos botones caben a lo alto
            Dim CantidadBotonesAlto As Integer = (Alto_Pantalla - 250) / Alto_btn
            Dim CantidadBotonesAncho As Integer = Ancho_Pantalla / Ancho_btn



            Me.Width = Ancho_btn + 15
            Me.Height = 5

            '  lbl_Cerrar = New Label

            'With lbl_Cerrar
            '    .Name = "lbl_Cerrar"
            '    .Text = "[Cerrar]"
            '    .Font = New Font("Arial", 6, FontStyle.Bold)
            '    .TextAlign = ContentAlignment.MiddleCenter
            '    .Location = New Point(X, Y)
            '    .Width = 100
            '    .Height = 25
            '    Me.Controls.Add(lbl_Cerrar)
            '    AddHandler lbl_Cerrar.Click, AddressOf Evento_Click
            'End With

            Me.Height = Me.Height + 25 + 5

            Y = Y + 25 + 5
            '--------------------------------------24/05/2019--JAVIER ZAPATA-------------------------
            ReDim ArregloCajas(dt_CajasLocales.Rows.Count, dt_CajasLocales.Columns.Count - 1)
            Dim Posicion1 As Integer = 0
            Dim Posicion2 As Integer = 0


            For Each dr_Elementos As DataRow In dt_CajasLocales.Rows
                ArregloCajas(Posicion1, Posicion2) = dr_Elementos("Id_Caja")
                ArregloCajas(Posicion1, Posicion2 + 1) = dr_Elementos("Clave_Caja")
                ArregloCajas(Posicion1, Posicion2 + 2) = dr_Elementos("Descripcion")
                Posicion1 = Posicion1 + 1
                '----------------------------------------------------------------------------
                miBoton = New Button

                If (btnContar = CantidadBotonesAlto) Or (btnContar = (CantidadBotonesAlto * 2)) Then
                    X = X + Ancho_btn + 5
                    Y = 10
                    Me.Width += Ancho_btn + 10 - 5
                    Me.Location = New Point(Me.Location.X - (Ancho_btn / 2) - 10, Me.Location.Y)
                End If

                With miBoton
                    .Name = "btn_" & dr_Elementos("Id_Caja")
                    .Text = dr_Elementos("Descripcion")
                    .Tag = dr_Elementos("Id_Caja")
                    .Width = Ancho_btn
                    .Height = Alto_btn
                    .Font = New Font("Arial", 14, FontStyle.Bold)
                    '.Anchor = CType(AnchorStyles.Left Or AnchorStyles.Right, AnchorStyles)
                    '.Image = CType(My.Resources.ResourceManager.GetObject(TablapUser(ObjContador)(1).ToString), System.Drawing.Image)
                    .BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(65, Byte), Integer))
                    .ImageAlign = ContentAlignment.MiddleCenter
                    .TextAlign = ContentAlignment.MiddleCenter
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
                    .TextImageRelation = TextImageRelation.ImageAboveText
                    .Location = New Point(X, Y)
                    Me.Controls.Add(miBoton)
                    AddHandler miBoton.Click, AddressOf Evento_Click
                End With

                If btnContar < CantidadBotonesAlto Then Me.Height += Alto_btn + 7
                Y = Y + Alto_btn + 5
                btnContar += 1

            Next

            Call fn_CambiaTamanoFuente(Me, 14, varPub.TamañoFuente_Botones)
        End If
    End Sub

    Public Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0
        Dim btn As Button = CType(sender, Button)
        '-----------Recorremos el arreglo que se guardó en la consulta/ dividimos entre las tres columnas menos uno pues empieza de 0
        For i = 0 To (ArregloCajas.Length / 3) - 1
            If ArregloCajas(i, 0) = btn.Tag Then
                Clave_Caja = ArregloCajas(i, 1) ' y así casamos la clave con el id del tag del boton
            End If
        Next
        Id_Caja = btn.Tag
        Cerrar = False
        varPub.Id_caja = Id_Caja
        Me.Close()
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Cerrar = True
        Me.Close()
        Exit Sub
    End Sub
End Class