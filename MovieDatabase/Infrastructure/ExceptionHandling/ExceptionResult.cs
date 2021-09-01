using System.Collections.Generic;

namespace MovieDatabase.Infrastructure.ExceptionHandling
{
    public class ExceptionResult
    {
        public string Message { get; set; }
        public IDictionary<string, string[]> ModelState { get; set; }
        public string StackTrace { get; set; }
    }
}
