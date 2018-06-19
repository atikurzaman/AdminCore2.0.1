using System;
using System.Runtime.Serialization;

namespace Application.Utility
{
    public class ConcurrencyException : SystemException
    {
        public ConcurrencyException()
            : base()
        {
        }

        public ConcurrencyException(String message)
            : base(message)
        {
        }

        public ConcurrencyException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ConcurrencyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
