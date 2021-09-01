using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace MovieDatabase.Infrastructure.Swagger
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription.ParameterDescriptions
                                                .First(p => p.Name == parameter.Name);

                var defaultVersion = OpenApiAnyFactory.CreateFor(parameter.Schema, description.DefaultValue);
                if (description?.DefaultValue != null && defaultVersion != null)
                {
                    parameter.Schema.Default = defaultVersion;
                }

                parameter.Required |= description.IsRequired;
            }
        }
    }
}