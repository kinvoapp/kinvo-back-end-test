using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entitys
{
    public class Product : BaseClass
    {
        public string Name { get; set; }
        public decimal YieldRate { get; set; }
    }
}
