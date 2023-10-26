<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Lista_Cajas
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
        Me.tmr_ColaImpresion = New System.Windows.Forms.Timer(Me.components)
        Me.btn_Cerrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tmr_ColaImpresion
        '
        Me.tmr_ColaImpresion.Interval = 1000
        '
        'btn_Cerrar
        '
        Me.btn_Cerrar.AutoSize = True
        Me.btn_Cerrar.CausesValidation = False
        Me.btn_Cerrar.FlatAppearance.BorderSize = 0
        Me.btn_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Cerrar.Font = New System.Drawing.Font("Times New Roman", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cerrar.Location = New System.Drawing.Point(8, 2)
        Me.btn_Cerrar.Name = "btn_Cerrar"
        Me.btn_Cerrar.Size = New System.Drawing.Size(51, 25)
        Me.btn_Cerrar.TabIndex = 0
        Me.btn_Cerrar.Text = "[Cerrar]"
        Me.btn_Cerrar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cerrar.UseVisualStyleBackColor = True
        '
        'frm_Lista_Cajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Orange
        Me.ClientSize = New System.Drawing.Size(321, 199)
        Me.Controls.Add(Me.btn_Cerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "frm_Lista_Cajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cajas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmr_ColaImpresion As System.Windows.Forms.Timer
    Friend WithEvents btn_Cerrar As System.Windows.Forms.Button
End Class
