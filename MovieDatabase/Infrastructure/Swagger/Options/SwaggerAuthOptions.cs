using System.Collections.Generic;

namespace MovieDatabase.Infrastructure.Swagger.Options
{
    public class SwaggerAuthOption
    {
        public static string SectionName => "Swagger:Authorization";
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationUrl { get; set; }
        public string TokenUrl { get; set; }
        public Dictionary<string, string> Scopes { get; set; }
        public string ManagementApiUsersEndpoint { get; set; }
        public string Authority { get; set; }
    }
}
