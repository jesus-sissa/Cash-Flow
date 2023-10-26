Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports System.Threading

Public Class frm_Privilegios
    Dim listaoriginal() As String
    Dim listaModificada() As String

#Region "Funciones Privadas"

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub PrivilegiosAsignados_LlenarListBox()
        Call fn_PrivilegiosAsignados_LlenarLista(lst_PrivilegiosAsig, lst_Usuarios.SelectedValue.ToString.Split("/")(0))
    End Sub

    Private Sub DeseleccionaPrivilegiosAsig()
        'sub que verifica que no active los botones de quitar uno y todo si esta seleccionado
        ' la Opcion "Privilegios"
        btn_QuitarUno.Enabled = lst_PrivilegiosAsig.Items.Count > 0
        btn_QuitarTodo.Enabled = lst_PrivilegiosAsig.Items.Count > 0

        lst_PrivilegiosAsig.SelectedIndex = -1
        lbl_PrivilegiosAsig.Text = "Privilegios Asignados: " & lst_PrivilegiosAsig.Items.Count
    End Sub

    Private Sub CierraModales()
        Dim TotalModal As Integer = Application.OpenForms.Count - 1 '-1 porque es de 0 a N
        For contador As Integer = 2 To TotalModal '0 Login ,1 es Teclado por eso empieza en 2

            If Application.OpenForms(TotalModal).Modal OrElse Not (Application.OpenForms(TotalModal).Modal) Then
                Application.OpenForms(TotalModal).Close()
                Call fn_EscribirLog(varPub.UsuarioClave, "Privilegios", "Cerrando pantalla por Modificacion de privilegios del usuario firmado")
                TotalModal -= 1
            End If
        Next
        varPub.SegundosSesion = 0

    End Sub
