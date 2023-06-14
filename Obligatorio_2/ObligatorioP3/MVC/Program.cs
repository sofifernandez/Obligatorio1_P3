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
builder.Services.AddScoped<IRepositorioParametro, RepositorioParametro > ();
builder.Services.AddScoped<IAltaCabana, AltaCabana>();
builder.Services.AddScoped<IAltaTipo, AltaTipo>();
builder.Services.AddScoped<IEditarTipo, EditarTipo>();

var configurationBuilder=new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration=configurationBuilder.Build();
string miConexion = configuration.GetConnectionString("MiConexion");
builder.Services.AddDbContext<HotelContext>(options=>options.UseSqlServer(miConexion));

builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

builder.Services.AddSession();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
