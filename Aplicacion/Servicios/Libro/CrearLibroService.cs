using BibliotecaAPI.Aplicacion.Dto.Libro;
using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Libro;

public class CrearLibroService
{
    private readonly IRepositorioLibro repositorio;

    public CrearLibroService(IRepositorioLibro repositorio)
    {
        this.repositorio = repositorio;
    }

    public LibroDto Ejecutar(CrearLibroInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Titulo))
        throw new Exception("El título es obligatorio.");

        if (string.IsNullOrWhiteSpace(input.Autor))
        throw new Exception("El autor es obligatorio.");

        if (input.AnioPublicacion <= 0)
        throw new Exception("El año de publicación es inválido.");

        if (input.Precio <= 0)
        throw new Exception("El precio debe ser mayor que cero.");

        var libroExistente = repositorio.ObtenerTodos()
        .FirstOrDefault(l =>
            l.Titulo.Equals(input.Titulo, StringComparison.OrdinalIgnoreCase) &&
            l.Autor.Equals(input.Autor, StringComparison.OrdinalIgnoreCase));

        if (libroExistente != null)
        throw new Exception("Ese libro ya existe.");


        Dominio.Entidades.Libro libro = new()
        {
        Id = Guid.NewGuid(),
        Titulo = input.Titulo,
        Autor = input.Autor,
        AnioPublicacion = input.AnioPublicacion,
        Precio = input.Precio
        };

        repositorio.Crear(libro);

        return new LibroDto
        {
        Id = libro.Id,
        Titulo = libro.Titulo,
        Autor = libro.Autor,
        AnioPublicacion = libro.AnioPublicacion,
        Precio = libro.Precio
        };
    }
}