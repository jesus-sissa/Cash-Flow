<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaDepositos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ConsultaDepositos))
        Me.lbl_Desde = New System.Windows.Forms.Label()
        Me.lbl_Hasta = New System.Windows.Forms.Label()
        Me.cmb_Usuarios = New System.Windows.Forms.ComboBox()
        Me.lbl_TotalD = New System.Windows.Forms.Label()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.lbl_Usuario = New System.Windows.Forms.Label()
        Me.btn_FechaHasta = New System.Windows.Forms.Button()
        Me.btn_FechaDesde = New System.Windows.Forms.Button()
        Me.btn_Reimprimir = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.chk_Todos = New System.Windows.Forms.CheckBox()
        Me.btn_Detalle = New System.Windows.Forms.Button()
        Me.lsv_Depositos = New System.Windows.Forms.ListView()
        Me.btn_Mostrar = New System.Windows.Forms.Button()
        Me.chk_Cancelados = New System.Windows.Forms.CheckBox()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.tab_Depositos = New System.Windows.Forms.TabControl()
        Me.tab_ConsultaDepositos = New System.Windows.Forms.TabPage()
        Me.tab_SumaDepositos = New System.Windows.Forms.TabPage()
        Me.pnl_SumaDepositos = New System.Windows.Forms.Panel()
        Me.lbl_Usuario2 = New System.Windows.Forms.Label()
        Me.btn_FechaHasta2 = New System.Windows.Forms.Button()
        Me.btn_FechaDesde2 = New System.Windows.Forms.Button()
        Me.btn_Cerrar2 = New System.Windows.Forms.Button()
        Me.chk_Todos2 = New System.Windows.Forms.CheckBox()
        Me.lsv_SumaDepositos = New System.Windows.Forms.ListView()
        Me.cmb_Usuarios2 = New System.Windows.Forms.ComboBox()
        Me.btn_Mostrar2 = New System.Windows.Forms.Button()
        Me.lbl_TotalDeposito = New System.Windows.Forms.Label()
        Me.lbl_Desde2 = New System.Windows.Forms.Label()
        Me.lbl_Hasta2 = New System.Windows.Forms.Label()
        Me.pnl_General.SuspendLayout()
        Me.tab_Depositos.SuspendLayout()
        Me.tab_ConsultaDepositos.SuspendLayout()
        Me.tab_SumaDepositos.SuspendLayout()
        Me.pnl_SumaDepositos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Desde
        '
        Me.lbl_Desde.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Desde.Location = New System.Drawing.Point(25, 11)
        Me.lbl_Desde.Name = "lbl_Desde"
        Me.lbl_Desde.Size = New System.Drawing.Size(96, 32)
        Me.lbl_Desde.TabIndex = 0
        Me.lbl_Desde.Text = "Desde"
        Me.lbl_Desde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Hasta
        '
        Me.lbl_Hasta.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Hasta.Location = New System.Drawing.Point(287, 11)
        Me.lbl_Hasta.Name = "lbl_Hasta"
        Me.lbl_Hasta.Size = New System.Drawing.Size(87, 32)
        Me.lbl_Hasta.TabIndex = 2
        Me.lbl_Hasta.Text = "Hasta"
        Me.lbl_Hasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Usuarios
        '
        Me.cmb_Usuarios.DisplayMember = "Nombre_Corto"
        Me.cmb_Usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Usuarios.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Usuarios.FormattingEnabled = True
        Me.cmb_Usuarios.Location = New System.Drawing.Point(122, 52)
        Me.cmb_Usuarios.MaxDropDownItems = 20
        Me.cmb_Usuarios.Name = "cmb_Usuarios"
        Me.cmb_Usuarios.Size = New System.Drawing.Size(415, 40)
        Me.cmb_Usuarios.TabIndex = 4
        Me.cmb_Usuarios.ValueMember = "Clave_Usuario"
        '
        'lbl_TotalD
        '
        Me.lbl_TotalD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalD.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TotalD.Location = New System.Drawing.Point(185, 342)
        Me.lbl_TotalD.Name = "lbl_TotalD"
        Me.lbl_TotalD.Size = New System.Drawing.Size(267, 75)
        Me.lbl_TotalD.TabIndex = 10
        Me.lbl_TotalD.Text = "$0.00"
        Me.lbl_TotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.lbl_Usuario)
        Me.pnl_General.Controls.Add(Me.btn_FechaHasta)
        Me.pnl_General.Controls.Add(Me.btn_FechaDesde)
        Me.pnl_General.Controls.Add(Me.btn_Reimprimir)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.chk_Todos)
        Me.pnl_General.Controls.Add(Me.btn_Detalle)
        Me.pnl_General.Controls.Add(Me.lsv_Depositos)
        Me.pnl_General.Controls.Add(Me.cmb_Usuarios)
        Me.pnl_General.Controls.Add(Me.btn_Mostrar)
        Me.pnl_General.Controls.Add(Me.lbl_TotalD)
        Me.pnl_General.Controls.Add(Me.lbl_Desde)
        Me.pnl_General.Controls.Add(Me.chk_Cancelados)
        Me.pnl_General.Controls.Add(Me.lbl_Hasta)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Enabled = False
        Me.pnl_General.Location = New System.Drawing.Point(3, 3)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(782, 426)
        Me.pnl_General.TabIndex = 0
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Usuario.Location = New System.Drawing.Point(11, 52)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(109, 32)
        Me.lbl_Usuario.TabIndex = 16
        Me.lbl_Usuario.Text = "Usuario"
        Me.lbl_Usuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_FechaHasta
        '
        Me.btn_FechaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaHasta.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaHasta.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.calendar_16
        Me.btn_FechaHasta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaHasta.Location = New System.Drawing.Point(372, 5)
        Me.btn_FechaHasta.Name = "btn_FechaHasta"
        Me.btn_FechaHasta.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaHasta.TabIndex = 15
        Me.btn_FechaHasta.Tag = "1"
        Me.btn_FechaHasta.Text = "06/08/2016"
        Me.btn_FechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaHasta.UseVisualStyleBackColor = False
        '
        'btn_FechaDesde
        '
        Me.btn_FechaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaDesde.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaDesde.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.calendar_16
        Me.btn_FechaDesde.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaDesde.Location = New System.Drawing.Point(122, 5)
        Me.btn_FechaDesde.Name = "btn_FechaDesde"
        Me.btn_FechaDesde.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaDesde.TabIndex = 14
        Me.btn_FechaDesde.Tag = "1"
        Me.btn_FechaDesde.Text = "06/08/2016"
        Me.btn_FechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaDesde.UseVisualStyleBackColor = False
        '
        'btn_Reimprimir
        '
        Me.btn_Reimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Reimprimir.Enabled = False
        Me.btn_Reimprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Reimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Reimprimir.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reimprimir.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_Reimprimir.Location = New System.Drawing.Point(458, 342)
        Me.btn_Reimprimir.Name = "btn_Reimprimir"
        Me.btn_Reimprimir.Size = New System.Drawing.Size(155, 75)
        Me.btn_Reimprimir.TabIndex = 12
        Me.btn_Reimprimir.Text = "&Imprimir"
        Me.btn_Reimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Reimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Reimprimir.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(619, 342)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(155, 75)
        Me.btn_Cerrar.TabIndex = 11
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'chk_Todos
        '
        Me.chk_Todos.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_Todos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Todos.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_Todos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_Todos.Location = New System.Drawing.Point(542, 51)
        Me.chk_Todos.Name = "chk_Todos"
        Me.chk_Todos.Size = New System.Drawing.Size(85, 44)
        Me.chk_Todos.TabIndex = 5
        Me.chk_Todos.Text = "Todos"
        Me.chk_Todos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Todos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Todos.UseVisualStyleBackColor = True
        '
        'btn_Detalle
        '
        Me.btn_Detalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Detalle.Enabled = False
        Me.btn_Detalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Detalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Detalle.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Detalle
        Me.btn_Detalle.Location = New System.Drawing.Point(24, 342)
        Me.btn_Detalle.Name = "btn_Detalle"
        Me.btn_Detalle.Size = New System.Drawing.Size(155, 75)
        Me.btn_Detalle.TabIndex = 8
        Me.btn_Detalle.Text = "&Detalle"
        Me.btn_Detalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Detalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Detalle.UseVisualStyleBackColor = True
        '
        'lsv_Depositos
        '
        Me.lsv_Depositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Depositos.AutoArrange = False
        Me.lsv_Depositos.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_Depositos
        Me.lsv_Depositos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Depositos.FullRowSelect = True
        Me.lsv_Depositos.HideSelection = False
        Me.lsv_Depositos.Location = New System.Drawing.Point(-3, 98)
        Me.lsv_Depositos.MultiSelect = False
        Me.lsv_Depositos.Name = "lsv_Depositos"
        Me.lsv_Depositos.Size = New System.Drawing.Size(785, 241)
        Me.lsv_Depositos.TabIndex = 7
        Me.lsv_Depositos.UseCompatibleStateImageBehavior = False
        Me.lsv_Depositos.View = System.Windows.Forms.View.Details
        '
        'btn_Mostrar
        '
        Me.btn_Mostrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Mostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Mostrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Mostrar
        Me.btn_Mostrar.Location = New System.Drawing.Point(633, 9)
        Me.btn_Mostrar.Name = "btn_Mostrar"
        Me.btn_Mostrar.Size = New System.Drawing.Size(155, 75)
        Me.btn_Mostrar.TabIndex = 6
        Me.btn_Mostrar.Text = "&Mostrar"
        Me.btn_Mostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Mostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Mostrar.UseVisualStyleBackColor = False
        '
        'chk_Cancelados
        '
        Me.chk_Cancelados.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_Cancelados.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Cancelados.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_Cancelados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_Cancelados.Location = New System.Drawing.Point(542, 6)
        Me.chk_Cancelados.Name = "chk_Cancelados"
        Me.chk_Cancelados.Size = New System.Drawing.Size(85, 44)
        Me.chk_Cancelados.TabIndex = 13
        Me.chk_Cancelados.Text = "CNL"
        Me.chk_Cancelados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Cancelados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Cancelados.UseVisualStyleBackColor = True
        '
        'iml_Sincronia
        '
        Me.iml_Sincronia.ImageStream = CType(resources.GetObject("iml_Sincronia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Sincronia.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Sincronia.Images.SetKeyName(0, "Correcto.png")
        Me.iml_Sincronia.Images.SetKeyName(1, "Pendiente.png")
        '
        'tab_Depositos
        '
        Me.tab_Depositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_Depositos.Controls.Add(Me.tab_ConsultaDepositos)
        Me.tab_Depositos.Controls.Add(Me.tab_SumaDepositos)
        Me.tab_Depositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_Depositos.Location = New System.Drawing.Point(2, 3)
        Me.tab_Depositos.Name = "tab_Depositos"
        Me.tab_Depositos.SelectedIndex = 0
        Me.tab_Depositos.Size = New System.Drawing.Size(796, 474)
        Me.tab_Depositos.TabIndex = 1
        '
        'tab_ConsultaDepositos
        '
        Me.tab_ConsultaDepositos.Controls.Add(Me.pnl_General)
        Me.tab_ConsultaDepositos.Location = New System.Drawing.Point(4, 38)
        Me.tab_ConsultaDepositos.Name = "tab_ConsultaDepositos"
        Me.tab_ConsultaDepositos.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ConsultaDepositos.Size = New System.Drawing.Size(788, 432)
        Me.tab_ConsultaDepositos.TabIndex = 0
        Me.tab_ConsultaDepositos.Text = "Consulta Depósitos"
        Me.tab_ConsultaDepositos.UseVisualStyleBackColor = True
        '
        'tab_SumaDepositos
        '
        Me.tab_SumaDepositos.Controls.Add(Me.pnl_SumaDepositos)
        Me.tab_SumaDepositos.Location = New System.Drawing.Point(4, 38)
        Me.tab_SumaDepositos.Name = "tab_SumaDepositos"
        Me.tab_SumaDepositos.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_SumaDepositos.Size = New System.Drawing.Size(788, 432)
        Me.tab_SumaDepositos.TabIndex = 1
        Me.tab_SumaDepositos.Text = "Suma Depósitos"
        Me.tab_SumaDepositos.UseVisualStyleBackColor = True
        '
        'pnl_SumaDepositos
        '
        Me.pnl_SumaDepositos.Controls.Add(Me.lbl_Usuario2)
        Me.pnl_SumaDepositos.Controls.Add(Me.btn_FechaHasta2)
        Me.pnl_SumaDepositos.Controls.Add(Me.btn_FechaDesde2)
        Me.pnl_SumaDepositos.Controls.Add(Me.btn_Cerrar2)
        Me.pnl_SumaDepositos.Controls.Add(Me.chk_Todos2)
        Me.pnl_SumaDepositos.Controls.Add(Me.lsv_SumaDepositos)
        Me.pnl_SumaDepositos.Controls.Add(Me.cmb_Usuarios2)
        Me.pnl_SumaDepositos.Controls.Add(Me.btn_Mostrar2)
        Me.pnl_SumaDepositos.Controls.Add(Me.lbl_TotalDeposito)
        Me.pnl_SumaDepositos.Controls.Add(Me.lbl_Desde2)
        Me.pnl_SumaDepositos.Controls.Add(Me.lbl_Hasta2)
        Me.pnl_SumaDepositos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_SumaDepositos.Location = New System.Drawing.Point(3, 3)
        Me.pnl_SumaDepositos.Name = "pnl_SumaDepositos"
        Me.pnl_SumaDepositos.Size = New System.Drawing.Size(782, 426)
        Me.pnl_SumaDepositos.TabIndex = 1
        '
        'lbl_Usuario2
        '
        Me.lbl_Usuario2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Usuario2.Location = New System.Drawing.Point(11, 52)
        Me.lbl_Usuario2.Name = "lbl_Usuario2"
        Me.lbl_Usuario2.Size = New System.Drawing.Size(109, 32)
        Me.lbl_Usuario2.TabIndex = 16
        Me.lbl_Usuario2.Text = "Usuario"
        Me.lbl_Usuario2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_FechaHasta2
        '
        Me.btn_FechaHasta2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaHasta2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaHasta2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.calendar_16
        Me.btn_FechaHasta2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaHasta2.Location = New System.Drawing.Point(372, 5)
        Me.btn_FechaHasta2.Name = "btn_FechaHasta2"
        Me.btn_FechaHasta2.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaHasta2.TabIndex = 15
        Me.btn_FechaHasta2.Tag = "1"
        Me.btn_FechaHasta2.Text = "06/08/2016"
        Me.btn_FechaHasta2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaHasta2.UseVisualStyleBackColor = False
        '
        'btn_FechaDesde2
        '
        Me.btn_FechaDesde2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaDesde2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaDesde2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.calendar_16
        Me.btn_FechaDesde2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaDesde2.Location = New System.Drawing.Point(122, 5)
        Me.btn_FechaDesde2.Name = "btn_FechaDesde2"
        Me.btn_FechaDesde2.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaDesde2.TabIndex = 14
        Me.btn_FechaDesde2.Tag = "1"
        Me.btn_FechaDesde2.Text = "06/08/2016"
        Me.btn_FechaDesde2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaDesde2.UseVisualStyleBackColor = False
        '
        'btn_Cerrar2
        '
        Me.btn_Cerrar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Cerrar2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar2.Location = New System.Drawing.Point(624, 342)
        Me.btn_Cerrar2.Name = "btn_Cerrar2"
        Me.btn_Cerrar2.Size = New System.Drawing.Size(155, 75)
        Me.btn_Cerrar2.TabIndex = 11
        Me.btn_Cerrar2.Text = "&Cerrar"
        Me.btn_Cerrar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar2.UseVisualStyleBackColor = True
        '
        'chk_Todos2
        '
        Me.chk_Todos2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_Todos2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Todos2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_Todos2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_Todos2.Location = New System.Drawing.Point(452, 48)
        Me.chk_Todos2.Name = "chk_Todos2"
        Me.chk_Todos2.Size = New System.Drawing.Size(85, 44)
        Me.chk_Todos2.TabIndex = 5
        Me.chk_Todos2.Text = "Todos"
        Me.chk_Todos2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Todos2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Todos2.UseVisualStyleBackColor = True
        '
        'lsv_SumaDepositos
        '
        Me.lsv_SumaDepositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_SumaDepositos.AutoArrange = False
        Me.lsv_SumaDepositos.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_Depositos
        Me.lsv_SumaDepositos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_SumaDepositos.FullRowSelect = True
        Me.lsv_SumaDepositos.HideSelection = False
        Me.lsv_SumaDepositos.Location = New System.Drawing.Point(-3, 98)
        Me.lsv_SumaDepositos.MultiSelect = False
        Me.lsv_SumaDepositos.Name = "lsv_SumaDepositos"
        Me.lsv_SumaDepositos.Size = New System.Drawing.Size(785, 241)
        Me.lsv_SumaDepositos.TabIndex = 7
        Me.lsv_SumaDepositos.UseCompatibleStateImageBehavior = False
        Me.lsv_SumaDepositos.View = System.Windows.Forms.View.Details
        '
        'cmb_Usuarios2
        '
        Me.cmb_Usuarios2.DisplayMember = "Nombre_Corto"
        Me.cmb_Usuarios2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Usuarios2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Usuarios2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Usuarios2.FormattingEnabled = True
        Me.cmb_Usuarios2.Location = New System.Drawing.Point(122, 52)
        Me.cmb_Usuarios2.MaxDropDownItems = 20
        Me.cmb_Usuarios2.Name = "cmb_Usuarios2"
        Me.cmb_Usuarios2.Size = New System.Drawing.Size(324, 40)
        Me.cmb_Usuarios2.TabIndex = 4
        Me.cmb_Usuarios2.ValueMember = "Clave_Usuario"
        '
        'btn_Mostrar2
        '
        Me.btn_Mostrar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Mostrar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Mostrar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Mostrar2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Mostrar
        Me.btn_Mostrar2.Location = New System.Drawing.Point(544, 5)
        Me.btn_Mostrar2.Name = "btn_Mostrar2"
        Me.btn_Mostrar2.Size = New System.Drawing.Size(155, 75)
        Me.btn_Mostrar2.TabIndex = 6
        Me.btn_Mostrar2.Text = "&Mostrar"
        Me.btn_Mostrar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Mostrar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Mostrar2.UseVisualStyleBackColor = False
        '
        'lbl_TotalDeposito
        '
        Me.lbl_TotalDeposito.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalDeposito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalDeposito.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalDeposito.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TotalDeposito.Location = New System.Drawing.Point(3, 342)
        Me.lbl_TotalDeposito.Name = "lbl_TotalDeposito"
        Me.lbl_TotalDeposito.Size = New System.Drawing.Size(610, 75)
        Me.lbl_TotalDeposito.TabIndex = 10
        Me.lbl_TotalDeposito.Text = "$0.00"
        Me.lbl_TotalDeposito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Desde2
        '
        Me.lbl_Desde2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Desde2.Location = New System.Drawing.Point(25, 11)
        Me.lbl_Desde2.Name = "lbl_Desde2"
        Me.lbl_Desde2.Size = New System.Drawing.Size(96, 32)
        Me.lbl_Desde2.TabIndex = 0
        Me.lbl_Desde2.Text = "Desde"
        Me.lbl_Desde2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Hasta2
        '
        Me.lbl_Hasta2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Hasta2.Location = New System.Drawing.Point(287, 11)
        Me.lbl_Hasta2.Name = "lbl_Hasta2"
        Me.lbl_Hasta2.Size = New System.Drawing.Size(87, 32)
        Me.lbl_Hasta2.TabIndex = 2
        Me.lbl_Hasta2.Text = "Hasta"
        Me.lbl_Hasta2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_ConsultaDepositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.tab_Depositos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaDepositos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Depósitos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.tab_Depositos.ResumeLayout(False)
        Me.tab_ConsultaDepositos.ResumeLayout(False)
        Me.tab_SumaDepositos.ResumeLayout(False)
        Me.pnl_SumaDepositos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsv_Depositos As System.Windows.Forms.ListView
    Friend WithEvents btn_Mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lbl_Desde As System.Windows.Forms.Label
    Friend WithEvents lbl_Hasta As System.Windows.Forms.Label
    Friend WithEvents cmb_Usuarios As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Detalle As System.Windows.Forms.Button
    Friend WithEvents chk_Todos As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_TotalD As System.Windows.Forms.Label
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Reimprimir As System.Windows.Forms.Button
    Friend WithEvents chk_Cancelados As System.Windows.Forms.CheckBox
    Friend WithEvents btn_FechaDesde As System.Windows.Forms.Button
    Friend WithEvents btn_FechaHasta As System.Windows.Forms.Button
    Friend WithEvents lbl_Usuario As System.Windows.Forms.Label
    Friend WithEvents iml_Sincronia As System.Windows.Forms.ImageList
    Friend WithEvents tab_Depositos As System.Windows.Forms.TabControl
    Friend WithEvents tab_ConsultaDepositos As System.Windows.Forms.TabPage
    Friend WithEvents tab_SumaDepositos As System.Windows.Forms.TabPage
    Friend WithEvents pnl_SumaDepositos As System.Windows.Forms.Panel
    Friend WithEvents lbl_Usuario2 As System.Windows.Forms.Label
    Friend WithEvents btn_FechaHasta2 As System.Windows.Forms.Button
    Friend WithEvents btn_FechaDesde2 As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar2 As System.Windows.Forms.Button
    Friend WithEvents chk_Todos2 As System.Windows.Forms.CheckBox
    Friend WithEvents lsv_SumaDepositos As System.Windows.Forms.ListView
    Friend WithEvents cmb_Usuarios2 As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Mostrar2 As System.Windows.Forms.Button
    Friend WithEvents lbl_TotalDeposito As System.Windows.Forms.Label
    Friend WithEvents lbl_Desde2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Hasta2 As System.Windows.Forms.Label
End Class
