using BibliotecaAPI.Aplicacion.Dto.Usuario;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Usuario;

public class ActualizarUsuarioService
{
    private readonly IRepositorioUsuario repositorioUsuario;

    public ActualizarUsuarioService(IRepositorioUsuario repositorioUsuario)
    {
        this.repositorioUsuario = repositorioUsuario;
    }

    public void Ejecutar(Guid id, ActualizarUsuarioInput input)
    {
        var usuario = repositorioUsuario.ObtenerPorId(id);

        if (usuario == null)
            throw new Exception("El usuario no existe.");

        usuario.Nombre = input.Nombre;
        usuario.Email = input.Email;
        usuario.Password = input.Password;
        usuario.Saldo = input.Saldo;

        repositorioUsuario.Actualizar(usuario);
    }
}