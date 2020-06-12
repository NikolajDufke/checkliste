using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestService31.Models;

namespace RestService31
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
            services.AddDbContext<BilContext>(opt => opt.UseInMemoryDatabase("bilItems"));

            //Nuget - SwashBuckle.AspNetCore
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Bil API",
                        Version = "v1.0",
                        Description = "Example of OpenAPI for api/Bil",
                        Contact = new OpenApiContact()
                        {
                            Email = "NewEmail@email.com",
                            Name = "YouNameHere",
                            Url = new Uri("http://urltohelppage.com/%22"),
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "NameHere",
                            Url = new Uri("http://urltohelppage.com/%22"),
                        }
                    }
                );
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin());
                options.AddPolicy("AllowMyLocalOrigin", builder => builder.WithOrigins("http://localhost:3000"));//indsæt dit eget local host link
                options.AddPolicy("AllowAllOrigin", builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
                options.AddPolicy("AllowGETOrigin", builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().WithMethods("GET", "POST"));
                options.AddPolicy("AllowGetPost", builder => builder.AllowAnyOrigin().WithMethods("GET", "POST"));
            });
            services.AddControllers();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Records API v1.0")
            );

            //app.UseCors("AllowAnyOrigin");
            app.UseCors("AllowAllOrigin");
            //app.UseCors("AllowGETOrigin");
            //app.UseCors("AllowMyLocalOrigin");
            //app.UseCors("AllowGetPost");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
