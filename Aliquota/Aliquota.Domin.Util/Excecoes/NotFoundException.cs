using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Aliquota.Domin.Util.Excecoes
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
