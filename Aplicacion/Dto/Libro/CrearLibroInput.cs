namespace BibliotecaAPI.Aplicacion.Dto.Libro;

public class CrearLibroInput
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;

    public string Autor { get; set; } = string.Empty;

    public int AnioPublicacion { get; set; }

    public decimal Precio { get; set; }
}