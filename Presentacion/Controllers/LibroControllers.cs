using BibliotecaAPI.Aplicacion.Dto.Libro;
using BibliotecaAPI.Aplicacion.Servicios.Libro;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Presentacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibroController : ControllerBase
{
    private readonly CrearLibroService crearLibroService;
    private readonly ObtenerLibroPorIdService obtenerLibroPorIdService;
    private readonly ObtenerTodosLosLibrosService obtenerTodosLosLibrosService;
    private readonly EliminarLibroService eliminarLibroService;

    public LibroController(
        CrearLibroService crearLibroService,
        ObtenerLibroPorIdService obtenerLibroPorIdService,
        ObtenerTodosLosLibrosService obtenerTodosLosLibrosService,
        EliminarLibroService eliminarLibroService)
    {
        this.crearLibroService = crearLibroService;
        this.obtenerLibroPorIdService = obtenerLibroPorIdService;
        this.obtenerTodosLosLibrosService = obtenerTodosLosLibrosService;
        this.eliminarLibroService = eliminarLibroService;
    }

    [HttpPost]
    public ActionResult<LibroDto> Crear(CrearLibroInput input)
    {
        return Ok(crearLibroService.Ejecutar(input));
    }

    [HttpGet]
    public ActionResult<List<LibroDto>> ObtenerTodos()
    {
        return Ok(obtenerTodosLosLibrosService.Ejecutar());
    }

    [HttpGet("{id}")]
    public ActionResult<LibroDto> ObtenerPorId(Guid id)
    {
        var libro = obtenerLibroPorIdService.Ejecutar(id);

        if (libro == null)
            return NotFound();

        return Ok(libro);
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(Guid id)
    {
        eliminarLibroService.Ejecutar(id);
        return NoContent();
    }
}