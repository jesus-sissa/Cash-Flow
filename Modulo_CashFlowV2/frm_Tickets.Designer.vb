<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Tickets
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lv_tickets = New System.Windows.Forms.ListView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Terminar = New System.Windows.Forms.Button()
        Me.btn_Recibir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_Tickets)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 70)
        Me.Panel1.TabIndex = 3
        '
        'lbl_Tickets
        '
        Me.lbl_Tickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Tickets.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tickets.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Tickets.Name = "lbl_Tickets"
        Me.lbl_Tickets.Size = New System.Drawing.Size(873, 70)
        Me.lbl_Tickets.TabIndex = 30
        Me.lbl_Tickets.Text = "Tickets de Sucursal"
        Me.lbl_Tickets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 70)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(873, 601)
        Me.Panel3.TabIndex = 4
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lv_tickets)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(873, 520)
        Me.Panel5.TabIndex = 1
        '
        'lv_tickets
        '
        Me.lv_tickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_tickets.Font = New System.Drawing.Font("Arial Black", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_tickets.FullRowSelect = True
        Me.lv_tickets.HideSelection = False
        Me.lv_tickets.Location = New System.Drawing.Point(0, 0)
        Me.lv_tickets.MultiSelect = False
        Me.lv_tickets.Name = "lv_tickets"
        Me.lv_tickets.Size = New System.Drawing.Size(873, 520)
        Me.lv_tickets.TabIndex = 0
        Me.lv_tickets.UseCompatibleStateImageBehavior = False
        Me.lv_tickets.View = System.Windows.Forms.View.Details
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_Cerrar)
        Me.Panel4.Controls.Add(Me.btn_Terminar)
        Me.Panel4.Controls.Add(Me.btn_Recibir)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 520)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(873, 81)
        Me.Panel4.TabIndex = 0
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(682, 6)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(170, 68)
        Me.btn_Cerrar.TabIndex = 15
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'btn_Terminar
        '
        Me.btn_Terminar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Terminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Terminar.Enabled = False
        Me.btn_Terminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Terminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Terminar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Terminar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Aceptar
        Me.btn_Terminar.Location = New System.Drawing.Point(208, 3)
        Me.btn_Terminar.Name = "btn_Terminar"
        Me.btn_Terminar.Size = New System.Drawing.Size(170, 71)
        Me.btn_Terminar.TabIndex = 17
        Me.btn_Terminar.Text = "&Terminar"
        Me.btn_Terminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Terminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Terminar.UseVisualStyleBackColor = False
        '
        'btn_Recibir
        '
        Me.btn_Recibir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Recibir.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Recibir.Enabled = False
        Me.btn_Recibir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Recibir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Recibir.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Recibir.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Descargar
        Me.btn_Recibir.Location = New System.Drawing.Point(22, 3)
        Me.btn_Recibir.Name = "btn_Recibir"
        Me.btn_Recibir.Size = New System.Drawing.Size(170, 71)
        Me.btn_Recibir.TabIndex = 17
        Me.btn_Recibir.Text = "&Recibir"
        Me.btn_Recibir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Recibir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Recibir.UseVisualStyleBackColor = False
        '
        'frm_Tickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(873, 671)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Tickets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbl_Tickets As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lv_tickets As ListView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_Recibir As Button
    Friend WithEvents btn_Terminar As Button
End Class
