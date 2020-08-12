using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models.BD
{
    public class BDCadastroInvestidor
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string TipoAplicacao { get; set; }
        public double ValorAplicacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataResgate { get; set; }
    }
}
