<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Tablas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Tablas))
        Me.pnl_Tablas = New System.Windows.Forms.Panel()
        Me.btn_Limpiar = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lsv_Tablas = New System.Windows.Forms.ListView()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.pnl_Tablas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Tablas
        '
        Me.pnl_Tablas.Controls.Add(Me.btn_Limpiar)
        Me.pnl_Tablas.Controls.Add(Me.btn_Cerrar)
        Me.pnl_Tablas.Controls.Add(Me.lsv_Tablas)
        Me.pnl_Tablas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Tablas.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Tablas.Name = "pnl_Tablas"
        Me.pnl_Tablas.Size = New System.Drawing.Size(800, 480)
        Me.pnl_Tablas.TabIndex = 0
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Limpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Limpiar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_EliminarCaset
        Me.btn_Limpiar.Location = New System.Drawing.Point(12, 400)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Limpiar.TabIndex = 12
        Me.btn_Limpiar.Text = "&Limpiar"
        Me.btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Limpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(624, 400)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 11
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lsv_Tablas
        '
        Me.lsv_Tablas.AllowColumnReorder = True
        Me.lsv_Tablas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Tablas.CheckBoxes = True
        Me.lsv_Tablas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Tablas.FullRowSelect = True
        Me.lsv_Tablas.HideSelection = False
        Me.lsv_Tablas.Location = New System.Drawing.Point(12, 12)
        Me.lsv_Tablas.MultiSelect = False
        Me.lsv_Tablas.Name = "lsv_Tablas"
        Me.lsv_Tablas.Size = New System.Drawing.Size(776, 382)
        Me.lsv_Tablas.TabIndex = 9
        Me.lsv_Tablas.UseCompatibleStateImageBehavior = False
        Me.lsv_Tablas.View = System.Windows.Forms.View.Details
        '
        'iml_Sincronia
        '
        Me.iml_Sincronia.ImageStream = CType(resources.GetObject("iml_Sincronia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Sincronia.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Sincronia.Images.SetKeyName(0, "Correcto.png")
        Me.iml_Sincronia.Images.SetKeyName(1, "Pendiente.png")
        '
        'frm_Tablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_Tablas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Tablas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Casets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Tablas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents pnl_Tablas As System.Windows.Forms.Panel
    Friend WithEvents lsv_Tablas As System.Windows.Forms.ListView
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents iml_Sincronia As System.Windows.Forms.ImageList
End Class
