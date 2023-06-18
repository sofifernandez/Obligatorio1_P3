using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Datos.Repositorios;
using Aplicacion.CU;
using Aplicacion.InterfacesCU;
using Aplicacion.CU.CabanaCU;
using Aplicacion.InterfacesCU.ICabana;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONFIGURAMOS LAS INYECCIONES DE DEPENDENCIAS
builder.Services.AddScoped<IRepositorioCabana, RepositorioCabana>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioTipo, RepositorioTipo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioParametro, RepositorioParametro>();

builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IEditarTipo, EditarTipo>();

builder.Services.AddScoped<IListadoCabana, ListadoCabana>();
builder.Services.AddScoped<IBuscarPorTexto, BuscarPorTexto>();
builder.Services.AddScoped<IBuscarPorID, BuscarPorID>();
builder.Services.AddScoped<IAltaCabana, AltaCabana>();
builder.Services.AddScoped<IBuscarCabanaMax, BuscarCabanaMax>();



var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration = configurationBuilder.Build();
string miConexion = configuration.GetConnectionString("MiConexion");
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(miConexion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
