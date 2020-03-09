using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entities
{
    [Table("ProdutoFinanceiro")]
    public class ProdutoFinanceiro
    {
        [Key, Column("ID")]
        [Display(Description = "Código")]
        public int ID { get; set; }

        [Column("Descricao")]
        [Display(Description = "Descrição")]
        public string Descricao { get; set; }

        [Column("Rendimento")]
        [Display(Description = "Rendimento Mensal")]
        public decimal Rendimento { get; set; }

        [Column("Custo")]
        [Display(Description = "Custo Mensal")]
        public decimal Custo { get; set; }
    }
}
