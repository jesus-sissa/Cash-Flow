<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ConsultaUsuarios))
        Me.lsv_Usuarios = New System.Windows.Forms.ListView()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.tab_Usuarios = New System.Windows.Forms.TabControl()
        Me.tbp_ListadoUser = New System.Windows.Forms.TabPage()
        Me.btn_ReiniciarPassword = New System.Windows.Forms.Button()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Editar = New System.Windows.Forms.Button()
        Me.btn_CambiarStatus = New System.Windows.Forms.Button()
        Me.tbp_Nuevo = New System.Windows.Forms.TabPage()
        Me.tbx_NombreCorto = New System.Windows.Forms.TextBox()
        Me.lbl_NombreCorto = New System.Windows.Forms.Label()
        Me.lbl_Advertencia = New System.Windows.Forms.Label()
        Me.tbx_ContrasenaNueva = New System.Windows.Forms.TextBox()
        Me.tbx_ContrasenaActual = New System.Windows.Forms.TextBox()
        Me.lbl_Clave = New System.Windows.Forms.Label()
        Me.lbl_ContrasenaActual = New System.Windows.Forms.Label()
        Me.lbl_ContrasenaNueva = New System.Windows.Forms.Label()
        Me.lbl_Tipo = New System.Windows.Forms.Label()
        Me.tbx_NombreCompleto = New System.Windows.Forms.TextBox()
        Me.tbx_Confirmar = New System.Windows.Forms.TextBox()
        Me.lbl_NombreCompleto = New System.Windows.Forms.Label()
        Me.lbl_Confirmar = New System.Windows.Forms.Label()
        Me.gbx_Tipo = New System.Windows.Forms.GroupBox()
        Me.rdb_Admin = New System.Windows.Forms.RadioButton()
        Me.rdb_Local = New System.Windows.Forms.RadioButton()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_CerrarNewuser = New System.Windows.Forms.Button()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.tbx_Clave = New System.Windows.Forms.TextBox()
        Me.pnl_General.SuspendLayout()
        Me.tab_Usuarios.SuspendLayout()
        Me.tbp_ListadoUser.SuspendLayout()
        Me.tbp_Nuevo.SuspendLayout()
        Me.gbx_Tipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsv_Usuarios
        '
        Me.lsv_Usuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Usuarios.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Usuarios.FullRowSelect = True
        Me.lsv_Usuarios.HideSelection = False
        Me.lsv_Usuarios.Location = New System.Drawing.Point(6, 6)
        Me.lsv_Usuarios.MultiSelect = False
        Me.lsv_Usuarios.Name = "lsv_Usuarios"
        Me.lsv_Usuarios.Size = New System.Drawing.Size(783, 347)
        Me.lsv_Usuarios.TabIndex = 0
        Me.lsv_Usuarios.UseCompatibleStateImageBehavior = False
        Me.lsv_Usuarios.View = System.Windows.Forms.View.Details
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.tab_Usuarios)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'tab_Usuarios
        '
        Me.tab_Usuarios.Controls.Add(Me.tbp_ListadoUser)
        Me.tab_Usuarios.Controls.Add(Me.tbp_Nuevo)
        Me.tab_Usuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Usuarios.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_Usuarios.Location = New System.Drawing.Point(0, 0)
        Me.tab_Usuarios.Name = "tab_Usuarios"
        Me.tab_Usuarios.SelectedIndex = 0
        Me.tab_Usuarios.Size = New System.Drawing.Size(800, 480)
        Me.tab_Usuarios.TabIndex = 0
        '
        'tbp_ListadoUser
        '
        Me.tbp_ListadoUser.Controls.Add(Me.btn_ReiniciarPassword)
        Me.tbp_ListadoUser.Controls.Add(Me.btn_Eliminar)
        Me.tbp_ListadoUser.Controls.Add(Me.btn_Cerrar)
        Me.tbp_ListadoUser.Controls.Add(Me.btn_Editar)
        Me.tbp_ListadoUser.Controls.Add(Me.btn_CambiarStatus)
        Me.tbp_ListadoUser.Controls.Add(Me.lsv_Usuarios)
        Me.tbp_ListadoUser.Location = New System.Drawing.Point(4, 36)
        Me.tbp_ListadoUser.Name = "tbp_ListadoUser"
        Me.tbp_ListadoUser.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_ListadoUser.Size = New System.Drawing.Size(792, 440)
        Me.tbp_ListadoUser.TabIndex = 0
        Me.tbp_ListadoUser.Text = "Listado"
        Me.tbp_ListadoUser.UseVisualStyleBackColor = True
        '
        'btn_ReiniciarPassword
        '
        Me.btn_ReiniciarPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ReiniciarPassword.BackColor = System.Drawing.SystemColors.Control
        Me.btn_ReiniciarPassword.Enabled = False
        Me.btn_ReiniciarPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ReiniciarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ReiniciarPassword.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ReiniciarPassword.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CambiarPassword
        Me.btn_ReiniciarPassword.Location = New System.Drawing.Point(320, 359)
        Me.btn_ReiniciarPassword.Name = "btn_ReiniciarPassword"
        Me.btn_ReiniciarPassword.Size = New System.Drawing.Size(150, 75)
        Me.btn_ReiniciarPassword.TabIndex = 5
        Me.btn_ReiniciarPassword.Text = "Reiniciar"
        Me.btn_ReiniciarPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ReiniciarPassword.UseVisualStyleBackColor = False
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Eliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Eliminar.Enabled = False
        Me.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Eliminar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Eliminar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_EliminarUsuario
        Me.btn_Eliminar.Location = New System.Drawing.Point(164, 359)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(150, 75)
        Me.btn_Eliminar.TabIndex = 1
        Me.btn_Eliminar.Text = "&Eliminar"
        Me.btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Eliminar.UseVisualStyleBackColor = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(639, 359)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(150, 75)
        Me.btn_Cerrar.TabIndex = 4
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'btn_Editar
        '
        Me.btn_Editar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Editar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Editar.Enabled = False
        Me.btn_Editar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Editar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Editar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_EditarUsuario
        Me.btn_Editar.Location = New System.Drawing.Point(8, 359)
        Me.btn_Editar.Name = "btn_Editar"
        Me.btn_Editar.Size = New System.Drawing.Size(150, 75)
        Me.btn_Editar.TabIndex = 2
        Me.btn_Editar.Text = "E&ditar"
        Me.btn_Editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Editar.UseVisualStyleBackColor = False
        '
        'btn_CambiarStatus
        '
        Me.btn_CambiarStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CambiarStatus.BackColor = System.Drawing.SystemColors.Control
        Me.btn_CambiarStatus.Enabled = False
        Me.btn_CambiarStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CambiarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CambiarStatus.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CambiarStatus.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.BajaReing
        Me.btn_CambiarStatus.Location = New System.Drawing.Point(476, 359)
        Me.btn_CambiarStatus.Name = "btn_CambiarStatus"
        Me.btn_CambiarStatus.Size = New System.Drawing.Size(150, 75)
        Me.btn_CambiarStatus.TabIndex = 3
        Me.btn_CambiarStatus.Text = "Estatus"
        Me.btn_CambiarStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_CambiarStatus.UseVisualStyleBackColor = False
        '
        'tbp_Nuevo
        '
        Me.tbp_Nuevo.Controls.Add(Me.tbx_NombreCorto)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_NombreCorto)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_Advertencia)
        Me.tbp_Nuevo.Controls.Add(Me.tbx_ContrasenaNueva)
        Me.tbp_Nuevo.Controls.Add(Me.tbx_ContrasenaActual)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_Clave)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_ContrasenaActual)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_ContrasenaNueva)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_Tipo)
        Me.tbp_Nuevo.Controls.Add(Me.tbx_NombreCompleto)
        Me.tbp_Nuevo.Controls.Add(Me.tbx_Confirmar)
        Me.tbp_Nuevo.Controls.Add(Me.tbx_Clave)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_NombreCompleto)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_Confirmar)
        Me.tbp_Nuevo.Controls.Add(Me.gbx_Tipo)
        Me.tbp_Nuevo.Controls.Add(Me.btn_Guardar)
        Me.tbp_Nuevo.Controls.Add(Me.btn_CerrarNewuser)
        Me.tbp_Nuevo.Location = New System.Drawing.Point(4, 36)
        Me.tbp_Nuevo.Name = "tbp_Nuevo"
        Me.tbp_Nuevo.Size = New System.Drawing.Size(792, 440)
        Me.tbp_Nuevo.TabIndex = 2
        Me.tbp_Nuevo.Text = "Nuevo"
        '
        'tbx_NombreCorto
        '
        Me.tbx_NombreCorto.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_NombreCorto.Location = New System.Drawing.Point(261, 120)
        Me.tbx_NombreCorto.MaxLength = 20
        Me.tbx_NombreCorto.Name = "tbx_NombreCorto"
        Me.tbx_NombreCorto.Size = New System.Drawing.Size(214, 39)
        Me.tbx_NombreCorto.TabIndex = 7
        '
        'lbl_NombreCorto
        '
        Me.lbl_NombreCorto.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NombreCorto.Location = New System.Drawing.Point(57, 128)
        Me.lbl_NombreCorto.Name = "lbl_NombreCorto"
        Me.lbl_NombreCorto.Size = New System.Drawing.Size(198, 31)
        Me.lbl_NombreCorto.TabIndex = 6
        Me.lbl_NombreCorto.Text = "Nombre Corto"
        Me.lbl_NombreCorto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Advertencia
        '
        Me.lbl_Advertencia.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Advertencia.Location = New System.Drawing.Point(228, 337)
        Me.lbl_Advertencia.Name = "lbl_Advertencia"
        Me.lbl_Advertencia.Size = New System.Drawing.Size(297, 80)
        Me.lbl_Advertencia.TabIndex = 29
        Me.lbl_Advertencia.Text = "4 Numeros y 4 Letras(Mayus y Minus)"
        Me.lbl_Advertencia.Visible = False
        '
        'tbx_ContrasenaNueva
        '
        Me.tbx_ContrasenaNueva.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ContrasenaNueva.Location = New System.Drawing.Point(261, 210)
        Me.tbx_ContrasenaNueva.MaxLength = 8
        Me.tbx_ContrasenaNueva.Name = "tbx_ContrasenaNueva"
        Me.tbx_ContrasenaNueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_ContrasenaNueva.Size = New System.Drawing.Size(107, 39)
        Me.tbx_ContrasenaNueva.TabIndex = 11
        Me.tbx_ContrasenaNueva.Visible = False
        '
        'tbx_ContrasenaActual
        '
        Me.tbx_ContrasenaActual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ContrasenaActual.Location = New System.Drawing.Point(261, 165)
        Me.tbx_ContrasenaActual.MaxLength = 8
        Me.tbx_ContrasenaActual.Name = "tbx_ContrasenaActual"
        Me.tbx_ContrasenaActual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_ContrasenaActual.Size = New System.Drawing.Size(107, 39)
        Me.tbx_ContrasenaActual.TabIndex = 9
        Me.tbx_ContrasenaActual.Visible = False
        '
        'lbl_Clave
        '
        Me.lbl_Clave.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clave.Location = New System.Drawing.Point(171, 32)
        Me.lbl_Clave.Name = "lbl_Clave"
        Me.lbl_Clave.Size = New System.Drawing.Size(84, 31)
        Me.lbl_Clave.TabIndex = 0
        Me.lbl_Clave.Text = "Clave"
        Me.lbl_Clave.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_ContrasenaActual
        '
        Me.lbl_ContrasenaActual.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ContrasenaActual.Location = New System.Drawing.Point(28, 173)
        Me.lbl_ContrasenaActual.Name = "lbl_ContrasenaActual"
        Me.lbl_ContrasenaActual.Size = New System.Drawing.Size(227, 31)
        Me.lbl_ContrasenaActual.TabIndex = 8
        Me.lbl_ContrasenaActual.Text = "Contraseña Actual"
        Me.lbl_ContrasenaActual.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_ContrasenaActual.Visible = False
        '
        'lbl_ContrasenaNueva
        '
        Me.lbl_ContrasenaNueva.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ContrasenaNueva.Location = New System.Drawing.Point(104, 218)
        Me.lbl_ContrasenaNueva.Name = "lbl_ContrasenaNueva"
        Me.lbl_ContrasenaNueva.Size = New System.Drawing.Size(151, 31)
        Me.lbl_ContrasenaNueva.TabIndex = 10
        Me.lbl_ContrasenaNueva.Text = "Contraseña Nueva"
        Me.lbl_ContrasenaNueva.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_ContrasenaNueva.Visible = False
        '
        'lbl_Tipo
        '
        Me.lbl_Tipo.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tipo.Location = New System.Drawing.Point(425, 32)
        Me.lbl_Tipo.Name = "lbl_Tipo"
        Me.lbl_Tipo.Size = New System.Drawing.Size(68, 31)
        Me.lbl_Tipo.TabIndex = 2
        Me.lbl_Tipo.Text = "Tipo"
        Me.lbl_Tipo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tbx_NombreCompleto
        '
        Me.tbx_NombreCompleto.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_NombreCompleto.Location = New System.Drawing.Point(261, 75)
        Me.tbx_NombreCompleto.MaxLength = 50
        Me.tbx_NombreCompleto.Name = "tbx_NombreCompleto"
        Me.tbx_NombreCompleto.Size = New System.Drawing.Size(485, 39)
        Me.tbx_NombreCompleto.TabIndex = 5
        '
        'tbx_Confirmar
        '
        Me.tbx_Confirmar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Confirmar.Location = New System.Drawing.Point(261, 255)
        Me.tbx_Confirmar.MaxLength = 8
        Me.tbx_Confirmar.Name = "tbx_Confirmar"
        Me.tbx_Confirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Confirmar.Size = New System.Drawing.Size(107, 39)
        Me.tbx_Confirmar.TabIndex = 13
        Me.tbx_Confirmar.Visible = False
        '
        'lbl_NombreCompleto
        '
        Me.lbl_NombreCompleto.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NombreCompleto.Location = New System.Drawing.Point(19, 83)
        Me.lbl_NombreCompleto.Name = "lbl_NombreCompleto"
        Me.lbl_NombreCompleto.Size = New System.Drawing.Size(236, 31)
        Me.lbl_NombreCompleto.TabIndex = 4
        Me.lbl_NombreCompleto.Text = "Nombre Completo"
        Me.lbl_NombreCompleto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Confirmar
        '
        Me.lbl_Confirmar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Confirmar.Location = New System.Drawing.Point(3, 263)
        Me.lbl_Confirmar.Name = "lbl_Confirmar"
        Me.lbl_Confirmar.Size = New System.Drawing.Size(252, 31)
        Me.lbl_Confirmar.TabIndex = 12
        Me.lbl_Confirmar.Text = "Confirmar Contraseña"
        Me.lbl_Confirmar.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbl_Confirmar.Visible = False
        '
        'gbx_Tipo
        '
        Me.gbx_Tipo.Controls.Add(Me.rdb_Admin)
        Me.gbx_Tipo.Controls.Add(Me.rdb_Local)
        Me.gbx_Tipo.Location = New System.Drawing.Point(499, 3)
        Me.gbx_Tipo.Name = "gbx_Tipo"
        Me.gbx_Tipo.Size = New System.Drawing.Size(286, 70)
        Me.gbx_Tipo.TabIndex = 3
        Me.gbx_Tipo.TabStop = False
        '
        'rdb_Admin
        '
        Me.rdb_Admin.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_Admin.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_Admin.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_Admin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_Admin.Location = New System.Drawing.Point(150, 22)
        Me.rdb_Admin.Name = "rdb_Admin"
        Me.rdb_Admin.Size = New System.Drawing.Size(130, 42)
        Me.rdb_Admin.TabIndex = 1
        Me.rdb_Admin.Text = "Admin"
        Me.rdb_Admin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_Admin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_Admin.UseVisualStyleBackColor = True
        '
        'rdb_Local
        '
        Me.rdb_Local.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_Local.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_Local.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_Local.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_Local.Location = New System.Drawing.Point(5, 22)
        Me.rdb_Local.Name = "rdb_Local"
        Me.rdb_Local.Size = New System.Drawing.Size(130, 42)
        Me.rdb_Local.TabIndex = 0
        Me.rdb_Local.Text = "Local"
        Me.rdb_Local.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_Local.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_Local.UseVisualStyleBackColor = True
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Guardar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Guardar.Location = New System.Drawing.Point(8, 357)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Guardar.TabIndex = 14
        Me.btn_Guardar.Text = "&Guardar"
        Me.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_CerrarNewuser
        '
        Me.btn_CerrarNewuser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CerrarNewuser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CerrarNewuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CerrarNewuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_CerrarNewuser.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Cancelar
        Me.btn_CerrarNewuser.Location = New System.Drawing.Point(620, 357)
        Me.btn_CerrarNewuser.Name = "btn_CerrarNewuser"
        Me.btn_CerrarNewuser.Size = New System.Drawing.Size(164, 75)
        Me.btn_CerrarNewuser.TabIndex = 15
        Me.btn_CerrarNewuser.Text = "&Cancelar"
        Me.btn_CerrarNewuser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CerrarNewuser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_CerrarNewuser.UseVisualStyleBackColor = True
        '
        'iml_Sincronia
        '
        Me.iml_Sincronia.ImageStream = CType(resources.GetObject("iml_Sincronia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Sincronia.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Sincronia.Images.SetKeyName(0, "Correcto.png")
        Me.iml_Sincronia.Images.SetKeyName(1, "Pendiente.png")
        '
        'tbx_Clave
        '
        Me.tbx_Clave.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Clave.Location = New System.Drawing.Point(261, 30)
        Me.tbx_Clave.MaxLength = 4
        Me.tbx_Clave.Name = "tbx_Clave"
        Me.tbx_Clave.Size = New System.Drawing.Size(107, 39)
        Me.tbx_Clave.TabIndex = 1
        '
        'frm_ConsultaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.tab_Usuarios.ResumeLayout(False)
        Me.tbp_ListadoUser.ResumeLayout(False)
        Me.tbp_Nuevo.ResumeLayout(False)
        Me.tbp_Nuevo.PerformLayout()
        Me.gbx_Tipo.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_Editar As System.Windows.Forms.Button
    Friend WithEvents btn_CambiarStatus As System.Windows.Forms.Button
    Friend WithEvents lsv_Usuarios As System.Windows.Forms.ListView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents tab_Usuarios As System.Windows.Forms.TabControl
    Friend WithEvents tbp_ListadoUser As System.Windows.Forms.TabPage
    Friend WithEvents tbp_Nuevo As System.Windows.Forms.TabPage
    Friend WithEvents lbl_Advertencia As System.Windows.Forms.Label
    Friend WithEvents tbx_ContrasenaNueva As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ContrasenaActual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Clave As System.Windows.Forms.Label
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents lbl_ContrasenaActual As System.Windows.Forms.Label
    Friend WithEvents btn_CerrarNewuser As System.Windows.Forms.Button
    Friend WithEvents lbl_ContrasenaNueva As System.Windows.Forms.Label
    Friend WithEvents lbl_Tipo As System.Windows.Forms.Label
    Friend WithEvents tbx_NombreCompleto As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Confirmar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NombreCompleto As System.Windows.Forms.Label
    Friend WithEvents lbl_Confirmar As System.Windows.Forms.Label
    Friend WithEvents gbx_Tipo As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_Admin As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_Local As System.Windows.Forms.RadioButton
    Friend WithEvents tbx_NombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NombreCorto As System.Windows.Forms.Label
    Friend WithEvents iml_Sincronia As System.Windows.Forms.ImageList
    Friend WithEvents btn_ReiniciarPassword As System.Windows.Forms.Button
    Friend WithEvents tbx_Clave As System.Windows.Forms.TextBox
End Class
