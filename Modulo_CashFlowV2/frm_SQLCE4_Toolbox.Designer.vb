<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SQLCE4_Toolbox
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
        Me.pnl_Actualizacion = New System.Windows.Forms.Panel()
        Me.sts_Status = New System.Windows.Forms.StatusStrip()
        Me.tsl_Estatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.spc_Consultas = New System.Windows.Forms.SplitContainer()
        Me.gbx_Consulta = New System.Windows.Forms.GroupBox()
        Me.rtb_Consulta = New System.Windows.Forms.RichTextBox()
        Me.gbx_Result = New System.Windows.Forms.GroupBox()
        Me.lbl_LineaDivisoria = New System.Windows.Forms.Label()
        Me.tbx_Mensajes = New System.Windows.Forms.TextBox()
        Me.lsv_Consulta = New System.Windows.Forms.ListView()
        Me.tls_Botones = New System.Windows.Forms.ToolStrip()
        Me.tsb_Ejecutar = New System.Windows.Forms.ToolStripButton()
        Me.tsb_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.pnl_Actualizacion.SuspendLayout()
        Me.sts_Status.SuspendLayout()
        CType(Me.spc_Consultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spc_Consultas.Panel1.SuspendLayout()
        Me.spc_Consultas.Panel2.SuspendLayout()
        Me.spc_Consultas.SuspendLayout()
        Me.gbx_Consulta.SuspendLayout()
        Me.gbx_Result.SuspendLayout()
        Me.tls_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Actualizacion
        '
        Me.pnl_Actualizacion.Controls.Add(Me.sts_Status)
        Me.pnl_Actualizacion.Controls.Add(Me.spc_Consultas)
        Me.pnl_Actualizacion.Controls.Add(Me.tls_Botones)
        Me.pnl_Actualizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Actualizacion.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Actualizacion.Name = "pnl_Actualizacion"
        Me.pnl_Actualizacion.Size = New System.Drawing.Size(800, 480)
        Me.pnl_Actualizacion.TabIndex = 0
        '
        'sts_Status
        '
        Me.sts_Status.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.sts_Status.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.sts_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsl_Estatus})
        Me.sts_Status.Location = New System.Drawing.Point(0, 454)
        Me.sts_Status.Name = "sts_Status"
        Me.sts_Status.Size = New System.Drawing.Size(800, 26)
        Me.sts_Status.TabIndex = 11
        Me.sts_Status.Text = "StatusStrip1"
        '
        'tsl_Estatus
        '
        Me.tsl_Estatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsl_Estatus.Name = "tsl_Estatus"
        Me.tsl_Estatus.Size = New System.Drawing.Size(34, 21)
        Me.tsl_Estatus.Text = "----"
        '
        'spc_Consultas
        '
        Me.spc_Consultas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spc_Consultas.Location = New System.Drawing.Point(0, 39)
        Me.spc_Consultas.Name = "spc_Consultas"
        Me.spc_Consultas.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spc_Consultas.Panel1
        '
        Me.spc_Consultas.Panel1.Controls.Add(Me.gbx_Consulta)
        '
        'spc_Consultas.Panel2
        '
        Me.spc_Consultas.Panel2.Controls.Add(Me.gbx_Result)
        Me.spc_Consultas.Size = New System.Drawing.Size(788, 412)
        Me.spc_Consultas.SplitterDistance = 74
        Me.spc_Consultas.TabIndex = 10
        '
        'gbx_Consulta
        '
        Me.gbx_Consulta.Controls.Add(Me.rtb_Consulta)
        Me.gbx_Consulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_Consulta.Location = New System.Drawing.Point(0, 0)
        Me.gbx_Consulta.Name = "gbx_Consulta"
        Me.gbx_Consulta.Size = New System.Drawing.Size(788, 74)
        Me.gbx_Consulta.TabIndex = 1
        Me.gbx_Consulta.TabStop = False
        '
        'rtb_Consulta
        '
        Me.rtb_Consulta.AcceptsTab = True
        Me.rtb_Consulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb_Consulta.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtb_Consulta.Location = New System.Drawing.Point(3, 16)
        Me.rtb_Consulta.Name = "rtb_Consulta"
        Me.rtb_Consulta.Size = New System.Drawing.Size(782, 55)
        Me.rtb_Consulta.TabIndex = 0
        Me.rtb_Consulta.Text = ""
        Me.rtb_Consulta.WordWrap = False
        '
        'gbx_Result
        '
        Me.gbx_Result.Controls.Add(Me.lbl_LineaDivisoria)
        Me.gbx_Result.Controls.Add(Me.tbx_Mensajes)
        Me.gbx_Result.Controls.Add(Me.lsv_Consulta)
        Me.gbx_Result.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_Result.Location = New System.Drawing.Point(0, 0)
        Me.gbx_Result.Name = "gbx_Result"
        Me.gbx_Result.Size = New System.Drawing.Size(788, 334)
        Me.gbx_Result.TabIndex = 1
        Me.gbx_Result.TabStop = False
        '
        'lbl_LineaDivisoria
        '
        Me.lbl_LineaDivisoria.AutoSize = True
        Me.lbl_LineaDivisoria.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LineaDivisoria.ForeColor = System.Drawing.Color.Red
        Me.lbl_LineaDivisoria.Location = New System.Drawing.Point(290, -3)
        Me.lbl_LineaDivisoria.Name = "lbl_LineaDivisoria"
        Me.lbl_LineaDivisoria.Size = New System.Drawing.Size(200, 16)
        Me.lbl_LineaDivisoria.TabIndex = 0
        Me.lbl_LineaDivisoria.Text = "------------------------"
        '
        'tbx_Mensajes
        '
        Me.tbx_Mensajes.AcceptsReturn = True
        Me.tbx_Mensajes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbx_Mensajes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbx_Mensajes.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Mensajes.ForeColor = System.Drawing.Color.Red
        Me.tbx_Mensajes.Location = New System.Drawing.Point(3, 16)
        Me.tbx_Mensajes.Multiline = True
        Me.tbx_Mensajes.Name = "tbx_Mensajes"
        Me.tbx_Mensajes.ReadOnly = True
        Me.tbx_Mensajes.Size = New System.Drawing.Size(782, 315)
        Me.tbx_Mensajes.TabIndex = 1
        '
        'lsv_Consulta
        '
        Me.lsv_Consulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsv_Consulta.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Consulta.FullRowSelect = True
        Me.lsv_Consulta.GridLines = True
        Me.lsv_Consulta.HideSelection = False
        Me.lsv_Consulta.Location = New System.Drawing.Point(3, 16)
        Me.lsv_Consulta.MultiSelect = False
        Me.lsv_Consulta.Name = "lsv_Consulta"
        Me.lsv_Consulta.Size = New System.Drawing.Size(782, 315)
        Me.lsv_Consulta.TabIndex = 0
        Me.lsv_Consulta.UseCompatibleStateImageBehavior = False
        Me.lsv_Consulta.View = System.Windows.Forms.View.Details
        '
        'tls_Botones
        '
        Me.tls_Botones.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.tls_Botones.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tls_Botones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_Ejecutar, Me.tsb_Cerrar})
        Me.tls_Botones.Location = New System.Drawing.Point(0, 0)
        Me.tls_Botones.Name = "tls_Botones"
        Me.tls_Botones.Size = New System.Drawing.Size(800, 39)
        Me.tls_Botones.TabIndex = 8
        Me.tls_Botones.Text = "ToolStrip1"
        '
        'tsb_Ejecutar
        '
        Me.tsb_Ejecutar.BackColor = System.Drawing.Color.Silver
        Me.tsb_Ejecutar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Execute
        Me.tsb_Ejecutar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Ejecutar.Name = "tsb_Ejecutar"
        Me.tsb_Ejecutar.Size = New System.Drawing.Size(88, 36)
        Me.tsb_Ejecutar.Text = "Ejecutar "
        '
        'tsb_Cerrar
        '
        Me.tsb_Cerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsb_Cerrar.BackColor = System.Drawing.Color.Gray
        Me.tsb_Cerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsb_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.tsb_Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_Cerrar.Name = "tsb_Cerrar"
        Me.tsb_Cerrar.Size = New System.Drawing.Size(36, 36)
        Me.tsb_Cerrar.Text = "Cerrar"
        '
        'frm_SQLCE4_Toolbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_Actualizacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_SQLCE4_Toolbox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Herramienta para alterar la Base de Datos SQL Compact 4.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Actualizacion.ResumeLayout(False)
        Me.pnl_Actualizacion.PerformLayout()
        Me.sts_Status.ResumeLayout(False)
        Me.sts_Status.PerformLayout()
        Me.spc_Consultas.Panel1.ResumeLayout(False)
        Me.spc_Consultas.Panel2.ResumeLayout(False)
        CType(Me.spc_Consultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spc_Consultas.ResumeLayout(False)
        Me.gbx_Consulta.ResumeLayout(False)
        Me.gbx_Result.ResumeLayout(False)
        Me.gbx_Result.PerformLayout()
        Me.tls_Botones.ResumeLayout(False)
        Me.tls_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Actualizacion As System.Windows.Forms.Panel
    Friend WithEvents tls_Botones As System.Windows.Forms.ToolStrip
    Friend WithEvents tsb_Ejecutar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_Cerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents spc_Consultas As System.Windows.Forms.SplitContainer
    Friend WithEvents rtb_Consulta As System.Windows.Forms.RichTextBox
    Friend WithEvents lbl_LineaDivisoria As System.Windows.Forms.Label
    Friend WithEvents gbx_Consulta As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_Result As System.Windows.Forms.GroupBox
    Friend WithEvents lsv_Consulta As System.Windows.Forms.ListView
    Friend WithEvents sts_Status As System.Windows.Forms.StatusStrip
    Friend WithEvents tsl_Estatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbx_Mensajes As System.Windows.Forms.TextBox
End Class
