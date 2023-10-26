Imports System.Net.Mail
Imports System.Text.Encoding
Imports System.Net

Imports Modulo_CashFlowV2.cls_CashFlow

Public Class cls_Correo

    Public Shared Function MandarCorreo(ByVal Descripcion As String,
                                        Optional ByVal Asunto As String = "",
                                        Optional ByVal Clave_Usuario As String = "",
                                        Optional ByVal Usuario As String = "Nadie") As Boolean
        Try
            Dim Correo As New MailMessage
            Dim Smtp As New SmtpClient
            Dim Sesion As Boolean

            Correo.From = New MailAddress("alertas.cajeros@sissaseguridad.com", "CAJERO INTELIGENTE", UTF8)

            Dim Dt As DataTable = fn_Correos_Consulta()
            If Dt.Rows.Count = 0 Or Dt Is Nothing Then
                cls_FuncionesPublicas.fn_EscribirLog(varPub.UsuarioClave, "Correos", "SIN CORREOS PARA ENVIAR.")
                Return False
                Exit Function
            End If

            For Each Row As DataRow In Dt.Rows
                'Dim Correos As String = Row("Correo") Para saber el nombre de cada correo
                Correo.To.Add(CStr(Row("Correo")))
            Next

            Correo.Subject = "Cajero Inteligente, " & Asunto
            Correo.SubjectEncoding = UTF8

            For Each Frm As Form In Application.OpenForms
                If Frm.Name = "frm_MenuGeneral" Then
                    Sesion = True
                End If
            Next


            If Sesion Then
                Correo.Body = "ATENCIÓN : <br/>" &
                Descripcion & "<br/>" &
                "Esto en la sucursal " & varPub.Cliente & " - " & varPub.Nombre_Sucursal & "<br/>" &
                varPub.UsuarioClave.ToString & " - " & varPub.NombreUser & " estuvo utilizando el sistema en ese momento" & " <br/>" &
                "Con la fecha de " & Date.Today.ToShortDateString & " de las " & System.DateTime.Now.ToLongTimeString & "<br/>" &
                "Saludos y buen día."

            Else

                Correo.Body = "ATENCIÓN : <br/>" &
                Descripcion & "<br/>" &
                "Esto en la sucursal " & varPub.Cliente & " - " & varPub.Nombre_Sucursal & "<br/>" &
                "Nadie estuvo utilizando el sistema en ese momento" & " <br/>" &
                "Con la fecha de " & Date.Today.ToShortDateString & " de las " & System.DateTime.Now.ToLongTimeString & "<br/>" &
                "Saludos y buen día."
            End If

            Correo.IsBodyHtml = True
            Correo.BodyEncoding = UTF8
            Correo.Priority = MailPriority.High
            '------------------------------------------------------
            Smtp.Credentials = New NetworkCredential("alertas.cajeros@sissaseguridad.com", "Pass.010")
            Smtp.Port = 587
            Smtp.Host = "mail.sissaseguridad.com"
            Smtp.UseDefaultCredentials = False
            Smtp.Send(Correo)

            If Not IsNothing(ctrlTeclado) Then
                If Not ctrlTeclado.InvokeRequired Then
                    ctrlTeclado.Hide()
                End If
            End If

            cls_FuncionesPublicas.fn_EscribirLog(varPub.UsuarioClave, "CORREO", "CORREO ENVIADO CORRECTAMENTE.")
            fn_MsgBox("Correo enviado correctamente.", MessageBoxIcon.Exclamation, False)

            Return True
        Catch ex As Exception
            fn_MsgBox("Es posible que algunos correos lleguen como SPAM. ", MessageBoxIcon.Information, False)
            cls_FuncionesPublicas.fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 78, varPub.IdPantalla, "Correos " + " FIN - ERROR AL CONSULTAR LOS CORREOS: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function EnviarCorreo(ByVal Descripcion As String,
                                        Optional ByVal Asunto As String = "",
                                        Optional ByVal Clave_Usuario As String = "",
                                        Optional ByVal Usuario As String = "Nadie") As Boolean

        Dim smtp As New System.Net.Mail.SmtpClient
        Dim correo As New System.Net.Mail.MailMessage

        Try
            Dim Dt As DataTable = fn_Correos_Consulta()
            If Dt.Rows.Count = 0 Or Dt Is Nothing Then
                cls_FuncionesPublicas.fn_EscribirLog(varPub.UsuarioClave, "CORREOS", "SIN CORREOS PARA ENVIAR.")
                Return False
                Exit Function
            End If

            For Each Row As DataRow In Dt.Rows
                correo.To.Add(CStr(Row("Correo")))
            Next

            With smtp
                .Port = 587
                .Host = "mail.sissaseguridad.com"
                .Credentials = New System.Net.NetworkCredential("alertas.cajeros@sissaseguridad.com", "Pass.010")
                .EnableSsl = False
            End With

            With correo
                .From = New System.Net.Mail.MailAddress("alertas.cajeros@sissaseguridad.com")
                ''.To.Add("cajeros.inteligentes@sissaseguridad.com")
                '.Subject = "IGNORAR ESTE EMAIL PRUEBA DE SISTEMAS - ATASCO EN LA SUCURSAL PRUEBA SISSA"
                .Subject = Asunto & " - CAJERO INTELIGENTE"
                .SubjectEncoding = UTF8

                .Body = "<strong>ATASCO EN SUCURSAL: </strong> <br/>" &
                Descripcion & "<br/>" &
                "Esto en la sucursal " & varPub.Cliente & " - " & varPub.Nombre_Sucursal & "<br/>" &
                "ID del usuario: <strong>" & varPub.UsuarioClave.ToString & "</strong> - " & "El usuario: <strong>" & varPub.NombreUser & "</strong> estuvo utilizando el sistema en ese momento" & " <br/>" &
                "Con la fecha de " & Date.Today.ToShortDateString & " de las " & System.DateTime.Now.ToLongTimeString & "<br/>" &
                "Saludos y buen día."
                .IsBodyHtml = True
                .Priority = System.Net.Mail.MailPriority.High

                '.Attachments.Add(adjunto)
            End With


            smtp.Send(correo)

            If Not IsNothing(ctrlTeclado) Then
                If Not ctrlTeclado.InvokeRequired Then
                    ctrlTeclado.Hide()
                End If
            End If
            cls_FuncionesPublicas.fn_EscribirLog(varPub.UsuarioClave, "CORREO", "CORREO ENVIADO CORRECTAMENTE.")
            Return True
        Catch ex As Exception
            fn_MsgBox("Es posible que algunos correos lleguen como SPAM.", MessageBoxIcon.Information, False)
            cls_FuncionesPublicas.fn_AddLog(varPub.Id_Caje, varPub.UsuarioClave, varPub.Cve_Sucursal, 78, varPub.IdPantalla, "CORREOS " + " FIN - ERROR AL CONSULTAR LOS CORREOS: " & ex.Message)
            Return False
        End Try
        Return True
    End Function
End Class
