<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_EscanearPuertos
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
        Me.tbx_PuertoVal2 = New System.Windows.Forms.TextBox()
        Me.lbl_puertoval2 = New System.Windows.Forms.Label()
        Me.tbx_PuertoVal1 = New System.Windows.Forms.TextBox()
        Me.lbl_puertoval1 = New System.Windows.Forms.Label()
        Me.tbx_Validador2 = New System.Windows.Forms.TextBox()
        Me.tbx_Validador1 = New System.Windows.Forms.TextBox()
        Me.lbl_val2 = New System.Windows.Forms.Label()
        Me.lbl_val1 = New System.Windows.Forms.Label()
        Me.gbx_StatusVal1 = New System.Windows.Forms.GroupBox()
        Me.btn_Detener = New System.Windows.Forms.Button()
        Me.btn_Escanear = New System.Windows.Forms.Button()
        Me.lbl_ValorStatus = New System.Windows.Forms.Label()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.gbx_StatusVal2 = New System.Windows.Forms.GroupBox()
        Me.btn_Detener2 = New System.Windows.Forms.Button()
        Me.btn_Escanear2 = New System.Windows.Forms.Button()
        Me.lbl_ValorStatus2 = New System.Windows.Forms.Label()
        Me.lbl_Status2 = New System.Windows.Forms.Label()
        Me.lbl_NumPuertos = New System.Windows.Forms.Label()
        Me.cmb_Puertos = New System.Windows.Forms.ComboBox()
        Me.tmr_Puerto = New System.Windows.Forms.Timer(Me.components)
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.btn_CopiarTexto = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.gbx_NumValidadores = New System.Windows.Forms.GroupBox()
        Me.rdb_2val = New System.Windows.Forms.RadioButton()
        Me.rdb_1val = New System.Windows.Forms.RadioButton()
        Me.lbl_CantidadVal = New System.Windows.Forms.Label()
        Me.spc_Validadores = New System.Windows.Forms.SplitContainer()
        Me.gbx_StatusVal1.SuspendLayout()
        Me.gbx_StatusVal2.SuspendLayout()
        Me.pnl_General.SuspendLayout()
        Me.gbx_NumValidadores.SuspendLayout()
        CType(Me.spc_Validadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spc_Validadores.Panel1.SuspendLayout()
        Me.spc_Validadores.Panel2.SuspendLayout()
        Me.spc_Validadores.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbx_PuertoVal2
        '
        Me.tbx_PuertoVal2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_PuertoVal2.BackColor = System.Drawing.Color.White
        Me.tbx_PuertoVal2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_PuertoVal2.Location = New System.Drawing.Point(178, 94)
        Me.tbx_PuertoVal2.MaxLength = 2
        Me.tbx_PuertoVal2.Name = "tbx_PuertoVal2"
        Me.tbx_PuertoVal2.ReadOnly = True
        Me.tbx_PuertoVal2.Size = New System.Drawing.Size(71, 32)
        Me.tbx_PuertoVal2.TabIndex = 56
        '
        'lbl_puertoval2
        '
        Me.lbl_puertoval2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_puertoval2.AutoSize = True
        Me.lbl_puertoval2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puertoval2.Location = New System.Drawing.Point(75, 94)
        Me.lbl_puertoval2.Name = "lbl_puertoval2"
        Me.lbl_puertoval2.Size = New System.Drawing.Size(97, 22)
        Me.lbl_puertoval2.TabIndex = 55
        Me.lbl_puertoval2.Text = "Puerto Val"
        '
        'tbx_PuertoVal1
        '
        Me.tbx_PuertoVal1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_PuertoVal1.BackColor = System.Drawing.Color.White
        Me.tbx_PuertoVal1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_PuertoVal1.Location = New System.Drawing.Point(188, 94)
        Me.tbx_PuertoVal1.MaxLength = 2
        Me.tbx_PuertoVal1.Name = "tbx_PuertoVal1"
        Me.tbx_PuertoVal1.ReadOnly = True
        Me.tbx_PuertoVal1.Size = New System.Drawing.Size(71, 32)
        Me.tbx_PuertoVal1.TabIndex = 54
        '
        'lbl_puertoval1
        '
        Me.lbl_puertoval1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_puertoval1.AutoSize = True
        Me.lbl_puertoval1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_puertoval1.Location = New System.Drawing.Point(85, 98)
        Me.lbl_puertoval1.Name = "lbl_puertoval1"
        Me.lbl_puertoval1.Size = New System.Drawing.Size(97, 22)
        Me.lbl_puertoval1.TabIndex = 53
        Me.lbl_puertoval1.Text = "Puerto Val"
        '
        'tbx_Validador2
        '
        Me.tbx_Validador2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Validador2.BackColor = System.Drawing.Color.White
        Me.tbx_Validador2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Validador2.Location = New System.Drawing.Point(177, 54)
        Me.tbx_Validador2.MaxLength = 15
        Me.tbx_Validador2.Name = "tbx_Validador2"
        Me.tbx_Validador2.ReadOnly = True
        Me.tbx_Validador2.Size = New System.Drawing.Size(185, 32)
        Me.tbx_Validador2.TabIndex = 52
        '
        'tbx_Validador1
        '
        Me.tbx_Validador1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_Validador1.BackColor = System.Drawing.Color.White
        Me.tbx_Validador1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Validador1.Location = New System.Drawing.Point(188, 54)
        Me.tbx_Validador1.MaxLength = 15
        Me.tbx_Validador1.Name = "tbx_Validador1"
        Me.tbx_Validador1.ReadOnly = True
        Me.tbx_Validador1.Size = New System.Drawing.Size(185, 32)
        Me.tbx_Validador1.TabIndex = 50
        '
        'lbl_val2
        '
        Me.lbl_val2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_val2.AutoSize = True
        Me.lbl_val2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_val2.Location = New System.Drawing.Point(33, 58)
        Me.lbl_val2.Name = "lbl_val2"
        Me.lbl_val2.Size = New System.Drawing.Size(139, 22)
        Me.lbl_val2.TabIndex = 51
        Me.lbl_val2.Text = "Serie Validador"
        '
        'lbl_val1
        '
        Me.lbl_val1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_val1.AutoSize = True
        Me.lbl_val1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_val1.Location = New System.Drawing.Point(43, 58)
        Me.lbl_val1.Name = "lbl_val1"
        Me.lbl_val1.Size = New System.Drawing.Size(139, 22)
        Me.lbl_val1.TabIndex = 49
        Me.lbl_val1.Text = "Serie Validador"
        '
        'gbx_StatusVal1
        '
        Me.gbx_StatusVal1.Controls.Add(Me.btn_Detener)
        Me.gbx_StatusVal1.Controls.Add(Me.btn_Escanear)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_ValorStatus)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_Status)
        Me.gbx_StatusVal1.Controls.Add(Me.tbx_Validador1)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_val1)
        Me.gbx_StatusVal1.Controls.Add(Me.lbl_puertoval1)
        Me.gbx_StatusVal1.Controls.Add(Me.tbx_PuertoVal1)
        Me.gbx_StatusVal1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_StatusVal1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_StatusVal1.Location = New System.Drawing.Point(0, 0)
        Me.gbx_StatusVal1.Name = "gbx_StatusVal1"
        Me.gbx_StatusVal1.Size = New System.Drawing.Size(395, 274)
        Me.gbx_StatusVal1.TabIndex = 57
        Me.gbx_StatusVal1.TabStop = False
        Me.gbx_StatusVal1.Text = "Validador 1"
        '
        'btn_Detener
        '
        Me.btn_Detener.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Detener.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Detener.Enabled = False
        Me.btn_Detener.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Detener.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Detener.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Detener.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Finalizar
        Me.btn_Detener.Location = New System.Drawing.Point(188, 193)
        Me.btn_Detener.Name = "btn_Detener"
        Me.btn_Detener.Size = New System.Drawing.Size(164, 75)
        Me.btn_Detener.TabIndex = 66
        Me.btn_Detener.Text = "&Detener"
        Me.btn_Detener.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Detener.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Detener.UseVisualStyleBackColor = False
        '
        'btn_Escanear
        '
        Me.btn_Escanear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Escanear.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Escanear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Escanear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Escanear.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Escanear.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.EscanearPuerto
        Me.btn_Escanear.Location = New System.Drawing.Point(3, 193)
        Me.btn_Escanear.Name = "btn_Escanear"
        Me.btn_Escanear.Size = New System.Drawing.Size(177, 75)
        Me.btn_Escanear.TabIndex = 65
        Me.btn_Escanear.Text = "&Escanear"
        Me.btn_Escanear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Escanear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Escanear.UseVisualStyleBackColor = False
        '
        'lbl_ValorStatus
        '
        Me.lbl_ValorStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_ValorStatus.AutoSize = True
        Me.lbl_ValorStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ValorStatus.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_ValorStatus.Location = New System.Drawing.Point(184, 143)
        Me.lbl_ValorStatus.Name = "lbl_ValorStatus"
        Me.lbl_ValorStatus.Size = New System.Drawing.Size(134, 22)
        Me.lbl_ValorStatus.TabIndex = 59
        Me.lbl_ValorStatus.Text = "Desconectado"
        '
        'lbl_Status
        '
        Me.lbl_Status.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.Location = New System.Drawing.Point(109, 141)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(73, 22)
        Me.lbl_Status.TabIndex = 58
        Me.lbl_Status.Text = "Estatus"
        '
        'gbx_StatusVal2
        '
        Me.gbx_StatusVal2.Controls.Add(Me.btn_Detener2)
        Me.gbx_StatusVal2.Controls.Add(Me.btn_Escanear2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_ValorStatus2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_Status2)
        Me.gbx_StatusVal2.Controls.Add(Me.tbx_Validador2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_val2)
        Me.gbx_StatusVal2.Controls.Add(Me.tbx_PuertoVal2)
        Me.gbx_StatusVal2.Controls.Add(Me.lbl_puertoval2)
        Me.gbx_StatusVal2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbx_StatusVal2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_StatusVal2.Location = New System.Drawing.Point(0, 0)
        Me.gbx_StatusVal2.Name = "gbx_StatusVal2"
        Me.gbx_StatusVal2.Size = New System.Drawing.Size(391, 274)
        Me.gbx_StatusVal2.TabIndex = 58
        Me.gbx_StatusVal2.TabStop = False
        Me.gbx_StatusVal2.Text = "Validador 2"
        '
        'btn_Detener2
        '
        Me.btn_Detener2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Detener2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Detener2.Enabled = False
        Me.btn_Detener2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Detener2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Detener2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Detener2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Finalizar
        Me.btn_Detener2.Location = New System.Drawing.Point(225, 193)
        Me.btn_Detener2.Name = "btn_Detener2"
        Me.btn_Detener2.Size = New System.Drawing.Size(164, 75)
        Me.btn_Detener2.TabIndex = 68
        Me.btn_Detener2.Text = "&Detener"
        Me.btn_Detener2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Detener2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Detener2.UseVisualStyleBackColor = False
        '
        'btn_Escanear2
        '
        Me.btn_Escanear2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Escanear2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Escanear2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Escanear2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Escanear2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Escanear2.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.EscanearPuerto
        Me.btn_Escanear2.Location = New System.Drawing.Point(34, 193)
        Me.btn_Escanear2.Name = "btn_Escanear2"
        Me.btn_Escanear2.Size = New System.Drawing.Size(177, 75)
        Me.btn_Escanear2.TabIndex = 67
        Me.btn_Escanear2.Text = "&Escanear"
        Me.btn_Escanear2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Escanear2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Escanear2.UseVisualStyleBackColor = False
        '
        'lbl_ValorStatus2
        '
        Me.lbl_ValorStatus2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_ValorStatus2.AutoSize = True
        Me.lbl_ValorStatus2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ValorStatus2.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_ValorStatus2.Location = New System.Drawing.Point(174, 141)
        Me.lbl_ValorStatus2.Name = "lbl_ValorStatus2"
        Me.lbl_ValorStatus2.Size = New System.Drawing.Size(134, 22)
        Me.lbl_ValorStatus2.TabIndex = 61
        Me.lbl_ValorStatus2.Text = "Desconectado"
        '
        'lbl_Status2
        '
        Me.lbl_Status2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Status2.AutoSize = True
        Me.lbl_Status2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status2.Location = New System.Drawing.Point(99, 141)
        Me.lbl_Status2.Name = "lbl_Status2"
        Me.lbl_Status2.Size = New System.Drawing.Size(73, 22)
        Me.lbl_Status2.TabIndex = 60
        Me.lbl_Status2.Text = "Estatus"
        '
        'lbl_NumPuertos
        '
        Me.lbl_NumPuertos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_NumPuertos.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NumPuertos.Location = New System.Drawing.Point(89, 73)
        Me.lbl_NumPuertos.Name = "lbl_NumPuertos"
        Me.lbl_NumPuertos.Size = New System.Drawing.Size(215, 22)
        Me.lbl_NumPuertos.TabIndex = 60
        Me.lbl_NumPuertos.Text = "Puertos Disponibles"
        Me.lbl_NumPuertos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Puertos
        '
        Me.cmb_Puertos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmb_Puertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Puertos.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Puertos.FormattingEnabled = True
        Me.cmb_Puertos.Location = New System.Drawing.Point(310, 62)
        Me.cmb_Puertos.MaxDropDownItems = 20
        Me.cmb_Puertos.Name = "cmb_Puertos"
        Me.cmb_Puertos.Size = New System.Drawing.Size(208, 40)
        Me.cmb_Puertos.TabIndex = 61
        '
        'tmr_Puerto
        '
        Me.tmr_Puerto.Interval = 2000
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.btn_CopiarTexto)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.gbx_NumValidadores)
        Me.pnl_General.Controls.Add(Me.spc_Validadores)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 62
        '
        'btn_CopiarTexto
        '
        Me.btn_CopiarTexto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_CopiarTexto.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_CopiarTexto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_CopiarTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CopiarTexto.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CopiarTexto.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.copy
        Me.btn_CopiarTexto.Location = New System.Drawing.Point(8, 400)
        Me.btn_CopiarTexto.Name = "btn_CopiarTexto"
        Me.btn_CopiarTexto.Size = New System.Drawing.Size(177, 75)
        Me.btn_CopiarTexto.TabIndex = 65
        Me.btn_CopiarTexto.Text = "&Copiar Texto"
        Me.btn_CopiarTexto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CopiarTexto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_CopiarTexto.UseVisualStyleBackColor = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(629, 400)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 64
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'gbx_NumValidadores
        '
        Me.gbx_NumValidadores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_NumValidadores.Controls.Add(Me.rdb_2val)
        Me.gbx_NumValidadores.Controls.Add(Me.rdb_1val)
        Me.gbx_NumValidadores.Controls.Add(Me.lbl_CantidadVal)
        Me.gbx_NumValidadores.Controls.Add(Me.cmb_Puertos)
        Me.gbx_NumValidadores.Controls.Add(Me.lbl_NumPuertos)
        Me.gbx_NumValidadores.Location = New System.Drawing.Point(5, 5)
        Me.gbx_NumValidadores.Name = "gbx_NumValidadores"
        Me.gbx_NumValidadores.Size = New System.Drawing.Size(790, 109)
        Me.gbx_NumValidadores.TabIndex = 63
        Me.gbx_NumValidadores.TabStop = False
        '
        'rdb_2val
        '
        Me.rdb_2val.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_2val.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_2val.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_2val.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_UnChecked_24x24
        Me.rdb_2val.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_2val.Location = New System.Drawing.Point(433, 16)
        Me.rdb_2val.Name = "rdb_2val"
        Me.rdb_2val.Size = New System.Drawing.Size(85, 42)
        Me.rdb_2val.TabIndex = 51
        Me.rdb_2val.Text = "2"
        Me.rdb_2val.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_2val.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_2val.UseVisualStyleBackColor = True
        '
        'rdb_1val
        '
        Me.rdb_1val.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdb_1val.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdb_1val.Checked = True
        Me.rdb_1val.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_1val.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.RadioButton_Checked_24x24
        Me.rdb_1val.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb_1val.Location = New System.Drawing.Point(310, 16)
        Me.rdb_1val.Name = "rdb_1val"
        Me.rdb_1val.Size = New System.Drawing.Size(85, 42)
        Me.rdb_1val.TabIndex = 50
        Me.rdb_1val.TabStop = True
        Me.rdb_1val.Text = "1"
        Me.rdb_1val.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdb_1val.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb_1val.UseVisualStyleBackColor = True
        '
        'lbl_CantidadVal
        '
        Me.lbl_CantidadVal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_CantidadVal.AutoSize = True
        Me.lbl_CantidadVal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CantidadVal.Location = New System.Drawing.Point(145, 27)
        Me.lbl_CantidadVal.Name = "lbl_CantidadVal"
        Me.lbl_CantidadVal.Size = New System.Drawing.Size(159, 22)
        Me.lbl_CantidadVal.TabIndex = 31
        Me.lbl_CantidadVal.Text = "Cant. Validadores"
        '
        'spc_Validadores
        '
        Me.spc_Validadores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spc_Validadores.Location = New System.Drawing.Point(5, 120)
        Me.spc_Validadores.Name = "spc_Validadores"
        '
        'spc_Validadores.Panel1
        '
        Me.spc_Validadores.Panel1.Controls.Add(Me.gbx_StatusVal1)
        '
        'spc_Validadores.Panel2
        '
        Me.spc_Validadores.Panel2.Controls.Add(Me.gbx_StatusVal2)
        Me.spc_Validadores.Size = New System.Drawing.Size(790, 274)
        Me.spc_Validadores.SplitterDistance = 395
        Me.spc_Validadores.TabIndex = 62
        '
        'frm_EscanearPuertos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "frm_EscanearPuertos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Escanea Puertos de los Validadores Conectados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbx_StatusVal1.ResumeLayout(False)
        Me.gbx_StatusVal1.PerformLayout()
        Me.gbx_StatusVal2.ResumeLayout(False)
        Me.gbx_StatusVal2.PerformLayout()
        Me.pnl_General.ResumeLayout(False)
        Me.gbx_NumValidadores.ResumeLayout(False)
        Me.gbx_NumValidadores.PerformLayout()
        Me.spc_Validadores.Panel1.ResumeLayout(False)
        Me.spc_Validadores.Panel2.ResumeLayout(False)
        CType(Me.spc_Validadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spc_Validadores.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbx_PuertoVal2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_puertoval2 As System.Windows.Forms.Label
    Friend WithEvents tbx_PuertoVal1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_puertoval1 As System.Windows.Forms.Label
    Friend WithEvents tbx_Validador2 As System.Windows.Forms.TextBox
    Friend WithEvents tbx_Validador1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_val2 As System.Windows.Forms.Label
    Friend WithEvents lbl_val1 As System.Windows.Forms.Label
    Friend WithEvents gbx_StatusVal1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_StatusVal2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_ValorStatus As System.Windows.Forms.Label
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents lbl_ValorStatus2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Status2 As System.Windows.Forms.Label
    Friend WithEvents lbl_NumPuertos As System.Windows.Forms.Label
    Friend WithEvents cmb_Puertos As System.Windows.Forms.ComboBox
    Friend WithEvents tmr_Puerto As System.Windows.Forms.Timer
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents spc_Validadores As System.Windows.Forms.SplitContainer
    Friend WithEvents gbx_NumValidadores As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_2val As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_1val As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_CantidadVal As System.Windows.Forms.Label
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_Detener As System.Windows.Forms.Button
    Friend WithEvents btn_Escanear As System.Windows.Forms.Button
    Friend WithEvents btn_Detener2 As System.Windows.Forms.Button
    Friend WithEvents btn_Escanear2 As System.Windows.Forms.Button
    Friend WithEvents btn_CopiarTexto As System.Windows.Forms.Button
End Class
