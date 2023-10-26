Imports System.Data.SqlServerCe
Imports dataconection.cls_DatosSQLCE
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class frm_SQLCE4_Toolbox

    Private Sub frm_SQLCE4_Toolbox_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub frm_SQLCE4_Toolbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbx_Mensajes.Visible = False
        'spc_Consultas.Panel2Collapsed = True

        If forma_teclado <> kbcustom.Tecladocontrol.TipoTeclado.COMPLETO Then
            forma_teclado = kbcustom.Tecladocontrol.TipoTeclado.COMPLETO
            ctrlTeclado.RedimensionarForm(forma_teclado, varTecl.AnchoPantalla, varTecl.AltoPantalla)
            ctrlTeclado.Size = New Size(ctrlTeclado.Width, ctrlTeclado.Height)
        End If

        varTecl.ubicaX_Teclado = 0
        varTecl.ubicaY_Teclado = (Me.Height - ctrlTeclado.Height)
        varTecl.PuntoNew_Teclado = New Point(varTecl.ubicaX_Teclado, varTecl.ubicaY_Teclado)

    End Sub

    Private Sub tsb_Cerrar_Click(sender As Object, e As EventArgs) Handles tsb_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub tsb_Ejecutar_Click(sender As Object, e As EventArgs) Handles tsb_Ejecutar.Click


    End Sub

    Private Sub rtb_Consulta_Click(sender As Object, e As EventArgs) Handles rtb_Consulta.Click
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(rtb_Consulta) = True
    End Sub

    Private Sub pnl_Actualizacion_Click(sender As Object, e As EventArgs) Handles pnl_Actualizacion.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub sts_Status_Click(sender As Object, e As EventArgs) Handles sts_Status.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub tls_Botones_Click(sender As Object, e As EventArgs) Handles tls_Botones.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub lbl_LineaDivisoria_Click(sender As Object, e As EventArgs) Handles lbl_LineaDivisoria.Click
        ctrlTeclado.Hide()
        varPub.SegundosSesion = 0
    End Sub

    Private Sub rtb_Consulta_Enter(sender As Object, e As EventArgs) Handles rtb_Consulta.Enter
        varPub.SegundosSesion = 0
        ctrlTeclado.Location = varTecl.PuntoNew_Teclado
        ctrlTeclado.Show()
        Teclado_RecibirControl(rtb_Consulta) = True
    End Sub

    Private Sub rtb_Consulta_TextChanged(sender As Object, e As EventArgs) Handles rtb_Consulta.TextChanged
        varPub.SegundosSesion = 0

        Dim wordsRED As New List(Of String)
        Dim wordsBLUE As New List(Of String)
        Dim wordsGRAY As New List(Of String)
        Dim wordsFUCHSIA As New List(Of String)

        'Red Word List
        wordsRED.Add("'")

        'Blue Word List
        wordsBLUE.Add("SELECT")
        wordsBLUE.Add("ALTER")
        wordsBLUE.Add("FROM")
        wordsBLUE.Add("SET")
        wordsBLUE.Add("WHERE")
        wordsBLUE.Add("DROP")
        wordsBLUE.Add("TABLE")
        wordsBLUE.Add("INSERT")
        wordsBLUE.Add("INTO")
        wordsBLUE.Add("DELETE")
        wordsBLUE.Add("VALUES")

        ' PALABRAS GRISES
        wordsGRAY.Add("AND")
        wordsGRAY.Add("OR")
        wordsGRAY.Add(">")
        wordsGRAY.Add("<")
        wordsGRAY.Add("=")
        wordsGRAY.Add(")")
        wordsGRAY.Add("(")
        wordsGRAY.Add("*")
        wordsGRAY.Add("+")

        'PALABRAS FUCHSIA
        wordsFUCHSIA.Add("UPDATE")
        wordsFUCHSIA.Add("GETDATE")

        If rtb_Consulta.Text.Length > 0 Then

            Dim selectStart As Integer = rtb_Consulta.SelectionStart
            rtb_Consulta.Select(0, rtb_Consulta.Text.Length)

            rtb_Consulta.SelectionColor = Color.Black
            rtb_Consulta.DeselectAll()

            'Red Colored Words
            For Each oneWord As String In wordsRED
                Dim pos As Integer = 0

                Do While rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0
                    pos = rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)
                    rtb_Consulta.Select(pos, oneWord.Length)
                    rtb_Consulta.SelectionColor = Color.Red
                    pos += 1
                Loop
            Next
            rtb_Consulta.SelectionLength = 0 ' new
            rtb_Consulta.SelectionStart = selectStart


            'Blue Colored Words
            For Each oneWord As String In wordsBLUE
                Dim pos As Integer = 0

                Do While rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0
                    pos = rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)
                    rtb_Consulta.Select(pos, oneWord.Length)
                    rtb_Consulta.SelectionColor = Color.Blue
                    pos += 1
                Loop
            Next
            rtb_Consulta.SelectionLength = 0 ' new
            rtb_Consulta.SelectionStart = selectStart


            'Purple Colored Words
            For Each oneWord As String In wordsGRAY
                Dim pos As Integer = 0

                Do While rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0
                    pos = rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)
                    rtb_Consulta.Select(pos, oneWord.Length)
                    rtb_Consulta.SelectionColor = Color.Gray
                    pos += 1
                Loop
            Next
            rtb_Consulta.SelectionLength = 0 ' new
            rtb_Consulta.SelectionStart = selectStart


            'Green Colored Words
            For Each oneWord As String In wordsFUCHSIA
                Dim pos As Integer = 0

                Do While rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos) >= 0
                    pos = rtb_Consulta.Text.ToUpper.IndexOf(oneWord.ToUpper, pos)
                    rtb_Consulta.Select(pos, oneWord.Length)
                    rtb_Consulta.SelectionColor = Color.Fuchsia
                    pos += 1
                Loop
            Next
            rtb_Consulta.SelectionLength = 0 ' new
            rtb_Consulta.SelectionStart = selectStart
        End If

    End Sub

    Private Sub tls_Botones_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tls_Botones.ItemClicked

    End Sub
End Class