using FluentValidation;
using Kinvo.Aliquota.Domain.Entities.Products;
using Kinvo.Aliquota.Models.Products;
using Kinvo.Aliquota.Validators.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinvo.Aliquota.Domain.Database.Interfaces.Products;

namespace Kinvo.Aliquota.Validators.Products
{
    public class ProductValidator : AbstractValidator<ProductRequest>, IProductValidator
    {
        private readonly IProductRepository _productRepository;
        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private void GeneralValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required").NotNull().WithMessage("Name is required")
                    .MaximumLength(200).WithMessage("Maximum lengh must be 200 caracteres");

            RuleFor(x => x.Income)
                .NotEmpty().WithMessage("Income is required").NotNull().WithMessage("Income is required");
        }

        public async Task ValidateCreation(ProductRequest request)
        {
            GeneralValidator();
        }

        public async Task<Product> ValidateEdit(Guid? uuid, ProductRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> ValidateRemove(Guid? uuid)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Product> ValidateUuid(Guid? uuid)
        {
            if (!uuid.HasValue)
            {
                throw new ArgumentException("Uuid is required");
                return null;
            }

            var obj = await _productRepository.FindAsync(uuid.Value);

            return obj;

        }
    }
}
