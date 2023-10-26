<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RespaldarenWeb
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
        Me.lbl_porcientoUp = New System.Windows.Forms.Label()
        Me.pgr_Subiendo = New System.Windows.Forms.ProgressBar()
        Me.btn_SubirArchivo = New System.Windows.Forms.Button()
        Me.gbx_Destino = New System.Windows.Forms.GroupBox()
        Me.lbl_Destino = New System.Windows.Forms.Label()
        Me.gbx_Origen = New System.Windows.Forms.GroupBox()
        Me.lbl_RutaBdd = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lbl_Info = New System.Windows.Forms.Label()
        Me.pnl_General.SuspendLayout()
        Me.gbx_Destino.SuspendLayout()
        Me.gbx_Origen.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.lbl_porcientoUp)
        Me.pnl_General.Controls.Add(Me.pgr_Subiendo)
        Me.pnl_General.Controls.Add(Me.btn_SubirArchivo)
        Me.pnl_General.Controls.Add(Me.gbx_Destino)
        Me.pnl_General.Controls.Add(Me.gbx_Origen)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.lbl_Info)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'lbl_porcientoUp
        '
        Me.lbl_porcientoUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_porcientoUp.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_porcientoUp.Location = New System.Drawing.Point(12, 318)
        Me.lbl_porcientoUp.Name = "lbl_porcientoUp"
        Me.lbl_porcientoUp.Size = New System.Drawing.Size(776, 27)
        Me.lbl_porcientoUp.TabIndex = 3
        Me.lbl_porcientoUp.Text = "0%"
        Me.lbl_porcientoUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgr_Subiendo
        '
        Me.pgr_Subiendo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgr_Subiendo.Location = New System.Drawing.Point(12, 348)
        Me.pgr_Subiendo.Name = "pgr_Subiendo"
        Me.pgr_Subiendo.Size = New System.Drawing.Size(776, 42)
        Me.pgr_Subiendo.TabIndex = 4
        '
        'btn_SubirArchivo
        '
        Me.btn_SubirArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_SubirArchivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_SubirArchivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_SubirArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SubirArchivo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SubirArchivo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_SubirArchivo
        Me.btn_SubirArchivo.Location = New System.Drawing.Point(7, 400)
        Me.btn_SubirArchivo.Name = "btn_SubirArchivo"
        Me.btn_SubirArchivo.Size = New System.Drawing.Size(164, 75)
        Me.btn_SubirArchivo.TabIndex = 5
        Me.btn_SubirArchivo.Tag = ""
        Me.btn_SubirArchivo.Text = "Subir Archivo"
        Me.btn_SubirArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_SubirArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_SubirArchivo.UseVisualStyleBackColor = False
        '
        'gbx_Destino
        '
        Me.gbx_Destino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Destino.Controls.Add(Me.lbl_Destino)
        Me.gbx_Destino.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Destino.Location = New System.Drawing.Point(12, 186)
        Me.gbx_Destino.Name = "gbx_Destino"
        Me.gbx_Destino.Size = New System.Drawing.Size(781, 103)
        Me.gbx_Destino.TabIndex = 2
        Me.gbx_Destino.TabStop = False
        Me.gbx_Destino.Text = "A:"
        '
        'lbl_Destino
        '
        Me.lbl_Destino.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Destino.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Destino.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lbl_Destino.Location = New System.Drawing.Point(6, 32)
        Me.lbl_Destino.Name = "lbl_Destino"
        Me.lbl_Destino.Size = New System.Drawing.Size(769, 59)
        Me.lbl_Destino.TabIndex = 0
        Me.lbl_Destino.Text = "...Destino ftp"
        '
        'gbx_Origen
        '
        Me.gbx_Origen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Origen.Controls.Add(Me.lbl_RutaBdd)
        Me.gbx_Origen.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Origen.Location = New System.Drawing.Point(12, 73)
        Me.gbx_Origen.Name = "gbx_Origen"
        Me.gbx_Origen.Size = New System.Drawing.Size(781, 100)
        Me.gbx_Origen.TabIndex = 1
        Me.gbx_Origen.TabStop = False
        Me.gbx_Origen.Text = "Copiar de: "
        '
        'lbl_RutaBdd
        '
        Me.lbl_RutaBdd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_RutaBdd.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RutaBdd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_RutaBdd.Location = New System.Drawing.Point(6, 33)
        Me.lbl_RutaBdd.Name = "lbl_RutaBdd"
        Me.lbl_RutaBdd.Size = New System.Drawing.Size(769, 52)
        Me.lbl_RutaBdd.TabIndex = 0
        Me.lbl_RutaBdd.Text = "Base de Datos Local .sdf"
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(629, 400)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 6
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'lbl_Info
        '
        Me.lbl_Info.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_Info.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Info.Location = New System.Drawing.Point(7, 9)
        Me.lbl_Info.Name = "lbl_Info"
        Me.lbl_Info.Size = New System.Drawing.Size(786, 36)
        Me.lbl_Info.TabIndex = 0
        Me.lbl_Info.Text = "Respaldar  base de datos local a FTP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_RespaldarenWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_RespaldarenWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respaldar bdd a Web"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.gbx_Destino.ResumeLayout(False)
        Me.gbx_Origen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lbl_Info As System.Windows.Forms.Label
    Friend WithEvents lbl_RutaBdd As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents gbx_Origen As System.Windows.Forms.GroupBox
    Friend WithEvents btn_SubirArchivo As System.Windows.Forms.Button
    Friend WithEvents gbx_Destino As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Destino As System.Windows.Forms.Label
    Friend WithEvents lbl_porcientoUp As System.Windows.Forms.Label
    Friend WithEvents pgr_Subiendo As System.Windows.Forms.ProgressBar
End Class
