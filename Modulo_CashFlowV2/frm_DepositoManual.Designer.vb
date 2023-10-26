<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DepositoManual
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
        Me.btn_Cajas = New System.Windows.Forms.Button()
        Me.grp_CajasEntradas = New System.Windows.Forms.GroupBox()
        Me.lbl_USDConvertido = New System.Windows.Forms.Label()
        Me.tbx_USDConvertido = New System.Windows.Forms.TextBox()
        Me.rdb_NoEsEfectivo = New System.Windows.Forms.RadioButton()
        Me.rdb_SiEsEfectivo = New System.Windows.Forms.RadioButton()
        Me.lbl_TipoCambio = New System.Windows.Forms.Label()
        Me.Lbl_Efectivo = New System.Windows.Forms.Label()
        Me.tbx_TipoCambio = New System.Windows.Forms.TextBox()
        Me.tbx_USD = New System.Windows.Forms.TextBox()
        Me.tbx_MXP = New System.Windows.Forms.TextBox()
        Me.lbl_USD = New System.Windows.Forms.Label()
        Me.lbl_MXP = New System.Windows.Forms.Label()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.grp_CajasEntradas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.btn_Cajas)
        Me.pnl_General.Controls.Add(Me.grp_CajasEntradas)
        Me.pnl_General.Controls.Add(Me.btn_Guardar)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Margin = New System.Windows.Forms.Padding(4)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(1067, 648)
        Me.pnl_General.TabIndex = 0
        '
        'btn_Cajas
        '
        Me.btn_Cajas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_Cajas.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cajas.Enabled = False
        Me.btn_Cajas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cajas.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cajas.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Cajas.Location = New System.Drawing.Point(230, 15)
        Me.btn_Cajas.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cajas.Name = "btn_Cajas"
        Me.btn_Cajas.Size = New System.Drawing.Size(543, 92)
        Me.btn_Cajas.TabIndex = 0
        Me.btn_Cajas.Text = "Cajas"
        Me.btn_Cajas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cajas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cajas.UseVisualStyleBackColor = False
        '
        'grp_CajasEntradas
        '
        Me.grp_CajasEntradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grp_CajasEntradas.Controls.Add(Me.lbl_USDConvertido)
        Me.grp_CajasEntradas.Controls.Add(Me.tbx_USDConvertido)
        Me.grp_CajasEntradas.Controls.Add(Me.rdb_NoEsEfectivo)
        Me.grp_CajasEntradas.Controls.Add(Me.rdb_SiEsEfectivo)
        Me.grp_CajasEntradas.Controls.Add(Me.lbl_TipoCambio)
        Me.grp_CajasEntradas.Controls.Add(Me.Lbl_Efectivo)
        Me.grp_CajasEntradas.Controls.Add(Me.tbx_TipoCambio)
        Me.grp_CajasEntradas.Controls.Add(Me.tbx_USD)
        Me.grp_CajasEntradas.Controls.Add(Me.tbx_MXP)
        Me.grp_CajasEntradas.Controls.Add(Me.lbl_USD)
        Me.grp_CajasEntradas.Controls.Add(Me.lbl_MXP)
        Me.grp_CajasEntradas.Enabled = False
        Me.grp_CajasEntradas.Location = New System.Drawing.Point(4, 114)
        Me.grp_CajasEntradas.Margin = New System.Windows.Forms.Padding(4)
        Me.grp_CajasEntradas.Name = "grp_CajasEntradas"
        Me.grp_CajasEntradas.Padding = New System.Windows.Forms.Padding(4)
        Me.grp_CajasEntradas.Size = New System.Drawing.Size(1059, 419)
        Me.grp_CajasEntradas.TabIndex = 1
        Me.grp_CajasEntradas.TabStop = False
        '
        'lbl_USDConvertido
        '
        Me.lbl_USDConvertido.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_USDConvertido.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_USDConvertido.Location = New System.Drawing.Point(217, 220)
        Me.lbl_USDConvertido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_USDConvertido.Name = "lbl_USDConvertido"
        Me.lbl_USDConvertido.Size = New System.Drawing.Size(353, 43)
        Me.lbl_USDConvertido.TabIndex = 9
        Me.lbl_USDConvertido.Text = "Importe USD en MXN:"
        '
        'tbx_USDConvertido
        '
        Me.tbx_USDConvertido.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbx_USDConvertido.Enabled = False
        Me.tbx_USDConvertido.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_USDConvertido.Location = New System.Drawing.Point(586, 215)
        Me.tbx_USDConvertido.Margin = New System.Windows.Forms.Padding(4)
        Me.tbx_USDConvertido.MaxLength = 6
        Me.tbx_USDConvertido.Name = "tbx_USDConvertido"
        Me.tbx_USDConvertido.ReadOnly = True
        Me.tbx_USDConvertido.Size = New System.Drawing.Size(185, 42)
        Me.tbx_USDConvertido.TabIndex = 10
        Me.tbx_USDConvertido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rdb_NoEsEfectivo
        '
        Me.rdb_NoEsEfectivo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdb_NoEsEfectivo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_NoEsEfectivo.AutoSize = True
        Me.rdb_NoEsEfectivo.Checked = True
        Me.rdb_NoEsEfectivo.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_NoEsEfectivo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_NoEsEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_NoEsEfectivo.Location = New System.Drawing.Point(587, 17)
        Me.rdb_NoEsEfectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.rdb_NoEsEfectivo.Name = "rdb_NoEsEfectivo"
        Me.rdb_NoEsEfectivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdb_NoEsEfectivo.Size = New System.Drawing.Size(169, 37)
        Me.rdb_NoEsEfectivo.TabIndex = 2
        Me.rdb_NoEsEfectivo.TabStop = True
        Me.rdb_NoEsEfectivo.Text = "Documento"
        Me.rdb_NoEsEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_NoEsEfectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_NoEsEfectivo.UseVisualStyleBackColor = True
        '
        'rdb_SiEsEfectivo
        '
        Me.rdb_SiEsEfectivo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdb_SiEsEfectivo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_SiEsEfectivo.AutoSize = True
        Me.rdb_SiEsEfectivo.Enabled = False
        Me.rdb_SiEsEfectivo.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_SiEsEfectivo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_SiEsEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_SiEsEfectivo.Location = New System.Drawing.Point(433, 17)
        Me.rdb_SiEsEfectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.rdb_SiEsEfectivo.Name = "rdb_SiEsEfectivo"
        Me.rdb_SiEsEfectivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdb_SiEsEfectivo.Size = New System.Drawing.Size(130, 37)
        Me.rdb_SiEsEfectivo.TabIndex = 1
        Me.rdb_SiEsEfectivo.Text = "Efectivo"
        Me.rdb_SiEsEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_SiEsEfectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_SiEsEfectivo.UseVisualStyleBackColor = True
        '
        'lbl_TipoCambio
        '
        Me.lbl_TipoCambio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_TipoCambio.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TipoCambio.Location = New System.Drawing.Point(217, 176)
        Me.lbl_TipoCambio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_TipoCambio.Name = "lbl_TipoCambio"
        Me.lbl_TipoCambio.Size = New System.Drawing.Size(259, 43)
        Me.lbl_TipoCambio.TabIndex = 7
        Me.lbl_TipoCambio.Text = "Tipo de Cambio:"
        '
        'Lbl_Efectivo
        '
        Me.Lbl_Efectivo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lbl_Efectivo.Font = New System.Drawing.Font("Arial", 20.25!)
        Me.Lbl_Efectivo.Location = New System.Drawing.Point(217, 17)
        Me.Lbl_Efectivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Efectivo.Name = "Lbl_Efectivo"
        Me.Lbl_Efectivo.Size = New System.Drawing.Size(222, 39)
        Me.Lbl_Efectivo.TabIndex = 0
        Me.Lbl_Efectivo.Text = "Tipo depósito:"
        '
        'tbx_TipoCambio
        '
        Me.tbx_TipoCambio.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbx_TipoCambio.Enabled = False
        Me.tbx_TipoCambio.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_TipoCambio.Location = New System.Drawing.Point(586, 165)
        Me.tbx_TipoCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.tbx_TipoCambio.MaxLength = 6
        Me.tbx_TipoCambio.Name = "tbx_TipoCambio"
        Me.tbx_TipoCambio.ReadOnly = True
        Me.tbx_TipoCambio.Size = New System.Drawing.Size(185, 42)
        Me.tbx_TipoCambio.TabIndex = 8
        Me.tbx_TipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbx_USD
        '
        Me.tbx_USD.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbx_USD.Font = New System.Drawing.Font("Arial", 18.0!)
        Me.tbx_USD.Location = New System.Drawing.Point(586, 115)
        Me.tbx_USD.Margin = New System.Windows.Forms.Padding(4)
        Me.tbx_USD.MaxLength = 6
        Me.tbx_USD.Name = "tbx_USD"
        Me.tbx_USD.Size = New System.Drawing.Size(185, 42)
        Me.tbx_USD.TabIndex = 6
        Me.tbx_USD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbx_MXP
        '
        Me.tbx_MXP.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbx_MXP.Font = New System.Drawing.Font("Arial", 18.0!)
        Me.tbx_MXP.Location = New System.Drawing.Point(586, 64)
        Me.tbx_MXP.Margin = New System.Windows.Forms.Padding(4)
        Me.tbx_MXP.MaxLength = 6
        Me.tbx_MXP.Name = "tbx_MXP"
        Me.tbx_MXP.Size = New System.Drawing.Size(185, 42)
        Me.tbx_MXP.TabIndex = 4
        Me.tbx_MXP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_USD
        '
        Me.lbl_USD.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_USD.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_USD.Location = New System.Drawing.Point(219, 124)
        Me.lbl_USD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_USD.Name = "lbl_USD"
        Me.lbl_USD.Size = New System.Drawing.Size(219, 43)
        Me.lbl_USD.TabIndex = 5
        Me.lbl_USD.Text = "Importe USD:"
        '
        'lbl_MXP
        '
        Me.lbl_MXP.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_MXP.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MXP.Location = New System.Drawing.Point(219, 68)
        Me.lbl_MXP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_MXP.Name = "lbl_MXP"
        Me.lbl_MXP.Size = New System.Drawing.Size(265, 43)
        Me.lbl_MXP.TabIndex = 3
        Me.lbl_MXP.Text = "Importe MXN:"
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Guardar.Enabled = False
        Me.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Guardar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Guardar.Location = New System.Drawing.Point(16, 541)
        Me.btn_Guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(219, 92)
        Me.btn_Guardar.TabIndex = 2
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
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(832, 541)
        Me.btn_Cerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(219, 92)
        Me.btn_Cerrar.TabIndex = 3
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'frm_DepositoManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 648)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm_DepositoManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposito Buzon"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.grp_CajasEntradas.ResumeLayout(False)
        Me.grp_CajasEntradas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lbl_MXP As System.Windows.Forms.Label
    Friend WithEvents lbl_USD As System.Windows.Forms.Label
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents tbx_USDConvertido As System.Windows.Forms.TextBox
    Friend WithEvents lbl_USDConvertido As System.Windows.Forms.Label
    Friend WithEvents tbx_TipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_TipoCambio As System.Windows.Forms.Label
    Friend WithEvents tbx_MXP As System.Windows.Forms.TextBox
    Friend WithEvents tbx_USD As System.Windows.Forms.TextBox
    Friend WithEvents rdb_NoEsEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_SiEsEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents Lbl_Efectivo As System.Windows.Forms.Label
    Friend WithEvents grp_CajasEntradas As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Cajas As System.Windows.Forms.Button
End Class
