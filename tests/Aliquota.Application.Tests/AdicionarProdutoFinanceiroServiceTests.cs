using Aliquota.Application.Services;
using Aliquota.Application.ViewModels;
using Aliquota.Domain.Models;
using AutoMapper;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Application.Tests
{
    public class AdicionarProdutoFinanceiroServiceTests
    {
        [Trait("Categoria", "Adicionar Produto Financeiro Service")]
        [Fact(DisplayName = "")]
        public async Task AdicionarProdutoFinanceiroService_Adicionar_DevePassarViewModelParaOMapper()
        {
            var mock = new AutoMocker();
            var autoMapperMock = mock.GetMock<IMapper>();

            var produtoFinanceiroViewModel = new ProdutoFinanceiroViewModel
            {
                Aplicacao = 1000,
                DataAplicacao = new DateTime(2020 - 01 - 01),
                Lucro = 10,
                DataResgate = new DateTime(2021 - 01 - 01)
            };

            var produtoFinanceiro = new ProdutoFinanceiro(1000, new DateTime(2020-01-01), 10, new DateTime(2021-01-01));

            autoMapperMock
                .Setup(m => m.Map(produtoFinanceiroViewModel, It.IsAny<Action<IMappingOperationOptions<ProdutoFinanceiroViewModel, ProdutoFinanceiro>>>()))
                .Returns(produtoFinanceiro);

            var sut = mock.CreateInstance<AdicionarProdutoFinanceiroService>();

            var result = await sut.Adicionar(produtoFinanceiroViewModel);


        }
    }
}
