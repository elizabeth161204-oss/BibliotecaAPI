using BibliotecaAPI.Aplicacion.Dto.Compras;
using BibliotecaAPI.Aplicacion.Servicios.Compras;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Presentacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompraController : ControllerBase
{
    private readonly ComprarLibroService comprarLibroService;

    public CompraController(ComprarLibroService comprarLibroService)
    {
        this.comprarLibroService = comprarLibroService;
    }

    [HttpPost]
    public IActionResult Comprar(ComprarLibroInput input)
    {
        comprarLibroService.Ejecutar(input);

        return Ok("Compra realizada correctamente.");
    }
}