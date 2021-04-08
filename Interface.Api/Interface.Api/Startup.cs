using Interface.Api.Infraestructura.Servicios;
using Interface.Api.Models.ICRE007001.Request;
using Interface.Api.Models.ICRE007002.Request;
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

namespace Interface.Api
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


            services.AddScoped(typeof(IManejadorRequestQueue<APICRE007002MessageRequestLegado>), typeof(ManejadorRequestQueue<APICRE007002MessageRequestLegado>));
            services.AddScoped(typeof(IManejadorResponseQueue2<APICRE007002MessageResponseLegado>), typeof(ManejadorResponseQueue2<APICRE007002MessageResponseLegado>));
            //
            services.AddScoped(typeof(IManejadorRequestQueue<APICRE007001MessageRequestLegado>), typeof(ManejadorRequestQueue<APICRE007001MessageRequestLegado>));
            services.AddScoped(typeof(IManejadorResponseQueue2<APICRE007001MessageResponseLegado>), typeof(ManejadorResponseQueue2<APICRE007001MessageResponseLegado>));
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
        }
    }
}
