using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Aliquota.Domin.Util.Excecoes
{
    public class IntegridadeException : ApplicationException
    {
        public IntegridadeException()
        {
        }

        public IntegridadeException(string message) : base(message)
        {
        }

        public IntegridadeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IntegridadeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
