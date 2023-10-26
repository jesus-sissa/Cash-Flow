<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_FirmaElectronica
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
        Me.tbx_Contrasena = New System.Windows.Forms.TextBox()
        Me.tbx_Clave = New System.Windows.Forms.TextBox()
        Me.lbl_Contrasena = New System.Windows.Forms.Label()
        Me.lbl_Clave = New System.Windows.Forms.Label()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.lbl_AlertaApagar = New System.Windows.Forms.Label()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_Apagar = New System.Windows.Forms.Button()
        Me.btn_Reiniciar = New System.Windows.Forms.Button()
        Me.pnl_Firma = New System.Windows.Forms.Panel()
        Me.pnl_General.SuspendLayout()
        Me.pnl_Botones.SuspendLayout()
        Me.pnl_Firma.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbx_Contrasena
        '
        Me.tbx_Contrasena.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_Contrasena.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Contrasena.Location = New System.Drawing.Point(221, 73)
        Me.tbx_Contrasena.MaxLength = 8
        Me.tbx_Contrasena.Name = "tbx_Contrasena"
        Me.tbx_Contrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Contrasena.Size = New System.Drawing.Size(170, 63)
        Me.tbx_Contrasena.TabIndex = 5
        '
        'tbx_Clave
        '
        Me.tbx_Clave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_Clave.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Clave.Location = New System.Drawing.Point(221, 3)
        Me.tbx_Clave.MaxLength = 6
        Me.tbx_Clave.Name = "tbx_Clave"
        Me.tbx_Clave.Size = New System.Drawing.Size(170, 63)
        Me.tbx_Clave.TabIndex = 3
        '
        'lbl_Contrasena
        '
        Me.lbl_Contrasena.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Contrasena.AutoSize = True
        Me.lbl_Contrasena.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Contrasena.Location = New System.Drawing.Point(7, 86)
        Me.lbl_Contrasena.Name = "lbl_Contrasena"
        Me.lbl_Contrasena.Size = New System.Drawing.Size(208, 42)
        Me.lbl_Contrasena.TabIndex = 4
        Me.lbl_Contrasena.Text = "Contraseña"
        Me.lbl_Contrasena.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Clave
        '
        Me.lbl_Clave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Clave.AutoSize = True
        Me.lbl_Clave.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clave.Location = New System.Drawing.Point(106, 17)
        Me.lbl_Clave.Name = "lbl_Clave"
        Me.lbl_Clave.Size = New System.Drawing.Size(109, 42)
        Me.lbl_Clave.TabIndex = 2
        Me.lbl_Clave.Text = "Clave"
        Me.lbl_Clave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.lbl_AlertaApagar)
        Me.pnl_General.Controls.Add(Me.btn_Cancelar)
        Me.pnl_General.Controls.Add(Me.pnl_Botones)
        Me.pnl_General.Controls.Add(Me.pnl_Firma)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 10
        '
        'lbl_AlertaApagar
        '
        Me.lbl_AlertaApagar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_AlertaApagar.AutoSize = True
        Me.lbl_AlertaApagar.BackColor = System.Drawing.Color.Red
        Me.lbl_AlertaApagar.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_AlertaApagar.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_AlertaApagar.Location = New System.Drawing.Point(199, 7)
        Me.lbl_AlertaApagar.Name = "lbl_AlertaApagar"
        Me.lbl_AlertaApagar.Size = New System.Drawing.Size(440, 42)
        Me.lbl_AlertaApagar.TabIndex = 11
        Me.lbl_AlertaApagar.Text = "Firma para Apagar Cajero"
        Me.lbl_AlertaApagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_AlertaApagar.Visible = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancelar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Cancelar
        Me.btn_Cancelar.Location = New System.Drawing.Point(0, 0)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cancelar.TabIndex = 0
        Me.btn_Cancelar.Text = "&Cancelar"
        Me.btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'pnl_Botones
        '
        Me.pnl_Botones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnl_Botones.Controls.Add(Me.btn_Apagar)
        Me.pnl_Botones.Controls.Add(Me.btn_Reiniciar)
        Me.pnl_Botones.Location = New System.Drawing.Point(206, 196)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(373, 93)
        Me.pnl_Botones.TabIndex = 9
        Me.pnl_Botones.Visible = False
        '
        'btn_Apagar
        '
        Me.btn_Apagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Apagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Apagar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Apagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Apagar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Apagar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Salir
        Me.btn_Apagar.Location = New System.Drawing.Point(16, 9)
        Me.btn_Apagar.Name = "btn_Apagar"
        Me.btn_Apagar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Apagar.TabIndex = 6
        Me.btn_Apagar.Text = "Apagar"
        Me.btn_Apagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Apagar.UseVisualStyleBackColor = False
        '
        'btn_Reiniciar
        '
        Me.btn_Reiniciar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Reiniciar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Reiniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Reiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Reiniciar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reiniciar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.ReiniciarPC
        Me.btn_Reiniciar.Location = New System.Drawing.Point(206, 9)
        Me.btn_Reiniciar.Name = "btn_Reiniciar"
        Me.btn_Reiniciar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Reiniciar.TabIndex = 7
        Me.btn_Reiniciar.Text = "Reiniciar"
        Me.btn_Reiniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Reiniciar.UseVisualStyleBackColor = False
        '
        'pnl_Firma
        '
        Me.pnl_Firma.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnl_Firma.Controls.Add(Me.tbx_Clave)
        Me.pnl_Firma.Controls.Add(Me.lbl_Contrasena)
        Me.pnl_Firma.Controls.Add(Me.lbl_Clave)
        Me.pnl_Firma.Controls.Add(Me.tbx_Contrasena)
        Me.pnl_Firma.Location = New System.Drawing.Point(162, 52)
        Me.pnl_Firma.Name = "pnl_Firma"
        Me.pnl_Firma.Size = New System.Drawing.Size(394, 141)
        Me.pnl_Firma.TabIndex = 8
        Me.pnl_Firma.Visible = False
        '
        'frm_FirmaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_FirmaElectronica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firma Electrónica"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        Me.pnl_Botones.ResumeLayout(False)
        Me.pnl_Firma.ResumeLayout(False)
        Me.pnl_Firma.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents tbx_Contrasena As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Clave As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Contrasena As System.Windows.Forms.Label
    Friend WithEvents lbl_Clave As System.Windows.Forms.Label
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Apagar As System.Windows.Forms.Button
    Friend WithEvents btn_Reiniciar As System.Windows.Forms.Button
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents pnl_Firma As System.Windows.Forms.Panel
    Friend WithEvents lbl_AlertaApagar As System.Windows.Forms.Label
End Class
