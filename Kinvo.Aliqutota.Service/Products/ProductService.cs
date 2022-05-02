using AutoMapper;
using Kinvo.Aliquota.Domain.Database.Interfaces.Products;
using Kinvo.Aliquota.Domain.Entities.Products;
using Kinvo.Aliquota.Models.Products;
using Kinvo.Aliquota.Service.Interfaces.Products;
using Kinvo.Aliquota.Validators.Interfaces.Products;
using Kinvo.Aliqutota.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliqutota.Service.Products
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductValidator _productValidator;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IProductValidator productValidator, IMapper mapper)
            : base(productRepository)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Create(ProductRequest productRequest)
        {
            var client = _mapper.Map<Product>(productRequest);

            _productRepository.Insert(client);
            return _mapper.Map<ProductResponse>(client);

        }

        public async Task<ProductResponse> Edit(Guid? Uuid, ProductRequest productRequest)
        {

            var client = await _productRepository.FindAsync(Uuid.Value);

            client.ModificationDate = DateTime.Now;
            client.Name = productRequest.Name;
            client.Income = productRequest.Income;
         
            _productRepository.Update(client);
            return _mapper.Map<ProductResponse>(client);
        }

        public async Task Remove(Guid? Uuid)
        {
            var obj = await _productRepository.FindAsync(Uuid.Value);

            _productRepository.Delete(obj.Id);

            return;

        }

        public async Task<List<ProductResponse>> List()
        {
            var obj = await _productRepository.ListAsync();
            List<ProductResponse> response = _mapper.Map<List<ProductResponse>>(obj);

            return response;


        }
    }
}
