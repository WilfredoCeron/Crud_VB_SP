Public Class Form1

    'instancia de la conexion'
    Public oConexion As New Conexion
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        MsgBox(oConexion.Insertar(txtDui.Text, txtNombre.Text, Conversion.Int(txtEdad.Text), txtPass.Text, CDate(ddldate.Value)))
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtDui.Text.Equals("") Then

        Else
            MsgBox(oConexion.eliminar(txtDui.Text))
        End If
    End Sub
End Class
