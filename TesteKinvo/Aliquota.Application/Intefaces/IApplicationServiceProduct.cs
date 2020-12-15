using Aliquota.Application.Dtos;
using System.Collections.Generic;

namespace Aliquota.Application.Intefaces
{
    public interface IApplicationServiceProduct
    {
        void Add(ProductDto productDto);
        void Update(ProductDto productDto);
        void Remove(ProductDto productDto);
        IEnumerable<ProductDto> GetAll();
        ProductDto GetById(int id);
    }
}
