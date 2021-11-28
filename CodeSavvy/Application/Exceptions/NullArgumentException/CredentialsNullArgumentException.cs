using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NullArgumentException
{
    public class CredentialsNullArgumentException : Exception
    {
        private const string CredentialsNullArgumentExceptionMessage = "Credentials passed for database insertion were null";

        public CredentialsNullArgumentException() : base(CredentialsNullArgumentExceptionMessage)
        { }

        public CredentialsNullArgumentException(string message) : base($"{CredentialsNullArgumentExceptionMessage} - {message}")
        { }

        public CredentialsNullArgumentException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public CredentialsNullArgumentException(string message, Exception innException) :
            base($"{CredentialsNullArgumentExceptionMessage} - {message}", innException)
        { }
    }
}
