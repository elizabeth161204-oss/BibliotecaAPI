using BibliotecaAPI.Aplicacion.Dto.Compras;
using BibliotecaAPI.Aplicacion.Servicios.Compras;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Presentacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompraController : ControllerBase
{
    private readonly ComprarLibroService comprarLibroService;
    private readonly ObtenerTodasLasComprasService obtenerTodasLasComprasService;

    public CompraController(ComprarLibroService comprarLibroService, ObtenerTodasLasComprasService obtenerTodasLasComprasService)
    {
        this.comprarLibroService = comprarLibroService;
        this.obtenerTodasLasComprasService = obtenerTodasLasComprasService;
    }

    [HttpPost]
    public IActionResult Comprar(ComprarLibroInput input)
    {
        comprarLibroService.Ejecutar(input);

        return Ok("Compra realizada correctamente.");
    }

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        return Ok(obtenerTodasLasComprasService.Ejecutar());
    }
}