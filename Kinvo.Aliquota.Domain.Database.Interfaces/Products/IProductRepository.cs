using Kinvo.Aliquota.Domain.Database.Interfaces.BaseRepository;
using Kinvo.Aliquota.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Database.Interfaces.Products
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
