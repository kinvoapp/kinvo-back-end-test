using Aliquota.Domain.Entities.Financial;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.FinancialModule
{
    public class MovementBase : BaseEntity
    {

        public Tax Tax { get; set; }

    }
}
