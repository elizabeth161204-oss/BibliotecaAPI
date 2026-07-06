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

    public void Actualizar(Usuario usuario)
    {
        var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == usuario.Id);

        if (usuarioExistente != null)
        {
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Password = usuario.Password;
            usuarioExistente.Saldo = usuario.Saldo;
        }
    }
}