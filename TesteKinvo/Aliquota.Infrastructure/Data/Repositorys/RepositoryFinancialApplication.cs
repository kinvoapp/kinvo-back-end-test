using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Entitys;

namespace Aliquota.Infrastructure.Data.Repositorys
{
    public class RepositoryFinancialApplication : RepositoryBase<FinancialApplication>, IRepositoryFinancialApplication
    {
        private readonly SqlContext sqlContext;

        public RepositoryFinancialApplication(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
