using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Usuario;

public class ObtenerUsuarioPorIdService
{
    private readonly IRepositorioUsuario repositorioUsuario;

    public ObtenerUsuarioPorIdService(IRepositorioUsuario repositorioUsuario)
    {
        this.repositorioUsuario = repositorioUsuario;
    }

    public BibliotecaAPI.Dominio.Entidades.Usuario? Ejecutar(Guid id)
    {
        return repositorioUsuario.ObtenerPorId(id);
    }
}