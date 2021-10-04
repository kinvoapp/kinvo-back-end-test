using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Investimento { get; set; }
        public float Tempo_investido { get; set; }
        public decimal Imposto { get; set; }
        public decimal Rendimento { get; set; }
    }
}
