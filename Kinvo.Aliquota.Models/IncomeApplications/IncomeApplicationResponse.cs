using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Models.Clients;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateWithdrawals;
using Kinvo.Aliquota.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.IncomeApplications
{
    [AutoMap(typeof(IncomeApplication))]
    public class IncomeApplicationResponse
    {
        public Guid Uuid { get; set; }
        public ClientResponse Client { get; set; }
        public ProductResponse Product { get; set; }

        public long AppliedValue { get; set; }

        public long? DailyProfit { get; set; }

        public long? TotalProfit { get; set; }

        public List<DateIncomeApplicationResponse> DateIncomeApplication { get; set; }

        public List<DateWithdrawalResponse> DateWithdrawal { get; set; }

        public bool Ativo { get; set; }
    }
}
