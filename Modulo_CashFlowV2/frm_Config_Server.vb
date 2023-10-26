
Imports System.Configuration
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Net
Imports System.Data.SQLite

Public Class frm_Config_Server
    Private servidores As SqlDataSourceEnumerator
    Private Tbl_Servidores As DataTable




    'Public Shared Function fn_GetComputerName() As String
    '    fn_GetComputerName = System.Net.Dns.GetHostName
    'End Function

    'Public Shared Function fn_GetComputerIP() As String
    '    Dim hostName As String = Dns.GetHostName()
    '    Dim host As IPHostEntry = Dns.GetHostEntry(hostName)

    '    Dim firstAddress As IPAddress = host.AddressList(0)
    '    fn_GetComputerIP = firstAddress.ToString
    'End Function
    Private Sub frm_Config_Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim hostName As String = Dns.GetHostName()
        'Dim host As IPHostEntry = Dns.GetHostEntry(hostName)

        'Dim firstAddress As IPAddress = host.AddressList(1)

        'tbx_Server.Text = firstAddress.ToString

        '-----------------------------------------------------------------------------------------

        'If My.Settings.ServerName <> "" Then
        '    'tbx_Servidor.Text = My.Settings.ServerName
        'End If
        'If My.Settings.PrdOPrb = 1 Then
        '    cb_produccion.Checked = True
        '    cb_pruebas.Checked = False
        'ElseIf My.Settings.PrdOPrb = 2 Then
        '    cb_produccion.Checked = False
        '    cb_pruebas.Checked = True
        'End If

        '----------------------------------------------------------------------------------

    End Sub

    Private Sub cb_produccion_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cb_pruebas_CheckedChanged(sender As Object, e As EventArgs)

    End Sub



    Function Test_Conexion(ByVal Cnx As String) As Boolean
        Try
            Dim connection As SqlConnection = New SqlConnection(Cnx)
            connection.Open()

            If (connection.State And ConnectionState.Open) > 0 Then
                connection.Close()
                Return True
            Else
                Return False
            End If

        Catch
            Return False
        End Try
    End Function
    Public Function Existe_Configuracion() As Boolean
        Using conexion As SQLiteConnection = New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
            conexion.Open()
            Dim query As String = "select * from Parametros"
            Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)
            cmd.CommandType = System.Data.CommandType.Text

            Using dr As SQLiteDataReader = cmd.ExecuteReader()

                If dr.Read() Then
                    Return True
                End If
            End Using
        End Using
        Return False
    End Function
    Public Function Guardar_Configuracion(ByVal Server As String) As Boolean
        Dim _Conexion As String
        Dim query As String

        If (Server.ToUpper = "SQL-MTY-T01") Then
            _Conexion = "Data Source=" + Server + ";Initial Catalog=CashFlow; User id=SIACMOVIL; pwd=SisTema.SIACLogin"
        Else
            _Conexion = "Data Source=" + Server + ";Initial Catalog=CashFlow; Integrated Security=True"
        End If
        If (Test_Conexion(_Conexion)) Then
            Try
                Using conexion As SQLiteConnection = New SQLiteConnection(ConfigurationManager.ConnectionStrings("cadenaSQLite").ConnectionString)
                    conexion.Open()
                    '""
                    query = "Insert Into Parametros (ServerName,Cnx) Values( @ServerName,@Cnx)"
                    If Existe_Configuracion() Then
                        query = "update Parametros set ServerName = @ServerName , Cnx = @Cnx"
                    End If
                    Dim cmd As SQLiteCommand = New SQLiteCommand(query, conexion)
                    cmd.Parameters.Add(New SQLiteParameter("@ServerName", Server))
                    cmd.Parameters.Add(New SQLiteParameter("@Cnx", _Conexion))
                    cmd.CommandType = System.Data.CommandType.Text

                    If cmd.ExecuteNonQuery() < 1 Then
                        Variables._ServerName = ""
                        Variables._Cnx = ""
                        Return False
                    End If
                    Variables._ServerName = Server
                    Variables._Cnx = _Conexion
                    Return True
                End Using
            Catch ex As Exception
                Variables._ServerName = ""
                Variables._Cnx = ""
                Return False
            End Try
        Else
            Variables._ServerName = ""
            Variables._Cnx = ""
            Return False
        End If
    End Function

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        If (Guardar_Configuracion(tbx_Server.Text)) Then
            Me.Close()
        End If
    End Sub

    Private Sub ReiniciarMedidasEscritorio()

    End Sub

    Private Sub tbx_Servidor_Click(sender As Object, e As EventArgs)
        varPub.SegundosSesion = 0

        ReiniciarMedidasEscritorio()
    End Sub
    Private Sub Reestablecer_TecladoLogin()

    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click

        Variables._ServerName = ""
        Close()
    End Sub
End Class