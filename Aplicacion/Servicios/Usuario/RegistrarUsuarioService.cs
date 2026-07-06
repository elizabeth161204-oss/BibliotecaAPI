using BibliotecaAPI.Aplicacion.Dto.Usuario;
using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Usuario;

public class RegistrarUsuarioService
{
    private readonly IRepositorioUsuario repositorio;

    public RegistrarUsuarioService(IRepositorioUsuario repositorio)
    {
        this.repositorio = repositorio;
    }

    public void Ejecutar(CrearUsuarioInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Nombre))
        throw new Exception("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(input.Email))
        throw new Exception("El email es obligatorio.");

        if (string.IsNullOrWhiteSpace(input.Password))
        throw new Exception("La contraseña es obligatoria.");

        if (input.Saldo < 0)
        throw new Exception("El saldo no puede ser negativo.");

        var existe = repositorio.ObtenerPorEmail(input.Email);

        if (existe != null)
        {
            throw new Exception("Ya existe un usuario con ese email.");
        }

        var usuario = new Dominio.Entidades.Usuario
        {
            Id = Guid.NewGuid(),
            Nombre = input.Nombre,
            Email = input.Email,
            Password = input.Password,
            Saldo = input.Saldo
        };

        repositorio.Crear(usuario);
    }
}