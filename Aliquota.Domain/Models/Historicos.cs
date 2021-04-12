using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class Historicos
    {
        [Key]
        public int Id { get; set; }
        public double Valor { get; set; }
        public double Lucro { get; set; }
        public DateTime Data { get; set; }
        public int AplicacaoId { get; set; }
        public Aplicacoes Aplicacoes { get; set; }
    }
}
