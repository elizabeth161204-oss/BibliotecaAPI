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