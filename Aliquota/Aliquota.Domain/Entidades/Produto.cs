using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Produto
    {
        public string descricao { get; set; }
        public double taxaRendimento { get; set; }

        public Produto(string descricao, double taxaRendimento)
        {
            this.descricao = descricao;
            this.taxaRendimento = taxaRendimento;
        }
    }
}
