Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports System.Threading
Imports Modulo_CashFlowV2.cls_Correo

Public Class frm_MenuGeneral
    Dim miBoton As Button
    Dim miTipo As Type
    Dim segundosImprime As Integer = 0
    Public TablapUser As DataTable = Nothing
    Dim btn_Sincronizar As Button
    Dim thread As Thread
    Dim SincronizaBtn As Boolean

#Region "Prodimientos Privados"

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs)
        varPub.SegundosSesion = 0

        Call fn_SincronizaUltimaConexion()

        Select Case sender.Name
            Case "btn_Depositos"
                Call fn_DepositosPendientes_Close()

                '---------------Validar que hay mas 2 CAsets minimo X 1Validado
                Dim Num_Casets As Integer = fn_Casets_Count()

                If varPub.Cant_Validadores = 1 Then
                    Select Case Num_Casets
                        Case 0, 1
                            Call fn_MsgBox("Debe haber mínimo 2 casets activos.", MessageBoxIcon.Exclamation)

                    End Select
                ElseIf Num_Casets < 4 And varPub.Cant_Validadores = 2 Then
                    Call fn_MsgBox("Debe haber Mínimo 4 casets activos porque se tienen 2 validadores.", MessageBoxIcon.Exclamation)

                End If
                '----------------------
                Call fn_Menus_Open(1)

            Case "btn_Retiros"
                Call fn_DepositosPendientes_Close()
                Call fn_Menus_Open(2)

            Case "Corte"
                Call fn_DepositosPendientes_Close()
                Call fn_Menus_Open(19)

            Case "btn_ValidarBilletes"
                Call fn_Menus_Open(21)
            Case "btn_ConsultaDepositos"
                Call fn_DepositosPendientes_Close()
                Call fn_Menus_Open(3)
            Case "btn_ConsultaRetiros"
                Call fn_DepositosPendientes_Close()
                Call fn_Menus_Open(16)
            Case "btn_ConsultaSaldos"
                Call fn_DepositosPendientes_Close()
                Call fn_Menus_Open(4)
            Case "btn_Movimientos"
                Call fn_DepositosPendientes_Close()
                Call fn_Menus_Open(7)
            Case "btn_CatalogoCaset"
                Call fn_Menus_Open(11)
            Case "btn_ConsultaUsuarios"
                Call fn_Menus_Open(5)
            Case "btn_Corte"
                Call fn_Menus_Open(25)
            Case "btn_Parametros"
                Call fn_Menus_Open(8, 0)

                lbl_AlertaUpdate.Visible = (varPub.ConexionwebAdmin = 1) AndAlso (varPub.Comprobacion < DateTime.Now.ToString("MM/yy"))
                If btn_Sincronizar IsNot Nothing Then
                    btn_Sincronizar.Enabled = (varPub.ConexionwebAdmin = 1)
                End If

            Case "btn_Sincronizar"
                'pct_Cargando.Visible = True
                'Application.DoEvents()
                frm_Login.tmr_SesionGeneral.Enabled = False

                If SincronizaBtn = False Then


                    Panel1.Enabled = False

                    varPub.SegundosSesion = 0
                    Cursor = Cursors.WaitCursor
                    If (varPub.ConexionwebAdmin = 1 Or varPub.ConexionwebAdmin = 2) Then
                        If fn_VerificaConexionInternet() Then
                            'COMENTARIZADO POR JMB 2021 POR QUE USAR THREAD
                            'thread = New Thread(New ThreadStart(AddressOf ThreadSincronizarDepositosDescarga))
                            'thread.Start()
                            'fn_MsgBox("Espere un momento, enviando información a la WEB, gracias.", MessageBoxIcon.Information, True)
                            Dim frm As New frm_Mensaje
                            frm.pct_Icono.Image = My.Resources.information_128
                            frm.btn_Aceptar.Font = New Font("", varPub.TamañoFuente_Botones)
                            frm.btn_Cancelar.Font = New Font("", varPub.TamañoFuente_Botones)
                            frm.btn_Cancelar.Visible = False
                            frm.btn_Aceptar.Visible = False
                            frm.lbl_Mensaje.Text = "Sincronizando información, espere un momento..."
                            frm.lbl_Mensaje.Visible = True
                            frm.tmr_Mensaje.Enabled = False
                            frm.Show()
                            frm.Refresh()
                            Call fn_Menus_Open(14) 'DEscargas
                            Call fn_Menus_Open(15) 'Subidas
                            frm.Close()
                        Else
                            Call fn_MsgBox("Sin conexión a Internet.", MessageBoxIcon.Error)
                        End If
                        ' sincronizar todo(Usuarios, caset, denominaciones, monedas)
                        lbl_AlertaUpdate.Visible = (varPub.Comprobacion < DateTime.Now.ToString("MM/yy"))
                    End If
                    Cursor = Cursors.Default
                    'pct_Cargando.Visible = False
                    Panel1.Enabled = True
                    SincronizaBtn = True
                    btn_Sincronizar.Enabled = False
                    frm_Login.tmr_SesionGeneral.Enabled = True
                Else
                    btn_Sincronizar.Enabled = False
                End If

            Case "btn_CambiarPassword"
                Call fn_Menus_Open(5, -1)
            Case "btn_Privilegios"
                Call fn_Menus_Open(6)
            Case "btn_Auditoria"
                Call fn_Menus_Open(9)
            Case "btn_ReiniciarImpresora"
                Call ReinciarImpresora()
            Case "btn_CerrarSesion"

                Dim frm As New frm_Mensaje
                frm.pct_Icono.Image = My.Resources.information_128
                frm.btn_Aceptar.Font = New Font("", varPub.TamañoFuente_Botones)
                frm.btn_Cancelar.Font = New Font("", varPub.TamañoFuente_Botones)
                frm.btn_Cancelar.Visible = False
                frm.btn_Aceptar.Visible = False
                frm.lbl_Mensaje.Text = "Sincronizando información, espere un momento..."
                frm.lbl_Mensaje.Visible = True
                frm.tmr_Mensaje.Enabled = False
                frm.Show()
                frm.Refresh()

                Panel1.Enabled = False
                varPub.SegundosSesion = 0
                Cursor = Cursors.WaitCursor
                If fn_VerificaConexionInternet() Then
                    'fn_Menus_Open(15) 'Subidas
                    frm_Login.Sincronizar()
                End If
                frm.Close()
                Cursor = Cursors.Default
                Panel1.Enabled = True
                Me.Close()

                'COMENTARIZADO BJSE 20 ABRIL 2021
                'If varPub.Conectividad = False AndAlso varPub.Trabajar_sin = False Then
                '    frm_Login.Sincronizar()
                'End If
                'frm_Login.Sincronizar()
            Case "btn_Cajas"
                Call fn_Menus_Open(26)
            Case "btn_Correos"
                Call fn_Menus_Open(27)
            Case "btn_Cerradura"
                Call fn_Menus_Open(28)
            Case "btn_Atasco"
                Call fn_Menus_Open(29)
            Case "btn_Reporte"
                Call fn_Menus_Open(30)
        End Select

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

            fn_EscribirLog(varPub.UsuarioClave, "Parametros", "REINICIANDO impresora")
            cmdColaImpresion.Start()
            'esperar 3 segundos y luego Mandar Imprimir Ticket prueba
            tmr_ColaImpresion.Enabled = True

        Catch ex As Exception
            tmr_ColaImpresion.Enabled = False
            fn_EscribirLog(varPub.UsuarioClave, "Parametros", "ERROR al reinciar impresora")

            fn_MsgBox("ERROR al reiniciar la impresora. " & ex.Message, MessageBoxIcon.Error, True, 2)
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub ThreadSincronizarDepositosDescarga()

        Call fn_Menus_Open(14) 'DEscargas
        Call fn_Menus_Open(15) 'Subidas

    End Sub

