using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        
        public string Nome { get; set; }

        public List<Transacao> Transacoes { get; set; }
    }
}
