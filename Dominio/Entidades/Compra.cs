namespace BibliotecaAPI.Dominio.Entidades;

public class Compra
{
    public Guid Id { get; set; }

    public Guid UsuarioId { get; set; }

    public Guid LibroId { get; set; }

    public DateTime FechaCompra { get; set; }
}