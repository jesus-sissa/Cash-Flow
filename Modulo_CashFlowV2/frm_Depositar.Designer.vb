<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Depositar
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
        Me.gbx_CorteDiario = New System.Windows.Forms.GroupBox()
        Me.btn_DepositoManual = New System.Windows.Forms.Button()
        Me.btn_DepositoXvalidador = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.gbx_CorteDiario.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
        Me.pnl_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.pnl_General.Controls.Add(Me.gbx_CorteDiario)
        Me.pnl_General.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_General.Location = New System.Drawing.Point(0, 0)
        Me.pnl_General.Name = "pnl_General"
        Me.pnl_General.Size = New System.Drawing.Size(800, 480)
        Me.pnl_General.TabIndex = 0
        '
        'gbx_CorteDiario
        '
        Me.gbx_CorteDiario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_CorteDiario.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.gbx_CorteDiario.Controls.Add(Me.btn_DepositoManual)
        Me.gbx_CorteDiario.Controls.Add(Me.btn_DepositoXvalidador)
        Me.gbx_CorteDiario.Controls.Add(Me.btn_Cerrar)
        Me.gbx_CorteDiario.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_CorteDiario.Location = New System.Drawing.Point(12, 12)
        Me.gbx_CorteDiario.Name = "gbx_CorteDiario"
        Me.gbx_CorteDiario.Size = New System.Drawing.Size(776, 456)
        Me.gbx_CorteDiario.TabIndex = 10
        Me.gbx_CorteDiario.TabStop = False
        Me.gbx_CorteDiario.Text = "Modo de Depósito"
        '
        'btn_DepositoManual
        '
        Me.btn_DepositoManual.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DepositoManual.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_DepositoManual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_DepositoManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DepositoManual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DepositoManual.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Buzon
        Me.btn_DepositoManual.Location = New System.Drawing.Point(157, 225)
        Me.btn_DepositoManual.Name = "btn_DepositoManual"
        Me.btn_DepositoManual.Size = New System.Drawing.Size(430, 75)
        Me.btn_DepositoManual.TabIndex = 32
        Me.btn_DepositoManual.Text = "Depósito Manual"
        Me.btn_DepositoManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DepositoManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_DepositoManual.UseVisualStyleBackColor = False
        Me.btn_DepositoManual.Visible = False
        '
        'btn_DepositoXvalidador
        '
        Me.btn_DepositoXvalidador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DepositoXvalidador.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_DepositoXvalidador.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_DepositoXvalidador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DepositoXvalidador.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DepositoXvalidador.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_ValidarBilletes
        Me.btn_DepositoXvalidador.Location = New System.Drawing.Point(157, 97)
        Me.btn_DepositoXvalidador.Name = "btn_DepositoXvalidador"
        Me.btn_DepositoXvalidador.Size = New System.Drawing.Size(430, 75)
        Me.btn_DepositoXvalidador.TabIndex = 30
        Me.btn_DepositoXvalidador.Text = "Depósito por Validador"
        Me.btn_DepositoXvalidador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DepositoXvalidador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_DepositoXvalidador.UseVisualStyleBackColor = False
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btn_Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.btn_CerrarSesion
        Me.btn_Cerrar.Location = New System.Drawing.Point(157, 349)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(430, 75)
        Me.btn_Cerrar.TabIndex = 9
        Me.btn_Cerrar.Text = "&Cerrar"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Cerrar.UseVisualStyleBackColor = False
        '
        'frm_Depositar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Depositar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depositar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.gbx_CorteDiario.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents gbx_CorteDiario As System.Windows.Forms.GroupBox
    Friend WithEvents btn_DepositoXvalidador As System.Windows.Forms.Button
    Friend WithEvents btn_DepositoManual As System.Windows.Forms.Button
End Class
