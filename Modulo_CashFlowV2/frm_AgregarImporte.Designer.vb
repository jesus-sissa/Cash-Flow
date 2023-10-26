<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AgregarImporte
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
        Me.pnl_Usuarios = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.tbx_Folio = New System.Windows.Forms.TextBox()
        Me.tbx_Importe = New System.Windows.Forms.TextBox()
        Me.lbl_Importe = New System.Windows.Forms.Label()
        Me.lbl_Folio = New System.Windows.Forms.Label()
        Me.pnl_Usuarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Usuarios
        '
        Me.pnl_Usuarios.Controls.Add(Me.Button1)
        Me.pnl_Usuarios.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Usuarios.Controls.Add(Me.tbx_Folio)
        Me.pnl_Usuarios.Controls.Add(Me.tbx_Importe)
        Me.pnl_Usuarios.Controls.Add(Me.lbl_Importe)
        Me.pnl_Usuarios.Controls.Add(Me.lbl_Folio)
        Me.pnl_Usuarios.Location = New System.Drawing.Point(86, 47)
        Me.pnl_Usuarios.Name = "pnl_Usuarios"
        Me.pnl_Usuarios.Size = New System.Drawing.Size(437, 237)
        Me.pnl_Usuarios.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Negar
        Me.Button1.Location = New System.Drawing.Point(260, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 66)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "&Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Aceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Aceptar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Aceptar
        Me.btn_Aceptar.Location = New System.Drawing.Point(29, 113)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(149, 66)
        Me.btn_Aceptar.TabIndex = 16
        Me.btn_Aceptar.Text = "&Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'tbx_Folio
        '
        Me.tbx_Folio.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Folio.Location = New System.Drawing.Point(172, 6)
        Me.tbx_Folio.MaxLength = 13
        Me.tbx_Folio.Name = "tbx_Folio"
        Me.tbx_Folio.Size = New System.Drawing.Size(248, 39)
        Me.tbx_Folio.TabIndex = 14
        '
        'tbx_Importe
        '
        Me.tbx_Importe.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Importe.Location = New System.Drawing.Point(172, 51)
        Me.tbx_Importe.MaxLength = 6
        Me.tbx_Importe.Name = "tbx_Importe"
        Me.tbx_Importe.Size = New System.Drawing.Size(248, 39)
        Me.tbx_Importe.TabIndex = 15
        '
        'lbl_Importe
        '
        Me.lbl_Importe.AutoSize = True
        Me.lbl_Importe.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Importe.Location = New System.Drawing.Point(51, 54)
        Me.lbl_Importe.Name = "lbl_Importe"
        Me.lbl_Importe.Size = New System.Drawing.Size(115, 32)
        Me.lbl_Importe.TabIndex = 7
        Me.lbl_Importe.Text = "Importe:"
        '
        'lbl_Folio
        '
        Me.lbl_Folio.AutoSize = True
        Me.lbl_Folio.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Folio.Location = New System.Drawing.Point(84, 9)
        Me.lbl_Folio.Name = "lbl_Folio"
        Me.lbl_Folio.Size = New System.Drawing.Size(82, 32)
        Me.lbl_Folio.TabIndex = 6
        Me.lbl_Folio.Text = "Folio:"
        '
        'frm_AgregarImporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(608, 331)
        Me.Controls.Add(Me.pnl_Usuarios)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_AgregarImporte"
        Me.Text = "frm_AgregarImporte"
        Me.pnl_Usuarios.ResumeLayout(False)
        Me.pnl_Usuarios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Usuarios As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents tbx_Folio As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Importe As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Importe As System.Windows.Forms.Label
    Friend WithEvents lbl_Folio As System.Windows.Forms.Label
End Class
