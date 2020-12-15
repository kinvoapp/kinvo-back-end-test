using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Entitys;

namespace Aliquota.Infrastructure.Data.Repositorys
{
    public class RepositoryClient : RepositoryBase<Client>, IRepositoryClient
    {
        private readonly SqlContext sqlContext;

        public RepositoryClient(SqlContext sqlContext)
            :base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
