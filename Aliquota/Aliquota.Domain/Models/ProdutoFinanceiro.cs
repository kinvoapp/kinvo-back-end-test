using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class ProdutoFinanceiro
    {
        public ProdutoFinanceiro()
        {
            Aliquotas = new Dictionary<int, double>();
            Aliquotas.Add(365, 22.5);
            Aliquotas.Add(2* 365, 18.5);
            AliquotaDefault = 15;
        }
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Cotacao { get; set; }

        [NotMapped]
        public Dictionary<int, Double> Aliquotas { get; private set; }

        [NotMapped]
        public Double AliquotaDefault { get; private set; }
    }
}
