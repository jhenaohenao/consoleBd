using Consola;
using Data;
using System.Data;

string archivoConfiguracion = Path.Combine(Environment.CurrentDirectory, ".Env");
var configuracion = new Configuracion();
var conf = configuracion.ObtenerConfiguracion(archivoConfiguracion);

string rutaArchivo = @"D:\APIS-CSharp\archivosNuevos\separado.csv";

var conexion = new Conexion(conf["Servidor"], conf["BaseDatos"], conf["Usuario"], conf["Password"]);
var manejadorArchivos = new ManejadorArchivo();

var usuarios = conexion.ObtenerUsuariosSinSincronizar();

foreach (DataRow usuario in usuarios.Tables[0].Rows)
{
    try
    {
        if (manejadorArchivos.GuardarEnCSV(usuario, rutaArchivo))
        {
            conexion.ActualizarSincronizado(int.Parse(usuario["id"].ToString()));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    
}
Console.WriteLine("Fin Lectura");