using System;
using System.Runtime.Serialization;

namespace CodeSavvy.Application.Exceptions.NotFoundException
{
    public class ApplicationNotFoundException : Exception
    {
        private const string ApplicationNotFoundExceptionMessage = "Application with specified Id not found";

        public ApplicationNotFoundException() : base(ApplicationNotFoundExceptionMessage)
        { }

        public ApplicationNotFoundException(string message) : base($"{ApplicationNotFoundExceptionMessage} - {message}")
        { }

        public ApplicationNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public ApplicationNotFoundException(string message, Exception innException) :
            base($"{ApplicationNotFoundExceptionMessage} - {message}", innException)
        { }
    }
}
