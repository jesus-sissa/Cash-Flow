Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class frm_Tablas
    Private Sub CambiarTamanodelosControles()
        fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub frm_CatalogoCaset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        varPub.SegundosSesion = 0
        Call CambiarTamanodelosControles()

        lsv_Tablas.Columns.Add("Tablas", 200)
        lsv_Tablas.Columns.Add("Descripcion", 300)

        Dim Elementos(0) As ListViewItem

        Dim Tablas() As String = {"Cajas", "Casets", "Corte", "DepositosD", "Privilegios", "RetirosD", "Usuarios", "Cerraduras", "Correos"}

        For i As Integer = 0 To Tablas.Length - 1

            Elementos(i) = New ListViewItem(Tablas(i))

            ReDim Preserve Elementos(i + 1)
            lsv_Tablas.Items.Add(Elementos(i))
        Next
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub lsv_Tablas_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lsv_Tablas.ItemChecked
        varPub.SegundosSesion = 0
        If e.Item.Text.ToUpper = "DEPOSITOSD" Then
            For Each Elemento As ListViewItem In lsv_Tablas.Items
                If Elemento.Text.ToUpper = "DEPOSITOS" Then Elemento.Checked = e.Item.Checked
            Next
        ElseIf e.Item.Text.ToUpper = "DEPOSITOS" Then
            For Each Elemento As ListViewItem In lsv_Tablas.Items
                If Elemento.Text.ToUpper = "DEPOSITOSD" Then Elemento.Checked = e.Item.Checked
            Next
        ElseIf e.Item.Text.ToUpper = "RETIROSD" Then
            For Each Elemento As ListViewItem In lsv_Tablas.Items
                If Elemento.Text.ToUpper = "RETIROS" Then Elemento.Checked = e.Item.Checked
            Next
        ElseIf e.Item.Text.ToUpper = "RETIROS" Then
            For Each Elemento As ListViewItem In lsv_Tablas.Items
                If Elemento.Text.ToUpper = "RETIROSD" Then Elemento.Checked = e.Item.Checked
            Next
          ElseIf e.Item.Text.ToUpper = "CERRADURAS" Then
            For Each Elemento As ListViewItem In lsv_Tablas.Items
                If Elemento.Text.ToUpper = "CERRADURAS" Then Elemento.Checked = e.Item.Checked
            Next
          ElseIf e.Item.Text.ToUpper = "CORREOS" Then
            For Each Elemento As ListViewItem In lsv_Tablas.Items
                If Elemento.Text.ToUpper = "CORREOS" Then Elemento.Checked = e.Item.Checked
            Next
        End If

    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        CheckForIllegalCrossThreadCalls = False
        varPub.SegundosSesion = 0
        Dim NombreTabla As String = ""
        Dim Status As Integer = 0
        Dim Descripcion As String = ""

        For Each Elementos As ListViewItem In lsv_Tablas.CheckedItems


            Select Case Elementos.Text.ToUpper

                Case "CAJAS"
                    Status = fn_Cajas_Borrar(Descripcion)

                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Cajas se limpió correctamente")
                        varPub.Cantidad_Cajas = 0
                    End If
                Case "CASETS"
                    Status = 0
                    Status = fn_Casets_Borrar(Descripcion)

                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Casets se limpió correctamente")
                        varPub.CasetID = 0
                        varPub.Serie_Caset1 = ""
                        varPub.Caset2ID = 0
                        varPub.Serie_Caset2 = ""
                        varPub.Capacidad_Actual = 0
                        varPub.Capacidad_Actual2 = 0
                    End If
                Case "CORTE"
                    Status = 0
                    Status = fn_Corte_Borrar(Descripcion)

                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Corte se limpió correctamente")
                        varPub.CorteActual = 0
                    End If

                Case "DEPOSITOSD"
                    Status = 0
                    Status = fn_DepositosD_Borrar(Descripcion)

                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla DepositosD se limpió correctamente")
                        varPub.ID_DepositoP = 0
                    End If

                Case "PRIVILEGIOS"
                    Status = 0
                    Status = fn_Privilegios_Borrar(Descripcion)


                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Privilegios se limpió correctamente")
                    End If

                Case "RETIROSD"

                    Status = 0
                    Status = fn_RetirosD_Borrar(Descripcion)


                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Privilegios se limpió correctamente")
                        varPub.ID_UltimoRetiro = 0
                    End If

                Case "CERRADURAS"

                    Status = 0
                    Status = fn_Cerradura_Borrar(Descripcion)


                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Cerradura se limpió correctamente")
                        varPub.ID_UltimoRetiro = 0
                    End If

                 Case "CORREOS"

                    Status = 0
                    Status = fn_Correos_Borrar(Descripcion)


                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Correos se limpió correctamente")
                        varPub.ID_UltimoRetiro = 0
                    End If


                Case "USUARIOS"

                    Status = 0
                    Status = fn_Usuarios_Borrar(Descripcion)


                    If Status = -1 Or Status = -2 Then
                        Call PintarListaTablas(Elementos, Status, Descripcion)
                    ElseIf Status = 1 Then
                        Call PintarListaTablas(Elementos, Status, "La Tabla Usuarios se limpió correctamente")
                    End If
            End Select
        Next

        Dim Persistente As cls_VariablesPersistentes = New cls_VariablesPersistentes
        If Persistente.Existe Then
            Persistente.Persistir()
            Persistente.Cargar()
        End If



        'ERROR NO CONTROLADO 
        'ELIMINAR DIRECTORIO DE LOGS (ARCHIVO -> TXT)

       'If System.IO.Directory.Exists(varPub.Ruta_Log) Then
       '     My.Computer.FileSystem.DeleteDirectory(varPub.Ruta_Log, FileIO.DeleteDirectoryOption.DeleteAllContents)
       ' End If

        lsv_Tablas.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
        btn_Limpiar.Enabled = False

    End Sub

    Private Sub PintarListaTablas(ByRef Elementos As ListViewItem, ByRef Status As Integer, ByRef Descripcion As String)
        If Status = -1 Or Status = -2 Then
            Elementos.ForeColor = Color.Red
            Elementos.SubItems.Add(Descripcion)
        ElseIf Status = 1 Then
            Elementos.ForeColor = Color.Green
            Elementos.SubItems.Add(Descripcion)
        End If
    End Sub
End Class