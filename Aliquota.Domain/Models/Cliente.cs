using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
