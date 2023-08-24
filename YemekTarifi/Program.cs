using Microsoft.EntityFrameworkCore;
using YemekTarifi.Models.DB;

namespace YemekTarifi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<YemekTarifiContext>();
           

            builder.Services.AddDbContext<YemekTarifiContext>(options =>
                options.UseSqlServer("Data Source=SELMAN;Initial Catalog=YemekTarifi;User Id =sa;Password=Password1;TrustServerCertificate=True"));
            

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
        }
       
    }
}