using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NotFoundException
{
    public class EmployeeNotFoundException : Exception
    {
        private const string EmployeeNotFoundExceptionMessage = "Credentials with specified Id not found";

        public EmployeeNotFoundException() : base(EmployeeNotFoundExceptionMessage)
        { }

        public EmployeeNotFoundException(string message) : base($"{EmployeeNotFoundExceptionMessage} - {message}")
        { }

        public EmployeeNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public EmployeeNotFoundException(string message, Exception innException) :
            base($"{EmployeeNotFoundExceptionMessage} - {message}", innException)
        { }
    }
}
