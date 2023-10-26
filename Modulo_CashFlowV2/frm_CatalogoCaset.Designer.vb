<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CatalogoCaset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CatalogoCaset))
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.btn_CambiarStatus = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lsv_Casets = New System.Windows.Forms.ListView()
        Me.iml_Sincronia = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.lbl_ClaveCaset = New System.Windows.Forms.Label()
        Me.lbl_Serie = New System.Windows.Forms.Label()
        Me.lbl_Porcentaje = New System.Windows.Forms.Label()
        Me.lbl_Capacidad = New System.Windows.Forms.Label()
        Me.tbx_ClaveCaset = New System.Windows.Forms.TextBox()
        Me.tbx_Serie = New System.Windows.Forms.TextBox()
        Me.tbx_Capacidad = New System.Windows.Forms.TextBox()
        Me.tbx_Porcentaje = New System.Windows.Forms.TextBox()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.btn_Eliminar)
        Me.pnl_General.Controls.Add(Me.btn_CambiarStatus)
        Me.pnl_General.Controls.Add(Me.tbx_Porcentaje)
        Me.pnl_General.Controls.Add(Me.tbx_Capacidad)
        Me.pnl_General.Controls.Add(Me.tbx_Serie)
        Me.pnl_General.Controls.Add(Me.tbx_ClaveCaset)
        Me.pnl_General.Controls.Add(Me.lbl_Capacidad)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.btn_Agregar)
        Me.pnl_General.Controls.Add(Me.lsv_Casets)
        Me.pnl_General.Controls.Add(Me.lbl_Porcentaje)
        Me.pnl_General.Controls.Add(Me.lbl_Serie)
        Me.pnl_General.Controls.Add(Me.lbl_ClaveCaset)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Eliminar.Enabled = False
        Me.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Eliminar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_EliminarCaset
        Me.btn_Eliminar.Location = New System.Drawing.Point(182, 400)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Eliminar.TabIndex = 12
        Me.btn_Eliminar.Text = "&Eliminar"
        Me.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'btn_CambiarStatus
        '
        Me.btn_CambiarStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_CambiarStatus.Enabled = False
        Me.btn_CambiarStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CambiarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CambiarStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CambiarStatus.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.BajaReing
        Me.btn_CambiarStatus.Location = New System.Drawing.Point(12, 400)
        Me.btn_CambiarStatus.Name = "btn_CambiarStatus"
        Me.btn_CambiarStatus.Size = New System.Drawing.Size(164, 75)
        Me.btn_CambiarStatus.TabIndex = 10
        Me.btn_CambiarStatus.Text = "Estatus"
        Me.btn_CambiarStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CambiarStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_CambiarStatus.UseVisualStyleBackColor = True
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
        'lsv_Casets
        '
        Me.lsv_Casets.AllowColumnReorder = True
        Me.lsv_Casets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Casets.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Casets.FullRowSelect = True
        Me.lsv_Casets.HideSelection = False
        Me.lsv_Casets.Location = New System.Drawing.Point(12, 132)
        Me.lsv_Casets.MultiSelect = False
        Me.lsv_Casets.Name = "lsv_Casets"
        Me.lsv_Casets.Size = New System.Drawing.Size(776, 262)
        Me.lsv_Casets.TabIndex = 9
        Me.lsv_Casets.UseCompatibleStateImageBehavior = False
        Me.lsv_Casets.View = System.Windows.Forms.View.Details
        '
        'iml_Sincronia
        '
        Me.iml_Sincronia.ImageStream = CType(resources.GetObject("iml_Sincronia.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_Sincronia.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_Sincronia.Images.SetKeyName(0, "Correcto.png")
        Me.iml_Sincronia.Images.SetKeyName(1, "Pendiente.png")
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Agregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Agregar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_AgregarCaset
        Me.btn_Agregar.Location = New System.Drawing.Point(624, 4)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Agregar.TabIndex = 8
        Me.btn_Agregar.Text = "&Agregar"
        Me.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'lbl_ClaveCaset
        '
        Me.lbl_ClaveCaset.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ClaveCaset.Location = New System.Drawing.Point(56, 4)
        Me.lbl_ClaveCaset.Name = "lbl_ClaveCaset"
        Me.lbl_ClaveCaset.Size = New System.Drawing.Size(100, 31)
        Me.lbl_ClaveCaset.TabIndex = 0
        Me.lbl_ClaveCaset.Text = "Clave"
        Me.lbl_ClaveCaset.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Serie
        '
        Me.lbl_Serie.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Serie.Location = New System.Drawing.Point(56, 44)
        Me.lbl_Serie.Name = "lbl_Serie"
        Me.lbl_Serie.Size = New System.Drawing.Size(100, 31)
        Me.lbl_Serie.TabIndex = 2
        Me.lbl_Serie.Text = "Serie"
        Me.lbl_Serie.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Porcentaje
        '
        Me.lbl_Porcentaje.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Porcentaje.Location = New System.Drawing.Point(242, 85)
        Me.lbl_Porcentaje.Name = "lbl_Porcentaje"
        Me.lbl_Porcentaje.Size = New System.Drawing.Size(181, 31)
        Me.lbl_Porcentaje.TabIndex = 6
        Me.lbl_Porcentaje.Text = "% para Alerta"
        Me.lbl_Porcentaje.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Capacidad
        '
        Me.lbl_Capacidad.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Capacidad.Location = New System.Drawing.Point(3, 85)
        Me.lbl_Capacidad.Name = "lbl_Capacidad"
        Me.lbl_Capacidad.Size = New System.Drawing.Size(153, 31)
        Me.lbl_Capacidad.TabIndex = 4
        Me.lbl_Capacidad.Text = "Capacidad"
        Me.lbl_Capacidad.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tbx_ClaveCaset
        '
        Me.tbx_ClaveCaset.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ClaveCaset.Location = New System.Drawing.Point(153, 3)
        Me.tbx_ClaveCaset.MaxLength = 10
        Me.tbx_ClaveCaset.Name = "tbx_ClaveCaset"
        Me.tbx_ClaveCaset.Size = New System.Drawing.Size(150, 26)
        Me.tbx_ClaveCaset.TabIndex = 1
        '
        'tbx_Serie
        '
        Me.tbx_Serie.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Serie.Location = New System.Drawing.Point(153, 44)
        Me.tbx_Serie.MaxLength = 17
        Me.tbx_Serie.Name = "tbx_Serie"
        Me.tbx_Serie.Size = New System.Drawing.Size(193, 26)
        Me.tbx_Serie.TabIndex = 3
        '
        'tbx_Capacidad
        '
        Me.tbx_Capacidad.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Capacidad.Location = New System.Drawing.Point(153, 85)
        Me.tbx_Capacidad.MaxLength = 4
        Me.tbx_Capacidad.Name = "tbx_Capacidad"
        Me.tbx_Capacidad.Size = New System.Drawing.Size(83, 26)
        Me.tbx_Capacidad.TabIndex = 5
        Me.tbx_Capacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbx_Porcentaje
        '
        Me.tbx_Porcentaje.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Porcentaje.Location = New System.Drawing.Point(429, 85)
        Me.tbx_Porcentaje.MaxLength = 3
        Me.tbx_Porcentaje.Name = "tbx_Porcentaje"
        Me.tbx_Porcentaje.Size = New System.Drawing.Size(53, 26)
        Me.tbx_Porcentaje.TabIndex = 7
        Me.tbx_Porcentaje.Text = "90"
        Me.tbx_Porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frm_Tablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Tablas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Casets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lsv_Casets As System.Windows.Forms.ListView
    Friend WithEvents btn_CambiarStatus As System.Windows.Forms.Button
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents iml_Sincronia As System.Windows.Forms.ImageList
    Friend WithEvents tbx_Porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Capacidad As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Serie As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ClaveCaset As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Capacidad As System.Windows.Forms.Label
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents lbl_Porcentaje As System.Windows.Forms.Label
    Friend WithEvents lbl_Serie As System.Windows.Forms.Label
    Friend WithEvents lbl_ClaveCaset As System.Windows.Forms.Label
End Class
