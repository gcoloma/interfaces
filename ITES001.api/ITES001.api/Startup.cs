using ITES001.api.Infraestructura.Servicios;
using ITES001.api.Models._001.Request;
using ITES001.api.Models._001.Response;
using ITES001.api.Models.Homologa;
using Microex.Swagger.SwaggerGen.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITES001.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped(typeof(IHomologacionService<ResponseHomologa>), typeof(HomologacionService<ResponseHomologa>));
            services.AddScoped(typeof(IManejadorRequestQueue<APITES001001MessageRequest>), typeof(ManejadorRequestQueue<APITES001001MessageRequest>));
            services.AddScoped(typeof(IManejadorResponseQueue2<APITES001001MessageResponse>), typeof(ManejadorResponseQueue2<APITES001001MessageResponse>));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ITES001.api",
                    Description = "Muestra la informaci�n de las transacciones pagadas al Banco de Guayaquil",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                         name: "default",
                        // pattern: "{controller=Home}/{action=Index}/{id?}");
                            pattern: "{action=Index}/{id?}");
        });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "Liquidaci�n de Multas y matr�culas de motos(Banco Guayaquil).");
            });
        }
    }
}
