using System;
using System.Collections.Generic;

#nullable disable

namespace Aliquota.Domain.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Aplicacoes = new HashSet<Aplicacao>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Aplicacao> Aplicacoes { get; set; }
    }
}
