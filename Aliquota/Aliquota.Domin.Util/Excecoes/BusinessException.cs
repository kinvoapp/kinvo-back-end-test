using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Aliquota.Domin.Util.Excecoes
{
    public class BusinessException : ApplicationException
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
