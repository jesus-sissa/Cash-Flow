<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Mensaje
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
        Me.components = New System.ComponentModel.Container()
        Me.tmr_Mensaje = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_Mensaje = New System.Windows.Forms.Label()
        Me.pct_Icono = New System.Windows.Forms.PictureBox()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        CType(Me.pct_Icono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmr_Mensaje
        '
        Me.tmr_Mensaje.Interval = 5000
        '
        'lbl_Mensaje
        '
        Me.lbl_Mensaje.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Mensaje.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mensaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Mensaje.Location = New System.Drawing.Point(12, 167)
        Me.lbl_Mensaje.Name = "lbl_Mensaje"
        Me.lbl_Mensaje.Size = New System.Drawing.Size(776, 227)
        Me.lbl_Mensaje.TabIndex = 0
        Me.lbl_Mensaje.Text = "Mensaje"
        Me.lbl_Mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pct_Icono
        '
        Me.pct_Icono.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pct_Icono.ErrorImage = Nothing
        Me.pct_Icono.Location = New System.Drawing.Point(320, 28)
        Me.pct_Icono.Name = "pct_Icono"
        Me.pct_Icono.Size = New System.Drawing.Size(158, 139)
        Me.pct_Icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pct_Icono.TabIndex = 4
        Me.pct_Icono.TabStop = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cancelar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Cancelar
        Me.btn_Cancelar.Location = New System.Drawing.Point(451, 399)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(171, 75)
        Me.btn_Cancelar.TabIndex = 12
        Me.btn_Cancelar.Text = "&Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_Aceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Aceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Aceptar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Aceptar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Aceptar
        Me.btn_Aceptar.Location = New System.Drawing.Point(187, 399)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Aceptar.TabIndex = 11
        Me.btn_Aceptar.Text = "&Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'frm_Mensaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.lbl_Mensaje)
        Me.Controls.Add(Me.pct_Icono)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Mensaje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensaje"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pct_Icono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pct_Icono As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Mensaje As System.Windows.Forms.Label
    Friend WithEvents tmr_Mensaje As System.Windows.Forms.Timer
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
End Class
