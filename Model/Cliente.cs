using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aliquota.Domain.Model
{
   public class Cliente
    {
        [Key]
        public int Id_cliente { get; set; }

        public string Nome_cliente { get; set; }

        public double Valor_investido { get; set; }

        public DateTime Data_investimento { get; set; }
    }

   
}
