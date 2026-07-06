using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Compras;

public class ObtenerTodasLasComprasService
{
    private readonly IRepositorioCompra repositorioCompra;

    public ObtenerTodasLasComprasService(IRepositorioCompra repositorioCompra)
    {
        this.repositorioCompra = repositorioCompra;
    }

    public object Ejecutar()
    {
        return repositorioCompra.ObtenerTodas();
    }
}