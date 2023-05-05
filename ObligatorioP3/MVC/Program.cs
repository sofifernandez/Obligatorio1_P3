using Microsoft.EntityFrameworkCore;
using Datos.ContextoEF;
using Dominio.InterfacesRepositorios;
using Datos.Repositorios;
using Aplicacion.CU;
using Aplicacion.InterfacesCU;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepositorioCabana, RepositorioCabana>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioTipo, RepositorioTipo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IAltaCabana, AltaCabana>();
builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();
builder.Services.AddScoped<IAltaTipo, AltaTipo>();

var configurationBuilder=new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration=configurationBuilder.Build();
string miConexion = configuration.GetConnectionString("MiConexion");
builder.Services.AddDbContext<HotelContext>(options=>options.UseSqlServer(miConexion));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
