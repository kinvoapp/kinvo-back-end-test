using Aliquota.Application.Dtos;
using Aliquota.Domain.Entitys;
using System.Collections.Generic;

namespace Aliquota.Application.Intefaces
{
    public interface IMapperProduct
    {
        Product MapperDtoToEntity(ProductDto productDto);
        IEnumerable<ProductDto> MapperListProductsDto(IEnumerable<Product> products);
        ProductDto MapperEntityToDto(Product product);
    }
}
