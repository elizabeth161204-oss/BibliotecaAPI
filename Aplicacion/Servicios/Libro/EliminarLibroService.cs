using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Libro;

public class EliminarLibroService
{
    private readonly IRepositorioLibro repositorio;

    public EliminarLibroService(IRepositorioLibro repositorio)
    {
        this.repositorio = repositorio;
    }

    public void Ejecutar(Guid id)
    {
        repositorio.Eliminar(id);
    }
}