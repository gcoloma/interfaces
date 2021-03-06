using DCAJ017.api.Infraestructura.Servicios;
using DCAJ017.api.Infraestructure.Services;
using DCAJ017.api.Models._001.Request;
using DCAJ017.api.Models._001.Response;
using DCAJ017.api.Models._002.Request;
using DCAJ017.api.Models._002.Response;
using DCAJ017.api.Models._003.Request;
using DCAJ017.api.Models._003.Response;
using DCAJ017.api.Models.ResponseHomologacion;
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

namespace DCAJ017.api
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
            services.AddScoped(typeof(IManejadorHomologacion<ResponseHomologacion>), typeof(ManejadorHomologacion<ResponseHomologacion>));
            
            services.AddScoped(typeof(IManejadorRequest<APDCAJ017001MessageRequest>), typeof(ManejadorRequest<APDCAJ017001MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APDCAJ017001MessageResponse>), typeof(ManejadorResponse<APDCAJ017001MessageResponse>));

            services.AddScoped(typeof(IManejadorRequest<APDCAJ017002MessageRequest>), typeof(ManejadorRequest<APDCAJ017002MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APDCAJ017002MessageResponse>), typeof(ManejadorResponse<APDCAJ017002MessageResponse>));

            services.AddScoped(typeof(IManejadorRequest<APDCAJ017003MessageRequest>), typeof(ManejadorRequest<APDCAJ017003MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APDCAJ017003MessageResponse>), typeof(ManejadorResponse<APDCAJ017003MessageResponse>));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Interfaz Documento DSAC017",
                Description = "Interfaz para Preparaci?n de dep?sitos de cheques, confirmaci?n de dep?sitos de cheques y anulaciones de cheques en la gesti?n de cheques.",
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
