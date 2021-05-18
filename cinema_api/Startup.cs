using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appli_Cinéma.CinemaContext;
using Appli_Cinéma.Extensions;
using Appli_Cinéma.Modele;
using Appli_Cinéma.Repositories;
using Appli_Cinéma.Secrets;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Appli_Cinéma
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

            services.AddDbContext<CinemaDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<CinemaDBContext>()
                .AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.Configure<JwtSetting>(Configuration.GetSection("Jwt"));
            var jwtSetting = Configuration.GetSection("Jwt").Get<JwtSetting>();
            services.AddAuth(jwtSetting);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IAvisRepository, AvisRepository>();
            services.AddScoped<ISalleRepository, SalleRepository>();
            services.AddScoped<IClientRepository, ClientRepository>(); 
            services.AddScoped<INourritureRepository, NourritureRepository>(); 
            

            services.AddControllers()
             .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseSwaggerAsHome();

            app.UseRouting();

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