#End Region



    Private Sub frm_MenuGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 33

        'verificar si la tabla Tiene  permisos     (vacio- nothing)
        ' funcion llena Botones con las opcines d acuerdo a la consulta
        'If ((varPub.ConexionwebAdmin = 1) And (varPub.VerificaUpdate = "S")) Then
        '    fn_MsgBox("Hay una actualizacion disponible ", MessageBoxIcon.Information, True, 2)
        'End If

        '1.- Verifica tipo Corte existente


        'If varPub.ManejaCorte = 1 Then

        '    Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes

        '    Dim dt_Corte As DataTable = fn_VerificaCorte()

        '    If dt_Corte Is Nothing Then
        '        fn_MsgBox("Ocurrió un error al verificar el corte actual.", MessageBoxIcon.Error, True, 2)
        '    End If

        '    If dt_Corte.Rows.Count > 0 Then
        '        varPub.CorteActual = CInt(dt_Corte.Rows(0).Item("Corte"))
        '        Persistente.Persistir()
        '        Persistente.Cargar()
        '    ElseIf dt_Corte.Rows.Count = 0 Then

        '        If cls_CashFlow.Fn_AbrirCorte() Then
        '            Persistente.Persistir()
        '            Persistente.Cargar()
        '        Else
        '            Persistente.Persistir()
        '            Persistente.Cargar()
        '        End If
        '    End If
        'End If


        Select Case fn_Cerradura_Consultar_Fecha()
          Case 1
            fn_MsgBox("La cerradura necesita cambio de batería", MessageBoxIcon.Information, True)
           If varPub.Conectividad Then
              If fn_VerificaConexionInternet() Then
                 MandarCorreo("La cerradura necesita cambio de batería", "Cerradura", varPub.UsuarioClave, varPub.NombreUser)
                 If Not fn_Cerradura_Estatus_Enviado() Then
                            fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", " ERROR AL CAMBIA EL ESTATUS A ENVIADO")
                        End If
                    End If
                End If

            Case 2
                'fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", "LA CERRADURA AUN CUENTA CON BATERIA")
            Case 3
                fn_EscribirLog(varPub.UsuarioClave, "MENU GENERAL", " ERROR AL CONSULTAR FECHA DE BATERIA DE CERRADURA")
        End Select

        'Se Verifica Conexiones
        If fn_VerificaConexionInternet() = True Then
            'Sia la ultima comprobacion fue en un mes diferente se vuelve a comprobar la version 
            If varPub.Comprobacion = "" Then
                varPub.Comprobacion = "1900/00"
            End If
            If varPub.Comprobacion < DateTime.Now.ToString("yyyy/MM") Then
                frm_BuscarActualizar.ShowDialog()

            End If

        End If

        If TablapUser Is Nothing OrElse TablapUser.Rows.Count = 0 Then
            Call fn_MsgBox("No se cargaron valores para los privilegios,", MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        'filas seria en este caso el N° de botones {4botones x fila por ejemplo}
        Dim Filas As Integer = TablapUser.Rows.Count
        Dim Renglon As Integer = -1
        Dim ObjContador As Integer = 0
        Dim cuentaCol As Integer = 1

        'esto es para 4 columnas y 5 filas 22/14/2014
        If Filas > 0 AndAlso Filas <= 4 Then
            Renglon = 0
        ElseIf Filas > 4 AndAlso Filas <= 8 Then
            Renglon = 1
        ElseIf Filas > 8 AndAlso Filas <= 12 Then
            Renglon = 2
        ElseIf Filas > 12 AndAlso Filas <= 16 Then
            Renglon = 3
        ElseIf Filas > 16 AndAlso Filas <= 20 Then
            Renglon = 4
        ElseIf Filas > 20 AndAlso Filas <= 24 Then
            Renglon = 5
        End If

        For i As Integer = 0 To Renglon ' {0-4 columnas}
            cuentaCol = 1
            For j As Integer = 0 To Filas - 1 '{0-2Col X 1fila} {22/01/2014 es de 0 A 3}

                miBoton = New Button
                miTipo = miBoton.GetType

                With miBoton

                    .Name = TablapUser(ObjContador)(1).ToString 'miTipo.Name.ToString
                    .Text = TablapUser(ObjContador)(0).ToString '"Nuevo boton"
                    .Height = 88
                    .Width = 260
                    .Font = New Font("Arial", 14, FontStyle.Bold)
                    .Anchor = CType(AnchorStyles.Left Or AnchorStyles.Right, AnchorStyles)
                    .Image = CType(My.Resources.ResourceManager.GetObject(TablapUser(ObjContador)(1).ToString), System.Drawing.Image)
                    .BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
                    .ImageAlign = ContentAlignment.MiddleCenter
                    .TextAlign = ContentAlignment.MiddleCenter
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
                    .TextImageRelation = TextImageRelation.ImageAboveText
                End With

                If miBoton.Name = "btn_Sincronizar" Then
                    miBoton.Enabled = True
                    btn_Sincronizar = miBoton
                    'agregamos el boton a TablelayoutPAnel
                    tbLP_Botones.Controls.Add(btn_Sincronizar, j, i)
                    'agregamnos el handled del evcento click a dcada boton
                    AddHandler btn_Sincronizar.Click, AddressOf Evento_Click
                Else
                    'agregamos el boton a TablelayoutPAnel
                    tbLP_Botones.Controls.Add(miBoton, j, i)
                    'agregamnos el handled del evcento click a dcada boton
                    AddHandler miBoton.Click, AddressOf Evento_Click
                End If

                ObjContador += 1
                'cuenta col era 3 ahora 4 porke son 4Columnas
                If cuentaCol = 4 Then
                    Filas -= cuentaCol
                    Exit For
                End If
                cuentaCol += 1
            Next
        Next

        'despues de crear los botones Aplicar TAmaño fuente y TipoFuente
        Call fn_CambiaTamanoFuente(Me, 14, varPub.TamañoFuente_Botones)

        '.Font = New Font(New FontFamily("Arial"), FuenteTLabel)

        'verifica si hubo depositos pendientes
        If varPub.ID_DepositoP > 0 Then
            Call fn_Menus_Open(1)
        End If
        If (varPub.ConexionwebAdmin = 1) Then
            '' lbl_AlertaUpdate.Visible = (varPub.VerificaUpdate = "S")
        End If
    End Sub

    Private Sub tmr_ColaImpresion_Tick(sender As Object, e As EventArgs) Handles tmr_ColaImpresion.Tick
        segundosImprime += 1
        If segundosImprime = 3 Then
            Call fn_ImpresiondePrueba()
            segundosImprime = 0
            tmr_ColaImpresion.Enabled = False
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TbLP_Botones_Paint(sender As Object, e As PaintEventArgs) Handles tbLP_Botones.Paint

    End Sub
End Class