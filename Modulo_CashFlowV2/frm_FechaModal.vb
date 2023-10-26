Imports Modulo_CashFlowV2.cls_CashFlow
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class frm_FechaModal

    Public Fecha As Date
    Dim str_fecha() As String

    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub

    Private Sub frm_FechaModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 27
        varPub.SegundosSesion = 0
        Call CambiarTamanodelosControles()
        btn_FechaAceptar.Font = New Font(New FontFamily("Arial"), varPub.TamañoFuente_Botones + 6)

        btn_FechaAceptar.Text = Fecha.Date
        str_fecha = btn_FechaAceptar.Text.Split("/")

        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)

    End Sub

    Private Sub pnl_Fecha_Click(sender As Object, e As EventArgs) Handles pnl_Fecha.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_DiaUp_Click(sender As Object, e As EventArgs) Handles btn_DiaUp.Click
        If CInt(str_fecha(0)) = 31 Then str_fecha(0) = 0

        str_fecha(0) += 1
        str_fecha(0) = (fn_RellenarCadena(str_fecha(0), 2, "0", strPosicion.Izquierda))
        str_fecha(1) = (fn_RellenarCadena(str_fecha(1), 2, "0", strPosicion.Izquierda))
        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)
    End Sub

    Private Sub btn_MesUp_Click(sender As Object, e As EventArgs) Handles btn_MesUp.Click
        If CInt(str_fecha(1)) = 12 Then str_fecha(1) = 0

        str_fecha(1) += 1
        str_fecha(0) = (fn_RellenarCadena(str_fecha(0), 2, "0", strPosicion.Izquierda))
        str_fecha(1) = (fn_RellenarCadena(str_fecha(1), 2, "0", strPosicion.Izquierda))
        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)
    
    End Sub

    Private Sub btn_YearUp_Click(sender As Object, e As EventArgs) Handles btn_YearUp.Click
        str_fecha(2) += 1
        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)

    End Sub

    Private Sub btn_FechaAceptar_Click(sender As Object, e As EventArgs) Handles btn_FechaAceptar.Click
        If Not DateTime.TryParse(btn_FechaAceptar.Text.Trim, Fecha) Then
            Call fn_MsgBox("La fecha capturada no es válida,", MessageBoxIcon.Error)
            Exit Sub
        End If

        Fecha = CDate(btn_FechaAceptar.Text.Trim)

        Me.Close()
    End Sub

    Private Sub btn_DiaDown_Click(sender As Object, e As EventArgs) Handles btn_DiaDown.Click
        If CInt(str_fecha(0)) = 1 Then str_fecha(0) = 32

        str_fecha(0) -= 1
        str_fecha(0) = (fn_RellenarCadena(str_fecha(0), 2, "0", strPosicion.Izquierda))
        str_fecha(1) = (fn_RellenarCadena(str_fecha(1), 2, "0", strPosicion.Izquierda))
        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)

    End Sub

    Private Sub btn_MesDown_Click(sender As Object, e As EventArgs) Handles btn_MesDown.Click
        If CInt(str_fecha(1)) = 1 Then str_fecha(1) = 13

        str_fecha(1) -= 1
        str_fecha(0) = (fn_RellenarCadena(str_fecha(0), 2, "0", strPosicion.Izquierda))
        str_fecha(1) = (fn_RellenarCadena(str_fecha(1), 2, "0", strPosicion.Izquierda))
        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)
    End Sub

    Private Sub btn_YearDown_Click(sender As Object, e As EventArgs) Handles btn_YearDown.Click
        str_fecha(2) -= 1
        btn_FechaAceptar.Text = str_fecha(0) & "  /  " & str_fecha(1) & "  /  " & str_fecha(2)

    End Sub
End Class