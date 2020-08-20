using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain
{
   public class Aplicacao
   {
      public int AplicacaoId { get; set; }

      [DataType(DataType.Date)]
      [Column(TypeName = "Date")] 
      public DateTime DataMov { get; set;  }

      [Column(TypeName = "decimal(18, 2)")]
      public decimal ValorAplicado { get; set; }

      [DataType(DataType.Date)]
      [Column(TypeName = "Date")]
      public DateTime DataAtual { get; set; }

      [Column(TypeName = "decimal(18, 2)")]
      public decimal ValorAtual { get; set; }

      public int ClienteId { get; set; }
      public virtual Cliente Cliente { get; set; }



   }
}
