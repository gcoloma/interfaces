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
using Microsoft.EntityFrameworkCore;

using ICRE_002.Infraestructure.Services;
using ICRE_002.Models;
using ICRE_002.Models.Response;
using ICRE_002.Models._002.Request;
using ICRE_002.Models._002.Response;
using ICRE_002.Models._003.Request;
using ICRE_002.Models._003.Response;

namespace ICRE_002
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

          
            services.AddScoped(typeof(IManejadorRequest<APICRE002001MessageRequest>), typeof(ManejadorRequest<APICRE002001MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APICRE002001MessageResponse>), typeof(ManejadorResponse<APICRE002001MessageResponse>));
            services.AddScoped(typeof(IManejadorRequest<APICRE002002MessageRequest>), typeof(ManejadorRequest<APICRE002002MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APICRE002002MessageResponse>), typeof(ManejadorResponse<APICRE002002MessageResponse>));
            services.AddScoped(typeof(IManejadorRequest<APICRE002003MessageRequest>), typeof(ManejadorRequest<APICRE002003MessageRequest>));
            services.AddScoped(typeof(IManejadorResponse<APICRE002003MessageResponse>), typeof(ManejadorResponse<APICRE002003MessageResponse>));
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
            // services.AddScoped(typeof(IManejadorResponse<APISAC021002MessageResponse>), typeof(ManejadorResponse<APISAC021002MessageResponse>));
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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
            });
        }
    }
}
