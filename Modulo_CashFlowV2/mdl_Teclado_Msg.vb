Module mdl_Teclado_Msg

#Region "Teclado"

    Public ctrlTeclado As kbcustom.Tecladocontrol = New kbcustom.Tecladocontrol
    Private _tbx As Control

    Public forma_teclado As New kbcustom.Tecladocontrol.TipoTeclado

    Public WriteOnly Property Teclado_RecibirControl(Optional ByVal tbx As Control = Nothing) As Boolean
        Set(ByVal value As Boolean)

            RemoveHandler ctrlTeclado.Letrapasada, AddressOf Recibir_TeclaPresionada
            If value Then
                _tbx = tbx
                AddHandler ctrlTeclado.Letrapasada, AddressOf Recibir_TeclaPresionada
            Else
                _tbx = Nothing
            End If
        End Set
    End Property

    Private Sub Recibir_TeclaPresionada(ByVal teclaPresionada As String)
        If _tbx Is Nothing Then Exit Sub
        _tbx.Focus()
        SendKeys.Send(teclaPresionada)
    End Sub

#End Region


#Region "Mensaje Personalizado"

    Public Function fn_MsgBox(ByVal Mensaje As String, ByVal Icono As MessageBoxIcon, Optional ByVal Poner_Timer As Boolean = True, Optional ByVal Tiempo_Timer As Int16 = 5, Optional ByVal btnAceptarVisible As Boolean = False, Optional ByVal btnCancelarVisible As Boolean = False) As Boolean
        Try
            varPub.Resp = False
            Dim frm As New frm_Mensaje
            varPub.SegundosReceptor = 0
            varPub.SegundosSesion = 0
            Select Case Icono

                Case MessageBoxIcon.Asterisk, MessageBoxIcon.Information
                    frm.pct_Icono.Image = My.Resources.information_128

                Case MessageBoxIcon.Error, MessageBoxIcon.Stop, MessageBoxIcon.Hand
                    frm.pct_Icono.Image = My.Resources.error_128

                Case MessageBoxIcon.Exclamation, MessageBoxIcon.Warning
                    frm.pct_Icono.Image = My.Resources.warning_128

                Case MessageBoxIcon.None
                    frm.pct_Icono.Image = Nothing

                Case MessageBoxIcon.Question
                    frm.pct_Icono.Image = My.Resources.question_128
            End Select

            If varPub.TamañoFuente_Mensajes <> 0 Then
                frm.lbl_Mensaje.Font = New Font("", varPub.TamañoFuente_Mensajes)
            End If

            frm.btn_Aceptar.Font = New Font("", varPub.TamañoFuente_Botones)
            frm.btn_Cancelar.Font = New Font("", varPub.TamañoFuente_Botones)
            frm.btn_Cancelar.Visible = btnCancelarVisible
            frm.btn_Aceptar.Visible = btnAceptarVisible
            frm.lbl_Mensaje.Text = Mensaje
            frm.tmr_Mensaje.Enabled = Poner_Timer
            If Poner_Timer Then
                If Tiempo_Timer = 0 Then Tiempo_Timer = 5
                frm.tmr_Mensaje.Interval = (Tiempo_Timer * 1000)
            End If

            frm.ShowDialog()
            varPub.SegundosReceptor = 0
            varPub.SegundosSesion = 0
            Return varPub.Resp
           Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

End Module
