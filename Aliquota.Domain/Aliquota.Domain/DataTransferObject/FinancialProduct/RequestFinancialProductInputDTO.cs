using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.DataTransferObject.Entities.FinancialProduct
{
    class RequestFinancialProductInputDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Percentage { get; set; }

    }
  
}
