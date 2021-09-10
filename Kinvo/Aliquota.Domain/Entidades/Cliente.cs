using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entidades
{
    [Table("TbClientes")]
    public class Cliente
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string Cpf { get; set; }

        public ICollection<ProdutoFinanceiro> ProdutoFinanceiros { get; set; }

        public ICollection<Transacao> Transacoes { get; set; }



        
    }
}