#End Region

    Private Sub frm_Privilegios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_Privilegios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 35

        varPub.SegundosSesion = 0
        pnl_General.Enabled = False
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)


        If (varPub.ConexionwebAdmin = 1) Then
            If fn_VerificaConexionInternet() Then
                'Descargar privilegios de la web
                Dim thread = New Thread(New ThreadStart(AddressOf fn_SincronizarPrivilegios_aLocal))
                thread.Start()
            End If
        End If

        'LLena Usuarios en ListBox
        Call fn_Usuarios_LlenarLista(lst_Usuarios)

        '--------------------------------------
        'consultar privilegios de usuario logueado y almacenarlos en una vector
        Call fn_PrivilegiosAsignados_LlenarListaArray(listaoriginal, varPub.UsuarioClave)
        '--------------------------------------

        pnl_General.Enabled = True
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lst_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_Usuarios.SelectedIndexChanged
        If lst_Usuarios.SelectedItems.Count > 0 Then

            'llena lista Privilegios Generales a Listbox si es Admin o local
            Call fn_Privilegios_LlenarLista(lst_Privilegios, lst_Usuarios.SelectedValue.ToString.Split("/")(1))

            'llena lista Privilegios Asignados DE ESE USUARIO a Listbox
            Call PrivilegiosAsignados_LlenarListBox()

            lst_Privilegios.SelectedIndex = -1
            lbl_Privilegios.Text = "Total Privilegios: " & lst_Privilegios.Items.Count

            Call DeseleccionaPrivilegiosAsig()
        End If
    End Sub

    Private Sub lst_Privilegios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_Privilegios.SelectedIndexChanged
        If lst_Privilegios.SelectedItems.Count > 0 Then
            If lst_Privilegios.SelectedItems.Count > 1 Then
                btn_AgregarUno.Enabled = True
                btn_AgregarTodo.Enabled = False
            Else
                btn_AgregarTodo.Enabled = True
                btn_AgregarUno.Enabled = True
            End If
        Else
            btn_AgregarTodo.Enabled = False
            btn_AgregarUno.Enabled = False
        End If
    End Sub

    Private Sub lst_PrivilegiosAsig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_PrivilegiosAsig.SelectedIndexChanged

        If lst_PrivilegiosAsig.SelectedItems.Count > 0 Then
            If lst_PrivilegiosAsig.SelectedItems.Count > 1 Then
                btn_QuitarUno.Enabled = True
                btn_QuitarTodo.Enabled = False
            Else
                'verificar que no pueda eliminarse opcion '14=Privilegios' si es usuario Logueado
                If CInt(lst_Usuarios.SelectedValue.ToString.Split("/")(0)) = varPub.UsuarioClave AndAlso _
                    lst_PrivilegiosAsig.SelectedValue = "14" Then
                    btn_QuitarUno.Enabled = False
                    btn_QuitarTodo.Enabled = False
                Else
                    btn_QuitarTodo.Enabled = True
                    btn_QuitarUno.Enabled = True
                End If
            End If
        Else
            btn_QuitarUno.Enabled = False
            btn_QuitarTodo.Enabled = False
        End If
    End Sub

    Private Sub btn_AgregarUno_Click(sender As Object, e As EventArgs) Handles btn_AgregarUno.Click
        varPub.SegundosSesion = 0
        Dim Existe As Boolean = False

        If lst_Privilegios.SelectedItems.Count <> 0 Then
            For Each viewPriv As DataRowView In lst_Privilegios.SelectedItems
                Existe = False
                'Al agregar, Buscar si ya existe ----
                For Each viewPrivAsig As DataRowView In lst_PrivilegiosAsig.Items

                    If viewPriv(lst_Privilegios.ValueMember).ToString = viewPrivAsig(0).ToString Then
                        Existe = True
                        Call fn_MsgBox("La opción ya existe en la lista.", MessageBoxIcon.Exclamation, True, 1)
                        Exit For
                    End If
                Next
                If Not Existe Then
                    Call fn_AgregaPrivilegios(viewPriv(lst_Privilegios.ValueMember), lst_Usuarios.SelectedValue)
                    Call PrivilegiosAsignados_LlenarListBox()
                End If
            Next

        End If

        '-----------new
        lst_Privilegios.SelectedIndex = -1
        Call DeseleccionaPrivilegiosAsig()
    End Sub

    Private Sub btn_AgregarTodo_Click(sender As Object, e As EventArgs) Handles btn_AgregarTodo.Click
        varPub.SegundosSesion = 0

        Call fn_AgregaPrivilegios("T", lst_Usuarios.SelectedValue)
        Call PrivilegiosAsignados_LlenarListBox()

        lst_Privilegios.SelectedIndex = -1
        Call DeseleccionaPrivilegiosAsig()
    End Sub

    Private Sub btn_QuitarUno_Click(sender As Object, e As EventArgs) Handles btn_QuitarUno.Click
        varPub.SegundosSesion = 0
        '---------------------
        If lst_PrivilegiosAsig.SelectedItems.Count <> 0 Then
            For Each viewPrivAsig As DataRowView In lst_PrivilegiosAsig.SelectedItems

                If (CInt(lst_Usuarios.SelectedValue.ToString.Split("/")(0)) = varPub.UsuarioClave AndAlso _
                   viewPrivAsig(0) = "14") = False Then
                    Call fn_BorrarPrivilegios(viewPrivAsig(lst_Privilegios.ValueMember), lst_Usuarios.SelectedValue)
                    Call PrivilegiosAsignados_LlenarListBox()
                End If
            Next

        End If
        '------------------------

        Call DeseleccionaPrivilegiosAsig()
    End Sub

    Private Sub btn_QuitarTodo_Click(sender As Object, e As EventArgs) Handles btn_QuitarTodo.Click
        varPub.SegundosSesion = 0

        Call fn_BorrarPrivilegios("T", lst_Usuarios.SelectedValue)
        Call PrivilegiosAsignados_LlenarListBox()

        Call DeseleccionaPrivilegiosAsig()
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Call fn_PrivilegiosAsignados_LlenarListaArray(listaModificada, varPub.UsuarioClave)

        If listaModificada IsNot Nothing Then
            Dim Diferencia
            Dim Cambios As Boolean = False

            If listaoriginal.Count < listaModificada.Count Then
                Diferencia = listaModificada.Except(listaoriginal)
            Else
                Diferencia = listaoriginal.Except(listaModificada)
            End If

            For Each name As String In Diferencia
                Cambios = True
                Exit For
            Next
            If Cambios Then
                'Cerrar Sesion porque Si hubo cambio de privilegios
                Call CierraModales()
                Exit Sub
            End If

        End If

        Me.Close()
    End Sub

    Private Sub lst_Usuarios_Click(sender As Object, e As EventArgs) Handles lst_Usuarios.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_Privilegios_Click(sender As Object, e As EventArgs) Handles lbl_Privilegios.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_PrivilegiosAsig_Click(sender As Object, e As EventArgs) Handles lbl_PrivilegiosAsig.Click
        varPub.SegundosSesion = 0
    End Sub


End Class