using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;



namespace Aliquota.Domain
{
   public class Rendimento
   {
      public int RendimentoId { get; set; }

      [DataType(DataType.Date)]
      [Column(TypeName = "Date")]
      public DateTime Data { get; set; }

      [Column(TypeName = "decimal(18, 2)")]
      public decimal Percentual { get; set; }

   }
}
