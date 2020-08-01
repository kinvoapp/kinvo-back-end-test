using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.MVC.ViewModels
{
    public class AplicacaoFinanceiraViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        [Display(Name = "Data da aplicação")]
        public DateTime DataAplicacao { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        [Display(Name = "Data do resgate")]
        public DateTime DataResgate { get; set; }

        [Required]
        [Display(Name = "Valor da aplicação")]
        public Decimal ValorAplicacao { get; set; }

        [Required]
        [Display(Name = "Rentabilidade anual (%)")]
        public Decimal RentabilidadeAnual { get; set; }


        [Display(Name = "IR recolhido")]
        public Decimal IRRecolhido { get; set; }

        public Decimal Rendimento { get; set; }

        [Display(Name = "Alíquota IR")]
        public Decimal AliquotaIR { get; set; }

        public Decimal DiasAplicacaoAtiva { get; set; }
    }
}
