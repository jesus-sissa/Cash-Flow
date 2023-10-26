<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ConsultaLog
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
        Me.lsv_Detalle = New System.Windows.Forms.ListView()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_FechaDesde = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsv_Detalle
        '
        Me.lsv_Detalle.AllowColumnReorder = True
        Me.lsv_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Detalle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Detalle.FullRowSelect = True
        Me.lsv_Detalle.HideSelection = False
        Me.lsv_Detalle.Location = New System.Drawing.Point(3, 87)
        Me.lsv_Detalle.MultiSelect = False
        Me.lsv_Detalle.Name = "lsv_Detalle"
        Me.lsv_Detalle.Size = New System.Drawing.Size(1026, 390)
        Me.lsv_Detalle.TabIndex = 6
        Me.lsv_Detalle.UseCompatibleStateImageBehavior = False
        Me.lsv_Detalle.View = System.Windows.Forms.View.Details
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.btn_FechaDesde)
        Me.pnl_General.Controls.Add(Me.Btn_Limpiar)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.lsv_Detalle)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(1032, 480)
        Me.pnl_General.TabIndex = 0
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Limpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.Btn_Limpiar.Location = New System.Drawing.Point(675, 4)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(198, 75)
        Me.Btn_Limpiar.TabIndex = 9
        Me.Btn_Limpiar.Text = "&Limpiar log"
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Limpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(879, 4)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(150, 75)
        Me.btn_Cerrar.TabIndex = 8
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_FechaDesde
        '
        Me.btn_FechaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaDesde.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaDesde.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.calendar_16
        Me.btn_FechaDesde.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaDesde.Location = New System.Drawing.Point(34, 23)
        Me.btn_FechaDesde.Name = "btn_FechaDesde"
        Me.btn_FechaDesde.Size = New System.Drawing.Size(192, 55)
        Me.btn_FechaDesde.TabIndex = 16
        Me.btn_FechaDesde.Tag = "1"
        Me.btn_FechaDesde.Text = "06/08/2016"
        Me.btn_FechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaDesde.UseVisualStyleBackColor = False
        '
        'frm_ConsultaLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta del Log"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsv_Detalle As System.Windows.Forms.ListView
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents Btn_Limpiar As Button
    Friend WithEvents btn_FechaDesde As Button
End Class
