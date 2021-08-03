using System;

namespace Aliquota.Domain.Entidades.Base
{
    public abstract class EntidadeBase<ChavePrimaria>
    {
        public ChavePrimaria Id { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}#{Id}";
        }
    }

    public abstract class EntidadeBase : EntidadeBase<Guid>
    {
    }
}