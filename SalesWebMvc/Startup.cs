﻿using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using SalesWebMvc.Data;

namespace SalesWebMvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SalesWebMvcContext>(options =>
                 options.UseMySQL(Configuration.GetConnectionString("SalesWebMvcContext"), builder =>
                    builder.MigrationsAssembly("SalesWebMvc")));
        }
    }
}
