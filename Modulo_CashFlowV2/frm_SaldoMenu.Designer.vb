<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SaldoMenu
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
        Me.btn_DiaActualCompleto = New System.Windows.Forms.Button()
        Me.btn_DiaActual = New System.Windows.Forms.Button()
        Me.btn_UltimaRecoleccion = New System.Windows.Forms.Button()
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.pnl_General.SuspendLayout()
        Me.gbx_CorteDiario.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_General
        '
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
        Me.gbx_CorteDiario.Controls.Add(Me.btn_DiaActualCompleto)
        Me.gbx_CorteDiario.Controls.Add(Me.btn_DiaActual)
        Me.gbx_CorteDiario.Controls.Add(Me.btn_UltimaRecoleccion)
        Me.gbx_CorteDiario.Controls.Add(Me.btn_Cerrar)
        Me.gbx_CorteDiario.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbx_CorteDiario.Location = New System.Drawing.Point(12, 12)
        Me.gbx_CorteDiario.Name = "gbx_CorteDiario"
        Me.gbx_CorteDiario.Size = New System.Drawing.Size(776, 456)
        Me.gbx_CorteDiario.TabIndex = 10
        Me.gbx_CorteDiario.TabStop = False
        Me.gbx_CorteDiario.Text = "Modo de Corte Diario"
        '
        'btn_DiaActualCompleto
        '
        Me.btn_DiaActualCompleto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DiaActualCompleto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_DiaActualCompleto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DiaActualCompleto.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DiaActualCompleto.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_DiaActualCompleto.Location = New System.Drawing.Point(157, 254)
        Me.btn_DiaActualCompleto.Name = "btn_DiaActualCompleto"
        Me.btn_DiaActualCompleto.Size = New System.Drawing.Size(430, 75)
        Me.btn_DiaActualCompleto.TabIndex = 32
        Me.btn_DiaActualCompleto.Text = "Día Actual Completo"
        Me.btn_DiaActualCompleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DiaActualCompleto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_DiaActualCompleto.UseVisualStyleBackColor = True
        '
        'btn_DiaActual
        '
        Me.btn_DiaActual.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_DiaActual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_DiaActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DiaActual.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DiaActual.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_DiaActual.Location = New System.Drawing.Point(157, 154)
        Me.btn_DiaActual.Name = "btn_DiaActual"
        Me.btn_DiaActual.Size = New System.Drawing.Size(430, 75)
        Me.btn_DiaActual.TabIndex = 31
        Me.btn_DiaActual.Text = "Día Actual "
        Me.btn_DiaActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DiaActual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_DiaActual.UseVisualStyleBackColor = True
        '
        'btn_UltimaRecoleccion
        '
        Me.btn_UltimaRecoleccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_UltimaRecoleccion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_UltimaRecoleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_UltimaRecoleccion.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_UltimaRecoleccion.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Imprimir
        Me.btn_UltimaRecoleccion.Location = New System.Drawing.Point(157, 51)
        Me.btn_UltimaRecoleccion.Name = "btn_UltimaRecoleccion"
        Me.btn_UltimaRecoleccion.Size = New System.Drawing.Size(430, 75)
        Me.btn_UltimaRecoleccion.TabIndex = 30
        Me.btn_UltimaRecoleccion.Text = "Desde última Recolección"
        Me.btn_UltimaRecoleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_UltimaRecoleccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_UltimaRecoleccion.UseVisualStyleBackColor = True
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.Anchor = System.Windows.Forms.AnchorStyles.None
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
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'frm_CorteDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.pnl_General)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_CorteDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corte Diario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnl_General.ResumeLayout(False)
        Me.gbx_CorteDiario.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_General As System.Windows.Forms.Panel
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
    Friend WithEvents gbx_CorteDiario As System.Windows.Forms.GroupBox
    Friend WithEvents btn_UltimaRecoleccion As System.Windows.Forms.Button
    Friend WithEvents btn_DiaActual As System.Windows.Forms.Button
    Friend WithEvents btn_DiaActualCompleto As System.Windows.Forms.Button
End Class
