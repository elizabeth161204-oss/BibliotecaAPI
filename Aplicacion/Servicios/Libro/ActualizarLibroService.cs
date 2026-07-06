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