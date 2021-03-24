using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public Tipo Tipo { get; set; }
        public decimal ValorAplcado { get; set; }
        public decimal Porcentagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataResgate { get; set; }
    }
}
