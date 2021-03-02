using Aliquota.Domain.AggregatesModel.AplicacaoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Infrastructure.Repositories
{
    public class AplicacaoRepository : IAplicacaoRepository
    {
        private readonly AliquotaContext context;

        public AplicacaoRepository(AliquotaContext context)
        {
            this.context = context;
        }

        public Aplicacao Add(Aplicacao aplicacao)
        {
            return context.aplicacoes.Add(aplicacao).Entity;
        }

        public Aplicacao GetAplicacaoById(int id)
        {
            Aplicacao aplicacao = context.aplicacoes
                                            .Where(x => x.Id == id)
                                            .FirstOrDefault();
            return aplicacao;
        }

        public void Remove(Aplicacao aplicacao)
        {
            context.Remove(aplicacao);
        }

        public void Update(Aplicacao aplicacao)
        {
            context.Entry(aplicacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
    }
}
