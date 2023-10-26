<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Login
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
        Me.lbl_Clave = New System.Windows.Forms.Label()
        Me.lbl_Contrasena = New System.Windows.Forms.Label()
        Me.tbx_Clave = New System.Windows.Forms.TextBox()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnl_Bateria = New System.Windows.Forms.Panel()
        Me.lbl_Clavesucursal = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.tbx_Contrasena = New System.Windows.Forms.TextBox()
        Me.tmr_SesionGeneral = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_General.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Bateria.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Clave
        '
        Me.lbl_Clave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Clave.AutoSize = True
        Me.lbl_Clave.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clave.Location = New System.Drawing.Point(211, 96)
        Me.lbl_Clave.Name = "lbl_Clave"
        Me.lbl_Clave.Size = New System.Drawing.Size(154, 42)
        Me.lbl_Clave.TabIndex = 1
        Me.lbl_Clave.Text = "Usuario:"
        Me.lbl_Clave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Contrasena
        '
        Me.lbl_Contrasena.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Contrasena.AutoSize = True
        Me.lbl_Contrasena.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Contrasena.Location = New System.Drawing.Point(147, 159)
        Me.lbl_Contrasena.Name = "lbl_Contrasena"
        Me.lbl_Contrasena.Size = New System.Drawing.Size(218, 42)
        Me.lbl_Contrasena.TabIndex = 3
        Me.lbl_Contrasena.Text = "Contraseña:"
        Me.lbl_Contrasena.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbx_Clave
        '
        Me.tbx_Clave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Clave.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Clave.Location = New System.Drawing.Point(371, 75)
        Me.tbx_Clave.MaxLength = 6
        Me.tbx_Clave.Name = "tbx_Clave"
        Me.tbx_Clave.Size = New System.Drawing.Size(170, 63)
        Me.tbx_Clave.TabIndex = 2
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnl_General.Controls.Add(Me.PictureBox1)
        Me.pnl_General.Controls.Add(Me.pnl_Bateria)
        Me.pnl_General.Controls.Add(Me.tbx_Contrasena)
        Me.pnl_General.Controls.Add(Me.tbx_Clave)
        Me.pnl_General.Controls.Add(Me.lbl_Contrasena)
        Me.pnl_General.Controls.Add(Me.lbl_Clave)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 646)
        Me.pnl_General.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Logosissa
        Me.PictureBox1.Location = New System.Drawing.Point(420, -36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'pnl_Bateria
        '
        Me.pnl_Bateria.BackColor = System.Drawing.Color.Black
        Me.pnl_Bateria.Controls.Add(Me.lbl_Clavesucursal)
        Me.pnl_Bateria.Controls.Add(Me.lblVersion)
        Me.pnl_Bateria.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Bateria.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.pnl_Bateria.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Bateria.Name = "pnl_Bateria"
        Me.pnl_Bateria.Size = New System.Drawing.Size(800, 20)
        Me.pnl_Bateria.TabIndex = 5
        '
        'lbl_Clavesucursal
        '
        Me.lbl_Clavesucursal.AutoSize = True
        Me.lbl_Clavesucursal.BackColor = System.Drawing.Color.Black
        Me.lbl_Clavesucursal.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbl_Clavesucursal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clavesucursal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbl_Clavesucursal.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Clavesucursal.Name = "lbl_Clavesucursal"
        Me.lbl_Clavesucursal.Size = New System.Drawing.Size(66, 14)
        Me.lbl_Clavesucursal.TabIndex = 11
        Me.lbl_Clavesucursal.Text = "SUCURSAL:"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Black
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblVersion.Location = New System.Drawing.Point(748, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(52, 14)
        Me.lblVersion.TabIndex = 10
        Me.lblVersion.Text = "VERSION"
        '
        'tbx_Contrasena
        '
        Me.tbx_Contrasena.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Contrasena.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Contrasena.Location = New System.Drawing.Point(371, 145)
        Me.tbx_Contrasena.MaxLength = 8
        Me.tbx_Contrasena.Name = "tbx_Contrasena"
        Me.tbx_Contrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbx_Contrasena.Size = New System.Drawing.Size(170, 63)
        Me.tbx_Contrasena.TabIndex = 4
        '
        'tmr_SesionGeneral
        '
        Me.tmr_SesionGeneral.Interval = 1000
        '
        'frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 646)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Bateria.ResumeLayout(False)
        Me.pnl_Bateria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Clave As System.Windows.Forms.Label
    Friend WithEvents lbl_Contrasena As System.Windows.Forms.Label
    Friend WithEvents tbx_Clave As System.Windows.Forms.TextBox
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents tmr_SesionGeneral As System.Windows.Forms.Timer
    Friend WithEvents tbx_Contrasena As System.Windows.Forms.TextBox
    Friend WithEvents pnl_Bateria As System.Windows.Forms.Panel
    Friend WithEvents lblVersion As Label
    Friend WithEvents lbl_Clavesucursal As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
