<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_MenuGeneral
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
        Me.tbLP_Botones = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_AlertaUpdate = New System.Windows.Forms.Label()
        Me.tmr_ColaImpresion = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbLP_Botones
        '
        Me.tbLP_Botones.ColumnCount = 4
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tbLP_Botones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbLP_Botones.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLP_Botones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbLP_Botones.Location = New System.Drawing.Point(0, 0)
        Me.tbLP_Botones.Name = "tbLP_Botones"
        Me.tbLP_Botones.RowCount = 6
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tbLP_Botones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tbLP_Botones.Size = New System.Drawing.Size(800, 480)
        Me.tbLP_Botones.TabIndex = 21
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_AlertaUpdate)
        Me.Panel1.Controls.Add(Me.tbLP_Botones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 480)
        Me.Panel1.TabIndex = 22
        '
        'lbl_AlertaUpdate
        '
        Me.lbl_AlertaUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_AlertaUpdate.BackColor = System.Drawing.Color.Red
        Me.lbl_AlertaUpdate.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_AlertaUpdate.ForeColor = System.Drawing.Color.Yellow
        Me.lbl_AlertaUpdate.Location = New System.Drawing.Point(-3, 455)
        Me.lbl_AlertaUpdate.Name = "lbl_AlertaUpdate"
        Me.lbl_AlertaUpdate.Size = New System.Drawing.Size(488, 25)
        Me.lbl_AlertaUpdate.TabIndex = 22
        Me.lbl_AlertaUpdate.Text = "Hay una nueva actualizacion del sistema"
        Me.lbl_AlertaUpdate.Visible = False
        '
        'tmr_ColaImpresion
        '
        Me.tmr_ColaImpresion.Interval = 1000
        '
        'frm_MenuGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 480)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_MenuGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu General"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbLP_Botones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_AlertaUpdate As System.Windows.Forms.Label
    Friend WithEvents tmr_ColaImpresion As System.Windows.Forms.Timer
End Class
