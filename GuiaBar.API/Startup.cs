using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuiaBar.Data;
using GuiaBar.Data.Repository;
using GuiaBar.Domain.Interface;
using GuiaBar.Domain.Services;
using GuiaBar.Domain.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuiaBar.Domain.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<GuiaBarContext>(options => options.UseNpgsql("Host=postgres.evilsummit.com.br;Port=5432;Username=usr011;Password=h4tQ7csNwV;Database=db011;").UseLazyLoadingProxies().UseLowerCaseNamingConvention());
            

            #region Dependency Injection
            //Repository
            services.AddScoped<IUserRepository, UserRepository>();
            //Services
            services.AddScoped<IUserService, UserService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseCors(options => options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
