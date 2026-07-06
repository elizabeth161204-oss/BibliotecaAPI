using BibliotecaAPI.Aplicacion.Dto.Libro;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Libro;

public class ObtenerTodosLosLibrosService
{
    private readonly IRepositorioLibro repositorio;

    public ObtenerTodosLosLibrosService(IRepositorioLibro repositorio)
    {
        this.repositorio = repositorio;
    }

    public List<LibroDto> Ejecutar()
    {
        return repositorio
            .ObtenerTodos()
            .Select(l => new LibroDto
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autor = l.Autor,
                AnioPublicacion = l.AnioPublicacion
            })
            .ToList();
    }
}