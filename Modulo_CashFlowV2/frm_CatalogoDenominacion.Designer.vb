<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CatalogoDenominacion
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
        Me.cmb_Monedas = New System.Windows.Forms.ComboBox()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.tbx_Denominacion = New System.Windows.Forms.TextBox()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.lsv_Denominaciones = New System.Windows.Forms.ListView()
        Me.lbl_Moneda = New System.Windows.Forms.Label()
        Me.lbl_Denominacion = New System.Windows.Forms.Label()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.cmb_Monedas)
        Me.pnl_General.Controls.Add(Me.btn_Eliminar)
        Me.pnl_General.Controls.Add(Me.tbx_Denominacion)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.btn_Agregar)
        Me.pnl_General.Controls.Add(Me.lsv_Denominaciones)
        Me.pnl_General.Controls.Add(Me.lbl_Moneda)
        Me.pnl_General.Controls.Add(Me.lbl_Denominacion)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'cmb_Monedas
        '
        Me.cmb_Monedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Monedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Monedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Monedas.FormattingEnabled = True
        Me.cmb_Monedas.Location = New System.Drawing.Point(129, 8)
        Me.cmb_Monedas.MaxDropDownItems = 20
        Me.cmb_Monedas.Name = "cmb_Monedas"
        Me.cmb_Monedas.Size = New System.Drawing.Size(177, 28)
        Me.cmb_Monedas.TabIndex = 1
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Eliminar.Enabled = False
        Me.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Eliminar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Baja
        Me.btn_Eliminar.Location = New System.Drawing.Point(3, 402)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Eliminar.TabIndex = 6
        Me.btn_Eliminar.Text = "&Eliminar"
        Me.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'tbx_Denominacion
        '
        Me.tbx_Denominacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Denominacion.Location = New System.Drawing.Point(505, 11)
        Me.tbx_Denominacion.MaxLength = 4
        Me.tbx_Denominacion.Name = "tbx_Denominacion"
        Me.tbx_Denominacion.Size = New System.Drawing.Size(108, 26)
        Me.tbx_Denominacion.TabIndex = 3
        Me.tbx_Denominacion.Text = "0"
        Me.tbx_Denominacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(633, 402)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 7
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Agregar
        '
        Me.btn_Agregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Agregar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Agregar
        Me.btn_Agregar.Location = New System.Drawing.Point(633, 3)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Agregar.TabIndex = 4
        Me.btn_Agregar.Text = "&Agregar"
        Me.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'lsv_Denominaciones
        '
        Me.lsv_Denominaciones.AllowColumnReorder = True
        Me.lsv_Denominaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Denominaciones.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Denominaciones.FullRowSelect = True
        Me.lsv_Denominaciones.HideSelection = False
        Me.lsv_Denominaciones.Location = New System.Drawing.Point(12, 84)
        Me.lsv_Denominaciones.MultiSelect = False
        Me.lsv_Denominaciones.Name = "lsv_Denominaciones"
        Me.lsv_Denominaciones.Size = New System.Drawing.Size(776, 312)
        Me.lsv_Denominaciones.TabIndex = 5
        Me.lsv_Denominaciones.UseCompatibleStateImageBehavior = False
        Me.lsv_Denominaciones.View = System.Windows.Forms.View.Details
        '
        'lbl_Moneda
        '
        Me.lbl_Moneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Moneda.Location = New System.Drawing.Point(3, 11)
        Me.lbl_Moneda.Name = "lbl_Moneda"
        Me.lbl_Moneda.Size = New System.Drawing.Size(120, 31)
        Me.lbl_Moneda.TabIndex = 0
        Me.lbl_Moneda.Text = "Moneda"
        Me.lbl_Moneda.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Denominacion
        '
        Me.lbl_Denominacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Denominacion.Location = New System.Drawing.Point(304, 11)
        Me.lbl_Denominacion.Name = "lbl_Denominacion"
        Me.lbl_Denominacion.Size = New System.Drawing.Size(195, 31)
        Me.lbl_Denominacion.TabIndex = 2
        Me.lbl_Denominacion.Text = "Denominación"
        Me.lbl_Denominacion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frm_CatalogoDenominacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_CatalogoDenominacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Denominaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents tbx_Denominacion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Denominacion As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents lsv_Denominaciones As System.Windows.Forms.ListView
    Friend WithEvents lbl_Moneda As System.Windows.Forms.Label
    Friend WithEvents cmb_Monedas As System.Windows.Forms.ComboBox
End Class
