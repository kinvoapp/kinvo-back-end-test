using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Aliquota.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Application.Mapper
{
    public class MapperProduct : IMapperProduct
    {
        public Product MapperDtoToEntity(ProductDto productDto)
        {
            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                YieldRate = productDto.YieldRate
            };

            return product;
        }
        public ProductDto MapperEntityToDto(Product product)
        {
            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                YieldRate = product.YieldRate
            };

            return productDto;
        }
        public IEnumerable<ProductDto> MapperListProductsDto(IEnumerable<Product> products)
        {
            var dto = products.Select(p => new ProductDto
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                            YieldRate = p.YieldRate
                                        });
            return dto;
        }
    }
}
