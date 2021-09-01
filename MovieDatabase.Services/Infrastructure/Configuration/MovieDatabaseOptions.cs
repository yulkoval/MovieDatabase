using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Services.Infrastructure.Configuration
{
    public class MovieDatabaseOptions
    {
        public static string ConnectionString { get; set; } = "DefaultConnection";
    }
}
