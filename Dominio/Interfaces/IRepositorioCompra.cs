using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Dominio.Interfaces;

public interface IRepositorioCompra
{
    void Crear(Compra compra);

    List<Compra> ObtenerTodas();
}