using System;
using System.Reflection;
using CodeSavvy.Application.Applications.Queries.GetApplicationByIdQuery;
using CodeSavvy.Domain.DataAccess;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CodeSavvy.WebUI
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
            // services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(GetApplicationByIdQuery).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(Startup));

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default")); 
            });

            services.AddControllersWithViews();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeSavvy", Version = "v1" });
            });

            services.AddSwaggerDocument(settings =>
            {
                settings.Title = "CodeSavvy";
            });

            AddRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecruitmentManagerApp v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void HandleHandlers(IServiceCollection service)
        {
            var assembly = AppDomain.CurrentDomain.Load("Data");
            service.AddMediatR(assembly);
        }

        private void AddRepositories(IServiceCollection service)
        {
            service.AddTransient<IApplicationRepository, ApplicationRepository>();
            service.AddTransient<ICredentialsRepository, CredentialsRepository>();
            service.AddTransient<IEmployerRepository, EmployerRepository>();
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
            service.AddTransient<IFavoriteRepository, FavoriteRepository>();
            service.AddTransient<IJobRepository, JobRepository>();
        }
    }
}
