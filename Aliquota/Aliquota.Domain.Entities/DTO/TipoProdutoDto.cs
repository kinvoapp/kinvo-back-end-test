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

        [DisplayName("Rentabilidade do produto")]
        public decimal Rentabilidade { get; set; }

        public TipoProdutoDto()
        {
        }
        public TipoProdutoDto(TipoProduto tipoProduto)
        {
            Id = tipoProduto.Id;
            NomeTipoProduto = tipoProduto.NomeTipoProduto;
            Rentabilidade = tipoProduto.Rentabilidade;
        }
    }
}
