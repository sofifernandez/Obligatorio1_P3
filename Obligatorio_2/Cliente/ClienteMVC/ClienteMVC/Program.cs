namespace ClienteMVC {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

           // app.UseAuthorization();

            //app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tipo}/{action=Index}/{id?}");

            app.Run();

        }


    }

}

