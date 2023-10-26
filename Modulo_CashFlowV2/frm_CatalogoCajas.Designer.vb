<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CatalogoCajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CatalogoCajas))
        Me.pnl_Cajas = New System.Windows.Forms.Panel()
        Me.tbx_IpCaja = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsv_Cajas = New System.Windows.Forms.ListView()
        Me.tbx_DescripcionCaja = New System.Windows.Forms.TextBox()
        Me.tbx_NumeroCaja = New System.Windows.Forms.TextBox()
        Me.lbl_DescripcionCaja = New System.Windows.Forms.Label()
        Me.lbl_NumeroCaja = New System.Windows.Forms.Label()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Editar = New System.Windows.Forms.Button()
        Me.btn_EliminarCaja = New System.Windows.Forms.Button()
        Me.btn_CambiarStatusCaja = New System.Windows.Forms.Button()
        Me.btn_CerrarCaja = New System.Windows.Forms.Button()
        Me.btn_AgregarCaja = New System.Windows.Forms.Button()
        Me.pnl_Cajas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Cajas
        '
        Me.pnl_Cajas.Controls.Add(Me.btn_Editar)
        Me.pnl_Cajas.Controls.Add(Me.tbx_IpCaja)
        Me.pnl_Cajas.Controls.Add(Me.Label1)
        Me.pnl_Cajas.Controls.Add(Me.lsv_Cajas)
        Me.pnl_Cajas.Controls.Add(Me.btn_EliminarCaja)
        Me.pnl_Cajas.Controls.Add(Me.btn_CambiarStatusCaja)
        Me.pnl_Cajas.Controls.Add(Me.btn_CerrarCaja)
        Me.pnl_Cajas.Controls.Add(Me.btn_AgregarCaja)
        Me.pnl_Cajas.Controls.Add(Me.tbx_DescripcionCaja)
        Me.pnl_Cajas.Controls.Add(Me.tbx_NumeroCaja)
        Me.pnl_Cajas.Controls.Add(Me.lbl_DescripcionCaja)
        Me.pnl_Cajas.Controls.Add(Me.lbl_NumeroCaja)
        Me.pnl_Cajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Cajas.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Cajas.Name = "pnl_Cajas"
        Me.pnl_Cajas.Size = New System.Drawing.Size(800, 480)
        Me.pnl_Cajas.TabIndex = 0
        '
        'tbx_IpCaja
        '
        Me.tbx_IpCaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_IpCaja.Location = New System.Drawing.Point(213, 75)
        Me.tbx_IpCaja.MaxLength = 15
        Me.tbx_IpCaja.Name = "tbx_IpCaja"
        Me.tbx_IpCaja.Size = New System.Drawing.Size(150, 26)
        Me.tbx_IpCaja.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(90, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 31)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Ip Caja"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lsv_Cajas
        '
        Me.lsv_Cajas.AllowColumnReorder = True
        Me.lsv_Cajas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Cajas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Cajas.FullRowSelect = True
        Me.lsv_Cajas.HideSelection = False
        Me.lsv_Cajas.Location = New System.Drawing.Point(12, 131)
        Me.lsv_Cajas.MultiSelect = False
        Me.lsv_Cajas.Name = "lsv_Cajas"
        Me.lsv_Cajas.Size = New System.Drawing.Size(776, 240)
        Me.lsv_Cajas.TabIndex = 16
        Me.lsv_Cajas.UseCompatibleStateImageBehavior = False
        Me.lsv_Cajas.View = System.Windows.Forms.View.Details
        '
        'tbx_DescripcionCaja
        '
        Me.tbx_DescripcionCaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_DescripcionCaja.Location = New System.Drawing.Point(213, 39)
        Me.tbx_DescripcionCaja.MaxLength = 17
        Me.tbx_DescripcionCaja.Name = "tbx_DescripcionCaja"
        Me.tbx_DescripcionCaja.Size = New System.Drawing.Size(274, 26)
        Me.tbx_DescripcionCaja.TabIndex = 9
        '
        'tbx_NumeroCaja
        '
        Me.tbx_NumeroCaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_NumeroCaja.Location = New System.Drawing.Point(213, 4)
        Me.tbx_NumeroCaja.MaxLength = 6
        Me.tbx_NumeroCaja.Name = "tbx_NumeroCaja"
        Me.tbx_NumeroCaja.Size = New System.Drawing.Size(150, 26)
        Me.tbx_NumeroCaja.TabIndex = 8
        '
        'lbl_DescripcionCaja
        '
        Me.lbl_DescripcionCaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DescripcionCaja.Location = New System.Drawing.Point(58, 42)
        Me.lbl_DescripcionCaja.Name = "lbl_DescripcionCaja"
        Me.lbl_DescripcionCaja.Size = New System.Drawing.Size(149, 31)
        Me.lbl_DescripcionCaja.TabIndex = 6
        Me.lbl_DescripcionCaja.Text = "Descripcion"
        Me.lbl_DescripcionCaja.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_NumeroCaja
        '
        Me.lbl_NumeroCaja.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NumeroCaja.Location = New System.Drawing.Point(90, 7)
        Me.lbl_NumeroCaja.Name = "lbl_NumeroCaja"
        Me.lbl_NumeroCaja.Size = New System.Drawing.Size(117, 31)
        Me.lbl_NumeroCaja.TabIndex = 5
        Me.lbl_NumeroCaja.Text = "Clave Caja"
        Me.lbl_NumeroCaja.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'iml_Sincronia
        '
        Me.iml_Sincronia.ImageStream = CType(resources.GetObject("iml_Sincronia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Sincronia.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Sincronia.Images.SetKeyName(0, "Correcto.png")
        Me.iml_Sincronia.Images.SetKeyName(1, "Pendiente.png")
        '
        'btn_Editar
        '
        Me.btn_Editar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Editar.Enabled = False
        Me.btn_Editar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Editar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_EliminarCaset
        Me.btn_Editar.Location = New System.Drawing.Point(186, 402)
        Me.btn_Editar.Name = "btn_Editar"
        Me.btn_Editar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btn_Editar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Editar.TabIndex = 19
        Me.btn_Editar.Text = "&Editar"
        Me.btn_Editar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Editar.UseVisualStyleBackColor = True
        '
        'btn_EliminarCaja
        '
        Me.btn_EliminarCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_EliminarCaja.Enabled = False
        Me.btn_EliminarCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_EliminarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EliminarCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EliminarCaja.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_EliminarCaset
        Me.btn_EliminarCaja.Location = New System.Drawing.Point(356, 402)
        Me.btn_EliminarCaja.Name = "btn_EliminarCaja"
        Me.btn_EliminarCaja.Size = New System.Drawing.Size(164, 75)
        Me.btn_EliminarCaja.TabIndex = 15
        Me.btn_EliminarCaja.Text = "&Eliminar"
        Me.btn_EliminarCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_EliminarCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_EliminarCaja.UseVisualStyleBackColor = True
        '
        'btn_CambiarStatusCaja
        '
        Me.btn_CambiarStatusCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_CambiarStatusCaja.Enabled = False
        Me.btn_CambiarStatusCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CambiarStatusCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CambiarStatusCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CambiarStatusCaja.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.BajaReing
        Me.btn_CambiarStatusCaja.Location = New System.Drawing.Point(16, 402)
        Me.btn_CambiarStatusCaja.Name = "btn_CambiarStatusCaja"
        Me.btn_CambiarStatusCaja.Size = New System.Drawing.Size(164, 75)
        Me.btn_CambiarStatusCaja.TabIndex = 13
        Me.btn_CambiarStatusCaja.Text = "Estatus"
        Me.btn_CambiarStatusCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CambiarStatusCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_CambiarStatusCaja.UseVisualStyleBackColor = True
        '
        'btn_CerrarCaja
        '
        Me.btn_CerrarCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_CerrarCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CerrarCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CerrarCaja.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_CerrarCaja.Location = New System.Drawing.Point(624, 402)
        Me.btn_CerrarCaja.Name = "btn_CerrarCaja"
        Me.btn_CerrarCaja.Size = New System.Drawing.Size(164, 75)
        Me.btn_CerrarCaja.TabIndex = 14
        Me.btn_CerrarCaja.Text = "&Cerrar"
        Me.btn_CerrarCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CerrarCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_CerrarCaja.UseVisualStyleBackColor = True
        '
        'btn_AgregarCaja
        '
        Me.btn_AgregarCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AgregarCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_AgregarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AgregarCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarCaja.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_AgregarCaset
        Me.btn_AgregarCaja.Location = New System.Drawing.Point(624, 7)
        Me.btn_AgregarCaja.Name = "btn_AgregarCaja"
        Me.btn_AgregarCaja.Size = New System.Drawing.Size(164, 75)
        Me.btn_AgregarCaja.TabIndex = 11
        Me.btn_AgregarCaja.Text = "&Agregar"
        Me.btn_AgregarCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_AgregarCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_AgregarCaja.UseVisualStyleBackColor = True
        '
        'frm_CatalogoCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_Cajas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_CatalogoCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Cajas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Cajas.ResumeLayout(False)
        Me.pnl_Cajas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Cajas As System.Windows.Forms.Panel
    Friend WithEvents lbl_DescripcionCaja As System.Windows.Forms.Label
    Friend WithEvents lbl_NumeroCaja As System.Windows.Forms.Label
    Friend WithEvents tbx_DescripcionCaja As System.Windows.Forms.TextBox
    Friend WithEvents tbx_NumeroCaja As System.Windows.Forms.TextBox
    Friend WithEvents btn_AgregarCaja As System.Windows.Forms.Button
    Friend WithEvents btn_EliminarCaja As System.Windows.Forms.Button
    Friend WithEvents btn_CambiarStatusCaja As System.Windows.Forms.Button
    Friend WithEvents btn_CerrarCaja As System.Windows.Forms.Button
    Friend WithEvents lsv_Cajas As System.Windows.Forms.ListView
    Friend WithEvents iml_Sincronia As System.Windows.Forms.ImageList
    Friend WithEvents btn_Editar As System.Windows.Forms.Button
    Friend WithEvents tbx_IpCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
