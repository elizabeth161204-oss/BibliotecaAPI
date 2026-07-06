using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Usuario;

public class ObtenerTodosLosUsuariosService
{
    private readonly IRepositorioUsuario repositorioUsuario;

    public ObtenerTodosLosUsuariosService(
        IRepositorioUsuario repositorioUsuario)
    {
        this.repositorioUsuario = repositorioUsuario;
    }

    public List<BibliotecaAPI.Dominio.Entidades.Usuario> Ejecutar()
{
    return repositorioUsuario.ObtenerTodos();
}
}