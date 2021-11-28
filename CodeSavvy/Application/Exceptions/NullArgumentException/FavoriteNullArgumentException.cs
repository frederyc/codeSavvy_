using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Application.Exceptions.NullArgumentException
{
    public class FavoriteNullArgumentException : Exception
    {
        private const string FavoriteNullArgumentExceptionMessage = "Favorite passed for database insertion was null";

        public FavoriteNullArgumentException() : base(FavoriteNullArgumentExceptionMessage)
        { }

        public FavoriteNullArgumentException(string message) : base($"{FavoriteNullArgumentExceptionMessage} - {message}")
        { }

        public FavoriteNullArgumentException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        { }

        public FavoriteNullArgumentException(string message, Exception innException) :
            base($"{FavoriteNullArgumentExceptionMessage} - {message}", innException)
        { }
    }
}
