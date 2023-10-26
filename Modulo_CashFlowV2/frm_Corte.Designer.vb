<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Corte
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_USDConvertido = New System.Windows.Forms.Label()
        Me.Lbl_Fecha = New System.Windows.Forms.Label()
        Me.btn_Corte = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Lbl_NombreUsuario = New System.Windows.Forms.Label()
        Me.Lbl_Folio = New System.Windows.Forms.Label()
        Me.lbl_ClaveUsuario = New System.Windows.Forms.Label()
        Me.Lbl_HoraCorte = New System.Windows.Forms.Label()
        Me.Lbl_FechaCorte = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.Lbl_FolioCorte = New System.Windows.Forms.Label()
        Me.pnl_General.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.lbl_ClaveUsuario)
        Me.pnl_General.Controls.Add(Me.Lbl_HoraCorte)
        Me.pnl_General.Controls.Add(Me.Lbl_FechaCorte)
        Me.pnl_General.Controls.Add(Me.LblNombre)
        Me.pnl_General.Controls.Add(Me.Lbl_FolioCorte)
        Me.pnl_General.Controls.Add(Me.Label1)
        Me.pnl_General.Controls.Add(Me.lbl_USDConvertido)
        Me.pnl_General.Controls.Add(Me.Lbl_Fecha)
        Me.pnl_General.Controls.Add(Me.btn_Corte)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.Lbl_NombreUsuario)
        Me.pnl_General.Controls.Add(Me.Lbl_Folio)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(784, 441)
        Me.pnl_General.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 35)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Clave Usuario:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_USDConvertido
        '
        Me.lbl_USDConvertido.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_USDConvertido.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_USDConvertido.Location = New System.Drawing.Point(65, 258)
        Me.lbl_USDConvertido.Name = "lbl_USDConvertido"
        Me.lbl_USDConvertido.Size = New System.Drawing.Size(290, 35)
        Me.lbl_USDConvertido.TabIndex = 20
        Me.lbl_USDConvertido.Text = "Hora Corte:"
        Me.lbl_USDConvertido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Fecha.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fecha.Location = New System.Drawing.Point(94, 217)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(261, 35)
        Me.Lbl_Fecha.TabIndex = 18
        Me.Lbl_Fecha.Text = "Fecha Corte:"
        Me.Lbl_Fecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Corte
        '
        Me.btn_Corte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Corte.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Corte.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Corte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Corte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Corte.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Corte.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Guardar
        Me.btn_Corte.Location = New System.Drawing.Point(12, 354)
        Me.btn_Corte.Name = "btn_Corte"
        Me.btn_Corte.Size = New System.Drawing.Size(164, 75)
        Me.btn_Corte.TabIndex = 16
        Me.btn_Corte.Text = "&Corte"
        Me.btn_Corte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Corte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Corte.UseVisualStyleBackColor = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(608, 354)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 17
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'Lbl_NombreUsuario
        '
        Me.Lbl_NombreUsuario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_NombreUsuario.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NombreUsuario.Location = New System.Drawing.Point(135, 176)
        Me.Lbl_NombreUsuario.Name = "Lbl_NombreUsuario"
        Me.Lbl_NombreUsuario.Size = New System.Drawing.Size(220, 35)
        Me.Lbl_NombreUsuario.TabIndex = 2
        Me.Lbl_NombreUsuario.Text = "Nombre Usuario:"
        Me.Lbl_NombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Folio
        '
        Me.Lbl_Folio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Folio.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Folio.Location = New System.Drawing.Point(156, 94)
        Me.Lbl_Folio.Name = "Lbl_Folio"
        Me.Lbl_Folio.Size = New System.Drawing.Size(199, 35)
        Me.Lbl_Folio.TabIndex = 0
        Me.Lbl_Folio.Text = "Folio Corte:"
        Me.Lbl_Folio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ClaveUsuario
        '
        Me.lbl_ClaveUsuario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_ClaveUsuario.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ClaveUsuario.Location = New System.Drawing.Point(361, 141)
        Me.lbl_ClaveUsuario.Name = "lbl_ClaveUsuario"
        Me.lbl_ClaveUsuario.Size = New System.Drawing.Size(348, 35)
        Me.lbl_ClaveUsuario.TabIndex = 28
        Me.lbl_ClaveUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_HoraCorte
        '
        Me.Lbl_HoraCorte.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_HoraCorte.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_HoraCorte.Location = New System.Drawing.Point(361, 258)
        Me.Lbl_HoraCorte.Name = "Lbl_HoraCorte"
        Me.Lbl_HoraCorte.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_HoraCorte.TabIndex = 27
        Me.Lbl_HoraCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_FechaCorte
        '
        Me.Lbl_FechaCorte.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_FechaCorte.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FechaCorte.Location = New System.Drawing.Point(361, 217)
        Me.Lbl_FechaCorte.Name = "Lbl_FechaCorte"
        Me.Lbl_FechaCorte.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_FechaCorte.TabIndex = 26
        Me.Lbl_FechaCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblNombre.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.Location = New System.Drawing.Point(361, 176)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(348, 35)
        Me.LblNombre.TabIndex = 25
        Me.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_FolioCorte
        '
        Me.Lbl_FolioCorte.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_FolioCorte.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FolioCorte.Location = New System.Drawing.Point(361, 94)
        Me.Lbl_FolioCorte.Name = "Lbl_FolioCorte"
        Me.Lbl_FolioCorte.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_FolioCorte.TabIndex = 24
        Me.Lbl_FolioCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Corte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 441)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Corte"
        Me.Text = "Corte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lbl_USDConvertido As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents btn_Corte As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Lbl_NombreUsuario As System.Windows.Forms.Label
    Friend WithEvents Lbl_Folio As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_ClaveUsuario As System.Windows.Forms.Label
    Friend WithEvents Lbl_HoraCorte As System.Windows.Forms.Label
    Friend WithEvents Lbl_FechaCorte As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents Lbl_FolioCorte As System.Windows.Forms.Label
End Class
