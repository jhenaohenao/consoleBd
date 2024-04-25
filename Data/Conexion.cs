using Microsoft.Data.SqlClient;
using System.Data;

namespace Data
{
    public class Conexion
    {
        // private readonly string _cadena = $"Server=.;DataBase=APIColombia;User=henao88;Password=asd123;TrustServerCertificate=True";
        private string _cadena;
        public Conexion(string servidor, string bd, string usuario, string password) 
        {
            _cadena = $"Server={servidor};Database={bd};User={usuario};Password={password};TrustServerCertificate=True";
        }
        public DataSet ObtenerUsuariosSinSincronizar()
        {
            DataSet ds = new DataSet();
            using SqlConnection conn = new SqlConnection(_cadena); //cerrar conexión al finalizar el proceso: Using permiten que todo el código dentro de un bloque using se cierre en cuanto sale del bloque

            var query = "ConsultarUsuariosNoSincronizados";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido un error al conectar o ejecutar la consulta, {ex.Message}");
            }
        }

        public bool ActualizarSincronizado(int idUsuario)
        {
            using SqlConnection conn = new SqlConnection(_cadena); 
            var query = "GuardarUsuarioSincronizado";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioId", idUsuario);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
         


            }
            catch (Exception ex)
            {
                throw new Exception($"Se ha producido un error al guardar el sincronizado, {ex.Message}");
            }
        }
    }
}
