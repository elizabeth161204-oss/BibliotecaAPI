using BibliotecaAPI.Aplicacion.Dto.Compras;
using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Interfaces;

namespace BibliotecaAPI.Aplicacion.Servicios.Compras;

public class ComprarLibroService
{
    private readonly IRepositorioCompra repositorioCompra;
    private readonly IRepositorioUsuario repositorioUsuario;
    private readonly IRepositorioLibro repositorioLibro;

    public ComprarLibroService(
        IRepositorioCompra repositorioCompra,
        IRepositorioUsuario repositorioUsuario,
        IRepositorioLibro repositorioLibro)
    {
        this.repositorioCompra = repositorioCompra;
        this.repositorioUsuario = repositorioUsuario;
        this.repositorioLibro = repositorioLibro;
    }

    public void Ejecutar(ComprarLibroInput input)
{
    var usuario = repositorioUsuario.ObtenerPorId(input.UsuarioId);

    if (usuario == null)
        throw new Exception("El usuario no existe.");

    var libro = repositorioLibro.ObtenerPorId(input.LibroId);

    if (libro == null)
        throw new Exception("El libro no existe.");

    var compraExistente = repositorioCompra.ObtenerPorUsuarioYLibro(
        input.UsuarioId,
        input.LibroId);

    if (compraExistente != null)
        throw new Exception("El usuario ya compró este libro.");

    if (usuario.Saldo < libro.Precio)
    {
        throw new Exception("El usuario no tiene saldo suficiente para comprar este libro.");
    }

    usuario.Saldo -= libro.Precio;

    Compra compra = new Compra
    {
        Id = Guid.NewGuid(),
        UsuarioId = input.UsuarioId,
        LibroId = input.LibroId,
        FechaCompra = DateTime.Now
    };

    repositorioCompra.Crear(compra);

    if (usuario.Saldo < libro.Precio)
    {
        throw new Exception("El usuario no tiene saldo suficiente.");
    }

    usuario.Saldo -= libro.Precio;
}

    

   
}