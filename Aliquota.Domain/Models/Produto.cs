using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public double TaxaDeRendimento { get; set; }
        public DateTime Aniversario { get; set; }
        public double Capital { get; set; }
        public Cliente Cliente { get; set; }
    }
}
