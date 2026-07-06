using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Persistencia.Repositorios.Libro;

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
}