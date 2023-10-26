<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaRecoleccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ConsultaRecoleccion))
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.chk_Todos = New System.Windows.Forms.CheckBox()
        Me.lbl_Usuario = New System.Windows.Forms.Label()
        Me.btn_FechaHasta = New System.Windows.Forms.Button()
        Me.btn_FechaDesde = New System.Windows.Forms.Button()
        Me.btn_Reimprimir = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Detalle = New System.Windows.Forms.Button()
        Me.lsv_Recoleccion = New System.Windows.Forms.ListView()
        Me.cmb_Usuarios = New System.Windows.Forms.ComboBox()
        Me.btn_Mostrar = New System.Windows.Forms.Button()
        Me.lbl_TotalD = New System.Windows.Forms.Label()
        Me.lbl_Desde = New System.Windows.Forms.Label()
        Me.lbl_Hasta = New System.Windows.Forms.Label()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_General.Controls.Add(Me.chk_Todos)
        Me.pnl_General.Controls.Add(Me.lbl_Usuario)
        Me.pnl_General.Controls.Add(Me.btn_FechaHasta)
        Me.pnl_General.Controls.Add(Me.btn_FechaDesde)
        Me.pnl_General.Controls.Add(Me.btn_Reimprimir)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.btn_Detalle)
        Me.pnl_General.Controls.Add(Me.lsv_Recoleccion)
        Me.pnl_General.Controls.Add(Me.cmb_Usuarios)
        Me.pnl_General.Controls.Add(Me.btn_Mostrar)
        Me.pnl_General.Controls.Add(Me.lbl_TotalD)
        Me.pnl_General.Controls.Add(Me.lbl_Desde)
        Me.pnl_General.Controls.Add(Me.lbl_Hasta)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Enabled = False
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 1
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
        Me.chk_Todos.TabIndex = 19
        Me.chk_Todos.Text = "Todos"
        Me.chk_Todos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Todos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_Todos.UseVisualStyleBackColor = True
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Usuario.Location = New System.Drawing.Point(11, 52)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(109, 32)
        Me.lbl_Usuario.TabIndex = 18
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
        Me.btn_FechaHasta.TabIndex = 17
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
        Me.btn_FechaDesde.Location = New System.Drawing.Point(120, 5)
        Me.btn_FechaDesde.Name = "btn_FechaDesde"
        Me.btn_FechaDesde.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaDesde.TabIndex = 16
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
        Me.btn_Reimprimir.Location = New System.Drawing.Point(454, 402)
        Me.btn_Reimprimir.Name = "btn_Reimprimir"
        Me.btn_Reimprimir.Size = New System.Drawing.Size(164, 75)
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
        Me.btn_Cerrar.Location = New System.Drawing.Point(624, 402)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 11
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Detalle
        '
        Me.btn_Detalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Detalle.Enabled = False
        Me.btn_Detalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Detalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Detalle.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Detalle
        Me.btn_Detalle.Location = New System.Drawing.Point(11, 402)
        Me.btn_Detalle.Name = "btn_Detalle"
        Me.btn_Detalle.Size = New System.Drawing.Size(164, 75)
        Me.btn_Detalle.TabIndex = 8
        Me.btn_Detalle.Text = "&Detalle"
        Me.btn_Detalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Detalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Detalle.UseVisualStyleBackColor = True
        '
        'lsv_Recoleccion
        '
        Me.lsv_Recoleccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Recoleccion.AutoArrange = False
        Me.lsv_Recoleccion.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_Retiros
        Me.lsv_Recoleccion.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Recoleccion.FullRowSelect = True
        Me.lsv_Recoleccion.HideSelection = False
        Me.lsv_Recoleccion.Location = New System.Drawing.Point(11, 101)
        Me.lsv_Recoleccion.MultiSelect = False
        Me.lsv_Recoleccion.Name = "lsv_Recoleccion"
        Me.lsv_Recoleccion.Size = New System.Drawing.Size(778, 295)
        Me.lsv_Recoleccion.TabIndex = 7
        Me.lsv_Recoleccion.UseCompatibleStateImageBehavior = False
        Me.lsv_Recoleccion.View = System.Windows.Forms.View.Details
        '
        'cmb_Usuarios
        '
        Me.cmb_Usuarios.BackColor = System.Drawing.SystemColors.Window
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
        Me.btn_Mostrar.Location = New System.Drawing.Point(633, 20)
        Me.btn_Mostrar.Name = "btn_Mostrar"
        Me.btn_Mostrar.Size = New System.Drawing.Size(155, 75)
        Me.btn_Mostrar.TabIndex = 6
        Me.btn_Mostrar.Text = "&Mostrar"
        Me.btn_Mostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Mostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Mostrar.UseVisualStyleBackColor = True
        '
        'lbl_TotalD
        '
        Me.lbl_TotalD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalD.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TotalD.Location = New System.Drawing.Point(181, 402)
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
        'frm_ConsultaRecoleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaRecoleccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Recoleccion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Detalle As System.Windows.Forms.Button
    Friend WithEvents lsv_Recoleccion As System.Windows.Forms.ListView
    Friend WithEvents cmb_Usuarios As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Mostrar As System.Windows.Forms.Button
    Friend WithEvents lbl_TotalD As System.Windows.Forms.Label
    Friend WithEvents lbl_Desde As System.Windows.Forms.Label
    Friend WithEvents lbl_Hasta As System.Windows.Forms.Label
    Friend WithEvents btn_Reimprimir As System.Windows.Forms.Button
    Friend WithEvents btn_FechaHasta As System.Windows.Forms.Button
    Friend WithEvents btn_FechaDesde As System.Windows.Forms.Button
    Friend WithEvents lbl_Usuario As System.Windows.Forms.Label
    Friend WithEvents chk_Todos As System.Windows.Forms.CheckBox
    Friend WithEvents iml_Sincronia As System.Windows.Forms.ImageList
End Class
