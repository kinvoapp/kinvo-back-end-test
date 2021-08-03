using System;
using System.Runtime.Serialization;

namespace Aliquota.Domain.Excecao
{
    [Serializable]
    public class AliquotaException : Exception
    {
        public AliquotaException()
        {
        }

        public AliquotaException(string mensagem) : base(mensagem)
        {
        }

        public AliquotaException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {
        }

        protected AliquotaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public object Entidade { get; set; }
    }
}