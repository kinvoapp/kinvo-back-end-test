using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Produto : BaseModel
    {
        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto financeiro")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo excedido")]
        public string Nome { get; set; }

        [Display(Name = "Rendimento Anual (%)")]
        [Required(ErrorMessage = "Por favor, preencha o valor da taxa de rendimento ao ano")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [Range(minimum: 0, maximum: 100,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "O valor da taxa pode estar entre 0% e 100% apenas")]
        public double TaxaRendimentoAnual { get; private set; }

        public virtual IList<Investimento> Investimentos { get; set; }

        // Construtor usado para aplicar migração
        private Produto() { }

        public Produto(string nome, double taxaRendimentoAnual)
        {
            this.Nome = nome;
            this.TaxaRendimentoAnual = taxaRendimentoAnual;
        }
        public void Update(Produto produtoNovo)
        {
            this.Nome = produtoNovo.Nome;
            this.TaxaRendimentoAnual = produtoNovo.TaxaRendimentoAnual;
        }

        public override string ToString() => $"{this.Nome} {this.TaxaRendimentoAnual}%";
    }
}
