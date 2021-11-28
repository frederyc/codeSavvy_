using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NullArgumentException
{
    public class ApplicationNullArgumentException : Exception
    {
        private const string ApplicationNullArgumentExceptionMessage = "Application passed for database insertion was null";

        public ApplicationNullArgumentException() : base(ApplicationNullArgumentExceptionMessage)
        { }

        public ApplicationNullArgumentException(string message) : base($"{ApplicationNullArgumentExceptionMessage} - {message}")
        { }

        public ApplicationNullArgumentException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public ApplicationNullArgumentException(string message, Exception innException) :
            base($"{ApplicationNullArgumentExceptionMessage} - {message}", innException)
        { }
    }
}
