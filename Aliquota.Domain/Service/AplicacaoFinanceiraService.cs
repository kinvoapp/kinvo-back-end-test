using Aliquota.Domain.Entity;
using Aliquota.Domain.Interface;
using Aliquota.Domain.Interface.Repository;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Aliquota.Domain.Service
{
    public class AplicacaoFinanceiraService : ServiceBase<AplicacaoFinanceira>, IAplicacaoFinanceiraService
    {
        public AplicacaoFinanceiraService(IAplicacaoFinanceiraRepository repository) : base(repository) { }

        public async Task<decimal> ConsultarMontante(Guid clienteId)
        {
            var resultado = (await (Repository as IAplicacaoFinanceiraRepository)
                .Get(x => x.Cliente.Id == clienteId)).Sum(x => x.Valor);
            return resultado;
        }
        public decimal GetTaxaIR(double tempo)
        {
            if (tempo > 720)
                return 0.15M;
            else if (tempo >= 361 && tempo <= 720)
                return 0.185M;
            return 0.225M;
        }
        public async Task<decimal> GerarResgateTotal(Guid aplicacaoId)
        {
            var aplicacao = await GetById(aplicacaoId);
            var tempoAplicacao = (DateTime.Today - aplicacao.DataAplicacao).TotalDays;
            var taxaIr = GetTaxaIR(tempoAplicacao);
            var rendimento = (aplicacao.Valor * aplicacao.Produto.TaxaRedendimento) / 100;
            var valorIr = rendimento * taxaIr;
            aplicacao.Valor = 0;
            aplicacao.DataRetirada = DateTime.Today;
            await this.Update(aplicacao);
            return aplicacao.Valor + rendimento - valorIr;
        }
        public async Task<AplicacaoFinanceira> Aplicar(Cliente cliente, decimal valor, ProdutoFinanceiro produto)
        {
            var aplicacao = new AplicacaoFinanceira(cliente, produto, DateTime.Today, null, valor);
            var resultado = await this.Create(aplicacao);
            //asdsada
            return resultado;
        }
    }
}
