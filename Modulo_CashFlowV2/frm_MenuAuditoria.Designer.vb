<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MenuAuditoria
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
        Me.tbLP_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_ConsultaLog = New System.Windows.Forms.Button()
        Me.btn_Parametros = New System.Windows.Forms.Button()
        Me.btn_ConsultaUsuario = New System.Windows.Forms.Button()
        Me.btn_Privilegios = New System.Windows.Forms.Button()
        Me.btn_EscanearPuerto = New System.Windows.Forms.Button()
        Me.btn_Denominaciones = New System.Windows.Forms.Button()
        Me.btn_Monedas = New System.Windows.Forms.Button()
        Me.btn_CatalogoCaset = New System.Windows.Forms.Button()
        Me.btn_ExitApp = New System.Windows.Forms.Button()
        Me.Btn_resetear = New System.Windows.Forms.Button()
        Me.btn_CerrarSesion = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.tbLP_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.tbLP_Botones)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'tbLP_Botones
        '
        Me.tbLP_Botones.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.tbLP_Botones.ColumnCount = 4
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.Controls.Add(Me.btn_ConsultaLog, 1, 0)
        Me.tbLP_Botones.Controls.Add(Me.btn_Parametros, 0, 0)
        Me.tbLP_Botones.Controls.Add(Me.btn_ConsultaUsuario, 2, 0)
        Me.tbLP_Botones.Controls.Add(Me.btn_Privilegios, 3, 0)
        Me.tbLP_Botones.Controls.Add(Me.btn_EscanearPuerto, 0, 1)
        Me.tbLP_Botones.Controls.Add(Me.btn_Denominaciones, 3, 1)
        Me.tbLP_Botones.Controls.Add(Me.btn_Monedas, 2, 1)
        Me.tbLP_Botones.Controls.Add(Me.btn_CatalogoCaset, 1, 1)
        Me.tbLP_Botones.Controls.Add(Me.btn_ExitApp, 3, 2)
        Me.tbLP_Botones.Controls.Add(Me.Btn_resetear, 2, 2)
        Me.tbLP_Botones.Controls.Add(Me.Button1, 1, 2)
        Me.tbLP_Botones.Controls.Add(Me.btn_CerrarSesion, 0, 2)
        Me.tbLP_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbLP_Botones.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLP_Botones.Location = New System.Drawing.Point(0, 0)
        Me.tbLP_Botones.Name = "tbLP_Botones"
        Me.tbLP_Botones.RowCount = 5
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tbLP_Botones.Size = New System.Drawing.Size(800, 480)
        Me.tbLP_Botones.TabIndex = 22
        '
        'btn_ConsultaLog
        '
        Me.btn_ConsultaLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ConsultaLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_ConsultaLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ConsultaLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ConsultaLog.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ConsultaLog.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Auditoria
        Me.btn_ConsultaLog.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ConsultaLog.Location = New System.Drawing.Point(203, 4)
        Me.btn_ConsultaLog.Name = "btn_ConsultaLog"
        Me.btn_ConsultaLog.Size = New System.Drawing.Size(194, 88)
        Me.btn_ConsultaLog.TabIndex = 1
        Me.btn_ConsultaLog.Text = "Auditoría"
        Me.btn_ConsultaLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ConsultaLog.UseVisualStyleBackColor = False
        '
        'btn_Parametros
        '
        Me.btn_Parametros.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Parametros.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Parametros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Parametros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Parametros.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Parametros.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Parametros
        Me.btn_Parametros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Parametros.Location = New System.Drawing.Point(3, 4)
        Me.btn_Parametros.Name = "btn_Parametros"
        Me.btn_Parametros.Size = New System.Drawing.Size(194, 88)
        Me.btn_Parametros.TabIndex = 2
        Me.btn_Parametros.Text = "&Parámetros"
        Me.btn_Parametros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Parametros.UseVisualStyleBackColor = False
        '
        'btn_ConsultaUsuario
        '
        Me.btn_ConsultaUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ConsultaUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_ConsultaUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ConsultaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ConsultaUsuario.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ConsultaUsuario.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_ConsultaUsuarios
        Me.btn_ConsultaUsuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ConsultaUsuario.Location = New System.Drawing.Point(403, 4)
        Me.btn_ConsultaUsuario.Name = "btn_ConsultaUsuario"
        Me.btn_ConsultaUsuario.Size = New System.Drawing.Size(194, 88)
        Me.btn_ConsultaUsuario.TabIndex = 19
        Me.btn_ConsultaUsuario.Text = "Usuarios"
        Me.btn_ConsultaUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ConsultaUsuario.UseVisualStyleBackColor = False
        '
        'btn_Privilegios
        '
        Me.btn_Privilegios.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Privilegios.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Privilegios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Privilegios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Privilegios.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Privilegios.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Privilegios
        Me.btn_Privilegios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Privilegios.Location = New System.Drawing.Point(603, 4)
        Me.btn_Privilegios.Name = "btn_Privilegios"
        Me.btn_Privilegios.Size = New System.Drawing.Size(194, 88)
        Me.btn_Privilegios.TabIndex = 16
        Me.btn_Privilegios.Text = "Privilegios"
        Me.btn_Privilegios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Privilegios.UseVisualStyleBackColor = False
        '
        'btn_EscanearPuerto
        '
        Me.btn_EscanearPuerto.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_EscanearPuerto.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_EscanearPuerto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_EscanearPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EscanearPuerto.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EscanearPuerto.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Escanear
        Me.btn_EscanearPuerto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_EscanearPuerto.Location = New System.Drawing.Point(3, 100)
        Me.btn_EscanearPuerto.Name = "btn_EscanearPuerto"
        Me.btn_EscanearPuerto.Size = New System.Drawing.Size(194, 88)
        Me.btn_EscanearPuerto.TabIndex = 58
        Me.btn_EscanearPuerto.Text = "Escanear Puertos"
        Me.btn_EscanearPuerto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_EscanearPuerto.UseVisualStyleBackColor = False
        '
        'btn_Denominaciones
        '
        Me.btn_Denominaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Denominaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Denominaciones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Denominaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Denominaciones.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Denominaciones.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Pesos
        Me.btn_Denominaciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Denominaciones.Location = New System.Drawing.Point(603, 100)
        Me.btn_Denominaciones.Name = "btn_Denominaciones"
        Me.btn_Denominaciones.Size = New System.Drawing.Size(194, 88)
        Me.btn_Denominaciones.TabIndex = 21
        Me.btn_Denominaciones.Text = "D&enominaciones"
        Me.btn_Denominaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Denominaciones.UseVisualStyleBackColor = False
        '
        'btn_Monedas
        '
        Me.btn_Monedas.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Monedas.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Monedas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Monedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Monedas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Monedas.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Dollar
        Me.btn_Monedas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Monedas.Location = New System.Drawing.Point(403, 100)
        Me.btn_Monedas.Name = "btn_Monedas"
        Me.btn_Monedas.Size = New System.Drawing.Size(194, 88)
        Me.btn_Monedas.TabIndex = 20
        Me.btn_Monedas.Text = "&Monedas"
        Me.btn_Monedas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Monedas.UseVisualStyleBackColor = False
        '
        'btn_CatalogoCaset
        '
        Me.btn_CatalogoCaset.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CatalogoCaset.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_CatalogoCaset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CatalogoCaset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CatalogoCaset.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CatalogoCaset.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CatalogoCaset
        Me.btn_CatalogoCaset.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_CatalogoCaset.Location = New System.Drawing.Point(203, 100)
        Me.btn_CatalogoCaset.Name = "btn_CatalogoCaset"
        Me.btn_CatalogoCaset.Size = New System.Drawing.Size(194, 88)
        Me.btn_CatalogoCaset.TabIndex = 18
        Me.btn_CatalogoCaset.Text = "Cartuchos"
        Me.btn_CatalogoCaset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_CatalogoCaset.UseVisualStyleBackColor = False
        '
        'btn_ExitApp
        '
        Me.btn_ExitApp.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ExitApp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_ExitApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ExitApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ExitApp.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ExitApp.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarAplicacion
        Me.btn_ExitApp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ExitApp.Location = New System.Drawing.Point(603, 196)
        Me.btn_ExitApp.Name = "btn_ExitApp"
        Me.btn_ExitApp.Size = New System.Drawing.Size(194, 88)
        Me.btn_ExitApp.TabIndex = 15
        Me.btn_ExitApp.Text = "Salir de Apli&cacion"
        Me.btn_ExitApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ExitApp.UseVisualStyleBackColor = False
        '
        'Btn_resetear
        '
        Me.Btn_resetear.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_resetear.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Btn_resetear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Btn_resetear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_resetear.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_resetear.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Cerradura
        Me.Btn_resetear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_resetear.Location = New System.Drawing.Point(403, 196)
        Me.Btn_resetear.Name = "Btn_resetear"
        Me.Btn_resetear.Size = New System.Drawing.Size(194, 88)
        Me.Btn_resetear.TabIndex = 59
        Me.Btn_resetear.Text = "&Resetear"
        Me.Btn_resetear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Btn_resetear.UseVisualStyleBackColor = False
        '
        'btn_CerrarSesion
        '
        Me.btn_CerrarSesion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CerrarSesion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_CerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CerrarSesion.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CerrarSesion.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_CerrarSesion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_CerrarSesion.Location = New System.Drawing.Point(3, 196)
        Me.btn_CerrarSesion.Name = "btn_CerrarSesion"
        Me.btn_CerrarSesion.Size = New System.Drawing.Size(194, 88)
        Me.btn_CerrarSesion.TabIndex = 22
        Me.btn_CerrarSesion.Text = "&Cerrar Sesión"
        Me.btn_CerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_CerrarSesion.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Detalle
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(203, 196)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 88)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "Tickets"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frm_MenuAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_MenuAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.tbLP_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents tbLP_Botones As TableLayoutPanel
    Friend WithEvents btn_ConsultaLog As Button
    Friend WithEvents btn_Parametros As Button
    Friend WithEvents btn_ConsultaUsuario As Button
    Friend WithEvents btn_ExitApp As Button
    Friend WithEvents btn_CerrarSesion As Button
    Friend WithEvents btn_Privilegios As Button
    Friend WithEvents btn_EscanearPuerto As Button
    Friend WithEvents btn_Denominaciones As Button
    Friend WithEvents btn_Monedas As Button
    Friend WithEvents btn_CatalogoCaset As Button
    Friend WithEvents Btn_resetear As Button
    Friend WithEvents Button1 As Button
End Class
