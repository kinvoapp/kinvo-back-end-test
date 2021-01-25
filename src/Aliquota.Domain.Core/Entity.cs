using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Core
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public override string ToString()
        {
            return GetType().Name + $"[Id = {Id} ]";
        }
    }
}
