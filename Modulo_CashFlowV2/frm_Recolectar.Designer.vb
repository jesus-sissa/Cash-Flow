<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Recolectar
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
        Dim btn_Retirar As System.Windows.Forms.Button
        Me.lbl_SaldoGeneral = New System.Windows.Forms.Label()
        Me.lbl_CiaTV = New System.Windows.Forms.Label()
        Me.lbl_CasetActual = New System.Windows.Forms.Label()
        Me.lbl_CiaTVD = New System.Windows.Forms.Label()
        Me.pnl_General = New System.Windows.Forms.Panel()
        Me.tbx_Observaciones = New System.Windows.Forms.TextBox()
        Me.tbx_Envase = New System.Windows.Forms.TextBox()
        Me.lbl_Envase = New System.Windows.Forms.Label()
        Me.tbx_ImporteOtros = New System.Windows.Forms.TextBox()
        Me.lbl_Observaciones = New System.Windows.Forms.Label()
        Me.tbx_Remision = New System.Windows.Forms.TextBox()
        Me.lbl_Remision = New System.Windows.Forms.Label()
        Me.tlp_DatosCaset = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_CasetActualD2 = New System.Windows.Forms.Label()
        Me.lblCasetActual_2 = New System.Windows.Forms.Label()
        Me.lbl_CasetDisponibles = New System.Windows.Forms.Label()
        Me.lbl_Total2 = New System.Windows.Forms.Label()
        Me.cmb_Caset = New System.Windows.Forms.ComboBox()
        Me.lblTotalcaset_2 = New System.Windows.Forms.Label()
        Me.lbl_CasetActualD = New System.Windows.Forms.Label()
        Me.lblCasetnuevo_2 = New System.Windows.Forms.Label()
        Me.lbl_Subtotal1 = New System.Windows.Forms.Label()
        Me.cmb_Caset2 = New System.Windows.Forms.ComboBox()
        Me.lbl_Total1 = New System.Windows.Forms.Label()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.lbl_ImporteOtros = New System.Windows.Forms.Label()
        btn_Retirar = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.tlp_DatosCaset.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Retirar
        '
        btn_Retirar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        btn_Retirar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        btn_Retirar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        btn_Retirar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btn_Retirar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_Retiros
        btn_Retirar.Location = New System.Drawing.Point(3, 402)
        btn_Retirar.Name = "btn_Retirar"
        btn_Retirar.Size = New System.Drawing.Size(164, 75)
        btn_Retirar.TabIndex = 11
        btn_Retirar.Text = "&Retirar"
        btn_Retirar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        btn_Retirar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        btn_Retirar.UseVisualStyleBackColor = True
        AddHandler btn_Retirar.Click, AddressOf Me.btn_Retirar_Click
        '
        'lbl_SaldoGeneral
        '
        Me.lbl_SaldoGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_SaldoGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_SaldoGeneral.Font = New System.Drawing.Font("Arial", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SaldoGeneral.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SaldoGeneral.Location = New System.Drawing.Point(173, 402)
        Me.lbl_SaldoGeneral.Name = "lbl_SaldoGeneral"
        Me.lbl_SaldoGeneral.Size = New System.Drawing.Size(444, 75)
        Me.lbl_SaldoGeneral.TabIndex = 13
        Me.lbl_SaldoGeneral.Tag = "0"
        Me.lbl_SaldoGeneral.Text = "$0.00"
        Me.lbl_SaldoGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_CiaTV
        '
        Me.lbl_CiaTV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_CiaTV.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CiaTV.Location = New System.Drawing.Point(3, 209)
        Me.lbl_CiaTV.Name = "lbl_CiaTV"
        Me.lbl_CiaTV.Size = New System.Drawing.Size(182, 31)
        Me.lbl_CiaTV.TabIndex = 8
        Me.lbl_CiaTV.Text = "Compañía"
        Me.lbl_CiaTV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CasetActual
        '
        Me.lbl_CasetActual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CasetActual.Location = New System.Drawing.Point(3, 0)
        Me.lbl_CasetActual.Name = "lbl_CasetActual"
        Me.lbl_CasetActual.Size = New System.Drawing.Size(174, 30)
        Me.lbl_CasetActual.TabIndex = 0
        Me.lbl_CasetActual.Text = "Caset Actual"
        Me.lbl_CasetActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CiaTVD
        '
        Me.lbl_CiaTVD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_CiaTVD.BackColor = System.Drawing.SystemColors.Window
        Me.lbl_CiaTVD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CiaTVD.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CiaTVD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_CiaTVD.Location = New System.Drawing.Point(194, 209)
        Me.lbl_CiaTVD.Name = "lbl_CiaTVD"
        Me.lbl_CiaTVD.Size = New System.Drawing.Size(597, 31)
        Me.lbl_CiaTVD.TabIndex = 9
        Me.lbl_CiaTVD.Text = "_TRASLADO DE VALORES"
        Me.lbl_CiaTVD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnl_General
        '
        Me.pnl_General.Controls.Add(Me.tbx_Observaciones)
        Me.pnl_General.Controls.Add(Me.tbx_Envase)
        Me.pnl_General.Controls.Add(Me.lbl_Envase)
        Me.pnl_General.Controls.Add(Me.tbx_ImporteOtros)
        Me.pnl_General.Controls.Add(Me.lbl_Observaciones)
        Me.pnl_General.Controls.Add(Me.tbx_Remision)
        Me.pnl_General.Controls.Add(Me.lbl_Remision)
        Me.pnl_General.Controls.Add(Me.tlp_DatosCaset)
        Me.pnl_General.Controls.Add(Me.lbl_CiaTVD)
        Me.pnl_General.Controls.Add(Me.btn_Cerrar)
        Me.pnl_General.Controls.Add(Me.lbl_CiaTV)
        Me.pnl_General.Controls.Add(Me.lbl_SaldoGeneral)
        Me.pnl_General.Controls.Add(btn_Retirar)
        Me.pnl_General.Controls.Add(Me.lbl_ImporteOtros)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'tbx_Observaciones
        '
        Me.tbx_Observaciones.AcceptsReturn = True
        Me.tbx_Observaciones.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Observaciones.Location = New System.Drawing.Point(8, 126)
        Me.tbx_Observaciones.MaxLength = 200
        Me.tbx_Observaciones.Multiline = True
        Me.tbx_Observaciones.Name = "tbx_Observaciones"
        Me.tbx_Observaciones.Size = New System.Drawing.Size(783, 80)
        Me.tbx_Observaciones.TabIndex = 15
        '
        'tbx_Envase
        '
        Me.tbx_Envase.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Envase.Location = New System.Drawing.Point(561, 38)
        Me.tbx_Envase.MaxLength = 14
        Me.tbx_Envase.Name = "tbx_Envase"
        Me.tbx_Envase.Size = New System.Drawing.Size(230, 50)
        Me.tbx_Envase.TabIndex = 5
        '
        'lbl_Envase
        '
        Me.lbl_Envase.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Envase.Location = New System.Drawing.Point(590, 6)
        Me.lbl_Envase.Name = "lbl_Envase"
        Me.lbl_Envase.Size = New System.Drawing.Size(175, 32)
        Me.lbl_Envase.TabIndex = 2
        Me.lbl_Envase.Text = "No. Envase"
        Me.lbl_Envase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbx_ImporteOtros
        '
        Me.tbx_ImporteOtros.BackColor = System.Drawing.Color.White
        Me.tbx_ImporteOtros.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_ImporteOtros.Location = New System.Drawing.Point(257, 38)
        Me.tbx_ImporteOtros.MaxLength = 5
        Me.tbx_ImporteOtros.Name = "tbx_ImporteOtros"
        Me.tbx_ImporteOtros.ReadOnly = True
        Me.tbx_ImporteOtros.Size = New System.Drawing.Size(298, 50)
        Me.tbx_ImporteOtros.TabIndex = 4
        Me.tbx_ImporteOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Observaciones
        '
        Me.lbl_Observaciones.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Observaciones.Location = New System.Drawing.Point(10, 91)
        Me.lbl_Observaciones.Name = "lbl_Observaciones"
        Me.lbl_Observaciones.Size = New System.Drawing.Size(196, 32)
        Me.lbl_Observaciones.TabIndex = 6
        Me.lbl_Observaciones.Text = "Observaciones"
        '
        'tbx_Remision
        '
        Me.tbx_Remision.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_Remision.Location = New System.Drawing.Point(8, 38)
        Me.tbx_Remision.MaxLength = 15
        Me.tbx_Remision.Name = "tbx_Remision"
        Me.tbx_Remision.Size = New System.Drawing.Size(243, 50)
        Me.tbx_Remision.TabIndex = 3
        '
        'lbl_Remision
        '
        Me.lbl_Remision.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remision.Location = New System.Drawing.Point(10, 6)
        Me.lbl_Remision.Name = "lbl_Remision"
        Me.lbl_Remision.Size = New System.Drawing.Size(128, 32)
        Me.lbl_Remision.TabIndex = 0
        Me.lbl_Remision.Text = "Remisión"
        Me.lbl_Remision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlp_DatosCaset
        '
        Me.tlp_DatosCaset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlp_DatosCaset.ColumnCount = 4
        Me.tlp_DatosCaset.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183.0!))
        Me.tlp_DatosCaset.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_DatosCaset.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.tlp_DatosCaset.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_CasetActualD2, 3, 0)
        Me.tlp_DatosCaset.Controls.Add(Me.lblCasetActual_2, 2, 0)
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_CasetActual, 0, 0)
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_CasetDisponibles, 0, 1)
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_Total2, 3, 2)
        Me.tlp_DatosCaset.Controls.Add(Me.cmb_Caset, 1, 1)
        Me.tlp_DatosCaset.Controls.Add(Me.lblTotalcaset_2, 2, 2)
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_CasetActualD, 1, 0)
        Me.tlp_DatosCaset.Controls.Add(Me.lblCasetnuevo_2, 2, 1)
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_Subtotal1, 0, 2)
        Me.tlp_DatosCaset.Controls.Add(Me.cmb_Caset2, 3, 1)
        Me.tlp_DatosCaset.Controls.Add(Me.lbl_Total1, 1, 2)
        Me.tlp_DatosCaset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tlp_DatosCaset.Location = New System.Drawing.Point(8, 251)
        Me.tlp_DatosCaset.Name = "tlp_DatosCaset"
        Me.tlp_DatosCaset.RowCount = 3
        Me.tlp_DatosCaset.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_DatosCaset.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.tlp_DatosCaset.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tlp_DatosCaset.Size = New System.Drawing.Size(784, 116)
        Me.tlp_DatosCaset.TabIndex = 10
        '
        'lbl_CasetActualD2
        '
        Me.lbl_CasetActualD2.BackColor = System.Drawing.SystemColors.Window
        Me.lbl_CasetActualD2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CasetActualD2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CasetActualD2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_CasetActualD2.Location = New System.Drawing.Point(576, 0)
        Me.lbl_CasetActualD2.Name = "lbl_CasetActualD2"
        Me.lbl_CasetActualD2.Size = New System.Drawing.Size(200, 30)
        Me.lbl_CasetActualD2.TabIndex = 3
        Me.lbl_CasetActualD2.Text = "CASET2"
        Me.lbl_CasetActualD2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCasetActual_2
        '
        Me.lblCasetActual_2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCasetActual_2.Location = New System.Drawing.Point(396, 0)
        Me.lblCasetActual_2.Name = "lblCasetActual_2"
        Me.lblCasetActual_2.Size = New System.Drawing.Size(174, 30)
        Me.lblCasetActual_2.TabIndex = 2
        Me.lblCasetActual_2.Text = "Caset Actual"
        Me.lblCasetActual_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CasetDisponibles
        '
        Me.lbl_CasetDisponibles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_CasetDisponibles.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CasetDisponibles.Location = New System.Drawing.Point(3, 46)
        Me.lbl_CasetDisponibles.Name = "lbl_CasetDisponibles"
        Me.lbl_CasetDisponibles.Size = New System.Drawing.Size(174, 32)
        Me.lbl_CasetDisponibles.TabIndex = 4
        Me.lbl_CasetDisponibles.Text = "Caset Nuevo"
        Me.lbl_CasetDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Total2
        '
        Me.lbl_Total2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total2.BackColor = System.Drawing.SystemColors.Window
        Me.lbl_Total2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Total2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total2.Location = New System.Drawing.Point(576, 84)
        Me.lbl_Total2.Name = "lbl_Total2"
        Me.lbl_Total2.Size = New System.Drawing.Size(200, 32)
        Me.lbl_Total2.TabIndex = 11
        Me.lbl_Total2.Text = "$ 0.00"
        Me.lbl_Total2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Caset
        '
        Me.cmb_Caset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_Caset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Caset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Caset.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Caset.FormattingEnabled = True
        Me.cmb_Caset.Location = New System.Drawing.Point(186, 35)
        Me.cmb_Caset.MaxDropDownItems = 20
        Me.cmb_Caset.Name = "cmb_Caset"
        Me.cmb_Caset.Size = New System.Drawing.Size(200, 40)
        Me.cmb_Caset.TabIndex = 5
        '
        'lblTotalcaset_2
        '
        Me.lblTotalcaset_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalcaset_2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalcaset_2.Location = New System.Drawing.Point(396, 84)
        Me.lblTotalcaset_2.Name = "lblTotalcaset_2"
        Me.lblTotalcaset_2.Size = New System.Drawing.Size(174, 32)
        Me.lblTotalcaset_2.TabIndex = 10
        Me.lblTotalcaset_2.Text = "Importe"
        Me.lblTotalcaset_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CasetActualD
        '
        Me.lbl_CasetActualD.BackColor = System.Drawing.SystemColors.Window
        Me.lbl_CasetActualD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CasetActualD.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CasetActualD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_CasetActualD.Location = New System.Drawing.Point(186, 0)
        Me.lbl_CasetActualD.Name = "lbl_CasetActualD"
        Me.lbl_CasetActualD.Size = New System.Drawing.Size(200, 30)
        Me.lbl_CasetActualD.TabIndex = 1
        Me.lbl_CasetActualD.Text = "CASET1"
        Me.lbl_CasetActualD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCasetnuevo_2
        '
        Me.lblCasetnuevo_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCasetnuevo_2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCasetnuevo_2.Location = New System.Drawing.Point(396, 46)
        Me.lblCasetnuevo_2.Name = "lblCasetnuevo_2"
        Me.lblCasetnuevo_2.Size = New System.Drawing.Size(174, 32)
        Me.lblCasetnuevo_2.TabIndex = 6
        Me.lblCasetnuevo_2.Text = "Caset Nuevo"
        Me.lblCasetnuevo_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Subtotal1
        '
        Me.lbl_Subtotal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Subtotal1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Subtotal1.Location = New System.Drawing.Point(3, 84)
        Me.lbl_Subtotal1.Name = "lbl_Subtotal1"
        Me.lbl_Subtotal1.Size = New System.Drawing.Size(174, 32)
        Me.lbl_Subtotal1.TabIndex = 8
        Me.lbl_Subtotal1.Text = "Importe"
        Me.lbl_Subtotal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_Caset2
        '
        Me.cmb_Caset2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_Caset2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Caset2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Caset2.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Caset2.FormattingEnabled = True
        Me.cmb_Caset2.Location = New System.Drawing.Point(576, 35)
        Me.cmb_Caset2.MaxDropDownItems = 20
        Me.cmb_Caset2.Name = "cmb_Caset2"
        Me.cmb_Caset2.Size = New System.Drawing.Size(200, 40)
        Me.cmb_Caset2.TabIndex = 7
        '
        'lbl_Total1
        '
        Me.lbl_Total1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Total1.BackColor = System.Drawing.SystemColors.Window
        Me.lbl_Total1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Total1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total1.Location = New System.Drawing.Point(186, 84)
        Me.lbl_Total1.Name = "lbl_Total1"
        Me.lbl_Total1.Size = New System.Drawing.Size(204, 32)
        Me.lbl_Total1.TabIndex = 9
        Me.lbl_Total1.Text = "$ 0.00"
        Me.lbl_Total1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(627, 402)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(164, 75)
        Me.btn_Cerrar.TabIndex = 14
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'lbl_ImporteOtros
        '
        Me.lbl_ImporteOtros.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ImporteOtros.Location = New System.Drawing.Point(302, 6)
        Me.lbl_ImporteOtros.Name = "lbl_ImporteOtros"
        Me.lbl_ImporteOtros.Size = New System.Drawing.Size(206, 32)
        Me.lbl_ImporteOtros.TabIndex = 1
        Me.lbl_ImporteOtros.Text = "Importe Manual"
        Me.lbl_ImporteOtros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_Recolectar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Recolectar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retiro"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.pnl_General.PerformLayout()
        Me.tlp_DatosCaset.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_SaldoGeneral As System.Windows.Forms.Label
    Friend WithEvents lbl_CiaTV As System.Windows.Forms.Label
    Friend WithEvents lbl_CasetActual As System.Windows.Forms.Label
    Friend WithEvents lbl_CiaTVD As System.Windows.Forms.Label
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents tlp_DatosCaset As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Subtotal1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Total2 As System.Windows.Forms.Label
    Friend WithEvents lbl_CasetActualD2 As System.Windows.Forms.Label
    Friend WithEvents lblCasetActual_2 As System.Windows.Forms.Label
    Friend WithEvents lblCasetnuevo_2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalcaset_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_CasetActualD As System.Windows.Forms.Label
    Friend WithEvents cmb_Caset2 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_CasetDisponibles As System.Windows.Forms.Label
    Friend WithEvents cmb_Caset As System.Windows.Forms.ComboBox
    Friend WithEvents tbx_Envase As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Envase As System.Windows.Forms.Label
    Friend WithEvents tbx_ImporteOtros As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Observaciones As System.Windows.Forms.Label
    Friend WithEvents tbx_Remision As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ImporteOtros As System.Windows.Forms.Label
    Friend WithEvents lbl_Remision As System.Windows.Forms.Label
    Friend WithEvents tbx_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents lbl_Total1 As System.Windows.Forms.Label
End Class
