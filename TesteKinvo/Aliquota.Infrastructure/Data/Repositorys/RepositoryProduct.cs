using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Entitys;

namespace Aliquota.Infrastructure.Data.Repositorys
{
   public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        private readonly SqlContext sqlContext;
        public RepositoryProduct(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
