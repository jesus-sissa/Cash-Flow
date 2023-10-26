<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Actualizar
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
        Me.pnl_Actualizacion = New System.Windows.Forms.Panel()
        Me.rtb_Observaciones = New System.Windows.Forms.RichTextBox()
        Me.btn_Guardar = New System.Windows.Forms.Button()
        Me.btn_Mostrar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lsv_Actualizar = New System.Windows.Forms.ListView()
        Me.pnl_Actualizacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Actualizacion
        '
        Me.pnl_Actualizacion.Controls.Add(Me.rtb_Observaciones)
        Me.pnl_Actualizacion.Controls.Add(Me.btn_Guardar)
        Me.pnl_Actualizacion.Controls.Add(Me.btn_Mostrar)
        Me.pnl_Actualizacion.Controls.Add(Me.btn_Cerrar)
        Me.pnl_Actualizacion.Controls.Add(Me.lsv_Actualizar)
        Me.pnl_Actualizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Actualizacion.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Actualizacion.Name = "pnl_Actualizacion"
        Me.pnl_Actualizacion.Size = New System.Drawing.Size(800, 480)
        Me.pnl_Actualizacion.TabIndex = 0
        '
        'rtb_Observaciones
        '
        Me.rtb_Observaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtb_Observaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rtb_Observaciones.Location = New System.Drawing.Point(26, 328)
        Me.rtb_Observaciones.MaxLength = 200
        Me.rtb_Observaciones.Name = "rtb_Observaciones"
        Me.rtb_Observaciones.Size = New System.Drawing.Size(734, 44)
        Me.rtb_Observaciones.TabIndex = 29
        Me.rtb_Observaciones.Text = ""
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Guardar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Guardar.Location = New System.Drawing.Point(26, 397)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Guardar.TabIndex = 28
        Me.btn_Guardar.Text = "&Guardar"
        Me.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Guardar.UseVisualStyleBackColor = True
        '
        'btn_Mostrar
        '
        Me.btn_Mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Mostrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Mostrar
        Me.btn_Mostrar.Location = New System.Drawing.Point(250, 397)
        Me.btn_Mostrar.Name = "btn_Mostrar"
        Me.btn_Mostrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Mostrar.TabIndex = 7
        Me.btn_Mostrar.Text = "&Mostrar"
        Me.btn_Mostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Mostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Mostrar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(624, 393)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 4
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lsv_Actualizar
        '
        Me.lsv_Actualizar.FullRowSelect = True
        Me.lsv_Actualizar.Location = New System.Drawing.Point(26, 21)
        Me.lsv_Actualizar.MultiSelect = False
        Me.lsv_Actualizar.Name = "lsv_Actualizar"
        Me.lsv_Actualizar.Size = New System.Drawing.Size(734, 301)
        Me.lsv_Actualizar.TabIndex = 0
        Me.lsv_Actualizar.UseCompatibleStateImageBehavior = False
        Me.lsv_Actualizar.View = System.Windows.Forms.View.Details
        '
        'frm_Actualizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_Actualizacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Actualizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizacion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Actualizacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Actualizacion As System.Windows.Forms.Panel
    Friend WithEvents lsv_Actualizar As System.Windows.Forms.ListView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Mostrar As System.Windows.Forms.Button
    Friend WithEvents btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents rtb_Observaciones As System.Windows.Forms.RichTextBox

End Class
