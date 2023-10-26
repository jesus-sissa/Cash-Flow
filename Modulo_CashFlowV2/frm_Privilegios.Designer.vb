<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Privilegios
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
        Me.lbl_NombreUsuarios = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lbl_Privilegios = New System.Windows.Forms.Label()
        Me.lst_Privilegios = New System.Windows.Forms.ListBox()
        Me.lbl_PrivilegiosAsig = New System.Windows.Forms.Label()
        Me.lst_PrivilegiosAsig = New System.Windows.Forms.ListBox()
        Me.btn_QuitarTodo = New System.Windows.Forms.Button()
        Me.btn_AgregarUno = New System.Windows.Forms.Button()
        Me.btn_QuitarUno = New System.Windows.Forms.Button()
        Me.btn_AgregarTodo = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lst_Usuarios = New System.Windows.Forms.ListBox()
        Me.pnl_General.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.lbl_NombreUsuarios)
        Me.pnl_General.Controls.Add(Me.SplitContainer1)
        Me.pnl_General.Controls.Add(Me.btn_QuitarTodo)
        Me.pnl_General.Controls.Add(Me.btn_AgregarUno)
        Me.pnl_General.Controls.Add(Me.btn_QuitarUno)
        Me.pnl_General.Controls.Add(Me.btn_AgregarTodo)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.lst_Usuarios)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'lbl_NombreUsuarios
        '
        Me.lbl_NombreUsuarios.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NombreUsuarios.Location = New System.Drawing.Point(12, 2)
        Me.lbl_NombreUsuarios.Name = "lbl_NombreUsuarios"
        Me.lbl_NombreUsuarios.Size = New System.Drawing.Size(382, 31)
        Me.lbl_NombreUsuarios.TabIndex = 2
        Me.lbl_NombreUsuarios.Text = "Nombre de Usuarios"
        Me.lbl_NombreUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 190)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbl_Privilegios)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lst_Privilegios)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl_PrivilegiosAsig)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lst_PrivilegiosAsig)
        Me.SplitContainer1.Size = New System.Drawing.Size(776, 209)
        Me.SplitContainer1.SplitterDistance = 388
        Me.SplitContainer1.TabIndex = 22
        '
        'lbl_Privilegios
        '
        Me.lbl_Privilegios.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Privilegios.Location = New System.Drawing.Point(3, -1)
        Me.lbl_Privilegios.Name = "lbl_Privilegios"
        Me.lbl_Privilegios.Size = New System.Drawing.Size(382, 31)
        Me.lbl_Privilegios.TabIndex = 1
        Me.lbl_Privilegios.Text = "Total Privilegios: "
        Me.lbl_Privilegios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lst_Privilegios
        '
        Me.lst_Privilegios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_Privilegios.FormattingEnabled = True
        Me.lst_Privilegios.Location = New System.Drawing.Point(3, 33)
        Me.lst_Privilegios.Name = "lst_Privilegios"
        Me.lst_Privilegios.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lst_Privilegios.Size = New System.Drawing.Size(383, 173)
        Me.lst_Privilegios.TabIndex = 0
        '
        'lbl_PrivilegiosAsig
        '
        Me.lbl_PrivilegiosAsig.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrivilegiosAsig.Location = New System.Drawing.Point(3, 0)
        Me.lbl_PrivilegiosAsig.Name = "lbl_PrivilegiosAsig"
        Me.lbl_PrivilegiosAsig.Size = New System.Drawing.Size(378, 31)
        Me.lbl_PrivilegiosAsig.TabIndex = 2
        Me.lbl_PrivilegiosAsig.Text = "Privilegios Asignados: "
        Me.lbl_PrivilegiosAsig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lst_PrivilegiosAsig
        '
        Me.lst_PrivilegiosAsig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_PrivilegiosAsig.FormattingEnabled = True
        Me.lst_PrivilegiosAsig.Location = New System.Drawing.Point(3, 33)
        Me.lst_PrivilegiosAsig.Name = "lst_PrivilegiosAsig"
        Me.lst_PrivilegiosAsig.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lst_PrivilegiosAsig.Size = New System.Drawing.Size(378, 173)
        Me.lst_PrivilegiosAsig.TabIndex = 0
        '
        'btn_QuitarTodo
        '
        Me.btn_QuitarTodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_QuitarTodo.Enabled = False
        Me.btn_QuitarTodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_QuitarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_QuitarTodo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_QuitarTodo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_QuitarTodo
        Me.btn_QuitarTodo.Location = New System.Drawing.Point(533, 402)
        Me.btn_QuitarTodo.Name = "btn_QuitarTodo"
        Me.btn_QuitarTodo.Size = New System.Drawing.Size(124, 75)
        Me.btn_QuitarTodo.TabIndex = 5
        Me.btn_QuitarTodo.Text = "Quitar"
        Me.btn_QuitarTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_QuitarTodo.UseVisualStyleBackColor = True
        '
        'btn_AgregarUno
        '
        Me.btn_AgregarUno.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_AgregarUno.Enabled = False
        Me.btn_AgregarUno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_AgregarUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AgregarUno.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarUno.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_AgregarUno
        Me.btn_AgregarUno.Location = New System.Drawing.Point(146, 402)
        Me.btn_AgregarUno.Name = "btn_AgregarUno"
        Me.btn_AgregarUno.Size = New System.Drawing.Size(124, 75)
        Me.btn_AgregarUno.TabIndex = 2
        Me.btn_AgregarUno.Text = "Agregar"
        Me.btn_AgregarUno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_AgregarUno.UseVisualStyleBackColor = True
        '
        'btn_QuitarUno
        '
        Me.btn_QuitarUno.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_QuitarUno.Enabled = False
        Me.btn_QuitarUno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_QuitarUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_QuitarUno.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_QuitarUno.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_QuitarUno
        Me.btn_QuitarUno.Location = New System.Drawing.Point(408, 402)
        Me.btn_QuitarUno.Name = "btn_QuitarUno"
        Me.btn_QuitarUno.Size = New System.Drawing.Size(124, 75)
        Me.btn_QuitarUno.TabIndex = 4
        Me.btn_QuitarUno.Text = "Quitar"
        Me.btn_QuitarUno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_QuitarUno.UseVisualStyleBackColor = True
        '
        'btn_AgregarTodo
        '
        Me.btn_AgregarTodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btn_AgregarTodo.Enabled = False
        Me.btn_AgregarTodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_AgregarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AgregarTodo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AgregarTodo.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_AgregarTodo
        Me.btn_AgregarTodo.Location = New System.Drawing.Point(271, 402)
        Me.btn_AgregarTodo.Name = "btn_AgregarTodo"
        Me.btn_AgregarTodo.Size = New System.Drawing.Size(124, 75)
        Me.btn_AgregarTodo.TabIndex = 3
        Me.btn_AgregarTodo.Text = "Agregar"
        Me.btn_AgregarTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_AgregarTodo.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(664, 402)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(124, 75)
        Me.btn_Cerrar.TabIndex = 6
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lst_Usuarios
        '
        Me.lst_Usuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_Usuarios.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_Usuarios.FormattingEnabled = True
        Me.lst_Usuarios.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lst_Usuarios.ItemHeight = 24
        Me.lst_Usuarios.Location = New System.Drawing.Point(12, 36)
        Me.lst_Usuarios.Name = "lst_Usuarios"
        Me.lst_Usuarios.Size = New System.Drawing.Size(776, 148)
        Me.lst_Usuarios.TabIndex = 0
        '
        'frm_Privilegios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Privilegios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Privilegios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lst_Usuarios As System.Windows.Forms.ListBox
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_QuitarUno As System.Windows.Forms.Button
    Friend WithEvents btn_AgregarTodo As System.Windows.Forms.Button
    Friend WithEvents lst_Privilegios As System.Windows.Forms.ListBox
    Friend WithEvents lst_PrivilegiosAsig As System.Windows.Forms.ListBox
    Friend WithEvents btn_QuitarTodo As System.Windows.Forms.Button
    Friend WithEvents btn_AgregarUno As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbl_Privilegios As System.Windows.Forms.Label
    Friend WithEvents lbl_PrivilegiosAsig As System.Windows.Forms.Label
    Friend WithEvents lbl_NombreUsuarios As System.Windows.Forms.Label
End Class
