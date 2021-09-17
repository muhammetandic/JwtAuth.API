using System;

namespace JwtAuth.API.Exceptions
{
    public class StudentAgeException : Exception
    {
        public StudentAgeException()
        {

        }

        public StudentAgeException(string message) : base(message)
        {

        }

        public StudentAgeException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
