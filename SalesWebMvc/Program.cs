using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SalesWebMvc.Data;
using System.Configuration;
using MySql.EntityFrameworkCore;
using SalesWebMvc.Services;

namespace SalesWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SalesWebMvcContext>(options =>                
                options.UseMySQL(builder.Configuration.GetConnectionString("SalesWebMvcContext"), builder =>
                    builder.MigrationsAssembly("SalesWebMvc")));

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                
            }
            app.Services.CreateScope().ServiceProvider.GetService<SeedingService>().Seed();

            app.UseHttpsRedirection();
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
