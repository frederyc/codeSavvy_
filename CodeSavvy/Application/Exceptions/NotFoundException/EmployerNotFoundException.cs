using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NotFoundException
{
    public class EmployerNotFoundException : Exception
    {
        private const string EmployerNotFoundExceptionMessage = "Credentials with specified Id not found";

        public EmployerNotFoundException() : base(EmployerNotFoundExceptionMessage)
        { }

        public EmployerNotFoundException(string message) : base($"{EmployerNotFoundExceptionMessage} - {message}")
        { }

        public EmployerNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public EmployerNotFoundException(string message, Exception innException) :
            base($"{EmployerNotFoundExceptionMessage} - {message}", innException)
        { }
    }
}
