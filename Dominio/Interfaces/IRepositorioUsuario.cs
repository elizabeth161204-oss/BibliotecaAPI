using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Dominio.Interfaces;

public interface IRepositorioUsuario
{
    void Crear(Usuario usuario);

    void Actualizar(Usuario usuario);

    Usuario? ObtenerPorEmail(string email);

    Usuario? ObtenerPorId(Guid id);

    List<Usuario> ObtenerTodos();
}