using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities
{    
    public class Aplicacao
    {
        [Key]
        public int ID { get; set; }
        public int ProdutoFinanceiro_ID { get; set; }
        public int Cliente_ID { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime? DataRetirada { get; set; }
        public decimal Valor { get; set; }

        public virtual ProdutoFinanceiro Produto{ get; set; }

        public virtual Cliente Investidor { get; set; }
    }
}
