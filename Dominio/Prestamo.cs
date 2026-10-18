namespace Prestamo_Biblioteca.Dominio;

public sealed class Prestamo
{
    public int LectorId { get; }
    public int LibroId { get; }
    public DateTime FechaPrestamo { get; }
    public DateTime FechaLimite { get; }
    public DateTime? FechaDevolucion { get; }

    public bool EstaActivo => FechaDevolucion is null;

    public Prestamo(int lectorId, int libroId, DateTime fechaPrestamo, DateTime fechaLimite, DateTime? fechaDevolucion = null)
    {
        if (fechaLimite.Date < fechaPrestamo.Date)
            throw new ArgumentException("La fecha limite no puede ser anterior a la fecha de prestamo.");
        LectorId = lectorId;
        LibroId = libroId;
        FechaPrestamo = fechaPrestamo.Date;
        FechaLimite = fechaLimite.Date;
        FechaDevolucion = fechaDevolucion?.Date;
    }
}