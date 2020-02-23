using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Excecao
{
    public class ExcecaoNegocio : Exception
    {
        public ExcecaoNegocio()
        {
        }

        public ExcecaoNegocio(string mensagem) : base(mensagem)
        {
        }

        public ExcecaoNegocio(string mensagem, Exception inner) : base(mensagem, inner)
        {
        }
    }
}
