<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CatalogoMonedas
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
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lbl_Clave = New System.Windows.Forms.Label()
        Me.tbx_NombreMoneda = New System.Windows.Forms.TextBox()
        Me.tbx_ClaveMoneda = New System.Windows.Forms.TextBox()
        Me.lbl_Nombre = New System.Windows.Forms.Label()
        Me.lsv_Monedas = New System.Windows.Forms.ListView()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(624, 402)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 5
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lbl_Clave
        '
        Me.lbl_Clave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clave.Location = New System.Drawing.Point(44, 13)
        Me.lbl_Clave.Name = "lbl_Clave"
        Me.lbl_Clave.Size = New System.Drawing.Size(194, 31)
        Me.lbl_Clave.TabIndex = 0
        Me.lbl_Clave.Text = "Clave Moneda"
        Me.lbl_Clave.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tbx_NombreMoneda
        '
        Me.tbx_NombreMoneda.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_NombreMoneda.Location = New System.Drawing.Point(244, 50)
        Me.tbx_NombreMoneda.MaxLength = 50
        Me.tbx_NombreMoneda.Name = "tbx_NombreMoneda"
        Me.tbx_NombreMoneda.Size = New System.Drawing.Size(197, 26)
        Me.tbx_NombreMoneda.TabIndex = 3
        '
        'tbx_ClaveMoneda
        '
        Me.tbx_ClaveMoneda.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ClaveMoneda.Location = New System.Drawing.Point(244, 9)
        Me.tbx_ClaveMoneda.MaxLength = 5
        Me.tbx_ClaveMoneda.Name = "tbx_ClaveMoneda"
        Me.tbx_ClaveMoneda.Size = New System.Drawing.Size(107, 26)
        Me.tbx_ClaveMoneda.TabIndex = 1
        '
        'lbl_Nombre
        '
        Me.lbl_Nombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Nombre.Location = New System.Drawing.Point(12, 55)
        Me.lbl_Nombre.Name = "lbl_Nombre"
        Me.lbl_Nombre.Size = New System.Drawing.Size(226, 31)
        Me.lbl_Nombre.TabIndex = 2
        Me.lbl_Nombre.Text = "Nombre Moneda"
        Me.lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lsv_Monedas
        '
        Me.lsv_Monedas.AllowColumnReorder = True
        Me.lsv_Monedas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Monedas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Monedas.FullRowSelect = True
        Me.lsv_Monedas.HideSelection = False
        Me.lsv_Monedas.Location = New System.Drawing.Point(12, 94)
        Me.lsv_Monedas.MultiSelect = False
        Me.lsv_Monedas.Name = "lsv_Monedas"
        Me.lsv_Monedas.Size = New System.Drawing.Size(776, 302)
        Me.lsv_Monedas.TabIndex = 6
        Me.lsv_Monedas.UseCompatibleStateImageBehavior = False
        Me.lsv_Monedas.View = System.Windows.Forms.View.Details
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Agregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Agregar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Agregar
        Me.btn_Agregar.Location = New System.Drawing.Point(624, 3)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Agregar.TabIndex = 7
        Me.btn_Agregar.Text = "&Agregar"
        Me.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.tbx_NombreMoneda)
        Me.pnl_General.Controls.Add(Me.tbx_ClaveMoneda)
        Me.pnl_General.Controls.Add(Me.lbl_Clave)
        Me.pnl_General.Controls.Add(Me.lbl_Nombre)
        Me.pnl_General.Controls.Add(Me.btn_Eliminar)
        Me.pnl_General.Controls.Add(Me.btn_Agregar)
        Me.pnl_General.Controls.Add(Me.lsv_Monedas)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 8
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Eliminar.Enabled = False
        Me.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Eliminar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Baja
        Me.btn_Eliminar.Location = New System.Drawing.Point(12, 402)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Eliminar.TabIndex = 8
        Me.btn_Eliminar.Text = "&Eliminar"
        Me.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'frm_CatalogoMonedas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_CatalogoMonedas"
        Me.Text = "Catálogo Monedas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lbl_Clave As System.Windows.Forms.Label
    Friend WithEvents tbx_NombreMoneda As System.Windows.Forms.TextBox
    Friend WithEvents tbx_ClaveMoneda As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Nombre As System.Windows.Forms.Label
    Friend WithEvents lsv_Monedas As System.Windows.Forms.ListView
    Friend WithEvents btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
End Class
