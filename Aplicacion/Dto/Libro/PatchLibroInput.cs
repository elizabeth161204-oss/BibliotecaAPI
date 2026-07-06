namespace BibliotecaAPI.Aplicacion.Dto.Libro;

public class PatchLibroInput
{
    public string? Titulo { get; set; }

    public string? Autor { get; set; }

    public int? AnioPublicacion { get; set; }
}