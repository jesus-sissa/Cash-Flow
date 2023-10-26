Imports Ccash
Imports MPOST
Public Class frm_Check_Validadores
#Region "Variables"
    '///////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Variables bill acceptors
    ''' </summary>
    Private BillAcceptorMei1 As Acceptor = New Acceptor()
    Private BillAcceptorMei2 As Acceptor = New Acceptor()

    Dim EstadoMEI_V1 As String = ""
    Dim EstadoMEI_V2 As String = ""
    Dim Val1_Conectado As Boolean = False
    Dim Val2_Conectado As Boolean = False

#End Region
#Region "Funciones mei-1"
    ''' <summary>
    ''' variables y Eventos del validador 1
    ''' ConnectedMei1 para saber cuando se ha conectado,
    ''' DisconnectedMei1 pára saber cuando se desconecta,
    ''' BoxMei1Removed para saber cuando se remueve el cartucho
    ''' </summary>
    Private ConnectedMei1 As New ConnectedEventHandler(AddressOf ConnectedEventMei1)

    Private Sub ConnectedEventMei1(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(ConnectedMei1, New Object() {sender, e})
        Else
            pb1.BackColor = Color.Green
            EstadoMEI_V1 = "CORRECTO"
            lbl_val1.ForeColor = Color.Green
            Val1_Conectado = True
        End If
    End Sub

    Private DisconnectedMei1 As New DisconnectedEventHandler(AddressOf DisconnectedEventMei1)

    Private Sub DisconnectedEventMei1(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(DisconnectedMei1, New Object() {sender, e})
        Else
            pb1.BackColor = Color.Red
            EstadoMEI_V1 = "DESCONECTADO"
            lbl_val1.ForeColor = Color.OrangeRed
            Val1_Conectado = False
        End If
    End Sub

    Private BoxMei1Removed As New CashBoxRemovedEventHandler(AddressOf BoxRemovedEventMei1)

    Private Sub BoxRemovedEventMei1(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(BoxMei1Removed, New Object() {sender, e})
        Else
            pb1.BackColor = Color.Yellow
            EstadoMEI_V1 = "REMOVIDO"
            lbl_val1.ForeColor = Color.Orange
        End If
    End Sub
    Private CashBoxMei1Attache As New CashBoxAttachedEventHandler(AddressOf BoxAttacheMei1)

    Private Sub BoxAttacheMei1(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(CashBoxMei1Attache, New Object() {sender, e})
        Else
            pb1.BackColor = Color.Green
            EstadoMEI_V1 = "CORRECTO"
            lbl_val1.ForeColor = Color.Green
        End If
    End Sub
    Private JamDetectedMei1 As New JamDetectedEventHandler(AddressOf JamDetectedMei1Event)

    Private Sub JamDetectedMei1Event(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(JamDetectedMei1, New Object() {sender, e})
        Else
            pb1.BackColor = Color.Orange
            EstadoMEI_V1 = "ATASCO"
            lbl_val1.ForeColor = Color.Orange
        End If
    End Sub
    Private JamClearedMei1 As New JamClearedEventHandler(AddressOf JamClearedMei1Event)

    Private Sub JamClearedMei1Event(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(JamClearedMei1, New Object() {sender, e})
        Else
            pb1.BackColor = Color.Green
            EstadoMEI_V1 = "CORRECTO"
            lbl_val1.ForeColor = Color.Green
        End If
    End Sub

#End Region
#Region "Funciones mei-2"
    ''' <summary>
    ''' Eventos del validador 2
    ''' ConnectedMei1 para saber cuando se ha conectado,
    ''' DisconnectedMei1 pára saber cuando se desconecta,
    ''' BoxMei1Removed para saber cuando se remueve el cartucho
    ''' </summary>
    Private ConnectedMei2 As New ConnectedEventHandler(AddressOf ConnectedEventMei2)

    Private Sub ConnectedEventMei2(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(ConnectedMei2, New Object() {sender, e})
        Else
            pb2.BackColor = Color.Green
            EstadoMEI_V2 = "CORRECTO"
            lbl_val2.ForeColor = Color.Green
            Val2_Conectado = True
        End If
    End Sub

    Private DisconnectedMei2 As New DisconnectedEventHandler(AddressOf DisconnectedEventMei2)

    Private Sub DisconnectedEventMei2(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(DisconnectedMei2, New Object() {sender, e})
        Else
            pb2.BackColor = Color.Red
            EstadoMEI_V2 = "DESCONECTADO"
            lbl_val2.ForeColor = Color.OrangeRed
            Val2_Conectado = False
        End If
    End Sub

    Private BoxMei2Removed As New CashBoxRemovedEventHandler(AddressOf BoxRemovedEventMei2)

    Private Sub BoxRemovedEventMei2(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(BoxMei2Removed, New Object() {sender, e})
        Else
            pb2.BackColor = Color.Yellow
            EstadoMEI_V2 = "REMOVIDO"
            lbl_val2.ForeColor = Color.Orange
        End If
    End Sub
     Private CashBoxMei2Attache As New CashBoxAttachedEventHandler(AddressOf BoxAttacheMei2)

    Private Sub BoxAttacheMei2(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(CashBoxMei2Attache, New Object() {sender, e})
        Else
            pb2.BackColor = Color.Green
            EstadoMEI_V2 = "CORRECTO"
            lbl_val2.ForeColor = Color.Green
        End If
    End Sub
    Private JamDetectedMei2 As New JamDetectedEventHandler(AddressOf JamDetectedMei2Event)

    Private Sub JamDetectedMei2Event(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(JamDetectedMei2, New Object() {sender, e})
        Else
            pb2.BackColor = Color.Orange
            EstadoMEI_V2 = "ATASCO"
            lbl_val2.ForeColor = Color.Orange
        End If
    End Sub
    Private JamClearedMei2 As New JamClearedEventHandler(AddressOf JamClearedMei2Event)

    Private Sub JamClearedMei2Event(sender As Object, e As EventArgs)
        If InvokeRequired Then
            BeginInvoke(JamClearedMei2, New Object() {sender, e})
        Else
            pb2.BackColor = Color.Green
            EstadoMEI_V2 = "CORRECTO"
            lbl_val2.ForeColor = Color.Green
        End If
    End Sub
#End Region
#Region "funciones"
    Public Sub Init_Mei1()
        Try
            AddHandler BillAcceptorMei1.OnConnected, ConnectedMei1
            AddHandler BillAcceptorMei1.OnDisconnected, DisconnectedMei1
            AddHandler BillAcceptorMei1.OnCashBoxRemoved, BoxMei1Removed
            AddHandler BillAcceptorMei1.OnCashBoxAttached, CashBoxMei1Attache
            AddHandler BillAcceptorMei1.OnJamDetected, JamDetectedMei1
            AddHandler BillAcceptorMei1.OnJamCleared, JamClearedMei1
            BillAcceptorMei1.Open("COM" + varPub.Puerto_Val1, PowerUp.A)
            pb1.BackColor = Color.LightGreen
            pb1.Enabled = True
            lbl_val1.Enabled = True
            lbl_val1.BackColor = Color.White
        Catch ex As Exception
            pb1.BackColor = Color.Red
            EstadoMEI_V1 = "ERR CONEXION"
            lbl_val1.ForeColor = Color.Red
        End Try
    End Sub
    Public Sub Init_Mei2()
        Try
            AddHandler BillAcceptorMei2.OnConnected, ConnectedMei2
            AddHandler BillAcceptorMei2.OnDisconnected, DisconnectedMei2
            AddHandler BillAcceptorMei2.OnCashBoxRemoved, BoxMei2Removed
            AddHandler BillAcceptorMei2.OnCashBoxAttached, CashBoxMei2Attache
            AddHandler BillAcceptorMei2.OnJamDetected, JamDetectedMei2
            AddHandler BillAcceptorMei2.OnJamCleared, JamClearedMei2
            BillAcceptorMei2.Open("COM" + varPub.Puerto_Val2, PowerUp.A)
            pb2.BackColor = Color.LightGreen
            pb2.Enabled = True
            lbl_val2.Enabled = True
            lbl_val2.BackColor = Color.White
        Catch ex As Exception
            pb2.BackColor = Color.Red
            EstadoMEI_V2 = "ERR CONEXION"
            lbl_val2.ForeColor = Color.Red
        End Try
    End Sub

#End Region

    Private Sub frm_Check_Validadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm_Login.tmr_SesionGeneral.Stop()
        If varPub.Cant_Validadores = 2 Then
            Init_Mei1()
            Init_Mei2()
        Else
            Init_Mei1()
        End If

        'If varPub.Activar_Val1 Then
        '    pb1.Enabled = True
        '    lbl_val1.Enabled = True
        '    Init_Mei1()
        'Else
        '    pb1.BackColor = Color.Gray
        '    EstadoMEI_V1 = "DESACTIVADO"
        '    lbl_val1.ForeColor = Color.Gray
        'End If
        'If varPub.Activar_Val2 Then
        '    pb2.Enabled = True
        '    lbl_val2.Enabled = True
        '    Init_Mei2()
        'Else
        '    pb2.BackColor = Color.Gray
        '    EstadoMEI_V2 = "DESACTIVADO"
        '    lbl_val2.ForeColor = Color.Gray
        'End If


        DeviceStatus.Start()
        btn_verificar.Enabled = True

    End Sub

    Private Sub btn_verificar_Click(sender As Object, e As EventArgs) Handles btn_verificar.Click

        If Not Val1_Conectado Then
            varPub.Activar_Val1 = 0
        Else
            varPub.Activar_Val1 = 1
        End If

        If Not Val2_Conectado Then
            varPub.Activar_Val2 = 0
        Else
            varPub.Activar_Val2 = 1
        End If
        Dim Persistente As New cls_VariablesPersistentes()
        Persistente.Persistir()
        Call fn_MsgBox("Validadores Verificados correctamente.", MessageBoxIcon.Information)
        frm_Login.tmr_SesionGeneral.Start()
        Me.Close()
    End Sub

    Private Sub DeviceStatusTick(sender As Object, e As EventArgs) Handles DeviceStatus.Tick
        lbl_val1.Text = EstadoMEI_V1.ToString
        lbl_val2.Text = EstadoMEI_V2.ToString
    End Sub

    Private Sub Close_BillAcceptor()
        If BillAcceptorMei1.Connected Then
            BillAcceptorMei1.Close()

        End If
        If BillAcceptorMei2.Connected Then
            BillAcceptorMei2.Close()
        End If
    End Sub
    Private Sub frm_Check_Validadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Close_BillAcceptor()
    End Sub

    Private Sub frm_Check_Validadores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Close_BillAcceptor()
    End Sub
End Class