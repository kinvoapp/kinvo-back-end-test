using Aliquota.Application.Interface;
using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Service
{
    public class ClienteAppService : AppServiceBase, IAplicacaoFinanceiraAppService
    {
        private readonly IAplicacaoFinanceiraService Service;
        public ClienteAppService(IAplicacaoFinanceiraService service)
        {
            Service = service;
        }

        public async Task<IList<AplicacaoFinanceira>> Handle(string nomeCliente)
        {
            var listAplicacoes = await Service.GetAll();
            var listAplicacoesCliente = listAplicacoes.Where(x => x.Cliente.Nome == nomeCliente).Select(x => x);

            return listAplicacoesCliente.ToList();

        }

        public Task<AplicacaoFinanceira> Handle(Cliente cliente, decimal valor, ProdutoFinanceiro produto)
        {
            throw new NotImplementedException();
        }
    }
}
