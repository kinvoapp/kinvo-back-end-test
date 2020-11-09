using Aliquota.Domain.Entities;
using Aliquota.Infraestructure.DBConfiguration;
using Aliquota.Infraestructure.Interfaces.Repositories.Domain;
using Aliquota.Infraestructure.Repositories.Standard;

namespace Aliquota.Infraestructure.Repositories
{
    public class AplicacaoFinanceiraRepository : DomainRepository<AplicacaoFinanceira>, IAplicacaoFinanceiraRepository
    {
        public AplicacaoFinanceiraRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
