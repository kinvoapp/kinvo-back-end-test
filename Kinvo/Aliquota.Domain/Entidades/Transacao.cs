using Aliquota.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entidades
{
    [Table("TbTransacao")]
    public class Transacao
    {
        [Key, Column("Id")]
        public int TransacaoId { get; set; }

        [Column("DtTransacao")]
        public DateTime DataTransacao { get; set; }

        [Column("SentidoTransacao")]
        public SentidoTransacao SentidoTransacao { get; set; }

        [Column("ClienteId")]
        public Cliente Cliente { get; set; }

        [Column("ProdutoFinanceiroId")]
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }

        public ClienteProdutoFinanceiro ClienteProdutoFinanceiro { get; set; }

    }
}
