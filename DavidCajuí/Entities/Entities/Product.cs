using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class Product : Base
    {
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "DataInicioAplicacao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicioAplicacao { get; set; }

        [Display(Name = "DataFinalEstimadaAplicacao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinalEstimadaAplicacao { get; set; }

        [Display(Name = "DataResgateAplicacao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataResgateAplicacao { get; set; }

        [Display(Name = "ValorAplicado")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public string ValorAplicado { get; set; }

        [Display(Name = "ValorDoImposto")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public Double ValorDoImposto { get; set; }

        [Display(Name = "JurosRecebido")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public string JurosRecebido { get; set; }

        [Display(Name = "RendimentoMultiplicador")]
        public Double RendimentoAplicacao { get; set; }
    }
}

