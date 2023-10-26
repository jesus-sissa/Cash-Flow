<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Cerradura
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
        Me.pnl_Cerradura = New System.Windows.Forms.Panel()
        Me.btn_FechaPuesta = New System.Windows.Forms.Button()
        Me.Lbl_Meses = New System.Windows.Forms.Label()
        Me.cmb_Meses = New System.Windows.Forms.ComboBox()
        Me.Lbl_Estat2 = New System.Windows.Forms.Label()
        Me.Lbl_Estat = New System.Windows.Forms.Label()
        Me.lbl_Clave2 = New System.Windows.Forms.Label()
        Me.Lbl_FechaEx2 = New System.Windows.Forms.Label()
        Me.Lbl_Nombre2 = New System.Windows.Forms.Label()
        Me.Lbl_NumBateria2 = New System.Windows.Forms.Label()
        Me.Lbl_Clave = New System.Windows.Forms.Label()
        Me.Lbl_FechaEx = New System.Windows.Forms.Label()
        Me.Lbl_Fecha = New System.Windows.Forms.Label()
        Me.btn_Cerradura = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.Lbl_Nombre = New System.Windows.Forms.Label()
        Me.Lbl_NumBateria = New System.Windows.Forms.Label()
        Me.pnl_Cerradura.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Cerradura
        '
        Me.pnl_Cerradura.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_Cerradura.Controls.Add(Me.btn_FechaPuesta)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Meses)
        Me.pnl_Cerradura.Controls.Add(Me.cmb_Meses)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Estat2)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Estat)
        Me.pnl_Cerradura.Controls.Add(Me.lbl_Clave2)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_FechaEx2)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Nombre2)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_NumBateria2)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Clave)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_FechaEx)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Fecha)
        Me.pnl_Cerradura.Controls.Add(Me.btn_Cerradura)
        Me.pnl_Cerradura.Controls.Add(Me.btn_Cerrar)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_Nombre)
        Me.pnl_Cerradura.Controls.Add(Me.Lbl_NumBateria)
        Me.pnl_Cerradura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Cerradura.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Cerradura.Name = "pnl_Cerradura"
        Me.pnl_Cerradura.Size = New System.Drawing.Size(784, 441)
        Me.pnl_Cerradura.TabIndex = 0
        '
        'btn_FechaPuesta
        '
        Me.btn_FechaPuesta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_FechaPuesta.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_FechaPuesta.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaPuesta.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.calendar_16
        Me.btn_FechaPuesta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaPuesta.Location = New System.Drawing.Point(356, 166)
        Me.btn_FechaPuesta.Name = "btn_FechaPuesta"
        Me.btn_FechaPuesta.Size = New System.Drawing.Size(173, 38)
        Me.btn_FechaPuesta.TabIndex = 46
        Me.btn_FechaPuesta.Tag = "1"
        Me.btn_FechaPuesta.Text = " "
        Me.btn_FechaPuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaPuesta.UseVisualStyleBackColor = False
        '
        'Lbl_Meses
        '
        Me.Lbl_Meses.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Meses.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Meses.Location = New System.Drawing.Point(46, 282)
        Me.Lbl_Meses.Name = "Lbl_Meses"
        Me.Lbl_Meses.Size = New System.Drawing.Size(290, 35)
        Me.Lbl_Meses.TabIndex = 45
        Me.Lbl_Meses.Text = "Meses:"
        Me.Lbl_Meses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Meses
        '
        Me.cmb_Meses.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_Meses.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.cmb_Meses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Meses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Meses.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Meses.FormattingEnabled = True
        Me.cmb_Meses.Items.AddRange(New Object() {"3", "4", "5", "6"})
        Me.cmb_Meses.Location = New System.Drawing.Point(356, 280)
        Me.cmb_Meses.Name = "cmb_Meses"
        Me.cmb_Meses.Size = New System.Drawing.Size(152, 40)
        Me.cmb_Meses.TabIndex = 44
        '
        'Lbl_Estat2
        '
        Me.Lbl_Estat2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Estat2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estat2.Location = New System.Drawing.Point(350, 242)
        Me.Lbl_Estat2.Name = "Lbl_Estat2"
        Me.Lbl_Estat2.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_Estat2.TabIndex = 43
        Me.Lbl_Estat2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Estat
        '
        Me.Lbl_Estat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Estat.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estat.Location = New System.Drawing.Point(46, 242)
        Me.Lbl_Estat.Name = "Lbl_Estat"
        Me.Lbl_Estat.Size = New System.Drawing.Size(290, 35)
        Me.Lbl_Estat.TabIndex = 42
        Me.Lbl_Estat.Text = "Estatus:"
        Me.Lbl_Estat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Clave2
        '
        Me.lbl_Clave2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Clave2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clave2.Location = New System.Drawing.Point(350, 90)
        Me.lbl_Clave2.Name = "lbl_Clave2"
        Me.lbl_Clave2.Size = New System.Drawing.Size(348, 35)
        Me.lbl_Clave2.TabIndex = 40
        Me.lbl_Clave2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_FechaEx2
        '
        Me.Lbl_FechaEx2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_FechaEx2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FechaEx2.Location = New System.Drawing.Point(350, 207)
        Me.Lbl_FechaEx2.Name = "Lbl_FechaEx2"
        Me.Lbl_FechaEx2.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_FechaEx2.TabIndex = 39
        Me.Lbl_FechaEx2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Nombre2
        '
        Me.Lbl_Nombre2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Nombre2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nombre2.Location = New System.Drawing.Point(350, 125)
        Me.Lbl_Nombre2.Name = "Lbl_Nombre2"
        Me.Lbl_Nombre2.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_Nombre2.TabIndex = 37
        Me.Lbl_Nombre2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_NumBateria2
        '
        Me.Lbl_NumBateria2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_NumBateria2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NumBateria2.Location = New System.Drawing.Point(350, 43)
        Me.Lbl_NumBateria2.Name = "Lbl_NumBateria2"
        Me.Lbl_NumBateria2.Size = New System.Drawing.Size(348, 35)
        Me.Lbl_NumBateria2.TabIndex = 36
        Me.Lbl_NumBateria2.Text = "0"
        Me.Lbl_NumBateria2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Clave
        '
        Me.Lbl_Clave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Clave.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Clave.Location = New System.Drawing.Point(137, 84)
        Me.Lbl_Clave.Name = "Lbl_Clave"
        Me.Lbl_Clave.Size = New System.Drawing.Size(199, 35)
        Me.Lbl_Clave.TabIndex = 35
        Me.Lbl_Clave.Text = "Clave Usuario:"
        Me.Lbl_Clave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_FechaEx
        '
        Me.Lbl_FechaEx.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_FechaEx.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FechaEx.Location = New System.Drawing.Point(46, 207)
        Me.Lbl_FechaEx.Name = "Lbl_FechaEx"
        Me.Lbl_FechaEx.Size = New System.Drawing.Size(290, 35)
        Me.Lbl_FechaEx.TabIndex = 34
        Me.Lbl_FechaEx.Text = "Fecha expira:"
        Me.Lbl_FechaEx.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Fecha.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Fecha.Location = New System.Drawing.Point(75, 166)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(261, 35)
        Me.Lbl_Fecha.TabIndex = 33
        Me.Lbl_Fecha.Text = "Fecha puesta:"
        Me.Lbl_Fecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Cerradura
        '
        Me.btn_Cerradura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerradura.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerradura.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cerradura.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerradura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerradura.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerradura.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Refrescar
        Me.btn_Cerradura.Location = New System.Drawing.Point(12, 354)
        Me.btn_Cerradura.Name = "btn_Cerradura"
        Me.btn_Cerradura.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerradura.TabIndex = 31
        Me.btn_Cerradura.Text = "&Bateria"
        Me.btn_Cerradura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerradura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerradura.UseVisualStyleBackColor = False
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
        Me.btn_Cerrar.TabIndex = 32
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'Lbl_Nombre
        '
        Me.Lbl_Nombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Nombre.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Nombre.Location = New System.Drawing.Point(116, 125)
        Me.Lbl_Nombre.Name = "Lbl_Nombre"
        Me.Lbl_Nombre.Size = New System.Drawing.Size(220, 35)
        Me.Lbl_Nombre.TabIndex = 30
        Me.Lbl_Nombre.Text = "Nombre Usuario:"
        Me.Lbl_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_NumBateria
        '
        Me.Lbl_NumBateria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_NumBateria.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NumBateria.Location = New System.Drawing.Point(88, 43)
        Me.Lbl_NumBateria.Name = "Lbl_NumBateria"
        Me.Lbl_NumBateria.Size = New System.Drawing.Size(248, 35)
        Me.Lbl_NumBateria.TabIndex = 29
        Me.Lbl_NumBateria.Text = "Batería cerradura:"
        Me.Lbl_NumBateria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_Cerradura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 441)
        Me.Controls.Add(Me.pnl_Cerradura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Cerradura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Cerradura"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_Cerradura.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Cerradura As System.Windows.Forms.Panel
    Friend WithEvents lbl_Clave2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_FechaEx2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Nombre2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_NumBateria2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Clave As System.Windows.Forms.Label
    Friend WithEvents Lbl_FechaEx As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents btn_Cerradura As System.Windows.Forms.Button
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Lbl_Nombre As System.Windows.Forms.Label
    Friend WithEvents Lbl_NumBateria As System.Windows.Forms.Label
    Friend WithEvents Lbl_Estat2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Estat As System.Windows.Forms.Label
    Friend WithEvents Lbl_Meses As System.Windows.Forms.Label
    Friend WithEvents cmb_Meses As System.Windows.Forms.ComboBox
    Friend WithEvents btn_FechaPuesta As System.Windows.Forms.Button
End Class
