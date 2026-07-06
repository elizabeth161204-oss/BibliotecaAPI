namespace BibliotecaAPI.Aplicacion.Dto.Usuario;

public class CrearUsuarioInput
{
    public string Nombre { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public decimal Saldo { get; set; }
}