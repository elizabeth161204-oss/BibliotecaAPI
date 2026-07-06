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

    public Compra? ObtenerPorUsuarioYLibro(Guid usuarioId, Guid libroId)
{
    return compras.FirstOrDefault(c =>
        c.UsuarioId == usuarioId &&
        c.LibroId == libroId);
}
}