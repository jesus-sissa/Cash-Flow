Imports Modulo_CashFlowV2.cls_CashFlow
Public Class cls_DepositoXValidadorWebS

    Public Event IniciarDeposito(Id_Caja As Integer, Clave_Caja As String)
    'Public Event FinalizarDeposito()
    'Public Event CancerDeposito()

    Private tmr As New Timer ' a traves de este objeto, el cajero escuchará las peticiones del web service
    Private StatusCajero As New Dictionary(Of String, String)

    Public Sub IniciarCajeroConsulta_Status() ' permite al cajero escuchar  las peticiones
        tmr.Interval = 1000
        AddHandler tmr.Tick, AddressOf CajeroConsulta_Status
        tmr.Start()
    End Sub

    Public Sub DetenerCajeroConsulta_Status() ' detiene el modo escucha de las peticiones
        tmr.Stop()
        tmr.Dispose()
    End Sub

    Public Sub CajeroConsulta_Status()

        Dim dt_CajeroStatus As DataTable

        dt_CajeroStatus = fn_Cajero_ConsultaStatus() 'devuelve el estasdo del cajero

        If dt_CajeroStatus.Rows.Count > 0 Then

            If dt_CajeroStatus.Rows(0).Item("Status") = "IN" Then 'verifica el estado del cajero igual a iniciado

                If Not StatusCajero.ContainsKey("K_IN") Then
                    StatusCajero.Add("K_IN", "IN") 'guarda el estado actual del cajero para evitar consultas de transacciones infinitas 

                    Dim dt_Transaccion As DataTable = fn_Transaccion_Consulta() 'obtiene la transacción actual

                    If dt_Transaccion.Rows.Count > 0 Then
                        varPub.UsuarioClave = dt_Transaccion.Rows(0).Item("Clave_Usuario")
                        varPub.Id_Transaccion = dt_Transaccion.Rows(0).Item("Id")
                        varPub.Folio = dt_Transaccion.Rows(0).Item("Folio").ToString
                        Dim dt_Cajas As DataTable = fn_Cajas_Read(CInt(dt_Transaccion.Rows(0).Item("Id_Caja")))
                        If dt_Cajas.Rows.Count > 0 Then
                            RaiseEvent IniciarDeposito(CInt(dt_Transaccion.Rows(0).Item("Id_Caja")), dt_Cajas.Rows(0).Item("Clave_Caja").ToString) ' inicia pantalla dopósitos
                        End If
                    End If
                End If

            End If

            If varPub.DepositoFinalizado Then 'valida si el depósito actual ya fue finalizado  
                If StatusCajero.ContainsKey("K_IN") Then
                    StatusCajero.Clear()
                    varPub.DepositoFinalizado = False ' se le asigna el valor de falso después de finalizar el  depósitos para que el cajero quede en modo escucha
                End If
            End If
        End If
    End Sub
End Class
