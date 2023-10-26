<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ConsultaSaldos
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
        Me.lbl_TotalGeneral = New System.Windows.Forms.Label()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.tab_Saldos = New System.Windows.Forms.TabControl()
        Me.tabp_SaldoValidado = New System.Windows.Forms.TabPage()
        Me.tlp_Lista = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Total2 = New System.Windows.Forms.Label()
        Me.prg_Caset2 = New System.Windows.Forms.ProgressBar()
        Me.lsv_Saldos1 = New System.Windows.Forms.ListView()
        Me.prg_Caset1 = New System.Windows.Forms.ProgressBar()
        Me.lbl_Total1 = New System.Windows.Forms.Label()
        Me.lsv_Saldos2 = New System.Windows.Forms.ListView()
        Me.tabp_SaldoManual = New System.Windows.Forms.TabPage()
        Me.tbx_subtotalManual = New System.Windows.Forms.TextBox()
        Me.lbl_SubtotalManual = New System.Windows.Forms.Label()
        Me.tbx_usdManualConvert = New System.Windows.Forms.TextBox()
        Me.lbl_usdenMXN = New System.Windows.Forms.Label()
        Me.tbx_usdManual = New System.Windows.Forms.TextBox()
        Me.lbl_USD = New System.Windows.Forms.Label()
        Me.tbx_mxnManual = New System.Windows.Forms.TextBox()
        Me.lbl_MXN = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.Tbx_ImporteDocumentosUSD = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tbx_ImporteDocumentosMXN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tbx_ImporteDocumentosUsdEnMxp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl_General.SuspendLayout()
        Me.tab_Saldos.SuspendLayout()
        Me.tabp_SaldoValidado.SuspendLayout()
        Me.tlp_Lista.SuspendLayout()
        Me.tabp_SaldoManual.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_TotalGeneral
        '
        Me.lbl_TotalGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_TotalGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TotalGeneral.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalGeneral.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_TotalGeneral.Location = New System.Drawing.Point(182, 402)
        Me.lbl_TotalGeneral.Name = "lbl_TotalGeneral"
        Me.lbl_TotalGeneral.Size = New System.Drawing.Size(436, 75)
        Me.lbl_TotalGeneral.TabIndex = 3
        Me.lbl_TotalGeneral.Text = "$ 0.00"
        Me.lbl_TotalGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.tab_Saldos)
        Me.pnl_General.Controls.Add(Me.lbl_TotalGeneral)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.btn_Imprimir)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'tab_Saldos
        '
        Me.tab_Saldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_Saldos.Controls.Add(Me.tabp_SaldoValidado)
        Me.tab_Saldos.Controls.Add(Me.tabp_SaldoManual)
        Me.tab_Saldos.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_Saldos.Location = New System.Drawing.Point(6, 7)
        Me.tab_Saldos.Name = "tab_Saldos"
        Me.tab_Saldos.SelectedIndex = 0
        Me.tab_Saldos.Size = New System.Drawing.Size(791, 389)
        Me.tab_Saldos.TabIndex = 22
        '
        'tabp_SaldoValidado
        '
        Me.tabp_SaldoValidado.Controls.Add(Me.tlp_Lista)
        Me.tabp_SaldoValidado.Location = New System.Drawing.Point(4, 36)
        Me.tabp_SaldoValidado.Name = "tabp_SaldoValidado"
        Me.tabp_SaldoValidado.Padding = New System.Windows.Forms.Padding(3)
        Me.tabp_SaldoValidado.Size = New System.Drawing.Size(783, 349)
        Me.tabp_SaldoValidado.TabIndex = 0
        Me.tabp_SaldoValidado.Text = "Saldo Validado"
        Me.tabp_SaldoValidado.UseVisualStyleBackColor = True
        '
        'tlp_Lista
        '
        Me.tlp_Lista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlp_Lista.ColumnCount = 2
        Me.tlp_Lista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Lista.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_Lista.Controls.Add(Me.lbl_Total2, 1, 2)
        Me.tlp_Lista.Controls.Add(Me.prg_Caset2, 1, 1)
        Me.tlp_Lista.Controls.Add(Me.lsv_Saldos1, 0, 0)
        Me.tlp_Lista.Controls.Add(Me.prg_Caset1, 0, 1)
        Me.tlp_Lista.Controls.Add(Me.lbl_Total1, 0, 2)
        Me.tlp_Lista.Controls.Add(Me.lsv_Saldos2, 1, 0)
        Me.tlp_Lista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tlp_Lista.Location = New System.Drawing.Point(6, 3)
        Me.tlp_Lista.Name = "tlp_Lista"
        Me.tlp_Lista.RowCount = 3
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Lista.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_Lista.Size = New System.Drawing.Size(771, 340)
        Me.tlp_Lista.TabIndex = 21
        '
        'lbl_Total2
        '
        Me.lbl_Total2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total2.Location = New System.Drawing.Point(388, 307)
        Me.lbl_Total2.Name = "lbl_Total2"
        Me.lbl_Total2.Size = New System.Drawing.Size(315, 33)
        Me.lbl_Total2.TabIndex = 5
        Me.lbl_Total2.Text = "--"
        Me.lbl_Total2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'prg_Caset2
        '
        Me.prg_Caset2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prg_Caset2.Location = New System.Drawing.Point(388, 279)
        Me.prg_Caset2.Name = "prg_Caset2"
        Me.prg_Caset2.Size = New System.Drawing.Size(380, 25)
        Me.prg_Caset2.TabIndex = 13
        '
        'lsv_Saldos1
        '
        Me.lsv_Saldos1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Saldos1.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.CASET1
        Me.lsv_Saldos1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Saldos1.FullRowSelect = True
        Me.lsv_Saldos1.HideSelection = False
        Me.lsv_Saldos1.Location = New System.Drawing.Point(3, 3)
        Me.lsv_Saldos1.MultiSelect = False
        Me.lsv_Saldos1.Name = "lsv_Saldos1"
        Me.lsv_Saldos1.Size = New System.Drawing.Size(379, 270)
        Me.lsv_Saldos1.TabIndex = 4
        Me.lsv_Saldos1.UseCompatibleStateImageBehavior = False
        Me.lsv_Saldos1.View = System.Windows.Forms.View.Details
        '
        'prg_Caset1
        '
        Me.prg_Caset1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prg_Caset1.Location = New System.Drawing.Point(3, 279)
        Me.prg_Caset1.Name = "prg_Caset1"
        Me.prg_Caset1.Size = New System.Drawing.Size(379, 25)
        Me.prg_Caset1.TabIndex = 12
        '
        'lbl_Total1
        '
        Me.lbl_Total1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total1.Location = New System.Drawing.Point(3, 307)
        Me.lbl_Total1.Name = "lbl_Total1"
        Me.lbl_Total1.Size = New System.Drawing.Size(315, 33)
        Me.lbl_Total1.TabIndex = 14
        Me.lbl_Total1.Text = "--"
        Me.lbl_Total1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lsv_Saldos2
        '
        Me.lsv_Saldos2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsv_Saldos2.BackgroundImage = Global.Modulo_CashFlowV2.My.Resources.Resources.CASET2
        Me.lsv_Saldos2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsv_Saldos2.FullRowSelect = True
        Me.lsv_Saldos2.HideSelection = False
        Me.lsv_Saldos2.Location = New System.Drawing.Point(388, 3)
        Me.lsv_Saldos2.MultiSelect = False
        Me.lsv_Saldos2.Name = "lsv_Saldos2"
        Me.lsv_Saldos2.Size = New System.Drawing.Size(380, 270)
        Me.lsv_Saldos2.TabIndex = 5
        Me.lsv_Saldos2.UseCompatibleStateImageBehavior = False
        Me.lsv_Saldos2.View = System.Windows.Forms.View.Details
        '
        'tabp_SaldoManual
        '
        Me.tabp_SaldoManual.Controls.Add(Me.Tbx_ImporteDocumentosUsdEnMxp)
        Me.tabp_SaldoManual.Controls.Add(Me.Label3)
        Me.tabp_SaldoManual.Controls.Add(Me.Tbx_ImporteDocumentosUSD)
        Me.tabp_SaldoManual.Controls.Add(Me.Label1)
        Me.tabp_SaldoManual.Controls.Add(Me.Tbx_ImporteDocumentosMXN)
        Me.tabp_SaldoManual.Controls.Add(Me.Label2)
        Me.tabp_SaldoManual.Controls.Add(Me.tbx_subtotalManual)
        Me.tabp_SaldoManual.Controls.Add(Me.lbl_SubtotalManual)
        Me.tabp_SaldoManual.Controls.Add(Me.tbx_usdManualConvert)
        Me.tabp_SaldoManual.Controls.Add(Me.lbl_usdenMXN)
        Me.tabp_SaldoManual.Controls.Add(Me.tbx_usdManual)
        Me.tabp_SaldoManual.Controls.Add(Me.lbl_USD)
        Me.tabp_SaldoManual.Controls.Add(Me.tbx_mxnManual)
        Me.tabp_SaldoManual.Controls.Add(Me.lbl_MXN)
        Me.tabp_SaldoManual.Location = New System.Drawing.Point(4, 36)
        Me.tabp_SaldoManual.Name = "tabp_SaldoManual"
        Me.tabp_SaldoManual.Padding = New System.Windows.Forms.Padding(3)
        Me.tabp_SaldoManual.Size = New System.Drawing.Size(783, 349)
        Me.tabp_SaldoManual.TabIndex = 1
        Me.tabp_SaldoManual.Text = "Saldo Manual"
        Me.tabp_SaldoManual.UseVisualStyleBackColor = True
        '
        'tbx_subtotalManual
        '
        Me.tbx_subtotalManual.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_subtotalManual.BackColor = System.Drawing.Color.White
        Me.tbx_subtotalManual.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_subtotalManual.Location = New System.Drawing.Point(453, 285)
        Me.tbx_subtotalManual.MaxLength = 15
        Me.tbx_subtotalManual.Name = "tbx_subtotalManual"
        Me.tbx_subtotalManual.ReadOnly = True
        Me.tbx_subtotalManual.Size = New System.Drawing.Size(232, 35)
        Me.tbx_subtotalManual.TabIndex = 11
        Me.tbx_subtotalManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_SubtotalManual
        '
        Me.lbl_SubtotalManual.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_SubtotalManual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubtotalManual.Location = New System.Drawing.Point(297, 282)
        Me.lbl_SubtotalManual.Name = "lbl_SubtotalManual"
        Me.lbl_SubtotalManual.Size = New System.Drawing.Size(150, 35)
        Me.lbl_SubtotalManual.TabIndex = 10
        Me.lbl_SubtotalManual.Text = "Subtotal"
        Me.lbl_SubtotalManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbx_usdManualConvert
        '
        Me.tbx_usdManualConvert.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_usdManualConvert.BackColor = System.Drawing.Color.White
        Me.tbx_usdManualConvert.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_usdManualConvert.Location = New System.Drawing.Point(453, 231)
        Me.tbx_usdManualConvert.MaxLength = 15
        Me.tbx_usdManualConvert.Name = "tbx_usdManualConvert"
        Me.tbx_usdManualConvert.ReadOnly = True
        Me.tbx_usdManualConvert.Size = New System.Drawing.Size(232, 35)
        Me.tbx_usdManualConvert.TabIndex = 9
        Me.tbx_usdManualConvert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_usdenMXN
        '
        Me.lbl_usdenMXN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_usdenMXN.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_usdenMXN.Location = New System.Drawing.Point(9, 228)
        Me.lbl_usdenMXN.Name = "lbl_usdenMXN"
        Me.lbl_usdenMXN.Size = New System.Drawing.Size(438, 35)
        Me.lbl_usdenMXN.TabIndex = 8
        Me.lbl_usdenMXN.Text = "Importe Efectivo USD en MXN"
        Me.lbl_usdenMXN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbx_usdManual
        '
        Me.tbx_usdManual.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_usdManual.BackColor = System.Drawing.Color.White
        Me.tbx_usdManual.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_usdManual.Location = New System.Drawing.Point(453, 190)
        Me.tbx_usdManual.MaxLength = 15
        Me.tbx_usdManual.Name = "tbx_usdManual"
        Me.tbx_usdManual.ReadOnly = True
        Me.tbx_usdManual.Size = New System.Drawing.Size(232, 35)
        Me.tbx_usdManual.TabIndex = 7
        Me.tbx_usdManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_USD
        '
        Me.lbl_USD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_USD.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_USD.Location = New System.Drawing.Point(109, 187)
        Me.lbl_USD.Name = "lbl_USD"
        Me.lbl_USD.Size = New System.Drawing.Size(338, 35)
        Me.lbl_USD.TabIndex = 6
        Me.lbl_USD.Text = "Importe Efectivo USD"
        Me.lbl_USD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbx_mxnManual
        '
        Me.tbx_mxnManual.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbx_mxnManual.BackColor = System.Drawing.Color.White
        Me.tbx_mxnManual.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_mxnManual.Location = New System.Drawing.Point(453, 149)
        Me.tbx_mxnManual.MaxLength = 15
        Me.tbx_mxnManual.Name = "tbx_mxnManual"
        Me.tbx_mxnManual.ReadOnly = True
        Me.tbx_mxnManual.Size = New System.Drawing.Size(232, 35)
        Me.tbx_mxnManual.TabIndex = 5
        Me.tbx_mxnManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_MXN
        '
        Me.lbl_MXN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_MXN.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MXN.Location = New System.Drawing.Point(103, 146)
        Me.lbl_MXN.Name = "lbl_MXN"
        Me.lbl_MXN.Size = New System.Drawing.Size(344, 35)
        Me.lbl_MXN.TabIndex = 4
        Me.lbl_MXN.Text = "Importe Efectivo MXN"
        Me.lbl_MXN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btn_Cerrar.TabIndex = 4
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Imprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_Imprimir.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_Imprimir.Location = New System.Drawing.Point(12, 402)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(164, 75)
        Me.btn_Imprimir.TabIndex = 1
        Me.btn_Imprimir.Text = "&Imprimir"
        Me.btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Tbx_ImporteDocumentosUSD
        '
        Me.Tbx_ImporteDocumentosUSD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Tbx_ImporteDocumentosUSD.BackColor = System.Drawing.Color.White
        Me.Tbx_ImporteDocumentosUSD.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbx_ImporteDocumentosUSD.Location = New System.Drawing.Point(453, 55)
        Me.Tbx_ImporteDocumentosUSD.MaxLength = 15
        Me.Tbx_ImporteDocumentosUSD.Name = "Tbx_ImporteDocumentosUSD"
        Me.Tbx_ImporteDocumentosUSD.ReadOnly = True
        Me.Tbx_ImporteDocumentosUSD.Size = New System.Drawing.Size(232, 35)
        Me.Tbx_ImporteDocumentosUSD.TabIndex = 15
        Me.Tbx_ImporteDocumentosUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 35)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Importe Documentos USD"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tbx_ImporteDocumentosMXN
        '
        Me.Tbx_ImporteDocumentosMXN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Tbx_ImporteDocumentosMXN.BackColor = System.Drawing.Color.White
        Me.Tbx_ImporteDocumentosMXN.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbx_ImporteDocumentosMXN.Location = New System.Drawing.Point(453, 14)
        Me.Tbx_ImporteDocumentosMXN.MaxLength = 15
        Me.Tbx_ImporteDocumentosMXN.Name = "Tbx_ImporteDocumentosMXN"
        Me.Tbx_ImporteDocumentosMXN.ReadOnly = True
        Me.Tbx_ImporteDocumentosMXN.Size = New System.Drawing.Size(232, 35)
        Me.Tbx_ImporteDocumentosMXN.TabIndex = 13
        Me.Tbx_ImporteDocumentosMXN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(103, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(344, 35)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Importe Documentos MXN "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tbx_ImporteDocumentosUsdEnMxp
        '
        Me.Tbx_ImporteDocumentosUsdEnMxp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Tbx_ImporteDocumentosUsdEnMxp.BackColor = System.Drawing.Color.White
        Me.Tbx_ImporteDocumentosUsdEnMxp.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tbx_ImporteDocumentosUsdEnMxp.Location = New System.Drawing.Point(453, 96)
        Me.Tbx_ImporteDocumentosUsdEnMxp.MaxLength = 15
        Me.Tbx_ImporteDocumentosUsdEnMxp.Name = "Tbx_ImporteDocumentosUsdEnMxp"
        Me.Tbx_ImporteDocumentosUsdEnMxp.ReadOnly = True
        Me.Tbx_ImporteDocumentosUsdEnMxp.Size = New System.Drawing.Size(232, 35)
        Me.Tbx_ImporteDocumentosUsdEnMxp.TabIndex = 17
        Me.Tbx_ImporteDocumentosUsdEnMxp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(444, 35)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Importe Documentos USD en MXN"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_ConsultaSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_ConsultaSaldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Saldos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.tab_Saldos.ResumeLayout(False)
        Me.tabp_SaldoValidado.ResumeLayout(False)
        Me.tlp_Lista.ResumeLayout(False)
        Me.tabp_SaldoManual.ResumeLayout(False)
        Me.tabp_SaldoManual.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lbl_TotalGeneral As System.Windows.Forms.Label
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents lbl_Total1 As System.Windows.Forms.Label
    Friend WithEvents prg_Caset2 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_Total2 As System.Windows.Forms.Label
    Friend WithEvents prg_Caset1 As System.Windows.Forms.ProgressBar
    Friend WithEvents tlp_Lista As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lsv_Saldos2 As System.Windows.Forms.ListView
    Friend WithEvents lsv_Saldos1 As System.Windows.Forms.ListView
    Friend WithEvents tab_Saldos As System.Windows.Forms.TabControl
    Friend WithEvents tabp_SaldoValidado As System.Windows.Forms.TabPage
    Friend WithEvents tabp_SaldoManual As System.Windows.Forms.TabPage
    Friend WithEvents tbx_usdManual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_USD As System.Windows.Forms.Label
    Friend WithEvents tbx_mxnManual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_MXN As System.Windows.Forms.Label
    Friend WithEvents tbx_usdManualConvert As System.Windows.Forms.TextBox
    Friend WithEvents lbl_usdenMXN As System.Windows.Forms.Label
    Friend WithEvents tbx_subtotalManual As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SubtotalManual As System.Windows.Forms.Label
    Friend WithEvents Tbx_ImporteDocumentosUSD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tbx_ImporteDocumentosMXN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tbx_ImporteDocumentosUsdEnMxp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
