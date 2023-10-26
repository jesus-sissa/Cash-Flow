Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQL
Imports dataconection.cls_DatosSQLCE
Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.Data.SqlClient
Public Class frm_Corte

    Private Sub frm_Corte_Load(sender As Object, e As EventArgs) Handles Me.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 20

        Call LlenarInfoCorte()

    End Sub

    Private Sub btn_Corte_Click(sender As Object, e As EventArgs) Handles btn_Corte.Click
        varPub.SegundosSesion = 0
        Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
        Dim Mensaje As String = ""
        If varPub.CorteActual = 0 Then
            Mensaje = "Desea generar un Corte nuevo"
        Else
            Mensaje = "Desea cerrar Corte actual y generar uno nuevo"
        End If

        Select Case fn_MsgBox(Mensaje, MsgBoxStyle.YesNo + MsgBoxStyle.Question, , Tiempo_Timer:=20, btnAceptarVisible:=True, btnCancelarVisible:=True)
            Case MsgBoxResult.Yes
            Case False
                Exit Sub
        End Select

        If varPub.CorteActual > 0 Then
            If Not Fn_CerrarCorte() Then
                Call fn_MsgBox("Ocurrió un Error al intentar generar el Corte.", MessageBoxIcon.Information)
                Exit Sub
            End If
            'escribir en log que se cerró el corte

        End If

        If varPub.ManejaConexionWebService = 0 Then

            If Fn_AbrirCorte() Then
                Persistente.Persistir()
                Persistente.Cargar()
                Call fn_MsgBox("El Corte se generó correctamente.", MessageBoxIcon.Information)
                'escribir en log que se Abrió el corte
            Else
                Persistente.Persistir()
                Persistente.Cargar()
                Call fn_MsgBox("Ocurrió un Error al intentar generar el Corte.", MessageBoxIcon.Information)
            End If


        ElseIf varPub.ManejaConexionWebService = 1 Then
            If varPub.CorteActual = 0 Then
                If Fn_AbrirCorte() Then
                    Persistente.Persistir()
                    Persistente.Cargar()
                    Call fn_MsgBox("El Corte se generó correctamente.", MessageBoxIcon.Information)
                    varPub.CajeroStatus = "D"
                    'escribir en log que se Abrió el corte
                Else
                    Persistente.Persistir()
                    Persistente.Cargar()
                    Call fn_MsgBox("Ocurrió un Error al intentar generar el Corte.", MessageBoxIcon.Information)
                End If

            End If
        End If
    End Sub

    Sub LlenarInfoCorte()
        Try
            Dim Cnn As SqlConnection

            Cnn = Crear_ConexionSQL(_Cnx)

            Dim Cmd As SqlCommand = Crear_ComandoSQL("Cortes_Read", CommandType.StoredProcedure, Cnn)

            Dim dt_IC_Verifica As DataTable = Ejecutar_ConsultaSQL(Cmd)
            cmd.Dispose()
            cnn.Dispose()
            If dt_IC_Verifica IsNot Nothing And dt_IC_Verifica.Rows.Count > 0 Then
                Lbl_FolioCorte.Text = dt_IC_Verifica.Rows(0)("Corte")
                lbl_ClaveUsuario.Text = dt_IC_Verifica.Rows(0)("Clave")
                LblNombre.Text = dt_IC_Verifica.Rows(0)("Nombre")
                Lbl_FechaCorte.Text = dt_IC_Verifica.Rows(0)("Fecha")
                Lbl_HoraCorte.Text = dt_IC_Verifica.Rows(0)("Hora")
            End If
        Catch ex As Exception
            Call fn_MsgBox("Ocurrió un Error al intentar llenar Corte", MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Function Cerrar_ConexionSQL(cnx_Local As String) As SqlConnection
        Throw New NotImplementedException
    End Function

End Class