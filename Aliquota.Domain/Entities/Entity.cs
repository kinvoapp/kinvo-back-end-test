using System;
using Flunt.Notifications;

namespace Aliquota.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
