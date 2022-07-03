using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.API.ViewModels
{
    public class PosicaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Produto")]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Aporte")]
        [DataType(DataType.Date)]
        public DateTime DataAporte { get; set; }

        [DisplayName("Data Resgate")]
        [DataType(DataType.Date)]
        public DateTime? DataResgate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Valor Aportado")]
        [DataType(DataType.Currency)]
        public decimal ValorAportado { get; set; }

        [DisplayName("Valor Resgatado")]
        [DataType(DataType.Currency)]
        public decimal? ValorResgatado { get; set; }

        [DisplayName("Valor Tributado")]
        [DataType(DataType.Currency)]
        public decimal? ValorTributado { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public ProdutoViewModel Produto { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
