using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Infra.Contextos.Base
{
    public abstract class ContextoBase : DbContext, IContextoBase
    {
        public abstract string NomeContexto { get; }

        protected ContextoBase(DbContextOptions options)
            : base(options)
        {
        }
    }
}