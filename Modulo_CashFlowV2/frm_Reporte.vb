Public Class frm_Reporte
    Dim Fallas As String = Nothing
    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub chk_AtascoBillete_CheckedChanged(sender As Object, e As EventArgs) Handles chk_AtascoBillete.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_AtascoBillete.Checked Then
            chk_AtascoBillete.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_AtascoBillete.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_SistemaLento_CheckedChanged(sender As Object, e As EventArgs) Handles chk_SistemaLento.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_SistemaLento.Checked Then
            chk_SistemaLento.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_SistemaLento.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_NoImprimeRecibo_CheckedChanged(sender As Object, e As EventArgs) Handles chk_NoImprimeRecibo.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_NoImprimeRecibo.Checked Then
            chk_NoImprimeRecibo.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_NoImprimeRecibo.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_NoAceptaBilletes_CheckedChanged(sender As Object, e As EventArgs) Handles chk_NoAceptaBilletes.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_NoAceptaBilletes.Checked Then
            chk_NoAceptaBilletes.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_NoAceptaBilletes.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_CartuchoLleno_CheckedChanged(sender As Object, e As EventArgs) Handles chk_CartuchoLleno.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_CartuchoLleno.Checked Then
            chk_CartuchoLleno.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_CartuchoLleno.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub
    Private Sub chk_FalloPantalla_CheckedChanged(sender As Object, e As EventArgs) Handles chk_FalloPantalla.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_FalloPantalla.Checked Then
            chk_FalloPantalla.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_FalloPantalla.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub

    Private Sub chk_NoDepositar_CheckedChanged(sender As Object, e As EventArgs) Handles chk_NoDepositar.CheckedChanged
        varPub.SegundosSesion = 0
        'Call Limpiar()
        If chk_NoDepositar.Checked Then
            chk_NoDepositar.Image = My.Resources.CheckBox_Checked_24x24
        Else
            chk_NoDepositar.Image = My.Resources.CheckBox_Unchecked_24x24
        End If
    End Sub
    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click

        Dim WsCajero As New WsRemision.WsCashFlowSoapClient
        If Checks() > 0 Then
            If WsCajero.Guardar_Ticket(varPub.Plaza + "%" + Fallas + "%" + varPub.Nombre_Sucursal + "%" + varPub.NombreUser) Then
                Call fn_MsgBox("Reporte enviado correctamente.", MessageBoxIcon.Information, True, 3)
                Me.Close()
            Else
                Call fn_MsgBox("Reporte no pudo ser enviado.", MessageBoxIcon.Information, True, 3)
            End If
        Else
            Call fn_MsgBox("Seleccione alguna opcion", MessageBoxIcon.Information, True, 3)
        End If



    End Sub
    Private Function Checks() As Integer
        Dim count As Integer = 0
        Fallas += varPub.Cliente + Environment.NewLine
        Fallas += "Se reportan las siguientes Fallos en la Sucursal " + varPub.Nombre_Sucursal + ":" + Environment.NewLine
        If chk_AtascoBillete.Checked Then
            Fallas += "-Atasco de Billetes" + Environment.NewLine
            count += 1
        End If
        If chk_SistemaLento.Checked Then
            Fallas += "-Sistema Lento" + Environment.NewLine
            count += 1
        End If
        If chk_NoImprimeRecibo.Checked Then
            Fallas += "-No imprime Recibos" + Environment.NewLine
            count += 1
        End If
        If chk_NoAceptaBilletes.Checked Then
            Fallas += "-No acepta billetes" + Environment.NewLine
            count += 1
        End If
        If chk_CartuchoLleno.Checked Then
            Fallas += "-Cartucho Lleno" + Environment.NewLine
            count += 1
        End If
        If chk_FalloPantalla.Checked Then
            Fallas += "-Fallo de pantalla" + Environment.NewLine
            count += 1
        End If
        If chk_NoDepositar.Checked Then
            Fallas += "-No se puede depositar" + Environment.NewLine
            count += 1
        End If

        Return count
    End Function


End Class