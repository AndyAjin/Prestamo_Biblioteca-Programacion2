using System;
using Prestamo_Biblioteca.Persistencia;
using Prestamos_Biblioteca.Aplicacion;

namespace Prestamo_Biblioteca
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Inicializa la base de datos (crea archivo y tablas si no existen)
                var inicializador = new InicializadorBaseDatos();
                inicializador.Inicializar();

                // Crea el repositorio con la cadena de conexión
                var repositorio = new RepositorioBiblioteca(inicializador.CadenaConexion);

                // Ejecuta la aplicación principal de biblioteca
                var biblioteca = new MenuBiblioteca(repositorio);
                biblioteca.Ejecutar();
            }
            catch (Exception error)
            {
                Console.WriteLine($"No fue posible iniciar la aplicación: {error.Message}");
            }
        }
    }
}