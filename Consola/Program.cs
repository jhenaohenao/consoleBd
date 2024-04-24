//Cadena de conexión: Servidor;Base de dtos;usuario;clave

using Microsoft.Data.SqlClient;

var Servidor = string.Empty;
var Bd = string.Empty;
var Usuario = string.Empty;
var Passwd = string.Empty;

Console.WriteLine("Por favor ingrese el servidor de bases de datos: ");
Servidor = Console.ReadLine();
Console.WriteLine("Por favor ingrese la BD");
Bd = Console.ReadLine();
Console.WriteLine("Por favor ingrese el usuario");
Usuario = Console.ReadLine();
Console.WriteLine("Por favor ingrese la contraseña");
Passwd = Console.ReadLine();

var cadena  = $"Server={Servidor};DataBase={Bd};User={Usuario};Password={Passwd};TrustServerCertificate=True"; 
Console.WriteLine($"Cadena de conexión: {cadena}");

using (SqlConnection conn = new SqlConnection(cadena)) //cerrar conexión al finalizar el proceso: Using permiten que todo el código dentro de un bloque using se cierre en cuanto sale del bloque
{
    var query = "SELECT @@SERVERNAME";//Valida que exista conexión
    SqlCommand cmd = new SqlCommand(query, conn);

    try
    {
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Nombre del Servidor: {reader[0]}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se ha producido un error al conectar o ejecutar la consulta, {ex.Message}");
    }
}