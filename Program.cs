using BibliotecaAPI.Aplicacion.Servicios.Libro;
using BibliotecaAPI.Dominio.Interfaces;
using BibliotecaAPI.Persistencia.Repositorios.Libro;
using BibliotecaAPI.Aplicacion.Servicios.Usuario;
using BibliotecaAPI.Persistencia.Repositorios.Usuarios;
using BibliotecaAPI.Persistencia.Repositorios.Compras;
using BibliotecaAPI.Aplicacion.Servicios.Compras;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepositorioLibro, RepositorioLibroEnMemoria>();

builder.Services.AddScoped<CrearLibroService>();
builder.Services.AddScoped<ObtenerLibroPorIdService>();
builder.Services.AddScoped<ObtenerTodosLosLibrosService>();
builder.Services.AddScoped<EliminarLibroService>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEnMemoria>();
builder.Services.AddScoped<RegistrarUsuarioService>();
builder.Services.AddScoped<ObtenerTodosLosUsuariosService>();
builder.Services.AddScoped<IRepositorioCompra, RepositorioCompraEnMemoria>();
builder.Services.AddScoped<ComprarLibroService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
