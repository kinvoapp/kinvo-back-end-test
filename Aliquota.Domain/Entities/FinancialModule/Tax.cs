using Aliquota.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entities.Financial
{
    public class Tax : BaseEntity
    {

        public string NmTax { get; set; }
        public TaxAction TaxAction { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal VlPercentageDiscount { get; set; }

        public int QtMinDayDiscount { get; set; }

        public int QtMaxDayDiscount { get; set; }

        public Product Product { get; set; }
    }
}
