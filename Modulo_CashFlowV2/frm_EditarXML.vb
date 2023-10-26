Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.Reflection
Imports Newtonsoft.Json
Imports System.Xml

Public Class frm_EditarXML

    '''<summary> Filtro para que sólo se seleccione ciertos tipos de Archivos, Ejemplo: "Documento de Word (*.Doc)|*.Doc|Archivo PDF(*.Pdf)|*.Pdf" </summary>
    Dim gv_tbxPasador As DataGridViewTextBoxCell ' nuevo en V2

    Private Sub frm_EditarXML_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_EditarXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 25

        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = (Me.Height - ctrlTeclado.Height)
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        dgv_Archivos.Columns.Add("Variables", "Variables")
        dgv_Archivos.Columns(0).Width = 230
        dgv_Archivos.Columns(0).ReadOnly = True

        dgv_Archivos.Columns.Add("Valores", "Valores")
        dgv_Archivos.Columns(1).Width = (dgv_Archivos.Width - 250)
        dgv_Archivos.Columns(1).ReadOnly = True
        Dim Response As DataTable = fn_ParametrosGet()
        'Dim Persistente As New cls_VariablesPersistentes()
        Dim Persistente As New Cls_Propiedades
        Dim GetTypeC As Type = Persistente.GetType()
        Dim GetProperties As PropertyInfo() = GetTypeC.GetProperties()
        For Each row As DataColumn In Response.Columns
            For Each oProperty As PropertyInfo In GetProperties
                If row.ColumnName = oProperty.Name Then
                    'oProperty.SetValue(Persistente, Response.Rows(0)(row.ColumnName))
                    dgv_Archivos.Rows.Add(row.ColumnName, Response.Rows(0)(row.ColumnName).ToString)
                End If
            Next
        Next


        dgv_Archivos.Height = (varTecl.AltoPantalla - (ctrlTeclado.Height + 50))

    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
        pnl_General.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub tbx_pasador_TextChanged(sender As Object, e As EventArgs) Handles tbx_pasador.TextChanged
        If gv_tbxPasador Is Nothing Then Exit Sub
        gv_tbxPasador.Value = tbx_pasador.Text
    End Sub

    Private Sub dgv_Archivos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Archivos.CellClick
        varPub.SegundosSesion = 0
        If e.ColumnIndex = 0 Then Exit Sub

        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()

        ' esto es nuevo en v2 ya que no se usa -->Interaction.AppActivate(TituloForm)
        gv_tbxPasador = dgv_Archivos.Rows(e.RowIndex).Cells(1)
        tbx_pasador.Text = gv_tbxPasador.Value

        Teclado_RecibirControl(tbx_pasador) = True
        tbx_pasador.Focus()
    End Sub
    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim Persistente As New cls_VariablesPersistentes()


        Dim Json As String = JsonConvert.SerializeObject(dgv_Archivos.DataSource)

        Dim Response As DataTable = JsonConvert.DeserializeObject(Of DataTable)(Json)
        Dim Persistentee As New Cls_Propiedades()
        Dim GetTypeC As Type = Persistentee.GetType()
        Dim GetProperties As PropertyInfo() = GetTypeC.GetProperties()
        For Each row As DataGridViewRow In dgv_Archivos.Rows
            For Each oProperty As PropertyInfo In GetProperties
                If row.Cells(0).Value.ToString = oProperty.Name Then
                    If IsNumeric(row.Cells(1).Value) Then
                        Select Case oProperty.Name
                            Case "pSerieCaset1"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pSerieCaset2"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pSerieVal1"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pSerieVal2"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pPuerto_Val1"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pPuerto_Val2"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pCve_Sucursal"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pTelefono"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pVersionNvo"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pVersionAnt"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "pCorteActual"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "Id_caj"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                            Case "Plaza"
                                oProperty.SetValue(Persistentee, row.Cells(1).Value)
                                Exit For
                        End Select
                        oProperty.SetValue(Persistentee, CInt(row.Cells(1).Value))
                        Exit For
                    ElseIf oProperty.Name = "pCve_Cliente" Then
                        oProperty.SetValue(Persistentee, row.Cells(1).Value)
                        Exit For
                    ElseIf oProperty.Name = "pComprobacion" Then
                        oProperty.SetValue(Persistentee, row.Cells(1).Value)
                        Exit For
                    ElseIf IsDate((row.Cells(1).Value)) Then
                        oProperty.SetValue(Persistentee, CDate(row.Cells(1).Value))
                        Exit For
                    Else
                        oProperty.SetValue(Persistentee, row.Cells(1).Value)
                        Exit For
                    End If
                    'If TypeOf oProperty.Name Is String Then
                    '    oProperty.SetValue(Persistentee, row.Cells(1).Value)
                    'ElseIf TypeOf oProperty.Name Is Integer Then
                    'End If

                End If
            Next
        Next
        Persistente.Persistir()
        Persistente.Cargar()
        Me.Close()
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub dgv_Archivos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Archivos.CellValueChanged
        Dim SalidaEntera As Integer
        Dim Campo As String = dgv_Archivos.SelectedRows(0).Cells(0).Value.ToString

        If Campo = "pDepositoP" Or Campo = "pUlt_Retiro" Or Campo = "pCmd_Fuente" Or Campo = "pLbl_Fuente" Or Campo = "pMsg_Fuente" Or Campo = "pDias_Expira" Or Campo = "pMargenIZq" Or Campo = "pPorcentaje_Alerta" Or Campo = "pCasetID" Or Campo = "pCapacidad_Actual" Or Campo = "pCapacidad_Caset" Or Campo = "pAlto_Pantalla" Or Campo = "pAncho_Pantalla" Or Campo = "pLimiteCapacidadKct" Or Campo = "pLimiteCapacidadKct2" Then
            If Not Integer.TryParse(dgv_Archivos.SelectedRows(0).Cells(1).Value, SalidaEntera) Then
                MsgBox("Campo no Valido")
                dgv_Archivos.SelectedRows(0).Cells(1).Value = 0
            End If
        End If
    End Sub
End Class