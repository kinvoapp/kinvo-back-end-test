using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Factories
{
    class ProductRescueFactory
    {
        public ProductRescue BuildNewProductRescue(Guid productApplicationID)
        {
            DateTime dateRescue = DateTime.Now;
            ProductRescue productRescue = new ProductRescue(productApplicationID, dateRescue);
            return productRescue;
        }
    }
}
