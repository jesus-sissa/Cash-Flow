<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaAtascos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ConsultaAtascos))
        Me.tab_Depositos = New System.Windows.Forms.TabControl()
        Me.tab_ConsultaAtascos = New System.Windows.Forms.TabPage()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.lbl_Usuario = New System.Windows.Forms.Label()
        Me.btn_FechaHasta = New System.Windows.Forms.Button()
        Me.btn_FechaDesde = New System.Windows.Forms.Button()
        Me.btn_Reimprimir = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.chk_Todos = New System.Windows.Forms.CheckBox()
        Me.lsv_Atascos = New System.Windows.Forms.ListView()
        Me.cmb_Usuarios = New System.Windows.Forms.ComboBox()
        Me.btn_Mostrar = New System.Windows.Forms.Button()
        Me.lbl_TotalD = New System.Windows.Forms.Label()
        Me.lbl_Desde = New System.Windows.Forms.Label()
        Me.chk_Cancelados = New System.Windows.Forms.CheckBox()
        Me.lbl_Hasta = New System.Windows.Forms.Label()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.tab_Depositos.SuspendLayout()
        Me.tab_ConsultaAtascos.SuspendLayout()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab_Depositos
        '
        Me.tab_Depositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_Depositos.Controls.Add(Me.tab_ConsultaAtascos)
        Me.tab_Depositos.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_Depositos.Location = New System.Drawing.Point(2, 5)
        Me.tab_Depositos.Name = "tab_Depositos"
        Me.tab_Depositos.SelectedIndex = 0
        Me.tab_Depositos.Size = New System.Drawing.Size(796, 457)
        Me.tab_Depositos.TabIndex = 2
        '
        'tab_ConsultaAtascos
        '
        Me.tab_ConsultaAtascos.Controls.Add(Me.pnl_General)
        Me.tab_ConsultaAtascos.Location = New System.Drawing.Point(4, 38)
        Me.tab_ConsultaAtascos.Name = "tab_ConsultaAtascos"
        Me.tab_ConsultaAtascos.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ConsultaAtascos.Size = New System.Drawing.Size(788, 415)
        Me.tab_ConsultaAtascos.TabIndex = 0
        Me.tab_ConsultaAtascos.Text = "Consulta Atascos"
        Me.tab_ConsultaAtascos.UseVisualStyleBackColor = True
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.lbl_Usuario)
        Me.pnl_General.Controls.Add(Me.btn_FechaHasta)
        Me.pnl_General.Controls.Add(Me.btn_FechaDesde)
        Me.pnl_General.Controls.Add(Me.btn_Reimprimir)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.chk_Todos)
        Me.pnl_General.Controls.Add(Me.lsv_Atascos)
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
        Me.pnl_General.Size = New System.Drawing.Size(782, 409)
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
        Me.btn_Reimprimir.Location = New System.Drawing.Point(458, 325)
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
        Me.btn_Cerrar.Location = New System.Drawing.Point(619, 325)
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
        'lsv_Atascos
        '
        Me.lsv_Atascos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Atascos.AutoArrange = False
        Me.lsv_Atascos.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_Depositos
        Me.lsv_Atascos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Atascos.FullRowSelect = True
        Me.lsv_Atascos.HideSelection = False
        Me.lsv_Atascos.Location = New System.Drawing.Point(-3, 98)
        Me.lsv_Atascos.MultiSelect = False
        Me.lsv_Atascos.Name = "lsv_Atascos"
        Me.lsv_Atascos.Size = New System.Drawing.Size(785, 224)
        Me.lsv_Atascos.TabIndex = 7
        Me.lsv_Atascos.UseCompatibleStateImageBehavior = False
        Me.lsv_Atascos.View = System.Windows.Forms.View.Details
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
        'lbl_TotalD
        '
        Me.lbl_TotalD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalD.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TotalD.Location = New System.Drawing.Point(185, 325)
        Me.lbl_TotalD.Name = "lbl_TotalD"
        Me.lbl_TotalD.Size = New System.Drawing.Size(267, 75)
        Me.lbl_TotalD.TabIndex = 10
        Me.lbl_TotalD.Text = "$0.00"
        Me.lbl_TotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.chk_Cancelados.Visible = False
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
        'iml_Sincronia
        '
        Me.iml_Sincronia.ImageStream = CType(resources.GetObject("iml_Sincronia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Sincronia.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Sincronia.Images.SetKeyName(0, "Correcto.png")
        Me.iml_Sincronia.Images.SetKeyName(1, "Pendiente.png")
        '
        'frm_ConsultaAtascos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.tab_Depositos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ConsultaAtascos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_ConsultaAtascos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tab_Depositos.ResumeLayout(False)
        Me.tab_ConsultaAtascos.ResumeLayout(False)
        Me.pnl_General.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tab_Depositos As TabControl
    Friend WithEvents tab_ConsultaAtascos As TabPage
    Friend WithEvents pnl_General As Panel
    Friend WithEvents lbl_Usuario As Label
    Friend WithEvents btn_FechaHasta As Button
    Friend WithEvents btn_FechaDesde As Button
    Friend WithEvents btn_Reimprimir As Button
    Friend WithEvents btn_Cerrar As Button
    Friend WithEvents chk_Todos As CheckBox
    Friend WithEvents lsv_Atascos As ListView
    Friend WithEvents cmb_Usuarios As ComboBox
    Friend WithEvents btn_Mostrar As Button
    Friend WithEvents lbl_TotalD As Label
    Friend WithEvents lbl_Desde As Label
    Friend WithEvents chk_Cancelados As CheckBox
    Friend WithEvents lbl_Hasta As Label
    Friend WithEvents iml_Sincronia As ImageList
End Class
