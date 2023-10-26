<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CortePorDia
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
        Me.btn_Saldo = New System.Windows.Forms.Button()
        Me.btn_CortePorDia = New System.Windows.Forms.Button()
        Me.Btn_Cerrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Saldo
        '
        Me.btn_Saldo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Saldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Saldo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Saldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Saldo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Saldo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_Saldo.Location = New System.Drawing.Point(192, 193)
        Me.btn_Saldo.Name = "btn_Saldo"
        Me.btn_Saldo.Size = New System.Drawing.Size(430, 75)
        Me.btn_Saldo.TabIndex = 34
        Me.btn_Saldo.Text = "Saldo"
        Me.btn_Saldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Saldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Saldo.UseVisualStyleBackColor = False
        '
        'btn_CortePorDia
        '
        Me.btn_CortePorDia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_CortePorDia.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_CortePorDia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CortePorDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CortePorDia.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CortePorDia.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_CortePorDia.Location = New System.Drawing.Point(192, 93)
        Me.btn_CortePorDia.Name = "btn_CortePorDia"
        Me.btn_CortePorDia.Size = New System.Drawing.Size(430, 75)
        Me.btn_CortePorDia.TabIndex = 33
        Me.btn_CortePorDia.Text = "Saldo Por Corte"
        Me.btn_CortePorDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CortePorDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_CortePorDia.UseVisualStyleBackColor = False
        '
        'Btn_Cerrar
        '
        Me.Btn_Cerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Cancelar
        Me.Btn_Cerrar.Location = New System.Drawing.Point(192, 291)
        Me.Btn_Cerrar.Name = "Btn_Cerrar"
        Me.Btn_Cerrar.Size = New System.Drawing.Size(430, 75)
        Me.Btn_Cerrar.TabIndex = 35
        Me.Btn_Cerrar.Text = "Cerrar"
        Me.Btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Cerrar.UseVisualStyleBackColor = False
        '
        'Frm_CortePorDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.Btn_Cerrar)
        Me.Controls.Add(Me.btn_Saldo)
        Me.Controls.Add(Me.btn_CortePorDia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frm_CortePorDia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_CortePorDia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Saldo As System.Windows.Forms.Button
    Friend WithEvents btn_CortePorDia As System.Windows.Forms.Button
    Friend WithEvents Btn_Cerrar As System.Windows.Forms.Button
End Class
