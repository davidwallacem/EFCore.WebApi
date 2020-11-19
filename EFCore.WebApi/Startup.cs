using EFCore.Api.Interface;
using EFCore.Api.Services;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using EFCore.Infra.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace EFCore.WebApi
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

            //======================================================Swagger==================================================================//
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Minha Empresa",
                        Version = "v1",
                        Description = "Exemplo de Web usando o Swagger.",
                        Contact = new OpenApiContact
                        {
                            Name = "David Wallace Marques Ferreira",
                            Email = "davidwallacem@hotmail.com"
                        }
                    });
            });
            //=========================================================================================================================================//

            //===========================================Serialize Newsoft=============================================================================//
            //Instalar os nugets:
            //Microsoft.AspNetCore.Mvc.NewtonsoftJson , Microsoft.AspNetCore.SignalR.Protocols.Newtonsoft

            //simples:
            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //API da web simples
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //SignalR
            services.AddSignalR().AddNewtonsoftJsonProtocol(p =>
            {
                p.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            //=========================================================================================================================================//

            //comando usados quando usa o EntityFramework
            //Context Adicionado.
            services.AddDbContext<HeroiContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HeroiConnection")));

            //Interface Generic
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Interfaces Dominio
            services.AddScoped<IRepositoryHeroi, RepositoryHeroi>();
            services.AddScoped<IRepositoryBatalha, RepositoryBatalha>();
            //Interfaces Api
            services.AddScoped<IServiceHeroi, ServiceHeroi>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
