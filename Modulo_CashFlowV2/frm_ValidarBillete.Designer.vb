<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ValidarBillete
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
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.lbl_Denominacion = New System.Windows.Forms.Label()
        Me.btn_Validador2 = New System.Windows.Forms.Button()
        Me.btn_Validador1 = New System.Windows.Forms.Button()
        Me.pct_cargando = New System.Windows.Forms.PictureBox()
        Me.pct_Billetes = New System.Windows.Forms.PictureBox()
        Me.btn_Salir = New System.Windows.Forms.Button()
        Me.pnl_General = New System.Windows.Forms.Panel()
        CType(Me.pct_cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pct_Billetes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Status
        '
        Me.lbl_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Status.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.Black
        Me.lbl_Status.Location = New System.Drawing.Point(3, 6)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(794, 31)
        Me.lbl_Status.TabIndex = 3
        Me.lbl_Status.Text = "VALIDACION DE BILLETES"
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Denominacion
        '
        Me.lbl_Denominacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Denominacion.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Denominacion.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Denominacion.Location = New System.Drawing.Point(9, 40)
        Me.lbl_Denominacion.Name = "lbl_Denominacion"
        Me.lbl_Denominacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_Denominacion.Size = New System.Drawing.Size(788, 31)
        Me.lbl_Denominacion.TabIndex = 4
        Me.lbl_Denominacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Validador2
        '
        Me.btn_Validador2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Validador2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Validador2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Validador2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Validador2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Inicializar
        Me.btn_Validador2.Location = New System.Drawing.Point(212, 393)
        Me.btn_Validador2.Name = "btn_Validador2"
        Me.btn_Validador2.Size = New System.Drawing.Size(164, 75)
        Me.btn_Validador2.TabIndex = 8
        Me.btn_Validador2.Text = "Iniciar Val.2"
        Me.btn_Validador2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Validador2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Validador2.UseVisualStyleBackColor = True
        Me.btn_Validador2.Visible = False
        '
        'btn_Validador1
        '
        Me.btn_Validador1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Validador1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Validador1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Validador1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Validador1.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Inicializar
        Me.btn_Validador1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Validador1.Location = New System.Drawing.Point(9, 393)
        Me.btn_Validador1.Name = "btn_Validador1"
        Me.btn_Validador1.Size = New System.Drawing.Size(164, 75)
        Me.btn_Validador1.TabIndex = 7
        Me.btn_Validador1.Text = "Iniciar Val.1"
        Me.btn_Validador1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Validador1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Validador1.UseVisualStyleBackColor = True
        '
        'pct_cargando
        '
        Me.pct_cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pct_cargando.BackColor = System.Drawing.SystemColors.Control
        Me.pct_cargando.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.cargando
        Me.pct_cargando.InitialImage = Nothing
        Me.pct_cargando.Location = New System.Drawing.Point(334, 181)
        Me.pct_cargando.Name = "pct_cargando"
        Me.pct_cargando.Size = New System.Drawing.Size(129, 105)
        Me.pct_cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pct_cargando.TabIndex = 6
        Me.pct_cargando.TabStop = False
        Me.pct_cargando.Visible = False
        '
        'pct_Billetes
        '
        Me.pct_Billetes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pct_Billetes.BackColor = System.Drawing.SystemColors.Control
        Me.pct_Billetes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pct_Billetes.Location = New System.Drawing.Point(9, 74)
        Me.pct_Billetes.Name = "pct_Billetes"
        Me.pct_Billetes.Size = New System.Drawing.Size(782, 313)
        Me.pct_Billetes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pct_Billetes.TabIndex = 5
        Me.pct_Billetes.TabStop = False
        '
        'btn_Salir
        '
        Me.btn_Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Salir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Salir.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Salir.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Salir.Location = New System.Drawing.Point(627, 393)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(164, 75)
        Me.btn_Salir.TabIndex = 2
        Me.btn_Salir.Text = "Cerrar"
        Me.btn_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Salir.UseVisualStyleBackColor = True
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.lbl_Status)
        Me.pnl_General.Controls.Add(Me.btn_Salir)
        Me.pnl_General.Controls.Add(Me.btn_Validador2)
        Me.pnl_General.Controls.Add(Me.btn_Validador1)
        Me.pnl_General.Controls.Add(Me.lbl_Denominacion)
        Me.pnl_General.Controls.Add(Me.pct_Billetes)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 9
        '
        'frm_ValidarBillete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pct_cargando)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ValidarBillete"
        Me.Text = "Validación de Billetes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pct_cargando, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pct_Billetes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_General.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Salir As System.Windows.Forms.Button
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents lbl_Denominacion As System.Windows.Forms.Label
    Friend WithEvents pct_Billetes As System.Windows.Forms.PictureBox
    Friend WithEvents pct_cargando As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Validador1 As System.Windows.Forms.Button
    Friend WithEvents btn_Validador2 As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
End Class
