using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain
{
   public class Resgate
   {
      public int ResgateId { get; set; }

      [DataType(DataType.Date)]
      [Column(TypeName = "Date")]
      public DateTime DataMov { get; set;  }

      [Column(TypeName = "decimal(18, 2)")]
      public decimal Valor { get; set; }

      [Column(TypeName = "decimal(18, 2)")]
      public decimal IR { get; set; }

      public int ClienteId { get; set; }
      public virtual Cliente Cliente { get; set; }


   }
}
