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
    private readonly ObtenerUsuarioPorIdService obtenerUsuarioPorIdService;
    private readonly ActualizarUsuarioService actualizarUsuarioService;
    private readonly EliminarUsuarioService eliminarUsuarioService;
    

   public UsuarioController(RegistrarUsuarioService registrarUsuarioService, 
        ObtenerTodosLosUsuariosService obtenerTodosLosUsuariosService, 
        ObtenerUsuarioPorIdService obtenerUsuarioPorIdService,
        ActualizarUsuarioService actualizarUsuarioService, EliminarUsuarioService eliminarUsuarioService)
    {
        this.registrarUsuarioService = registrarUsuarioService;
        this.obtenerTodosLosUsuariosService = obtenerTodosLosUsuariosService;
        this.obtenerUsuarioPorIdService = obtenerUsuarioPorIdService;
        this.actualizarUsuarioService = actualizarUsuarioService;
        this.eliminarUsuarioService = eliminarUsuarioService;
    }


    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(obtenerTodosLosUsuariosService.Ejecutar());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(Guid id)
    {
        var usuario = obtenerUsuarioPorIdService.Ejecutar(id);

        if (usuario == null)
    {
        return NotFound("Usuario no encontrado.");
    }

        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult Registrar(CrearUsuarioInput input)
    {
        registrarUsuarioService.Ejecutar(input);

        return Ok("Usuario registrado correctamente");
    }

    [HttpPatch("{id}")]
    public IActionResult Actualizar(Guid id, ActualizarUsuarioInput input)
    {
        actualizarUsuarioService.Ejecutar(id, input);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(Guid id)
    {
        eliminarUsuarioService.Ejecutar(id);

        return NoContent();
    }

    
}