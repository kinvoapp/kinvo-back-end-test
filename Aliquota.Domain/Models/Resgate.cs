using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    class Resgate
    {
        [Key]
        public int Id { get; set; }
        public double Lucro { get; set; }
        public double Valor_IR { get; set; }
        public DateTime Data { get; set; }
        public int AplicacaoId { get; set; }
        public Aplicacao Aplicacao { get; set; }
    }
}
