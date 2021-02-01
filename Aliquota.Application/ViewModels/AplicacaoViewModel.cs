using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Application.ViewModels
{
    public class AplicacaoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Valor Aplicado")]
        public decimal ValorAplicado { get; set; }
        [DisplayName("Valor Atual")]
        public decimal ValorAtual { get; set; }

        [DisplayName("Data Retirada")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataRetirada { get; set; }

        [DisplayName("Data Aplicação")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAplicacao { get; set; }
        
        [DisplayName("Aliquota IR")]
        public decimal AliquotaIR { get; set; }

        [DisplayName("Valor IR")]
        public decimal ValorIR { get; set; }

        [DisplayName("Valor Restate")]
        public decimal ValorResgate { get; set; }

        public bool Ativo { get; set; }
    }

    public class AplicacaoCreateViewModel
    {
       
        [Required(ErrorMessage = "O campo 'nome' é obrigatório")]

        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo 'nomw' precisa possuir mais de 4 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'valor' é obrigatório")]
        [DisplayName("Valor")]
        public decimal ValorAplicado { get; set; }

        [Required(ErrorMessage = "O campo 'data aplicação' é obrigatório")]
        [DisplayName("Data Aplicação")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAplicacao { get; set; }

    }

    public class AplicacaoEditViewModel
    {
        public Guid Id { get; set; }

        
        [Required(ErrorMessage = "O campo 'valor atual' é obrigatório")]
        [DisplayName("Valor Atual")]
        public decimal ValorAtual { get; set; }

        [DisplayName("Data Retirada")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRetirada { get; set; }

    }
}
