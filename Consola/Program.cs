//Cadena de conexión: Servidor;Base de dtos;usuario;clave

using Microsoft.Data.SqlClient;
using System.Data;

var Servidor = string.Empty;
var Bd = string.Empty;
var Usuario = string.Empty;
var Passwd = string.Empty;

//Console.WriteLine("Por favor ingrese el servidor de bases de datos: ");
//Servidor = Console.ReadLine();
//Console.WriteLine("Por favor ingrese la BD");
//Bd = Console.ReadLine();
//Console.WriteLine("Por favor ingrese el usuario");
//Usuario = Console.ReadLine();
//Console.WriteLine("Por favor ingrese la contraseña");
//Passwd = Console.ReadLine();

// var cadena  = $"Server={Servidor};DataBase={Bd};User={Usuario};Password={Passwd};TrustServerCertificate=True"; 
var cadena  = $"Server=.;DataBase=APIColombia;User=henao88;Password=asd123;TrustServerCertificate=True"; 
Console.WriteLine($"Cadena de conexión: {cadena}");

using (SqlConnection conn = new SqlConnection(cadena)) //cerrar conexión al finalizar el proceso: Using permiten que todo el código dentro de un bloque using se cierre en cuanto sale del bloque
{
    // var query = "SELECT @@SERVERNAME";//Valida que exista conexión
    //var query = "SELECT  TOP 1 * FROM Usuarios"; // Muestra TOP 1
    var query = "SELECT  * FROM Usuarios";

    SqlCommand cmd = new SqlCommand(query, conn);

    try
    {
        conn.Open();
        //Tipo de conexión 1
        //SqlDataReader reader = cmd.ExecuteReader();
        //while (reader.Read())
        //{
        //    // Console.WriteLine($"Nombre del Servidor: {reader[0]}");
        //    Console.WriteLine($"Id: {reader["Id"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}");
        //}

        //Tipo de conexión por DATASET
        DataSet ds = new DataSet();
        var adaptador = new SqlDataAdapter(cmd);
        adaptador.Fill(ds);
        Console.ReadLine();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se ha producido un error al conectar o ejecutar la consulta, {ex.Message}");
    }
}