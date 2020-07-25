using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Aliquota.Domain.Entity
{
    public class Cliente : EntityBase
    {
        public Cliente() { }
        public Cliente(string nome, IList<AplicacaoFinanceira> aplicacoes, string cpf)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public ICollection<AplicacaoFinanceira> Aplicacoes { get; set; }
        public string Cpf { get; set; }
        public override string ToString() =>
           $"{GetType().Name}: {Nome}";
    }
}
