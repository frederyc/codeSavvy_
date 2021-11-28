using System;
using System.Runtime.Serialization;

namespace CodeSavvy.Application.Exceptions.NotFoundException
{
    public class CredentialsNotFoundException : Exception
    {
        private const string CredentialsNotFoundExceptionMessage = "Credentials with specified Id not found";

        public CredentialsNotFoundException() : base(CredentialsNotFoundExceptionMessage)
        { }

        public CredentialsNotFoundException(string message) : base($"{CredentialsNotFoundExceptionMessage} - {message}")
        { }

        public CredentialsNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public CredentialsNotFoundException(string message, Exception innException) : 
            base($"{CredentialsNotFoundExceptionMessage} - {message}", innException)
        { }
    }
}
