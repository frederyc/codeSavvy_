using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NotFoundException
{
    public class FavoriteNotFoundException : Exception
    {
        private const string FavoriteNotFoundExceptionMessage = "Credentials with specified Id not found";

        public FavoriteNotFoundException() : base(FavoriteNotFoundExceptionMessage)
        { }

        public FavoriteNotFoundException(string message) : base($"{FavoriteNotFoundExceptionMessage} - {message}")
        { }

        public FavoriteNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public FavoriteNotFoundException(string message, Exception innException) :
            base($"{FavoriteNotFoundExceptionMessage} - {message}", innException)
        { }
    }
}
