<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_BuscarActualizar
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
        Me.lbl_porcientoDown = New System.Windows.Forms.Label()
        Me.pgr_Descargando = New System.Windows.Forms.ProgressBar()
        Me.tmr_depositos = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_Padre = New System.Windows.Forms.Panel()
        Me.pnl_General.SuspendLayout()
        Me.pnl_Padre.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.lbl_porcientoDown)
        Me.pnl_General.Controls.Add(Me.pgr_Descargando)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'lbl_porcientoDown
        '
        Me.lbl_porcientoDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_porcientoDown.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_porcientoDown.Location = New System.Drawing.Point(190, 204)
        Me.lbl_porcientoDown.Name = "lbl_porcientoDown"
        Me.lbl_porcientoDown.Size = New System.Drawing.Size(420, 27)
        Me.lbl_porcientoDown.TabIndex = 56
        Me.lbl_porcientoDown.Text = "0%"
        Me.lbl_porcientoDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgr_Descargando
        '
        Me.pgr_Descargando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgr_Descargando.Location = New System.Drawing.Point(190, 234)
        Me.pgr_Descargando.Name = "pgr_Descargando"
        Me.pgr_Descargando.Size = New System.Drawing.Size(420, 42)
        Me.pgr_Descargando.TabIndex = 55
        '
        'tmr_depositos
        '
        Me.tmr_depositos.Interval = 1000
        '
        'pnl_Padre
        '
        Me.pnl_Padre.Controls.Add(Me.pnl_General)
        Me.pnl_Padre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Padre.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Padre.Name = "pnl_Padre"
        Me.pnl_Padre.Size = New System.Drawing.Size(800, 480)
        Me.pnl_Padre.TabIndex = 1
        '
        'frm_BuscarActualizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_Padre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_BuscarActualizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Sistema"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_Padre.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents tmr_depositos As System.Windows.Forms.Timer
    Friend WithEvents pnl_Padre As System.Windows.Forms.Panel
    Friend WithEvents lbl_porcientoDown As System.Windows.Forms.Label
    Friend WithEvents pgr_Descargando As System.Windows.Forms.ProgressBar

End Class
