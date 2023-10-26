Imports System.Management
Imports System.Net
Imports System.Text.RegularExpressions
Imports Modulo_CashFlowV2.cls_CashFlow

Public Class frm_CambiarIP

#Region "Cambiar IP"

    Private Sub ListarConexiones()
        Try

            Dim objMC As New ManagementClass("Win32_NetworkAdapter")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances

            Dim item As ListViewItem
            Dim Nombre As String = ""
            Dim Tag As String = ""
            Dim Dispositivo As String = ""
            Dim Estatus As String = ""
            Dim TipoEstatus As Int16 = 0
            Dim ImagenIndice As Int16 = 0
            Dim AdapterTypeID As Int16 = 0

            lbl_Dispositivo.Text = ""
            lbl_Dispositivo.Tag = ""


            lsv_Conexiones.Items.Clear()
            For Each objMO As ManagementObject In objMOC

                If objMO.Properties("NetEnabled").Value Is Nothing Then Continue For

                Nombre = objMO.Properties("NetConnectionID").Value
                Tag = objMO.Properties("Caption").Value
                Dispositivo = objMO.Properties("Name").Value
                TipoEstatus = objMO.Properties("NetConnectionStatus").Value
                AdapterTypeID = objMO.Properties("AdapterTypeID").Value

                Select Case TipoEstatus
                    Case 0
                        Estatus = "Disconnected"
                    Case 1
                        Estatus = "Connecting"
                    Case 2
                        Estatus = "Connected"
                    Case 3
                        Estatus = "Disconnecting"
                    Case 4
                        Estatus = "Hardware Not Present"
                    Case 5
                        Estatus = "Hardware Disabled"
                    Case 6
                        Estatus = "Hardware Malfunction"
                    Case 7
                        Estatus = "Media Disconnected"
                    Case 8
                        Estatus = "Authenticating"
                    Case 9
                        Estatus = "Authentication Succeeded"
                    Case 10
                        Estatus = "Authentication Failed"
                    Case 11
                        Estatus = "Invalid Address"
                    Case 12
                        Estatus = "Credentials Required"
                    Case Else
                        Estatus = "Other"
                End Select
                item = New ListViewItem

                If Nombre.ToUpper = "ETHERNET" And TipoEstatus = 7 Then
                    item.ImageIndex = 4 'media desconectado(cable desconectado)
                ElseIf Nombre.ToUpper = "ETHERNET" And TipoEstatus = 2 Then
                    item.ImageIndex = 2 'conectado
                ElseIf Nombre.ToUpper = "ETHERNET" And TipoEstatus = 0 Then
                    item.ImageIndex = 0 'Deshabilitado
                ElseIf Nombre.ToUpper = "WI-FI" And TipoEstatus = 2 Then
                    item.ImageIndex = 3 'conectado
                ElseIf Nombre.ToUpper = "WI-FI" And TipoEstatus = 0 Then
                    item.ImageIndex = 1 'Deshabilitado
                ElseIf Nombre.ToUpper = "WI-FI" And TipoEstatus = 7 Then
                    item.ImageIndex = 5 'media desconectado(antena desconectado)
                Else
                    item.ImageIndex = 2 ' otro=2
                End If

                item.Text = Nombre
                item.Tag = Tag
                item.SubItems.Add(Dispositivo)
                item.SubItems.Add(Estatus)
                lsv_Conexiones.Items.Add(item)
            Next

        Catch ex As Exception
            fn_MsgBox("Ocurrió un error al mostrar dispositivos de red.", MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub MostrarDatos(ByVal Nic As String)
        Try

            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()
            Dim prop As String()

            For Each objMO As ManagementObject In objMOC
                If objMO.Properties("Caption").Value = Nic Then


                    If CBool(objMO("DHCPEnabled")) Then
                        rbn_IpAutomatica.Checked = True
                        rbn_IpManual.Image = My.Resources.RadioButton_UnChecked_24x24
                        rbn_IpAutomatica.Image = My.Resources.RadioButton_Checked_24x24
                    Else

                        rbn_IpManual.Checked = True
                        rbn_IpAutomatica.Image = My.Resources.RadioButton_UnChecked_24x24
                        rbn_IpManual.Image = My.Resources.RadioButton_Checked_24x24

                        prop = objMO.Properties("IPAddress").Value
                        If prop Is Nothing OrElse prop.Length = 0 Then
                            tbx_IP.Text = ""
                        Else
                            tbx_IP.Text = objMO.Properties("IPAddress").Value(0)
                        End If

                        prop = objMO.Properties("IPSubnet").Value
                        If prop Is Nothing OrElse prop.Length = 0 Then
                            tbx_MascaraSubred.Text = ""
                        Else
                            tbx_MascaraSubred.Text = objMO.Properties("IPSubnet").Value(0)
                        End If

                        prop = objMO.Properties("DefaultIPGateway").Value
                        If prop Is Nothing OrElse prop.Length = 0 Then
                            tbx_PuertaEnlace.Text = ""
                        Else
                            tbx_PuertaEnlace.Text = objMO.Properties("DefaultIPGateway").Value(0)
                        End If
                    End If

                    Dim arrDns As String()
                    arrDns = objMO.Properties("DNSServerSearchOrder").Value
                    If arrDns Is Nothing OrElse arrDns.Length < 1 Then
                        If CBool(objMO("DHCPEnabled")) Then
                            rbn_DnsAutomatico.Checked = True
                            rbn_DnsManual.Image = My.Resources.RadioButton_UnChecked_24x24
                            rbn_DnsAutomatico.Image = My.Resources.RadioButton_Checked_24x24
                        End If
                    Else
                        rbn_DnsManual.Checked = True
                        rbn_DnsAutomatico.Image = My.Resources.RadioButton_UnChecked_24x24
                        rbn_DnsManual.Image = My.Resources.RadioButton_Checked_24x24

                        tbx_DnsPreferido.Text = arrDns(0)
                        If arrDns.Length = 2 Then
                            tbx_DnsAlternativo.Text = arrDns(1)
                        End If
                    End If

                    Exit Sub
                End If
            Next
        Catch ex As Exception
            fn_MsgBox("Ocurrió un error al obtener la información de la conexión.", MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Private Sub LimpiarTodo()
        Call LimpiarIP()
        Call LimpiarDNS()
        lbl_Dispositivo.Text = ""
        lbl_Dispositivo.Tag = ""
        rbn_IpAutomatica.Checked = False
        rbn_IpManual.Checked = False
        rbn_DnsAutomatico.Checked = False
        rbn_DnsManual.Checked = False
        rbn_IpAutomatica.Image = My.Resources.RadioButton_UnChecked_24x24
        rbn_IpManual.Image = My.Resources.RadioButton_UnChecked_24x24
        rbn_DnsAutomatico.Image = My.Resources.RadioButton_UnChecked_24x24
        rbn_DnsManual.Image = My.Resources.RadioButton_UnChecked_24x24
        rbn_DnsAutomatico.Enabled = True
        rbn_DnsManual.Enabled = True
        btn_Cambiar.Enabled = False
    End Sub

    Private Sub LimpiarIP()
        tbx_IP.Clear()
        tbx_MascaraSubred.Clear()
        tbx_PuertaEnlace.Clear()
    End Sub

    Private Sub LimpiarDNS()
        tbx_DnsPreferido.Clear()
        tbx_DnsAlternativo.Clear()
    End Sub

    Private Function Validar() As Boolean
        Dim Correcto As Boolean = True

        If rbn_IpAutomatica.Checked = False OrElse rbn_IpManual.Checked = False Then
            fn_MsgBox("Seleccione el tipo de dirección IP.", MessageBoxIcon.Error, True, 2)
            Return False
        ElseIf rbn_IpManual.Checked Then
            If tbx_IP.Text.Trim = "" Then
                fn_MsgBox("Capture la dirección IP.", MessageBoxIcon.Error, True, 2)
                Return False
            ElseIf tbx_MascaraSubred.Text.Trim = "" Then
                fn_MsgBox("Capture la mascara de subred.", MessageBoxIcon.Error, True, 2)
                Return False
            ElseIf tbx_PuertaEnlace.Text.Trim = "" Then
                fn_MsgBox("Capture la puerta de enlace.", MessageBoxIcon.Error, True, 2)
                Return False
            End If
        ElseIf rbn_DnsAutomatico.Checked = False OrElse rbn_DnsManual.Checked = False Then
            fn_MsgBox("Seleccione el DNS.", MessageBoxIcon.Error, True, 2)
            Return False
        End If
        Return Correcto

    End Function


    Public Sub setIP(ByVal Nic As String, ByVal ip_address As String, ByVal subnet_mask As String, ByVal PuertaEnlace As String)
        Try
            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            For Each objMO As ManagementObject In objMOC

                If objMO.Properties("Caption").Value = Nic Then
                    'If CBool(objMO("IPEnabled")) Then 'comprueba que la red este conectada


                    Dim setIP As ManagementBaseObject
                    Dim newIP As ManagementBaseObject = objMO.GetMethodParameters("EnableStatic")

                    newIP("IPAddress") = New String() {ip_address}
                    newIP("SubnetMask") = New String() {subnet_mask}
                    setIP = objMO.InvokeMethod("EnableStatic", newIP, Nothing)

                    Dim setGateway As ManagementBaseObject
                    Dim newGateway As ManagementBaseObject = objMO.GetMethodParameters("SetGateways")

                    newGateway("DefaultIPGateway") = New String() {PuertaEnlace}
                    newGateway("GatewayCostMetric") = New Integer() {1}
                    setGateway = objMO.InvokeMethod("SetGateways", newGateway, Nothing)

                    Exit For
                End If
            Next
        Catch ex As Exception
            fn_MsgBox("Ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error, True, 2)
        End Try

    End Sub

    Public Sub setGateway(ByVal gateway As String)
        Try

            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            For Each objMO As ManagementObject In objMOC
                If CBool(objMO("IPEnabled")) Then

                    Dim setGateway As ManagementBaseObject
                    Dim newGateway As ManagementBaseObject = objMO.GetMethodParameters("SetGateways")

                    newGateway("DefaultIPGateway") = New String() {gateway}
                    newGateway("GatewayCostMetric") = New Integer() {1}

                    setGateway = objMO.InvokeMethod("SetGateways", newGateway, Nothing)

                End If
            Next
        Catch ex As Exception
            fn_MsgBox("Ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error, True, 2)
        End Try

    End Sub

    Public Sub setDNS(ByVal Nic As String, ByVal Dns As ArrayList)
        Try
            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            For Each objMO As ManagementObject In objMOC
                If objMO("Caption").Equals(Nic) Then
                    'If CBool(objMO("IPEnabled")) Then

                    Dim newDNS As ManagementBaseObject = objMO.GetMethodParameters("SetDNSServerSearchOrder")

                    newDNS("DNSServerSearchOrder") = Dns.ToArray
                    Dim setDNS = objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, Nothing)

                    Exit For
                End If
            Next
        Catch ex As Exception
            fn_MsgBox("Ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Public Sub setWINS(ByVal NIC As String, ByVal priWINS As String, ByVal secWINS As String)
        Try

            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            For Each objMO As ManagementObject In objMOC
                'If CBool(objMO("IPEnabled")) Then
                If objMO("Caption").Equals(NIC) Then

                    Dim setWINS As ManagementBaseObject
                    Dim wins As ManagementBaseObject = objMO.GetMethodParameters("SetWINSServer")
                    wins.SetPropertyValue("WINSPrimaryServer", priWINS)
                    wins.SetPropertyValue("WINSSecondaryServer", secWINS)

                    setWINS = objMO.InvokeMethod("SetWINSServer", wins, Nothing)

                End If
                'End If
            Next

        Catch ex As Exception
            fn_MsgBox("Ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Public Sub SetIPAutomatica(ByVal Nic As String)
        Try

            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            For Each objMO As ManagementObject In objMOC

                If objMO.Properties("Caption").Value = Nic Then
                    'If CBool(objMO("IPEnabled")) Then

                    Dim setIP As ManagementBaseObject
                    setIP = objMO.InvokeMethod("EnableDHCP", Nothing, Nothing)

                    Exit For
                End If
            Next
        Catch ex As Exception
            fn_MsgBox("Ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Public Sub SetDNSAutomatico(ByVal Nic As String)
        Try
            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            For Each objMO As ManagementObject In objMOC

                If objMO.Properties("Caption").Value = Nic Then
                    'If CBool(objMO("IPEnabled")) Then


                    Dim NewDNS As ManagementBaseObject = objMO.GetMethodParameters("SetDNSServerSearchOrder")
                    NewDNS("DNSServerSearchOrder") = New String() {}
                    Dim setDNS = objMO.InvokeMethod("SetDNSServerSearchOrder", NewDNS, Nothing)


                    Exit For
                End If
            Next
        Catch ex As Exception
            fn_MsgBox("Ocurrió el siguiente error: " & ex.Message, MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Private Function ValidarIP(ByVal Ip As String) As Boolean
        Dim NuevaIp As IPAddress = Nothing

        Dim myRegex As New Regex("^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$")
        If myRegex.IsMatch(Ip) Then
            Return IPAddress.TryParse(Ip, NuevaIp)
        Else
            Return False
        End If

    End Function


#End Region

    Private Sub frm_CambiarIP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
    End Sub

    Private Sub frm_CambiarIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cambiaar IP
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA
        varPub.IdPantalla = 5
        Try

            pnl_General.Enabled = False
            Cursor = Cursors.WaitCursor
            Dim objMC As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMC.GetInstances()

            lsv_Conexiones.Clear()
            lsv_Conexiones.Columns.Add("Nombre", 100)
            lsv_Conexiones.Columns.Add("Dispositivo", 300)
            lsv_Conexiones.Columns.Add("Estatus", 80)

            Call ListarConexiones()
            Call LimpiarTodo()

            '----------------------------------------
            If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.miniNUMEROS Then
                forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.miniNUMEROS
                ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
                ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
            End If

            varTecl.ubicaY_Teclado = varTecl.AnchoPantalla - ctrlTeclado.Height 'las 2 lineas son para centrarlos
            varTecl.ubicaY_Teclado = varTecl.ubicaY_Teclado / 2
            varTecl.ubicaX_Teclado = 0
            varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

        Catch ex As Exception
            fn_MsgBox("Ocurrió un error al mostrar dispositivos de red.", MessageBoxIcon.Error)
        End Try

        pnl_General.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
        pnl_General.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub pnl_DNS_Click(sender As Object, e As EventArgs) Handles pnl_DNS.Click
        varPub.SegundosSesion = 0
        pnl_DNS.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub pnl_IP_Click(sender As Object, e As EventArgs) Handles pnl_IP.Click
        varpub.SegundosSesion = 0
        pnl_IP.Focus()
        ctrlTeclado.Hide()
    End Sub

    Private Sub btn_ActualizarConexiones_Click(sender As Object, e As EventArgs) Handles btn_ActualizarConexiones.Click
        Call LimpiarTodo()
        Call ListarConexiones()
    End Sub

    Private Sub btn_Cambiar_Click(sender As Object, e As EventArgs) Handles btn_Cambiar.Click
        varpub.SegundosSesion = 0
        ctrlTeclado.Hide()

        If lbl_Dispositivo.Tag = "" Then
            fn_MsgBox("No tiene Dispositivos conectados.", MessageBoxIcon.Error, True, 2)
            Exit Sub
        End If

        If rbn_IpManual.Checked Then
            If Not ValidarIP(tbx_IP.Text.Trim) Then
                fn_MsgBox("La dirección IP no es válida.", MessageBoxIcon.Error, True, 2)
                tbx_IP.Focus()
                Exit Sub
            End If

            If Not ValidarIP(tbx_MascaraSubred.Text.Trim) Then
                fn_MsgBox("La máscara de subred no es válida.", MessageBoxIcon.Error, True, 2)
                tbx_MascaraSubred.Focus()
                Exit Sub
            End If

            If Not ValidarIP(tbx_PuertaEnlace.Text.Trim) Then
                fn_MsgBox("La puerta de enlace no es válida.", MessageBoxIcon.Error, True, 2)
                tbx_PuertaEnlace.Focus()
                Exit Sub
            End If

        End If

        If rbn_DnsManual.Checked Then
            If Not ValidarIP(tbx_DnsPreferido.Text.Trim) Then
                fn_MsgBox("El servidor DNS preferido no es válido.", MessageBoxIcon.Error, True, 2)
                tbx_DnsPreferido.Focus()
                Exit Sub
            End If

            If Not ValidarIP(tbx_DnsAlternativo.Text.Trim) Then
                fn_MsgBox("El servidor DNS alternativo no es válido.", MessageBoxIcon.Error, True, 2)
                tbx_DnsAlternativo.Focus()
                Exit Sub
            End If
        End If

        Dim Dns As New ArrayList

        If rbn_IpManual.Checked Then
            Call setIP(lbl_Dispositivo.Tag, tbx_IP.Text.Trim, tbx_MascaraSubred.Text.Trim, tbx_PuertaEnlace.Text.Trim)
        ElseIf rbn_IpAutomatica.Checked Then
            Call SetIPAutomatica(lbl_Dispositivo.Tag)
        End If

        If rbn_DnsManual.Checked Then
            Dns.Add(tbx_DnsPreferido.Text.Trim)
            If tbx_DnsAlternativo.Text.Trim <> "" Then Dns.Add(tbx_DnsAlternativo.Text.Trim)
            Call setDNS(lbl_Dispositivo.Tag.Trim, Dns)
        ElseIf rbn_DnsManual.Checked Then
            Call SetDNSAutomatico(lbl_Dispositivo.Tag)
        End If
        fn_MsgBox("Se cambió la configuración correctamente.", MessageBoxIcon.Information, True, 2)

    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varpub.SegundosSesion = 0
        Me.Close()
    End Sub

    Private Sub rbn_IpAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles rbn_IpAutomatica.CheckedChanged
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        If rbn_IpAutomatica.Checked Then
            gbx_Ip.Enabled = False

            rbn_DnsAutomatico.Enabled = True
            rbn_DnsManual.Enabled = True
            rbn_IpAutomatica.Image = My.Resources.RadioButton_Checked_24x24
            rbn_IpManual.Image = My.Resources.RadioButton_UnChecked_24x24
            Call LimpiarIP()
        End If
    End Sub

    Private Sub rbn_IpManual_CheckedChanged(sender As Object, e As EventArgs) Handles rbn_IpManual.CheckedChanged
        varPub.SegundosSesion = 0
        ctrlTeclado.Hide()
        If rbn_IpManual.Checked Then
            gbx_Ip.Enabled = True

            rbn_DnsManual.Checked = True
            rbn_DnsAutomatico.Enabled = False
            rbn_DnsManual.Enabled = False

            rbn_IpManual.Image = My.Resources.RadioButton_Checked_24x24
            rbn_IpAutomatica.Image = My.Resources.RadioButton_UnChecked_24x24
            rbn_DnsAutomatico.Image = My.Resources.RadioButton_UnChecked_24x24
            rbn_DnsManual.Image = My.Resources.RadioButton_Checked_24x24
        End If
    End Sub

    Private Sub rbn_DnsAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles rbn_DnsAutomatico.CheckedChanged
        varpub.SegundosSesion = 0
        ctrlTeclado.Hide()

        If rbn_DnsAutomatico.Checked Then
            gbx_Dns.Enabled = False
            rbn_DnsAutomatico.Image = My.Resources.RadioButton_Checked_24x24
            rbn_DnsManual.Image = My.Resources.RadioButton_UnChecked_24x24
            Call LimpiarDNS()
        End If
    End Sub

    Private Sub rbn_DnsManual_CheckedChanged(sender As Object, e As EventArgs) Handles rbn_DnsManual.CheckedChanged
        varpub.SegundosSesion = 0
        ctrlTeclado.Hide()
        If rbn_DnsManual.Checked Then
            rbn_DnsManual.Image = My.Resources.RadioButton_Checked_24x24
            rbn_DnsAutomatico.Image = My.Resources.RadioButton_UnChecked_24x24
            gbx_Dns.Enabled = True
        End If
    End Sub

    Private Sub lsv_Conexiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Conexiones.SelectedIndexChanged
        If lsv_Conexiones.SelectedItems.Count = 0 Then
            Call LimpiarTodo()
            btn_Cambiar.Enabled = False
        Else
            lbl_Dispositivo.Text = lsv_Conexiones.SelectedItems(0).Text
            lbl_Dispositivo.Tag = lsv_Conexiones.SelectedItems(0).Tag
            Call MostrarDatos(lbl_Dispositivo.Tag)
            btn_Cambiar.Enabled = True
        End If
    End Sub

    Private Sub tbx_IP_Click(sender As Object, e As EventArgs) Handles tbx_IP.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_IP) = True
    End Sub

    Private Sub tbx_IP_Enter(sender As Object, e As EventArgs) Handles tbx_IP.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_IP) = True
    End Sub

    Private Sub tbx_IP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_IP.KeyPress
        varPub.SegundosSesion = 0
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            tbx_MascaraSubred.Focus() '8= Retroceso, 13=enter, 32=Espacio
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub tbx_IP_Leave(sender As Object, ByVal e As EventArgs) Handles tbx_IP.Leave
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_IP_TextChanged(sender As Object, e As EventArgs) Handles tbx_IP.TextChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tbx_MascaraSubred_Click(sender As Object, e As EventArgs) Handles tbx_MascaraSubred.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_MascaraSubred) = True
    End Sub

    Private Sub tbx_MascaraSubred_Enter(sender As Object, e As EventArgs) Handles tbx_MascaraSubred.Enter
        varpub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_MascaraSubred) = True
    End Sub

    Private Sub tbx_MascaraSubred_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_MascaraSubred.KeyPress
        varPub.SegundosSesion = 0

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            tbx_PuertaEnlace.Focus() '8= Retroceso, 13=enter, 32=Espacio
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub tbx_MascaraSubred_Leave(sender As Object, e As EventArgs) Handles tbx_MascaraSubred.Leave
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_MascaraSubred_TextChanged(sender As Object, e As EventArgs) Handles tbx_MascaraSubred.TextChanged
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_PuertaEnlace_Click(sender As Object, e As EventArgs) Handles tbx_PuertaEnlace.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_PuertaEnlace) = True
    End Sub

    Private Sub tbx_PuertaEnlace_Enter(sender As Object, e As EventArgs) Handles tbx_PuertaEnlace.Enter
        varpub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_PuertaEnlace) = True
    End Sub

    Private Sub tbx_PuertaEnlace_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_PuertaEnlace.KeyPress
        varPub.SegundosSesion = 0
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            tbx_DnsPreferido.Focus() '8= Retroceso, 13=enter, 32=Espacio
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub tbx_PuertaEnlace_Leave(sender As Object, e As EventArgs) Handles tbx_PuertaEnlace.Leave
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_PuertaEnlace_TextChanged(sender As Object, e As EventArgs) Handles tbx_PuertaEnlace.TextChanged
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DnsPreferido_Click(sender As Object, e As EventArgs) Handles tbx_DnsPreferido.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DnsPreferido) = True
    End Sub

    Private Sub tbx_DnsPreferido_Enter(sender As Object, e As EventArgs) Handles tbx_DnsPreferido.Enter
        varpub.SegundosSesion = 0
          ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DnsPreferido) = True
    End Sub

    Private Sub tbx_DnsPreferido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbx_DnsPreferido.KeyPress
        varPub.SegundosSesion = 0

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            tbx_DnsAlternativo.Focus() '8= Retroceso, 13=enter, 32=Espacio
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub tbx_DnsPreferido_Leave(sender As Object, e As EventArgs) Handles tbx_DnsPreferido.Leave
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DnsPreferido_TextChanged(sender As Object, e As EventArgs) Handles tbx_DnsPreferido.TextChanged
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DnsAlternativo_Click(sender As Object, e As EventArgs) Handles tbx_DnsAlternativo.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DnsAlternativo) = True
    End Sub

    Private Sub tbx_DnsAlternativo_Enter(sender As Object, e As EventArgs) Handles tbx_DnsAlternativo.Enter
        varpub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(tbx_DnsAlternativo) = True
    End Sub

    Private Sub tbx_DnsAlternativo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbx_DnsAlternativo.KeyPress
        varpub.SegundosSesion = 0
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            btn_Cambiar.Focus() '8= Retroceso, 13=enter, 32=Espacio
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub tbx_DnsAlternativo_Leave(sender As Object, e As EventArgs) Handles tbx_DnsAlternativo.Leave
        varpub.SegundosSesion = 0
    End Sub

    Private Sub tbx_DnsAlternativo_TextChanged(sender As Object, e As EventArgs) Handles tbx_DnsAlternativo.TextChanged
        varpub.SegundosSesion = 0
    End Sub

End Class