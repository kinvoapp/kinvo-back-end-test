using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class ProdutoFinanceiro
    {
        [Key]
        public int ID { get; set; }
        public string Descricao { get; set; }
        public decimal Rendimento { get; set; }
        public decimal Custo { get; set; }
    }
}
