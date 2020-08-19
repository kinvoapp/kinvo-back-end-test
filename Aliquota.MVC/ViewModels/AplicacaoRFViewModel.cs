using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.MVC.ViewModels
{
    public class AplicacaoRFViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Data Aplicação")]
        [DataType(DataType.Date)]
        public DateTime? DataAplicacao { get; set; }

        [Required]
        [DisplayName("Data Resgate")]
        [DataType(DataType.Date)]
        public DateTime? DataResgate { get; set; }

        [Required]
        [DisplayName("Valor Aplicado")]
        [DataType(DataType.Currency)]
        public decimal ValorAplicado { get; set; }

        [Required]
        [DisplayName("Tx. Juros Anual")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal TaxaJurosAnual { get; set; }

        [NotMapped]
        [DisplayName("Alíquota IR")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal AliquotaIR { get; set; }

        [NotMapped]
        [DisplayName("Rendimento Total")]
        [DataType(DataType.Currency)]
        public decimal RendimentoTotal { get; set; }

        [NotMapped]
        [DisplayName("IR Recolhido")]
        [DataType(DataType.Currency)]
        public decimal IRRecolhido { get; set; }
    }
}