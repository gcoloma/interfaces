using IVTA014.api.Infraestructura.Servicios;
using IVTA014.api.Models._001.Request;
using IVTA014.api.Models._001.Response;
using IVTA014.api.Models._002.Request;
using IVTA014.api.Models._002.Response;
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
namespace IVTA014.api
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
            services.AddScoped(typeof(IManejadorRequestQueue<APIVTA014001MessageRequest>), typeof(ManejadorRequestQueue<APIVTA014001MessageRequest>));
            services.AddScoped(typeof(IManejadorResponseQueue2<APIVTA014001MessageResponse>), typeof(ManejadorResponseQueue2<APIVTA014001MessageResponse>));
            services.AddScoped(typeof(IManejadorRequestQueue<APIVTA014002MessageRequest>), typeof(ManejadorRequestQueue<APIVTA014002MessageRequest>));
            services.AddScoped(typeof(IManejadorResponseQueue2<APIVTA014002MessageResponse>), typeof(ManejadorResponseQueue2<APIVTA014002MessageResponse>));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger Demo API",
                    Description = "Demo API",
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
                         pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
            });
        }
    }
}
