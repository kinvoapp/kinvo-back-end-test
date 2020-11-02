
using System;

namespace Income.Tax.Willian.Santos.Kinvo.Shared.Entities
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get;  set; }
    }
}
