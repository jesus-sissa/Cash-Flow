Imports Modulo_CashFlowV2.cls_CashFlow
Imports System.IO
Imports Modulo_CashFlowV2.cls_FuncionesPublicas
Imports System.Data.SQLite
Imports System.Configuration

Public Class frm_ConsultaLog
    Dim Anterior As Integer = 0
    Dim Inicio As Integer = 0
    Dim Final As Integer = 0
    Dim str_fecha() As String
    Public Fecha As Date

#Region "Funciones Privadas"
    Private Sub CambiarTamanodelosControles()
        Call fn_CambiaTamanoFuente(Me, varPub.TamañoFuente_Etiqueta, varPub.TamañoFuente_Botones)
    End Sub



#End Region

    Private Sub frm_ConsultaLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VARIABLE QUE INDICA QUE ID ES LA PANTALLA

        varPub.IdPantalla = 14

        'Dim FechaActual As Date = Date.Today
        'Dim FechaCalculo As String = FechaActual.AddDays(-30)
        Call fn_EliminarLog()

        Call CambiarTamanodelosControles()


        lsv_Detalle.Columns.Add("Id_Log", 80)
        lsv_Detalle.Columns.Add("Fecha", 200)
        lsv_Detalle.Columns.Add("Hora", 200)
        lsv_Detalle.Columns.Add("Usuario", 200)
        lsv_Detalle.Columns.Add("Pantalla", 200)
        lsv_Detalle.Columns.Add("Accion", 300)
        'lsv_Detalle.Columns.Add("Pantalla", 80)
        'lsv_Detalle.Columns.Add("Acción", 80)

        'For i As Byte = 0 To lsv_Detalle.Columns.Count - 1
        '    lsv_Detalle.Columns(i).Width = -2
        'Next

        btn_FechaDesde.Text = CDate(Date.Now.ToShortDateString)

        Get_log(Date.Now)

    End Sub


    Function Get_log(ByVal fecha As String)
        Dim query As String
        Dim fech(5) As String
        If fecha.Contains(" ") Then
            fech = fecha.Split(" ")
        Else
            fech(0) = fecha
        End If

        Using conexion As New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
            conexion.Open()
            '""
            query = "Select Id_Log,Usuario,Pantalla,Accion,strftime(Fecha),Hora From  Tbl_Log Where Fecha = @Fecha ORDER BY Id_Log DESC"
            Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)
            cmd.Parameters.AddWithValue("@fecha", String.Format("{0:yyyy'-'MM'-'dd}", DateTime.Parse(fech(0))))
            ' cmd.Parameters.AddWithValue("$Fecha", fech(0))

            Using read As SQLiteDataReader = cmd.ExecuteReader()
                lsv_Detalle.Items.Clear()

                While (read.Read())

                    Dim obj As New ListViewItem(read(0).ToString)

                    obj.SubItems.Add(read(4).ToString)
                    obj.SubItems.Add(read(1).ToString)
                    obj.SubItems.Add(read(5).ToString)
                    obj.SubItems.Add(read(2).ToString)
                    obj.SubItems.Add(read(3).ToString)

                    lsv_Detalle.Items.Add(obj)
                End While
            End Using
        End Using
        Try
        Catch ex As Exception
            Call fn_MsgBox("No se pudo cargar el log.", MessageBoxIcon.Error, True, 2)
        End Try
    End Function

    Public Shared Sub fn_EliminarLog()



        Dim query As String
        Try
            Using conexion As SQLiteConnection = New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
                conexion.Open()
                '""
                query = "Delete From Tbl_Log where Fecha < @Fecha"
                Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)

                Dim f = String.Format("{0:yyyy'-'MM'-'dd}", DateTime.Parse(Date.Now).AddDays(-30))
                cmd.Parameters.Add(New SQLiteParameter("@Fecha", f))

                cmd.CommandType = System.Data.CommandType.Text

                cmd.ExecuteNonQuery()


            End Using
        Catch ex As Exception
            MsgBox("Error  :(")
        End Try

    End Sub





    Private Sub pnl_General_Click(sender As Object, e As EventArgs) Handles pnl_General.Click
        varPub.SegundosSesion = 0
    End Sub

    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        varPub.SegundosSesion = 0
        Me.Close()
    End Sub
    Private Sub lsv_Detalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsv_Detalle.SelectedIndexChanged
        varPub.SegundosSesion = 0
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Dim query As String
        Try
            Using conexion As New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
                conexion.Open()
                '""
                query = "Delete From  Tbl_Log"
                Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)

                cmd.ExecuteNonQuery()

            End Using
            Get_log(Date.Now)
        Catch ex As Exception
            Call fn_MsgBox("No se pudo limpiar el log.", MessageBoxIcon.Error, True, 2)
        End Try
    End Sub

    Private Sub btn_FechaDesde_Click(sender As Object, e As EventArgs) Handles btn_FechaDesde.Click
        varPub.SegundosSesion = 0
        pnl_General.Enabled = False
        Dim frm_Fecha As New frm_FechaModal
        frm_Fecha.Fecha = CDate(btn_FechaDesde.Text)
        frm_Fecha.Location = New Point(btn_FechaDesde.Location.X, (btn_FechaDesde.Location.Y + btn_FechaDesde.Height + 5))
        frm_Fecha.ShowDialog()
        btn_FechaDesde.Text = frm_Fecha.Fecha
        Get_log(frm_Fecha.Fecha)
        frm_Fecha.Dispose()
        pnl_General.Enabled = True



    End Sub

    Private Sub pnl_General_Paint(sender As Object, e As PaintEventArgs) Handles pnl_General.Paint

    End Sub
End Class