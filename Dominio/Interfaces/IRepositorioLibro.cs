using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Dominio.Interfaces;

public interface IRepositorioLibro
{
    void Crear(Libro libro);

    Libro? ObtenerPorId(Guid id);

    List<Libro> ObtenerTodos();

    void Eliminar(Guid id);

    void Actualizar(Libro libro);
   
}