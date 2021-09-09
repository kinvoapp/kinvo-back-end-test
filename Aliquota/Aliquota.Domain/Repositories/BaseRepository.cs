using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly AliquotaContext context;
        protected readonly DbSet<T> dbSets;

        public BaseRepository(AliquotaContext context)
        {
            this.context = context;
            this.dbSets = this.context.Set<T>();
        }
    }
}
