using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Aliquota.Domin.Util.Excecoes
{
    public class NaoEncontradoException : ApplicationException
    {
        public NaoEncontradoException()
        {
        }

        public NaoEncontradoException(string message) : base(message)
        {
        }

        public NaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
