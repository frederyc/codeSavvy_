using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NullArgumentException
{
    public class EmployerNullArgumentException : Exception
    {
        private const string EmployerNullArgumentExceptionMessage = "Employee passed for database insertion was null";

        public EmployerNullArgumentException() : base(EmployerNullArgumentExceptionMessage)
        { }

        public EmployerNullArgumentException(string message) : base($"{EmployerNullArgumentExceptionMessage} - {message}")
        { }

        public EmployerNullArgumentException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public EmployerNullArgumentException(string message, Exception innException) :
            base($"{EmployerNullArgumentExceptionMessage} - {message}", innException)
        { }
    }
}
