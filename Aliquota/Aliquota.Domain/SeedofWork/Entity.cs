using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.SeedofWork
{
    public class Entity
    {
        public int Id { get; set; }

        private IList<INotification> _domainEvents;
        public void AddDomainEvent(INotification domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
        }

        public void RemoveDomainEvent(INotification domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvent()
        {
            _domainEvents?.Clear();
        }
    }
}
