using Aliquota.Domain.Models;
using Aliquota.Domain.Repositorios.ProdutoFinanceiroRp;
using Aliquota.Domain.Servicos.CalculoIR;
using Aliquota.Domain.Servicos.ProdutoFinanceiroSv.ValidacaoResgate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Servicos.ProdutoFinanceiroSv
{
    public class ProdutoFinanceiroServico : IProdutoFinanceiroServico
    {
        private IProdutoFinanceiroRepositorio _repositorio;
        private ICalculadorIR _calculadorIR;
        private IValidadorDataResgate _validadorDataResgate;

        public ProdutoFinanceiroServico(IProdutoFinanceiroRepositorio repositorio,
                                            ICalculadorIR calculadorIR, IValidadorDataResgate validaDataResgate)
        {
            _repositorio = repositorio;
            _calculadorIR = calculadorIR;
            _validadorDataResgate = validaDataResgate;
        }

        public async Task<ProdutoFinanceiro> BuscaProdutoFinanceiroPor(Guid id)
        => await _repositorio.BuscaProdutoFinanceiroPor(id);

        public async Task<IEnumerable<ProdutoFinanceiro>> BuscarTodos()
        => await _repositorio.BuscarTodos();

        public async Task CadastraProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        => await _repositorio.SalvaProdutoFinanceiro(produtoFinanceiro);

        public async Task DeletaProdutoFinanceiro(ProdutoFinanceiro produtoFinanceiro)
        => await _repositorio.DeletaProdutoFinanceiro(produtoFinanceiro);

        public async Task ResgataProdutoFinanceiro(string dataResgate, ProdutoFinanceiro produtoFinanceiro)
        {
            var dataResgateValida = _validadorDataResgate
                                            .ValidaDataResgate(dataResgate, produtoFinanceiro.DataAplicacao);
            produtoFinanceiro.Resgatar(_calculadorIR,dataResgateValida);
            await _repositorio.AtualizaProdutoFinanceiro(produtoFinanceiro);
        }
    }
}
