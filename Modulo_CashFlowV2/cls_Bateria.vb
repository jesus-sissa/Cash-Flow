Imports Modulo_CashFlowV2.cls_Correo
Imports System.Reflection
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Public Class cls_Bateria
Private BateriaBaja As Boolean
Private BateriaCritica As Boolean
Private SesionIniciada As Boolean
Private Conectividad As Boolean

Sub New(_SesionIniciada As Boolean, _BateriaBaja As Boolean, _BateriaCritica As Boolean)
BateriaBaja = _BateriaBaja
BateriaCritica = _BateriaCritica
SesionIniciada = _SesionIniciada
End Sub
   'JAVIER ZAPATA 16/10/2018
   Public Sub Bateria()

   'Creamos una variable tipo type de la clase POWERSTATUS(Información actual del estado de alimentación)
   Dim Estado As Type = GetType(PowerStatus)

   'Creamos un arreglo llamado Propiedades que contendrá las propiedadesque tiene ahor "Estado"
   '(0) PoweLineStatus --Proporciona el estado de la conectividad                              
   '(3) Single BatteryLifePercent    
   Dim Propiedades As PropertyInfo() = Estado.GetProperties

   'para saber el nivel de carga apuntamos a la propiedad 3 y se lo asignamos a la variable "Carga"
   Dim Carga As PropertyInfo = Propiedades(3)

   'Object soporta todas las clases de la jerarquía .net, por tanto al no saber el tipo de dato que nos arojará
   'utilizamos la función GetValue que nos devuelve el valor de propiedad del objeto especificado
   Dim Valor As Object = Carga.GetValue(SystemInformation.PowerStatus, Nothing)

   'Si queremos saber el estado actual de conectado apuntamos a la propiedad 0 
   Dim Conectado As PropertyInfo = Propiedades(0)

   'El nothing representa el valor predeterminado del tipo de dato Object
   'El valor de la propiedad puede ser
   '0-Desconectado
   '1-Conectado
   Dim Conexion As Object = Conectado.GetValue(SystemInformation.PowerStatus, Nothing)

     If Conexion = 1 Then
      varPub.BateriaBaja = False
      varPub.BateriaCritica = False
    Else
       If varPub.BateriaCritica = False Then
         If Valor * 100 < varPub.PorcentajeBateriaCritica Then
        varPub.BateriaCritica = True
         If Not IsNothing(ctrlTeclado) Then
            If Not ctrlTeclado.InvokeRequired Then
              ctrlTeclado.Hide()
            End If
         End If
                    fn_MsgBox("UPS sin batería, Apagando el equipo.", MessageBoxIcon.Information, False)

                    If varPub.Conectividad Then
           If cls_CashFlow.fn_VerificaConexionInternet Then
              Conectividad = True
           End If
        End If

      If SesionIniciada = True Then
         Call fn_EscribirLog(varPub.UsuarioClave, "APAGANDO EQUIPO", "EL CAJERO FUE UTILIZADO POR: " & varPub.UsuarioClave & ": " & varPub.NombreUser)
                        Conectividad = MandarCorreo("UPS sin batería, Apagando el equipo", "Batería UPS", varPub.UsuarioClave, varPub.NombreUser)
                    Else
         Call fn_EscribirLog(0, "SE APAGÓ EL CAJERO", "LA BATERÍA CRÍTICA DEL UPS LLEGÓ A SU LIMITE")
                        Conectividad = MandarCorreo("UPS sin batería, Apagando el equipo", "Batería UPS")
                    End If

'Recorre los formularios abiertos y los cierra uno por uno, después apaga el equipo

'''''''''''''''
                    Dim TotalModal As Integer = Application.OpenForms.Count - 1  '-1 porque Empieza en 0 a N
                    For contador As Byte = 0 To TotalModal '
                        If Application.OpenForms(TotalModal).Modal OrElse Not (Application.OpenForms(TotalModal).Modal) Then
                            Application.OpenForms(TotalModal).Close()
                            TotalModal -= 1
                        End If
                    Next
                    Shell("cmd.exe /kshutdown -s ")
                    Exit Sub

'''''''''''''''''
               Exit Sub
'Si el porcentaje de batería está entre la batería baja y la crítica muestra el mensaje 
        ElseIf Valor * 100 < varPub.PorcentajeBateriaBaja And Valor * 100 > varPub.PorcentajeBateriaCritica Then

       If varPub.Conectividad Then
         If cls_CashFlow.fn_VerificaConexionInternet Then
           Conectividad = True
         End If
       End If

            If varPub.BateriaBaja = False Then
             varPub.BateriaBaja = True
                     If Not IsNothing(ctrlTeclado) Then
                       If Not ctrlTeclado.InvokeRequired Then
                          ctrlTeclado.Hide()
                       End If
                     End If

                        fn_MsgBox("El UPS cuenta con poca batería, apagar inmediatamente.", MessageBoxIcon.Information, False)

                        If SesionIniciada = True Then
      Call fn_EscribirLog(varPub.UsuarioClave, "BATERÍA BAJA", "EL MENSAJE FUE VISTO POR : " & varPub.UsuarioClave & ": " & varPub.NombreUser)
     End If


   If Conectividad And SesionIniciada Then
                            MandarCorreo("El UPS cuenta con poca batería, apagar inmediatamente", "UPS Batería", varPub.UsuarioClave, varPub.NombreUser)
                            Exit Sub

    ElseIf Conectividad And SesionIniciada = False Then
                            MandarCorreo("El UPS cuenta con poca batería, apagar inmediatamente", "UPS Batería", "5959")
                            Exit Sub
    End If

           End If
         End If
        End If
    End If

End Sub
End Class


