using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ManejadorArchivo
    {
        public bool GuardarEnCSV(DataRow row, string rutaArchivo) 
        { 
            if (string.IsNullOrEmpty(rutaArchivo)) { throw new Exception("La ruta no puede ser vacia"); }
            try
            {
                var cadena = $"{row["id"]}, {row["nombre"]},{row["apellido"]},{row["email"]},{row["genero"]},{row["usuario"]},{row["activo"]}";
                var directorio = Path.GetDirectoryName(rutaArchivo);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                using StreamWriter writer = new StreamWriter(rutaArchivo, true);
                writer.WriteLine(cadena);
                writer.Close();// Esta linea podria omitirse
                return true;

            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Se ha generado un error al guardar el archivo [{rutaArchivo}], {ex.Message}");
                return false;
            }
        }
    }
}
