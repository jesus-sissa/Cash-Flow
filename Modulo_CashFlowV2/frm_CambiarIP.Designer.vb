<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CambiarIP
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CambiarIP))
        Me.lbl_EtiquetaDispositivo = New System.Windows.Forms.Label()
        Me.lbl_Dispositivo = New System.Windows.Forms.Label()
        Me.gbx_Ip = New System.Windows.Forms.GroupBox()
        Me.tbx_IP = New System.Windows.Forms.TextBox()
        Me.tbx_PuertaEnlace = New System.Windows.Forms.TextBox()
        Me.tbx_MascaraSubred = New System.Windows.Forms.TextBox()
        Me.lbl_PuertaEnlace = New System.Windows.Forms.Label()
        Me.lbl_MascaraSubred = New System.Windows.Forms.Label()
        Me.lbl_Ip = New System.Windows.Forms.Label()
        Me.gbx_Dns = New System.Windows.Forms.GroupBox()
        Me.tbx_DnsAlternativo = New System.Windows.Forms.TextBox()
        Me.tbx_DnsPreferido = New System.Windows.Forms.TextBox()
        Me.lbl_DnsAlternativo = New System.Windows.Forms.Label()
        Me.lbl_DnsPreferido = New System.Windows.Forms.Label()
        Me.pnl_IP = New System.Windows.Forms.Panel()
        Me.rbn_IpManual = New System.Windows.Forms.RadioButton()
        Me.rbn_IpAutomatica = New System.Windows.Forms.RadioButton()
        Me.pnl_DNS = New System.Windows.Forms.Panel()
        Me.rbn_DnsManual = New System.Windows.Forms.RadioButton()
        Me.rbn_DnsAutomatico = New System.Windows.Forms.RadioButton()
        Me.lsv_Conexiones = New System.Windows.Forms.ListView()
        Me.iml_Network = New System.Windows.Forms.ImageList(Me.components)
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Cambiar = New System.Windows.Forms.Button()
        Me.btn_ActualizarConexiones = New System.Windows.Forms.Button()
        Me.gbx_Ip.SuspendLayout()
        Me.gbx_Dns.SuspendLayout()
        Me.pnl_IP.SuspendLayout()
        Me.pnl_DNS.SuspendLayout()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_EtiquetaDispositivo
        '
        Me.lbl_EtiquetaDispositivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_EtiquetaDispositivo.AutoSize = True
        Me.lbl_EtiquetaDispositivo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_EtiquetaDispositivo.Location = New System.Drawing.Point(11, 76)
        Me.lbl_EtiquetaDispositivo.Name = "lbl_EtiquetaDispositivo"
        Me.lbl_EtiquetaDispositivo.Size = New System.Drawing.Size(176, 22)
        Me.lbl_EtiquetaDispositivo.TabIndex = 1
        Me.lbl_EtiquetaDispositivo.Text = "Dispositivo de Red:"
        '
        'lbl_Dispositivo
        '
        Me.lbl_Dispositivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Dispositivo.AutoSize = True
        Me.lbl_Dispositivo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dispositivo.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Dispositivo.Location = New System.Drawing.Point(183, 77)
        Me.lbl_Dispositivo.Name = "lbl_Dispositivo"
        Me.lbl_Dispositivo.Size = New System.Drawing.Size(113, 22)
        Me.lbl_Dispositivo.TabIndex = 2
        Me.lbl_Dispositivo.Text = "ETHERNET"
        '
        'gbx_Ip
        '
        Me.gbx_Ip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Ip.Controls.Add(Me.tbx_IP)
        Me.gbx_Ip.Controls.Add(Me.tbx_PuertaEnlace)
        Me.gbx_Ip.Controls.Add(Me.tbx_MascaraSubred)
        Me.gbx_Ip.Controls.Add(Me.lbl_PuertaEnlace)
        Me.gbx_Ip.Controls.Add(Me.lbl_MascaraSubred)
        Me.gbx_Ip.Controls.Add(Me.lbl_Ip)
        Me.gbx_Ip.Location = New System.Drawing.Point(21, 52)
        Me.gbx_Ip.Name = "gbx_Ip"
        Me.gbx_Ip.Size = New System.Drawing.Size(582, 129)
        Me.gbx_Ip.TabIndex = 1
        Me.gbx_Ip.TabStop = False
        '
        'tbx_IP
        '
        Me.tbx_IP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_IP.Location = New System.Drawing.Point(363, 20)
        Me.tbx_IP.MaxLength = 16
        Me.tbx_IP.Name = "tbx_IP"
        Me.tbx_IP.Size = New System.Drawing.Size(206, 32)
        Me.tbx_IP.TabIndex = 1
        '
        'tbx_PuertaEnlace
        '
        Me.tbx_PuertaEnlace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_PuertaEnlace.Location = New System.Drawing.Point(363, 91)
        Me.tbx_PuertaEnlace.MaxLength = 16
        Me.tbx_PuertaEnlace.Name = "tbx_PuertaEnlace"
        Me.tbx_PuertaEnlace.Size = New System.Drawing.Size(206, 32)
        Me.tbx_PuertaEnlace.TabIndex = 5
        '
        'tbx_MascaraSubred
        '
        Me.tbx_MascaraSubred.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_MascaraSubred.Location = New System.Drawing.Point(363, 55)
        Me.tbx_MascaraSubred.MaxLength = 16
        Me.tbx_MascaraSubred.Name = "tbx_MascaraSubred"
        Me.tbx_MascaraSubred.Size = New System.Drawing.Size(206, 32)
        Me.tbx_MascaraSubred.TabIndex = 3
        '
        'lbl_PuertaEnlace
        '
        Me.lbl_PuertaEnlace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_PuertaEnlace.AutoSize = True
        Me.lbl_PuertaEnlace.Location = New System.Drawing.Point(31, 94)
        Me.lbl_PuertaEnlace.Name = "lbl_PuertaEnlace"
        Me.lbl_PuertaEnlace.Size = New System.Drawing.Size(326, 24)
        Me.lbl_PuertaEnlace.TabIndex = 4
        Me.lbl_PuertaEnlace.Text = "Puerta de enlace predeterminada:"
        '
        'lbl_MascaraSubred
        '
        Me.lbl_MascaraSubred.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_MascaraSubred.AutoSize = True
        Me.lbl_MascaraSubred.Location = New System.Drawing.Point(161, 58)
        Me.lbl_MascaraSubred.Name = "lbl_MascaraSubred"
        Me.lbl_MascaraSubred.Size = New System.Drawing.Size(196, 24)
        Me.lbl_MascaraSubred.TabIndex = 2
        Me.lbl_MascaraSubred.Text = "Mascara de subred:"
        '
        'lbl_Ip
        '
        Me.lbl_Ip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Ip.AutoSize = True
        Me.lbl_Ip.Location = New System.Drawing.Point(226, 23)
        Me.lbl_Ip.Name = "lbl_Ip"
        Me.lbl_Ip.Size = New System.Drawing.Size(131, 24)
        Me.lbl_Ip.TabIndex = 0
        Me.lbl_Ip.Text = "Dirección IP:"
        '
        'gbx_Dns
        '
        Me.gbx_Dns.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Dns.Controls.Add(Me.tbx_DnsAlternativo)
        Me.gbx_Dns.Controls.Add(Me.tbx_DnsPreferido)
        Me.gbx_Dns.Controls.Add(Me.lbl_DnsAlternativo)
        Me.gbx_Dns.Controls.Add(Me.lbl_DnsPreferido)
        Me.gbx_Dns.Location = New System.Drawing.Point(20, 48)
        Me.gbx_Dns.Name = "gbx_Dns"
        Me.gbx_Dns.Size = New System.Drawing.Size(584, 114)
        Me.gbx_Dns.TabIndex = 1
        Me.gbx_Dns.TabStop = False
        '
        'tbx_DnsAlternativo
        '
        Me.tbx_DnsAlternativo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_DnsAlternativo.Location = New System.Drawing.Point(363, 76)
        Me.tbx_DnsAlternativo.MaxLength = 16
        Me.tbx_DnsAlternativo.Name = "tbx_DnsAlternativo"
        Me.tbx_DnsAlternativo.Size = New System.Drawing.Size(208, 32)
        Me.tbx_DnsAlternativo.TabIndex = 3
        '
        'tbx_DnsPreferido
        '
        Me.tbx_DnsPreferido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_DnsPreferido.Location = New System.Drawing.Point(363, 41)
        Me.tbx_DnsPreferido.MaxLength = 16
        Me.tbx_DnsPreferido.Name = "tbx_DnsPreferido"
        Me.tbx_DnsPreferido.Size = New System.Drawing.Size(208, 32)
        Me.tbx_DnsPreferido.TabIndex = 1
        '
        'lbl_DnsAlternativo
        '
        Me.lbl_DnsAlternativo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_DnsAlternativo.AutoSize = True
        Me.lbl_DnsAlternativo.Location = New System.Drawing.Point(109, 79)
        Me.lbl_DnsAlternativo.Name = "lbl_DnsAlternativo"
        Me.lbl_DnsAlternativo.Size = New System.Drawing.Size(248, 24)
        Me.lbl_DnsAlternativo.TabIndex = 2
        Me.lbl_DnsAlternativo.Text = "Servidor DNS alternativo:"
        '
        'lbl_DnsPreferido
        '
        Me.lbl_DnsPreferido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_DnsPreferido.AutoSize = True
        Me.lbl_DnsPreferido.Location = New System.Drawing.Point(124, 44)
        Me.lbl_DnsPreferido.Name = "lbl_DnsPreferido"
        Me.lbl_DnsPreferido.Size = New System.Drawing.Size(233, 24)
        Me.lbl_DnsPreferido.TabIndex = 0
        Me.lbl_DnsPreferido.Text = "Servidor DNS preferido:"
        '
        'pnl_IP
        '
        Me.pnl_IP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_IP.Controls.Add(Me.rbn_IpManual)
        Me.pnl_IP.Controls.Add(Me.rbn_IpAutomatica)
        Me.pnl_IP.Controls.Add(Me.gbx_Ip)
        Me.pnl_IP.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_IP.Location = New System.Drawing.Point(14, 100)
        Me.pnl_IP.Name = "pnl_IP"
        Me.pnl_IP.Size = New System.Drawing.Size(612, 193)
        Me.pnl_IP.TabIndex = 3
        '
        'rbn_IpManual
        '
        Me.rbn_IpManual.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbn_IpManual.AutoSize = True
        Me.rbn_IpManual.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rbn_IpManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbn_IpManual.Location = New System.Drawing.Point(41, 44)
        Me.rbn_IpManual.Name = "rbn_IpManual"
        Me.rbn_IpManual.Size = New System.Drawing.Size(323, 34)
        Me.rbn_IpManual.TabIndex = 2
        Me.rbn_IpManual.Text = "Usar la siguiente dirección IP:"
        Me.rbn_IpManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbn_IpManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbn_IpManual.UseVisualStyleBackColor = True
        '
        'rbn_IpAutomatica
        '
        Me.rbn_IpAutomatica.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbn_IpAutomatica.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbn_IpAutomatica.AutoSize = True
        Me.rbn_IpAutomatica.Checked = True
        Me.rbn_IpAutomatica.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rbn_IpAutomatica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbn_IpAutomatica.Location = New System.Drawing.Point(41, 8)
        Me.rbn_IpAutomatica.Name = "rbn_IpAutomatica"
        Me.rbn_IpAutomatica.Size = New System.Drawing.Size(442, 34)
        Me.rbn_IpAutomatica.TabIndex = 0
        Me.rbn_IpAutomatica.TabStop = True
        Me.rbn_IpAutomatica.Text = "Obtener una dirección IP automáticamente"
        Me.rbn_IpAutomatica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbn_IpAutomatica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbn_IpAutomatica.UseVisualStyleBackColor = True
        '
        'pnl_DNS
        '
        Me.pnl_DNS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_DNS.Controls.Add(Me.rbn_DnsManual)
        Me.pnl_DNS.Controls.Add(Me.rbn_DnsAutomatico)
        Me.pnl_DNS.Controls.Add(Me.gbx_Dns)
        Me.pnl_DNS.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_DNS.Location = New System.Drawing.Point(15, 299)
        Me.pnl_DNS.Name = "pnl_DNS"
        Me.pnl_DNS.Size = New System.Drawing.Size(611, 172)
        Me.pnl_DNS.TabIndex = 4
        '
        'rbn_DnsManual
        '
        Me.rbn_DnsManual.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbn_DnsManual.AutoSize = True
        Me.rbn_DnsManual.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rbn_DnsManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbn_DnsManual.Location = New System.Drawing.Point(41, 45)
        Me.rbn_DnsManual.Name = "rbn_DnsManual"
        Me.rbn_DnsManual.Size = New System.Drawing.Size(502, 34)
        Me.rbn_DnsManual.TabIndex = 2
        Me.rbn_DnsManual.Text = "Usar las siguientes direcciones de servidor DNS:"
        Me.rbn_DnsManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbn_DnsManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbn_DnsManual.UseVisualStyleBackColor = True
        '
        'rbn_DnsAutomatico
        '
        Me.rbn_DnsAutomatico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbn_DnsAutomatico.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbn_DnsAutomatico.AutoSize = True
        Me.rbn_DnsAutomatico.Checked = True
        Me.rbn_DnsAutomatico.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rbn_DnsAutomatico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbn_DnsAutomatico.Location = New System.Drawing.Point(41, 8)
        Me.rbn_DnsAutomatico.Name = "rbn_DnsAutomatico"
        Me.rbn_DnsAutomatico.Size = New System.Drawing.Size(562, 34)
        Me.rbn_DnsAutomatico.TabIndex = 0
        Me.rbn_DnsAutomatico.TabStop = True
        Me.rbn_DnsAutomatico.Text = "Obtener la dirección del servidor DNS automáticamente"
        Me.rbn_DnsAutomatico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbn_DnsAutomatico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbn_DnsAutomatico.UseVisualStyleBackColor = True
        '
        'lsv_Conexiones
        '
        Me.lsv_Conexiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Conexiones.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lsv_Conexiones.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Conexiones.FullRowSelect = True
        Me.lsv_Conexiones.HideSelection = False
        Me.lsv_Conexiones.LargeImageList = Me.iml_Network
        Me.lsv_Conexiones.Location = New System.Drawing.Point(7, 4)
        Me.lsv_Conexiones.MultiSelect = False
        Me.lsv_Conexiones.Name = "lsv_Conexiones"
        Me.lsv_Conexiones.Size = New System.Drawing.Size(612, 71)
        Me.lsv_Conexiones.TabIndex = 0
        Me.lsv_Conexiones.TileSize = New System.Drawing.Size(390, 70)
        Me.lsv_Conexiones.UseCompatibleStateImageBehavior = False
        Me.lsv_Conexiones.View = System.Windows.Forms.View.Tile
        '
        'iml_Network
        '
        Me.iml_Network.ImageStream = CType(resources.GetObject("iml_Network.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Network.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Network.Images.SetKeyName(0, "EternetDeshabilitado.png")
        Me.iml_Network.Images.SetKeyName(1, "WifiDeshabilitado.png")
        Me.iml_Network.Images.SetKeyName(2, "EternetConectado.png")
        Me.iml_Network.Images.SetKeyName(3, "WifiConectado.png")
        Me.iml_Network.Images.SetKeyName(4, "EternetCableDesconectado.png")
        Me.iml_Network.Images.SetKeyName(5, "WifiAntenaDesconectado.png")
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.lsv_Conexiones)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.btn_Cambiar)
        Me.pnl_General.Controls.Add(Me.btn_ActualizarConexiones)
        Me.pnl_General.Controls.Add(Me.pnl_DNS)
        Me.pnl_General.Controls.Add(Me.pnl_IP)
        Me.pnl_General.Controls.Add(Me.lbl_EtiquetaDispositivo)
        Me.pnl_General.Controls.Add(Me.lbl_Dispositivo)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cerrar.Location = New System.Drawing.Point(631, 396)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 7
        Me.btn_Cerrar.Text = "Cerrar"
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Cambiar
        '
        Me.btn_Cambiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cambiar.Enabled = False
        Me.btn_Cambiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cambiar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cambiar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Aceptar
        Me.btn_Cambiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cambiar.Location = New System.Drawing.Point(631, 103)
        Me.btn_Cambiar.Name = "btn_Cambiar"
        Me.btn_Cambiar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cambiar.TabIndex = 6
        Me.btn_Cambiar.Text = "Aceptar"
        Me.btn_Cambiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Cambiar.UseVisualStyleBackColor = True
        '
        'btn_ActualizarConexiones
        '
        Me.btn_ActualizarConexiones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ActualizarConexiones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ActualizarConexiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ActualizarConexiones.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ActualizarConexiones.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Refrescar
        Me.btn_ActualizarConexiones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ActualizarConexiones.Location = New System.Drawing.Point(631, 4)
        Me.btn_ActualizarConexiones.Name = "btn_ActualizarConexiones"
        Me.btn_ActualizarConexiones.Size = New System.Drawing.Size(164, 75)
        Me.btn_ActualizarConexiones.TabIndex = 5
        Me.btn_ActualizarConexiones.Text = "Actualizar"
        Me.btn_ActualizarConexiones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ActualizarConexiones.UseVisualStyleBackColor = True
        '
        'frm_CambiarIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_CambiarIP"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar IP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbx_Ip.ResumeLayout(False)
        Me.gbx_Ip.PerformLayout()
        Me.gbx_Dns.ResumeLayout(False)
        Me.gbx_Dns.PerformLayout()
        Me.pnl_IP.ResumeLayout(False)
        Me.pnl_IP.PerformLayout()
        Me.pnl_DNS.ResumeLayout(False)
        Me.pnl_DNS.PerformLayout()
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cambiar As System.Windows.Forms.Button
    Friend WithEvents lbl_EtiquetaDispositivo As System.Windows.Forms.Label
    Friend WithEvents lbl_Dispositivo As System.Windows.Forms.Label
    Friend WithEvents rbn_IpAutomatica As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_IpManual As System.Windows.Forms.RadioButton
    Friend WithEvents gbx_Ip As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_PuertaEnlace As System.Windows.Forms.Label
    Friend WithEvents lbl_MascaraSubred As System.Windows.Forms.Label
    Friend WithEvents lbl_Ip As System.Windows.Forms.Label
    Friend WithEvents tbx_PuertaEnlace As System.Windows.Forms.TextBox
    Friend WithEvents tbx_MascaraSubred As System.Windows.Forms.TextBox
    Friend WithEvents rbn_DnsAutomatico As System.Windows.Forms.RadioButton
    Friend WithEvents rbn_DnsManual As System.Windows.Forms.RadioButton
    Friend WithEvents gbx_Dns As System.Windows.Forms.GroupBox
    Friend WithEvents tbx_DnsAlternativo As System.Windows.Forms.TextBox
    Friend WithEvents tbx_DnsPreferido As System.Windows.Forms.TextBox
    Friend WithEvents lbl_DnsAlternativo As System.Windows.Forms.Label
    Friend WithEvents lbl_DnsPreferido As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents pnl_IP As System.Windows.Forms.Panel
    Friend WithEvents pnl_DNS As System.Windows.Forms.Panel
    Friend WithEvents lsv_Conexiones As System.Windows.Forms.ListView
    Friend WithEvents btn_ActualizarConexiones As System.Windows.Forms.Button
    Friend WithEvents tbx_IP As System.Windows.Forms.TextBox
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents iml_Network As System.Windows.Forms.ImageList

End Class
