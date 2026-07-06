namespace BibliotecaAPI.Dominio.Entidades;

public class Libro
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Autor { get; set; } = string.Empty;

    public int AnioPublicacion { get; set; }

    public decimal Precio { get; set; }
}