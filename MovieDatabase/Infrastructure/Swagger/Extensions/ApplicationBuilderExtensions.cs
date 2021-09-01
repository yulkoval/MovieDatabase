using Microsoft.AspNetCore.Builder;
using System;


namespace MovieDatabase.Infrastructure.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerCustom(this IApplicationBuilder applicationBuilder, string pathBase = default)
        {
            if (applicationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(IApplicationBuilder)} is null.");
            }

            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(options =>
            {
                options.OAuthClientId("movie.client");
                options.OAuthClientSecret("SuperSecretPassword");
            });

            return applicationBuilder;
        }
    }
}
