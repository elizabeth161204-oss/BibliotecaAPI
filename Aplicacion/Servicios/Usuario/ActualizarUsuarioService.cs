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

        
        if (string.IsNullOrWhiteSpace(input.Nombre))
            throw new Exception("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(input.Email))
            throw new Exception("El email es obligatorio.");

        if (string.IsNullOrWhiteSpace(input.Password))
            throw new Exception("La contraseña es obligatoria.");

        if (input.Saldo < 0)
            throw new Exception("El saldo no puede ser negativo.");

        
        var usuarioConEmail = repositorioUsuario.ObtenerPorEmail(input.Email);

        if (usuarioConEmail != null && usuarioConEmail.Id != id)
            throw new Exception("Ya existe otro usuario con ese email.");

        
        usuario.Nombre = input.Nombre;
        usuario.Email = input.Email;
        usuario.Password = input.Password;
        usuario.Saldo = input.Saldo;

        repositorioUsuario.Actualizar(usuario);
    }
}