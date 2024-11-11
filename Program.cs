using ST10298613_PROG6212_POE.Data;
using Microsoft.EntityFrameworkCore;

namespace ST10298613_PROG6212_POE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Dashboard}/{id?}");
            app.MapControllerRoute(
            name: "lecturer",
            pattern: "Lecturer/{action=Dashboard}/{id?}",
            defaults: new { controller = "Lecturer" });

            app.MapControllerRoute(
                name: "admin",
                pattern: "Admin/{action=Dashboard}/{id?}",
                defaults: new { controller = "Admin" });


            app.Run();
        }
    }
}
