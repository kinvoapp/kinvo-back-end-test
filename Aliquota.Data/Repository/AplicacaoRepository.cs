using Aliquota.Data.Context;
using Aliquota.Domain.Interfaces;
using Aliquota.Domain.Models;

namespace Aliquota.Data.Repository
{
    public class AplicacaoRepository : Repository<Aplicacao>, IAplicacaoRepository
    {
        public AplicacaoRepository(DADbContext context) : base(context) { }
    }
}
