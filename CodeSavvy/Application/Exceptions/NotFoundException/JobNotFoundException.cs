using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NotFoundException
{
    public class JobNotFoundException : Exception
    {
        private const string JobNotFoundExceptionMessage = "Credentials with specified Id not found";

        public JobNotFoundException() : base(JobNotFoundExceptionMessage)
        { }

        public JobNotFoundException(string message) : base($"{JobNotFoundExceptionMessage} - {message}")
        { }

        public JobNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public JobNotFoundException(string message, Exception innException) :
            base($"{JobNotFoundExceptionMessage} - {message}", innException)
        { }
    }
}
