using BibliotecaAPI.Dominio.Interfaces;
using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Persistencia.Repositorios.Libros;

public class RepositorioLibroEnMemoria : IRepositorioLibro
{
    private static List<BibliotecaAPI.Dominio.Entidades.Libro> libros = new();

    public void Crear(BibliotecaAPI.Dominio.Entidades.Libro libro)
    {
        libros.Add(libro);
    }

    public BibliotecaAPI.Dominio.Entidades.Libro? ObtenerPorId(Guid id)
    {
        return libros.FirstOrDefault(l => l.Id == id);
    }

    public List<BibliotecaAPI.Dominio.Entidades.Libro> ObtenerTodos()
    {
        return libros;
    }

    public void Eliminar(Guid id)
    {
        var libro = ObtenerPorId(id);

        if (libro != null)
        {
            libros.Remove(libro);
        }
    }

    public void Actualizar(Libro libro)
{
    var libroExistente = ObtenerPorId(libro.Id);

    if (libroExistente != null)
    {
        libroExistente.Titulo = libro.Titulo;
        libroExistente.Autor = libro.Autor;
        libroExistente.AnioPublicacion = libro.AnioPublicacion;
        libroExistente.Precio = libro.Precio;
    }
}
}