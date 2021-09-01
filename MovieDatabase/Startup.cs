using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MovieDatabase.Application;
using MovieDatabase.Application.Movie.Models;
using MovieDatabase.Infrastructure;
using MovieDatabase.Infrastructure.Data.Extensions;
using MovieDatabase.Infrastructure.ExceptionHandling.Middleware;
using MovieDatabase.Infrastructure.Swagger;
using MovieDatabase.Infrastructure.Swagger.Options;
using MovieDatabase.Persistence;
using Serilog;
using System.Reflection;

namespace MovieDatabase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Add Controllers
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Add Swagger Authentification Options
            services.AddOptions<SwaggerAuthOption>()
                    .Bind(Configuration.GetSection(SwaggerAuthOption.SectionName));

            //Generate Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieDatabase", Version = "v1" });
            });
            services.AddSwagger();

            //Add DbContext
            services.AddDbContext<MovieDatabaseDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("MovieDatabase.Persistence")));

            //Add DbSeed
            services.AddTransient<MovieDatabaseDbSeed>();

            //Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperConfig));

            //Add MediatR
            var domainAssembly = typeof(MovieModel).GetTypeInfo().Assembly;
            services.AddMediatR(domainAssembly);

            //Add Data Validation
            AssemblyScanner.FindValidatorsInAssembly(typeof(MovieModel).Assembly)
              .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            //Add CORS Policy
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            services.AddCors(options =>
            {
                options.AddPolicy("CORS Policy", corsBuilder.Build());
            });

            //Add Authentication
            var oauth2Config = Configuration.GetSection(SwaggerAuthOption.SectionName).Get<SwaggerAuthOption>();
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "MovieTestProject";
                    options.Authority = oauth2Config.Authority;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Use Cors
            app.UseCors("CORS Policy");

            //Use Swagger
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieDatabase v1"));
            }

            //Use Https Protocol
            app.UseHttpsRedirection();

            //Work with the Database
            app.MigrateDatabase();
            if (env.IsDevelopment())
            {
                app.SeedDatabase();
            }

            //Use Middleware
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.UseRouting();

            //Security and Identity
            app.UseAuthentication();
            app.UseAuthorization();

            //Mapping endpoints in controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}