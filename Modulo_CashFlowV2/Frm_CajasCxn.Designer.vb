<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CajasCxn
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
        Me.Lbl_Servidor = New System.Windows.Forms.Label()
        Me.Tbx_servidor = New System.Windows.Forms.TextBox()
        Me.Tbx_bd = New System.Windows.Forms.TextBox()
        Me.Lbl_Base = New System.Windows.Forms.Label()
        Me.Tbx_usuario = New System.Windows.Forms.TextBox()
        Me.Lbl_Usuario = New System.Windows.Forms.Label()
        Me.Lbl_contrasena = New System.Windows.Forms.Label()
        Me.Btn_Guardar = New System.Windows.Forms.Button()
        Me.Btn_Actualizar = New System.Windows.Forms.Button()
        Me.Btn_Cerrar = New System.Windows.Forms.Button()
        Me.Btn_Status = New System.Windows.Forms.Button()
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.Tbx_contra = New System.Windows.Forms.TextBox()
        Me.Lbl_Statuss = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lbl_Servidor
        '
        Me.Lbl_Servidor.AutoSize = True
        Me.Lbl_Servidor.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Lbl_Servidor.Location = New System.Drawing.Point(24, 30)
        Me.Lbl_Servidor.Name = "Lbl_Servidor"
        Me.Lbl_Servidor.Size = New System.Drawing.Size(203, 24)
        Me.Lbl_Servidor.TabIndex = 0
        Me.Lbl_Servidor.Text = "Nombre del servidor:"
        '
        'Tbx_servidor
        '
        Me.Tbx_servidor.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Tbx_servidor.Location = New System.Drawing.Point(233, 27)
        Me.Tbx_servidor.MaxLength = 30
        Me.Tbx_servidor.Multiline = True
        Me.Tbx_servidor.Name = "Tbx_servidor"
        Me.Tbx_servidor.Size = New System.Drawing.Size(286, 32)
        Me.Tbx_servidor.TabIndex = 1
        '
        'Tbx_bd
        '
        Me.Tbx_bd.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Tbx_bd.Location = New System.Drawing.Point(233, 62)
        Me.Tbx_bd.MaxLength = 30
        Me.Tbx_bd.Multiline = True
        Me.Tbx_bd.Name = "Tbx_bd"
        Me.Tbx_bd.Size = New System.Drawing.Size(286, 32)
        Me.Tbx_bd.TabIndex = 3
        '
        'Lbl_Base
        '
        Me.Lbl_Base.AutoSize = True
        Me.Lbl_Base.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Lbl_Base.Location = New System.Drawing.Point(75, 65)
        Me.Lbl_Base.Name = "Lbl_Base"
        Me.Lbl_Base.Size = New System.Drawing.Size(152, 24)
        Me.Lbl_Base.TabIndex = 2
        Me.Lbl_Base.Text = "Base de datos:"
        '
        'Tbx_usuario
        '
        Me.Tbx_usuario.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Tbx_usuario.Location = New System.Drawing.Point(233, 97)
        Me.Tbx_usuario.MaxLength = 30
        Me.Tbx_usuario.Multiline = True
        Me.Tbx_usuario.Name = "Tbx_usuario"
        Me.Tbx_usuario.Size = New System.Drawing.Size(286, 32)
        Me.Tbx_usuario.TabIndex = 5
        '
        'Lbl_Usuario
        '
        Me.Lbl_Usuario.AutoSize = True
        Me.Lbl_Usuario.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Lbl_Usuario.Location = New System.Drawing.Point(139, 100)
        Me.Lbl_Usuario.Name = "Lbl_Usuario"
        Me.Lbl_Usuario.Size = New System.Drawing.Size(88, 24)
        Me.Lbl_Usuario.TabIndex = 4
        Me.Lbl_Usuario.Text = "Usuario:"
        '
        'Lbl_contrasena
        '
        Me.Lbl_contrasena.AutoSize = True
        Me.Lbl_contrasena.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Lbl_contrasena.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Lbl_contrasena.Location = New System.Drawing.Point(102, 132)
        Me.Lbl_contrasena.Name = "Lbl_contrasena"
        Me.Lbl_contrasena.Size = New System.Drawing.Size(125, 24)
        Me.Lbl_contrasena.TabIndex = 6
        Me.Lbl_contrasena.Text = "Contraseña:"
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Btn_Guardar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.Btn_Guardar.Location = New System.Drawing.Point(15, 211)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(164, 75)
        Me.Btn_Guardar.TabIndex = 29
        Me.Btn_Guardar.Text = "&Guardar"
        Me.Btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Guardar.UseVisualStyleBackColor = False
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Actualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Btn_Actualizar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.Btn_Actualizar.Location = New System.Drawing.Point(185, 211)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Size = New System.Drawing.Size(164, 75)
        Me.Btn_Actualizar.TabIndex = 31
        Me.Btn_Actualizar.Text = "&Actualizar"
        Me.Btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Actualizar.UseVisualStyleBackColor = False
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.Btn_Cerrar.Location = New System.Drawing.Point(525, 211)
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.Btn_Cerrar.TabIndex = 32
        Me.Btn_Cerrar.Text = "&Cerrar"
        Me.Btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Cerrar.UseVisualStyleBackColor = False
        '
        'Btn_Status
        '
        Me.Btn_Status.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Status.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Btn_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Btn_Status.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.BajaReing
        Me.Btn_Status.Location = New System.Drawing.Point(355, 211)
        Me.Btn_Status.Name = "Btn_Status"
        Me.Btn_Status.Size = New System.Drawing.Size(164, 75)
        Me.Btn_Status.TabIndex = 36
        Me.Btn_Status.Text = "&Baja/Alta"
        Me.Btn_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Status.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Status.UseVisualStyleBackColor = False
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.Location = New System.Drawing.Point(229, 168)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(69, 19)
        Me.Lbl_Status.TabIndex = 37
        Me.Lbl_Status.Text = "ACTIVO"
        Me.Lbl_Status.Visible = False
        '
        'Tbx_contra
        '
        Me.Tbx_contra.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbx_contra.Location = New System.Drawing.Point(233, 132)
        Me.Tbx_contra.MaxLength = 30
        Me.Tbx_contra.Multiline = True
        Me.Tbx_contra.Name = "Tbx_contra"
        Me.Tbx_contra.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Tbx_contra.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tbx_contra.Size = New System.Drawing.Size(286, 31)
        Me.Tbx_contra.TabIndex = 7
        '
        'Lbl_Statuss
        '
        Me.Lbl_Statuss.AutoSize = True
        Me.Lbl_Statuss.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.Lbl_Statuss.Location = New System.Drawing.Point(147, 163)
        Me.Lbl_Statuss.Name = "Lbl_Statuss"
        Me.Lbl_Statuss.Size = New System.Drawing.Size(76, 24)
        Me.Lbl_Statuss.TabIndex = 39
        Me.Lbl_Statuss.Text = "Status:"
        Me.Lbl_Statuss.Visible = False
        '
        'Frm_CajasCxn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(702, 298)
        Me.Controls.Add(Me.Lbl_Statuss)
        Me.Controls.Add(Me.Tbx_contra)
        Me.Controls.Add(Me.Lbl_Status)
        Me.Controls.Add(Me.Btn_Status)
        Me.Controls.Add(Me.Btn_Cerrar)
        Me.Controls.Add(Me.Btn_Actualizar)
        Me.Controls.Add(Me.Btn_Guardar)
        Me.Controls.Add(Me.Lbl_contrasena)
        Me.Controls.Add(Me.Tbx_usuario)
        Me.Controls.Add(Me.Lbl_Usuario)
        Me.Controls.Add(Me.Tbx_bd)
        Me.Controls.Add(Me.Lbl_Base)
        Me.Controls.Add(Me.Tbx_servidor)
        Me.Controls.Add(Me.Lbl_Servidor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frm_CajasCxn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_CajasCxn"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Servidor As Label
    Friend WithEvents Tbx_servidor As TextBox
    Friend WithEvents Tbx_bd As TextBox
    Friend WithEvents Lbl_Base As Label
    Friend WithEvents Tbx_usuario As TextBox
    Friend WithEvents Lbl_Usuario As Label
    Friend WithEvents Lbl_contrasena As Label
    Friend WithEvents Btn_Guardar As Button
    Friend WithEvents Btn_Actualizar As Button
    Friend WithEvents Btn_Cerrar As Button
    Friend WithEvents Btn_Status As Button
    Friend WithEvents Lbl_Status As Label
    Friend WithEvents Tbx_contra As TextBox
    Friend WithEvents Lbl_Statuss As Label
End Class
