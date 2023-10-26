<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaMovimientos
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
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.btn_FechaHasta = New System.Windows.Forms.Button()
        Me.btn_FechaDesde = New System.Windows.Forms.Button()
        Me.lbl_TotalRetiros = New System.Windows.Forms.Label()
        Me.lbl_TotalDepositos = New System.Windows.Forms.Label()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lsv_Balance = New System.Windows.Forms.ListView()
        Me.btn_Mostrar = New System.Windows.Forms.Button()
        Me.lbl_Desde = New System.Windows.Forms.Label()
        Me.lbl_Hasta = New System.Windows.Forms.Label()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.btn_FechaHasta)
        Me.pnl_General.Controls.Add(Me.btn_FechaDesde)
        Me.pnl_General.Controls.Add(Me.lbl_TotalRetiros)
        Me.pnl_General.Controls.Add(Me.lbl_TotalDepositos)
        Me.pnl_General.Controls.Add(Me.btn_Imprimir)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.lsv_Balance)
        Me.pnl_General.Controls.Add(Me.btn_Mostrar)
        Me.pnl_General.Controls.Add(Me.lbl_Desde)
        Me.pnl_General.Controls.Add(Me.lbl_Hasta)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Enabled = False
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 2
        '
        'btn_FechaHasta
        '
        Me.btn_FechaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaHasta.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaHasta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaHasta.Location = New System.Drawing.Point(392, 20)
        Me.btn_FechaHasta.Name = "btn_FechaHasta"
        Me.btn_FechaHasta.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaHasta.TabIndex = 17
        Me.btn_FechaHasta.Tag = "1"
        Me.btn_FechaHasta.Text = "06/08/2016"
        Me.btn_FechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaHasta.UseVisualStyleBackColor = False
        '
        'btn_FechaDesde
        '
        Me.btn_FechaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaDesde.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaDesde.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaDesde.Location = New System.Drawing.Point(110, 20)
        Me.btn_FechaDesde.Name = "btn_FechaDesde"
        Me.btn_FechaDesde.Size = New System.Drawing.Size(165, 44)
        Me.btn_FechaDesde.TabIndex = 16
        Me.btn_FechaDesde.Tag = "1"
        Me.btn_FechaDesde.Text = "06/08/2016"
        Me.btn_FechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaDesde.UseVisualStyleBackColor = False
        '
        'lbl_TotalRetiros
        '
        Me.lbl_TotalRetiros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalRetiros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalRetiros.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalRetiros.Location = New System.Drawing.Point(196, 446)
        Me.lbl_TotalRetiros.Name = "lbl_TotalRetiros"
        Me.lbl_TotalRetiros.Size = New System.Drawing.Size(423, 31)
        Me.lbl_TotalRetiros.TabIndex = 9
        Me.lbl_TotalRetiros.Text = "Total Retiros $ 0.00"
        Me.lbl_TotalRetiros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_TotalDepositos
        '
        Me.lbl_TotalDepositos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalDepositos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalDepositos.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalDepositos.Location = New System.Drawing.Point(196, 402)
        Me.lbl_TotalDepositos.Name = "lbl_TotalDepositos"
        Me.lbl_TotalDepositos.Size = New System.Drawing.Size(423, 37)
        Me.lbl_TotalDepositos.TabIndex = 8
        Me.lbl_TotalDepositos.Text = "Total Depositos $ 0.00"
        Me.lbl_TotalDepositos.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Imprimir.Enabled = False
        Me.btn_Imprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Imprimir.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_Imprimir.Location = New System.Drawing.Point(6, 402)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(178, 75)
        Me.btn_Imprimir.TabIndex = 6
        Me.btn_Imprimir.Text = "&Imprimir"
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(628, 402)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 7
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lsv_Balance
        '
        Me.lsv_Balance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Balance.AutoArrange = False
        Me.lsv_Balance.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.C_Movimientos
        Me.lsv_Balance.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Balance.FullRowSelect = True
        Me.lsv_Balance.HideSelection = False
        Me.lsv_Balance.Location = New System.Drawing.Point(6, 90)
        Me.lsv_Balance.MultiSelect = False
        Me.lsv_Balance.Name = "lsv_Balance"
        Me.lsv_Balance.Size = New System.Drawing.Size(786, 306)
        Me.lsv_Balance.TabIndex = 5
        Me.lsv_Balance.UseCompatibleStateImageBehavior = False
        Me.lsv_Balance.View = System.Windows.Forms.View.Details
        '
        'btn_Mostrar
        '
        Me.btn_Mostrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Mostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Mostrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Mostrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Mostrar
        Me.btn_Mostrar.Location = New System.Drawing.Point(628, 9)
        Me.btn_Mostrar.Name = "btn_Mostrar"
        Me.btn_Mostrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Mostrar.TabIndex = 4
        Me.btn_Mostrar.Text = "&Mostrar"
        Me.btn_Mostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Mostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Mostrar.UseVisualStyleBackColor = True
        '
        'lbl_Desde
        '
        Me.lbl_Desde.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Desde.Location = New System.Drawing.Point(8, 26)
        Me.lbl_Desde.Name = "lbl_Desde"
        Me.lbl_Desde.Size = New System.Drawing.Size(96, 31)
        Me.lbl_Desde.TabIndex = 0
        Me.lbl_Desde.Text = "Desde"
        Me.lbl_Desde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Hasta
        '
        Me.lbl_Hasta.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Hasta.Location = New System.Drawing.Point(294, 26)
        Me.lbl_Hasta.Name = "lbl_Hasta"
        Me.lbl_Hasta.Size = New System.Drawing.Size(92, 31)
        Me.lbl_Hasta.TabIndex = 2
        Me.lbl_Hasta.Text = "Hasta"
        Me.lbl_Hasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_ConsultaMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lsv_Balance As System.Windows.Forms.ListView
    Friend WithEvents btn_Mostrar As System.Windows.Forms.Button
    Friend WithEvents lbl_Desde As System.Windows.Forms.Label
    Friend WithEvents lbl_Hasta As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalRetiros As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalDepositos As System.Windows.Forms.Label
    Friend WithEvents btn_FechaHasta As System.Windows.Forms.Button
    Friend WithEvents btn_FechaDesde As System.Windows.Forms.Button
End Class
