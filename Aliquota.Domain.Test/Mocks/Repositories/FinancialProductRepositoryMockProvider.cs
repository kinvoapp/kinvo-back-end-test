using System;
using System.Collections.Generic;
using Aliquota.Domain.Contracts.Repositories;
using Aliquota.Domain.Entities;
using Moq;

namespace Aliquota.Domain.Test.Mocks
{
    public static class FinancialProductRepositoryMockProvider
    {
        public static FinancialProduct GetStandardFinancialProduct() 
        {
            var financialProduct = new FinancialProduct()
            {
                Name = "TELEX FREE", // Because its a fake
            };

            return financialProduct;
        }

        public static Mock<IFinancialProductRepository> GetNewMock()
        {
            var mock = new Mock<IFinancialProductRepository>();

            mock.Setup(r => r.GetProductAsync(It.IsAny<Guid>())).ReturnsAsync(GetStandardFinancialProduct());
            mock.Setup(r => r.GetProductsAsync()).ReturnsAsync(new List<FinancialProduct>() { GetStandardFinancialProduct() });
            return mock;
        }   
    }
}