using Aliquota.Domain.Shared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Shared.Models
{
    public class Aplicacao
    {
        private decimal _valorTotal;
        
        public int Id { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        [Required]
        [Range(1, 999999999, ErrorMessage ="O valor não pode ser menor ou igual a zero.")]
        public decimal ValorInvestido { get; set; }
        
        [Required]
        [Range(0.001, 10000, ErrorMessage ="O valor deve ser positivo.")]
        public double Juros { get; set; }
        
        [Required]
        [Range(1, 1000000000, ErrorMessage ="O valor não pode ser menor do que 1.")]
        public int PeriodoPrevistoAplicadoEmMeses { get; set; }
        
        public DateTime DataAplicacao { get; set; }
        
        public DateTime DataRetirada { get; set; }

        public decimal ValorSacado { get; set; }

        public decimal ValorTotal
        {
            get { return _valorTotal; }
            set
            {
                _valorTotal = Utilitarios.CalculaRentabilidade((double)ValorInvestido, Juros,
                  PeriodoPrevistoAplicadoEmMeses);
            }
        }
    }
}
