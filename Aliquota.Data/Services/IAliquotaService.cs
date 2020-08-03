using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aliquota.Domain.Model;

namespace Aliquota.Data.Services
{
    public interface IAliquotaService
    {
        Task<bool> AdicionarProduto(uint id, string nome, decimal taxa, DateTime vencimento);
        Task<bool> ExistProdutoByIdAsync(uint id);
        Task<Produto> GetProdutoByIdAsync(uint id);

        Task<bool> AdicionarCarteira(string nome);
        Task<bool> ExistCarteiraByNomeAsync(string nome);
        Task<Carteira> GetCarteiraByNomeAsync(string nome);
        Task<Carteira> GetCarteiraByNomeAsync(Guid id);


        Task<bool> AdicionarInvestimento(uint ProdutoId, Guid CarteiraId, decimal valor);
        Task<bool> ExistInvestimentoByIdAsync(Guid id);
        Task<Investimento> GetInvestimentoByIdAsync(Guid id);

        Task<List<Produto>> GetProdutosAsync();
        Task<List<Investimento>> GetInvestimentosAsync(Guid CarteiraId);

        Task<Object> RealizarSaqueInvestimento(Guid InvestimentoId,DateTime dataSaque);
    }
}
