<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Reporte
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Observaciones = New System.Windows.Forms.Label()
        Me.chk_NoDepositar = New System.Windows.Forms.CheckBox()
        Me.chk_FalloPantalla = New System.Windows.Forms.CheckBox()
        Me.chk_CartuchoLleno = New System.Windows.Forms.CheckBox()
        Me.chk_NoAceptaBilletes = New System.Windows.Forms.CheckBox()
        Me.chk_NoImprimeRecibo = New System.Windows.Forms.CheckBox()
        Me.chk_SistemaLento = New System.Windows.Forms.CheckBox()
        Me.chk_AtascoBillete = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lbl_Observaciones)
        Me.Panel1.Controls.Add(Me.chk_NoDepositar)
        Me.Panel1.Controls.Add(Me.chk_FalloPantalla)
        Me.Panel1.Controls.Add(Me.chk_CartuchoLleno)
        Me.Panel1.Controls.Add(Me.chk_NoAceptaBilletes)
        Me.Panel1.Controls.Add(Me.chk_NoImprimeRecibo)
        Me.Panel1.Controls.Add(Me.chk_SistemaLento)
        Me.Panel1.Controls.Add(Me.chk_AtascoBillete)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(887, 601)
        Me.Panel1.TabIndex = 0
        '
        'lbl_Observaciones
        '
        Me.lbl_Observaciones.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_Observaciones.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Observaciones.Location = New System.Drawing.Point(154, 23)
        Me.lbl_Observaciones.Name = "lbl_Observaciones"
        Me.lbl_Observaciones.Size = New System.Drawing.Size(617, 32)
        Me.lbl_Observaciones.TabIndex = 29
        Me.lbl_Observaciones.Text = "Seleccione una o mas opciones a reportar"
        '
        'chk_NoDepositar
        '
        Me.chk_NoDepositar.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_NoDepositar.AutoSize = True
        Me.chk_NoDepositar.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_NoDepositar.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_NoDepositar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_NoDepositar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_NoDepositar.Location = New System.Drawing.Point(436, 211)
        Me.chk_NoDepositar.Name = "chk_NoDepositar"
        Me.chk_NoDepositar.Size = New System.Drawing.Size(341, 43)
        Me.chk_NoDepositar.TabIndex = 28
        Me.chk_NoDepositar.Text = "No se puede depositar"
        Me.chk_NoDepositar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_NoDepositar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_NoDepositar.UseVisualStyleBackColor = True
        '
        'chk_FalloPantalla
        '
        Me.chk_FalloPantalla.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_FalloPantalla.AutoSize = True
        Me.chk_FalloPantalla.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_FalloPantalla.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_FalloPantalla.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_FalloPantalla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_FalloPantalla.Location = New System.Drawing.Point(436, 117)
        Me.chk_FalloPantalla.Name = "chk_FalloPantalla"
        Me.chk_FalloPantalla.Size = New System.Drawing.Size(263, 43)
        Me.chk_FalloPantalla.TabIndex = 27
        Me.chk_FalloPantalla.Text = "Fallo de pantalla"
        Me.chk_FalloPantalla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_FalloPantalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_FalloPantalla.UseVisualStyleBackColor = True
        '
        'chk_CartuchoLleno
        '
        Me.chk_CartuchoLleno.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_CartuchoLleno.AutoSize = True
        Me.chk_CartuchoLleno.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_CartuchoLleno.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_CartuchoLleno.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_CartuchoLleno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_CartuchoLleno.Location = New System.Drawing.Point(100, 509)
        Me.chk_CartuchoLleno.Name = "chk_CartuchoLleno"
        Me.chk_CartuchoLleno.Size = New System.Drawing.Size(246, 43)
        Me.chk_CartuchoLleno.TabIndex = 26
        Me.chk_CartuchoLleno.Text = "Cartucho Lleno"
        Me.chk_CartuchoLleno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_CartuchoLleno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_CartuchoLleno.UseVisualStyleBackColor = True
        '
        'chk_NoAceptaBilletes
        '
        Me.chk_NoAceptaBilletes.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_NoAceptaBilletes.AutoSize = True
        Me.chk_NoAceptaBilletes.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_NoAceptaBilletes.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_NoAceptaBilletes.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_NoAceptaBilletes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_NoAceptaBilletes.Location = New System.Drawing.Point(100, 410)
        Me.chk_NoAceptaBilletes.Name = "chk_NoAceptaBilletes"
        Me.chk_NoAceptaBilletes.Size = New System.Drawing.Size(285, 43)
        Me.chk_NoAceptaBilletes.TabIndex = 25
        Me.chk_NoAceptaBilletes.Text = "No Acepta Billetes"
        Me.chk_NoAceptaBilletes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_NoAceptaBilletes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_NoAceptaBilletes.UseVisualStyleBackColor = True
        '
        'chk_NoImprimeRecibo
        '
        Me.chk_NoImprimeRecibo.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_NoImprimeRecibo.AutoSize = True
        Me.chk_NoImprimeRecibo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_NoImprimeRecibo.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_NoImprimeRecibo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_NoImprimeRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_NoImprimeRecibo.Location = New System.Drawing.Point(100, 309)
        Me.chk_NoImprimeRecibo.Name = "chk_NoImprimeRecibo"
        Me.chk_NoImprimeRecibo.Size = New System.Drawing.Size(299, 43)
        Me.chk_NoImprimeRecibo.TabIndex = 24
        Me.chk_NoImprimeRecibo.Text = "No imprime Recibo"
        Me.chk_NoImprimeRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_NoImprimeRecibo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_NoImprimeRecibo.UseVisualStyleBackColor = True
        '
        'chk_SistemaLento
        '
        Me.chk_SistemaLento.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_SistemaLento.AutoSize = True
        Me.chk_SistemaLento.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_SistemaLento.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_SistemaLento.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_SistemaLento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_SistemaLento.Location = New System.Drawing.Point(100, 211)
        Me.chk_SistemaLento.Name = "chk_SistemaLento"
        Me.chk_SistemaLento.Size = New System.Drawing.Size(235, 43)
        Me.chk_SistemaLento.TabIndex = 23
        Me.chk_SistemaLento.Text = "Sistema Lento"
        Me.chk_SistemaLento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_SistemaLento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_SistemaLento.UseVisualStyleBackColor = True
        '
        'chk_AtascoBillete
        '
        Me.chk_AtascoBillete.Appearance = System.Windows.Forms.Appearance.Button
        Me.chk_AtascoBillete.AutoSize = True
        Me.chk_AtascoBillete.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_AtascoBillete.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_AtascoBillete.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.CheckBox_Unchecked_24x24
        Me.chk_AtascoBillete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_AtascoBillete.Location = New System.Drawing.Point(100, 117)
        Me.chk_AtascoBillete.Name = "chk_AtascoBillete"
        Me.chk_AtascoBillete.Size = New System.Drawing.Size(266, 43)
        Me.chk_AtascoBillete.TabIndex = 22
        Me.chk_AtascoBillete.Text = "Atasco de Billete"
        Me.chk_AtascoBillete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_AtascoBillete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chk_AtascoBillete.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btn_Guardar)
        Me.Panel2.Controls.Add(Me.btn_Cerrar)
        Me.Panel2.Location = New System.Drawing.Point(2, 610)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(887, 98)
        Me.Panel2.TabIndex = 1
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Guardar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Guardar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Guardar.Location = New System.Drawing.Point(10, 13)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Guardar.TabIndex = 16
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
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(711, 13)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 15
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'frm_Reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(889, 710)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Reporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_Guardar As Button
    Friend WithEvents btn_Cerrar As Button
    Friend WithEvents chk_CartuchoLleno As CheckBox
    Friend WithEvents chk_NoAceptaBilletes As CheckBox
    Friend WithEvents chk_NoImprimeRecibo As CheckBox
    Friend WithEvents chk_SistemaLento As CheckBox
    Friend WithEvents chk_AtascoBillete As CheckBox
    Friend WithEvents chk_NoDepositar As CheckBox
    Friend WithEvents chk_FalloPantalla As CheckBox
    Friend WithEvents lbl_Observaciones As Label
End Class
