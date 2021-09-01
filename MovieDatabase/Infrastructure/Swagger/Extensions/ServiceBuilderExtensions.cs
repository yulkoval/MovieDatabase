using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MovieDatabase.Infrastructure.Swagger.Options;
using System;
using System.Collections.Generic;


namespace MovieDatabase.Infrastructure.Swagger
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var serviceProvider = services.BuildServiceProvider();

                options.SwaggerDoc("MovieTestProject", new OpenApiInfo
                {
                    Title = $"HTTP API",
                    Version = "v1",
                    Description = "This API version has been deprecated.",
                });

                var oauth2Config = serviceProvider.GetService<IOptions<SwaggerAuthOption>>()?.Value;
                if (oauth2Config != null)
                {
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            ClientCredentials = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri(oauth2Config.TokenUrl),
                                AuthorizationUrl = new Uri(oauth2Config.AuthorizationUrl),
                                Scopes = oauth2Config.Scopes
                            }
                        }
                    });
                }

                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Id = "oauth2", Type = ReferenceType.SecurityScheme } },
                        new List<string>() } });
            });

            return services;
        }
    }
}
