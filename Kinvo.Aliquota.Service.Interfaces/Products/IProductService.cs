using Kinvo.Aliquota.Domain.Entities.Products;
using Kinvo.Aliquota.Models.Products;
using Kinvo.Aliquota.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Service.Interfaces.Products
{
    public interface IProductService : IBaseService<Product>
    {
        Task<ProductResponse> Create(ProductRequest productRequest);

        Task<ProductResponse> Edit(Guid? Uuid, ProductRequest request);

        Task Remove(Guid? Uuid);

        Task<List<ProductResponse>> List();
    }
}
