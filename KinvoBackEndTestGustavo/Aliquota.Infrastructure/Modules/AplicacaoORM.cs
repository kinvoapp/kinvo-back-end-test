using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.Shared;
using Aliquota.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Infrastructure.Modules
{
    public class AplicacaoORM : RepositoryBase<Aplicacao>, IRepository<Aplicacao>
    {
        public AplicacaoORM(AliquotaDBContext db) : base(db)
        {
        }

        public override List<Aplicacao> SelecionartTodos()
        {
            return db.Aplicacoes
                .Include(x => x.Produto)
                .ToList<Aplicacao>();
        }
    }
}