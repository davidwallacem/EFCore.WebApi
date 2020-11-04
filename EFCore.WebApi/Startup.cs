using EFCore.Api.App;
using EFCore.Api.Interface;
using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using EFCore.Infra.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddScoped<IAppHeroi, AppHeroi>();
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
        }
    }
}
