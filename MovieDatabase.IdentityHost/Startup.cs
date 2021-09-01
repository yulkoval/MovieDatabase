using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace MovieDatabase.IdentityHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
            .AddInMemoryClients(new List<Client>
            {
                new Client
                {
                    ClientId = "movie.client",
                    ClientName = "MovieTestProject",
                    ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
    
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new List<string>
                    {
                        "movieClient",
                    }
                }
            })
            .AddInMemoryIdentityResources(new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            })
            .AddInMemoryApiResources(new List<ApiResource>
            {
                new ApiResource("MovieTestProject")
                {
                    Scopes = new List<string> { "movieClient" },
                    ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())}, // change me!
                }
            })
            .AddInMemoryApiScopes(new List<ApiScope>
            {
                new ApiScope(name: "movieClient"),
            })
            .AddDeveloperSigningCredential();


            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            services.AddCors(options =>
            {
                options.AddPolicy("CORS Policy", corsBuilder.Build());
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CORS Policy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
