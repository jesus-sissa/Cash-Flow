<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AccesoRecoleccion
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
        Me.pnl_Firma = New System.Windows.Forms.Panel()
        Me.tbx_Clave = New System.Windows.Forms.TextBox()
        Me.lbl_Clave = New System.Windows.Forms.Label()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.lbl_fecha = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_Firma.SuspendLayout()
        Me.pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Firma
        '
        Me.pnl_Firma.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnl_Firma.Controls.Add(Me.tbx_Clave)
        Me.pnl_Firma.Controls.Add(Me.lbl_Clave)
        Me.pnl_Firma.Location = New System.Drawing.Point(33, 62)
        Me.pnl_Firma.Name = "pnl_Firma"
        Me.pnl_Firma.Size = New System.Drawing.Size(394, 80)
        Me.pnl_Firma.TabIndex = 9
        '
        'tbx_Clave
        '
        Me.tbx_Clave.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Clave.Location = New System.Drawing.Point(142, 22)
        Me.tbx_Clave.MaxLength = 20
        Me.tbx_Clave.Name = "tbx_Clave"
        Me.tbx_Clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Clave.Size = New System.Drawing.Size(249, 39)
        Me.tbx_Clave.TabIndex = 8
        '
        'lbl_Clave
        '
        Me.lbl_Clave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Clave.AutoSize = True
        Me.lbl_Clave.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clave.Location = New System.Drawing.Point(27, 17)
        Me.lbl_Clave.Name = "lbl_Clave"
        Me.lbl_Clave.Size = New System.Drawing.Size(109, 42)
        Me.lbl_Clave.TabIndex = 2
        Me.lbl_Clave.Text = "Clave"
        Me.lbl_Clave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnl_Botones
        '
        Me.pnl_Botones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Botones.Location = New System.Drawing.Point(33, 143)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(394, 93)
        Me.pnl_Botones.TabIndex = 10
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Aceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Aceptar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Aceptar
        Me.btn_Aceptar.Location = New System.Drawing.Point(34, 9)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(170, 75)
        Me.btn_Aceptar.TabIndex = 17
        Me.btn_Aceptar.Text = "&Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancelar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Cancelar
        Me.btn_Cancelar.Location = New System.Drawing.Point(221, 9)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(170, 75)
        Me.btn_Cancelar.TabIndex = 7
        Me.btn_Cancelar.Text = "&Cancelar"
        Me.btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'lbl_fecha
        '
        Me.lbl_fecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbl_fecha.Location = New System.Drawing.Point(69, 8)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(0, 44)
        Me.lbl_fecha.TabIndex = 11
        Me.lbl_fecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frm_AccesoRecoleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(461, 244)
        Me.Controls.Add(Me.lbl_fecha)
        Me.Controls.Add(Me.pnl_Botones)
        Me.Controls.Add(Me.pnl_Firma)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_AccesoRecoleccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_AccesoRecoleccion"
        Me.pnl_Firma.ResumeLayout(False)
        Me.pnl_Firma.PerformLayout()
        Me.pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_Firma As System.Windows.Forms.Panel
    Friend WithEvents lbl_Clave As System.Windows.Forms.Label
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents lbl_fecha As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tbx_Clave As System.Windows.Forms.TextBox
End Class
