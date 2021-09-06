using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Base : Notify
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
