using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using Kinvo.Aliquota.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Entities.IncomeApplications
{
    public class IncomeApplication : DefaultEntity
    {
        public long ClientId { get; set; }

        public Client Client { get; set; }

        public long ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public long AppliedValue { get; set; }

        public long? DailyProfit { get; set; }

        public long? TotalProfit { get; set; }

        public List<DateIncomeApplication> DateIncomeApplication { get; set; }

        public List<DateWithdrawal> DateWithdrawal { get; set; }
    }
}
