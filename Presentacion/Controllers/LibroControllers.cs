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
    private readonly ActualizarLibroService actualizarLibroService;

    public LibroController(
        CrearLibroService crearLibroService,
        ObtenerLibroPorIdService obtenerLibroPorIdService,
        ObtenerTodosLosLibrosService obtenerTodosLosLibrosService,
        EliminarLibroService eliminarLibroService,
        ActualizarLibroService actualizarLibroService
        )
    {
        this.crearLibroService = crearLibroService;
        this.obtenerLibroPorIdService = obtenerLibroPorIdService;
        this.obtenerTodosLosLibrosService = obtenerTodosLosLibrosService;
        this.eliminarLibroService = eliminarLibroService;
        this.actualizarLibroService = actualizarLibroService;
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

    [HttpPost]
    public ActionResult<LibroDto> Crear(CrearLibroInput input)
    {
        return Ok(crearLibroService.Ejecutar(input));
    }

    [HttpPatch("{id}")]
    public IActionResult Actualizar(Guid id, PatchLibroInput input)
    {
        actualizarLibroService.Ejecutar(id, input);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Eliminar(Guid id)
    {
        eliminarLibroService.Ejecutar(id);
        return NoContent();
    }
}