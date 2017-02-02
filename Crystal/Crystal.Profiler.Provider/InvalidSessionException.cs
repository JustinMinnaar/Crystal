using System;
using System.Runtime.Serialization;

namespace Crystal.Profiler.Provider
{
    [Serializable]
    internal class InvalidSessionException : Exception
    {
        public InvalidSessionException()
        {
        }

        public InvalidSessionException(string message) : base(message)
        {
        }

        public InvalidSessionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSessionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}