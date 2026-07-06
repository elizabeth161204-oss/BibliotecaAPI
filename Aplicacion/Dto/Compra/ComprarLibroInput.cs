namespace BibliotecaAPI.Aplicacion.Dto.Compras;

public class ComprarLibroInput
{
    public Guid UsuarioId { get; set; }

    public Guid LibroId { get; set; }
}