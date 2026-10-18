namespace Prestamo_Biblioteca.Dominio;

public abstract class Persona
{
    public string Codigo { get; }
    public string Nombre { get; }
    public string Correo { get; }
    public string Telefono { get; }

    protected Persona(string codigo, string nombre, string correo, string telefono)
    {
        Codigo = Requerido(codigo, nameof(codigo));
        Nombre = Requerido(nombre, nameof(nombre));
        Correo = Requerido(correo, nameof(correo));
        Telefono = Requerido(telefono, nameof(telefono));
    }

    public virtual string ObtenerInformacion() =>
        $"Persona [{Codigo}] {Nombre} - {Correo} - {Telefono}";

    private static string Requerido(string valor, string campo) =>
        string.IsNullOrWhiteSpace(valor)
            ? throw new ArgumentException($"El campo '{campo}' es obligatorio.")
            : valor.Trim();
}