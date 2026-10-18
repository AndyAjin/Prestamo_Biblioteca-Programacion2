using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Sqlite;

namespace Prestamo_Biblioteca.Persistencia
{
    internal sealed class InicializadorBaseDatos
    {
        // Ruta física del archivo de base de datos
        public string RutaBaseDatos { get; } = Environment.GetEnvironmentVariable("PRESTAMO_BIBLIOTECA_DB")
            ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "UMG",
                "PrestamoBiblioteca",
                "biblioteca.db");

        // Cadena de conexión a SQLite
        public string CadenaConexion => new SqliteConnectionStringBuilder
        {
            DataSource = RutaBaseDatos,
            ForeignKeys = true
        }.ToString();

        // Método principal de inicialización
        public void Inicializar()
        {
            var directorio = Path.GetDirectoryName(RutaBaseDatos);
            if (!string.IsNullOrEmpty(directorio))
                Directory.CreateDirectory(directorio);

            using var conexion = new SqliteConnection(CadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = LeerScriptTablas();
            comando.ExecuteNonQuery();
        }

        // Lee el script SQL directamente desde la carpeta
        private static string LeerScriptTablas()
        {
            var ruta = Path.Combine(AppContext.BaseDirectory, "BaseDatos", "TablasBiblioteca.sql");
            if (!File.Exists(ruta))
                throw new InvalidOperationException($"No se encontró el archivo SQL en: {ruta}");

            return File.ReadAllText(ruta);
        }

    }
}