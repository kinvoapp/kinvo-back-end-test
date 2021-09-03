using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Entities.DTO
{
    public class TipoProdutoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [DisplayName("Nome do tipo de produto")]
        public string NomeTipoProduto { get; set; }

        [DisplayName("Rentabilidade do produto (%)")]
        public int Rentabilidade { get; set; }

        public string NomeRentabilidade { get { return NomeTipoProduto + " - Rentabilidade: " +(Rentabilidade).ToString() + "%"; } }
        public TipoProdutoDto()
        {
        }
        public TipoProdutoDto(TipoProduto tipoProduto)
        {
            Id = tipoProduto.Id;
            NomeTipoProduto = tipoProduto.NomeTipoProduto;
            Rentabilidade = Decimal.ToInt32((tipoProduto.Rentabilidade - 1)*100);
        }
    }
}
