<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Tickets_Detalle
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Tickets = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Detalle = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lv_respuestas = New System.Windows.Forms.ListView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_Tickets)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 100)
        Me.Panel1.TabIndex = 0
        '
        'lbl_Tickets
        '
        Me.lbl_Tickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Tickets.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tickets.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Tickets.Name = "lbl_Tickets"
        Me.lbl_Tickets.Size = New System.Drawing.Size(873, 100)
        Me.lbl_Tickets.TabIndex = 31
        Me.lbl_Tickets.Text = "Finalizacion de Ticket"
        Me.lbl_Tickets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_Cerrar)
        Me.Panel2.Controls.Add(Me.btn_Detalle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 575)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(873, 96)
        Me.Panel2.TabIndex = 1
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(691, 9)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(170, 75)
        Me.btn_Cerrar.TabIndex = 19
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'btn_Detalle
        '
        Me.btn_Detalle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btn_Detalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Detalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Detalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Detalle.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Detalle.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Descargar
        Me.btn_Detalle.Location = New System.Drawing.Point(12, 9)
        Me.btn_Detalle.Name = "btn_Detalle"
        Me.btn_Detalle.Size = New System.Drawing.Size(164, 75)
        Me.btn_Detalle.TabIndex = 18
        Me.btn_Detalle.Text = "&Finalizar"
        Me.btn_Detalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Detalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Detalle.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lv_respuestas)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(873, 475)
        Me.Panel3.TabIndex = 2
        '
        'lv_respuestas
        '
        Me.lv_respuestas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_respuestas.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_respuestas.HideSelection = False
        Me.lv_respuestas.Location = New System.Drawing.Point(0, 0)
        Me.lv_respuestas.Name = "lv_respuestas"
        Me.lv_respuestas.Size = New System.Drawing.Size(873, 475)
        Me.lv_respuestas.TabIndex = 0
        Me.lv_respuestas.UseCompatibleStateImageBehavior = False
        Me.lv_respuestas.View = System.Windows.Forms.View.Details
        '
        'frm_Tickets_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(873, 671)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Tickets_Detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Tickets_Detalle"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbl_Tickets As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_Detalle As Button
    Friend WithEvents btn_Cerrar As Button
    Friend WithEvents lv_respuestas As ListView
End Class
