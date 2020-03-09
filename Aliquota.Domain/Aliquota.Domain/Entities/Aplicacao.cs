using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entities
{
    [Table("Aplicacao")]
    public class Aplicacao
    {
        [Key, Column("ID")]
        [Display(Description ="Código")]
        public int ID { get; set; }

        [Column("ProdutoFinanceiro_ID"), ForeignKey("Produto")]
        [Display(Description = "Produto Financeiro")]
        public int ProdutoFinanceiro_ID { get; set; }

        [Column("Cliente_ID"), ForeignKey("Investidor")]
        [Display(Description = "Investidor")]
        public int Cliente_ID { get; set; }

        [Column("DataAplicacao")]
        [Display(Description = "Data Aplicação")]
        public DateTime DataAplicacao { get; set; }

        [Column("DataRetirada")]
        [Display(Description = "Data Retirada")]
        public DateTime? DataRetirada { get; set; }

        [Column("Valor")]
        [Display(Description = "Valor Aplicação")]
        public decimal Valor { get; set; }

        public virtual ProdutoFinanceiro Produto{ get; set; }

        public virtual Cliente Investidor { get; set; }
    }
}
