using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public decimal Rentabilidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Posicao> Posicoes { get; set; }
    }
}
