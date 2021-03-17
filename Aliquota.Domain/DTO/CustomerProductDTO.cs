using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.DTO
{
    public class CustomerProductDTO
    {

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }


}
