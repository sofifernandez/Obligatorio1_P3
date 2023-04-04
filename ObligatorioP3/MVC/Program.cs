using Microsoft.EntityFrameworkCore;
using Datos.ContextoEF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var configurationBuilder=new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration=configurationBuilder.Build();
string miConexion = configuration.GetConnectionString("MiConexion");
builder.Services.AddDbContext<LibreriaContext>(options=>options.UseSqlServer(miConexion));

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
