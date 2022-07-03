using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.API.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Rentabilidade (Anual)")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal Rentabilidade { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public IEnumerable<PosicaoViewModel> Posicoes { get; set; }
    }
}
