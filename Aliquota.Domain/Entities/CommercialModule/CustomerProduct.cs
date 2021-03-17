using Aliquota.Domain.Entities.Financial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities.Commercial
{
    public class CustomerProduct: BaseEntity
    {

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
