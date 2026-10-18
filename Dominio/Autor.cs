namespace Prestamo_Biblioteca.Dominio;

public sealed class Autor
{
    public string Nombre { get; }

    public Autor(string nombre)
    {
        Nombre = nombre;
    }

    public string ObtenerInformacion() =>
        $"Autor: {Nombre}";
}