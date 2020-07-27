using Aliquota.Domain.Entities;
using Aliquota.Domain.Services.Interfaces;
using System;
using Aliquota.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Services
{
    public class ProdutoService: IProdutoService
    {

        private readonly IAplicacaoRepository _aplicacaoRepository;

        public ProdutoService(IAplicacaoRepository aplicacaoRepository)
        {
            _aplicacaoRepository = aplicacaoRepository;
        }

        public Aplicacao ObterPorId(Guid id)
        {
            return _aplicacaoRepository.ObterPorId(id);
        }

        public IEnumerable<Aplicacao> ObterTodos()
        {
            return _aplicacaoRepository.ObterTodos();
        }

        public Aplicacao Aplicar(Aplicacao aplicacao)
        {
            if (!aplicacao.EValida())
            {
                throw new Exception("Valor da aplicação precisa ser maior do que zero.");
            }

            return _aplicacaoRepository.Inserir(aplicacao);
        }

        public Resgate Resgatar(Aplicacao aplicacao, DateTime dataResgate)
        {
            if (!aplicacao.PodeResgatar(dataResgate))
            {
                throw new Exception($"Data de resgate deve ser superior a data da aplicação {aplicacao.Data.ToString("dd / MM / yyyy HH: mm:ss")}.");
            }

            aplicacao.Resgatar(dataResgate);

            var aplicacaoResult = _aplicacaoRepository.Atualizar(aplicacao);

            return aplicacaoResult.Resgate;
        }

        public IEnumerable<Resgate> ResgatarTodosDisponiveis(DateTime dataResgate)
        {
            var aplicacoesNaoResgatadas = _aplicacaoRepository.ObterTodos(x => !x.Resgatado && dataResgate > x.Data);

            return aplicacoesNaoResgatadas.Select(x => Resgatar(x, dataResgate));
        }
    }
}
