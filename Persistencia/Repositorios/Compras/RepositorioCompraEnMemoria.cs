using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Persistencia.Repositorios.Compras;

public class RepositorioCompraEnMemoria : IRepositorioCompra
{
    private static List<Compra> compras = new();

    public void Crear(Compra compra)
    {
        compras.Add(compra);
    }

    public List<Compra> ObtenerTodas()
    {
        return compras;
    }
}