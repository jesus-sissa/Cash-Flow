Imports System.Data.OleDb
Imports Modulo_CashFlowV2.cls_FuncionesPublicas

Public Class cls_Oledb

    Public Shared Function Crear_CnxOledb(Conexion As String) As Boolean
        Dim con = New OleDbConnection()
        con.ConnectionString = Conexion
        con.Open()
        con.Dispose()
        Return True
    End Function
    Public Shared Function fn_ValidarFolio_Oledb(folio As String) As DataTable
        Dim conn = New OleDbConnection()
        Dim oledbAdapter As New OleDbDataAdapter
        Dim ds As New DataTable
        Try
            conn.ConnectionString = "provider=SQLOLEDB;" & varPub.CajasCnx
            conn.Open()
            oledbAdapter.SelectCommand = New OleDbCommand("Select Codigo From ViewFoliosSissaNoVerificados Where Codigo = '" & folio & "'", conn)
            oledbAdapter.Fill(ds)
            oledbAdapter.Dispose()
            conn.Close()
            conn.Dispose()
            Return ds
        Catch ex As Exception
            Call fn_EscribirLog(varPub.UsuarioClave, "DEPOSITOS", ":ERROR AL CONSULTAR FOLIO  ")
            conn.Close()
            conn.Dispose()
            'Call fn_MsgBox("Error al consultar el folio.", MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function
End Class
