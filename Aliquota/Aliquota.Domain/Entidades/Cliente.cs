using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public List<Produto> produtos { get; set; }
        public double patrimonio { get; set; }

        public Cliente(string nome, string cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
            produtos = new List<Produto>();
        }
    }
}
