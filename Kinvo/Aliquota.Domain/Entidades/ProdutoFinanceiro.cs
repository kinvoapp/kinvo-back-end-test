using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entidades
{
    [Table("TbProdutoFinanceiro")]
    public class ProdutoFinanceiro
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("TaxaDeJurosAoAno")]
        public decimal TaxaJuros_aa { get; set; }

        public ICollection<Cliente> Clientes { get; set; }


        public ProdutoFinanceiro()
        {
        }

        


    }
}
