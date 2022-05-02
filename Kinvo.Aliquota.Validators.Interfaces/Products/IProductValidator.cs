using Kinvo.Aliquota.Domain.Entities.Products;
using Kinvo.Aliquota.Models.Products;
using Kinvo.Aliquota.Validators.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Validators.Interfaces.Products
{
    public interface IProductValidator : IBaseValidator<Product, ProductRequest>
    {
    }
}
