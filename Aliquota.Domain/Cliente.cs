using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Cliente
    {

        public Guid ClienteId { get; set; }

        public String NomeCompleto { get; set; }

        public TIPOS_PESSOA TipoPessoa { get; set; }



    }
}
