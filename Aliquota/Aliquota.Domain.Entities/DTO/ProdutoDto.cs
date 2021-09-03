using Aliquota.Domain.Entities.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aliquota.Domain.Entities.DTO
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public int IdTipoProduto { get; set; }
        public int IdSituacaoProduto { get; set; }
        public int IdCliente { get; set; }
        [Display(Name = "Valor Investido")]
        [DisplayFormat(DataFormatString = "R$" + "{0:F2}")]
        [Required(ErrorMessage = "O preenchimento do {0} é obrigatório.")]
        public decimal? ValorInvestido { get; set; }
        [Display(Name = "Valor Projetado")]
        [DisplayFormat(DataFormatString = "R$" + "{0:F2}")]
        [Required(ErrorMessage = "O preenchimento do {0} é obrigatório.")]
        public decimal? ValorAtual { get; set; }
        [Display(Name = "Valor Resgatado")]
        [DisplayFormat(DataFormatString = "R$" + "{0:F2}")]
        [Required(ErrorMessage = "O preenchimento do {0} é obrigatório.")]
        public decimal? ValorResgatado { get; set; }
        [Display(Name = "Valor Valor IR")]
        [DisplayFormat(DataFormatString = "R$" + "{0:F2}")]
        public decimal? ValorImposto { get; set; }
        public DateTime DataInvestimento { get; set; }
        [RequiredIfData("DataInvestimento", "DataResgate")]
        public DateTime? DataResgate { get; set; }
        public TipoProdutoDto TipoProduto { get; set; }
        public SituacaoProdutoDto SituacaoAtual { get; set; }
        public ClienteDto Proprietario { get; set; }

        public ProdutoDto(Produto produto)
        {
            Id = produto.Id;
            IdTipoProduto = produto.IdTipoProduto;
            IdSituacaoProduto = produto.IdSituacaoProduto;
            IdCliente = produto.IdCliente;
            ValorInvestido = produto.ValorInvestido;
            ValorAtual = produto.ValorAtual;
            ValorResgatado = produto.ValorResgatado;
            ValorImposto = produto.ValorImposto;
            DataInvestimento = produto.DataInvestimento;
            DataResgate = produto.DataResgate;
            if(produto.TipoProduto != null)
            {
                TipoProduto = new TipoProdutoDto(produto.TipoProduto);
            }

            if(produto.SituacaoProduto != null)
            {
                SituacaoAtual = new SituacaoProdutoDto(produto.SituacaoProduto);
            }
        }

        public ProdutoDto()
        {
            DataInvestimento = DateTime.Now;
        }
        
    }
}
public class RequiredIfDataAttribute : ValidationAttribute
{
    RequiredAttribute _innerAttribute = new RequiredAttribute();
    public string _dependentProperty { get; set; }
    public string _targetValue { get; set; }

    public RequiredIfDataAttribute(string dependentProperty, string propriedadeTestada)
    {
        this._dependentProperty = dependentProperty;
        this._targetValue = propriedadeTestada;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var field = validationContext.ObjectType.GetProperty(_dependentProperty);
        var field2 = validationContext.ObjectType.GetProperty(_dependentProperty);
        if (field != null)
        {
            var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
            if (field2 != null)
            {
                var consequentValue = field2.GetValue(validationContext.ObjectInstance, null);
                var dataInicial = Convert.ToDateTime(dependentValue);
                var dataFinal = Convert.ToDateTime(consequentValue);
                if ((dependentValue == null) || (DateTime.Compare(dataInicial, dataFinal) > 0))
                {
                    if (!_innerAttribute.IsValid(value))
                    {
                        string name = validationContext.DisplayName;
                        return new ValidationResult(ErrorMessage = name + " Data Resgate deve ser maior que data investimento.");
                    }
                }
            }
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult(FormatErrorMessage(_dependentProperty));
        }
    }
}
