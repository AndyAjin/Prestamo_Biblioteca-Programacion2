namespace Prestamo_Biblioteca.Dominio;

public sealed class Lector : Persona
{
    public Lector(string codigo, string nombre, string correo, string telefono)
        : base(codigo, nombre, correo, telefono) { }

    public override string ObtenerInformacion() =>
        $"Lector [{Codigo}] {Nombre} - Correo: {Correo} - Tel: {Telefono}";
}