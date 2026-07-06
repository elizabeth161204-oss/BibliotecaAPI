using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Persistencia.Repositorios.Usuarios;

public class RepositorioUsuarioEnMemoria : IRepositorioUsuario
{
    private static List<Usuario> usuarios = new();

    public void Crear(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public Usuario? ObtenerPorEmail(string email)
    {
        return usuarios.FirstOrDefault(u => u.Email == email);
    }

    public Usuario? ObtenerPorId(Guid id)
    {
        return usuarios.FirstOrDefault(u => u.Id == id);
    }

    public List<Usuario> ObtenerTodos()
    {
        return usuarios;
    }
}