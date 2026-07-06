using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Dominio.Interfaces;

public interface IRepositorioCompra
{
    void Crear(Compra compra);

    List<Compra> ObtenerTodas();

    Compra? ObtenerPorUsuarioYLibro(Guid usuarioId, Guid libroId);
    
}