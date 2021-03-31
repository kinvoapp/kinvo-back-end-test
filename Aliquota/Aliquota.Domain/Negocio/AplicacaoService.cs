using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Negocio
{
    public class AplicacaoService : IAplicacaoService
    {
        IUnitOfWork _unitOfWork;

        public AplicacaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Aplicacao item)
        {
            if (!ValidarAplicacao(item))
                throw new ApplicationException("Valor da aplicação deve ser maior que 0 (zero).");

            _unitOfWork.Aplicacoes.Add(item);
            _unitOfWork.Complete();
        }

        public void Edit(Aplicacao item)
        {
            _unitOfWork.Aplicacoes.Update(item);
            _unitOfWork.Complete();
        }

        public async Task<Aplicacao> Find(Guid id)
        {
            return await _unitOfWork.Aplicacoes.Get(id);
        }

        public Task<IEnumerable<Aplicacao>> List()
        {
            return _unitOfWork.Aplicacoes.GetAll();
        }

        public decimal ObterAlicotaImposto(Aplicacao aplicacao, DateTime dataResgate)
        {
            int diasAplicado = (dataResgate - aplicacao.DataAplicacao).Days;
            if (!aplicacao.ProdutoFinanceiro.Aliquotas.Any(x => x.Key > diasAplicado))
                return (decimal)aplicacao.ProdutoFinanceiro.AliquotaDefault;

            Double alicota = aplicacao.ProdutoFinanceiro.Aliquotas.Where(x => x.Key > diasAplicado).OrderBy(x => x.Key).First().Value;
            return (decimal)alicota;

        }

        public decimal ObterImpostoARecolher(Aplicacao aplicacao, DateTime dataResgate)
        {
            decimal variacao = ObterLucroAplicacao(aplicacao);

            if (variacao < 0)
                return 0;

            decimal alicota = ObterAlicotaImposto(aplicacao, dataResgate);
            return variacao * (alicota / 100);
        }

        private static decimal ObterLucroAplicacao(Aplicacao aplicacao)
        {
            decimal valorAtual = aplicacao.Quantidade * aplicacao.ProdutoFinanceiro.Cotacao;
            decimal variacao = valorAtual - aplicacao.ValorAplicado;
            return variacao;
        }

        public void Remove(Aplicacao item)
        {
            _unitOfWork.Aplicacoes.Delete(item);
            _unitOfWork.Complete();
        }

        public bool ValidarAplicacao(Aplicacao aplicacao)
        {
            if (aplicacao == null)
                return false;

            if (aplicacao.ValorAplicado <= 0)
                return false;

            if (aplicacao.Quantidade <= 0)
                return false;

            return true;
        }

        public bool ValidarResgate(Aplicacao aplicacao, DateTime dataResgate)
        {
            if (aplicacao.DataAplicacao > dataResgate)
                return false;

            return true;
        }

        public void Resgatar(Aplicacao aplicacao, DateTime dataResgate)
        {
            if (!ValidarResgate(aplicacao, dataResgate))
                throw new ApplicationException("Data de resgate deve ser maior que a data da aplicação");

            Remove(aplicacao);

        }
    }
}
