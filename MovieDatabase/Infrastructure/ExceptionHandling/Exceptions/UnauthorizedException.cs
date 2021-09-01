using System;

namespace MovieDatabase.Infrastructure.ExceptionHandling.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string massage)
            : base(massage)
        {
        }
    }
}
