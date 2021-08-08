using Aliquota.WebApp.Models.ProdutoFinanceiroViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProdutoFinanceiroControllerNovo
    {
        [Fact]
        public void ProdutoFinanceiroFormVMComValorDeAplicacaoIgualAZeroEInvalido()
        {
            var erros = new List<ValidationResult>();

            var produtoFinanceiroViewModel = new ProdutoFinanceiroFormVM()
            {
                ValorAplicado = 0,
                TipoProdutoFinanceiroFk = Guid.NewGuid()
            };

            var retorno = Validator.TryValidateObject(produtoFinanceiroViewModel, new ValidationContext(produtoFinanceiroViewModel), erros, true);

            Assert.False(retorno);
            Assert.Equal(nameof(produtoFinanceiroViewModel.ValorAplicado), erros[0].MemberNames.First());
        }

        [Fact]
        public void ProdutoFinanceiroFormVMComValorDeAplicacaoMenorQueZeroEInvalido()
        {
            var erros = new List<ValidationResult>();

            var produtoFinanceiroViewModel = new ProdutoFinanceiroFormVM()
            {
                ValorAplicado = -1,
                TipoProdutoFinanceiroFk = Guid.NewGuid()
            };

            var retorno = Validator.TryValidateObject(produtoFinanceiroViewModel, new ValidationContext(produtoFinanceiroViewModel), erros, true);

            Assert.False(retorno);
            Assert.Equal(nameof(produtoFinanceiroViewModel.ValorAplicado), erros[0].MemberNames.First());
        }
    }
}
