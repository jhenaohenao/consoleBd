﻿using Data;
using System.Data;

string path = @"D:\APIS-CSharp\archivosNuevos\separado.csv";
var directory = Path.GetDirectoryName(path);
if (!Directory.Exists(directory))
{
    Directory.CreateDirectory(directory);
}

var conexion = new Conexion();
var usuarios = conexion.ObtenerUsuariosSinSincronizar();
foreach (DataRow usuario in usuarios.Tables[0].Rows)
{
    //Console.WriteLine($"Id {usuario[0]}, Nombre {usuario[1]}");
    //Console.WriteLine($"Id {usuario["id"]}, Nombre {usuario["nombre"]}");
    var cadena = $"{usuario["id"]}, {usuario["nombre"]},{usuario["nombre"]},{usuario["apellido"]},{usuario["email"]},{usuario["genero"]},{usuario["usuario"]},{usuario["activo"]}";
    //Console.WriteLine(cadena);

    using (StreamWriter writer = new StreamWriter(path, true))
    {
        writer.WriteLine(cadena);
    }
}
Console.WriteLine("Fin Lectura");