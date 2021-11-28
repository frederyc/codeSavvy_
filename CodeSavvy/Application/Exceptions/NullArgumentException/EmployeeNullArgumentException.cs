using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NullArgumentException
{
    public class EmployeeNullArgumentException : Exception
    {
        private const string EmployeeNullArgumentExceptionMessage = "Employee passed for database insertion was null";

        public EmployeeNullArgumentException() : base(EmployeeNullArgumentExceptionMessage)
        { }

        public EmployeeNullArgumentException(string message) : base($"{EmployeeNullArgumentExceptionMessage} - {message}")
        { }

        public EmployeeNullArgumentException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public EmployeeNullArgumentException(string message, Exception innException) :
            base($"{EmployeeNullArgumentExceptionMessage} - {message}", innException)
        { }
    }
}
