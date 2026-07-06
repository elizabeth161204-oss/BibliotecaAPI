using BibliotecaAPI.Aplicacion.Dto.Libro;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Libro;

public class ActualizarLibroService
{
    private readonly IRepositorioLibro repositorioLibro;

    public ActualizarLibroService(IRepositorioLibro repositorioLibro)
    {
        this.repositorioLibro = repositorioLibro;
    }

    public void Ejecutar(Guid id, PatchLibroInput input)
    {
        var libro = repositorioLibro.ObtenerPorId(id);

        if (libro == null)
            throw new Exception("El libro no existe.");

        if (input.Titulo != null && string.IsNullOrWhiteSpace(input.Titulo))
        throw new Exception("El título no puede estar vacío.");

        if (input.Autor != null && string.IsNullOrWhiteSpace(input.Autor))
        throw new Exception("El autor no puede estar vacío.");

        if (input.AnioPublicacion.HasValue && input.AnioPublicacion.Value <= 0)
        throw new Exception("El año de publicación es inválido.");

        if (input.Precio.HasValue && input.Precio.Value <= 0)
        throw new Exception("El precio debe ser mayor que cero.");

        if (input.Titulo != null)
            libro.Titulo = input.Titulo;

        if (input.Autor != null)
            libro.Autor = input.Autor;

        if (input.AnioPublicacion.HasValue)
            libro.AnioPublicacion = input.AnioPublicacion.Value;

        if (input.Precio.HasValue)
            libro.Precio = input.Precio.Value;

        repositorioLibro.Actualizar(libro);
    }

}