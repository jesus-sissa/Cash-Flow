<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaDepositosD
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
        Me.lbl_TotalD = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lsv_DepositosD = New System.Windows.Forms.ListView()
        Me.pnl_DepositosD = New System.Windows.Forms.Panel()
        Me.pnl_DepositosD.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_TotalD
        '
        Me.lbl_TotalD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalD.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TotalD.Location = New System.Drawing.Point(10, 397)
        Me.lbl_TotalD.Name = "lbl_TotalD"
        Me.lbl_TotalD.Size = New System.Drawing.Size(612, 75)
        Me.lbl_TotalD.TabIndex = 2
        Me.lbl_TotalD.Text = "$0.00"
        Me.lbl_TotalD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(628, 397)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 3
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lsv_DepositosD
        '
        Me.lsv_DepositosD.AllowColumnReorder = True
        Me.lsv_DepositosD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_DepositosD.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_DepositosD
        Me.lsv_DepositosD.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_DepositosD.FullRowSelect = True
        Me.lsv_DepositosD.HideSelection = False
        Me.lsv_DepositosD.Location = New System.Drawing.Point(10, 14)
        Me.lsv_DepositosD.MultiSelect = False
        Me.lsv_DepositosD.Name = "lsv_DepositosD"
        Me.lsv_DepositosD.Size = New System.Drawing.Size(782, 377)
        Me.lsv_DepositosD.TabIndex = 0
        Me.lsv_DepositosD.UseCompatibleStateImageBehavior = False
        Me.lsv_DepositosD.View = System.Windows.Forms.View.Details
        '
        'pnl_DepositosD
        '
        Me.pnl_DepositosD.Controls.Add(Me.lsv_DepositosD)
        Me.pnl_DepositosD.Controls.Add(Me.lbl_TotalD)
        Me.pnl_DepositosD.Controls.Add(Me.btn_Cerrar)
        Me.pnl_DepositosD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_DepositosD.Location = New System.Drawing.Point(0, 0)
        Me.pnl_DepositosD.Name = "pnl_DepositosD"
        Me.pnl_DepositosD.Size = New System.Drawing.Size(800, 480)
        Me.pnl_DepositosD.TabIndex = 4
        '
        'frm_ConsultaDepositosD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_DepositosD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaDepositosD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta del Detalle de Depósitos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_DepositosD.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lsv_DepositosD As System.Windows.Forms.ListView
    Friend WithEvents lbl_TotalD As System.Windows.Forms.Label
    Friend WithEvents pnl_DepositosD As System.Windows.Forms.Panel
End Class
