using Aliquota.Application.ViewModels;
using System.Threading.Tasks;

namespace Aliquota.Application.Interfaces
{
    public interface IAdicionarProdutoFinanceiroService
    {
        Task<bool> Adicionar(CriarProdutoFinanceiroViewModel produtoFinanceiroViewModel);
    }
}