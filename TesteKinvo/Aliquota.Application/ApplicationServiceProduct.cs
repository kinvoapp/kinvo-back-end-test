using Aliquota.Application.Dtos;
using Aliquota.Application.Intefaces;
using Aliquota.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Application
{
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {
        private readonly IServiceProduct serviceProduct;
        private readonly IMapperProduct mapperProduct;

        public ApplicationServiceProduct(IServiceProduct serviceProduc,
                                          IMapperProduct mapperProduct)
        {
            this.serviceProduct = serviceProduc;
            this.mapperProduct = mapperProduct;
        }
        public void Add(ProductDto productDto)
        {
            var product = mapperProduct.MapperDtoToEntity(productDto);
            serviceProduct.Add(product);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = serviceProduct.GetAll();
            return mapperProduct.MapperListProductsDto(products);
        }

        public ProductDto GetById(int id)
        {
            var product = serviceProduct.GetById(id);
            return mapperProduct.MapperEntityToDto(product);
        }

        public void Remove(ProductDto productDto)
        {
            var product = mapperProduct.MapperDtoToEntity(productDto);
            serviceProduct.Remove(product);
        }

        public void Update(ProductDto productDto)
        {
            var product = mapperProduct.MapperDtoToEntity(productDto);
            serviceProduct.Update(product);
        }
    }
}
