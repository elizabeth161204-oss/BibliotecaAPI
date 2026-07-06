using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Usuario;

public class EliminarUsuarioService
{
    private readonly IRepositorioUsuario repositorioUsuario;

    public EliminarUsuarioService(IRepositorioUsuario repositorioUsuario)
    {
        this.repositorioUsuario = repositorioUsuario;
    }

    public void Ejecutar(Guid id)
    {
        var usuario = repositorioUsuario.ObtenerPorId(id);

        if (usuario == null)
            throw new Exception("El usuario no existe.");

        repositorioUsuario.Eliminar(id);
    }
}