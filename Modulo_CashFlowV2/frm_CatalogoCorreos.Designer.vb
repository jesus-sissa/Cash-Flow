<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CatalogoCorreos
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
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.tab_Correos = New System.Windows.Forms.TabControl()
        Me.tbp_ListadoUser = New System.Windows.Forms.TabPage()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Editar = New System.Windows.Forms.Button()
        Me.btn_CambiarStatus = New System.Windows.Forms.Button()
        Me.lsv_Correos = New System.Windows.Forms.ListView()
        Me.tbp_Nuevo = New System.Windows.Forms.TabPage()
        Me.tbx_Descripcion = New System.Windows.Forms.TextBox()
        Me.lbl_Descripcion = New System.Windows.Forms.Label()
        Me.lbl_Advertencia = New System.Windows.Forms.Label()
        Me.tbx_Correo = New System.Windows.Forms.TextBox()
        Me.lbl_CorreoDestinatario = New System.Windows.Forms.Label()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_CerrarNewuser = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.tab_Correos.SuspendLayout()
        Me.tbp_ListadoUser.SuspendLayout()
        Me.tbp_Nuevo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.tab_Correos)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'tab_Correos
        '
        Me.tab_Correos.Controls.Add(Me.tbp_ListadoUser)
        Me.tab_Correos.Controls.Add(Me.tbp_Nuevo)
        Me.tab_Correos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_Correos.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_Correos.Location = New System.Drawing.Point(0, 0)
        Me.tab_Correos.Name = "tab_Correos"
        Me.tab_Correos.SelectedIndex = 0
        Me.tab_Correos.Size = New System.Drawing.Size(800, 480)
        Me.tab_Correos.TabIndex = 0
        '
        'tbp_ListadoUser
        '
        Me.tbp_ListadoUser.Controls.Add(Me.btn_Cerrar)
        Me.tbp_ListadoUser.Controls.Add(Me.btn_Editar)
        Me.tbp_ListadoUser.Controls.Add(Me.btn_CambiarStatus)
        Me.tbp_ListadoUser.Controls.Add(Me.lsv_Correos)
        Me.tbp_ListadoUser.Location = New System.Drawing.Point(4, 36)
        Me.tbp_ListadoUser.Name = "tbp_ListadoUser"
        Me.tbp_ListadoUser.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp_ListadoUser.Size = New System.Drawing.Size(792, 440)
        Me.tbp_ListadoUser.TabIndex = 0
        Me.tbp_ListadoUser.Text = "Listado"
        Me.tbp_ListadoUser.UseVisualStyleBackColor = True
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
        Me.btn_Editar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Correos
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
        'lsv_Correos
        '
        Me.lsv_Correos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Correos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Correos.FullRowSelect = True
        Me.lsv_Correos.HideSelection = False
        Me.lsv_Correos.Location = New System.Drawing.Point(6, 6)
        Me.lsv_Correos.MultiSelect = False
        Me.lsv_Correos.Name = "lsv_Correos"
        Me.lsv_Correos.Size = New System.Drawing.Size(783, 347)
        Me.lsv_Correos.TabIndex = 0
        Me.lsv_Correos.UseCompatibleStateImageBehavior = False
        Me.lsv_Correos.View = System.Windows.Forms.View.Details
        '
        'tbp_Nuevo
        '
        Me.tbp_Nuevo.Controls.Add(Me.tbx_Descripcion)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_Descripcion)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_Advertencia)
        Me.tbp_Nuevo.Controls.Add(Me.tbx_Correo)
        Me.tbp_Nuevo.Controls.Add(Me.lbl_CorreoDestinatario)
        Me.tbp_Nuevo.Controls.Add(Me.btn_Guardar)
        Me.tbp_Nuevo.Controls.Add(Me.btn_CerrarNewuser)
        Me.tbp_Nuevo.Location = New System.Drawing.Point(4, 36)
        Me.tbp_Nuevo.Name = "tbp_Nuevo"
        Me.tbp_Nuevo.Size = New System.Drawing.Size(792, 440)
        Me.tbp_Nuevo.TabIndex = 2
        Me.tbp_Nuevo.Text = "Nuevo"
        '
        'tbx_Descripcion
        '
        Me.tbx_Descripcion.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Descripcion.Location = New System.Drawing.Point(190, 86)
        Me.tbx_Descripcion.MaxLength = 30
        Me.tbx_Descripcion.Name = "tbx_Descripcion"
        Me.tbx_Descripcion.Size = New System.Drawing.Size(198, 39)
        Me.tbx_Descripcion.TabIndex = 31
        '
        'lbl_Descripcion
        '
        Me.lbl_Descripcion.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Descripcion.Location = New System.Drawing.Point(14, 94)
        Me.lbl_Descripcion.Name = "lbl_Descripcion"
        Me.lbl_Descripcion.Size = New System.Drawing.Size(158, 31)
        Me.lbl_Descripcion.TabIndex = 30
        Me.lbl_Descripcion.Text = "Descripción:"
        Me.lbl_Descripcion.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'tbx_Correo
        '
        Me.tbx_Correo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Correo.Location = New System.Drawing.Point(190, 31)
        Me.tbx_Correo.MaxLength = 60
        Me.tbx_Correo.Name = "tbx_Correo"
        Me.tbx_Correo.Size = New System.Drawing.Size(556, 39)
        Me.tbx_Correo.TabIndex = 5
        '
        'lbl_CorreoDestinatario
        '
        Me.lbl_CorreoDestinatario.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CorreoDestinatario.Location = New System.Drawing.Point(65, 39)
        Me.lbl_CorreoDestinatario.Name = "lbl_CorreoDestinatario"
        Me.lbl_CorreoDestinatario.Size = New System.Drawing.Size(107, 31)
        Me.lbl_CorreoDestinatario.TabIndex = 4
        Me.lbl_CorreoDestinatario.Text = "Correo:"
        Me.lbl_CorreoDestinatario.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'frm_CatalogoCorreos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_CatalogoCorreos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_CatalogoCorreos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.tab_Correos.ResumeLayout(False)
        Me.tbp_ListadoUser.ResumeLayout(False)
        Me.tbp_Nuevo.ResumeLayout(False)
        Me.tbp_Nuevo.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents tab_Correos As System.Windows.Forms.TabControl
    Friend WithEvents tbp_ListadoUser As System.Windows.Forms.TabPage
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Editar As System.Windows.Forms.Button
    Friend WithEvents btn_CambiarStatus As System.Windows.Forms.Button
    Friend WithEvents lsv_Correos As System.Windows.Forms.ListView
    Friend WithEvents tbp_Nuevo As System.Windows.Forms.TabPage
    Friend WithEvents lbl_Advertencia As System.Windows.Forms.Label
    Friend WithEvents lbl_CorreoDestinatario As System.Windows.Forms.Label
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents btn_CerrarNewuser As System.Windows.Forms.Button
    Friend WithEvents tbx_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Descripcion As System.Windows.Forms.Label
    Friend WithEvents tbx_Correo As System.Windows.Forms.TextBox
End Class
