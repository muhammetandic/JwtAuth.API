using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public StudentAgeException(string message, Exception innerException) : base(message,innerException)
        {

        }
    }
}
