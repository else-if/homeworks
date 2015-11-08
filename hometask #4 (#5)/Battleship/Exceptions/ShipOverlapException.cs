using System;
using System.Runtime.Serialization;

namespace Battleship.Exceptions
{
    public class ShipOverlapException : Exception
    {
        public ShipOverlapException()
        {
        }

        public ShipOverlapException(string message) : base(message)
        {
        }

        public ShipOverlapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShipOverlapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}