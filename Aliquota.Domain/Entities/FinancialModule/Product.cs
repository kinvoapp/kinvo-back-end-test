using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Entities.Financial
{
    public class Product : BaseEntity
    {

        public String NmProduct { get; set; }
        public String Ticker { get; set; }
        public DateTime DtRegister { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal VlProfit { get; set; }

        public List<MovementApplication> Applications { get; set; }
        public List<MovementRescue> Rescues { get; set; }

        public List<Tax> Taxes { get; set; }
    }
}
