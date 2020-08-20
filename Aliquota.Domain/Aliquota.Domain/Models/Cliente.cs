using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain
{
   public class Cliente
   {
      public int ClienteId { get; set; }
      [StringLength(100)]
      public string Nome { get; set; }

      public List<Aplicacao> Aplicacoes { get; set; }
      public List<Resgate> Resgates { get; set; }
   }
}
