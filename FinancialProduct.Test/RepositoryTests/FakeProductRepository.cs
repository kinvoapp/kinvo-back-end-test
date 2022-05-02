

using System;
using System.Collections.Generic;
using FinancialProduct.Domain.Entities;
using FinancialProduct.Domain.Repositories;

namespace FinancialProduct.Test.RepositoryTests;

public class FakeProductRepository : IProductRepository
{
    public void Create(Product product)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAllQuery(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAllQueryRescued(string user)
    {
        throw new NotImplementedException();
    }

    public Product GetById(Guid id)
    {
         throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
