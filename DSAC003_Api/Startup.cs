using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSAC003.api.Infraestructure.Services;
using DSAC003.Api.Models.Request;
using DSAC003.Api.Models.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSAC003.Api
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
            services.AddScoped(typeof(IManejadorRequest<APDSAC003001MessageRequest>), typeof(ManejadorRequest<APDSAC003001MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APDSAC003001MessageResponse>), typeof(ManejadorResponse<APDSAC003001MessageResponse>));
            //
            //Codigo para Documentación con swagger
            //
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Interfaz DSAC003 Documentación",
                    Description = "Documentación Interfaz DSAC003",
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
                endpoints.MapControllers();
            });

            //
            //Codigo para Documentación con swagger
            //
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentacion Interfaz DSAC003");
            });
        }
    }
}
