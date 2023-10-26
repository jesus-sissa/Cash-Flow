Imports MPOST
Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_MenuAuditoria



    Private Sub frm_MenuAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 32

        varPub.SegundosSesion = 0
        ' btn_SubirArchivo.Enabled = varPub.Conectividad
    End Sub

    Private Sub tbLP_Botones_Click(sender As Object, e As EventArgs) Handles tbLP_Botones.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_TarjetaRed_Click(sender As Object, e As EventArgs)
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        'Configurar la tarjeta de red
        Call fn_Menus_Open(23, 0) ' 03/11/2015 ira el menu que hará la configuracion de tarjeta de red
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_ConsultaLog_Click(sender As Object, e As EventArgs) Handles btn_ConsultaLog.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(9)
        pnl_General.Enabled = True


    End Sub


    Private Sub btn_Respaldar_Click(sender As Object, e As EventArgs)
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Dim frm As New frm_RespaldarSistema
        frm.ShowDialog()
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_ModificarXML_Click(sender As Object, e As EventArgs)
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Dim frm As New frm_EditarXML
        frm.ShowDialog()
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Parametros_Click(sender As Object, e As EventArgs) Handles btn_Parametros.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(8, 0)
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_BorrarMov_Click(sender As Object, e As EventArgs)
        Call fn_Menus_Open(20)
    End Sub

    Private Sub btn_ScriptSql_Click(sender As Object, e As EventArgs)
        pnl_General.Enabled = True

        varPub.SegundosSesion = 0
        Call fn_MsgBox("Opción para uso futuro. No se realizó ningún movimiento.", MessageBoxIcon.Error, True, 3)
        Exit Sub
        Cursor = Cursors.WaitCursor

        If fn_MsgBox("Realmente desea ejecutar el Script para alterar la estructura de la Base De Datos.?", MessageBoxIcon.Exclamation, False, 0, True, True) Then
            Call cls_FuncionesPublicas.fn_EscribirLog(varPub.UsuarioClave, "PARAMETROS", "INICIANDO PROCESO DE ALTERACION DE BASE DE DATOS SQLCE")

            If Not cls_Actualizacion.fn_AlterarEsctructura_SQLCE() Then
                Call fn_MsgBox("Ocurrió un error al modificar la estructura de la Base De Datos.", MessageBoxIcon.Error, True, 3)
            Else
                Call fn_MsgBox("La actualización a la Base De Datos se realizó correctamente.", MessageBoxIcon.Information, True, 3)
            End If
        End If
        Cursor = Cursors.Default

        pnl_General.Enabled = True
    End Sub

    Private Sub btn_LimpiaBDD_Click(sender As Object, e As EventArgs)
        'Procedimiento para limpiar la BDD Local SqlCE
        'pnl_General.Enabled = False

        'If fn_MsgBox("Está Seguro Limpiar todas las Tablas de la Base De Datos", MessageBoxIcon.Exclamation, False, , True, True) Then
        '    varPub.SegundosSesion = 0
        Call fn_Menus_Open(18) 'Limpiar bddLocal {}
        '    Me.Close()
        'End If
        'pnl_General.Enabled = True
    End Sub

    Private Sub btn_CatalogoCaset_Click(sender As Object, e As EventArgs) Handles btn_CatalogoCaset.Click
        pnl_General.Enabled = False
        Call fn_Menus_Open(11) 'Casets
        pnl_General.Enabled = True
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Monedas_Click(sender As Object, e As EventArgs) Handles btn_Monedas.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(13) 'Monedas
        pnl_General.Enabled = True

    End Sub

    Private Sub btn_Denominaciones_Click(sender As Object, e As EventArgs) Handles btn_Denominaciones.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(12)
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_ConsultaUsuario_Click(sender As Object, e As EventArgs) Handles btn_ConsultaUsuario.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(5)
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_Privilegios_Click(sender As Object, e As EventArgs) Handles btn_Privilegios.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Call fn_Menus_Open(6) 'MEnu privilegios
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_SubirArchivo_Click(sender As Object, e As EventArgs)
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Dim frm As New frm_RespaldarenWeb
        frm.ShowDialog()
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_ExitApp_Click(sender As Object, e As EventArgs) Handles btn_ExitApp.Click
        varPub.SegundosSesion = 0

        If fn_MsgBox("Está Seguro De salir de la Aplicación", MessageBoxIcon.Exclamation, False, , True, True) Then
            Dim TotalModal As Integer = Application.OpenForms.Count - 1  '-1 porque Empieza en 0 
            For contador As Byte = 0 To TotalModal '
                If Application.OpenForms(TotalModal).Modal OrElse Not (Application.OpenForms(TotalModal).Modal) Then
                    Application.OpenForms(TotalModal).Close()
                    TotalModal -= 1
                End If
            Next
            End ' finaliza todo de jalon.
        End If

    End Sub

    Private Sub btn_CerrarSesion_Click(sender As Object, e As EventArgs) Handles btn_CerrarSesion.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub btn_EscanearPuerto_Click(sender As Object, e As EventArgs) Handles btn_EscanearPuerto.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Dim frm As New frm_EscanearPuertos
        frm.ShowDialog()
        pnl_General.Enabled = True
    End Sub

    Private Sub btn_EditarBDsqlCE_Click(sender As Object, e As EventArgs)
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Dim frm As New frm_SQLCE4_Toolbox
        frm.ShowDialog()
        pnl_General.Enabled = True
    End Sub

    Private Sub Btn_resetear_Click(sender As Object, e As EventArgs) Handles Btn_resetear.Click
        Dim frmConfigServer As New frm_Rest_Validador
        frmConfigServer.ShowDialog()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pnl_General.Enabled = False
        varPub.SegundosSesion = 0
        Dim frm As New frm_Tickets
        frm.ShowDialog()
        pnl_General.Enabled = True
    End Sub
End Class