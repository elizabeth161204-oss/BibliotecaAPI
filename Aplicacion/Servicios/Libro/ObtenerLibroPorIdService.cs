using BibliotecaAPI.Aplicacion.Dto.Libro;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Libro;

public class ObtenerLibroPorIdService
{
    private readonly IRepositorioLibro repositorio;

    public ObtenerLibroPorIdService(IRepositorioLibro repositorio)
    {
        this.repositorio = repositorio;
    }

    public LibroDto? Ejecutar(Guid id)
    {
        var libro = repositorio.ObtenerPorId(id);

        if (libro == null)
            return null;

        return new LibroDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            Autor = libro.Autor,
            AnioPublicacion = libro.AnioPublicacion
        };
    }
}