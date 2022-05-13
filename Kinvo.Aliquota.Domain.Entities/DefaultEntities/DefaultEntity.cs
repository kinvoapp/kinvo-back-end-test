using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Entities.DefaultEntities
{
    public class DefaultEntity
    {
        public DefaultEntity()
        {
            this.Uuid = Guid.NewGuid();
            this.Active = true;
        }
        public virtual Guid Uuid { get; set; }

        public virtual long Id { get; set; }

        public virtual bool Active { get; set; }

        public virtual DateTime CreationDate { get; set; } = DateTime.Now;

        public virtual DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
