Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_RespaldarSistema

    Private Sub frm_RespaldarSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_RutaInstalacion.Text = Application.StartupPath
        lbl_RutaLogs.Text = varPub.Ruta_Log
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 38
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Destino_Click(sender As Object, e As EventArgs) Handles btn_Destino.Click
        varPub.SegundosSesion = 0
        frm_Login.tmr_SesionGeneral.Enabled = False
        Dim Dialogo As New FolderBrowserDialog With {.Description = "Destino de los Archivos.", .ShowNewFolderButton = True}
        If Dialogo.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            frm_Login.tmr_SesionGeneral.Enabled = True
            Exit Sub
        End If
        varPub.SegundosSesion = 0
        frm_Login.tmr_SesionGeneral.Enabled = True
        btn_Copiar.Enabled = True
        lbl_Destino.Text = Dialogo.SelectedPath
    End Sub

    Private Sub btn_Copiar_Click(sender As Object, e As EventArgs) Handles btn_Copiar.Click
        varPub.SegundosSesion = 0
        pnl_General.Enabled = False
        Try
            My.Computer.FileSystem.CopyDirectory(lbl_RutaInstalacion.Text, lbl_Destino.Text & "\RespaldoSistema\", FileIO.UIOption.AllDialogs) '19/11/2015
            My.Computer.FileSystem.CopyDirectory(lbl_RutaLogs.Text, lbl_Destino.Text & "\RespaldoLogs\", FileIO.UIOption.AllDialogs) '19/11/2015
            fn_MsgBox("El proceso de copiado se ha realizado correctamente.", MessageBoxIcon.Information, True, 2)
            pnl_General.Enabled = True
            Me.Close()
        Catch ex As Exception
            pnl_General.Enabled = True
            fn_MsgBox("Ocurrió un error al respaldar los Directorios.", MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub
End Class