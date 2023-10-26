<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Check_Validadores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btn_verificar = New System.Windows.Forms.Button()
        Me.tlp_Lista = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_val2 = New System.Windows.Forms.Label()
        Me.lbl_val1 = New System.Windows.Forms.Label()
        Me.pb2 = New System.Windows.Forms.PictureBox()
        Me.pb1 = New System.Windows.Forms.PictureBox()
        Me.DeviceStatus = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlp_Lista.SuspendLayout()
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_verificar
        '
        Me.btn_verificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_verificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_verificar.Enabled = False
        Me.btn_verificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_verificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_verificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_verificar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Cerradura
        Me.btn_verificar.Location = New System.Drawing.Point(12, 311)
        Me.btn_verificar.Name = "btn_verificar"
        Me.btn_verificar.Size = New System.Drawing.Size(236, 75)
        Me.btn_verificar.TabIndex = 2
        Me.btn_verificar.Text = "&Guardar Verificacion"
        Me.btn_verificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_verificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_verificar.UseVisualStyleBackColor = False
        '
        'tlp_Lista
        '
        Me.tlp_Lista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlp_Lista.ColumnCount = 2
        Me.tlp_Lista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Lista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Lista.Controls.Add(Me.lbl_val2, 1, 1)
        Me.tlp_Lista.Controls.Add(Me.lbl_val1, 0, 1)
        Me.tlp_Lista.Controls.Add(Me.pb2, 1, 0)
        Me.tlp_Lista.Controls.Add(Me.pb1, 0, 0)
        Me.tlp_Lista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tlp_Lista.Location = New System.Drawing.Point(12, 62)
        Me.tlp_Lista.Name = "tlp_Lista"
        Me.tlp_Lista.RowCount = 3
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_Lista.Size = New System.Drawing.Size(795, 243)
        Me.tlp_Lista.TabIndex = 20
        '
        'lbl_val2
        '
        Me.lbl_val2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_val2.BackColor = System.Drawing.Color.LightGray
        Me.lbl_val2.Enabled = False
        Me.lbl_val2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_val2.Location = New System.Drawing.Point(400, 180)
        Me.lbl_val2.Name = "lbl_val2"
        Me.lbl_val2.Size = New System.Drawing.Size(392, 63)
        Me.lbl_val2.TabIndex = 4
        Me.lbl_val2.Text = "Validador-2"
        Me.lbl_val2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_val1
        '
        Me.lbl_val1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_val1.BackColor = System.Drawing.Color.LightGray
        Me.lbl_val1.Enabled = False
        Me.lbl_val1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_val1.Location = New System.Drawing.Point(3, 180)
        Me.lbl_val1.Name = "lbl_val1"
        Me.lbl_val1.Size = New System.Drawing.Size(391, 63)
        Me.lbl_val1.TabIndex = 3
        Me.lbl_val1.Text = "Validador-1"
        Me.lbl_val1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb2
        '
        Me.pb2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb2.BackColor = System.Drawing.Color.LightGray
        Me.pb2.Enabled = False
        Me.pb2.Location = New System.Drawing.Point(400, 3)
        Me.pb2.Name = "pb2"
        Me.pb2.Size = New System.Drawing.Size(392, 174)
        Me.pb2.TabIndex = 1
        Me.pb2.TabStop = False
        '
        'pb1
        '
        Me.pb1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb1.BackColor = System.Drawing.Color.LightGray
        Me.pb1.Enabled = False
        Me.pb1.Location = New System.Drawing.Point(3, 3)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(391, 174)
        Me.pb1.TabIndex = 0
        Me.pb1.TabStop = False
        '
        'DeviceStatus
        '
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(792, 50)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Validadores"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_Check_Validadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(819, 389)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tlp_Lista)
        Me.Controls.Add(Me.btn_verificar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Check_Validadores"
        Me.Text = "frm_Check_Validadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlp_Lista.ResumeLayout(False)
        CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_verificar As Button
    Friend WithEvents tlp_Lista As TableLayoutPanel
    Friend WithEvents pb2 As PictureBox
    Friend WithEvents pb1 As PictureBox
    Friend WithEvents lbl_val2 As Label
    Friend WithEvents lbl_val1 As Label
    Friend WithEvents DeviceStatus As Timer
    Friend WithEvents Label1 As Label
End Class
