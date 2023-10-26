<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_FechaModal
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
        Me.pnl_Fecha = New System.Windows.Forms.Panel()
        Me.btn_YearDown = New System.Windows.Forms.Button()
        Me.btn_MesDown = New System.Windows.Forms.Button()
        Me.btn_YearUp = New System.Windows.Forms.Button()
        Me.btn_MesUp = New System.Windows.Forms.Button()
        Me.btn_DiaUp = New System.Windows.Forms.Button()
        Me.btn_DiaDown = New System.Windows.Forms.Button()
        Me.btn_FechaAceptar = New System.Windows.Forms.Button()
        Me.pnl_Fecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Fecha
        '
        Me.pnl_Fecha.Controls.Add(Me.btn_YearDown)
        Me.pnl_Fecha.Controls.Add(Me.btn_MesDown)
        Me.pnl_Fecha.Controls.Add(Me.btn_YearUp)
        Me.pnl_Fecha.Controls.Add(Me.btn_MesUp)
        Me.pnl_Fecha.Controls.Add(Me.btn_DiaUp)
        Me.pnl_Fecha.Controls.Add(Me.btn_DiaDown)
        Me.pnl_Fecha.Controls.Add(Me.btn_FechaAceptar)
        Me.pnl_Fecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Fecha.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Fecha.Name = "pnl_Fecha"
        Me.pnl_Fecha.Size = New System.Drawing.Size(296, 237)
        Me.pnl_Fecha.TabIndex = 0
        '
        'btn_YearDown
        '
        Me.btn_YearDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_YearDown.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.img_Bajar
        Me.btn_YearDown.Location = New System.Drawing.Point(174, 170)
        Me.btn_YearDown.Name = "btn_YearDown"
        Me.btn_YearDown.Size = New System.Drawing.Size(112, 48)
        Me.btn_YearDown.TabIndex = 6
        Me.btn_YearDown.Tag = "1"
        Me.btn_YearDown.UseVisualStyleBackColor = False
        '
        'btn_MesDown
        '
        Me.btn_MesDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_MesDown.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.img_Bajar
        Me.btn_MesDown.Location = New System.Drawing.Point(90, 170)
        Me.btn_MesDown.Name = "btn_MesDown"
        Me.btn_MesDown.Size = New System.Drawing.Size(76, 48)
        Me.btn_MesDown.TabIndex = 5
        Me.btn_MesDown.Tag = "1"
        Me.btn_MesDown.UseVisualStyleBackColor = False
        '
        'btn_YearUp
        '
        Me.btn_YearUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_YearUp.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.img_Subir
        Me.btn_YearUp.Location = New System.Drawing.Point(174, 20)
        Me.btn_YearUp.Name = "btn_YearUp"
        Me.btn_YearUp.Size = New System.Drawing.Size(112, 55)
        Me.btn_YearUp.TabIndex = 2
        Me.btn_YearUp.Tag = "1"
        Me.btn_YearUp.UseVisualStyleBackColor = False
        '
        'btn_MesUp
        '
        Me.btn_MesUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_MesUp.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.img_Subir
        Me.btn_MesUp.Location = New System.Drawing.Point(90, 20)
        Me.btn_MesUp.Name = "btn_MesUp"
        Me.btn_MesUp.Size = New System.Drawing.Size(76, 55)
        Me.btn_MesUp.TabIndex = 1
        Me.btn_MesUp.Tag = "1"
        Me.btn_MesUp.UseVisualStyleBackColor = False
        '
        'btn_DiaUp
        '
        Me.btn_DiaUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_DiaUp.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.img_Subir
        Me.btn_DiaUp.Location = New System.Drawing.Point(6, 20)
        Me.btn_DiaUp.Name = "btn_DiaUp"
        Me.btn_DiaUp.Size = New System.Drawing.Size(76, 55)
        Me.btn_DiaUp.TabIndex = 0
        Me.btn_DiaUp.Tag = "1"
        Me.btn_DiaUp.UseVisualStyleBackColor = False
        '
        'btn_DiaDown
        '
        Me.btn_DiaDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.btn_DiaDown.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.img_Bajar
        Me.btn_DiaDown.Location = New System.Drawing.Point(6, 170)
        Me.btn_DiaDown.Name = "btn_DiaDown"
        Me.btn_DiaDown.Size = New System.Drawing.Size(76, 48)
        Me.btn_DiaDown.TabIndex = 4
        Me.btn_DiaDown.Tag = "1"
        Me.btn_DiaDown.UseVisualStyleBackColor = False
        '
        'btn_FechaAceptar
        '
        Me.btn_FechaAceptar.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FechaAceptar.Image = Global.Modulo_CashFlowV2.My.Resources.Resources.Aceptar
        Me.btn_FechaAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_FechaAceptar.Location = New System.Drawing.Point(6, 85)
        Me.btn_FechaAceptar.Name = "btn_FechaAceptar"
        Me.btn_FechaAceptar.Size = New System.Drawing.Size(280, 75)
        Me.btn_FechaAceptar.TabIndex = 3
        Me.btn_FechaAceptar.Text = "06  /  08  /  2016"
        Me.btn_FechaAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_FechaAceptar.UseVisualStyleBackColor = True
        '
        'frm_FechaModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnl_Fecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_FechaModal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.pnl_Fecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Fecha As System.Windows.Forms.Panel
    Friend WithEvents btn_DiaUp As System.Windows.Forms.Button
    Friend WithEvents btn_DiaDown As System.Windows.Forms.Button
    Friend WithEvents btn_FechaAceptar As System.Windows.Forms.Button
    Friend WithEvents btn_YearDown As System.Windows.Forms.Button
    Friend WithEvents btn_MesDown As System.Windows.Forms.Button
    Friend WithEvents btn_YearUp As System.Windows.Forms.Button
    Friend WithEvents btn_MesUp As System.Windows.Forms.Button
End Class
