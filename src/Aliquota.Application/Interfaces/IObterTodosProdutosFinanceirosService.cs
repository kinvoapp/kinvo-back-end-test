using Aliquota.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Interfaces
{
    public interface IObterTodosProdutosFinanceirosService
    {
        Task<List<ProdutoFinanceiroViewModel>> ObterTodos();
    }
}
