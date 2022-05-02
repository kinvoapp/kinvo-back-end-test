using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.Products;
using Kinvo.Aliquota.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.Products
{
    [AutoMap(typeof(Product))]
    public class ProductRequest
    {
        [Searchable]
        public string Name { get; set; }

        public float Income { get; set; }
    }
}
