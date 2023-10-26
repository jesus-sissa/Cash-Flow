<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DepositoXvalidador
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
        Me.components = New System.ComponentModel.Container()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.lbl_Alerta = New System.Windows.Forms.Label()
        Me.tlp_Lista = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Total2 = New System.Windows.Forms.Label()
        Me.lbl_Total1 = New System.Windows.Forms.Label()
        Me.prg_Caset2 = New System.Windows.Forms.ProgressBar()
        Me.lsv_Datos = New System.Windows.Forms.ListView()
        Me.lsv_Datos2 = New System.Windows.Forms.ListView()
        Me.prg_Caset1 = New System.Windows.Forms.ProgressBar()
        Me.lbl_tmrCerrar = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Finalizar = New System.Windows.Forms.Button()
        Me.lbl_DepositoP = New System.Windows.Forms.Label()
        Me.btn_Iniciar = New System.Windows.Forms.Button()
        Me.tmr_depositos = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_Padre = New System.Windows.Forms.Panel()
        Me.pct_cargando = New System.Windows.Forms.PictureBox()
        Me.pnl_General.SuspendLayout()
        Me.tlp_Lista.SuspendLayout()
        Me.pnl_Padre.SuspendLayout()
        CType(Me.pct_cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.lbl_Alerta)
        Me.pnl_General.Controls.Add(Me.tlp_Lista)
        Me.pnl_General.Controls.Add(Me.lbl_tmrCerrar)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.btn_Finalizar)
        Me.pnl_General.Controls.Add(Me.lbl_DepositoP)
        Me.pnl_General.Controls.Add(Me.btn_Iniciar)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'lbl_Alerta
        '
        Me.lbl_Alerta.BackColor = System.Drawing.Color.Red
        Me.lbl_Alerta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Alerta.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_Alerta.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Alert_CashFlow
        Me.lbl_Alerta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Alerta.Location = New System.Drawing.Point(6, 37)
        Me.lbl_Alerta.Name = "lbl_Alerta"
        Me.lbl_Alerta.Size = New System.Drawing.Size(368, 25)
        Me.lbl_Alerta.TabIndex = 21
        Me.lbl_Alerta.Text = "    Caset1 Llenandose"
        Me.lbl_Alerta.Visible = False
        '
        'tlp_Lista
        '
        Me.tlp_Lista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlp_Lista.ColumnCount = 2
        Me.tlp_Lista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Lista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Lista.Controls.Add(Me.lbl_Total2, 1, 2)
        Me.tlp_Lista.Controls.Add(Me.lbl_Total1, 0, 2)
        Me.tlp_Lista.Controls.Add(Me.prg_Caset2, 1, 1)
        Me.tlp_Lista.Controls.Add(Me.lsv_Datos, 0, 0)
        Me.tlp_Lista.Controls.Add(Me.lsv_Datos2, 1, 0)
        Me.tlp_Lista.Controls.Add(Me.prg_Caset1, 0, 1)
        Me.tlp_Lista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tlp_Lista.Location = New System.Drawing.Point(7, 84)
        Me.tlp_Lista.Name = "tlp_Lista"
        Me.tlp_Lista.RowCount = 3
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Lista.Size = New System.Drawing.Size(787, 384)
        Me.tlp_Lista.TabIndex = 19
        '
        'lbl_Total2
        '
        Me.lbl_Total2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Total2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total2.Location = New System.Drawing.Point(396, 351)
        Me.lbl_Total2.Name = "lbl_Total2"
        Me.lbl_Total2.Size = New System.Drawing.Size(388, 33)
        Me.lbl_Total2.TabIndex = 5
        Me.lbl_Total2.Tag = "0/0"
        Me.lbl_Total2.Text = "Total $ 0.00"
        Me.lbl_Total2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Total1
        '
        Me.lbl_Total1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Total1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total1.Location = New System.Drawing.Point(3, 351)
        Me.lbl_Total1.Name = "lbl_Total1"
        Me.lbl_Total1.Size = New System.Drawing.Size(387, 33)
        Me.lbl_Total1.TabIndex = 14
        Me.lbl_Total1.Tag = "0/0"
        Me.lbl_Total1.Text = "Total $ 0.00"
        Me.lbl_Total1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'prg_Caset2
        '
        Me.prg_Caset2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prg_Caset2.Location = New System.Drawing.Point(396, 323)
        Me.prg_Caset2.Name = "prg_Caset2"
        Me.prg_Caset2.Size = New System.Drawing.Size(388, 25)
        Me.prg_Caset2.TabIndex = 13
        '
        'lsv_Datos
        '
        Me.lsv_Datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Datos.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lsv_Datos.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Datos.FullRowSelect = True
        Me.lsv_Datos.HideSelection = False
        Me.lsv_Datos.Location = New System.Drawing.Point(3, 3)
        Me.lsv_Datos.MultiSelect = False
        Me.lsv_Datos.Name = "lsv_Datos"
        Me.lsv_Datos.Size = New System.Drawing.Size(387, 314)
        Me.lsv_Datos.TabIndex = 5
        Me.lsv_Datos.UseCompatibleStateImageBehavior = False
        Me.lsv_Datos.View = System.Windows.Forms.View.Details
        '
        'lsv_Datos2
        '
        Me.lsv_Datos2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Datos2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.lsv_Datos2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Datos2.FullRowSelect = True
        Me.lsv_Datos2.HideSelection = False
        Me.lsv_Datos2.Location = New System.Drawing.Point(396, 3)
        Me.lsv_Datos2.MultiSelect = False
        Me.lsv_Datos2.Name = "lsv_Datos2"
        Me.lsv_Datos2.Size = New System.Drawing.Size(388, 314)
        Me.lsv_Datos2.TabIndex = 4
        Me.lsv_Datos2.UseCompatibleStateImageBehavior = False
        Me.lsv_Datos2.View = System.Windows.Forms.View.Details
        '
        'prg_Caset1
        '
        Me.prg_Caset1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prg_Caset1.Location = New System.Drawing.Point(3, 323)
        Me.prg_Caset1.Name = "prg_Caset1"
        Me.prg_Caset1.Size = New System.Drawing.Size(387, 25)
        Me.prg_Caset1.TabIndex = 12
        '
        'lbl_tmrCerrar
        '
        Me.lbl_tmrCerrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_tmrCerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tmrCerrar.Location = New System.Drawing.Point(380, 9)
        Me.lbl_tmrCerrar.Name = "lbl_tmrCerrar"
        Me.lbl_tmrCerrar.Size = New System.Drawing.Size(69, 72)
        Me.lbl_tmrCerrar.TabIndex = 13
        Me.lbl_tmrCerrar.Text = "TE"
        Me.lbl_tmrCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(685, 8)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(106, 72)
        Me.btn_Cerrar.TabIndex = 9
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'btn_Finalizar
        '
        Me.btn_Finalizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Finalizar.Enabled = False
        Me.btn_Finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Finalizar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Finalizar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Finalizar
        Me.btn_Finalizar.Location = New System.Drawing.Point(573, 8)
        Me.btn_Finalizar.Name = "btn_Finalizar"
        Me.btn_Finalizar.Size = New System.Drawing.Size(106, 72)
        Me.btn_Finalizar.TabIndex = 3
        Me.btn_Finalizar.Text = "Fin"
        Me.btn_Finalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Finalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Finalizar.UseVisualStyleBackColor = False
        '
        'lbl_DepositoP
        '
        Me.lbl_DepositoP.BackColor = System.Drawing.Color.Red
        Me.lbl_DepositoP.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DepositoP.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_DepositoP.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Alert_CashFlow
        Me.lbl_DepositoP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_DepositoP.Location = New System.Drawing.Point(6, 8)
        Me.lbl_DepositoP.Name = "lbl_DepositoP"
        Me.lbl_DepositoP.Size = New System.Drawing.Size(368, 25)
        Me.lbl_DepositoP.TabIndex = 10
        Me.lbl_DepositoP.Text = "    Depósito Pendiente"
        Me.lbl_DepositoP.Visible = False
        '
        'btn_Iniciar
        '
        Me.btn_Iniciar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Iniciar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Iniciar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Inicializar
        Me.btn_Iniciar.Location = New System.Drawing.Point(460, 8)
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.Size = New System.Drawing.Size(106, 72)
        Me.btn_Iniciar.TabIndex = 2
        Me.btn_Iniciar.Text = "Inicio"
        Me.btn_Iniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Iniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Iniciar.UseVisualStyleBackColor = False
        '
        'tmr_depositos
        '
        Me.tmr_depositos.Interval = 1000
        '
        'pnl_Padre
        '
        Me.pnl_Padre.Controls.Add(Me.pct_cargando)
        Me.pnl_Padre.Controls.Add(Me.pnl_General)
        Me.pnl_Padre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Padre.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Padre.Name = "pnl_Padre"
        Me.pnl_Padre.Size = New System.Drawing.Size(800, 480)
        Me.pnl_Padre.TabIndex = 1
        '
        'pct_cargando
        '
        Me.pct_cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pct_cargando.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.cargando
        Me.pct_cargando.InitialImage = Nothing
        Me.pct_cargando.Location = New System.Drawing.Point(333, 205)
        Me.pct_cargando.Name = "pct_cargando"
        Me.pct_cargando.Size = New System.Drawing.Size(129, 105)
        Me.pct_cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pct_cargando.TabIndex = 0
        Me.pct_cargando.TabStop = False
        Me.pct_cargando.Visible = False
        '
        'frm_DepositoXvalidador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_Padre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_DepositoXvalidador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depósitos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.tlp_Lista.ResumeLayout(False)
        Me.pnl_Padre.ResumeLayout(False)
        CType(Me.pct_cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents prg_Caset1 As System.Windows.Forms.ProgressBar
    Friend WithEvents tmr_depositos As System.Windows.Forms.Timer
    Friend WithEvents pnl_Padre As System.Windows.Forms.Panel
    Friend WithEvents lbl_tmrCerrar As System.Windows.Forms.Label
    Friend WithEvents tlp_Lista As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Total2 As System.Windows.Forms.Label
    Friend WithEvents prg_Caset2 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_Total1 As System.Windows.Forms.Label
    Friend WithEvents lsv_Datos2 As System.Windows.Forms.ListView
    Friend WithEvents lbl_Alerta As System.Windows.Forms.Label
    Friend WithEvents lsv_Datos As System.Windows.Forms.ListView
    Friend WithEvents pct_cargando As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Finalizar As Button
    Friend WithEvents btn_Iniciar As Button
    Friend WithEvents lbl_DepositoP As Label
End Class
