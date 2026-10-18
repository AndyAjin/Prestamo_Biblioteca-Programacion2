namespace Prestamo_Biblioteca.Dominio;

public sealed class Libro
{
    public string Codigo { get; }
    public string Titulo { get; }
    public string Autor { get; }
    public int Ejemplares { get; }

    public Libro(string codigo, string titulo, string autor, int ejemplares)
    {
        if (string.IsNullOrWhiteSpace(codigo)) throw new ArgumentException("El codigo es obligatorio.");
        if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("El titulo es obligatorio.");
        if (string.IsNullOrWhiteSpace(autor)) throw new ArgumentException("El autor es obligatorio.");
        if (ejemplares < 1) throw new ArgumentException("Debe haber al menos 1 ejemplar.");
        Codigo = codigo.Trim();
        Titulo = titulo.Trim();
        Autor = autor.Trim();
        Ejemplares = ejemplares;
    }
}