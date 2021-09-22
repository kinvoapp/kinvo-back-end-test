using System;
using System.Linq.Expressions;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Queries
{
    public class ProductsQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
