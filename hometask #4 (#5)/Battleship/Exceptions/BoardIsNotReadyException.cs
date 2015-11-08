using System;
using System.Runtime.Serialization;

namespace Battleship.Exceptions
{
    public class BoardIsNotReadyException : Exception
    {
        public BoardIsNotReadyException()
        {
        }

        public BoardIsNotReadyException(string message) : base(message)
        {
        }

        public BoardIsNotReadyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BoardIsNotReadyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}