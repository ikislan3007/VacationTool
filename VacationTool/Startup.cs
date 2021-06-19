using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Okta.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationTool.DAL;

namespace VacationTool
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
            //string con = "Server=(localdb)\\mssqllocaldb;Database=CompanyContext2;Trusted_Connection=True;";
            // устанавливаем контекст данных
            services.AddDbContext<CompanyContext2>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CompanyContext2;Trusted_Connection=True;"));

            services.AddCors(options =>
            {
                // The CORS policy is open for testing purposes. In a production application, you should restrict it to known origins.
                options.AddPolicy(
                    "AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            })
            .AddOktaWebApi(new OktaWebApiOptions()
            {
                OktaDomain = "https://dev-48415089.okta.com",
            });

            services.AddControllers();
            services.AddAuthorization();
          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VacationTool", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CompanyContext2 context)
        {
            if (env.IsDevelopment())
             {
                // context.Database.EnsureCreated();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VacationTool v1"));
             }

            app.UseDeveloperExceptionPage();
            // 
            // app.UseCors("AllowAll");
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseAuthentication(); 

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
