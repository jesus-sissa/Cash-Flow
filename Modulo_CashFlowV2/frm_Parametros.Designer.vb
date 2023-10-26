<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Parametros
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmb_MsgFuente = New System.Windows.Forms.ComboBox()
        Me.cmb_cmdFuente = New System.Windows.Forms.ComboBox()
        Me.cmb_lblFuente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_MsgFuente = New System.Windows.Forms.Label()
        Me.lbl_Conectividad = New System.Windows.Forms.Label()
        Me.Tab_Parametros = New System.Windows.Forms.TabControl()
        Me.tbp_ConexionCentral = New System.Windows.Forms.TabPage()
        Me.gbx_ConexionSA = New System.Windows.Forms.GroupBox()
        Me.tbx_HostIP = New System.Windows.Forms.TextBox()
        Me.lbl_HostIP = New System.Windows.Forms.Label()
        Me.tbx_Servidor = New System.Windows.Forms.TextBox()
        Me.btn_DesktopSize = New System.Windows.Forms.Button()
        Me.chk_BD = New System.Windows.Forms.CheckBox()
        Me.lbl_Width = New System.Windows.Forms.Label()
        Me.chk_User = New System.Windows.Forms.CheckBox()
        Me.tbx_Width = New System.Windows.Forms.TextBox()
        Me.lbl_Height = New System.Windows.Forms.Label()
        Me.chk_Servidor = New System.Windows.Forms.CheckBox()
        Me.tbx_Height = New System.Windows.Forms.TextBox()
        Me.chk_Password = New System.Windows.Forms.CheckBox()
        Me.chk_ClaveUnica = New System.Windows.Forms.CheckBox()
        Me.lbl_Servidor = New System.Windows.Forms.Label()
        Me.lbl_BDD = New System.Windows.Forms.Label()
        Me.tbx_BDD = New System.Windows.Forms.TextBox()
        Me.rdb_NoconectaSA = New System.Windows.Forms.RadioButton()
        Me.lbl_Usuario = New System.Windows.Forms.Label()
        Me.rdb_SiConectaSA = New System.Windows.Forms.RadioButton()
        Me.tbx_Usuario = New System.Windows.Forms.TextBox()
        Me.chk_Taskbar = New System.Windows.Forms.CheckBox()
        Me.lbl_Password = New System.Windows.Forms.Label()
        Me.tbx_ClaveUnica = New System.Windows.Forms.TextBox()
        Me.tbx_Password = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_ConectarBDD = New System.Windows.Forms.Button()
        Me.tbp_datos = New System.Windows.Forms.TabPage()
        Me.gbx_Sucursal = New System.Windows.Forms.GroupBox()
        Me.lbl_Cajero = New System.Windows.Forms.Label()
        Me.tbx_IdCajero = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btn_FechaInicioOperaciones = New System.Windows.Forms.Button()
        Me.lbl_Mail = New System.Windows.Forms.Label()
        Me.lbl_RutaLog = New System.Windows.Forms.Label()
        Me.btn_DestinoLog = New System.Windows.Forms.Button()
        Me.tbx_Mail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbx_SucursalNombre = New System.Windows.Forms.TextBox()
        Me.tbx_NombreCorto = New System.Windows.Forms.TextBox()
        Me.btn_AgregaCaset = New System.Windows.Forms.Button()
        Me.lbl_NombreCorto = New System.Windows.Forms.Label()
        Me.btn_Sincronizar = New System.Windows.Forms.Button()
        Me.btn_Actualizar = New System.Windows.Forms.Button()
        Me.cmb_ClaveSucursal = New System.Windows.Forms.ComboBox()
        Me.lbl_SucursalN = New System.Windows.Forms.Label()
        Me.tbx_ClaveSucursal = New System.Windows.Forms.TextBox()
        Me.tbx_Cliente = New System.Windows.Forms.TextBox()
        Me.lbl_Cliente = New System.Windows.Forms.Label()
        Me.tbx_ClaveCliente = New System.Windows.Forms.TextBox()
        Me.lbl_Telefono = New System.Windows.Forms.Label()
        Me.lbl_Domicilio = New System.Windows.Forms.Label()
        Me.tbx_Tel = New System.Windows.Forms.TextBox()
        Me.lbl_CiaTV = New System.Windows.Forms.Label()
        Me.lbl_Cvecliente = New System.Windows.Forms.Label()
        Me.tbx_Direccion = New System.Windows.Forms.TextBox()
        Me.lbl_ClaveSucursal = New System.Windows.Forms.Label()
        Me.tbx_CiaTV = New System.Windows.Forms.TextBox()
        Me.tbp_SizeFuente = New System.Windows.Forms.TabPage()
        Me.gbx_Tiempo = New System.Windows.Forms.GroupBox()
        Me.pic_BuscarPuertos = New System.Windows.Forms.PictureBox()
        Me.cmb_puertoSensor = New System.Windows.Forms.ComboBox()
        Me.lbl_puertoSensor = New System.Windows.Forms.Label()
        Me.cmb_PorcBateriaCritica = New System.Windows.Forms.ComboBox()
        Me.cmb_PorcBateriaBaja = New System.Windows.Forms.ComboBox()
        Me.lbl_BateriaBaja = New System.Windows.Forms.Label()
        Me.lbl_BateriaCritica = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmb_TiempoReceptor = New System.Windows.Forms.ComboBox()
        Me.tbx_DiasExpira = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmb_TiempoSesion = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbp_Cajero = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_TeamViewer = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.gbx_NumValidadores = New System.Windows.Forms.GroupBox()
        Me.rdb_2val = New System.Windows.Forms.RadioButton()
        Me.rdb_1val = New System.Windows.Forms.RadioButton()
        Me.lbl_CantodadVal = New System.Windows.Forms.Label()
        Me.spc_Validadores = New System.Windows.Forms.SplitContainer()
        Me.gbx_StatusVal1 = New System.Windows.Forms.GroupBox()
        Me.Cmb_PesoDolarV1 = New System.Windows.Forms.ComboBox()
        Me.lbl_Val1Activado = New System.Windows.Forms.Label()
        Me.rdb_NoVal1 = New System.Windows.Forms.RadioButton()
        Me.rdb_SiVal1 = New System.Windows.Forms.RadioButton()
        Me.lbl_LimiteCapacidadKct = New System.Windows.Forms.Label()
        Me.cmb_LimiteCapacidadKct = New System.Windows.Forms.ComboBox()
        Me.lbl_val1 = New System.Windows.Forms.Label()
        Me.cmb_Caset = New System.Windows.Forms.ComboBox()
        Me.lbl_Caset = New System.Windows.Forms.Label()
        Me.tbx_Validador1 = New System.Windows.Forms.TextBox()
        Me.lbl_puertoval1 = New System.Windows.Forms.Label()
        Me.tbx_PuertoVal1 = New System.Windows.Forms.TextBox()
        Me.gbx_StatusVal2 = New System.Windows.Forms.GroupBox()
        Me.Cmb_PesoDolarV2 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_LimiteCapacidadKct2 = New System.Windows.Forms.Label()
        Me.rdb_NoVal2 = New System.Windows.Forms.RadioButton()
        Me.cmb_LimiteCapacidadKct2 = New System.Windows.Forms.ComboBox()
        Me.rdb_SiVal2 = New System.Windows.Forms.RadioButton()
        Me.cmb_Caset2 = New System.Windows.Forms.ComboBox()
        Me.tbx_PuertoVal2 = New System.Windows.Forms.TextBox()
        Me.lbl_caset2 = New System.Windows.Forms.Label()
        Me.lbl_puertoval2 = New System.Windows.Forms.Label()
        Me.lbl_val2 = New System.Windows.Forms.Label()
        Me.tbx_Validador2 = New System.Windows.Forms.TextBox()
        Me.tbp_TipoCambio = New System.Windows.Forms.TabPage()
        Me.gbx_TipoCambio = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tbx_NuevoTC = New System.Windows.Forms.TextBox()
        Me.btn_GuardarTC = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbx_AnteriorTC = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbx_FechaTC = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbx_MonedaTC = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbp_ConexionAdmin = New System.Windows.Forms.TabPage()
        Me.gbx_Conexion = New System.Windows.Forms.GroupBox()
        Me.gbx_Conectado = New System.Windows.Forms.GroupBox()
        Me.rdb_NOconectaAdmin = New System.Windows.Forms.RadioButton()
        Me.lbl_ConectividadUser = New System.Windows.Forms.Label()
        Me.rdb_SIconectaAdmin = New System.Windows.Forms.RadioButton()
        Me.gbx_Prioridad = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rdb_local = New System.Windows.Forms.RadioButton()
        Me.rdb_web = New System.Windows.Forms.RadioButton()
        Me.gbx_Actualizar = New System.Windows.Forms.GroupBox()
        Me.btn_ActualizaWeb = New System.Windows.Forms.Button()
        Me.btn_ActualizarLocal = New System.Windows.Forms.Button()
        Me.tbp_Impresora = New System.Windows.Forms.TabPage()
        Me.gbx_Papel = New System.Windows.Forms.GroupBox()
        Me.cmb_MododeImprimir = New System.Windows.Forms.ComboBox()
        Me.lbl_MododeImprimir = New System.Windows.Forms.Label()
        Me.btn_EliminaLogo = New System.Windows.Forms.Button()
        Me.lbl_DetalleCorteDiario = New System.Windows.Forms.Label()
        Me.btn_AgregarLogo = New System.Windows.Forms.Button()
        Me.lbl_NoCopias = New System.Windows.Forms.Label()
        Me.cmb_NoCopias = New System.Windows.Forms.ComboBox()
        Me.pct_ImgEmpresa = New System.Windows.Forms.PictureBox()
        Me.cmb_LineasBlanco = New System.Windows.Forms.ComboBox()
        Me.lbl_LineasBlanco = New System.Windows.Forms.Label()
        Me.cmb_MargenIzq = New System.Windows.Forms.ComboBox()
        Me.cmb_TipoWindows = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbx_Sizepapel = New System.Windows.Forms.GroupBox()
        Me.rdb_58mm = New System.Windows.Forms.RadioButton()
        Me.rdb_80mm = New System.Windows.Forms.RadioButton()
        Me.gbx_DetalleCD = New System.Windows.Forms.GroupBox()
        Me.rdb_SIdetalle = New System.Windows.Forms.RadioButton()
        Me.rdb_NOdetalle = New System.Windows.Forms.RadioButton()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grp_ConexionWebS = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Cmb_Plaza = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Rdb_rdn = New System.Windows.Forms.RadioButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Rdb_rds = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Rdb_sin_n = New System.Windows.Forms.RadioButton()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Rdb_sin_s = New System.Windows.Forms.RadioButton()
        Me.gbx_verificarfolio = New System.Windows.Forms.GroupBox()
        Me.rdb_validarfn = New System.Windows.Forms.RadioButton()
        Me.rdb_validarfsi = New System.Windows.Forms.RadioButton()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.grp_CorteDiario = New System.Windows.Forms.GroupBox()
        Me.Rdb_CorteNo = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Rdb_CorteSi = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.rdb_ManejaFolioManualNo = New System.Windows.Forms.RadioButton()
        Me.rdb_ManejaFolioManualSi = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.rdb_ManejaDepositoManualNo = New System.Windows.Forms.RadioButton()
        Me.rdb_ManejaDepositoManualSi = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdb_WebServiceNo = New System.Windows.Forms.RadioButton()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.rdb_WebServiceSi = New System.Windows.Forms.RadioButton()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.Tab_Parametros.SuspendLayout()
        Me.tbp_ConexionCentral.SuspendLayout()
        Me.gbx_ConexionSA.SuspendLayout()
        Me.tbp_datos.SuspendLayout()
        Me.gbx_Sucursal.SuspendLayout()
        Me.tbp_SizeFuente.SuspendLayout()
        Me.gbx_Tiempo.SuspendLayout()
        CType(Me.pic_BuscarPuertos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp_Cajero.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.btn_TeamViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbx_NumValidadores.SuspendLayout()
        CType(Me.spc_Validadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spc_Validadores.Panel1.SuspendLayout()
        Me.spc_Validadores.Panel2.SuspendLayout()
        Me.spc_Validadores.SuspendLayout()
        Me.gbx_StatusVal1.SuspendLayout()
        Me.gbx_StatusVal2.SuspendLayout()
        Me.tbp_TipoCambio.SuspendLayout()
        Me.gbx_TipoCambio.SuspendLayout()
        Me.tbp_ConexionAdmin.SuspendLayout()
        Me.gbx_Conexion.SuspendLayout()
        Me.gbx_Conectado.SuspendLayout()
        Me.gbx_Prioridad.SuspendLayout()
        Me.gbx_Actualizar.SuspendLayout()
        Me.tbp_Impresora.SuspendLayout()
        Me.gbx_Papel.SuspendLayout()
        CType(Me.pct_ImgEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbx_Sizepapel.SuspendLayout()
        Me.gbx_DetalleCD.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grp_ConexionWebS.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gbx_verificarfolio.SuspendLayout()
        Me.grp_CorteDiario.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmb_MsgFuente
        '
        Me.cmb_MsgFuente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_MsgFuente.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_MsgFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_MsgFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_MsgFuente.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_MsgFuente.FormattingEnabled = True
        Me.cmb_MsgFuente.Items.AddRange(New Object() {"8", "10", "12", "14", "16", "18", "22", "28", "36"})
        Me.cmb_MsgFuente.Location = New System.Drawing.Point(473, 284)
        Me.cmb_MsgFuente.Name = "cmb_MsgFuente"
        Me.cmb_MsgFuente.Size = New System.Drawing.Size(152, 40)
        Me.cmb_MsgFuente.TabIndex = 11
        '
        'cmb_cmdFuente
        '
        Me.cmb_cmdFuente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_cmdFuente.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_cmdFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_cmdFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_cmdFuente.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_cmdFuente.FormattingEnabled = True
        Me.cmb_cmdFuente.Location = New System.Drawing.Point(473, 146)
        Me.cmb_cmdFuente.Name = "cmb_cmdFuente"
        Me.cmb_cmdFuente.Size = New System.Drawing.Size(152, 40)
        Me.cmb_cmdFuente.TabIndex = 5
        '
        'cmb_lblFuente
        '
        Me.cmb_lblFuente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_lblFuente.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_lblFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_lblFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_lblFuente.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_lblFuente.FormattingEnabled = True
        Me.cmb_lblFuente.Location = New System.Drawing.Point(473, 100)
        Me.cmb_lblFuente.Name = "cmb_lblFuente"
        Me.cmb_lblFuente.Size = New System.Drawing.Size(152, 40)
        Me.cmb_lblFuente.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(194, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tamaño de Fuente de Botones"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(279, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tamaño de Fuente de Etiquetas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_MsgFuente
        '
        Me.lbl_MsgFuente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_MsgFuente.AutoSize = True
        Me.lbl_MsgFuente.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgFuente.Location = New System.Drawing.Point(187, 294)
        Me.lbl_MsgFuente.Name = "lbl_MsgFuente"
        Me.lbl_MsgFuente.Size = New System.Drawing.Size(275, 22)
        Me.lbl_MsgFuente.TabIndex = 2
        Me.lbl_MsgFuente.Text = "Tamaño de Fuente del Mensaje"
        '
        'lbl_Conectividad
        '
        Me.lbl_Conectividad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Conectividad.AutoSize = True
        Me.lbl_Conectividad.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Conectividad.Location = New System.Drawing.Point(10, 107)
        Me.lbl_Conectividad.Name = "lbl_Conectividad"
        Me.lbl_Conectividad.Size = New System.Drawing.Size(152, 24)
        Me.lbl_Conectividad.TabIndex = 0
        Me.lbl_Conectividad.Text = "Sincronización:"
        '
        'Tab_Parametros
        '
        Me.Tab_Parametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab_Parametros.Controls.Add(Me.tbp_ConexionCentral)
        Me.Tab_Parametros.Controls.Add(Me.tbp_datos)
        Me.Tab_Parametros.Controls.Add(Me.tbp_SizeFuente)
        Me.Tab_Parametros.Controls.Add(Me.tbp_Cajero)
        Me.Tab_Parametros.Controls.Add(Me.tbp_TipoCambio)
        Me.Tab_Parametros.Controls.Add(Me.tbp_ConexionAdmin)
        Me.Tab_Parametros.Controls.Add(Me.tbp_Impresora)
        Me.Tab_Parametros.Controls.Add(Me.TabPage1)
        Me.Tab_Parametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_Parametros.Location = New System.Drawing.Point(4, 6)
        Me.Tab_Parametros.Name = "Tab_Parametros"
        Me.Tab_Parametros.SelectedIndex = 0
        Me.Tab_Parametros.Size = New System.Drawing.Size(959, 558)
        Me.Tab_Parametros.TabIndex = 0
        '
        'tbp_ConexionCentral
        '
        Me.tbp_ConexionCentral.Controls.Add(Me.gbx_ConexionSA)
        Me.tbp_ConexionCentral.Location = New System.Drawing.Point(4, 38)
        Me.tbp_ConexionCentral.Name = "tbp_ConexionCentral"
        Me.tbp_ConexionCentral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_ConexionCentral.Size = New System.Drawing.Size(951, 516)
        Me.tbp_ConexionCentral.TabIndex = 1
        Me.tbp_ConexionCentral.Text = "Conexion"
        Me.tbp_ConexionCentral.UseVisualStyleBackColor = True
        '
        'gbx_ConexionSA
        '
        Me.gbx_ConexionSA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_ConexionSA.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_HostIP)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_HostIP)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_Servidor)
        Me.gbx_ConexionSA.Controls.Add(Me.btn_DesktopSize)
        Me.gbx_ConexionSA.Controls.Add(Me.chk_BD)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_Width)
        Me.gbx_ConexionSA.Controls.Add(Me.chk_User)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_Width)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_Height)
        Me.gbx_ConexionSA.Controls.Add(Me.chk_Servidor)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_Height)
        Me.gbx_ConexionSA.Controls.Add(Me.chk_Password)
        Me.gbx_ConexionSA.Controls.Add(Me.chk_ClaveUnica)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_Servidor)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_BDD)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_BDD)
        Me.gbx_ConexionSA.Controls.Add(Me.rdb_NoconectaSA)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_Usuario)
        Me.gbx_ConexionSA.Controls.Add(Me.rdb_SiConectaSA)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_Usuario)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_Conectividad)
        Me.gbx_ConexionSA.Controls.Add(Me.chk_Taskbar)
        Me.gbx_ConexionSA.Controls.Add(Me.lbl_Password)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_ClaveUnica)
        Me.gbx_ConexionSA.Controls.Add(Me.tbx_Password)
        Me.gbx_ConexionSA.Controls.Add(Me.Label11)
        Me.gbx_ConexionSA.Controls.Add(Me.btn_ConectarBDD)
        Me.gbx_ConexionSA.Location = New System.Drawing.Point(6, 2)
        Me.gbx_ConexionSA.Name = "gbx_ConexionSA"
        Me.gbx_ConexionSA.Size = New System.Drawing.Size(947, 518)
        Me.gbx_ConexionSA.TabIndex = 25
        Me.gbx_ConexionSA.TabStop = False
        '
        'tbx_HostIP
        '
        Me.tbx_HostIP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_HostIP.Enabled = False
        Me.tbx_HostIP.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_HostIP.Location = New System.Drawing.Point(203, 284)
        Me.tbx_HostIP.MaxLength = 60
        Me.tbx_HostIP.Name = "tbx_HostIP"
        Me.tbx_HostIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_HostIP.Size = New System.Drawing.Size(185, 32)
        Me.tbx_HostIP.TabIndex = 26
        '
        'lbl_HostIP
        '
        Me.lbl_HostIP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_HostIP.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HostIP.Location = New System.Drawing.Point(6, 290)
        Me.lbl_HostIP.Name = "lbl_HostIP"
        Me.lbl_HostIP.Size = New System.Drawing.Size(198, 31)
        Me.lbl_HostIP.TabIndex = 25
        Me.lbl_HostIP.Text = "Host ó IP para Ping:"
        '
        'tbx_Servidor
        '
        Me.tbx_Servidor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Servidor.Enabled = False
        Me.tbx_Servidor.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Servidor.Location = New System.Drawing.Point(203, 175)
        Me.tbx_Servidor.MaxLength = 60
        Me.tbx_Servidor.Name = "tbx_Servidor"
        Me.tbx_Servidor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Servidor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_Servidor.Size = New System.Drawing.Size(499, 32)
        Me.tbx_Servidor.TabIndex = 4
        '
        'btn_DesktopSize
        '
        Me.btn_DesktopSize.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DesktopSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_DesktopSize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_DesktopSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DesktopSize.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DesktopSize.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_DesktopSize
        Me.btn_DesktopSize.Location = New System.Drawing.Point(514, 374)
        Me.btn_DesktopSize.Name = "btn_DesktopSize"
        Me.btn_DesktopSize.Size = New System.Drawing.Size(287, 45)
        Me.btn_DesktopSize.TabIndex = 19
        Me.btn_DesktopSize.Text = "Obtener Tamaño Monitor"
        Me.btn_DesktopSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DesktopSize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_DesktopSize.UseVisualStyleBackColor = False
        '
        'chk_BD
        '
        Me.chk_BD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_BD.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_BD.AutoSize = True
        Me.chk_BD.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_BD.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_BD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_BD.Location = New System.Drawing.Point(394, 210)
        Me.chk_BD.Name = "chk_BD"
        Me.chk_BD.Size = New System.Drawing.Size(75, 34)
        Me.chk_BD.TabIndex = 22
        Me.chk_BD.Text = "Ver"
        Me.chk_BD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_BD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_BD.UseVisualStyleBackColor = True
        '
        'lbl_Width
        '
        Me.lbl_Width.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Width.AutoSize = True
        Me.lbl_Width.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Width.Location = New System.Drawing.Point(530, 341)
        Me.lbl_Width.Name = "lbl_Width"
        Me.lbl_Width.Size = New System.Drawing.Size(68, 24)
        Me.lbl_Width.TabIndex = 15
        Me.lbl_Width.Text = "Ancho"
        '
        'chk_User
        '
        Me.chk_User.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_User.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_User.AutoSize = True
        Me.chk_User.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_User.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_User.Location = New System.Drawing.Point(709, 245)
        Me.chk_User.Name = "chk_User"
        Me.chk_User.Size = New System.Drawing.Size(75, 34)
        Me.chk_User.TabIndex = 23
        Me.chk_User.Text = "Ver"
        Me.chk_User.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_User.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_User.UseVisualStyleBackColor = True
        '
        'tbx_Width
        '
        Me.tbx_Width.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Width.BackColor = System.Drawing.Color.SteelBlue
        Me.tbx_Width.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Width.Location = New System.Drawing.Point(604, 339)
        Me.tbx_Width.MaxLength = 4
        Me.tbx_Width.Name = "tbx_Width"
        Me.tbx_Width.ReadOnly = True
        Me.tbx_Width.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_Width.Size = New System.Drawing.Size(70, 32)
        Me.tbx_Width.TabIndex = 16
        '
        'lbl_Height
        '
        Me.lbl_Height.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Height.AutoSize = True
        Me.lbl_Height.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Height.Location = New System.Drawing.Point(680, 341)
        Me.lbl_Height.Name = "lbl_Height"
        Me.lbl_Height.Size = New System.Drawing.Size(45, 24)
        Me.lbl_Height.TabIndex = 17
        Me.lbl_Height.Text = "Alto"
        '
        'chk_Servidor
        '
        Me.chk_Servidor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_Servidor.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_Servidor.AutoSize = True
        Me.chk_Servidor.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Servidor.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_Servidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_Servidor.Location = New System.Drawing.Point(709, 172)
        Me.chk_Servidor.Name = "chk_Servidor"
        Me.chk_Servidor.Size = New System.Drawing.Size(75, 34)
        Me.chk_Servidor.TabIndex = 21
        Me.chk_Servidor.Text = "Ver"
        Me.chk_Servidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Servidor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Servidor.UseVisualStyleBackColor = True
        '
        'tbx_Height
        '
        Me.tbx_Height.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Height.BackColor = System.Drawing.Color.SteelBlue
        Me.tbx_Height.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Height.Location = New System.Drawing.Point(730, 339)
        Me.tbx_Height.MaxLength = 4
        Me.tbx_Height.Name = "tbx_Height"
        Me.tbx_Height.ReadOnly = True
        Me.tbx_Height.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_Height.Size = New System.Drawing.Size(70, 32)
        Me.tbx_Height.TabIndex = 18
        '
        'chk_Password
        '
        Me.chk_Password.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_Password.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_Password.AutoSize = True
        Me.chk_Password.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Password.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_Password.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_Password.Location = New System.Drawing.Point(394, 245)
        Me.chk_Password.Name = "chk_Password"
        Me.chk_Password.Size = New System.Drawing.Size(75, 34)
        Me.chk_Password.TabIndex = 24
        Me.chk_Password.Text = "Ver"
        Me.chk_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Password.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Password.UseVisualStyleBackColor = True
        '
        'chk_ClaveUnica
        '
        Me.chk_ClaveUnica.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_ClaveUnica.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_ClaveUnica.AutoSize = True
        Me.chk_ClaveUnica.Checked = True
        Me.chk_ClaveUnica.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_ClaveUnica.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_ClaveUnica.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Checked_24x24
        Me.chk_ClaveUnica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_ClaveUnica.Location = New System.Drawing.Point(514, 140)
        Me.chk_ClaveUnica.Name = "chk_ClaveUnica"
        Me.chk_ClaveUnica.Size = New System.Drawing.Size(75, 34)
        Me.chk_ClaveUnica.TabIndex = 20
        Me.chk_ClaveUnica.Text = "Ver"
        Me.chk_ClaveUnica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_ClaveUnica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_ClaveUnica.UseVisualStyleBackColor = True
        '
        'lbl_Servidor
        '
        Me.lbl_Servidor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Servidor.AutoSize = True
        Me.lbl_Servidor.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Servidor.Location = New System.Drawing.Point(10, 182)
        Me.lbl_Servidor.Name = "lbl_Servidor"
        Me.lbl_Servidor.Size = New System.Drawing.Size(95, 24)
        Me.lbl_Servidor.TabIndex = 3
        Me.lbl_Servidor.Text = "Servidor:"
        '
        'lbl_BDD
        '
        Me.lbl_BDD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_BDD.AutoSize = True
        Me.lbl_BDD.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BDD.Location = New System.Drawing.Point(7, 216)
        Me.lbl_BDD.Name = "lbl_BDD"
        Me.lbl_BDD.Size = New System.Drawing.Size(156, 24)
        Me.lbl_BDD.TabIndex = 5
        Me.lbl_BDD.Text = "Base de Datos:"
        '
        'tbx_BDD
        '
        Me.tbx_BDD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_BDD.Enabled = False
        Me.tbx_BDD.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_BDD.Location = New System.Drawing.Point(203, 210)
        Me.tbx_BDD.MaxLength = 50
        Me.tbx_BDD.Name = "tbx_BDD"
        Me.tbx_BDD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_BDD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_BDD.Size = New System.Drawing.Size(185, 32)
        Me.tbx_BDD.TabIndex = 6
        '
        'rdb_NoconectaSA
        '
        Me.rdb_NoconectaSA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_NoconectaSA.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_NoconectaSA.AutoSize = True
        Me.rdb_NoconectaSA.Checked = True
        Me.rdb_NoconectaSA.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_NoconectaSA.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_NoconectaSA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_NoconectaSA.Location = New System.Drawing.Point(334, 102)
        Me.rdb_NoconectaSA.Name = "rdb_NoconectaSA"
        Me.rdb_NoconectaSA.Size = New System.Drawing.Size(174, 34)
        Me.rdb_NoconectaSA.TabIndex = 2
        Me.rdb_NoconectaSA.TabStop = True
        Me.rdb_NoconectaSA.Text = "Por intervalos"
        Me.rdb_NoconectaSA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_NoconectaSA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_NoconectaSA.UseVisualStyleBackColor = True
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Usuario.AutoSize = True
        Me.lbl_Usuario.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Usuario.Location = New System.Drawing.Point(515, 219)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(82, 24)
        Me.lbl_Usuario.TabIndex = 7
        Me.lbl_Usuario.Text = "Usuario"
        '
        'rdb_SiConectaSA
        '
        Me.rdb_SiConectaSA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_SiConectaSA.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_SiConectaSA.AutoSize = True
        Me.rdb_SiConectaSA.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_SiConectaSA.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_SiConectaSA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_SiConectaSA.Location = New System.Drawing.Point(203, 102)
        Me.rdb_SiConectaSA.Name = "rdb_SiConectaSA"
        Me.rdb_SiConectaSA.Size = New System.Drawing.Size(121, 34)
        Me.rdb_SiConectaSA.TabIndex = 1
        Me.rdb_SiConectaSA.Text = "Siempre"
        Me.rdb_SiConectaSA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_SiConectaSA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_SiConectaSA.UseVisualStyleBackColor = True
        '
        'tbx_Usuario
        '
        Me.tbx_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Usuario.Enabled = False
        Me.tbx_Usuario.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Usuario.Location = New System.Drawing.Point(518, 245)
        Me.tbx_Usuario.MaxLength = 50
        Me.tbx_Usuario.Name = "tbx_Usuario"
        Me.tbx_Usuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Usuario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_Usuario.Size = New System.Drawing.Size(185, 32)
        Me.tbx_Usuario.TabIndex = 8
        '
        'chk_Taskbar
        '
        Me.chk_Taskbar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_Taskbar.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_Taskbar.AutoSize = True
        Me.chk_Taskbar.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Taskbar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_Taskbar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_Taskbar.Location = New System.Drawing.Point(604, 292)
        Me.chk_Taskbar.Name = "chk_Taskbar"
        Me.chk_Taskbar.Size = New System.Drawing.Size(190, 34)
        Me.chk_Taskbar.TabIndex = 14
        Me.chk_Taskbar.Text = "Taskbar Ocultar"
        Me.chk_Taskbar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Taskbar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Taskbar.UseVisualStyleBackColor = True
        '
        'lbl_Password
        '
        Me.lbl_Password.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Password.AutoSize = True
        Me.lbl_Password.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Password.Location = New System.Drawing.Point(6, 250)
        Me.lbl_Password.Name = "lbl_Password"
        Me.lbl_Password.Size = New System.Drawing.Size(125, 24)
        Me.lbl_Password.TabIndex = 9
        Me.lbl_Password.Text = "Contraseña:"
        '
        'tbx_ClaveUnica
        '
        Me.tbx_ClaveUnica.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_ClaveUnica.BackColor = System.Drawing.SystemColors.Info
        Me.tbx_ClaveUnica.Enabled = False
        Me.tbx_ClaveUnica.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ClaveUnica.Location = New System.Drawing.Point(203, 140)
        Me.tbx_ClaveUnica.MaxLength = 50
        Me.tbx_ClaveUnica.Name = "tbx_ClaveUnica"
        Me.tbx_ClaveUnica.Size = New System.Drawing.Size(304, 32)
        Me.tbx_ClaveUnica.TabIndex = 13
        '
        'tbx_Password
        '
        Me.tbx_Password.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Password.Enabled = False
        Me.tbx_Password.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Password.Location = New System.Drawing.Point(203, 245)
        Me.tbx_Password.MaxLength = 50
        Me.tbx_Password.Name = "tbx_Password"
        Me.tbx_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Password.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbx_Password.Size = New System.Drawing.Size(185, 32)
        Me.tbx_Password.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 24)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Clave Única:"
        '
        'btn_ConectarBDD
        '
        Me.btn_ConectarBDD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_ConectarBDD.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_ConectarBDD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ConectarBDD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ConectarBDD.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ConectarBDD.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Conectar
        Me.btn_ConectarBDD.Location = New System.Drawing.Point(203, 373)
        Me.btn_ConectarBDD.Name = "btn_ConectarBDD"
        Me.btn_ConectarBDD.Size = New System.Drawing.Size(266, 44)
        Me.btn_ConectarBDD.TabIndex = 11
        Me.btn_ConectarBDD.Text = "Co&nectar Central"
        Me.btn_ConectarBDD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ConectarBDD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ConectarBDD.UseVisualStyleBackColor = False
        '
        'tbp_datos
        '
        Me.tbp_datos.Controls.Add(Me.gbx_Sucursal)
        Me.tbp_datos.Location = New System.Drawing.Point(4, 38)
        Me.tbp_datos.Name = "tbp_datos"
        Me.tbp_datos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_datos.Size = New System.Drawing.Size(951, 516)
        Me.tbp_datos.TabIndex = 0
        Me.tbp_datos.Text = "Sucursal"
        Me.tbp_datos.UseVisualStyleBackColor = True
        '
        'gbx_Sucursal
        '
        Me.gbx_Sucursal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Sucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.gbx_Sucursal.Controls.Add(Me.lbl_Cajero)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_IdCajero)
        Me.gbx_Sucursal.Controls.Add(Me.Label21)
        Me.gbx_Sucursal.Controls.Add(Me.btn_FechaInicioOperaciones)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_Mail)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_RutaLog)
        Me.gbx_Sucursal.Controls.Add(Me.btn_DestinoLog)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_Mail)
        Me.gbx_Sucursal.Controls.Add(Me.Label6)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_SucursalNombre)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_NombreCorto)
        Me.gbx_Sucursal.Controls.Add(Me.btn_AgregaCaset)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_NombreCorto)
        Me.gbx_Sucursal.Controls.Add(Me.btn_Sincronizar)
        Me.gbx_Sucursal.Controls.Add(Me.btn_Actualizar)
        Me.gbx_Sucursal.Controls.Add(Me.cmb_ClaveSucursal)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_SucursalN)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_ClaveSucursal)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_Cliente)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_Cliente)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_ClaveCliente)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_Telefono)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_Domicilio)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_Tel)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_CiaTV)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_Cvecliente)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_Direccion)
        Me.gbx_Sucursal.Controls.Add(Me.lbl_ClaveSucursal)
        Me.gbx_Sucursal.Controls.Add(Me.tbx_CiaTV)
        Me.gbx_Sucursal.Location = New System.Drawing.Point(3, 0)
        Me.gbx_Sucursal.Name = "gbx_Sucursal"
        Me.gbx_Sucursal.Size = New System.Drawing.Size(952, 520)
        Me.gbx_Sucursal.TabIndex = 0
        Me.gbx_Sucursal.TabStop = False
        '
        'lbl_Cajero
        '
        Me.lbl_Cajero.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Cajero.AutoSize = True
        Me.lbl_Cajero.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Cajero.Location = New System.Drawing.Point(615, 240)
        Me.lbl_Cajero.Name = "lbl_Cajero"
        Me.lbl_Cajero.Size = New System.Drawing.Size(66, 22)
        Me.lbl_Cajero.TabIndex = 24
        Me.lbl_Cajero.Text = "Cajero"
        '
        'tbx_IdCajero
        '
        Me.tbx_IdCajero.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_IdCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_IdCajero.Location = New System.Drawing.Point(705, 236)
        Me.tbx_IdCajero.MaxLength = 12
        Me.tbx_IdCajero.Name = "tbx_IdCajero"
        Me.tbx_IdCajero.Size = New System.Drawing.Size(153, 29)
        Me.tbx_IdCajero.TabIndex = 25
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(122, 264)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(147, 49)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Fecha Inicio de Operaciones"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_FechaInicioOperaciones
        '
        Me.btn_FechaInicioOperaciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_FechaInicioOperaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaInicioOperaciones.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaInicioOperaciones.Location = New System.Drawing.Point(275, 269)
        Me.btn_FechaInicioOperaciones.Name = "btn_FechaInicioOperaciones"
        Me.btn_FechaInicioOperaciones.Size = New System.Drawing.Size(161, 44)
        Me.btn_FechaInicioOperaciones.TabIndex = 19
        Me.btn_FechaInicioOperaciones.Tag = "1"
        Me.btn_FechaInicioOperaciones.Text = "06/08/2016"
        Me.btn_FechaInicioOperaciones.UseVisualStyleBackColor = False
        '
        'lbl_Mail
        '
        Me.lbl_Mail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Mail.AutoSize = True
        Me.lbl_Mail.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mail.Location = New System.Drawing.Point(226, 205)
        Me.lbl_Mail.Name = "lbl_Mail"
        Me.lbl_Mail.Size = New System.Drawing.Size(43, 22)
        Me.lbl_Mail.TabIndex = 14
        Me.lbl_Mail.Text = "Mail"
        '
        'lbl_RutaLog
        '
        Me.lbl_RutaLog.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_RutaLog.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RutaLog.Location = New System.Drawing.Point(96, 326)
        Me.lbl_RutaLog.Name = "lbl_RutaLog"
        Me.lbl_RutaLog.Size = New System.Drawing.Size(759, 26)
        Me.lbl_RutaLog.TabIndex = 6
        Me.lbl_RutaLog.Text = "__"
        Me.lbl_RutaLog.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn_DestinoLog
        '
        Me.btn_DestinoLog.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DestinoLog.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DestinoLog.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Examinar
        Me.btn_DestinoLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_DestinoLog.Location = New System.Drawing.Point(705, 282)
        Me.btn_DestinoLog.Name = "btn_DestinoLog"
        Me.btn_DestinoLog.Size = New System.Drawing.Size(88, 40)
        Me.btn_DestinoLog.TabIndex = 5
        Me.btn_DestinoLog.Text = "..."
        Me.btn_DestinoLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DestinoLog.UseVisualStyleBackColor = True
        '
        'tbx_Mail
        '
        Me.tbx_Mail.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Mail.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Mail.Location = New System.Drawing.Point(275, 201)
        Me.tbx_Mail.MaxLength = 50
        Me.tbx_Mail.Name = "tbx_Mail"
        Me.tbx_Mail.Size = New System.Drawing.Size(282, 29)
        Me.tbx_Mail.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(579, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 22)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Ruta del Log"
        '
        'tbx_SucursalNombre
        '
        Me.tbx_SucursalNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_SucursalNombre.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_SucursalNombre.Location = New System.Drawing.Point(275, 73)
        Me.tbx_SucursalNombre.MaxLength = 50
        Me.tbx_SucursalNombre.Name = "tbx_SucursalNombre"
        Me.tbx_SucursalNombre.Size = New System.Drawing.Size(583, 29)
        Me.tbx_SucursalNombre.TabIndex = 1
        '
        'tbx_NombreCorto
        '
        Me.tbx_NombreCorto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_NombreCorto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_NombreCorto.Location = New System.Drawing.Point(705, 105)
        Me.tbx_NombreCorto.MaxLength = 14
        Me.tbx_NombreCorto.Name = "tbx_NombreCorto"
        Me.tbx_NombreCorto.Size = New System.Drawing.Size(153, 29)
        Me.tbx_NombreCorto.TabIndex = 5
        '
        'btn_AgregaCaset
        '
        Me.btn_AgregaCaset.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_AgregaCaset.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_AgregaCaset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_AgregaCaset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AgregaCaset.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregaCaset.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CatalogoCaset
        Me.btn_AgregaCaset.Location = New System.Drawing.Point(691, 355)
        Me.btn_AgregaCaset.Name = "btn_AgregaCaset"
        Me.btn_AgregaCaset.Size = New System.Drawing.Size(164, 75)
        Me.btn_AgregaCaset.TabIndex = 23
        Me.btn_AgregaCaset.Text = "Cartuchos"
        Me.btn_AgregaCaset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregaCaset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_AgregaCaset.UseVisualStyleBackColor = False
        '
        'lbl_NombreCorto
        '
        Me.lbl_NombreCorto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_NombreCorto.AutoSize = True
        Me.lbl_NombreCorto.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NombreCorto.Location = New System.Drawing.Point(570, 109)
        Me.lbl_NombreCorto.Name = "lbl_NombreCorto"
        Me.lbl_NombreCorto.Size = New System.Drawing.Size(130, 22)
        Me.lbl_NombreCorto.TabIndex = 4
        Me.lbl_NombreCorto.Text = "Nombre Corto"
        '
        'btn_Sincronizar
        '
        Me.btn_Sincronizar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Sincronizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Sincronizar.Enabled = False
        Me.btn_Sincronizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Sincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Sincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Sincronizar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Sincronizar
        Me.btn_Sincronizar.Location = New System.Drawing.Point(272, 355)
        Me.btn_Sincronizar.Name = "btn_Sincronizar"
        Me.btn_Sincronizar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Sincronizar.TabIndex = 21
        Me.btn_Sincronizar.Text = "&Sincronizar"
        Me.btn_Sincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Sincronizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Sincronizar.UseVisualStyleBackColor = False
        '
        'btn_Actualizar
        '
        Me.btn_Actualizar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Actualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Actualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Actualizar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.BajaReing
        Me.btn_Actualizar.Location = New System.Drawing.Point(484, 355)
        Me.btn_Actualizar.Name = "btn_Actualizar"
        Me.btn_Actualizar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Actualizar.TabIndex = 22
        Me.btn_Actualizar.Text = "Ejem. Actualizar"
        Me.btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Actualizar.UseVisualStyleBackColor = False
        Me.btn_Actualizar.Visible = False
        '
        'cmb_ClaveSucursal
        '
        Me.cmb_ClaveSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_ClaveSucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_ClaveSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ClaveSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_ClaveSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_ClaveSucursal.FormattingEnabled = True
        Me.cmb_ClaveSucursal.Location = New System.Drawing.Point(114, 377)
        Me.cmb_ClaveSucursal.MaxDropDownItems = 20
        Me.cmb_ClaveSucursal.Name = "cmb_ClaveSucursal"
        Me.cmb_ClaveSucursal.Size = New System.Drawing.Size(151, 32)
        Me.cmb_ClaveSucursal.TabIndex = 20
        Me.cmb_ClaveSucursal.Visible = False
        '
        'lbl_SucursalN
        '
        Me.lbl_SucursalN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_SucursalN.AutoSize = True
        Me.lbl_SucursalN.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SucursalN.Location = New System.Drawing.Point(113, 73)
        Me.lbl_SucursalN.Name = "lbl_SucursalN"
        Me.lbl_SucursalN.Size = New System.Drawing.Size(156, 22)
        Me.lbl_SucursalN.TabIndex = 0
        Me.lbl_SucursalN.Text = "Nombre Sucursal"
        '
        'tbx_ClaveSucursal
        '
        Me.tbx_ClaveSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_ClaveSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ClaveSucursal.Location = New System.Drawing.Point(705, 137)
        Me.tbx_ClaveSucursal.MaxLength = 5
        Me.tbx_ClaveSucursal.Name = "tbx_ClaveSucursal"
        Me.tbx_ClaveSucursal.Size = New System.Drawing.Size(153, 29)
        Me.tbx_ClaveSucursal.TabIndex = 9
        '
        'tbx_Cliente
        '
        Me.tbx_Cliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Cliente.Location = New System.Drawing.Point(275, 105)
        Me.tbx_Cliente.MaxLength = 50
        Me.tbx_Cliente.Name = "tbx_Cliente"
        Me.tbx_Cliente.Size = New System.Drawing.Size(282, 29)
        Me.tbx_Cliente.TabIndex = 3
        '
        'lbl_Cliente
        '
        Me.lbl_Cliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Cliente.AutoSize = True
        Me.lbl_Cliente.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Cliente.Location = New System.Drawing.Point(96, 109)
        Me.lbl_Cliente.Name = "lbl_Cliente"
        Me.lbl_Cliente.Size = New System.Drawing.Size(173, 22)
        Me.lbl_Cliente.TabIndex = 2
        Me.lbl_Cliente.Text = "Nombre del Cliente"
        '
        'tbx_ClaveCliente
        '
        Me.tbx_ClaveCliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_ClaveCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ClaveCliente.Location = New System.Drawing.Point(705, 169)
        Me.tbx_ClaveCliente.MaxLength = 12
        Me.tbx_ClaveCliente.Name = "tbx_ClaveCliente"
        Me.tbx_ClaveCliente.Size = New System.Drawing.Size(153, 29)
        Me.tbx_ClaveCliente.TabIndex = 13
        '
        'lbl_Telefono
        '
        Me.lbl_Telefono.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Telefono.AutoSize = True
        Me.lbl_Telefono.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Telefono.Location = New System.Drawing.Point(615, 205)
        Me.lbl_Telefono.Name = "lbl_Telefono"
        Me.lbl_Telefono.Size = New System.Drawing.Size(84, 22)
        Me.lbl_Telefono.TabIndex = 16
        Me.lbl_Telefono.Text = "Telefono"
        '
        'lbl_Domicilio
        '
        Me.lbl_Domicilio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Domicilio.AutoSize = True
        Me.lbl_Domicilio.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Domicilio.Location = New System.Drawing.Point(181, 141)
        Me.lbl_Domicilio.Name = "lbl_Domicilio"
        Me.lbl_Domicilio.Size = New System.Drawing.Size(88, 22)
        Me.lbl_Domicilio.TabIndex = 6
        Me.lbl_Domicilio.Text = "Domicilio"
        '
        'tbx_Tel
        '
        Me.tbx_Tel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Tel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Tel.Location = New System.Drawing.Point(705, 201)
        Me.tbx_Tel.MaxLength = 12
        Me.tbx_Tel.Name = "tbx_Tel"
        Me.tbx_Tel.Size = New System.Drawing.Size(153, 29)
        Me.tbx_Tel.TabIndex = 17
        '
        'lbl_CiaTV
        '
        Me.lbl_CiaTV.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_CiaTV.AutoSize = True
        Me.lbl_CiaTV.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CiaTV.Location = New System.Drawing.Point(143, 173)
        Me.lbl_CiaTV.Name = "lbl_CiaTV"
        Me.lbl_CiaTV.Size = New System.Drawing.Size(126, 22)
        Me.lbl_CiaTV.TabIndex = 10
        Me.lbl_CiaTV.Text = "Compañia TV"
        '
        'lbl_Cvecliente
        '
        Me.lbl_Cvecliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Cvecliente.AutoSize = True
        Me.lbl_Cvecliente.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Cvecliente.Location = New System.Drawing.Point(579, 173)
        Me.lbl_Cvecliente.Name = "lbl_Cvecliente"
        Me.lbl_Cvecliente.Size = New System.Drawing.Size(122, 22)
        Me.lbl_Cvecliente.TabIndex = 12
        Me.lbl_Cvecliente.Text = "Clave Cliente"
        '
        'tbx_Direccion
        '
        Me.tbx_Direccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Direccion.Location = New System.Drawing.Point(275, 137)
        Me.tbx_Direccion.MaxLength = 50
        Me.tbx_Direccion.Name = "tbx_Direccion"
        Me.tbx_Direccion.Size = New System.Drawing.Size(282, 29)
        Me.tbx_Direccion.TabIndex = 7
        '
        'lbl_ClaveSucursal
        '
        Me.lbl_ClaveSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_ClaveSucursal.AutoSize = True
        Me.lbl_ClaveSucursal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ClaveSucursal.Location = New System.Drawing.Point(564, 141)
        Me.lbl_ClaveSucursal.Name = "lbl_ClaveSucursal"
        Me.lbl_ClaveSucursal.Size = New System.Drawing.Size(136, 22)
        Me.lbl_ClaveSucursal.TabIndex = 8
        Me.lbl_ClaveSucursal.Text = "Clave Sucursal"
        '
        'tbx_CiaTV
        '
        Me.tbx_CiaTV.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_CiaTV.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_CiaTV.Location = New System.Drawing.Point(275, 169)
        Me.tbx_CiaTV.MaxLength = 100
        Me.tbx_CiaTV.Name = "tbx_CiaTV"
        Me.tbx_CiaTV.Size = New System.Drawing.Size(282, 29)
        Me.tbx_CiaTV.TabIndex = 11
        '
        'tbp_SizeFuente
        '
        Me.tbp_SizeFuente.Controls.Add(Me.gbx_Tiempo)
        Me.tbp_SizeFuente.Location = New System.Drawing.Point(4, 38)
        Me.tbp_SizeFuente.Name = "tbp_SizeFuente"
        Me.tbp_SizeFuente.Size = New System.Drawing.Size(951, 516)
        Me.tbp_SizeFuente.TabIndex = 2
        Me.tbp_SizeFuente.Text = "Tiempo-Fuente"
        Me.tbp_SizeFuente.UseVisualStyleBackColor = True
        '
        'gbx_Tiempo
        '
        Me.gbx_Tiempo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Tiempo.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.gbx_Tiempo.Controls.Add(Me.pic_BuscarPuertos)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_puertoSensor)
        Me.gbx_Tiempo.Controls.Add(Me.lbl_puertoSensor)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_PorcBateriaCritica)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_PorcBateriaBaja)
        Me.gbx_Tiempo.Controls.Add(Me.lbl_BateriaBaja)
        Me.gbx_Tiempo.Controls.Add(Me.lbl_BateriaCritica)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_MsgFuente)
        Me.gbx_Tiempo.Controls.Add(Me.Label8)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_TiempoReceptor)
        Me.gbx_Tiempo.Controls.Add(Me.tbx_DiasExpira)
        Me.gbx_Tiempo.Controls.Add(Me.Label4)
        Me.gbx_Tiempo.Controls.Add(Me.Label7)
        Me.gbx_Tiempo.Controls.Add(Me.Label10)
        Me.gbx_Tiempo.Controls.Add(Me.Label2)
        Me.gbx_Tiempo.Controls.Add(Me.Label1)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_lblFuente)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_cmdFuente)
        Me.gbx_Tiempo.Controls.Add(Me.cmb_TiempoSesion)
        Me.gbx_Tiempo.Controls.Add(Me.Label5)
        Me.gbx_Tiempo.Controls.Add(Me.lbl_MsgFuente)
        Me.gbx_Tiempo.Controls.Add(Me.Label9)
        Me.gbx_Tiempo.Location = New System.Drawing.Point(3, 3)
        Me.gbx_Tiempo.Name = "gbx_Tiempo"
        Me.gbx_Tiempo.Size = New System.Drawing.Size(948, 517)
        Me.gbx_Tiempo.TabIndex = 38
        Me.gbx_Tiempo.TabStop = False
        '
        'pic_BuscarPuertos
        '
        Me.pic_BuscarPuertos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pic_BuscarPuertos.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Escanear
        Me.pic_BuscarPuertos.Location = New System.Drawing.Point(644, 424)
        Me.pic_BuscarPuertos.Name = "pic_BuscarPuertos"
        Me.pic_BuscarPuertos.Size = New System.Drawing.Size(41, 40)
        Me.pic_BuscarPuertos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pic_BuscarPuertos.TabIndex = 44
        Me.pic_BuscarPuertos.TabStop = False
        '
        'cmb_puertoSensor
        '
        Me.cmb_puertoSensor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_puertoSensor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_puertoSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_puertoSensor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_puertoSensor.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_puertoSensor.FormattingEnabled = True
        Me.cmb_puertoSensor.Location = New System.Drawing.Point(473, 424)
        Me.cmb_puertoSensor.Name = "cmb_puertoSensor"
        Me.cmb_puertoSensor.Size = New System.Drawing.Size(152, 40)
        Me.cmb_puertoSensor.TabIndex = 43
        '
        'lbl_puertoSensor
        '
        Me.lbl_puertoSensor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_puertoSensor.AutoSize = True
        Me.lbl_puertoSensor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puertoSensor.Location = New System.Drawing.Point(308, 434)
        Me.lbl_puertoSensor.Name = "lbl_puertoSensor"
        Me.lbl_puertoSensor.Size = New System.Drawing.Size(154, 24)
        Me.lbl_puertoSensor.TabIndex = 42
        Me.lbl_puertoSensor.Text = "Puerto de sensor"
        '
        'cmb_PorcBateriaCritica
        '
        Me.cmb_PorcBateriaCritica.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_PorcBateriaCritica.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_PorcBateriaCritica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_PorcBateriaCritica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_PorcBateriaCritica.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_PorcBateriaCritica.FormattingEnabled = True
        Me.cmb_PorcBateriaCritica.Items.AddRange(New Object() {"29", "28", "27", "26", "25", "24", "23", "22", "21", "20"})
        Me.cmb_PorcBateriaCritica.Location = New System.Drawing.Point(473, 376)
        Me.cmb_PorcBateriaCritica.Name = "cmb_PorcBateriaCritica"
        Me.cmb_PorcBateriaCritica.Size = New System.Drawing.Size(152, 40)
        Me.cmb_PorcBateriaCritica.TabIndex = 41
        '
        'cmb_PorcBateriaBaja
        '
        Me.cmb_PorcBateriaBaja.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_PorcBateriaBaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_PorcBateriaBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_PorcBateriaBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_PorcBateriaBaja.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_PorcBateriaBaja.FormattingEnabled = True
        Me.cmb_PorcBateriaBaja.Items.AddRange(New Object() {"65", "55", "50", "45", "40", "35", "30"})
        Me.cmb_PorcBateriaBaja.Location = New System.Drawing.Point(473, 330)
        Me.cmb_PorcBateriaBaja.Name = "cmb_PorcBateriaBaja"
        Me.cmb_PorcBateriaBaja.Size = New System.Drawing.Size(152, 40)
        Me.cmb_PorcBateriaBaja.TabIndex = 40
        '
        'lbl_BateriaBaja
        '
        Me.lbl_BateriaBaja.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_BateriaBaja.AutoSize = True
        Me.lbl_BateriaBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BateriaBaja.Location = New System.Drawing.Point(261, 340)
        Me.lbl_BateriaBaja.Name = "lbl_BateriaBaja"
        Me.lbl_BateriaBaja.Size = New System.Drawing.Size(203, 24)
        Me.lbl_BateriaBaja.TabIndex = 39
        Me.lbl_BateriaBaja.Text = "Porcentaje Batería Baja"
        '
        'lbl_BateriaCritica
        '
        Me.lbl_BateriaCritica.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_BateriaCritica.AutoSize = True
        Me.lbl_BateriaCritica.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BateriaCritica.Location = New System.Drawing.Point(244, 386)
        Me.lbl_BateriaCritica.Name = "lbl_BateriaCritica"
        Me.lbl_BateriaCritica.Size = New System.Drawing.Size(218, 24)
        Me.lbl_BateriaCritica.TabIndex = 38
        Me.lbl_BateriaCritica.Text = "Porcentaje Batería Crítica"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(600, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 22)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Segundos"
        '
        'cmb_TiempoReceptor
        '
        Me.cmb_TiempoReceptor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_TiempoReceptor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_TiempoReceptor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_TiempoReceptor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_TiempoReceptor.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_TiempoReceptor.FormattingEnabled = True
        Me.cmb_TiempoReceptor.Location = New System.Drawing.Point(473, 192)
        Me.cmb_TiempoReceptor.Name = "cmb_TiempoReceptor"
        Me.cmb_TiempoReceptor.Size = New System.Drawing.Size(121, 40)
        Me.cmb_TiempoReceptor.TabIndex = 0
        '
        'tbx_DiasExpira
        '
        Me.tbx_DiasExpira.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_DiasExpira.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_DiasExpira.Location = New System.Drawing.Point(473, 55)
        Me.tbx_DiasExpira.MaxLength = 3
        Me.tbx_DiasExpira.Name = "tbx_DiasExpira"
        Me.tbx_DiasExpira.Size = New System.Drawing.Size(121, 39)
        Me.tbx_DiasExpira.TabIndex = 37
        Me.tbx_DiasExpira.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(190, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(276, 22)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tiempo de Espera de Depósito"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(600, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 22)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Segundos"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(600, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 22)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Días"
        '
        'cmb_TiempoSesion
        '
        Me.cmb_TiempoSesion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_TiempoSesion.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_TiempoSesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_TiempoSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_TiempoSesion.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_TiempoSesion.FormattingEnabled = True
        Me.cmb_TiempoSesion.Location = New System.Drawing.Point(473, 238)
        Me.cmb_TiempoSesion.Name = "cmb_TiempoSesion"
        Me.cmb_TiempoSesion.Size = New System.Drawing.Size(121, 40)
        Me.cmb_TiempoSesion.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(227, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(239, 22)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Tiempo de Espera General"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(112, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(352, 22)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Días Expira Contraseña : entre 30  y 180"
        '
        'tbp_Cajero
        '
        Me.tbp_Cajero.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.tbp_Cajero.Controls.Add(Me.GroupBox4)
        Me.tbp_Cajero.Controls.Add(Me.gbx_NumValidadores)
        Me.tbp_Cajero.Controls.Add(Me.spc_Validadores)
        Me.tbp_Cajero.Location = New System.Drawing.Point(4, 38)
        Me.tbp_Cajero.Name = "tbp_Cajero"
        Me.tbp_Cajero.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Cajero.Size = New System.Drawing.Size(951, 516)
        Me.tbp_Cajero.TabIndex = 4
        Me.tbp_Cajero.Text = "Cajero"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btn_TeamViewer)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(383, 65)
        Me.GroupBox4.TabIndex = 52
        Me.GroupBox4.TabStop = False
        '
        'btn_TeamViewer
        '
        Me.btn_TeamViewer.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btn_TeamViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btn_TeamViewer.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Conectar
        Me.btn_TeamViewer.Location = New System.Drawing.Point(206, 17)
        Me.btn_TeamViewer.Name = "btn_TeamViewer"
        Me.btn_TeamViewer.Size = New System.Drawing.Size(160, 42)
        Me.btn_TeamViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.btn_TeamViewer.TabIndex = 32
        Me.btn_TeamViewer.TabStop = False
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(7, 29)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(183, 22)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Mostrar TeamViewer"
        '
        'gbx_NumValidadores
        '
        Me.gbx_NumValidadores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_NumValidadores.Controls.Add(Me.rdb_2val)
        Me.gbx_NumValidadores.Controls.Add(Me.rdb_1val)
        Me.gbx_NumValidadores.Controls.Add(Me.lbl_CantodadVal)
        Me.gbx_NumValidadores.Location = New System.Drawing.Point(398, 7)
        Me.gbx_NumValidadores.Name = "gbx_NumValidadores"
        Me.gbx_NumValidadores.Size = New System.Drawing.Size(383, 66)
        Me.gbx_NumValidadores.TabIndex = 47
        Me.gbx_NumValidadores.TabStop = False
        '
        'rdb_2val
        '
        Me.rdb_2val.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_2val.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_2val.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_2val.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_2val.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_2val.Location = New System.Drawing.Point(259, 17)
        Me.rdb_2val.Name = "rdb_2val"
        Me.rdb_2val.Size = New System.Drawing.Size(85, 42)
        Me.rdb_2val.TabIndex = 51
        Me.rdb_2val.Text = "2"
        Me.rdb_2val.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_2val.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_2val.UseVisualStyleBackColor = True
        '
        'rdb_1val
        '
        Me.rdb_1val.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_1val.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_1val.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_1val.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_1val.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_1val.Location = New System.Drawing.Point(168, 17)
        Me.rdb_1val.Name = "rdb_1val"
        Me.rdb_1val.Size = New System.Drawing.Size(85, 42)
        Me.rdb_1val.TabIndex = 50
        Me.rdb_1val.Text = "1"
        Me.rdb_1val.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_1val.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_1val.UseVisualStyleBackColor = True
        '
        'lbl_CantodadVal
        '
        Me.lbl_CantodadVal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_CantodadVal.AutoSize = True
        Me.lbl_CantodadVal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CantodadVal.Location = New System.Drawing.Point(7, 30)
        Me.lbl_CantodadVal.Name = "lbl_CantodadVal"
        Me.lbl_CantodadVal.Size = New System.Drawing.Size(159, 22)
        Me.lbl_CantodadVal.TabIndex = 31
        Me.lbl_CantodadVal.Text = "Cant. Validadores"
        '
        'spc_Validadores
        '
        Me.spc_Validadores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spc_Validadores.Location = New System.Drawing.Point(8, 79)
        Me.spc_Validadores.Name = "spc_Validadores"
        '
        'spc_Validadores.Panel1
        '
        Me.spc_Validadores.Panel1.Controls.Add(Me.gbx_StatusVal1)
        '
        'spc_Validadores.Panel2
        '
        Me.spc_Validadores.Panel2.Controls.Add(Me.gbx_StatusVal2)
        Me.spc_Validadores.Size = New System.Drawing.Size(773, 296)
        Me.spc_Validadores.SplitterDistance = 385
        Me.spc_Validadores.TabIndex = 48
        '
        'gbx_StatusVal1
        '
        Me.gbx_StatusVal1.Controls.Add(Me.Cmb_PesoDolarV1)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_Val1Activado)
        Me.gbx_StatusVal1.Controls.Add(Me.rdb_NoVal1)
        Me.gbx_StatusVal1.Controls.Add(Me.rdb_SiVal1)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_LimiteCapacidadKct)
        Me.gbx_StatusVal1.Controls.Add(Me.cmb_LimiteCapacidadKct)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_val1)
        Me.gbx_StatusVal1.Controls.Add(Me.cmb_Caset)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_Caset)
        Me.gbx_StatusVal1.Controls.Add(Me.tbx_Validador1)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_puertoval1)
        Me.gbx_StatusVal1.Controls.Add(Me.tbx_PuertoVal1)
        Me.gbx_StatusVal1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_StatusVal1.Location = New System.Drawing.Point(0, 0)
        Me.gbx_StatusVal1.Name = "gbx_StatusVal1"
        Me.gbx_StatusVal1.Size = New System.Drawing.Size(385, 296)
        Me.gbx_StatusVal1.TabIndex = 45
        Me.gbx_StatusVal1.TabStop = False
        Me.gbx_StatusVal1.Text = "Validador 1"
        '
        'Cmb_PesoDolarV1
        '
        Me.Cmb_PesoDolarV1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cmb_PesoDolarV1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Cmb_PesoDolarV1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_PesoDolarV1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_PesoDolarV1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_PesoDolarV1.FormattingEnabled = True
        Me.Cmb_PesoDolarV1.Location = New System.Drawing.Point(239, 124)
        Me.Cmb_PesoDolarV1.MaxDropDownItems = 20
        Me.Cmb_PesoDolarV1.Name = "Cmb_PesoDolarV1"
        Me.Cmb_PesoDolarV1.Size = New System.Drawing.Size(129, 40)
        Me.Cmb_PesoDolarV1.TabIndex = 50
        '
        'lbl_Val1Activado
        '
        Me.lbl_Val1Activado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Val1Activado.AutoSize = True
        Me.lbl_Val1Activado.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Val1Activado.Location = New System.Drawing.Point(96, 53)
        Me.lbl_Val1Activado.Name = "lbl_Val1Activado"
        Me.lbl_Val1Activado.Size = New System.Drawing.Size(83, 22)
        Me.lbl_Val1Activado.TabIndex = 49
        Me.lbl_Val1Activado.Text = "Activado"
        '
        'rdb_NoVal1
        '
        Me.rdb_NoVal1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_NoVal1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_NoVal1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_NoVal1.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_NoVal1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_NoVal1.Location = New System.Drawing.Point(283, 40)
        Me.rdb_NoVal1.Name = "rdb_NoVal1"
        Me.rdb_NoVal1.Size = New System.Drawing.Size(85, 42)
        Me.rdb_NoVal1.TabIndex = 44
        Me.rdb_NoVal1.Text = "No"
        Me.rdb_NoVal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_NoVal1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_NoVal1.UseVisualStyleBackColor = True
        '
        'rdb_SiVal1
        '
        Me.rdb_SiVal1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_SiVal1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_SiVal1.Checked = True
        Me.rdb_SiVal1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_SiVal1.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_SiVal1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_SiVal1.Location = New System.Drawing.Point(186, 40)
        Me.rdb_SiVal1.Name = "rdb_SiVal1"
        Me.rdb_SiVal1.Size = New System.Drawing.Size(85, 42)
        Me.rdb_SiVal1.TabIndex = 43
        Me.rdb_SiVal1.TabStop = True
        Me.rdb_SiVal1.Text = "Si"
        Me.rdb_SiVal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_SiVal1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_SiVal1.UseVisualStyleBackColor = True
        '
        'lbl_LimiteCapacidadKct
        '
        Me.lbl_LimiteCapacidadKct.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_LimiteCapacidadKct.AutoSize = True
        Me.lbl_LimiteCapacidadKct.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LimiteCapacidadKct.Location = New System.Drawing.Point(18, 225)
        Me.lbl_LimiteCapacidadKct.Name = "lbl_LimiteCapacidadKct"
        Me.lbl_LimiteCapacidadKct.Size = New System.Drawing.Size(161, 22)
        Me.lbl_LimiteCapacidadKct.TabIndex = 47
        Me.lbl_LimiteCapacidadKct.Text = "Limite Cap. Caset"
        '
        'cmb_LimiteCapacidadKct
        '
        Me.cmb_LimiteCapacidadKct.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_LimiteCapacidadKct.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_LimiteCapacidadKct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_LimiteCapacidadKct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_LimiteCapacidadKct.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_LimiteCapacidadKct.FormattingEnabled = True
        Me.cmb_LimiteCapacidadKct.Location = New System.Drawing.Point(186, 214)
        Me.cmb_LimiteCapacidadKct.MaxDropDownItems = 20
        Me.cmb_LimiteCapacidadKct.Name = "cmb_LimiteCapacidadKct"
        Me.cmb_LimiteCapacidadKct.Size = New System.Drawing.Size(96, 40)
        Me.cmb_LimiteCapacidadKct.TabIndex = 48
        '
        'lbl_val1
        '
        Me.lbl_val1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_val1.AutoSize = True
        Me.lbl_val1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_val1.Location = New System.Drawing.Point(40, 93)
        Me.lbl_val1.Name = "lbl_val1"
        Me.lbl_val1.Size = New System.Drawing.Size(139, 22)
        Me.lbl_val1.TabIndex = 35
        Me.lbl_val1.Text = "Serie Validador"
        '
        'cmb_Caset
        '
        Me.cmb_Caset.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_Caset.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_Caset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Caset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Caset.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Caset.FormattingEnabled = True
        Me.cmb_Caset.Location = New System.Drawing.Point(186, 168)
        Me.cmb_Caset.MaxDropDownItems = 20
        Me.cmb_Caset.Name = "cmb_Caset"
        Me.cmb_Caset.Size = New System.Drawing.Size(182, 40)
        Me.cmb_Caset.TabIndex = 30
        '
        'lbl_Caset
        '
        Me.lbl_Caset.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Caset.AutoSize = True
        Me.lbl_Caset.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Caset.Location = New System.Drawing.Point(63, 176)
        Me.lbl_Caset.Name = "lbl_Caset"
        Me.lbl_Caset.Size = New System.Drawing.Size(116, 22)
        Me.lbl_Caset.TabIndex = 29
        Me.lbl_Caset.Text = "Caset Actual"
        '
        'tbx_Validador1
        '
        Me.tbx_Validador1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Validador1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Validador1.Location = New System.Drawing.Point(186, 89)
        Me.tbx_Validador1.MaxLength = 15
        Me.tbx_Validador1.Name = "tbx_Validador1"
        Me.tbx_Validador1.Size = New System.Drawing.Size(182, 32)
        Me.tbx_Validador1.TabIndex = 36
        '
        'lbl_puertoval1
        '
        Me.lbl_puertoval1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_puertoval1.AutoSize = True
        Me.lbl_puertoval1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puertoval1.Location = New System.Drawing.Point(29, 135)
        Me.lbl_puertoval1.Name = "lbl_puertoval1"
        Me.lbl_puertoval1.Size = New System.Drawing.Size(150, 22)
        Me.lbl_puertoval1.TabIndex = 39
        Me.lbl_puertoval1.Text = "Puerto Validador"
        '
        'tbx_PuertoVal1
        '
        Me.tbx_PuertoVal1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_PuertoVal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_PuertoVal1.Location = New System.Drawing.Point(186, 127)
        Me.tbx_PuertoVal1.MaxLength = 2
        Me.tbx_PuertoVal1.Name = "tbx_PuertoVal1"
        Me.tbx_PuertoVal1.Size = New System.Drawing.Size(47, 35)
        Me.tbx_PuertoVal1.TabIndex = 40
        Me.tbx_PuertoVal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbx_StatusVal2
        '
        Me.gbx_StatusVal2.Controls.Add(Me.Cmb_PesoDolarV2)
        Me.gbx_StatusVal2.Controls.Add(Me.Label14)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_LimiteCapacidadKct2)
        Me.gbx_StatusVal2.Controls.Add(Me.rdb_NoVal2)
        Me.gbx_StatusVal2.Controls.Add(Me.cmb_LimiteCapacidadKct2)
        Me.gbx_StatusVal2.Controls.Add(Me.rdb_SiVal2)
        Me.gbx_StatusVal2.Controls.Add(Me.cmb_Caset2)
        Me.gbx_StatusVal2.Controls.Add(Me.tbx_PuertoVal2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_caset2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_puertoval2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_val2)
        Me.gbx_StatusVal2.Controls.Add(Me.tbx_Validador2)
        Me.gbx_StatusVal2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_StatusVal2.Location = New System.Drawing.Point(0, 0)
        Me.gbx_StatusVal2.Name = "gbx_StatusVal2"
        Me.gbx_StatusVal2.Size = New System.Drawing.Size(384, 296)
        Me.gbx_StatusVal2.TabIndex = 46
        Me.gbx_StatusVal2.TabStop = False
        Me.gbx_StatusVal2.Text = "Validador 2"
        '
        'Cmb_PesoDolarV2
        '
        Me.Cmb_PesoDolarV2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cmb_PesoDolarV2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Cmb_PesoDolarV2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_PesoDolarV2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_PesoDolarV2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_PesoDolarV2.FormattingEnabled = True
        Me.Cmb_PesoDolarV2.Location = New System.Drawing.Point(235, 124)
        Me.Cmb_PesoDolarV2.MaxDropDownItems = 20
        Me.Cmb_PesoDolarV2.Name = "Cmb_PesoDolarV2"
        Me.Cmb_PesoDolarV2.Size = New System.Drawing.Size(134, 40)
        Me.Cmb_PesoDolarV2.TabIndex = 51
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(93, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 22)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Activado"
        '
        'lbl_LimiteCapacidadKct2
        '
        Me.lbl_LimiteCapacidadKct2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_LimiteCapacidadKct2.AutoSize = True
        Me.lbl_LimiteCapacidadKct2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LimiteCapacidadKct2.Location = New System.Drawing.Point(15, 222)
        Me.lbl_LimiteCapacidadKct2.Name = "lbl_LimiteCapacidadKct2"
        Me.lbl_LimiteCapacidadKct2.Size = New System.Drawing.Size(161, 22)
        Me.lbl_LimiteCapacidadKct2.TabIndex = 49
        Me.lbl_LimiteCapacidadKct2.Text = "Limite Cap. Caset"
        '
        'rdb_NoVal2
        '
        Me.rdb_NoVal2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_NoVal2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_NoVal2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_NoVal2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_NoVal2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_NoVal2.Location = New System.Drawing.Point(284, 40)
        Me.rdb_NoVal2.Name = "rdb_NoVal2"
        Me.rdb_NoVal2.Size = New System.Drawing.Size(85, 42)
        Me.rdb_NoVal2.TabIndex = 44
        Me.rdb_NoVal2.Text = "No"
        Me.rdb_NoVal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_NoVal2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_NoVal2.UseVisualStyleBackColor = True
        '
        'cmb_LimiteCapacidadKct2
        '
        Me.cmb_LimiteCapacidadKct2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_LimiteCapacidadKct2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_LimiteCapacidadKct2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_LimiteCapacidadKct2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_LimiteCapacidadKct2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_LimiteCapacidadKct2.FormattingEnabled = True
        Me.cmb_LimiteCapacidadKct2.Location = New System.Drawing.Point(182, 214)
        Me.cmb_LimiteCapacidadKct2.MaxDropDownItems = 20
        Me.cmb_LimiteCapacidadKct2.Name = "cmb_LimiteCapacidadKct2"
        Me.cmb_LimiteCapacidadKct2.Size = New System.Drawing.Size(96, 40)
        Me.cmb_LimiteCapacidadKct2.TabIndex = 50
        '
        'rdb_SiVal2
        '
        Me.rdb_SiVal2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_SiVal2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_SiVal2.Checked = True
        Me.rdb_SiVal2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_SiVal2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_SiVal2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_SiVal2.Location = New System.Drawing.Point(182, 40)
        Me.rdb_SiVal2.Name = "rdb_SiVal2"
        Me.rdb_SiVal2.Size = New System.Drawing.Size(85, 42)
        Me.rdb_SiVal2.TabIndex = 43
        Me.rdb_SiVal2.TabStop = True
        Me.rdb_SiVal2.Text = "Si"
        Me.rdb_SiVal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_SiVal2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_SiVal2.UseVisualStyleBackColor = True
        '
        'cmb_Caset2
        '
        Me.cmb_Caset2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_Caset2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_Caset2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Caset2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Caset2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Caset2.FormattingEnabled = True
        Me.cmb_Caset2.Location = New System.Drawing.Point(182, 168)
        Me.cmb_Caset2.MaxDropDownItems = 20
        Me.cmb_Caset2.Name = "cmb_Caset2"
        Me.cmb_Caset2.Size = New System.Drawing.Size(187, 40)
        Me.cmb_Caset2.TabIndex = 34
        '
        'tbx_PuertoVal2
        '
        Me.tbx_PuertoVal2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_PuertoVal2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_PuertoVal2.Location = New System.Drawing.Point(182, 127)
        Me.tbx_PuertoVal2.MaxLength = 2
        Me.tbx_PuertoVal2.Name = "tbx_PuertoVal2"
        Me.tbx_PuertoVal2.Size = New System.Drawing.Size(47, 35)
        Me.tbx_PuertoVal2.TabIndex = 42
        Me.tbx_PuertoVal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_caset2
        '
        Me.lbl_caset2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_caset2.AutoSize = True
        Me.lbl_caset2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_caset2.Location = New System.Drawing.Point(60, 176)
        Me.lbl_caset2.Name = "lbl_caset2"
        Me.lbl_caset2.Size = New System.Drawing.Size(116, 22)
        Me.lbl_caset2.TabIndex = 33
        Me.lbl_caset2.Text = "Caset Actual"
        '
        'lbl_puertoval2
        '
        Me.lbl_puertoval2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_puertoval2.AutoSize = True
        Me.lbl_puertoval2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puertoval2.Location = New System.Drawing.Point(79, 130)
        Me.lbl_puertoval2.Name = "lbl_puertoval2"
        Me.lbl_puertoval2.Size = New System.Drawing.Size(97, 22)
        Me.lbl_puertoval2.TabIndex = 41
        Me.lbl_puertoval2.Text = "Puerto Val"
        '
        'lbl_val2
        '
        Me.lbl_val2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_val2.AutoSize = True
        Me.lbl_val2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_val2.Location = New System.Drawing.Point(37, 90)
        Me.lbl_val2.Name = "lbl_val2"
        Me.lbl_val2.Size = New System.Drawing.Size(139, 22)
        Me.lbl_val2.TabIndex = 37
        Me.lbl_val2.Text = "Serie Validador"
        '
        'tbx_Validador2
        '
        Me.tbx_Validador2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Validador2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Validador2.Location = New System.Drawing.Point(182, 89)
        Me.tbx_Validador2.MaxLength = 15
        Me.tbx_Validador2.Name = "tbx_Validador2"
        Me.tbx_Validador2.Size = New System.Drawing.Size(187, 31)
        Me.tbx_Validador2.TabIndex = 38
        '
        'tbp_TipoCambio
        '
        Me.tbp_TipoCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.tbp_TipoCambio.Controls.Add(Me.gbx_TipoCambio)
        Me.tbp_TipoCambio.Location = New System.Drawing.Point(4, 38)
        Me.tbp_TipoCambio.Name = "tbp_TipoCambio"
        Me.tbp_TipoCambio.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_TipoCambio.Size = New System.Drawing.Size(951, 516)
        Me.tbp_TipoCambio.TabIndex = 6
        Me.tbp_TipoCambio.Text = "Tipo Cambio"
        '
        'gbx_TipoCambio
        '
        Me.gbx_TipoCambio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_TipoCambio.Controls.Add(Me.Label20)
        Me.gbx_TipoCambio.Controls.Add(Me.TextBox1)
        Me.gbx_TipoCambio.Controls.Add(Me.tbx_NuevoTC)
        Me.gbx_TipoCambio.Controls.Add(Me.btn_GuardarTC)
        Me.gbx_TipoCambio.Controls.Add(Me.Label18)
        Me.gbx_TipoCambio.Controls.Add(Me.tbx_AnteriorTC)
        Me.gbx_TipoCambio.Controls.Add(Me.Label17)
        Me.gbx_TipoCambio.Controls.Add(Me.tbx_FechaTC)
        Me.gbx_TipoCambio.Controls.Add(Me.Label16)
        Me.gbx_TipoCambio.Controls.Add(Me.tbx_MonedaTC)
        Me.gbx_TipoCambio.Controls.Add(Me.Label15)
        Me.gbx_TipoCambio.Location = New System.Drawing.Point(6, 6)
        Me.gbx_TipoCambio.Name = "gbx_TipoCambio"
        Me.gbx_TipoCambio.Size = New System.Drawing.Size(772, 369)
        Me.gbx_TipoCambio.TabIndex = 9
        Me.gbx_TipoCambio.TabStop = False
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(200, 45)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(155, 22)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Moneda Nacional"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(361, 42)
        Me.TextBox1.MaxLength = 10
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(122, 29)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = "PESOS"
        '
        'tbx_NuevoTC
        '
        Me.tbx_NuevoTC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_NuevoTC.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_NuevoTC.Location = New System.Drawing.Point(361, 185)
        Me.tbx_NuevoTC.MaxLength = 5
        Me.tbx_NuevoTC.Name = "tbx_NuevoTC"
        Me.tbx_NuevoTC.Size = New System.Drawing.Size(69, 29)
        Me.tbx_NuevoTC.TabIndex = 7
        Me.tbx_NuevoTC.Text = "20"
        Me.tbx_NuevoTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_GuardarTC
        '
        Me.btn_GuardarTC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_GuardarTC.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_GuardarTC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_GuardarTC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_GuardarTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GuardarTC.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Dollar
        Me.btn_GuardarTC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_GuardarTC.Location = New System.Drawing.Point(361, 220)
        Me.btn_GuardarTC.Name = "btn_GuardarTC"
        Me.btn_GuardarTC.Size = New System.Drawing.Size(164, 75)
        Me.btn_GuardarTC.TabIndex = 8
        Me.btn_GuardarTC.Text = "Guardar Tipo de Cambio"
        Me.btn_GuardarTC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_GuardarTC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_GuardarTC.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(140, 150)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(215, 22)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Tipo de Cambio Anterior"
        '
        'tbx_AnteriorTC
        '
        Me.tbx_AnteriorTC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_AnteriorTC.BackColor = System.Drawing.Color.White
        Me.tbx_AnteriorTC.Enabled = False
        Me.tbx_AnteriorTC.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_AnteriorTC.Location = New System.Drawing.Point(361, 147)
        Me.tbx_AnteriorTC.MaxLength = 5
        Me.tbx_AnteriorTC.Name = "tbx_AnteriorTC"
        Me.tbx_AnteriorTC.ReadOnly = True
        Me.tbx_AnteriorTC.Size = New System.Drawing.Size(69, 29)
        Me.tbx_AnteriorTC.TabIndex = 5
        Me.tbx_AnteriorTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(188, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(167, 22)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Moneda Extranjera"
        '
        'tbx_FechaTC
        '
        Me.tbx_FechaTC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_FechaTC.BackColor = System.Drawing.Color.White
        Me.tbx_FechaTC.Enabled = False
        Me.tbx_FechaTC.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_FechaTC.Location = New System.Drawing.Point(361, 112)
        Me.tbx_FechaTC.MaxLength = 11
        Me.tbx_FechaTC.Name = "tbx_FechaTC"
        Me.tbx_FechaTC.ReadOnly = True
        Me.tbx_FechaTC.Size = New System.Drawing.Size(122, 29)
        Me.tbx_FechaTC.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(151, 188)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(204, 22)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Tipo de Cambio Nuevo"
        '
        'tbx_MonedaTC
        '
        Me.tbx_MonedaTC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_MonedaTC.BackColor = System.Drawing.Color.White
        Me.tbx_MonedaTC.Enabled = False
        Me.tbx_MonedaTC.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_MonedaTC.Location = New System.Drawing.Point(361, 77)
        Me.tbx_MonedaTC.MaxLength = 10
        Me.tbx_MonedaTC.Name = "tbx_MonedaTC"
        Me.tbx_MonedaTC.ReadOnly = True
        Me.tbx_MonedaTC.Size = New System.Drawing.Size(122, 29)
        Me.tbx_MonedaTC.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(292, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 22)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Fecha"
        '
        'tbp_ConexionAdmin
        '
        Me.tbp_ConexionAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.tbp_ConexionAdmin.Controls.Add(Me.gbx_Conexion)
        Me.tbp_ConexionAdmin.Controls.Add(Me.gbx_Actualizar)
        Me.tbp_ConexionAdmin.Location = New System.Drawing.Point(4, 38)
        Me.tbp_ConexionAdmin.Name = "tbp_ConexionAdmin"
        Me.tbp_ConexionAdmin.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_ConexionAdmin.Size = New System.Drawing.Size(951, 516)
        Me.tbp_ConexionAdmin.TabIndex = 7
        Me.tbp_ConexionAdmin.Text = "Actualizar"
        '
        'gbx_Conexion
        '
        Me.gbx_Conexion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Conexion.Controls.Add(Me.gbx_Conectado)
        Me.gbx_Conexion.Controls.Add(Me.gbx_Prioridad)
        Me.gbx_Conexion.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Conexion.Location = New System.Drawing.Point(6, 6)
        Me.gbx_Conexion.Name = "gbx_Conexion"
        Me.gbx_Conexion.Size = New System.Drawing.Size(772, 239)
        Me.gbx_Conexion.TabIndex = 52
        Me.gbx_Conexion.TabStop = False
        Me.gbx_Conexion.Text = "Conexión Internet"
        '
        'gbx_Conectado
        '
        Me.gbx_Conectado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Conectado.Controls.Add(Me.rdb_NOconectaAdmin)
        Me.gbx_Conectado.Controls.Add(Me.lbl_ConectividadUser)
        Me.gbx_Conectado.Controls.Add(Me.rdb_SIconectaAdmin)
        Me.gbx_Conectado.Enabled = False
        Me.gbx_Conectado.Location = New System.Drawing.Point(6, 26)
        Me.gbx_Conectado.Name = "gbx_Conectado"
        Me.gbx_Conectado.Size = New System.Drawing.Size(760, 101)
        Me.gbx_Conectado.TabIndex = 27
        Me.gbx_Conectado.TabStop = False
        '
        'rdb_NOconectaAdmin
        '
        Me.rdb_NOconectaAdmin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_NOconectaAdmin.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_NOconectaAdmin.Checked = True
        Me.rdb_NOconectaAdmin.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_NOconectaAdmin.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_NOconectaAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_NOconectaAdmin.Location = New System.Drawing.Point(366, 34)
        Me.rdb_NOconectaAdmin.Name = "rdb_NOconectaAdmin"
        Me.rdb_NOconectaAdmin.Size = New System.Drawing.Size(120, 42)
        Me.rdb_NOconectaAdmin.TabIndex = 26
        Me.rdb_NOconectaAdmin.TabStop = True
        Me.rdb_NOconectaAdmin.Text = "No"
        Me.rdb_NOconectaAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_NOconectaAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_NOconectaAdmin.UseVisualStyleBackColor = True
        '
        'lbl_ConectividadUser
        '
        Me.lbl_ConectividadUser.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_ConectividadUser.AutoSize = True
        Me.lbl_ConectividadUser.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ConectividadUser.Location = New System.Drawing.Point(122, 46)
        Me.lbl_ConectividadUser.Name = "lbl_ConectividadUser"
        Me.lbl_ConectividadUser.Size = New System.Drawing.Size(112, 24)
        Me.lbl_ConectividadUser.TabIndex = 24
        Me.lbl_ConectividadUser.Text = "Conectado"
        '
        'rdb_SIconectaAdmin
        '
        Me.rdb_SIconectaAdmin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_SIconectaAdmin.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_SIconectaAdmin.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_SIconectaAdmin.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_SIconectaAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_SIconectaAdmin.Location = New System.Drawing.Point(240, 34)
        Me.rdb_SIconectaAdmin.Name = "rdb_SIconectaAdmin"
        Me.rdb_SIconectaAdmin.Size = New System.Drawing.Size(120, 42)
        Me.rdb_SIconectaAdmin.TabIndex = 25
        Me.rdb_SIconectaAdmin.Text = "Si"
        Me.rdb_SIconectaAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_SIconectaAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_SIconectaAdmin.UseVisualStyleBackColor = True
        '
        'gbx_Prioridad
        '
        Me.gbx_Prioridad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Prioridad.Controls.Add(Me.Label19)
        Me.gbx_Prioridad.Controls.Add(Me.rdb_local)
        Me.gbx_Prioridad.Controls.Add(Me.rdb_web)
        Me.gbx_Prioridad.Enabled = False
        Me.gbx_Prioridad.Location = New System.Drawing.Point(6, 126)
        Me.gbx_Prioridad.Name = "gbx_Prioridad"
        Me.gbx_Prioridad.Size = New System.Drawing.Size(760, 107)
        Me.gbx_Prioridad.TabIndex = 54
        Me.gbx_Prioridad.TabStop = False
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(226, 24)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Prioridad de Privilegios"
        '
        'rdb_local
        '
        Me.rdb_local.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_local.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_local.Checked = True
        Me.rdb_local.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_local.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_local.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_local.Location = New System.Drawing.Point(240, 31)
        Me.rdb_local.Name = "rdb_local"
        Me.rdb_local.Size = New System.Drawing.Size(120, 42)
        Me.rdb_local.TabIndex = 43
        Me.rdb_local.TabStop = True
        Me.rdb_local.Text = "Local"
        Me.rdb_local.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_local.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_local.UseVisualStyleBackColor = True
        '
        'rdb_web
        '
        Me.rdb_web.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_web.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_web.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_web.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_web.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_web.Location = New System.Drawing.Point(366, 31)
        Me.rdb_web.Name = "rdb_web"
        Me.rdb_web.Size = New System.Drawing.Size(120, 42)
        Me.rdb_web.TabIndex = 44
        Me.rdb_web.Text = "Web"
        Me.rdb_web.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_web.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_web.UseVisualStyleBackColor = True
        '
        'gbx_Actualizar
        '
        Me.gbx_Actualizar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Actualizar.Controls.Add(Me.btn_ActualizaWeb)
        Me.gbx_Actualizar.Controls.Add(Me.btn_ActualizarLocal)
        Me.gbx_Actualizar.Location = New System.Drawing.Point(6, 236)
        Me.gbx_Actualizar.Name = "gbx_Actualizar"
        Me.gbx_Actualizar.Size = New System.Drawing.Size(772, 109)
        Me.gbx_Actualizar.TabIndex = 53
        Me.gbx_Actualizar.TabStop = False
        '
        'btn_ActualizaWeb
        '
        Me.btn_ActualizaWeb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ActualizaWeb.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_ActualizaWeb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ActualizaWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ActualizaWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ActualizaWeb.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Descargar
        Me.btn_ActualizaWeb.Location = New System.Drawing.Point(608, 28)
        Me.btn_ActualizaWeb.Name = "btn_ActualizaWeb"
        Me.btn_ActualizaWeb.Size = New System.Drawing.Size(164, 75)
        Me.btn_ActualizaWeb.TabIndex = 51
        Me.btn_ActualizaWeb.Text = "Buscar Actualizaciones"
        Me.btn_ActualizaWeb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ActualizaWeb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ActualizaWeb.UseVisualStyleBackColor = False
        '
        'btn_ActualizarLocal
        '
        Me.btn_ActualizarLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_ActualizarLocal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ActualizarLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ActualizarLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ActualizarLocal.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.auditoria_software
        Me.btn_ActualizarLocal.Location = New System.Drawing.Point(-3, 31)
        Me.btn_ActualizarLocal.Name = "btn_ActualizarLocal"
        Me.btn_ActualizarLocal.Size = New System.Drawing.Size(164, 75)
        Me.btn_ActualizarLocal.TabIndex = 49
        Me.btn_ActualizarLocal.Text = "Actualizar Local"
        Me.btn_ActualizarLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ActualizarLocal.UseVisualStyleBackColor = False
        '
        'tbp_Impresora
        '
        Me.tbp_Impresora.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.tbp_Impresora.Controls.Add(Me.gbx_Papel)
        Me.tbp_Impresora.Location = New System.Drawing.Point(4, 38)
        Me.tbp_Impresora.Name = "tbp_Impresora"
        Me.tbp_Impresora.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_Impresora.Size = New System.Drawing.Size(951, 516)
        Me.tbp_Impresora.TabIndex = 8
        Me.tbp_Impresora.Text = "Impresora"
        '
        'gbx_Papel
        '
        Me.gbx_Papel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Papel.Controls.Add(Me.cmb_MododeImprimir)
        Me.gbx_Papel.Controls.Add(Me.lbl_MododeImprimir)
        Me.gbx_Papel.Controls.Add(Me.btn_EliminaLogo)
        Me.gbx_Papel.Controls.Add(Me.lbl_DetalleCorteDiario)
        Me.gbx_Papel.Controls.Add(Me.btn_AgregarLogo)
        Me.gbx_Papel.Controls.Add(Me.lbl_NoCopias)
        Me.gbx_Papel.Controls.Add(Me.cmb_NoCopias)
        Me.gbx_Papel.Controls.Add(Me.pct_ImgEmpresa)
        Me.gbx_Papel.Controls.Add(Me.cmb_LineasBlanco)
        Me.gbx_Papel.Controls.Add(Me.lbl_LineasBlanco)
        Me.gbx_Papel.Controls.Add(Me.cmb_MargenIzq)
        Me.gbx_Papel.Controls.Add(Me.cmb_TipoWindows)
        Me.gbx_Papel.Controls.Add(Me.Label12)
        Me.gbx_Papel.Controls.Add(Me.Label3)
        Me.gbx_Papel.Controls.Add(Me.Label13)
        Me.gbx_Papel.Controls.Add(Me.gbx_Sizepapel)
        Me.gbx_Papel.Controls.Add(Me.gbx_DetalleCD)
        Me.gbx_Papel.Location = New System.Drawing.Point(6, 6)
        Me.gbx_Papel.Name = "gbx_Papel"
        Me.gbx_Papel.Size = New System.Drawing.Size(772, 369)
        Me.gbx_Papel.TabIndex = 28
        Me.gbx_Papel.TabStop = False
        '
        'cmb_MododeImprimir
        '
        Me.cmb_MododeImprimir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_MododeImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_MododeImprimir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_MododeImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_MododeImprimir.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_MododeImprimir.FormattingEnabled = True
        Me.cmb_MododeImprimir.Location = New System.Drawing.Point(349, 36)
        Me.cmb_MododeImprimir.Name = "cmb_MododeImprimir"
        Me.cmb_MododeImprimir.Size = New System.Drawing.Size(210, 40)
        Me.cmb_MododeImprimir.TabIndex = 43
        '
        'lbl_MododeImprimir
        '
        Me.lbl_MododeImprimir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_MododeImprimir.AutoSize = True
        Me.lbl_MododeImprimir.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MododeImprimir.Location = New System.Drawing.Point(168, 47)
        Me.lbl_MododeImprimir.Name = "lbl_MododeImprimir"
        Me.lbl_MododeImprimir.Size = New System.Drawing.Size(175, 22)
        Me.lbl_MododeImprimir.TabIndex = 42
        Me.lbl_MododeImprimir.Text = "Modo de Impresión"
        Me.lbl_MododeImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_EliminaLogo
        '
        Me.btn_EliminaLogo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_EliminaLogo.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EliminaLogo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_EliminaLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_EliminaLogo.Location = New System.Drawing.Point(690, 170)
        Me.btn_EliminaLogo.Name = "btn_EliminaLogo"
        Me.btn_EliminaLogo.Size = New System.Drawing.Size(44, 40)
        Me.btn_EliminaLogo.TabIndex = 37
        Me.btn_EliminaLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_EliminaLogo.UseVisualStyleBackColor = True
        Me.btn_EliminaLogo.Visible = False
        '
        'lbl_DetalleCorteDiario
        '
        Me.lbl_DetalleCorteDiario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_DetalleCorteDiario.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DetalleCorteDiario.Location = New System.Drawing.Point(163, 260)
        Me.lbl_DetalleCorteDiario.Name = "lbl_DetalleCorteDiario"
        Me.lbl_DetalleCorteDiario.Size = New System.Drawing.Size(180, 49)
        Me.lbl_DetalleCorteDiario.TabIndex = 34
        Me.lbl_DetalleCorteDiario.Text = "Imprimir Detalle Corte Diario"
        Me.lbl_DetalleCorteDiario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_AgregarLogo
        '
        Me.btn_AgregarLogo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_AgregarLogo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarLogo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Examinar
        Me.btn_AgregarLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AgregarLogo.Location = New System.Drawing.Point(565, 170)
        Me.btn_AgregarLogo.Name = "btn_AgregarLogo"
        Me.btn_AgregarLogo.Size = New System.Drawing.Size(119, 40)
        Me.btn_AgregarLogo.TabIndex = 33
        Me.btn_AgregarLogo.Text = "Logo ..."
        Me.btn_AgregarLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregarLogo.UseVisualStyleBackColor = True
        Me.btn_AgregarLogo.Visible = False
        '
        'lbl_NoCopias
        '
        Me.lbl_NoCopias.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_NoCopias.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NoCopias.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_NoCopias.Location = New System.Drawing.Point(105, 77)
        Me.lbl_NoCopias.Name = "lbl_NoCopias"
        Me.lbl_NoCopias.Size = New System.Drawing.Size(238, 45)
        Me.lbl_NoCopias.TabIndex = 28
        Me.lbl_NoCopias.Text = "Nº de Copias x Impresion (Depósitos y Retiros)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl_NoCopias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_NoCopias
        '
        Me.cmb_NoCopias.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_NoCopias.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_NoCopias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_NoCopias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_NoCopias.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_NoCopias.FormattingEnabled = True
        Me.cmb_NoCopias.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cmb_NoCopias.Location = New System.Drawing.Point(349, 79)
        Me.cmb_NoCopias.Name = "cmb_NoCopias"
        Me.cmb_NoCopias.Size = New System.Drawing.Size(152, 40)
        Me.cmb_NoCopias.TabIndex = 29
        '
        'pct_ImgEmpresa
        '
        Me.pct_ImgEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pct_ImgEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pct_ImgEmpresa.Location = New System.Drawing.Point(565, 36)
        Me.pct_ImgEmpresa.Name = "pct_ImgEmpresa"
        Me.pct_ImgEmpresa.Size = New System.Drawing.Size(169, 128)
        Me.pct_ImgEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pct_ImgEmpresa.TabIndex = 32
        Me.pct_ImgEmpresa.TabStop = False
        Me.pct_ImgEmpresa.Visible = False
        '
        'cmb_LineasBlanco
        '
        Me.cmb_LineasBlanco.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_LineasBlanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_LineasBlanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_LineasBlanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_LineasBlanco.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_LineasBlanco.FormattingEnabled = True
        Me.cmb_LineasBlanco.Location = New System.Drawing.Point(349, 122)
        Me.cmb_LineasBlanco.Name = "cmb_LineasBlanco"
        Me.cmb_LineasBlanco.Size = New System.Drawing.Size(152, 40)
        Me.cmb_LineasBlanco.TabIndex = 31
        '
        'lbl_LineasBlanco
        '
        Me.lbl_LineasBlanco.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_LineasBlanco.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LineasBlanco.Location = New System.Drawing.Point(121, 119)
        Me.lbl_LineasBlanco.Name = "lbl_LineasBlanco"
        Me.lbl_LineasBlanco.Size = New System.Drawing.Size(220, 46)
        Me.lbl_LineasBlanco.TabIndex = 30
        Me.lbl_LineasBlanco.Text = "Numero de lineas en blanco al final del Ticket"
        Me.lbl_LineasBlanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_MargenIzq
        '
        Me.cmb_MargenIzq.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_MargenIzq.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_MargenIzq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_MargenIzq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_MargenIzq.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_MargenIzq.FormattingEnabled = True
        Me.cmb_MargenIzq.Items.AddRange(New Object() {"0", "2", "4", "7", "10", "15", "17", "20", "23", "26", "30"})
        Me.cmb_MargenIzq.Location = New System.Drawing.Point(349, 165)
        Me.cmb_MargenIzq.Name = "cmb_MargenIzq"
        Me.cmb_MargenIzq.Size = New System.Drawing.Size(152, 40)
        Me.cmb_MargenIzq.TabIndex = 22
        '
        'cmb_TipoWindows
        '
        Me.cmb_TipoWindows.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_TipoWindows.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_TipoWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_TipoWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_TipoWindows.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_TipoWindows.FormattingEnabled = True
        Me.cmb_TipoWindows.Location = New System.Drawing.Point(21, 293)
        Me.cmb_TipoWindows.Name = "cmb_TipoWindows"
        Me.cmb_TipoWindows.Size = New System.Drawing.Size(104, 40)
        Me.cmb_TipoWindows.TabIndex = 27
        Me.cmb_TipoWindows.Visible = False
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(123, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(220, 22)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Margen Izquierdo en mm"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(128, 221)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(214, 22)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Tamaño de Papel a usar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 47)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Tipo de Windows"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.Visible = False
        '
        'gbx_Sizepapel
        '
        Me.gbx_Sizepapel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbx_Sizepapel.Controls.Add(Me.rdb_58mm)
        Me.gbx_Sizepapel.Controls.Add(Me.rdb_80mm)
        Me.gbx_Sizepapel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Sizepapel.Location = New System.Drawing.Point(347, 201)
        Me.gbx_Sizepapel.Name = "gbx_Sizepapel"
        Me.gbx_Sizepapel.Size = New System.Drawing.Size(212, 60)
        Me.gbx_Sizepapel.TabIndex = 40
        Me.gbx_Sizepapel.TabStop = False
        '
        'rdb_58mm
        '
        Me.rdb_58mm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_58mm.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_58mm.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_58mm.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_58mm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_58mm.Location = New System.Drawing.Point(2, 12)
        Me.rdb_58mm.Name = "rdb_58mm"
        Me.rdb_58mm.Size = New System.Drawing.Size(103, 42)
        Me.rdb_58mm.TabIndex = 38
        Me.rdb_58mm.Text = "58 mm"
        Me.rdb_58mm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdb_58mm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_58mm.UseVisualStyleBackColor = True
        '
        'rdb_80mm
        '
        Me.rdb_80mm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_80mm.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_80mm.Checked = True
        Me.rdb_80mm.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_80mm.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_80mm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_80mm.Location = New System.Drawing.Point(106, 12)
        Me.rdb_80mm.Name = "rdb_80mm"
        Me.rdb_80mm.Size = New System.Drawing.Size(103, 42)
        Me.rdb_80mm.TabIndex = 39
        Me.rdb_80mm.TabStop = True
        Me.rdb_80mm.Text = "80 mm"
        Me.rdb_80mm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_80mm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_80mm.UseVisualStyleBackColor = True
        '
        'gbx_DetalleCD
        '
        Me.gbx_DetalleCD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbx_DetalleCD.Controls.Add(Me.rdb_SIdetalle)
        Me.gbx_DetalleCD.Controls.Add(Me.rdb_NOdetalle)
        Me.gbx_DetalleCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_DetalleCD.Location = New System.Drawing.Point(347, 256)
        Me.gbx_DetalleCD.Name = "gbx_DetalleCD"
        Me.gbx_DetalleCD.Size = New System.Drawing.Size(212, 60)
        Me.gbx_DetalleCD.TabIndex = 41
        Me.gbx_DetalleCD.TabStop = False
        '
        'rdb_SIdetalle
        '
        Me.rdb_SIdetalle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_SIdetalle.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_SIdetalle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_SIdetalle.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_SIdetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_SIdetalle.Location = New System.Drawing.Point(2, 12)
        Me.rdb_SIdetalle.Name = "rdb_SIdetalle"
        Me.rdb_SIdetalle.Size = New System.Drawing.Size(103, 42)
        Me.rdb_SIdetalle.TabIndex = 35
        Me.rdb_SIdetalle.Text = "Si"
        Me.rdb_SIdetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_SIdetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_SIdetalle.UseVisualStyleBackColor = True
        '
        'rdb_NOdetalle
        '
        Me.rdb_NOdetalle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_NOdetalle.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_NOdetalle.Checked = True
        Me.rdb_NOdetalle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_NOdetalle.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_NOdetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_NOdetalle.Location = New System.Drawing.Point(106, 12)
        Me.rdb_NOdetalle.Name = "rdb_NOdetalle"
        Me.rdb_NOdetalle.Size = New System.Drawing.Size(103, 42)
        Me.rdb_NOdetalle.TabIndex = 36
        Me.rdb_NOdetalle.TabStop = True
        Me.rdb_NOdetalle.Text = "No"
        Me.rdb_NOdetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_NOdetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_NOdetalle.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.grp_ConexionWebS)
        Me.TabPage1.Location = New System.Drawing.Point(4, 38)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(951, 516)
        Me.TabPage1.TabIndex = 9
        Me.TabPage1.Text = "Configuración"
        '
        'grp_ConexionWebS
        '
        Me.grp_ConexionWebS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_ConexionWebS.Controls.Add(Me.GroupBox7)
        Me.grp_ConexionWebS.Controls.Add(Me.GroupBox6)
        Me.grp_ConexionWebS.Controls.Add(Me.GroupBox5)
        Me.grp_ConexionWebS.Controls.Add(Me.gbx_verificarfolio)
        Me.grp_ConexionWebS.Controls.Add(Me.grp_CorteDiario)
        Me.grp_ConexionWebS.Controls.Add(Me.GroupBox3)
        Me.grp_ConexionWebS.Controls.Add(Me.GroupBox2)
        Me.grp_ConexionWebS.Controls.Add(Me.GroupBox1)
        Me.grp_ConexionWebS.Location = New System.Drawing.Point(6, 6)
        Me.grp_ConexionWebS.Name = "grp_ConexionWebS"
        Me.grp_ConexionWebS.Size = New System.Drawing.Size(845, 510)
        Me.grp_ConexionWebS.TabIndex = 0
        Me.grp_ConexionWebS.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Cmb_Plaza)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Location = New System.Drawing.Point(423, 97)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(400, 70)
        Me.GroupBox7.TabIndex = 60
        Me.GroupBox7.TabStop = False
        '
        'Cmb_Plaza
        '
        Me.Cmb_Plaza.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cmb_Plaza.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Cmb_Plaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Plaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Plaza.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Plaza.FormattingEnabled = True
        Me.Cmb_Plaza.Items.AddRange(New Object() {"MONTERREY", "SALTILLO", "DEVELOPER"})
        Me.Cmb_Plaza.Location = New System.Drawing.Point(175, 19)
        Me.Cmb_Plaza.Name = "Cmb_Plaza"
        Me.Cmb_Plaza.Size = New System.Drawing.Size(178, 40)
        Me.Cmb_Plaza.TabIndex = 53
        '
        'Label30
        '
        Me.Label30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(19, 30)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(56, 22)
        Me.Label30.TabIndex = 52
        Me.Label30.Text = "Plaza"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Rdb_rdn)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.Rdb_rds)
        Me.GroupBox6.Location = New System.Drawing.Point(423, 25)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(400, 66)
        Me.GroupBox6.TabIndex = 59
        Me.GroupBox6.TabStop = False
        '
        'Rdb_rdn
        '
        Me.Rdb_rdn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Rdb_rdn.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rdb_rdn.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_rdn.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.Rdb_rdn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rdb_rdn.Location = New System.Drawing.Point(268, 17)
        Me.Rdb_rdn.Name = "Rdb_rdn"
        Me.Rdb_rdn.Size = New System.Drawing.Size(85, 42)
        Me.Rdb_rdn.TabIndex = 44
        Me.Rdb_rdn.Text = "No"
        Me.Rdb_rdn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Rdb_rdn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Rdb_rdn.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(19, 30)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(144, 22)
        Me.Label29.TabIndex = 52
        Me.Label29.Text = "Remisión digital"
        '
        'Rdb_rds
        '
        Me.Rdb_rds.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Rdb_rds.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rdb_rds.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_rds.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.Rdb_rds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rdb_rds.Location = New System.Drawing.Point(175, 17)
        Me.Rdb_rds.Name = "Rdb_rds"
        Me.Rdb_rds.Size = New System.Drawing.Size(85, 42)
        Me.Rdb_rds.TabIndex = 53
        Me.Rdb_rds.Text = "Si"
        Me.Rdb_rds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Rdb_rds.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Rdb_rds.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Rdb_sin_n)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Rdb_sin_s)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 385)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(400, 66)
        Me.GroupBox5.TabIndex = 58
        Me.GroupBox5.TabStop = False
        '
        'Rdb_sin_n
        '
        Me.Rdb_sin_n.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Rdb_sin_n.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rdb_sin_n.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_sin_n.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.Rdb_sin_n.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rdb_sin_n.Location = New System.Drawing.Point(309, 17)
        Me.Rdb_sin_n.Name = "Rdb_sin_n"
        Me.Rdb_sin_n.Size = New System.Drawing.Size(85, 42)
        Me.Rdb_sin_n.TabIndex = 44
        Me.Rdb_sin_n.Text = "No"
        Me.Rdb_sin_n.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Rdb_sin_n.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Rdb_sin_n.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(19, 30)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(188, 22)
        Me.Label28.TabIndex = 52
        Me.Label28.Text = "Trabajar sin conexión"
        '
        'Rdb_sin_s
        '
        Me.Rdb_sin_s.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Rdb_sin_s.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rdb_sin_s.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_sin_s.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.Rdb_sin_s.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rdb_sin_s.Location = New System.Drawing.Point(218, 17)
        Me.Rdb_sin_s.Name = "Rdb_sin_s"
        Me.Rdb_sin_s.Size = New System.Drawing.Size(85, 42)
        Me.Rdb_sin_s.TabIndex = 53
        Me.Rdb_sin_s.Text = "Si"
        Me.Rdb_sin_s.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Rdb_sin_s.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Rdb_sin_s.UseVisualStyleBackColor = True
        '
        'gbx_verificarfolio
        '
        Me.gbx_verificarfolio.Controls.Add(Me.rdb_validarfn)
        Me.gbx_verificarfolio.Controls.Add(Me.rdb_validarfsi)
        Me.gbx_verificarfolio.Controls.Add(Me.Label27)
        Me.gbx_verificarfolio.Location = New System.Drawing.Point(6, 247)
        Me.gbx_verificarfolio.Name = "gbx_verificarfolio"
        Me.gbx_verificarfolio.Size = New System.Drawing.Size(400, 70)
        Me.gbx_verificarfolio.TabIndex = 57
        Me.gbx_verificarfolio.TabStop = False
        '
        'rdb_validarfn
        '
        Me.rdb_validarfn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_validarfn.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_validarfn.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_validarfn.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_validarfn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_validarfn.Location = New System.Drawing.Point(309, 18)
        Me.rdb_validarfn.Name = "rdb_validarfn"
        Me.rdb_validarfn.Size = New System.Drawing.Size(85, 42)
        Me.rdb_validarfn.TabIndex = 57
        Me.rdb_validarfn.Text = "No"
        Me.rdb_validarfn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_validarfn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_validarfn.UseVisualStyleBackColor = True
        '
        'rdb_validarfsi
        '
        Me.rdb_validarfsi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_validarfsi.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_validarfsi.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_validarfsi.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_validarfsi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_validarfsi.Location = New System.Drawing.Point(218, 18)
        Me.rdb_validarfsi.Name = "rdb_validarfsi"
        Me.rdb_validarfsi.Size = New System.Drawing.Size(85, 42)
        Me.rdb_validarfsi.TabIndex = 56
        Me.rdb_validarfsi.Text = "Si"
        Me.rdb_validarfsi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_validarfsi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_validarfsi.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(15, 31)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(120, 22)
        Me.Label27.TabIndex = 54
        Me.Label27.Text = "Verificar folio"
        '
        'grp_CorteDiario
        '
        Me.grp_CorteDiario.Controls.Add(Me.Rdb_CorteNo)
        Me.grp_CorteDiario.Controls.Add(Me.Label22)
        Me.grp_CorteDiario.Controls.Add(Me.Rdb_CorteSi)
        Me.grp_CorteDiario.Location = New System.Drawing.Point(6, 318)
        Me.grp_CorteDiario.Name = "grp_CorteDiario"
        Me.grp_CorteDiario.Size = New System.Drawing.Size(400, 66)
        Me.grp_CorteDiario.TabIndex = 56
        Me.grp_CorteDiario.TabStop = False
        '
        'Rdb_CorteNo
        '
        Me.Rdb_CorteNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Rdb_CorteNo.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rdb_CorteNo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_CorteNo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.Rdb_CorteNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rdb_CorteNo.Location = New System.Drawing.Point(309, 17)
        Me.Rdb_CorteNo.Name = "Rdb_CorteNo"
        Me.Rdb_CorteNo.Size = New System.Drawing.Size(85, 42)
        Me.Rdb_CorteNo.TabIndex = 44
        Me.Rdb_CorteNo.Text = "No"
        Me.Rdb_CorteNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Rdb_CorteNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Rdb_CorteNo.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(19, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(176, 22)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "Maneja Corte Diario"
        '
        'Rdb_CorteSi
        '
        Me.Rdb_CorteSi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Rdb_CorteSi.Appearance = System.Windows.Forms.Appearance.Button
        Me.Rdb_CorteSi.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_CorteSi.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.Rdb_CorteSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Rdb_CorteSi.Location = New System.Drawing.Point(218, 17)
        Me.Rdb_CorteSi.Name = "Rdb_CorteSi"
        Me.Rdb_CorteSi.Size = New System.Drawing.Size(85, 42)
        Me.Rdb_CorteSi.TabIndex = 53
        Me.Rdb_CorteSi.Text = "Si"
        Me.Rdb_CorteSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Rdb_CorteSi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Rdb_CorteSi.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.rdb_ManejaFolioManualNo)
        Me.GroupBox3.Controls.Add(Me.rdb_ManejaFolioManualSi)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 171)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(400, 70)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        '
        'Label24
        '
        Me.Label24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 31)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(117, 22)
        Me.Label24.TabIndex = 54
        Me.Label24.Text = "Folio manual"
        '
        'rdb_ManejaFolioManualNo
        '
        Me.rdb_ManejaFolioManualNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_ManejaFolioManualNo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_ManejaFolioManualNo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_ManejaFolioManualNo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_ManejaFolioManualNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_ManejaFolioManualNo.Location = New System.Drawing.Point(309, 22)
        Me.rdb_ManejaFolioManualNo.Name = "rdb_ManejaFolioManualNo"
        Me.rdb_ManejaFolioManualNo.Size = New System.Drawing.Size(85, 42)
        Me.rdb_ManejaFolioManualNo.TabIndex = 54
        Me.rdb_ManejaFolioManualNo.Text = "No"
        Me.rdb_ManejaFolioManualNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_ManejaFolioManualNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_ManejaFolioManualNo.UseVisualStyleBackColor = True
        '
        'rdb_ManejaFolioManualSi
        '
        Me.rdb_ManejaFolioManualSi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_ManejaFolioManualSi.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_ManejaFolioManualSi.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_ManejaFolioManualSi.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_ManejaFolioManualSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_ManejaFolioManualSi.Location = New System.Drawing.Point(218, 22)
        Me.rdb_ManejaFolioManualSi.Name = "rdb_ManejaFolioManualSi"
        Me.rdb_ManejaFolioManualSi.Size = New System.Drawing.Size(85, 42)
        Me.rdb_ManejaFolioManualSi.TabIndex = 55
        Me.rdb_ManejaFolioManualSi.Text = "Si"
        Me.rdb_ManejaFolioManualSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_ManejaFolioManualSi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_ManejaFolioManualSi.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.rdb_ManejaDepositoManualNo)
        Me.GroupBox2.Controls.Add(Me.rdb_ManejaDepositoManualSi)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 70)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(15, 31)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(152, 22)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "Deposito manual"
        '
        'rdb_ManejaDepositoManualNo
        '
        Me.rdb_ManejaDepositoManualNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_ManejaDepositoManualNo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_ManejaDepositoManualNo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_ManejaDepositoManualNo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_ManejaDepositoManualNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_ManejaDepositoManualNo.Location = New System.Drawing.Point(309, 22)
        Me.rdb_ManejaDepositoManualNo.Name = "rdb_ManejaDepositoManualNo"
        Me.rdb_ManejaDepositoManualNo.Size = New System.Drawing.Size(85, 42)
        Me.rdb_ManejaDepositoManualNo.TabIndex = 54
        Me.rdb_ManejaDepositoManualNo.Text = "No"
        Me.rdb_ManejaDepositoManualNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_ManejaDepositoManualNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_ManejaDepositoManualNo.UseVisualStyleBackColor = True
        '
        'rdb_ManejaDepositoManualSi
        '
        Me.rdb_ManejaDepositoManualSi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_ManejaDepositoManualSi.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_ManejaDepositoManualSi.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_ManejaDepositoManualSi.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_ManejaDepositoManualSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_ManejaDepositoManualSi.Location = New System.Drawing.Point(218, 22)
        Me.rdb_ManejaDepositoManualSi.Name = "rdb_ManejaDepositoManualSi"
        Me.rdb_ManejaDepositoManualSi.Size = New System.Drawing.Size(85, 42)
        Me.rdb_ManejaDepositoManualSi.TabIndex = 55
        Me.rdb_ManejaDepositoManualSi.Text = "Si"
        Me.rdb_ManejaDepositoManualSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_ManejaDepositoManualSi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_ManejaDepositoManualSi.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdb_WebServiceNo)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.rdb_WebServiceSi)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 72)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        '
        'rdb_WebServiceNo
        '
        Me.rdb_WebServiceNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_WebServiceNo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_WebServiceNo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_WebServiceNo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_WebServiceNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_WebServiceNo.Location = New System.Drawing.Point(309, 24)
        Me.rdb_WebServiceNo.Name = "rdb_WebServiceNo"
        Me.rdb_WebServiceNo.Size = New System.Drawing.Size(85, 42)
        Me.rdb_WebServiceNo.TabIndex = 54
        Me.rdb_WebServiceNo.Text = "No"
        Me.rdb_WebServiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_WebServiceNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_WebServiceNo.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(28, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 22)
        Me.Label23.TabIndex = 55
        Me.Label23.Text = "Web Service"
        '
        'rdb_WebServiceSi
        '
        Me.rdb_WebServiceSi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_WebServiceSi.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_WebServiceSi.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_WebServiceSi.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_WebServiceSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_WebServiceSi.Location = New System.Drawing.Point(218, 24)
        Me.rdb_WebServiceSi.Name = "rdb_WebServiceSi"
        Me.rdb_WebServiceSi.Size = New System.Drawing.Size(85, 42)
        Me.rdb_WebServiceSi.TabIndex = 56
        Me.rdb_WebServiceSi.Text = "Si"
        Me.rdb_WebServiceSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_WebServiceSi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_WebServiceSi.UseVisualStyleBackColor = True
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Guardar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Guardar.Location = New System.Drawing.Point(4, 570)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Guardar.TabIndex = 1
        Me.btn_Guardar.Tag = ""
        Me.btn_Guardar.Text = "&Guardar"
        Me.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Guardar.UseVisualStyleBackColor = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(833, 570)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 2
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'lbl_Version
        '
        Me.lbl_Version.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_Version.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.lbl_Version.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Version.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Version.ForeColor = System.Drawing.Color.Black
        Me.lbl_Version.Location = New System.Drawing.Point(319, 582)
        Me.lbl_Version.Name = "lbl_Version"
        Me.lbl_Version.Size = New System.Drawing.Size(362, 56)
        Me.lbl_Version.TabIndex = 27
        Me.lbl_Version.Text = "Versión"
        Me.lbl_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_Parametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1001, 648)
        Me.Controls.Add(Me.lbl_Version)
        Me.Controls.Add(Me.Tab_Parametros)
        Me.Controls.Add(Me.btn_Guardar)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Parametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Tab_Parametros.ResumeLayout(False)
        Me.tbp_ConexionCentral.ResumeLayout(False)
        Me.gbx_ConexionSA.ResumeLayout(False)
        Me.gbx_ConexionSA.PerformLayout()
        Me.tbp_datos.ResumeLayout(False)
        Me.gbx_Sucursal.ResumeLayout(False)
        Me.gbx_Sucursal.PerformLayout()
        Me.tbp_SizeFuente.ResumeLayout(False)
        Me.gbx_Tiempo.ResumeLayout(False)
        Me.gbx_Tiempo.PerformLayout()
        CType(Me.pic_BuscarPuertos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp_Cajero.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.btn_TeamViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbx_NumValidadores.ResumeLayout(False)
        Me.gbx_NumValidadores.PerformLayout()
        Me.spc_Validadores.Panel1.ResumeLayout(False)
        Me.spc_Validadores.Panel2.ResumeLayout(False)
        CType(Me.spc_Validadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spc_Validadores.ResumeLayout(False)
        Me.gbx_StatusVal1.ResumeLayout(False)
        Me.gbx_StatusVal1.PerformLayout()
        Me.gbx_StatusVal2.ResumeLayout(False)
        Me.gbx_StatusVal2.PerformLayout()
        Me.tbp_TipoCambio.ResumeLayout(False)
        Me.gbx_TipoCambio.ResumeLayout(False)
        Me.gbx_TipoCambio.PerformLayout()
        Me.tbp_ConexionAdmin.ResumeLayout(False)
        Me.gbx_Conexion.ResumeLayout(False)
        Me.gbx_Conectado.ResumeLayout(False)
        Me.gbx_Conectado.PerformLayout()
        Me.gbx_Prioridad.ResumeLayout(False)
        Me.gbx_Prioridad.PerformLayout()
        Me.gbx_Actualizar.ResumeLayout(False)
        Me.tbp_Impresora.ResumeLayout(False)
        Me.gbx_Papel.ResumeLayout(False)
        Me.gbx_Papel.PerformLayout()
        CType(Me.pct_ImgEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbx_Sizepapel.ResumeLayout(False)
        Me.gbx_DetalleCD.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.grp_ConexionWebS.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gbx_verificarfolio.ResumeLayout(False)
        Me.gbx_verificarfolio.PerformLayout()
        Me.grp_CorteDiario.ResumeLayout(False)
        Me.grp_CorteDiario.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents lbl_MsgFuente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_cmdFuente As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_lblFuente As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Conectividad As System.Windows.Forms.Label
    Friend WithEvents Tab_Parametros As System.Windows.Forms.TabControl
    Friend WithEvents tbp_ConexionCentral As System.Windows.Forms.TabPage
    Friend WithEvents tbx_Password As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Password As System.Windows.Forms.Label
    Friend WithEvents tbx_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Usuario As System.Windows.Forms.Label
    Friend WithEvents tbx_BDD As System.Windows.Forms.TextBox
    Friend WithEvents lbl_BDD As System.Windows.Forms.Label
    Friend WithEvents tbx_Servidor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Servidor As System.Windows.Forms.Label
    Friend WithEvents btn_ConectarBDD As System.Windows.Forms.Button
    Friend WithEvents cmb_MsgFuente As System.Windows.Forms.ComboBox
    Friend WithEvents tbp_SizeFuente As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_TiempoSesion As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_TiempoReceptor As System.Windows.Forms.ComboBox
    Friend WithEvents rdb_SiConectaSA As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_NoconectaSA As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbx_ClaveUnica As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chk_Taskbar As System.Windows.Forms.CheckBox
    Friend WithEvents tbp_Cajero As System.Windows.Forms.TabPage
    Friend WithEvents tbp_datos As System.Windows.Forms.TabPage
    Friend WithEvents tbx_Validador2 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Validador1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Caset As System.Windows.Forms.Label
    Friend WithEvents lbl_val2 As System.Windows.Forms.Label
    Friend WithEvents lbl_val1 As System.Windows.Forms.Label
    Friend WithEvents lbl_caset2 As System.Windows.Forms.Label
    Friend WithEvents cmb_Caset2 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_CantodadVal As System.Windows.Forms.Label
    Friend WithEvents tbx_PuertoVal1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_puertoval1 As System.Windows.Forms.Label
    Friend WithEvents tbx_PuertoVal2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_puertoval2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmb_MargenIzq As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_TipoWindows As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbp_TipoCambio As System.Windows.Forms.TabPage
    Friend WithEvents btn_GuardarTC As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbx_NuevoTC As System.Windows.Forms.TextBox
    Friend WithEvents tbx_AnteriorTC As System.Windows.Forms.TextBox
    Friend WithEvents tbx_FechaTC As System.Windows.Forms.TextBox
    Friend WithEvents tbx_MonedaTC As System.Windows.Forms.TextBox
    Friend WithEvents tbx_DiasExpira As System.Windows.Forms.TextBox
    Friend WithEvents btn_DesktopSize As System.Windows.Forms.Button
    Friend WithEvents tbx_Height As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Height As System.Windows.Forms.Label
    Friend WithEvents tbx_Width As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Width As System.Windows.Forms.Label
    Friend WithEvents rdb_SiVal1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_NoVal1 As System.Windows.Forms.RadioButton
    Friend WithEvents gbx_StatusVal2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_NoVal2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_SiVal2 As System.Windows.Forms.RadioButton
    Friend WithEvents gbx_StatusVal1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_web As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_local As System.Windows.Forms.RadioButton
    Friend WithEvents btn_ActualizarLocal As System.Windows.Forms.Button
    Friend WithEvents btn_ActualizaWeb As System.Windows.Forms.Button
    Friend WithEvents lbl_LimiteCapacidadKct As System.Windows.Forms.Label
    Friend WithEvents cmb_LimiteCapacidadKct As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_LimiteCapacidadKct2 As System.Windows.Forms.Label
    Friend WithEvents cmb_LimiteCapacidadKct2 As System.Windows.Forms.ComboBox
    Friend WithEvents chk_BD As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Servidor As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ClaveUnica As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Password As System.Windows.Forms.CheckBox
    Friend WithEvents chk_User As System.Windows.Forms.CheckBox
    Friend WithEvents gbx_TipoCambio As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_ConectividadUser As System.Windows.Forms.Label
    Friend WithEvents rdb_SIconectaAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_NOconectaAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_Val1Activado As System.Windows.Forms.Label
    Friend WithEvents tbp_ConexionAdmin As System.Windows.Forms.TabPage
    Friend WithEvents gbx_Conexion As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents gbx_ConexionSA As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Tiempo As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Papel As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Actualizar As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Prioridad As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Conectado As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_NumValidadores As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_2val As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_1val As System.Windows.Forms.RadioButton
    Friend WithEvents cmb_NoCopias As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_NoCopias As System.Windows.Forms.Label
    Friend WithEvents cmb_LineasBlanco As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_LineasBlanco As System.Windows.Forms.Label
    Friend WithEvents tbp_Impresora As System.Windows.Forms.TabPage
    Friend WithEvents spc_Validadores As System.Windows.Forms.SplitContainer
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_HostIP As System.Windows.Forms.Label
    Friend WithEvents tbx_HostIP As System.Windows.Forms.TextBox
    Friend WithEvents pct_ImgEmpresa As System.Windows.Forms.PictureBox
    Friend WithEvents btn_AgregarLogo As System.Windows.Forms.Button
    Friend WithEvents lbl_DetalleCorteDiario As System.Windows.Forms.Label
    Friend WithEvents rdb_SIdetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_NOdetalle As System.Windows.Forms.RadioButton
    Friend WithEvents btn_EliminaLogo As System.Windows.Forms.Button
    Friend WithEvents rdb_80mm As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_58mm As System.Windows.Forms.RadioButton
    Friend WithEvents gbx_DetalleCD As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Sizepapel As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_MododeImprimir As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_MododeImprimir As System.Windows.Forms.Label
    Friend WithEvents Cmb_PesoDolarV1 As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_PesoDolarV2 As System.Windows.Forms.ComboBox
    Friend WithEvents gbx_Sucursal As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btn_FechaInicioOperaciones As System.Windows.Forms.Button
    Friend WithEvents lbl_Mail As System.Windows.Forms.Label
    Friend WithEvents lbl_RutaLog As System.Windows.Forms.Label
    Friend WithEvents btn_DestinoLog As System.Windows.Forms.Button
    Friend WithEvents tbx_Mail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbx_SucursalNombre As System.Windows.Forms.TextBox
    Friend WithEvents tbx_NombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents btn_AgregaCaset As System.Windows.Forms.Button
    Friend WithEvents lbl_NombreCorto As System.Windows.Forms.Label
    Friend WithEvents btn_Sincronizar As System.Windows.Forms.Button
    Friend WithEvents btn_Actualizar As System.Windows.Forms.Button
    Friend WithEvents cmb_ClaveSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_SucursalN As System.Windows.Forms.Label
    Friend WithEvents tbx_ClaveSucursal As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Cliente As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Cliente As System.Windows.Forms.Label
    Friend WithEvents tbx_ClaveCliente As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Telefono As System.Windows.Forms.Label
    Friend WithEvents lbl_Domicilio As System.Windows.Forms.Label
    Friend WithEvents tbx_Tel As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CiaTV As System.Windows.Forms.Label
    Friend WithEvents lbl_Cvecliente As System.Windows.Forms.Label
    Friend WithEvents tbx_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ClaveSucursal As System.Windows.Forms.Label
    Friend WithEvents tbx_CiaTV As System.Windows.Forms.TextBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grp_ConexionWebS As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_PorcBateriaCritica As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_PorcBateriaBaja As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_BateriaBaja As System.Windows.Forms.Label
    Friend WithEvents lbl_BateriaCritica As System.Windows.Forms.Label
    Friend WithEvents cmb_puertoSensor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_puertoSensor As System.Windows.Forms.Label
    Friend WithEvents pic_BuscarPuertos As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents rdb_ManejaDepositoManualNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_ManejaDepositoManualSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_WebServiceNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents rdb_WebServiceSi As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents rdb_ManejaFolioManualNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_ManejaFolioManualSi As System.Windows.Forms.RadioButton
    Friend WithEvents grp_CorteDiario As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_CorteNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Rdb_CorteSi As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_TeamViewer As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents gbx_verificarfolio As GroupBox
    Friend WithEvents Label27 As Label
    Friend WithEvents rdb_validarfn As RadioButton
    Friend WithEvents rdb_validarfsi As RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_sin_n As System.Windows.Forms.RadioButton
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Rdb_sin_s As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_Cajero As System.Windows.Forms.Label
    Friend WithEvents tbx_IdCajero As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_rdn As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Rdb_rds As System.Windows.Forms.RadioButton
    Friend WithEvents cmb_Caset As ComboBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Cmb_Plaza As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents lbl_Version As Label
End Class
