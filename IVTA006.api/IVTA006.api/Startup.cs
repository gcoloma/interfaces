using IVTA006.api.Infraestructura.Servicios;
using IVTA006.api.Infrastructure.Services;
using IVTA006.api.Models._001.Request;
using IVTA006.api.Models._001.Response;
using IVTA006.api.Models.Homologacion;
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

namespace IVTA006.api
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
            services.AddScoped(typeof(IManejadorRequest<APIVTA006001MessageRequest>), typeof(ManejadorRequest<APIVTA006001MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APIVTA006001MessageResponse>), typeof(ManejadorResponse<APIVTA006001MessageResponse>));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Interfaz Documento IVTA006",
                    Description = "Interfaz de env�o de informaci�n MSD365FO �> GTM proceso batch",
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
                        pattern: "{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "Swagger Demo API");
            });
        }
    }
}
