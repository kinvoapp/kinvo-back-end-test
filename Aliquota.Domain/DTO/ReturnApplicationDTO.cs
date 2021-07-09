using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.DTO
{
    public class ReturnApplicationDTO
    {
        public int ClientId { get; set; }
        public decimal Value { get; set; }
        public DateTime ApplicationDate { get; set; }
        
    }
}
