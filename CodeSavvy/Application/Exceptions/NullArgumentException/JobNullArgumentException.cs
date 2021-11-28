using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NullArgumentException
{
    public class JobNullArgumentException : Exception
    {
        private const string JobNullArgumentExceptionMessage = "Employee passed for database insertion was null";

        public JobNullArgumentException() : base(JobNullArgumentExceptionMessage)
        { }

        public JobNullArgumentException(string message) : base($"{JobNullArgumentExceptionMessage} - {message}")
        { }

        public JobNullArgumentException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public JobNullArgumentException(string message, Exception innException) :
            base($"{JobNullArgumentExceptionMessage} - {message}", innException)
        { }
    }
}
