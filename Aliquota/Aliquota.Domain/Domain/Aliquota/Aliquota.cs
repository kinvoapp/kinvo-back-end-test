using Aliquota.Domain.SeedofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Domain.Aliquota
{
    public class Aliquota:Entity
    {
        public string Guid { get; set; }
        public decimal Percentual { get; set; }

    }
}
