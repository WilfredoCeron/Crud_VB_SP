Imports System.Data.SqlClient
Imports System.Data.Sql

#Region "Conexion"
Public Class Conexion
    'variables de clases'
    Dim conexionDB As SqlConnection
    Dim cmd As SqlCommand
    Sub New()
        Try
            conexionDB = New SqlConnection("Data Source=localhost;Initial Catalog=pruebaVidri;Integrated Security=True")
            conexionDB.Open()
            MsgBox("Conectado")
        Catch ex As Exception
            MsgBox("No se ha conectado" * ex.Message)
        End Try
    End Sub
#End Region

#Region "Insertar Persona" 'inserta a la tabla persona mediante procediminetos almacenados '
    Function Insertar(ByVal dui As String, ByVal nombre As String, ByVal edad As Integer, ByVal contra As String, ByVal fecha As Date) As String
        Dim salida As String = "Se inserto Correctamente"

        Try
            cmd = New SqlCommand("sp_persona", conexionDB)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@dui", dui)
                .AddWithValue("@nombre", nombre)
                .AddWithValue("@edad", edad)
                .AddWithValue("@contra", contra)
                .AddWithValue("@fecha", fecha)
                .AddWithValue("@identificador", "I")
            End With

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            salida = "No se inserto debido a " + ex.Message
        End Try
        Return salida
    End Function
#End Region

#Region "Eliminar Persona" 'Elimina un regitro de la tabla persona mediante el procedimiento almacenado'
    Function eliminar(ByVal dui As String) As String
        Dim salida As String = "Se elimino correctamente"
        Try
            cmd = New SqlCommand("sp_persona", conexionDB)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@dui", dui)
                .AddWithValue("@identificador", "D")
            End With

            cmd.ExecuteNonQuery()


        Catch ex As Exception
            salida = "No se elimino debido a " + ex.Message
        End Try

        Return salida
    End Function
#End Region

#Region "Actualizar Persona"
    Function Actualizar(ByVal dui As String, ByVal nombre As String, ByVal edad As Integer, ByVal contra As String, ByVal fecha As Date) As String
        Dim salida As String = "Se inserto Correctamente"

        Try
            cmd = New SqlCommand("sp_persona", conexionDB)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@dui", dui)
                .AddWithValue("@nombre", nombre)
                .AddWithValue("@edad", edad)
                .AddWithValue("@contra", contra)
                .AddWithValue("@fecha", fecha)
                .AddWithValue("@identificador", "U")
            End With

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            salida = "No se inserto debido a " + ex.Message
        End Try
        Return salida
    End Function
#End Region
End Class
