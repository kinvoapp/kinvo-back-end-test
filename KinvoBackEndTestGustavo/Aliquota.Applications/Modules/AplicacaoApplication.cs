using Aliquota.Applications.Shared;
using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.Shared;
using System.Collections.Generic;

namespace Aliquota.Applications.Modules
{
    public class AplicacaoApplication : ApplicationBase<Aplicacao>
    {
        private readonly IRepository<Aplicacao> AplicacaoRepository;
        public AplicacaoApplication(IRepository<Aplicacao> aplicacaoRepository)
        {
            AplicacaoRepository = aplicacaoRepository;
        }

        public override bool AddEntidade(Aplicacao aplicacao)
        {
            bool resultado = AplicacaoRepository.InserirNovo(aplicacao);
            return resultado;
        }

        public override bool EditarEntidade(int id, Aplicacao aplicacao)
        {
            bool resultado = AplicacaoRepository.Resgatar(id, aplicacao);
            return resultado;
        }

        public override List<Aplicacao> SelecionarTodasEntidades()
        {
            List<Aplicacao> aplicacoes = AplicacaoRepository.SelecionartTodos();
            return aplicacoes;
        }

        public override Aplicacao SelecionarEntidadePorId(int id)
        {
            Aplicacao aplicacao = AplicacaoRepository.SelecionarPorId(id);
            return aplicacao;
        }
    }
}
