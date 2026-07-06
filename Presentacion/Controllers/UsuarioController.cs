using BibliotecaAPI.Aplicacion.Dto.Usuario;
using BibliotecaAPI.Aplicacion.Servicios.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Presentacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly RegistrarUsuarioService registrarUsuarioService;
    private readonly ObtenerTodosLosUsuariosService obtenerTodosLosUsuariosService;

    public UsuarioController(
        RegistrarUsuarioService registrarUsuarioService,
        ObtenerTodosLosUsuariosService obtenerTodosLosUsuariosService)
    {
        this.registrarUsuarioService = registrarUsuarioService;
        this.obtenerTodosLosUsuariosService = obtenerTodosLosUsuariosService;
    }

    [HttpPost]
    public IActionResult Registrar(CrearUsuarioInput input)
    {
        registrarUsuarioService.Ejecutar(input);

        return Ok("Usuario registrado correctamente");
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(obtenerTodosLosUsuariosService.Ejecutar());
    }
}