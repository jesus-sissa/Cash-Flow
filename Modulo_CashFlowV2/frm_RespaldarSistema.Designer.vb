<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_RespaldarSistema
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
        Me.btn_Copiar = New System.Windows.Forms.Button()
        Me.gbx_Destino = New System.Windows.Forms.GroupBox()
        Me.lbl_Destino = New System.Windows.Forms.Label()
        Me.gbx_Origen = New System.Windows.Forms.GroupBox()
        Me.lbl_RutaInstalacion = New System.Windows.Forms.Label()
        Me.lbl_RutaLogs = New System.Windows.Forms.Label()
        Me.btn_Destino = New System.Windows.Forms.Button()
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
        Me.pnl_General.Controls.Add(Me.btn_Copiar)
        Me.pnl_General.Controls.Add(Me.gbx_Destino)
        Me.pnl_General.Controls.Add(Me.gbx_Origen)
        Me.pnl_General.Controls.Add(Me.btn_Destino)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.lbl_Info)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'btn_Copiar
        '
        Me.btn_Copiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Copiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Copiar.Enabled = False
        Me.btn_Copiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Copiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Copiar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Copiar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.copy
        Me.btn_Copiar.Location = New System.Drawing.Point(182, 400)
        Me.btn_Copiar.Name = "btn_Copiar"
        Me.btn_Copiar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Copiar.TabIndex = 8
        Me.btn_Copiar.Tag = ""
        Me.btn_Copiar.Text = "Copiar"
        Me.btn_Copiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Copiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Copiar.UseVisualStyleBackColor = False
        '
        'gbx_Destino
        '
        Me.gbx_Destino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Destino.Controls.Add(Me.lbl_Destino)
        Me.gbx_Destino.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Destino.Location = New System.Drawing.Point(12, 252)
        Me.gbx_Destino.Name = "gbx_Destino"
        Me.gbx_Destino.Size = New System.Drawing.Size(781, 111)
        Me.gbx_Destino.TabIndex = 7
        Me.gbx_Destino.TabStop = False
        Me.gbx_Destino.Text = "A:"
        '
        'lbl_Destino
        '
        Me.lbl_Destino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Destino.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Destino.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lbl_Destino.Location = New System.Drawing.Point(6, 35)
        Me.lbl_Destino.Name = "lbl_Destino"
        Me.lbl_Destino.Size = New System.Drawing.Size(769, 59)
        Me.lbl_Destino.TabIndex = 1
        Me.lbl_Destino.Text = "...Sin Destino..."
        '
        'gbx_Origen
        '
        Me.gbx_Origen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Origen.Controls.Add(Me.lbl_RutaInstalacion)
        Me.gbx_Origen.Controls.Add(Me.lbl_RutaLogs)
        Me.gbx_Origen.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_Origen.Location = New System.Drawing.Point(12, 80)
        Me.gbx_Origen.Name = "gbx_Origen"
        Me.gbx_Origen.Size = New System.Drawing.Size(781, 143)
        Me.gbx_Origen.TabIndex = 6
        Me.gbx_Origen.TabStop = False
        Me.gbx_Origen.Text = "Copiar de: "
        '
        'lbl_RutaInstalacion
        '
        Me.lbl_RutaInstalacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_RutaInstalacion.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RutaInstalacion.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_RutaInstalacion.Location = New System.Drawing.Point(6, 32)
        Me.lbl_RutaInstalacion.Name = "lbl_RutaInstalacion"
        Me.lbl_RutaInstalacion.Size = New System.Drawing.Size(769, 54)
        Me.lbl_RutaInstalacion.TabIndex = 1
        Me.lbl_RutaInstalacion.Text = "Carpeta Instalación"
        '
        'lbl_RutaLogs
        '
        Me.lbl_RutaLogs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_RutaLogs.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RutaLogs.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lbl_RutaLogs.Location = New System.Drawing.Point(6, 89)
        Me.lbl_RutaLogs.Name = "lbl_RutaLogs"
        Me.lbl_RutaLogs.Size = New System.Drawing.Size(769, 49)
        Me.lbl_RutaLogs.TabIndex = 2
        Me.lbl_RutaLogs.Text = "Carpeta Logs"
        '
        'btn_Destino
        '
        Me.btn_Destino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Destino.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Destino.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Destino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Destino.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Destino.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Examinar
        Me.btn_Destino.Location = New System.Drawing.Point(12, 400)
        Me.btn_Destino.Name = "btn_Destino"
        Me.btn_Destino.Size = New System.Drawing.Size(164, 75)
        Me.btn_Destino.TabIndex = 4
        Me.btn_Destino.Tag = ""
        Me.btn_Destino.Text = "Destino"
        Me.btn_Destino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Destino.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Destino.UseVisualStyleBackColor = False
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
        Me.btn_Cerrar.TabIndex = 5
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'lbl_Info
        '
        Me.lbl_Info.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Info.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Info.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Info.Name = "lbl_Info"
        Me.lbl_Info.Size = New System.Drawing.Size(776, 36)
        Me.lbl_Info.TabIndex = 0
        Me.lbl_Info.Text = "Respaldar Carpeta de Instalación y Carpeta Logs"
        '
        'frm_RespaldarSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_RespaldarSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respaldar Sistema"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.gbx_Destino.ResumeLayout(False)
        Me.gbx_Origen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lbl_Info As System.Windows.Forms.Label
    Friend WithEvents lbl_RutaLogs As System.Windows.Forms.Label
    Friend WithEvents lbl_RutaInstalacion As System.Windows.Forms.Label
    Friend WithEvents btn_Destino As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents gbx_Origen As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Copiar As System.Windows.Forms.Button
    Friend WithEvents gbx_Destino As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Destino As System.Windows.Forms.Label
End Class
