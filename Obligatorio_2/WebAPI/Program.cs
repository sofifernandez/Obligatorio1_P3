using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Datos.Repositorios;
using Aplicacion.CU.CabanaCU;
using Aplicacion.InterfacesCU.ICabana;
using Microsoft.EntityFrameworkCore;
using Aplicacion.CU.TipoCU;
using Aplicacion.InterfacesCU.ITipo;
using Aplicacion.CU.MantenimientoCU;
using Aplicacion.InterfacesCU.IMantenimiento;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONFIGURAMOS LAS INYECCIONES DE DEPENDENCIAS
//Repositorios
builder.Services.AddScoped<IRepositorioCabana, RepositorioCabana>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioTipo, RepositorioTipo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioParametro, RepositorioParametro>();

//TIPOS
builder.Services.AddScoped<IListadoTipo, ListadoTipo>();
builder.Services.AddScoped<IBuscarTipoPorID, BuscarTipoPorID>();
builder.Services.AddScoped<IBuscarTipoPorNombre, BuscarTipoPorNombre>();
builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IEditarTipo, EditarTipo>();
builder.Services.AddScoped<IBorrarTipo, BorrarTipo>();


//CABANAS
builder.Services.AddScoped<IListadoCabana, ListadoCabana>();
builder.Services.AddScoped<IBuscarCabanaPorNombre, BuscarCabanaPorNombre>();
builder.Services.AddScoped<IBuscarCabanaPorID, BuscarCabanaPorID>();
builder.Services.AddScoped<IAltaCabana, AltaCabana>();
builder.Services.AddScoped<IBuscarCabanaMax, BuscarCabanaMax>();
builder.Services.AddScoped<IBuscarCabanasHabilitadas, BuscarCabanasHabilitadas>();
builder.Services.AddScoped<IBuscarCabanaPorTipo, BuscarCabanaPorTipo>();

//MANTENIMIENTOS
builder.Services.AddScoped<IListadoMantenimientoDeCabana, ListadoMantenimientoDeCabana>();
builder.Services.AddScoped<IBuscarMantenPorFechas, BuscarMantenPorFechas>();
builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();



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
