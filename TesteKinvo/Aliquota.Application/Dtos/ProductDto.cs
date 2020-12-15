using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal YieldRate { get; set; }
    }
}
