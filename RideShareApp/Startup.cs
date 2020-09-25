using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RideShare.Data;
using RideShare.Data.Interfaces;
using RideShare.Data.Repositories;
using RideShare.Service;
using RideShare.Service.Interfaces;

namespace RideShareApp
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
            services.AddSwaggerGen();
            services.AddScoped<IJourneyService, JourneyService>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRideShareService, RideShareService>();
            services.AddScoped<IMapService, MapService>(); 
            services.AddScoped<IMapRepository, MapRepository>();
            services.AddScoped<IJourneyRepository, JourneyRepository>();
            services.AddScoped<IMongoDbContext, MongoDBContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RideShare API",
                    Description = "A simple Web API demonstrating on handling rides&shares.",                                        
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdessoV1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();                        

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
