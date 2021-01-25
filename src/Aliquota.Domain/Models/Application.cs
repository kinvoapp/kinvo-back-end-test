using Aliquota.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Models
{
    public class Application : Entity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? WithdrawnAt { get; set; }
    }
}
