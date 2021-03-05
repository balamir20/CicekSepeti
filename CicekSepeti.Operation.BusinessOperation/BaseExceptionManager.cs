using System;
using System.Runtime.Serialization;

namespace CicekSepeti.Operation.BusinessOperation
{
    [Serializable]
    public class BaseExceptionManager : Exception
    {
        public BaseExceptionManager(string message) : base(message)
        { }
        public BaseExceptionManager(string message, Exception innerException) : base(message, innerException)
        { }
        public BaseExceptionManager(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
