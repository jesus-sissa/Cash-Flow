<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Rest_Validador
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
        Me.lbl_Servidor = New System.Windows.Forms.Label()
        Me.btn_Resetear = New System.Windows.Forms.Button()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.cmb_Puertos = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lbl_Servidor
        '
        Me.lbl_Servidor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Servidor.AutoSize = True
        Me.lbl_Servidor.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Servidor.Location = New System.Drawing.Point(71, 25)
        Me.lbl_Servidor.Name = "lbl_Servidor"
        Me.lbl_Servidor.Size = New System.Drawing.Size(182, 24)
        Me.lbl_Servidor.TabIndex = 22
        Me.lbl_Servidor.Text = "Seleccione Puerto"
        '
        'btn_Resetear
        '
        Me.btn_Resetear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Resetear.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Resetear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Resetear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Resetear.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Resetear.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Resetear.Location = New System.Drawing.Point(336, 106)
        Me.btn_Resetear.Name = "btn_Resetear"
        Me.btn_Resetear.Size = New System.Drawing.Size(181, 47)
        Me.btn_Resetear.TabIndex = 24
        Me.btn_Resetear.Tag = ""
        Me.btn_Resetear.Text = "&Resetear"
        Me.btn_Resetear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Resetear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Resetear.UseVisualStyleBackColor = False
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Buscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Buscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Buscar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Buscar.Location = New System.Drawing.Point(166, 106)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(164, 47)
        Me.btn_Buscar.TabIndex = 32
        Me.btn_Buscar.Tag = ""
        Me.btn_Buscar.Text = "Salir"
        Me.btn_Buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Buscar.UseVisualStyleBackColor = False
        '
        'cmb_Puertos
        '
        Me.cmb_Puertos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Puertos.FormattingEnabled = True
        Me.cmb_Puertos.Location = New System.Drawing.Point(75, 52)
        Me.cmb_Puertos.Name = "cmb_Puertos"
        Me.cmb_Puertos.Size = New System.Drawing.Size(442, 33)
        Me.cmb_Puertos.TabIndex = 33
        '
        'Timer1
        '
        Me.Timer1.Interval = 9000
        '
        'frm_Rest_Validador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(590, 193)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmb_Puertos)
        Me.Controls.Add(Me.btn_Buscar)
        Me.Controls.Add(Me.btn_Resetear)
        Me.Controls.Add(Me.lbl_Servidor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_Rest_Validador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resetear "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Servidor As Label
    Friend WithEvents btn_Resetear As Button
    Friend WithEvents btn_Buscar As Button
    Friend WithEvents cmb_Puertos As ComboBox
    Friend WithEvents Timer1 As Timer
End Class
