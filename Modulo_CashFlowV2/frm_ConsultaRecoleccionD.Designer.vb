<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaRecoleccionD
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
        Me.lbl_ImporteTotal = New System.Windows.Forms.Label()
        Me.lsv_RecoleccionD = New System.Windows.Forms.ListView()
        Me.lbl_SubTotalValidado = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lbl_SubtotalManual = New System.Windows.Forms.Label()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.lbl_ImporteValidado = New System.Windows.Forms.Label()
        Me.lbl_ImporteManual = New System.Windows.Forms.Label()
        Me.pnl_RecoleccionD = New System.Windows.Forms.Panel()
        Me.pnl_RecoleccionD.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_ImporteTotal
        '
        Me.lbl_ImporteTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ImporteTotal.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ImporteTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_ImporteTotal.Location = New System.Drawing.Point(403, 437)
        Me.lbl_ImporteTotal.Name = "lbl_ImporteTotal"
        Me.lbl_ImporteTotal.Size = New System.Drawing.Size(223, 34)
        Me.lbl_ImporteTotal.TabIndex = 6
        Me.lbl_ImporteTotal.Text = "$0.00"
        Me.lbl_ImporteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lsv_RecoleccionD
        '
        Me.lsv_RecoleccionD.AllowColumnReorder = True
        Me.lsv_RecoleccionD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_RecoleccionD.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_RetirosD
        Me.lsv_RecoleccionD.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_RecoleccionD.FullRowSelect = True
        Me.lsv_RecoleccionD.HideSelection = False
        Me.lsv_RecoleccionD.Location = New System.Drawing.Point(8, 12)
        Me.lsv_RecoleccionD.MultiSelect = False
        Me.lsv_RecoleccionD.Name = "lsv_RecoleccionD"
        Me.lsv_RecoleccionD.Size = New System.Drawing.Size(785, 378)
        Me.lsv_RecoleccionD.TabIndex = 4
        Me.lsv_RecoleccionD.UseCompatibleStateImageBehavior = False
        Me.lsv_RecoleccionD.View = System.Windows.Forms.View.Details
        '
        'lbl_SubTotalValidado
        '
        Me.lbl_SubTotalValidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_SubTotalValidado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_SubTotalValidado.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubTotalValidado.Location = New System.Drawing.Point(8, 395)
        Me.lbl_SubTotalValidado.Name = "lbl_SubTotalValidado"
        Me.lbl_SubTotalValidado.Size = New System.Drawing.Size(185, 34)
        Me.lbl_SubTotalValidado.TabIndex = 5
        Me.lbl_SubTotalValidado.Text = "IMP. VAL"
        Me.lbl_SubTotalValidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(629, 396)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 7
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lbl_SubtotalManual
        '
        Me.lbl_SubtotalManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_SubtotalManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_SubtotalManual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubtotalManual.Location = New System.Drawing.Point(8, 437)
        Me.lbl_SubtotalManual.Name = "lbl_SubtotalManual"
        Me.lbl_SubtotalManual.Size = New System.Drawing.Size(181, 34)
        Me.lbl_SubtotalManual.TabIndex = 8
        Me.lbl_SubtotalManual.Text = "IMP. MAN"
        Me.lbl_SubtotalManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Total
        '
        Me.lbl_Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Total.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Total.Location = New System.Drawing.Point(403, 395)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(223, 34)
        Me.lbl_Total.TabIndex = 9
        Me.lbl_Total.Text = "TOTAL"
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_ImporteValidado
        '
        Me.lbl_ImporteValidado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_ImporteValidado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ImporteValidado.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ImporteValidado.Location = New System.Drawing.Point(195, 395)
        Me.lbl_ImporteValidado.Name = "lbl_ImporteValidado"
        Me.lbl_ImporteValidado.Size = New System.Drawing.Size(208, 34)
        Me.lbl_ImporteValidado.TabIndex = 10
        Me.lbl_ImporteValidado.Text = "$0.00"
        Me.lbl_ImporteValidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ImporteManual
        '
        Me.lbl_ImporteManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_ImporteManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ImporteManual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ImporteManual.Location = New System.Drawing.Point(195, 437)
        Me.lbl_ImporteManual.Name = "lbl_ImporteManual"
        Me.lbl_ImporteManual.Size = New System.Drawing.Size(208, 34)
        Me.lbl_ImporteManual.TabIndex = 11
        Me.lbl_ImporteManual.Text = "$0.00"
        Me.lbl_ImporteManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnl_RecoleccionD
        '
        Me.pnl_RecoleccionD.Controls.Add(Me.lbl_ImporteManual)
        Me.pnl_RecoleccionD.Controls.Add(Me.lsv_RecoleccionD)
        Me.pnl_RecoleccionD.Controls.Add(Me.lbl_SubTotalValidado)
        Me.pnl_RecoleccionD.Controls.Add(Me.lbl_ImporteValidado)
        Me.pnl_RecoleccionD.Controls.Add(Me.btn_Cerrar)
        Me.pnl_RecoleccionD.Controls.Add(Me.lbl_Total)
        Me.pnl_RecoleccionD.Controls.Add(Me.lbl_ImporteTotal)
        Me.pnl_RecoleccionD.Controls.Add(Me.lbl_SubtotalManual)
        Me.pnl_RecoleccionD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_RecoleccionD.Location = New System.Drawing.Point(0, 0)
        Me.pnl_RecoleccionD.Name = "pnl_RecoleccionD"
        Me.pnl_RecoleccionD.Size = New System.Drawing.Size(800, 480)
        Me.pnl_RecoleccionD.TabIndex = 12
        '
        'frm_ConsultaRecoleccionD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_RecoleccionD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaRecoleccionD"
        Me.Text = "Consulta del Detalle de Recoleccion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_RecoleccionD.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_ImporteTotal As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lsv_RecoleccionD As System.Windows.Forms.ListView
    Friend WithEvents lbl_SubTotalValidado As System.Windows.Forms.Label
    Friend WithEvents lbl_SubtotalManual As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents lbl_ImporteValidado As System.Windows.Forms.Label
    Friend WithEvents lbl_ImporteManual As System.Windows.Forms.Label
    Friend WithEvents pnl_RecoleccionD As System.Windows.Forms.Panel
End Class
